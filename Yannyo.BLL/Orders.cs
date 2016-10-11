using System;
using System.Data;
using System.Data.Common;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

using Yannyo.Common;
using Yannyo.Data;
using Yannyo.Config;
using Yannyo.Entity;
using System.Collections;
using System.Xml;
using Yannyo.SOAP;

namespace Yannyo.BLL
{
    public class Orders
    {
        #region ProductsStorage
        public static int ExistsProductsStorage(int StorageID, int ProductsID) { return DatabaseProvider.GetInstance().ExistsProductsStorage(StorageID, ProductsID); }
        public static int ExistsProductsStorage(int StorageID, int ProductsID, DateTime dT) { return DatabaseProvider.GetInstance().ExistsProductsStorage(StorageID, ProductsID, dT); }
        public static int AddProductsStorage(ProductsStorageInfo model) { return DatabaseProvider.GetInstance().AddProductsStorage(model); }
        public static void UpdateProductsStorage(ProductsStorageInfo model) { DatabaseProvider.GetInstance().UpdateProductsStorage(model); }
        public static void DeleteProductsStorage(int ProductsStorageID) { DatabaseProvider.GetInstance().DeleteProductsStorage(ProductsStorageID); }
        public static ProductsStorageInfo GetProductsStorageModel(int ProductsStorageID) { return DatabaseProvider.GetInstance().GetProductsStorageModel(ProductsStorageID); }
        /// <summary>
        /// 取当前指定仓库/产品,库存
        /// </summary>
        /// <param name="StorageID"></param>
        /// <param name="ProductsID"></param>
        /// <returns></returns>
        public static ProductsStorageInfo GetProductsStorageModel(int StorageID, int ProductsID) { return DatabaseProvider.GetInstance().GetProductsStorageModel(StorageID, ProductsID); }
        /// <summary>
        /// 取当指定时间指定仓库/产品,库存
        /// </summary>
        /// <param name="StorageID"></param>
        /// <param name="ProductsID"></param>
        /// <param name="dT"></param>
        /// <returns></returns>
        public static ProductsStorageInfo GetProductsStorageModel(int StorageID, int ProductsID, DateTime dT) { return DatabaseProvider.GetInstance().GetProductsStorageModel(StorageID, ProductsID, dT); }
        /// <summary>
        /// 添加当前指定仓库/商品库存
        /// </summary>
        /// <param name="StorageID"></param>
        /// <param name="ProductsID"></param>
        /// <returns></returns>
        public static int AddProductsStorage(int StorageID, int ProductsID) { return DatabaseProvider.GetInstance().AddProductsStorage(StorageID, ProductsID); }
        /// <summary>
        /// 添加指定时间指定仓库/商品库存
        /// </summary>
        /// <param name="StorageID"></param>
        /// <param name="ProductsID"></param>
        /// <param name="dT"></param>
        /// <returns></returns>
        public static int AddProductsStorage(int StorageID, int ProductsID, DateTime dT) { return DatabaseProvider.GetInstance().AddProductsStorage(StorageID, ProductsID, dT); }
        public static DataSet GetProductsStorageList(string strWhere) { return DatabaseProvider.GetInstance().GetProductsStorageList(strWhere); }
        public static DataSet GetProductsStorageInfoList(int Top, string strWhere, string filedOrder) { return DatabaseProvider.GetInstance().GetProductsStorageInfoList(Top, strWhere, filedOrder); }
        public static DataTable GetProductsStorageList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName) { return DatabaseProvider.GetInstance().GetProductsStorageList(PageSize, PageIndex, strWhere, out  pagetotal, OrderType, showFName); }
        #endregion

