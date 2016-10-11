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
using Yannyo.SOAP;

namespace Yannyo.BLL
{
    public class tbProductsInfo
    {
        #region  ProductsInfo
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool ExistsProductsInfo(string pName)
        {
            return DatabaseProvider.GetInstance().ExistsProductsInfo(pName);
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool ExistsProductsInfo_pCode(string pCode)
        {
            return DatabaseProvider.GetInstance().ExistsProductsInfo_pCode(pCode);
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool ExistsProductsInfo_pBarcode(string pBarcode)
        {
            return DatabaseProvider.GetInstance().ExistsProductsInfo_pCode(pBarcode);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddProductsInfo(ProductsInfo model)
        {
            return DatabaseProvider.GetInstance().AddProductsInfo(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateProductsInfo(ProductsInfo model)
        {
            DatabaseProvider.GetInstance().UpdateProductsInfo(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteProductsInfo(int ProductsID)
        {
            DatabaseProvider.GetInstance().DeleteProductsInfo(ProductsID);
        }
        /// <summary>
        /// 删除一组数据
        /// </summary>
        public static void DeleteProductsInfo(string ProductsID)
        {
            if (ProductsID.Trim() != "")
            {
                ProductsID = "," + ProductsID + ",";
                ProductsID = Utils.ReSQLSetTxt(ProductsID);
                DatabaseProvider.GetInstance().DeleteProductsInfo(ProductsID);
            }
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static ProductsInfo GetProductsInfoModel(int ProductsID)
        {
            return DatabaseProvider.GetInstance().GetProductsInfoModel(ProductsID);
        }
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public static ProductsInfo GetProductsInfoModelByCode(string Code)
		{
			return DatabaseProvider.GetInstance().GetProductsInfoModelByCode(Code);
		}
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static ProductsInfo GetProductsInfoModelByName(string pName)
        {
            return DatabaseProvider.GetInstance().GetProductsInfoModelByName(pName);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static ProductsInfo GetProductsInfoModelByBarcode(string pBarcode)
        {
            return DatabaseProvider.GetInstance().GetProductsInfoModelByBarcode(pBarcode);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataSet GetProductsInfoList(string strWhere)
        {
            return DatabaseProvider.GetInstance().GetProductsInfoList(strWhere);
        }

        public static DataSet GetProductsInfoListAndQuantity(string strWhere)
        {
            return DatabaseProvider.GetInstance().GetProductsInfoListAndQuantity(strWhere);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataSet GetProductsBrandList(string strWhere)
        {
            return DatabaseProvider.GetInstance().GetProductsBrandList(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public static DataTable GetProductsInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
        {
            return DatabaseProvider.GetInstance().GetProductsInfoList(PageSize, PageIndex, strWhere, out  pagetotal, OrderType, showFName);
        }
        public static DataTable GetProductsPriceClassPriceList(int ProductsID)
        {
            DataTable dt = new DataTable();
            DataTable dt_B = new DataTable();
            dt = DataClass.GetPriceClassInfoList("").Tables[0];
            if (dt != null)
            {
                dt.Columns.Add("pPrice", typeof(decimal));
                dt.Columns.Add("pIsEdit", typeof(Int32));
                dt_B = tbPriceClassDefaultPriceInfo.GetPriceClassDefaultPriceInfoList(" ProductsID=" + ProductsID).Tables[0];
                foreach (DataRow dr in dt_B.Rows)
                {
                    foreach (DataRow drr in dt.Rows)
                    {
                        if (Convert.ToInt32(dr["PriceClassID"].ToString()) == Convert.ToInt32(drr["PriceClassID"].ToString()))
                        {
                            drr["pPrice"] = Convert.ToDecimal(dr["pPrice"].ToString());
                            drr["pIsEdit"] = Convert.ToInt32(dr["pIsEdit"].ToString());
                        }
                    }
                }
                dt.AcceptChanges();
            }
            return dt;
        }

        /// <summary>
        /// 获取产品列表
        /// </summary>
        public static DataTable getERPProductList(string tSQL)
        {
            return Bdu9ErpDataEngineService.getProductList(tSQL);
        }

        /// <summary>
        /// 获取产品单据列表
        /// </summary>
        public static DataTable getERPProductOrderList(int ProduceID, int OrderType, DateTime bDate, DateTime eDate)
        {
            return Bdu9ErpDataEngineService.getProductOrderList(ProduceID, OrderType, bDate, eDate);
        }

        /// <summary>
        /// 获取订单单据列表
        /// </summary>
        public static DataTable GetOrderList(string OrderStr)
        {
            return Bdu9ErpDataEngineService.GetOrderList(OrderStr);
        }

        /// <summary>
        /// 同步远程产品信息
        /// </summary>
        public static int SynErpProduct()
        {
            int reNo = 0;
            ProductsInfo pi = new ProductsInfo();
            try
            {
                DataTable dt = Bdu9ErpDataEngineService.getProductList("");
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["P_NAME"].ToString().Trim() != "")
                    {
                        if (tbProductsInfo.ExistsProductsInfo(dr["P_NAME"].ToString().Trim()) == false)
                        {
                            pi.pStandard = "";
                            pi.pUnits = dr["p_rule_min"].ToString().Trim();
                            pi.pMaxUnits = dr["p_rule_max"].ToString().Trim();
                            pi.pToBoxNo = Utils.StrToInt(dr["p_rules"].ToString().Trim(), 0);
                            pi.pState = 0;

                            ProductClassInfo pci = DataClass.GetProductClassInfoModel(dr["typename"].ToString().Trim());
                            if (pci != null) {
                                pi.ProductClassID = pci.ProductClassID;
                            }
                            pi.pBrand = dr["typename"].ToString().Trim();
                            pi.pPrice = decimal.Parse(Utils.StrToFloat(dr["a_price"].ToString().Trim(), 0).ToString());

                            pi.pCode = Utils.GetRanDomCode();
                            pi.pBarcode = dr["p_code"].ToString().Trim();
                            pi.pName = dr["p_name"].ToString().Trim();
                            pi.pAppendTime = DateTime.Now;
                            tbProductsInfo.AddProductsInfo(pi);
                            reNo++;
                        }
                    }
                }
            }
            finally
            {
                pi = null;
            }
            return reNo;
        }

		/// <summary>
		/// Checks the products by order.
		/// </summary>
		/// <returns><c>true</c>, if products by order was checked, <c>false</c> otherwise.</returns>
		/// <param name="ProductsID">Products I.</param>
		public static bool CheckProductsByOrder(int ProductsID){
			return DatabaseProvider.GetInstance().CheckProductsByOrder(ProductsID);
		}
        #endregion
        #region ProductsStorage
        public static int ExistsProductsStorage(int StorageID, int ProductsID)
        {
            return DatabaseProvider.GetInstance().ExistsProductsStorage(StorageID, ProductsID);
        }

        public static int ExistsProductsStorage(int StorageID, int ProductsID, DateTime dT)
        {
            return DatabaseProvider.GetInstance().ExistsProductsStorage(StorageID, ProductsID, dT);
        }
        public static int AddProductsStorage(ProductsStorageInfo model)
        {
            return DatabaseProvider.GetInstance().AddProductsStorage(model);
        }
        public static void UpdateProductsStorage(ProductsStorageInfo model)
        {
            DatabaseProvider.GetInstance().UpdateProductsStorage(model);
        }
        public static void DeleteProductsStorage(int ProductsStorageID)
        {
            DatabaseProvider.GetInstance().DeleteProductsStorage(ProductsStorageID);
        }
        public static ProductsStorageInfo GetProductsStorageModel(int ProductsStorageID)
        {
            return DatabaseProvider.GetInstance().GetProductsStorageModel(ProductsStorageID);
        }
        /// <summary>
        /// 更是商品库存信息
        /// </summary>
        /// <param name="OrderID"></param>
        /// <returns></returns>
        public static bool UpdateProductsStorageByOrderID(int OrderID)
        { 
            return DatabaseProvider.GetInstance().UpdateProductsStorageByOrderID(OrderID);
        }
        /// <summary>
        /// 设置产品期初库存
        /// </summary>
        /// <param name="StorageID"></param>
        /// <param name="ProductsID"></param>
        /// <param name="pQuantity"></param>
        /// <returns></returns>
        public static bool UpdateProductsBeginningStorage(int StorageID, int ProductsID, decimal pQuantity)
        {
            return DatabaseProvider.GetInstance().UpdateProductsBeginningStorage(StorageID, ProductsID, pQuantity);
        }
        /// <summary>
        /// 取产品指定仓库期初库存
        /// </summary>
        /// <param name="StorageID"></param>
        /// <param name="ProductsID"></param>
        /// <returns></returns>
        public static decimal GetProductsBeginningStorage(int StorageID, int ProductsID)
        {
            return DatabaseProvider.GetInstance().GetProductsBeginningStorage(StorageID, ProductsID);
        }
        /// <summary>
        /// 取当前指定仓库/产品,库存
        /// </summary>
        /// <param name="StorageID"></param>
        /// <param name="ProductsID"></param>
        /// <returns></returns>
        public static ProductsStorageInfo GetProductsStorageModel(int StorageID, int ProductsID)
        {
            return DatabaseProvider.GetInstance().GetProductsStorageModel(StorageID, ProductsID);
        }
        /// <summary>
        /// 取当指定时间指定仓库/产品,库存
        /// </summary>
        /// <param name="StorageID"></param>
        /// <param name="ProductsID"></param>
        /// <param name="dT"></param>
        /// <returns></returns>
        public static ProductsStorageInfo GetProductsStorageModel(int StorageID, int ProductsID, DateTime dT)
        {
            return DatabaseProvider.GetInstance().GetProductsStorageModel(StorageID, ProductsID, dT);
        }
        /// <summary>
        /// 添加当前指定仓库/商品库存
        /// </summary>
        /// <param name="StorageID"></param>
        /// <param name="ProductsID"></param>
        /// <returns></returns>
        public static int AddProductsStorage(int StorageID, int ProductsID)
        {
            return DatabaseProvider.GetInstance().AddProductsStorage(StorageID, ProductsID);
        }
        /// <summary>
        /// 添加指定时间指定仓库/商品库存
        /// </summary>
        /// <param name="StorageID"></param>
        /// <param name="ProductsID"></param>
        /// <param name="dT"></param>
        /// <returns></returns>
        public static int AddProductsStorage(int StorageID, int ProductsID, DateTime dT)
        {
            return DatabaseProvider.GetInstance().AddProductsStorage(StorageID, ProductsID, dT);
        }
        public static DataSet GetProductsStorageList(string strWhere)
        {
            return DatabaseProvider.GetInstance().GetProductsStorageList(strWhere);
        }
        public static DataSet GetProductsStorageInfoList(int Top, string strWhere, string filedOrder)
        {
            return DatabaseProvider.GetInstance().GetProductsStorageInfoList(Top, strWhere, filedOrder);
        }
        public static DataTable GetProductsStorageList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
        {
            return DatabaseProvider.GetInstance().GetProductsStorageList(PageSize, PageIndex, strWhere, out  pagetotal, OrderType, showFName);
        }
        /// <summary>
        /// 产品库存列表
        /// </summary>
        /// <param name="StorageID">仓库编号</param>
        /// <param name="sDateTime">时间点</param>
        /// <returns></returns>
        public static DataTable GetProductsStorageInfoByStorageID(int sClassID, int StorageID, DateTime sDateTime, int ProductsID)
        {
            return DatabaseProvider.GetInstance().GetProductsStorageInfoByStorageID(sClassID, StorageID, sDateTime, ProductsID);
        }
        public static DataTable GetProductsStorageInfoByStorageID_XP(int StorageID, DateTime sDateTime, int ProductsID)
        {
            return DatabaseProvider.GetInstance().GetProductsStorageInfoByStorageID_XP(StorageID, sDateTime, ProductsID);
        }
        #endregion
        #region ProductsStorageLog
        public static int AddProductsStorageLog(ProductsStorageLogInfo model)
        {
            return DatabaseProvider.GetInstance().AddProductsStorageLog(model);
        }
        public static void UpdateProductsStorageLog(ProductsStorageLogInfo model)
        {
            DatabaseProvider.GetInstance().UpdateProductsStorageLog(model);
        }
        public static void DeleteProductsStorageLog(int ProductsStorageLogID)
        {
            DatabaseProvider.GetInstance().DeleteProductsStorageLog(ProductsStorageLogID);
        }
        public static ProductsStorageLogInfo GetProductsStorageLogModel(int ProductsStorageLogID)
        {
            return DatabaseProvider.GetInstance().GetProductsStorageLogModel(ProductsStorageLogID);
        }
        public static DataSet GetProductsStorageLogList(string strWhere)
        {
            return DatabaseProvider.GetInstance().GetProductsStorageLogList(strWhere);
        }
        public static DataSet GetProductsStorageLogList(int Top, string strWhere, string filedOrder)
        {
            return DatabaseProvider.GetInstance().GetProductsStorageLogList(Top, strWhere, filedOrder);
        }
        public static DataTable GetProductsStorageLogList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
        {
            return DatabaseProvider.GetInstance().GetProductsStorageLogList(PageSize, PageIndex, strWhere, out  pagetotal, OrderType, showFName);
        }
        #endregion

        #region productsGraphManage
        public static DataTable getProductsSaleDetails(int GraphType, int SalesType, DateTime dt, string regionID, int sType)
        {
            return DatabaseProvider.GetInstance().getProductsSaleDetails(GraphType, SalesType, dt, regionID, sType);
        }
        #endregion
    }
}
