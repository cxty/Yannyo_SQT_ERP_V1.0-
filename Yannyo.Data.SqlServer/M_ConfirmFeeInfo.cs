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
    /// 交易确认收货费用信息。
    /// </summary>
    public partial class DataProvider : IDataProvider
    {
        public bool ExistsM_ConfirmFeeInfo(int m_Type, int m_ObjID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_M_ConfirmFeeInfo");
            strSql.Append(" where m_Type=@m_Type and m_ObjID=@m_ObjID");
            SqlParameter[] parameters = {
					new SqlParameter("@m_Type", SqlDbType.Int,4),
                                        new SqlParameter("@m_ObjID", SqlDbType.Int,4)};
            parameters[0].Value = m_Type;
            parameters[1].Value = m_ObjID;

            return ((int)DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters)) > 0;
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddM_ConfirmFeeInfo(M_ConfirmFeeInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_M_ConfirmFeeInfo(");
            strSql.Append("m_Type,m_ObjID,confirm_fee,confirm_post_fee,is_last_order,mAppendTime)");
            strSql.Append(" values (");
            strSql.Append("@m_Type,@m_ObjID,@confirm_fee,@confirm_post_fee,@is_last_order,@mAppendTime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@m_Type", SqlDbType.Int,4),
					new SqlParameter("@m_ObjID", SqlDbType.Int,4),
					new SqlParameter("@confirm_fee", SqlDbType.Money,8),
					new SqlParameter("@confirm_post_fee", SqlDbType.Money,8),
					new SqlParameter("@is_last_order", SqlDbType.Bit,1),
					new SqlParameter("@mAppendTime", SqlDbType.DateTime)};
            parameters[0].Value = model.m_Type;
            parameters[1].Value = model.m_ObjID;
            parameters[2].Value = model.confirm_fee;
            parameters[3].Value = model.confirm_post_fee;
            parameters[4].Value = model.is_last_order;
            parameters[5].Value = model.mAppendTime;

            object obj = DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
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
        public void UpdateM_ConfirmFeeInfo(M_ConfirmFeeInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_M_ConfirmFeeInfo set ");
            strSql.Append("m_Type=@m_Type,");
            strSql.Append("m_ObjID=@m_ObjID,");
            strSql.Append("confirm_fee=@confirm_fee,");
            strSql.Append("confirm_post_fee=@confirm_post_fee,");
            strSql.Append("is_last_order=@is_last_order,");
            strSql.Append("mAppendTime=@mAppendTime");
            strSql.Append(" where m_ConfirmFeeInfoID=@m_ConfirmFeeInfoID ");
            SqlParameter[] parameters = {
					new SqlParameter("@m_ConfirmFeeInfoID", SqlDbType.Int,4),
					new SqlParameter("@m_Type", SqlDbType.Int,4),
					new SqlParameter("@m_ObjID", SqlDbType.Int,4),
					new SqlParameter("@confirm_fee", SqlDbType.Money,8),
					new SqlParameter("@confirm_post_fee", SqlDbType.Money,8),
					new SqlParameter("@is_last_order", SqlDbType.Bit,1),
					new SqlParameter("@mAppendTime", SqlDbType.DateTime)};
            parameters[0].Value = model.m_ConfirmFeeInfoID;
            parameters[1].Value = model.m_Type;
            parameters[2].Value = model.m_ObjID;
            parameters[3].Value = model.confirm_fee;
            parameters[4].Value = model.confirm_post_fee;
            parameters[5].Value = model.is_last_order;
            parameters[6].Value = model.mAppendTime;

            DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void DeleteM_ConfirmFeeInfo(int m_ConfirmFeeInfoID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_M_ConfirmFeeInfo ");
            strSql.Append(" where m_ConfirmFeeInfoID=@m_ConfirmFeeInfoID ");
            SqlParameter[] parameters = {
					new SqlParameter("@m_ConfirmFeeInfoID", SqlDbType.Int,4)};
            parameters[0].Value = m_ConfirmFeeInfoID;

            DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public M_ConfirmFeeInfo GetM_ConfirmFeeInfoModel(int m_ConfirmFeeInfoID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 m_ConfirmFeeInfoID,m_Type,m_ObjID,confirm_fee,confirm_post_fee,is_last_order,mAppendTime from tb_M_ConfirmFeeInfo ");
            strSql.Append(" where m_ConfirmFeeInfoID=@m_ConfirmFeeInfoID ");
            SqlParameter[] parameters = {
					new SqlParameter("@m_ConfirmFeeInfoID", SqlDbType.Int,4)};
            parameters[0].Value = m_ConfirmFeeInfoID;

            M_ConfirmFeeInfo model = new M_ConfirmFeeInfo();
            DataSet ds = DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["m_ConfirmFeeInfoID"].ToString() != "")
                {
                    model.m_ConfirmFeeInfoID = int.Parse(ds.Tables[0].Rows[0]["m_ConfirmFeeInfoID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["m_Type"].ToString() != "")
                {
                    model.m_Type = int.Parse(ds.Tables[0].Rows[0]["m_Type"].ToString());
                }
                if (ds.Tables[0].Rows[0]["m_ObjID"].ToString() != "")
                {
                    model.m_ObjID = int.Parse(ds.Tables[0].Rows[0]["m_ObjID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["confirm_fee"].ToString() != "")
                {
                    model.confirm_fee = decimal.Parse(ds.Tables[0].Rows[0]["confirm_fee"].ToString());
                }
                if (ds.Tables[0].Rows[0]["confirm_post_fee"].ToString() != "")
                {
                    model.confirm_post_fee = decimal.Parse(ds.Tables[0].Rows[0]["confirm_post_fee"].ToString());
                }
                if (ds.Tables[0].Rows[0]["is_last_order"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["is_last_order"].ToString() == "1") || (ds.Tables[0].Rows[0]["is_last_order"].ToString().ToLower() == "true"))
                    {
                        model.is_last_order = true;
                    }
                    else
                    {
                        model.is_last_order = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["mAppendTime"].ToString() != "")
                {
                    model.mAppendTime = DateTime.Parse(ds.Tables[0].Rows[0]["mAppendTime"].ToString());
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
        public DataSet GetM_ConfirmFeeInfoList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select m_ConfirmFeeInfoID,m_Type,m_ObjID,confirm_fee,confirm_post_fee,is_last_order,mAppendTime ");
            strSql.Append(" FROM tb_M_ConfirmFeeInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelper.ExecuteDataset(CommandType.Text,strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetM_ConfirmFeeInfoList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" m_ConfirmFeeInfoID,m_Type,m_ObjID,confirm_fee,confirm_post_fee,is_last_order,mAppendTime ");
            strSql.Append(" FROM tb_M_ConfirmFeeInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelper.ExecuteDataset(CommandType.Text,strSql.ToString());
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataTable GetM_ConfirmFeeInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
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
            parameters[0].Value = "tb_M_ConfirmFeeInfo";
            parameters[1].Value = "M_ConfirmFeeInfoID";
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
    }
}
