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

		public bool ExistsProductField(int ProductClassID,string pfName)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select count(1) from tbProductFieldInfo");
			strSql.Append(" where ProductClassID=@ProductClassID and pfName=@pfName ");
			SqlParameter[] parameters = {
				new SqlParameter("@ProductClassID", SqlDbType.Int,4),
				new SqlParameter("@pfName", SqlDbType.VarChar,128)};
			parameters[0].Value = ProductClassID;
			parameters[1].Value = pfName;

			return ((int)DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters)) > 0;
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int AddProductField(ProductFieldInfo model)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("insert into tbProductFieldInfo(");
			strSql.Append("ProductClassID,pfName,pfType,pfOrder,pfState,pfAppendTime)");
			strSql.Append(" values (");
			strSql.Append("@ProductClassID,@pfName,@pfType,@pfOrder,@pfState,@pfAppendTime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
				new SqlParameter("@ProductClassID", SqlDbType.Int,4),
				new SqlParameter("@pfName", SqlDbType.VarChar,128),
				new SqlParameter("@pfType", SqlDbType.Int,4),
				new SqlParameter("@pfOrder", SqlDbType.Int,4),
				new SqlParameter("@pfState", SqlDbType.Int,4),
				new SqlParameter("@pfAppendTime", SqlDbType.DateTime)};
			parameters[0].Value = model.ProductClassID;
			parameters[1].Value = model.pfName;
			parameters[2].Value = model.pfType;
			parameters[3].Value = model.pfOrder;
			parameters[4].Value = model.pfState;
			parameters[5].Value = model.pfAppendTime;

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
		public int UpdateProductField(ProductFieldInfo model)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("update tbProductFieldInfo set ");
			strSql.Append("ProductClassID=@ProductClassID,");
			strSql.Append("pfName=@pfName,");
			strSql.Append("pfType=@pfType,");
			strSql.Append("pfOrder=@pfOrder,");
			strSql.Append("pfState=@pfState,");
			strSql.Append("pfAppendTime=@pfAppendTime");
			strSql.Append(" where ProductFieldID=@ProductFieldID ");
			SqlParameter[] parameters = {
				new SqlParameter("@ProductFieldID", SqlDbType.Int,4),
				new SqlParameter("@ProductClassID", SqlDbType.Int,4),
				new SqlParameter("@pfName", SqlDbType.VarChar,128),
				new SqlParameter("@pfType", SqlDbType.Int,4),
				new SqlParameter("@pfOrder", SqlDbType.Int,4),
				new SqlParameter("@pfState", SqlDbType.Int,4),
				new SqlParameter("@pfAppendTime", SqlDbType.DateTime)};
			parameters[0].Value = model.ProductFieldID;
			parameters[1].Value = model.ProductClassID;
			parameters[2].Value = model.pfName;
			parameters[3].Value = model.pfType;
			parameters[4].Value = model.pfOrder;
			parameters[5].Value = model.pfState;
			parameters[6].Value = model.pfAppendTime;


			return DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void DeleteProductField(int ProductFieldID)
		{

			StringBuilder strSql = new StringBuilder();
			strSql.Append("delete from tbProductFieldInfo ");
			strSql.Append(" where ProductFieldID=@ProductFieldID ");
			SqlParameter[] parameters = {
				new SqlParameter("@ProductFieldID", SqlDbType.Int,4)};
			parameters[0].Value = ProductFieldID;

			DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void DeleteProductField(string ProductFieldID)
		{

			StringBuilder strSql = new StringBuilder();
			strSql.Append("delete from tbProductFieldInfo ");
			strSql.Append(" where ProductFieldID in(" + ProductFieldID + ") ");

			DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString());
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ProductFieldInfo GetProductFieldModel(int ProductFieldID)
		{

			StringBuilder strSql = new StringBuilder();
			strSql.Append("select  top 1 ProductFieldID,ProductClassID,pfName,pfType,pfOrder,pfState,pfAppendTime,(select pClassName from tbProductClassInfo where tbProductClassInfo.ProductClassID=tbProductFieldInfo.ProductClassID) as ProductClassName from tbProductFieldInfo ");
			strSql.Append(" where ProductFieldID=@ProductFieldID ");
			SqlParameter[] parameters = {
				new SqlParameter("@ProductFieldID", SqlDbType.Int,4)};
			parameters[0].Value = ProductFieldID;

			ProductFieldInfo model = new ProductFieldInfo();
			DataSet ds = DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(), parameters);
			if (ds.Tables[0].Rows.Count > 0)
			{
				model.ProductClassName = ds.Tables[0].Rows[0]["ProductClassName"].ToString();
				model.pfName = ds.Tables[0].Rows[0]["pfName"].ToString();
				if (ds.Tables[0].Rows[0]["ProductFieldID"].ToString() != "")
				{
					model.ProductFieldID = int.Parse(ds.Tables[0].Rows[0]["ProductFieldID"].ToString());
				}
				if (ds.Tables[0].Rows[0]["ProductClassID"].ToString() != "")
				{
					model.ProductClassID = int.Parse(ds.Tables[0].Rows[0]["ProductClassID"].ToString());
				}
				if (ds.Tables[0].Rows[0]["pfType"].ToString() != "")
				{
					model.pfType = int.Parse(ds.Tables[0].Rows[0]["pfType"].ToString());
				}
				if (ds.Tables[0].Rows[0]["pfOrder"].ToString() != "")
				{
					model.pfOrder = int.Parse(ds.Tables[0].Rows[0]["pfOrder"].ToString());
				}
				if (ds.Tables[0].Rows[0]["pfState"].ToString() != "")
				{
					model.pfState = int.Parse(ds.Tables[0].Rows[0]["pfState"].ToString());
				}
				if (ds.Tables[0].Rows[0]["pfAppendTime"].ToString() != "")
				{
					model.pfAppendTime = DateTime.Parse(ds.Tables[0].Rows[0]["pfAppendTime"].ToString());
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
		public DataSet GetProductFieldList(string strWhere)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select ProductFieldID,ProductClassID,pfName,pfType,pfOrder,pfState,pfAppendTime,(select pClassName from tbProductClassInfo where tbProductClassInfo.ProductClassID=tbProductFieldInfo.ProductClassID) as ProductClassName ");
			strSql.Append(" FROM tbProductFieldInfo ");
			if (strWhere.Trim() != "")
			{
				strSql.Append(" where " + strWhere);
			}
			return DbHelper.ExecuteDataset(CommandType.Text,strSql.ToString());
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataTable GetProductFieldList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
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
			parameters[0].Value = "tbProductFieldInfo";
			parameters[1].Value = "ProductFieldID";
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

