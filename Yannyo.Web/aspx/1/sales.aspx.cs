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
    public partial class sales : PageBase
    {
        public DataTable dList = new DataTable();
        public DataTable ddList = new DataTable();
        public int pagesize;
        public int pageindex;
        public int pagetotal;
        public string sDate = "";
        protected virtual void Page_Load(object sender, EventArgs e)
        {
            pagesize = 20;
            PageBarHTML = "";
            string tSQL = " 1=1 ";

            if (this.userid > 0)
            {
                if (CheckUserPopedoms("X") || CheckUserPopedoms("3-4-1"))
                {
                    if (HTTPRequest.GetString("page").Trim() != "" && Utils.IsInt(HTTPRequest.GetString("page").Trim()))
                    {
                        pageindex = int.Parse(HTTPRequest.GetString("page").Trim());
                    }
                    else
                    {
                        pageindex = 1;
                    }
                    
                    sDate =Utils.ChkSQL(HTTPRequest.GetString("sDate"));

                    if (sDate.Trim() != "")
                    {
                        tSQL += " and sDateTime>='" + sDate + "' and sDateTime<='" + sDate + " 23:59:59' ";
                    }

                    dList = tbSalesInfo.GetSalesInfoList(pagesize, pageindex, tSQL, out pagetotal, 1, "*,(select sName from tbStoresInfo where StoresID=tbSalesInfo.StoresID) as StoresName,(select pName from tbProductsInfo where ProductsID=tbSalesInfo.ProductsID) as ProductsName");

                    ddList = tbSalesInfo.GetNOJoinDataSalesInfoList();

                    PageBarHTML = Utils.TenPage(pageindex, pagetotal, 0, "&sDate=" + sDate);
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
            pagetitle = " 销售数据管理";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}
