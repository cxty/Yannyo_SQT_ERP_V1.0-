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
	public partial class storage_order_print : PageBase
	{
		public int orderid = 0;
		public int ordertype = 0;
		public OrderInfo oi = new OrderInfo();
		public DataTable OrderList = new DataTable();//单据体列表
		public DataTable StorageOrderList = new DataTable();
		public UserInfo print_ui = new UserInfo();//开单人员
		public UserInfo print_v_ui = new UserInfo();//审核人员
		public decimal sumQuantityM = 0;//合计数量,小单位
		public decimal sumQuantityB = 0;//合计数量,大单位
		public bool IsMOrder = false;//是否为网购订单
		public M_SendGoodsInfo _ms = new M_SendGoodsInfo();//网购订单
		public M_ExpressTemplatesInfo _mxsp = new M_ExpressTemplatesInfo();//物流信息
		public string BuyerName = "";//买家昵称

		protected virtual void Page_Load(object sender, EventArgs e)
		{

			if (this.userid > 0) {
				if (CheckUserPopedoms ("X") || CheckUserPopedoms ("3-1-1-8") || CheckUserPopedoms ("3-1-2-8") || CheckUserPopedoms ("3-2-1-8") || CheckUserPopedoms ("3-2-2-8") || CheckUserPopedoms ("3-2-3-8") || CheckUserPopedoms ("3-2-4-8") || CheckUserPopedoms ("3-2-5-8") || CheckUserPopedoms ("3-3-1-8") || CheckUserPopedoms ("3-3-2-8") || CheckUserPopedoms ("3-3-3-8")) {
					orderid = HTTPRequest.GetInt ("orderid", 0);
					ordertype = HTTPRequest.GetInt ("ordertype", 0);

					if (orderid > 0) {
						oi = Orders.GetOrderInfoModel (orderid);
						if (oi != null) {
							string tSteps = ((oi.oSteps == 1) ? "  tbOrderListInfo.oWorkType=0 " : "  tbOrderListInfo.oWorkType<>0 ").ToString();
							OrderList = Orders.GetOrderListInfoList(" OrderID=" + oi.OrderID + " and " + tSteps + " order by OrderListID asc").Tables[0];

							//取已收发列表
							StorageOrderList = tbStorageProductLogInfo.GetStorageProductLogListINOrderList(oi.OrderID).Tables[0];


							//库存调拨单,整理数据
							if (oi.oType == 9)
							{
								DataTable nOrderList = new DataTable();
								nOrderList = OrderList.Clone();

								foreach (DataRow dr in OrderList.Rows)
								{
									if (Convert.ToDecimal(dr["oQuantity"].ToString()) < 0)
									{
										dr["StorageName"] ="来源:"+ dr["StorageName"].ToString();
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

							//制单人
							print_ui = tbUserInfo.GetUserInfoModel(oi.UserID);
							//审核人
							OrderWorkingLogInfo owil = Orders.GetOrderWorkingUserID(oi.OrderID, 2);
							if (owil != null)
							{
								print_v_ui = tbUserInfo.GetUserInfoModel(owil.UserID);
							}
							else {
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
													oi.oCustomersOrderID +=_mt.tid.ToString()+ " ";
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
							else {
								IsMOrder = false;
								_mxsp = null;
							}

							OrderWorkingLogInfo owl = new OrderWorkingLogInfo();
							owl.OrderID = oi.OrderID;
							owl.UserID = this.userid;
							owl.oType = 6;
							owl.oMsg = "打印单据,仓库收发货";
							owl.pAppendTime = DateTime.Now;

							Orders.AddOrderWorkingLogInfo(owl);

						}else {
							AddErrLine("参数错误,单据不存在!");
						}
					}else
					{
						AddErrLine("参数错误!");
					}
				}else
				{
					AddErrLine("权限不足!");
				}
			}else
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

