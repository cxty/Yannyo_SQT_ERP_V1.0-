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
    public partial class orderlist_dobox : PageBase
    {
        public int ordertype = 0;//单据类型
        public int productid = 0;//产品编号
        public DataTable StorageList = new DataTable();//仓库列表
        public DataTable StoresSupplierList = new DataTable();//客户或供应商列表
        public string tObj = "";//页面回调用
        public string PriceClass = "";
        //public ProductsInfo pi = new ProductsInfo();//产品
        protected virtual void Page_Load(object sender, EventArgs e)
        {
            if (this.userid > 0)
            {
                StorageList = tbStorageInfo.GetStorageInfoList(" sState=0 ").Tables[0];
                ordertype = HTTPRequest.GetInt("ordertype", 0);
                productid = HTTPRequest.GetInt("productid", 0);
                tObj = HTTPRequest.GetString("tObj");
                if (productid > 0)
                {
                   // pi = tbProductsInfo.GetProductsInfoModel(productid);
                    switch (ordertype)
                    {
                        case 1:
                        case 2:
                            StoresSupplierList = tbSupplierInfo.GetSupplierInfoList("").Tables[0];
                            break;
                        case 3:
                        case 4:
                        case 5:
                        case 6:
                        case 7:
                            PriceClass = Caches.GetPriceClassInfoToHTML();
                            StoresSupplierList = tbStoresInfo.GetStoresInfoList("").Tables[0];
                            break;
                    }
                }
                else {
                    AddErrLine("参数错误!");
                    AddScript("window.setTimeout('history.back(1);',2000);");
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
            pagetitle = " 具体信息";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}