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
using Yannyo.Public;

namespace Yannyo.Web
{
    public partial class orderlist : PageBase
    {
        public DataTable dList = new DataTable();
        public int pagesize;
        public int pageindex;
        public int pagetotal;
        public string Act = "";
		public string AllOrderList = "";//导出单据中是否包含子单据
        public string S_key = "";
        public int ordertype = 0;//单据类型
        public string ordertypeStr = "";//单据类型联合检索
        public int StoresSupplierID = 0;//客户,供货商
        public string StoresSupplier = "";//客户,供货商

        public int StorageID = 0;//仓库编号
        public string StorageName = "";//仓库名称

        public string oOrderNum = "";//单据编号
        public int StaffID = 0;//业务员
        public string StaffName = "";
        public int UserID = 0;//操作员
        public string UserName = "";
        public string oCustomersOrderID = "";//客户订单号
        public string oOrderDateTimeB = "";//单据时间,起点
        public string oOrderDateTimeE = "";//单据时间,结束

        public string dDateTimeB = "";//操作时间,起点
        public string dDateTimeE = "";//操作时间,结束

        public int sType = 1;//统计时间,1=单据,2=操作

        public int dType = -2;//操作类型
        public int dType_b = -2;//操作类型

        public int oState = -1;//单据状态
        public int oSteps = -1;//单据步骤
        public int NextID = 0;//差额单据是否已处理
        public DataTable OrderStpes = new DataTable();
        public string ProductsName = "";//产品名称
        public int ProductsID = 0;//产品编号

        public decimal SUMMoney = 0;//合计总金额
        protected virtual void Page_Load(object sender, EventArgs e)
        {
            pagesize = 30;
            PageBarHTML = "";
            string tSQL = "";

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
					AllOrderList = HTTPRequest.GetFormString ("AllOrderList");
                }
                else
                {
                    Act = HTTPRequest.GetQueryString("Act");
                    S_key = Utils.ChkSQL(HTTPRequest.GetQueryString("S_key"));
					AllOrderList = HTTPRequest.GetQueryString ("AllOrderList");
                }
                ordertype = HTTPRequest.GetInt("ordertype", 0);
                ordertypeStr = Utils.ChkSQL(HTTPRequest.GetString("ordertypeStr"));
                string _otypestr = "0";

