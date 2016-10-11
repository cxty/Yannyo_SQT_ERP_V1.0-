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
    public partial class login : PageBase
    {
        /// <summary>
        /// 登录所使用的用户名
        /// </summary>
        public string postusername;

        /// <summary>
        /// 登陆时提交的密码
        /// </summary>
        public string postpassword = "";

        /// <summary>
        /// 登陆成功后跳转的链接
        /// </summary>
        public string referer = HTTPRequest.GetString("referer");

        protected virtual void Page_Load(object sender, EventArgs e)
        {
            int uid = -1;
            UserInfo ui = new UserInfo();

            postusername = Utils.ChkSQL(HTTPRequest.GetString("username"));
            postpassword = Utils.ChkSQL(HTTPRequest.GetString("password"));

            if (!ispost)
            {
                if (this.userid > 0)
                {
                    AddErrLine("您已经登录，无需重复登录。");
                    AddScript("window.setTimeout(function(){top.location='Default.aspx';},1500);");
                    SetShowMsgLink(false);
                }
            }
            else
            {
                try
                {
                    if (postpassword.Equals(""))
                    {
                        AddErrLine("密码不能为空");
                    }
                    else
                    {
                        if (postusername.Equals(""))
                        {
                            AddErrLine("用户名不能为空");
                        }
                        else
                        {
                            if (BLL.tbUserInfo.ExistsUserInfo(postusername))
                            {
                                uid = BLL.tbUserInfo.CheckPassword(postusername, postpassword, true);
                                if (uid != -1)
                                {
                                    UserInfo tui = BLL.tbUserInfo.GetUserInfoModel(uid);
                                    if (tui.uEstate == 1)
                                    {
                                        AddErrLine("抱歉, 您的用户身份尚未得到验证");
                                    }
                                    if (!IsErr())
                                    {
										BLL.tbUserInfo.DeleteErrLoginRecord(this.GetIP());
										tui.uLastIP = this.GetIP();
                                        tui.uUpAppendTime = DateTime.Now;
                                        BLL.tbUserInfo.UpdateUserInfo(tui);
                                        UsersUtils.WriteUserCookie(uid, Utils.StrToInt(HTTPRequest.GetString("expires"), -1), config.Passwordkey, HTTPRequest.GetInt("loginmode", -1));
                                        UsersUtils.WriteCookie("UserPKey", DES.Encode(postpassword, config.Passwordkey));

                                        AddMsgLine("登录成功,页面转接中,请稍后!");

                                        AddScript("window.setTimeout(function(){top.location='Default.aspx';},1000);");

                                        SetShowMsgLink(false);
                                    }
                                }
                                else
                                {
                                    CheckPassErrorCount();
                                }
                            }
                            else
                            {
                                AddErrLine("用户不存在");
                            }
                        }
                    }
                    if (IsErr())
                    {
                        AddScript("window.setTimeout(function(){window.history.go(-1);},1500);");
                        SetShowMsgLink(false);
                    }
                }
                finally
                {
                    ui = null;
                }
            }
        }
        public void CheckPassErrorCount()
        {
			int errcount = BLL.tbUserInfo.UpdateLoginLog(this.GetIP(), true);
            if (errcount >= 5)
            {
                AddMsgLine("您已经多次输入密码错误, 请15分钟后再登录");
            }
            else
            {
                AddErrLine(string.Format("密码或安全提问第{0}次错误, 您最多有5次机会重试", errcount.ToString()));
            }
        }
        protected override void ShowPage()
        {
            pagetitle = "登录";

            this.Load += new EventHandler(this.Page_Load);
        }
    }
}
