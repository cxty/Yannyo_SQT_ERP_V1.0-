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
    public class tbDataToMailInfo
    {
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool ExistsDataToMailInfo(int dDataType, int dDateType, string dEmail)
        {
            return DatabaseProvider.GetInstance().ExistsDataToMailInfo(dDataType, dDateType, dEmail);
        }
	/// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddDataToMailInfo(DataToMailInfo model)
        { 
            return DatabaseProvider.GetInstance().AddDataToMailInfo( model);
            }
	/// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool UpdateDataToMailInfo(DataToMailInfo model)
        { 
            return DatabaseProvider.GetInstance().UpdateDataToMailInfo( model);
            }
	/// <summary>
        /// 删除一条数据
        /// </summary>
        public static bool DeleteDataToMailInfo(int DataToMaillID)
        { 
            return DatabaseProvider.GetInstance().DeleteDataToMailInfo( DataToMaillID);
            }
	/// <summary>
        /// 删除一条数据
        /// </summary>
        public static bool DeleteDataToMailInfoList(string DataToMaillIDlist)
        {
            if (DataToMaillIDlist != "")
            {
                DataToMaillIDlist = "," + DataToMaillIDlist + ",";
                DataToMaillIDlist = Utils.ReSQLSetTxt(DataToMaillIDlist);
                return DatabaseProvider.GetInstance().DeleteDataToMailInfoList(DataToMaillIDlist);
            }
            else {
                return false;
            }
        }
	/// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static DataToMailInfo GetDataToMailInfoModel(int DataToMaillID)
        { 
            return DatabaseProvider.GetInstance().GetDataToMailInfoModel( DataToMaillID);
        }
	/// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataSet GetDataToMailInfoList(string strWhere)
        { 
            return DatabaseProvider.GetInstance().GetDataToMailInfoList( strWhere);
            }
	/// <summary>
        /// 获得前几行数据
        /// </summary>
        public static DataSet GetDataToMailInfoList(int Top, string strWhere, string filedOrder)
        { 
            return DatabaseProvider.GetInstance().GetDataToMailInfoList( Top,  strWhere,  filedOrder);
            }
	/// <summary>
        /// 分页获取数据列表
        /// </summary>
        public static DataTable GetDataToMailInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
        { 
            return DatabaseProvider.GetInstance().GetDataToMailInfoList( PageSize,  PageIndex,  strWhere, out  pagetotal,  OrderType,  showFName);
            }


        /// <summary>
        /// 对账单步骤为DataTable
        /// </summary>
        public static DataTable GetDataToMailDataTypes()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("ID", typeof(string));
            dt.Columns.Add("Other", typeof(string));

            foreach (DataToMailDataTypes.Rewrite _DataType in DataToMailDataTypes.GetDataToMailDataTypes().DataType)
            {
                DataRow dr = dt.NewRow();
                dr["Name"] = _DataType.Name;
                dr["ID"] = _DataType.ID;
                dr["Other"] = _DataType.Other;
                dt.Rows.Add(dr);
            }
            dt.AcceptChanges();
            return dt;
        }
        /// <summary>
        /// 统计类型
        /// </summary>
        public class DataToMailDataTypes
        {
            private static object lockHelper = new object();
            private static volatile DataToMailDataTypes instance = null;
            string Files = HttpContext.Current.Server.MapPath(BaseConfigs.GetSysPath + "config/datatomail.config");
            private System.Collections.ArrayList _DataToMailDataTypes;
            public System.Collections.ArrayList DataType
            {
                get
                {
                    return _DataToMailDataTypes;
                }
                set
                {
                    _DataToMailDataTypes = value;
                }
            }
            private DataToMailDataTypes()
            {
                DataType = new ArrayList();
                XmlDocument xml = new XmlDocument();
                xml.Load(Files);
                try
                {
                    XmlNode root = xml.SelectSingleNode("//DataTypes");
                    foreach (XmlNode n in root.ChildNodes)
                    {
                        if (n.NodeType != XmlNodeType.Comment && n.Name.ToLower() == "datatype")
                        {
                            XmlAttribute _Name = n.Attributes["name"];//类型
                            XmlAttribute _ID = n.Attributes["id"];//系统识别编号

                            if (_Name != null && _ID != null)
                            {
                                DataType.Add(new Rewrite(_Name.Value, _ID.Value, n.InnerText));
                            }
                        }
                    }
                }
                finally
                {
                    xml = null;
                }
            }
            public static DataToMailDataTypes GetDataToMailDataTypes()
            {
                if (instance == null)
                {
                    lock (lockHelper)
                    {
                        if (instance == null)
                        {
                            instance = new DataToMailDataTypes();
                        }
                    }
                }
                return instance;

            }

            public static void SetInstance(DataToMailDataTypes anInstance)
            {
                if (anInstance != null)
                    instance = anInstance;
            }

            public static void SetInstance()
            {
                SetInstance(new DataToMailDataTypes());
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
