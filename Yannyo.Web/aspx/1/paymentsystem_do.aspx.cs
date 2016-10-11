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
    public partial class paymentsystem_do : PageBase
    {
        public PaymentSystemInfo pi = new PaymentSystemInfo();
        public string Act = "";
        public int PaymentSystemID = 0;
        public string pName = "";

        protected virtual void Page_Load(object sender, EventArgs e)
        {
            if (this.userid > 0)
            {
                if (CheckUserPopedoms("X") || CheckUserPopedoms("2-2-6"))
                {
                    Act = HTTPRequest.GetString("Act");
                    if (Act == "Edit")
                    {
                        PaymentSystemID = Utils.StrToInt(HTTPRequest.GetString("pid"), 0);

                        pi = tbPaymentSystemInfo.GetPaymentSystemModel(PaymentSystemID);
                    }
                    if (ispost)
                    {
                        pName = Utils.ChkSQL(HTTPRequest.GetString("pName"));

                        if (pName.Trim()!="")
                        {
                            pi.PaymentSystemID = PaymentSystemID;
                            pi.pName = pName;

                            if (Act == "Add")
                            {
                                pi.pAppendTime = DateTime.Now;
                                if (tbPaymentSystemInfo.AddPaymentSystem(pi) > 0)
                                {
                                    Logs.AddEventLog(this.userid, "新增结算系统." + pi.pName);
                                    AddMsgLine("创建成功!");
                                    AddScript("window.setTimeout('window.parent.HidBox();',2000);");
                                }
                                else
                                {
                                    AddErrLine("创建失败!");
                                    AddScript("history.back(1);");
                                }
                            }
                            if (Act == "Edit")
                            {
                                try
                                {
                                    tbPaymentSystemInfo.UpdatePaymentSystem(pi);
                                    Logs.AddEventLog(this.userid, "修改结算系统." +pi.pName);
                                    AddMsgLine("修改成功!");
                                    AddScript("window.setTimeout('window.parent.HidBox();',2000);");
                                }
                                catch (Exception ex)
                                {
                                    AddErrLine("修改失败!<br/>" + ex);
                                    AddScript("window.setTimeout('window.parent.HidBox();',2000);");
                                }
                            }
                        }
                        else
                        {
                            AddErrLine("参数错误!<br/>");
                            AddScript("window.setTimeout('window.parent.HidBox();',2000);");
                        }
                    }
                    else
                    {
                        if (Act == "Add")
                        {

                        }

                        if (Act == "Del")
                        {
                            try
                            {
                                tbPaymentSystemInfo.DeletePaymentSystem(HTTPRequest.GetString("pid"));
                                Logs.AddEventLog(this.userid, "删除结算系统." + HTTPRequest.GetString("pid"));
                                AddMsgLine("删除成功!");
                                AddScript("window.setTimeout('window.parent.HidBox();',2000);");
                            }
                            catch (Exception ex)
                            {
                                AddErrLine("创建失败!<br/>" + ex);
                                AddScript("window.setTimeout('window.parent.HidBox();',2000);");
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
            pagetitle = " 添加修改客户结算系统信息";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}
