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
    public partial class armoney_importdata : PageBase
    {
        public decimal tMoney = 0;
        public DataTable dList = new DataTable();
        public string Act = "";
        public DateTime bDate = DateTime.Parse(DateTime.Now.AddMonths(-1).ToString("yyyy-MM-01 00:00:00"));
        public DateTime eDate = DateTime.Parse(DateTime.Now.AddMonths(1).AddDays(DateTime.Now.Day * -1).ToString("yyyy-MM-dd 23:59:59"));
        public int loop_count = 0;

        protected virtual void Page_Load(object sender, EventArgs e)
        {
            Act = HTTPRequest.GetString("Act");
            if (ispost) {
                //if (Act == "Search")
                {
                    if (HTTPRequest.GetString("bDate").Trim() != "")
                    {
                        bDate = DateTime.Parse(HTTPRequest.GetString("bDate").Trim() + " 00:00:00");
                    }
                    if (HTTPRequest.GetString("eDate").Trim() != "")
                    {
                        eDate = DateTime.Parse(HTTPRequest.GetString("eDate").Trim() + " 23:59:59");
                    }
                }
                if (Act == "OK")
                {
                    loop_count = HTTPRequest.GetInt("loop_count",0);
                    if (loop_count > 0)
                    {
                        int StoresID = 0;
                        decimal tMoney = 0;
                        decimal nMoney = 0;

                        ARMoneyInfo ar = new ARMoneyInfo();
                        string odIDStr = "";
                        int tCount = 0;

                        for (int i = 0; i < loop_count; i++)
                        {
                            StoresID = HTTPRequest.GetInt("_StoresID_" + i, 0);
                            if (StoresID > 0)
                            {
                                tMoney = decimal.Parse(HTTPRequest.GetString("_tMoney_" + i).ToString());
                                nMoney = decimal.Parse(HTTPRequest.GetString("_nMoney_" + i).ToString());

                                ar.ARObjID = StoresID;
                                ar.ARObjType = 0;
                                ar.aAMoney = nMoney;
                                ar.aBMoney = tMoney;
                                ar.aOpenDate = DateTime.Now;
                                ar.aOpenMoney = tMoney;
                                ar.aDate = DateTime.Now;
                                ar.aActualDate = DateTime.Now;
                                ar.aActualMoney = 0;
                                ar.aUpdateTime = DateTime.Now;
                                ar.aSteps = 1;
                                ar.aAppendTime = DateTime.Now;

                                ar.ARMoneyID = tbARMoneyInfo.AddARMoneyInfo(ar);

                                if (ar.ARMoneyID > 0)
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
                                    tCount++;
                                }
                            }
                        }
                        AddMsgLine("导入成功,共导入 <b>" + tCount + "</b> 家客户,门店应收数据!");
                        AddScript("window.setTimeout('window.parent.HidBox();',3000);");
                    }
                }
            }
            dList = tbARMoneyInfo.GetErpCustomerPay("","",bDate,eDate);
            if (dList != null)
            {
                dList.Columns.Add("tMoney", typeof(decimal));
                dList.Columns.Add("nMoney", typeof(decimal));
                foreach (DataRow dr in dList.Rows)
                {
                    //实际应收
                    dr["tMoney"] = decimal.Parse(dr["sDoDayMoney"].ToString()) + (decimal.Parse(dr["DeliveryMoney"].ToString()) - decimal.Parse(dr["ReturnMoney"].ToString())) + (decimal.Parse(dr["AMoney"].ToString()) - decimal.Parse(dr["ActualMoney"].ToString()));
                    //新增应收
                    dr["nMoney"] = decimal.Parse(dr["DeliveryMoney"].ToString()) - decimal.Parse(dr["ReturnMoney"].ToString());
                }
            }
            DataView dv = dList.DefaultView;
            dv.Sort = "tMoney desc";
            dList = dv.ToTable();
            /*
            if (Act == "OK")
            {
                ARMoneyInfo ar = new ARMoneyInfo();
                string odIDStr = "";
                int tCount = 0;

                foreach (DataRow dr2 in dList.Rows)
                {
                    if (decimal.Parse(dr2["nMoney"].ToString()) != 0 )
                    {
                        odIDStr = "";

                        ar.ARObjID = int.Parse(dr2["StoresID"].ToString());
                        ar.ARObjType = 0;
                        ar.aAMoney = decimal.Parse(dr2["nMoney"].ToString());
                        ar.aBMoney = decimal.Parse(dr2["tMoney"].ToString());
                        ar.aOpenDate = DateTime.Now;
                        ar.aOpenMoney = decimal.Parse(dr2["tMoney"].ToString());
                        ar.aDate = DateTime.Now;
                        ar.aActualDate = DateTime.Now;
                        ar.aActualMoney = decimal.Parse(dr2["tMoney"].ToString());
                        ar.aUpdateTime = DateTime.Now;
                        ar.aSteps = 0;
                        ar.aAppendTime = DateTime.Now;

                        ar.ARMoneyID = tbARMoneyInfo.AddARMoneyInfo(ar);

                        if (ar.ARMoneyID > 0)
                        {
                            //给单据打标记,标明为"已对账"
                            //取出该客户门店下所有指定订单编号
                            odIDStr = tbErpOrderInfo.GetErpOrderIDStr(ar.ARObjID, 1, eDate);//发货
                            odIDStr = odIDStr +","+ tbErpOrderInfo.GetErpOrderIDStr(ar.ARObjID, 5, eDate);//退货
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
                            tCount++;
                        }
                    }
                }
                AddMsgLine("导入成功,共导入 <b>" + tCount + "</b> 家客户,门店应收数据!");
                AddScript("window.setTimeout('window.parent.HidBox();',3000);");
            }
            */
        }
        protected override void ShowPage()
        {
            pagetitle = " 导入门店,客户应付账款";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}
