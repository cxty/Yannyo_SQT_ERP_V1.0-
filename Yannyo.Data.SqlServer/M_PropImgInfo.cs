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
	/// 数据访问类M_PropImgInfo。
	/// </summary>
	public partial class DataProvider : IDataProvider
    {
        #region 属性图片信息

        /// <summary>
		/// 是否存在该记录
		/// </summary>
        public bool ExistsM_PropImgInfo(int m_ConfigInfoID, int m_Type, int m_ObjID, long m_id, long product_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_M_PropImgInfo");
            strSql.Append(" where m_ConfigInfoID=@m_ConfigInfoID and m_Type=@m_Type and m_ObjID=@m_ObjID and m_id=@m_id and product_id=@product_id");
			SqlParameter[] parameters = {
					new SqlParameter("@m_ConfigInfoID", SqlDbType.Int,4),
                                        new SqlParameter("@m_Type", SqlDbType.Int,4),
                                        new SqlParameter("@m_ObjID", SqlDbType.Int,4),
                                        new SqlParameter("@m_id", SqlDbType.BigInt),
                                        new SqlParameter("@product_id", SqlDbType.BigInt)};
            parameters[0].Value = m_ConfigInfoID;
            parameters[1].Value = m_Type;
            parameters[2].Value = m_ObjID;
            parameters[3].Value = m_id;
            parameters[4].Value = product_id;

			return ((int)DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters)) > 0;
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int AddM_PropImgInfo(M_PropImgInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_M_PropImgInfo(");
			strSql.Append("m_ConfigInfoID,m_Type,m_ObjID,m_id,product_id,props,url,position,created,modified)");
			strSql.Append(" values (");
			strSql.Append("@m_ConfigInfoID,@m_Type,@m_ObjID,@m_id,@product_id,@props,@url,@position,@created,@modified)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@m_ConfigInfoID", SqlDbType.Int,4),
					new SqlParameter("@m_Type", SqlDbType.Int,4),
					new SqlParameter("@m_ObjID", SqlDbType.Int,4),
					new SqlParameter("@m_id", SqlDbType.BigInt),
					new SqlParameter("@product_id", SqlDbType.BigInt),
					new SqlParameter("@props", SqlDbType.VarChar,512),
					new SqlParameter("@url", SqlDbType.VarChar,512),
					new SqlParameter("@position", SqlDbType.Int,4),
					new SqlParameter("@created", SqlDbType.DateTime),
					new SqlParameter("@modified", SqlDbType.DateTime)};
			parameters[0].Value = model.m_ConfigInfoID;
			parameters[1].Value = model.m_Type;
			parameters[2].Value = model.m_ObjID;
			parameters[3].Value = model.m_id;
			parameters[4].Value = model.product_id;
			parameters[5].Value = model.props;
			parameters[6].Value = model.url;
			parameters[7].Value = model.position;
			parameters[8].Value = model.created;
			parameters[9].Value = model.modified;

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
		public void UpdateM_PropImgInfo(M_PropImgInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_M_PropImgInfo set ");
			strSql.Append("m_ConfigInfoID=@m_ConfigInfoID,");
			strSql.Append("m_Type=@m_Type,");
			strSql.Append("m_ObjID=@m_ObjID,");
			strSql.Append("m_id=@m_id,");
			strSql.Append("product_id=@product_id,");
			strSql.Append("props=@props,");
			strSql.Append("url=@url,");
			strSql.Append("position=@position,");
			strSql.Append("created=@created,");
			strSql.Append("modified=@modified");
			strSql.Append(" where m_PropImgInfoID=@m_PropImgInfoID ");
			SqlParameter[] parameters = {
					new SqlParameter("@m_PropImgInfoID", SqlDbType.Int,4),
					new SqlParameter("@m_ConfigInfoID", SqlDbType.Int,4),
					new SqlParameter("@m_Type", SqlDbType.Int,4),
					new SqlParameter("@m_ObjID", SqlDbType.Int,4),
					new SqlParameter("@m_id", SqlDbType.BigInt),
					new SqlParameter("@product_id", SqlDbType.BigInt),
					new SqlParameter("@props", SqlDbType.VarChar,512),
					new SqlParameter("@url", SqlDbType.VarChar,512),
					new SqlParameter("@position", SqlDbType.Int,4),
					new SqlParameter("@created", SqlDbType.DateTime),
					new SqlParameter("@modified", SqlDbType.DateTime)};
			parameters[0].Value = model.m_PropImgInfoID;
			parameters[1].Value = model.m_ConfigInfoID;
			parameters[2].Value = model.m_Type;
			parameters[3].Value = model.m_ObjID;
			parameters[4].Value = model.m_id;
			parameters[5].Value = model.product_id;
			parameters[6].Value = model.props;
			parameters[7].Value = model.url;
			parameters[8].Value = model.position;
			parameters[9].Value = model.created;
			parameters[10].Value = model.modified;

			DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void DeleteM_PropImgInfo(int m_PropImgInfoID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_M_PropImgInfo ");
			strSql.Append(" where m_PropImgInfoID=@m_PropImgInfoID ");
			SqlParameter[] parameters = {
					new SqlParameter("@m_PropImgInfoID", SqlDbType.Int,4)};
			parameters[0].Value = m_PropImgInfoID;

			DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public M_PropImgInfo GetM_PropImgInfoModel(int m_PropImgInfoID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 m_PropImgInfoID,m_ConfigInfoID,m_Type,m_ObjID,m_id,product_id,props,url,position,created,modified from tb_M_PropImgInfo ");
			strSql.Append(" where m_PropImgInfoID=@m_PropImgInfoID ");
			SqlParameter[] parameters = {
					new SqlParameter("@m_PropImgInfoID", SqlDbType.Int,4)};
			parameters[0].Value = m_PropImgInfoID;

			M_PropImgInfo model=new M_PropImgInfo();
			DataSet ds=DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(), parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["m_PropImgInfoID"].ToString()!="")
				{
					model.m_PropImgInfoID=int.Parse(ds.Tables[0].Rows[0]["m_PropImgInfoID"].ToString());
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
				if(ds.Tables[0].Rows[0]["m_id"].ToString()!="")
				{
					model.m_id=int.Parse(ds.Tables[0].Rows[0]["m_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["product_id"].ToString()!="")
				{
					model.product_id=int.Parse(ds.Tables[0].Rows[0]["product_id"].ToString());
				}
				model.props=ds.Tables[0].Rows[0]["props"].ToString();
				model.url=ds.Tables[0].Rows[0]["url"].ToString();
				if(ds.Tables[0].Rows[0]["position"].ToString()!="")
				{
					model.position=int.Parse(ds.Tables[0].Rows[0]["position"].ToString());
				}
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
		public DataSet GetM_PropImgInfoList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select m_PropImgInfoID,m_ConfigInfoID,m_Type,m_ObjID,m_id,product_id,props,url,position,created,modified ");
			strSql.Append(" FROM tb_M_PropImgInfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelper.ExecuteDataset(CommandType.Text,strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetM_PropImgInfoList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" m_PropImgInfoID,m_ConfigInfoID,m_Type,m_ObjID,m_id,product_id,props,url,position,created,modified ");
			strSql.Append(" FROM tb_M_PropImgInfo ");
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
		public DataTable GetM_PropImgInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
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
			parameters[0].Value = "tb_M_PropImgInfo";
			parameters[1].Value = "M_PropImgInfoID";
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