                switch (ordertype)
                {
                    case 1://采购入库=1
                        if (CheckUserPopedoms("X") || CheckUserPopedoms("3-1-1-8"))
                        {
                            if (ordertypeStr.Trim() != "")
                            {
                                if (ordertypeStr.IndexOf("|1|") > -1)
                                {
                                    _otypestr += ",1";
                                }
                            }
                            else
                            {
                                _otypestr += ",1";
                            }
                        }
                        else
                        {
                            AddErrLine("权限不足,无法浏览 采购入库单 列表!");
                        }
                        break;
                    case 2://采购退货=2
                        if (CheckUserPopedoms("X") || CheckUserPopedoms("3-1-2-8"))
                        {
                            if (ordertypeStr.Trim() != "")
                            {
                                if (ordertypeStr.IndexOf("|2|") > -1)
                                {
                                    _otypestr += ",2";
                                }
                            }
                            else
                            {
                                _otypestr += ",2";
                            }
                        }
                        else
                        {
                            AddErrLine("权限不足,无法浏览 采购退货单 列表!");
                        }
                        break;
                    case 3://销售发货=3
                        if (CheckUserPopedoms("X") || CheckUserPopedoms("3-2-1-8"))
                        {
                            if (ordertypeStr.Trim() != "")
                            {
                                if (ordertypeStr.IndexOf("|3|") > -1)
                                {
                                    _otypestr += ",3";
                                }
                            }
                            else
                            {
                                _otypestr += ",3";
                            }
                        }
                        else
                        {
                            AddErrLine("权限不足,无法浏览 销售发货单 列表!");
                        }
                        break;
                    case 4://销售退货=4
                        if (CheckUserPopedoms("X") || CheckUserPopedoms("3-2-2-8"))
                        {
                            if (ordertypeStr.Trim() != "")
                            {
                                if (ordertypeStr.IndexOf("|4|") > -1)
                                {
                                    _otypestr += ",4";
                                }
                            }
                            else
                            {
                                _otypestr += ",4";
                            }
                        }
                        else
                        {
                            AddErrLine("权限不足,无法浏览 销售退货单 列表!");
                        }
                        break;
                    case 5://赠品=5
                        if (CheckUserPopedoms("X") || CheckUserPopedoms("3-2-3-8"))
                        {
                            if (ordertypeStr.Trim() != "")
                            {
                                if (ordertypeStr.IndexOf("|5|") > -1)
                                {
                                    _otypestr += ",5";
                                }
                            }
                            else
                            {
                                _otypestr += ",5";
                            }
                        }
                        else
                        {
                            AddErrLine("权限不足,无法浏览 赠品单 列表!");
                        }
                        break;
                    case 6://样品=6
                        if (CheckUserPopedoms("X") || CheckUserPopedoms("3-2-4-8"))
                        {
                            if (ordertypeStr.Trim() != "")
                            {
                                if (ordertypeStr.IndexOf("|6|") > -1)
                                {
                                    _otypestr += ",6";
                                }
                            }
                            else
                            {
                                _otypestr += ",6";
                            }
                        }
                        else
                        {
                            AddErrLine("权限不足,无法浏览 样品单 列表!");
                        }
                        break;
                    case 7://代购=7
                        if (CheckUserPopedoms("X") || CheckUserPopedoms("3-2-5-8"))
                        {
                            if (ordertypeStr.Trim() != "")
                            {
                                if (ordertypeStr.IndexOf("|7|") > -1)
                                {
                                    _otypestr += ",7";
                                }
                            }
                            else
                            {
                                _otypestr += ",7";
                            }
                        }
                        else
                        {
                            AddErrLine("权限不足,无法浏览 代购单 列表!");
                        }
                        break;
                    case 8://库存调整=8
                        if (CheckUserPopedoms("X") || CheckUserPopedoms("3-3-2-8"))
                        {
                            if (ordertypeStr.Trim() != "")
                            {
                                if (ordertypeStr.IndexOf("|8|") > -1)
                                {
                                    _otypestr += ",8";
                                }
                            }
                            else
                            {
                                _otypestr += ",8";
                            }
                        }
                        else
                        {
                            AddErrLine("权限不足,无法浏览 库存调整单 列表!");
                        }
                        break;
                    case 9://库存调拨=9
                        if (CheckUserPopedoms("X") || CheckUserPopedoms("3-3-1-8"))
                        {
                            if (ordertypeStr.Trim() != "")
                            {
                                if (ordertypeStr.IndexOf("|9|") > -1)
                                {
                                    _otypestr += ",9";
                                }
                            }
                            else
                            {
                                _otypestr += ",9";
                            }
                        }
                        else
                        {
                            AddErrLine("权限不足,无法浏览 库存调拨单 列表!");
                        }
                        break;
                    case 10://坏货=10
                        if (CheckUserPopedoms("X") || CheckUserPopedoms("3-3-3-8"))
                        {
                            if (ordertypeStr.Trim() != "")
                            {
                                if (ordertypeStr.IndexOf("|10|") > -1)
                                {
                                    _otypestr += ",10";
                                }
                            }
                            else
                            {
                                _otypestr += ",10";
                            }
                        }
                        else
                        {
                            AddErrLine("权限不足,无法浏览 坏货单 列表!");
                        }
                        break;
                    case 11://换货=11
                        if (CheckUserPopedoms("X") || CheckUserPopedoms("3-2-6-8"))
                        {
                            if (ordertypeStr.Trim() != "")
                            {
                                if (ordertypeStr.IndexOf("|11|") > -1)
                                {
                                    _otypestr += ",11";
                                }
                            }
                            else
                            {
                                _otypestr += ",11";
                            }
                        }
                        else
                        {
                            AddErrLine("权限不足,无法浏览 坏货单 列表!");
                        }
                        break;
                    default:
                        if (CheckUserPopedoms("X") || CheckUserPopedoms("3-1-1-8"))
                        {
                            if (ordertypeStr.Trim() != "")
                            {
                                if (ordertypeStr.IndexOf("|1|") > -1)
                                {
                                    _otypestr += ",1";
                                }
                            }
                            else
                            {
                                _otypestr += ",1";
                            }
                        }
                        if (CheckUserPopedoms("X") || CheckUserPopedoms("3-1-2-8"))
                        {
                            if (ordertypeStr.Trim() != "")
                            {
                                if (ordertypeStr.IndexOf("|2|") > -1)
                                {
                                    _otypestr += ",2";
                                }
                            }
                            else
                            {
                                _otypestr += ",2";
                            }
                        }
                        if (CheckUserPopedoms("X") || CheckUserPopedoms("3-2-1-8"))
                        {
                            if (ordertypeStr.Trim() != "")
                            {
                                if (ordertypeStr.IndexOf("|3|") > -1)
                                {
                                    _otypestr += ",3";
                                }
                            }
                            else
                            {
                                _otypestr += ",3";
                            }
                        }
                        if (CheckUserPopedoms("X") || CheckUserPopedoms("3-2-2-8"))
                        {
                            if (ordertypeStr.Trim() != "")
                            {
                                if (ordertypeStr.IndexOf("|4|") > -1)
                                {
                                    _otypestr += ",4";
                                }
                            }
                            else
                            {
                                _otypestr += ",4";
                            }
                        }
                        if (CheckUserPopedoms("X") || CheckUserPopedoms("3-2-3-8"))
                        {
                            if (ordertypeStr.Trim() != "")
                            {
                                if (ordertypeStr.IndexOf("|5|") > -1)
                                {
                                    _otypestr += ",5";
                                }
                            }
                            else
                            {
                                _otypestr += ",5";
                            }
                        }
                        if (CheckUserPopedoms("X") || CheckUserPopedoms("3-2-4-8"))
                        {
                            if (ordertypeStr.Trim() != "")
                            {
                                if (ordertypeStr.IndexOf("|6|") > -1)
                                {
                                    _otypestr += ",6";
                                }
                            }
                            else
                            {
                                _otypestr += ",6";
                            }
                        }
                        if (CheckUserPopedoms("X") || CheckUserPopedoms("3-2-5-8"))
                        {
                            if (ordertypeStr.Trim() != "")
                            {
                                if (ordertypeStr.IndexOf("|7|") > -1)
                                {
                                    _otypestr += ",7";
                                }
                            }
                            else
                            {
                                _otypestr += ",7";
                            }
                        }
                        if (CheckUserPopedoms("X") || CheckUserPopedoms("3-3-1-8"))
                        {
                            if (ordertypeStr.Trim() != "")
                            {
                                if (ordertypeStr.IndexOf("|8|") > -1)
                                {
                                    _otypestr += ",8";
                                }
                            }
                            else
                            {
                                _otypestr += ",8";
                            }
                        }
                        if (CheckUserPopedoms("X") || CheckUserPopedoms("3-3-2-8"))
                        {
                            if (ordertypeStr.Trim() != "")
                            {
                                if (ordertypeStr.IndexOf("|9|") > -1)
                                {
                                    _otypestr += ",9";
                                }
                            }
                            else
                            {
                                _otypestr += ",9";
                            }
                        }
                        if (CheckUserPopedoms("X") || CheckUserPopedoms("3-3-3-8"))
                        {
                            if (ordertypeStr.Trim() != "")
                            {
                                if (ordertypeStr.IndexOf("|10|") > -1)
                                {
                                    _otypestr += ",10";
                                }
                            }
                            else
                            {
                                _otypestr += ",10";
                            }
                        }
                        if (CheckUserPopedoms("X") || CheckUserPopedoms("3-2-6-8"))
                        {
                            if (ordertypeStr.Trim() != "")
                            {
                                if (ordertypeStr.IndexOf("|11|") > -1)
                                {
                                    _otypestr += ",11";
                                }
                            }
                            else
                            {
                                _otypestr += ",11";
                            }
                        }
                        break;
                }
                tSQL = " tbOrderInfo.oType in(" + _otypestr + ") ";
                StoresSupplierID = HTTPRequest.GetInt("StoresSupplierID", 0);
                if (StoresSupplierID > 0)
                {
                    tSQL += " and tbOrderInfo.StoresID=" + StoresSupplierID;
                }
                StoresSupplier = Utils.ChkSQL(HTTPRequest.GetString("StoresSupplier"));

