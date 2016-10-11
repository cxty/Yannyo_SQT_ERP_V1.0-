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

namespace Yannyo.BLL
{
    public class tbStockProductInfo
    {
        #region StockProductInfo
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool ExistsStockProductInfo(int StockProductID)
        {
            return DatabaseProvider.GetInstance().ExistsStockProductInfo(StockProductID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddStockProductInfo(StockProductInfo model)
        {
            return DatabaseProvider.GetInstance().AddStockProductInfo(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateStockProductInfo(StockProductInfo model)
        {
            DatabaseProvider.GetInstance().UpdateStockProductInfo(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteStockProductInfo(int StockProductID)
        {
            DatabaseProvider.GetInstance().DeleteStockProductInfo(StockProductID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static StockProductInfo GetStockProductInfoModel(int StockProductID)
        {
            return DatabaseProvider.GetInstance().GetStockProductInfoModel(StockProductID);
        }

        public static StockProductInfo GetStockProductInfoModelByProductsID(int ProductsID)
        {
            return DatabaseProvider.GetInstance().GetStockProductInfoModelByProductsID(ProductsID);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataSet GetStockProductInfoListByNow(string strWhere)
        {
            return DatabaseProvider.GetInstance().GetStockProductInfoListByNow(strWhere);
        }
        public static DataSet GetStockProductInfoList(string strWhere)
        {
            return DatabaseProvider.GetInstance().GetStockProductInfoList(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public static DataTable GetStockProductInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
        {
            return DatabaseProvider.GetInstance().GetStockProductInfoList(PageSize, PageIndex, strWhere, out  pagetotal, OrderType, showFName);
        }
        /// <summary>
        /// 获得仓库名称
        /// </summary>
        /// <param name="sid"></param>
        /// <returns></returns>
        public static DataTable getStorageNameByClass(int sid)
        {
            return DatabaseProvider.GetInstance().getStorageNameByClass(sid);
        }
        #endregion
        #region warehouseinventory
        public static DataTable getsManagerByStorage()
        {
            return DatabaseProvider.GetInstance().getsManagerByStorage();
        }
        public static bool AddWarehouseList(WarehouseInventoryInfo sInventoryInfo)
        {
            return DatabaseProvider.GetInstance().AddWarehouseList(sInventoryInfo);
        }
        public static bool UpdateWarehouseList(WarehouseInventoryInfo sInventoryInfo)
        {
            return DatabaseProvider.GetInstance().UpdateWarehouseList(sInventoryInfo);
        }
        public static DataTable getInventoryInfoList(int storageID, DateTime sAppendTime)
        {
            return DatabaseProvider.GetInstance().getInventoryInfoList(storageID, sAppendTime);
        }
        public static DataSet getStockInfo()
        {
            return DatabaseProvider.GetInstance().getStockInfo();
        }
        public static WarehouseInventoryInfo GetWarehouseInventoryInfoModel(int StocktakeID)
        {
            return DatabaseProvider.GetInstance().GetWarehouseInventoryInfoModel(StocktakeID);
        }
     
        public static int UpdateStorageInventoryInfo(WarehouseInventoryInfo pp)
        {
            return DatabaseProvider.GetInstance().UpdateStorageInventoryInfo(pp);
        }
        public static bool getWarehouseInfo(int sID, DateTime sAppendTime)
        {
            return DatabaseProvider.GetInstance().getWarehouseInfo(sID, sAppendTime);
        }
        public static DataTable GetWarehouseViewInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
        {
            return DatabaseProvider.GetInstance().GetWarehouseViewInfoList(PageSize, PageIndex, strWhere, out pagetotal, OrderType, showFName);
        }
        public static string getSnameByScode(int sCode)
        {
            return DatabaseProvider.GetInstance().getSnameByScode(sCode);
        }
        public static WarehouseInventoryInfo GetInventoryInfoModel(int StockID)
        {
            return DatabaseProvider.GetInstance().GetInventoryInfoModel(StockID);
        }
        public static DataTable getStorageNameByID(int storageID)
        {
            return DatabaseProvider.GetInstance().getStorageNameByID(storageID);
        }
        public static DataTable getProductsNameByID(int productID)
        {
            return DatabaseProvider.GetInstance().getProductsNameByID(productID);
        }
        #endregion
    }
}
