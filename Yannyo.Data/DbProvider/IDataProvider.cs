using System;
using System.Data;
using System.Text;

#if NET1
#else
using Yannyo.Common.Generic;
#endif

using Yannyo.Entity;
using System.Data.Common;

namespace Yannyo.Data
{
    public interface IDataProvider
    {
        #region 全局
        /// <summary>
        /// 设置上次任务计划的执行时间
        /// </summary>
        /// <param name="key">任务的标识</param>
        /// <param name="servername">主机名</param>
        /// <param name="lastexecuted">最后执行时间</param>
        void SetLastExecuteScheduledEventDateTime(string key, string servername, DateTime lastexecuted);
        /// <summary>
        /// 获取上次任务计划的执行时间
        /// </summary>
        /// <param name="key">任务的标识</param>
        /// <param name="servername">主机名</param>
        /// <returns></returns>
        DateTime GetLastExecuteScheduledEventDateTime(string key, string servername);
        /// <summary>
        /// 获取指定数据表,指定条件数据集合
        /// </summary>
        /// <param name="TableName">表名</param>
        /// <param name="OutName">输出字段名</param>
        /// <param name="InName">输入字段名</param>
        /// <param name="WhereStr">附加查询条件</param>
        string GetDataFieldStr(string TableName, string OutName, string InName, int InValue, string WhereStr);
       
        string GetDataFieldStrReverse(string TableName, string OutName, string InName, int InValue, string WhereStr);

        /// <summary>
        /// 获取指定数据表,指定条件数据集合
        /// </summary>
        /// <param name="TableName">表名</param>
        /// <param name="OutName">输出字段名</param>
        /// <param name="InName">输入字段名</param>
        /// <param name="WhereStr">附加查询条件</param>
        string GetDataFieldStr(string TableName, string OutName, string OutIDName, string InName, int InValue, string WhereStr);
        string GetDataFieldStr(string TableName, string OutName, string OutIDName, string InName, int InValue, string WhereStr,string sStr);
        string GetDataFieldStrReverse(string TableName, string OutName, string OutIDName, string InName, int InValue, string WhereStr);
        #endregion

        #region  ValenceInfo

