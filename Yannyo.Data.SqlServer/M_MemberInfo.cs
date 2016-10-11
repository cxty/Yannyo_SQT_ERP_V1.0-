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
    /// 数据访问类M_MemberInfo。
    /// </summary>
    public partial class DataProvider : IDataProvider
    {
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistsM_Member(int m_ConfigInfoID, string buyer_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_M_MemberInfo");
            strSql.Append(" where m_ConfigInfoID=@m_ConfigInfoID and buyer_id=@buyer_id");
            SqlParameter[] parameters = {
                    new SqlParameter("@m_ConfigInfoID", SqlDbType.Int,4),
					new SqlParameter("@buyer_id", SqlDbType.VarChar,50),
            };
            parameters[0].Value = m_ConfigInfoID;
            parameters[1].Value = buyer_id;

            return ((int)DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters)) > 0;
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddM_Member(M_MemberInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_M_MemberInfo(");
            strSql.Append("m_ConfigInfoID,buyer_id,buyer_nick,member_grade,trade_amount,trade_count,laste_time,status)");
            strSql.Append(" values (");
            strSql.Append("@m_ConfigInfoID,@buyer_id,@buyer_nick,@member_grade,@trade_amount,@trade_count,@laste_time,@status)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@m_ConfigInfoID", SqlDbType.Int,4),
					new SqlParameter("@buyer_id", SqlDbType.VarChar,50),
					new SqlParameter("@buyer_nick", SqlDbType.VarChar,50),
					new SqlParameter("@member_grade", SqlDbType.VarChar,50),
					new SqlParameter("@trade_amount", SqlDbType.Decimal,9),
					new SqlParameter("@trade_count", SqlDbType.Decimal,9),
					new SqlParameter("@laste_time", SqlDbType.DateTime),
					new SqlParameter("@status", SqlDbType.VarChar,50)};
            parameters[0].Value = model.m_ConfigInfoID;
            parameters[1].Value = model.buyer_id;
            parameters[2].Value = model.buyer_nick;
            parameters[3].Value = model.member_grade;
            parameters[4].Value = model.trade_amount;
            parameters[5].Value = model.trade_count;
            parameters[6].Value = model.laste_time;
            parameters[7].Value = model.status;

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
        public bool UpdateM_Member(M_MemberInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_M_MemberInfo set ");
            strSql.Append("m_ConfigInfoID=@m_ConfigInfoID,");
            strSql.Append("buyer_id=@buyer_id,");
            strSql.Append("buyer_nick=@buyer_nick,");
            strSql.Append("member_grade=@member_grade,");
            strSql.Append("trade_amount=@trade_amount,");
            strSql.Append("trade_count=@trade_count,");
            strSql.Append("laste_time=@laste_time,");
            strSql.Append("status=@status");
            strSql.Append(" where m_MemberInfoID=@m_MemberInfoID");
            SqlParameter[] parameters = {
					new SqlParameter("@m_ConfigInfoID", SqlDbType.Int,4),
					new SqlParameter("@buyer_id", SqlDbType.VarChar,50),
					new SqlParameter("@buyer_nick", SqlDbType.VarChar,50),
					new SqlParameter("@member_grade", SqlDbType.VarChar,50),
					new SqlParameter("@trade_amount", SqlDbType.Decimal,9),
					new SqlParameter("@trade_count", SqlDbType.Decimal,9),
					new SqlParameter("@laste_time", SqlDbType.DateTime),
					new SqlParameter("@status", SqlDbType.VarChar,50),
					new SqlParameter("@m_MemberInfoID", SqlDbType.Int,4)};
            parameters[0].Value = model.m_ConfigInfoID;
            parameters[1].Value = model.buyer_id;
            parameters[2].Value = model.buyer_nick;
            parameters[3].Value = model.member_grade;
            parameters[4].Value = model.trade_amount;
            parameters[5].Value = model.trade_count;
            parameters[6].Value = model.laste_time;
            parameters[7].Value = model.status;
            parameters[8].Value = model.m_MemberInfoID;

            int rows = DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteM_Member(int m_MemberInfoID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_M_MemberInfo ");
            strSql.Append(" where m_MemberInfoID=@m_MemberInfoID");
            SqlParameter[] parameters = {
					new SqlParameter("@m_MemberInfoID", SqlDbType.Int,4)
};
            parameters[0].Value = m_MemberInfoID;

            int rows = DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteM_MemberList(string m_MemberInfoIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_M_MemberInfo ");
            strSql.Append(" where m_MemberInfoID in (" + m_MemberInfoIDlist + ")  ");
            int rows = DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public M_MemberInfo GetM_MemberModel(int m_MemberInfoID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 m_MemberInfoID,m_ConfigInfoID,buyer_id,buyer_nick,member_grade,trade_amount,trade_count,laste_time,status from tb_M_MemberInfo ");
            strSql.Append(" where m_MemberInfoID=@m_MemberInfoID");
            SqlParameter[] parameters = {
					new SqlParameter("@m_MemberInfoID", SqlDbType.Int,4)
            };
            parameters[0].Value = m_MemberInfoID;

            M_MemberInfo model = new M_MemberInfo();
            DataSet ds = DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["m_MemberInfoID"].ToString() != "")
                {
                    model.m_MemberInfoID = int.Parse(ds.Tables[0].Rows[0]["m_MemberInfoID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["m_ConfigInfoID"].ToString() != "")
                {
                    model.m_ConfigInfoID = int.Parse(ds.Tables[0].Rows[0]["m_ConfigInfoID"].ToString());
                }
                model.buyer_id = ds.Tables[0].Rows[0]["buyer_id"].ToString();
                model.buyer_nick = ds.Tables[0].Rows[0]["buyer_nick"].ToString();
                model.member_grade = ds.Tables[0].Rows[0]["member_grade"].ToString();
                if (ds.Tables[0].Rows[0]["trade_amount"].ToString() != "")
                {
                    model.trade_amount = decimal.Parse(ds.Tables[0].Rows[0]["trade_amount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["trade_count"].ToString() != "")
                {
                    model.trade_count = decimal.Parse(ds.Tables[0].Rows[0]["trade_count"].ToString());
                }
                if (ds.Tables[0].Rows[0]["laste_time"].ToString() != "")
                {
                    model.laste_time = DateTime.Parse(ds.Tables[0].Rows[0]["laste_time"].ToString());
                }
                model.status = ds.Tables[0].Rows[0]["status"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }
        public M_MemberInfo GetM_MemberModel(int m_ConfigInfoID, string buyer_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 m_MemberInfoID,m_ConfigInfoID,buyer_id,buyer_nick,member_grade,trade_amount,trade_count,laste_time,status from tb_M_MemberInfo ");
            strSql.Append(" where m_ConfigInfoID=@m_ConfigInfoID and buyer_id=@buyer_id");
            SqlParameter[] parameters = {
					new SqlParameter("@m_ConfigInfoID", SqlDbType.Int,4),
                    new SqlParameter("@buyer_id", SqlDbType.VarChar,50)
            };
            parameters[0].Value = m_ConfigInfoID;
            parameters[1].Value = buyer_id;

            M_MemberInfo model = new M_MemberInfo();
            DataSet ds = DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["m_MemberInfoID"].ToString() != "")
                {
                    model.m_MemberInfoID = int.Parse(ds.Tables[0].Rows[0]["m_MemberInfoID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["m_ConfigInfoID"].ToString() != "")
                {
                    model.m_ConfigInfoID = int.Parse(ds.Tables[0].Rows[0]["m_ConfigInfoID"].ToString());
                }
                model.buyer_id = ds.Tables[0].Rows[0]["buyer_id"].ToString();
                model.buyer_nick = ds.Tables[0].Rows[0]["buyer_nick"].ToString();
                model.member_grade = ds.Tables[0].Rows[0]["member_grade"].ToString();
                if (ds.Tables[0].Rows[0]["trade_amount"].ToString() != "")
                {
                    model.trade_amount = decimal.Parse(ds.Tables[0].Rows[0]["trade_amount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["trade_count"].ToString() != "")
                {
                    model.trade_count = decimal.Parse(ds.Tables[0].Rows[0]["trade_count"].ToString());
                }
                if (ds.Tables[0].Rows[0]["laste_time"].ToString() != "")
                {
                    model.laste_time = DateTime.Parse(ds.Tables[0].Rows[0]["laste_time"].ToString());
                }
                model.status = ds.Tables[0].Rows[0]["status"].ToString();
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
        public DataSet GetM_MemberList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select m_MemberInfoID,m_ConfigInfoID,buyer_id,buyer_nick,member_grade,trade_amount,trade_count,laste_time,status ");
            strSql.Append(" FROM tb_M_MemberInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelper.ExecuteDataset(CommandType.Text,strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetM_MemberList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" m_MemberInfoID,m_ConfigInfoID,buyer_id,buyer_nick,member_grade,trade_amount,trade_count,laste_time,status ");
            strSql.Append(" FROM tb_M_MemberInfo ");
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
        public DataTable GetM_MemberList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
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
            parameters[0].Value = "tb_M_MemberInfo";
            parameters[1].Value = "m_MemberInfoID";
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
