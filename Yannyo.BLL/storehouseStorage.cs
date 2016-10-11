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

namespace Yannyo.BLL
{
    public class storehouseStorage
    {
        #region  storehouseStorageBindInfo
        /// <summary>
        /// 绑定第二步中对数据库操作的方法
        /// </summary>
        /// <returns></returns>
        public static DataTable SnameBindDropdownlist()
        {
            return DatabaseProvider.GetInstance().SnameBindDropdownlist();
        }
        public static String SelectScodeBySname(string name)
        {
            return DatabaseProvider.GetInstance().SelectScodeBySname(name);
        }
        public static int AddStorehouseStorageInfo(StorehouseStoreInfo str)
        {
            return DatabaseProvider.GetInstance().AddStorehouseStorageInfo(str);
        }
        /// <summary>
        /// 导入门店库存数据副本
        /// </summary>
        /// <param name="storehouseStorage"></param>
        /// <returns></returns>
        public static int AddStorehouseStorageInfo_calculate(StorehouseStoreInfo storehouseStorage)
        {
            return DatabaseProvider.GetInstance().AddStorehouseStorageInfo_calculate(storehouseStorage);
        }
        public static int UpdateStorehouseStorageInfo(StorehouseStoreInfo s)
        {
           return  DatabaseProvider.GetInstance().UpdateStorehouseStorageInfo(s);
        }
        /// <summary>
        /// 更新门店库存数据副本
        /// </summary>
        /// <param name="storehouseStorage"></param>
        /// <returns></returns>
        public static int UpdateStorehouseStorageInfo_calculate(StorehouseStoreInfo storehouseStorage)
        {
            return DatabaseProvider.GetInstance().UpdateStorehouseStorageInfo_calculate(storehouseStorage);
        }
        /// <summary>
        /// 实体副本
        /// </summary>
        /// <param name="ProductID"></param>
        /// <returns></returns>
        public static StorehouseStoreInfo GetStorehouseProductsInfoModel_calculate(int ProductID)
        {
            return DatabaseProvider.GetInstance().GetStorehouseProductsInfoModel_calculate(ProductID);
        }
        public static DataTable GetStorehouseInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
        {
            return DatabaseProvider.GetInstance().GetStorehouseInfoList(PageSize, PageIndex, strWhere, out pagetotal, OrderType, showFName);
        }
        public static bool GetDateTimeDataStorehouseInfoList(DateTime strDate, int sCode, string stNum, int pCode)
        {
            return DatabaseProvider.GetInstance().GetDateTimeDataStorehouseInfoList(strDate, sCode, stNum, pCode);
        }
        /// <summary>
        /// 表单提交产品信息验证
        /// </summary>
        /// <param name="strDate"></param>
        /// <param name="sCode"></param>
        /// <param name="stNum"></param>
        /// <returns></returns>
        public static bool GetDateTimeDataStorehouseInfoLists(DateTime strDate, int sCode, string stNum, StorehouseStorageJsonInfo ssji)
        {
            return DatabaseProvider.GetInstance().GetDateTimeDataStorehouseInfoLists(strDate, sCode, stNum, ssji);
        }
        public static bool GetDateTimeDataStorehouse(int StoresID, string StCode, int ProductsID, string ProductsName, string ProductsBarcode, string pNum, DateTime pAppendTime)
        {
            return DatabaseProvider.GetInstance().GetDateTimeDataStorehouse(StoresID, StCode, ProductsID, ProductsName, ProductsBarcode, pNum, pAppendTime);
        }
        public static DataSet GetStorehouseInfoLists(string strWhere)
        {
            return DatabaseProvider.GetInstance().GetStorehouseInfoLists(strWhere);
        }
        public static void DeleteStorhouseStorageInfo(int ProductID)
        {
            DatabaseProvider.GetInstance().DeleteStorhouseStorageInfo(ProductID);
        }
        public static void DeleteStoragesInfo(string ProductID)
        {
            ProductID = "," + ProductID + ",";
            ProductID = Utils.ReSQLSetTxt(ProductID);
            DatabaseProvider.GetInstance().DeleteStoragesInfo(ProductID);
        }
        public static DataTable GetScodeBySname(string sname)
        {
            return DatabaseProvider.GetInstance().GetScodeBySname(sname);
        }
        public static int GetRegionIDByName(string RegionName)
        {
            return DatabaseProvider.GetInstance().GetRegionIDByName(RegionName);
        }
        public static String GetScode(string sname)
        {
            return DatabaseProvider.GetInstance().GetScode(sname);
        }
        public static int getStaffIDByName(string StaffName)
        {
            return DatabaseProvider.GetInstance().getStaffIDByName(StaffName);
        }
        public static int getStorageIDByName(string sName)
        {
            return DatabaseProvider.GetInstance().getStorageIDByName(sName);
        }
        public static DataTable GetStorehouseStorageReport(int regionID, int storageID, int staffID, DateTime bTime, DateTime eTime, int reType, int associated)
        {
            return DatabaseProvider.GetInstance().GetStorehouseStorageReport(regionID, storageID, staffID, bTime, eTime, reType, associated);
        }
        public static String SelectPcodeBySname(string name)
        {
            return DatabaseProvider.GetInstance().SelectPcodeBySname(name);
        }
        public static String GetInQuantity(string ProductsID)
        {
            return DatabaseProvider.GetInstance().GetInQuantity(ProductsID);
        }
        public static String OutQuantity(string ProductsID)
        {
            return DatabaseProvider.GetInstance().OutQuantity(ProductsID);
        }
        public static String SelectPcodeByName(string name)
        {
            return DatabaseProvider.GetInstance().SelectPcodeByName(name);
        }
        public static String SelectpBarcodeByName(string name)
        {
            return DatabaseProvider.GetInstance().SelectpBarcodeByName(name);
        }
        public static int[] StorehouseStorageSyn()
        {
            return DatabaseProvider.GetInstance().StorehouseStorageSyn();
        }
        //public static DataTable GetNOJoinDataStorehouseInfoList(string StoresID)
        //{
        //    return DatabaseProvider.GetInstance().GetNOJoinDataStorehouseInfoList(StoresID);
        //}
        public static bool AddStorehouseStorageData(StorehouseStorageJsonInfo storehouseStorage)
        {
            return DatabaseProvider.GetInstance().AddStorehouseStorageData(storehouseStorage);
        }

