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
	/// 数据访问类M_ConfigInfo。
	/// </summary>
	public partial class DataProvider : IDataProvider
    {
        #region  网店配置信息

        /// <summary>
		/// 是否存在该记录
		/// </summary>
        public bool ExistsM_ConfigInfo(string m_Name)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_M_ConfigInfo");
            strSql.Append(" where m_Name=@m_Name ");
			SqlParameter[] parameters = {
					new SqlParameter("@m_Name", SqlDbType.VarChar,50)};
            parameters[0].Value = m_Name;

			return ((int)DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters)) > 0;
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int AddM_ConfigInfo(M_ConfigInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_M_ConfigInfo(");
            strSql.Append("m_Name,m_AppKey,m_AppSecret,StoresID,m_State,m_AppendTime,m_SessionKey,m_UpdateTime)");
			strSql.Append(" values (");
            strSql.Append("@m_Name,@m_AppKey,@m_AppSecret,@StoresID,@m_State,@m_AppendTime,@m_SessionKey,@m_UpdateTime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@m_Name", SqlDbType.VarChar,50),
					new SqlParameter("@m_AppKey", SqlDbType.VarChar,50),
					new SqlParameter("@m_AppSecret", SqlDbType.VarChar,50),
					new SqlParameter("@StoresID", SqlDbType.Int,4),
					new SqlParameter("@m_State", SqlDbType.Int,4),
					new SqlParameter("@m_AppendTime", SqlDbType.DateTime),
                                        new SqlParameter("@m_SessionKey", SqlDbType.VarChar,50),
                                        new SqlParameter("@m_UpdateTime", SqlDbType.DateTime),};
			parameters[0].Value = model.m_Name;
			parameters[1].Value = model.m_AppKey;
			parameters[2].Value = model.m_AppSecret;
			parameters[3].Value = model.StoresID;
			parameters[4].Value = model.m_State;
			parameters[5].Value = model.m_AppendTime;
            parameters[6].Value = model.m_SessionKey;
            parameters[7].Value = model.m_UpdateTime;

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
		public void UpdateM_ConfigInfo(M_ConfigInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_M_ConfigInfo set ");
			strSql.Append("m_Name=@m_Name,");
			strSql.Append("m_AppKey=@m_AppKey,");
			strSql.Append("m_AppSecret=@m_AppSecret,");
			strSql.Append("StoresID=@StoresID,");
			strSql.Append("m_State=@m_State,");
			strSql.Append("m_AppendTime=@m_AppendTime,");
            strSql.Append("m_SessionKey=@m_SessionKey,");
            strSql.Append("m_UpdateTime=@m_UpdateTime");
			strSql.Append(" where m_ConfigInfoID=@m_ConfigInfoID ");
			SqlParameter[] parameters = {
					new SqlParameter("@m_ConfigInfoID", SqlDbType.Int,4),
					new SqlParameter("@m_Name", SqlDbType.VarChar,50),
					new SqlParameter("@m_AppKey", SqlDbType.VarChar,50),
					new SqlParameter("@m_AppSecret", SqlDbType.VarChar,50),
					new SqlParameter("@StoresID", SqlDbType.Int,4),
					new SqlParameter("@m_State", SqlDbType.Int,4),
					new SqlParameter("@m_AppendTime", SqlDbType.DateTime),
                                        new SqlParameter("@m_SessionKey", SqlDbType.VarChar,50),
                                        new SqlParameter("@m_UpdateTime", SqlDbType.DateTime),};
			parameters[0].Value = model.m_ConfigInfoID;
			parameters[1].Value = model.m_Name;
			parameters[2].Value = model.m_AppKey;
			parameters[3].Value = model.m_AppSecret;
			parameters[4].Value = model.StoresID;
			parameters[5].Value = model.m_State;
			parameters[6].Value = model.m_AppendTime;
            parameters[7].Value = model.m_SessionKey;
            parameters[8].Value = model.m_UpdateTime;

			DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
		}
        /// <summary>
        /// 更新SessionKey时间
        /// </summary>
        /// <param name="m_ConfigInfoID"></param>
        public void UpdateM_ConfigSessionKeyTime(int m_ConfigInfoID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_M_ConfigInfo set m_UpdateTime=getdate() where m_ConfigInfoID=@m_ConfigInfoID;");
            SqlParameter[] parameters = {
					new SqlParameter("@m_ConfigInfoID", SqlDbType.Int,4),
                                        };
            parameters[0].Value = m_ConfigInfoID;
            DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void DeleteM_ConfigInfo(int m_ConfigInfoID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_M_ConfigInfo ");
			strSql.Append(" where m_ConfigInfoID=@m_ConfigInfoID ");
			SqlParameter[] parameters = {
					new SqlParameter("@m_ConfigInfoID", SqlDbType.Int,4)};
			parameters[0].Value = m_ConfigInfoID;

			DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public M_ConfigInfo GetM_ConfigInfoModel(int m_ConfigInfoID)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 m_ConfigInfoID,m_Name,m_AppKey,m_AppSecret,StoresID,(select sName from tbStoresInfo where StoresID=tb_M_ConfigInfo.StoresID) as StoresName,m_State,m_AppendTime,m_SessionKey,m_UpdateTime from tb_M_ConfigInfo ");
			strSql.Append(" where m_ConfigInfoID=@m_ConfigInfoID ");
			SqlParameter[] parameters = {
					new SqlParameter("@m_ConfigInfoID", SqlDbType.Int,4)};
			parameters[0].Value = m_ConfigInfoID;

			M_ConfigInfo model=new M_ConfigInfo();
			DataSet ds=DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(), parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["m_ConfigInfoID"].ToString()!="")
				{
					model.m_ConfigInfoID=int.Parse(ds.Tables[0].Rows[0]["m_ConfigInfoID"].ToString());
				}
				model.m_Name=ds.Tables[0].Rows[0]["m_Name"].ToString();
				model.m_AppKey=ds.Tables[0].Rows[0]["m_AppKey"].ToString();
				model.m_AppSecret=ds.Tables[0].Rows[0]["m_AppSecret"].ToString();
				if(ds.Tables[0].Rows[0]["StoresID"].ToString()!="")
				{
                    model.StoresID = int.Parse(ds.Tables[0].Rows[0]["StoresID"].ToString());
				}
                model.StoresName =ds.Tables[0].Rows[0]["StoresName"].ToString();
                model.m_SessionKey = ds.Tables[0].Rows[0]["m_SessionKey"].ToString();
				if(ds.Tables[0].Rows[0]["m_State"].ToString()!="")
				{
					model.m_State=int.Parse(ds.Tables[0].Rows[0]["m_State"].ToString());
				}
				if(ds.Tables[0].Rows[0]["m_AppendTime"].ToString()!="")
				{
					model.m_AppendTime=DateTime.Parse(ds.Tables[0].Rows[0]["m_AppendTime"].ToString());
				}
                if (ds.Tables[0].Rows[0]["m_UpdateTime"].ToString() != "")
                {
                    model.m_UpdateTime = DateTime.Parse(ds.Tables[0].Rows[0]["m_UpdateTime"].ToString());
                }
				return model;
			}
			else
			{
				return null;
			}
		}

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public M_ConfigInfo GetM_ConfigInfoModelByAppKey(string m_AppKey)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 m_ConfigInfoID,m_Name,m_AppKey,m_AppSecret,StoresID,(select sName from tbStoresInfo where StoresID=tb_M_ConfigInfo.StoresID) as StoresName,m_State,m_AppendTime,m_SessionKey,m_UpdateTime from tb_M_ConfigInfo ");
            strSql.Append(" where m_AppKey=@m_AppKey ");
            SqlParameter[] parameters = {
					new SqlParameter("@m_AppKey", SqlDbType.VarChar,50)};
            parameters[0].Value = m_AppKey;

            M_ConfigInfo model = new M_ConfigInfo();
            DataSet ds = DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["m_ConfigInfoID"].ToString() != "")
                {
                    model.m_ConfigInfoID = int.Parse(ds.Tables[0].Rows[0]["m_ConfigInfoID"].ToString());
                }
                model.m_Name = ds.Tables[0].Rows[0]["m_Name"].ToString();
                model.m_AppKey = ds.Tables[0].Rows[0]["m_AppKey"].ToString();
                model.m_AppSecret = ds.Tables[0].Rows[0]["m_AppSecret"].ToString();
                if (ds.Tables[0].Rows[0]["StoresID"].ToString() != "")
                {
                    model.StoresID = int.Parse(ds.Tables[0].Rows[0]["StoresID"].ToString());
                }
                model.StoresName = ds.Tables[0].Rows[0]["StoresName"].ToString();
                model.m_SessionKey = ds.Tables[0].Rows[0]["m_SessionKey"].ToString();
                if (ds.Tables[0].Rows[0]["m_State"].ToString() != "")
                {
                    model.m_State = int.Parse(ds.Tables[0].Rows[0]["m_State"].ToString());
                }
                if (ds.Tables[0].Rows[0]["m_AppendTime"].ToString() != "")
                {
                    model.m_AppendTime = DateTime.Parse(ds.Tables[0].Rows[0]["m_AppendTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["m_UpdateTime"].ToString() != "")
                {
                    model.m_UpdateTime = DateTime.Parse(ds.Tables[0].Rows[0]["m_UpdateTime"].ToString());
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
		public DataSet GetM_ConfigInfoList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select m_ConfigInfoID,m_Name,m_AppKey,m_AppSecret,StoresID,m_State,m_AppendTime,(select sName from tbStoresInfo where StoresID=tb_M_ConfigInfo.StoresID) as StoresName,m_SessionKey,m_UpdateTime ");
			strSql.Append(" FROM tb_M_ConfigInfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelper.ExecuteDataset(CommandType.Text,strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetM_ConfigInfoList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
            strSql.Append(" m_ConfigInfoID,m_Name,m_AppKey,m_AppSecret,StoresID,m_State,m_AppendTime,(select sName from tbStoresInfo where StoresID=tb_M_ConfigInfo.StoresID) as StoresName,m_SessionKey,m_UpdateTime ");
			strSql.Append(" FROM tb_M_ConfigInfo ");
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
		public DataTable GetM_ConfigInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
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
			parameters[0].Value = "tb_M_ConfigInfo";
			parameters[1].Value = "M_ConfigInfoID";
			parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 1;
            parameters[5].Value = OrderType;
            parameters[6].Value = strWhere;
            parameters[7].Value = showFName + ",(select sName from tbStoresInfo where StoresID=tb_M_ConfigInfo.StoresID) as StoresName ";
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