                StorageID = HTTPRequest.GetInt("StorageID", 0);
                if (StorageID > 0)
                {
                    tSQL += " and tbOrderInfo.OrderID in(select siol.OrderID from tbOrderListInfo siol where siol.StorageID=" + StorageID + " ) ";
                }
                StorageName = Utils.ChkSQL(HTTPRequest.GetString("StorageName"));

                oOrderNum = Utils.ChkSQL(HTTPRequest.GetString("oOrderNum"));
                if (oOrderNum.Trim() != "") 
                {
                    tSQL += " and tbOrderInfo.oOrderNum like '%" + oOrderNum+"%'";
                }
                StaffID = HTTPRequest.GetInt("StaffID", 0);
                if (StaffID > 0)
                {
                    tSQL += " and tbOrderInfo.StaffID=" + StaffID;
                }
                StaffName = Utils.ChkSQL(HTTPRequest.GetString("StaffName"));

                UserID = HTTPRequest.GetInt("UserID", 0);
                if (UserID > 0)
                {
                    tSQL += " and tbOrderInfo.UserID=" + UserID;
                }
                UserName = Utils.ChkSQL(HTTPRequest.GetString("User"));

                oCustomersOrderID = Utils.ChkSQL(HTTPRequest.GetString("oCustomersOrderID"));
                if (oCustomersOrderID.Trim()!="")
                {
                    tSQL += " and tbOrderInfo.oCustomersOrderID like '%" + oCustomersOrderID+"%'";
                }
               

