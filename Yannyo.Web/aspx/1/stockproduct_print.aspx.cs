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
    public partial class stockproduct_print : PageBase
    {
        public DataTable dList = new DataTable();
        public int pagesize;
        public int pageindex;
        public int pagetotal;
        public string Act = "";
        public string S_key = "";
        public int ProductID = 0;
        public int StorageID = 0;
        public int loop_count = 0;
        public DateTime sDate = DateTime.Now;
        public StorageInfo si = new StorageInfo();
        protected virtual void Page_Load(object sender, EventArgs e)
        {
            pagesize = 20;
            PageBarHTML = "";

            if (this.userid > 0)
            {
                if (HTTPRequest.GetString("page").Trim() != "" && Utils.IsInt(HTTPRequest.GetString("page").Trim()))
                {
                    pageindex = int.Parse(HTTPRequest.GetString("page").Trim());
                }
                else
                {
                    pageindex = 1;
                }
                if (ispost)
                {
                    Act = HTTPRequest.GetFormString("Act");
                    S_key = Utils.ChkSQL(HTTPRequest.GetFormString("S_key"));
                }
                else
                {
                    Act = HTTPRequest.GetQueryString("Act");
                    S_key = Utils.ChkSQL(HTTPRequest.GetQueryString("S_key"));
                }

                ProductID = HTTPRequest.GetInt("ProductID", 0);
                StorageID = HTTPRequest.GetInt("StorageID", 0);
                sDate = HTTPRequest.GetString("sDate").Trim() != "" ? Convert.ToDateTime(HTTPRequest.GetString("sDate").Trim()+" 23:59:59") : DateTime.Now;
                if (StorageID > 0)
                {
                    si = tbStorageInfo.GetStorageInfoModel(StorageID);
                    dList = tbProductsInfo.GetProductsStorageInfoByStorageID(0,StorageID, sDate, ProductID);// DataUtils.GetStock_analysis(0, DateTime.Now, ProductID);
                }
                else {
                    AddErrLine("请先选择仓库!");
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
            pagetitle = " 打印库存信息";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}