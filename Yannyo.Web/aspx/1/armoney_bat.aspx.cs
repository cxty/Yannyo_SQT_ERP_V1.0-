using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using Yannyo.Config;
using Yannyo.Common;
using Yannyo.Entity;
using Yannyo.BLL;

namespace Yannyo.Web
{
    public partial class armoney_bat : PageBase
    {
        public int ARObjType = 0;
        public int loop_count = 0;
        public string Act = "";
        public DateTime eDate = DateTime.Now;

        protected virtual void Page_Load(object sender, EventArgs e)
        {
            if (this.userid > 0)
            {
                if (CheckUserPopedoms("X") || CheckUserPopedoms("6-3"))
                {
                    Act = HTTPRequest.GetString("Act");
                    if (ispost)
                    {
                        if (Act == "OK")
                        {
                            eDate = DateTime.Parse(HTTPRequest.GetString("eDate"));
                            loop_count = HTTPRequest.GetInt("loop_count_obj", 0);
                            if (loop_count > 0)
                            {
                                int ARObjID = 0;
                                DateTime aOpenDate = DateTime.Now;
                                decimal aOpenMoney = 0;
                                DateTime aDate = DateTime.Now;
                                DateTime aActualDate = DateTime.Now;
                                decimal aAMoney = 0;
                                decimal aBMoney = 0;
                                decimal aActualMoney = 0;
                                ARObjType = HTTPRequest.GetInt("ARObjType", 0);

                                ARMoneyInfo ar = new ARMoneyInfo();

                                int tCount = 0;
                                string odIDStr = "";

                                for (int i = 0; i < loop_count; i++)
                                {
                                    ARObjID = HTTPRequest.GetInt("ARObjID_" + i, 0);
                                    if (ARObjID > 0)
                                    {
                                        aAMoney = decimal.Parse(HTTPRequest.GetString("aAMoney_" + i).ToString());
                                        aBMoney = decimal.Parse(HTTPRequest.GetString("aBMoney_" + i).ToString());
                                        aOpenMoney = decimal.Parse(HTTPRequest.GetString("aOpenMoney_" + i).ToString());
                                        aActualMoney = decimal.Parse(HTTPRequest.GetString("aActualMoney_" + i).ToString());

                                        aOpenDate = HTTPRequest.GetString("aOpenDate_" + i).Trim() != "" ? DateTime.Parse(HTTPRequest.GetString("aOpenDate_" + i).Trim()) : DateTime.Now;
                                        aDate = HTTPRequest.GetString("aDate_" + i).Trim() != "" ? DateTime.Parse(HTTPRequest.GetString("aDate_" + i).Trim()) : DateTime.Now;
                                        aActualDate = HTTPRequest.GetString("aActualDate_" + i).Trim() != "" ? DateTime.Parse(HTTPRequest.GetString("aActualDate_" + i).Trim()) : DateTime.Now;

                                        ar.ARObjID = ARObjID;
                                        ar.ARObjType = ARObjType;
                                        ar.aAMoney = aAMoney;
                                        ar.aBMoney = aBMoney;
                                        ar.aOpenDate = aOpenDate;
                                        ar.aOpenMoney = aOpenMoney;
                                        ar.aDate = aDate;
                                        ar.aActualDate = aActualDate;
                                        ar.aActualMoney = aActualMoney;
                                        ar.aUpdateTime = DateTime.Now;
                                        ar.aSteps = 1;
                                        ar.aAppendTime = DateTime.Now;

                                        ar.ARMoneyID = tbARMoneyInfo.AddARMoneyInfo(ar);

                                        if (ar.ARMoneyID > 0)//更新,订单状态,并保留操作编号
                                        {
                                            if (ARObjType == 0)//非结算系统
                                            {
                                                //给单据打标记,标明为"已对账"
                                                //取出该客户门店下所有指定订单编号
                                                odIDStr = tbErpOrderInfo.GetErpOrderIDStr(ar.ARObjID, 1, eDate);//发货
                                                odIDStr = odIDStr + "," + tbErpOrderInfo.GetErpOrderIDStr(ar.ARObjID, 5, eDate);//退货
                                                ar.aErpOrderIDStr = odIDStr;

                                                try
                                                {
                                                    tbErpOrderInfo.UpdateErpOrderCheck(ar.ARObjID, 1, eDate, 1);//发货
                                                    tbErpOrderInfo.UpdateErpOrderCheck(ar.ARObjID, 5, eDate, 1);//退货

                                                    tbARMoneyInfo.UpdateARMoneyInfo(ar);
                                                }
                                                catch
                                                {

                                                }
                                            }
                                            else if (ARObjType == 2)//结算系统
                                            {
                                                DataTable _pDataList = tbStoresInfo.GetStoresInfoList(" PaymentSystemID=" + ar.ARObjID + "").Tables[0];
                                                try
                                                {
                                                    if (_pDataList != null)
                                                    {
                                                        foreach (DataRow dr in _pDataList.Rows)
                                                        {
                                                            odIDStr = odIDStr + "," + tbErpOrderInfo.GetErpOrderIDStr(int.Parse(dr["StoresID"].ToString()), 1, eDate);//发货
                                                            odIDStr = odIDStr + "," + tbErpOrderInfo.GetErpOrderIDStr(int.Parse(dr["StoresID"].ToString()), 5, eDate);//退货
                                                            tbErpOrderInfo.UpdateErpOrderCheck(int.Parse(dr["StoresID"].ToString()), 1, eDate, 1);//发货
                                                            tbErpOrderInfo.UpdateErpOrderCheck(int.Parse(dr["StoresID"].ToString()), 5, eDate, 1);//退货
                                                        }
                                                        ar.aErpOrderIDStr = odIDStr;
                                                        try
                                                        {
                                                            tbARMoneyInfo.UpdateARMoneyInfo(ar);
                                                        }
                                                        catch
                                                        {

                                                        }
                                                    }
                                                }
                                                finally
                                                {
                                                    _pDataList.Clear();
                                                }
                                            }
                                            tCount++;
                                        }
                                    }
                                }
                                AddMsgLine("导入成功,共导入 <b>" + tCount + "</b> 条应收数据!");
                                AddScript("window.setTimeout('window.parent.HidBox();',3000);");
                            }
                            else
                            {
                                AddErrLine("没有任何数据插入!");
                                AddScript("window.setTimeout('window.parent.HidBox();',1000);");
                            }
                        }
                    }
                }
                else
                {
                    AddErrLine("权限不足!");
                    AddScript("window.setTimeout('window.parent.HidBox();',1000);");
                }
            }
            else
            {
                AddErrLine("请先登录!");
                SetBackLink("login.aspx?referer=" + Utils.UrlEncode(Utils.GetUrlReferrer()));
                SetMetaRefresh(1, "login.aspx?referer=" + Utils.UrlEncode(Utils.GetUrlReferrer()));
            }
        }
        protected override void ShowPage()
        {
            pagetitle = " 批量添加应收账款";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}
