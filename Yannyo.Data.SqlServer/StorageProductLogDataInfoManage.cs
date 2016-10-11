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
		public int AddStorageProductLogDataInfo(StorageProductLogDataInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tbStorageProductLogDataInfo(");
			strSql.Append("StorageProductLogID,StorageID,ProductsID,pQuantity,OrderListID)");
			strSql.Append(" values (");
			strSql.Append("@StorageProductLogID,@StorageID,@ProductsID,@pQuantity,@OrderListID)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
				new SqlParameter("@StorageProductLogID", SqlDbType.Int,4),
				new SqlParameter("@StorageID", SqlDbType.Int,4),
				new SqlParameter("@ProductsID", SqlDbType.Int,4),
				new SqlParameter("@pQuantity", SqlDbType.Int,4),
				new SqlParameter("@OrderListID", SqlDbType.Int,4)};
			parameters[0].Value = model.StorageProductLogID;
			parameters[1].Value = model.StorageID;
			parameters[2].Value = model.ProductsID;
			parameters[3].Value = model.pQuantity;
			parameters[4].Value = model.OrderListID;

			object obj = DbHelper.ExecuteScalar(CommandType.Text,strSql.ToString(),parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool UpdateStorageProductLogDataInfo(StorageProductLogDataInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tbStorageProductLogDataInfo set ");
			strSql.Append("OrderListID=@OrderListID,");
			strSql.Append("StorageProductLogID=@StorageProductLogID,");
			strSql.Append("StorageID=@StorageID,");
			strSql.Append("ProductsID=@ProductsID,");
			strSql.Append("pQuantity=@pQuantity");
			strSql.Append(" where StorageProductLogDataID=@StorageProductLogDataID");
			SqlParameter[] parameters = {
				new SqlParameter("@StorageProductLogID", SqlDbType.Int,4),
				new SqlParameter("@StorageID", SqlDbType.Int,4),
				new SqlParameter("@ProductsID", SqlDbType.Int,4),
				new SqlParameter("@pQuantity", SqlDbType.Int,4),
				new SqlParameter("@StorageProductLogDataID", SqlDbType.Int,4),
				new SqlParameter("@OrderListID", SqlDbType.Int,4)};
			parameters[0].Value = model.StorageProductLogID;
			parameters[1].Value = model.StorageID;
			parameters[2].Value = model.ProductsID;
			parameters[3].Value = model.pQuantity;
			parameters[4].Value = model.StorageProductLogDataID;
			parameters[5].Value = model.OrderListID;

			int rows=DbHelper.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
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
		public bool DeleteStorageProductLogDataInfo(int StorageProductLogDataID)
		{

			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tbStorageProductLogDataInfo ");
			strSql.Append(" where StorageProductLogDataID=@StorageProductLogDataID");
			SqlParameter[] parameters = {
				new SqlParameter("@StorageProductLogDataID", SqlDbType.Int,4)
			};
			parameters[0].Value = StorageProductLogDataID;

			int rows=DbHelper.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
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
		public bool DeleteStorageProductLogDataInfoList(string StorageProductLogDataIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tbStorageProductLogDataInfo ");
			strSql.Append(" where StorageProductLogDataID in ("+StorageProductLogDataIDlist + ")  ");
			int rows=DbHelper.ExecuteNonQuery(CommandType.Text,strSql.ToString());
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
		public StorageProductLogDataInfo GetStorageProductLogDataInfoModel(int StorageProductLogDataID)
		{

			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 StorageProductLogDataID,OrderListID,StorageProductLogID,StorageID,ProductsID,pQuantity from tbStorageProductLogDataInfo ");
			strSql.Append(" where StorageProductLogDataID=@StorageProductLogDataID");
			SqlParameter[] parameters = {
				new SqlParameter("@StorageProductLogDataID", SqlDbType.Int,4)
			};
			parameters[0].Value = StorageProductLogDataID;

			//StorageProductLogDataInfo model=new StorageProductLogDataInfo();
			DataSet ds=DbHelper.ExecuteDataset(CommandType.Text,strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToStorageProductLogDataInfoModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public StorageProductLogDataInfo DataRowToStorageProductLogDataInfoModel(DataRow row)
		{
			StorageProductLogDataInfo model=new StorageProductLogDataInfo();
			if (row != null)
			{
				if(row["StorageProductLogDataID"]!=null && row["StorageProductLogDataID"].ToString()!="")
				{
					model.StorageProductLogDataID=int.Parse(row["StorageProductLogDataID"].ToString());
				}
				if(row["StorageProductLogID"]!=null && row["StorageProductLogID"].ToString()!="")
				{
					model.StorageProductLogID=int.Parse(row["StorageProductLogID"].ToString());
				}
				if(row["StorageID"]!=null && row["StorageID"].ToString()!="")
				{
					model.StorageID=int.Parse(row["StorageID"].ToString());
				}
				if(row["ProductsID"]!=null && row["ProductsID"].ToString()!="")
				{
					model.ProductsID=int.Parse(row["ProductsID"].ToString());
				}
				if(row["pQuantity"]!=null && row["pQuantity"].ToString()!="")
				{
					model.pQuantity=int.Parse(row["pQuantity"].ToString());
				}
				if(row["OrderListID"]!=null && row["OrderListID"].ToString()!="")
				{
					model.OrderListID=int.Parse(row["OrderListID"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetStorageProductLogDataInfoList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select StorageProductLogDataID,OrderListID,StorageProductLogID,StorageID,ProductsID,pQuantity ");
			strSql.Append(" FROM tbStorageProductLogDataInfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelper.ExecuteDataset(CommandType.Text,strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetStorageProductLogDataInfoList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" StorageProductLogDataID,OrderListID,StorageProductLogID,StorageID,ProductsID,pQuantity ");
			strSql.Append(" FROM tbStorageProductLogDataInfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelper.ExecuteDataset(CommandType.Text,strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetStorageProductLogDataInfoRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM tbStorageProductLogDataInfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelper.ExecuteScalar(CommandType.Text,strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetStorageProductLogDataInfoListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.StorageProductLogDataID desc");
			}
			strSql.Append(")AS Row, T.*  from tbStorageProductLogDataInfo T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelper.ExecuteDataset(CommandType.Text,strSql.ToString());
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataTable GetStorageProductLogDataInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
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
			parameters[0].Value = "tbStorageProductLogDataInfo";
			parameters[1].Value = "StorageProductLogDataID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 1;
			parameters[5].Value = OrderType;
			parameters[6].Value = strWhere;
			parameters[7].Value = showFName + ",(select sName from tbStorageInfo where StorageID=tbStorageProductLogInfo.StorageID) as StorageName";
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

