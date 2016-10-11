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
		public int AddProductsFieldValue(ProductsFieldValueInfo model)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("insert into tbProductsFieldValueInfo(");
			strSql.Append("ProductsID,ProductFieldID,pfvType,pfvData,pfvAppendTime)");
			strSql.Append(" values (");
			strSql.Append("@ProductsID,@ProductFieldID,@pfvType,@pfvData,@pfvAppendTime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
				new SqlParameter("@ProductsID", SqlDbType.Int,4),
				new SqlParameter("@ProductFieldID", SqlDbType.Int,4),
				new SqlParameter("@pfvType", SqlDbType.Int,4),
				new SqlParameter("@pfvData", SqlDbType.NText),
				new SqlParameter("@pfvAppendTime", SqlDbType.DateTime)};
			parameters[0].Value = model.ProductsID;
			parameters[1].Value = model.ProductFieldID;
			parameters[2].Value = model.pfvType;
			parameters[3].Value = model.pfvData;
			parameters[4].Value = model.pfvAppendTime;

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
		public bool AddProductsFieldValue(int ProductsID,ProductFieldValueJson fJson){
			try {
				if (fJson != null) {
					StringBuilder strSql = new StringBuilder ();

					foreach (FieldValue fv in fJson.FieldValue) {
						if (fv != null) {
							strSql.Append ("insert into tbProductsFieldValueInfo(");
							strSql.Append ("ProductsID,ProductFieldID,pfvType,pfvData,pfvAppendTime)");
							strSql.Append (" values (");
							strSql.Append ("@ProductsID," + fv.ProductFieldID + "," + fv.Type + ",'" + fv.value + "',@pfvAppendTime);");
						}
					}

					SqlParameter[] parameters = {
						new SqlParameter("@ProductsID", SqlDbType.Int,4),
						new SqlParameter("@pfvAppendTime", SqlDbType.DateTime)
					};
					parameters [0].Value = ProductsID;
					parameters [1].Value = DateTime.Now;

					DbHelper.ExecuteNonQuery (CommandType.Text, strSql.ToString (), parameters);
					return true;
				}else{
					return false;
				}
			} catch {
				return false;
			}
		}
		public bool UpdateProductsFieldValue(int ProductsID,ProductFieldValueJson fJson){
			try {
				if (fJson != null) {
					string tID = "";
					StringBuilder strSql = new StringBuilder ();

					foreach (FieldValue fv in fJson.FieldValue) {
						if (fv != null) {
							if(fv.ProductFieldValueID>0){//Old Data Update
								tID +=fv.ProductFieldValueID+",";
								strSql.Append("update tbProductsFieldValueInfo set ");
								strSql.Append("ProductsID=@ProductsID,");
								strSql.Append("ProductFieldID="+fv.ProductFieldID+",");
								strSql.Append("pfvType="+fv.Type+",");
								strSql.Append("pfvData='"+fv.value+"'");

								strSql.Append(" where ProductsFieldValueID="+fv.ProductFieldValueID+" ;");
							}else{//New Data Insert
								strSql.Append ("insert into tbProductsFieldValueInfo(");
								strSql.Append ("ProductsID,ProductFieldID,pfvType,pfvData,pfvAppendTime)");
								strSql.Append (" values (");
								strSql.Append ("@ProductsID," + fv.ProductFieldID + "," + fv.Type + ",'" + fv.value + "',@pfvAppendTime);");
							}
						}
					}

					SqlParameter[] parameters = {
						new SqlParameter("@ProductsID", SqlDbType.Int,4),
						new SqlParameter("@pfvAppendTime", SqlDbType.DateTime)
					};
					parameters [0].Value = ProductsID;
					parameters [1].Value = DateTime.Now;


					//删除不在该列表内的记录
					if (tID.Trim()!="")
					{
						tID = Utils.ReSQLSetTxt(tID);
						strSql.Append("delete from tbProductsFieldValueInfo where ProductsFieldValueID not in(" + tID + ") and ProductsID=@ProductsID;");
					}

					DbHelper.ExecuteNonQuery (CommandType.Text, strSql.ToString (), parameters);
					return true;
				}else{
					return false;
				}
			} catch {
				return false;
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void UpdateProductsFieldValue(ProductsFieldValueInfo model)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("update tbProductsFieldValueInfo set ");
			strSql.Append("ProductsID=@ProductsID,");
			strSql.Append("ProductFieldID=@ProductFieldID,");
			strSql.Append("pfvType=@pfvType,");
			strSql.Append("pfvData=@pfvData,");
			strSql.Append("pfvAppendTime=@pfvAppendTime");
			strSql.Append(" where ProductsFieldValueID=@ProductsFieldValueID ");
			SqlParameter[] parameters = {
				new SqlParameter("@ProductsFieldValueID", SqlDbType.Int,4),
				new SqlParameter("@ProductsID", SqlDbType.Int,4),
				new SqlParameter("@ProductFieldID", SqlDbType.Int,4),
				new SqlParameter("@pfvType", SqlDbType.Int,4),
				new SqlParameter("@pfvData", SqlDbType.NText),
				new SqlParameter("@pfvAppendTime", SqlDbType.DateTime)};
			parameters[0].Value = model.ProductsFieldValueID;
			parameters[1].Value = model.ProductsID;
			parameters[2].Value = model.ProductFieldID;
			parameters[3].Value = model.pfvType;
			parameters[4].Value = model.pfvData;
			parameters[5].Value = model.pfvAppendTime;


			DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void DeleteProductsFieldValue(int ProductsFieldValueID)
		{

			StringBuilder strSql = new StringBuilder();
			strSql.Append("delete from tbProductsFieldValueInfo ");
			strSql.Append(" where ProductsFieldValueID=@ProductsFieldValueID ");
			SqlParameter[] parameters = {
				new SqlParameter("@ProductsFieldValueID", SqlDbType.Int,4)};
			parameters[0].Value = ProductsFieldValueID;

			DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void DeleteProductsFieldValue(string ProductsFieldValueID)
		{

			StringBuilder strSql = new StringBuilder();
			strSql.Append("delete from tbProductsFieldValueInfo ");
			strSql.Append(" where ProductsFieldValueID in(" + ProductsFieldValueID + ") ");

			DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString());
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ProductsFieldValueInfo GetProductsFieldValueModel(int ProductsFieldValueID)
		{

			StringBuilder strSql = new StringBuilder();
			strSql.Append("select  top 1 ProductsFieldValueID,ProductsID,ProductFieldID,pfvType,pfvData,pfvAppendTime from tbProductsFieldValueInfo ");
			strSql.Append(" where ProductsFieldValueID=@ProductsFieldValueID ");
			SqlParameter[] parameters = {
				new SqlParameter("@ProductsFieldValueID", SqlDbType.Int,4)};
			parameters[0].Value = ProductsFieldValueID;

			ProductsFieldValueInfo model = new ProductsFieldValueInfo();
			DataSet ds = DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(), parameters);
			if (ds.Tables[0].Rows.Count > 0)
			{
				model.pfvData = ds.Tables[0].Rows[0]["pfvData"].ToString();

				if (ds.Tables[0].Rows[0]["ProductsFieldValueID"].ToString() != "")
				{
					model.ProductsFieldValueID = int.Parse(ds.Tables[0].Rows[0]["ProductsFieldValueID"].ToString());
				}
				if (ds.Tables[0].Rows[0]["ProductsID"].ToString() != "")
				{
					model.ProductsID = int.Parse(ds.Tables[0].Rows[0]["ProductsID"].ToString());
				}
				if (ds.Tables[0].Rows[0]["ProductFieldID"].ToString() != "")
				{
					model.ProductFieldID = int.Parse(ds.Tables[0].Rows[0]["ProductFieldID"].ToString());
				}
				if (ds.Tables[0].Rows[0]["pfvType"].ToString() != "")
				{
					model.pfvType = int.Parse(ds.Tables[0].Rows[0]["pfvType"].ToString());
				}

				if (ds.Tables[0].Rows[0]["pfvAppendTime"].ToString() != "")
				{
					model.pfvAppendTime = DateTime.Parse(ds.Tables[0].Rows[0]["pfvAppendTime"].ToString());
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
		public DataSet GetProductsFieldValueList(string strWhere)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select ProductsFieldValueID,ProductsID,ProductFieldID,pfvType,pfvData,pfvAppendTime ");
			strSql.Append(" FROM tbProductsFieldValueInfo ");
			if (strWhere.Trim() != "")
			{
				strSql.Append(" where " + strWhere);
			}
			return DbHelper.ExecuteDataset(CommandType.Text,strSql.ToString());
		}


		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataTable GetProductsFieldValueList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
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
			parameters[0].Value = "tbProductsFieldValueInfo";
			parameters[1].Value = "ProductsFieldValueID";
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

