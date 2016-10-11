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
        #region  tbYHsysInfo
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistsYHsysInfo(string yName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tbYHsysInfo");
            strSql.Append(" where yName=@yName ");
            SqlParameter[] parameters = {
					new SqlParameter("@yName", SqlDbType.VarChar,50)};
            parameters[0].Value = yName;

            return ((int)DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters)) > 0;
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddYHsysInfo(YHsysInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tbYHsysInfo(");
            strSql.Append("yName,yAppendTime)");
            strSql.Append(" values (");
            strSql.Append("@yName,@yAppendTime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@yName", SqlDbType.VarChar,50),
					new SqlParameter("@yAppendTime", SqlDbType.DateTime)};
            parameters[0].Value = model.yName;
            parameters[1].Value = model.yAppendTime;

            object obj = DbHelper.ExecuteScalar(CommandType.Text,strSql.ToString(), parameters);
            if (obj == null)
            {
                return 1;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void UpdateYHsysInfo(YHsysInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbYHsysInfo set ");
            strSql.Append("yName=@yName,");
            strSql.Append("yAppendTime=@yAppendTime");
            strSql.Append(" where YHsysID=@YHsysID ");
            SqlParameter[] parameters = {
					new SqlParameter("@YHsysID", SqlDbType.Int,4),
					new SqlParameter("@yName", SqlDbType.VarChar,50),
					new SqlParameter("@yAppendTime", SqlDbType.DateTime)};
            parameters[0].Value = model.YHsysID;
            parameters[1].Value = model.yName;
            parameters[2].Value = model.yAppendTime;

            DbHelper.ExecuteNonQuery(CommandType.Text,strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void DeleteYHsysInfo(int YHsysID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbYHsysInfo ");
            strSql.Append(" where YHsysID=@YHsysID ");
            SqlParameter[] parameters = {
					new SqlParameter("@YHsysID", SqlDbType.Int,4)};
            parameters[0].Value = YHsysID;

            DbHelper.ExecuteNonQuery(CommandType.Text,strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一组数据
        /// </summary>
        public void DeleteYHsysInfo(string YHsysID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbYHsysInfo ");
            strSql.Append(" where YHsysID in(" + YHsysID + ") ");

            DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString());
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public YHsysInfo GetYHsysInfoModel(int YHsysID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 YHsysID,yName,yAppendTime from tbYHsysInfo ");
            strSql.Append(" where YHsysID=@YHsysID ");
            SqlParameter[] parameters = {
					new SqlParameter("@YHsysID", SqlDbType.Int,4)};
            parameters[0].Value = YHsysID;

            YHsysInfo model = new YHsysInfo();
            DataSet ds = DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["YHsysID"].ToString() != "")
                {
                    model.YHsysID = int.Parse(ds.Tables[0].Rows[0]["YHsysID"].ToString());
                }
                model.yName = ds.Tables[0].Rows[0]["yName"].ToString();
                if (ds.Tables[0].Rows[0]["yAppendTime"].ToString() != "")
                {
                    model.yAppendTime = DateTime.Parse(ds.Tables[0].Rows[0]["yAppendTime"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public YHsysInfo GetYHsysInfoModelByName(string yName)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 YHsysID,yName,yAppendTime from tbYHsysInfo ");
            strSql.Append(" where yName=@yName ");
            SqlParameter[] parameters = {
					new SqlParameter("@yName", SqlDbType.VarChar,50)};
            parameters[0].Value = yName;

            YHsysInfo model = new YHsysInfo();
            DataSet ds = DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["YHsysID"].ToString() != "")
                {
                    model.YHsysID = int.Parse(ds.Tables[0].Rows[0]["YHsysID"].ToString());
                }
                model.yName = ds.Tables[0].Rows[0]["yName"].ToString();
                if (ds.Tables[0].Rows[0]["yAppendTime"].ToString() != "")
                {
                    model.yAppendTime = DateTime.Parse(ds.Tables[0].Rows[0]["yAppendTime"].ToString());
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
        public DataSet GetYHsysInfoList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select YHsysID,yName,yAppendTime ");
            strSql.Append(" FROM tbYHsysInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelper.ExecuteDataset(CommandType.Text,strSql.ToString());
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataTable GetYHsysInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
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
            parameters[0].Value = "tbYHsysInfo";
            parameters[1].Value = "YHsysID";
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

        #endregion
    }
}