        public static String SelectPcodeByPName(string[] name)
        {
            return DatabaseProvider.GetInstance().SelectPcodeByPName(name);
        }
        public static bool GetStorehouseProductPriceInfoList(int StoresID, string StCode, int ProductsID, string ProductsName, string ProductsBarcode, decimal pPrice, DateTime pAppendTime)
        {
            return DatabaseProvider.GetInstance().GetStorehouseProductPriceInfoList(StoresID, StCode, ProductsID, ProductsName, ProductsBarcode, pPrice, pAppendTime);
        }
        public static DataTable GetStorageName(string rName,string StaffName)
        {
            return DatabaseProvider.GetInstance().GetStorageName(rName, StaffName);
        }
        public static DataTable StaffNameByRegionName(string RegionName)
        {
            return DatabaseProvider.GetInstance().StaffNameByRegionName(RegionName);
        }
        public static DataTable RegionName()
        {
            return DatabaseProvider.GetInstance().RegionName();
        }
        public static DataTable getProductsOfRegionDetails(int regionID, int productID, DateTime bDate, DateTime eDate)
        {
            return DatabaseProvider.GetInstance().getProductsOfRegionDetails(regionID, productID, bDate, eDate);
        }
        public static int GetStorageIDBySname(string sName)
        {
            return DatabaseProvider.GetInstance().GetStorageIDBySname(sName);
        }
        /// <summary>
        /// 查询客户库存详情
        /// </summary>
        /// <param name="sId"></param>
        /// <param name="bDate"></param>
        /// <param name="eDate"></param>
        /// <returns></returns>
        public static DataTable SelectStorageData(int sId, DateTime bDate, DateTime eDate)
        {
            return DatabaseProvider.GetInstance().SelectStorageData(sId, bDate, eDate);
        }
        #endregion

