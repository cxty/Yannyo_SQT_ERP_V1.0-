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
    public partial class departmentsclass_edit : PageBase
    {
        public DepartmentsClassInfo pi = new DepartmentsClassInfo();
        public int departmentClassID;
        public string dClassName = "";
        public DateTime dAppendTime = DateTime.Now;
        public string Act = "";
        public string lastName = "";//修改前的名称
        protected virtual void Page_Load(object sender, EventArgs e)
        {
            if (this.userid > 0)
            {
                if (CheckUserPopedoms("X") || CheckUserPopedoms("2-1-2"))
                {
                    Act = HTTPRequest.GetString("Act");
                    dClassName = HTTPRequest.GetString("tName").Trim();
                    departmentClassID = HTTPRequest.GetInt("classID", 0);
                    lastName = HTTPRequest.GetString("lastName").Trim();

                    if (departmentClassID > 0)
                    {
                        pi = DataClass.GetDepartmentsClassInfoModel(departmentClassID);
                    }

                    if (ispost)
                    {
                        //添加
                        if (Act.IndexOf("add") > -1)
                        {
                            DepartmentsClassInfo li = new DepartmentsClassInfo();
                            if (dClassName != "")
                            {
                                li.dParentID = departmentClassID;
                                li.dClassName = dClassName;
                                li.dOrder = HTTPRequest.GetInt("tOrder", 0);
                                li.dAppendTime = DateTime.Now;

                                bool hValue = DataClass.ExistsDepartmentsClassInfo(HTTPRequest.GetString("tName"), departmentClassID);
                                if (hValue)
                                {
                                    AddErrLine("操作失败，该条分类已经存在，请核对后重新添加！");
                                }
                                else
                                {
                                    int addCount = DataClass.AddDepartmentsClassInfo(li);
                                    if (addCount > 0)
                                    {
                                        //记录成功操作
                                        Logs.AddEventLog(this.userid, "添加" + dClassName + "部门分类");
                                        AddMsgLine("操作成功！");
                                        AddScript("window.setTimeout('window.parent.HidBox();',1000);");
                                    }
                                    else
                                    {
                                        AddErrLine("操作失败，请重新添加！");
                                    }
                                }
                            }
                            else
                            {
                                AddErrLine("操作失败，请重新添加！");
                            }
                        }
                        //修改
                        if (Act.IndexOf("update") > -1)
                        {
                            if (dClassName != "")
                            {
                                pi.DepartmentsClassID = departmentClassID;
                                pi.dClassName = dClassName;
                                pi.dAppendTime = DateTime.Now;

                                int count = DataClass.UpdateDepartmentsClassInfo(pi);
                                if (count > 0)
                                {
                                    //记录修改操作
                                    Logs.AddEventLog(this.userid, "将" + lastName + "部门修改为" + dClassName);
                                    AddMsgLine("修改成功！");
                                    AddScript("window.setTimeout('window.parent.HidBox();',1000);");
                                }
                                else
                                {
                                    AddErrLine("修改失败！");
                                }
                            }
                            else
                            {
                                AddErrLine("修改失败！");
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
            pagetitle = " 部门分类信息";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}