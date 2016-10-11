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
    public class tbStaffInfo
    {
        #region  StaffInfo
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool ExistsStaffInfo(string sName)
        {
            return DatabaseProvider.GetInstance().ExistsStaffInfo(sName);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddStaffInfo(StaffInfo model)
        {
            return DatabaseProvider.GetInstance().AddStaffInfo(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateStaffInfo(StaffInfo model)
        {
            DatabaseProvider.GetInstance().UpdateStaffInfo(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteStaffInfo(int StaffID)
        {
            DatabaseProvider.GetInstance().DeleteStaffInfo(StaffID);
        }
        /// <summary>
        /// 删除一组数据
        /// </summary>
        public static void DeleteStaffInfo(string StaffID)
        {
            if (StaffID.Trim() != "")
            {
                StaffID = "," + StaffID + ",";
                StaffID = Utils.ReSQLSetTxt(StaffID);
                DatabaseProvider.GetInstance().DeleteStaffInfo(StaffID);
            }
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static StaffInfo GetStaffInfoModel(int StaffID)
        {
            return DatabaseProvider.GetInstance().GetStaffInfoModel(StaffID);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static StaffInfo GetStaffInfoModelByName(string sName)
        {
            return DatabaseProvider.GetInstance().GetStaffInfoModelByName(sName);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static StaffInfo GetStaffInfoModelByUserID(int UserID)
        {
            return DatabaseProvider.GetInstance().GetStaffInfoModelByUserID( UserID);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataSet GetStaffInfoList(string strWhere)
        {
            return DatabaseProvider.GetInstance().GetStaffInfoList(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public static DataTable GetStaffInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
        {
            return DatabaseProvider.GetInstance().GetStaffInfoList(PageSize, PageIndex, strWhere, out pagetotal, OrderType, showFName);
        }

        /// <summary>
        /// 给人员发送邮件
        /// </summary>
        /// <param name="StaffID"></param>
        /// <param name="MailSubject"></param>
        /// <param name="MailMsg"></param>
        public static void SendMailToStaff(int StaffID,string MailSubject, string MailMsg)
        {
            string Mail = tbStaffInfo.GetStaffInfoModel(StaffID).sEmail;
            if (Mail.Trim() != "")
            {
                GeneralConfigInfo configs = Config.GeneralConfigs.GetConfig();
                string[] MailArray = Utils.SplitString(Mail, ",");
                string SendedStr = ",";
                foreach (string _mail in MailArray)
                {
                    if (_mail.Trim() != "")
                    {
                        if (!(SendedStr.IndexOf("," + _mail.Trim() + ",") > -1))
                        {
                            MailQueueService.SendMail(configs.SendMailUserName, configs.SendMailUserPWD, MailSubject, MailMsg, configs.CompanyName, configs.SendMailUserName, _mail.Trim(), _mail.Trim(), true, DateTime.Now.AddSeconds(10));
                            SendedStr += _mail.Trim() + ",";
                        }
                    }
                }
            }
        }
        #endregion

        #region StaffDataInfo
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool ExistsStaffDataInfo(int StaffID){return DatabaseProvider.GetInstance().ExistsStaffDataInfo( StaffID);}
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddStaffDataInfo(StaffDataInfo model){return DatabaseProvider.GetInstance().AddStaffDataInfo( model);}
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool UpdateStaffDataInfo(StaffDataInfo model){return DatabaseProvider.GetInstance().UpdateStaffDataInfo( model);}
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static bool DeleteStaffDataInfo(int StaffDataID){return DatabaseProvider.GetInstance().DeleteStaffDataInfo( StaffDataID);}
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static bool DeleteStaffDataInfoList(string StaffDataIDlist){return DatabaseProvider.GetInstance().DeleteStaffDataInfoList( StaffDataIDlist);}
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static StaffDataInfo GetStaffDataInfoModel(int StaffDataID){return DatabaseProvider.GetInstance().GetStaffDataInfoModel( StaffDataID);}
        public static StaffDataInfo GetStaffDataInfoModelByStaffID(int StaffID)
        { 
            return DatabaseProvider.GetInstance().GetStaffDataInfoModelByStaffID(StaffID);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataSet GetStaffDataInfoList(string strWhere){return DatabaseProvider.GetInstance().GetStaffDataInfoList( strWhere);}
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public static DataSet GetStaffDataInfoList(int Top, string strWhere, string filedOrder){return DatabaseProvider.GetInstance().GetStaffDataInfoList( Top,  strWhere,  filedOrder);}
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public static DataTable GetStaffDataInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName){return DatabaseProvider.GetInstance().GetStaffDataInfoList( PageSize,  PageIndex,  strWhere, out  pagetotal,  OrderType,  showFName);}
        #endregion

        #region StaffEduDataInfo
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool ExistsStaffEduDataInfo(int StaffID, string eDate, string eSchools){return DatabaseProvider.GetInstance().ExistsStaffEduDataInfo( StaffID,  eDate,  eSchools);}
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddStaffEduDataInfo(StaffEduDataInfo model){return DatabaseProvider.GetInstance().AddStaffEduDataInfo( model);}
        public static bool AddStaffEduDataInfoByJson(StaffEduDataJson EduDataJson)
        { 
            return DatabaseProvider.GetInstance().AddStaffEduDataInfoByJson( EduDataJson);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool UpdateStaffEduDataInfo(StaffEduDataInfo model){return DatabaseProvider.GetInstance().UpdateStaffEduDataInfo( model);}
        public static bool UpdateStaffEduDataInfoByJson(StaffEduDataJson EduDataJson, int StaffID)
        {
            return DatabaseProvider.GetInstance().UpdateStaffEduDataInfoByJson(EduDataJson, StaffID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static bool DeleteStaffEduDataInfo(int StaffEduDataID){return DatabaseProvider.GetInstance().DeleteStaffEduDataInfo( StaffEduDataID);}
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static bool DeleteStaffEduDataInfoList(string StaffEduDataIDlist){return DatabaseProvider.GetInstance().DeleteStaffEduDataInfoList( StaffEduDataIDlist);}
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static StaffEduDataInfo GetStaffEduDataInfoModel(int StaffEduDataID){return DatabaseProvider.GetInstance().GetStaffEduDataInfoModel( StaffEduDataID);}
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataSet GetStaffEduDataInfoList(string strWhere){return DatabaseProvider.GetInstance().GetStaffEduDataInfoList( strWhere);}
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public static DataSet GetStaffEduDataInfoList(int Top, string strWhere, string filedOrder){return DatabaseProvider.GetInstance().GetStaffEduDataInfoList( Top,  strWhere,  filedOrder);}
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public static DataTable GetStaffEduDataInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName){return DatabaseProvider.GetInstance().GetStaffEduDataInfoList( PageSize,  PageIndex,  strWhere, out  pagetotal,  OrderType,  showFName);}
        #endregion

        #region StaffFamilyDataInfo
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool ExistsStaffFamilyDataInfo(int StaffID, string fName, string fTitle){return DatabaseProvider.GetInstance().ExistsStaffFamilyDataInfo( StaffID,  fName,  fTitle);}
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddStaffFamilyDataInfo(StaffFamilyDataInfo model){return DatabaseProvider.GetInstance().AddStaffFamilyDataInfo( model);}
        public static bool AddStaffFamilyDataInfoByJson(StaffFamilyDataJson FamilyDataJson)
        { 
            return DatabaseProvider.GetInstance().AddStaffFamilyDataInfoByJson( FamilyDataJson);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool UpdateStaffFamilyDataInfo(StaffFamilyDataInfo model){return DatabaseProvider.GetInstance().UpdateStaffFamilyDataInfo( model);}
        public static bool UpdateStaffFamilyDataInfoByJson(StaffFamilyDataJson FamilyDataJson, int StaffID)
        {
            return DatabaseProvider.GetInstance().UpdateStaffFamilyDataInfoByJson(FamilyDataJson, StaffID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static bool DeleteStaffFamilyDataInfo(int StaffFamilyDataID){return DatabaseProvider.GetInstance().DeleteStaffFamilyDataInfo( StaffFamilyDataID);}
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static bool DeleteStaffFamilyDataInfoList(string StaffFamilyDataIDlist){return DatabaseProvider.GetInstance().DeleteStaffFamilyDataInfoList( StaffFamilyDataIDlist);}
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static StaffFamilyDataInfo GetStaffFamilyDataInfoModel(int StaffFamilyDataID){return DatabaseProvider.GetInstance().GetStaffFamilyDataInfoModel( StaffFamilyDataID);}
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataSet GetStaffFamilyDataInfoList(string strWhere){return DatabaseProvider.GetInstance().GetStaffFamilyDataInfoList( strWhere);}
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public static DataSet GetStaffFamilyDataInfoList(int Top, string strWhere, string filedOrder){return DatabaseProvider.GetInstance().GetStaffFamilyDataInfoList( Top,  strWhere,  filedOrder);}
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public static DataTable GetStaffFamilyDataInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName){return DatabaseProvider.GetInstance().GetStaffFamilyDataInfoList( PageSize,  PageIndex,  strWhere, out  pagetotal,  OrderType,  showFName);}
        #endregion

        #region StaffWorkDataInfo
        // <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool ExistsStaffWorkDataInfo(int StaffID, string wDate, string wEnterprise){return DatabaseProvider.GetInstance().ExistsStaffWorkDataInfo( StaffID,  wDate,  wEnterprise);}
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddStaffWorkDataInfo(StaffWorkDataInfo model){return DatabaseProvider.GetInstance().AddStaffWorkDataInfo( model);}
        public static bool AddStaffWorkDataInfoByJson(StaffWorkDataJson WorkDataJson)
        { 
            return DatabaseProvider.GetInstance().AddStaffWorkDataInfoByJson( WorkDataJson);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool UpdateStaffWorkDataInfo(StaffWorkDataInfo model){return DatabaseProvider.GetInstance().UpdateStaffWorkDataInfo( model);}
        public static bool UpdateStaffWorkDataInfoByJson(StaffWorkDataJson WorkDataJson, int StaffID)
        {
            return DatabaseProvider.GetInstance().UpdateStaffWorkDataInfoByJson(WorkDataJson, StaffID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static bool DeleteStaffWorkDataInfo(int StaffWorkDataID){return DatabaseProvider.GetInstance().DeleteStaffWorkDataInfo( StaffWorkDataID);}
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static bool DeleteStaffWorkDataInfoList(string StaffWorkDataIDlist){return DatabaseProvider.GetInstance().DeleteStaffWorkDataInfoList( StaffWorkDataIDlist);}
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static StaffWorkDataInfo GetStaffWorkDataInfoModel(int StaffWorkDataID){return DatabaseProvider.GetInstance().GetStaffWorkDataInfoModel( StaffWorkDataID);}
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataSet GetStaffWorkDataInfoList(string strWhere){return DatabaseProvider.GetInstance().GetStaffWorkDataInfoList( strWhere);}
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public static DataSet GetStaffWorkDataInfoList(int Top, string strWhere, string filedOrder){return DatabaseProvider.GetInstance().GetStaffWorkDataInfoList( Top,  strWhere,  filedOrder);}
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public static DataTable GetStaffWorkDataInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName){return DatabaseProvider.GetInstance().GetStaffWorkDataInfoList( PageSize,  PageIndex,  strWhere, out  pagetotal,  OrderType,  showFName);}
        #endregion

        #region StaffAnalysisDataInfo
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddStaffAnalysisDataInfo(StaffAnalysisDataInfo model){return DatabaseProvider.GetInstance().AddStaffAnalysisDataInfo( model);}
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool UpdateStaffAnalysisDataInfo(StaffAnalysisDataInfo model){return DatabaseProvider.GetInstance().UpdateStaffAnalysisDataInfo( model);}
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static bool DeleteStaffAnalysisDataInfo(int StaffAnalysisDataID){return DatabaseProvider.GetInstance().DeleteStaffAnalysisDataInfo( StaffAnalysisDataID);}
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static bool DeleteStaffAnalysisDataInfoList(string StaffAnalysisDataIDlist){return DatabaseProvider.GetInstance().DeleteStaffAnalysisDataInfoList( StaffAnalysisDataIDlist);}
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static StaffAnalysisDataInfo GetStaffAnalysisDataInfoModel(int StaffAnalysisDataID){return DatabaseProvider.GetInstance().GetStaffAnalysisDataInfoModel( StaffAnalysisDataID);}
        public static StaffAnalysisDataInfo GetStaffAnalysisDataInfoModelByStaffID(int StaffID) { return DatabaseProvider.GetInstance().GetStaffAnalysisDataInfoModelByStaffID(StaffID); }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataSet GetStaffAnalysisDataInfoList(string strWhere){return DatabaseProvider.GetInstance().GetStaffAnalysisDataInfoList( strWhere);}
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public static DataSet GetStaffAnalysisDataInfoList(int Top, string strWhere, string filedOrder){return DatabaseProvider.GetInstance().GetStaffAnalysisDataInfoList( Top,  strWhere,  filedOrder);}
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public static DataTable GetStaffAnalysisDataInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName){return DatabaseProvider.GetInstance().GetStaffAnalysisDataInfoList( PageSize,  PageIndex,  strWhere, out  pagetotal,  OrderType,  showFName);}
        #endregion

        #region 人员岗位_月报表
        /// <summary>
        /// 获得人员岗位上离岗年份
        /// </summary>
        /// <returns></returns>
        public static DataTable getStaffDate()
        {
            return DatabaseProvider.GetInstance().getStaffDate();
        }
        /// <summary>
        /// 获得去年所有加入人员数量
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DataTable getStaffLastYear(DateTime dt)
        {
            return DatabaseProvider.GetInstance().getStaffLastYear(dt);
        }
        /// <summary>
        /// 获得每月的人员加入总数
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DataTable getStaffOfMonth(string dt)
        {
            return DatabaseProvider.GetInstance().getStaffOfMonth(dt);
        }
        /// <summary>
        /// 获得人员上下岗明细
        /// </summary>
        /// <param name="bDate"></param>
        /// <param name="eDate"></param>
        /// <param name="dType"></param>
        /// <returns></returns>
        public static DataTable getStaffDetails(DateTime bDate, DateTime eDate, int dType)
        {
            return DatabaseProvider.GetInstance().getStaffDetails(bDate, eDate, dType);
        }
        #endregion
    }
}
