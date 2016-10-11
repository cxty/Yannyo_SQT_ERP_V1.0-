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
        public bool ExistsPriceClassDefaultPriceInfo(int PriceClassID, int ProductsID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tbPriceClassDefaultPriceInfo");
            strSql.Append(" where PriceClassID=@PriceClassID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PriceClassID", SqlDbType.Int,4),
                                        new SqlParameter("@ProductsID", SqlDbType.Int,4)};
            parameters[0].Value = PriceClassID;
            parameters[1].Value = ProductsID;

            return ((int)DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters)) > 0;
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddPriceClassDefaultPriceInfo(PriceClassDefaultPriceInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tbPriceClassDefaultPriceInfo(");
            strSql.Append("PriceClassID,ProductsID,pPrice,pIsEdit)");
            strSql.Append(" values (");
            strSql.Append("@PriceClassID,@ProductsID,@pPrice,@pIsEdit)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@PriceClassID", SqlDbType.Int,4),
					new SqlParameter("@ProductsID", SqlDbType.Int,4),
					new SqlParameter("@pPrice", SqlDbType.Money,8),
                    new SqlParameter("@pIsEdit", SqlDbType.Int,4),};
            parameters[0].Value = model.PriceClassID;
            parameters[1].Value = model.ProductsID;
            parameters[2].Value = model.pPrice;
            parameters[3].Value = model.pIsEdit;

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
        public void UpdatePriceClassDefaultPriceInfo(PriceClassDefaultPriceInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbPriceClassDefaultPriceInfo set ");
            strSql.Append("PriceClassID=@PriceClassID,");
            strSql.Append("ProductsID=@ProductsID,");
            strSql.Append("pPrice=@pPrice,");
            strSql.Append("pIsEdit=@pIsEdit");
            strSql.Append(" where PriceClassDefaultPriceID=@PriceClassDefaultPriceID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PriceClassDefaultPriceID", SqlDbType.Int,4),
					new SqlParameter("@PriceClassID", SqlDbType.Int,4),
					new SqlParameter("@ProductsID", SqlDbType.Int,4),
					new SqlParameter("@pPrice", SqlDbType.Money,8),
                                        new SqlParameter("@pIsEdit", SqlDbType.Int,4),};
            parameters[0].Value = model.PriceClassDefaultPriceID;
            parameters[1].Value = model.PriceClassID;
            parameters[2].Value = model.ProductsID;
            parameters[3].Value = model.pPrice;
            parameters[4].Value = model.pIsEdit;

            DbHelper.ExecuteNonQuery(CommandType.Text,strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void DeletePriceClassDefaultPriceInfo(int PriceClassDefaultPriceID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbPriceClassDefaultPriceInfo ");
            strSql.Append(" where PriceClassDefaultPriceID=@PriceClassDefaultPriceID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PriceClassDefaultPriceID", SqlDbType.Int,4)};
            parameters[0].Value = PriceClassDefaultPriceID;

            DbHelper.ExecuteNonQuery(CommandType.Text,strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public PriceClassDefaultPriceInfo GetPriceClassDefaultPriceInfoModel(int PriceClassDefaultPriceID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 PriceClassDefaultPriceID,PriceClassID,ProductsID,pPrice,pIsEdit from tbPriceClassDefaultPriceInfo ");
            strSql.Append(" where PriceClassDefaultPriceID=@PriceClassDefaultPriceID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PriceClassDefaultPriceID", SqlDbType.Int,4)};
            parameters[0].Value = PriceClassDefaultPriceID;

            PriceClassDefaultPriceInfo model = new PriceClassDefaultPriceInfo();
            DataSet ds = DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["PriceClassDefaultPriceID"].ToString() != "")
                {
                    model.PriceClassDefaultPriceID = int.Parse(ds.Tables[0].Rows[0]["PriceClassDefaultPriceID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PriceClassID"].ToString() != "")
                {
                    model.PriceClassID = int.Parse(ds.Tables[0].Rows[0]["PriceClassID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ProductsID"].ToString() != "")
                {
                    model.ProductsID = int.Parse(ds.Tables[0].Rows[0]["ProductsID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["pPrice"].ToString() != "")
                {
                    model.pPrice = decimal.Parse(ds.Tables[0].Rows[0]["pPrice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["pIsEdit"].ToString() != "")
                {
                    model.pIsEdit = int.Parse(ds.Tables[0].Rows[0]["pIsEdit"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }
        public PriceClassDefaultPriceInfo GetPriceClassDefaultPriceInfoModel(int PriceClassID, int ProductsID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 PriceClassDefaultPriceID,PriceClassID,ProductsID,pPrice,pIsEdit from tbPriceClassDefaultPriceInfo ");
            strSql.Append(" where PriceClassID=@PriceClassID and ProductsID=@ProductsID");
            SqlParameter[] parameters = {
					new SqlParameter("@PriceClassID", SqlDbType.Int,4),
                                        new SqlParameter("@ProductsID", SqlDbType.Int,4)};
            parameters[0].Value = PriceClassID;
            parameters[1].Value = ProductsID;

            PriceClassDefaultPriceInfo model = new PriceClassDefaultPriceInfo();
            DataSet ds = DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["PriceClassDefaultPriceID"].ToString() != "")
                {
                    model.PriceClassDefaultPriceID = int.Parse(ds.Tables[0].Rows[0]["PriceClassDefaultPriceID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PriceClassID"].ToString() != "")
                {
                    model.PriceClassID = int.Parse(ds.Tables[0].Rows[0]["PriceClassID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ProductsID"].ToString() != "")
                {
                    model.ProductsID = int.Parse(ds.Tables[0].Rows[0]["ProductsID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["pPrice"].ToString() != "")
                {
                    model.pPrice = decimal.Parse(ds.Tables[0].Rows[0]["pPrice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["pIsEdit"].ToString() != "")
                {
                    model.pIsEdit = int.Parse(ds.Tables[0].Rows[0]["pIsEdit"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 取指定商品指定门店默认价格
        /// </summary>
        /// <param name="ProductID"></param>
        /// <param name="StoresID"></param>
        /// <returns></returns>
        public decimal GetProductsPiceByStoresID(int ProductsID, int StoresID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 pPrice from tbPriceClassDefaultPriceInfo where ProductsID=@ProductsID and PriceClassID in(select PriceClassID from tbStoresInfo where StoresID=@StoresID)");
            SqlParameter[] parameters = {
					new SqlParameter("@ProductsID", SqlDbType.Int,4),
                                        new SqlParameter("@StoresID", SqlDbType.Int,4)};
            parameters[0].Value = ProductsID;
            parameters[1].Value = StoresID;

            return Convert.ToDecimal(DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters));
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetPriceClassDefaultPriceInfoList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select PriceClassDefaultPriceID,PriceClassID,ProductsID,pPrice,(select tbProductsInfo.pName from tbProductsInfo where tbProductsInfo.ProductsID=tbPriceClassDefaultPriceInfo.ProductsID) as ProductName,pIsEdit ");
            strSql.Append(" FROM tbPriceClassDefaultPriceInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetPriceClassDefaultPriceInfoList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" PriceClassDefaultPriceID,PriceClassID,ProductsID,pPrice,pIsEdit ");
            strSql.Append(" FROM tbPriceClassDefaultPriceInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString());
        }
    }
}
