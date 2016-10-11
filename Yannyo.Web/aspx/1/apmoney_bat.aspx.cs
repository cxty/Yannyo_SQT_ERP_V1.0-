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
    public partial class apmoney_bat : PageBase
    {
        public int APObjType = 0;
        public int loop_count = 0;
        public string Act = "";
        public DateTime eDate = DateTime.Now;

        protected virtual void Page_Load(object sender, EventArgs e)
        {
            if (this.userid > 0)
            {
                if (CheckUserPopedoms("X") || CheckUserPopedoms("6-4"))
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
                                APObjType = HTTPRequest.GetInt("APObjType", 0);
                                int tCount = 0;

                                APMoneyInfo ap = new APMoneyInfo();
                                int APObjID = 0;
                                decimal nMoney = 0;
                                decimal tMoney = 0;
                                decimal aPayMoney = 0;
                                int FeesSubjectID = 0;
                                string odIDStr = "";
                                DateTime aDoDateTime = DateTime.Now;

                                for (int i = 0; i < loop_count; i++)
                                {
                                    APObjID = HTTPRequest.GetInt("APObjID_" + i, 0);
                                    if (APObjID > 0)
                                    {
                                        nMoney = decimal.Parse(HTTPRequest.GetString("nMoney_" + i).ToString());
                                        tMoney = decimal.Parse(HTTPRequest.GetString("tMoney_" + i).ToString());
                                        aPayMoney = decimal.Parse(HTTPRequest.GetString("aPayMoney_" + i).ToString());
                                        aDoDateTime = HTTPRequest.GetString("aDoDateTime_" + i).Trim() != "" ? DateTime.Parse(HTTPRequest.GetString("aDoDateTime_" + i).Trim()) : DateTime.Now;

                                        FeesSubjectID = HTTPRequest.GetInt("FeesSubjectID_"+i, 0);

                                        ap.APObjID = APObjID;
                                        ap.APObjType = APObjType;
                                        ap.aNPMoney = nMoney;
                                        ap.aPMoney = tMoney;
                                        ap.aPayMoney = aPayMoney;
                                        ap.aOtherMoney = 0;
                                        ap.FeesSubjectID = FeesSubjectID;
                                        ap.aReMake = "";
                                        ap.aDoDateTime = aDoDateTime;
                                        ap.aAppendTime = DateTime.Now;

                                        ap.APMoneyID = tbAPMoneyInfo.AddAPMoneyInfo(ap);

                                        if (ap.APMoneyID > 0)
                                        {
                                            //给单据打标记,标明为"已对账"
                                            //取出该供货商下所有指定订单编号
                                            odIDStr = tbErpOrderInfo.GetErpOrderIDStr(ap.APObjID, 4, eDate);//入库
                                            odIDStr = odIDStr + "," + tbErpOrderInfo.GetErpOrderIDStr(ap.APObjID, 8, eDate);//退货
                                            ap.aErpOrderIDStr = odIDStr;

                                            try
                                            {
                                                tbErpOrderInfo.UpdateErpOrderCheck(ap.APObjID, 4, eDate, 1);//发货
                                                tbErpOrderInfo.UpdateErpOrderCheck(ap.APObjID, 8, eDate, 1);//退货

                                                tbAPMoneyInfo.UpdateAPMoneyInfo(ap);
                                            }
                                            catch
                                            {

                                            }
                                            tCount++;
                                        }
                                    }
                                }
                                AddMsgLine("导入成功,共导入 <b>" + tCount + "</b> 条应付数据!");
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
            pagetitle = " 批量添加应付账款";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}
