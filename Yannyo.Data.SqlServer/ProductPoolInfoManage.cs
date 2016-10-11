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
        public int AddProductPool(ProductPoolInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tbProductPoolInfo(");
            strSql.Append("ProductsID,pDateTime,pType,pAppendTime)");
            strSql.Append(" values (");
            strSql.Append("@ProductsID,@pDateTime,@pType,@pAppendTime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@ProductsID", SqlDbType.Int,4),
					new SqlParameter("@pDateTime", SqlDbType.DateTime),
					new SqlParameter("@pType", SqlDbType.Int,4),
					new SqlParameter("@pAppendTime", SqlDbType.DateTime)};
            parameters[0].Value = model.ProductsID;
            parameters[1].Value = model.pDateTime;
            parameters[2].Value = model.pType;
            parameters[3].Value = model.pAppendTime;

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
        public void UpdateProductPool(ProductPoolInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbProductPoolInfo set ");
            strSql.Append("ProductsID=@ProductsID,");
            strSql.Append("pDateTime=@pDateTime,");
            strSql.Append("pType=@pType,");
            strSql.Append("pAppendTime=@pAppendTime");
            strSql.Append(" where ProductPoolID=@ProductPoolID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ProductPoolID", SqlDbType.Int,4),
					new SqlParameter("@ProductsID", SqlDbType.Int,4),
					new SqlParameter("@pDateTime", SqlDbType.DateTime),
					new SqlParameter("@pType", SqlDbType.Int,4),
					new SqlParameter("@pAppendTime", SqlDbType.DateTime)};
            parameters[0].Value = model.ProductPoolID;
            parameters[1].Value = model.ProductsID;
            parameters[2].Value = model.pDateTime;
            parameters[3].Value = model.pType;
            parameters[4].Value = model.pAppendTime;

            DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void DeleteProductPool(int ProductPoolID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbProductPoolInfo ");
            strSql.Append(" where ProductPoolID=@ProductPoolID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ProductPoolID", SqlDbType.Int,4)};
            parameters[0].Value = ProductPoolID;

            DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void DeleteProductPool(string ProductPoolID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbProductPoolInfo ");
            strSql.Append(" where ProductPoolID in(" + ProductPoolID + ") ");

            DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString());
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ProductPoolInfo GetProductPoolModel(int ProductPoolID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ProductPoolID,ProductsID,pDateTime,pType,pAppendTime,(select pName from tbProductsInfo where tbProductsInfo.ProductsID=tbProductPoolInfo.ProductsID) as ProductsName from tbProductPoolInfo ");
            strSql.Append(" where ProductPoolID=@ProductPoolID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ProductPoolID", SqlDbType.Int,4)};
            parameters[0].Value = ProductPoolID;

            ProductPoolInfo model = new ProductPoolInfo();
            DataSet ds = DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.ProductsName = ds.Tables[0].Rows[0]["ProductsName"].ToString();
                if (ds.Tables[0].Rows[0]["ProductPoolID"].ToString() != "")
                {
                    model.ProductPoolID = int.Parse(ds.Tables[0].Rows[0]["ProductPoolID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ProductsID"].ToString() != "")
                {
                    model.ProductsID = int.Parse(ds.Tables[0].Rows[0]["ProductsID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["pDateTime"].ToString() != "")
                {
                    model.pDateTime = DateTime.Parse(ds.Tables[0].Rows[0]["pDateTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["pType"].ToString() != "")
                {
                    model.pType = int.Parse(ds.Tables[0].Rows[0]["pType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["pAppendTime"].ToString() != "")
                {
                    model.pAppendTime = DateTime.Parse(ds.Tables[0].Rows[0]["pAppendTime"].ToString());
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
        public DataSet GetProductPoolList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ProductPoolID,ProductsID,pDateTime,pType,pAppendTime ");
            strSql.Append(" FROM tbProductPoolInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelper.ExecuteDataset(CommandType.Text,strSql.ToString());
        }

        
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataTable GetProductPoolList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
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
            parameters[0].Value = "tbProductPoolInfo";
            parameters[1].Value = "ProductPoolID";
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
