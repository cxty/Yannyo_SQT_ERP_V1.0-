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
    public partial class erpdata_do : PageBase
    {
        public string Act = "";
        protected virtual void Page_Load(object sender, EventArgs e)
        {
            if (this.userid > 0)
            {
                if (CheckUserPopedoms("X") || CheckUserPopedoms("13"))
                {
                    Act = HTTPRequest.GetString("Act");
                    if (Act == "Del")
                    {
                        try
                        {
                            tbErpOrderInfo.DeleteErpOrderInfo(HTTPRequest.GetString("eid"));
                            AddMsgLine("删除成功!");
                            AddScript("window.setTimeout('window.parent.HidBox();',1000);");
                        }
                        catch (Exception ex)
                        {
                            AddErrLine("创建失败!<br/>" + ex);
                            AddScript("window.setTimeout('window.parent.HidBox();',1000);");
                        }
                    }
                }
                else
                {
                    AddErrLine("权限不足!");
                    AddScript("window.parent.HidBox();");
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
            pagetitle = " Erp单据数据";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}
