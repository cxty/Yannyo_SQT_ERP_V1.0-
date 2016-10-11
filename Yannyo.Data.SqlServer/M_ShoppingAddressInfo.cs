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
	/// 数据访问类M_ShoppingAddressInfo。
	/// </summary>
	public partial class DataProvider : IDataProvider
    {
        #region  交易地址信息

        /// <summary>
		/// 是否存在该记录
		/// </summary>
        public bool ExistsM_ShoppingAddressInfo(int m_ConfigInfoID, int m_Type, int m_ObjID, int address_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_M_ShoppingAddressInfo");
            strSql.Append(" where m_ConfigInfoID=@m_ConfigInfoID and m_Type=@m_Type and m_ObjID=@m_ObjID  and address_id=@address_id");
			SqlParameter[] parameters = {
					new SqlParameter("@m_ConfigInfoID", SqlDbType.Int,4),
                                        new SqlParameter("@m_Type", SqlDbType.Int,4),
                                        new SqlParameter("@m_ObjID", SqlDbType.Int,4),
                                        new SqlParameter("@address_id", SqlDbType.Int,4)};
            parameters[0].Value = m_ConfigInfoID;
            parameters[1].Value = m_Type;
            parameters[2].Value = m_ObjID;
            parameters[3].Value = address_id;

			return ((int)DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters)) > 0;
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int AddM_ShoppingAddressInfo(M_ShoppingAddressInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_M_ShoppingAddressInfo(");
			strSql.Append("m_ConfigInfoID,m_Type,m_ObjID,address_id,receiver_name,phone,mobile,is_default,created)");
			strSql.Append(" values (");
			strSql.Append("@m_ConfigInfoID,@m_Type,@m_ObjID,@address_id,@receiver_name,@phone,@mobile,@is_default,@created)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@m_ConfigInfoID", SqlDbType.Int,4),
					new SqlParameter("@m_Type", SqlDbType.Int,4),
					new SqlParameter("@m_ObjID", SqlDbType.Int,4),
					new SqlParameter("@address_id", SqlDbType.Int,4),
					new SqlParameter("@receiver_name", SqlDbType.VarChar,50),
					new SqlParameter("@phone", SqlDbType.VarChar,50),
					new SqlParameter("@mobile", SqlDbType.VarChar,50),
					new SqlParameter("@is_default", SqlDbType.Bit,1),
					new SqlParameter("@created", SqlDbType.DateTime)};
			parameters[0].Value = model.m_ConfigInfoID;
			parameters[1].Value = model.m_Type;
			parameters[2].Value = model.m_ObjID;
			parameters[3].Value = model.address_id;
			parameters[4].Value = model.receiver_name;
			parameters[5].Value = model.phone;
			parameters[6].Value = model.mobile;
			parameters[7].Value = model.is_default;
			parameters[8].Value = model.created;

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
		public void UpdateM_ShoppingAddressInfo(M_ShoppingAddressInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_M_ShoppingAddressInfo set ");
			strSql.Append("m_ConfigInfoID=@m_ConfigInfoID,");
			strSql.Append("m_Type=@m_Type,");
			strSql.Append("m_ObjID=@m_ObjID,");
			strSql.Append("address_id=@address_id,");
			strSql.Append("receiver_name=@receiver_name,");
			strSql.Append("phone=@phone,");
			strSql.Append("mobile=@mobile,");
			strSql.Append("is_default=@is_default,");
			strSql.Append("created=@created");
			strSql.Append(" where m_ShoppingAddressInfoID=@m_ShoppingAddressInfoID ");
			SqlParameter[] parameters = {
					new SqlParameter("@m_ShoppingAddressInfoID", SqlDbType.Int,4),
					new SqlParameter("@m_ConfigInfoID", SqlDbType.Int,4),
					new SqlParameter("@m_Type", SqlDbType.Int,4),
					new SqlParameter("@m_ObjID", SqlDbType.Int,4),
					new SqlParameter("@address_id", SqlDbType.Int,4),
					new SqlParameter("@receiver_name", SqlDbType.VarChar,50),
					new SqlParameter("@phone", SqlDbType.VarChar,50),
					new SqlParameter("@mobile", SqlDbType.VarChar,50),
					new SqlParameter("@is_default", SqlDbType.Bit,1),
					new SqlParameter("@created", SqlDbType.DateTime)};
			parameters[0].Value = model.m_ShoppingAddressInfoID;
			parameters[1].Value = model.m_ConfigInfoID;
			parameters[2].Value = model.m_Type;
			parameters[3].Value = model.m_ObjID;
			parameters[4].Value = model.address_id;
			parameters[5].Value = model.receiver_name;
			parameters[6].Value = model.phone;
			parameters[7].Value = model.mobile;
			parameters[8].Value = model.is_default;
			parameters[9].Value = model.created;

			DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void DeleteM_ShoppingAddressInfo(int m_ShoppingAddressInfoID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_M_ShoppingAddressInfo ");
			strSql.Append(" where m_ShoppingAddressInfoID=@m_ShoppingAddressInfoID ");
			SqlParameter[] parameters = {
					new SqlParameter("@m_ShoppingAddressInfoID", SqlDbType.Int,4)};
			parameters[0].Value = m_ShoppingAddressInfoID;

			DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public M_ShoppingAddressInfo GetM_ShoppingAddressInfoModel(int m_ShoppingAddressInfoID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 m_ShoppingAddressInfoID,m_ConfigInfoID,m_Type,m_ObjID,address_id,receiver_name,phone,mobile,is_default,created from tb_M_ShoppingAddressInfo ");
			strSql.Append(" where m_ShoppingAddressInfoID=@m_ShoppingAddressInfoID ");
			SqlParameter[] parameters = {
					new SqlParameter("@m_ShoppingAddressInfoID", SqlDbType.Int,4)};
			parameters[0].Value = m_ShoppingAddressInfoID;

			M_ShoppingAddressInfo model=new M_ShoppingAddressInfo();
			DataSet ds=DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(), parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["m_ShoppingAddressInfoID"].ToString()!="")
				{
					model.m_ShoppingAddressInfoID=int.Parse(ds.Tables[0].Rows[0]["m_ShoppingAddressInfoID"].ToString());
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
				if(ds.Tables[0].Rows[0]["address_id"].ToString()!="")
				{
					model.address_id=int.Parse(ds.Tables[0].Rows[0]["address_id"].ToString());
				}
				model.receiver_name=ds.Tables[0].Rows[0]["receiver_name"].ToString();
				model.phone=ds.Tables[0].Rows[0]["phone"].ToString();
				model.mobile=ds.Tables[0].Rows[0]["mobile"].ToString();
				if(ds.Tables[0].Rows[0]["is_default"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["is_default"].ToString()=="1")||(ds.Tables[0].Rows[0]["is_default"].ToString().ToLower()=="true"))
					{
						model.is_default=true;
					}
					else
					{
						model.is_default=false;
					}
				}
				if(ds.Tables[0].Rows[0]["created"].ToString()!="")
				{
					model.created=DateTime.Parse(ds.Tables[0].Rows[0]["created"].ToString());
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
		public DataSet GetM_ShoppingAddressInfoList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select m_ShoppingAddressInfoID,m_ConfigInfoID,m_Type,m_ObjID,address_id,receiver_name,phone,mobile,is_default,created ");
			strSql.Append(" FROM tb_M_ShoppingAddressInfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelper.ExecuteDataset(CommandType.Text,strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetM_ShoppingAddressInfoList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" m_ShoppingAddressInfoID,m_ConfigInfoID,m_Type,m_ObjID,address_id,receiver_name,phone,mobile,is_default,created ");
			strSql.Append(" FROM tb_M_ShoppingAddressInfo ");
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
		public DataTable GetM_ShoppingAddressInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
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
			parameters[0].Value = "tb_M_ShoppingAddressInfo";
			parameters[1].Value = "M_ShoppingAddressInfoID";
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

