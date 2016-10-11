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
	/// 数据访问类M_MessageImgInfo。
	/// </summary>
	public partial class DataProvider : IDataProvider
    {
        #region  交易留言凭证图片信息

        /// <summary>
		/// 是否存在该记录
		/// </summary>
        public bool ExistsM_MessageImgInfo(int m_MessageInfoID, string url)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_M_MessageImgInfo");
            strSql.Append(" where m_MessageInfoID=@m_MessageInfoID and url=@url");
			SqlParameter[] parameters = {
					new SqlParameter("@m_MessageInfoID", SqlDbType.Int,4),
                                        new SqlParameter("@url", SqlDbType.VarChar,512)};
            parameters[0].Value = m_MessageInfoID;
            parameters[1].Value = url;

			return ((int)DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters)) > 0;
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int AddM_MessageImgInfo(M_MessageImgInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_M_MessageImgInfo(");
			strSql.Append("m_MessageInfoID,url)");
			strSql.Append(" values (");
			strSql.Append("@m_MessageInfoID,@url)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@m_MessageInfoID", SqlDbType.Int,4),
					new SqlParameter("@url", SqlDbType.VarChar,512)};
			parameters[0].Value = model.m_MessageInfoID;
			parameters[1].Value = model.url;

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
		public void UpdateM_MessageImgInfo(M_MessageImgInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_M_MessageImgInfo set ");
			strSql.Append("m_MessageInfoID=@m_MessageInfoID,");
			strSql.Append("url=@url");
			strSql.Append(" where m_MessageImgInfoID=@m_MessageImgInfoID ");
			SqlParameter[] parameters = {
					new SqlParameter("@m_MessageImgInfoID", SqlDbType.Int,4),
					new SqlParameter("@m_MessageInfoID", SqlDbType.Int,4),
					new SqlParameter("@url", SqlDbType.VarChar,512)};
			parameters[0].Value = model.m_MessageImgInfoID;
			parameters[1].Value = model.m_MessageInfoID;
			parameters[2].Value = model.url;

			DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void DeleteM_MessageImgInfo(int m_MessageImgInfoID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_M_MessageImgInfo ");
			strSql.Append(" where m_MessageImgInfoID=@m_MessageImgInfoID ");
			SqlParameter[] parameters = {
					new SqlParameter("@m_MessageImgInfoID", SqlDbType.Int,4)};
			parameters[0].Value = m_MessageImgInfoID;

			DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public M_MessageImgInfo GetM_MessageImgInfoModel(int m_MessageImgInfoID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 m_MessageImgInfoID,m_MessageInfoID,url from tb_M_MessageImgInfo ");
			strSql.Append(" where m_MessageImgInfoID=@m_MessageImgInfoID ");
			SqlParameter[] parameters = {
					new SqlParameter("@m_MessageImgInfoID", SqlDbType.Int,4)};
			parameters[0].Value = m_MessageImgInfoID;

			M_MessageImgInfo model=new M_MessageImgInfo();
			DataSet ds=DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(), parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["m_MessageImgInfoID"].ToString()!="")
				{
					model.m_MessageImgInfoID=int.Parse(ds.Tables[0].Rows[0]["m_MessageImgInfoID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["m_MessageInfoID"].ToString()!="")
				{
					model.m_MessageInfoID=int.Parse(ds.Tables[0].Rows[0]["m_MessageInfoID"].ToString());
				}
				model.url=ds.Tables[0].Rows[0]["url"].ToString();
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
		public DataSet GetM_MessageImgInfoList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select m_MessageImgInfoID,m_MessageInfoID,url ");
			strSql.Append(" FROM tb_M_MessageImgInfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelper.ExecuteDataset(CommandType.Text,strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetM_MessageImgInfoList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" m_MessageImgInfoID,m_MessageInfoID,url ");
			strSql.Append(" FROM tb_M_MessageImgInfo ");
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
		public DataTable GetM_MessageImgInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
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
			parameters[0].Value = "tb_M_MessageImgInfo";
			parameters[1].Value = "M_MessageImgInfoID";
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

