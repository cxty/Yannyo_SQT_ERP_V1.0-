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

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Yannyo.Web
{


	public partial class storage_order_do : PageBase
	{

		public int ordertype = 0;//单据类型
		public string Act = "";
		public string OrderListDataJsonStr = "";
		public string StorageOrderList = "";
		public string StorageOrderListJsonStr = "";
		public DateTime oOrderDateTime = DateTime.Now;
		public DataTable OrderFieldList = new DataTable();
		public DataTable CertificateList = new DataTable();
		public string OrderFieldListJson = "";
		public int orderid = 0;//单据编号
		public OrderInfo oi = new OrderInfo();
		public StorageProductLogInfo spl = new StorageProductLogInfo ();

		public bool ShowTree = false;
		public bool IsVerify = false;
		public bool IsEditData = false;//修正数据操作单
		public string OrderWorkingLogMsg = "";
		public int OrderWorkingType = 0;//当前单据操作标识
		public string format = "";//返回值格式,默认html
		public bool IsFirst = false;//当前是否为原始单据
		public bool ShowEdit = false;//是否可编辑
		public bool IsNOFull = false;//是否为非全额单据
		public bool IsNOFullAndNOToDo = false;//非全额单据且差额未转单

		public bool IsPrepayOK = false;//需预付的是否预付成功
		public decimal PrepayMoney = 0;//已预付金额
		public decimal cSumMoney = 0;//预付合计

		public string pagecode = "";//防止操作员提交后刷新,导致重新提交.
		public bool IsMOrder = false;//是否为网购订单
		public M_SendGoodsInfo _ms = new M_SendGoodsInfo();//网购订单
		public string MS_Json = "";//网购单操作时返回信息

		public string Order_QRCode_URL = "";//外部查看连接

		protected virtual void Page_Load(object sender, EventArgs e)
		{

			if (this.userid > 0)
			{
				ordertype = HTTPRequest.GetInt("ordertype", 0);
				orderid = HTTPRequest.GetInt("orderid", 0);

				Act = Utils.ChkSQL(HTTPRequest.GetString("Act")).Trim();
				format = HTTPRequest.GetString("format");
				IsFirst = (HTTPRequest.GetString("IsFirst").Trim() != "") ? Convert.ToBoolean(HTTPRequest.GetString("IsFirst").Trim()) : false; ;

				if (ordertype > 0 && Act != "")
				{
					#region 权限判断
					switch (ordertype)
					{
					case 1://采购入库=1
						if (CheckUserPopedoms("X") || CheckUserPopedoms("3-3-4-1-1") || CheckUserPopedoms("3-3-4-1-2"))
						{
							switch (Act)
							{

							case "8":
							case "v":
								if (ispost) {
									if (CheckUserPopedoms("X") || CheckUserPopedoms("3-3-4-1-2")){
										oi = Orders.GetOrderInfoModel(this.orderid);

										if (oi != null)
										{
											if (oi.oSteps == 2 || oi.oSteps == 3)
											{

											}
											else
											{
												AddErrLine("无法 添加 记录，单据状态限制!");
											}
										}
										else {
											AddErrLine("参数错误!");
										}
									}
									else
									{
										AddErrLine("权限不足,无法 操作 列表!");
									}
								}
								if (CheckUserPopedoms("X") || CheckUserPopedoms("3-3-4-1-1"))
								{
									OrderWorkingType = 8;
								}
								else
								{
									AddErrLine("权限不足,无法 查看 列表!");
								}
								break;
							}
						}
						else
						{
							AddErrLine("权限不足,无法浏览 采购入库单 列表!");
						}
						break;
					case 2://采购退货=2
						if (CheckUserPopedoms("X") || CheckUserPopedoms("3-3-4-2-1") || CheckUserPopedoms("3-3-4-2-2") )
						{
							switch (Act)
							{

							case "8":case "v":
								if (ispost)
								{
									if (CheckUserPopedoms("X") || CheckUserPopedoms("3-3-4-2-2")){
										oi = Orders.GetOrderInfoModel(this.orderid);

										if (oi != null)
										{
											if (oi.oSteps == 2 || oi.oSteps == 3)
											{

											}
											else
											{
												AddErrLine("无法 添加 记录，单据状态限制!");
											}
										}
										else {
											AddErrLine("参数错误!");
										}
									}
									else
									{
										AddErrLine("权限不足,无法 操作 列表!");
									}
								}
								if (CheckUserPopedoms("X") || CheckUserPopedoms("3-3-4-2-1"))
								{
									OrderWorkingType =8;
								}
								else
								{
									AddErrLine("权限不足,无法 查看 列表!");
								}
								break;
							}
						}
						else
						{
							AddErrLine("权限不足,无法浏览 采购退货单 列表!");
						}
						break;
					case 3://销售发货=3
						if (CheckUserPopedoms("X") || CheckUserPopedoms("3-3-4-3-1") || CheckUserPopedoms("3-3-4-3-2"))
						{
							switch (Act)
							{

							case "8":
							case "v":
								if (ispost)
								{
									if (CheckUserPopedoms("X") || CheckUserPopedoms("3-3-4-3-2")){
										oi = Orders.GetOrderInfoModel(this.orderid);

										if (oi != null)
										{
											if (oi.oSteps == 2 || oi.oSteps == 3)
											{

											}
											else
											{
												AddErrLine("无法 添加 记录，单据状态限制!");
											}
										}
										else {
											AddErrLine("参数错误!");
										}
									}
									else
									{
										AddErrLine("权限不足,无法 操作 列表!");
									}
								}
								if (CheckUserPopedoms("X") || CheckUserPopedoms("3-3-4-3-1"))
								{
									OrderWorkingType =8;
								}
								else
								{
									AddErrLine("权限不足,无法 查看 列表!");
								}
								break;
							}
						}
						else
						{
							AddErrLine("权限不足,无法浏览 销售发货单 列表!");
						}
						break;
					case 4://销售退货=4
						if (CheckUserPopedoms("X") || CheckUserPopedoms("3-3-4-4-1") || CheckUserPopedoms("3-3-4-4-2"))
						{
							switch (Act)
							{

							case "8":
							case "v":
								if (ispost)
								{
									if (CheckUserPopedoms("X") || CheckUserPopedoms("3-3-4-4-2")){
										oi = Orders.GetOrderInfoModel(this.orderid);

										if (oi != null)
										{
											if (oi.oSteps == 2 || oi.oSteps == 3)
											{

											}
											else
											{
												AddErrLine("无法 添加 记录，单据状态限制!");
											}
										}
										else {
											AddErrLine("参数错误!");
										}
									}
									else
									{
										AddErrLine("权限不足,无法 操作 列表!");
									}
								}
								if (CheckUserPopedoms("X") || CheckUserPopedoms("3-3-4-4-1"))
								{
									OrderWorkingType =8;
								}
								else
								{
									AddErrLine("权限不足,无法 查看 列表!");
								}
								break;
							}
						}
						else
						{
							AddErrLine("权限不足,无法浏览 销售退货单 列表!");
						}
						break;
					case 5://赠品=5
						if (CheckUserPopedoms("X") || CheckUserPopedoms("3-3-4-5-1") || CheckUserPopedoms("3-3-4-5-2"))
						{
							switch (Act)
							{

							case "8":
							case "v":
								if (ispost)
								{
									if (CheckUserPopedoms("X") || CheckUserPopedoms("3-3-4-5-2")){
										oi = Orders.GetOrderInfoModel(this.orderid);

										if (oi != null)
										{
											if (oi.oSteps == 2 || oi.oSteps == 3)
											{

											}
											else
											{
												AddErrLine("无法 添加 记录，单据状态限制!");
											}
										}
										else {
											AddErrLine("参数错误!");
										}
									}
									else
									{
										AddErrLine("权限不足,无法 操作 列表!");
									}
								}
								if (CheckUserPopedoms("X") || CheckUserPopedoms("3-3-4-5-1"))
								{
									OrderWorkingType =8;
								}
								else
								{
									AddErrLine("权限不足,无法 查看 列表!");
								}
								break;
							}
						}
						else
						{
							AddErrLine("权限不足,无法浏览 赠品单 列表!");
						}
						break;
					case 6://样品=6
						if (CheckUserPopedoms("X") || CheckUserPopedoms("3-3-4-6-1") || CheckUserPopedoms("3-3-4-6-2"))
						{
							switch (Act)
							{

							case "8":
							case "v":
								if (ispost)
								{
									if (CheckUserPopedoms("X") || CheckUserPopedoms("3-3-4-6-2")){
										oi = Orders.GetOrderInfoModel(this.orderid);

										if (oi != null)
										{
											if (oi.oSteps == 2 || oi.oSteps == 3)
											{

											}
											else
											{
												AddErrLine("无法 添加 记录，单据状态限制!");
											}
										}
										else {
											AddErrLine("参数错误!");
										}
									}
									else
									{
										AddErrLine("权限不足,无法 操作 列表!");
									}
								}
								if (CheckUserPopedoms("X") || CheckUserPopedoms("3-3-4-6-1"))
								{
									OrderWorkingType =8;
								}
								else
								{
									AddErrLine("权限不足,无法 查看 列表!");
								}
								break;
							}
						}
						else
						{
							AddErrLine("权限不足,无法浏览 样品单 列表!");
						}
						break;
					case 7://代购=7
						if (CheckUserPopedoms("X") || CheckUserPopedoms("3-3-4-7-1") || CheckUserPopedoms("3-3-4-7-2"))
						{
							switch (Act)
							{

							case "8":
							case "v":
								if (ispost)
								{
									if (CheckUserPopedoms("X") || CheckUserPopedoms("3-3-4-7-2")){
										oi = Orders.GetOrderInfoModel(this.orderid);

										if (oi != null)
										{
											if (oi.oSteps == 2 || oi.oSteps == 3)
											{

											}
											else
											{
												AddErrLine("无法 添加 记录，单据状态限制!");
											}
										}
										else {
											AddErrLine("参数错误!");
										}
									}
									else
									{
										AddErrLine("权限不足,无法 操作 列表!");
									}
								}
								if (CheckUserPopedoms("X") || CheckUserPopedoms("3-3-4-7-1"))
								{
									OrderWorkingType =8;
								}
								else
								{
									AddErrLine("权限不足,无法 查看 列表!");
								}
								break;
							}
						}
						else
						{
							AddErrLine("权限不足,无法浏览 代购单 列表!");
						}
						break;
					case 8://库存调整=8
						if (CheckUserPopedoms("X") || CheckUserPopedoms("3-3-4-8-1") || CheckUserPopedoms("3-3-4-8-2"))
						{
							switch (Act)
							{

							case "8":
							case "v":
								if (ispost)
								{
									if (CheckUserPopedoms("X") || CheckUserPopedoms("3-3-4-8-2")){
										oi = Orders.GetOrderInfoModel(this.orderid);

										if (oi != null)
										{
											if (oi.oSteps == 2 || oi.oSteps == 3)
											{

											}
											else
											{
												AddErrLine("无法 添加 记录，单据状态限制!");
											}
										}
										else {
											AddErrLine("参数错误!");
										}
									}
									else
									{
										AddErrLine("权限不足,无法 操作 列表!");
									}
								}
								if (CheckUserPopedoms("X") || CheckUserPopedoms("3-3-4-8-1"))
								{
									OrderWorkingType =8;
								}
								else
								{
									AddErrLine("权限不足,无法 查看 列表!");
								}
								break;
							}
						}
						else
						{
							AddErrLine("权限不足,无法浏览 库存调整单 列表!");
						}
						break;
					case 9://库存调拨=9
						if (CheckUserPopedoms("X") || CheckUserPopedoms("3-3-4-8-1") || CheckUserPopedoms("3-3-4-8-2"))
						{
							switch (Act)
							{

							case "8":
							case "v":
								if (ispost)
								{
									if (CheckUserPopedoms("X") || CheckUserPopedoms("3-3-4-8-2")){
										oi = Orders.GetOrderInfoModel(this.orderid);

										if (oi != null)
										{
											if (oi.oSteps == 2 || oi.oSteps == 3)
											{

											}
											else
											{
												AddErrLine("无法 添加 记录，单据状态限制!");
											}
										}
										else {
											AddErrLine("参数错误!");
										}
									}
									else
									{
										AddErrLine("权限不足,无法 操作 列表!");
									}
								}
								if (CheckUserPopedoms("X") || CheckUserPopedoms("3-3-4-8-1"))
								{
									OrderWorkingType =8;
								}
								else
								{
									AddErrLine("权限不足,无法 查看 列表!");
								}
								break;
							}
						}
						else
						{
							AddErrLine("权限不足,无法浏览 库存调拨单 列表!");
						}
						break;
					case 10://坏货=10
						if (CheckUserPopedoms("X") || CheckUserPopedoms("3-3-4-8-1") || CheckUserPopedoms("3-3-4-8-2"))
						{
							switch (Act)
							{

							case "8":
							case "v":
								if (ispost)
								{
									if (CheckUserPopedoms("X") || CheckUserPopedoms("3-3-4-8-2")){
										oi = Orders.GetOrderInfoModel(this.orderid);

										if (oi != null)
										{
											if (oi.oSteps == 2 || oi.oSteps == 3)
											{

											}
											else
											{
												AddErrLine("无法 添加 记录，单据状态限制!");
											}
										}
										else {
											AddErrLine("参数错误!");
										}
									}
									else
									{
										AddErrLine("权限不足,无法 操作 列表!");
									}
								}
								if (CheckUserPopedoms("X") || CheckUserPopedoms("3-3-4-8-1"))
								{
									OrderWorkingType =8;
								}
								else
								{
									AddErrLine("权限不足,无法 查看 列表!");
								}
								break;
							}
						}
						else
						{
							AddErrLine("权限不足,无法浏览 坏货单 列表!");
						}
						break;
					case 11://换货=11
						if (CheckUserPopedoms("X") || CheckUserPopedoms("3-3-4-8-1") || CheckUserPopedoms("3-3-4-8-2"))
						{
							switch (Act)
							{

							case "8":
							case "v":
								if (ispost)
								{
									if (CheckUserPopedoms("X") || CheckUserPopedoms("3-3-4-8-2")){
										oi = Orders.GetOrderInfoModel(this.orderid);

										if (oi != null)
										{
											if (oi.oSteps == 2 || oi.oSteps == 3)
											{

											}
											else
											{
												AddErrLine("无法 添加 记录，单据状态限制!");
											}
										}
										else {
											AddErrLine("参数错误!");
										}
									}
									else
									{
										AddErrLine("权限不足,无法 操作 列表!");
									}
								}
								if (CheckUserPopedoms("X") || CheckUserPopedoms("3-3-4-8-1"))
								{
									OrderWorkingType = 8;
								}
								else
								{
									AddErrLine("权限不足,无法 查看 列表!");
								}
								break;
							}
						}
						else
						{
							AddErrLine("权限不足,无法浏览 换货单 列表!");
						}
						break;
					case 12://修正数据
						if (CheckUserPopedoms("X") || CheckUserPopedoms("7-2-1-5-7-1")){
							IsEditData = true;
						}else{
							AddErrLine("权限不足,无法进行数据调整操作!");
						}
						break;
					}

					#endregion
				}
				else
				{
					AddErrLine("参数错误,请返回!");
				}

				if (!IsErr())
				{

					oOrderDateTime = (HTTPRequest.GetString("oOrderDateTime").Trim() != "") ? Convert.ToDateTime(Utils.ChkSQL(HTTPRequest.GetString("oOrderDateTime"))) : DateTime.Now;
					string _OrderListDataJson = HTTPRequest.GetString("OrderListDataJson");
					OrderWorkingLogMsg = Utils.ChkSQL(HTTPRequest.GetString("OrderWorkingLogMsg"));
					string _splRemake = Utils.ChkSQL(HTTPRequest.GetString("splRemake"));
					// oi = new OrderInfo();
					switch (Act)
					{
						#region 查看,修改
					case "v":case "e":
						oi = Orders.GetOrderInfoModel(orderid);
						if (!ispost)
						{
							if (oi != null)
							{
								//CertificateList = Certificates.GetCertificateInfoList(" cObject=1 and cObjectID=" + oi.OrderID + " and cState=0 order by cDateTime desc").Tables[0];
								PrepayMoney = Certificates.GetPrepayMoneyByOrderID(oi.OrderID);
								oOrderDateTime = oi.oOrderDateTime;

								//是否为网购订单
								_ms = M_Utils.GetM_SendGoodsInfoModelByOrderID(oi.OrderID);
								if (_ms != null)
								{
									IsMOrder = true;
								}

								//未审核,可修改
								if (oi.oSteps == 1)
								{
									this.ShowEdit = true;
									ShowTree = true;
									IsVerify = true;
								}
								else {
									if (oi.oType != 11)//非换货单可修改
									{
										if (oi.oPrepay == 1)
										{
											//是否已完成预付操作
											IsPrepayOK = Certificates.CheckCertificateByOrderID(oi.OrderID);
										}
										else 
										{
											IsPrepayOK = true;
										}

										//已审核已发货
										if (oi.oSteps == 3)
										{
											this.ShowEdit = true;
										}
										else if (oi.oSteps >= 4)
										{
											//已经收货,已验收,已对账
											IsNOFull = Orders.CheckOrderIsFull(oi.OrderID);
										}
									}
									else {
										IsPrepayOK = true;
										this.ShowEdit = false;
									}
								}
								OrderListDataJsonStr = "";//{"OrderListJson":[{"OrderListID":0,"OrderID":0,"StorageID":0,"ProductsID":0,"oQuantity":0,"oPrice":0,"oMoney":0,"StoresSupplierID":0,"IsPromotions":0,"oWorkType":0,"oAppendTime":"\/Date(1289206775426+0800)\/","OrderFieldValueInfo":[{"OrderFieldValueID":0,"OrderFieldID":0,"OrderListID":0,"oFieldValue":null,"IsVerify":0,"oAppendTime":"\/Date(1289206775426+0800)\/"}]}]} 
								string OrderFieldValueStr = "";
								string tSteps = "";
								string tSteps_b = "";

								Order_QRCode_URL = "" + config.Sysurl + "/o-" + oi.OrderID + ".aspx?rc=" + Utils.UrlEncode(DES.Encode(oi.LastPrintDateTime.ToString() + "|" + oi.oOrderNum, config.Passwordkey)).Trim();


								if (IsFirst)//输出原始单据
								{
									tSteps = " oWorkType=0";
									tSteps_b = " IsVerify=0";
								}
								else
								{
									tSteps = ((oi.oSteps == 1) ? " oWorkType=0" : " oWorkType<>0").ToString();
									tSteps_b = ((oi.oSteps == 1) ? " IsVerify=0" : " IsVerify<>0").ToString();
								}

								//取已收发列表
								DataTable Storage_Order = tbStorageProductLogInfo.GetStorageProductLogListINOrderList(oi.OrderID).Tables[0];
								if(Storage_Order!=null){
									foreach(DataRow dr_Storage_Order in Storage_Order.Rows){
										StorageOrderList+="{\"OrderListID\":"+dr_Storage_Order["OrderListID"].ToString()+","+
														   "\"StorageID\":"+dr_Storage_Order["StorageID"].ToString()+","+
										                   "\"ProductsID\":"+dr_Storage_Order["ProductsID"].ToString()+","+
										                   "\"pQuantity\":"+dr_Storage_Order["pQuantity"].ToString()+"},";
									}
									if(StorageOrderList!=""){
										StorageOrderListJsonStr = "{\"StorageOrderList\":["+Utils.ReSQLSetTxt(StorageOrderList)+"]}";
									}
								}

								//取单据列表
								DataTable OrderListData = Orders.GetOrderListInfoList(" OrderID=" + oi.OrderID + " and " + tSteps + " order by OrderListID asc").Tables[0];
								if (OrderListData != null)
								{
									foreach (DataRow dr_OrderListData in OrderListData.Rows)
									{
										OrderFieldValueStr = "";
										DataTable OrderFieldValueData = Orders.GetOrderFieldValueInfoList(" OrderListID=" + dr_OrderListData["OrderListID"].ToString() + "and " + tSteps_b).Tables[0];
										foreach (DataRow dr_OrderFieldValueData in OrderFieldValueData.Rows)
										{
											OrderFieldValueStr += "{\"OrderFieldValueID\":" + dr_OrderFieldValueData["OrderFieldValueID"].ToString() + ",\"OrderFieldID\":" + dr_OrderFieldValueData["OrderFieldID"].ToString() + ",\"OrderListID\":" + dr_OrderFieldValueData["OrderListID"].ToString() + ",\"oFieldValue\":\"" + dr_OrderFieldValueData["oFieldValue"].ToString() + "\",\"IsVerify\":" + dr_OrderFieldValueData["IsVerify"].ToString() + ",\"oAppendTime\":\"" + dr_OrderFieldValueData["oAppendTime"].ToString() + "\"},";
										}
										if (OrderFieldValueStr != "")
										{
											OrderFieldValueStr =",\"OrderFieldValueInfo\":["+ Utils.ReSQLSetTxt(OrderFieldValueStr)+"]";
										}
										OrderListDataJsonStr += "{\"OrderListID\":" + dr_OrderListData["OrderListID"].ToString() + ","+
										                            "\"OrderID\":" + dr_OrderListData["OrderID"].ToString() + "," +
										                            "\"StorageID\":" + dr_OrderListData["StorageID"].ToString() + "," +
										                            "\"StorageName\":\"" + dr_OrderListData["StorageName"].ToString() + "\"," +
										                            "\"ProductsID\":" + dr_OrderListData["ProductsID"].ToString() + "," +
										                            "\"ProductsName\":\"" +Utils.ReplaceString( Utils.ReplaceString( dr_OrderListData["ProductsName"].ToString(),"'","\\'",false),"\"","\\\"",false) + "\"," +
										                            "\"oQuantity\":" + dr_OrderListData["oQuantity"].ToString() + "," +
										                            "\"oPrice\":" + dr_OrderListData["oPrice"].ToString() + "," +
										                            "\"oMoney\":" + dr_OrderListData["oMoney"].ToString() + "," +
										                            "\"StoresSupplierID\":" + dr_OrderListData["StoresSupplierID"].ToString() + "," +
										                            "\"IsPromotions\":" + dr_OrderListData["IsPromotions"].ToString() + "," +
										                            "\"oWorkType\":" + dr_OrderListData["oWorkType"].ToString() + "," +
										                            "\"IsGifts\":" + dr_OrderListData["IsGifts"].ToString() + "," +
										                            "\"oAppendTime\":\"" + dr_OrderListData["oAppendTime"].ToString() + "\"," +
										                            "\"PriceClassID\":\"" + dr_OrderListData["PriceClassID"].ToString() + "\" "+OrderFieldValueStr+"},";

									}
									if (OrderListDataJsonStr.Trim() != "")
									{
										OrderListDataJsonStr = "{\"OrderListJson\":["+Utils.ReSQLSetTxt(OrderListDataJsonStr)+"]}";
									}
								}
							}
							else
							{
								AddErrLine("参数错误,单据列表不存在!");
							}
						}
						break;
						#endregion

					}
					if (ispost) {

						if(!IsEditData){
							//非作废单据
							if (oi.oState != 1)
							{
								if(oi.oSteps == 2 || oi.oSteps == 3)
								{

								}

							}
							else {
								AddErrLine("此单已作废,无法修改!");
								AddScript("window.setTimeout('history.back(1);',2000);");
							}
						}else{

							oi = new OrderInfo();

						}

						if (!IsErr()){
							//增加发货记录
							spl.StorageID = 0;//暂留无用
							spl.StaffID = this.userid;
							spl.OrderID = oi.OrderID;
							spl.splRemake = _splRemake;
							spl.splAppendTime = DateTime.Now;


						//Response.Write (_OrderListDataJson);
						//	Response.End ();

							spl.StorageOrderListDataJson = (StorageOrderListDataJson)JavaScriptConvert.DeserializeObject(_OrderListDataJson,typeof(StorageOrderListDataJson));

							int StorageProductLogDataID = tbStorageProductLogInfo.AddStorageProductLogInfo(spl);

							if(StorageProductLogDataID>0){

								AddMsgLine("保存成功!");

								//更新当前在途库存情况
								if(oi.oSteps == 2){
									oi.oSteps = 3;
									Orders.UpdateOrderInfo(oi);

									tbProductsInfo.UpdateProductsStorageByOrderID(orderid);

									OrderWorkingLogInfo owl = new OrderWorkingLogInfo();
									owl.OrderID = oi.OrderID;
									owl.UserID = this.userid;
									owl.oType = 3;
									owl.oMsg = OrderWorkingLogMsg;
									owl.pAppendTime = DateTime.Now;

									Orders.AddOrderWorkingLogInfo(owl);

									
									try
									{
										#region 发送邮件给收货人员
										//oi = Orders.GetOrderInfoModel(OrderID);
										switch (oi.oType)
										{
										case 1://采购入库
											UsersUtils.SendUserMailByPopedom("3-1-1-4", "采购入库单 等待收货处理,单号:" + oi.oOrderNum, "采购入库单 等待收货处理,单号:" + oi.oOrderNum);
											break;
										case 2://采购退货
											UsersUtils.SendUserMailByPopedom("3-1-2-4", "采购退货单 等待收货处理,单号:" + oi.oOrderNum, "采购退货单 等待收货处理,单号:" + oi.oOrderNum);
											break;
										case 3://销售发货
											UsersUtils.SendUserMailByPopedom("3-2-1-4", "销售发货单 等待收货处理,单号:" + oi.oOrderNum, "销售发货单 等待收货处理,单号:" + oi.oOrderNum);
											break;
										case 4://销售退货
											UsersUtils.SendUserMailByPopedom("3-2-2-4", "销售退货单 等待收货处理,单号:" + oi.oOrderNum, "销售退货单 等待收货处理,单号:" + oi.oOrderNum);
											break;
										case 5://赠品
											UsersUtils.SendUserMailByPopedom("3-2-3-4", "赠品单 等待收货处理,单号:" + oi.oOrderNum, "赠品单 等待收货处理,单号:" + oi.oOrderNum);
											break;
										case 6://样品
											UsersUtils.SendUserMailByPopedom("3-2-4-4", "样品单 等待收货处理,单号:" + oi.oOrderNum, "样品单 等待收货处理,单号:" + oi.oOrderNum);
											break;
										case 7://代购
											UsersUtils.SendUserMailByPopedom("3-2-5-4", "代购单 等待收货处理,单号:" + oi.oOrderNum, "代购单 等待收货处理,单号:" + oi.oOrderNum);
											break;
										case 11://换货
											UsersUtils.SendUserMailByPopedom("3-2-6-4", "换货单 等待收货处理,单号:" + oi.oOrderNum, "换货单 等待收货处理,单号:" + oi.oOrderNum);
											break;
										case 10://坏货
											UsersUtils.SendUserMailByPopedom("3-3-3-4", "坏货单 等待收货处理,单号:" + oi.oOrderNum, "坏货单 等待收货处理,单号:" + oi.oOrderNum);
											break;
										case 8://库存调整
											UsersUtils.SendUserMailByPopedom("3-3-1-4", "库存调整单 等待收货处理,单号:" + oi.oOrderNum, "库存调整单 等待收货处理,单号:" + oi.oOrderNum);
											break;
										case 9://库存调拨
											UsersUtils.SendUserMailByPopedom("3-3-2-4", "库存调拨单 等待收货处理,单号:" + oi.oOrderNum, "库存调拨单 等待收货处理,单号:" + oi.oOrderNum);
											break;
										}
										#endregion


										switch (oi.oType)
										{

										case 3:
										case 4:
										case 5:
										case 6:
											#region 发邮件给业务员
											if (oi.StaffID != 0)
											{
												tbStaffInfo.SendMailToStaff(oi.StaffID, tbStoresInfo.GetStoresInfoModel(oi.StoresSupplierID).sName + "," + GetOrderType(oi.oType.ToString()) + "单:" + oi.oOrderNum + "已发货.", "客户:" + tbStoresInfo.GetStoresInfoModel(oi.StoresSupplierID).sName + ",的" + GetOrderType(oi.oType.ToString()) + "单,单号:" + oi.oOrderNum + "已发货等待收货,请注意跟踪.<br>单据处理情况:" + config.Sysurl + "/o-" + oi.OrderID + ".aspx?rc=" + Utils.UrlEncode(DES.Encode(oi.LastPrintDateTime.ToString() + "|" + oi.oOrderNum, config.Passwordkey)).Trim());
											}
											#endregion

											#region 给客户发邮件
											tbStoresInfo.SendMailToStores(oi.StoresSupplierID, GetOrderType(oi.oType.ToString()) + "单 已发货,单号:" + oi.oOrderNum, GetOrderType(oi.oType.ToString()) + "单 已发货,单号:" + oi.oOrderNum);
											#endregion
											break;
										}

									}
									catch(Exception ex)
									{
										AddErrLine(ex.Message);
									}
								}
							}
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
			if (format == "json")
			{
				Response.ClearContent();
				Response.Buffer = true;
				Response.ExpiresAbsolute = System.DateTime.Now.AddYears(-1);
				Response.Expires = 0;

				Response.Charset = "utf-8";
				Response.ContentEncoding = System.Text.Encoding.GetEncoding("utf-8");
				Response.ContentType = "application/json";
				string Json_Str = "{\"results\": {\"msg\":\"" + this.msgbox_text + "\",\"state\":\"" + (!IsErr()).ToString() + "\"}" + MS_Json + "}";
				Response.Write(Json_Str);
				Response.End();
			}
		}
		protected override void ShowPage()
		{
			pagetitle = " 单据信息";
			this.Load += new EventHandler(this.Page_Load);
		}
	}


}