        #region ProductsStorageLog
        public static int AddProductsStorageLog(ProductsStorageLogInfo model) { return DatabaseProvider.GetInstance().AddProductsStorageLog(model); }
        public static void UpdateProductsStorageLog(ProductsStorageLogInfo model) { DatabaseProvider.GetInstance().UpdateProductsStorageLog(model); }
        public static void DeleteProductsStorageLog(int ProductsStorageLogID) { DatabaseProvider.GetInstance().DeleteProductsStorageLog(ProductsStorageLogID); }
        public static ProductsStorageLogInfo GetProductsStorageLogModel(int ProductsStorageLogID) { return DatabaseProvider.GetInstance().GetProductsStorageLogModel(ProductsStorageLogID); }
        public static DataSet GetProductsStorageLogList(string strWhere) { return DatabaseProvider.GetInstance().GetProductsStorageLogList(strWhere); }
        public static DataSet GetProductsStorageLogList(int Top, string strWhere, string filedOrder) { return DatabaseProvider.GetInstance().GetProductsStorageLogList(Top, strWhere, filedOrder); }
        public static DataTable GetProductsStorageLogList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName) { return DatabaseProvider.GetInstance().GetProductsStorageLogList(PageSize, PageIndex, strWhere, out  pagetotal, OrderType, showFName); }
        #endregion

        #region Order
        public static bool ExistsOrderInfo(string oOrderNum) { return DatabaseProvider.GetInstance().ExistsOrderInfo(oOrderNum); }
        public static int AddOrderInfo(OrderInfo model) { return DatabaseProvider.GetInstance().AddOrderInfo(model); }
        /// <summary>
        /// 审核单据
        /// </summary>
        /// <param name="OrderID"></param>
        public static void VerifyOrder(int OrderID)
        {
            DatabaseProvider.GetInstance().VerifyOrder(OrderID);
        }
        public static int AddOrderInfoAndList(OrderInfo model)
        {
            if (model.OrderListDataJson != null)
            {
                return DatabaseProvider.GetInstance().AddOrderInfoAndList(model);
            }
            else
            {
                return DatabaseProvider.GetInstance().AddOrderInfo(model);
            }
        }
        public static bool UpdateOrderInfoAndList(OrderInfo model)
        {
            if (model.OrderListDataJson != null)
            {
                return DatabaseProvider.GetInstance().UpdateOrderInfoAndList(model);
            }
            else
            {
                DatabaseProvider.GetInstance().UpdateOrderInfo(model);
                return true;
            }
        }

        public static void UpdateOrderInfo(OrderInfo model) { DatabaseProvider.GetInstance().UpdateOrderInfo(model); }
        public static void DeleteOrderInfo(int OrderID) { DatabaseProvider.GetInstance().DeleteOrderInfo(OrderID); }
        public static OrderInfo GetOrderInfoModel(int OrderID) { return DatabaseProvider.GetInstance().GetOrderInfoModel(OrderID); }
        public static DataSet GetOrderInfoList(string strWhere) { return DatabaseProvider.GetInstance().GetOrderInfoList(strWhere); }
        public static DataSet GetOrderInfoList(int Top, string strWhere, string filedOrder) { return DatabaseProvider.GetInstance().GetOrderInfoList(Top, strWhere, filedOrder); }
        public static DataTable GetOrderInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName) { return DatabaseProvider.GetInstance().GetOrderInfoList(PageSize, PageIndex, strWhere, out  pagetotal, OrderType, showFName); }
        public static DataTable GetOrderInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName, string filedOrder, string OrderfldName) { return DatabaseProvider.GetInstance().GetOrderInfoList(PageSize, PageIndex, strWhere, out  pagetotal, OrderType, showFName, filedOrder, OrderfldName); }
        public static DataTable GetOrderInfoList_xp(int PageSize, int PageIndex, string strWhere, out int pagetotal, string OrderfldName) {return DatabaseProvider.GetInstance().GetOrderInfoList_xp( PageSize,  PageIndex,  strWhere, out  pagetotal,  OrderfldName); }
        /// <summary>
        /// 返回最新未使用单据号
        /// </summary>
        /// <returns></returns>
        public static string GetNewOrderNum()
        {
            GeneralConfigInfo ManageConfig = GeneralConfigs.GetConfig();
            ManageConfig.OrderID = (Convert.ToInt64(Config.GeneralConfigs.GetConfig().OrderID.Trim()) + 1).ToString();

            GeneralConfigs.Serialiaze(ManageConfig, Utils.GetMapPath(BaseConfigs.GetSysPath + "config/general.config"));
            BaseConfigs.ResetConfig();

            return ManageConfig.OrderID;
        }
		/// <summary>
		/// 取同类型的最新的单据
		/// </summary>
		/// <returns>The next order.</returns>
		/// <param name="oType">单据类型</param>
		/// <param name="oState">查询状态，0正常，1屏蔽</param>
		/// <param name="oSteps">查询进度，新开单=1
		/// 新单已审核=2
		/// 已发货=3
		/// 已收货=4
		/// 收货已确认(验收单已回)=5
		/// 未对账=6(正在对账中)
		/// 已对账=7
		/// 完成收付款=8
		/// 已结账=9
		/// </param>
		public static OrderInfo GetNextOrder(int oType,int oState,int oSteps)
		{
			return DatabaseProvider.GetInstance().GetNextOrder( oType, oState, oSteps);
		}
        /// <summary>
        /// 返回当前各种单据基础统计信息
        /// </summary>
        /// <returns></returns>
        public static DataSet GetOrderStateList()
        {
            return DatabaseProvider.GetInstance().GetOrderStateList();
        }
        /// <summary>
        /// 验证指定单据是否为全额收货
        /// </summary>
        /// <param name="OrderID"></param>
        /// <returns></returns>
        public static bool CheckOrderIsFull(int OrderID)
        {
            return DatabaseProvider.GetInstance().CheckOrderIsFull(OrderID);
        }
        /// <summary>
        /// 返回非全额收货单据体
        /// </summary>
        /// <param name="OrderID"></param>
        /// <returns></returns>
        public static DataTable GetOrderNOFullList(int OrderID)
        {
            return DatabaseProvider.GetInstance().GetOrderNOFullList(OrderID);
        }
        /// <summary>
        /// 返回产品库存报警列表,库存数 <=10出库, >=20天出库
        /// </summary>
        /// <returns></returns>
        public static DataTable GetProductAlarm()
        {
            return DatabaseProvider.GetInstance().GetProductAlarm();
        }
        /// <summary>
        /// 验证指定非全额单据是否已处理差额
        /// </summary>
        /// <param name="OrderID"></param>
        /// <returns></returns>
        public static bool CheckOrderNOFullToDo(int OrderID)
        {
            return DatabaseProvider.GetInstance().CheckOrderNOFullToDo(OrderID);
        }
        /// <summary>
        /// 更新待处理单据状态
        /// </summary>
        /// <param name="OrderID"></param>
        /// <param name="NextOrderID"></param>
        public static void UpdateOrderNOFullNextOrder(int OrderID, int NextOrderID)
        { 
            DatabaseProvider.GetInstance().UpdateOrderNOFullNextOrder( OrderID,  NextOrderID);
        }
        /// <summary>
        /// 进销存报表
        /// </summary>
        /// <param name="ProductsID"></param>
        /// <param name="StorageID"></param>
        /// <param name="sDate">选择的时间点</param>
        /// <param name="ReType">返回类型,月表=1,年表=2</param>
        /// <param name="DataType">返回表类型,1存档记录,2实算记录</param>
        /// <param name="sDataType">统计数据方式,0=取上期结存成本,1=取本期发生成本</param>
        /// <returns></returns>
        public static DataTable GetInvoicingReport(int ProductsID, int StorageID, DateTime sDate, int ReType, out int DataType, int sDataType)
        {
            return DatabaseProvider.GetInstance().GetInvoicingReport(ProductsID, StorageID, sDate, ReType, out DataType, sDataType);
        }
        public static DataTable GetInvoicingReport(int ProductsID, int StorageID, DateTime sDate, int ReType, out int DataType, int sDataType,DateTime eDate)
        {
            return DatabaseProvider.GetInstance().GetInvoicingReport(ProductsID, StorageID, sDate, ReType, out DataType, sDataType, eDate);
        }
        /// <summary>
        /// 返回产品进销存缓存数据
        /// </summary>
        /// <param name="StorageID"></param>
        /// <param name="ProductsID"></param>
        /// <param name="sDate"></param>
        /// <param name="rType"></param>
        /// <returns></returns>
        public static DataTable GetReportInvoicingDataInfoList(int StorageID, int ProductsID, DateTime sDate, int rType)
        { 
            return DatabaseProvider.GetInstance().GetReportInvoicingDataInfoList( StorageID,  ProductsID,  sDate,  rType);
        }
        /// <summary>
        /// 重置进销存数据,已加一天
        /// </summary>
        /// <param name="sDate"></param>
        /// <returns></returns>
        public static bool ReSetInvoicingData(DateTime sDate)
        { 
            return DatabaseProvider.GetInstance().ReSetInvoicingData(sDate);
        }
        /// <summary>
        /// 更新进销存数据结存数据
        /// </summary>
        /// <param name="eQuantity"></param>
        /// <param name="eMoney"></param>
        /// <param name="ReportInvoicingID"></param>
        /// <returns></returns>
        public static bool UpdateReportInvoicingDataInfoByEndData(decimal eQuantity, decimal eMoney, int ReportInvoicingID)
        { 
            return DatabaseProvider.GetInstance().UpdateReportInvoicingDataInfoByEndData( eQuantity,  eMoney,  ReportInvoicingID);
        }
        /// <summary>
        /// 更新进销存数据结存数据
        /// </summary>
        /// <param name="eQuantity"></param>
        /// <param name="eMoney"></param>
        /// <param name="ReportInvoicingID"></param>
        /// <returns></returns>
        public static bool UpdateReportInvoicingDataInfoByEndData(decimal eQuantity, decimal eMoney, decimal bQuantity, decimal bMoney, decimal InQuantity, decimal InMoney, decimal OutQuantity, decimal OutMoney, int ReportInvoicingID)
        { 
            return DatabaseProvider.GetInstance().UpdateReportInvoicingDataInfoByEndData( eQuantity,  eMoney,  bQuantity,  bMoney,  InQuantity,  InMoney,  OutQuantity,  OutMoney,  ReportInvoicingID);
        }
        /// <summary>
        /// 取单据总金额
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static decimal GetOrderSumMoney(string strWhere)
        { 
            return DatabaseProvider.GetInstance().GetOrderSumMoney( strWhere);
        }
        /// <summary>
        /// 返回单据合计金额
        /// </summary>
        /// <param name="OrderID"></param>
        /// <returns></returns>
        public static decimal GetOrderSumMoney(int OrderID)
        { 
             return DatabaseProvider.GetInstance().GetOrderSumMoney(OrderID);
        }
        /// <summary>
        /// 取单据的操作员,人员,打印时间,合计数 等信息
        /// </summary>
        /// <param name="OrderID"></param>
        /// <returns></returns>
        public static string[] GetOrderOtherInfo(int OrderID)
        { 
            return DatabaseProvider.GetInstance().GetOrderOtherInfo(OrderID);
        }
		/// <summary>
		/// OrderList查询条件下的所有子单据列表
		/// </summary>
		/// <returns>The order list by order where.</returns>
		/// <param name="strWhere">String where.</param>
		public static DataSet GetOrderListByOrderWhere (string strWhere,bool getWorkType0)
		{
			return DatabaseProvider.GetInstance().GetOrderListByOrderWhere (strWhere, getWorkType0);
		}
		/// <summary>
		/// 验证单据库存数是否有超出
		/// </summary>
		/// <returns><c>true</c>, if order products stock was checked, <c>false</c> otherwise.</returns>
		/// <param name="OrderID">Order I.</param>
		public static bool CheckOrderProductsStock(int OrderID)
		{
			return DatabaseProvider.GetInstance ().CheckOrderProductsStock (OrderID);
		}
        #endregion

        #region OrderList
        public static bool ExistsOrderListInfo(int OrderID, int StorageID, int ProductsID) { return DatabaseProvider.GetInstance().ExistsOrderListInfo(OrderID, StorageID, ProductsID); }
        public static int AddOrderListInfo(OrderListInfo model) { return DatabaseProvider.GetInstance().AddOrderListInfo(model); }
        public static void UpdateOrderListInfo(OrderListInfo model) { DatabaseProvider.GetInstance().UpdateOrderListInfo(model); }
        public static void DeleteOrderListInfo(int OrderListID) { DatabaseProvider.GetInstance().DeleteOrderListInfo(OrderListID); }
        public static OrderListInfo GetOrderListInfoModel(int OrderListID) { return DatabaseProvider.GetInstance().GetOrderListInfoModel(OrderListID); }
        public static DataSet GetOrderListInfoList(string strWhere) { return DatabaseProvider.GetInstance().GetOrderListInfoList(strWhere); }
        public static DataSet GetOrderListInfoList(int Top, string strWhere, string filedOrder) { return DatabaseProvider.GetInstance().GetOrderListInfoList(Top, strWhere, filedOrder); }
        public static DataTable GetOrderListInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName) { return DatabaseProvider.GetInstance().GetOrderListInfoList(PageSize, PageIndex, strWhere, out  pagetotal, OrderType, showFName); }
        #endregion

		#region SCM
		public static bool UpdateSCMProductsStockByOrderID(int OrderID){
            GeneralConfigInfo _config = new GeneralConfigInfo();
            _config = GeneralConfigs.GetConfig();
            if (_config.DBO_ErpSys.Trim()!="" && _config.DBO_CompanyID.Trim()!="")
            {
                string ProductsCode, StockCode;
                int Quantity, StorageID, ProductID;
                DataTable dList = new DataTable();
                DateTime bDate = DateTime.Now;
                
                ArrayList ProductsCode_Array = new ArrayList();
                ArrayList StockCode_Array = new ArrayList();
                ArrayList Quantity_Array = new ArrayList();

                try
                {
                    StorageInfo _si = new StorageInfo();
                    ProductsInfo _pi = new ProductsInfo();
                    DataTable _dt_data = new DataTable();


                    dList = GetOrderListInfoList(" OrderID=" + OrderID + " and oWorkType<>0 order by OrderListID asc").Tables[0];
                    foreach (DataRow dr in dList.Rows)
                    {

                        if (Convert.ToInt32(dr["oWorkType"]) == 1)
                        {
                            //AddProductsStorage(Convert.ToInt32(dr["StorageID"]), Convert.ToInt32(dr["ProductsID"]));
                            StorageID = Convert.ToInt32(dr["StorageID"]);
                            ProductID = Convert.ToInt32(dr["ProductsID"]);

                            _si = tbStorageInfo.GetStorageInfoModel(StorageID);
                            _pi = tbProductsInfo.GetProductsInfoModel(ProductID);

                            if (_si != null && _pi != null)
                            {

                                Quantity = 0;
                                ProductsCode = _pi.pCode;
                                StockCode = _si.sCode;

                                _dt_data = tbProductsInfo.GetProductsStorageInfoByStorageID_XP(StorageID, bDate, ProductID);
                                if (_dt_data.Rows.Count > 0)
                                {
                                    Quantity = (Convert.ToInt32(_dt_data.Rows[0]["pStorage"]) + Convert.ToInt32(_dt_data.Rows[0]["pStorageIn"])) - Convert.ToInt32(_dt_data.Rows[0]["pStorageOut"]) + Convert.ToInt32(_dt_data.Rows[0]["Beginning"]);
                                }

                                ProductsCode_Array.Add(ProductsCode);
                                StockCode_Array.Add(StockCode);
                                Quantity_Array.Add(Quantity.ToString());
                            }
                        }
                    }

                    UpdateSCMProductsStock(ProductsCode_Array, StockCode_Array, Quantity_Array);

                    return true;
                }
                finally
                {
                    dList.Clear();
                }
            }
            return true;
		}

        /**
         * 同步数据到SCM系统
         */
        public static bool SyncData2SCM() {
            try
            {
                //DataTable _StorageList = new DataTable();
                //DataTable _ProductsList = new DataTable();
                DataTable _ProductsStock = new DataTable();
                DateTime bDate = new DateTime();
                bDate = DateTime.Now;

                //_StorageList = tbStorageInfo.GetStorageInfoList("").Tables[0];
                //_ProductsList = tbProductsInfo.GetProductsInfoList(" pState=0 ").Tables[0];
                DataTable _dt_data = tbProductsInfo.GetProductsStorageInfoByStorageID_XP(0, bDate, 0);
                string ProductsCode = "";
                string StockCode = "";
                int Quantity = 0;
                for (int i = 0; i < _dt_data.Rows.Count; i++)
                { 
                    ProductsCode = _dt_data.Rows[i]["pCode"].ToString();
                    StockCode = _dt_data.Rows[i]["sCode"].ToString();
                    Quantity = (Convert.ToInt32(_dt_data.Rows[i]["pStorage"]) + Convert.ToInt32(_dt_data.Rows[i]["pStorageIn"])) - Convert.ToInt32(_dt_data.Rows[i]["pStorageOut"]) + Convert.ToInt32(_dt_data.Rows[i]["Beginning"]);
                    UpdateSCMProductsStock(ProductsCode, StockCode, Quantity);
                }
                    return true;
            }
            catch
            {
                return true;
            }
        }

		public static bool UpdateSCMProductsStock(string ProductsCode,string StockCode,int Quantity){
			GeneralConfigInfo _config = new GeneralConfigInfo ();
			_config = GeneralConfigs.GetConfig ();

			DBOwner dbo = new DBOwner(_config.DBO_API, _config.DBO_AppID, _config.DBO_AppKey,"","json","");
			try{
				dbo.DBOwnerUpdateProductsStock (_config.DBO_ErpSys, _config.DBO_CompanyID, ProductsCode, StockCode, Quantity,_config.DBO_AppID);
				return true;
			}catch{
				return false;
			}
		}
        public static bool UpdateSCMProductsStock(ArrayList ProductsCodeArray, ArrayList StockCodeArray, ArrayList QuantityArray)
        {
            GeneralConfigInfo _config = new GeneralConfigInfo();
            _config = GeneralConfigs.GetConfig();

            DBOwner dbo = new DBOwner(_config.DBO_API, _config.DBO_AppID, _config.DBO_AppKey, "", "json", "");
            try
            {
                string ProductsCode = string.Join(",", ProductsCodeArray.ToArray(typeof(string)) as string[]);
                string StockCode = string.Join(",", StockCodeArray.ToArray(typeof(string)) as string[]);
                string Quantity = string.Join(",", QuantityArray.ToArray(typeof(string)) as string[]);

                dbo.DBOwnerUpdateProductsStockByStr(_config.DBO_ErpSys, _config.DBO_CompanyID, ProductsCode, StockCode, Quantity, _config.DBO_AppID);
                return true;
            }
            catch
            {
                return false;
            }
        }
		#endregion

        #region OrderField
        public static bool ExistsOrderFieldInfo(int OrderType, string fName) { return DatabaseProvider.GetInstance().ExistsOrderFieldInfo(OrderType, fName); }
        public static int AddOrderFieldInfo(OrderFieldInfo model) { return DatabaseProvider.GetInstance().AddOrderFieldInfo(model); }
        public static void UpdateOrderFieldInfo(OrderFieldInfo model) { DatabaseProvider.GetInstance().UpdateOrderFieldInfo(model); }
        public static void DeleteOrderFieldInfo(int OrderFieldID) { DatabaseProvider.GetInstance().DeleteOrderFieldInfo(OrderFieldID); }
        public static void DeleteOrderFieldInfo(string OrderFieldID)
        {
            if (OrderFieldID.Trim() != "")
            {
                OrderFieldID = "," + OrderFieldID + ",";
                OrderFieldID = Utils.ReSQLSetTxt(OrderFieldID);
                DatabaseProvider.GetInstance().DeleteOrderFieldInfo(OrderFieldID);
            }
        }
        public static OrderFieldInfo GetOrderFieldInfoModel(int OrderFieldID) { return DatabaseProvider.GetInstance().GetOrderFieldInfoModel(OrderFieldID); }
        public static DataSet GetOrderFieldInfoList(string strWhere) { return DatabaseProvider.GetInstance().GetOrderFieldInfoList(strWhere); }
        public static DataSet GetOrderFieldInfoList(int Top, string strWhere, string filedOrder) { return DatabaseProvider.GetInstance().GetOrderFieldInfoList(Top, strWhere, filedOrder); }
        public static DataTable GetOrderFieldInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName) { return DatabaseProvider.GetInstance().GetOrderFieldInfoList(PageSize, PageIndex, strWhere, out  pagetotal, OrderType, showFName); }
        #endregion

        #region OrderFieldValue
        public static bool ExistsOrderFieldValueInfo(int OrderFieldID, int OrderListID) { return DatabaseProvider.GetInstance().ExistsOrderFieldValueInfo(OrderFieldID, OrderListID); }
        public static int AddOrderFieldValueInfo(OrderFieldValueInfo model) { return DatabaseProvider.GetInstance().AddOrderFieldValueInfo(model); }
        public static void UpdateOrderFieldValueInfo(OrderFieldValueInfo model) { DatabaseProvider.GetInstance().UpdateOrderFieldValueInfo(model); }
        public static void DeleteOrderFieldValueInfo(int OrderFieldValueID) { DatabaseProvider.GetInstance().DeleteOrderFieldValueInfo(OrderFieldValueID); }
        public static OrderFieldValueInfo GetOrderFieldValueInfoModel(int OrderFieldValueID) { return DatabaseProvider.GetInstance().GetOrderFieldValueInfoModel(OrderFieldValueID); }
        public static DataSet GetOrderFieldValueInfoList(string strWhere) { return DatabaseProvider.GetInstance().GetOrderFieldValueInfoList(strWhere); }
        public static DataSet GetOrderFieldValueInfoList(int Top, string strWhere, string filedOrder) { return DatabaseProvider.GetInstance().GetOrderFieldValueInfoList(Top, strWhere, filedOrder); }
        public static DataTable GetOrderFieldValueInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName) { return DatabaseProvider.GetInstance().GetOrderFieldValueInfoList(PageSize, PageIndex, strWhere, out  pagetotal, OrderType, showFName); }
        #endregion

        #region OrderWorkingLogInfo
        public static int AddOrderWorkingLogInfo(OrderWorkingLogInfo model) { return DatabaseProvider.GetInstance().AddOrderWorkingLogInfo(model); }
        public static void UpdateOrderWorkingLogInfo(OrderWorkingLogInfo model) { DatabaseProvider.GetInstance().UpdateOrderWorkingLogInfo(model); }
        public static void DeleteOrderWorkingLogInfo(int OrderWorkingLogID) { DatabaseProvider.GetInstance().DeleteOrderWorkingLogInfo(OrderWorkingLogID); }
        public static OrderWorkingLogInfo GetOrderWorkingLogInfoModel(int OrderWorkingLogID) { return DatabaseProvider.GetInstance().GetOrderWorkingLogInfoModel(OrderWorkingLogID); }
         /// <summary>
        /// 指定单据编号,工作类型,获得工作记录
        /// </summary>
        /// <param name="OrderID"></param>
        /// <param name="WorkType"></param>
        /// <returns></returns>
        public static OrderWorkingLogInfo GetOrderWorkingLogInfoModelByOrderIDAndWorkType(int OrderID, int WorkType)
        {
            return DatabaseProvider.GetInstance().GetOrderWorkingLogInfoModelByOrderIDAndWorkType( OrderID,  WorkType);
        }
        public static DataSet GetOrderWorkingLogInfoList(string strWhere) { return DatabaseProvider.GetInstance().GetOrderWorkingLogInfoList(strWhere); }
        public static DataSet GetOrderWorkingLogInfoList(int Top, string strWhere, string filedOrder) { return DatabaseProvider.GetInstance().GetOrderWorkingLogInfoList(Top, strWhere, filedOrder); }
        public static DataTable GetOrderWorkingLogInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName) { return DatabaseProvider.GetInstance().GetOrderWorkingLogInfoList(PageSize, PageIndex, strWhere, out  pagetotal, OrderType, showFName); }
        /// <summary>
        /// 取单据指定操作类型的操作信息
        /// </summary>
        /// <param name="OrderID"></param>
        /// <param name="WorkType"></param>
        /// <returns></returns>
        public static OrderWorkingLogInfo GetOrderWorkingUserID(int OrderID, int WorkType)
        { 
            return DatabaseProvider.GetInstance().GetOrderWorkingUserID( OrderID,  WorkType);
        }
        #endregion

        #region OrderNOFullInfo
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool ExistsOrderNOFullInfo(int OrderID, int OrderToID, int ProductsID, int FormStorageID, int ToStorageID, decimal oQuantity, int oState)
        {
            return DatabaseProvider.GetInstance().ExistsOrderNOFullInfo(OrderID, OrderToID, ProductsID, FormStorageID, ToStorageID, oQuantity, oState);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static void AddOrderNOFullInfo(OrderNOFullInfo model)
        {
            DatabaseProvider.GetInstance().AddOrderNOFullInfo(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateOrderNOFullInfo(OrderNOFullInfo model)
        {
            DatabaseProvider.GetInstance().UpdateOrderNOFullInfo(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteOrderNOFullInfo(int OrderID, int OrderToID, int ProductsID, int FormStorageID, int ToStorageID)
        {
            DatabaseProvider.GetInstance().DeleteOrderNOFullInfo(OrderID, OrderToID, ProductsID, FormStorageID, ToStorageID);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static OrderNOFullInfo GetOrderNOFullInfoModel(int OrderID, int OrderToID, int ProductsID, int FormStorageID, int ToStorageID)
        {
            return DatabaseProvider.GetInstance().GetOrderNOFullInfoModel(OrderID, OrderToID, ProductsID, FormStorageID, ToStorageID);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataSet GetOrderNOFullInfoList(string strWhere)
        {
            return DatabaseProvider.GetInstance().GetOrderNOFullInfoList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public static DataSet GetOrderNOFullInfoList(int Top, string strWhere, string filedOrder)
        {
            return DatabaseProvider.GetInstance().GetOrderNOFullInfoList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public static DataTable GetOrderNOFullInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
        {
            return DatabaseProvider.GetInstance().GetOrderNOFullInfoList(PageSize, PageIndex, strWhere, out  pagetotal, OrderType, showFName);
        }
        #endregion


        /// <summary>
        /// 单据类型为DataTable
        /// </summary>
        public static DataTable GetOrder_Type()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("ID", typeof(string));
            dt.Columns.Add("InOut", typeof(string));
            dt.Columns.Add("Other", typeof(string));

            foreach (Order_Type.Rewrite OrderType in Order_Type.GetOrderType().OrderType)
            {
                DataRow dr = dt.NewRow();
                dr["Name"] = OrderType.Name;
                dr["ID"] = OrderType.ID;
                dr["InOut"] = OrderType.InOut;
                dr["Other"] = OrderType.Other;

                dt.Rows.Add(dr);
            }
            dt.AcceptChanges();
            return dt;
        }
        /// <summary>
        /// 单据类型
        /// </summary>
        public class Order_Type
        {
            private static object lockHelper = new object();
            private static volatile Order_Type instance = null;
            string Files = HttpContext.Current.Server.MapPath(BaseConfigs.GetSysPath + "config/ordertype.config");
            private System.Collections.ArrayList _OrderType;
            public System.Collections.ArrayList OrderType
            {
                get
                {
                    return _OrderType;
                }
                set
                {
                    _OrderType = value;
                }
            }
            private Order_Type()
            {
                OrderType = new ArrayList();
                XmlDocument xml = new XmlDocument();
                xml.Load(Files);
                try
                {
                    XmlNode root = xml.SelectSingleNode("//OrderTypes");
                    foreach (XmlNode n in root.ChildNodes)
                    {
                        if (n.NodeType != XmlNodeType.Comment && n.Name.ToLower() == "ordertype")
                        {
                            XmlAttribute _Name = n.Attributes["name"];//类型
                            XmlAttribute _ID = n.Attributes["id"];//系统识别编号
                            XmlAttribute _InOut = n.Attributes["InOut"];//入库,出库标记

                            if (_Name != null && _ID != null)
                            {
                                OrderType.Add(new Rewrite(_Name.Value, _ID.Value, _InOut.Value, n.InnerText));
                            }
                        }
                    }
                }
                finally
                {
                    xml = null;
                }
            }
            public static Order_Type GetOrderType()
            {
                if (instance == null)
                {
                    lock (lockHelper)
                    {
                        if (instance == null)
                        {
                            instance = new Order_Type();
                        }
                    }
                }
                return instance;

            }

            public static void SetInstance(Order_Type anInstance)
            {
                if (anInstance != null)
                    instance = anInstance;
            }

            public static void SetInstance()
            {
                SetInstance(new Order_Type());
            }
            public class Rewrite
            {
                #region 成员变量
                private string _Name;
                public string Name
                {
                    get
                    {
                        return _Name;
                    }
                    set
                    {
                        _Name = value;
                    }
                }
                private string _ID;
                public string ID
                {
                    get
                    {
                        return _ID;
                    }
                    set
                    {
                        _ID = value;
                    }
                }
                private string _InOut;
                public string InOut
                {
                    get
                    {
                        return _InOut;
                    }
                    set
                    {
                        _InOut = value;
                    }
                }
                private string _Other;
                public string Other
                {
                    get
                    {
                        return _Other;
                    }
                    set
                    {
                        _Other = value;
                    }
                }
                #endregion
                #region 构造函数
                public Rewrite(string name, string id, string inout, string other)
                {
                    _Name = name;
                    _ID = id;
                    _InOut = inout;
                    _Other = other;
                }
                #endregion
            }
        }

        /// <summary>
        /// 单据字段类型为DataTable
        /// </summary>
        public static DataTable GetOrderFieldTypes()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("ID", typeof(string));
            dt.Columns.Add("Format", typeof(string));
            dt.Columns.Add("Other", typeof(string));

            foreach (OrderFieldTypes.Rewrite FieldTypes in OrderFieldTypes.GetOrderFieldType().FieldTypes)
            {
                DataRow dr = dt.NewRow();
                dr["Name"] = FieldTypes.Name;
                dr["ID"] = FieldTypes.ID;
                dr["Format"] = FieldTypes.Format;
                dr["Other"] = FieldTypes.Other;

                dt.Rows.Add(dr);
            }
            dt.AcceptChanges();
            return dt;
        }
        /// <summary>
        /// 字段类型
        /// </summary>
        public class OrderFieldTypes
        {
            private static object lockHelper = new object();
            private static volatile OrderFieldTypes instance = null;
            string Files = HttpContext.Current.Server.MapPath(BaseConfigs.GetSysPath + "config/fieldtype.config");
            private System.Collections.ArrayList _FieldTypes;
            public System.Collections.ArrayList FieldTypes
            {
                get
                {
                    return _FieldTypes;
                }
                set
                {
                    _FieldTypes = value;
                }
            }
            private OrderFieldTypes()
            {
                FieldTypes = new ArrayList();
                XmlDocument xml = new XmlDocument();
                xml.Load(Files);
                try
                {
                    XmlNode root = xml.SelectSingleNode("//FieldTypes");
                    foreach (XmlNode n in root.ChildNodes)
                    {
                        if (n.NodeType != XmlNodeType.Comment && n.Name.ToLower() == "fieldtype")
                        {
                            XmlAttribute _Name = n.Attributes["name"];
                            XmlAttribute _ID = n.Attributes["id"];
                            XmlAttribute _format = n.Attributes["format"];

                            if (_Name != null && _ID != null)
                            {
                                FieldTypes.Add(new Rewrite(_Name.Value, _ID.Value, _format.Value, n.InnerText));
                            }
                        }
                    }
                }
                finally
                {
                    xml = null;
                }
            }
            public static OrderFieldTypes GetOrderFieldType()
            {
                if (instance == null)
                {
                    lock (lockHelper)
                    {
                        if (instance == null)
                        {
                            instance = new OrderFieldTypes();
                        }
                    }
                }
                return instance;

            }

            public static void SetInstance(OrderFieldTypes anInstance)
            {
                if (anInstance != null)
                    instance = anInstance;
            }

            public static void SetInstance()
            {
                SetInstance(new OrderFieldTypes());
            }
            public class Rewrite
            {
                #region 成员变量
                private string _Name;
                public string Name
                {
                    get
                    {
                        return _Name;
                    }
                    set
                    {
                        _Name = value;
                    }
                }
                private string _ID;
                public string ID
                {
                    get
                    {
                        return _ID;
                    }
                    set
                    {
                        _ID = value;
                    }
                }
                private string _format;
                public string Format
                {
                    get
                    {
                        return _format;
                    }
                    set
                    {
                        _format = value;
                    }
                }
                private string _Other;
                public string Other
                {
                    get
                    {
                        return _Other;
                    }
                    set
                    {
                        _Other = value;
                    }
                }
                #endregion
                #region 构造函数
                public Rewrite(string name, string id, string format, string other)
                {
                    _Name = name;
                    _ID = id;
                    _format = format;
                    _Other = other;
                }
                #endregion
            }
        }

        /// <summary>
        /// 单据步骤为DataTable
        /// </summary>
        public static DataTable GetOrderSteps()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("ID", typeof(string));
            dt.Columns.Add("Other", typeof(string));

            foreach (OrderSteps.Rewrite _OrderStep in OrderSteps.GetOrderSteps().OrderStep)
            {
                DataRow dr = dt.NewRow();
                dr["Name"] = _OrderStep.Name;
                dr["ID"] = _OrderStep.ID;
                dr["Other"] = _OrderStep.Other;

                dt.Rows.Add(dr);
            }
            dt.AcceptChanges();
            return dt;
        }
        /// <summary>
        /// 单据步骤
        /// </summary>
        public class OrderSteps
        {
            private static object lockHelper = new object();
            private static volatile OrderSteps instance = null;
            string Files = HttpContext.Current.Server.MapPath(BaseConfigs.GetSysPath + "config/ordersteps.config");
            private System.Collections.ArrayList _OrderSteps;
            public System.Collections.ArrayList OrderStep
            {
                get
                {
                    return _OrderSteps;
                }
                set
                {
                    _OrderSteps = value;
                }
            }
            private OrderSteps()
            {
                OrderStep = new ArrayList();
                XmlDocument xml = new XmlDocument();
                xml.Load(Files);
                try
                {
                    XmlNode root = xml.SelectSingleNode("//OrderSteps");
                    foreach (XmlNode n in root.ChildNodes)
                    {
                        if (n.NodeType != XmlNodeType.Comment && n.Name.ToLower() == "orderstep")
                        {
                            XmlAttribute _Name = n.Attributes["name"];//类型
                            XmlAttribute _ID = n.Attributes["id"];//系统识别编号

                            if (_Name != null && _ID != null)
                            {
                                OrderStep.Add(new Rewrite(_Name.Value, _ID.Value, n.InnerText));
                            }
                        }
                    }
                }
                finally
                {
                    xml = null;
                }
            }
            public static OrderSteps GetOrderSteps()
            {
                if (instance == null)
                {
                    lock (lockHelper)
                    {
                        if (instance == null)
                        {
                            instance = new OrderSteps();
                        }
                    }
                }
                return instance;

            }

            public static void SetInstance(OrderSteps anInstance)
            {
                if (anInstance != null)
                    instance = anInstance;
            }

            public static void SetInstance()
            {
                SetInstance(new OrderSteps());
            }
            public class Rewrite
            {
                #region 成员变量
                private string _Name;
                public string Name
                {
                    get
                    {
                        return _Name;
                    }
                    set
                    {
                        _Name = value;
                    }
                }
                private string _ID;
                public string ID
                {
                    get
                    {
                        return _ID;
                    }
                    set
                    {
                        _ID = value;
                    }
                }

                private string _Other;
                public string Other
                {
                    get
                    {
                        return _Other;
                    }
                    set
                    {
                        _Other = value;
                    }
                }
                #endregion
                #region 构造函数
                public Rewrite(string name, string id, string other)
                {
                    _Name = name;
                    _ID = id;
                    _Other = other;
                }
                #endregion
            }
        }
    }
}