                ProductsName = Utils.ChkSQL(HTTPRequest.GetString("ProductsName"));
                ProductsID = HTTPRequest.GetInt("ProductsID", 0);
                if (ProductsID>0)
                {
                    tSQL += " and tbOrderInfo.OrderID in(select pol.OrderID from tbOrderListInfo pol where pol.ProductsID=" + ProductsID + " ) ";
                }
                //按操作类型查询
                
                dDateTimeB = Utils.ChkSQL(HTTPRequest.GetString("dDateTimeB"));
                dDateTimeE = Utils.ChkSQL(HTTPRequest.GetString("dDateTimeE"));

                dDateTimeB = dDateTimeB.Trim() == "" ? DateTime.Now.Year + "-1-1" : dDateTimeB.Trim();

                //步骤
                oSteps = HTTPRequest.GetInt("oSteps", -1);
                sType = HTTPRequest.GetInt("sType",1);
                dType = -2;
                dType_b = -2;

                if (sType == 1)
                {
                    oOrderDateTimeB = Utils.ChkSQL(HTTPRequest.GetString("oOrderDateTimeB"));
                    if (oOrderDateTimeB.Trim() == "")
                    {
                        if (ordertype != 0)
                        {
                            oOrderDateTimeB = DateTime.Now.Year + "-1-1";
                        }
                    }
                    if (oOrderDateTimeB.Trim() != "" && Utils.IsDateString(oOrderDateTimeB.Trim()))
                    {
                        tSQL += " and tbOrderInfo.oOrderDateTime>='" + Convert.ToDateTime(oOrderDateTimeB.Trim()).ToString("yyyy-MM-dd") + " 00:00:00 '";
                    }
                    oOrderDateTimeE = Utils.ChkSQL(HTTPRequest.GetString("oOrderDateTimeE"));
                    if (oOrderDateTimeE.Trim() != "" && Utils.IsDateString(oOrderDateTimeE.Trim()))
                    {
                        tSQL += " and tbOrderInfo.oOrderDateTime<='" + Convert.ToDateTime(oOrderDateTimeE.Trim()).ToString("yyyy-MM-dd") + " 23:59:59 '";
                    }

                }

