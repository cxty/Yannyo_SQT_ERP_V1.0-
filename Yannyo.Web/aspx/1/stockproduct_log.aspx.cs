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
    public partial class stockproduct_log : PageBase
    {
        public string Act = "";
        public bool ShowPrice = false;                      //是否显示金额
        public DateTime bDate = DateTime.Now;		//开始时间
        public DateTime eDate = DateTime.Now;		//结束时间
        
        public int CostPrice =1;                                //是否计算成本,0=显示,1=不显示
        public decimal Product_UPYear =0;              //上年结转数量
        

        public DataSet dSet = new DataSet();           //数据集
        public DataTable dList = new DataTable();     //列表
        public DataTable yList = new DataTable();      //年累计
        public DataTable bList = new DataTable();     //开始月前半部分累计
        public DataTable eList = new DataTable();       //结束月后半部分累计

        public DataTable StorageList = new DataTable();//仓库列表

        public string StorageClassName = "";                           //仓库分类名称
        public int StorageClassNum = 0;                          //仓库分类编号
        public string S_key = "";                                   //产品名称,关键字
        public int StorageID = 0;                                  //仓库编号
        public int ProductID = 0;                                //产品

        public string StorageClassJson = "";                //仓库分类数

        public decimal sum_a = 0;
        public decimal sum_b = 0;
        public decimal sum_c = 0;
        public decimal sum_d = 0;
        public decimal sum_e = 0;
        public decimal sum_f = 0;
        public decimal sum_g = 0;
        public decimal sum_h = 0;
        public decimal sum_i = 0;
        public decimal sum_j = 0;
        public decimal sum_k = 0;

        public decimal sum_y_a = 0;
        public decimal sum_y_b = 0;
        public decimal sum_y_c = 0;
        public decimal sum_y_d = 0;
        public decimal sum_y_e = 0;
        public decimal sum_y_f = 0;
        public decimal sum_y_g = 0;
        public decimal sum_y_h = 0;
        public decimal sum_y_i = 0;
        public decimal sum_y_j = 0;
        public decimal sum_y_k = 0;

        public int thisMonth = 0;
        public int thisYear = 0;

        protected virtual void Page_Load(object sender, EventArgs e)
        {
            Act = HTTPRequest.GetString("Act");
            if (this.userid > 0)
            {
                if (CheckUserPopedoms("X") || CheckUserPopedoms("7-2-1-5-6-1"))
                {
                    if (CheckUserPopedoms("X") || CheckUserPopedoms("7-2-1-5-6-2"))
                    {
                        ShowPrice = true;
                    }
                    bDate =Convert.ToDateTime(( (HTTPRequest.GetString("bDate").Trim() != "") ? Convert.ToDateTime(HTTPRequest.GetString("bDate").Trim()) : Convert.ToDateTime(DateTime.Now.Year + "-" + DateTime.Now.Month + "-1")).ToShortDateString() +" 00:00:00");
                    eDate =Convert.ToDateTime(( (HTTPRequest.GetString("eDate").Trim() != "") ? Convert.ToDateTime(HTTPRequest.GetString("eDate").Trim()) : DateTime.Now).ToShortDateString()+" 23:59:59");
                    
                    
                    ProductID = HTTPRequest.GetInt("ProductID", 0);
                    CostPrice = HTTPRequest.GetInt("CostPrice", 1);
                    StorageID = HTTPRequest.GetInt("StorageID", 0);
                    StorageClassName = Utils.ChkSQL(HTTPRequest.GetString("StorageClassName"));
                    StorageClassNum = HTTPRequest.GetInt("StorageClassNum", 0);
                    S_key =Utils.ChkSQL(HTTPRequest.GetString("S_key"));

                    StorageList = tbStockProductInfo.getStorageNameByClass(StorageClassNum);
                    StorageClassJson = Caches.GetStorageInfoToJson(-1, false, true);

                    if (CostPrice == 1)
                    {
                        ShowPrice = false;
                    }
                    if (Act.IndexOf("Search") > -1)
                    {
                        dSet = Caches.GetProductLogDetails(bDate, eDate, ProductID, CostPrice, StorageID);
                        if (dSet != null)
                        {
                            Product_UPYear =decimal.Parse(dSet.Tables[0].Rows[0][0].ToString());
                            dList = dSet.Tables[1];//查询具体数据
                            yList = dSet.Tables[2];//年累计
                            bList = dSet.Tables[3];//开始月前半部分累计
                            eList = dSet.Tables[4];//结束月后半部分累计

                            
                        }
                    }
                    else 
                    {
                        //导出
                        if (Act.IndexOf("Export") > -1)
                        {
                            dSet = Caches.GetProductLogDetails(bDate, eDate, ProductID, CostPrice, StorageID);
                            if (dSet != null)
                            {
                                Product_UPYear = decimal.Parse(dSet.Tables[0].Rows[0][0].ToString());
                                dList = dSet.Tables[1];//查询具体数据
                                yList = dSet.Tables[2];//年累计
                                bList = dSet.Tables[3];//开始月前半部分累计
                                eList = dSet.Tables[4];//结束月后半部分累计
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
            pagetitle = config.CompanyName + " 库存商品明细";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}