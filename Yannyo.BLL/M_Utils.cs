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
using System.Collections.Generic;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Yannyo.BLL
{
    public class M_Utils
    {
        #region  网店客户应用订购信息

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool ExistsM_AppSubscribeInfo(int m_UserInfoID, int lease_id) { return DatabaseProvider.GetInstance().ExistsM_AppSubscribeInfo(m_UserInfoID, lease_id); }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddM_AppSubscribeInfo(M_AppSubscribeInfo model) { return DatabaseProvider.GetInstance().AddM_AppSubscribeInfo(model); }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateM_AppSubscribeInfo(M_AppSubscribeInfo model) { DatabaseProvider.GetInstance().UpdateM_AppSubscribeInfo(model); }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteM_AppSubscribeInfo(int m_AppSubscribeInfoID) { DatabaseProvider.GetInstance().DeleteM_AppSubscribeInfo(m_AppSubscribeInfoID); }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static M_AppSubscribeInfo GetM_AppSubscribeInfoModel(int m_AppSubscribeInfoID) { return DatabaseProvider.GetInstance().GetM_AppSubscribeInfoModel(m_AppSubscribeInfoID); }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataSet GetM_AppSubscribeInfoList(string strWhere) { return DatabaseProvider.GetInstance().GetM_AppSubscribeInfoList(strWhere); }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public static DataSet GetM_AppSubscribeInfoList(int Top, string strWhere, string filedOrder) { return DatabaseProvider.GetInstance().GetM_AppSubscribeInfoList(Top, strWhere, filedOrder); }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public static DataTable GetM_AppSubscribeInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName) { return DatabaseProvider.GetInstance().GetM_AppSubscribeInfoList(PageSize, PageIndex, strWhere, out  pagetotal, OrderType, showFName); }
        #endregion

        #region  网店配置信息

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool ExistsM_ConfigInfo(string m_Name) { return DatabaseProvider.GetInstance().ExistsM_ConfigInfo(m_Name); }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddM_ConfigInfo(M_ConfigInfo model) { return DatabaseProvider.GetInstance().AddM_ConfigInfo(model); }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateM_ConfigInfo(M_ConfigInfo model) { DatabaseProvider.GetInstance().UpdateM_ConfigInfo(model); }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteM_ConfigInfo(int m_ConfigInfoID) { DatabaseProvider.GetInstance().DeleteM_ConfigInfo(m_ConfigInfoID); }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static M_ConfigInfo GetM_ConfigInfoModel(int m_ConfigInfoID) { return DatabaseProvider.GetInstance().GetM_ConfigInfoModel(m_ConfigInfoID); }
        public static M_ConfigInfo GetM_ConfigInfoModelByAppKey(string m_AppKey) { return DatabaseProvider.GetInstance().GetM_ConfigInfoModelByAppKey(m_AppKey); }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataSet GetM_ConfigInfoList(string strWhere) { return DatabaseProvider.GetInstance().GetM_ConfigInfoList(strWhere); }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public static DataSet GetM_ConfigInfoList(int Top, string strWhere, string filedOrder) { return DatabaseProvider.GetInstance().GetM_ConfigInfoList(Top, strWhere, filedOrder); }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public static DataTable GetM_ConfigInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName) { return DatabaseProvider.GetInstance().GetM_ConfigInfoList(PageSize, PageIndex, strWhere, out  pagetotal, OrderType, showFName); }
        /// <summary>
        /// 更新SessionKey时间
        /// </summary>
        /// <param name="m_ConfigInfoID"></param>
        public static void UpdateM_ConfigSessionKeyTime(int m_ConfigInfoID)
        {
            DatabaseProvider.GetInstance().UpdateM_ConfigSessionKeyTime(m_ConfigInfoID);
        }
        #endregion

        #region  网店客户信用信息

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool ExistsM_CreditInfo(int m_UserInfoID) { return DatabaseProvider.GetInstance().ExistsM_CreditInfo(m_UserInfoID); }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddM_CreditInfo(M_CreditInfo model) { return DatabaseProvider.GetInstance().AddM_CreditInfo(model); }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateM_CreditInfo(M_CreditInfo model) { DatabaseProvider.GetInstance().UpdateM_CreditInfo(model); }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteM_CreditInfo(int m_CreditInfoID) { DatabaseProvider.GetInstance().DeleteM_CreditInfo(m_CreditInfoID); }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static M_CreditInfo GetM_CreditInfoModel(int m_CreditInfoID) { return DatabaseProvider.GetInstance().GetM_CreditInfoModel(m_CreditInfoID); }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataSet GetM_CreditInfoList(string strWhere) { return DatabaseProvider.GetInstance().GetM_CreditInfoList(strWhere); }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public static DataSet GetM_CreditInfoList(int Top, string strWhere, string filedOrder) { return DatabaseProvider.GetInstance().GetM_CreditInfoList(Top, strWhere, filedOrder); }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public static DataTable GetM_CreditInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName) { return DatabaseProvider.GetInstance().GetM_CreditInfoList(PageSize, PageIndex, strWhere, out pagetotal, OrderType, showFName); }
        #endregion

        #region 网店会员
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool ExistsM_Member(int m_ConfigInfoID, string buyer_id)
        {
            return DatabaseProvider.GetInstance().ExistsM_Member(m_ConfigInfoID, buyer_id);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddM_Member(M_MemberInfo model)
        {
            return DatabaseProvider.GetInstance().AddM_Member(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool UpdateM_Member(M_MemberInfo model)
        {
            return DatabaseProvider.GetInstance().UpdateM_Member(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static bool DeleteM_Member(int m_MemberInfoID)
        {
            return DatabaseProvider.GetInstance().DeleteM_Member(m_MemberInfoID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static bool DeleteM_MemberList(string m_MemberInfoIDlist)
        {
            return DatabaseProvider.GetInstance().DeleteM_MemberList(m_MemberInfoIDlist);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static M_MemberInfo GetM_MemberModel(int m_MemberInfoID)
        {
            return DatabaseProvider.GetInstance().GetM_MemberModel(m_MemberInfoID);
        }
        public static M_MemberInfo GetM_MemberModel(int m_ConfigInfoID,string buyer_id)
        {
            return DatabaseProvider.GetInstance().GetM_MemberModel(m_ConfigInfoID, buyer_id);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataSet GetM_MemberList(string strWhere)
        {
            return DatabaseProvider.GetInstance().GetM_MemberList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public static DataSet GetM_MemberList(int Top, string strWhere, string filedOrder)
        {
            return DatabaseProvider.GetInstance().GetM_MemberList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public static DataTable GetM_MemberList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
        {
            return DatabaseProvider.GetInstance().GetM_MemberList(PageSize, PageIndex, strWhere, out  pagetotal, OrderType, showFName);
        }

        #endregion

        #region  商品扩展信息

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool ExistsM_GoodsExtraInfo(int m_GoodsID, int eid, int num_iid, string title) { return DatabaseProvider.GetInstance().ExistsM_GoodsExtraInfo(m_GoodsID, eid, num_iid, title); }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddM_GoodsExtraInfo(M_GoodsExtraInfo model) { return DatabaseProvider.GetInstance().AddM_GoodsExtraInfo(model); }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateM_GoodsExtraInfo(M_GoodsExtraInfo model) { DatabaseProvider.GetInstance().UpdateM_GoodsExtraInfo(model); }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteM_GoodsExtraInfo(int m_GoodsExtraInfoID) { DatabaseProvider.GetInstance().DeleteM_GoodsExtraInfo(m_GoodsExtraInfoID); }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static M_GoodsExtraInfo GetM_GoodsExtraInfoModel(int m_GoodsExtraInfoID) { return DatabaseProvider.GetInstance().GetM_GoodsExtraInfoModel(m_GoodsExtraInfoID); }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataSet GetM_GoodsExtraInfoList(string strWhere) { return DatabaseProvider.GetInstance().GetM_GoodsExtraInfoList(strWhere); }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public static DataSet GetM_GoodsExtraInfoList(int Top, string strWhere, string filedOrder) { return DatabaseProvider.GetInstance().GetM_GoodsExtraInfoList(Top, strWhere, filedOrder); }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public static DataTable GetM_GoodsExtraInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName) { return DatabaseProvider.GetInstance().GetM_GoodsExtraInfoList(PageSize, PageIndex, strWhere, out  pagetotal, OrderType, showFName); }
        #endregion

        #region  商品信息
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool ExistsM_GoodsInfo(int m_ConfigInfoID, int ProductsID, int m_ProductInfoID, long product_id) { return DatabaseProvider.GetInstance().ExistsM_GoodsInfo(m_ConfigInfoID, ProductsID, m_ProductInfoID, product_id); }
        public static bool ExistsM_GoodsInfo(int m_ConfigInfoID, long num_iid)
        {
            return DatabaseProvider.GetInstance().ExistsM_GoodsInfo(m_ConfigInfoID, num_iid);
        }
        public static int ExistsM_GoodsInfoAndGetID(int m_ConfigInfoID, long num_iid)
        {
            return DatabaseProvider.GetInstance().ExistsM_GoodsInfoAndGetID(m_ConfigInfoID, num_iid);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddM_GoodsInfo(M_GoodsInfo model) { return DatabaseProvider.GetInstance().AddM_GoodsInfo(model); }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateM_GoodsInfo(M_GoodsInfo model) { DatabaseProvider.GetInstance().UpdateM_GoodsInfo(model); }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteM_GoodsInfo(int m_GoodsID) { DatabaseProvider.GetInstance().DeleteM_GoodsInfo(m_GoodsID); }
        /// <summary>
        /// 非真删除
        /// </summary>
        /// <param name="m_GoodsID"></param>
        public static void DeleteM_GoodsInfoNOTrue(int m_GoodsID)
        {
            DatabaseProvider.GetInstance().DeleteM_GoodsInfoNOTrue(m_GoodsID);
        }
        /// <summary>
        /// 上架
        /// </summary>
        /// <param name="m_GoodsID"></param>
        public static void ListingM_Goods(int m_GoodsID)
        {
            DatabaseProvider.GetInstance().ListingM_Goods(m_GoodsID);
        }
        /// <summary>
        /// 下架
        /// </summary>
        /// <param name="m_GoodsID"></param>
        public static void DelistingM_Goods(int m_GoodsID)
        {
            DatabaseProvider.GetInstance().DelistingM_Goods(m_GoodsID);
        }
        /// <summary>
        /// 推荐
        /// </summary>
        /// <param name="m_GoodsID"></param>
        public static void RecommendAddM_Goods(int m_GoodsID)
        {
            DatabaseProvider.GetInstance().RecommendAddM_Goods(m_GoodsID);
        }
        /// <summary>
        /// 取消推荐
        /// </summary>
        /// <param name="m_GoodsID"></param>
        public static void RecommendDeleteM_Goods(int m_GoodsID)
        {
            DatabaseProvider.GetInstance().RecommendDeleteM_Goods(m_GoodsID);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static M_GoodsInfo GetM_GoodsInfoModel(int m_GoodsID) { return DatabaseProvider.GetInstance().GetM_GoodsInfoModel(m_GoodsID); }
        public static M_GoodsInfo GetM_GoodsInfoModelByProductsID(int m_ConfigInfoID, int ProductsID) { return DatabaseProvider.GetInstance().GetM_GoodsInfoModelByProductsID(m_ConfigInfoID, ProductsID); }
        public static M_GoodsInfo GetM_GoodsInfoModelByNum_iid(int m_ConfigInfoID, long num_iid) { return DatabaseProvider.GetInstance().GetM_GoodsInfoModelByNum_iid(m_ConfigInfoID, num_iid); }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataSet GetM_GoodsInfoList(string strWhere) { return DatabaseProvider.GetInstance().GetM_GoodsInfoList(strWhere); }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public static DataSet GetM_GoodsInfoList(int Top, string strWhere, string filedOrder) { return DatabaseProvider.GetInstance().GetM_GoodsInfoList(Top, strWhere, filedOrder); }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public static DataTable GetM_GoodsInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName) { return DatabaseProvider.GetInstance().GetM_GoodsInfoList(PageSize, PageIndex, strWhere, out  pagetotal, OrderType, showFName); }
        /// <summary>
        /// 返回商品数量列表
        /// </summary>
        /// <param name="m_ConfigInfoID"></param>
        /// <returns></returns>
        public static DataTable GetM_GoodsStockList(int m_ConfigInfoID)
        {
            return DatabaseProvider.GetInstance().GetM_GoodsStockList(m_ConfigInfoID);
        }
        /// <summary>
        /// 更新商品数量
        /// </summary>
        /// <param name="m_ConfigInfoID"></param>
        /// <param name="ProductsID"></param>
        /// <param name="Num"></param>
        /// <returns></returns>
        public static bool UpdateM_GoodsStockNum(int m_ConfigInfoID, int ProductsID, int Num, int StorageID)
        {
            return DatabaseProvider.GetInstance().UpdateM_GoodsStockNum(m_ConfigInfoID, ProductsID, Num, StorageID);
        }
        /// <summary>
        /// 获取商品仓库数量列表
        /// </summary>
        /// <param name="m_ConfigInfoID"></param>
        /// <param name="m_GoodsID"></param>
        /// <returns></returns>
        public static DataTable GetM_GoodsStockList(int m_ConfigInfoID, int m_GoodsID)
        {
            return DatabaseProvider.GetInstance().GetM_GoodsStockList(m_ConfigInfoID, m_GoodsID);
        }
        /// <summary>
        /// 更新商品总数量
        /// </summary>
        /// <param name="m_ConfigInfoID"></param>
        /// <param name="m_GoodsID"></param>
        /// <param name="Num"></param>
        /// <returns></returns>
        public static bool UpdateM_GoodsNum(int m_ConfigInfoID, int m_GoodsID, int Num)
        {
            return DatabaseProvider.GetInstance().UpdateM_GoodsNum(m_ConfigInfoID, m_GoodsID, Num);
        }
        /// <summary>
        /// 更新商品总数量
        /// </summary>
        /// <param name="m_ConfigInfoID"></param>
        /// <param name="num_iid"></param>
        /// <param name="Num"></param>
        /// <returns></returns>
        public static bool UpdateM_GoodsNum(int m_ConfigInfoID, long num_iid, int Num)
        {
            return DatabaseProvider.GetInstance().UpdateM_GoodsNum(m_ConfigInfoID, num_iid, Num);
        }
        #endregion

        #region  Sku扩展信息

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool ExistsM_GoodsSkuExtraInfo(int m_GoodsSkuInfoID, int extra_id, int sku_id) { return DatabaseProvider.GetInstance().ExistsM_GoodsSkuExtraInfo(m_GoodsSkuInfoID, extra_id, sku_id); }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddM_GoodsSkuExtraInfo(M_GoodsSkuExtraInfo model) { return DatabaseProvider.GetInstance().AddM_GoodsSkuExtraInfo(model); }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateM_GoodsSkuExtraInfo(M_GoodsSkuExtraInfo model) { DatabaseProvider.GetInstance().UpdateM_GoodsSkuExtraInfo(model); }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteM_GoodsSkuExtraInfo(int m_GoodsSkuExtraInfoID) { DatabaseProvider.GetInstance().DeleteM_GoodsSkuExtraInfo(m_GoodsSkuExtraInfoID); }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static M_GoodsSkuExtraInfo GetM_GoodsSkuExtraInfoModel(int m_GoodsSkuExtraInfoID) { return DatabaseProvider.GetInstance().GetM_GoodsSkuExtraInfoModel(m_GoodsSkuExtraInfoID); }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataSet GetM_GoodsSkuExtraInfoList(string strWhere) { return DatabaseProvider.GetInstance().GetM_GoodsSkuExtraInfoList(strWhere); }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public static DataSet GetM_GoodsSkuExtraInfoList(int Top, string strWhere, string filedOrder) { return DatabaseProvider.GetInstance().GetM_GoodsSkuExtraInfoList(Top, strWhere, filedOrder); }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public static DataTable GetM_GoodsSkuExtraInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName) { return DatabaseProvider.GetInstance().GetM_GoodsSkuExtraInfoList(PageSize, PageIndex, strWhere, out  pagetotal, OrderType, showFName); }
        #endregion

        #region  Sku信息

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool ExistsM_GoodsSkuInfo(int m_ConfigInfoID, int m_Type, int m_ObjID, int sku_id, int num_iid) { return DatabaseProvider.GetInstance().ExistsM_GoodsSkuInfo(m_ConfigInfoID, m_Type, m_ObjID, sku_id, num_iid); }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddM_GoodsSkuInfo(M_GoodsSkuInfo model) { return DatabaseProvider.GetInstance().AddM_GoodsSkuInfo(model); }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateM_GoodsSkuInfo(M_GoodsSkuInfo model) { DatabaseProvider.GetInstance().UpdateM_GoodsSkuInfo(model); }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteM_GoodsSkuInfo(int m_GoodsSkuInfoID) { DatabaseProvider.GetInstance().DeleteM_GoodsSkuInfo(m_GoodsSkuInfoID); }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static M_GoodsSkuInfo GetM_GoodsSkuInfoModel(int m_GoodsSkuInfoID) { return DatabaseProvider.GetInstance().GetM_GoodsSkuInfoModel(m_GoodsSkuInfoID); }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataSet GetM_GoodsSkuInfoList(string strWhere) { return DatabaseProvider.GetInstance().GetM_GoodsSkuInfoList(strWhere); }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public static DataSet GetM_GoodsSkuInfoList(int Top, string strWhere, string filedOrder) { return DatabaseProvider.GetInstance().GetM_GoodsSkuInfoList(Top, strWhere, filedOrder); }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public static DataTable GetM_GoodsSkuInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName) { return DatabaseProvider.GetInstance().GetM_GoodsSkuInfoList(PageSize, PageIndex, strWhere, out  pagetotal, OrderType, showFName); }
        #endregion

        #region 子图片信息

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool ExistsM_ImgInfo(int m_ConfigInfoID, int m_Type, int m_ObjID, int m_id) { return DatabaseProvider.GetInstance().ExistsM_ImgInfo(m_ConfigInfoID, m_Type, m_ObjID, m_id); }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddM_ImgInfo(M_ImgInfo model) { return DatabaseProvider.GetInstance().AddM_ImgInfo(model); }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateM_ImgInfo(M_ImgInfo model) { DatabaseProvider.GetInstance().UpdateM_ImgInfo(model); }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteM_ImgInfo(int m_ImgInfoID) { DatabaseProvider.GetInstance().DeleteM_ImgInfo(m_ImgInfoID); }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static M_ImgInfo GetM_ImgInfoModel(int m_ImgInfoID) { return DatabaseProvider.GetInstance().GetM_ImgInfoModel(m_ImgInfoID); }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataSet GetM_ImgInfoList(string strWhere) { return DatabaseProvider.GetInstance().GetM_ImgInfoList(strWhere); }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public static DataSet GetM_ImgInfoList(int Top, string strWhere, string filedOrder) { return DatabaseProvider.GetInstance().GetM_ImgInfoList(Top, strWhere, filedOrder); }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public static DataTable GetM_ImgInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName) { return DatabaseProvider.GetInstance().GetM_ImgInfoList(PageSize, PageIndex, strWhere, out  pagetotal, OrderType, showFName); }
        #endregion

        #region  地址信息

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool ExistsM_LocationInfo(int m_ConfigInfoID, int m_Type, int m_ObjID, string address) { return DatabaseProvider.GetInstance().ExistsM_LocationInfo(m_ConfigInfoID, m_Type, m_ObjID, address); }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddM_LocationInfo(M_LocationInfo model) { return DatabaseProvider.GetInstance().AddM_LocationInfo(model); }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateM_LocationInfo(M_LocationInfo model) { DatabaseProvider.GetInstance().UpdateM_LocationInfo(model); }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteM_LocationInfo(int m_LocationID) { DatabaseProvider.GetInstance().DeleteM_LocationInfo(m_LocationID); }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static M_LocationInfo GetM_LocationInfoModel(int m_LocationID) { return DatabaseProvider.GetInstance().GetM_LocationInfoModel(m_LocationID); }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataSet GetM_LocationInfoList(string strWhere) { return DatabaseProvider.GetInstance().GetM_LocationInfoList(strWhere); }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public static DataSet GetM_LocationInfoList(int Top, string strWhere, string filedOrder) { return DatabaseProvider.GetInstance().GetM_LocationInfoList(Top, strWhere, filedOrder); }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public static DataTable GetM_LocationInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName) { return DatabaseProvider.GetInstance().GetM_LocationInfoList(PageSize, PageIndex, strWhere, out  pagetotal, OrderType, showFName); }
        #endregion

        #region 交易

        #region  交易留言凭证图片信息

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool ExistsM_MessageImgInfo(int m_MessageInfoID, string url) { return DatabaseProvider.GetInstance().ExistsM_MessageImgInfo(m_MessageInfoID, url); }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddM_MessageImgInfo(M_MessageImgInfo model) { return DatabaseProvider.GetInstance().AddM_MessageImgInfo(model); }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateM_MessageImgInfo(M_MessageImgInfo model) { DatabaseProvider.GetInstance().UpdateM_MessageImgInfo(model); }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteM_MessageImgInfo(int m_MessageImgInfoID) { DatabaseProvider.GetInstance().DeleteM_MessageImgInfo(m_MessageImgInfoID); }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static M_MessageImgInfo GetM_MessageImgInfoModel(int m_MessageImgInfoID) { return DatabaseProvider.GetInstance().GetM_MessageImgInfoModel(m_MessageImgInfoID); }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataSet GetM_MessageImgInfoList(string strWhere) { return DatabaseProvider.GetInstance().GetM_MessageImgInfoList(strWhere); }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public static DataSet GetM_MessageImgInfoList(int Top, string strWhere, string filedOrder) { return DatabaseProvider.GetInstance().GetM_MessageImgInfoList(Top, strWhere, filedOrder); }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public static DataTable GetM_MessageImgInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName) { return DatabaseProvider.GetInstance().GetM_MessageImgInfoList(PageSize, PageIndex, strWhere, out  pagetotal, OrderType, showFName); }
        #endregion

        #region  交易留言凭证信息

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool ExistsM_MessageInfo(int m_ConfigInfoID, int m_Type, int m_ObjID, int m_id) { return DatabaseProvider.GetInstance().ExistsM_MessageInfo(m_ConfigInfoID, m_Type, m_ObjID, m_id); }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddM_MessageInfo(M_MessageInfo model) { return DatabaseProvider.GetInstance().AddM_MessageInfo(model); }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateM_MessageInfo(M_MessageInfo model) { DatabaseProvider.GetInstance().UpdateM_MessageInfo(model); }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteM_MessageInfo(int m_MessageInfoID) { DatabaseProvider.GetInstance().DeleteM_MessageInfo(m_MessageInfoID); }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static M_MessageInfo GetM_MessageInfoModel(int m_MessageInfoID) { return DatabaseProvider.GetInstance().GetM_MessageInfoModel(m_MessageInfoID); }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataSet GetM_MessageInfoList(string strWhere) { return DatabaseProvider.GetInstance().GetM_MessageInfoList(strWhere); }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public static DataSet GetM_MessageInfoList(int Top, string strWhere, string filedOrder) { return DatabaseProvider.GetInstance().GetM_MessageInfoList(Top, strWhere, filedOrder); }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public static DataTable GetM_MessageInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName) { return DatabaseProvider.GetInstance().GetM_MessageInfoList(PageSize, PageIndex, strWhere, out  pagetotal, OrderType, showFName); }
        #endregion

        #endregion

        #region  订单信息

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool ExistsM_OrderInfo(int m_ConfigInfoID, int m_TradeInfoID, int num_iid) { return DatabaseProvider.GetInstance().ExistsM_OrderInfo(m_ConfigInfoID, m_TradeInfoID, num_iid); }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddM_OrderInfo(M_OrderInfo model) { return DatabaseProvider.GetInstance().AddM_OrderInfo(model); }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateM_OrderInfo(M_OrderInfo model) { DatabaseProvider.GetInstance().UpdateM_OrderInfo(model); }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteM_OrderInfo(int m_OrderInfoID) { DatabaseProvider.GetInstance().DeleteM_OrderInfo(m_OrderInfoID); }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static M_OrderInfo GetM_OrderInfoModel(int m_OrderInfoID) { return DatabaseProvider.GetInstance().GetM_OrderInfoModel(m_OrderInfoID); }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataSet GetM_OrderInfoList(string strWhere) { return DatabaseProvider.GetInstance().GetM_OrderInfoList(strWhere); }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public static DataSet GetM_OrderInfoList(int Top, string strWhere, string filedOrder) { return DatabaseProvider.GetInstance().GetM_OrderInfoList(Top, strWhere, filedOrder); }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public static DataTable GetM_OrderInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName) { return DatabaseProvider.GetInstance().GetM_OrderInfoList(PageSize, PageIndex, strWhere, out  pagetotal, OrderType, showFName); }
        #endregion

        #region  订单优惠信息

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool ExistsM_OrderPromotionDetailInfo(int m_Type, int m_ObjID, int m_id) { return DatabaseProvider.GetInstance().ExistsM_OrderPromotionDetailInfo(m_Type, m_ObjID, m_id); }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddM_OrderPromotionDetailInfo(M_OrderPromotionDetailInfo model) { return DatabaseProvider.GetInstance().AddM_OrderPromotionDetailInfo(model); }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateM_OrderPromotionDetailInfo(M_OrderPromotionDetailInfo model) { DatabaseProvider.GetInstance().UpdateM_OrderPromotionDetailInfo(model); }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteM_OrderPromotionDetailInfo(int m_Order_PromotionDetailInfoID) { DatabaseProvider.GetInstance().DeleteM_OrderPromotionDetailInfo(m_Order_PromotionDetailInfoID); }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static M_OrderPromotionDetailInfo GetM_OrderPromotionDetailInfoModel(int m_Order_PromotionDetailInfoID) { return DatabaseProvider.GetInstance().GetM_OrderPromotionDetailInfoModel(m_Order_PromotionDetailInfoID); }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataSet GetM_OrderPromotionDetailInfoList(string strWhere) { return DatabaseProvider.GetInstance().GetM_OrderPromotionDetailInfoList(strWhere); }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public static DataSet GetM_OrderPromotionDetailInfoList(int Top, string strWhere, string filedOrder) { return DatabaseProvider.GetInstance().GetM_OrderPromotionDetailInfoList(Top, strWhere, filedOrder); }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public static DataTable GetM_OrderPromotionDetailInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName) { return DatabaseProvider.GetInstance().GetM_OrderPromotionDetailInfoList(PageSize, PageIndex, strWhere, out  pagetotal, OrderType, showFName); }
        #endregion

        #region  退款信息

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool ExistsM_OrderRefundInfo(int m_ConfigInfoID, int num_iid, int refund_id, int tid, int oid, string alipay_no) { return DatabaseProvider.GetInstance().ExistsM_OrderRefundInfo(m_ConfigInfoID, num_iid, refund_id, tid, oid, alipay_no); }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddM_OrderRefundInfo(M_OrderRefundInfo model) { return DatabaseProvider.GetInstance().AddM_OrderRefundInfo(model); }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateM_OrderRefundInfo(M_OrderRefundInfo model) { DatabaseProvider.GetInstance().UpdateM_OrderRefundInfo(model); }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteM_OrderRefundInfo(int m_OrderRefundInfoID) { DatabaseProvider.GetInstance().DeleteM_OrderRefundInfo(m_OrderRefundInfoID); }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static M_OrderRefundInfo GetM_OrderRefundInfoModel(int m_OrderRefundInfoID) { return DatabaseProvider.GetInstance().GetM_OrderRefundInfoModel(m_OrderRefundInfoID); }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataSet GetM_OrderRefundInfoList(string strWhere) { return DatabaseProvider.GetInstance().GetM_OrderRefundInfoList(strWhere); }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public static DataSet GetM_OrderRefundInfoList(int Top, string strWhere, string filedOrder) { return DatabaseProvider.GetInstance().GetM_OrderRefundInfoList(Top, strWhere, filedOrder); }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public static DataTable GetM_OrderRefundInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName) { return DatabaseProvider.GetInstance().GetM_OrderRefundInfoList(PageSize, PageIndex, strWhere, out  pagetotal, OrderType, showFName); }
        #endregion

        #region  产品结构信息

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool ExistsM_ProductInfo(int m_ConfigInfoID, int ProductsID, long product_id) { return DatabaseProvider.GetInstance().ExistsM_ProductInfo(m_ConfigInfoID, ProductsID, product_id); }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddM_ProductInfo(M_ProductInfo model) { return DatabaseProvider.GetInstance().AddM_ProductInfo(model); }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateM_ProductInfo(M_ProductInfo model) { DatabaseProvider.GetInstance().UpdateM_ProductInfo(model); }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteM_ProductInfo(int m_ProductInfoID) { DatabaseProvider.GetInstance().DeleteM_ProductInfo(m_ProductInfoID); }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static M_ProductInfo GetM_ProductInfoModel(int m_ProductInfoID) { return DatabaseProvider.GetInstance().GetM_ProductInfoModel(m_ProductInfoID); }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataSet GetM_ProductInfoList(string strWhere) { return DatabaseProvider.GetInstance().GetM_ProductInfoList(strWhere); }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public static DataSet GetM_ProductInfoList(int Top, string strWhere, string filedOrder) { return DatabaseProvider.GetInstance().GetM_ProductInfoList(Top, strWhere, filedOrder); }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public static DataTable GetM_ProductInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName) { return DatabaseProvider.GetInstance().GetM_ProductInfoList(PageSize, PageIndex, strWhere, out  pagetotal, OrderType, showFName); }
        #endregion

        #region 属性图片信息

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool ExistsM_PropImgInfo(int m_ConfigInfoID, int m_Type, int m_ObjID, int m_id, long product_id) { return DatabaseProvider.GetInstance().ExistsM_PropImgInfo(m_ConfigInfoID, m_Type, m_ObjID, m_id, product_id); }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddM_PropImgInfo(M_PropImgInfo model) { return DatabaseProvider.GetInstance().AddM_PropImgInfo(model); }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateM_PropImgInfo(M_PropImgInfo model) { DatabaseProvider.GetInstance().UpdateM_PropImgInfo(model); }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteM_PropImgInfo(int m_PropImgInfoID) { DatabaseProvider.GetInstance().DeleteM_PropImgInfo(m_PropImgInfoID); }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static M_PropImgInfo GetM_PropImgInfoModel(int m_PropImgInfoID) { return DatabaseProvider.GetInstance().GetM_PropImgInfoModel(m_PropImgInfoID); }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataSet GetM_PropImgInfoList(string strWhere) { return DatabaseProvider.GetInstance().GetM_PropImgInfoList(strWhere); }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public static DataSet GetM_PropImgInfoList(int Top, string strWhere, string filedOrder) { return DatabaseProvider.GetInstance().GetM_PropImgInfoList(Top, strWhere, filedOrder); }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public static DataTable GetM_PropImgInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName) { return DatabaseProvider.GetInstance().GetM_PropImgInfoList(PageSize, PageIndex, strWhere, out  pagetotal, OrderType, showFName); }
        #endregion

        #region  交易地址信息

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool ExistsM_ShoppingAddressInfo(int m_ConfigInfoID, int m_Type, int m_ObjID, int address_id) { return DatabaseProvider.GetInstance().ExistsM_ShoppingAddressInfo(m_ConfigInfoID, m_Type, m_ObjID, address_id); }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddM_ShoppingAddressInfo(M_ShoppingAddressInfo model) { return DatabaseProvider.GetInstance().AddM_ShoppingAddressInfo(model); }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateM_ShoppingAddressInfo(M_ShoppingAddressInfo model) { DatabaseProvider.GetInstance().UpdateM_ShoppingAddressInfo(model); }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteM_ShoppingAddressInfo(int m_ShoppingAddressInfoID) { DatabaseProvider.GetInstance().DeleteM_ShoppingAddressInfo(m_ShoppingAddressInfoID); }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static M_ShoppingAddressInfo GetM_ShoppingAddressInfoModel(int m_ShoppingAddressInfoID) { return DatabaseProvider.GetInstance().GetM_ShoppingAddressInfoModel(m_ShoppingAddressInfoID); }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataSet GetM_ShoppingAddressInfoList(string strWhere) { return DatabaseProvider.GetInstance().GetM_ShoppingAddressInfoList(strWhere); }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public static DataSet GetM_ShoppingAddressInfoList(int Top, string strWhere, string filedOrder) { return DatabaseProvider.GetInstance().GetM_ShoppingAddressInfoList(Top, strWhere, filedOrder); }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public static DataTable GetM_ShoppingAddressInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName) { return DatabaseProvider.GetInstance().GetM_ShoppingAddressInfoList(PageSize, PageIndex, strWhere, out  pagetotal, OrderType, showFName); }
        #endregion

        #region  网店商品库存信息

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool ExistsM_StockInfo(int m_ConfigInfoID, int ProductsID, int StorageID) { return DatabaseProvider.GetInstance().ExistsM_StockInfo(m_ConfigInfoID, ProductsID, StorageID); }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddM_StockInfo(M_StockInfo model) { return DatabaseProvider.GetInstance().AddM_StockInfo(model); }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateM_StockInfo(M_StockInfo model) { DatabaseProvider.GetInstance().UpdateM_StockInfo(model); }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteM_StockInfo(int m_StockInfoID) { DatabaseProvider.GetInstance().DeleteM_StockInfo(m_StockInfoID); }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static M_StockInfo GetM_StockInfoModel(int m_StockInfoID) { return DatabaseProvider.GetInstance().GetM_StockInfoModel(m_StockInfoID); }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataSet GetM_StockInfoList(string strWhere) { return DatabaseProvider.GetInstance().GetM_StockInfoList(strWhere); }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public static DataSet GetM_StockInfoList(int Top, string strWhere, string filedOrder) { return DatabaseProvider.GetInstance().GetM_StockInfoList(Top, strWhere, filedOrder); }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public static DataTable GetM_StockInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName) { return DatabaseProvider.GetInstance().GetM_StockInfoList(PageSize, PageIndex, strWhere, out  pagetotal, OrderType, showFName); }
        #endregion

        #region  交易超时信息

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool ExistsM_TimeOutInfo(int m_ConfigInfoID, int m_Type, int m_ObjID, int remind_type) { return DatabaseProvider.GetInstance().ExistsM_TimeOutInfo(m_ConfigInfoID, m_Type, m_ObjID, remind_type); }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddM_TimeOutInfo(M_TimeOutInfo model) { return DatabaseProvider.GetInstance().AddM_TimeOutInfo(model); }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateM_TimeOutInfo(M_TimeOutInfo model) { DatabaseProvider.GetInstance().UpdateM_TimeOutInfo(model); }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteM_TimeOutInfo(int m_TimeOutInfoID) { DatabaseProvider.GetInstance().DeleteM_TimeOutInfo(m_TimeOutInfoID); }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static M_TimeOutInfo GetM_TimeOutInfoModel(int m_TimeOutInfoID) { return DatabaseProvider.GetInstance().GetM_TimeOutInfoModel(m_TimeOutInfoID); }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataSet GetM_TimeOutInfoList(string strWhere) { return DatabaseProvider.GetInstance().GetM_TimeOutInfoList(strWhere); }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public static DataSet GetM_TimeOutInfoList(int Top, string strWhere, string filedOrder) { return DatabaseProvider.GetInstance().GetM_TimeOutInfoList(Top, strWhere, filedOrder); }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public static DataTable GetM_TimeOutInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName) { return DatabaseProvider.GetInstance().GetM_TimeOutInfoList(PageSize, PageIndex, strWhere, out  pagetotal, OrderType, showFName); }
        #endregion

        #region  交易信息

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool ExistsM_TradeInfo(int m_ConfigInfoID, long tid) { return DatabaseProvider.GetInstance().ExistsM_TradeInfo(m_ConfigInfoID, tid); }
        public static int ExistsM_TradeInfoAndReID(int m_ConfigInfoID, long tid) { return DatabaseProvider.GetInstance().ExistsM_TradeInfoAndReID(m_ConfigInfoID, tid); }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddM_TradeInfo(M_TradeInfo model) { return DatabaseProvider.GetInstance().AddM_TradeInfo(model); }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateM_TradeInfo(M_TradeInfo model) { DatabaseProvider.GetInstance().UpdateM_TradeInfo(model); }
        /// <summary>
        /// 更新交易状态
        /// </summary>
        /// <param name="m_TradeInfoID"></param>
        /// <param name="status"></param>
        public static void UpdateM_TradeStatus(int m_TradeInfoID, string status)
        {
            DatabaseProvider.GetInstance().UpdateM_TradeStatus(m_TradeInfoID, status);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteM_TradeInfo(int m_TradeInfoID) { DatabaseProvider.GetInstance().DeleteM_TradeInfo(m_TradeInfoID); }
        public static void DeleteM_TradeInfo(int m_ConfigInfoID, int m_TradeInfoID)
        {
            DatabaseProvider.GetInstance().DeleteM_TradeInfo(m_ConfigInfoID, m_TradeInfoID);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static M_TradeInfo GetM_TradeInfoModel(int m_TradeInfoID) { return DatabaseProvider.GetInstance().GetM_TradeInfoModel(m_TradeInfoID); }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataSet GetM_TradeInfoList(string strWhere) { return DatabaseProvider.GetInstance().GetM_TradeInfoList(strWhere); }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public static DataSet GetM_TradeInfoList(int Top, string strWhere, string filedOrder) { return DatabaseProvider.GetInstance().GetM_TradeInfoList(Top, strWhere, filedOrder); }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public static DataTable GetM_TradeInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName) { return DatabaseProvider.GetInstance().GetM_TradeInfoList(PageSize, PageIndex, strWhere, out  pagetotal, OrderType, showFName); }
        #endregion

        #region  网店客户信息

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool ExistsM_UserInfo(int m_ConfigInfoID, long user_id, string uid) { return DatabaseProvider.GetInstance().ExistsM_UserInfo(m_ConfigInfoID, user_id, uid); }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddM_UserInfo(M_UserInfo model) { return DatabaseProvider.GetInstance().AddM_UserInfo(model); }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateM_UserInfo(M_UserInfo model) { DatabaseProvider.GetInstance().UpdateM_UserInfo(model); }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteM_UserInfo(int m_UserInfoID) { DatabaseProvider.GetInstance().DeleteM_UserInfo(m_UserInfoID); }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static M_UserInfo GetM_UserInfoModel(int m_UserInfoID) { return DatabaseProvider.GetInstance().GetM_UserInfoModel(m_UserInfoID); }
        public static M_UserInfo GetM_UserInfoModel(int m_ConfigInfoID, long user_id, string uid) { return DatabaseProvider.GetInstance().GetM_UserInfoModel(m_ConfigInfoID, user_id, uid); }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataSet GetM_UserInfoList(string strWhere) { return DatabaseProvider.GetInstance().GetM_UserInfoList(strWhere); }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public static DataSet GetM_UserInfoList(int Top, string strWhere, string filedOrder) { return DatabaseProvider.GetInstance().GetM_UserInfoList(Top, strWhere, filedOrder); }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public static DataTable GetM_UserInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName) { return DatabaseProvider.GetInstance().GetM_UserInfoList(PageSize, PageIndex, strWhere, out  pagetotal, OrderType, showFName); }
        #endregion

        #region  视频信息

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool ExistsM_VideoInfo(int m_ConfigInfoID, int m_Type, int m_ObjID, int video_id) { return DatabaseProvider.GetInstance().ExistsM_VideoInfo(m_ConfigInfoID, m_Type, m_ObjID, video_id); }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddM_VideoInfo(M_VideoInfo model) { return DatabaseProvider.GetInstance().AddM_VideoInfo(model); }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateM_VideoInfo(M_VideoInfo model) { DatabaseProvider.GetInstance().UpdateM_VideoInfo(model); }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteM_VideoInfo(int m_VideoInfoID) { DatabaseProvider.GetInstance().DeleteM_VideoInfo(m_VideoInfoID); }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static M_VideoInfo GetM_VideoInfoModel(int m_VideoInfoID) { return DatabaseProvider.GetInstance().GetM_VideoInfoModel(m_VideoInfoID); }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataSet GetM_VideoInfoList(string strWhere) { return DatabaseProvider.GetInstance().GetM_VideoInfoList(strWhere); }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public static DataSet GetM_VideoInfoList(int Top, string strWhere, string filedOrder) { return DatabaseProvider.GetInstance().GetM_VideoInfoList(Top, strWhere, filedOrder); }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public static DataTable GetM_VideoInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName) { return DatabaseProvider.GetInstance().GetM_VideoInfoList(PageSize, PageIndex, strWhere, out  pagetotal, OrderType, showFName); }
        #endregion

        #region 交易确认收货费用信息
        public static bool ExistsM_ConfirmFeeInfo(int m_Type, int m_ObjID) { return DatabaseProvider.GetInstance().ExistsM_ConfirmFeeInfo(m_Type, m_ObjID); }
        public static int AddM_ConfirmFeeInfo(M_ConfirmFeeInfo model) { return DatabaseProvider.GetInstance().AddM_ConfirmFeeInfo(model); }
        public static void UpdateM_ConfirmFeeInfo(M_ConfirmFeeInfo model) { DatabaseProvider.GetInstance().UpdateM_ConfirmFeeInfo(model); }
        public static void DeleteM_ConfirmFeeInfo(int m_ConfirmFeeInfoID) { DatabaseProvider.GetInstance().DeleteM_ConfirmFeeInfo(m_ConfirmFeeInfoID); }
        public static M_ConfirmFeeInfo GetM_ConfirmFeeInfoModel(int m_ConfirmFeeInfoID) { return DatabaseProvider.GetInstance().GetM_ConfirmFeeInfoModel(m_ConfirmFeeInfoID); }
        public static DataSet GetM_ConfirmFeeInfoList(string strWhere) { return DatabaseProvider.GetInstance().GetM_ConfirmFeeInfoList(strWhere); }
        public static DataSet GetM_ConfirmFeeInfoList(int Top, string strWhere, string filedOrder) { return DatabaseProvider.GetInstance().GetM_ConfirmFeeInfoList(Top, strWhere, filedOrder); }
        public static DataTable GetM_ConfirmFeeInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName) { return DatabaseProvider.GetInstance().GetM_ConfirmFeeInfoList(PageSize, PageIndex, strWhere, out  pagetotal, OrderType, showFName); }
        #endregion

        #region 物流信息
        public static bool ExistsM_ShippingInfo(int m_ShippingInfoID) { return DatabaseProvider.GetInstance().ExistsM_ShippingInfo(m_ShippingInfoID); }
        public static int AddM_ShippingInfo(M_ShippingInfo model) { return DatabaseProvider.GetInstance().AddM_ShippingInfo(model); }
        public static void UpdateM_ShippingInfo(M_ShippingInfo model) { DatabaseProvider.GetInstance().UpdateM_ShippingInfo(model); }
        public static void DeleteM_ShippingInfo(int m_ShippingInfoID) { DatabaseProvider.GetInstance().DeleteM_ShippingInfo(m_ShippingInfoID); }
        public static M_ShippingInfo GetM_ShippingInfoModel(int m_ShippingInfoID) { return DatabaseProvider.GetInstance().GetM_ShippingInfoModel(m_ShippingInfoID); }
        public static DataSet GetM_ShippingInfoList(string strWhere) { return DatabaseProvider.GetInstance().GetM_ShippingInfoList(strWhere); }
        public static DataSet GetM_ShippingInfoList(int Top, string strWhere, string filedOrder) { return DatabaseProvider.GetInstance().GetM_ShippingInfoList(Top, strWhere, filedOrder); }
        public static DataTable GetM_ShippingInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName) { return DatabaseProvider.GetInstance().GetM_ShippingInfoList(PageSize, PageIndex, strWhere, out  pagetotal, OrderType, showFName); }
        #endregion

        #region 商品类目
        public static bool ExistsM_GoodsCatInfo(int m_ConfigInfoID, long cid) { return DatabaseProvider.GetInstance().ExistsM_GoodsCatInfo(m_ConfigInfoID, cid); }
        public static int AddM_GoodsCatInfo(M_GoodsCatInfo model) { return DatabaseProvider.GetInstance().AddM_GoodsCatInfo(model); }
        public static void UpdateM_GoodsCatInfo(M_GoodsCatInfo model) { DatabaseProvider.GetInstance().UpdateM_GoodsCatInfo(model); }
        public static void DeleteM_GoodsCatInfo(int m_GoodsCatInfoID) { DatabaseProvider.GetInstance().DeleteM_GoodsCatInfo(m_GoodsCatInfoID); }
        public static M_GoodsCatInfo GetM_GoodsCatInfoModel(int m_GoodsCatInfoID) { return DatabaseProvider.GetInstance().GetM_GoodsCatInfoModel(m_GoodsCatInfoID); }
        public static DataSet GetM_GoodsCatInfoList(string strWhere) { return DatabaseProvider.GetInstance().GetM_GoodsCatInfoList(strWhere); }
        public static DataSet GetM_GoodsCatInfoList(int Top, string strWhere, string filedOrder) { return DatabaseProvider.GetInstance().GetM_GoodsCatInfoList(Top, strWhere, filedOrder); }
        public static DataTable GetM_GoodsCatInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName) { return DatabaseProvider.GetInstance().GetM_GoodsCatInfoList(PageSize, PageIndex, strWhere, out  pagetotal, OrderType, showFName); }

        /// <summary>
        /// 批量添加商品类目
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static bool AddM_GoodsCatInfoByDataTable(DataTable dt, int m_ConfigInfoID)
        {
            return DatabaseProvider.GetInstance().AddM_GoodsCatInfoByDataTable(dt, m_ConfigInfoID);
        }
        /// <summary>
        /// 取商品类目最后更新时间
        /// </summary>
        /// <returns></returns>
        public static DateTime GetM_GoodsCatLastTime(int m_ConfigInfoID)
        {
            return DatabaseProvider.GetInstance().GetM_GoodsCatLastTime(m_ConfigInfoID);
        }
        /// <summary>
        /// 清理商品类目库
        /// </summary>
        /// <param name="m_ConfigInfoID"></param>
        public static void DeleteM_GoodsCatAll(int m_ConfigInfoID)
        {
            DatabaseProvider.GetInstance().DeleteM_GoodsCatAll(m_ConfigInfoID);
        }
        #endregion

        #region 快递模板
        public static bool ExistsM_ExpressTemplatesInfo(string mName)
        {
            return DatabaseProvider.GetInstance().ExistsM_ExpressTemplatesInfo(mName);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddM_ExpressTemplatesInfo(M_ExpressTemplatesInfo model)
        {
            return DatabaseProvider.GetInstance().AddM_ExpressTemplatesInfo(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool UpdateM_ExpressTemplatesInfo(M_ExpressTemplatesInfo model)
        {
            return DatabaseProvider.GetInstance().UpdateM_ExpressTemplatesInfo(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static bool DeleteM_ExpressTemplatesInfo(int m_ExpressTemplatesID)
        {
            return DatabaseProvider.GetInstance().DeleteM_ExpressTemplatesInfo(m_ExpressTemplatesID);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static bool DeleteM_ExpressTemplatesInfoList(string m_ExpressTemplatesIDlist)
        {
            if (m_ExpressTemplatesIDlist.Trim() != "")
            {
                m_ExpressTemplatesIDlist = "," + m_ExpressTemplatesIDlist + ",";
                m_ExpressTemplatesIDlist = Utils.ReSQLSetTxt(m_ExpressTemplatesIDlist);
                return DatabaseProvider.GetInstance().DeleteM_ExpressTemplatesInfoList(m_ExpressTemplatesIDlist);
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static M_ExpressTemplatesInfo GetM_ExpressTemplatesInfoModel(int m_ExpressTemplatesID)
        {
            return DatabaseProvider.GetInstance().GetM_ExpressTemplatesInfoModel(m_ExpressTemplatesID);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataSet GetM_ExpressTemplatesInfoList(string strWhere)
        {
            return DatabaseProvider.GetInstance().GetM_ExpressTemplatesInfoList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public static DataSet GetM_ExpressTemplatesInfoList(int Top, string strWhere, string filedOrder)
        {
            return DatabaseProvider.GetInstance().GetM_ExpressTemplatesInfoList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public static DataTable GetM_ExpressTemplatesInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
        {
            return DatabaseProvider.GetInstance().GetM_ExpressTemplatesInfoList(PageSize, PageIndex, strWhere, out  pagetotal, OrderType, showFName);
        }

        #region 系统公共快递模板
        /// <summary>
        /// 单据步骤为DataTable
        /// </summary>
        public static DataTable GetPublicExpressTemplates()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("ID", typeof(string));
            dt.Columns.Add("Data", typeof(string));
            dt.Columns.Add("Pic", typeof(string));
            dt.Columns.Add("Width", typeof(string));
            dt.Columns.Add("Height", typeof(string));
            dt.Columns.Add("ExpName", typeof(string));

            foreach (PublicExpressTemplatess.Rewrite _PublicExpressTemplates in PublicExpressTemplatess.GetPublicExpressTemplatess().PublicExpressTemplates)
            {
                DataRow dr = dt.NewRow();
                dr["Name"] = _PublicExpressTemplates.Name;
                dr["ID"] = _PublicExpressTemplates.ID;
                dr["Data"] = _PublicExpressTemplates.Data;
                dr["Pic"] = _PublicExpressTemplates.Pic;
                dr["Width"] = _PublicExpressTemplates.Width;
                dr["Height"] = _PublicExpressTemplates.Height;
                dr["ExpName"] = _PublicExpressTemplates.ExpName;

                dt.Rows.Add(dr);
            }
            dt.AcceptChanges();
            return dt;
        }
        public static string GetPublicExpressTemplatesJson()
        {
            string reVal = "";
            DataTable dt = GetPublicExpressTemplates();
            if (dt != null)
            {
                //reVal = Utils.DataTableToJSON(dt).ToString();
                List<Hashtable> tList = new List<Hashtable>();
                foreach (DataRow dr in dt.Rows)
                {
                    Hashtable ht = new Hashtable();
                    ht["Name"] = dr["Name"].ToString();
                    ht["ID"] = dr["ID"].ToString();
                    ht["Data"] = dr["Data"].ToString();
                    ht["Pic"] = dr["Pic"].ToString();
                    ht["Width"] = dr["Width"].ToString();
                    ht["Height"] = dr["Height"].ToString();
                    ht["ExpName"] = dr["ExpName"].ToString();
                    tList.Add(ht);
                    //eVal += "{\"Name\":\"" + dr["Name"].ToString() + "\",\"ID\":\"" + dr["ID"].ToString() + "\",\"Data\":\"" + dr["Data"].ToString() + "\",\"Pic\":\"" + dr["Pic"].ToString() + "\",\"Width\":\"" + dr["Width"].ToString() + "\",\"Height\":\"" + dr["Height"].ToString() + "\",\"ExpName\":\"" + dr["ExpName"].ToString() + "\"},";
                }
                reVal = JavaScriptConvert.SerializeObject(tList);
                /*
                if (reVal.Trim() != "")
                {
                    reVal = Utils.ReSQLSetTxt(reVal);
                }
                 */
            }
            return "{\"PublicExpressTemplates\":" + reVal + "}";
        }
        /// <summary>
        /// 单据步骤
        /// </summary>
        public class PublicExpressTemplatess
        {
            private static object lockHelper = new object();
            private static volatile PublicExpressTemplatess instance = null;
            string Files = HttpContext.Current.Server.MapPath(BaseConfigs.GetSysPath + "config/ExpressTemplates.config");
            private System.Collections.ArrayList _PublicExpressTemplatess;
            public System.Collections.ArrayList PublicExpressTemplates
            {
                get
                {
                    return _PublicExpressTemplatess;
                }
                set
                {
                    _PublicExpressTemplatess = value;
                }
            }
            private PublicExpressTemplatess()
            {
                PublicExpressTemplates = new ArrayList();
                XmlDocument xml = new XmlDocument();
                xml.Load(Files);
                try
                {
                    XmlNode root = xml.SelectSingleNode("//ExpressTemplates");
                    foreach (XmlNode n in root.ChildNodes)
                    {
                        if (n.NodeType != XmlNodeType.Comment && n.Name.ToLower() == "template")
                        {
                            XmlAttribute _Name = n.Attributes["name"];
                            XmlAttribute _ID = n.Attributes["id"];
                            XmlAttribute _Pic = n.Attributes["Pic"];
                            XmlAttribute _ExpName = n.Attributes["ExpName"];
                            XmlAttribute _Width = n.Attributes["Width"];
                            XmlAttribute _Height = n.Attributes["Height"];

                            if (_Name != null && _ID != null)
                            {
                                PublicExpressTemplates.Add(new Rewrite(_Name.Value, _ID.Value, n.InnerText, _Pic.Value, _Width.Value, _Height.Value, _ExpName.Value));
                            }
                        }
                    }
                }
                finally
                {
                    xml = null;
                }
            }
            public static PublicExpressTemplatess GetPublicExpressTemplatess()
            {
                if (instance == null)
                {
                    lock (lockHelper)
                    {
                        if (instance == null)
                        {
                            instance = new PublicExpressTemplatess();
                        }
                    }
                }
                return instance;

            }

            public static void SetInstance(PublicExpressTemplatess anInstance)
            {
                if (anInstance != null)
                    instance = anInstance;
            }

            public static void SetInstance()
            {
                SetInstance(new PublicExpressTemplatess());
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

                private string _Pic;
                public string Pic
                {
                    get
                    {
                        return _Pic;
                    }
                    set
                    {
                        _Pic = value;
                    }
                }

                private string _Width;
                public string Width
                {
                    get
                    {
                        return _Width;
                    }
                    set
                    {
                        _Width = value;
                    }
                }

                private string _Height;
                public string Height
                {
                    get
                    {
                        return _Height;
                    }
                    set
                    {
                        _Height = value;
                    }
                }

                private string _ExpName;
                public string ExpName
                {
                    get
                    {
                        return _ExpName;
                    }
                    set
                    {
                        _ExpName = value;
                    }
                }

                private string _Data;
                public string Data
                {
                    get
                    {
                        return _Data;
                    }
                    set
                    {
                        _Data = value;
                    }
                }
                #endregion
                #region 构造函数
                public Rewrite(string name, string id, string data, string Pic, string Width, string Height, string ExpName)
                {
                    _Name = name;
                    _ID = id;
                    _Data = data;
                    _Pic = Pic;
                    _Width = Width;
                    _Height = Height;
                    _ExpName = ExpName;
                }
                #endregion
            }
        }
        #endregion

        #endregion

        #region 发货单
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool ExistsM_SendGoodsInfo(int OrderID, string m_TradeInfoID)
        {
            return DatabaseProvider.GetInstance().ExistsM_SendGoodsInfo(OrderID, m_TradeInfoID);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddM_SendGoodsInfo(M_SendGoodsInfo model)
        {
            return DatabaseProvider.GetInstance().AddM_SendGoodsInfo(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool UpdateM_SendGoodsInfo(M_SendGoodsInfo model)
        {
            return DatabaseProvider.GetInstance().UpdateM_SendGoodsInfo(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static bool DeleteM_SendGoodsInfo(int m_SendGoodsID)
        {
            return DatabaseProvider.GetInstance().DeleteM_SendGoodsInfo(m_SendGoodsID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static bool DeleteM_SendGoodsInfoList(string m_SendGoodsIDlist)
        {
            if (m_SendGoodsIDlist.Trim() != "")
            {
                m_SendGoodsIDlist = "," + m_SendGoodsIDlist + ",";
                m_SendGoodsIDlist = Utils.ReSQLSetTxt(m_SendGoodsIDlist);
                return DatabaseProvider.GetInstance().DeleteM_SendGoodsInfoList(m_SendGoodsIDlist);
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static M_SendGoodsInfo GetM_SendGoodsInfoModel(int m_SendGoodsID)
        {
            return DatabaseProvider.GetInstance().GetM_SendGoodsInfoModel(m_SendGoodsID);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataSet GetM_SendGoodsInfoList(string strWhere)
        {
            return DatabaseProvider.GetInstance().GetM_SendGoodsInfoList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public static DataSet GetM_SendGoodsInfoList(int Top, string strWhere, string filedOrder)
        {
            return DatabaseProvider.GetInstance().GetM_SendGoodsInfoList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public static DataTable GetM_SendGoodsInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
        {
            return DatabaseProvider.GetInstance().GetM_SendGoodsInfoList(PageSize, PageIndex, strWhere, out  pagetotal, OrderType, showFName);
        }
        /// <summary>
        /// 网购交易系统编号返回网购发货单
        /// </summary>
        /// <param name="m_TradeInfoID"></param>
        /// <returns></returns>
        public static M_SendGoodsInfo GetM_SendGoodsInfoModelBym_TradeInfoID(int m_TradeInfoID)
        {
            return DatabaseProvider.GetInstance().GetM_SendGoodsInfoModelBym_TradeInfoID(m_TradeInfoID);
        }
        /// <summary>
        /// 指定发货单返回网购发货单
        /// </summary>
        /// <param name="OrderID"></param>
        /// <returns></returns>
        public static M_SendGoodsInfo GetM_SendGoodsInfoModelByOrderID(int OrderID)
        {
            return DatabaseProvider.GetInstance().GetM_SendGoodsInfoModelByOrderID(OrderID);
        }
        #endregion
    }
}
