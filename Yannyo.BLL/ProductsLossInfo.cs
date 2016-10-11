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
    public class ProductsLossInfo
    {
        #region  仓库产品报损详情
        /// <summary>
        /// 获得仓库名称
        /// </summary>
        /// <returns></returns>
        public static DataTable getWorehouseName()
        {
            return DatabaseProvider.GetInstance().getWorehouseName();
        }
        /// <summary>
        /// 根据仓库编号获得产品信息
        /// </summary>
        /// <param name="sid"></param>
        /// <returns></returns>
        public static DataTable getProductsInfoByStorageID(int aid, int sid, DateTime date, DateTime eDate)
        {
            return DatabaseProvider.GetInstance().getProductsInfoByStorageID(aid, sid, date, eDate);
        }
  
        /// <summary>
        /// 调用存储过程获得联营产品报损详情
        /// </summary>
        /// <param name="sDate"></param>
        /// <param name="inyAssociated"></param>
        /// <param name="inyStorageID"></param>
        /// <returns></returns>
        public static DataTable bindProductsLoss(DateTime bDate, DateTime eDate, int inyAssociated, int inyStorageID, int export)
        {
            return DatabaseProvider.GetInstance().bindProductsLoss(bDate, eDate, inyAssociated, inyStorageID, export);
        }
        /// <summary>
        /// 获得仓库产品报损单据编号以及单据时间
        /// </summary>
        /// <param name="bDate"></param>
        /// <param name="eDate"></param>
        /// <param name="inyStorageID"></param>
        /// <param name="inyProductsID"></param>
        /// <returns></returns>
        public static DataTable getProductsLossDetails(DateTime bDate, DateTime eDate, int inyStorageID, int inyProductsID)
        {
            return DatabaseProvider.GetInstance().getProductsLossDetails(bDate, eDate, inyStorageID, inyProductsID);
        }
        #endregion 
        #region 联营产品详情
        /// <summary>
        /// 根据地区id获得门店名称
        /// </summary>
        /// <param name="rid"></param>
        /// <returns></returns>
        public static DataTable getStorehouseNameByRegionID(int rid)
        {
            return DatabaseProvider.GetInstance().getStorehouseNameByRegionID(rid);
        }
        /// <summary>
        /// 获取门店联营产品：包含，剔除，仅包含总数
        /// </summary>
        /// <param name="assc"></param>
        /// <param name="dtTime"></param>
        /// <returns></returns>
        public static DataTable getStorehouseProductsDetails(int regionID,int assc, DateTime dtTime)
        {
            return DatabaseProvider.GetInstance().getStorehouseProductsDetails(regionID, assc, dtTime);
        }
        /// <summary>
        /// 联营产品库存详情
        /// </summary>
        /// <param name="sID"></param>
        /// <param name="aID"></param>
        /// <param name="sDate"></param>
        /// <returns></returns>
        public static DataTable getProductDetailsByStorehouseID(int sID, int aID, DateTime sDate, int qID)
        {
            return DatabaseProvider.GetInstance().getProductDetailsByStorehouseID(sID, aID, sDate, qID);
        }
        /// <summary>
        /// 导出数据
        /// </summary>
        /// <param name="bDate"></param>
        /// <returns></returns>
        public static DataTable getProductsLossExportData(DateTime bDate, DateTime eDate, int isAssocite)
        {
            return DatabaseProvider.GetInstance().getProductsLossExportData(bDate, eDate, isAssocite);
        }
        #endregion
        #region 产品日均销量统计
        /// <summary>
        /// 统计购销产品日均销量
        /// </summary>
        /// <param name="tTpye"></param>
        /// <param name="bDate"></param>
        /// <param name="eDate"></param>
        /// <returns></returns>
        public static DataTable getProductsDay_Sales_Details(int tTpye, DateTime bDate, DateTime eDate)
        {
            return DatabaseProvider.GetInstance().getProductsDay_Sales_Details(tTpye, bDate, eDate);
        }
        /// <summary>
        /// 获得单品日均销量在各门店的详情
        /// </summary>
        /// <param name="productsID"></param>
        /// <param name="bDate"></param>
        /// <param name="eDate"></param>
        /// <param name="tType"></param>
        /// <returns></returns>
        public static DataTable getProducts_Sales_Storehouse(int productsID, DateTime bDate, DateTime eDate, int tType)
        {
            return DatabaseProvider.GetInstance().getProducts_Sales_Storehouse(productsID, bDate, eDate, tType);
        }
        /// <summary>
        /// 获得产品同比日均销量
        /// </summary>
        /// <param name="productsID"></param>
        /// <param name="bDate"></param>
        /// <param name="eDate"></param>
        /// <param name="tType"></param>
        /// <returns></returns>
        public static DataTable getProducts_Sales_Details_year_basis(int tTpye, int productsID, DateTime bDate, DateTime eDate)
        {
            return DatabaseProvider.GetInstance().getProducts_Sales_Details_year_basis(tTpye, productsID, bDate, eDate);
        }
        /// <summary>
        /// 获得门店单品日均销量
        /// </summary>
        /// <param name="tTpye"></param>
        /// <param name="productsID"></param>
        /// <param name="bDate"></param>
        /// <param name="eDate"></param>
        /// <returns></returns>
        public static DataTable Products_Sale_Details_year_annulus(int tTpye, int productsID, DateTime bDate, DateTime eDate)
        {
            return DatabaseProvider.GetInstance().Products_Sale_Details_year_annulus(tTpye, productsID, bDate, eDate);
        }
        /// <summary>
        /// 获得门店销售同比日均销量
        /// </summary>
        /// <param name="productsID"></param>
        /// <param name="bDate"></param>
        /// <param name="eDate"></param>
        /// <param name="tType"></param>
        /// <returns></returns>
        public static DataTable Products_sales_storehouse_basis(int productsID, int storesID, DateTime bDate, DateTime eDate, int tType)
        {
            return DatabaseProvider.GetInstance().Products_sales_storehouse_basis(productsID, storesID, bDate, eDate, tType);
        }
        /// <summary>
        /// 获得门店产品环比日均销量
        /// </summary>
        /// <param name="productsID"></param>
        /// <param name="storesID"></param>
        /// <param name="bDate"></param>
        /// <param name="eDate"></param>
        /// <param name="tType"></param>
        /// <returns></returns>
        public static DataTable Products_sales_storehouse_annulus(int productsID, int storesID, DateTime bDate, DateTime eDate, int tType)
        {
            return DatabaseProvider.GetInstance().Products_sales_storehouse_annulus(productsID, storesID, bDate, eDate, tType);
        }
        /// <summary>
        /// 门店详情
        /// </summary>
        /// <returns></returns>
        public static DataTable getStoresName(DateTime dt)
        {
            return DatabaseProvider.GetInstance().getStoresName(dt);
        }
        #endregion
    }
} 
