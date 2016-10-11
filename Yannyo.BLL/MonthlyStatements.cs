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
    public class MonthlyStatements
    {
        /// <summary>
        /// 返回最新未使用的对账单号
        /// </summary>
        /// <returns></returns>
        public static string GetNewNum()
        {
            GeneralConfigInfo ManageConfig = GeneralConfigs.GetConfig();
            ManageConfig.MonthlyStatementCode = (Convert.ToInt32(Config.GeneralConfigs.GetConfig().MonthlyStatementCode.Trim()) + 1).ToString();

            GeneralConfigs.Serialiaze(ManageConfig, Utils.GetMapPath(BaseConfigs.GetSysPath + "config/general.config"));
            BaseConfigs.ResetConfig();

            return ManageConfig.MonthlyStatementCode;
        }

        #region MonthlyStatementInfo
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool ExistsMonthlyStatementInfo(string sCode)
        {
            return DatabaseProvider.GetInstance().ExistsMonthlyStatementInfo(sCode);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddMonthlyStatementInfo(MonthlyStatementInfo model)
        {
            return DatabaseProvider.GetInstance().AddMonthlyStatementInfo(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateMonthlyStatementInfo(MonthlyStatementInfo model)
        {
            DatabaseProvider.GetInstance().UpdateMonthlyStatementInfo(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteMonthlyStatementInfo(int MonthlyStatementID)
        {
            DatabaseProvider.GetInstance().DeleteMonthlyStatementInfo(MonthlyStatementID);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static MonthlyStatementInfo GetMonthlyStatementInfoModel(int MonthlyStatementID)
        {
            return DatabaseProvider.GetInstance().GetMonthlyStatementInfoModel(MonthlyStatementID);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataSet GetMonthlyStatementInfoList(string strWhere)
        {
            return DatabaseProvider.GetInstance().GetMonthlyStatementInfoList(strWhere);
        }
        /// <summary>
        /// 合计本期金额
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static decimal GetMonthlyStatementInfoListSumMoney(string strWhere)
        { 
            return DatabaseProvider.GetInstance().GetMonthlyStatementInfoListSumMoney( strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public static DataSet GetMonthlyStatementInfoList(int Top, string strWhere, string filedOrder)
        {
            return DatabaseProvider.GetInstance().GetMonthlyStatementInfoList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public static DataTable GetMonthlyStatementInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
        {
            return DatabaseProvider.GetInstance().GetMonthlyStatementInfoList(PageSize, PageIndex, strWhere, out  pagetotal, OrderType, showFName);
        }
         /// <summary>
        /// 取指定对象上期余额
        /// </summary>
        /// <param name="sObjectID"></param>
        /// <param name="sObjectType"></param>
        /// <param name="sType"></param>
        /// <returns></returns>
        public static decimal GetSObjectUpMoney(int sObjectID, int sObjectType, int sType)
        { 
            return DatabaseProvider.GetInstance().GetSObjectUpMoney( sObjectID,  sObjectType,  sType);
        }
        /// <summary>
        /// 更新对账单步骤
        /// </summary>
        /// <param name="MonthlyStatementID"></param>
        /// <param name="sSteps"></param>
        public static void UpdateMonthlyStatementSteps(int MonthlyStatementID, int sSteps)
        { 
            DatabaseProvider.GetInstance().UpdateMonthlyStatementSteps( MonthlyStatementID,  sSteps);
        }
        /// <summary>
        /// 更新凭证系统状态,只允许作废
        /// </summary>
        /// <param name="MonthlyStatementID"></param>
        public static void UpdateMonthlyStatementState(int MonthlyStatementID)
        {
            DatabaseProvider.GetInstance().UpdateMonthlyStatementState(MonthlyStatementID, 1);
        }
        #endregion

        #region MonthlyStatementDataInfo
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool ExistsMonthlyStatementDataInfo(int MonthlyStatementID, int OrderID)
        {
            return DatabaseProvider.GetInstance().ExistsMonthlyStatementDataInfo(MonthlyStatementID, OrderID);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddMonthlyStatementDataInfo(MonthlyStatementDataInfo model)
        {
            return DatabaseProvider.GetInstance().AddMonthlyStatementDataInfo(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateMonthlyStatementDataInfo(MonthlyStatementDataInfo model)
        {
            DatabaseProvider.GetInstance().UpdateMonthlyStatementDataInfo(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteMonthlyStatementDataInfo(int MonthlyStatementDataID)
        {
            DatabaseProvider.GetInstance().DeleteMonthlyStatementDataInfo(MonthlyStatementDataID);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static MonthlyStatementDataInfo GetMonthlyStatementDataInfoModel(int MonthlyStatementDataID)
        {
            return DatabaseProvider.GetInstance().GetMonthlyStatementDataInfoModel(MonthlyStatementDataID);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataSet GetMonthlyStatementDataInfoList(string strWhere)
        {
            return DatabaseProvider.GetInstance().GetMonthlyStatementDataInfoList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public static DataSet GetMonthlyStatementDataInfoList(int Top, string strWhere, string filedOrder)
        {
            return DatabaseProvider.GetInstance().GetMonthlyStatementDataInfoList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public static DataTable GetMonthlyStatementDataInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
        {
            return DatabaseProvider.GetInstance().GetMonthlyStatementDataInfoList(PageSize, PageIndex, strWhere, out  pagetotal, OrderType, showFName);
        }
        #endregion

        #region MonthlyStatementAppendDataInfo
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool ExistsMonthlyStatementAppendDataInfo(int MonthlyStatementID, int CertificateID)
        {
            return DatabaseProvider.GetInstance().ExistsMonthlyStatementAppendDataInfo(MonthlyStatementID, CertificateID);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddMonthlyStatementAppendDataInfo(MonthlyStatementAppendDataInfo model)
        {
            return DatabaseProvider.GetInstance().AddMonthlyStatementAppendDataInfo(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateMonthlyStatementAppendDataInfo(MonthlyStatementAppendDataInfo model)
        {
            DatabaseProvider.GetInstance().UpdateMonthlyStatementAppendDataInfo(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteMonthlyStatementAppendDataInfo(int MonthlyStatementAppendDataID)
        {
            DatabaseProvider.GetInstance().DeleteMonthlyStatementAppendDataInfo(MonthlyStatementAppendDataID);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static MonthlyStatementAppendDataInfo GetMonthlyStatementAppendDataInfoModel(int MonthlyStatementAppendDataID)
        {
            return DatabaseProvider.GetInstance().GetMonthlyStatementAppendDataInfoModel(MonthlyStatementAppendDataID);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataSet GetMonthlyStatementAppendDataInfoList(string strWhere)
        {
            return DatabaseProvider.GetInstance().GetMonthlyStatementAppendDataInfoList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public static DataSet GetMonthlyStatementAppendDataInfoList(int Top, string strWhere, string filedOrder)
        {
            return DatabaseProvider.GetInstance().GetMonthlyStatementAppendDataInfoList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public static DataTable GetMonthlyStatementAppendDataInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
        {
            return DatabaseProvider.GetInstance().GetMonthlyStatementAppendDataInfoList(PageSize, PageIndex, strWhere, out  pagetotal, OrderType, showFName);
        }
        #endregion

        #region MonthlyStatementWorkingLogInfo
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static  int AddMonthlyStatementWorkingLogInfo(MonthlyStatementWorkingLogInfo model)
        {
        return DatabaseProvider.GetInstance().AddMonthlyStatementWorkingLogInfo( model);
        }
	/// <summary>
        /// 更新一条数据
        /// </summary>
        public static  void UpdateMonthlyStatementWorkingLogInfo(MonthlyStatementWorkingLogInfo model)
        {
        DatabaseProvider.GetInstance().UpdateMonthlyStatementWorkingLogInfo( model);
        }
	/// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteMonthlyStatementWorkingLogInfo(int MonthlyStatementWorkingLogID)
        { 
            DatabaseProvider.GetInstance().DeleteMonthlyStatementWorkingLogInfo( MonthlyStatementWorkingLogID);
        }
	/// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static  MonthlyStatementWorkingLogInfo GetMonthlyStatementWorkingLogInfoModel(int MonthlyStatementWorkingLogID)
        {
        return DatabaseProvider.GetInstance().GetMonthlyStatementWorkingLogInfoModel( MonthlyStatementWorkingLogID);
        }
	/// <summary>
        /// 获得数据列表
        /// </summary>
        public static  DataSet GetMonthlyStatementWorkingLogInfoList(string strWhere)
        {
        return DatabaseProvider.GetInstance().GetMonthlyStatementWorkingLogInfoList( strWhere);
        }
	/// <summary>
        /// 获得前几行数据
        /// </summary>
        public static  DataSet GetMonthlyStatementWorkingLogInfoList(int Top, string strWhere, string filedOrder)
        {
        return DatabaseProvider.GetInstance().GetMonthlyStatementWorkingLogInfoList( Top,  strWhere,  filedOrder);
        }
	/// <summary>
        /// 分页获取数据列表
        /// </summary>
        public static  DataTable GetMonthlyStatementWorkingLogInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
        {
        return DatabaseProvider.GetInstance().GetMonthlyStatementWorkingLogInfoList( PageSize,  PageIndex,  strWhere, out  pagetotal,  OrderType,  showFName);
        }
	#endregion

        #region MonthlyStatementAppendMoneyDataInfo
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddMonthlyStatementAppendMoneyDataInfo(MonthlyStatementAppendMoneyDataInfo model)
        { 
        return DatabaseProvider.GetInstance().AddMonthlyStatementAppendMoneyDataInfo( model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool UpdateMonthlyStatementAppendMoneyDataInfo(MonthlyStatementAppendMoneyDataInfo model)
        { 
        return DatabaseProvider.GetInstance().UpdateMonthlyStatementAppendMoneyDataInfo( model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static bool DeleteMonthlyStatementAppendMoneyDataInfo(int MonthlyStatementAppendMoneyDataID)
        { 
        return DatabaseProvider.GetInstance().DeleteMonthlyStatementAppendMoneyDataInfo( MonthlyStatementAppendMoneyDataID);
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public static bool DeleteMonthlyStatementAppendMoneyDataInfoList(string MonthlyStatementAppendMoneyDataIDlist)
        { 
        return DatabaseProvider.GetInstance().DeleteMonthlyStatementAppendMoneyDataInfoList( MonthlyStatementAppendMoneyDataIDlist);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static MonthlyStatementAppendMoneyDataInfo GetMonthlyStatementAppendMoneyDataInfoModel(int MonthlyStatementAppendMoneyDataID)
        { 
        return DatabaseProvider.GetInstance().GetMonthlyStatementAppendMoneyDataInfoModel( MonthlyStatementAppendMoneyDataID);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataSet GetMonthlyStatementAppendMoneyDataInfoList(string strWhere)
        { 
        return DatabaseProvider.GetInstance().GetMonthlyStatementAppendMoneyDataInfoList( strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public static DataSet GetMonthlyStatementAppendMoneyDataInfoList(int Top, string strWhere, string filedOrder)
        { 
        return DatabaseProvider.GetInstance().GetMonthlyStatementAppendMoneyDataInfoList( Top,  strWhere,  filedOrder);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public static DataTable GetMonthlyStatementAppendMoneyDataInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
        { 
        return DatabaseProvider.GetInstance().GetMonthlyStatementAppendMoneyDataInfoList( PageSize,  PageIndex,  strWhere, out  pagetotal,  OrderType,  showFName);
        }
        #endregion

        /// <summary>
        /// 对账单步骤为DataTable
        /// </summary>
        public static DataTable GetMonthlyStatementSteps()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("ID", typeof(string));
            dt.Columns.Add("Other", typeof(string));

            foreach (MonthlyStatementSteps.Rewrite _MonthlyStatementStep in MonthlyStatementSteps.GetMonthlyStatementSteps().MonthlyStatementStep)
            {
                DataRow dr = dt.NewRow();
                dr["Name"] = _MonthlyStatementStep.Name;
                dr["ID"] = _MonthlyStatementStep.ID;
                dr["Other"] = _MonthlyStatementStep.Other;

                dt.Rows.Add(dr);
            }
            dt.AcceptChanges();
            return dt;
        }
        /// <summary>
        /// 对账单除了李步骤
        /// </summary>
        public class MonthlyStatementSteps
        {
            private static object lockHelper = new object();
            private static volatile MonthlyStatementSteps instance = null;
            string Files = HttpContext.Current.Server.MapPath(BaseConfigs.GetSysPath + "config/monthlystatementsteps.config");
            private System.Collections.ArrayList _MonthlyStatementSteps;
            public System.Collections.ArrayList MonthlyStatementStep
            {
                get
                {
                    return _MonthlyStatementSteps;
                }
                set
                {
                    _MonthlyStatementSteps = value;
                }
            }
            private MonthlyStatementSteps()
            {
                MonthlyStatementStep = new ArrayList();
                XmlDocument xml = new XmlDocument();
                xml.Load(Files);
                try
                {
                    XmlNode root = xml.SelectSingleNode("//MonthlyStatementSteps");
                    foreach (XmlNode n in root.ChildNodes)
                    {
                        if (n.NodeType != XmlNodeType.Comment && n.Name.ToLower() == "monthlystatementstep")
                        {
                            XmlAttribute _Name = n.Attributes["name"];//类型
                            XmlAttribute _ID = n.Attributes["id"];//系统识别编号

                            if (_Name != null && _ID != null)
                            {
                                MonthlyStatementStep.Add(new Rewrite(_Name.Value, _ID.Value, n.InnerText));
                            }
                        }
                    }
                }
                finally
                {
                    xml = null;
                }
            }
            public static MonthlyStatementSteps GetMonthlyStatementSteps()
            {
                if (instance == null)
                {
                    lock (lockHelper)
                    {
                        if (instance == null)
                        {
                            instance = new MonthlyStatementSteps();
                        }
                    }
                }
                return instance;

            }

            public static void SetInstance(MonthlyStatementSteps anInstance)
            {
                if (anInstance != null)
                    instance = anInstance;
            }

            public static void SetInstance()
            {
                SetInstance(new MonthlyStatementSteps());
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
