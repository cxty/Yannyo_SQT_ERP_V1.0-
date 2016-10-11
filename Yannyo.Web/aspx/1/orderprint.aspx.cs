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
    public partial class orderprint : PageBase
    {
        public int orderid = 0;
        public int ordertype = 0;
        public string act = "";//pl = printlist批量打印
        public string orderidstr = "";
        public string ordertypestr = "";

        public string ot = "";//是否非订单打印,是=d
        public OrderInfo oi = new OrderInfo();
        public DataTable OrderFieldList = new DataTable();//自定义字段
        public DataTable OrderFieldValueList = new DataTable();//自定义字段值
        public DataTable OrderList = new DataTable();//单据体列表
        public DataSet OrderListSet = new DataSet();//分页后的单据体集合

        //批量打印部分
        public ArrayList oi_array = new ArrayList();

        public decimal summoney = 0;//合计
        public string summoney_str = "";//大写
        public decimal sumQuantityM = 0;//合计数量,小单位
        public decimal sumQuantityB = 0;//合计数量,大单位

        public decimal summoney_page = 0;//合计
        public string summoney_str_page = "";//大写
        public decimal sumQuantityM_page = 0;//合计数量,小单位
        public decimal sumQuantityB_page = 0;//合计数量,大单位

        public int print_page_sum = 0;//打印分页合计页数
        public int print_page_index = 0;//打印分页当前页码

        public int OrderFieldCount = 0;//自定义字段数
        public bool ShowMoney = false;//是否显示金额
        public UserInfo print_ui = new UserInfo();//开单人员
        public UserInfo print_v_ui = new UserInfo();//审核人员

        public bool IsMOrder = false;//是否为网购订单
        public M_SendGoodsInfo _ms = new M_SendGoodsInfo();//网购订单
        public M_ExpressTemplatesInfo _mxsp = new M_ExpressTemplatesInfo();//物流信息
        public string BuyerName = "";//买家昵称
        public string Print_Foot = "";//打印页脚信息
        public int Order_Print_Item = 10;//打印分页，每页条数
		

        protected virtual void Page_Load(object sender, EventArgs e)
        {
            if (this.userid > 0)
            {
                if (CheckUserPopedoms("X") || CheckUserPopedoms("3-1-1-8") || CheckUserPopedoms("3-1-2-8") || CheckUserPopedoms("3-2-1-8") || CheckUserPopedoms("3-2-2-8") || CheckUserPopedoms("3-2-3-8") || CheckUserPopedoms("3-2-4-8") || CheckUserPopedoms("3-2-5-8") || CheckUserPopedoms("3-3-1-8") || CheckUserPopedoms("3-3-2-8") || CheckUserPopedoms("3-3-3-8"))
                {
                    act = HTTPRequest.GetString("act");
                    orderid = HTTPRequest.GetInt("orderid", 0);
                    ordertype = HTTPRequest.GetInt("ordertype", 0);
                    ot = HTTPRequest.GetString("ot");
                    Order_Print_Item = this.config.Order_Print_Item;

                    string[] orderid_array;
                    string[] ordertypestr_array;
                    OrderPrintObj opo = new OrderPrintObj();

                    if (act == "pl")//批量打印
                    {
                        orderidstr = HTTPRequest.GetString("orderid");
                        ordertypestr = HTTPRequest.GetString("ordertype");

                        orderid_array = Utils.SplitString(orderidstr, "x");
                        ordertypestr_array = Utils.SplitString(ordertypestr, "x");

                        if (orderid_array.Length == ordertypestr_array.Length)
                        {
                            for (int i = 0; i < orderid_array.Length; i++)
                            {
                                oi = Orders.GetOrderInfoModel(Utils.StrToInt(orderid_array[i],0));
                                if (oi != null)
                                {
                                    opo = new OrderPrintObj();
                                    
                                    string tSteps = ((oi.oSteps == 1) ? "  tbOrderListInfo.oWorkType=0 " : "  tbOrderListInfo.oWorkType<>0 ").ToString();
                                    string tSteps_b = ((oi.oSteps == 1) ? " IsVerify=0 " : " IsVerify<>0 ").ToString();

                                    if (CheckUserPopedoms("X") || CheckUserPopedoms("3-1-1-9") || CheckUserPopedoms("3-1-2-9") || CheckUserPopedoms("3-2-1-9") || CheckUserPopedoms("3-2-2-9") || CheckUserPopedoms("3-2-3-9") || CheckUserPopedoms("3-2-4-9") || CheckUserPopedoms("3-2-5-9") || CheckUserPopedoms("3-3-1-9") || CheckUserPopedoms("3-3-2-9") || CheckUserPopedoms("3-3-3-9"))
                                    {
                                        ShowMoney = true;
                                        ShowMoney = (HTTPRequest.GetString("ShowMoney").Trim() != "") ? false : true;
                                    }
                                    else
                                    {
                                        ShowMoney = false;
                                    }
                                    

                                    Print_Foot = Utils.ReplaceString(this.config.Print_Foot, "[", "<", false);
                                    Print_Foot = Utils.ReplaceString(Print_Foot, "]", ">", false);

                                   
                                    OrderList = Orders.GetOrderListInfoList(" OrderID=" + oi.OrderID + " and " + tSteps + " order by OrderListID asc").Tables[0];

                                    OrderFieldList = Orders.GetOrderFieldInfoList(" OrderType=" + ordertype + " and fState=0 and fPrint=0").Tables[0];
                                    if (OrderFieldList != null)
                                    {
                                        OrderFieldValueList = Orders.GetOrderFieldValueInfoList(" OrderListID in(select tbOrderListInfo.OrderListID from tbOrderListInfo where tbOrderListInfo.OrderID=" + oi.OrderID + " and " + tSteps + ") and " + tSteps_b + "").Tables[0];
                                    }
                                    foreach (DataRow dr in OrderList.Rows)
                                    {
                                        summoney += Convert.ToDecimal(dr["oQuantity"]) * Convert.ToDecimal(dr["oPrice"]);
                                    }
                                    summoney_str = chang(summoney.ToString());

                                    summoney = Math.Round(summoney, config.MoneyDecimal);

                                    //库存调拨单,整理数据
                                    if (oi.oType == 9)
                                    {
                                        DataTable nOrderList = new DataTable();
                                        nOrderList = OrderList.Clone();

                                        foreach (DataRow dr in OrderList.Rows)
                                        {
                                            if (Convert.ToDecimal(dr["oQuantity"].ToString()) < 0)
                                            {
                                                dr["StorageName"] = "来源:" + dr["StorageName"].ToString();
                                                nOrderList.Rows.Add(dr.ItemArray);
                                            }
                                        }
                                        nOrderList.AcceptChanges();

                                        foreach (DataRow dr in OrderList.Rows)
                                        {
                                            foreach (DataRow ddr in nOrderList.Rows)
                                            {
                                                if (Convert.ToInt32(ddr["ProductsID"].ToString()) == Convert.ToInt32(dr["ProductsID"].ToString()))
                                                {
                                                    if (Convert.ToDecimal(dr["oQuantity"].ToString()) > 0)
                                                    {
                                                        ddr["oQuantity"] = Convert.ToDecimal(dr["oQuantity"].ToString());
                                                        ddr["StorageName"] = ddr["StorageName"].ToString() + "<br>去向:" + dr["StorageName"].ToString() + "";
                                                    }
                                                }
                                            }
                                            nOrderList.AcceptChanges();
                                        }

                                        OrderList.Clear();
                                        OrderList = nOrderList.Copy();
                                    }

                                    //处理分页打印
                                    if (OrderList.Rows.Count > 0)
                                    {
                                        OrderListSet = new DataSet();
                                        print_page_sum = (int)Math.Ceiling((float)OrderList.Rows.Count / (float)Order_Print_Item);

                                        for (int k = 0; k < print_page_sum; k++)
                                        {
                                            DataTable _dt = new DataTable();
                                            _dt = OrderList.Clone();
                                            _dt = Public.PublicLib.GetPagedTable(OrderList, k + 1, Order_Print_Item);
                                            _dt.TableName = (k + 1).ToString();
                                            OrderListSet.Tables.Add(_dt);

                                            OrderListSet.AcceptChanges();
                                        }



                                    }

                                    //制单人
                                    print_ui = tbUserInfo.GetUserInfoModel(oi.UserID);
                                    //审核人
                                    OrderWorkingLogInfo owil = Orders.GetOrderWorkingUserID(oi.OrderID, 2);
                                    if (owil != null)
                                    {
                                        print_v_ui = tbUserInfo.GetUserInfoModel(owil.UserID);
                                    }
                                    else
                                    {
                                        print_v_ui = null;
                                    }

                                    opo.Order = oi;
                                    opo.ShowMoney = ShowMoney;
                                    opo.Print_Foot = Print_Foot;
                                    opo.OrderList = OrderList;
                                    opo.OrderFieldList = OrderFieldList;
                                    opo.OrderFieldValueList = OrderFieldValueList;
                                    opo.summoney = summoney;
                                    opo.summoney_str = summoney_str;
                                    opo.print_page_sum = print_page_sum;
                                    opo.OrderListSet = OrderListSet;
                                    opo.print_ui = print_ui;
                                    opo.print_v_ui = print_v_ui;

                                    oi_array.Add(opo);
                                }
                            }
                                
                        }
                        else
                        {
                            AddErrLine("参数错误,批量打印失败!");
                        }

                    }
                    else
                    {


                        if (orderid > 0)
                        {
                            oi = Orders.GetOrderInfoModel(orderid);
                            if (oi != null)
                            {
                                string tSteps = ((oi.oSteps == 1) ? "  tbOrderListInfo.oWorkType=0 " : "  tbOrderListInfo.oWorkType<>0 ").ToString();
                                string tSteps_b = ((oi.oSteps == 1) ? " IsVerify=0 " : " IsVerify<>0 ").ToString();

                                if (CheckUserPopedoms("X") || CheckUserPopedoms("3-1-1-9") || CheckUserPopedoms("3-1-2-9") || CheckUserPopedoms("3-2-1-9") || CheckUserPopedoms("3-2-2-9") || CheckUserPopedoms("3-2-3-9") || CheckUserPopedoms("3-2-4-9") || CheckUserPopedoms("3-2-5-9") || CheckUserPopedoms("3-3-1-9") || CheckUserPopedoms("3-3-2-9") || CheckUserPopedoms("3-3-3-9"))
                                {
                                    ShowMoney = true;
                                    ShowMoney = (HTTPRequest.GetString("ShowMoney").Trim() != "") ? false : true;
                                }
                                else
                                {
                                    ShowMoney = false;
                                }
                                Print_Foot = Utils.ReplaceString(this.config.Print_Foot, "[", "<", false);
                                Print_Foot = Utils.ReplaceString(Print_Foot, "]", ">", false);
                                OrderList = Orders.GetOrderListInfoList(" OrderID=" + oi.OrderID + " and " + tSteps + " order by OrderListID asc").Tables[0];

                                OrderFieldList = Orders.GetOrderFieldInfoList(" OrderType=" + ordertype + " and fState=0 and fPrint=0").Tables[0];
                                if (OrderFieldList != null)
                                {
                                    OrderFieldValueList = Orders.GetOrderFieldValueInfoList(" OrderListID in(select tbOrderListInfo.OrderListID from tbOrderListInfo where tbOrderListInfo.OrderID=" + oi.OrderID + " and " + tSteps + ") and " + tSteps_b + "").Tables[0];
                                }
                                foreach (DataRow dr in OrderList.Rows)
                                {
                                    summoney += Convert.ToDecimal(dr["oQuantity"]) * Convert.ToDecimal(dr["oPrice"]);
                                }
                                summoney_str = chang(summoney.ToString());

                                summoney = Math.Round(summoney, config.MoneyDecimal);

                                //库存调拨单,整理数据
                                if (oi.oType == 9)
                                {
                                    DataTable nOrderList = new DataTable();
                                    nOrderList = OrderList.Clone();

                                    foreach (DataRow dr in OrderList.Rows)
                                    {
                                        if (Convert.ToDecimal(dr["oQuantity"].ToString()) < 0)
                                        {
                                            dr["StorageName"] = "来源:" + dr["StorageName"].ToString();
                                            nOrderList.Rows.Add(dr.ItemArray);
                                        }
                                    }
                                    nOrderList.AcceptChanges();

                                    foreach (DataRow dr in OrderList.Rows)
                                    {
                                        foreach (DataRow ddr in nOrderList.Rows)
                                        {
                                            if (Convert.ToInt32(ddr["ProductsID"].ToString()) == Convert.ToInt32(dr["ProductsID"].ToString()))
                                            {
                                                if (Convert.ToDecimal(dr["oQuantity"].ToString()) > 0)
                                                {
                                                    ddr["oQuantity"] = Convert.ToDecimal(dr["oQuantity"].ToString());
                                                    ddr["StorageName"] = ddr["StorageName"].ToString() + "<br>去向:" + dr["StorageName"].ToString() + "";
                                                }
                                            }
                                        }
                                        nOrderList.AcceptChanges();
                                    }

                                    OrderList.Clear();
                                    OrderList = nOrderList.Copy();
                                }

                                //处理分页打印
                                if (OrderList.Rows.Count > 0)
                                {

                                    print_page_sum = (int)Math.Ceiling((float)OrderList.Rows.Count / (float)Order_Print_Item);

                                    for (int k = 0; k < print_page_sum; k++)
                                    {
                                        DataTable _dt = new DataTable();
                                        _dt = OrderList.Clone();
                                        _dt = Public.PublicLib.GetPagedTable(OrderList, k + 1, Order_Print_Item);
                                        _dt.TableName = (k + 1).ToString();
                                        OrderListSet.Tables.Add(_dt);

                                        OrderListSet.AcceptChanges();
                                    }



                                }

                                //制单人
                                print_ui = tbUserInfo.GetUserInfoModel(oi.UserID);
                                //审核人
                                OrderWorkingLogInfo owil = Orders.GetOrderWorkingUserID(oi.OrderID, 2);
                                if (owil != null)
                                {
                                    print_v_ui = tbUserInfo.GetUserInfoModel(owil.UserID);
                                }
                                else
                                {
                                    print_v_ui = null;
                                }

                                //是否为网购订单
                                _ms = M_Utils.GetM_SendGoodsInfoModelByOrderID(oi.OrderID);
                                if (_ms != null)
                                {
                                    IsMOrder = true;
                                    _mxsp = M_Utils.GetM_ExpressTemplatesInfoModel(_ms.mExpName);
                                    //转换交易单号
                                    oi.oCustomersOrderID = "";
                                    string _m_TradeInfoID = _ms.m_TradeInfoID;
                                    string[] _m_TradeInfoIDArr = Utils.SplitString(_m_TradeInfoID, ",");
                                    foreach (string _m_TradeInfoID_Str in _m_TradeInfoIDArr)
                                    {
                                        if (_m_TradeInfoID_Str.Trim() != "")
                                        {
                                            M_TradeInfo _mt = new M_TradeInfo();
                                            try
                                            {
                                                try
                                                {
                                                    _mt = M_Utils.GetM_TradeInfoModel(Convert.ToInt32(_m_TradeInfoID_Str.Trim()));
                                                    if (_mt != null)
                                                    {
                                                        BuyerName = _mt.buyer_nick;
                                                        oi.oCustomersOrderID += _mt.tid.ToString() + " ";
                                                    }
                                                }
                                                catch
                                                {

                                                }
                                            }
                                            finally
                                            {
                                                _mt = null;
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    IsMOrder = false;
                                    _mxsp = null;
                                }

                                OrderWorkingLogInfo owl = new OrderWorkingLogInfo();
                                owl.OrderID = oi.OrderID;
                                owl.UserID = this.userid;
                                owl.oType = 6;
                                owl.oMsg = (ot.Trim() != "d") ? "" : "打印订单,备货";
                                owl.pAppendTime = DateTime.Now;

                                Orders.AddOrderWorkingLogInfo(owl);

                            }
                            else
                            {
                                AddErrLine("参数错误,单据不存在!");
                            }
                        }
                        else
                        {
                            AddErrLine("参数错误!");
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
            pagetitle = " 打印单据";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}