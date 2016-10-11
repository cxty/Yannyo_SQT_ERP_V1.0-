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
    public partial class logout : PageBase
    {
        protected virtual void Page_Load(object sender, EventArgs e)
        {
            string referer = HTTPRequest.GetQueryString("reurl");
            if (!HTTPRequest.IsPost() || referer != "")
            {
                string r = "";
                if (referer != "")
                {
                    r = referer;
                }
                else
                {
                    if ((HTTPRequest.GetUrlReferrer() == "") || (HTTPRequest.GetUrlReferrer().IndexOf("login") > -1) ||
                        HTTPRequest.GetUrlReferrer().IndexOf("logout") > -1)
                    {
                        r = "Default.aspx";
                    }
                    else
                    {
                        r = HTTPRequest.GetUrlReferrer();
                    }
                }
                Utils.WriteCookie("reurl", (referer == "" || referer.IndexOf("login.aspx") > -1) ? r : referer);
            }


            SetUrl(Utils.UrlDecode(UsersUtils.GetReUrl()));

            SetMetaRefresh();
            SetShowBackLink(false);

            tbUserInfo.UpdateUserOnlineTime(userid, DateTime.Now.ToString());
            OnlineUsers.DeleteRows(olid);
            UsersUtils.ClearUserCookie();
            this.userid = 0;

            AddMsgLine("已经清除了您的登录信息");
        }
        protected override void ShowPage()
        {
            pagetitle = "登出";

            this.Load += new EventHandler(this.Page_Load);
        }
    }
}
