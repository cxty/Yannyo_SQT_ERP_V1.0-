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
    public partial class customers_dataanalysis : PageBase
    {
        public int dType = 1;//分析类型,1=客户,2=业务员,3=促销员,4=产品,5=品牌(产品分类),6=超市系统,7=客户与商品
        public string bDate = "";//开始时间
        public string eDate = "";//结束时间
        public DataTable dList = new DataTable();//数据列表
        public DataTable cList = new DataTable();//获得客户列表
        public decimal AllSumMoney = 0;//总金额
        public decimal sumA;

        public int isIsPool = 0;//是否联营,0=全部,1=联营,2=非联营

        public DataTable dcList = new DataTable();//导出数据
        public string Act = "";
        public int checkValue;
        public int sID;
        public int tLoopid;
        public string tbDate;
        public string teDate;
        public int count;

        protected virtual void Page_Load(object sender, EventArgs e)
        {
            Act = HTTPRequest.GetString("Act");

            if (this.userid > 0)
            {
                if (CheckUserPopedoms("X") || CheckUserPopedoms("7-1-1"))
                {
                     dType = HTTPRequest.GetInt("dType", 0);
                     sID = HTTPRequest.GetInt("sID",0);
                     isIsPool = HTTPRequest.GetInt("isIsPool", 0);
                     bDate = Utils.ChkSQL(HTTPRequest.GetString("bDate"));
                     eDate = Utils.ChkSQL(HTTPRequest.GetString("eDate"));
                     tbDate = bDate + " 00:00:00";
                     teDate = eDate + " 23:59:59";
                    
                     checkValue = HTTPRequest.GetInt("checkValue",0);

                     if (ispost)
                     {
                         if (dType == 7)
                         {
                             cList = DataUtils.getStoresList(Convert.ToDateTime(tbDate), Convert.ToDateTime(teDate));
                           
                         }
                         if (dType > 0 && dType !=7)
                         {
                             dList = DataUtils.GetCustomers_DataAnalysis(dType, Convert.ToDateTime(tbDate), Convert.ToDateTime(teDate), out AllSumMoney, 0, isIsPool);
                         }
                     }
                     else
                     {
                         if (Act.IndexOf("Export") > -1)
                         {
                             dcList = DataUtils.GetCustomers_DataAnalysis(dType, Convert.ToDateTime(tbDate), Convert.ToDateTime(teDate), out AllSumMoney, 0, isIsPool);
                             DataTable dt = dcList.Copy();
                             DataSet ds = new DataSet();
                             //客户
                             if (dType == 1)
                             {
                                 ds.Tables.Add(dt);
                                 ds.Tables[0].Columns[0].ColumnName = "客户名称";
                                 ds.Tables[0].Columns[1].ColumnName = "销售金额";

                                 CreateExcel(ds.Tables[0], "Customer_sales_data_customer_Data_" + Convert.ToDateTime(tbDate).ToShortDateString() + ".xls");
                                 
                             }
                             //业务员
                             if (dType == 2)
                             {
                                 ds.Tables.Add(dt);
                                 ds.Tables[0].Columns[0].ColumnName = "业务员名称";
                                 ds.Tables[0].Columns[1].ColumnName = "销售金额";

                                 CreateExcel(ds.Tables[0], "Customer_sales_data_staff_Data_" + Convert.ToDateTime(tbDate).ToShortDateString() + ".xls");
                                 
                             }
                             //促销员
                             if (dType == 3)
                             {
                                 ds.Tables.Add(dt);
                                 ds.Tables[0].Columns[0].ColumnName = "促销员名称";
                                 ds.Tables[0].Columns[1].ColumnName = "销售金额";

                                 CreateExcel(ds.Tables[0], "Customer_sales_data_promotion_Data_" + Convert.ToDateTime(tbDate).ToShortDateString() + ".xls");

                             }
                             //单品
                             if (dType == 4)
                             {
                                 ds.Tables.Add(dt);
                                 ds.Tables[0].Columns[0].ColumnName = "商品名称";
                                 ds.Tables[0].Columns[1].ColumnName = "销售金额";

                                 CreateExcel(ds.Tables[0], "Customer_sales_data_goods_Data_" + Convert.ToDateTime(tbDate).ToShortDateString() + ".xls");
                                 
                             }
                             //品牌
                             if (dType == 5)
                             {
                                 ds.Tables.Add(dt);
                                 ds.Tables[0].Columns[0].ColumnName = "品牌名称";
                                 ds.Tables[0].Columns[1].ColumnName = "销售金额";


                                 CreateExcel(ds.Tables[0], "Customer_sales_data_brand_Data_" + Convert.ToDateTime(tbDate).ToShortDateString() + ".xls");  
                             }
                             if (dType == 7)
                             {
                                 ds.Tables.Add(dt);
                                 ds.Tables[0].Columns[0].ColumnName = "客户名称";
                                 ds.Tables[0].Columns[1].ColumnName = "商品名称";
                                 ds.Tables[0].Columns[2].ColumnName = "商品数量";
                                 ds.Tables[0].Columns[3].ColumnName = "商品金额";


                                 CreateExcel(ds.Tables[0], "门店商品数据_" + Convert.ToDateTime(tbDate).ToShortDateString() + ".xls");  
                             }
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
            pagetitle = " 客户销售数据分析";
            this.Load += new EventHandler(this.Page_Load);
        }
        public DataTable getStoreProducts(string bDate, string eDate, string sid)
        {
            tbDate = bDate + " 00:00:00";
            teDate = eDate + " 23:59:59";
            dList = DataUtils.GetCustomers_DataAnalysis(dType, Convert.ToDateTime(tbDate), Convert.ToDateTime(teDate), out AllSumMoney, Convert.ToInt32(sid), isIsPool);
            if (dList.Rows.Count > 0)
            {
                return dList;
            }
            else
            {
                return null;
            }
        }
        public int getStoreProductsCount(string bDate, string eDate, string sid)
        {
            tbDate = bDate + " 00:00:00";
            teDate = eDate + " 23:59:59";
            dList = DataUtils.GetCustomers_DataAnalysis(dType, Convert.ToDateTime(tbDate), Convert.ToDateTime(teDate), out AllSumMoney, Convert.ToInt32(sid), isIsPool);
            if (dList.Rows.Count > 0)
            {
                return dList.Rows.Count;
            }
            else
            {
                return 0;
            }
        }
    }
}