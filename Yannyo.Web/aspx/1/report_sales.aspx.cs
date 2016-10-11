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
    public partial class report_sales : PageBase
    {
        public DataTable dList = new DataTable();
        public DataTable cList = new DataTable();
        public DataTable rList = new DataTable();

        public DateTime sDate = DateTime.Now;
        public DateTime bDate = DateTime.Now;
        public DateTime eDate = DateTime.Now;

        public DataTable sSysList = new DataTable();//结算系统列表
        public DataTable ddList = new DataTable();//表内循环用
        public DataTable OrderStpes = new DataTable();//单据步骤

        public int ReDateType = 1;//统计类型，操作时间统计=1,单据时间统计=2
		public int ReType = 1;//商品销售=1,客户销售=2,结算系统=3,业务员（岗位变动）=4,促销员=5,地区统计=6,业务员（单据）=7,出货统计(商品)=8，出货统计(客户)=9
        public int DateType = 0;//列表统计=0,日=1,月=2.年=3
        public int NOJoinSales = 0;//剔除联营,不剔除=0,剔除=1,仅联营=2
        public bool ShowPrice = false;//是否显示金额

        public int tLoopid_b = 0;
        public int tLoopid_a = 0;
        public int tLoopid = 0;

        public decimal MoneyA, MoneyAA, MoneyAAA = 0;
        public decimal MoneyB, MoneyBB, MoneyBBB = 0;
        public decimal MoneyC, MoneyCC, MoneyCCC= 0;
        public decimal MoneyD, MoneyDD, MoneyDDD = 0;
        public decimal MoneyH, MoneyHH, MoneyHHH = 0;
        public decimal MoneyI, MoneyII, MoneyIII = 0;

		public decimal MoneyE, MoneyEE, MoneyEEE = 0;
		public decimal MoneyF, MoneyFF, MoneyFFF = 0;
		public decimal MoneyG, MoneyGG, MoneyGGG = 0;

        public decimal bMoneyA, bMoneyAA, bMoneyAAA = 0;
        public decimal bMoneyB, bMoneyBB, bMoneyBBB = 0;
        public decimal bMoneyC, bMoneyCC, bMoneyCCC = 0;
        public decimal bMoneyD, bMoneyDD, bMoneyDDD = 0;
        public decimal bMoneyH, bMoneyHH, bMoneyHHH = 0;

        public decimal cMoneyA, cMoneyAA, cMoneyAAA = 0;
        public decimal cMoneyB, cMoneyBB, cMoneyBBB = 0;
        public decimal cMoneyC, cMoneyCC, cMoneyCCC = 0;
        public decimal cMoneyD, cMoneyDD, cMoneyDDD = 0;
        public decimal cMoneyH, cMoneyHH, cMoneyHHH = 0;
        public decimal cMoneyI, cMoneyII, cMoneyIII = 0;

		public decimal bMoneyE, bMoneyEE, bMoneyEEE = 0;
		public decimal bMoneyF, bMoneyFF, bMoneyFFF = 0;
		public decimal bMoneyG, bMoneyGG, bMoneyGGG = 0;

		public decimal cMoneyE, cMoneyEE, cMoneyEEE = 0;
		public decimal cMoneyF, cMoneyFF, cMoneyFFF = 0;
		public decimal cMoneyG, cMoneyGG, cMoneyGGG = 0;

        public int StoresID = 0;//客户编号
        public string StoresName = "";//客户名称
        public int PaymentSystemID = 0;//结算系统编号
        public string PaymentSystemName = "";//结算系统名称
        public int oSteps = 5;//单据步骤,默认已经验收确认
        public int dType = 0;//
        public int CostPrice = 0;//成本,0显示成本,1不显示成本

		public int SingleMemberID = 0;//开单员
		public string SingleMemberName = "";//开单员名称

		public string OrderNumber = "";//单据号,逗号隔开

        public string Act = "";
        public DataTable eList = new DataTable();

        /// <summary>
        /// 页面调用
        /// </summary>
        /// <param name="ReType"></param>
        /// <param name="bDate"></param>
        /// <param name="eDate"></param>
        /// <param name="NOJoinSales"></param>
        /// <param name="StoresID"></param>
        /// <param name="PaymentSystemID"></param>
        /// <returns></returns>
        public DataTable GetSalesReport(int ReType,DateTime bDate,DateTime eDate,int NOJoinSales,int StoresID, int PaymentSystemID)
        {
            return DataUtils.GetSalesReport(ReType, bDate, eDate, NOJoinSales, StoresID, PaymentSystemID); ;
        }

        protected virtual void Page_Load(object sender, EventArgs e)
        {
            Act = HTTPRequest.GetString("Act");
            if (this.userid > 0)
            {
                if (CheckUserPopedoms("X") || CheckUserPopedoms("7-2-1-6-1"))
                {

                    if (CheckUserPopedoms("X") || CheckUserPopedoms("7-2-1-6-2"))
                    {
                        ShowPrice = true;
                    }

					OrderNumber = Utils.ChkSQL(HTTPRequest.GetString ("OrderNumber")).Trim();
                    StoresID = HTTPRequest.GetInt("StoresID", 0);
                    StoresName = Utils.ChkSQL(HTTPRequest.GetString("StoresName"));

                    PaymentSystemID = HTTPRequest.GetInt("PaymentSystemID", 0);
                    PaymentSystemName = Utils.ChkSQL(HTTPRequest.GetString("PaymentSystemName")).Trim();
                   
					SingleMemberID = HTTPRequest.GetInt ("SingleMemberID",0);
					SingleMemberName = Utils.ChkSQL (HTTPRequest.GetString ("SingleMemberName")).Trim ();

					if (OrderNumber != "") {
						OrderNumber = "," + OrderNumber + ",";
						OrderNumber = Utils.ReSQLSetTxt(OrderNumber);
					}

                    if (PaymentSystemID == 0)
                    {
                        PaymentSystemInfo psi = tbPaymentSystemInfo.GetPaymentSystemModel(PaymentSystemName);
                        if (psi != null)
                        {
                            PaymentSystemID = psi.PaymentSystemID;
                        }
                    }

                    sDate = (HTTPRequest.GetString("sDate").Trim() != "") ? Convert.ToDateTime(HTTPRequest.GetString("sDate").Trim()) : DateTime.Now;
                    bDate = (HTTPRequest.GetString("bDate").Trim() != "") ? Convert.ToDateTime(HTTPRequest.GetString("bDate").Trim()) :Convert.ToDateTime(DateTime.Now.Year +"-"+ DateTime.Now.Month+"-1");
                    eDate = (HTTPRequest.GetString("eDate").Trim() != "") ? Convert.ToDateTime(HTTPRequest.GetString("eDate").Trim()) : DateTime.Now;

                    ReDateType = HTTPRequest.GetInt("ReDateType", 1);//统计类型
                    ReType = HTTPRequest.GetInt("ReType", 1);//默认商品销售
                    DateType = HTTPRequest.GetInt("DateType", 0);//默认列表统计
                    NOJoinSales = HTTPRequest.GetInt("NOJoinSales", 0);
                    dType = HTTPRequest.GetInt("dType",0);
                    oSteps = HTTPRequest.GetInt("oSteps", 5);
                    CostPrice = HTTPRequest.GetInt("CostPrice", 1);//默认不计算成本
                    OrderStpes = Orders.GetOrderSteps();

                    if (CostPrice == 1)
                    {
                        ShowPrice = false;
                    }

                    sSysList = tbPaymentSystemInfo.GetPaymentSystemList(" 1=1 order by PaymentSystemID desc").Tables[0];

                    string tSQL = "";
                    if (ispost)
                    {
						//AddErrLine ("ReType:"+ReType+", bDate:"+bDate+", eDate:"+eDate+", NOJoinSales:"+NOJoinSales+", StoresID:"+StoresID+", PaymentSystemID:"+PaymentSystemID+", oSteps:"+oSteps+", dType:"+dType+", CostPrice:"+CostPrice+",SingleMemberID:"+SingleMemberID+",OrderNumber:"+OrderNumber);

                        dList = Caches.GetSalesReport(ReDateType,ReType, bDate, eDate, NOJoinSales, StoresID, PaymentSystemID, oSteps, dType, CostPrice, SingleMemberID, OrderNumber);

                        //客户方式,销售，发出
                        if (ReType == 2 || ReType == 9)
                        {
                            tSQL = " 0=0 ";
                            if (StoresID > 0)
                            {
                                tSQL += " and StoresID=" + StoresID;
                            }
                            cList = tbStoresInfo.GetStoresInfoList(" " + tSQL + " order by sAppendTime desc").Tables[0];
                            int pCount = 0;

                            cList.Columns.Add("pCount", typeof(System.Int32));

                            foreach (DataRow dr in cList.Rows)
                            {
                                pCount = 0;
                                foreach (DataRow ddr in dList.Rows)
                                {
                                    if (dr["StoresID"].ToString() == ddr["StoresID"].ToString())
                                    {
                                        //if (Convert.ToDecimal(ddr["oQuantity"]) > 0 || Convert.ToDecimal(ddr["oQuantity_t"]) > 0 || Convert.ToDecimal(ddr["oQuantity_z"]) > 0 || Convert.ToDecimal(ddr["oQuantity_y"]) > 0)
                                        {
                                            pCount++;
                                        }
                                    }
                                }
                                dr["pCount"] = pCount > 0 ? pCount + 1 : 0;
                            }
                        }
						//开单员(销售)=10，开单员(出货)=11
						if(ReType == 10 || ReType == 11){
							tSQL = " 0=0 ";


						}
                        //结算系统方式
                        if (ReType == 3)
                        {
                            tSQL = " 1=1 ";
                            if (PaymentSystemID > 0)
                            {
                                tSQL += " and  PaymentSystemID=" + PaymentSystemID;
                            }
                            cList = tbPaymentSystemInfo.GetPaymentSystemList(" " + tSQL + " order by pAppendTime desc").Tables[0];
                            int pCount = 0;

                            cList.Columns.Add("pCount", typeof(System.Int32));

                            foreach (DataRow dr in cList.Rows)
                            {
                                pCount = 0;
                                foreach (DataRow ddr in dList.Rows)
                                {
                                    if (dr["PaymentSystemID"].ToString() == ddr["PaymentSystemID"].ToString())
                                    {
                                        //if (Convert.ToDecimal(ddr["oQuantity"]) > 0 || Convert.ToDecimal(ddr["oQuantity_t"]) > 0 || Convert.ToDecimal(ddr["oQuantity_z"]) > 0 || Convert.ToDecimal(ddr["oQuantity_y"]) > 0)
                                        {
                                            pCount++;
                                        }
                                    }
                                }
                                dr["pCount"] = pCount > 0 ? pCount + 1 : 0;
                            }
                        }
                        // else
                        // {
                        //     cList = DataClass.GetProductClassInfoList("").Tables[0];
                        // }
                        //业务员,促销员方式
                        if (ReType == 4 || ReType==5 || ReType==7)
                        {
                            tSQL = " 0=0 ";

                            cList = tbStaffInfo.GetStaffInfoList(" " + tSQL + " order by sAppendTime desc").Tables[0];
                            int pCount = 0;

                            cList.Columns.Add("pCount", typeof(System.Int32));

                            foreach (DataRow dr in cList.Rows)
                            {
                                pCount = 0;
                                foreach (DataRow ddr in dList.Rows)
                                {
                                    if (dr["StaffID"].ToString() == ddr["StaffID"].ToString())
                                    {
                                        //if (Convert.ToDecimal(ddr["oQuantity"]) > 0 || Convert.ToDecimal(ddr["oQuantity_t"]) > 0 || Convert.ToDecimal(ddr["oQuantity_z"]) > 0 || Convert.ToDecimal(ddr["oQuantity_y"]) > 0)
                                        {
                                            pCount++;
                                        }
                                    }
                                }
                                dr["pCount"] = pCount > 0 ? pCount + 1 : 0;
                            }
                        }
                        //地区统计
                        if (ReType == 6)
                        {
                            int rCount = 0;
                            int pCount = 0;
                            rList = tbRegionInfo.GetRegionInfoList(" 0=0 order by rUpID asc").Tables[0];

                            DataRow r_dr = rList.NewRow();
                            r_dr["RegionID"] = 0;
                            r_dr["rName"] = "未归类";
                            r_dr["rUpID"] = 0;
                            r_dr["rOrder"] = 0;
                            r_dr["rState"] = 0;
                            r_dr["rAppendTime"] = DateTime.Now;

                            rList.Rows.Add(r_dr);

                            rList.Columns.Add("pCount", typeof(System.Int32));

                            rList.AcceptChanges();

                            tSQL = " 0=0 ";
                            if (StoresID > 0)
                            {
                                tSQL += "   and StoresID=" + StoresID;
                            }
                            cList = tbStoresInfo.GetStoresInfoList(" " + tSQL + " order by sAppendTime desc").Tables[0];
                            cList.Columns.Add("pCount", typeof(System.Int32));

                            foreach (DataRow dr in cList.Rows)
                            {
                                
                                pCount = 0;
                                foreach (DataRow ddr in dList.Rows)
                                {
                                    if (dr["StoresID"].ToString() == ddr["StoresID"].ToString())
                                    {
                                        pCount++;
                                    }
                                }
                                
                                dr["pCount"] = pCount > 0 ? pCount + 1 : 0;
                            }

                            foreach (DataRow _dr in rList.Rows)
                            {
                                rCount = 0;

                                foreach (DataRow _ddr in cList.Rows)
                                {
                                    if (_dr["RegionID"].ToString() == _ddr["RegionID"].ToString())
                                    {
                                        rCount += Convert.ToInt32(_ddr["pCount"].ToString());
                                    }
                                }
                                _dr["pCount"] = rCount > 0 ? rCount + 1 : 0;

                            }

                        }
                    }
                    else
                    {
                        if (Act.IndexOf("Export") > -1)
                        {
                            //商品方式，销售，发出
                            if (ReType == 1 || ReType==8)
                            {
                                eList = Caches.GetSalesReport(ReDateType,ReType, bDate, eDate, NOJoinSales, StoresID, PaymentSystemID, oSteps, dType, CostPrice, SingleMemberID, OrderNumber);
                                
                                DataTable dt = eList.Copy();

                                dt.Columns.RemoveAt(0);
                                dt.Columns.RemoveAt(4);
                                dt.Columns.RemoveAt(4);
                                dt.Columns.RemoveAt(4);
                                dt.Columns.RemoveAt(4);
                                dt.Columns.RemoveAt(4);
                                dt.Columns.RemoveAt(5);
                                dt.Columns.RemoveAt(17);
                                dt.Columns.RemoveAt(17);
                                dt.Columns.RemoveAt(17);
                                dt.Columns.RemoveAt(17);
                                dt.Columns.RemoveAt(17);
                                dt.Columns.RemoveAt(17);
                                dt.Columns.RemoveAt(17);
                                DataSet ds = new DataSet();
                                ds.Tables.Add(dt);
                                ds.Tables[0].Columns[0].ColumnName = "商品默认成本";
                                ds.Tables[0].Columns[1].ColumnName = "商品加权平均成本";
                                ds.Tables[0].Columns[2].ColumnName = "商品条码";
                                ds.Tables[0].Columns[3].ColumnName = "商品名称";
                                ds.Tables[0].Columns[4].ColumnName = "装件数";
                                ds.Tables[0].Columns[5].ColumnName = "销售发货数量";
                                ds.Tables[0].Columns[6].ColumnName = "销售发货金额";
                                ds.Tables[0].Columns[7].ColumnName = "销售退货数量";
                                ds.Tables[0].Columns[8].ColumnName = "销售退货金额";

                                ds.Tables[0].Columns[9].ColumnName = "赠品数量";
                                ds.Tables[0].Columns[10].ColumnName = "赠品金额";
                                ds.Tables[0].Columns[11].ColumnName = "样品数量";
                                ds.Tables[0].Columns[12].ColumnName = "样品金额";
                                ds.Tables[0].Columns[13].ColumnName = "坏货数量";
                                ds.Tables[0].Columns[14].ColumnName = "坏货金额";
                                ds.Tables[0].Columns[15].ColumnName = "销售赠品数量";
                                ds.Tables[0].Columns[16].ColumnName = "销售赠品金额";

								CreateExcel(ds.Tables[0], "Sales_Data_" + bDate.ToShortDateString() + ".xls");
                            }
                            //客户方式，销售，发出
                            if (ReType == 2 || ReType==9)
                            {
                                eList = Caches.GetSalesReport(ReDateType,ReType, bDate, eDate, NOJoinSales, StoresID, PaymentSystemID, oSteps, dType, CostPrice, SingleMemberID, OrderNumber);
                                DataTable dt = eList.Copy();

                                dt.Columns.RemoveAt(0);
                                dt.Columns.RemoveAt(0);
                                DataSet ds = new DataSet();
                                ds.Tables.Add(dt);

                                ds.Tables[0].Columns[0].ColumnName = "客户名称";
                                ds.Tables[0].Columns[1].ColumnName = "商品加权平均成本";
                                ds.Tables[0].Columns[2].ColumnName = "商品默认成本";
                                ds.Tables[0].Columns[3].ColumnName = "商品条码";
                                ds.Tables[0].Columns[4].ColumnName = "商品名称";
                                ds.Tables[0].Columns[5].ColumnName = "装件数";
                                ds.Tables[0].Columns[6].ColumnName = "销售发货数量";
                                ds.Tables[0].Columns[7].ColumnName = "销售发货金额";
                                ds.Tables[0].Columns[8].ColumnName = "销售退货数量";
                                ds.Tables[0].Columns[9].ColumnName = "销售退货金额";
                                ds.Tables[0].Columns[10].ColumnName = "赠品数量";
                                ds.Tables[0].Columns[11].ColumnName = "赠品金额";
                                ds.Tables[0].Columns[12].ColumnName = "样品数量";
                                ds.Tables[0].Columns[13].ColumnName = "样品金额";
                                ds.Tables[0].Columns[14].ColumnName = "销售赠品数量";
                                ds.Tables[0].Columns[15].ColumnName = "销售赠品金额";

								CreateExcel(ds.Tables[0], "Sales_Data_" + bDate.ToShortDateString() + ".xls");
                            }
                            //结算系统
                            if (ReType == 3)
                            {
                                eList = Caches.GetSalesReport(ReDateType,ReType, bDate, eDate, NOJoinSales, StoresID, PaymentSystemID, oSteps, dType, CostPrice, SingleMemberID, OrderNumber);
                                DataTable dt = eList.Copy();
                                dt.Columns.RemoveAt(0);
                                dt.Columns.RemoveAt(1);
                                dt.Columns.RemoveAt(11);
                                dt.Columns.RemoveAt(11);
                                dt.Columns.RemoveAt(11);
                                dt.Columns.RemoveAt(11);
                                dt.Columns["ProductName"].SetOrdinal(1);
                                dt.Columns["pBarcode"].SetOrdinal(2);
                                DataSet ds = new DataSet();
                                ds.Tables.Add(dt);
                                ds.Tables[0].Columns[0].ColumnName = "结算系统名称";
                                ds.Tables[0].Columns[1].ColumnName = "商品名称";
                                ds.Tables[0].Columns[2].ColumnName = "商品条码";
                                ds.Tables[0].Columns[3].ColumnName = "销售数量";
                                ds.Tables[0].Columns[4].ColumnName = "销售金额";
                                ds.Tables[0].Columns[5].ColumnName = "退货数量";
                                ds.Tables[0].Columns[6].ColumnName = "退货金额";
                                ds.Tables[0].Columns[7].ColumnName = "赠品数量";
                                ds.Tables[0].Columns[8].ColumnName = "赠品金额";
                                ds.Tables[0].Columns[9].ColumnName = "样品数量";
                                ds.Tables[0].Columns[10].ColumnName = "样品金额";
								CreateExcel(ds.Tables[0], "Sales_Data_" + bDate.ToShortDateString() + ".xls");
                            }
                            //业务员,促销员方式
                            if (ReType == 4 || ReType==5 || ReType ==7)
                            {
                                eList = Caches.GetSalesReport(ReDateType,ReType, bDate, eDate, NOJoinSales, StoresID, PaymentSystemID, oSteps, dType, CostPrice, SingleMemberID, OrderNumber);
                                DataTable dt = eList.Copy();
                                dt.Columns.RemoveAt(0);
                                dt.Columns.RemoveAt(0);
                                DataSet ds = new DataSet();
                                ds.Tables.Add(dt);
                                ds.Tables[0].Columns[0].ColumnName = "姓名";
                                ds.Tables[0].Columns[1].ColumnName = "商品加权平均成本";
                                ds.Tables[0].Columns[2].ColumnName = "商品默认成本";
                                ds.Tables[0].Columns[3].ColumnName = "商品条码";
                                ds.Tables[0].Columns[4].ColumnName = "商品名称";
                                ds.Tables[0].Columns[5].ColumnName = "装件数";
                                ds.Tables[0].Columns[6].ColumnName = "销售发货数量";
                                ds.Tables[0].Columns[7].ColumnName = "销售发货金额";
                                ds.Tables[0].Columns[8].ColumnName = "销售退货数量";
                                ds.Tables[0].Columns[9].ColumnName = "销售退货金额";
                                ds.Tables[0].Columns[10].ColumnName = "赠品数量";
                                ds.Tables[0].Columns[11].ColumnName = "赠品金额";
                                ds.Tables[0].Columns[12].ColumnName = "样品数量";
                                ds.Tables[0].Columns[13].ColumnName = "样品金额";
                                ds.Tables[0].Columns[14].ColumnName = "销售赠品数量";
                                ds.Tables[0].Columns[15].ColumnName = "销售赠品金额";

								CreateExcel(ds.Tables[0], "Sales_Data_" + bDate.ToShortDateString() + ".xls");
                            }
                            //按地区
                            if (ReType == 6)
                            {
                                eList = Caches.GetSalesReport(ReDateType,ReType, bDate, eDate, NOJoinSales, StoresID, PaymentSystemID, oSteps, dType, CostPrice, SingleMemberID, OrderNumber);
                                DataTable dt = eList.Copy();

                                dt.Columns.RemoveAt(0);
                                dt.Columns.RemoveAt(0);
                                dt.Columns.RemoveAt(1);
                                dt.Columns.RemoveAt(2);
                                DataSet ds = new DataSet();
                                ds.Tables.Add(dt);

                                ds.Tables[0].Columns[0].ColumnName = "客户名称";
                                ds.Tables[0].Columns[1].ColumnName = "地区";
                                ds.Tables[0].Columns[2].ColumnName = "商品加权平均成本";
                                ds.Tables[0].Columns[3].ColumnName = "商品默认成本";
                                ds.Tables[0].Columns[4].ColumnName = "商品条码";
                                ds.Tables[0].Columns[5].ColumnName = "商品名称";
                                ds.Tables[0].Columns[6].ColumnName = "装件数";
                                ds.Tables[0].Columns[7].ColumnName = "销售发货数量";
                                ds.Tables[0].Columns[8].ColumnName = "销售发货金额";
                                ds.Tables[0].Columns[9].ColumnName = "销售退货数量";
                                ds.Tables[0].Columns[10].ColumnName = "销售退货金额";
                                ds.Tables[0].Columns[11].ColumnName = "赠品数量";
                                ds.Tables[0].Columns[12].ColumnName = "赠品金额";
                                ds.Tables[0].Columns[13].ColumnName = "样品数量";
                                ds.Tables[0].Columns[14].ColumnName = "样品金额";
                                ds.Tables[0].Columns[15].ColumnName = "销售赠品数量";
                                ds.Tables[0].Columns[16].ColumnName = "销售赠品金额";

								CreateExcel(ds.Tables[0], "Sales_Data_" + bDate.ToShortDateString() + ".xls");
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
            pagetitle = config.CompanyName + " 销售报表";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}