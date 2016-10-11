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
    public partial class productpool_do : PageBase
    {
        public ProductPoolInfo pi = new ProductPoolInfo();
        public string Act = "";
        public int ProductPoolID = 0;
        public int ProductsID = 0;
        public int pType = 0;
        public DateTime pDateTime = DateTime.Now;

        protected virtual void Page_Load(object sender, EventArgs e)
        {
            if (this.userid > 0)
            {
                if (CheckUserPopedoms("X") || CheckUserPopedoms("5-3"))
                {
                    Act = HTTPRequest.GetString("Act");
                    if (Act == "Edit")
                    {
                        ProductPoolID = Utils.StrToInt(HTTPRequest.GetString("pid"), 0);

                        pi = tbProductPoolInfo.GetProductPoolModel(ProductPoolID);
                    }
                    if (ispost)
                    {
                        ProductsID = Utils.StrToInt(HTTPRequest.GetString("ProductsID"), 0);

                        pType = Utils.StrToInt(HTTPRequest.GetString("pType"), 0);

                        pDateTime = Utils.IsDateString(HTTPRequest.GetString("pDateTime")) ? DateTime.Parse(HTTPRequest.GetString("pDateTime")) : DateTime.Now;

                        if (ProductsID > 0 )
                        {
                            pi.ProductsID = ProductsID;
                            pi.pDateTime = pDateTime;
                            pi.pType = pType;

                            if (Act == "Add")
                            {
                                pi.pAppendTime = DateTime.Now;
                                if (tbProductPoolInfo.AddProductPool(pi) > 0)
                                {
                                    AddMsgLine("创建成功!");
                                    AddScript("window.setTimeout('window.parent.HidBox();',1000);");
                                }
                                else
                                {
                                    AddErrLine("创建失败!");
                                    AddScript("history.back(1);");
                                }
                            }
                            if (Act == "Edit")
                            {
                                try
                                {
                                    tbProductPoolInfo.UpdateProductPool(pi);
                                    AddMsgLine("修改成功!");
                                    AddScript("window.setTimeout('window.parent.HidBox();',2000);");
                                }
                                catch (Exception ex)
                                {
                                    AddErrLine("修改失败!<br/>" + ex);
                                    AddScript("window.setTimeout('window.parent.HidBox();',2000);");
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
                            
                        }

                        if (Act == "Del")
                        {
                            try
                            {
                                tbProductPoolInfo.DeleteProductPool(HTTPRequest.GetString("pid"));
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
            pagetitle = " 添加修改产品联营信息";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}
