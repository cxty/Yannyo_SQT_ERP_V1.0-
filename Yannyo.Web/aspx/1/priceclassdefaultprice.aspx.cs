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
    public partial class priceclassdefaultprice : PageBase
    {
        public DataTable dList = new DataTable();
        public int pagesize;
        public int pageindex;
        public int pagetotal;
        public int ProductID=0;
        public string S_key = "";
        protected virtual void Page_Load(object sender, EventArgs e)
        {
            if (this.userid > 0)
            {
                if (CheckUserPopedoms("X") || CheckUserPopedoms("2-3-3"))
                {
                    pagesize = 20;
                    PageBarHTML = "";

                    if (HTTPRequest.GetString("page").Trim() != "" && Utils.IsInt(HTTPRequest.GetString("page").Trim()))
                    {
                        pageindex = int.Parse(HTTPRequest.GetString("page").Trim());
                    }
                    else
                    {
                        pageindex = 1;
                    }
                    string sWhere = "";
                    ProductID = HTTPRequest.GetInt("ProductID", 0);
                    S_key =Utils.ChkSQL(HTTPRequest.GetString("S_key"));

                    
                    if (S_key.Trim()!="")
                    {
                        sWhere = "  (pName like'%" + S_key + "%' or pBarcode like '%" + S_key + "%') ";
                    }

                    dList = tbProductsInfo.GetProductsInfoList(pagesize, pageindex, sWhere, out pagetotal, 1, "*,(select tbProductClassInfo.pClassName from tbProductClassInfo where tbProductClassInfo.ProductClassID=tbProductsInfo.ProductClassID) as ProductClass");

                    PageBarHTML = Utils.TenPage(pageindex, pagetotal, 0, "&ProductsID=" + ProductID + "&S_key=" + S_key);
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
            pagetitle = " 价格类型默认价格";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}