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
    public partial class DataProvider : IDataProvider
    {
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistsPaymentSystem(string pName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tbPaymentSystemInfo");
            strSql.Append(" where pName=@pName ");
            SqlParameter[] parameters = {
					new SqlParameter("@pName", SqlDbType.VarChar,50)};
            parameters[0].Value = pName;

            return ((int)DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters)) > 0;
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddPaymentSystem(PaymentSystemInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tbPaymentSystemInfo(");
            strSql.Append("pName,pAppendTime)");
            strSql.Append(" values (");
            strSql.Append("@pName,@pAppendTime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@pName", SqlDbType.VarChar,50),
					new SqlParameter("@pAppendTime", SqlDbType.DateTime)};
            parameters[0].Value = model.pName;
            parameters[1].Value = model.pAppendTime;

            object obj = DbHelper.ExecuteScalar(CommandType.Text,strSql.ToString(), parameters);
            if (obj == null)
            {
                return 1;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void UpdatePaymentSystem(PaymentSystemInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbPaymentSystemInfo set ");
            strSql.Append("pName=@pName,");
            strSql.Append("pAppendTime=@pAppendTime");
            strSql.Append(" where PaymentSystemID=@PaymentSystemID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PaymentSystemID", SqlDbType.Int,4),
					new SqlParameter("@pName", SqlDbType.VarChar,50),
					new SqlParameter("@pAppendTime", SqlDbType.DateTime)};
            parameters[0].Value = model.PaymentSystemID;
            parameters[1].Value = model.pName;
            parameters[2].Value = model.pAppendTime;

            DbHelper.ExecuteNonQuery(CommandType.Text,strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void DeletePaymentSystem(int PaymentSystemID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbPaymentSystemInfo ");
            strSql.Append(" where PaymentSystemID=@PaymentSystemID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PaymentSystemID", SqlDbType.Int,4)};
            parameters[0].Value = PaymentSystemID;

            DbHelper.ExecuteNonQuery(CommandType.Text,strSql.ToString(), parameters);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void DeletePaymentSystem(string PaymentSystemID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbPaymentSystemInfo ");
            strSql.Append(" where PaymentSystemID in(" + PaymentSystemID + ") ");

            DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString());
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public PaymentSystemInfo GetPaymentSystemModel(int PaymentSystemID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 PaymentSystemID,pName,pAppendTime from tbPaymentSystemInfo ");
            strSql.Append(" where PaymentSystemID=@PaymentSystemID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PaymentSystemID", SqlDbType.Int,4)};
            parameters[0].Value = PaymentSystemID;

            PaymentSystemInfo model = new PaymentSystemInfo();
            DataSet ds = DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["PaymentSystemID"].ToString() != "")
                {
                    model.PaymentSystemID = int.Parse(ds.Tables[0].Rows[0]["PaymentSystemID"].ToString());
                }
                model.pName = ds.Tables[0].Rows[0]["pName"].ToString();
                if (ds.Tables[0].Rows[0]["pAppendTime"].ToString() != "")
                {
                    model.pAppendTime = DateTime.Parse(ds.Tables[0].Rows[0]["pAppendTime"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }
        public PaymentSystemInfo GetPaymentSystemModel(string PaymentSystemName)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 PaymentSystemID,pName,pAppendTime from tbPaymentSystemInfo ");
            strSql.Append(" where pName=@PaymentSystemName ");
            SqlParameter[] parameters = {
					new SqlParameter("@PaymentSystemName", SqlDbType.VarChar,50)};
            parameters[0].Value = PaymentSystemName;

            PaymentSystemInfo model = new PaymentSystemInfo();
            DataSet ds = DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["PaymentSystemID"].ToString() != "")
                {
                    model.PaymentSystemID = int.Parse(ds.Tables[0].Rows[0]["PaymentSystemID"].ToString());
                }
                model.pName = ds.Tables[0].Rows[0]["pName"].ToString();
                if (ds.Tables[0].Rows[0]["pAppendTime"].ToString() != "")
                {
                    model.pAppendTime = DateTime.Parse(ds.Tables[0].Rows[0]["pAppendTime"].ToString());
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
        public DataSet GetPaymentSystemList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select PaymentSystemID,pName,pAppendTime ");
            strSql.Append(" FROM tbPaymentSystemInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelper.ExecuteDataset(CommandType.Text,strSql.ToString());
        }

        
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataTable GetPaymentSystemList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
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
            parameters[0].Value = "tbPaymentSystemInfo";
            parameters[1].Value = "PaymentSystemID";
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
