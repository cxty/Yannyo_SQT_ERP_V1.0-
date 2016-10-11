using System;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.IO;

using System.Data;
using System.Text;

using System.Xml.Linq;
using System.Xml;
using System.IO;
using System.Net;

using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;

using Yannyo.Common;
using Yannyo.Config;
using Yannyo.Entity;
using Yannyo.BLL;
using Yannyo.Public;
using Yannyo.Data;

using System.Web.Script.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Yannyo.Web
{
	[WebService(Namespace = "Yannyo.Web.Data")]
	#if NET1
	#else
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	#endif
	public class service: System.Web.Services.WebService
	{
		public service()
		{

		}

		/// <summary>
		/// 验证授权码
		/// </summary>
		/// <returns><c>true</c>, if pass code was checked, <c>false</c> otherwise.</returns>
		/// <param name="passCode">Pass code.</param>
		public bool checkPassCode(string passCode)
		{
			string _passCode = GeneralConfigs.GetConfig ().Server_Key;
			return (passCode.Trim () == _passCode.Trim ());
		}
		/// <summary>
		/// 取指定产品信息
		/// </summary>
		/// <returns>The product info.</returns>
		/// <param name="passCode">Pass code.</param>
		/// <param name="productCode">Product code.</param>
		[WebMethod(Description = "取指定产品信息")]
		public string GetProductInfo(string passCode, string productCode)
		{
			string _re = "";
			if (checkPassCode (passCode)) {
				ProductsInfo _products = new ProductsInfo ();
				try {
					_products = tbProductsInfo.GetProductsInfoModelByCode (productCode);
					if (_products != null) {
						JavaScriptSerializer jsonSerializer = new JavaScriptSerializer ();
						_re = jsonSerializer.Serialize (_products);
						jsonSerializer = null;
					}
				} finally {
					_products = null;
				}
			}
			return _re;
		}

		/// <summary>
		/// 取产品列表
		/// </summary>
		/// <returns>The products list.</returns>
		/// <param name="passCode">Pass code.</param>
		[WebMethod(Description = "取产品列表")]
		public string GetProductsList(string passCode)
		{
			DataTable _dt = new DataTable ();
			DataSet _ds = new DataSet ();

			if (checkPassCode (passCode)) {
				_ds = tbProductsInfo.GetProductsInfoList (" pState=0 ");
				if (_ds.Tables.Count > 0) {

					_dt = _ds.Tables [0];

				}
			}
            _dt.TableName = "ProductsList";

            return Yannyo.Public.PublicLib.ToJson(_dt);
		}

		/// <summary>
		/// 取仓库列表
		/// </summary>
		/// <returns>The stock list.</returns>
        [WebMethod(Description = "取仓库列表")]
		public string GetStorageList(string passCode){
			DataTable _dt = new DataTable ();
			if (checkPassCode (passCode)) {
				DataSet _ds = new DataSet ();
				_ds = tbStorageInfo.GetStorageInfoList (" sState = 0 ");
				if (_ds.Tables.Count > 0) {
					_dt = _ds.Tables [0];
				}
			}
            _dt.TableName = "StockList";
            return Yannyo.Public.PublicLib.ToJson(_dt);
		}

        /// <summary>
        /// 增加商品档案
        /// </summary>
        /// <returns></returns>
        [WebMethod(Description = "增加商品档案")]
        public string AddProductsInfo(string passCode, string pStandard, string pUnits, string pMaxUnits, int pToBoxNo, string pBrand)
        {

            string _re = "";
            if (checkPassCode(passCode))
            {
                ProductsInfo pi = new ProductsInfo();

                pi.pStandard = pStandard;
                pi.pUnits = pUnits;
                pi.pMaxUnits = pMaxUnits;
                pi.pToBoxNo = pToBoxNo;
                pi.pState = 0;
                pi.pBrand = pBrand;
                pi.pPrice = pPrice;
                pi.pSellingPrice = pSellingPrice;
                pi.pDoDayQuantity = pDoDayQuantity;
                pi.ProductClassID = ProductClassID;
                pi.pProducer = pProducer;
                pi.pExpireDay = pExpireDay;
                pi.pAddress = pAddress;

                pi.pCode = Utils.GetRanDomCode();
                pi.pBarcode = pBarcode;
                pi.pName = pName;
                pi.pAppendTime = DateTime.Now;

                int _ProductsID = tbProductsInfo.AddProductsInfo(pi);


            }
            return _re;
        }
		/// <summary>
		/// 取指定商品库存信息
		/// </summary>
		/// <returns>The products stock.</returns>
		/// <param name="passCode">Pass code.</param>
		/// <param name="productsCode">Products code.</param>
        [WebMethod(Description = "取指定商品库存信息")]
        public string GetProductsStock(string passCode,string productsCode)
		{
			string _re = "";
			if (checkPassCode (passCode)) {
				DateTime bDate = new DateTime ();
				bDate = DateTime.Now;



				ProductsInfo pi = new ProductsInfo ();
				pi = tbProductsInfo.GetProductsInfoModelByCode (productsCode);
				if (pi != null) {
					DataTable _dt_Storage = tbStorageInfo.GetStorageInfoList (" sState = 0 ").Tables [0];
					//DataTable _dt_Product = tbProductsInfo.GetProductsInfoList(" pCode = '"+productsCode+"' and pState = 0 ").Tables[0];
					DataTable _dt_data = tbProductsInfo.GetProductsStorageInfoByStorageID_XP (0, bDate, pi.ProductsID);

					_dt_Storage.TableName = "StorageList";
					_dt_data.TableName = "ProductsStorageList";
                    string _dt_Storage_str = Yannyo.Public.PublicLib.ToJson(_dt_Storage);
                    string _dt_data_str = Yannyo.Public.PublicLib.ToJson(_dt_data);

					_re = "{\"StorageList\":"+_dt_Storage_str+",\"ProductsStorageList\":"+_dt_data_str+"}";
				}

			}
			return _re;
			/*
			DataTable _dt = new DataTable ();

			if (checkPassCode (passCode)) {
				ProductsInfo _pi = tbProductsInfo.GetProductsInfoModelByCode (productsCode);
				if (_pi != null) {
					_dt = DataUtils.GetStock_analysis(0, DateTime.Now, _pi.ProductsID);
				}
			}
            _dt.TableName = "ProductsList";
            return ToJson(_dt);
            */
		}

		[WebMethod(Description = "取所有商品库存信息")]
		public string GetProductsStockForAll(string passCode){
			string _re = "";
			if (checkPassCode (passCode)) {
				DateTime bDate = new DateTime ();
				bDate = DateTime.Now;

				DataTable _dt_Storage = tbStorageInfo.GetStorageInfoList (" sState = 0 ").Tables [0];
				//DataTable _dt_Product = tbProductsInfo.GetProductsInfoList(" pCode = '"+productsCode+"' and pState = 0 ").Tables[0];
				DataTable _dt_data = tbProductsInfo.GetProductsStorageInfoByStorageID_XP (0, bDate, 0);

				_dt_Storage.TableName = "StorageList";
				_dt_data.TableName = "ProductsStorageList";
                string _dt_Storage_str = Yannyo.Public.PublicLib.ToJson(_dt_Storage);
                string _dt_data_str = Yannyo.Public.PublicLib.ToJson(_dt_data);

				_re = "{\"StorageList\":"+_dt_Storage_str+",\"ProductsStorageList\":"+_dt_data_str+"}";
			}
			return _re;
		
		}

		/// <summary>
		/// 创建订单
		/// </summary>
		/// <returns>The order.</returns>
		/// <param name="oType">O type.</param>
		/// <param name="StoresSupplierID">Stores supplier I.</param>
		/// <param name="oCustomersName">O customers name.</param>
		/// <param name="oCustomersContact">O customers contact.</param>
		/// <param name="oCustomersTel">O customers tel.</param>
		/// <param name="oCustomersAddress">O customers address.</param>
		/// <param name="oCustomersOrderID">O customers order I.</param>
		/// <param name="oCustomersNameB">O customers name b.</param>
		/// <param name="oOrderDateTime">O order date time.</param>
		/// <param name="oPrepay">O prepay.</param>
		/// <param name="oReMake">O re make.</param>
		/// <param name="_OrderListDataJson">Order list data json.</param>
        [WebMethod(Description = "创建订单")]
        public int AddOrder(string passCode,int oType,int StoresSupplierID,
			string oCustomersName,string oCustomersContact,string oCustomersTel,string oCustomersAddress,string oCustomersOrderID,string oCustomersNameB,
			int oPrepay,string oReMake,string _OrderListDataJson)
		{
			int StaffID = 0;
			int UserID = 0;
			int OrderID = 0;

			if (checkPassCode (passCode)) {
				StaffInfo _sf = new StaffInfo ();
				UserInfo _ui = new UserInfo ();

				GeneralConfigInfo _cf = new GeneralConfigInfo ();
				_cf = GeneralConfigs.GetConfig ();

				if (_cf.Server_Staff.Trim () != "") {
					_sf = tbStaffInfo.GetStaffInfoModelByName (_cf.Server_Staff.Trim ());
					if (_sf != null) {
						StaffID = _sf.StaffID;
					}
				}

				if (_cf.Server_User.Trim () != "") {
					_ui = tbUserInfo.GetUserInfoModelByUserName (_cf.Server_User.Trim ());
					if (_ui != null) {
						UserID = _ui.UserID;
					}
				}

                /*
                 * _OrderListDataJson = {"ProductsCode":"","StorageCode":"","Quantity":0,"Money":0}
                 */


                _OrderListDataJson = "";


				OrderInfo oi = new OrderInfo ();
				oi.oOrderNum = "----------";
				oi.oType = oType;
				oi.StoresID = StoresSupplierID;
				oi.oCustomersName = oCustomersName;
				oi.oCustomersContact = oCustomersContact;
				oi.oCustomersTel = oCustomersTel;
				oi.oCustomersAddress = oCustomersAddress;
				oi.oCustomersOrderID = oCustomersOrderID;
				oi.oCustomersNameB = oCustomersNameB;
				oi.StaffID = StaffID;
				oi.UserID = UserID;
				oi.oAppendTime = DateTime.Now;
				oi.oOrderDateTime = DateTime.Now;
				oi.oState = 0;
				oi.oSteps = 1;
				oi.oPrepay = oPrepay;
				oi.oReMake = oReMake;
				oi.OrderListDataJson = (OrderListDataJson)JavaScriptConvert.DeserializeObject (_OrderListDataJson, typeof(OrderListDataJson));

				OrderID = Orders.AddOrderInfoAndList (oi);

				if (OrderID > 0) {

					OrderWorkingLogInfo owl = new OrderWorkingLogInfo ();

					owl.OrderID = OrderID;
					owl.UserID = 0;
					owl.oType = 0;
					owl.oMsg = "";
					owl.pAppendTime = DateTime.Now;

					Orders.AddOrderWorkingLogInfo (owl);

				}
			}
			return OrderID;
		}

		/// <summary>
		/// 取指定单据头信息
		/// </summary>
		/// <returns>The order info.</returns>
		/// <param name="passCode">Pass code.</param>
		/// <param name="OrderID">Order I.</param>
        [WebMethod(Description = "取指定单据头信息")]
        public OrderInfo GetOrderInfo(string passCode,int OrderID){
			OrderInfo _oi = new OrderInfo ();
			if (checkPassCode (passCode)) {
				_oi = Orders.GetOrderInfoModel (OrderID);
			}
			return _oi;
		}

        /// <summary>
        /// 取业务员列表
        /// </summary>
        /// <param name="passCode"></param>
        /// <returns></returns>
        [WebMethod(Description = "取业务员列表")]
        public string GetSalesmanList(string passCode)
        {
            DataTable _dt = new DataTable();
            if (checkPassCode(passCode))
            {
                DataSet _ds = new DataSet();
                _ds = tbStorageInfo.GetStorageInfoList(" sState = 0 ");
                if (_ds.Tables.Count > 0)
                {
                    _dt = _ds.Tables[0];
                }
            }
            _dt.TableName = "SalesmanList";
            return Yannyo.Public.PublicLib.ToJson(_dt);
        }

        /// <summary>
        /// 取客户列表
        /// </summary>
        /// <param name="passCode"></param>
        /// <returns></returns>
        [WebMethod(Description = "取客户列表")]
        public string GetCustomerList(string passCode)
        {
            DataTable _dt = new DataTable();
            if (checkPassCode(passCode))
            {
                DataSet _ds = new DataSet();
                _ds = tbStoresInfo.GetStoresInfoList(" sState = 0 ");
                if (_ds.Tables.Count > 0)
                {
                    _dt = _ds.Tables[0];
                }
            }
            _dt.TableName = "CustomerList";
            return Yannyo.Public.PublicLib.ToJson(_dt);
        }

        /// <summary>
        /// 取供应商信息
        /// </summary>
        /// <param name="passCode"></param>
        /// <returns></returns>
        [WebMethod(Description = "取供应商列表")]
        public string GetSupplierList(string passCode)
        {
            DataTable _dt = new DataTable();
            if (checkPassCode(passCode))
            {
                DataSet _ds = new DataSet();
                _ds = tbSupplierInfo.GetSupplierInfoList("");
                if (_ds.Tables.Count > 0)
                {
                    _dt = _ds.Tables[0];
                }
            }
            _dt.TableName = "SupplierList";
            return Yannyo.Public.PublicLib.ToJson(_dt);
        }

	}

}