                if (oSteps > -1)
                {
                    
                    if (sType == 1)
                    {
                        tSQL += " and tbOrderInfo.oSteps=" + oSteps;
                    }
                    if (sType == 2)
                    {
                        dType_b = -2;
                        switch (oSteps)
                        {
                            case 1://开单
                                dType = 0;//新开单
                                break;
                            case 2://审核
                                dType = 2;//新单已审核
                                break;
                            case 3://发货
                                dType = 3;//已发货
                                break;
                            case 4://收货
                                dType = 4;//已收货
                                break;
                            case 5://验收核销
                                dType = 5;//已验收确认(已核销)
                                break;
                            case 6://对账中
                                dType = 11;
                                break;
                            case 7://已对账
                                dType = 12;
                                break;
                            case 8://已收款
                                dType = 13;
                                break;
                            case 9://已结账
                                dType = 14;
                                break;
                        }
                    }
                }
                else if (oSteps == -2)//查看非全额收货单据,oSteps=-2
                {
                    NextID = HTTPRequest.GetInt("NextID", -1);
                    if (NextID == 0)
                    {
                        tSQL += " and tbOrderInfo.OrderID in(select OrderID from tbOrderNOFullInfo where oNextOrderID=0 )   ";
                    }
                    else
                    {
                        tSQL += " and tbOrderInfo.OrderID in(select ooool.OrderID from ( " +
                                        "select oool.ProductsID,oool.OrderID,SUM(oool.oQuantity) as oQuantity,SUM(oool.oldQuantity) as oldQuantity from ( " +
                                        "select  osl.ProductsID,osl.OrderListID, osl.OrderID,osl.oQuantity,oosl.oQuantity as oldQuantity from  " +
                                        "(select ol.ProductsID,ol.OrderListID,ol.OrderID, ol.oQuantity,ol.StorageID from tbOrderListInfo as ol where ol.oWorkType<>0) as osl left join " +
                                        "(select ool.oQuantity,ool.ProductsID,ool.StorageID,ool.OrderID from tbOrderListInfo as ool where ool.oWorkType=0) as oosl on osl.ProductsID = oosl.ProductsID and osl.OrderID=oosl.OrderID and osl.StorageID=oosl.StorageID " +
                                        ") as oool " +
                                        "group by oool.ProductsID,oool.OrderID " +
                                        ") as ooool where ooool.oQuantity<>ooool.oldQuantity and ooool.OrderID in(select o.OrderID from tbOrderInfo as o where o.oSteps not in(1,2,3) and o.OrderID not in(select OrderID from tbOrderNOFullInfo where oState=0) and o.oType in(1,2,3,4,5,6,7,10)) )   ";
                    }

                }

                //仅选择了开始
                if (dType > -2 && dType_b==-2)
                {
                    if (dDateTimeB.Trim() != "" && dDateTimeE.Trim()=="")
                    {
                        tSQL += " and tbOrderInfo.OrderID in(select OrderID from tbOrderWorkingLogInfo where oType=" + dType + " and pAppendTime>='" + Convert.ToDateTime(dDateTimeB.Trim()).ToString("yyyy-MM-dd") +" 00:00:00') ";
                    }
                    if (dDateTimeE.Trim() != "" && dDateTimeB.Trim() == "")
                    {
                        tSQL += " and tbOrderInfo.OrderID in(select OrderID from tbOrderWorkingLogInfo where oType=" + dType + " and pAppendTime<='" + Convert.ToDateTime(dDateTimeE.Trim()).ToString("yyyy-MM-dd") + " 23:59:59') ";
                    }
                    if (dDateTimeE.Trim() != "" && dDateTimeB.Trim() != "")
                    {
                        tSQL += " and tbOrderInfo.OrderID in(select OrderID from tbOrderWorkingLogInfo where oType=" + dType + " and pAppendTime between '" + Convert.ToDateTime(dDateTimeB.Trim()).ToString("yyyy-MM-dd") + " 00:00:00' and '" + Convert.ToDateTime(dDateTimeE.Trim()).ToString("yyyy-MM-dd") + " 23:59:59') ";
                    }
                }
                else if (dType > -2 && dType_b > -2)//开始与结束都选择
                {
                    if (dDateTimeB.Trim() != "" && dDateTimeE.Trim() == "")
                    {
                        tSQL += " and tbOrderInfo.OrderID in(select OrderID from tbOrderWorkingLogInfo where oType = " + dType_b + " and OrderID in(select OrderID from tbOrderWorkingLogInfo where oType=" + dType + " and pAppendTime>='" + Convert.ToDateTime(dDateTimeB.Trim()).ToString("yyyy-MM-dd") + " 00:00:00')   and pAppendTime>='" + Convert.ToDateTime(dDateTimeB.Trim()).ToString("yyyy-MM-dd") + " 00:00:00') ";
                    }
                    if (dDateTimeE.Trim() != "" && dDateTimeB.Trim() == "")
                    {
                        tSQL += " and tbOrderInfo.OrderID in(select OrderID from tbOrderWorkingLogInfo where oType = " + dType_b + " and OrderID in(select OrderID from tbOrderWorkingLogInfo where oType=" + dType + " and pAppendTime<='" + Convert.ToDateTime(dDateTimeE.Trim()).ToString("yyyy-MM-dd") + " 23:59:59')    and pAppendTime<='" + Convert.ToDateTime(dDateTimeE.Trim()).ToString("yyyy-MM-dd") + " 23:59:59') ";
                    }
                    if (dDateTimeE.Trim() != "" && dDateTimeB.Trim() != "")
                    {
                        tSQL += " and tbOrderInfo.OrderID in(select OrderID from tbOrderWorkingLogInfo where oType = " + dType_b + " and OrderID in(select OrderID from tbOrderWorkingLogInfo where oType=" + dType + " and pAppendTime between '" + Convert.ToDateTime(dDateTimeB.Trim()).ToString("yyyy-MM-dd") + " 00:00:00' and '" + Convert.ToDateTime(dDateTimeE.Trim()).ToString("yyyy-MM-dd") + " 23:59:59')   and pAppendTime between '" + Convert.ToDateTime(dDateTimeB.Trim()).ToString("yyyy-MM-dd") + " 00:00:00' and '" + Convert.ToDateTime(dDateTimeE.Trim()).ToString("yyyy-MM-dd") + " 23:59:59') ";
                    }
                }

