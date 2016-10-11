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
	/// <summary>
	/// 数据访问类M_StockInfo。
	/// </summary>
	public partial class DataProvider : IDataProvider
    {
        #region  网店商品库存信息

        /// <summary>
		/// 是否存在该记录
		/// </summary>
        public bool ExistsM_StockInfo(int m_ConfigInfoID, int ProductsID, int StorageID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_M_StockInfo");
            strSql.Append(" where m_ConfigInfoID=@m_ConfigInfoID and ProductsID=@ProductsID and StorageID=@StorageID ");
			SqlParameter[] parameters = {
					new SqlParameter("@m_ConfigInfoID", SqlDbType.Int,4),
                                        new SqlParameter("@ProductsID", SqlDbType.Int,4),
                                        new SqlParameter("@StorageID", SqlDbType.Int,4)};
            parameters[0].Value = m_ConfigInfoID;
            parameters[1].Value = ProductsID;
            parameters[2].Value = StorageID;

			return ((int)DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters)) > 0;
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int AddM_StockInfo(M_StockInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_M_StockInfo(");
            strSql.Append("m_ConfigInfoID,ProductsID,m_Num,m_UpdateTime,StorageID)");
			strSql.Append(" values (");
            strSql.Append("@m_ConfigInfoID,@ProductsID,@m_Num,@m_UpdateTime,@StorageID)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@m_ConfigInfoID", SqlDbType.Int,4),
					new SqlParameter("@ProductsID", SqlDbType.Int,4),
					new SqlParameter("@m_Num", SqlDbType.Int,4),
					new SqlParameter("@m_UpdateTime", SqlDbType.DateTime),
                                        new SqlParameter("@StorageID", SqlDbType.Int,4),};
			parameters[0].Value = model.m_ConfigInfoID;
			parameters[1].Value = model.ProductsID;
			parameters[2].Value = model.m_Num;
			parameters[3].Value = model.m_UpdateTime;
            parameters[4].Value = model.StorageID;

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
		public void UpdateM_StockInfo(M_StockInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_M_StockInfo set ");
			strSql.Append("m_ConfigInfoID=@m_ConfigInfoID,");
			strSql.Append("ProductsID=@ProductsID,");
			strSql.Append("m_Num=@m_Num,");
			strSql.Append("m_UpdateTime=@m_UpdateTime,");
            strSql.Append("StorageID=@StorageID");
			strSql.Append(" where m_StockInfoID=@m_StockInfoID ");
			SqlParameter[] parameters = {
					new SqlParameter("@m_StockInfoID", SqlDbType.Int,4),
					new SqlParameter("@m_ConfigInfoID", SqlDbType.Int,4),
					new SqlParameter("@ProductsID", SqlDbType.Int,4),
					new SqlParameter("@m_Num", SqlDbType.Int,4),
					new SqlParameter("@m_UpdateTime", SqlDbType.DateTime),
                                        new SqlParameter("@StorageID", SqlDbType.Int,4),};
			parameters[0].Value = model.m_StockInfoID;
			parameters[1].Value = model.m_ConfigInfoID;
			parameters[2].Value = model.ProductsID;
			parameters[3].Value = model.m_Num;
			parameters[4].Value = model.m_UpdateTime;
            parameters[5].Value = model.StorageID;

			DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void DeleteM_StockInfo(int m_StockInfoID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_M_StockInfo ");
			strSql.Append(" where m_StockInfoID=@m_StockInfoID ");
			SqlParameter[] parameters = {
					new SqlParameter("@m_StockInfoID", SqlDbType.Int,4)};
			parameters[0].Value = m_StockInfoID;

			DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public M_StockInfo GetM_StockInfoModel(int m_StockInfoID)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 m_StockInfoID,m_ConfigInfoID,ProductsID,m_Num,m_UpdateTime,StorageID,(select sname from tbStorageInfo where StorageID=tb_M_StockInfo.StorageID) as StorageName from tb_M_StockInfo ");
			strSql.Append(" where m_StockInfoID=@m_StockInfoID ");
			SqlParameter[] parameters = {
					new SqlParameter("@m_StockInfoID", SqlDbType.Int,4)};
			parameters[0].Value = m_StockInfoID;

			M_StockInfo model=new M_StockInfo();
			DataSet ds=DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(), parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["m_StockInfoID"].ToString()!="")
				{
					model.m_StockInfoID=int.Parse(ds.Tables[0].Rows[0]["m_StockInfoID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["m_ConfigInfoID"].ToString()!="")
				{
					model.m_ConfigInfoID=int.Parse(ds.Tables[0].Rows[0]["m_ConfigInfoID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ProductsID"].ToString()!="")
				{
					model.ProductsID=int.Parse(ds.Tables[0].Rows[0]["ProductsID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["m_Num"].ToString()!="")
				{
					model.m_Num=int.Parse(ds.Tables[0].Rows[0]["m_Num"].ToString());
				}
				if(ds.Tables[0].Rows[0]["m_UpdateTime"].ToString()!="")
				{
					model.m_UpdateTime=DateTime.Parse(ds.Tables[0].Rows[0]["m_UpdateTime"].ToString());
				}
                if(ds.Tables[0].Rows[0]["StorageID"].ToString()!="")
				{
					model.StorageID=int.Parse(ds.Tables[0].Rows[0]["StorageID"].ToString());
				}
                model.StorageName = ds.Tables[0].Rows[0]["StorageName"].ToString();
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
		public DataSet GetM_StockInfoList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select m_StockInfoID,m_ConfigInfoID,ProductsID,m_Num,m_UpdateTime,StorageID,(select sname from tbStorageInfo where StorageID=tb_M_StockInfo.StorageID) as StorageName ");
			strSql.Append(" FROM tb_M_StockInfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelper.ExecuteDataset(CommandType.Text,strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetM_StockInfoList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
            strSql.Append(" m_StockInfoID,m_ConfigInfoID,ProductsID,m_Num,m_UpdateTime,StorageID,(select sname from tbStorageInfo where StorageID=tb_M_StockInfo.StorageID) as StorageName ");
			strSql.Append(" FROM tb_M_StockInfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelper.ExecuteDataset(CommandType.Text,strSql.ToString());
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataTable GetM_StockInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
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
			parameters[0].Value = "tb_M_StockInfo";
			parameters[1].Value = "M_StockInfoID";
			parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 1;
            parameters[5].Value = OrderType;
            parameters[6].Value = strWhere;
            parameters[7].Value = showFName + ",(select sname from tbStorageInfo where StorageID=tb_M_StockInfo.StorageID) as StorageName ";
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

