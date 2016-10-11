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
using Newtonsoft.Json;

namespace Yannyo.Web
{
    public partial class orderlist_do_nofull : PageBase
    {
        public int OrderID = 0;
        public int OrderType = 0;
        public OrderInfo oi = new OrderInfo();
        public DataTable dList = new DataTable();
        public DataTable StorageList = new DataTable();//仓库列表
        protected virtual void Page_Load(object sender, EventArgs e)
        {
            if (this.userid > 0)
            {
                if (CheckUserPopedoms("X") || CheckUserPopedoms("3-4-2"))
                {
                    OrderID = HTTPRequest.GetInt("orderid", 0);
                    OrderType = HTTPRequest.GetInt("ordertype", 0);
                    if (OrderID>0)
                    {
                        oi = Orders.GetOrderInfoModel(OrderID);
                        if (oi != null)
                        {
                            if (!ispost)
                            {
                                dList = Orders.GetOrderNOFullList(OrderID);
                                StorageList = tbStorageInfo.GetStorageInfoList("").Tables[0];
                            }
                            else {
                                int loop_count = HTTPRequest.GetInt("loop_count", 0);
                                if (loop_count > 0)
                                {
                                    int s_StorageID = 0;
                                    int ProductsID = 0;
                                    decimal Quantity = 0;
                                    int t_StorageID = 0;
                                    string _OrderListDataJson = "";
                                    for (int i = 1; i <= loop_count; i++)
                                    {
                                        s_StorageID = HTTPRequest.GetInt("s_StorageID_"+i, 0);
                                        ProductsID = HTTPRequest.GetInt("ProductsID_" + i, 0);
                                        t_StorageID = HTTPRequest.GetInt("t_StorageID_" + i, 0);
                                        Quantity = HTTPRequest.GetString("Quantity_" + i).Trim() != "" ? Convert.ToDecimal(HTTPRequest.GetString("Quantity_" + i).Trim()) : 0;

                                        if (s_StorageID > 0 && ProductsID > 0 )
                                        {
                                            if (t_StorageID > 0)
                                            {
                                                _OrderListDataJson += "{\"OrderListID\":0," +
                                                                                        "\"OrderID\":0," +
                                                                                        "\"StorageID\":" + s_StorageID + "," +
                                                                                        "\"ProductsID\":" + ProductsID + "," +
                                                                                        "\"oQuantity\":" + (0 - Quantity) + "," +
                                                                                        "\"oPrice\":0," +
                                                                                        "\"oMoney\":0," +
                                                                                        "\"StoresSupplierID\":0," +
                                                                                        "\"IsPromotions\":0," +
                                                                                        "\"oWorkType\":0," +
                                                                                        "\"oAppendTime\":\"" + DateTime.Now + "\"},";

                                                _OrderListDataJson += "{\"OrderListID\":0," +
                                                                                       "\"OrderID\":0," +
                                                                                       "\"StorageID\":" + t_StorageID + "," +
                                                                                       "\"ProductsID\":" + ProductsID + "," +
                                                                                       "\"oQuantity\":" + Quantity + "," +
                                                                                       "\"oPrice\":0," +
                                                                                       "\"oMoney\":0," +
                                                                                       "\"StoresSupplierID\":0," +
                                                                                       "\"IsPromotions\":0," +
                                                                                       "\"oWorkType\":0," +
                                                                                       "\"oAppendTime\":\"" + DateTime.Now + "\"},";
                                            }
                                            else
                                            {
                                                _OrderListDataJson += "{\"OrderListID\":0," +
                                                                                            "\"OrderID\":0," +
                                                                                            "\"StorageID\":" + s_StorageID + "," +
                                                                                            "\"ProductsID\":" + ProductsID + "," +
                                                                                            "\"oQuantity\":" + (0 - Quantity) + "," +
                                                                                            "\"oPrice\":0," +
                                                                                            "\"oMoney\":0," +
                                                                                            "\"StoresSupplierID\":0," +
                                                                                            "\"IsPromotions\":0," +
                                                                                            "\"oWorkType\":0," +
                                                                                            "\"oAppendTime\":\"" + DateTime.Now + "\"},";

                                                _OrderListDataJson += "{\"OrderListID\":0," +
                                                                                       "\"OrderID\":0," +
                                                                                       "\"StorageID\":" + s_StorageID + "," +
                                                                                       "\"ProductsID\":" + ProductsID + "," +
                                                                                       "\"oQuantity\":" + Quantity + "," +
                                                                                       "\"oPrice\":0," +
                                                                                       "\"oMoney\":0," +
                                                                                       "\"StoresSupplierID\":0," +
                                                                                       "\"IsPromotions\":0," +
                                                                                       "\"oWorkType\":0," +
                                                                                       "\"oAppendTime\":\"" + DateTime.Now + "\"},";
                                            }
                                        }
                                    }
                                    if (_OrderListDataJson.Trim() != "")
                                    {
                                        _OrderListDataJson = "{\"OrderListJson\":[" + Utils.ReSQLSetTxt(_OrderListDataJson) + "]}";
                                    }

                                    OrderInfo _oi = new OrderInfo();
                                    OrderNOFullInfo _of = new OrderNOFullInfo();

                                    _oi.oOrderNum = Orders.GetNewOrderNum();
                                    _oi.oType = 9;//调拨
                                    _oi.StoresID = 0;
                                    _oi.oCustomersName = "";
                                    _oi.oCustomersContact = "";
                                    _oi.oCustomersTel = "";
                                    _oi.oCustomersAddress = "";
                                    _oi.oCustomersOrderID = "";
                                    _oi.oCustomersNameB = "";
                                    _oi.StaffID = 0;
                                    _oi.UserID = this.userid;
                                    _oi.oAppendTime = DateTime.Now;
                                    _oi.oOrderDateTime = DateTime.Now;
                                    _oi.oState = 0;
                                    _oi.oSteps = 1;
                                    _oi.OrderListDataJson = (OrderListDataJson)JavaScriptConvert.DeserializeObject(_OrderListDataJson, typeof(OrderListDataJson));
                                    int ToOrderID = Orders.AddOrderInfoAndList(_oi);
                                    if (ToOrderID > 0)
                                    {
                                        for (int i = 1; i <= loop_count; i++)
                                        {
                                            s_StorageID = HTTPRequest.GetInt("s_StorageID_" + i, 0);
                                            ProductsID = HTTPRequest.GetInt("ProductsID_" + i, 0);
                                            t_StorageID = HTTPRequest.GetInt("t_StorageID_" + i, 0);
                                            Quantity = HTTPRequest.GetString("Quantity_" + i).Trim() != "" ? Convert.ToDecimal(HTTPRequest.GetString("Quantity_" + i).Trim()) : 0;

                                            if (s_StorageID > 0 && ProductsID > 0)
                                            {
                                                 if (t_StorageID > 0)
                                                {
                                                    _of.OrderID = OrderID;
                                                    _of.OrderToID = ToOrderID;
                                                    _of.ProductsID = ProductsID;
                                                    _of.FormStorageID = s_StorageID;
                                                    _of.ToStorageID = t_StorageID;
                                                    _of.oQuantity = Quantity;
                                                    _of.oState = 0;
                                                    _of.oAppendTimie = DateTime.Now;
                                                    _of.UserID = this.userid;

                                                    Orders.AddOrderNOFullInfo(_of);
                                                }
                                                 else
                                                 {
                                                     _of.OrderID = OrderID;
                                                     _of.OrderToID = ToOrderID;
                                                     _of.ProductsID = ProductsID;
                                                     _of.FormStorageID = s_StorageID;
                                                     _of.ToStorageID = s_StorageID;
                                                     _of.oQuantity = Quantity;
                                                     _of.oState = 0;
                                                     _of.oAppendTimie = DateTime.Now;
                                                     _of.UserID = this.userid;

                                                     Orders.AddOrderNOFullInfo(_of);
                                                 }
                                            }
                                            
                                        }

                                        //审核
                                        _oi = Orders.GetOrderInfoModel(ToOrderID);
                                        Orders.VerifyOrder(_oi.OrderID);
                                        tbProductsInfo.UpdateProductsStorageByOrderID(OrderID);//更新当前在途库存情况


                                        OrderWorkingLogInfo owl = new OrderWorkingLogInfo();

                                        //原单操作记录
                                        owl.OrderID = oi.OrderID;
                                        owl.UserID = this.userid;
                                        owl.oType = 7;
                                        owl.oMsg = "非全额单据,调拨处理,系统自动完成,原单据:" + oi.oOrderNum+",调拨单据:"+_oi.oOrderNum;
                                        owl.pAppendTime = DateTime.Now;

                                        Orders.AddOrderWorkingLogInfo(owl);

                                        //调拨单操作记录
                                        owl.OrderID = _oi.OrderID;
                                        owl.UserID = this.userid;
                                        owl.oType = 2;
                                        owl.oMsg = "非全额单据,调拨处理,系统自动完成,原单据:" + oi.oOrderNum;
                                        owl.pAppendTime = DateTime.Now;

                                        Orders.AddOrderWorkingLogInfo(owl);
                                        _oi.oSteps = 3;
                                        Orders.UpdateOrderInfo(_oi);

                                        tbProductsInfo.UpdateProductsStorageByOrderID(ToOrderID);//更新当前在途库存情况

                                        owl = new OrderWorkingLogInfo();
                                        owl.OrderID = _oi.OrderID;
                                        owl.UserID = this.userid;
                                        owl.oType = 3;
                                        owl.oMsg = "非全额单据,调拨处理,系统自动完成,原单据:" + oi.oOrderNum;
                                        owl.pAppendTime = DateTime.Now;

                                        Orders.AddOrderWorkingLogInfo(owl);
                                        //完成收货操作
                                        _oi.oSteps = 4;
                                        Orders.UpdateOrderInfo(_oi);

                                        tbProductsInfo.UpdateProductsStorageByOrderID(ToOrderID);//更新当前在途库存情况

                                        owl = new OrderWorkingLogInfo();
                                        owl.OrderID = _oi.OrderID;
                                        owl.UserID = this.userid;
                                        owl.oType = 4;
                                        owl.oMsg = "非全额单据,调拨处理,系统自动完成,原单据:" + oi.oOrderNum;
                                        owl.pAppendTime =DateTime.Now;

                                        Orders.AddOrderWorkingLogInfo(owl);

                                        //完成核销操作
                                        _oi.oSteps = 5;
                                        Orders.UpdateOrderInfo(_oi);

                                        tbProductsInfo.UpdateProductsStorageByOrderID(ToOrderID);//更新当前在途库存情况

                                        owl = new OrderWorkingLogInfo();
                                        owl.OrderID = _oi.OrderID;
                                        owl.UserID = this.userid;
                                        owl.oType = 5;
                                        owl.oMsg = "非全额单据,调拨处理,系统自动完成,原单据:" + oi.oOrderNum;
                                        owl.pAppendTime = DateTime.Now;

                                        Orders.AddOrderWorkingLogInfo(owl);

                                        AddMsgLine("非全额收获单处理完成!转调拨单:" + _oi.oOrderNum);
                                        AddScript("window.setTimeout('parent.location=parent.location;',2000);");
                                    }
                                    else {
                                        AddErrLine("操作失败!");
                                    }
                                }
                                else {
                                    AddErrLine("数据错误!");
                                }
                            }
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
            pagetitle = " 非全额收货单据处理";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}