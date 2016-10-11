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
        #region  ValenceInfo

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddValenceInfo(ValenceInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tbValenceInfo(");
            strSql.Append("ProductsID,bDateTime,eDateTime,vPrice,vAppendTime)");
            strSql.Append(" values (");
            strSql.Append("@ProductsID,@bDateTime,@eDateTime,@vPrice,@vAppendTime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@ProductsID", SqlDbType.Int,4),
					new SqlParameter("@bDateTime", SqlDbType.DateTime),
					new SqlParameter("@eDateTime", SqlDbType.DateTime),
					new SqlParameter("@vPrice", SqlDbType.Money,8),
					new SqlParameter("@vAppendTime", SqlDbType.DateTime)};
            parameters[0].Value = model.ProductsID;
            parameters[1].Value = model.bDateTime;
            parameters[2].Value = model.eDateTime;
            parameters[3].Value = model.vPrice;
            parameters[4].Value = model.vAppendTime;

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
        public void UpdateValenceInfo(ValenceInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbValenceInfo set ");
            strSql.Append("ProductsID=@ProductsID,");
            strSql.Append("bDateTime=@bDateTime,");
            strSql.Append("eDateTime=@eDateTime,");
            strSql.Append("vPrice=@vPrice,");
            strSql.Append("vAppendTime=@vAppendTime");
            strSql.Append(" where ValenceID=@ValenceID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ValenceID", SqlDbType.Int,4),
					new SqlParameter("@ProductsID", SqlDbType.Int,4),
					new SqlParameter("@bDateTime", SqlDbType.DateTime),
					new SqlParameter("@eDateTime", SqlDbType.DateTime),
					new SqlParameter("@vPrice", SqlDbType.Money,8),
					new SqlParameter("@vAppendTime", SqlDbType.DateTime)};
            parameters[0].Value = model.ValenceID;
            parameters[1].Value = model.ProductsID;
            parameters[2].Value = model.bDateTime;
            parameters[3].Value = model.eDateTime;
            parameters[4].Value = model.vPrice;
            parameters[5].Value = model.vAppendTime;

            DbHelper.ExecuteNonQuery(CommandType.Text,strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void DeleteValenceInfo(int ValenceID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbValenceInfo ");
            strSql.Append(" where ValenceID=@ValenceID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ValenceID", SqlDbType.Int,4)};
            parameters[0].Value = ValenceID;

            DbHelper.ExecuteNonQuery(CommandType.Text,strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一组数据
        /// </summary>
        public void DeleteValenceInfo(string ValenceID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbValenceInfo ");
            strSql.Append(" where ValenceID in(" + ValenceID + ") ");

            DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString());
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ValenceInfo GetValenceInfoModel(int ValenceID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ValenceID,ProductsID,bDateTime,eDateTime,vPrice,vAppendTime,(select pName from tbProductsInfo where ProductsID=tbValenceInfo.[ProductsID]) as ProductsName from tbValenceInfo ");
            strSql.Append(" where ValenceID=@ValenceID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ValenceID", SqlDbType.Int,4)};
            parameters[0].Value = ValenceID;

            ValenceInfo model = new ValenceInfo();
            DataSet ds = DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ValenceID"].ToString() != "")
                {
                    model.ValenceID = int.Parse(ds.Tables[0].Rows[0]["ValenceID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ProductsID"].ToString() != "")
                {
                    model.ProductsID = int.Parse(ds.Tables[0].Rows[0]["ProductsID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["bDateTime"].ToString() != "")
                {
                    model.bDateTime = DateTime.Parse(ds.Tables[0].Rows[0]["bDateTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["eDateTime"].ToString() != "")
                {
                    model.eDateTime = DateTime.Parse(ds.Tables[0].Rows[0]["eDateTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["vPrice"].ToString() != "")
                {
                    model.vPrice = decimal.Parse(ds.Tables[0].Rows[0]["vPrice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["vAppendTime"].ToString() != "")
                {
                    model.vAppendTime = DateTime.Parse(ds.Tables[0].Rows[0]["vAppendTime"].ToString());
                }
                model.ProductsName = ds.Tables[0].Rows[0]["ProductsName"].ToString();
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
        public DataSet GetValenceInfoList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ValenceID,ProductsID,bDateTime,eDateTime,vPrice,vAppendTime,(select pName from tbProductsInfo where ProductsID=tbValenceInfo.[ProductsID]) as ProductsName ");
            strSql.Append(" FROM tbValenceInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelper.ExecuteDataset(CommandType.Text,strSql.ToString());
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataTable GetValenceInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
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
            parameters[0].Value = "tbValenceInfo";
            parameters[1].Value = "ValenceID";
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

        #endregion  成员方法
    }
}
