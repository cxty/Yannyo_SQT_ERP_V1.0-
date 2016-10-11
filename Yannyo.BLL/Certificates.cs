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
    public class Certificates
    {
        /// <summary>
        /// 返回最新未使用的凭证号
        /// </summary>
        /// <returns></returns>
        public static string GetNewNum()
        {
            GeneralConfigInfo ManageConfig = GeneralConfigs.GetConfig();
            ManageConfig.CertificateCode = (Convert.ToInt32(Config.GeneralConfigs.GetConfig().CertificateCode.Trim()) + 1).ToString();

            GeneralConfigs.Serialiaze(ManageConfig, Utils.GetMapPath(BaseConfigs.GetSysPath + "config/general.config"));
            BaseConfigs.ResetConfig();

            return ManageConfig.CertificateCode;
        }

        /// <summary>
        /// 根据时间返回新的凭证序号,已自动加1
        /// </summary>
        /// <param name="sDate">时间</param>
        /// <returns></returns>
        public static int GetCertificateNewNumber(DateTime sDate)
        {
            return DatabaseProvider.GetInstance().GetCertificateNewNumber(sDate);
        }

         /// <summary>
        /// 验证凭证序号是否重复
        /// </summary>
        /// <param name="sDate"></param>
        /// <param name="cNumber"></param>
        /// <returns></returns>
        public static bool CheckCertificateNumber(DateTime sDate, int cNumber)
        {
            return DatabaseProvider.GetInstance().CheckCertificateNumber(sDate, cNumber);
        }
        /// <summary>
        /// 当前最大凭证日期
        /// </summary>
        /// <returns></returns>
        public static DateTime GetMaxCertificateData()
        {
            return DatabaseProvider.GetInstance().GetMaxCertificateData();
        }
        /// <summary>
        /// 去凭证最大日期,排除指定ID
        /// </summary>
        /// <returns></returns>
        public static DateTime GetMaxCertificateData(Int32 CertificateID)
        {
            return DatabaseProvider.GetInstance().GetMaxCertificateData(CertificateID);
        }
        #region 凭证头
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool ExistsCertificateInfo(string cCode)
        {
            return DatabaseProvider.GetInstance().ExistsCertificateInfo(cCode);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddCertificateInfo(CertificateInfo model)
        {
            return DatabaseProvider.GetInstance().AddCertificateInfo(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateCertificateInfo(CertificateInfo model)
        {
            DatabaseProvider.GetInstance().UpdateCertificateInfo(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteCertificateInfo(int CertificateID)
        {
            DatabaseProvider.GetInstance().DeleteCertificateInfo(CertificateID);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static CertificateInfo GetCertificateInfoModel(int CertificateID)
        {
            return DatabaseProvider.GetInstance().GetCertificateInfoModel(CertificateID);
        }
        public static CertificateInfo GetCertificateInfoModel(string cCode)
        {
            return DatabaseProvider.GetInstance().GetCertificateInfoModel(cCode);
        }
        /// <summary>
        /// 金额合计
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static decimal GetCertificateSumMoney(string strWhere)
        {
            return DatabaseProvider.GetInstance().GetCertificateSumMoney(strWhere);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataSet GetCertificateInfoList(string strWhere)
        {
            return DatabaseProvider.GetInstance().GetCertificateInfoList(strWhere);
        }
        public static DataSet GetCertificateInfoListByObject(int cObject, int cObjectID)
        {
            return DatabaseProvider.GetInstance().GetCertificateInfoList(" cObject=" + cObject + " and cObjectID=" + cObjectID + " and cState=0 order by cDateTime desc");
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public static DataSet GetCertificateInfoList(int Top, string strWhere, string filedOrder)
        {
            return DatabaseProvider.GetInstance().GetCertificateInfoList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public static DataTable GetCertificateInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
        {
            return DatabaseProvider.GetInstance().GetCertificateInfoList(PageSize, PageIndex, strWhere, out  pagetotal, OrderType, showFName);
        }
        public static DataTable GetCertificateInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName, string OrderFldName)
        {
            return DatabaseProvider.GetInstance().GetCertificateInfoList(PageSize, PageIndex, strWhere, out  pagetotal, OrderType, showFName, OrderFldName);
        }
        
        /// <summary>
        /// 验证指定单据是否附加凭证信息
        /// </summary>
        /// <param name="OrderID"></param>
        /// <returns></returns>
        public static bool CheckCertificateByOrderID(int OrderID)
        {
            return DatabaseProvider.GetInstance().CheckCertificateByOrderID(OrderID);
        }
        /// <summary>
        /// 移除凭证随附信息
        /// </summary>
        /// <param name="CertificateID"></param>
        public static void RemoveCertificateToObject(int CertificateID)
        {
            DatabaseProvider.GetInstance().RemoveCertificateToObject(CertificateID);
        }
        /// <summary>
        /// 设置凭证随附信息
        /// </summary>
        /// <param name="CertificateID"></param>
        public static void SetCertificateToObject(int CertificateID, int cObject, int cObjectID)
        {
            DatabaseProvider.GetInstance().SetCertificateToObject(CertificateID, cObject, cObjectID);
        }
        /// <summary>
        /// 返回指定单号预付款合计金额
        /// </summary>
        /// <param name="OrderID"></param>
        /// <returns></returns>
        public static decimal GetPrepayMoneyByOrderID(int OrderID)
        {
            return DatabaseProvider.GetInstance().GetPrepayMoneyByOrderID(OrderID);
        }
        /// <summary>
        /// 更新凭证头信息
        /// </summary>
        /// <param name="model"></param>
        public static void UpdateCertificateInfoNOListData(CertificateInfo model)
        {
             DatabaseProvider.GetInstance().UpdateCertificateInfoNOListData( model);
        }

	/// <summary>
        /// 更新步骤
        /// </summary>
        /// <param name="CertificateID"></param>
        /// <param name="cSteps"></param>
        public static void SetCertificateSteps(int CertificateID, int cSteps)
        { 
            DatabaseProvider.GetInstance().SetCertificateSteps( CertificateID,  cSteps);
        }

        /// <summary>
        /// 获取指定凭证编号的前后凭证编号
        /// </summary>
        /// <param name="CertificateID"></param>
        /// <returns></returns>
        public static long[] GetCertificateUpDownID(int CertificateID)
        {
            return DatabaseProvider.GetInstance().GetCertificateUpDownID(CertificateID);
        }
        #endregion
        #region 凭证内容
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool ExistsCertificateDataInfo(int CertificateID, int FeesSubjectID, string cdName)
        {
            return DatabaseProvider.GetInstance().ExistsCertificateDataInfo(CertificateID, FeesSubjectID, cdName);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddCertificateDataInfo(CertificateDataInfo model)
        {
            return DatabaseProvider.GetInstance().AddCertificateDataInfo(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateCertificateDataInfo(CertificateDataInfo model)
        {
            DatabaseProvider.GetInstance().UpdateCertificateDataInfo(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteCertificateDataInfo(int CertificateDataID)
        {
            DatabaseProvider.GetInstance().DeleteCertificateDataInfo(CertificateDataID);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static CertificateDataInfo GetCertificateDataInfoModel(int CertificateDataID)
        {
            return DatabaseProvider.GetInstance().GetCertificateDataInfoModel(CertificateDataID);
        }
         /// <summary>
        /// 取指定条件下的合计数
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static decimal[] GetCertificateDataSumMoney(string strWhere)
        {
             return DatabaseProvider.GetInstance().GetCertificateDataSumMoney( strWhere);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataSet GetCertificateDataInfoList(string strWhere)
        {
            return DatabaseProvider.GetInstance().GetCertificateDataInfoList(strWhere);
        }
        public static DataSet GetCertificateDataInfoListB(string strWhere)
        {
            return DatabaseProvider.GetInstance().GetCertificateDataInfoListB(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public static DataSet GetCertificateDataInfoList(int Top, string strWhere, string filedOrder)
        {
            return DatabaseProvider.GetInstance().GetCertificateDataInfoList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public static DataTable GetCertificateDataInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
        {
            return DatabaseProvider.GetInstance().GetCertificateDataInfoList(PageSize, PageIndex, strWhere, out  pagetotal, OrderType, showFName);
        }
        #endregion
        #region 凭证照片
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddCertificatePicInfo(CertificatePicInfo model)
        {
            return DatabaseProvider.GetInstance().AddCertificatePicInfo(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateCertificatePicInfo(CertificatePicInfo model)
        {
            DatabaseProvider.GetInstance().UpdateCertificatePicInfo(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteCertificatePicInfo(int CertificatePicID)
        {
            DatabaseProvider.GetInstance().DeleteCertificatePicInfo(CertificatePicID);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static CertificatePicInfo GetCertificatePicInfoModel(int CertificatePicID)
        {
            return DatabaseProvider.GetInstance().GetCertificatePicInfoModel(CertificatePicID);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataSet GetCertificatePicInfoList(string strWhere)
        {
            return DatabaseProvider.GetInstance().GetCertificatePicInfoList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public static DataSet GetCertificatePicInfoList(int Top, string strWhere, string filedOrder)
        {
            return DatabaseProvider.GetInstance().GetCertificatePicInfoList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public static DataTable GetCertificatePicInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
        {
            return DatabaseProvider.GetInstance().GetCertificatePicInfoList(PageSize, PageIndex, strWhere, out  pagetotal, OrderType, showFName);
        }
        /// <summary>
        /// 更新指定凭证照片的凭证编号
        /// </summary>
        /// <param name="CertificatePicID"></param>
        /// <param name="CertificateID"></param>
        public static void UpdateCertificatePicCertificateID(int CertificatePicID, int CertificateID)
        { 
            DatabaseProvider.GetInstance().UpdateCertificatePicCertificateID( CertificatePicID,  CertificateID);
        }
        #endregion
        #region 凭证操作记录
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddCertificateWorkingLog(CertificateWorkingLogInfo model) { return DatabaseProvider.GetInstance().AddCertificateWorkingLog(model); }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool UpdateCertificateWorkingLog(CertificateWorkingLogInfo model) { return DatabaseProvider.GetInstance().UpdateCertificateWorkingLog( model);}
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static bool DeleteCertificateWorkingLog(int CertificateWorkingLogID) { return DatabaseProvider.GetInstance().DeleteCertificateWorkingLog( CertificateWorkingLogID) ;}
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static bool DeleteCertificateWorkingLogList(string CertificateWorkingLogIDlist) { return DatabaseProvider.GetInstance().DeleteCertificateWorkingLogList( CertificateWorkingLogIDlist);}
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static CertificateWorkingLogInfo GetCertificateWorkingLogModel(int CertificateWorkingLogID) { return DatabaseProvider.GetInstance().GetCertificateWorkingLogModel( CertificateWorkingLogID);}
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataSet GetCertificateWorkingLogList(string strWhere) { return DatabaseProvider.GetInstance().GetCertificateWorkingLogList( strWhere);}
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public static DataSet GetCertificateWorkingLogList(int Top, string strWhere, string filedOrder) { return DatabaseProvider.GetInstance().GetCertificateWorkingLogList( Top,  strWhere,  filedOrder) ;}
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public static DataTable GetCertificateWorkingLogList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName) { return DatabaseProvider.GetInstance().GetCertificateWorkingLogList( PageSize,  PageIndex,  strWhere, out  pagetotal,  OrderType,  showFName);}
        /// <summary>
        /// 取指定类型记录下的记录
        /// </summary>
        /// <param name="CertificateID"></param>
        /// <param name="cType"></param>
        /// <returns></returns>
        public static CertificateWorkingLogInfo GetCertificateWorkingLogUserID(int CertificateID, int cType)
        { 
            return DatabaseProvider.GetInstance().GetCertificateWorkingLogUserID( CertificateID,  cType);
        }
        /// <summary>
        /// 取指定凭证最后一次审核时间
        /// </summary>
        /// <param name="CertificateID"></param>
        /// <returns></returns>
        public static DateTime GetLastVerifyTime(int CertificateID)
        { 
            return DatabaseProvider.GetInstance().GetLastVerifyTime( CertificateID);
        }
        #endregion

        #region 凭证汇总
        public static DataTable GetCertificate_Summary(DateTime bDate, DateTime eDate, out int cCount, out string bCode, out string eCode)
        { 
        return DatabaseProvider.GetInstance().GetCertificate_Summary( bDate,  eDate, out  cCount, out  bCode, out  eCode);
        }
        #endregion
    }
}
