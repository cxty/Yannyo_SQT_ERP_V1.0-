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
    public partial class products_sales : PageBase
    {
        public DataTable pList = new DataTable();   //购销产品日均销量
        public DataTable tpList = new DataTable();  //获得产品同比日均销量
        public DataTable hpList = new DataTable();  //获得产品环比日均销量
        public DateTime bDate = DateTime.Now.AddDays(-(DateTime.Now.Day)+1);
        public DateTime eDate = DateTime.Now;
        public int tType;                          //查询类别 0=时间段查看；1=年查看；2=月查看
        public decimal sumA, sumAA, sumAAA, sumB, sumBB, sumBBB;
        public string Act;

        public DataTable getProductsDay_Sales_Details(int tpye,string pID,DateTime btime, DateTime etime)
        {
            tpList = ProductsLossInfo.getProducts_Sales_Details_year_basis(tpye,Convert.ToInt32(pID),btime, etime);//获得同比日均销量
            if (tpList.Rows.Count > 0)
            {
                return tpList;
            }
            else
            {
                return null;
            }
        }
        public DataTable getProducts_Sale_Details_year_annulus(int tpye, string pID, DateTime btime, DateTime etime)
        {
             hpList = ProductsLossInfo.Products_Sale_Details_year_annulus(tpye, Convert.ToInt32(pID), btime, etime);//获得环比日均销量
             if (hpList.Rows.Count > 0)
            {
                return hpList;
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
                    Act = HTTPRequest.GetString("Act");
                    if (ispost)
                    {
                        tType = HTTPRequest.GetInt("tType", 2);
                        bDate = (HTTPRequest.GetString("bDate").Trim() != "") ? Convert.ToDateTime(HTTPRequest.GetString("bDate").Trim()) : DateTime.Now;
                        eDate = (HTTPRequest.GetString("eDate").Trim() != "") ? Convert.ToDateTime(HTTPRequest.GetString("eDate").Trim()) : DateTime.Now;
                        pList = ProductsLossInfo.getProductsDay_Sales_Details(tType, bDate, eDate);         //获得当前日均销量
                    }
                    else
                    {
                        if (Act.IndexOf("act") > -1)
                        {
                            bDate = (HTTPRequest.GetString("bDate").Trim() != "") ? Convert.ToDateTime(HTTPRequest.GetString("bDate").Trim()) : DateTime.Now;
                            eDate = (HTTPRequest.GetString("eDate").Trim() != "") ? Convert.ToDateTime(HTTPRequest.GetString("eDate").Trim()) : DateTime.Now;
                            pList = ProductsLossInfo.getProductsDay_Sales_Details(0, bDate, eDate);

                            DataTable dt = pList.Copy();
                            dt.Columns.RemoveAt(0);
                            DataSet ds = new DataSet();
                            ds.Tables.Add(dt);
                            ds.Tables[0].Columns[0].ColumnName = "商品名称";
                            ds.Tables[0].Columns[1].ColumnName = "商品条码";
                            ds.Tables[0].Columns[2].ColumnName = "购销日均销量";
                            ds.Tables[0].Columns[3].ColumnName = "客户日均销量";

                            CreateExcel(ds.Tables[0],"商品日均销量_"+DateTime.Now.ToString("yyyy-MM-dd")+".xls");
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
            pagetitle = " 产品日均销量统计";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}