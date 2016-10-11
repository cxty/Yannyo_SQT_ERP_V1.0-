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
		public int AddProductPriceNOAuto(ProductPriceNOAutoInfo model)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("insert into tbProductPriceNOAutoInfo(");
			strSql.Append("ProductsID,Price,PriceRMB,ppAppendTime)");
			strSql.Append(" values (");
			strSql.Append("@ProductsID,@Price,@PriceRMB,Getdate())");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {

				new SqlParameter("@ProductsID", SqlDbType.Int),
				new SqlParameter("@Price", SqlDbType.Money),
				new SqlParameter("@PriceRMB", SqlDbType.Money),

			};
			parameters[0].Value = model.ProductsID;
			parameters[1].Value = model.Price;
			parameters[2].Value = model.PriceRMB;

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
		public void UpdateProductPriceNOAuto(ProductPriceNOAutoInfo model)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("update tbProductPriceNOAutoInfo set ");
			strSql.Append("ProductsID=@ProductsID,");
			strSql.Append("Price=@Price,");
			strSql.Append("PriceRMB=@PriceRMB,");
			strSql.Append("ppAppendTime=GETDATE()");
			strSql.Append(" where ProductPriceNOAutoID=@ProductPriceNOAutoID ");
			SqlParameter[] parameters = {
				new SqlParameter("@ProductPriceNOAutoID", SqlDbType.Int),
				new SqlParameter("@ProductsID", SqlDbType.Int),
				new SqlParameter("@Price", SqlDbType.Money),
				new SqlParameter("@PriceRMB", SqlDbType.Money),
			};
			parameters[0].Value = model.ProductPriceNOAutoID;
			parameters[1].Value = model.ProductsID;
			parameters[2].Value = model.Price;
			parameters[3].Value = model.PriceRMB;

			DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void DeleteProductPriceNOAuto(int ProductPriceNOAutoID)
		{

			StringBuilder strSql = new StringBuilder();
			strSql.Append("delete from tbProductPriceNOAutoInfo ");
			strSql.Append(" where ProductPriceNOAutoID=@ProductPriceNOAutoID ");
			SqlParameter[] parameters = {
				new SqlParameter("@ProductPriceNOAutoID", SqlDbType.Int)};
			parameters[0].Value = ProductPriceNOAutoID;

			DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void DeleteProductPriceNOAuto(string ProductPriceNOAutoID)
		{

			StringBuilder strSql = new StringBuilder();
			strSql.Append("delete from tbProductPriceNOAutoInfo ");
			strSql.Append(" where ProductPriceNOAutoID in(" + ProductPriceNOAutoID + ") ");

			DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString());
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ProductPriceNOAutoInfo GetProductPriceNOAutoModel(int ProductPriceNOAutoID)
		{

			StringBuilder strSql = new StringBuilder();
			strSql.Append("select  top 1 ProductPriceNOAutoID,ProductsID,Price,PriceRMB,ppAppendTime from tbProductPriceNOAutoInfo ");
			strSql.Append(" where ProductPriceNOAutoID=@ProductPriceNOAutoID ");
			SqlParameter[] parameters = {
				new SqlParameter("@ProductPriceNOAutoID", SqlDbType.Int)};
			parameters[0].Value = ProductPriceNOAutoID;

			ProductPriceNOAutoInfo model = new ProductPriceNOAutoInfo();
			DataSet ds = DbHelper.ExecuteDataset(CommandType.Text,strSql.ToString(), parameters);
			if (ds.Tables[0].Rows.Count > 0)
			{
				if (ds.Tables[0].Rows[0]["ProductPriceNOAutoID"].ToString() != "")
				{
					model.ProductPriceNOAutoID = int.Parse(ds.Tables[0].Rows[0]["ProductPriceNOAutoID"].ToString());
				}

				if (ds.Tables[0].Rows[0]["ProductsID"].ToString() != "")
				{
					model.ProductsID = int.Parse(ds.Tables[0].Rows[0]["ProductsID"].ToString());
				}

				if (ds.Tables[0].Rows[0]["Price"].ToString() != "")
				{

					model.Price =decimal.Parse(ds.Tables[0].Rows[0]["Price"].ToString());
				}

				if (ds.Tables[0].Rows[0]["PriceRMB"].ToString() != "")
				{

					model.PriceRMB =decimal.Parse(ds.Tables[0].Rows[0]["PriceRMB"].ToString());
				}

				if (ds.Tables[0].Rows[0]["ppAppendTime"].ToString() != "")
				{

					model.ppAppendTime = DateTime.Parse(ds.Tables[0].Rows[0]["ppAppendTime"].ToString());
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
		public DataSet GetProductPriceNOAutoList(string strWhere)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select ProductPriceNOAutoID,ProductsID,Price,PriceRMB,ppAppendTime ");
			strSql.Append(" from tbProductPriceNOAutoInfo ");
			if (strWhere.Trim() != "")
			{
				strSql.Append(" where " + strWhere);
			}
			return DbHelper.ExecuteDataset(CommandType.Text,strSql.ToString());
		}

		/// <summary>
		/// 获得最新的产品价格列表
		/// </summary>
		public DataSet GetProductPriceNOAutoListNew(string strWhere)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select distinct(p2.ProductsID),p2.ProductPriceNOAutoID,ISNULL(p2.Price,0) Price,ISNULL(p2.PriceRMB,0) PriceRMB,p2.ppAppendTime"+
				" from (select MAX(ProductPriceNOAutoID) as ProductPriceNOAutoID  from tbProductPriceNOAutoInfo group by ProductsID) as p1"+
				" join tbProductPriceNOAutoInfo as p2 "+
				" on p1.ProductPriceNOAutoID=p2.ProductPriceNOAutoID");

			if (strWhere.Trim() != "")
			{
				strSql.Append(" where " + strWhere);
			}
			return DbHelper.ExecuteDataset(CommandType.Text,strSql.ToString());
		}
	}
}

