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
        /// 是否存在该记录
        /// </summary>
        public bool ExistsDataToMailInfo(int dDataType, int dDateType, string dEmail)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tbDataToMailInfo");
            strSql.Append(" where dDataType=@dDataType and dDateType=@dDateType and dEmail=@dEmail");
            SqlParameter[] parameters = {
                    new SqlParameter("@dDataType", SqlDbType.Int,4),
					new SqlParameter("@dDateType", SqlDbType.Int,4),
					new SqlParameter("@dEmail", SqlDbType.VarChar,512),
            };
            parameters[0].Value = dDataType;
            parameters[1].Value = dDateType;
            parameters[2].Value = dEmail;

            return ((int)DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters)) > 0;
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddDataToMailInfo(DataToMailInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tbDataToMailInfo(");
            strSql.Append("dDataType,dDateType,dState,dEmail,dAppendTime)");
            strSql.Append(" values (");
            strSql.Append("@dDataType,@dDateType,@dState,@dEmail,@dAppendTime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@dDataType", SqlDbType.Int,4),
					new SqlParameter("@dDateType", SqlDbType.Int,4),
					new SqlParameter("@dState", SqlDbType.Int,4),
					new SqlParameter("@dEmail", SqlDbType.VarChar,512),
					new SqlParameter("@dAppendTime", SqlDbType.DateTime)};
            parameters[0].Value = model.dDataType;
            parameters[1].Value = model.dDateType;
            parameters[2].Value = model.dState;
            parameters[3].Value = model.dEmail;
            parameters[4].Value = model.dAppendTime;

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
        public bool UpdateDataToMailInfo(DataToMailInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbDataToMailInfo set ");
            strSql.Append("dDataType=@dDataType,");
            strSql.Append("dDateType=@dDateType,");
            strSql.Append("dState=@dState,");
            strSql.Append("dEmail=@dEmail,");
            strSql.Append("dAppendTime=@dAppendTime");
            strSql.Append(" where DataToMaillID=@DataToMaillID");
            SqlParameter[] parameters = {
					new SqlParameter("@dDataType", SqlDbType.Int,4),
					new SqlParameter("@dDateType", SqlDbType.Int,4),
					new SqlParameter("@dState", SqlDbType.Int,4),
					new SqlParameter("@dEmail", SqlDbType.VarChar,512),
					new SqlParameter("@dAppendTime", SqlDbType.DateTime),
					new SqlParameter("@DataToMaillID", SqlDbType.Int,4)};
            parameters[0].Value = model.dDataType;
            parameters[1].Value = model.dDateType;
            parameters[2].Value = model.dState;
            parameters[3].Value = model.dEmail;
            parameters[4].Value = model.dAppendTime;
            parameters[5].Value = model.DataToMaillID;

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
        public bool DeleteDataToMailInfo(int DataToMaillID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbDataToMailInfo ");
            strSql.Append(" where DataToMaillID=@DataToMaillID");
            SqlParameter[] parameters = {
					new SqlParameter("@DataToMaillID", SqlDbType.Int,4)
};
            parameters[0].Value = DataToMaillID;

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
        public bool DeleteDataToMailInfoList(string DataToMaillIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbDataToMailInfo ");
            strSql.Append(" where DataToMaillID in (" + DataToMaillIDlist + ")  ");
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
        public DataToMailInfo GetDataToMailInfoModel(int DataToMaillID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 DataToMaillID,dDataType,dDateType,dState,dEmail,dAppendTime from tbDataToMailInfo ");
            strSql.Append(" where DataToMaillID=@DataToMaillID");
            SqlParameter[] parameters = {
					new SqlParameter("@DataToMaillID", SqlDbType.Int,4)
};
            parameters[0].Value = DataToMaillID;

            DataToMailInfo model = new DataToMailInfo();
            DataSet ds = DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["DataToMaillID"].ToString() != "")
                {
                    model.DataToMaillID = int.Parse(ds.Tables[0].Rows[0]["DataToMaillID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["dDataType"].ToString() != "")
                {
                    model.dDataType = int.Parse(ds.Tables[0].Rows[0]["dDataType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["dDateType"].ToString() != "")
                {
                    model.dDateType = int.Parse(ds.Tables[0].Rows[0]["dDateType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["dState"].ToString() != "")
                {
                    model.dState = int.Parse(ds.Tables[0].Rows[0]["dState"].ToString());
                }
                model.dEmail = ds.Tables[0].Rows[0]["dEmail"].ToString();
                if (ds.Tables[0].Rows[0]["dAppendTime"].ToString() != "")
                {
                    model.dAppendTime = DateTime.Parse(ds.Tables[0].Rows[0]["dAppendTime"].ToString());
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
        public DataSet GetDataToMailInfoList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select DataToMaillID,dDataType,dDateType,dState,dEmail,dAppendTime ");
            strSql.Append(" FROM tbDataToMailInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetDataToMailInfoList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" DataToMaillID,dDataType,dDateType,dState,dEmail,dAppendTime ");
            strSql.Append(" FROM tbDataToMailInfo ");
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
        public DataTable GetDataToMailInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
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
            parameters[0].Value = "tbDataToMailInfo";
            parameters[1].Value = "DataToMaillID";
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
