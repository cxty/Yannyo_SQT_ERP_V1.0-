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
    public partial class customersclass_edit : PageBase
    {
        public CustomersClassInfo pi = new CustomersClassInfo();
        public int customersClassID;
        public string cClassName = "";
        public DateTime dAppendTime = DateTime.Now;
        public string Act = "";
        public string lastName = "";//修改前的名称
        protected virtual void Page_Load(object sender, EventArgs e)
        {
              if (this.userid > 0)
            {
                if (CheckUserPopedoms("X") || CheckUserPopedoms("2-1-4"))
                {
                    Act = HTTPRequest.GetString("Act");
                    cClassName = HTTPRequest.GetString("tName").Trim();
                    customersClassID = HTTPRequest.GetInt("classID", 0);
                    lastName = HTTPRequest.GetString("lastName").Trim();
                    if (customersClassID > 0)
                    {
                        pi = DataClass.GetCustomersClassInfoModel(customersClassID);
                    }

                    if (ispost)
                    {
                        //添加
                        if (Act.IndexOf("add") > -1)
                        {
                            CustomersClassInfo li = new CustomersClassInfo();
                            if (cClassName != "")
                            {
                                li.cParentID = customersClassID;
                                li.cClassName = cClassName;
                                li.cOrder = HTTPRequest.GetInt("tOrder", 0);
                                li.cAppendTime = DateTime.Now;

                                bool hValue = DataClass.ExistsCustomersClassInfo(HTTPRequest.GetString("tName"), customersClassID);
                                if (hValue)
                                {
                                    AddErrLine("操作失败，该条分类已经存在，请核对后重新添加！");
                                }
                                else
                                {
                                    int addCount = DataClass.AddCustomersClassInfo(li);
                                    if (addCount > 0)
                                    {
                                        //记录成功操作
                                        Logs.AddEventLog(this.userid, "添加" + cClassName + "客户分类");
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
                            if (cClassName != "")
                            {
                                pi.CustomersClassID = customersClassID;
                                pi.cClassName = cClassName;
                                pi.cAppendTime = DateTime.Now;

                                int count = DataClass.UpdateCustomersClassInfo(pi);
                                if (count > 0)
                                {
                                    //记录修改操作
                                    Logs.AddEventLog(this.userid, "将" + lastName + "客户修改为" + cClassName);
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
            pagetitle = "客户分类信息";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}