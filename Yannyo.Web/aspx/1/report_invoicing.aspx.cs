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
    public partial class report_invoicing : PageBase
    {
        public DataTable ProductClassList = new DataTable();
        public DataTable StorageList = new DataTable();
       public DataTable dList = new DataTable();
       public DateTime sDate = DateTime.Now;
       public DateTime eDate = DateTime.Now;
       public int ProductsID = 0;//商品编号
       public int StorageID = 0;//仓库编号
       public int ReType = 0;//报表类型0日报,,1月报.2年报,3区间
       public decimal MoneyA, MoneyB, MoneyC, MoneyD, MoneyE = 0;
       public decimal numA, numB, numC, numD, numE = 0;
       public decimal numAA, numBB, numCC, numDD, numEE = 0;
       public bool ShowPrice = false;//是否显示金额
       public int DataType = 0;//返回表类型,1存档数据,2实算数据
        protected virtual void Page_Load(object sender, EventArgs e)
        {
            if (this.userid > 0)
            {
                if (CheckUserPopedoms("X") || CheckUserPopedoms("7-2-1-5-1"))
                {
                    if (CheckUserPopedoms("X") || CheckUserPopedoms("7-2-1-5-2"))
                    {
                        ShowPrice = true;
                    }

                    StorageList = tbStorageInfo.GetStorageInfoList(" sState=0 ").Tables[0];
                    sDate = (HTTPRequest.GetString("sDate").Trim() != "") ? Convert.ToDateTime(HTTPRequest.GetString("sDate").Trim()) : DateTime.Now;
                    eDate = (HTTPRequest.GetString("eDate").Trim() != "") ? Convert.ToDateTime(HTTPRequest.GetString("eDate").Trim()) : DateTime.Now;
                    ProductsID = HTTPRequest.GetInt("ProductsID",0);
                    StorageID = HTTPRequest.GetInt("StorageID",0);
                    ReType = HTTPRequest.GetInt("ReType",1);
                    if (StorageID > 0)
                    {
                        ProductClassList = DataClass.GetProductClassInfoList(" 1=1 order by pOrder,pAppendTime desc").Tables[0];
                        if (ReType != 3)
                        {
                            dList = Orders.GetInvoicingReport(ProductsID, StorageID, sDate, ReType, out DataType, 0);
                        }
                        else {
                            dList = Orders.GetInvoicingReport(ProductsID, StorageID, sDate, ReType, out DataType, 0, eDate);
                        }
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
            pagetitle = config.CompanyName+ " 进销存报表";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}