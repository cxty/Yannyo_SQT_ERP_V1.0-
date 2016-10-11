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
	/// 数据访问类M_LocationInfo。
	/// </summary>
	public partial class DataProvider : IDataProvider
    {
        #region  地址信息

        /// <summary>
		/// 是否存在该记录
		/// </summary>
        public bool ExistsM_LocationInfo(int m_ConfigInfoID, int m_Type, int m_ObjID, string address)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_M_LocationInfo");
            strSql.Append(" where m_ConfigInfoID=@m_ConfigInfoID and m_Type=@m_Type and m_ObjID=@m_ObjID and address=@address");
			SqlParameter[] parameters = {
					new SqlParameter("@m_ConfigInfoID", SqlDbType.Int,4),
                                        new SqlParameter("@m_Type", SqlDbType.Int,4),
                                        new SqlParameter("@m_ObjID", SqlDbType.Int,4),
                                        new SqlParameter("@address", SqlDbType.VarChar,512)};
            parameters[0].Value = m_ConfigInfoID;
            parameters[1].Value = m_Type;
            parameters[2].Value = m_ObjID;
            parameters[3].Value = address;

			return ((int)DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters)) > 0;
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int AddM_LocationInfo(M_LocationInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_M_LocationInfo(");
			strSql.Append("m_ConfigInfoID,m_Type,m_ObjID,zip,address,city,state,country,district,m_AppendTime)");
			strSql.Append(" values (");
			strSql.Append("@m_ConfigInfoID,@m_Type,@m_ObjID,@zip,@address,@city,@state,@country,@district,@m_AppendTime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@m_ConfigInfoID", SqlDbType.Int,4),
					new SqlParameter("@m_Type", SqlDbType.Int,4),
					new SqlParameter("@m_ObjID", SqlDbType.Int,4),
					new SqlParameter("@zip", SqlDbType.VarChar,50),
					new SqlParameter("@address", SqlDbType.VarChar,512),
					new SqlParameter("@city", SqlDbType.VarChar,50),
					new SqlParameter("@state", SqlDbType.VarChar,50),
					new SqlParameter("@country", SqlDbType.VarChar,50),
					new SqlParameter("@district", SqlDbType.VarChar,128),
					new SqlParameter("@m_AppendTime", SqlDbType.DateTime)};
			parameters[0].Value = model.m_ConfigInfoID;
			parameters[1].Value = model.m_Type;
			parameters[2].Value = model.m_ObjID;
			parameters[3].Value = model.zip;
			parameters[4].Value = model.address;
			parameters[5].Value = model.city;
			parameters[6].Value = model.state;
			parameters[7].Value = model.country;
			parameters[8].Value = model.district;
			parameters[9].Value = model.m_AppendTime;

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
		public void UpdateM_LocationInfo(M_LocationInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_M_LocationInfo set ");
			strSql.Append("m_ConfigInfoID=@m_ConfigInfoID,");
			strSql.Append("m_Type=@m_Type,");
			strSql.Append("m_ObjID=@m_ObjID,");
			strSql.Append("zip=@zip,");
			strSql.Append("address=@address,");
			strSql.Append("city=@city,");
			strSql.Append("state=@state,");
			strSql.Append("country=@country,");
			strSql.Append("district=@district,");
			strSql.Append("m_AppendTime=@m_AppendTime");
			strSql.Append(" where m_LocationID=@m_LocationID ");
			SqlParameter[] parameters = {
					new SqlParameter("@m_LocationID", SqlDbType.Int,4),
					new SqlParameter("@m_ConfigInfoID", SqlDbType.Int,4),
					new SqlParameter("@m_Type", SqlDbType.Int,4),
					new SqlParameter("@m_ObjID", SqlDbType.Int,4),
					new SqlParameter("@zip", SqlDbType.VarChar,50),
					new SqlParameter("@address", SqlDbType.VarChar,512),
					new SqlParameter("@city", SqlDbType.VarChar,50),
					new SqlParameter("@state", SqlDbType.VarChar,50),
					new SqlParameter("@country", SqlDbType.VarChar,50),
					new SqlParameter("@district", SqlDbType.VarChar,128),
					new SqlParameter("@m_AppendTime", SqlDbType.DateTime)};
			parameters[0].Value = model.m_LocationID;
			parameters[1].Value = model.m_ConfigInfoID;
			parameters[2].Value = model.m_Type;
			parameters[3].Value = model.m_ObjID;
			parameters[4].Value = model.zip;
			parameters[5].Value = model.address;
			parameters[6].Value = model.city;
			parameters[7].Value = model.state;
			parameters[8].Value = model.country;
			parameters[9].Value = model.district;
			parameters[10].Value = model.m_AppendTime;

			DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void DeleteM_LocationInfo(int m_LocationID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_M_LocationInfo ");
			strSql.Append(" where m_LocationID=@m_LocationID ");
			SqlParameter[] parameters = {
					new SqlParameter("@m_LocationID", SqlDbType.Int,4)};
			parameters[0].Value = m_LocationID;

			DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public M_LocationInfo GetM_LocationInfoModel(int m_LocationID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 m_LocationID,m_ConfigInfoID,m_Type,m_ObjID,zip,address,city,state,country,district,m_AppendTime from tb_M_LocationInfo ");
			strSql.Append(" where m_LocationID=@m_LocationID ");
			SqlParameter[] parameters = {
					new SqlParameter("@m_LocationID", SqlDbType.Int,4)};
			parameters[0].Value = m_LocationID;

			M_LocationInfo model=new M_LocationInfo();
			DataSet ds=DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(), parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["m_LocationID"].ToString()!="")
				{
					model.m_LocationID=int.Parse(ds.Tables[0].Rows[0]["m_LocationID"].ToString());
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
				model.zip=ds.Tables[0].Rows[0]["zip"].ToString();
				model.address=ds.Tables[0].Rows[0]["address"].ToString();
				model.city=ds.Tables[0].Rows[0]["city"].ToString();
				model.state=ds.Tables[0].Rows[0]["state"].ToString();
				model.country=ds.Tables[0].Rows[0]["country"].ToString();
				model.district=ds.Tables[0].Rows[0]["district"].ToString();
				if(ds.Tables[0].Rows[0]["m_AppendTime"].ToString()!="")
				{
					model.m_AppendTime=DateTime.Parse(ds.Tables[0].Rows[0]["m_AppendTime"].ToString());
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
		public DataSet GetM_LocationInfoList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select m_LocationID,m_ConfigInfoID,m_Type,m_ObjID,zip,address,city,state,country,district,m_AppendTime ");
			strSql.Append(" FROM tb_M_LocationInfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelper.ExecuteDataset(CommandType.Text,strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetM_LocationInfoList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" m_LocationID,m_ConfigInfoID,m_Type,m_ObjID,zip,address,city,state,country,district,m_AppendTime ");
			strSql.Append(" FROM tb_M_LocationInfo ");
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
		public DataTable GetM_LocationInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
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
			parameters[0].Value = "tb_M_LocationInfo";
			parameters[1].Value = "M_LocationInfoID";
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

