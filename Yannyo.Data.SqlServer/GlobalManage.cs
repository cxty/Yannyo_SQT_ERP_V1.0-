using System;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Yannyo.Data;
using Yannyo.Config;
using Yannyo.Common;
using Yannyo.Entity;
using System.Text.RegularExpressions;
using SQLDMO;
using System.Collections.Generic;
using System.Collections;

namespace Yannyo.Data.SqlServer
{
    public partial class DataProvider : IDataProvider
    {
        public void SetLastExecuteScheduledEventDateTime(string key, string servername, DateTime lastexecuted)
        {
            string sql = string.Format("tb{0}setlastexecutescheduledeventdatetime", BaseConfigs.GetTablePrefix);

            DbParameter[] parms = {
                DbHelper.MakeInParam("@key", (DbType)SqlDbType.VarChar, 100, key),
                DbHelper.MakeInParam("@servername", (DbType)SqlDbType.VarChar, 100, servername),
                DbHelper.MakeInParam("@lastexecuted", (DbType)SqlDbType.DateTime, 8, lastexecuted)
            };

            DbHelper.ExecuteNonQuery(CommandType.StoredProcedure, sql, parms);
        }

        public DateTime GetLastExecuteScheduledEventDateTime(string key, string servername)
        {
            string sql = string.Format("tb{0}getlastexecutescheduledeventdatetime", BaseConfigs.GetTablePrefix);

            DbParameter[] parms = {
                DbHelper.MakeInParam("@key", (DbType)SqlDbType.VarChar, 100, key),
                DbHelper.MakeInParam("@servername", (DbType)SqlDbType.VarChar, 100, servername),
                DbHelper.MakeOutParam("@lastexecuted", (DbType)SqlDbType.DateTime, 8)
            };

            DbHelper.ExecuteNonQuery(CommandType.StoredProcedure, sql, parms);

            return Convert.IsDBNull(parms[2].Value) ? DateTime.MinValue : Convert.ToDateTime(parms[2].Value);
        }

