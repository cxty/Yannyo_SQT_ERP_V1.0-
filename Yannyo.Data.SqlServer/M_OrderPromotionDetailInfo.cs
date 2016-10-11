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
	/// 数据访问类M_OrderPromotionDetailInfo。
	/// </summary>
	public partial class DataProvider : IDataProvider
    {
        #region  订单优惠信息

        /// <summary>
		/// 是否存在该记录
		/// </summary>
        public bool ExistsM_OrderPromotionDetailInfo(int m_Type, int m_ObjID, int m_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_M_OrderPromotionDetailInfo");
            strSql.Append(" where m_Type=@m_Type and m_ObjID=@m_ObjID and m_id=@m_id");
			SqlParameter[] parameters = {
					new SqlParameter("@m_Type", SqlDbType.Int,4),
                                        new SqlParameter("@m_ObjID", SqlDbType.Int,4),
                                        new SqlParameter("@m_id", SqlDbType.BigInt)};
            parameters[0].Value = m_Type;
            parameters[1].Value = m_Type;
            parameters[2].Value = m_Type;

			return ((int)DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters)) > 0;
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int AddM_OrderPromotionDetailInfo(M_OrderPromotionDetailInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_M_OrderPromotionDetailInfo(");
			strSql.Append("m_Type,m_ObjID,m_id,promotion_name,discount_fee,gift_item_name)");
			strSql.Append(" values (");
			strSql.Append("@m_Type,@m_ObjID,@m_id,@promotion_name,@discount_fee,@gift_item_name)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@m_Type", SqlDbType.Int,4),
					new SqlParameter("@m_ObjID", SqlDbType.Int,4),
					new SqlParameter("@m_id", SqlDbType.Int,4),
					new SqlParameter("@promotion_name", SqlDbType.VarChar,50),
					new SqlParameter("@discount_fee", SqlDbType.Money,8),
					new SqlParameter("@gift_item_name", SqlDbType.VarChar,50)};
			parameters[0].Value = model.m_Type;
			parameters[1].Value = model.m_ObjID;
			parameters[2].Value = model.m_id;
			parameters[3].Value = model.promotion_name;
			parameters[4].Value = model.discount_fee;
			parameters[5].Value = model.gift_item_name;

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
		public void UpdateM_OrderPromotionDetailInfo(M_OrderPromotionDetailInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_M_OrderPromotionDetailInfo set ");
			strSql.Append("m_Type=@m_Type,");
			strSql.Append("m_ObjID=@m_ObjID,");
			strSql.Append("m_id=@m_id,");
			strSql.Append("promotion_name=@promotion_name,");
			strSql.Append("discount_fee=@discount_fee,");
			strSql.Append("gift_item_name=@gift_item_name");
			strSql.Append(" where m_Order_PromotionDetailInfoID=@m_Order_PromotionDetailInfoID ");
			SqlParameter[] parameters = {
					new SqlParameter("@m_Order_PromotionDetailInfoID", SqlDbType.Int,4),
					new SqlParameter("@m_Type", SqlDbType.Int,4),
					new SqlParameter("@m_ObjID", SqlDbType.Int,4),
					new SqlParameter("@m_id", SqlDbType.Int,4),
					new SqlParameter("@promotion_name", SqlDbType.VarChar,50),
					new SqlParameter("@discount_fee", SqlDbType.Money,8),
					new SqlParameter("@gift_item_name", SqlDbType.VarChar,50)};
			parameters[0].Value = model.m_Order_PromotionDetailInfoID;
			parameters[1].Value = model.m_Type;
			parameters[2].Value = model.m_ObjID;
			parameters[3].Value = model.m_id;
			parameters[4].Value = model.promotion_name;
			parameters[5].Value = model.discount_fee;
			parameters[6].Value = model.gift_item_name;

			DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void DeleteM_OrderPromotionDetailInfo(int m_Order_PromotionDetailInfoID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_M_OrderPromotionDetailInfo ");
			strSql.Append(" where m_Order_PromotionDetailInfoID=@m_Order_PromotionDetailInfoID ");
			SqlParameter[] parameters = {
					new SqlParameter("@m_Order_PromotionDetailInfoID", SqlDbType.Int,4)};
			parameters[0].Value = m_Order_PromotionDetailInfoID;

			DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public M_OrderPromotionDetailInfo GetM_OrderPromotionDetailInfoModel(int m_Order_PromotionDetailInfoID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 m_Order_PromotionDetailInfoID,m_Type,m_ObjID,m_id,promotion_name,discount_fee,gift_item_name from tb_M_OrderPromotionDetailInfo ");
			strSql.Append(" where m_Order_PromotionDetailInfoID=@m_Order_PromotionDetailInfoID ");
			SqlParameter[] parameters = {
					new SqlParameter("@m_Order_PromotionDetailInfoID", SqlDbType.Int,4)};
			parameters[0].Value = m_Order_PromotionDetailInfoID;

			M_OrderPromotionDetailInfo model=new M_OrderPromotionDetailInfo();
			DataSet ds=DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(), parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["m_Order_PromotionDetailInfoID"].ToString()!="")
				{
					model.m_Order_PromotionDetailInfoID=int.Parse(ds.Tables[0].Rows[0]["m_Order_PromotionDetailInfoID"].ToString());
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
				model.promotion_name=ds.Tables[0].Rows[0]["promotion_name"].ToString();
				if(ds.Tables[0].Rows[0]["discount_fee"].ToString()!="")
				{
					model.discount_fee=decimal.Parse(ds.Tables[0].Rows[0]["discount_fee"].ToString());
				}
				model.gift_item_name=ds.Tables[0].Rows[0]["gift_item_name"].ToString();
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
		public DataSet GetM_OrderPromotionDetailInfoList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select m_Order_PromotionDetailInfoID,m_Type,m_ObjID,m_id,promotion_name,discount_fee,gift_item_name ");
			strSql.Append(" FROM tb_M_OrderPromotionDetailInfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelper.ExecuteDataset(CommandType.Text,strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetM_OrderPromotionDetailInfoList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" m_Order_PromotionDetailInfoID,m_Type,m_ObjID,m_id,promotion_name,discount_fee,gift_item_name ");
			strSql.Append(" FROM tb_M_OrderPromotionDetailInfo ");
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
		public DataTable GetM_OrderPromotionDetailInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
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
			parameters[0].Value = "tb_M_OrderPromotionDetailInfo";
			parameters[1].Value = "M_OrderPromotionDetailInfoID";
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

