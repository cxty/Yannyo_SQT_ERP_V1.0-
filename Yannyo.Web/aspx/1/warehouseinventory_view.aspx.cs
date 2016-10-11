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
using System.IO;
using Yannyo.Public;

namespace Yannyo.Web
{
    public partial class warehouseinventory_view : PageBase
    {
        public DataTable StorageList = new DataTable();
        public DataTable dList = new DataTable();
        public int StorageID = 0;
        public int pagesize;
        public int pageindex;
        public int pagetotal;
        protected virtual void Page_Load(object sender, EventArgs e)
        {
            pagesize = 20;
            PageBarHTML = "";
             if (this.userid > 0)
            {
                if (CheckUserPopedoms("X") || CheckUserPopedoms("5-6") || CheckUserPopedoms("3-4-5"))
                {
                   StorageList = Caches.GetStorageInfoList("");
                   if (HTTPRequest.GetString("page").Trim() != "" && Utils.IsInt(HTTPRequest.GetString("page").Trim()))
                   {
                       pageindex = int.Parse(HTTPRequest.GetString("page").Trim());
                   }
                   else
                   {
                       pageindex = 1;
                   }
                   dList = tbStockProductInfo.GetWarehouseViewInfoList(pagesize, pageindex, "", out pagetotal, 1, "*");
                   PageBarHTML = Utils.TenPage(pageindex, pagetotal, 0);
                   AddScript("window.setTimeout('window.parent.HidBox();',1000);");
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
            pagetitle = "仓库盘点信息";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}