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
    public partial class usermanage_do : PageBase
    {
        public UserInfo ui = new UserInfo();
        public UserPassportInfo pi = new UserPassportInfo();
        public string UserPopedomJson = "";
        public string Act = "";
        public int UserID = 0;
        public string uName = "";
        public string uPWD = "";
        public string uPWD_Old = "";

        public string uPermissions = "";
        public string uEstate = "";

        public string Erp_Name = "";
        public string Erp_Pwd = "";
        public string g_Name = "";
        public string g_PWD = "";
        public int uType = 0;
        public int StaffID = 0;
		public string StorageIDStr = "";

        public DataTable UserTypeList = new DataTable();
		public DataTable StorageList = new DataTable();

        protected virtual void Page_Load(object sender, EventArgs e)
        {
            if (this.userid > 0)
            {
                if (CheckUserPopedoms("X"))
                {
                    UserTypeList = Caches.GetUserTypeList();
                    Act = HTTPRequest.GetString("Act");

                    uName = Utils.ChkSQL(HTTPRequest.GetString("uName"));
                    uPWD = Utils.ChkSQL(HTTPRequest.GetString("uPWD"));
                    uPWD_Old = Utils.ChkSQL(HTTPRequest.GetString("uPWD_Old"));
                    uPermissions = Utils.ChkSQL(HTTPRequest.GetString("uPermissions"));
                    uEstate = Utils.ChkSQL(HTTPRequest.GetString("uEstate"));

                    Erp_Name = Utils.ChkSQL(HTTPRequest.GetString("Erp_Name"));
                    Erp_Pwd = Utils.ChkSQL(HTTPRequest.GetString("Erp_Pwd"));
                    g_Name = Utils.ChkSQL(HTTPRequest.GetString("g_Name"));
                    g_PWD = Utils.ChkSQL(HTTPRequest.GetString("g_PWD"));
                    uType = HTTPRequest.GetInt("uType", 0);
                    StaffID = HTTPRequest.GetInt("StaffID", 0);

					StorageIDStr = Utils.ChkSQL(HTTPRequest.GetString ("StorageIDStr"));

					StorageIDStr = StorageIDStr.IndexOf ("x") > -1 ? "x" : ","+StorageIDStr+",";

                    pi.Erp_Name = "";
                    pi.Erp_Pwd = "";
                    pi.g_Name = "";
                    pi.g_PWD = "";

                    

                    if (Act == "Edit")
                    {

                        UserID = Utils.StrToInt(HTTPRequest.GetString("uid"), 0);

                        ui = tbUserInfo.GetUserInfoModel(UserID);
                        pi = tbUserInfo.GetUserPassportInfoModel(UserID);
                        if (pi == null)
                        {
                            pi = new UserPassportInfo();
                            pi.Erp_Name = "";
                            pi.Erp_Pwd = "";
                            pi.g_Name = "";
                            pi.g_PWD = "";
                        }

                        UserPopedomJson = UsersUtils.GetUserPopedomToJsonStr();// UsersUtils.GetUserPopedomToJsonStr(ui.uPermissions);
                    }

                    if (ispost)
                    {
                        if (ui.uPermissions != "X")
                        {
                            ui.uPermissions = uPermissions;
                        }
                        ui.uEstate = uEstate == "0" ? 0 : 1;
                        ui.uType = uType;
                        ui.StaffID = StaffID;
						ui.StorageIDStr = StorageIDStr;

                        if (Act == "Add")
                        {
                            if (!tbUserInfo.ExistsUserInfo(uName))
                            {
                                ui.uName = uName;
                                ui.uPWD = Utils.MD5(uPWD);
                                ui.uCode = Utils.CutString(Utils.GetRanDomCode(), 16);

                                ui.uLastIP = HTTPRequest.GetIP();
                                ui.uAppendTime = DateTime.Now;
                                ui.uUpAppendTime = DateTime.Now;



                                pi.UserID = tbUserInfo.AddUserInfo(ui);
                                Logs.AddEventLog(this.userid, "新增用户:"+ui.uName);
                                if (pi.UserID > 0)
                                {
                                    pi.Erp_Name = Erp_Name;
                                    pi.Erp_Pwd = Erp_Pwd;
                                    pi.g_Name = g_Name;
                                    pi.g_PWD = g_PWD;

                                    if (tbUserInfo.AddUserPassportInfo(pi) > 0)
                                    {
                                        
                                        AddMsgLine("创建成功!");
                                        AddScript("window.setTimeout('window.parent.HidBox();',1000);");
                                    }
                                    else
                                    {
                                        AddErrLine("账户创建成功,但通行证绑定失败!");
                                        AddScript("history.back(1);");
                                    }
                                }
                                else
                                {
                                    AddErrLine("创建失败!");
                                    AddScript("history.back(1);");
                                }
                            }
                            else
                            {
                                AddErrLine("用户名:" + uName + ",已存在,请更换!");
                                AddScript("history.back(1);");
                            }
                        }
                        if (Act == "Edit")
                        {
                            if (UserID > 0)
                            {
                                ui.UserID = UserID;
                                if (uPWD.Trim() != "")
                                {
                                    ui.uPWD = Utils.MD5(uPWD);
                                }
                                else
                                {
                                    ui.uPWD = uPWD_Old;
                                }

                                //超级管理员无需修改权限与状态
                                if (ui.uPermissions == "X")
                                {
                                    ui.uPermissions = "X";
                                    ui.uEstate = 0;
                                }
                                try
                                {
                                    pi.UserID = UserID;
                                    pi.Erp_Name = Erp_Name;
                                    pi.Erp_Pwd = Erp_Pwd;
                                    pi.g_Name = g_Name;
                                    pi.g_PWD = g_PWD;

                                    if (tbUserInfo.UserPassportInfoExists(UserID))
                                    {
                                        tbUserInfo.UpdateUserPassportInfo(pi);
                                    }
                                    else
                                    {
                                        tbUserInfo.AddUserPassportInfo(pi);
                                    }

                                    tbUserInfo.UpdateUserInfo(ui);
                                    Logs.AddEventLog(this.userid, "修改用户:"+ui.uName);
                                    AddMsgLine("修改成功!");
                                    AddScript("window.setTimeout('window.parent.HidBox();',1000);");
                                }
                                catch (Exception ex)
                                {
                                    AddErrLine("修改失败!<br/>" + ex);
                                    AddScript("window.setTimeout('window.parent.HidBox();',1000);");
                                }
                            }
                            else
                            {
                                AddErrLine("参数错误,修改失败!");
                                AddScript("window.setTimeout('window.parent.HidBox();',1000);");
                            }
                        }
                    }
                    else
                    {
                        
						StorageList = tbStorageInfo.GetStorageInfoList(" sState = 0").Tables [0];

                        if (Act == "Add")
                        {
                            ui.UserID = 0;
                            ui.uName = "";
                            ui.uPWD = "";
                            ui.uCode = "";
                            ui.uEstate = 0;
                            ui.uPermissions = "";
							ui.StorageIDStr = "x";
                            UserPopedomJson = UsersUtils.GetUserPopedomToJsonStr();
                            
                        }

                        if (Act == "Del")
                        {
                            try
                            {
                                tbUserInfo.DeleteUserInfo(HTTPRequest.GetString("uid"));
                                Logs.AddEventLog(this.userid, "删除用户:uid=>" + HTTPRequest.GetString("uid"));
                                AddMsgLine("删除成功!");
                                AddScript("window.setTimeout('window.parent.HidBox();',1000);");
                            }
                            catch (Exception ex)
                            {
                                AddErrLine("删除失败!<br/>" + ex);
                                AddScript("window.setTimeout('window.parent.HidBox();',1000);");
                            }
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
            pagetitle = " 添加修改用户信息";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}
