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
using Yannyo.Cache;
using Yannyo.Common;
using Yannyo.Entity;
using Yannyo.BLL;
using Newtonsoft.Json;

namespace Yannyo.Web
{
    public partial class msendgoods : MPageBase
    {
        public string m_TradeInfoID_Str = "";//交易编号列表
        public decimal sum_a = 0;
        public decimal sum_b = 0;
        public decimal sum_c = 0;
        public decimal sum_d = 0;
        public decimal sum_e = 0;
        public string Act = "";
        public DataTable oList = new DataTable();//订单
        public DataTable tList = new DataTable();//交易
        public DataTable eList = new DataTable();//物流

        public int loop_count = 0;

        public M_SendGoodsInfo SendGoods = new M_SendGoodsInfo();
        public string OrderListDataJsonStr = "";//查看时使用

        public StoresInfo Sender = new StoresInfo();

        protected virtual void Page_Load(object sender, EventArgs e)
        {
            
             if (this.userid > 0)
            {
                if (CheckUserPopedoms("X") || CheckUserPopedoms("8-3-2-1"))
                {
                    Act = HTTPRequest.GetString("Act");
                    m_TradeInfoID_Str = HTTPRequest.GetString("m_TradeInfoID");
                   if (m_TradeInfoID_Str.Trim() != "")
                   {
                       m_TradeInfoID_Str = Utils.ReSQLSetTxt("," + m_TradeInfoID_Str + ",");

                       if (ispost)
                       {
                           OrderInfo oi = new OrderInfo();

                           string receiver_state = Utils.ChkSQL(HTTPRequest.GetString("receiver_state"));
                           string receiver_city = Utils.ChkSQL(HTTPRequest.GetString("receiver_city"));
                           string receiver_district = Utils.ChkSQL(HTTPRequest.GetString("receiver_district"));
                           string receiver_address = Utils.ChkSQL(HTTPRequest.GetString("receiver_address"));
                           string receiver_zip = Utils.ChkSQL(HTTPRequest.GetString("receiver_zip"));
                           string receiver_name = Utils.ChkSQL(HTTPRequest.GetString("receiver_name"));
                           string receiver_mobile = Utils.ChkSQL(HTTPRequest.GetString("receiver_mobile"));
                           string receiver_phone = Utils.ChkSQL(HTTPRequest.GetString("receiver_phone"));
                           
                           string from_name = Utils.ChkSQL(HTTPRequest.GetString("from_name"));
                           string from_state = Utils.ChkSQL(HTTPRequest.GetString("from_state"));
                           string from_city = Utils.ChkSQL(HTTPRequest.GetString("from_city"));
                           string from_district = Utils.ChkSQL(HTTPRequest.GetString("from_district"));
                           string from_address = Utils.ChkSQL(HTTPRequest.GetString("from_address"));
                           string from_zip = Utils.ChkSQL(HTTPRequest.GetString("from_zip"));
                           string from_mobile = Utils.ChkSQL(HTTPRequest.GetString("from_mobile"));
                           string from_phone = Utils.ChkSQL(HTTPRequest.GetString("from_phone"));


                           int ExpName = HTTPRequest.GetInt("ExpName",0);
                           string ExpNO =Utils.ChkSQL( HTTPRequest.GetString("ExpNO"));
                           string tMsg =Utils.ChkSQL( HTTPRequest.GetString("tMsg"));

                           int m_SendGoodsID = HTTPRequest.GetInt("m_SendGoodsID", 0);
                           string _OrderListDataJson = HTTPRequest.GetString("OrderListDataJson");

                           //创建发货单
                           if (Act == "Add")
                           {
                               
                               try {
                                   oi.oOrderNum = "----------";// Orders.GetNewOrderNum();
                                    //if (!Orders.ExistsOrderInfo(oi.oOrderNum))
                                    {
                                        oi.oType = 3;//销售发货单
                                        oi.StoresID = M_Config.StoresID;//系统客户编号
                                        oi.oCustomersName = M_Config.StoresName;//客户名称,
                                        oi.oCustomersContact = receiver_name;//联系人
                                        oi.oCustomersTel = receiver_mobile + "," + receiver_phone;//联系电话
                                        oi.oCustomersAddress = receiver_address;//地址
                                        oi.oCustomersOrderID = m_TradeInfoID_Str;//客户订单号
                                        oi.oCustomersNameB = "";
                                        oi.StaffID = 0;//业务员暂留空
                                        oi.UserID = this.userid;
                                        oi.oAppendTime = DateTime.Now;
                                        oi.oOrderDateTime = DateTime.Now;
                                        oi.oState = 0;
                                        oi.oSteps = 1;
                                        oi.oPrepay = 0;
                                        oi.OrderListDataJson = (OrderListDataJson)JavaScriptConvert.DeserializeObject(_OrderListDataJson, typeof(OrderListDataJson));
                                       int OrderID = Orders.AddOrderInfoAndList(oi);
                                       if (OrderID > 0)
                                       {
                                           OrderWorkingLogInfo owl = new OrderWorkingLogInfo();
                                           owl.OrderID = OrderID;
                                           owl.UserID = this.userid;
                                           owl.oType = 0;
                                           owl.oMsg = M_Config.StoresName+"-"+M_Config.m_Name+",下单:" + m_TradeInfoID_Str;
                                           owl.pAppendTime = DateTime.Now;

                                           Orders.AddOrderWorkingLogInfo(owl);

                                           //网店发货单
                                           SendGoods.m_ConfigInfoID = M_Config.m_ConfigInfoID;
                                            SendGoods.OrderID = OrderID;
                                            SendGoods.m_TradeInfoID = m_TradeInfoID_Str;
                                            SendGoods.receiver_name = receiver_name;
                                            SendGoods.receiver_state = receiver_state;
                                            SendGoods.receiver_city = receiver_city;
                                            SendGoods.receiver_district = receiver_district;
                                            SendGoods.receiver_address = receiver_address;
                                            SendGoods.receiver_zip = receiver_zip;
                                            SendGoods.receiver_mobile = receiver_mobile;
                                            SendGoods.receiver_phone = receiver_phone;
                                            SendGoods.from_name = M_Config.StoresName;
                                            SendGoods.from_state = from_state;
                                            SendGoods.from_city = from_city;
                                            SendGoods.from_district = from_district;
                                            SendGoods.from_address = from_address;
                                            SendGoods.from_zip = from_zip;
                                            SendGoods.from_mobile = from_mobile;
                                            SendGoods.from_phone = from_phone;
                                            SendGoods.mExpName = ExpName;
                                            SendGoods.mExpNO = ExpNO;
                                            SendGoods.mMemo = tMsg;
                                            SendGoods.mState = 0;
                                            SendGoods.mAppendTime = DateTime.Now;

                                            m_SendGoodsID = M_Utils.AddM_SendGoodsInfo(SendGoods);
                                            if (m_SendGoodsID > 0)
                                            {
                                                AddMsgLine("单据创建成功!<p class=\"SendGood\"><br>查看发货单据?-><a href=\"javascript:void(0);\" onclick=\"javascript:OrderDO.Show(" + OrderID + ");\">查看</a></p>");
                                                #region 发送邮件给审核人员
                                                try
                                                {
                                                    oi = Orders.GetOrderInfoModel(OrderID);
                                                    UsersUtils.SendUserMailByPopedom("3-2-1-2", "销售发货单 需审核,单号:" + oi.oOrderNum, "销售发货单 需审核,单号:" + oi.oOrderNum);
                                                }
                                                catch
                                                {
                                                }
                                                #endregion
                                            }
                                            else //网店订单生成失败,作废系统订单
                                            {
                                                oi = Orders.GetOrderInfoModel(OrderID);

                                                oi.oState = 1;
                                                Orders.UpdateOrderInfo(oi);

                                                tbProductsInfo.UpdateProductsStorageByOrderID(OrderID);//更新当前在途库存情况

                                                OrderWorkingLogInfo _owl = new OrderWorkingLogInfo();
                                                owl.OrderID = oi.OrderID;
                                                owl.UserID = this.userid;
                                                owl.oType = -1;
                                                owl.oMsg = "网店订单生成失败,系统自动作废发货单!网店单号:" + m_TradeInfoID_Str;
                                                owl.pAppendTime = DateTime.Now;

                                                Orders.AddOrderWorkingLogInfo(owl);
                                            }
                                       }
                                       else
                                       {
                                           AddErrLine("新建单据失败,请重试!");
                                       }
                                    }
                                    //else
                                    {
                                    //    AddErrLine("发货单据号重复,单据添加失败,请重试!");
                                    }
                               }
                               finally
                               {
                                   oi = null;
                               }
                           }
                           //修改操作
                           if (Act == "Edit")
                           {
                               int m_TradeInfoID = HTTPRequest.GetInt("m_TradeInfoID", 0);
                               SendGoods = M_Utils.GetM_SendGoodsInfoModelBym_TradeInfoID(m_TradeInfoID);
                               if (SendGoods != null)
                               {
                                   oi = Orders.GetOrderInfoModel(SendGoods.OrderID);
                                   oi.oCustomersContact = receiver_name;//联系人
                                   oi.oCustomersTel = receiver_mobile + "," + receiver_phone;//联系电话
                                   oi.oCustomersAddress = receiver_address;//地址
                                   
                                   oi.StaffID = 0;//业务员暂留空
                                   
                                   oi.OrderListDataJson = (OrderListDataJson)JavaScriptConvert.DeserializeObject(_OrderListDataJson, typeof(OrderListDataJson));
                                   if (Orders.UpdateOrderInfoAndList(oi))
                                   {
                                       OrderWorkingLogInfo owl = new OrderWorkingLogInfo();
                                       owl.OrderID = oi.OrderID;
                                       owl.UserID = this.userid;
                                       owl.oType = 1;
                                       owl.oMsg = "网购订单修改操作!";
                                       owl.pAppendTime = DateTime.Now;

                                       Orders.AddOrderWorkingLogInfo(owl);

                                       SendGoods.receiver_name = receiver_name;
                                       SendGoods.receiver_state = receiver_state;
                                       SendGoods.receiver_city = receiver_city;
                                       SendGoods.receiver_district = receiver_district;
                                       SendGoods.receiver_address = receiver_address;
                                       SendGoods.receiver_zip = receiver_zip;
                                       SendGoods.receiver_mobile = receiver_mobile;
                                       SendGoods.receiver_phone = receiver_phone;
                                       SendGoods.from_name = M_Config.StoresName;
                                       SendGoods.from_state = from_state;
                                       SendGoods.from_city = from_city;
                                       SendGoods.from_district = from_district;
                                       SendGoods.from_address = from_address;
                                       SendGoods.from_zip = from_zip;
                                       SendGoods.from_mobile = from_mobile;
                                       SendGoods.from_phone = from_phone;
                                       SendGoods.mExpName = ExpName;
                                       SendGoods.mExpNO = ExpNO;
                                       SendGoods.mMemo = tMsg;

                                       M_Utils.UpdateM_SendGoodsInfo(SendGoods);

                                       AddMsgLine("更新成功!");
                                   }
                                   else 
                                   {
                                       AddErrLine("发货单更新失败!");
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
                           Sender = tbStoresInfo.GetStoresInfoModel(M_Config.StoresID);

                           if (Act == "Edit")
                           {
                               //取 TradeID
                               int m_TradeInfoID = HTTPRequest.GetInt("m_TradeInfoID", 0);
                               SendGoods = M_Utils.GetM_SendGoodsInfoModelBym_TradeInfoID(m_TradeInfoID);
                               if (SendGoods != null)
                               {
                                   SendGoods.m_TradeInfoID = Utils.ReSQLSetTxt("0," + SendGoods.m_TradeInfoID + ",");
                                   tList = M_Utils.GetM_TradeInfoList(" m_ConfigInfoID=" + M_Config.m_ConfigInfoID + " and m_TradeInfoID in(" + SendGoods.m_TradeInfoID + ")").Tables[0];
                                   oList = M_Utils.GetM_OrderInfoList(" m_ConfigInfoID=" + M_Config.m_ConfigInfoID + " and m_TradeInfoID in(" + SendGoods.m_TradeInfoID + ")").Tables[0];

                                   DataTable OrderListData = Orders.GetOrderListInfoList(" OrderID=" + SendGoods.OrderID + " and oWorkType=1 order by OrderListID asc").Tables[0];
                                   if (OrderListData != null)
                                   {
                                       foreach (DataRow dr_OrderListData in OrderListData.Rows)
                                       {

                                           OrderListDataJsonStr += "{\"OrderListID\":" + dr_OrderListData["OrderListID"].ToString() + "," +
                                                                                   "\"OrderID\":" + dr_OrderListData["OrderID"].ToString() + "," +
                                                                                   "\"StorageID\":" + dr_OrderListData["StorageID"].ToString() + "," +
                                                                                   "\"StorageName\":\"" + dr_OrderListData["StorageName"].ToString() + "\"," +
                                                                                   "\"ProductsID\":" + dr_OrderListData["ProductsID"].ToString() + "," +
                                                                                   "\"ProductsName\":\"" + dr_OrderListData["ProductsName"].ToString() + "\"," +
                                                                                   "\"oQuantity\":" + dr_OrderListData["oQuantity"].ToString() + "," +
                                                                                   "\"oPrice\":" + dr_OrderListData["oPrice"].ToString() + "," +
                                                                                   "\"oMoney\":" + dr_OrderListData["oMoney"].ToString() + "," +
                                                                                   "\"StoresSupplierID\":" + dr_OrderListData["StoresSupplierID"].ToString() + "," +
                                                                                   "\"IsPromotions\":" + dr_OrderListData["IsPromotions"].ToString() + "," +
                                                                                   "\"oWorkType\":" + dr_OrderListData["oWorkType"].ToString() + "," +
                                                                                   "\"IsGifts\":" + dr_OrderListData["IsGifts"].ToString() + "," +
                                                                                   "\"PriceClassID\":" + dr_OrderListData["PriceClassID"].ToString() + "," +
                                                                                   "\"oAppendTime\":\"" + dr_OrderListData["oAppendTime"].ToString() + "\"},";

                                       }
                                       if (OrderListDataJsonStr.Trim() != "")
                                       {
                                           OrderListDataJsonStr = "{\"OrderListJson\":[" + Utils.ReSQLSetTxt(OrderListDataJsonStr) + "]}";
                                       }
                                   }
                               }
                               else {
                                   AddErrLine("该交易的发货单不存在!");
                               }
                           }
                           else
                           {
                               oList = M_Utils.GetM_OrderInfoList(" m_ConfigInfoID=" + M_Config.m_ConfigInfoID + " and m_TradeInfoID in(" + m_TradeInfoID_Str + ")").Tables[0];

                               tList = M_Utils.GetM_TradeInfoList(" m_ConfigInfoID=" + M_Config.m_ConfigInfoID + " and m_TradeInfoID in(" + m_TradeInfoID_Str + ")").Tables[0];
                           }
                           eList = M_Utils.GetM_ExpressTemplatesInfoList(" m_ConfigInfoID=" + M_Config.m_ConfigInfoID + " order by mAppendTime desc").Tables[0];
                       }
                   }
                   else {
                       AddErrLine("参数错误!");
                   }
                }
                else
                {
                    AddErrLine("权限不足!");
                    AddScript("window.setTimeout('window.parent.HidBox();',1000);");
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
            pagetitle = " 发货处理";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}