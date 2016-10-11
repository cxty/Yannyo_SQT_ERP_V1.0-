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
	/// 数据访问类M_MessageInfo。
	/// </summary>
	public partial class DataProvider : IDataProvider
    {
        #region  交易留言凭证信息

        /// <summary>
		/// 是否存在该记录
		/// </summary>
        public bool ExistsM_MessageInfo(int m_ConfigInfoID, int m_Type, int m_ObjID, int m_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_M_MessageInfo");
            strSql.Append(" where m_ConfigInfoID=@m_ConfigInfoID and m_Type=@m_Type and m_ObjID=@m_ObjID and m_id=@m_id ");
			SqlParameter[] parameters = {
					new SqlParameter("@m_ConfigInfoID", SqlDbType.Int,4),
                                        new SqlParameter("@m_Type", SqlDbType.Int,4),
                                        new SqlParameter("@m_ObjID", SqlDbType.Int,4),
                                        new SqlParameter("@m_id", SqlDbType.Int,4)};
            parameters[0].Value = m_ConfigInfoID;
            parameters[1].Value = m_Type;
            parameters[2].Value = m_ObjID;
            parameters[3].Value = m_id;

			return ((int)DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters)) > 0;
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int AddM_MessageInfo(M_MessageInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_M_MessageInfo(");
			strSql.Append("m_ConfigInfoID,m_Type,m_ObjID,m_id,refund_id,owner_id,owner_nick,owner_role,m_content,created,message_type)");
			strSql.Append(" values (");
			strSql.Append("@m_ConfigInfoID,@m_Type,@m_ObjID,@m_id,@refund_id,@owner_id,@owner_nick,@owner_role,@m_content,@created,@message_type)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@m_ConfigInfoID", SqlDbType.Int,4),
					new SqlParameter("@m_Type", SqlDbType.Int,4),
					new SqlParameter("@m_ObjID", SqlDbType.Int,4),
					new SqlParameter("@m_id", SqlDbType.Int,4),
					new SqlParameter("@refund_id", SqlDbType.Int,4),
					new SqlParameter("@owner_id", SqlDbType.Int,4),
					new SqlParameter("@owner_nick", SqlDbType.VarChar,50),
					new SqlParameter("@owner_role", SqlDbType.VarChar,50),
					new SqlParameter("@m_content", SqlDbType.VarChar,400),
					new SqlParameter("@created", SqlDbType.DateTime),
					new SqlParameter("@message_type", SqlDbType.VarChar,50)};
			parameters[0].Value = model.m_ConfigInfoID;
			parameters[1].Value = model.m_Type;
			parameters[2].Value = model.m_ObjID;
			parameters[3].Value = model.m_id;
			parameters[4].Value = model.refund_id;
			parameters[5].Value = model.owner_id;
			parameters[6].Value = model.owner_nick;
			parameters[7].Value = model.owner_role;
			parameters[8].Value = model.m_content;
			parameters[9].Value = model.created;
			parameters[10].Value = model.message_type;

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
		public void UpdateM_MessageInfo(M_MessageInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_M_MessageInfo set ");
			strSql.Append("m_ConfigInfoID=@m_ConfigInfoID,");
			strSql.Append("m_Type=@m_Type,");
			strSql.Append("m_ObjID=@m_ObjID,");
			strSql.Append("m_id=@m_id,");
			strSql.Append("refund_id=@refund_id,");
			strSql.Append("owner_id=@owner_id,");
			strSql.Append("owner_nick=@owner_nick,");
			strSql.Append("owner_role=@owner_role,");
			strSql.Append("m_content=@m_content,");
			strSql.Append("created=@created,");
			strSql.Append("message_type=@message_type");
			strSql.Append(" where m_MessageInfoID=@m_MessageInfoID ");
			SqlParameter[] parameters = {
					new SqlParameter("@m_MessageInfoID", SqlDbType.Int,4),
					new SqlParameter("@m_ConfigInfoID", SqlDbType.Int,4),
					new SqlParameter("@m_Type", SqlDbType.Int,4),
					new SqlParameter("@m_ObjID", SqlDbType.Int,4),
					new SqlParameter("@m_id", SqlDbType.Int,4),
					new SqlParameter("@refund_id", SqlDbType.Int,4),
					new SqlParameter("@owner_id", SqlDbType.Int,4),
					new SqlParameter("@owner_nick", SqlDbType.VarChar,50),
					new SqlParameter("@owner_role", SqlDbType.VarChar,50),
					new SqlParameter("@m_content", SqlDbType.VarChar,400),
					new SqlParameter("@created", SqlDbType.DateTime),
					new SqlParameter("@message_type", SqlDbType.VarChar,50)};
			parameters[0].Value = model.m_MessageInfoID;
			parameters[1].Value = model.m_ConfigInfoID;
			parameters[2].Value = model.m_Type;
			parameters[3].Value = model.m_ObjID;
			parameters[4].Value = model.m_id;
			parameters[5].Value = model.refund_id;
			parameters[6].Value = model.owner_id;
			parameters[7].Value = model.owner_nick;
			parameters[8].Value = model.owner_role;
			parameters[9].Value = model.m_content;
			parameters[10].Value = model.created;
			parameters[11].Value = model.message_type;

			DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void DeleteM_MessageInfo(int m_MessageInfoID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_M_MessageInfo ");
			strSql.Append(" where m_MessageInfoID=@m_MessageInfoID ");
			SqlParameter[] parameters = {
					new SqlParameter("@m_MessageInfoID", SqlDbType.Int,4)};
			parameters[0].Value = m_MessageInfoID;

			DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public M_MessageInfo GetM_MessageInfoModel(int m_MessageInfoID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 m_MessageInfoID,m_ConfigInfoID,m_Type,m_ObjID,m_id,refund_id,owner_id,owner_nick,owner_role,m_content,created,message_type from tb_M_MessageInfo ");
			strSql.Append(" where m_MessageInfoID=@m_MessageInfoID ");
			SqlParameter[] parameters = {
					new SqlParameter("@m_MessageInfoID", SqlDbType.Int,4)};
			parameters[0].Value = m_MessageInfoID;

			M_MessageInfo model=new M_MessageInfo();
			DataSet ds=DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(), parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["m_MessageInfoID"].ToString()!="")
				{
					model.m_MessageInfoID=int.Parse(ds.Tables[0].Rows[0]["m_MessageInfoID"].ToString());
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
				if(ds.Tables[0].Rows[0]["refund_id"].ToString()!="")
				{
					model.refund_id=int.Parse(ds.Tables[0].Rows[0]["refund_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["owner_id"].ToString()!="")
				{
					model.owner_id=int.Parse(ds.Tables[0].Rows[0]["owner_id"].ToString());
				}
				model.owner_nick=ds.Tables[0].Rows[0]["owner_nick"].ToString();
				model.owner_role=ds.Tables[0].Rows[0]["owner_role"].ToString();
				model.m_content=ds.Tables[0].Rows[0]["m_content"].ToString();
				if(ds.Tables[0].Rows[0]["created"].ToString()!="")
				{
					model.created=DateTime.Parse(ds.Tables[0].Rows[0]["created"].ToString());
				}
				model.message_type=ds.Tables[0].Rows[0]["message_type"].ToString();
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
		public DataSet GetM_MessageInfoList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select m_MessageInfoID,m_ConfigInfoID,m_Type,m_ObjID,m_id,refund_id,owner_id,owner_nick,owner_role,m_content,created,message_type ");
			strSql.Append(" FROM tb_M_MessageInfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelper.ExecuteDataset(CommandType.Text,strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetM_MessageInfoList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" m_MessageInfoID,m_ConfigInfoID,m_Type,m_ObjID,m_id,refund_id,owner_id,owner_nick,owner_role,m_content,created,message_type ");
			strSql.Append(" FROM tb_M_MessageInfo ");
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
		public DataTable GetM_MessageInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
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
			parameters[0].Value = "tb_M_MessageInfo";
			parameters[1].Value = "M_MessageInfoID";
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

