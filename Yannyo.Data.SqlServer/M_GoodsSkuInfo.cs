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
	/// 数据访问类M_GoodsSkuInfo。
	/// </summary>
	public partial class DataProvider : IDataProvider
    {
        #region  Sku信息

        /// <summary>
		/// 是否存在该记录
		/// </summary>
        public bool ExistsM_GoodsSkuInfo(int m_ConfigInfoID, int m_Type, int m_ObjID, int sku_id, int num_iid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_M_GoodsSkuInfo");
            strSql.Append(" where m_ConfigInfoID=@m_ConfigInfoID and m_Type=@m_Type and m_ObjID=@m_ObjID and sku_id=@sku_id and num_iid=@num_iid");
			SqlParameter[] parameters = {
					new SqlParameter("@m_ConfigInfoID", SqlDbType.Int,4),
                                        new SqlParameter("@m_Type", SqlDbType.Int,4),
                                        new SqlParameter("@m_ObjID", SqlDbType.Int,4),
                                        new SqlParameter("@sku_id", SqlDbType.BigInt),
                                        new SqlParameter("@num_iid", SqlDbType.BigInt)};
			parameters[0].Value = m_ConfigInfoID;
            parameters[1].Value = m_Type;
            parameters[2].Value = m_ObjID;
            parameters[3].Value = sku_id;
            parameters[4].Value = num_iid;

			return ((int)DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters)) > 0;
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int AddM_GoodsSkuInfo(M_GoodsSkuInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_M_GoodsSkuInfo(");
			strSql.Append("m_ConfigInfoID,m_Type,m_ObjID,sku_id,num_iid,properties,quantity,price,outer_id,created,modified,[status])");
			strSql.Append(" values (");
			strSql.Append("@m_ConfigInfoID,@m_Type,@m_ObjID,@sku_id,@num_iid,@properties,@quantity,@price,@outer_id,@created,@modified,@status)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@m_ConfigInfoID", SqlDbType.Int,4),
					new SqlParameter("@m_Type", SqlDbType.Int,4),
					new SqlParameter("@m_ObjID", SqlDbType.Int,4),
					new SqlParameter("@sku_id", SqlDbType.Int,4),
					new SqlParameter("@num_iid", SqlDbType.BigInt),
					new SqlParameter("@properties", SqlDbType.VarChar,512),
					new SqlParameter("@quantity", SqlDbType.Int,4),
					new SqlParameter("@price", SqlDbType.Money,8),
					new SqlParameter("@outer_id", SqlDbType.VarChar,50),
					new SqlParameter("@created", SqlDbType.DateTime),
					new SqlParameter("@modified", SqlDbType.DateTime),
					new SqlParameter("@status", SqlDbType.VarChar,50)};
			parameters[0].Value = model.m_ConfigInfoID;
			parameters[1].Value = model.m_Type;
			parameters[2].Value = model.m_ObjID;
			parameters[3].Value = model.sku_id;
			parameters[4].Value = model.num_iid;
			parameters[5].Value = model.properties;
			parameters[6].Value = model.quantity;
			parameters[7].Value = model.price;
			parameters[8].Value = model.outer_id;
			parameters[9].Value = model.created;
			parameters[10].Value = model.modified;
			parameters[11].Value = model.status;

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
		public void UpdateM_GoodsSkuInfo(M_GoodsSkuInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_M_GoodsSkuInfo set ");
			strSql.Append("m_ConfigInfoID=@m_ConfigInfoID,");
			strSql.Append("m_Type=@m_Type,");
			strSql.Append("m_ObjID=@m_ObjID,");
			strSql.Append("sku_id=@sku_id,");
			strSql.Append("num_iid=@num_iid,");
			strSql.Append("properties=@properties,");
			strSql.Append("quantity=@quantity,");
			strSql.Append("price=@price,");
			strSql.Append("outer_id=@outer_id,");
			strSql.Append("created=@created,");
			strSql.Append("modified=@modified,");
			strSql.Append("[status]=@status");
			strSql.Append(" where m_GoodsSkuInfoID=@m_GoodsSkuInfoID ");
			SqlParameter[] parameters = {
					new SqlParameter("@m_GoodsSkuInfoID", SqlDbType.Int,4),
					new SqlParameter("@m_ConfigInfoID", SqlDbType.Int,4),
					new SqlParameter("@m_Type", SqlDbType.Int,4),
					new SqlParameter("@m_ObjID", SqlDbType.Int,4),
					new SqlParameter("@sku_id", SqlDbType.Int,4),
					new SqlParameter("@num_iid", SqlDbType.BigInt),
					new SqlParameter("@properties", SqlDbType.VarChar,512),
					new SqlParameter("@quantity", SqlDbType.Int,4),
					new SqlParameter("@price", SqlDbType.Money,8),
					new SqlParameter("@outer_id", SqlDbType.VarChar,50),
					new SqlParameter("@created", SqlDbType.DateTime),
					new SqlParameter("@modified", SqlDbType.DateTime),
					new SqlParameter("@status", SqlDbType.VarChar,50)};
			parameters[0].Value = model.m_GoodsSkuInfoID;
			parameters[1].Value = model.m_ConfigInfoID;
			parameters[2].Value = model.m_Type;
			parameters[3].Value = model.m_ObjID;
			parameters[4].Value = model.sku_id;
			parameters[5].Value = model.num_iid;
			parameters[6].Value = model.properties;
			parameters[7].Value = model.quantity;
			parameters[8].Value = model.price;
			parameters[9].Value = model.outer_id;
			parameters[10].Value = model.created;
			parameters[11].Value = model.modified;
			parameters[12].Value = model.status;

			DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void DeleteM_GoodsSkuInfo(int m_GoodsSkuInfoID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_M_GoodsSkuInfo ");
			strSql.Append(" where m_GoodsSkuInfoID=@m_GoodsSkuInfoID ");
			SqlParameter[] parameters = {
					new SqlParameter("@m_GoodsSkuInfoID", SqlDbType.Int,4)};
			parameters[0].Value = m_GoodsSkuInfoID;

			DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public M_GoodsSkuInfo GetM_GoodsSkuInfoModel(int m_GoodsSkuInfoID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 m_GoodsSkuInfoID,m_ConfigInfoID,m_Type,m_ObjID,sku_id,num_iid,properties,quantity,price,outer_id,created,modified,[status] from tb_M_GoodsSkuInfo ");
			strSql.Append(" where m_GoodsSkuInfoID=@m_GoodsSkuInfoID ");
			SqlParameter[] parameters = {
					new SqlParameter("@m_GoodsSkuInfoID", SqlDbType.Int,4)};
			parameters[0].Value = m_GoodsSkuInfoID;

			M_GoodsSkuInfo model=new M_GoodsSkuInfo();
			DataSet ds=DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(), parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["m_GoodsSkuInfoID"].ToString()!="")
				{
					model.m_GoodsSkuInfoID=int.Parse(ds.Tables[0].Rows[0]["m_GoodsSkuInfoID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["m_ConfigInfoID"].ToString()!="")
				{
					model.m_ConfigInfoID=int.Parse(ds.Tables[0].Rows[0]["m_ConfigInfoID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["m_Type"].ToString()!="")
				{
					model.m_Type=int.Parse(ds.Tables[0].Rows[0]["m_Type"].ToString());
				}
				if(ds.Tables[0].Rows[0]["m_ObjID"].ToString()!="")
				{
					model.m_ObjID=int.Parse(ds.Tables[0].Rows[0]["m_ObjID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["sku_id"].ToString()!="")
				{
					model.sku_id=int.Parse(ds.Tables[0].Rows[0]["sku_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["num_iid"].ToString()!="")
				{
					model.num_iid=int.Parse(ds.Tables[0].Rows[0]["num_iid"].ToString());
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
				model.outer_id=ds.Tables[0].Rows[0]["outer_id"].ToString();
				if(ds.Tables[0].Rows[0]["created"].ToString()!="")
				{
					model.created=DateTime.Parse(ds.Tables[0].Rows[0]["created"].ToString());
				}
				if(ds.Tables[0].Rows[0]["modified"].ToString()!="")
				{
					model.modified=DateTime.Parse(ds.Tables[0].Rows[0]["modified"].ToString());
				}
				model.status=ds.Tables[0].Rows[0]["status"].ToString();
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
		public DataSet GetM_GoodsSkuInfoList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select m_GoodsSkuInfoID,m_ConfigInfoID,m_Type,m_ObjID,sku_id,num_iid,properties,quantity,price,outer_id,created,modified,[status] ");
			strSql.Append(" FROM tb_M_GoodsSkuInfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelper.ExecuteDataset(CommandType.Text,strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetM_GoodsSkuInfoList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" m_GoodsSkuInfoID,m_ConfigInfoID,m_Type,m_ObjID,sku_id,num_iid,properties,quantity,price,outer_id,created,modified,[status] ");
			strSql.Append(" FROM tb_M_GoodsSkuInfo ");
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
		public DataTable GetM_GoodsSkuInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
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
			parameters[0].Value = "tb_M_GoodsSkuInfo";
			parameters[1].Value = "M_GoodsSkuInfoID";
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

