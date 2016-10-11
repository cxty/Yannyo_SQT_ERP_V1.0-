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
    public partial class camera : PageBase
    {
        public string ucode = "";
        public int CertificateID = 0;
        public string Act = "";
        public int w = 640;
        public int h = 480;
        protected virtual void Page_Load(object sender, EventArgs e)
        {
            if (this.userid > 0)
            {
                ucode =DES.Encode(this.userinfo.uName + "|" + UsersUtils.GetCookiePassword(config.Passwordkey),config.Passwordkey);
                CertificateID = HTTPRequest.GetInt("CertificateID", 0);
                Act = HTTPRequest.GetString("Act");
                w = HTTPRequest.GetInt("w", 640);
                h = HTTPRequest.GetInt("h", 480);
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
            pagetitle = " 拍照存档";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}