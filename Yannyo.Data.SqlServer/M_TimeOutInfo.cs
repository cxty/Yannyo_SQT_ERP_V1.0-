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
	/// 数据访问类M_TimeOutInfo。
	/// </summary>
	public partial class DataProvider : IDataProvider
    {
        #region  交易超时信息

        /// <summary>
		/// 是否存在该记录
		/// </summary>
        public bool ExistsM_TimeOutInfo(int m_ConfigInfoID, int m_Type, int m_ObjID, int remind_type)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_M_TimeOutInfo");
            strSql.Append(" where m_ConfigInfoID=@m_ConfigInfoID and m_Type=@m_Type  and m_ObjID=@m_ObjID and remind_type=@remind_type");
			SqlParameter[] parameters = {
					new SqlParameter("@m_ConfigInfoID", SqlDbType.Int,4),
                                        new SqlParameter("@m_Type", SqlDbType.Int,4),
                                        new SqlParameter("@m_ObjID", SqlDbType.Int,4),
                                        new SqlParameter("@remind_type", SqlDbType.Int,4)};
            parameters[0].Value = m_ConfigInfoID;
            parameters[1].Value = m_Type;
            parameters[2].Value = m_ObjID;
            parameters[3].Value = remind_type;

			return ((int)DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters)) > 0;
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int AddM_TimeOutInfo(M_TimeOutInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_M_TimeOutInfo(");
			strSql.Append("m_ConfigInfoID,m_Type,m_ObjID,remind_type,exist_timeout,timeout)");
			strSql.Append(" values (");
			strSql.Append("@m_ConfigInfoID,@m_Type,@m_ObjID,@remind_type,@exist_timeout,@timeout)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@m_ConfigInfoID", SqlDbType.Int,4),
					new SqlParameter("@m_Type", SqlDbType.Int,4),
					new SqlParameter("@m_ObjID", SqlDbType.Int,4),
					new SqlParameter("@remind_type", SqlDbType.Int,4),
					new SqlParameter("@exist_timeout", SqlDbType.Bit,1),
					new SqlParameter("@timeout", SqlDbType.DateTime)};
			parameters[0].Value = model.m_ConfigInfoID;
			parameters[1].Value = model.m_Type;
			parameters[2].Value = model.m_ObjID;
			parameters[3].Value = model.remind_type;
			parameters[4].Value = model.exist_timeout;
			parameters[5].Value = model.timeout;

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
		public void UpdateM_TimeOutInfo(M_TimeOutInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_M_TimeOutInfo set ");
			strSql.Append("m_ConfigInfoID=@m_ConfigInfoID,");
			strSql.Append("m_Type=@m_Type,");
			strSql.Append("m_ObjID=@m_ObjID,");
			strSql.Append("remind_type=@remind_type,");
			strSql.Append("exist_timeout=@exist_timeout,");
			strSql.Append("timeout=@timeout");
			strSql.Append(" where m_TimeOutInfoID=@m_TimeOutInfoID ");
			SqlParameter[] parameters = {
					new SqlParameter("@m_TimeOutInfoID", SqlDbType.Int,4),
					new SqlParameter("@m_ConfigInfoID", SqlDbType.Int,4),
					new SqlParameter("@m_Type", SqlDbType.Int,4),
					new SqlParameter("@m_ObjID", SqlDbType.Int,4),
					new SqlParameter("@remind_type", SqlDbType.Int,4),
					new SqlParameter("@exist_timeout", SqlDbType.Bit,1),
					new SqlParameter("@timeout", SqlDbType.DateTime)};
			parameters[0].Value = model.m_TimeOutInfoID;
			parameters[1].Value = model.m_ConfigInfoID;
			parameters[2].Value = model.m_Type;
			parameters[3].Value = model.m_ObjID;
			parameters[4].Value = model.remind_type;
			parameters[5].Value = model.exist_timeout;
			parameters[6].Value = model.timeout;

			DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void DeleteM_TimeOutInfo(int m_TimeOutInfoID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_M_TimeOutInfo ");
			strSql.Append(" where m_TimeOutInfoID=@m_TimeOutInfoID ");
			SqlParameter[] parameters = {
					new SqlParameter("@m_TimeOutInfoID", SqlDbType.Int,4)};
			parameters[0].Value = m_TimeOutInfoID;

			DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public M_TimeOutInfo GetM_TimeOutInfoModel(int m_TimeOutInfoID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 m_TimeOutInfoID,m_ConfigInfoID,m_Type,m_ObjID,remind_type,exist_timeout,timeout from tb_M_TimeOutInfo ");
			strSql.Append(" where m_TimeOutInfoID=@m_TimeOutInfoID ");
			SqlParameter[] parameters = {
					new SqlParameter("@m_TimeOutInfoID", SqlDbType.Int,4)};
			parameters[0].Value = m_TimeOutInfoID;

			M_TimeOutInfo model=new M_TimeOutInfo();
			DataSet ds=DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(), parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["m_TimeOutInfoID"].ToString()!="")
				{
					model.m_TimeOutInfoID=int.Parse(ds.Tables[0].Rows[0]["m_TimeOutInfoID"].ToString());
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
				if(ds.Tables[0].Rows[0]["remind_type"].ToString()!="")
				{
					model.remind_type=int.Parse(ds.Tables[0].Rows[0]["remind_type"].ToString());
				}
				if(ds.Tables[0].Rows[0]["exist_timeout"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["exist_timeout"].ToString()=="1")||(ds.Tables[0].Rows[0]["exist_timeout"].ToString().ToLower()=="true"))
					{
						model.exist_timeout=true;
					}
					else
					{
						model.exist_timeout=false;
					}
				}
				if(ds.Tables[0].Rows[0]["timeout"].ToString()!="")
				{
					model.timeout=DateTime.Parse(ds.Tables[0].Rows[0]["timeout"].ToString());
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
		public DataSet GetM_TimeOutInfoList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select m_TimeOutInfoID,m_ConfigInfoID,m_Type,m_ObjID,remind_type,exist_timeout,timeout ");
			strSql.Append(" FROM tb_M_TimeOutInfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelper.ExecuteDataset(CommandType.Text,strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetM_TimeOutInfoList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" m_TimeOutInfoID,m_ConfigInfoID,m_Type,m_ObjID,remind_type,exist_timeout,timeout ");
			strSql.Append(" FROM tb_M_TimeOutInfo ");
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
		public DataTable GetM_TimeOutInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
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
			parameters[0].Value = "tb_M_TimeOutInfo";
			parameters[1].Value = "M_TimeOutInfoID";
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

