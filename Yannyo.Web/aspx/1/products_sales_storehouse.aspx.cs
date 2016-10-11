using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Xml;
using System.IO;
using System.Net;

using Yannyo.Common;
using Yannyo.Config;
using Yannyo.Entity;
using Yannyo.BLL;
using Yannyo.Public;

namespace Yannyo.Web
{
    public partial class products_sales_storehouse : PageBase
    {
        public DataTable sList = new DataTable();//日均销量
        public DataTable tList = new DataTable();//同比销量
        public DataTable hList = new DataTable();//环比销量
        public string pName;      //产品名称
        public string pBarcode;   //产品条码
        public int pID;           //产品编号
        public int sID;           //下拉选择
        public DateTime bDate;    //开始日期
        public DateTime eDate;    //结束日期
        public decimal sumA, sumAA, sumAAA, sumB, sumBB, sumBBB;
        public DataTable Products_sales_storehouse_basis(int productsID,string storeID,DateTime bDate, DateTime eDate, int tType)
        {
            tList = ProductsLossInfo.Products_sales_storehouse_basis(productsID, Convert.ToInt32(storeID), bDate, eDate, tType);
            if (tList.Rows.Count > 0)
            {
                return tList;
            }
            else
            {
                return null;
            }
        }
        public DataTable Products_sales_storehouse_annulus(int productsID, string storeID, DateTime bDate, DateTime eDate, int tType)
        {
            hList = ProductsLossInfo.Products_sales_storehouse_annulus(productsID, Convert.ToInt32(storeID), bDate, eDate, tType);
            if (hList.Rows.Count > 0)
            {
                return hList;
            }
            else
            {
                return null;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
         if (this.userid > 0)
            {
                if (CheckUserPopedoms("X") || CheckUserPopedoms("7-2-1-8"))
                {
                    pName = HTTPRequest.GetString("pname");
                    pBarcode = HTTPRequest.GetString("pbarcode");
                    pID = HTTPRequest.GetInt("pid",0);
                    sID = HTTPRequest.GetInt("sid",0);
                    bDate = (HTTPRequest.GetString("bDate").Trim() != "") ? Convert.ToDateTime(HTTPRequest.GetString("bDate").Trim()) : DateTime.Now;
                    eDate = (HTTPRequest.GetString("eDate").Trim() != "") ? Convert.ToDateTime(HTTPRequest.GetString("eDate").Trim()) : DateTime.Now;

                    sList = ProductsLossInfo.getProducts_Sales_Storehouse(pID,bDate,eDate,sID);
                }
                else
                {
                    AddErrLine("权限不足!");
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
            pagetitle = " 产品日均销量统计";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}