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
using Yannyo.Cache;
using Yannyo.Common;
using Yannyo.Entity;
using Yannyo.BLL;


namespace Yannyo.Web
{
    public partial class supplierclass_edit : PageBase
    {
        //1.实体
        public SupplierClassInfo pi = new SupplierClassInfo();
        public int SupplierClassID;
        public string sClassName = "";
        public DateTime pAppendTime = DateTime.Now;
        public string Act = "";
        public string lastName = "";//修改前的名称
        protected virtual void Page_Load(object sender, EventArgs e)
        {
             if (this.userid > 0)
            {
                if (CheckUserPopedoms("X") || CheckUserPopedoms("2-1-3"))
                {
                    Act = HTTPRequest.GetString("Act");
                    sClassName = HTTPRequest.GetString("tName").Trim();
                    SupplierClassID = HTTPRequest.GetInt("classID", 0);
                    lastName = HTTPRequest.GetString("lastName").Trim();
                    if (SupplierClassID > 0)
                    {
                        //2.获得实体
                        pi = DataClass.GetSupplierClassInfoModel(SupplierClassID);
                    }

                    if (ispost)
                    {
                        //添加
                        if (Act.IndexOf("add") > -1)
                        {
                            //3.实体
                            SupplierClassInfo li = new SupplierClassInfo();
                            if (sClassName != "")
                            {
                                li.sParentID = SupplierClassID;
                                li.sClassName = sClassName;
                                li.sOrder = HTTPRequest.GetInt("tOrder", 0);
                                li.sAppendTime = DateTime.Now;

                                //4.是否存在
                                bool hValue = DataClass.ExistsSupplierClassInfo(HTTPRequest.GetString("tName"), SupplierClassID);
                                if (hValue)
                                {
                                    AddErrLine("操作失败，该条分类已经存在，请核对后重新添加！");
                                }
                                else
                                {
                                    //5.添加一条数据
                                    int addCount = DataClass.AddSupplierClassInfo(li);
                                    if (addCount > 0)
                                    {
                                        //记录成功操作
                                        Logs.AddEventLog(this.userid, "添加" + sClassName + "供货商分类");
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
                            if (sClassName != "")
                            {
                                pi.SupplierClassID = SupplierClassID;
                                pi.sClassName = sClassName;
                                pi.sAppendTime = DateTime.Now;

                                //6.更新一条数据
                                int count = DataClass.UpdateSupplierClassInfo(pi);
                                if (count > 0)
                                {
                                    //记录修改操作
                                    Logs.AddEventLog(this.userid, "将" + lastName + "供货商修改为" + sClassName);
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
            pagetitle = "修改供应商信息分类";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}