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
    public partial class productclass_edit : PageBase
    {
        public ProductClassInfo pi = new ProductClassInfo();
        public int productClassID;
        public string pClassName = "";
        public DateTime pAppendTime = DateTime.Now;
        public string Act = "";
        public string lastName = "";//修改前的名称
        protected virtual void Page_Load(object sender, EventArgs e)
        {
            if (this.userid > 0)
            {
                if (CheckUserPopedoms("X") || CheckUserPopedoms("2-1-1"))
                {
                    Act = HTTPRequest.GetString("Act");
					pClassName=Utils.ChkSQL(HTTPRequest.GetString("tName").Trim());
                    productClassID = HTTPRequest.GetInt("classID", 0);
                    lastName = HTTPRequest.GetString("lastName").Trim();

                    if (productClassID > 0)
                    {
                        pi = DataClass.GetProductClassInfoModel(productClassID);
                    }

                    if (ispost)
                    {
                        //添加
                        if (Act.IndexOf("add") > -1)
                        {
                            ProductClassInfo li = new ProductClassInfo();
                            if (pClassName != "")
                            {
                                li.pParentID = productClassID;
                                li.pClassName = pClassName;
                                li.pOrder = HTTPRequest.GetInt("tOrder", 0);
                                li.pAppendTime = DateTime.Now;

                                bool hValue = DataClass.ExistsProductClassInfo(HTTPRequest.GetString("tName"), productClassID);
                                if (hValue)
                                {
                                    AddErrLine("操作失败，该条分类已经存在，请核对后重新添加！");
                                }
                                else
                                {
                                    int addCount = DataClass.AddProductClassInfo(li);
                                    if (addCount > 0)
                                    {
                                        //记录成功操作
                                        Logs.AddEventLog(this.userid,"添加"+pClassName+"商品分类");
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
                            if (pClassName != "")
                            {
                                pi.ProductClassID = productClassID;
                                pi.pClassName = pClassName;
                                pi.pAppendTime = DateTime.Now;

                                int count = DataClass.UpdateProductClassInfo(pi);
                                if (count > 0)
                                {
                                    //记录修改操作
                                    Logs.AddEventLog(this.userid, "将" + lastName + "商品修改为" + pClassName);
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
            pagetitle = "修改产品信息分类";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}