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
    public partial class productsloss_details : PageBase
    {
        public DataTable pList = new DataTable(); //获得产品详情
        public string storehouseName;             //门店名称
        public string storeId;                    //门店编号
        public string productsName;               //产品名称
        public string productsId;                 //产品编号
        public string productsBarcode;            //产品条码
        public string Act;
        public DateTime bDate;
        public DateTime eDate;
        public string sDate;
        public string tDate;
        public string Show = "";                         //判断权限
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.userid > 0)
            {
                if (CheckUserPopedoms("X") || CheckUserPopedoms("7-2-1-5-4-1"))
                {
                    bool ShowMoney = CheckUserPopedoms("7-2-1-5-4-2");
                    bool xshowMoney = CheckUserPopedoms("X");
                    if (ShowMoney || xshowMoney)
                    {
                        Show = "1";
                    }
                    //获取url过来的值
                     storehouseName = HTTPRequest.GetString("sname");
                     storeId = HTTPRequest.GetString("sid");
                     productsName = HTTPRequest.GetString("pname");
                     productsId = HTTPRequest.GetString("pid");
                     productsBarcode = HTTPRequest.GetString("pbard");
                     Act = HTTPRequest.GetString("act");
                     bDate =Convert.ToDateTime(HTTPRequest.GetString("sDate"));
                     eDate =Convert.ToDateTime(HTTPRequest.GetString("stDate"));
                     sDate = bDate.ToString("yyyy-MM-dd");
                     tDate = eDate.ToString("yyyy-MM-dd");

                     if (Act == "act")
                     {
                         pList = ProductsLossInfo.getProductsLossDetails(bDate,eDate, Convert.ToInt32(storeId), Convert.ToInt32(productsId));
                     }
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
            pagetitle = " 报损统计商品详情";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}