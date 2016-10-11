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
    public partial class staffstores_do : PageBase
    {
        public StaffStoresInfo si = new StaffStoresInfo();
        public string Act = "";
        public int StaffStoresID = 0;
        public int StaffID = 0;
        public int StoresID = 0;
        public int sType = 0;
        public DateTime sDateTime = DateTime.Now;

        protected virtual void Page_Load(object sender, EventArgs e)
        {
            if (this.userid > 0)
            {
                if (CheckUserPopedoms("X") || CheckUserPopedoms("4-2"))
                {
                    Act = HTTPRequest.GetString("Act");
                    if (Act == "Edit")
                    {
                        StaffStoresID = Utils.StrToInt(HTTPRequest.GetString("sid"), 0);

                        si = tbStaffStoresInfo.GetStaffStoresInfoModel(StaffStoresID);
                    }
                    if (ispost)
                    {
                        StaffID = Utils.StrToInt(HTTPRequest.GetString("StaffID"), 0);
                        StoresID = Utils.StrToInt(HTTPRequest.GetString("StoresID"), 0);
                        sType = Utils.StrToInt(HTTPRequest.GetString("sType"), 0);

                        sDateTime = Utils.IsDateString(HTTPRequest.GetString("sDateTime"))?DateTime.Parse(HTTPRequest.GetString("sDateTime")):DateTime.Now;

                        if (StaffID > 0 && StoresID > 0)
                        {
                            si.StoresID = StoresID;
                            si.StaffID = StaffID;
                            si.sDateTime = sDateTime;
                            si.sType = sType;

                            if (Act == "Add")
                            {
                                si.sAppendTime = DateTime.Now;
                                if (tbStaffStoresInfo.AddStaffStoresInfo(si) > 0)
                                {
                                    AddMsgLine("创建成功!");
                                    AddScript("window.setTimeout('window.parent.HidBox();',1000);");
                                }
                                else
                                {
                                    AddErrLine("创建失败!");
                                    AddScript("window.setTimeout('history.back(1);',1000);");
                                }
                            }
                            if (Act == "Edit")
                            {
                                try
                                {
                                    tbStaffStoresInfo.UpdateStaffStoresInfo(si);
                                    AddMsgLine("修改成功!");
                                    AddScript("window.setTimeout('window.parent.HidBox();',1000);");
                                }
                                catch (Exception ex)
                                {
                                    AddErrLine("修改失败!<br/>" + ex);
                                    AddScript("window.setTimeout('window.parent.HidBox();',1000);");
                                }
                            }
                        }
                        else
                        {
                            AddErrLine("参数错误!<br/>");
                            AddScript("window.setTimeout('window.parent.HidBox();',1000);");
                        }
                    }
                    else
                    {
                        if (Act == "Add")
                        {
                            si.StaffName = "";
                            si.StaffID = 0;
                            si.StoresName = "";
                            si.StoresID = 0;
                        }

                        if (Act == "Del")
                        {
                            try
                            {
                                tbStaffStoresInfo.DeleteStaffStoresInfo(HTTPRequest.GetString("sid"));
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
            pagetitle = " 添加修改人员门店绑定信息";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}