        /// <summary>
        /// 增加一条数据
        /// </summary>
        int AddValenceInfo(ValenceInfo model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        void UpdateValenceInfo(ValenceInfo model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        void DeleteValenceInfo(int ValenceID);
        /// <summary>
        /// 删除一组数据
        /// </summary>
        void DeleteValenceInfo(string ValenceID);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        ValenceInfo GetValenceInfoModel(int ValenceID);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetValenceInfoList(string strWhere);
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        DataTable GetValenceInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName);
        #endregion

        #region  UserInfo
        /// <summary>
        /// UserInfo
        /// </summary>
        bool ExistsUserInfo(string uName);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int AddUserInfo(UserInfo model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        void UpdateUserInfo(UserInfo model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        void DeleteUserInfo(int UserID);
        /// <summary>
        /// 删除一组数据
        /// </summary>
        void DeleteUserInfo(string UserID);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        UserInfo GetUserInfoModel(int UserID);
		UserInfo GetUserInfoModelByUserName(string UserName);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetUserInfoList(string strWhere);
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        DataTable GetUserInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName);

        /// <summary>
        /// 检测密码
        /// </summary>
        /// <param name="uid">用户id</param>
        /// <param name="password">密码</param>
        /// <param name="originalpassword">是否非MD5密码</param>
        /// <param name="UserGroupsID">用户组id</param>
        /// <returns>如果用户密码正确则返回uid, 否则返回-1</returns>
        IDataReader CheckPassword(int UserID, string uPWD, bool originalpassword);

        /// <summary>
        /// 检查密码
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <param name="UserSPID">接入SPID</param>
        /// <param name="originalpassword">是否非MD5密码</param>
        /// <returns>如果正确则返回用户id, 否则返回-1</returns>
        IDataReader CheckPassword(string uName, string uPWD, bool originalpassword);

        /// <summary>
        /// 根据IP获取错误登录记录
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        DataTable GetErrLoginRecordByIP(string ip);

        /// <summary>
        /// 增加指定IP的错误记录数
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        int AddErrLoginCount(string ip);

        /// <summary>
        /// 增加指定IP的错误记录
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        int AddErrLoginRecord(string ip);

        /// <summary>
        /// 将指定IP的错误登录次数重置为1
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        int ResetErrLoginCount(string ip);

        /// <summary>
        /// 删除指定IP或者超过15分钟的记录
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        int DeleteErrLoginRecord(string ip);

        /// <summary>
        /// 指定权限返回用户邮箱
        /// </summary>
        /// <param name="PopedomAllStr">权限代码</param>
        string GetUserMailByPopedom(string PopedomAllStr);

        /// <summary>
        /// 取指定用户Email
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        string GetUserEmail(int UserID);

        #region 用户在线
        /// <summary>
        /// 获得全部在线用户数
        /// </summary>
        /// <returns></returns>
        int GetOnlineAllUserCount();

        /// <summary>
        /// 创建在线表
        /// </summary>
        /// <returns></returns>
        int CreateOnlineTable();

        /// <summary>
        /// 执行在线用户向表及缓存中添加的操作。
        /// </summary>
        /// <param name="onlineuserinfo">在组用户信息内容</param>
        /// <returns>添加成功则返回刚刚添加的olid,失败则返回0</returns>
        int AddOnlineUser(OnlineUserInfo onlineuserinfo, int timeout);

        /// <summary>
        /// 获得在线注册用户总数量
        /// </summary>
        /// <returns>用户数量</returns>
        int GetOnlineUserCount();

        /// <summary>
        /// 获得全部在线用户列表
        /// </summary>
        /// <returns></returns>
        DataTable GetOnlineUserListTable();

        /// <summary>
        /// 获得全部在线用户列表
        /// </summary>
        /// <returns></returns>
        IDataReader GetOnlineUserList();

        /// <summary>
        /// 根据uid获得olid
        /// </summary>
        /// <param name="uid">uid</param>
        /// <returns>olid</returns>
        int GetolIDByUid(int uid);

        /// <summary>
        /// 获得指定在线用户
        /// </summary>
        /// <param name="olid">在线id</param>
        /// <returns>在线用户的详细信息</returns>
        IDataReader GetOnlineUser(int olid);

        /// <summary>
        /// 获得指定用户的详细信息
        /// </summary>
        /// <param name="userid">在线用户ID</param>
        /// <returns>用户的详细信息</returns>
        DataTable GetOnlineUserInfo(int userid);

        /// <summary>
        /// 获得指定用户的详细信息
        /// </summary>
        /// <param name="userid">在线用户ID</param>
        /// <param name="ip">IP</param>
        /// <returns></returns>
        DataTable GetOnlineUserByIP(int userid, string ip);

        /// <summary>
        /// 删除符合条件的一个或多个用户信息
        /// </summary>
        /// <returns>删除行数</returns>
        int DeleteRowsByIP(string ip);

        /// <summary>
        /// 删除在线表中指定在线id的行
        /// </summary>
        /// <param name="olid">在线id</param>
        /// <returns></returns>
        int DeleteRows(int olid);


        /// <summary>
        /// 更新用户最后活动时间
        /// </summary>
        /// <param name="olid">在线id</param>
        void UpdateLastTime(int olid);

        /// <summary>
        /// 更新用户IP地址
        /// </summary>
        /// <param name="olid">在线id</param>
        /// <param name="ip">ip地址</param>
        void UpdateIP(int olid, string ip);

        /// <summary>
        /// 更新用户的用户组
        /// </summary>
        /// <param name="userid">用户ID</param>
        /// <param name="groupid">组名</param>
        void UpdateGroupid(int userid, int groupid);

        /// <summary>
        /// 更新在线时间统计
        /// </summary>
        /// <param name="oltimespan">时间增加量</param>
        /// <param name="uid">用户id</param>
        void UpdateOnlineTime(int oltimespan, int uid);


        /// <summary>
        /// 更新用户当前的在线时间和最后活动时间
        /// </summary>
        /// <param name="UserID">UserID</param>
        void UpdateUserLastActivity(int UserID, string activitytime);

        /// <summary>
        /// 同步users表oltime
        /// </summary>
        /// <param name="uid"></param>
        void SynchronizeOltime(int uid);

        #endregion

        #endregion

        #region UserPssportInfo
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool UserPassportInfoExists(int UserID);

        /// <summary>
        /// 增加一条数据
        /// </summary>
        int AddUserPassportInfo(UserPassportInfo model);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        void UpdateUserPassportInfo(UserPassportInfo model);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        void DeleteUserPassportInfo(int UserID);

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        UserPassportInfo GetUserPassportInfoModel(int UserID);

        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetUserPassportInfoList(string strWhere);

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        DataTable GetUserPassportInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName);
        #endregion

        #region EventLogInfo
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int AddEventLog(EventLogInfo model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool UpdateEventLog(EventLogInfo model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool DeleteEventLog(int EventLogID);
        /// <summary>
        /// 批量删除数据
        /// </summary>
        bool DeleteListEventLog(string EventLogIDlist);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        EventLogInfo GetEventLogModel(int EventLogID);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetEventLogList(string strWhere);
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        DataSet GetEventLogList(int Top, string strWhere, string filedOrder);
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        DataTable GetEventLogList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName);
        #endregion

        #region  StoresInfo
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool ExistsStoresInfo(string sName);
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool ExistsStoresInfoCode(string sCode);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int AddStoresInfo(StoresInfo model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        void UpdateStoresInfo(StoresInfo model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        void DeleteStoresInfo(int StoresID);
        /// <summary>
        /// 删除一组数据
        /// </summary>
        void DeleteStoresInfo(string StoresID);

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        StoresInfo GetStoresInfoModel(int StoresID);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        StoresInfo GetStoresInfoModelByName(string sName);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        StoresInfo GetStoresInfoModelByCode(string sCode);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetStoresInfoList(string strWhere);
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        DataTable GetStoresInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName);
        /// <summary>
        /// 导出数据
        /// </summary>
        /// <param name="bDate"></param>
        /// <param name="eDate"></param>
        /// <returns></returns>
        DataTable getSalesExportData(DateTime bDate,  int dType);
		/// <summary>
		/// Checks the stores by order.
		/// </summary>
		/// <returns><c>true</c>, if stores by order was checked, <c>false</c> otherwise.</returns>
		/// <param name="StoresID">Stores I.</param>
		bool CheckStoresByOrder (int StoresID);
        #endregion


        #region StaffDataInfo
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool ExistsStaffDataInfo(int StaffID);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int AddStaffDataInfo(StaffDataInfo model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool UpdateStaffDataInfo(StaffDataInfo model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool DeleteStaffDataInfo(int StaffDataID);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool DeleteStaffDataInfoList(string StaffDataIDlist);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        StaffDataInfo GetStaffDataInfoModel(int StaffDataID);
        StaffDataInfo GetStaffDataInfoModelByStaffID(int StaffID);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetStaffDataInfoList(string strWhere);
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        DataSet GetStaffDataInfoList(int Top, string strWhere, string filedOrder);
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        DataTable GetStaffDataInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName);
        #endregion

        #region StaffEduDataInfo
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool ExistsStaffEduDataInfo(int StaffID, string eDate, string eSchools);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int AddStaffEduDataInfo(StaffEduDataInfo model);
        bool AddStaffEduDataInfoByJson(StaffEduDataJson EduDataJson);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool UpdateStaffEduDataInfo(StaffEduDataInfo model);
        bool UpdateStaffEduDataInfoByJson(StaffEduDataJson EduDataJson, int StaffID);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool DeleteStaffEduDataInfo(int StaffEduDataID);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool DeleteStaffEduDataInfoList(string StaffEduDataIDlist);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        StaffEduDataInfo GetStaffEduDataInfoModel(int StaffEduDataID);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetStaffEduDataInfoList(string strWhere);
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        DataSet GetStaffEduDataInfoList(int Top, string strWhere, string filedOrder);
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        DataTable GetStaffEduDataInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName);
        #endregion

        #region StaffFamilyDataInfo
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool ExistsStaffFamilyDataInfo(int StaffID, string fName, string fTitle);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int AddStaffFamilyDataInfo(StaffFamilyDataInfo model);
        bool AddStaffFamilyDataInfoByJson(StaffFamilyDataJson FamilyDataJson);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool UpdateStaffFamilyDataInfo(StaffFamilyDataInfo model);
        bool UpdateStaffFamilyDataInfoByJson(StaffFamilyDataJson FamilyDataJson, int StaffID);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool DeleteStaffFamilyDataInfo(int StaffFamilyDataID);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool DeleteStaffFamilyDataInfoList(string StaffFamilyDataIDlist);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        StaffFamilyDataInfo GetStaffFamilyDataInfoModel(int StaffFamilyDataID);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetStaffFamilyDataInfoList(string strWhere);
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        DataSet GetStaffFamilyDataInfoList(int Top, string strWhere, string filedOrder);
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        DataTable GetStaffFamilyDataInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName);
        #endregion

        #region StaffWorkDataInfo
        // <summary>
        /// 是否存在该记录
        /// </summary>
        bool ExistsStaffWorkDataInfo(int StaffID, string wDate, string wEnterprise);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int AddStaffWorkDataInfo(StaffWorkDataInfo model);
        bool AddStaffWorkDataInfoByJson(StaffWorkDataJson WorkDataJson);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool UpdateStaffWorkDataInfo(StaffWorkDataInfo model);
        bool UpdateStaffWorkDataInfoByJson(StaffWorkDataJson WorkDataJson, int StaffID);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool DeleteStaffWorkDataInfo(int StaffWorkDataID);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool DeleteStaffWorkDataInfoList(string StaffWorkDataIDlist);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        StaffWorkDataInfo GetStaffWorkDataInfoModel(int StaffWorkDataID);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetStaffWorkDataInfoList(string strWhere);
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        DataSet GetStaffWorkDataInfoList(int Top, string strWhere, string filedOrder);
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        DataTable GetStaffWorkDataInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName);
        #endregion

        #region StaffAnalysisDataInfo
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int AddStaffAnalysisDataInfo(StaffAnalysisDataInfo model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool UpdateStaffAnalysisDataInfo(StaffAnalysisDataInfo model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool DeleteStaffAnalysisDataInfo(int StaffAnalysisDataID);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool DeleteStaffAnalysisDataInfoList(string StaffAnalysisDataIDlist);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        StaffAnalysisDataInfo GetStaffAnalysisDataInfoModel(int StaffAnalysisDataID);
        StaffAnalysisDataInfo GetStaffAnalysisDataInfoModelByStaffID(int StaffID);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetStaffAnalysisDataInfoList(string strWhere);
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        DataSet GetStaffAnalysisDataInfoList(int Top, string strWhere, string filedOrder);
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        DataTable GetStaffAnalysisDataInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName);
        #endregion

        #region  StaffStoresInfo

        /// <summary>
        /// 增加一条数据
        /// </summary>
        int AddStaffStoresInfo(StaffStoresInfo model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        void UpdateStaffStoresInfo(StaffStoresInfo model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        void DeleteStaffStoresInfo(int StaffStoresID);
        /// <summary>
        /// 删除一组数据
        /// </summary>
        void DeleteStaffStoresInfo(string StaffStoresID);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        StaffStoresInfo GetStaffStoresInfoModel(int StaffStoresID);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetStaffStoresInfoList(string strWhere);
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        DataTable GetStaffStoresInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName);
        /// <summary>
        /// 人员上离岗记录
        /// </summary>
        DataTable GetStaff_StoresList(int StaffID, DateTime bDate, DateTime eDate, int sType);
        DataTable GetStaff_StoresList(int StaffID, int StoresID, DateTime bDate, DateTime eDate, int sType);
        /// <summary>
        /// 取指定门店目前上岗中的人员信息
        /// </summary>
        /// <param name="StoresID"></param>
        /// <param name="sType">人员类型,公司=0,业务员=1,促销员=2,其他=3</param>
        /// <returns></returns>
        StaffInfo GetStaffByStores(int StoresID, int sType);
        #endregion

        #region 人员岗位_月报表
        /// <summary>
        /// 获得人员岗位上离岗年份
        /// </summary>
        /// <returns></returns>
        DataTable getStaffDate();
        /// <summary>
        /// 获得去年所有加入人员数量
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        DataTable getStaffLastYear(DateTime dt);
        /// <summary>
        /// 获得每月的人员加入总数
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        DataTable getStaffOfMonth(string dt);
        /// <summary>
        /// 获得人员上下岗明细
        /// </summary>
        /// <param name="bDate"></param>
        /// <param name="eDate"></param>
        /// <param name="dType"></param>
        /// <returns></returns>
        DataTable getStaffDetails(DateTime bDate, DateTime eDate, int dType);
        #endregion

        #region  StaffInfo
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool ExistsStaffInfo(string sName);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int AddStaffInfo(StaffInfo model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        void UpdateStaffInfo(StaffInfo model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        void DeleteStaffInfo(int StaffID);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        void DeleteStaffInfo(string StaffID);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        StaffInfo GetStaffInfoModel(int StaffID);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        StaffInfo GetStaffInfoModelByName(string sName);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        StaffInfo GetStaffInfoModelByUserID(int UserID);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetStaffInfoList(string strWhere);
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        DataTable GetStaffInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName);
        #endregion

        #region  SalesInfo
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool ExistsSalesInfo(int SalesID);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int AddSalesInfo(SalesInfo model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        void UpdateSalesInfo(SalesInfo model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        void DeleteSalesInfo(int SalesID);
        /// <summary>
        /// 删除一组数据
        /// </summary>
        void DeleteSalesInfo(string SalesID);
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="SalesID"></param>
        /// <param name="sDateTime"></param>
        void DeleteSalesInfo(string SalesID, DateTime sDateTime);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        SalesInfo GetSalesInfoModel(int SalesID);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetSalesInfoList(string strWhere);
        /// <summary>
        /// 匹配数据,单据/产品匹配
        /// </summary>
        int[] SyncSalesInfo();
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        DataTable GetSalesInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName);
        /// <summary>
        /// 取未匹配数据
        /// </summary>
        /// <returns></returns>
        DataTable GetNOJoinDataSalesInfoList();
        #endregion

        #region  RegionInfo
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool ExistsRegionInfo(string rName, int rUpID);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int AddRegionInfo(RegionInfo model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        int UpdateRegionInfo(RegionInfo model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        int DeleteRegionInfo(int RegionID);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        RegionInfo GetRegionInfoModel(int RegionID);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        RegionInfo GetRegionInfoModelByName(string rName);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        RegionInfo GetRegionInfoModelLikeName(string rName);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetRegionInfoList(string strWhere);
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        DataTable GetRegionInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName);

        /// <summary>
        /// 更新排序
        /// </summary>
        /// <param name="sCID">源</param>
        /// <param name="tCID">目标</param>
        /// <param name="nCIDstr">排序后的目标同级ID串</param>
        /// <param name="pCID">目标父级编号</param>
        void UpdateRegionOrder(string sCID, string tCID, string nCIDstr, string pCID);
        DataTable geAreaClassList(int ParentID);
        DataTable GetAreaDetails(int AreaClassID);
        #endregion

        #region  ProductsInfo
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool ExistsProductsInfo(string pName);
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool ExistsProductsInfo_pCode(string pCode);
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool ExistsProductsInfo_pBarcode(string pBarcode);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int AddProductsInfo(ProductsInfo model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        void UpdateProductsInfo(ProductsInfo model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        void DeleteProductsInfo(int ProductsID);
        /// <summary>
        /// 删除一组数据
        /// </summary>
        void DeleteProductsInfo(string ProductsID);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        ProductsInfo GetProductsInfoModel(int ProductsID);
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		ProductsInfo GetProductsInfoModelByCode (string Code);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        ProductsInfo GetProductsInfoModelByName(string pName);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        ProductsInfo GetProductsInfoModelByBarcode(string pBarcode);

        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetProductsInfoList(string strWhere);

        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetProductsBrandList(string strWhere);
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        DataTable GetProductsInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName);

        DataSet GetProductsInfoListAndQuantity(string strWhere);
        /// <summary>
        /// 更是商品库存信息
        /// </summary>
        /// <param name="OrderID"></param>
        /// <returns></returns>
        bool UpdateProductsStorageByOrderID(int OrderID);

		/// <summary>
		/// Checks the products by order.
		/// </summary>
		/// <returns><c>true</c>, if products by order was checked, <c>false</c> otherwise.</returns>
		/// <param name="ProductsID">Products I.</param>
		bool CheckProductsByOrder (int ProductsID);
        #endregion

        #region  MarketingFeesInfo

        /// <summary>
        /// 增加一条数据
        /// </summary>
        int AddMarketingFeesInfo(MarketingFeesInfo model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        void UpdateMarketingFeesInfo(MarketingFeesInfo model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        void DeleteMarketingFeesInfo(int MarketingFeesID);
        /// <summary>
        /// 删除一组数据
        /// </summary>
        void DeleteMarketingFeesInfo(string MarketingFeesID);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        MarketingFeesInfo GetMarketingFeesInfoModel(int MarketingFeesID);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetMarketingFeesInfoList(string strWhere);
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        DataTable GetMarketingFeesInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName);
        #endregion

        #region  GiftsInfo

        /// <summary>
        /// 增加一条数据
        /// </summary>
        int AddGiftsInfo(GiftsInfo model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        void UpdateGiftsInfo(GiftsInfo model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        void DeleteGiftsInfo(int GiftsID);
        /// <summary>
        /// 删除一组数据
        /// </summary>
        void DeleteGiftsInfo(string GiftsID);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        GiftsInfo GetGiftsInfoModel(int GiftsID);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetGiftsInfoList(string strWhere);
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        DataTable GetGiftsInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName);
        #endregion

        #region  FeesSubjectInfo
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool ExistsFeesSubjectInfo(string fName);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int AddFeesSubjectInfo(FeesSubjectInfo model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        void UpdateFeesSubjectInfo(FeesSubjectInfo model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        void DeleteFeesSubjectInfo(int FeesSubjectID);
        /// <summary>
        /// 删除一组数据
        /// </summary>
        void DeleteFeesSubjectInfo(string FeesSubjectID);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        FeesSubjectInfo GetFeesSubjectInfoModel(int FeesSubjectID);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        FeesSubjectInfo GetFeesSubjectInfoModelByName(string fName);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetFeesSubjectInfoList(string strWhere);
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        DataTable GetFeesSubjectInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName);
        #endregion

        #region YHsysInfo
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool ExistsYHsysInfo(string yName);

        /// <summary>
        /// 增加一条数据
        /// </summary>
        int AddYHsysInfo(YHsysInfo model);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        void UpdateYHsysInfo(YHsysInfo model);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        void DeleteYHsysInfo(int YHsysID);

        /// <summary>
        /// 删除一组数据
        /// </summary>
        void DeleteYHsysInfo(string YHsysID);

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        YHsysInfo GetYHsysInfoModel(int YHsysID);

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        YHsysInfo GetYHsysInfoModelByName(string yName);

        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetYHsysInfoList(string strWhere);

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        DataTable GetYHsysInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName);
        #endregion

        #region CostValenceInfo
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool ExistsCostValenceInfo(int ProductsID, DateTime cDateTime);

        /// <summary>
        /// 增加一条数据
        /// </summary>
        int AddCostValenceInfo(CostValenceInfo model);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        void UpdateCostValenceInfo(CostValenceInfo model);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        void DeleteCostValenceInfo(int CostVelenceID);

        /// <summary>
        /// 删除一组数据
        /// </summary>
        void DeleteCostValenceInfo(string CostVelenceID);

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        CostValenceInfo GetCostValenceInfoModel(int CostVelenceID);

        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetCostValenceInfoList(string strWhere);

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        DataTable GetCostValenceInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName);
        #endregion

        #region ErpOrderInfo
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool ExistsErpOrderInfo(int O_ID, string O_ORDERNUM, int P_ID, int S_ID, int R_ID, DateTime O_CREATETIME);

        /// <summary>
        /// 增加一条数据
        /// </summary>
        int AddErpOrderInfo(ErpOrderInfo model);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        void UpdateErpOrderInfo(ErpOrderInfo model);

        /// <summary>
        /// 匹配数据,单据/产品匹配
        /// </summary>
        int[] SyncErpOrderInfo();

        /// <summary>
        /// 删除一条数据
        /// </summary>
        void DeleteErpOrderInfo(int ErpOrderID);

        void DeleteErpOrderInfoByOID(int O_ID);

        /// <summary>
        /// 删除一组数据
        /// </summary>
        void DeleteErpOrderInfo(string ErpOrderID);

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        ErpOrderInfo GetErpOrderInfoModel(int ErpOrderID);

        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetErpOrderInfoList(string strWhere);

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        DataTable GetErpOrderInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName);

        /// <summary>
        /// 获取指定条件下的订单编号集合
        /// </summary>
        /// <param name="StoresID">门店客户编号</param>
        /// <param name="R_ID">单据类型编号</param>
        /// <param name="eDate">结束时间</param>
        string GetErpOrderIDStr(int StoresID, int R_ID, DateTime eDate);

        /// <summary>
        /// 修改订单标记
        /// </summary>
        /// <param name="StoresID">门店客户编号</param>
        /// <param name="R_ID">单据类型编号</param>
        /// <param name="eDate">结束时间</param>
        /// <param name="IsCheck">修改后标记,未对账=0,已对账=1</param>
        bool UpdateErpOrderCheck(int StoresID, int R_ID, DateTime eDate, int IsCheck);
        /// <summary>
        /// 更新对账状态
        /// </summary>
        /// <param name="ErpOrderID">订单编号集合</param>
        /// <param name="t">对账状态:未对账=0,已对账=1</param>
        void UpdateErpOrderIsCheck(string ErpOrderID, int t);
        #endregion

        #region BankInfo
        bool ExistsBank(int bID);
        /// <summary>
        /// 添加一条资金账户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int AddBank(BankAccount model);
        void UpdateBank(BankAccount model);
        void DeleteBank(int BankID);
        void DeleteBank(string BankID);
        BankAccount GetBankModel(int BankID);
        DataSet GetBankList(string strWhere);
        DataTable GetBankList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName);

        #endregion

        #region BankMoneyInfo
        bool ExistsBankMoney(int BankMoneyID);
        int AddBankMoney(BankMoneyInfo model);
        void UpdateBankMoney(BankMoneyInfo model);
        void DeleteBankMoney(int BankMoneyID);
        void DeleteBankMoneyForDate(DateTime sDate);
        void DeleteBankMoneyForDate(string sDate);

        void DeleteBankMoney(string BankMoneyID);
        decimal GetBankMoney(DateTime dDate, int BankID);

        decimal GetBankMoneyByEndDate(DateTime eDate, int BankID);

        BankMoneyInfo GetBankMoneyModel(int BankMoneyID);
        BankMoneyInfo GetBankMoneyModel(DateTime dDate, int BankID);
        DataSet GetBankMoneyList(string strWhere);
        DataTable GetBankMoneyList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName);
        /// <summary>
        /// 设置资金帐户的期初金额
        /// </summary>
        /// <param name="BankID"></param>
        /// <param name="BeginMoney"></param>
        /// <returns></returns>
         void GetBankBeginMoney(int BankID, decimal BeginMoney);

        /// <summary>
        /// 取账户的期初金额
        /// </summary>
        /// <param name="BankID"></param>
        /// <returns></returns>
         decimal GetBankBeginMoney(int BankID);
        #endregion

        #region SupplierInfo
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool ExistsSupplierInfo(string sName);
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool ExistsSupplierInfoCode(string sCode);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int AddSupplierInfo(SupplierInfo model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        void UpdateSupplierInfo(SupplierInfo model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        void DeleteSupplierInfo(int SupplierID);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        void DeleteSupplierInfo(string SupplierID);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        SupplierInfo GetSupplierInfoModel(int SupplierID);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        SupplierInfo GetSupplierInfoModelByName(string sName);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        SupplierInfo GetSupplierInfoModelByCode(string sCode);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetSupplierInfoList(string strWhere);
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        DataTable GetSupplierInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName);
        #endregion

        #region APMoneyInfo
        bool ExistsAPMoneyInfo(int APMoneyID);
        int AddAPMoneyInfo(APMoneyInfo model);
        void UpdateAPMoneyInfo(APMoneyInfo model);
        void DeleteAPMoneyInfo(int APMoneyID);
        void DeleteAPMoneyInfo(string APMoneyID);
        APMoneyInfo GetAPMoneyInfoModel(int APMoneyID);
        DataSet GetAPMoneyInfoList(string strWhere);
        DataTable GetAPMoneyInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName);
        /// <summary>
        /// 指定时间段内应收数据
        /// </summary>
        /// <param name="bDate">开始时间</param>
        /// <param name="eDate">结束时间</param>
        DataTable GetErpWillPay(DateTime bDate, DateTime eDate);
        #endregion

        #region ARMoneyInfo
        bool ExistsARMoneyInfo(int ARMoneyID);
        int AddARMoneyInfo(ARMoneyInfo model);
        void UpdateARMoneyInfo(ARMoneyInfo model);
        void DeleteARMoneyInfo(int ARMoneyID);
        void DeleteARMoneyInfo(string ARMoneyID);
        ARMoneyInfo GetARMoneyInfoModel(int ARMoneyID);
        DataSet GetARMoneyInfoList(string strWhere);
        DataTable GetARMoneyInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName);
        /// <summary>
        /// 指定时间段内应收数据
        /// </summary>
        /// <param name="C_CODE">门店,客户编码</param>
        /// <param name="C_NAME">门店名称</param>
        /// <param name="bDate">开始时间</param>
        /// <param name="eDate">结束时间</param>
        DataTable GetErpCustomerPay(string C_CODE, string C_NAME, DateTime bDate, DateTime eDate);

        /// <summary>
        /// 指定时间段内应收数据
        /// </summary>
        /// <param name="C_CODE">门店,客户编码</param>
        /// <param name="C_NAME">门店名称</param>
        /// <param name="bDate">开始时间</param>
        /// <param name="eDate">结束时间</param>
        /// <param name="PaySystemName">结算系统名称</param>
        DataTable GetErpCustomerPay(string C_CODE, string C_NAME, DateTime bDate, DateTime eDate, string PaySystemName);
        #endregion

        #region ProductPoolInfo
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int AddProductPool(ProductPoolInfo model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        void UpdateProductPool(ProductPoolInfo model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        void DeleteProductPool(int ProductPoolID);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        void DeleteProductPool(string ProductPoolID);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        ProductPoolInfo GetProductPoolModel(int ProductPoolID);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetProductPoolList(string strWhere);
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        DataTable GetProductPoolList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName);
        #endregion

        #region StockProductInfo
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool ExistsStockProductInfo(int StockProductID);

        /// <summary>
        /// 增加一条数据
        /// </summary>
        int AddStockProductInfo(StockProductInfo model);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        void UpdateStockProductInfo(StockProductInfo model);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        void DeleteStockProductInfo(int StockProductID);

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        StockProductInfo GetStockProductInfoModel(int StockProductID);

        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetStockProductInfoList(string strWhere);
        DataSet GetStockProductInfoListByNow(string strWhere);

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        DataTable GetStockProductInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName);

        StockProductInfo GetStockProductInfoModelByProductsID(int ProductsID);
        #endregion

        #region PaymentSystemInfo
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool ExistsPaymentSystem(string pName);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int AddPaymentSystem(PaymentSystemInfo model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        void UpdatePaymentSystem(PaymentSystemInfo model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        void DeletePaymentSystem(int PaymentSystemID);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        void DeletePaymentSystem(string PaymentSystemID);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        PaymentSystemInfo GetPaymentSystemModel(int PaymentSystemID);
        PaymentSystemInfo GetPaymentSystemModel(string PaymentSystemName);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetPaymentSystemList(string strWhere);
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        DataTable GetPaymentSystemList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName);
        #endregion


        #region  CustomersClass
        bool ExistsCustomersClassInfo(string cClassName, int cParentID);
        /// <summary>
        /// 是否有子节点,即是否为叶节点
        /// </summary>
        /// <param name="CustomersClassID"></param>
        /// <returns></returns>
        bool ExistsCustomersClassChild(int CustomersClassID);
        int AddCustomersClassInfo(CustomersClassInfo model);
        int UpdateCustomersClassInfo(CustomersClassInfo model);
        int DeleteCustomersClassInfo(int CustomersClassID);
        CustomersClassInfo GetCustomersClassInfoModel(int CustomersClassID);
        DataSet GetCustomersClassInfoList(string strWhere);
        DataSet GetCustomersClassInfoList(int Top, string strWhere, string filedOrder);
        DataTable GetCustomersDetails(int CustomersClassID);
        DataTable getCustomersClassList(int ParentID);
        string getCustormChildrenCount(string kid);
        bool ExistsCustormClassChild(int Custorm);
        #endregion

        #region productsGraphManage
        DataTable getProductsSaleDetails(int GraphType, int SalesType, DateTime dt, string regionID, int sType);
        DataSet GetProductsList(string strWhere);
        string getProductsChildrenCount(string kid);
        #endregion

        #region 区域分类
        DataSet GetRegionClassInfoList(string strWhere);
        bool ExistsRegionClassChild(int RegionID);
        string getRegionChildrenCount(string kid);
        #endregion
        #region DepartmentsClass
        bool ExistsDepartmentsClassInfo(string dClassName, int dParentID);
        /// <summary>
        /// 是否有子节点,即是否为叶节点
        /// </summary>
        /// <param name="DepartmentsClassID"></param>
        /// <returns></returns>
        bool ExistsDepartmentsClassChild(int DepartmentsClassID);
        int AddDepartmentsClassInfo(DepartmentsClassInfo model);
        int UpdateDepartmentsClassInfo(DepartmentsClassInfo model);
        int DeleteDepartmentsClassInfo(int DepartmentsClassID);
        DepartmentsClassInfo GetDepartmentsClassInfoModel(int DepartmentsClassID);
        DataSet GetDepartmentsClassInfoList(string strWhere);
        DataSet GetDepartmentsClassInfoList(int Top, string strWhere, string filedOrder);
        DataTable GetDepartmentClassDetails(int DepartClassID);
        DataTable getDepartmentClassList(int ParentID);
        #endregion
        #region PriceClass
        bool ExistsPriceClassInfo(string pClassName, int pParentID);
        /// <summary>
        /// 是否有子节点,即是否为叶节点
        /// </summary>
        /// <param name="PriceClassID"></param>
        /// <returns></returns>
        bool ExistsPriceClassChild(int PriceClassID);
        int AddPriceClassInfo(PriceClassInfo model);
        int UpdatePriceClassInfo(PriceClassInfo model);
        int DeletePriceClassInfo(int PriceClassID);
        PriceClassInfo GetPriceClassInfoModel(int PriceClassID);
        PriceClassInfo GetPriceClassInfoModel(string pClassName);
        DataSet GetPriceClassInfoList(string strWhere);
        DataSet GetPriceClassInfoList(int Top, string strWhere, string filedOrder);
        DataTable getPriceClassList(int ParentID);
        DataTable GetPriceDetails(int PriceClassID);
        #endregion
        #region ProductClass
        bool ExistsProductClassInfo(string pClassName, int pParentID);
        /// <summary>
        /// 是否有子节点,即是否为叶节点
        /// </summary>
        /// <param name="ProductClassID"></param>
        /// <returns></returns>
        bool ExistsProductClassChild(int ProductClassID);
        int AddProductClassInfo(ProductClassInfo model);
        int UpdateProductClassInfo(ProductClassInfo model);
        int DeleteProductClassInfo(int ProductClassID);
        ProductClassInfo GetProductClassInfoModel(int ProductClassID);
        ProductClassInfo GetProductClassInfoModel(string pClassName);
        DataSet GetProductClassInfoList(string strWhere);
        DataSet GetProductClassInfoList(int Top, string strWhere, string filedOrder);
        DataTable GetProductClassDetails(int ProductClassID);
        DataTable GetProductClassInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName);
        DataTable getProductsClassList(int ParentID);
        #endregion
        #region SupplierClass
        bool ExistsSupplierClassInfo(string sClassName, int sParentID);
        /// <summary>
        /// 是否有子节点,即是否为叶节点
        /// </summary>
        /// <param name="SupplierClassID"></param>
        /// <returns></returns>
        bool ExistsSupplierClassChild(int SupplierClassID);
        int AddSupplierClassInfo(SupplierClassInfo model);
        int UpdateSupplierClassInfo(SupplierClassInfo model);
        int DeleteSupplierClassInfo(int SupplierClassID);
        SupplierClassInfo GetSupplierClassInfoModel(int SupplierClassID);
        DataSet GetSupplierClassInfoList(string strWhere);
        DataSet GetSupplierClassInfoList(int Top, string strWhere, string filedOrder);
        DataTable GetSupplierClassDetails(int SupplierClassID);
        DataTable getSupplierClassList(int ParentID);
        #endregion
        #region  FeesSubjectClass
        int updateCertificateToFeessubjects(string certificateID, int feesubjectID, int lastFeeID);
        DataTable getCertificateDate(int fid);
        int getFeeState(int fid);
        bool ExistsFeesSubjectClassInfo(string cClassName, int cParentID);
        /// <summary>
        /// 是否有子节点,即是否为叶节点
        /// </summary>
        /// <param name="FeesSubjectClassID"></param>
        /// <returns></returns>
        bool ExistsFeesSubjectClassChild(int FeesSubjectClassID);
        bool ExistsFeesSubjectClassInfoByCode(string cCode);
        int AddFeesSubjectClassInfo(FeesSubjectClassInfo model);
        int UpdateFeesSubjectClassInfo(FeesSubjectClassInfo model);
        int DeleteFeesSubjectClassInfo(int FeesSubjectClassID);
        FeesSubjectClassInfo GetFeesSubjectClassInfoModel(int FeesSubjectClassID);
        DataSet GetFeesSubjectClassInfoList(string strWhere);
        DataSet GetFeesSubjectClassInfoList(int Top, string strWhere, string filedOrder);
        DataTable getFeesSubjectClassList(int ParentID);
        DataTable GetFeesSubjectDetails(int CustomersClassID);
        #endregion
        #region StorageClass
        DataSet GetStorageClassInfoList(string strWhere);
        bool ExistsStorageClassChild(int StorageClassID);
        DataTable getStorageNameByClass(int sid);
        DataTable getStorageClassList(int ParentID);
        DataTable GetStorageDetails(int StorageClassID);
        #endregion

        #region Storage
        bool ExistsStorageInfo(string sName);
        bool ExistsStorageInfoByCode(string sCode);
        int AddStorageInfo(StorageInfo model);
        void UpdateStorageInfo(StorageInfo model);
        void DeleteStorageInfo(int StorageID);
        void DeleteStorageInfo(string StorageID);
        StorageInfo GetStorageInfoModel(int StorageID);
        DataSet GetStorageInfoList(string strWhere);
        DataSet GetList(int Top, string strWhere, string filedOrder);
        DataTable GetStorageInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName);
        DataSet GetStoragesInfoList(string strWhere);
        bool ExistsStorageInfo(string sClassName, int sParentID);
        int AddStorageListInfo(StorageClass model);
        StorageClass GetStoragesInfoModel(int StorageClassID);
        int UpdateStoragesInfo(StorageClass model);
        int DeleteStoragesInfo(int StorageID);

        StorageInfo GetStorageInfoModelBySCode(string sCode);

        StorageInfo GetStorageInfoModelByName(string sName);
        #endregion


        #region PriceClassDefaultPrice
        bool ExistsPriceClassDefaultPriceInfo(int PriceClassID, int ProductsID);
        int AddPriceClassDefaultPriceInfo(PriceClassDefaultPriceInfo model);
        void UpdatePriceClassDefaultPriceInfo(PriceClassDefaultPriceInfo model);
        void DeletePriceClassDefaultPriceInfo(int PriceClassDefaultPriceID);
        PriceClassDefaultPriceInfo GetPriceClassDefaultPriceInfoModel(int PriceClassDefaultPriceID);
        PriceClassDefaultPriceInfo GetPriceClassDefaultPriceInfoModel(int PriceClassID, int ProductsID);
        DataSet GetPriceClassDefaultPriceInfoList(string strWhere);
        DataSet GetPriceClassDefaultPriceInfoList(int Top, string strWhere, string filedOrder);
        /// <summary>
        /// 取指定商品指定门店默认价格
        /// </summary>
        /// <param name="ProductID"></param>
        /// <param name="StoresID"></param>
        /// <returns></returns>
        decimal GetProductsPiceByStoresID(int ProductsID, int StoresID);
        #endregion

        #region ProductsStorage
        int ExistsProductsStorage(int StorageID, int ProductsID);
        int ExistsProductsStorage(int StorageID, int ProductsID, DateTime dT);
        int AddProductsStorage(ProductsStorageInfo model);
        void UpdateProductsStorage(ProductsStorageInfo model);
        void DeleteProductsStorage(int ProductsStorageID);
        ProductsStorageInfo GetProductsStorageModel(int ProductsStorageID);
        /// <summary>
        /// 设置产品期初库存
        /// </summary>
        /// <param name="StorageID"></param>
        /// <param name="ProductsID"></param>
        /// <param name="pQuantity"></param>
        /// <returns></returns>
        bool UpdateProductsBeginningStorage(int StorageID, int ProductsID, decimal pQuantity);
        /// <summary>
        /// 取产品指定仓库期初库存
        /// </summary>
        /// <param name="StorageID"></param>
        /// <param name="ProductsID"></param>
        /// <returns></returns>
        decimal GetProductsBeginningStorage(int StorageID, int ProductsID);
        /// <summary>
        /// 取当前指定仓库/产品,库存
        /// </summary>
        /// <param name="StorageID"></param>
        /// <param name="ProductsID"></param>
        /// <returns></returns>
        ProductsStorageInfo GetProductsStorageModel(int StorageID, int ProductsID);
        /// <summary>
        /// 取当指定时间指定仓库/产品,库存
        /// </summary>
        /// <param name="StorageID"></param>
        /// <param name="ProductsID"></param>
        /// <param name="dT"></param>
        /// <returns></returns>
        ProductsStorageInfo GetProductsStorageModel(int StorageID, int ProductsID, DateTime dT);
        /// <summary>
        /// 添加当前指定仓库/商品库存
        /// </summary>
        /// <param name="StorageID"></param>
        /// <param name="ProductsID"></param>
        /// <returns></returns>
        int AddProductsStorage(int StorageID, int ProductsID);
        /// <summary>
        /// 添加指定时间指定仓库/商品库存
        /// </summary>
        /// <param name="StorageID"></param>
        /// <param name="ProductsID"></param>
        /// <param name="dT"></param>
        /// <returns></returns>
        int AddProductsStorage(int StorageID, int ProductsID, DateTime dT);
        DataSet GetProductsStorageList(string strWhere);
        DataSet GetProductsStorageInfoList(int Top, string strWhere, string filedOrder);
        DataTable GetProductsStorageList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName);

        /// <summary>
        /// 产品库存列表
        /// </summary>
        /// <param name="StorageID">仓库编号</param>
        /// <param name="sDateTime">时间点</param>
        /// <returns></returns>
        DataTable GetProductsStorageInfoByStorageID(int sClassID, int StorageID, DateTime sDateTime, int ProductsID);
        DataTable GetProductsStorageInfoByStorageID_XP(int StorageID, DateTime sDateTime, int ProductsID);
        #endregion

        #region ProductsStorageLog
        int AddProductsStorageLog(ProductsStorageLogInfo model);
        void UpdateProductsStorageLog(ProductsStorageLogInfo model);
        void DeleteProductsStorageLog(int ProductsStorageLogID);
        ProductsStorageLogInfo GetProductsStorageLogModel(int ProductsStorageLogID);
        DataSet GetProductsStorageLogList(string strWhere);
        DataSet GetProductsStorageLogList(int Top, string strWhere, string filedOrder);
        DataTable GetProductsStorageLogList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName);
        #endregion

        #region Order
        bool ExistsOrderInfo(string oOrderNum);
        int AddOrderInfo(OrderInfo model);
        int AddOrderInfoAndList(OrderInfo model);
        void UpdateOrderInfo(OrderInfo model);
        bool UpdateOrderInfoAndList(OrderInfo model);
        void DeleteOrderInfo(int OrderID);
        OrderInfo GetOrderInfoModel(int OrderID);
        DataSet GetOrderInfoList(string strWhere);
        DataSet GetOrderInfoList(int Top, string strWhere, string filedOrder);
        DataTable GetOrderInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName);
        DataTable GetOrderInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName, string filedOrder, string OrderfldName);
        DataTable GetOrderInfoList_xp(int PageSize, int PageIndex, string strWhere, out int pagetotal, string OrderfldName);
        
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
		OrderInfo GetNextOrder (int oType, int oState, int oSteps);
		/// <summary>
        /// 返回当前各种单据基础统计信息
        /// </summary>
        /// <returns></returns>
        DataSet GetOrderStateList();
        /// <summary>
        /// 审核单据
        /// </summary>
        /// <param name="OrderID"></param>
        void VerifyOrder(int OrderID);
        /// <summary>
        /// 取当前系统最后一个单据号
        /// </summary>
        /// <returns></returns>
        string GetMaxOrderNum();
        /// <summary>
        /// 验证指定单据是否为全额收货
        /// </summary>
        /// <param name="OrderID"></param>
        /// <returns></returns>
        bool CheckOrderIsFull(int OrderID);
        /// <summary>
        /// 返回非全额收货单据体
        /// </summary>
        /// <param name="OrderID"></param>
        /// <returns></returns>
        DataTable GetOrderNOFullList(int OrderID);
        /// <summary>
        /// 返回产品库存报警列表,库存数 <=10出库, >=20天出库
        /// </summary>
        /// <returns></returns>
        DataTable GetProductAlarm();
        /// <summary>
        /// 验证指定非全额单据是否已处理差额
        /// </summary>
        /// <param name="OrderID"></param>
        /// <returns></returns>
        bool CheckOrderNOFullToDo(int OrderID);
        /// <summary>
        /// 更新待处理单据状态
        /// </summary>
        /// <param name="OrderID"></param>
        /// <param name="NextOrderID"></param>
        void UpdateOrderNOFullNextOrder(int OrderID, int NextOrderID);
        /// <summary>
        /// 进销存报表
        /// </summary>
        /// <param name="ProductsID"></param>
        /// <param name="StorageID"></param>
        /// <param name="sDate">选择的时间点</param>
        /// <param name="ReType">返回类型,月表=1,年表=2,区间=3</param>
        /// <param name="DataType">返回表类型,1存档记录,2实算记录</param>
        /// <param name="sDataType">统计数据方式,0=取上期结存成本,1=取本期发生成本</param>
        /// <returns></returns>
        DataTable GetInvoicingReport(int ProductsID, int StorageID, DateTime sDate, int ReType, out int DataType, int sDataType);
        DataTable GetInvoicingReport(int ProductsID, int StorageID, DateTime sDate, int ReType, out int DataType, int sDataType,DateTime eDate);
        /// <summary>
        /// 返回产品进销存缓存数据
        /// </summary>
        /// <param name="StorageID"></param>
        /// <param name="ProductsID"></param>
        /// <param name="sDate"></param>
        /// <param name="rType"></param>
        /// <returns></returns>
        DataTable GetReportInvoicingDataInfoList(int StorageID, int ProductsID, DateTime sDate, int rType);
        /// <summary>
        /// 重置进销存数据,已加一天
        /// </summary>
        /// <param name="sDate"></param>
        /// <returns></returns>
        bool ReSetInvoicingData(DateTime sDate);
        /// <summary>
        /// 取单据总金额
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
         decimal GetOrderSumMoney(string strWhere);
        /// <summary>
        /// 返回单据合计金额
        /// </summary>
        /// <param name="OrderID"></param>
        /// <returns></returns>
          decimal GetOrderSumMoney(int OrderID);
        /// <summary>
        /// 取单据的操作员,人员,打印时间,合计数 等信息
        /// </summary>
        /// <param name="OrderID"></param>
        /// <returns></returns>
           string[] GetOrderOtherInfo(int OrderID);
        /// <summary>
        /// 更新进销存数据结存数据
        /// </summary>
        /// <param name="eQuantity"></param>
        /// <param name="eMoney"></param>
        /// <param name="ReportInvoicingID"></param>
        /// <returns></returns>
            bool UpdateReportInvoicingDataInfoByEndData(decimal eQuantity, decimal eMoney, int ReportInvoicingID);
        /// <summary>
        /// 更新进销存数据结存数据
        /// </summary>
        /// <param name="eQuantity"></param>
        /// <param name="eMoney"></param>
        /// <param name="ReportInvoicingID"></param>
        /// <returns></returns>
             bool UpdateReportInvoicingDataInfoByEndData(decimal eQuantity, decimal eMoney, decimal bQuantity, decimal bMoney, decimal InQuantity, decimal InMoney, decimal OutQuantity, decimal OutMoney, int ReportInvoicingID);
		/// <summary>
		/// OrderList查询条件下的所有子单据列表
		/// </summary>
		/// <returns>The order list by order where.</returns>
		/// <param name="strWhere">String where.</param>
		 DataSet GetOrderListByOrderWhere (string strWhere,bool getWorkType0);

