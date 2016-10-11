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
    public partial class manage_pwd : PageBase
    {
        
        protected virtual void Page_Load(object sender, EventArgs e)
        {
            if (this.userid > 0)
            {
                if (ispost)
                {
                    string OldPWD = Utils.ChkSQL(HTTPRequest.GetString("OldPWD"));
                    string NewPWD = Utils.ChkSQL(HTTPRequest.GetString("NewPWD"));
                    if (Utils.MD5(OldPWD) == userinfo.uPWD)
                    {
                        if (NewPWD.Trim() != "")
                        {
                            userinfo.uPWD = Utils.MD5(NewPWD.Trim());
                            tbUserInfo.UpdateUserInfo(userinfo);
                            AddMsgLine("修改成功,请重新登录!");
                            AddScript("window.setTimeout('top.location=\"logout.aspx\";',1000);");
                        }
                        else
                        {
                            AddErrLine("新密码不能为空!");
                            AddScript("window.setTimeout('history.back(1);',2000);");
                        }
                    }
                    else
                    {
                        AddErrLine("旧密码错误!");
                        AddScript("window.setTimeout('history.back(1);',2000);");
                    }
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
            pagetitle = " 修改个人信息";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}