                oState = HTTPRequest.GetInt("oState", -1);
                if (oState > -1) 
                {
                    tSQL += " and tbOrderInfo.oState=" + oState;
                }

                bool getWorkType0 = false;

                if (oSteps == 1) {
                    getWorkType0 = true;
                }

                if (!IsErr())
                {
                    OrderStpes = Orders.GetOrderSteps();

                    if (Act.IndexOf("Export")>-1)//导出
                    {
						if (AllOrderList.Trim ().IndexOf ("true") > -1) {//导出单据详细列表

							if (CheckUserPopedoms ("X")) {

                                //Response.Write(oState+"------"+ getWorkType0);
                                //Response.End();


                                DataSet _orderLists = Orders.GetOrderListByOrderWhere (tSQL, getWorkType0);

								_orderLists.Tables [0].Columns [0].ColumnName = "单号";
								_orderLists.Tables [0].Columns [1].ColumnName = "单据类型";
								_orderLists.Tables [0].Columns [2].ColumnName = "客户名称";
								_orderLists.Tables [0].Columns [3].ColumnName = "联系人";
								_orderLists.Tables [0].Columns [4].ColumnName = "电话号码";
								_orderLists.Tables [0].Columns [5].ColumnName = "地址";
								_orderLists.Tables [0].Columns [6].ColumnName = "客户订单号";
								_orderLists.Tables [0].Columns [7].ColumnName = "客户子名称";
								_orderLists.Tables [0].Columns [8].ColumnName = "业务员";
								_orderLists.Tables [0].Columns [9].ColumnName = "操作员";
								_orderLists.Tables [0].Columns [10].ColumnName = "创建时间";
								_orderLists.Tables [0].Columns [11].ColumnName = "单据时间";
								_orderLists.Tables [0].Columns [12].ColumnName = "单据状态";
								_orderLists.Tables [0].Columns [13].ColumnName = "单据步骤";
								_orderLists.Tables [0].Columns [14].ColumnName = "仓库名称";
								_orderLists.Tables [0].Columns [15].ColumnName = "是否赠品";
								_orderLists.Tables [0].Columns [16].ColumnName = "商品名称";
								_orderLists.Tables [0].Columns [17].ColumnName = "条码";
								_orderLists.Tables [0].Columns [18].ColumnName = "装件数";
								_orderLists.Tables [0].Columns [19].ColumnName = "小单位";
								_orderLists.Tables [0].Columns [20].ColumnName = "大单位";
								_orderLists.Tables [0].Columns [21].ColumnName = "数量";
								_orderLists.Tables [0].Columns [22].ColumnName = "单价";
								_orderLists.Tables [0].Columns [23].ColumnName = "金额";

                                CreateExcel (_orderLists.Tables [0], "Data_" + DateTime.Now.ToShortDateString () + ".xls");
							} else {
								AddErrLine("权限不足,无法导出 列表!");
							}
						} else {
							DataSet _exDs = Orders.GetOrderInfoList(tSQL);
							_exDs.Tables[0].Columns[0].ColumnName = "系统编号";
							_exDs.Tables[0].Columns[1].ColumnName = "单号";
							_exDs.Tables[0].Columns[2].ColumnName = "单据类型";
							_exDs.Tables[0].Columns[3].ColumnName = "客户系统编号";
							_exDs.Tables[0].Columns[4].ColumnName = "客户名称";
							_exDs.Tables[0].Columns[5].ColumnName = "联系人";
							_exDs.Tables[0].Columns[6].ColumnName = "联系电话";
							_exDs.Tables[0].Columns[7].ColumnName = "地址";
							_exDs.Tables[0].Columns[8].ColumnName = "客户订单号";
							_exDs.Tables[0].Columns[9].ColumnName = "客户子名称";
							_exDs.Tables[0].Columns[10].ColumnName = "业务员编号";
							_exDs.Tables[0].Columns[11].ColumnName = "操作员编号";
							_exDs.Tables[0].Columns[12].ColumnName = "创建时间";
							_exDs.Tables[0].Columns[13].ColumnName = "单据时间";
							_exDs.Tables[0].Columns[14].ColumnName = "单据状态(0正常,1作废)";
							_exDs.Tables[0].Columns[15].ColumnName = "单据步骤";
							_exDs.Tables[0].Columns[16].ColumnName = "是否预付款";
							_exDs.Tables[0].Columns[17].ColumnName = "客户名称B";
							_exDs.Tables[0].Columns[18].ColumnName = "合计金额";
							_exDs.Tables[0].Columns[19].ColumnName = "业务员";
							_exDs.Tables[0].Columns[20].ColumnName = "操作员";
							_exDs.Tables[0].Columns[21].ColumnName = "操作员姓名";
							_exDs.Tables[0].Columns[22].ColumnName = "打印时间";

							CreateExcel(_exDs.Tables[0], "Data_" + DateTime.Now.ToShortDateString() + ".xls");
						}

                        
                    }
                    else
                    {
                        if (oSteps == -2)
                        {
                            dList = Orders.GetOrderInfoList(tSQL).Tables[0];

                            foreach(DataRow dr in dList.Rows)
                            {
                                SUMMoney += decimal.Parse(dr["SumMoney"].ToString());
                            }

                            PageBarHTML = "";
                        }
                        else
                        {
                            SUMMoney = Orders.GetOrderSumMoney(tSQL);

                            dList = Orders.GetOrderInfoList_xp(pagesize, pageindex, tSQL, out pagetotal, "nOrderNum desc,OrderID desc");
                            //dList = Orders.GetOrderInfoList(pagesize, pageindex, tSQL, out pagetotal, 1, "*");//oOrderNum

                            PageBarHTML = Utils.TenPage(pageindex, pagetotal, 0, "&Act=" + Act + 
                                "&S_key=" + S_key + 
                                "&StoresSupplier=" + StoresSupplier + 
                                "&StoresSupplierID=" + StoresSupplierID + 
                                "&oOrderNum=" + oOrderNum + 
                                "&StaffID=" + StaffID +
                                "&StaffName=" +StaffName+
                                "&UserID=" + UserID +
                                "&UserName=" +UserName+
                                "&oCustomersOrderID=" + oCustomersOrderID + 
                                "&oOrderDateTimeB=" + oOrderDateTimeB + 
                                "&oOrderDateTimeE=" + oOrderDateTimeE + 
                                "&oState=" + oState + 
                                "&oSteps=" + oSteps + 
                                "&ProductsName=" + ProductsName + 
                                "&ProductsID=" + ProductsID + 
                                "&ordertypeStr=" + ordertypeStr + 
                                "&dType_b=" + dType_b + 
                                "&dType=" + dType + 
                                "&dDateTimeB=" + dDateTimeB +
                                "&dDateTimeE=" + dDateTimeE +
                                "&sType=" + sType+
                                "&StorageID=" + StorageID+
                                "&StorageName=" + StorageName);
                        }
                    }
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
            pagetitle = " 单据列表";
            this.Load += new EventHandler(this.Page_Load);
        }
        /// <summary>
        /// 页面调用,取客户或供应商名称
        /// </summary>
        /// <param name="StoresSupplierID"></param>
        /// <param name="oType"></param>
        /// <returns></returns>
        public string GetStoresSupplierName(int StoresSupplierID, int oType)
        {
            string restr = "";
            switch (oType)
            { 
                case 1:case 2:
                    SupplierInfo si = new SupplierInfo();
                    try
                    {
                        si = tbSupplierInfo.GetSupplierInfoModel(StoresSupplierID);
                        if (si != null)
                        {
                            restr = si.sName;
                        }
                    }
                    finally {
                        si = null;
                    }
                    break;
                case 3:case 4:case 5:case 6:case 7:case 11:
                    StoresInfo ssi = new StoresInfo();
                    try {
                        ssi = tbStoresInfo.GetStoresInfoModel(StoresSupplierID);
                        if (ssi != null)
                        {
                            restr = ssi.sName;
                        }
                    }
                    finally {
                        si = null;
                    }
                    break;
            }
            return restr;
        }

