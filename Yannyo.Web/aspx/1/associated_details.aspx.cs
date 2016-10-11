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
    public partial class associated_details : PageBase
    {
        public DataTable rList = new DataTable();  //地区信息
        public DataTable mList = new DataTable();
        public DataTable sList = new DataTable();
        public DataTable pList = new DataTable();  //获得联营库存产品详情
        public DataTable dList = new DataTable();  //导出数据

        public DateTime bDate =DateTime.Now;       //查询日期
        public int sel_rId;                      //区域id
        public int sType;                       //联营类型 
        public int tType;                       //统计方式
        public string Act = "";
        
        public string Show;
        public int tLoopid;
        public int pCount;
        public decimal sumA, sumB, sumC,sumD;

        public DataTable getProductDetails(string sID,int qID)
        { 
            sType = HTTPRequest.GetInt("aID", -1);           //接收联营类型
            bDate = (HTTPRequest.GetString("bDate").Trim() != "") ? Convert.ToDateTime(HTTPRequest.GetString("bDate").Trim()) : DateTime.Now; //获得日期
            pList = ProductsLossInfo.getProductDetailsByStorehouseID(Convert.ToInt32(sID), sType, bDate,qID);
            if (pList.Rows.Count > 0)
            {
                return pList;
            }
            else
            {
                return null;
            }
        }
        public int p_count(string sID,int qID)
        {
            sType = HTTPRequest.GetInt("aID", -1);           //接收联营类型
            bDate = (HTTPRequest.GetString("bDate").Trim() != "") ? Convert.ToDateTime(HTTPRequest.GetString("bDate").Trim()) : DateTime.Now; //获得日期
            pList = ProductsLossInfo.getProductDetailsByStorehouseID(Convert.ToInt32(sID), sType, bDate,qID);
            if (pList.Rows.Count > 0)
            {
                return pList.Rows.Count;
            }
            else
            {
                return 0;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Act = HTTPRequest.GetString("Act");
            if (this.userid > 0)
            {
                if (CheckUserPopedoms("X") || CheckUserPopedoms("7-1-1-6-1"))
                {
                    bDate = (HTTPRequest.GetString("bDate").Trim() != "") ? Convert.ToDateTime(HTTPRequest.GetString("bDate").Trim()) : DateTime.Now; //获得日期
                    tType = HTTPRequest.GetInt("tType", 0);  //获取统计类型
                    rList = storehouseStorage.RegionName();  //获得地区名称
                    //合成统计
                    if (tType == 0)
                    {
                        sList = ProductsLossInfo.getStoresName(bDate);
                        sType = HTTPRequest.GetInt("aID", -1);           //接收联营类型
                    }
                    //分步统计
                    if (tType == 1)
                    {
                        bool ShowMoney = CheckUserPopedoms("7-1-1-6-2");
                        bool xshowMoney = CheckUserPopedoms("X");
                        if (ShowMoney || xshowMoney)
                        {
                            Show = "1";
                        }
                        sType = HTTPRequest.GetInt("aID", -1);           //接收联营类型
                        sel_rId = HTTPRequest.GetInt("reginID", 0);      //接收选择的地区ID
                      

                        mList = ProductsLossInfo.getStorehouseProductsDetails(sel_rId, sType, bDate);
                    }
                    //导出联营库存数
                    if (Act.IndexOf("Export") > -1)
                    {
                        bDate = (HTTPRequest.GetString("Date").Trim() != "") ? Convert.ToDateTime(HTTPRequest.GetString("Date").Trim()) : DateTime.Now; //获得日期
                        tType = HTTPRequest.GetInt("tjType",0);
                        sType = HTTPRequest.GetInt("Associated", 0);

                        if (tType == 0)
                        {
                            dList = ProductsLossInfo.getProductsLossExportData(bDate, bDate, sType);
                            DataTable dt = new DataTable();
                            dt = dList.Copy();
                            dt.Columns.RemoveAt(0);
                            dt.Columns.RemoveAt(0);
                            DataSet ds = new DataSet();
                            ds.Tables.Add(dt);
                            ds.Tables[0].Columns[0].ColumnName = "门店名称";
                            ds.Tables[0].Columns[1].ColumnName = "商品名称";
                            ds.Tables[0].Columns[2].ColumnName = "商品条码";
                            ds.Tables[0].Columns[3].ColumnName = "商品品牌";
                            ds.Tables[0].Columns[4].ColumnName = "库存数量";


                            CreateExcel(ds.Tables[0], "Data_" + bDate + ".xls");
                            
                        }
                        if (tType == 1)
                        {
                            sel_rId = HTTPRequest.GetInt("reginID", 0);      //接收选择的地区ID
                            dList = ProductsLossInfo.getStorehouseProductsDetails(sel_rId, sType, bDate);
                            DataTable dt = new DataTable();
                            dt = dList.Copy();
                            dt.Columns.RemoveAt(2);
                            dt.Columns.RemoveAt(4);
                            DataSet ds = new DataSet();
                            ds.Tables.Add(dt);
                            ds.Tables[0].Columns[0].ColumnName = "门店名称";
                            ds.Tables[0].Columns[1].ColumnName = "门店类型";
                            ds.Tables[0].Columns[2].ColumnName = "库存数量";
                            ds.Tables[0].Columns[3].ColumnName = "销售金额";
                            ds.Tables[0].Columns[4].ColumnName = "截止日期";


                            CreateExcel(ds.Tables[0], "Data_" + bDate + ".xls");
                            
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
            pagetitle = "联营统计";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}