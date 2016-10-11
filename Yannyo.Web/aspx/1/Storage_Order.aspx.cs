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

	public partial class storage_order : PageBase
	{
		public DataTable dList = new DataTable();
		public int pagesize;
		public int pageindex;
		public int pagetotal;
		public string Act = "";
		public string S_key = "";
		public int ordertype = 0;//单据类型
		public string ordertypeStr = "";//单据类型联合检索
		public int StoresSupplierID = 0;//客户,供货商
		public string StoresSupplier = "";//客户,供货商

		public int StorageID = 0;//仓库编号
		public string StorageName = "";//仓库名称

		public string oOrderNum = "";//单据编号
		public string ProductsName = "";//产品名称
		public int ProductsID = 0;//产品编号

		public int StaffID = 0;//业务员
		public string StaffName = "";
		public int UserID = 0;//操作员
		public string UserName = "";
		public string oCustomersOrderID = "";//客户订单号
		public string oOrderDateTimeB = "";//单据时间,起点
		public string oOrderDateTimeE = "";//单据时间,结束

		public string dDateTimeB = "";//操作时间,起点
		public string dDateTimeE = "";//操作时间,结束

		public int oState = -1;//单据状态
		//public int oSteps = -1;//单据步骤
		public int sType = 1;//统计时间,1=单据,2=操作

		public DataTable OrderStpes = new DataTable();
		//public string tSQL = "";

		protected virtual void Page_Load(object sender, EventArgs e)
		{
			pagesize = 30;
			PageBarHTML = "";
			string tSQL = "";

			if (this.userid > 0) {

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
				}
				else
				{
					Act = HTTPRequest.GetQueryString("Act");
					S_key = Utils.ChkSQL(HTTPRequest.GetQueryString("S_key"));
				}
				ordertype = HTTPRequest.GetInt("ordertype", 0);
				ordertypeStr = Utils.ChkSQL(HTTPRequest.GetString("ordertypeStr"));
				string _otypestr = "0";

				switch (ordertype)
				{
				case 1://采购入库=1
					if (CheckUserPopedoms("X") || CheckUserPopedoms("3-3-4-1-1"))
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
					if (CheckUserPopedoms("X") || CheckUserPopedoms("3-3-4-2-1"))
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
					if (CheckUserPopedoms("X") || CheckUserPopedoms("3-3-4-3-1"))
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
					if (CheckUserPopedoms("X") || CheckUserPopedoms("3-3-4-4-1"))
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
					if (CheckUserPopedoms("X") || CheckUserPopedoms("3-3-4-5-1"))
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
					if (CheckUserPopedoms("X") || CheckUserPopedoms("3-3-4-6-1"))
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
					if (CheckUserPopedoms("X") || CheckUserPopedoms("3-3-4-7-1"))
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
					if (CheckUserPopedoms("X") || CheckUserPopedoms("3-3-4-8-1"))
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
					if (CheckUserPopedoms("X") || CheckUserPopedoms("3-3-4-8-1"))
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
					if (CheckUserPopedoms("X") || CheckUserPopedoms("3-3-4-8-1"))
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
					if (CheckUserPopedoms("X") || CheckUserPopedoms("3-3-4-8-1"))
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
					if (CheckUserPopedoms("X") || CheckUserPopedoms("3-3-4-1-1"))
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
					if (CheckUserPopedoms("X") || CheckUserPopedoms("3-3-4-2-1"))
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
					if (CheckUserPopedoms("X") || CheckUserPopedoms("3-3-4-3-1"))
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
					if (CheckUserPopedoms("X") || CheckUserPopedoms("3-3-4-4-1"))
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
					if (CheckUserPopedoms("X") || CheckUserPopedoms("3-3-4-5-1"))
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
					if (CheckUserPopedoms("X") || CheckUserPopedoms("3-3-4-6-1"))
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
					if (CheckUserPopedoms("X") || CheckUserPopedoms("3-3-4-7-1"))
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
					if (CheckUserPopedoms("X") || CheckUserPopedoms("3-3-4-8-1"))
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
					if (CheckUserPopedoms("X") || CheckUserPopedoms("3-3-4-8-1"))
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
					if (CheckUserPopedoms("X") || CheckUserPopedoms("3-3-4-8-1"))
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
					if (CheckUserPopedoms("X") || CheckUserPopedoms("3-3-4-8-1"))
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

				ProductsName = Utils.ChkSQL(HTTPRequest.GetString("ProductsName"));
				ProductsID = HTTPRequest.GetInt("ProductsID", 0);
				if (ProductsID>0)
				{
					tSQL += " and tbOrderInfo.OrderID in(select pol.OrderID from tbOrderListInfo pol where pol.ProductsID=" + ProductsID + " ) ";
				}

				dDateTimeB = Utils.ChkSQL(HTTPRequest.GetString("dDateTimeB"));
				dDateTimeE = Utils.ChkSQL(HTTPRequest.GetString("dDateTimeE"));

				dDateTimeB = dDateTimeB.Trim() == "" ? DateTime.Now.Year + "-1-1" : dDateTimeB.Trim();

				//步骤
				//oSteps = HTTPRequest.GetInt("oSteps", 2);//新单已审核
				sType = HTTPRequest.GetInt("sType",1);

				oState = HTTPRequest.GetInt("oState", 0);
				//if (oState > -1) 
				{
					tSQL += " and tbOrderInfo.oState=" + oState;
					tSQL += " and tbOrderInfo.oSteps in (2,3)";//新单已审核,发货

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



				if (!IsErr ()) {
					OrderStpes = Orders.GetOrderSteps ();

					dList = Orders.GetOrderInfoList_xp(pagesize, pageindex, tSQL, out pagetotal, "nOrderNum desc,OrderID desc");
					

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
					//"&oSteps=" + oSteps + 
						"&ProductsName=" + ProductsName + 
						"&ProductsID=" + ProductsID + 
						"&ordertypeStr=" + ordertypeStr + 
						"&dDateTimeB=" + dDateTimeB +
						"&dDateTimeE=" + dDateTimeE +
						"&sType=" + sType+
						"&StorageID=" + StorageID+
						"&StorageName=" + StorageName);
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
		///<summary>
		/// 是否完成发货
		///<summary>
		public string GetIsOK(int OrderID){
			string restr = "<span style=\"color:#F00\" >未完成</span>";
			if (tbStorageProductLogInfo.GetStorageProductLogCutLenFromOrderID (OrderID) != 0) {
				return restr;
			} else {
				return "<span >完成</span>";
			}
		}
	}

}