        /// <summary>
        /// 页面调用,取人员名称
        /// </summary>
        /// <param name="StaffID"></param>
        /// <returns></returns>
        public string GetStaffNameByStaffID(int StaffID)
        {
            string restr = "";
            StaffInfo si = new StaffInfo();
            try {
                si = tbStaffInfo.GetStaffInfoModel(StaffID);
                if (si != null)
                {
                    restr = si.sName;
                }
            }
            finally {
                si = null;
            }
            return restr;
        }

        /// <summary>
        /// 取系统用户名称
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public string GetUserNameByUserID(int UserID)
        {
            string restr = "";
            UserInfo si = new UserInfo();
            try
            {
                si = tbUserInfo.GetUserInfoModel(StaffID);
                if (si != null)
                {
                    restr = si.uName;
                }
            }
            finally
            {
                si = null;
            }
            return restr;
        }

        /// <summary>
        /// 操作员 转 人员名称
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public string GetUserStaffNameByUserID(int UserID)
        { 
            string restr = "";
            StaffInfo si = new StaffInfo();
            try {
                si = tbStaffInfo.GetStaffInfoModelByUserID(UserID);
                if (si != null)
                {
                    restr = si.sName;
                }
            }
            finally {
                si = null;
            }
            return restr;
        }

        public string GetUserStaffName(int UserID)
        {
            string restr = GetUserNameByUserID(UserID);
            if (restr.Trim() == "")
            {
                restr = GetUserStaffNameByUserID(UserID);
            }
            return restr;
        }
        /// <summary>
        /// 取打印时间
        /// </summary>
        /// <param name="OrderID"></param>
        /// <returns></returns>
        public string GetPrintTime(int OrderID)
        {
            string restr = "<span style=\"color:#F00\" >未打印</span>";
            OrderWorkingLogInfo si = new OrderWorkingLogInfo();
            try
            {
                si = Orders.GetOrderWorkingLogInfoModelByOrderIDAndWorkType(OrderID,6);
                if (si != null)
                {
                    restr = si.pAppendTime.ToString(); ;
                }
            }
            finally
            {
                si = null;
            }
            return restr;
        }

        /// <summary>
        /// 返回单据合计金额
        /// </summary>
        /// <param name="OrderID"></param>
        /// <returns></returns>
        public string GetOrderSumMoney(int OrderID)
        {
           return Orders.GetOrderSumMoney(OrderID).ToString();
        }

        public string[] GetOrderOtherInfo(int OrderID)
        {
            return Orders.GetOrderOtherInfo(OrderID);
        }
    }
}