        /// <summary>
        /// 获取指定数据表,指定条件数据集合
        /// </summary>
        /// <param name="TableName">表名</param>
        /// <param name="OutName">输出字段名</param>
        /// <param name="InName">输入字段名</param>
        /// <param name="WhereStr">附加查询条件</param>
        public string GetDataFieldStr(string TableName, string OutName, string InName, int InValue, string WhereStr)
        {
            string tRe = "";
            string strSql = "";
            if (WhereStr.Trim() != "")
            {
                strSql = "select " + OutName + " from " + TableName + " where " + InName + " = " + InValue.ToString() + " and " + WhereStr;
            }
            else
            {
                strSql = "select " + OutName + " from " + TableName + " where " + InName + " = " + InValue.ToString();
            }
            ArrayList temL = new ArrayList();
            DataSet ds = DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString());
            try
            {
                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        temL.Add(dr[OutName].ToString());
                    }
                }
            }
            finally
            {
                ds.Clear();
                ds.Dispose();
            }
            for (int i = 0; i < temL.Count; i++)
            {
                if (temL[i].ToString().Trim() != "")
                {
                    tRe += temL[i].ToString().Trim() + "," + GetDataFieldStr(TableName, OutName, InName, int.Parse(temL[i].ToString()), WhereStr);
                }
            }
            temL.Clear();
            temL = null;
            return tRe;
        }
        public string GetDataFieldStrReverse(string TableName, string OutName, string InName, int InValue, string WhereStr)
        {
            string tRe = "";
            string strSql = "";
            if (WhereStr.Trim() != "")
            {
                strSql = "select " + OutName + " from " + TableName + " where " + InName + " = " + InValue.ToString() + " and " + WhereStr;
            }
            else
            {
                strSql = "select " + OutName + " from " + TableName + " where " + InName + " = " + InValue.ToString();
            }
            ArrayList temL = new ArrayList();
            DataSet ds = DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString());
            try
            {
                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        temL.Add(dr[OutName].ToString());
                    }
                }
            }
            finally
            {
                ds.Clear();
                ds.Dispose();
            }
            for (int i = 0; i < temL.Count; i++)
            {
                if (temL[i].ToString().Trim() != "")
                {
                    tRe += GetDataFieldStrReverse(TableName, OutName, InName, int.Parse(temL[i].ToString()), WhereStr) +","+ temL[i].ToString().Trim();
                }
            }
            temL.Clear();
            temL = null;
            return tRe;
        }
        public string GetDataFieldStrReverse(string TableName, string OutName, string InName, int InValue, string WhereStr,string sStr)
        {
            string tRe = "";
            string strSql = "";
            if (WhereStr.Trim() != "")
            {
                strSql = "select " + OutName + " from " + TableName + " where " + InName + " = " + InValue.ToString() + " and " + WhereStr;
            }
            else
            {
                strSql = "select " + OutName + " from " + TableName + " where " + InName + " = " + InValue.ToString();
            }
            ArrayList temL = new ArrayList();
            DataSet ds = DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString());
            try
            {
                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        temL.Add(dr[OutName].ToString());
                    }
                }
            }
            finally
            {
                ds.Clear();
                ds.Dispose();
            }
            for (int i = 0; i < temL.Count; i++)
            {
                if (temL[i].ToString().Trim() != "")
                {
                    tRe += GetDataFieldStrReverse(TableName, OutName, InName, int.Parse(temL[i].ToString()), WhereStr, sStr) + sStr + temL[i].ToString().Trim();
                }
            }
            temL.Clear();
            temL = null;
            return tRe;
        }
        /// <summary>
        /// 获取指定数据表,指定条件数据集合
        /// </summary>
        /// <param name="TableName">表名</param>
        /// <param name="OutName">输出字段名</param>
        /// <param name="InName">输入字段名</param>
        /// <param name="WhereStr">附加查询条件</param>
        public string GetDataFieldStr(string TableName, string OutName,string OutIDName, string InName, int InValue, string WhereStr)
        {
            string tRe = "";
            string strSql = "";
            if (WhereStr.Trim() != "")
            {
                strSql = "select " + OutName + "," + OutIDName + " from " + TableName + " where " + InName + " = " + InValue.ToString() + " and " + WhereStr;
            }
            else
            {
                strSql = "select " + OutName + "," + OutIDName + " from " + TableName + " where " + InName + " = " + InValue.ToString();
            }
            ArrayList temL = new ArrayList();
            DataSet ds = DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString());
            try
            {
                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        string[] tstr = { dr[OutName].ToString(), dr[OutIDName].ToString() };
                        temL.Add(tstr);
                    }
                }
            }
            finally
            {
                ds.Clear();
                ds.Dispose();
            }
            for (int i = 0; i < temL.Count; i++)
            {
                string[] t = temL[i] as string[];
                if (t.Length > 0)
                {
                    if (t[0].ToString().Trim() != "" && t[1].ToString().Trim() != "")
                    {
                        tRe += GetDataFieldStr(TableName, OutName, OutIDName, InName, int.Parse(t[1].ToString()), WhereStr) + "," + t[0].ToString().Trim();
                    }
                }
            }
            temL.Clear();
            temL = null;
            return tRe;
        }
        public string GetDataFieldStr(string TableName, string OutName, string OutIDName, string InName, int InValue, string WhereStr,string sStr)
        {
            string tRe = "";
            string strSql = "";
            if (WhereStr.Trim() != "")
            {
                strSql = "select " + OutName + "," + OutIDName + " from " + TableName + " where " + InName + " = " + InValue.ToString() + " and " + WhereStr;
            }
            else
            {
                strSql = "select " + OutName + "," + OutIDName + " from " + TableName + " where " + InName + " = " + InValue.ToString();
            }
            ArrayList temL = new ArrayList();
            DataSet ds = DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString());
            try
            {
                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        string[] tstr = { dr[OutName].ToString(), dr[OutIDName].ToString() };
                        temL.Add(tstr);
                    }
                }
            }
            finally
            {
                ds.Clear();
                ds.Dispose();
            }
            for (int i = 0; i < temL.Count; i++)
            {
                string[] t = temL[i] as string[];
                if (t.Length > 0)
                {
                    if (t[0].ToString().Trim() != "" && t[1].ToString().Trim() != "")
                    {
                        tRe += GetDataFieldStr(TableName, OutName, OutIDName, InName, int.Parse(t[1].ToString()), WhereStr, sStr) + sStr + t[0].ToString().Trim();
                    }
                }
            }
            temL.Clear();
            temL = null;
            return tRe;
        }
        public string GetDataFieldStrReverse(string TableName, string OutName, string OutIDName, string InName, int InValue, string WhereStr)
        {
            string tRe = "";
            string strSql = "";
            if (WhereStr.Trim() != "")
            {
                strSql = "select " + OutName + "," + OutIDName + " from " + TableName + " where " + InName + " = " + InValue.ToString() + " and " + WhereStr;
            }
            else
            {
                strSql = "select " + OutName + "," + OutIDName + " from " + TableName + " where " + InName + " = " + InValue.ToString();
            }
            ArrayList temL = new ArrayList();
            DataSet ds = DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString());
            try
            {
                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        string[] tstr = { dr[OutName].ToString(), dr[OutIDName].ToString() };
                        temL.Add(tstr);
                    }
                }
            }
            finally
            {
                ds.Clear();
                ds.Dispose();
            }
            for (int i = 0; i < temL.Count; i++)
            {
                string[] t = temL[i] as string[];
                if (t.Length > 0)
                {
                    if (t[0].ToString().Trim() != "" && t[1].ToString().Trim() != "")
                    {
                        tRe += t[0].ToString().Trim()+"," +  GetDataFieldStrReverse(TableName, OutName, OutIDName, InName, int.Parse(t[1].ToString()), WhereStr) ;
                    }
                }
            }
            temL.Clear();
            temL = null;
            return tRe;
        }
    }
}
