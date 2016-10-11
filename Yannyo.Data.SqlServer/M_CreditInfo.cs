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
	/// ���ݷ�����M_CreditInfo��
	/// </summary>
	public partial class DataProvider : IDataProvider
    {
        #region  ����ͻ�������Ϣ

        /// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
        public bool ExistsM_CreditInfo(int m_UserInfoID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_M_CreditInfo");
            strSql.Append(" where m_UserInfoID=@m_UserInfoID ");
			SqlParameter[] parameters = {
					new SqlParameter("@m_UserInfoID", SqlDbType.Int,4)};
            parameters[0].Value = m_UserInfoID;

			return ((int)DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters)) > 0;
		}


		/// <summary>
		/// ����һ������
		/// </summary>
		public int AddM_CreditInfo(M_CreditInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_M_CreditInfo(");
			strSql.Append("m_UserInfoID,m_Type,m_level,score,total_num,good_num,last_updatetime)");
			strSql.Append(" values (");
			strSql.Append("@m_UserInfoID,@m_Type,@m_level,@score,@total_num,@good_num,@last_updatetime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@m_UserInfoID", SqlDbType.Int,4),
					new SqlParameter("@m_Type", SqlDbType.Int,4),
					new SqlParameter("@m_level", SqlDbType.Int,4),
					new SqlParameter("@score", SqlDbType.Int,4),
					new SqlParameter("@total_num", SqlDbType.Int,4),
					new SqlParameter("@good_num", SqlDbType.Int,4),
					new SqlParameter("@last_updatetime", SqlDbType.DateTime)};
			parameters[0].Value = model.m_UserInfoID;
			parameters[1].Value = model.m_Type;
			parameters[2].Value = model.m_level;
			parameters[3].Value = model.score;
			parameters[4].Value = model.total_num;
			parameters[5].Value = model.good_num;
			parameters[6].Value = model.last_updatetime;

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
		/// ����һ������
		/// </summary>
		public void UpdateM_CreditInfo(M_CreditInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_M_CreditInfo set ");
			strSql.Append("m_UserInfoID=@m_UserInfoID,");
			strSql.Append("m_Type=@m_Type,");
			strSql.Append("m_level=@m_level,");
			strSql.Append("score=@score,");
			strSql.Append("total_num=@total_num,");
			strSql.Append("good_num=@good_num,");
			strSql.Append("last_updatetime=@last_updatetime");
			strSql.Append(" where m_CreditInfoID=@m_CreditInfoID ");
			SqlParameter[] parameters = {
					new SqlParameter("@m_CreditInfoID", SqlDbType.Int,4),
					new SqlParameter("@m_UserInfoID", SqlDbType.Int,4),
					new SqlParameter("@m_Type", SqlDbType.Int,4),
					new SqlParameter("@m_level", SqlDbType.Int,4),
					new SqlParameter("@score", SqlDbType.Int,4),
					new SqlParameter("@total_num", SqlDbType.Int,4),
					new SqlParameter("@good_num", SqlDbType.Int,4),
					new SqlParameter("@last_updatetime", SqlDbType.DateTime)};
			parameters[0].Value = model.m_CreditInfoID;
			parameters[1].Value = model.m_UserInfoID;
			parameters[2].Value = model.m_Type;
			parameters[3].Value = model.m_level;
			parameters[4].Value = model.score;
			parameters[5].Value = model.total_num;
			parameters[6].Value = model.good_num;
			parameters[7].Value = model.last_updatetime;

			DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void DeleteM_CreditInfo(int m_CreditInfoID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_M_CreditInfo ");
			strSql.Append(" where m_CreditInfoID=@m_CreditInfoID ");
			SqlParameter[] parameters = {
					new SqlParameter("@m_CreditInfoID", SqlDbType.Int,4)};
			parameters[0].Value = m_CreditInfoID;

			DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
		}


		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public M_CreditInfo GetM_CreditInfoModel(int m_CreditInfoID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 m_CreditInfoID,m_UserInfoID,m_Type,m_level,score,total_num,good_num,last_updatetime from tb_M_CreditInfo ");
			strSql.Append(" where m_CreditInfoID=@m_CreditInfoID ");
			SqlParameter[] parameters = {
					new SqlParameter("@m_CreditInfoID", SqlDbType.Int,4)};
			parameters[0].Value = m_CreditInfoID;

			M_CreditInfo model=new M_CreditInfo();
			DataSet ds=DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(), parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["m_CreditInfoID"].ToString()!="")
				{
					model.m_CreditInfoID=int.Parse(ds.Tables[0].Rows[0]["m_CreditInfoID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["m_UserInfoID"].ToString()!="")
				{
					model.m_UserInfoID=int.Parse(ds.Tables[0].Rows[0]["m_UserInfoID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["m_Type"].ToString()!="")
				{
					model.m_Type=int.Parse(ds.Tables[0].Rows[0]["m_Type"].ToString());
				}
				if(ds.Tables[0].Rows[0]["m_level"].ToString()!="")
				{
					model.m_level=int.Parse(ds.Tables[0].Rows[0]["m_level"].ToString());
				}
				if(ds.Tables[0].Rows[0]["score"].ToString()!="")
				{
					model.score=int.Parse(ds.Tables[0].Rows[0]["score"].ToString());
				}
				if(ds.Tables[0].Rows[0]["total_num"].ToString()!="")
				{
					model.total_num=int.Parse(ds.Tables[0].Rows[0]["total_num"].ToString());
				}
				if(ds.Tables[0].Rows[0]["good_num"].ToString()!="")
				{
					model.good_num=int.Parse(ds.Tables[0].Rows[0]["good_num"].ToString());
				}
				if(ds.Tables[0].Rows[0]["last_updatetime"].ToString()!="")
				{
					model.last_updatetime=DateTime.Parse(ds.Tables[0].Rows[0]["last_updatetime"].ToString());
				}
				return model;
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		public DataSet GetM_CreditInfoList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select m_CreditInfoID,m_UserInfoID,m_Type,m_level,score,total_num,good_num,last_updatetime ");
			strSql.Append(" FROM tb_M_CreditInfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelper.ExecuteDataset(CommandType.Text,strSql.ToString());
		}

		/// <summary>
		/// ���ǰ��������
		/// </summary>
		public DataSet GetM_CreditInfoList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" m_CreditInfoID,m_UserInfoID,m_Type,m_level,score,total_num,good_num,last_updatetime ");
			strSql.Append(" FROM tb_M_CreditInfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelper.ExecuteDataset(CommandType.Text,strSql.ToString());
		}

		/// <summary>
		/// ��ҳ��ȡ�����б�
		/// </summary>
		public DataTable GetM_CreditInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
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
			parameters[0].Value = "tb_M_CreditInfo";
			parameters[1].Value = "M_CreditInfoID";
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

