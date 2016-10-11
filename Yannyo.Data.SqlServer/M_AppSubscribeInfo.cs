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
	/// 数据访问类M_AppSubscribeInfo。
	/// </summary>
	public partial class DataProvider : IDataProvider
    {
        #region  网店客户应用订购信息

        /// <summary>
		/// 是否存在该记录
		/// </summary>
        public bool ExistsM_AppSubscribeInfo(int m_UserInfoID, int lease_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_M_AppSubscribeInfo");
            strSql.Append(" where m_UserInfoID=@m_UserInfoID and lease_id=@lease_id");
			SqlParameter[] parameters = {
					new SqlParameter("@m_UserInfoID", SqlDbType.Int,4),
                                        new SqlParameter("@lease_id", SqlDbType.Int,4)};
            parameters[0].Value = m_UserInfoID;
            parameters[1].Value = lease_id;

			return ((int)DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters)) > 0;
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int AddM_AppSubscribeInfo(M_AppSubscribeInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_M_AppSubscribeInfo(");
			strSql.Append("m_UserInfoID,lease_id,status,start_date,end_date,version_no)");
			strSql.Append(" values (");
			strSql.Append("@m_UserInfoID,@lease_id,@status,@start_date,@end_date,@version_no)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@m_UserInfoID", SqlDbType.Int,4),
					new SqlParameter("@lease_id", SqlDbType.VarChar,50),
					new SqlParameter("@status", SqlDbType.VarChar,50),
					new SqlParameter("@start_date", SqlDbType.DateTime),
					new SqlParameter("@end_date", SqlDbType.DateTime),
					new SqlParameter("@version_no", SqlDbType.Int,4)};
			parameters[0].Value = model.m_UserInfoID;
			parameters[1].Value = model.lease_id;
			parameters[2].Value = model.status;
			parameters[3].Value = model.start_date;
			parameters[4].Value = model.end_date;
			parameters[5].Value = model.version_no;

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
		public void UpdateM_AppSubscribeInfo(M_AppSubscribeInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_M_AppSubscribeInfo set ");
			strSql.Append("m_UserInfoID=@m_UserInfoID,");
			strSql.Append("lease_id=@lease_id,");
			strSql.Append("status=@status,");
			strSql.Append("start_date=@start_date,");
			strSql.Append("end_date=@end_date,");
			strSql.Append("version_no=@version_no");
			strSql.Append(" where m_AppSubscribeInfoID=@m_AppSubscribeInfoID ");
			SqlParameter[] parameters = {
					new SqlParameter("@m_AppSubscribeInfoID", SqlDbType.Int,4),
					new SqlParameter("@m_UserInfoID", SqlDbType.Int,4),
					new SqlParameter("@lease_id", SqlDbType.VarChar,50),
					new SqlParameter("@status", SqlDbType.VarChar,50),
					new SqlParameter("@start_date", SqlDbType.DateTime),
					new SqlParameter("@end_date", SqlDbType.DateTime),
					new SqlParameter("@version_no", SqlDbType.Int,4)};
			parameters[0].Value = model.m_AppSubscribeInfoID;
			parameters[1].Value = model.m_UserInfoID;
			parameters[2].Value = model.lease_id;
			parameters[3].Value = model.status;
			parameters[4].Value = model.start_date;
			parameters[5].Value = model.end_date;
			parameters[6].Value = model.version_no;

			DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void DeleteM_AppSubscribeInfo(int m_AppSubscribeInfoID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_M_AppSubscribeInfo ");
			strSql.Append(" where m_AppSubscribeInfoID=@m_AppSubscribeInfoID ");
			SqlParameter[] parameters = {
					new SqlParameter("@m_AppSubscribeInfoID", SqlDbType.Int,4)};
			parameters[0].Value = m_AppSubscribeInfoID;

			DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public M_AppSubscribeInfo GetM_AppSubscribeInfoModel(int m_AppSubscribeInfoID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 m_AppSubscribeInfoID,m_UserInfoID,lease_id,status,start_date,end_date,version_no from tb_M_AppSubscribeInfo ");
			strSql.Append(" where m_AppSubscribeInfoID=@m_AppSubscribeInfoID ");
			SqlParameter[] parameters = {
					new SqlParameter("@m_AppSubscribeInfoID", SqlDbType.Int,4)};
			parameters[0].Value = m_AppSubscribeInfoID;

			M_AppSubscribeInfo model=new M_AppSubscribeInfo();
			DataSet ds=DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(), parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["m_AppSubscribeInfoID"].ToString()!="")
				{
					model.m_AppSubscribeInfoID=int.Parse(ds.Tables[0].Rows[0]["m_AppSubscribeInfoID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["m_UserInfoID"].ToString()!="")
				{
					model.m_UserInfoID=int.Parse(ds.Tables[0].Rows[0]["m_UserInfoID"].ToString());
				}
				model.lease_id=ds.Tables[0].Rows[0]["lease_id"].ToString();
				model.status=ds.Tables[0].Rows[0]["status"].ToString();
				if(ds.Tables[0].Rows[0]["start_date"].ToString()!="")
				{
					model.start_date=DateTime.Parse(ds.Tables[0].Rows[0]["start_date"].ToString());
				}
				if(ds.Tables[0].Rows[0]["end_date"].ToString()!="")
				{
					model.end_date=DateTime.Parse(ds.Tables[0].Rows[0]["end_date"].ToString());
				}
				if(ds.Tables[0].Rows[0]["version_no"].ToString()!="")
				{
					model.version_no=int.Parse(ds.Tables[0].Rows[0]["version_no"].ToString());
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
		public DataSet GetM_AppSubscribeInfoList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select m_AppSubscribeInfoID,m_UserInfoID,lease_id,status,start_date,end_date,version_no ");
			strSql.Append(" FROM tb_M_AppSubscribeInfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelper.ExecuteDataset(CommandType.Text,strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetM_AppSubscribeInfoList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" m_AppSubscribeInfoID,m_UserInfoID,lease_id,status,start_date,end_date,version_no ");
			strSql.Append(" FROM tb_M_AppSubscribeInfo ");
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
		public DataTable GetM_AppSubscribeInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
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
			parameters[0].Value = "tb_M_AppSubscribeInfo";
			parameters[1].Value = "M_AppSubscribeInfoID";
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

