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
	/// 数据访问类M_GoodsSkuExtraInfo。
	/// </summary>
	public partial class DataProvider : IDataProvider
    {
        #region  Sku扩展信息

        /// <summary>
		/// 是否存在该记录
		/// </summary>
        public bool ExistsM_GoodsSkuExtraInfo(int m_GoodsSkuInfoID, int extra_id, int sku_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_M_GoodsSkuExtraInfo");
            strSql.Append(" where m_GoodsSkuInfoID=@m_GoodsSkuInfoID and extra_id=@extra_id and sku_id=@sku_id ");
			SqlParameter[] parameters = {
					new SqlParameter("@m_GoodsSkuInfoID", SqlDbType.Int,4),
                                        new SqlParameter("@extra_id", SqlDbType.Int,4),
                                        new SqlParameter("@sku_id", SqlDbType.Int,4)};
            parameters[0].Value = m_GoodsSkuInfoID;
            parameters[1].Value = extra_id;
            parameters[2].Value = sku_id;

			return ((int)DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters)) > 0;
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int AddM_GoodsSkuExtraInfo(M_GoodsSkuExtraInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_M_GoodsSkuExtraInfo(");
			strSql.Append("m_GoodsSkuInfoID,extra_id,sku_id,properties,quantity,price,memo,created,modified)");
			strSql.Append(" values (");
			strSql.Append("@m_GoodsSkuInfoID,@extra_id,@sku_id,@properties,@quantity,@price,@memo,@created,@modified)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@m_GoodsSkuInfoID", SqlDbType.Int,4),
					new SqlParameter("@extra_id", SqlDbType.Int,4),
					new SqlParameter("@sku_id", SqlDbType.Int,4),
					new SqlParameter("@properties", SqlDbType.VarChar,512),
					new SqlParameter("@quantity", SqlDbType.Int,4),
					new SqlParameter("@price", SqlDbType.Money,8),
					new SqlParameter("@memo", SqlDbType.VarChar,512),
					new SqlParameter("@created", SqlDbType.DateTime),
					new SqlParameter("@modified", SqlDbType.DateTime)};
			parameters[0].Value = model.m_GoodsSkuInfoID;
			parameters[1].Value = model.extra_id;
			parameters[2].Value = model.sku_id;
			parameters[3].Value = model.properties;
			parameters[4].Value = model.quantity;
			parameters[5].Value = model.price;
			parameters[6].Value = model.memo;
			parameters[7].Value = model.created;
			parameters[8].Value = model.modified;

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
		public void UpdateM_GoodsSkuExtraInfo(M_GoodsSkuExtraInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_M_GoodsSkuExtraInfo set ");
			strSql.Append("m_GoodsSkuInfoID=@m_GoodsSkuInfoID,");
			strSql.Append("extra_id=@extra_id,");
			strSql.Append("sku_id=@sku_id,");
			strSql.Append("properties=@properties,");
			strSql.Append("quantity=@quantity,");
			strSql.Append("price=@price,");
			strSql.Append("memo=@memo,");
			strSql.Append("created=@created,");
			strSql.Append("modified=@modified");
			strSql.Append(" where m_GoodsSkuExtraInfoID=@m_GoodsSkuExtraInfoID ");
			SqlParameter[] parameters = {
					new SqlParameter("@m_GoodsSkuExtraInfoID", SqlDbType.Int,4),
					new SqlParameter("@m_GoodsSkuInfoID", SqlDbType.Int,4),
					new SqlParameter("@extra_id", SqlDbType.Int,4),
					new SqlParameter("@sku_id", SqlDbType.Int,4),
					new SqlParameter("@properties", SqlDbType.VarChar,512),
					new SqlParameter("@quantity", SqlDbType.Int,4),
					new SqlParameter("@price", SqlDbType.Money,8),
					new SqlParameter("@memo", SqlDbType.VarChar,512),
					new SqlParameter("@created", SqlDbType.DateTime),
					new SqlParameter("@modified", SqlDbType.DateTime)};
			parameters[0].Value = model.m_GoodsSkuExtraInfoID;
			parameters[1].Value = model.m_GoodsSkuInfoID;
			parameters[2].Value = model.extra_id;
			parameters[3].Value = model.sku_id;
			parameters[4].Value = model.properties;
			parameters[5].Value = model.quantity;
			parameters[6].Value = model.price;
			parameters[7].Value = model.memo;
			parameters[8].Value = model.created;
			parameters[9].Value = model.modified;

			DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void DeleteM_GoodsSkuExtraInfo(int m_GoodsSkuExtraInfoID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_M_GoodsSkuExtraInfo ");
			strSql.Append(" where m_GoodsSkuExtraInfoID=@m_GoodsSkuExtraInfoID ");
			SqlParameter[] parameters = {
					new SqlParameter("@m_GoodsSkuExtraInfoID", SqlDbType.Int,4)};
			parameters[0].Value = m_GoodsSkuExtraInfoID;

			DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public M_GoodsSkuExtraInfo GetM_GoodsSkuExtraInfoModel(int m_GoodsSkuExtraInfoID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 m_GoodsSkuExtraInfoID,m_GoodsSkuInfoID,extra_id,sku_id,properties,quantity,price,memo,created,modified from tb_M_GoodsSkuExtraInfo ");
			strSql.Append(" where m_GoodsSkuExtraInfoID=@m_GoodsSkuExtraInfoID ");
			SqlParameter[] parameters = {
					new SqlParameter("@m_GoodsSkuExtraInfoID", SqlDbType.Int,4)};
			parameters[0].Value = m_GoodsSkuExtraInfoID;

			M_GoodsSkuExtraInfo model=new M_GoodsSkuExtraInfo();
			DataSet ds=DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(), parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["m_GoodsSkuExtraInfoID"].ToString()!="")
				{
					model.m_GoodsSkuExtraInfoID=int.Parse(ds.Tables[0].Rows[0]["m_GoodsSkuExtraInfoID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["m_GoodsSkuInfoID"].ToString()!="")
				{
					model.m_GoodsSkuInfoID=int.Parse(ds.Tables[0].Rows[0]["m_GoodsSkuInfoID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["extra_id"].ToString()!="")
				{
					model.extra_id=int.Parse(ds.Tables[0].Rows[0]["extra_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["sku_id"].ToString()!="")
				{
					model.sku_id=int.Parse(ds.Tables[0].Rows[0]["sku_id"].ToString());
				}
				model.properties=ds.Tables[0].Rows[0]["properties"].ToString();
				if(ds.Tables[0].Rows[0]["quantity"].ToString()!="")
				{
					model.quantity=int.Parse(ds.Tables[0].Rows[0]["quantity"].ToString());
				}
				if(ds.Tables[0].Rows[0]["price"].ToString()!="")
				{
					model.price=decimal.Parse(ds.Tables[0].Rows[0]["price"].ToString());
				}
				model.memo=ds.Tables[0].Rows[0]["memo"].ToString();
				if(ds.Tables[0].Rows[0]["created"].ToString()!="")
				{
					model.created=DateTime.Parse(ds.Tables[0].Rows[0]["created"].ToString());
				}
				if(ds.Tables[0].Rows[0]["modified"].ToString()!="")
				{
					model.modified=DateTime.Parse(ds.Tables[0].Rows[0]["modified"].ToString());
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
		public DataSet GetM_GoodsSkuExtraInfoList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select m_GoodsSkuExtraInfoID,m_GoodsSkuInfoID,extra_id,sku_id,properties,quantity,price,memo,created,modified ");
			strSql.Append(" FROM tb_M_GoodsSkuExtraInfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelper.ExecuteDataset(CommandType.Text,strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetM_GoodsSkuExtraInfoList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" m_GoodsSkuExtraInfoID,m_GoodsSkuInfoID,extra_id,sku_id,properties,quantity,price,memo,created,modified ");
			strSql.Append(" FROM tb_M_GoodsSkuExtraInfo ");
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
		public DataTable GetM_GoodsSkuExtraInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
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
			parameters[0].Value = "tb_M_GoodsSkuExtraInfo";
			parameters[1].Value = "M_GoodsSkuExtraInfoID";
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

