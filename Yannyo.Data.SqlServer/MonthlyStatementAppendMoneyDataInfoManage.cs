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
        public int AddMonthlyStatementAppendMoneyDataInfo(MonthlyStatementAppendMoneyDataInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tbMonthlyStatementAppendMoneyDataInfo(");
            strSql.Append("MonthlyStatementID,mMoney,mDateTime,mState,mRemake,mAppendTime)");
            strSql.Append(" values (");
            strSql.Append("@MonthlyStatementID,@mMoney,@mDateTime,@mState,@mRemake,@mAppendTime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@MonthlyStatementID", SqlDbType.Int,4),
					new SqlParameter("@mMoney", SqlDbType.Decimal,9),
					new SqlParameter("@mDateTime", SqlDbType.DateTime),
					new SqlParameter("@mState", SqlDbType.Int,4),
					new SqlParameter("@mRemake", SqlDbType.VarChar,512),
					new SqlParameter("@mAppendTime", SqlDbType.DateTime)};
            parameters[0].Value = model.MonthlyStatementID;
            parameters[1].Value = model.mMoney;
            parameters[2].Value = model.mDateTime;
            parameters[3].Value = model.mState;
            parameters[4].Value = model.mRemake;
            parameters[5].Value = model.mAppendTime;

            object obj = DbHelper.ExecuteScalar(CommandType.Text,strSql.ToString(), parameters);
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
        public bool UpdateMonthlyStatementAppendMoneyDataInfo(MonthlyStatementAppendMoneyDataInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbMonthlyStatementAppendMoneyDataInfo set ");
            strSql.Append("MonthlyStatementID=@MonthlyStatementID,");
            strSql.Append("mMoney=@mMoney,");
            strSql.Append("mDateTime=@mDateTime,");
            strSql.Append("mState=@mState,");
            strSql.Append("mRemake=@mRemake,");
            strSql.Append("mAppendTime=@mAppendTime");
            strSql.Append(" where MonthlyStatementAppendMoneyDataID=@MonthlyStatementAppendMoneyDataID");
            SqlParameter[] parameters = {
					new SqlParameter("@MonthlyStatementID", SqlDbType.Int,4),
					new SqlParameter("@mMoney", SqlDbType.Decimal,9),
					new SqlParameter("@mDateTime", SqlDbType.DateTime),
					new SqlParameter("@mState", SqlDbType.Int,4),
					new SqlParameter("@mRemake", SqlDbType.VarChar,512),
					new SqlParameter("@mAppendTime", SqlDbType.DateTime),
					new SqlParameter("@MonthlyStatementAppendMoneyDataID", SqlDbType.Int,4)};
            parameters[0].Value = model.MonthlyStatementID;
            parameters[1].Value = model.mMoney;
            parameters[2].Value = model.mDateTime;
            parameters[3].Value = model.mState;
            parameters[4].Value = model.mRemake;
            parameters[5].Value = model.mAppendTime;
            parameters[6].Value = model.MonthlyStatementAppendMoneyDataID;

            int rows = DbHelper.ExecuteNonQuery(CommandType.Text,strSql.ToString(), parameters);
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
        public bool DeleteMonthlyStatementAppendMoneyDataInfo(int MonthlyStatementAppendMoneyDataID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbMonthlyStatementAppendMoneyDataInfo ");
            strSql.Append(" where MonthlyStatementAppendMoneyDataID=@MonthlyStatementAppendMoneyDataID");
            SqlParameter[] parameters = {
					new SqlParameter("@MonthlyStatementAppendMoneyDataID", SqlDbType.Int,4)
};
            parameters[0].Value = MonthlyStatementAppendMoneyDataID;

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
        public bool DeleteMonthlyStatementAppendMoneyDataInfoList(string MonthlyStatementAppendMoneyDataIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbMonthlyStatementAppendMoneyDataInfo ");
            strSql.Append(" where MonthlyStatementAppendMoneyDataID in (" + MonthlyStatementAppendMoneyDataIDlist + ")  ");
            int rows = DbHelper.ExecuteNonQuery(strSql.ToString());
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
        public MonthlyStatementAppendMoneyDataInfo GetMonthlyStatementAppendMoneyDataInfoModel(int MonthlyStatementAppendMoneyDataID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 MonthlyStatementAppendMoneyDataID,MonthlyStatementID,mMoney,mDateTime,mState,mRemake,mAppendTime from tbMonthlyStatementAppendMoneyDataInfo ");
            strSql.Append(" where MonthlyStatementAppendMoneyDataID=@MonthlyStatementAppendMoneyDataID");
            SqlParameter[] parameters = {
					new SqlParameter("@MonthlyStatementAppendMoneyDataID", SqlDbType.Int,4)
};
            parameters[0].Value = MonthlyStatementAppendMoneyDataID;

            MonthlyStatementAppendMoneyDataInfo model = new MonthlyStatementAppendMoneyDataInfo();
            DataSet ds = DbHelper.ExecuteDataset(CommandType.Text,strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["MonthlyStatementAppendMoneyDataID"] != null && ds.Tables[0].Rows[0]["MonthlyStatementAppendMoneyDataID"].ToString() != "")
                {
                    model.MonthlyStatementAppendMoneyDataID = int.Parse(ds.Tables[0].Rows[0]["MonthlyStatementAppendMoneyDataID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["MonthlyStatementID"] != null && ds.Tables[0].Rows[0]["MonthlyStatementID"].ToString() != "")
                {
                    model.MonthlyStatementID = int.Parse(ds.Tables[0].Rows[0]["MonthlyStatementID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["mMoney"] != null && ds.Tables[0].Rows[0]["mMoney"].ToString() != "")
                {
                    model.mMoney = decimal.Parse(ds.Tables[0].Rows[0]["mMoney"].ToString());
                }
                if (ds.Tables[0].Rows[0]["mDateTime"] != null && ds.Tables[0].Rows[0]["mDateTime"].ToString() != "")
                {
                    model.mDateTime = DateTime.Parse(ds.Tables[0].Rows[0]["mDateTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["mState"] != null && ds.Tables[0].Rows[0]["mState"].ToString() != "")
                {
                    model.mState = int.Parse(ds.Tables[0].Rows[0]["mState"].ToString());
                }
                if (ds.Tables[0].Rows[0]["mRemake"] != null && ds.Tables[0].Rows[0]["mRemake"].ToString() != "")
                {
                    model.mRemake = ds.Tables[0].Rows[0]["mRemake"].ToString();
                }
                if (ds.Tables[0].Rows[0]["mAppendTime"] != null && ds.Tables[0].Rows[0]["mAppendTime"].ToString() != "")
                {
                    model.mAppendTime = DateTime.Parse(ds.Tables[0].Rows[0]["mAppendTime"].ToString());
                }
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
        public DataSet GetMonthlyStatementAppendMoneyDataInfoList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select MonthlyStatementAppendMoneyDataID,MonthlyStatementID,mMoney,mDateTime,mState,mRemake,mAppendTime ");
            strSql.Append(" FROM tbMonthlyStatementAppendMoneyDataInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelper.ExecuteDataset(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetMonthlyStatementAppendMoneyDataInfoList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" MonthlyStatementAppendMoneyDataID,MonthlyStatementID,mMoney,mDateTime,mState,mRemake,mAppendTime ");
            strSql.Append(" FROM tbMonthlyStatementAppendMoneyDataInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelper.ExecuteDataset(strSql.ToString());
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataTable GetMonthlyStatementAppendMoneyDataInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
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
            parameters[0].Value = "tbMonthlyStatementAppendMoneyDataInfo";
            parameters[1].Value = "MonthlyStatementAppendMoneyDataID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 1;
            parameters[5].Value = OrderType;
            parameters[6].Value = strWhere;
            parameters[7].Value = showFName;
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
