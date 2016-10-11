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
    public partial class yhsys_do : PageBase
    {
        public YHsysInfo YHsys = new YHsysInfo();
        public string Act = "";
        public int YHsysID = 0;
        public string yName = "";
        public DateTime yAppendTime = DateTime.Now;

        protected virtual void Page_Load(object sender, EventArgs e)
        {
            if (this.userid > 0)
            {
                if (CheckUserPopedoms("X") || CheckUserPopedoms("2-2-5"))
                {
                    Act = HTTPRequest.GetString("Act");

                    yName = Utils.ChkSQL(HTTPRequest.GetString("yName"));
                    if (Act == "Edit")
                    {
                        YHsysID = Utils.StrToInt(HTTPRequest.GetString("yid"), 0);

                        YHsys = tbYHsysInfo.GetYHsysInfoModel(YHsysID);
                    }
                    if (ispost)
                    {
                        if (Act == "Add")
                        {
                            if (!tbYHsysInfo.ExistsYHsysInfo(yName))
                            {
                                YHsys.yName = yName;
                                YHsys.yAppendTime = yAppendTime;

                                if (tbYHsysInfo.AddYHsysInfo(YHsys) > 0)
                                {
                                    Logs.AddEventLog(this.userid, "新增系统." + YHsys.yName);
                                    AddMsgLine("创建成功!");
                                    AddScript("window.setTimeout('window.parent.HidBox();',1000);");
                                }
                                else
                                {
                                    AddErrLine("创建失败!");
                                    AddScript("history.back(1);");
                                }
                            }
                            else
                            {
                                AddErrLine("厂标:" + yName + ",已存在,请更换!");
                                AddScript("history.back(1);");
                            }
                        }
                        if (Act == "Edit")
                        {
                            if (YHsysID > 0)
                            {
                                if (!tbYHsysInfo.ExistsYHsysInfo(yName))
                                {
                                    YHsys.yName = yName;
                                    try
                                    {
                                        tbYHsysInfo.UpdateYHsysInfo(YHsys);
                                        Logs.AddEventLog(this.userid, "修改系统." + YHsys.yName);
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
                                    AddErrLine("厂标:" + yName + ",已存在,请更换!");
                                    AddScript("history.back(1);");
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
                        if (Act == "Add")
                        {
                        }

                        if (Act == "Del")
                        {
                            try
                            {
                                tbYHsysInfo.DeleteYHsysInfo(HTTPRequest.GetString("yid"));
                                Logs.AddEventLog(this.userid, "删除系统." + HTTPRequest.GetString("yid"));
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
            pagetitle = " 添加修改永辉厂标信息";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}
