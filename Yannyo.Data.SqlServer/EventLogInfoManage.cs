using System;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Yannyo.Data;
using Yannyo.Config;
using Yannyo.Common;
using Yannyo.Entity;

namespace Yannyo.Data.SqlServer
{
    public partial class DataProvider : IDataProvider
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddEventLog(EventLogInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tbEventLogInfo(");
            strSql.Append("UserID,eMSG,eAppendTime)");
            strSql.Append(" values (");
            strSql.Append("@UserID,@eMSG,@eAppendTime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@eMSG", SqlDbType.VarChar,1024),
					new SqlParameter("@eAppendTime", SqlDbType.DateTime)};
            parameters[0].Value = model.UserID;
            parameters[1].Value = model.eMSG;
            parameters[2].Value = model.eAppendTime;

            object obj = DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
            if (obj == null)
            {
                return -1;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdateEventLog(EventLogInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbEventLogInfo set ");
            strSql.Append("UserID=@UserID,");
            strSql.Append("eMSG=@eMSG,");
            strSql.Append("eAppendTime=@eAppendTime");
            strSql.Append(" where EventLogID=@EventLogID");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@eMSG", SqlDbType.VarChar,1024),
					new SqlParameter("@eAppendTime", SqlDbType.DateTime),
					new SqlParameter("@EventLogID", SqlDbType.Int,4)};
            parameters[0].Value = model.UserID;
            parameters[1].Value = model.eMSG;
            parameters[2].Value = model.eAppendTime;
            parameters[3].Value = model.EventLogID;

            int rows = DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteEventLog(int EventLogID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbEventLogInfo ");
            strSql.Append(" where EventLogID=@EventLogID");
            SqlParameter[] parameters = {
					new SqlParameter("@EventLogID", SqlDbType.Int,4)
            };
            parameters[0].Value = EventLogID;

            int rows = DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteListEventLog(string EventLogIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbEventLogInfo ");
            strSql.Append(" where EventLogID in (" + EventLogIDlist + ")  ");
            int rows = DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public EventLogInfo GetEventLogModel(int EventLogID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 EventLogID,UserID,eMSG,eAppendTime,(select uName from tbUserInfo where UserID=tbEventLogInfo.UserID) UserName from tbEventLogInfo ");
            strSql.Append(" where EventLogID=@EventLogID");
            SqlParameter[] parameters = {
					new SqlParameter("@EventLogID", SqlDbType.Int,4)
};
            parameters[0].Value = EventLogID;

            EventLogInfo model = new EventLogInfo();
            DataSet ds = DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["EventLogID"] != null && ds.Tables[0].Rows[0]["EventLogID"].ToString() != "")
                {
                    model.EventLogID = int.Parse(ds.Tables[0].Rows[0]["EventLogID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserID"] != null && ds.Tables[0].Rows[0]["UserID"].ToString() != "")
                {
                    model.UserID = int.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["eMSG"] != null && ds.Tables[0].Rows[0]["eMSG"].ToString() != "")
                {
                    model.eMSG = ds.Tables[0].Rows[0]["eMSG"].ToString();
                }
                if (ds.Tables[0].Rows[0]["eAppendTime"] != null && ds.Tables[0].Rows[0]["eAppendTime"].ToString() != "")
                {
                    model.eAppendTime = DateTime.Parse(ds.Tables[0].Rows[0]["eAppendTime"].ToString());
                }
                model.UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetEventLogList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select EventLogID,UserID,eMSG,eAppendTime,(select uName from tbUserInfo where UserID=tbEventLogInfo.UserID) UserName ");
            strSql.Append(" FROM tbEventLogInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetEventLogList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" EventLogID,UserID,eMSG,eAppendTime,(select uName from tbUserInfo where UserID=tbEventLogInfo.UserID) UserName ");
            strSql.Append(" FROM tbEventLogInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString());
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataTable GetEventLogList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
        {
            SqlParameter[] parameters = {
                     new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    new SqlParameter("@showFName", SqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "tbEventLogInfo";
            parameters[1].Value = "EventLogID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 1;
            parameters[5].Value = OrderType;
            parameters[6].Value = strWhere;
            parameters[7].Value = showFName + ",(select uName from tbUserInfo where UserID=tbEventLogInfo.UserID) UserName ";
            DataSet ds = DbHelper.ExecuteDataset(CommandType.StoredProcedure, "UP_" + BaseConfigs.GetTablePrefix + "GetRecordByPage", parameters);
            if (ds.Tables.Count > 1)
            {
                int total = (int)ds.Tables[0].Rows[0][0];

                if (total % PageSize == 0)
                {
                    pagetotal = total / PageSize;
                }
                else
                {
                    pagetotal = total / PageSize + 1;
                }
                return ds.Tables[1];
            }
            else
            {
                pagetotal = 0;
                return null;
            }
        }
    }
}
