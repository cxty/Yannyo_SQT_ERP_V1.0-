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
        #region  FeesSubjectInfo
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistsFeesSubjectInfo(string fName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tbFeesSubjectInfo");
            strSql.Append(" where fName=@fName ");
            SqlParameter[] parameters = {
					new SqlParameter("@fName", SqlDbType.VarChar,50)};
            parameters[0].Value = fName;

            return ((int)DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters)) > 0;
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddFeesSubjectInfo(FeesSubjectInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tbFeesSubjectInfo(");
            strSql.Append("fName,fAppendTime,FeesSubjectClassID,fCode,fDebitCredit)");
            strSql.Append(" values (");
            strSql.Append("@fName,@fAppendTime,@FeesSubjectClassID,@fCode,@fDebitCredit)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@fName", SqlDbType.VarChar,50),
					new SqlParameter("@fAppendTime", SqlDbType.DateTime),
                                        new SqlParameter("@FeesSubjectClassID", SqlDbType.Int,4),
                                        new SqlParameter("@fCode", SqlDbType.VarChar,50),
                                        new SqlParameter("@fDebitCredit", SqlDbType.Int,4),
                                        };
            parameters[0].Value = model.fName;
            parameters[1].Value = model.fAppendTime;
            parameters[2].Value = model.FeesSubjectClassID;
            parameters[3].Value = model.fCode;
            parameters[4].Value = model.fDebitCredit;

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
        public void UpdateFeesSubjectInfo(FeesSubjectInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbFeesSubjectInfo set ");
            strSql.Append("fName=@fName,");
            strSql.Append("fAppendTime=@fAppendTime,");
            strSql.Append("FeesSubjectClassID=@FeesSubjectClassID,");
            strSql.Append("fCode=@fCode,");
            strSql.Append("fDebitCredit=@fDebitCredit");
            strSql.Append(" where FeesSubjectID=@FeesSubjectID ");
            SqlParameter[] parameters = {
					new SqlParameter("@FeesSubjectID", SqlDbType.Int,4),
					new SqlParameter("@fName", SqlDbType.VarChar,50),
					new SqlParameter("@fAppendTime", SqlDbType.DateTime),
                                        new SqlParameter("@FeesSubjectClassID", SqlDbType.Int,4),
                                        new SqlParameter("@fCode", SqlDbType.VarChar,50),
                                        new SqlParameter("@fDebitCredit", SqlDbType.Int,4),};
            parameters[0].Value = model.FeesSubjectID;
            parameters[1].Value = model.fName;
            parameters[2].Value = model.fAppendTime;
            parameters[3].Value = model.FeesSubjectClassID;
            parameters[4].Value = model.fCode;
            parameters[5].Value = model.fDebitCredit;

            DbHelper.ExecuteNonQuery(CommandType.Text,strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void DeleteFeesSubjectInfo(int FeesSubjectID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbFeesSubjectInfo ");
            strSql.Append(" where FeesSubjectID=@FeesSubjectID ");
            SqlParameter[] parameters = {
					new SqlParameter("@FeesSubjectID", SqlDbType.Int,4)};
            parameters[0].Value = FeesSubjectID;

            DbHelper.ExecuteNonQuery(CommandType.Text,strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一组数据
        /// </summary>
        public void DeleteFeesSubjectInfo(string FeesSubjectID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbFeesSubjectInfo ");
            strSql.Append(" where FeesSubjectID in(" + FeesSubjectID + ") ");

            DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString());
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public FeesSubjectInfo GetFeesSubjectInfoModel(int FeesSubjectID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 FeesSubjectID,fName,fAppendTime,FeesSubjectClassID,fCode,fDebitCredit from tbFeesSubjectInfo ");
            strSql.Append(" where FeesSubjectID=@FeesSubjectID ");
            SqlParameter[] parameters = {
					new SqlParameter("@FeesSubjectID", SqlDbType.Int,4)};
            parameters[0].Value = FeesSubjectID;

            FeesSubjectInfo model = new FeesSubjectInfo();
            DataSet ds = DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["FeesSubjectID"].ToString() != "")
                {
                    model.FeesSubjectID = int.Parse(ds.Tables[0].Rows[0]["FeesSubjectID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["FeesSubjectClassID"].ToString() != "")
                {
                    model.FeesSubjectClassID = int.Parse(ds.Tables[0].Rows[0]["FeesSubjectClassID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["fDebitCredit"].ToString() != "")
                {
                    model.fDebitCredit = int.Parse(ds.Tables[0].Rows[0]["fDebitCredit"].ToString());
                }
                model.fCode = ds.Tables[0].Rows[0]["fCode"].ToString();
                model.fName = ds.Tables[0].Rows[0]["fName"].ToString();
                if (ds.Tables[0].Rows[0]["fAppendTime"].ToString() != "")
                {
                    model.fAppendTime = DateTime.Parse(ds.Tables[0].Rows[0]["fAppendTime"].ToString());
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
        public FeesSubjectInfo GetFeesSubjectInfoModelByName(string fName)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 FeesSubjectID,fName,fAppendTime,FeesSubjectClassID,fCode,fDebitCredit from tbFeesSubjectInfo ");
            strSql.Append(" where fName=@fName ");
            SqlParameter[] parameters = {
					new SqlParameter("@fName", SqlDbType.VarChar,50)};
            parameters[0].Value = fName;

            FeesSubjectInfo model = new FeesSubjectInfo();
            DataSet ds = DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["FeesSubjectID"].ToString() != "")
                {
                    model.FeesSubjectID = int.Parse(ds.Tables[0].Rows[0]["FeesSubjectID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["FeesSubjectClassID"].ToString() != "")
                {
                    model.FeesSubjectClassID = int.Parse(ds.Tables[0].Rows[0]["FeesSubjectClassID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["fDebitCredit"].ToString() != "")
                {
                    model.fDebitCredit = int.Parse(ds.Tables[0].Rows[0]["fDebitCredit"].ToString());
                }
                model.fCode = ds.Tables[0].Rows[0]["fCode"].ToString();
                model.fName = ds.Tables[0].Rows[0]["fName"].ToString();
                if (ds.Tables[0].Rows[0]["fAppendTime"].ToString() != "")
                {
                    model.fAppendTime = DateTime.Parse(ds.Tables[0].Rows[0]["fAppendTime"].ToString());
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
        public DataSet GetFeesSubjectInfoList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select FeesSubjectID,fName,fAppendTime,FeesSubjectClassID,fCode,fDebitCredit ");
            strSql.Append(" FROM tbFeesSubjectInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelper.ExecuteDataset(CommandType.Text,strSql.ToString());
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataTable GetFeesSubjectInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
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
            parameters[0].Value = "tbFeesSubjectInfo";
            parameters[1].Value = "FeesSubjectID";
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