        #region storehousePrice
        public static DataTable GetStNumByStName(string stName)
        {
            return DatabaseProvider.GetInstance().GetStNumByStName(stName);
        }
        public static int AddStorehouseStorageProductsPriceInfo(storehouseproductsprice storehouseStorage)
        {
            return DatabaseProvider.GetInstance().AddStorehouseStorageProductsPriceInfo(storehouseStorage);
        }
        public static DataTable GetStorehousePriceInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
        {
            return DatabaseProvider.GetInstance().GetStorehousePriceInfoList(PageSize, PageIndex, strWhere, out pagetotal, OrderType, showFName);
        }
        public static int[] StorehouseStoragePriceSyn()
        {
            return DatabaseProvider.GetInstance().StorehouseStoragePriceSyn();
        }
        public static void DeleteStoragesPriceInfo(string ProductID)
        {
            ProductID = "," + ProductID + ",";
            ProductID = Utils.ReSQLSetTxt(ProductID);
            DatabaseProvider.GetInstance().DeleteStoragesPriceInfo(ProductID);
        }
        public static storehouseproductsprice GetStorehouseProductsPriceInfoModel(int ProductPriceID)
        {
            return DatabaseProvider.GetInstance().GetStorehouseProductsPriceInfoModel(ProductPriceID);
        }
        public static int UpdateStorehouseStoragePriceInfo(storehouseproductsprice pp)
        {
           return DatabaseProvider.GetInstance().UpdateStorehouseStoragePriceInfo(pp);
        }
        public static string getPricePnumByPname(string pName)
        {
            return DatabaseProvider.GetInstance().getPricePnumByPname(pName);
        }
        public static bool GetStorehousePriceInfoList(int StoresID, string StCode, int ProductsID, DateTime pAppendTime)
        {
            return DatabaseProvider.GetInstance().GetStorehousePriceInfoList(StoresID, StCode, ProductsID, pAppendTime);
        }
        public static StorehouseStoreInfo GetStorehouseProductsInfoModel(int ProductID)
        {
            return DatabaseProvider.GetInstance().GetStorehouseProductsInfoModel(ProductID);
        }
        #endregion

        public static bool GetDateTimeDataStorehouse(DateTime sDateTime, string sCode, string sName, int proCode, string pBarcode)
        {
            throw new NotImplementedException();
        }

        #region 店员门店查询
        /// <summary>
        /// 获得营业员名称
        /// </summary>
        /// <returns></returns>
        public static DataTable getStaffName()
        {
            return DatabaseProvider.GetInstance().getStaffName();
        }
        /// <summary>
        /// 根据营业员名称获得门店名称
        /// </summary>
        /// <param name="staffName"></param>
        /// <returns></returns>
        public static DataTable getStorehouseNameByStaffName(string staffName)
        {
            return DatabaseProvider.GetInstance().getStorehouseNameByStaffName(staffName);
        }
        /// <summary>
        /// 获得返回行集
        /// </summary>
        /// <param name="staffName"></param>
        /// <returns></returns>
        public static DataTable getStorehouseNameByNameList(string staffName)
        {
            return DatabaseProvider.GetInstance().getStorehouseNameByNameList(staffName);
        }
        /// <summary>
        /// 获得每个门店，每年，每月的销售数量及销售金额
        /// </summary>
        /// <param name="dtYear"></param>
        /// <param name="storesID"></param>
        /// <returns></returns>
        public static DataTable getProductsDetaisMonth(string dtYear, int storesID)
        {
            return DatabaseProvider.GetInstance().getProductsDetaisMonth(dtYear, storesID);
        }
        /// <summary>
        /// 获得销售年份
        /// </summary>
        /// <returns></returns>
        public static DataTable getSalesYear()
        {
            return DatabaseProvider.GetInstance().getSalesYear();
        }
        /// <summary>
        /// 根据门店名称获得门店ID
        /// </summary>
        /// <param name="sName"></param>
        /// <returns></returns>
        public static int getStorageIDBystorageName(string sName)
        {
            return DatabaseProvider.GetInstance().getStorageIDBystorageName(sName);
        }

       /// <summary>
       /// 获得营业员每月的门店数量
       /// </summary>
       /// <param name="sAppendDate"></param>
       /// <param name="staffID"></param>
       /// <returns></returns>
        public static DataTable getStorageNum(string sAppendDate, int staffID)
        {
            return DatabaseProvider.GetInstance().getStorageNum(sAppendDate, staffID);
        }
        #endregion
    }
}