		/// <summary>
		/// 验证单据库存数是否有超出
		/// </summary>
		/// <returns><c>true</c>, if order products stock was checked, <c>false</c> otherwise.</returns>
		/// <param name="OrderID">Order I.</param>
		 bool CheckOrderProductsStock (int OrderID);
		#endregion

        #region OrderList
        bool ExistsOrderListInfo(int OrderID, int StorageID, int ProductsID);
        int AddOrderListInfo(OrderListInfo model);
        void UpdateOrderListInfo(OrderListInfo model);
        void DeleteOrderListInfo(int OrderListID);
        OrderListInfo GetOrderListInfoModel(int OrderListID);
        DataSet GetOrderListInfoList(string strWhere);
        DataSet GetOrderListInfoList(int Top, string strWhere, string filedOrder);
        DataTable GetOrderListInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName);
        #endregion

        #region OrderField
        bool ExistsOrderFieldInfo(int OrderType, string fName);
        int AddOrderFieldInfo(OrderFieldInfo model);
        void UpdateOrderFieldInfo(OrderFieldInfo model);
        void DeleteOrderFieldInfo(int OrderFieldID);
        void DeleteOrderFieldInfo(string OrderFieldID);
        OrderFieldInfo GetOrderFieldInfoModel(int OrderFieldID);
        DataSet GetOrderFieldInfoList(string strWhere);
        DataSet GetOrderFieldInfoList(int Top, string strWhere, string filedOrder);
        DataTable GetOrderFieldInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName);
        #endregion

        #region OrderFieldValue
        bool ExistsOrderFieldValueInfo(int OrderFieldID, int OrderListID);
        int AddOrderFieldValueInfo(OrderFieldValueInfo model);
        void UpdateOrderFieldValueInfo(OrderFieldValueInfo model);
        void DeleteOrderFieldValueInfo(int OrderFieldValueID);
        OrderFieldValueInfo GetOrderFieldValueInfoModel(int OrderFieldValueID);
        DataSet GetOrderFieldValueInfoList(string strWhere);
        DataSet GetOrderFieldValueInfoList(int Top, string strWhere, string filedOrder);
        DataTable GetOrderFieldValueInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName);
        #endregion

        #region OrderWorkingLogInfo
        int AddOrderWorkingLogInfo(OrderWorkingLogInfo model);
        void UpdateOrderWorkingLogInfo(OrderWorkingLogInfo model);
        void DeleteOrderWorkingLogInfo(int OrderWorkingLogID);
        OrderWorkingLogInfo GetOrderWorkingLogInfoModel(int OrderWorkingLogID);
         /// <summary>
        /// 指定单据编号,工作类型,获得工作记录
        /// </summary>
        /// <param name="OrderID"></param>
        /// <param name="WorkType"></param>
        /// <returns></returns>
        OrderWorkingLogInfo GetOrderWorkingLogInfoModelByOrderIDAndWorkType(int OrderID, int WorkType);
        DataSet GetOrderWorkingLogInfoList(string strWhere);
        DataSet GetOrderWorkingLogInfoList(int Top, string strWhere, string filedOrder);
        DataTable GetOrderWorkingLogInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName);
        /// <summary>
        /// 取单据指定操作类型的操作信息
        /// </summary>
        /// <param name="OrderID"></param>
        /// <param name="WorkType"></param>
        /// <returns></returns>
        OrderWorkingLogInfo GetOrderWorkingUserID(int OrderID, int WorkType);
        #endregion

        #region OrderNOFullInfo
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool ExistsOrderNOFullInfo(int OrderID, int OrderToID, int ProductsID, int FormStorageID, int ToStorageID, decimal oQuantity, int oState);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        void AddOrderNOFullInfo(OrderNOFullInfo model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        void UpdateOrderNOFullInfo(OrderNOFullInfo model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        void DeleteOrderNOFullInfo(int OrderID, int OrderToID, int ProductsID, int FormStorageID, int ToStorageID);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        OrderNOFullInfo GetOrderNOFullInfoModel(int OrderID, int OrderToID, int ProductsID, int FormStorageID, int ToStorageID);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetOrderNOFullInfoList(string strWhere);
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        DataSet GetOrderNOFullInfoList(int Top, string strWhere, string filedOrder);
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        DataTable GetOrderNOFullInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName);
        #endregion

        #region 凭证头
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool ExistsCertificateInfo(string cCode);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int AddCertificateInfo(CertificateInfo model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        void UpdateCertificateInfo(CertificateInfo model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        void DeleteCertificateInfo(int CertificateID);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        CertificateInfo GetCertificateInfoModel(int CertificateID);
        CertificateInfo GetCertificateInfoModel(string cCode);
        /// <summary>
        /// 金额合计
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        decimal GetCertificateSumMoney(string strWhere);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetCertificateInfoList(string strWhere);
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        DataSet GetCertificateInfoList(int Top, string strWhere, string filedOrder);
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        DataTable GetCertificateInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName);
        DataTable GetCertificateInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName, string OrderFldName);
        
        /// <summary>
        /// 验证指定单据是否附加凭证信息
        /// </summary>
        /// <param name="OrderID"></param>
        /// <returns></returns>
        bool CheckCertificateByOrderID(int OrderID);
        /// <summary>
        /// 移除凭证随附信息
        /// </summary>
        /// <param name="CertificateID"></param>
        void RemoveCertificateToObject(int CertificateID);
        /// <summary>
        /// 设置凭证随附信息
        /// </summary>
        /// <param name="CertificateID"></param>
        void SetCertificateToObject(int CertificateID, int cObject, int cObjectID);
        /// <summary>
        /// 返回指定单号预付款合计金额
        /// </summary>
        /// <param name="OrderID"></param>
        /// <returns></returns>
        decimal GetPrepayMoneyByOrderID(int OrderID);
        /// <summary>
        /// 取指定对象上期余额
        /// </summary>
        /// <param name="sObjectID"></param>
        /// <param name="sObjectType"></param>
        /// <param name="sType"></param>
        /// <returns></returns>
        decimal GetSObjectUpMoney(int sObjectID, int sObjectType, int sType);
        /// <summary>
        /// 更新凭证头信息
        /// </summary>
        /// <param name="model"></param>
         void UpdateCertificateInfoNOListData(CertificateInfo model);

	/// <summary>
        /// 更新步骤
        /// </summary>
        /// <param name="CertificateID"></param>
        /// <param name="cSteps"></param>
         void SetCertificateSteps(int CertificateID, int cSteps);

        /// <summary>
        /// 获取指定凭证编号的前后凭证编号
        /// </summary>
        /// <param name="CertificateID"></param>
        /// <returns></returns>
         long[] GetCertificateUpDownID(int CertificateID);

        /// <summary>
        /// 根据时间返回新的凭证序号,已自动加1
        /// </summary>
        /// <param name="sDate">时间</param>
        /// <returns></returns>
          int GetCertificateNewNumber(DateTime sDate);

         /// <summary>
        /// 验证凭证序号是否重复
        /// </summary>
        /// <param name="sDate"></param>
        /// <param name="cNumber"></param>
        /// <returns></returns>
           bool CheckCertificateNumber(DateTime sDate, int cNumber);

        /// <summary>
        /// 当前凭证最大日期
        /// </summary>
        /// <returns></returns>
           DateTime GetMaxCertificateData();
        /// <summary>
        /// 去凭证最大日期,排除指定ID
        /// </summary>
        /// <returns></returns>
            DateTime GetMaxCertificateData(Int32 CertificateID);
        #endregion
        #region 凭证内容
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool ExistsCertificateDataInfo(int CertificateID, int FeesSubjectID, string cdName);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int AddCertificateDataInfo(CertificateDataInfo model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        void UpdateCertificateDataInfo(CertificateDataInfo model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        void DeleteCertificateDataInfo(int CertificateDataID);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        CertificateDataInfo GetCertificateDataInfoModel(int CertificateDataID);
         /// <summary>
        /// 取指定条件下的合计数
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        decimal[] GetCertificateDataSumMoney(string strWhere);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetCertificateDataInfoList(string strWhere);
        DataSet GetCertificateDataInfoListB(string strWhere);
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        DataSet GetCertificateDataInfoList(int Top, string strWhere, string filedOrder);
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        DataTable GetCertificateDataInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName);
        #endregion
        #region 凭证照片
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int AddCertificatePicInfo(CertificatePicInfo model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        void UpdateCertificatePicInfo(CertificatePicInfo model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        void DeleteCertificatePicInfo(int CertificatePicID);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        CertificatePicInfo GetCertificatePicInfoModel(int CertificatePicID);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetCertificatePicInfoList(string strWhere);
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        DataSet GetCertificatePicInfoList(int Top, string strWhere, string filedOrder);
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        DataTable GetCertificatePicInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName);
        /// <summary>
        /// 更新指定凭证照片的凭证编号
        /// </summary>
        /// <param name="CertificatePicID"></param>
        /// <param name="CertificateID"></param>
        void UpdateCertificatePicCertificateID(int CertificatePicID, int CertificateID);
        #endregion
        #region 凭证操作记录
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int AddCertificateWorkingLog(CertificateWorkingLogInfo model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool UpdateCertificateWorkingLog(CertificateWorkingLogInfo model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool DeleteCertificateWorkingLog(int CertificateWorkingLogID);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool DeleteCertificateWorkingLogList(string CertificateWorkingLogIDlist);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        CertificateWorkingLogInfo GetCertificateWorkingLogModel(int CertificateWorkingLogID);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetCertificateWorkingLogList(string strWhere);
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        DataSet GetCertificateWorkingLogList(int Top, string strWhere, string filedOrder);
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        DataTable GetCertificateWorkingLogList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName);
        /// <summary>
        /// 取指定类型记录下的记录
        /// </summary>
        /// <param name="CertificateID"></param>
        /// <param name="cType"></param>
        /// <returns></returns>
        CertificateWorkingLogInfo GetCertificateWorkingLogUserID(int CertificateID, int cType);
        /// <summary>
        /// 取指定凭证最后一次审核时间
        /// </summary>
        /// <param name="CertificateID"></param>
        /// <returns></returns>
         DateTime GetLastVerifyTime(int CertificateID);
        #endregion
        #region 对账单
        #region MonthlyStatementInfo
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool ExistsMonthlyStatementInfo(string sCode);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int AddMonthlyStatementInfo(MonthlyStatementInfo model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        void UpdateMonthlyStatementInfo(MonthlyStatementInfo model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        void DeleteMonthlyStatementInfo(int MonthlyStatementID);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        MonthlyStatementInfo GetMonthlyStatementInfoModel(int MonthlyStatementID);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetMonthlyStatementInfoList(string strWhere);
        /// <summary>
        /// 合计本期金额
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
         decimal GetMonthlyStatementInfoListSumMoney(string strWhere);
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        DataSet GetMonthlyStatementInfoList(int Top, string strWhere, string filedOrder);
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        DataTable GetMonthlyStatementInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName);
        /// <summary>
        /// 更新对账单步骤
        /// </summary>
        /// <param name="MonthlyStatementID"></param>
        /// <param name="sSteps"></param>
        void UpdateMonthlyStatementSteps(int MonthlyStatementID, int sSteps);
        /// <summary>
        /// 更新凭证系统状态,只允许作废
        /// </summary>
        /// <param name="MonthlyStatementID"></param>
        /// <param name="state">state只能等于1</param>
        void UpdateMonthlyStatementState(int MonthlyStatementID, int state);
        #endregion

        #region MonthlyStatementDataInfo
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool ExistsMonthlyStatementDataInfo(int MonthlyStatementID, int OrderID);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int AddMonthlyStatementDataInfo(MonthlyStatementDataInfo model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        void UpdateMonthlyStatementDataInfo(MonthlyStatementDataInfo model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        void DeleteMonthlyStatementDataInfo(int MonthlyStatementDataID);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        MonthlyStatementDataInfo GetMonthlyStatementDataInfoModel(int MonthlyStatementDataID);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetMonthlyStatementDataInfoList(string strWhere);
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        DataSet GetMonthlyStatementDataInfoList(int Top, string strWhere, string filedOrder);
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        DataTable GetMonthlyStatementDataInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName);

        #endregion

        #region MonthlyStatementAppendDataInfo
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool ExistsMonthlyStatementAppendDataInfo(int MonthlyStatementID, int CertificateID);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int AddMonthlyStatementAppendDataInfo(MonthlyStatementAppendDataInfo model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        void UpdateMonthlyStatementAppendDataInfo(MonthlyStatementAppendDataInfo model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        void DeleteMonthlyStatementAppendDataInfo(int MonthlyStatementAppendDataID);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        MonthlyStatementAppendDataInfo GetMonthlyStatementAppendDataInfoModel(int MonthlyStatementAppendDataID);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetMonthlyStatementAppendDataInfoList(string strWhere);
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        DataSet GetMonthlyStatementAppendDataInfoList(int Top, string strWhere, string filedOrder);
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        DataTable GetMonthlyStatementAppendDataInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName);
        #endregion
        #region MonthlyStatementWorkingLogInfo
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int AddMonthlyStatementWorkingLogInfo(MonthlyStatementWorkingLogInfo model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        void UpdateMonthlyStatementWorkingLogInfo(MonthlyStatementWorkingLogInfo model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        void DeleteMonthlyStatementWorkingLogInfo(int MonthlyStatementWorkingLogID);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        MonthlyStatementWorkingLogInfo GetMonthlyStatementWorkingLogInfoModel(int MonthlyStatementWorkingLogID);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetMonthlyStatementWorkingLogInfoList(string strWhere);
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        DataSet GetMonthlyStatementWorkingLogInfoList(int Top, string strWhere, string filedOrder);
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        DataTable GetMonthlyStatementWorkingLogInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName);
        #endregion

        #region MonthlyStatementAppendMoneyDataInfo
        /// <summary>
        /// 增加一条数据
        /// </summary>
         int AddMonthlyStatementAppendMoneyDataInfo(MonthlyStatementAppendMoneyDataInfo model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
         bool UpdateMonthlyStatementAppendMoneyDataInfo(MonthlyStatementAppendMoneyDataInfo model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
         bool DeleteMonthlyStatementAppendMoneyDataInfo(int MonthlyStatementAppendMoneyDataID);
         /// <summary>
        /// 批量删除数据
        /// </summary>
         bool DeleteMonthlyStatementAppendMoneyDataInfoList(string MonthlyStatementAppendMoneyDataIDlist);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
         MonthlyStatementAppendMoneyDataInfo GetMonthlyStatementAppendMoneyDataInfoModel(int MonthlyStatementAppendMoneyDataID);
        /// <summary>
        /// 获得数据列表
        /// </summary>
         DataSet GetMonthlyStatementAppendMoneyDataInfoList(string strWhere);
        /// <summary>
        /// 获得前几行数据
        /// </summary>
         DataSet GetMonthlyStatementAppendMoneyDataInfoList(int Top, string strWhere, string filedOrder);
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
         DataTable GetMonthlyStatementAppendMoneyDataInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName);
        #endregion

        #endregion

        #region 凭证汇总
        DataTable GetCertificate_Summary(DateTime bDate, DateTime eDate, out int cCount, out string bCode, out string eCode);
        #endregion

        #region 数据分析
        #region 永辉数据
        DataTable GetSales_analysis(int StoresID, int StaffID, int StaffIDB, string Brand, int RegionID, int ProductID, int YHsysID, DateTime bDate, DateTime eDate, int ShowType, int DateType, out decimal AllSumValue);
        #endregion

        DataTable getStoresList(DateTime bDate, DateTime eDate);

        /// <summary>
        /// 库存商品明细
        /// </summary>
        /// <param name="bDate">开始时间</param>
        /// <param name="eDate">结束时间</param>
        /// <param name="ProductsID">商品编号</param>
        /// <param name="CostPrice">是否计算成本，0计算，1不计算</param>
        /// <param name="StorageID">仓库名称</param>
        /// <param name="Product_UPYear">上年结转，out</param>
        /// <returns></returns>
        DataSet GetProductLogDetails(DateTime bDate, DateTime eDate, int ProductsID, int CostPrice, int StorageID);

        /// <summary>
        /// 返回客户销售统计数据 
        /// </summary>
        /// <param name="ShowType">显示类型,1=按客户,2=业务员,3=促销员,4=产品,5=品牌(产品分类),6=系统,7=客户与商品</param>
        /// <param name="bDate"></param>
        /// <param name="eDate"></param>
        /// <param name="isIsPool">是否联营,0=全部,1=联营,2=非联营</param>
        /// <returns></returns>
        DataTable GetCustomers_DataAnalysis(int ShowType, DateTime bDate, DateTime eDate, out decimal AllSumMoney, int storesID, int isIsPool);

        /// <summary>
        ///   去销售统计小表
        /// </summary>
        /// <param name="ReType">商品销售=1,客户销售=2,销售成本,利润=3</param>
        /// <param name="bDate">开始时间</param>
        /// <param name="eDate">结束时间</param>
        /// <param name="NOJoinSales">是否剔除联营数据</param>
        /// <returns></returns>
        DataTable GetSalesReport(int ReType, DateTime bDate, DateTime eDate, int NOJoinSales);
		DataTable GetSalesReport(int ReType, DateTime bDate, DateTime eDate, int NOJoinSales, int StoresID,int SingleMemberID);
		DataTable GetSalesReport(int ReType, DateTime bDate, DateTime eDate, int NOJoinSales, int StoresID, int PaymentSystemID,int SingleMemberID);
		DataTable GetSalesReport(int ReType, DateTime bDate, DateTime eDate, int NOJoinSales, int StoresID, int PaymentSystemID, int oSteps,int SingleMemberID);
		DataTable GetSalesReport(int ReType, DateTime bDate, DateTime eDate, int NOJoinSales, int StoresID, int PaymentSystemID, int oSteps, int dType,int SingleMemberID);
		DataTable GetSalesReport(int ReType, DateTime bDate, DateTime eDate, int NOJoinSales, int StoresID, int PaymentSystemID, int oSteps, int dType, int CostPrice,int SingleMemberID);
		DataTable GetSalesReport(int ReDateType,int ReType, DateTime bDate, DateTime eDate, int NOJoinSales, int StoresID, int PaymentSystemID, int oSteps, int dType, int CostPrice,int SingleMemberID,string OrderNumber);
        /// <summary>
        /// 取进货统计表
        /// </summary>
        /// <param name="ReType"></param>
        /// <param name="bDate"></param>
        /// <param name="eDate"></param>
        /// <returns></returns>
        DataTable GetPurchaseReport(int ReType, DateTime bDate, DateTime eDate);
        /// <summary>
        /// 出库统计
        /// </summary>
        /// <param name="ReType">商品=1,客户=2</param>
        /// <param name="bDate"></param>
        /// <param name="eDate"></param>
        /// <param name="NOJoinSales"></param>
        /// <returns></returns>
        DataTable GetOutReport(int ReType, DateTime bDate, DateTime eDate, int NOJoinSales);
        /// <summary>
        /// 返回一个时间段内指定格式的日期，dType:1=日,2=月,3=年
        /// </summary>
        DataTable GetDateTimeList(DateTime bDate, DateTime eDate, int dType);
        /// <summary>
        /// 返回一个时间段内:销售额,成本,退货,坏货,赠品,销售费用,公司费用
        /// </summary>
        /// <param name="dType">类型(7:综合(含公司费用), 1:门店/客户, 2:业务员, 3:促销员, 4:产品, 5:品牌, 6:系统)</param>
        DataTable GetErpData_analysis(DateTime bDate, DateTime eDate, int dType);
        /// <summary>
        /// 返回一个时间段内:销售额,成本,退货,坏货,赠品,销售费用,公司费用
        /// </summary>
        /// <param name="dType">类型(7:综合(含公司费用), 1:门店/客户, 2:业务员, 3:促销员, 4:产品, 5:品牌, 6:系统)</param>
        /// <param name="StoresID">@StoresID int = 0,			--门店客户编号</param>
        /// <param name="StaffID">@StaffID int = 0,			--业务员编号</param>
        /// <param name="StaffIDB">@StaffIDB int = 0,			--促销员编号</param>
        /// <param name="Brand">@Brand varchar(128) = '',	--品牌名称,模糊</param>
        /// <param name="RegionID">@RegionID int = 0,			--地区编号</param>
        /// <param name="ProductID">@ProductID int = 0,			--产品编号</param>
        /// <param name="YHsysID">@YHsysID int = 0			--系统编号</param>
        DataTable GetErpData_analysis(DateTime bDate, DateTime eDate, int dType, int StoresID, int StaffID, int StaffIDB, string Brand, int RegionID, int ProductID, int YHsysID);

        /// <summary>
        /// 返回一个时间段内:费用
        /// </summary>
        /// <param name="mType">类型(销售费用=0,公司管理费用=1)</param>
        DataTable Get_Fees_analysis(DateTime bDate, DateTime eDate, int mType);

        /// <summary>
        /// 库存情况
        /// </summary>
        /// <param name="storageid">仓库编号</param>
        /// <param name="eDate">库存点</param>
        /// <param name="ProductID">产品编号</param>
        DataTable GetStock_analysis(int storageid, DateTime eDate, int ProductID);

        /// <summary>
        /// 应收应付
        /// </summary>
        /// <param name="gettype">客户应收=0,人员应收=1,供货商应付=2,人员应付=3</param>
        /// <param name="eDate">截止时间点</param>
        /// <param name="ObjID">指定对象编号</param>
        DataTable GetAPARMoney(int gettype, DateTime eDate, int ObjID);

        /// <summary>
        /// 返回净资产
        /// </summary>
        /// <param name="eDate">截止时间点</param>
        DataTable GetNetAssets(DateTime eDate);

        /// <summary>
        /// 返回人员带身份证列表
        /// </summary>
        DataTable GetStaffBirthdayList();

        /// <summary>
        /// 取指定门店的费用明细
        /// </summary>
        /// <param name="bDate"></param>
        /// <param name="eDate"></param>
        /// <param name="StoresID"></param>
        /// <returns></returns>
        DataTable Get_Fees_by_StoresID(DateTime bDate, DateTime eDate, int StoresID);

        /// <summary>
        /// 取指定科目费用明细
        /// </summary>
        /// <param name="bDate"></param>
        /// <param name="eDate"></param>
        /// <param name="FeesSubjectID"></param>
        /// <returns></returns>
        DataTable Get_Fees_by_FeesSubjectID(DateTime bDate, DateTime eDate, int FeesSubjectID);
        #endregion

        #region StorehouseStorageInfo
        ///<summary>
        ///获得门店名称列表
        ///<summary>
        DataTable SnameBindDropdownlist();
        ///<summary>
        ///获得门店编号，根据门店名称
        ///<summary>
        String SelectScodeBySname(string name);
        String GetScode(string sname);
        ///<summary>
        ///导入门店仓库数据
        ///<summary>
        int AddStorehouseStorageInfo(StorehouseStoreInfo str);
        /// <summary>
        /// 导入库存数据副本
        /// </summary>
        /// <param name="storehouseStorage"></param>
        /// <returns></returns>
        int AddStorehouseStorageInfo_calculate(StorehouseStoreInfo storehouseStorage);
        ///<summary>
        ///更新门店仓库数据
        ///<summary>
        int UpdateStorehouseStorageInfo(StorehouseStoreInfo storehouseStorage);
        /// <summary>
        /// 更新门店数据副本
        /// </summary>
        /// <param name="storehouseStorage"></param>
        /// <returns></returns>
        int UpdateStorehouseStorageInfo_calculate(StorehouseStoreInfo storehouseStorage);
        ///<summary>
        /// 分页获取数据列表
        ///<summary>
        DataTable GetStorehouseInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName);
        ///<summary>
        /// 取日期、产品编号、产品名称匹配的数据
        ///<summary>

        bool GetDateTimeDataStorehouseInfoList(DateTime strDate, int sCode, string stNum, int pCode);
        bool GetDateTimeDataStorehouse(int StoresID, string StCode, int ProductsID, string ProductsName, string ProductsBarcode, string pNum, DateTime pAppendTime);
        /// <summary>
        /// 表单提交产品信息验证
        /// </summary>
        /// <param name="strDate"></param>
        /// <param name="sCode"></param>
        /// <param name="stNum"></param>
        /// <returns></returns>
        bool GetDateTimeDataStorehouseInfoLists(DateTime strDate, int sCode, string stNum, StorehouseStorageJsonInfo ssji);


        ///<summary>
        /// 获取数据列表
        ///<summary>
        DataSet GetStorehouseInfoLists(string strWhere);
        ///<summary>
        /// 删除一条数据
        ///<summary>
        void DeleteStorhouseStorageInfo(int ProductID);
        ///<summary>
        /// 删除一组数据
        ///<summary>
        void DeleteStoragesInfo(string ProductID);
        ///<summary>
        /// 根据门店名称，获得门店编号
        ///<summary>
        DataTable GetScodeBySname(string sname);
        ///<summary>
        /// 获取门店库存报表
        ///<summary>
        DataTable GetStorehouseStorageReport(int regionID, int storageID, int staffID, DateTime bTime, DateTime eTime, int reType, int associated);
        ///<summary>
        /// 根据门店名称，获得产品编号
        ///<summary>
        String SelectPcodeBySname(string name);
        String GetInQuantity(string ProductsID);
        String OutQuantity(string ProductsID);
        String SelectPcodeByName(string name);
        String SelectpBarcodeByName(string name);
        int[] StorehouseStorageSyn();
        bool AddStorehouseStorageData(StorehouseStorageJsonInfo storehouseStorage);
        String SelectPcodeByPName(string[] name);
        StorehouseStoreInfo GetStorehouseProductsInfoModel(int ProductID);
        DataTable GetStorageName(string rName, string StaffName);
        DataTable RegionName();
        DataTable StaffNameByRegionName(string RegionName);
        int GetRegionIDByName(string RegionName);
        int getStaffIDByName(string StaffName);
        int getStorageIDByName(string sName);
        DataTable getProductsOfRegionDetails(int regionID, int productID, DateTime bDate, DateTime eDate);
        int GetStorageIDBySname(string sName);
        /// <summary>
        /// 实体副本
        /// </summary>
        /// <param name="ProductID"></param>
        /// <returns></returns>
        StorehouseStoreInfo GetStorehouseProductsInfoModel_calculate(int ProductID);
        /// <summary>
        /// 查询客户库存导入详情
        /// </summary>
        /// <param name="sId"></param>
        /// <param name="bDate"></param>
        /// <param name="eDate"></param>
        /// <returns></returns>
        DataTable SelectStorageData(int sId, DateTime bDate, DateTime eDate);
        #endregion

        #region 网店
        #region  网店客户应用订购信息

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool ExistsM_AppSubscribeInfo(int m_UserInfoID, int lease_id);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int AddM_AppSubscribeInfo(M_AppSubscribeInfo model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        void UpdateM_AppSubscribeInfo(M_AppSubscribeInfo model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        void DeleteM_AppSubscribeInfo(int m_AppSubscribeInfoID);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        M_AppSubscribeInfo GetM_AppSubscribeInfoModel(int m_AppSubscribeInfoID);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetM_AppSubscribeInfoList(string strWhere);
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        DataSet GetM_AppSubscribeInfoList(int Top, string strWhere, string filedOrder);
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        DataTable GetM_AppSubscribeInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName);
        #endregion

        #region  网店配置信息

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool ExistsM_ConfigInfo(string m_Name);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int AddM_ConfigInfo(M_ConfigInfo model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        void UpdateM_ConfigInfo(M_ConfigInfo model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        void DeleteM_ConfigInfo(int m_ConfigInfoID);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        M_ConfigInfo GetM_ConfigInfoModel(int m_ConfigInfoID);
        M_ConfigInfo GetM_ConfigInfoModelByAppKey(string m_AppKey);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetM_ConfigInfoList(string strWhere);
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        DataSet GetM_ConfigInfoList(int Top, string strWhere, string filedOrder);
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        DataTable GetM_ConfigInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName);
        /// <summary>
        /// 更新SessionKey时间
        /// </summary>
        /// <param name="m_ConfigInfoID"></param>
         void UpdateM_ConfigSessionKeyTime(int m_ConfigInfoID);
        #endregion

        #region  网店客户信用信息

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool ExistsM_CreditInfo(int m_UserInfoID);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int AddM_CreditInfo(M_CreditInfo model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        void UpdateM_CreditInfo(M_CreditInfo model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        void DeleteM_CreditInfo(int m_CreditInfoID);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        M_CreditInfo GetM_CreditInfoModel(int m_CreditInfoID);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetM_CreditInfoList(string strWhere);
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        DataSet GetM_CreditInfoList(int Top, string strWhere, string filedOrder);
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        DataTable GetM_CreditInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName);
        #endregion

        #region 网店会员
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool ExistsM_Member(int m_ConfigInfoID, string buyer_id);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int AddM_Member(M_MemberInfo model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool UpdateM_Member(M_MemberInfo model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool DeleteM_Member(int m_MemberInfoID);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool DeleteM_MemberList(string m_MemberInfoIDlist);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        M_MemberInfo GetM_MemberModel(int m_MemberInfoID);
        M_MemberInfo GetM_MemberModel(int m_ConfigInfoID,string buyer_id);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetM_MemberList(string strWhere);
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        DataSet GetM_MemberList(int Top, string strWhere, string filedOrder);
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        DataTable GetM_MemberList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName);
        #endregion

        #region  商品扩展信息

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool ExistsM_GoodsExtraInfo(int m_GoodsID, int eid, int num_iid, string title);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int AddM_GoodsExtraInfo(M_GoodsExtraInfo model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        void UpdateM_GoodsExtraInfo(M_GoodsExtraInfo model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        void DeleteM_GoodsExtraInfo(int m_GoodsExtraInfoID);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        M_GoodsExtraInfo GetM_GoodsExtraInfoModel(int m_GoodsExtraInfoID);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetM_GoodsExtraInfoList(string strWhere);
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        DataSet GetM_GoodsExtraInfoList(int Top, string strWhere, string filedOrder);
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        DataTable GetM_GoodsExtraInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName);
        #endregion

        #region  商品信息

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool ExistsM_GoodsInfo(int m_ConfigInfoID, int ProductsID, int m_ProductInfoID, long product_id);
        bool ExistsM_GoodsInfo(int m_ConfigInfoID, long num_iid);
        int ExistsM_GoodsInfoAndGetID(int m_ConfigInfoID, long num_iid);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int AddM_GoodsInfo(M_GoodsInfo model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        void UpdateM_GoodsInfo(M_GoodsInfo model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        void DeleteM_GoodsInfo(int m_GoodsID);
        /// <summary>
        /// 非真删除
        /// </summary>
        /// <param name="m_GoodsID"></param>
         void DeleteM_GoodsInfoNOTrue(int m_GoodsID);
        /// <summary>
        /// 上架
        /// </summary>
        /// <param name="m_GoodsID"></param>
          void ListingM_Goods(int m_GoodsID);
	    /// <summary>
        /// 下架
        /// </summary>
        /// <param name="m_GoodsID"></param>
         void DelistingM_Goods(int m_GoodsID);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        M_GoodsInfo GetM_GoodsInfoModel(int m_GoodsID);
        M_GoodsInfo GetM_GoodsInfoModelByProductsID(int m_ConfigInfoID, int ProductsID);
        M_GoodsInfo GetM_GoodsInfoModelByNum_iid(int m_ConfigInfoID, long num_iid);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetM_GoodsInfoList(string strWhere);
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        DataSet GetM_GoodsInfoList(int Top, string strWhere, string filedOrder);
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        DataTable GetM_GoodsInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName);

        /// <summary>
        /// 更新商品数量
        /// </summary>
        /// <param name="m_ConfigInfoID"></param>
        /// <param name="ProductsID"></param>
        /// <param name="Num"></param>
        /// <returns></returns>
        bool UpdateM_GoodsStockNum(int m_ConfigInfoID, int ProductsID, int Num, int StorageID);
        /// <summary>
        /// 返回商品数量列表
        /// </summary>
        /// <param name="m_ConfigInfoID"></param>
        /// <returns></returns>
         DataTable GetM_GoodsStockList(int m_ConfigInfoID);
        /// <summary>
        /// 获取商品仓库数量列表
        /// </summary>
        /// <param name="m_ConfigInfoID"></param>
        /// <param name="m_GoodsID"></param>
        /// <returns></returns>
          DataTable GetM_GoodsStockList(int m_ConfigInfoID, int m_GoodsID);
        /// <summary>
        /// 更新商品总数量
        /// </summary>
        /// <param name="m_ConfigInfoID"></param>
        /// <param name="m_GoodsID"></param>
        /// <param name="Num"></param>
        /// <returns></returns>
           bool UpdateM_GoodsNum(int m_ConfigInfoID, int m_GoodsID, int Num);
        /// <summary>
        /// 更新商品总数量
        /// </summary>
        /// <param name="m_ConfigInfoID"></param>
        /// <param name="num_iid"></param>
        /// <param name="Num"></param>
        /// <returns></returns>
            bool UpdateM_GoodsNum(int m_ConfigInfoID, long num_iid, int Num);
        /// <summary>
        /// 推荐
        /// </summary>
        /// <param name="m_GoodsID"></param>
         void RecommendAddM_Goods(int m_GoodsID);
	/// <summary>
        /// 取消推荐
        /// </summary>
        /// <param name="m_GoodsID"></param>
         void RecommendDeleteM_Goods(int m_GoodsID);
        #endregion

        #region  Sku扩展信息

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool ExistsM_GoodsSkuExtraInfo(int m_GoodsSkuInfoID, int extra_id, int sku_id);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int AddM_GoodsSkuExtraInfo(M_GoodsSkuExtraInfo model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        void UpdateM_GoodsSkuExtraInfo(M_GoodsSkuExtraInfo model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        void DeleteM_GoodsSkuExtraInfo(int m_GoodsSkuExtraInfoID);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        M_GoodsSkuExtraInfo GetM_GoodsSkuExtraInfoModel(int m_GoodsSkuExtraInfoID);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetM_GoodsSkuExtraInfoList(string strWhere);
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        DataSet GetM_GoodsSkuExtraInfoList(int Top, string strWhere, string filedOrder);
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        DataTable GetM_GoodsSkuExtraInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName);
        #endregion

        #region  Sku信息

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool ExistsM_GoodsSkuInfo(int m_ConfigInfoID, int m_Type, int m_ObjID, int sku_id, int num_iid);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int AddM_GoodsSkuInfo(M_GoodsSkuInfo model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        void UpdateM_GoodsSkuInfo(M_GoodsSkuInfo model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        void DeleteM_GoodsSkuInfo(int m_GoodsSkuInfoID);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        M_GoodsSkuInfo GetM_GoodsSkuInfoModel(int m_GoodsSkuInfoID);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetM_GoodsSkuInfoList(string strWhere);
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        DataSet GetM_GoodsSkuInfoList(int Top, string strWhere, string filedOrder);
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        DataTable GetM_GoodsSkuInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName);
        #endregion

        #region 子图片信息

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool ExistsM_ImgInfo(int m_ConfigInfoID, int m_Type, int m_ObjID, int m_id);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int AddM_ImgInfo(M_ImgInfo model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        void UpdateM_ImgInfo(M_ImgInfo model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        void DeleteM_ImgInfo(int m_ImgInfoID);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        M_ImgInfo GetM_ImgInfoModel(int m_ImgInfoID);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetM_ImgInfoList(string strWhere);
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        DataSet GetM_ImgInfoList(int Top, string strWhere, string filedOrder);
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        DataTable GetM_ImgInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName);
        #endregion

        #region  地址信息

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool ExistsM_LocationInfo(int m_ConfigInfoID, int m_Type, int m_ObjID, string address);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int AddM_LocationInfo(M_LocationInfo model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        void UpdateM_LocationInfo(M_LocationInfo model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        void DeleteM_LocationInfo(int m_LocationID);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        M_LocationInfo GetM_LocationInfoModel(int m_LocationID);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetM_LocationInfoList(string strWhere);
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        DataSet GetM_LocationInfoList(int Top, string strWhere, string filedOrder);
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        DataTable GetM_LocationInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName);
        #endregion

        #region  交易留言凭证图片信息

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool ExistsM_MessageImgInfo(int m_MessageInfoID, string url);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int AddM_MessageImgInfo(M_MessageImgInfo model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        void UpdateM_MessageImgInfo(M_MessageImgInfo model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        void DeleteM_MessageImgInfo(int m_MessageImgInfoID);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        M_MessageImgInfo GetM_MessageImgInfoModel(int m_MessageImgInfoID);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetM_MessageImgInfoList(string strWhere);
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        DataSet GetM_MessageImgInfoList(int Top, string strWhere, string filedOrder);
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        DataTable GetM_MessageImgInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName);
        #endregion

        #region  交易留言凭证信息

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool ExistsM_MessageInfo(int m_ConfigInfoID, int m_Type, int m_ObjID, int m_id);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int AddM_MessageInfo(M_MessageInfo model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        void UpdateM_MessageInfo(M_MessageInfo model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        void DeleteM_MessageInfo(int m_MessageInfoID);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        M_MessageInfo GetM_MessageInfoModel(int m_MessageInfoID);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetM_MessageInfoList(string strWhere);
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        DataSet GetM_MessageInfoList(int Top, string strWhere, string filedOrder);
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        DataTable GetM_MessageInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName);
        #endregion

        #region  订单信息

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool ExistsM_OrderInfo(int m_ConfigInfoID, int m_TradeInfoID, int num_iid);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int AddM_OrderInfo(M_OrderInfo model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        void UpdateM_OrderInfo(M_OrderInfo model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        void DeleteM_OrderInfo(int m_OrderInfoID);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        M_OrderInfo GetM_OrderInfoModel(int m_OrderInfoID);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetM_OrderInfoList(string strWhere);
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        DataSet GetM_OrderInfoList(int Top, string strWhere, string filedOrder);
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        DataTable GetM_OrderInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName);
        #endregion

        #region  订单优惠信息

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool ExistsM_OrderPromotionDetailInfo(int m_Type, int m_ObjID, int m_id);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int AddM_OrderPromotionDetailInfo(M_OrderPromotionDetailInfo model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        void UpdateM_OrderPromotionDetailInfo(M_OrderPromotionDetailInfo model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        void DeleteM_OrderPromotionDetailInfo(int m_Order_PromotionDetailInfoID);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        M_OrderPromotionDetailInfo GetM_OrderPromotionDetailInfoModel(int m_Order_PromotionDetailInfoID);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetM_OrderPromotionDetailInfoList(string strWhere);
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        DataSet GetM_OrderPromotionDetailInfoList(int Top, string strWhere, string filedOrder);
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        DataTable GetM_OrderPromotionDetailInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName);
        #endregion

        #region  退款信息

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool ExistsM_OrderRefundInfo(int m_ConfigInfoID, int num_iid, int refund_id, int tid, int oid, string alipay_no);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int AddM_OrderRefundInfo(M_OrderRefundInfo model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        void UpdateM_OrderRefundInfo(M_OrderRefundInfo model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        void DeleteM_OrderRefundInfo(int m_OrderRefundInfoID);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        M_OrderRefundInfo GetM_OrderRefundInfoModel(int m_OrderRefundInfoID);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetM_OrderRefundInfoList(string strWhere);
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        DataSet GetM_OrderRefundInfoList(int Top, string strWhere, string filedOrder);
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        DataTable GetM_OrderRefundInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName);
        #endregion

        #region  产品结构信息

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool ExistsM_ProductInfo(int m_ConfigInfoID, int ProductsID, long product_id);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int AddM_ProductInfo(M_ProductInfo model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        void UpdateM_ProductInfo(M_ProductInfo model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        void DeleteM_ProductInfo(int m_ProductInfoID);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        M_ProductInfo GetM_ProductInfoModel(int m_ProductInfoID);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetM_ProductInfoList(string strWhere);
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        DataSet GetM_ProductInfoList(int Top, string strWhere, string filedOrder);
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        DataTable GetM_ProductInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName);
        #endregion

        #region 交易确认收货费用信息
        bool ExistsM_ConfirmFeeInfo(int m_Type, int m_ObjID);
        int AddM_ConfirmFeeInfo(M_ConfirmFeeInfo model);
        void UpdateM_ConfirmFeeInfo(M_ConfirmFeeInfo model);
        void DeleteM_ConfirmFeeInfo(int m_ConfirmFeeInfoID);
        M_ConfirmFeeInfo GetM_ConfirmFeeInfoModel(int m_ConfirmFeeInfoID);
        DataSet GetM_ConfirmFeeInfoList(string strWhere);
        DataSet GetM_ConfirmFeeInfoList(int Top, string strWhere, string filedOrder);
        DataTable GetM_ConfirmFeeInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName);

        #endregion

        #region 物流信息
            bool ExistsM_ShippingInfo(int m_ShippingInfoID);
            int AddM_ShippingInfo(M_ShippingInfo model);
            void UpdateM_ShippingInfo(M_ShippingInfo model);
            void DeleteM_ShippingInfo(int m_ShippingInfoID);
            M_ShippingInfo GetM_ShippingInfoModel(int m_ShippingInfoID);
            DataSet GetM_ShippingInfoList(string strWhere);
            DataSet GetM_ShippingInfoList(int Top, string strWhere, string filedOrder);
            DataTable GetM_ShippingInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName);
        #endregion

        #region 属性图片信息

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool ExistsM_PropImgInfo(int m_ConfigInfoID, int m_Type, int m_ObjID, long m_id, long product_id);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int AddM_PropImgInfo(M_PropImgInfo model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        void UpdateM_PropImgInfo(M_PropImgInfo model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        void DeleteM_PropImgInfo(int m_PropImgInfoID);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        M_PropImgInfo GetM_PropImgInfoModel(int m_PropImgInfoID);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetM_PropImgInfoList(string strWhere);
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        DataSet GetM_PropImgInfoList(int Top, string strWhere, string filedOrder);
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        DataTable GetM_PropImgInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName);
        #endregion

        #region  交易地址信息

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool ExistsM_ShoppingAddressInfo(int m_ConfigInfoID, int m_Type, int m_ObjID, int address_id);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int AddM_ShoppingAddressInfo(M_ShoppingAddressInfo model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        void UpdateM_ShoppingAddressInfo(M_ShoppingAddressInfo model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        void DeleteM_ShoppingAddressInfo(int m_ShoppingAddressInfoID);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        M_ShoppingAddressInfo GetM_ShoppingAddressInfoModel(int m_ShoppingAddressInfoID);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetM_ShoppingAddressInfoList(string strWhere);
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        DataSet GetM_ShoppingAddressInfoList(int Top, string strWhere, string filedOrder);
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        DataTable GetM_ShoppingAddressInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName);
        #endregion

        #region  网店商品库存信息

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool ExistsM_StockInfo(int m_ConfigInfoID, int ProductsID, int StorageID);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int AddM_StockInfo(M_StockInfo model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        void UpdateM_StockInfo(M_StockInfo model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        void DeleteM_StockInfo(int m_StockInfoID);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        M_StockInfo GetM_StockInfoModel(int m_StockInfoID);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetM_StockInfoList(string strWhere);
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        DataSet GetM_StockInfoList(int Top, string strWhere, string filedOrder);
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        DataTable GetM_StockInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName);
        #endregion

        #region  交易超时信息

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool ExistsM_TimeOutInfo(int m_ConfigInfoID, int m_Type, int m_ObjID, int remind_type);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int AddM_TimeOutInfo(M_TimeOutInfo model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        void UpdateM_TimeOutInfo(M_TimeOutInfo model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        void DeleteM_TimeOutInfo(int m_TimeOutInfoID);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        M_TimeOutInfo GetM_TimeOutInfoModel(int m_TimeOutInfoID);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetM_TimeOutInfoList(string strWhere);
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        DataSet GetM_TimeOutInfoList(int Top, string strWhere, string filedOrder);
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        DataTable GetM_TimeOutInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName);
        #endregion

        #region  交易信息

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool ExistsM_TradeInfo(int m_ConfigInfoID, long tid);
        int ExistsM_TradeInfoAndReID(int m_ConfigInfoID, long tid);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int AddM_TradeInfo(M_TradeInfo model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        void UpdateM_TradeInfo(M_TradeInfo model);
        /// <summary>
        /// 更新交易状态
        /// </summary>
        /// <param name="m_TradeInfoID"></param>
        /// <param name="status"></param>
         void UpdateM_TradeStatus(int m_TradeInfoID, string status);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        void DeleteM_TradeInfo(int m_TradeInfoID);
        void DeleteM_TradeInfo(int m_ConfigInfoID, int m_TradeInfoID);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        M_TradeInfo GetM_TradeInfoModel(int m_TradeInfoID);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetM_TradeInfoList(string strWhere);
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        DataSet GetM_TradeInfoList(int Top, string strWhere, string filedOrder);
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        DataTable GetM_TradeInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName);
        #endregion

        #region  网店客户信息

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool ExistsM_UserInfo(int m_ConfigInfoID, long user_id, string uid);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int AddM_UserInfo(M_UserInfo model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        void UpdateM_UserInfo(M_UserInfo model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        void DeleteM_UserInfo(int m_UserInfoID);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        M_UserInfo GetM_UserInfoModel(int m_UserInfoID);
        M_UserInfo GetM_UserInfoModel(int m_ConfigInfoID, long user_id, string uid);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetM_UserInfoList(string strWhere);
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        DataSet GetM_UserInfoList(int Top, string strWhere, string filedOrder);
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        DataTable GetM_UserInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName);
        #endregion

        #region  视频信息

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool ExistsM_VideoInfo(int m_ConfigInfoID, int m_Type, int m_ObjID, int video_id);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int AddM_VideoInfo(M_VideoInfo model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        void UpdateM_VideoInfo(M_VideoInfo model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        void DeleteM_VideoInfo(int m_VideoInfoID);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        M_VideoInfo GetM_VideoInfoModel(int m_VideoInfoID);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetM_VideoInfoList(string strWhere);
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        DataSet GetM_VideoInfoList(int Top, string strWhere, string filedOrder);
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        DataTable GetM_VideoInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName);
        #endregion

        #region 商品类目
        bool ExistsM_GoodsCatInfo(int m_ConfigInfoID, long cid);
        int AddM_GoodsCatInfo(M_GoodsCatInfo model);
        void UpdateM_GoodsCatInfo(M_GoodsCatInfo model);
        void DeleteM_GoodsCatInfo(int m_GoodsCatInfoID);
        M_GoodsCatInfo GetM_GoodsCatInfoModel(int m_GoodsCatInfoID);
        DataSet GetM_GoodsCatInfoList(string strWhere);
        DataSet GetM_GoodsCatInfoList(int Top, string strWhere, string filedOrder);
        DataTable GetM_GoodsCatInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName);
        /// <summary>
        /// 批量添加商品类目
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        bool AddM_GoodsCatInfoByDataTable(DataTable dt, int m_ConfigInfoID);
        /// <summary>
        /// 取商品类目最后更新时间
        /// </summary>
        /// <returns></returns>
        DateTime GetM_GoodsCatLastTime(int m_ConfigInfoID);
        /// <summary>
        /// 清理商品类目库
        /// </summary>
        /// <param name="m_ConfigInfoID"></param>
        void DeleteM_GoodsCatAll(int m_ConfigInfoID);
        #endregion

        #region 快递模板
         bool ExistsM_ExpressTemplatesInfo(string mName);
/// <summary>
        /// 增加一条数据
        /// </summary>
         int AddM_ExpressTemplatesInfo(M_ExpressTemplatesInfo model);
	/// <summary>
        /// 更新一条数据
        /// </summary>
         bool UpdateM_ExpressTemplatesInfo(M_ExpressTemplatesInfo model);
	/// <summary>
        /// 删除一条数据
        /// </summary>
         bool DeleteM_ExpressTemplatesInfo(int m_ExpressTemplatesID);
	/// <summary>
        /// 删除一条数据
        /// </summary>
         bool DeleteM_ExpressTemplatesInfoList(string m_ExpressTemplatesIDlist);
	/// <summary>
        /// 得到一个对象实体
        /// </summary>
         M_ExpressTemplatesInfo GetM_ExpressTemplatesInfoModel(int m_ExpressTemplatesID);
	/// <summary>
        /// 获得数据列表
        /// </summary>
         DataSet GetM_ExpressTemplatesInfoList(string strWhere);
	/// <summary>
        /// 获得前几行数据
        /// </summary>
         DataSet GetM_ExpressTemplatesInfoList(int Top, string strWhere, string filedOrder);
	/// <summary>
        /// 分页获取数据列表
        /// </summary>
         DataTable GetM_ExpressTemplatesInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName);

        #endregion

         #region 发货单
        /// <summary>
        /// 是否存在该记录
        /// </summary>
         bool ExistsM_SendGoodsInfo(int OrderID, string m_TradeInfoID);
		/// <summary>
        /// 增加一条数据
        /// </summary>
         int AddM_SendGoodsInfo(M_SendGoodsInfo model);
		/// <summary>
        /// 更新一条数据
        /// </summary>
         bool UpdateM_SendGoodsInfo(M_SendGoodsInfo model);
		/// <summary>
        /// 删除一条数据
        /// </summary>
         bool DeleteM_SendGoodsInfo(int m_SendGoodsID);
		/// <summary>
        /// 删除一条数据
        /// </summary>
         bool DeleteM_SendGoodsInfoList(string m_SendGoodsIDlist);
		/// <summary>
        /// 得到一个对象实体
        /// </summary>
         M_SendGoodsInfo GetM_SendGoodsInfoModel(int m_SendGoodsID);
		/// <summary>
        /// 获得数据列表
        /// </summary>
         DataSet GetM_SendGoodsInfoList(string strWhere);
		/// <summary>
        /// 获得前几行数据
        /// </summary>
         DataSet GetM_SendGoodsInfoList(int Top, string strWhere, string filedOrder);
		/// <summary>
        /// 分页获取数据列表
        /// </summary>
         DataTable GetM_SendGoodsInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName);

        /// <summary>
        /// 网购交易系统编号返回网购发货单
        /// </summary>
        /// <param name="m_TradeInfoID"></param>
        /// <returns></returns>
          M_SendGoodsInfo GetM_SendGoodsInfoModelBym_TradeInfoID(int m_TradeInfoID);
	    /// <summary>
        /// 指定发货单返回网购发货单
        /// </summary>
        /// <param name="OrderID"></param>
        /// <returns></returns>
         M_SendGoodsInfo GetM_SendGoodsInfoModelByOrderID(int OrderID);
         #endregion

        #endregion
        
        #region purchasingpayment
         DataTable getPayment();
        DataTable GetPaymentInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName);
        DataTable GetPurchasingPaymentReport(int sObjectType, DateTime sDate, int ReType);
        #endregion

        #region proceeds
        DataTable GetProceedsReport(int sObjectType, DateTime sDate, int ReType);
        #endregion

        #region storehouseProductPrice
        bool GetStorehouseProductPriceInfoList(int StoresID, string StCode, int ProductsID, string ProductsName, string ProductsBarcode, decimal pPrice, DateTime pAppendTime);
        DataTable GetStNumByStName(string stName);
        int AddStorehouseStorageProductsPriceInfo(storehouseproductsprice storehouseStorage);
        DataTable GetStorehousePriceInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName);
        int[] StorehouseStoragePriceSyn();
        void DeleteStoragesPriceInfo(string ProductID);
        storehouseproductsprice GetStorehouseProductsPriceInfoModel(int ProductPriceID);
        int UpdateStorehouseStoragePriceInfo(storehouseproductsprice pp);
        string getPricePnumByPname(string pName);
        bool GetStorehousePriceInfoList(int StoresID, string StCode, int ProductsID, DateTime pAppendTime);
        #endregion

        #region warehouseinventory
        DataTable getsManagerByStorage();
        bool AddWarehouseList(WarehouseInventoryInfo sInventoryInfo);
        bool UpdateWarehouseList(WarehouseInventoryInfo sInventoryInfo);
        DataTable getInventoryInfoList(int storageID, DateTime sAppendTime);
        DataSet getStockInfo();
        WarehouseInventoryInfo GetWarehouseInventoryInfoModel(int StocktakeID);
        int UpdateStorageInventoryInfo(WarehouseInventoryInfo pp);
        bool getWarehouseInfo(int sID, DateTime sAppendTime);
        DataTable GetWarehouseViewInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName);
        string getSnameByScode(int sCode);
        WarehouseInventoryInfo GetInventoryInfoModel(int StockID);
        DataTable getStorageNameByID(int storageID);
        DataTable getProductsNameByID(int productID);
        #endregion

        #region 店员门店查询
        /// <summary>
        /// 获得营业员名称
        /// </summary>
        /// <returns></returns>
        DataTable getStaffName();
         /// <summary>
         /// 根据营业员名称获得门店名称
         /// </summary>
         /// <param name="staffName"></param>
         /// <returns></returns>
        DataTable getStorehouseNameByStaffName(string staffName);
        /// <summary>
        /// 获得查询的行级
        /// </summary>
        /// <param name="staffName"></param>
        /// <returns></returns>
        DataTable getStorehouseNameByNameList(string staffName);
        /// <summary>
        /// 获得每个门店，每年，每月的销售数量及销售金额
        /// </summary>
        /// <param name="dtYear"></param>
        /// <param name="storesID"></param>
        /// <returns></returns>
        DataTable getProductsDetaisMonth(string dtYear, int storesID);
        /// <summary>
        /// 获得销售年份
        /// </summary>
        /// <returns></returns>
        DataTable getSalesYear();
        /// <summary>
        /// 根据门店名称获得门店ID
        /// </summary>
        /// <param name="sName"></param>
        /// <returns></returns>
        int getStorageIDBystorageName(string sName);
        /// <summary>
        /// 获得店员每月的门店数量
        /// </summary>
        /// <param name="sAppendDate"></param>
        /// <param name="staffID"></param>
        /// <returns></returns>
        DataTable getStorageNum(string sAppendDate, int staffID);
        #endregion

        #region 仓库报损数据
        /// <summary>
        /// 获得仓库名称
        /// </summary>
        /// <returns></returns>
        DataTable getWorehouseName();
        /// <summary>
        /// 根据仓库编号获得产品信息
        /// </summary>
        /// <param name="sid"></param>
        /// <returns></returns>
        DataTable getProductsInfoByStorageID(int aid, int sid, DateTime date, DateTime eDate);
        /// <summary>
        /// 调用存储过程获得联营产品报损详情
        /// </summary>
        /// <param name="sDate"></param>
        /// <param name="inyAssociated"></param>
        /// <param name="inyStorageID"></param>
        /// <returns></returns>
        DataTable bindProductsLoss(DateTime bDate, DateTime eDate, int inyAssociated, int inyStorageID, int export);
        /// <summary>
        /// 获得仓库产品报损单据编号以及单据时间
        /// </summary>
        /// <param name="bDate"></param>
        /// <param name="eDate"></param>
        /// <param name="inyStorageID"></param>
        /// <param name="inyProductsID"></param>
        /// <returns></returns>
        DataTable getProductsLossDetails(DateTime bDate, DateTime eDate, int inyStorageID, int inyProductsID);
        #endregion

        #region 购销明细排行
        /// <summary>
        /// 获得客户购销明细
        /// </summary>
        /// <param name="bDate"></param>
        /// <param name="eDate"></param>
        /// <param name="classes"></param>
        /// <returns></returns>
        DataTable getBuySaleDetalsOfStorehouse(DateTime bDate, DateTime eDate, int classes);
        #endregion

        #region 联营统计
        /// <summary>
        /// 根据区域id获得门店名称
        /// </summary>
        /// <param name="rid"></param>
        /// <returns></returns>
        DataTable getStorehouseNameByRegionID(int rid);
        /// <summary>
        /// 获取门店联营产品：包含，剔除，仅包含总数
        /// </summary>
        /// <param name="assc"></param>
        /// <param name="dtTime"></param>
        /// <returns></returns>
        DataTable getStorehouseProductsDetails(int regionID, int assc, DateTime dtTime);
        /// <summary>
        /// 联营产品库存详情
        /// </summary>
        /// <param name="sID"></param>
        /// <param name="aID"></param>
        /// <param name="sDate"></param>
        /// <returns></returns>
        DataTable getProductDetailsByStorehouseID(int sID, int aID, DateTime sDate, int qID);
        /// <summary>
        /// 门店详情
        /// </summary>
        /// <returns></returns>
        DataTable getStoresName(DateTime dt);
        #endregion

        #region  产品日均销量统计
        /// <summary>
        /// 统计购销产品日均销量
        /// </summary>
        /// <param name="tTpye"></param>
        /// <param name="bDate"></param>
        /// <param name="eDate"></param>
        /// <returns></returns>
        DataTable getProductsDay_Sales_Details(int tTpye, DateTime bDate, DateTime eDate);
        /// <summary>
        /// 获得单品日均销量在各门店的详情
        /// </summary>
        /// <param name="productsID"></param>
        /// <param name="bDate"></param>
        /// <param name="eDate"></param>
        /// <param name="tType"></param>
        /// <returns></returns>
        DataTable getProducts_Sales_Storehouse(int productsID, DateTime bDate, DateTime eDate, int tType);
        #endregion

        #region  产品日均销量统计
       
        /// <summary>
        /// 获得产品同比日均销量
        /// </summary>
        /// <param name="productsID"></param>
        /// <param name="bDate"></param>
        /// <param name="eDate"></param>
        /// <param name="tType"></param>
        /// <returns></returns>
        DataTable getProducts_Sales_Details_year_basis(int tTpye, int productsID, DateTime bDate, DateTime eDate);
        /// <summary>
        /// 选择月份时候，获得环比产品日均销量
        /// </summary>
        /// <param name="tTpye"></param>
        /// <param name="productsID"></param>
        /// <param name="bDate"></param>
        /// <param name="eDate"></param>
        /// <returns></returns>
        DataTable Products_Sale_Details_year_annulus(int tTpye, int productsID, DateTime bDate, DateTime eDate);
        /// <summary>
        /// 获得门店销售同比日均销量
        /// </summary>
        /// <param name="productsID"></param>
        /// <param name="bDate"></param>
        /// <param name="eDate"></param>
        /// <param name="tType"></param>
        /// <returns></returns>
        DataTable Products_sales_storehouse_basis(int productsID, int storesID, DateTime bDate, DateTime eDate, int tType);
        /// <summary>
        /// 获得门店产品环比日均销量
        /// </summary>
        /// <param name="productsID"></param>
        /// <param name="storesID"></param>
        /// <param name="bDate"></param>
        /// <param name="eDate"></param>
        /// <param name="tType"></param>
        /// <returns></returns>
        DataTable Products_sales_storehouse_annulus(int productsID, int storesID, DateTime bDate, DateTime eDate, int tType);
        #endregion

        #region  费用统计
        /// <summary>
        /// 返回科目的使用情况
        /// </summary>
        /// <param name="classID"></param>
        /// <returns></returns>
        int getClassCount(int classID);
        /// <summary>
        /// 获得科目方向
        /// </summary>
        /// <param name="classID"></param>
        /// <returns></returns>
        string ClassDiretion(int classID);
        /// <summary>
        /// 科目详细
        /// </summary>
        /// <returns></returns>
        DataTable getObjectsList();
        /// <summary>
        /// 获得科目名称
        /// </summary>
        /// <param name="sid"></param>
        /// <returns></returns>
        DataTable getObjectsListName(int sid);
        /// <summary>
        /// 获得区域门店详情
        /// </summary>
        /// <returns></returns>
        DataTable getRegionList(int sid, string kid, DateTime bDate, DateTime eDate);
        /// <summary>
        /// 获得客户名称
        /// </summary>
        /// <param name="rID"></param>
        /// <returns></returns>
        DataTable getStorsList(int sid, string rID, DateTime bDate, DateTime eDate);
        /// <summary>
        /// 获得科目选择名称
        /// </summary>
        /// <param name="treeNode"></param>
        /// <returns></returns>
        DataTable getTreeName(string treeNode);
        /// <summary>
        /// 费用统计：客户—科目
        /// </summary>
        /// <param name="storesId"></param>
        /// <param name="kType"></param>
        /// <param name="type"></param>
        /// <param name="bDate"></param>
        /// <param name="eDate"></param>
        /// <returns></returns>
        DataTable getCostOfStorehouse(int storesId, string kType, int type, DateTime bDate, DateTime eDate);
        /// <summary>
        /// 门店费用详细
        /// </summary>
        /// <param name="selectID"></param>
        /// <param name="sid"></param>
        /// <param name="kid"></param>
        /// <param name="bDate"></param>
        /// <param name="eDate"></param>
        /// <returns></returns>
        DataTable getCostOfStorehouseDetails(int selectID, int sid, string kid, DateTime bDate, DateTime eDate);
        /// <summary>
        /// 循环找到科目孩节点
        /// </summary>
        /// <param name="kid"></param>
        /// <returns></returns>
        string getTreeChildrenCount(string kid);
        /// <summary>
        /// 费用科目统计详细
        /// </summary>
        /// <param name="sID"></param>
        /// <param name="bDate"></param>
        /// <param name="eDate"></param>
        /// <param name="kID"></param>
        /// <returns></returns>
        DataTable getCostOfClassDetails(int sID, DateTime bDate, DateTime eDate, int kID);
        /// <summary>
        /// 科目选择时科目名称
        /// </summary>
        /// <param name="kid"></param>
        /// <returns></returns>
        DataTable getClassName(string kid);
        /// <summary>
        /// 获得科目的统计费用
        /// </summary>
        /// <param name="type">借方或贷方</param>
        /// <param name="kid">科目</param>
        /// <param name="bDate">开始日期</param>
        /// <param name="eDate">结束日期</param>
        /// <returns></returns>
        DataTable getClassCost(int type, string kid, DateTime bDate, DateTime eDate);

        /// <summary>
        /// 获得业务员名称
        /// </summary>
        /// <param name="sid"></param>
        /// <param name="bDate"></param>
        /// <param name="eDate"></param>
        /// <returns></returns>
        DataTable getStaffName(int sid, DateTime bDate, DateTime eDate, int kID);
        /// <summary>
        /// 获得业务员费用
        /// </summary>
        /// <param name="sid"></param>
        /// <param name="bDate"></param>
        /// <param name="eDate"></param>
        /// <param name="kID"></param>
        /// <param name="staffID"></param>
        /// <returns></returns>
        DataTable getCostOfStaffID(int sid, DateTime bDate, DateTime eDate, int kID, int staffID);
        /// <summary>
        /// 获得业务费用明细
        /// </summary>
        /// <param name="sid"></param>
        /// <param name="bDate"></param>
        /// <param name="eDate"></param>
        /// <param name="staffID"></param>
        /// <param name="kID"></param>
        /// <returns></returns>
        DataTable getCostOfStaffDetails(int sid, DateTime bDate, DateTime eDate, int staffID, string kID);
        /// <summary>
        /// 获得门店赠品费用
        /// </summary>
        /// <param name="bDate"></param>
        /// <param name="eDate"></param>
        /// <returns></returns>
        DataTable getGiftCost(int sID, DateTime bDate, DateTime eDate);
        /// <summary>
        /// 获得门店
        /// </summary>
        /// <param name="bDate"></param>
        /// <param name="eDate"></param>
        /// <returns></returns>
        DataTable getGiftCost_storehouse(DateTime bDate, DateTime eDate);
        /// <summary>
        /// 获得赠品费用明细
        /// </summary>
        /// <param name="sid"></param>
        /// <param name="pid"></param>
        /// <param name="bDate"></param>
        /// <param name="eDate"></param>
        /// <returns></returns>
        DataTable getGiftCost_details(int sid, int pid, DateTime bDate, DateTime eDate);
        /// <summary>
        /// 获得区域毛利
        /// </summary>
        /// <param name="moriType"></param>
        /// <param name="saleType"></param>
        /// <param name="bDate"></param>
        /// <param name="eDate"></param>
        /// <returns></returns>
        DataTable getMoriOfRegion(int moriType, int saleType, DateTime bDate, DateTime eDate);
        #endregion

        #region 导出
        DataTable getProductsLossExportData(DateTime bDate, DateTime eDate, int isAssocite);
        DataTable getStorageSalesExportData(DateTime bDate, int Type, int checkValue);
        
        DataTable getReportOutExport(DateTime bDate, int checkValue);
        #endregion

        #region 导出数据转发Email
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool ExistsDataToMailInfo(int dDataType, int dDateType, string dEmail);
	/// <summary>
        /// 增加一条数据
        /// </summary>
         int AddDataToMailInfo(DataToMailInfo model);
	/// <summary>
        /// 更新一条数据
        /// </summary>
         bool UpdateDataToMailInfo(DataToMailInfo model);
	/// <summary>
        /// 删除一条数据
        /// </summary>
         bool DeleteDataToMailInfo(int DataToMaillID);
	/// <summary>
        /// 删除一条数据
        /// </summary>
         bool DeleteDataToMailInfoList(string DataToMaillIDlist);
	/// <summary>
        /// 得到一个对象实体
        /// </summary>
         DataToMailInfo GetDataToMailInfoModel(int DataToMaillID);
	/// <summary>
        /// 获得数据列表
        /// </summary>
         DataSet GetDataToMailInfoList(string strWhere);
	/// <summary>
        /// 获得前几行数据
        /// </summary>
         DataSet GetDataToMailInfoList(int Top, string strWhere, string filedOrder);
	/// <summary>
        /// 分页获取数据列表
        /// </summary>
         DataTable GetDataToMailInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName);
        #endregion

         #region 余额及发生额统计
         DataTable getOccurrenceAndBalanceDetails(DateTime bDate, DateTime eDate, int feeID, int status);
         DataTable get_Occurrence_Balance_Details(int objectID, DateTime bDate, DateTime eDate);
         int get_Occurrence_Balance_Details_Count(int objectID, DateTime bDate, DateTime eDate);
         DataTable get_Occurrence_Balance_addMonth(int objectID, DateTime bDate, DateTime eDate);
         DataTable getLastYearMoney(int objectID);
         DataTable getMonthCost(int objectID, DateTime bDate, DateTime eDate, int oMonth, int sType, int status);
         DataTable getSubjectNameAndID(int objectID);
         DataTable getMonthBySubjectAndDateTime(int objectID, DateTime bDate, DateTime eDate);
         string getMonthBySubjectAndDateTime_Max(int objectID, DateTime bDate, DateTime eDate);
         DataTable getFeeSubjectID(DateTime bDate, DateTime eDate);
         #endregion

		//20130812
		#region tbProductFieldInfo
		bool ExistsProductField (int ProductClassID, string pfName);
		int AddProductField (ProductFieldInfo model);
		int UpdateProductField(ProductFieldInfo model);
		void DeleteProductField(int ProductFieldID);
		void DeleteProductField (string ProductFieldID);
		ProductFieldInfo GetProductFieldModel(int ProductFieldID);
		DataSet GetProductFieldList(string strWhere);
		DataTable GetProductFieldList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName);

		#endregion

		#region  tbProductsFieldValueInfo
		int AddProductsFieldValue(ProductsFieldValueInfo model);
		void UpdateProductsFieldValue(ProductsFieldValueInfo model);
		void DeleteProductsFieldValue(int ProductsFieldValueID);
		void DeleteProductsFieldValue(string ProductsFieldValueID);
		ProductsFieldValueInfo GetProductsFieldValueModel(int ProductsFieldValueID);
		DataSet GetProductsFieldValueList(string strWhere);
		DataTable GetProductsFieldValueList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName);
		bool AddProductsFieldValue (int ProductsID, ProductFieldValueJson fJson);
		bool UpdateProductsFieldValue(int ProductsID,ProductFieldValueJson fJson);
		#endregion

		#region tbStorageProductLogInfo
		/// <summary>
		/// 增加一条数据
		/// </summary>
		int AddStorageProductLogInfo(StorageProductLogInfo model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		bool UpdateStorageProductLogInfo(StorageProductLogInfo model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		bool DeleteStorageProductLogInfo(int StorageProductLogID);
		/// <summary>
		/// 批量删除数据
		/// </summary>
		bool DeleteStorageProductLogInfoList(string StorageProductLogIDlist );
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		StorageProductLogInfo GetStorageProductLogInfoModel(int StorageProductLogID);
		/// <summary>
		/// 获得数据列表
		/// </summary>
		DataSet GetStorageProductLogInfoList(string strWhere);
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		DataSet GetStorageProductLogInfoList(int Top,string strWhere,string filedOrder);
		/// <summary>
		/// 获取记录总数
		/// </summary>
		int GetStorageProductLogInfoRecordCount(string strWhere);
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		DataSet GetStorageProductLogInfoListByPage(string strWhere, string orderby, int startIndex, int endIndex);
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		DataTable GetStorageProductLogInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName);

		int GetStorageProductLogCutLenFromOrderID (int OrderID);

		/// <summary>
		/// 整理发货记录并入单据详细列表返回
		/// </summary>
		/// <returns>The storage product log list IN order list.</returns>
		/// <param name="OrderID">Order I.</param>
		DataSet GetStorageProductLogListINOrderList (int OrderID);

		DataSet GetStorageList (int StorageClassID,int StorageID, int ProductsID, DateTime bDate, DateTime eDate);
		#endregion

		#region tbStorageProductLogDataInfo
		/// <summary>
		/// 增加一条数据
		/// </summary>
		int AddStorageProductLogDataInfo(StorageProductLogDataInfo model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		bool UpdateStorageProductLogDataInfo(StorageProductLogDataInfo model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		bool DeleteStorageProductLogDataInfo(int StorageProductLogDataID);
		/// <summary>
		/// 批量删除数据
		/// </summary>
		bool DeleteStorageProductLogDataInfoList(string StorageProductLogDataIDlist );
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		StorageProductLogDataInfo GetStorageProductLogDataInfoModel(int StorageProductLogDataID);
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		StorageProductLogDataInfo DataRowToStorageProductLogDataInfoModel(DataRow row);
		/// <summary>
		/// 获得数据列表
		/// </summary>
		DataSet GetStorageProductLogDataInfoList(string strWhere);
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		DataSet GetStorageProductLogDataInfoList(int Top,string strWhere,string filedOrder);
		/// <summary>
		/// 获取记录总数
		/// </summary>
		int GetStorageProductLogDataInfoRecordCount(string strWhere);
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		DataSet GetStorageProductLogDataInfoListByPage(string strWhere, string orderby, int startIndex, int endIndex);
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		DataTable GetStorageProductLogDataInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName);


		#endregion


		#region 商品成本（特）
		int AddProductPriceNOAuto (ProductPriceNOAutoInfo model);
		void UpdateProductPriceNOAuto (ProductPriceNOAutoInfo model);
		void DeleteProductPriceNOAuto (int ProductPriceNOAutoID);
		void DeleteProductPriceNOAuto (string ProductPriceNOAutoID);
		ProductPriceNOAutoInfo GetProductPriceNOAutoModel (int ProductPriceNOAutoID);
		DataSet GetProductPriceNOAutoList (string strWhere);
		/// <summary>
		/// 获得最新的产品价格列表
		/// </summary>
		DataSet GetProductPriceNOAutoListNew (string strWhere);
		#endregion
    }
}
