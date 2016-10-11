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
        public bool ExistsBankMoney(int BankMoneyID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tbBankMoneyInfo");
            strSql.Append(" where BankMoneyID=@BankMoneyID ");
            SqlParameter[] parameters = {
					new SqlParameter("@BankMoneyID", SqlDbType.Int,4)};
            parameters[0].Value = BankMoneyID;

            return ((int)DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters)) > 0;
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddBankMoney(BankMoneyInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tbBankMoneyInfo(");
            strSql.Append("BankID,bMoney,bUpdateTime,bAppendTime,isBegin)");
            strSql.Append(" values (");
            strSql.Append("@BankID,@bMoney,@bUpdateTime,@bAppendTime,@isBegin)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@BankID", SqlDbType.Int,4),
					new SqlParameter("@bMoney", SqlDbType.Money,8),
					new SqlParameter("@bUpdateTime", SqlDbType.DateTime),
					new SqlParameter("@bAppendTime", SqlDbType.DateTime),
                                        new SqlParameter("@isBegin", SqlDbType.Int,4),};
            parameters[0].Value = model.BankID;
            parameters[1].Value = model.bMoney;
            parameters[2].Value = model.bUpdateTime;
            parameters[3].Value = model.bAppendTime;
            parameters[4].Value = model.isBegin;

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
        public void UpdateBankMoney(BankMoneyInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbBankMoneyInfo set ");
            strSql.Append("BankID=@BankID,");
            strSql.Append("bMoney=@bMoney,");
            strSql.Append("bUpdateTime=@bUpdateTime,");
            strSql.Append("bAppendTime=@bAppendTime,");
            strSql.Append("isBegin=@isBegin");
            strSql.Append(" where BankMoneyID=@BankMoneyID ");
            SqlParameter[] parameters = {
					new SqlParameter("@BankMoneyID", SqlDbType.Int,4),
					new SqlParameter("@BankID", SqlDbType.Int,4),
					new SqlParameter("@bMoney", SqlDbType.Money,8),
					new SqlParameter("@bUpdateTime", SqlDbType.DateTime),
					new SqlParameter("@bAppendTime", SqlDbType.DateTime),
                                        new SqlParameter("@isBegin", SqlDbType.Int,4),};
            parameters[0].Value = model.BankMoneyID;
            parameters[1].Value = model.BankID;
            parameters[2].Value = model.bMoney;
            parameters[3].Value = model.bUpdateTime;
            parameters[4].Value = model.bAppendTime;
            parameters[5].Value = model.isBegin;

            DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void DeleteBankMoney(int BankMoneyID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbBankMoneyInfo ");
            strSql.Append(" where BankMoneyID=@BankMoneyID ");
            SqlParameter[] parameters = {
					new SqlParameter("@BankMoneyID", SqlDbType.Int,4)};
            parameters[0].Value = BankMoneyID;

            DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void DeleteBankMoney(string BankMoneyID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbBankMoneyInfo ");
            strSql.Append(" where BankMoneyID in(" + BankMoneyID + ") ");

            DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString());
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void DeleteBankMoneyForDate(DateTime sDate)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbBankMoneyInfo ");
            strSql.Append(" where bUpdateTime = @sDate");
            SqlParameter[] parameters = {
					new SqlParameter("@sDate", SqlDbType.DateTime,8)};
            parameters[0].Value = sDate;

            DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void DeleteBankMoneyForDate(string sDate)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbBankMoneyInfo ");
            strSql.Append(" where bUpdateTime in(" + sDate + ")");

            DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString());
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public BankMoneyInfo GetBankMoneyModel(int BankMoneyID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 BankMoneyID,BankID,bMoney,bUpdateTime,bAppendTime,isBegin from tbBankMoneyInfo ");
            strSql.Append(" where BankMoneyID=@BankMoneyID ");
            SqlParameter[] parameters = {
					new SqlParameter("@BankMoneyID", SqlDbType.Int,4)};
            parameters[0].Value = BankMoneyID;

            BankMoneyInfo model = new BankMoneyInfo();
            DataSet ds = DbHelper.ExecuteDataset(CommandType.Text,strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["BankMoneyID"].ToString() != "")
                {
                    model.BankMoneyID = int.Parse(ds.Tables[0].Rows[0]["BankMoneyID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["BankID"].ToString() != "")
                {
                    model.BankID = int.Parse(ds.Tables[0].Rows[0]["BankID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["bMoney"].ToString() != "")
                {
                    model.bMoney = decimal.Parse(ds.Tables[0].Rows[0]["bMoney"].ToString());
                }
                if (ds.Tables[0].Rows[0]["bUpdateTime"].ToString() != "")
                {
                    model.bUpdateTime = DateTime.Parse(ds.Tables[0].Rows[0]["bUpdateTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["bAppendTime"].ToString() != "")
                {
                    model.bAppendTime = DateTime.Parse(ds.Tables[0].Rows[0]["bAppendTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["isBegin"].ToString() != "")
                {
                    model.isBegin = int.Parse(ds.Tables[0].Rows[0]["isBegin"].ToString());
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
        public BankMoneyInfo GetBankMoneyModel(DateTime bUpdateTime, int BankID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 BankMoneyID,BankID,bMoney,bUpdateTime,bAppendTime,isBegin from tbBankMoneyInfo ");
            strSql.Append(" where BankID=@BankID and bUpdateTime=@bUpdateTime");
            SqlParameter[] parameters = {
					new SqlParameter("@BankID", SqlDbType.Int,4),
                                        new SqlParameter("@bUpdateTime", SqlDbType.DateTime,8)};
            parameters[0].Value = BankID;
            parameters[1].Value = bUpdateTime;

            BankMoneyInfo model = new BankMoneyInfo();
            DataSet ds = DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["BankMoneyID"].ToString() != "")
                {
                    model.BankMoneyID = int.Parse(ds.Tables[0].Rows[0]["BankMoneyID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["BankID"].ToString() != "")
                {
                    model.BankID = int.Parse(ds.Tables[0].Rows[0]["BankID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["bMoney"].ToString() != "")
                {
                    model.bMoney = decimal.Parse(ds.Tables[0].Rows[0]["bMoney"].ToString());
                }
                if (ds.Tables[0].Rows[0]["bUpdateTime"].ToString() != "")
                {
                    model.bUpdateTime = DateTime.Parse(ds.Tables[0].Rows[0]["bUpdateTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["bAppendTime"].ToString() != "")
                {
                    model.bAppendTime = DateTime.Parse(ds.Tables[0].Rows[0]["bAppendTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["isBegin"].ToString() != "")
                {
                    model.isBegin = int.Parse(ds.Tables[0].Rows[0]["isBegin"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        public decimal GetBankMoney(DateTime dDate, int BankID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 bMoney from tbBankMoneyInfo ");
            strSql.Append(" where BankID=@BankID and bUpdateTime=@bUpdateTime ");
            SqlParameter[] parameters = {
					new SqlParameter("@BankID", SqlDbType.Int,4),
                    new SqlParameter("@bUpdateTime", SqlDbType.DateTime,8)};
            parameters[0].Value = BankID;
            parameters[1].Value = dDate;
            DataSet ds = DbHelper.ExecuteDataset(CommandType.Text,strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return decimal.Parse(ds.Tables[0].Rows[0]["bMoney"].ToString());
            }
            else
            {
                return 0;
            }
        }
        /// <summary>
        /// 取账户的期初金额
        /// </summary>
        /// <param name="BankID"></param>
        /// <returns></returns>
        public decimal GetBankBeginMoney(int BankID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 bMoney from tbBankMoneyInfo ");
            strSql.Append(" where BankID=@BankID and isBegin=1 ");
            SqlParameter[] parameters = {
					new SqlParameter("@BankID", SqlDbType.Int,4)};
            parameters[0].Value = BankID;

            DataSet ds = DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return decimal.Parse(ds.Tables[0].Rows[0]["bMoney"].ToString());
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// 设置资金帐户的期初金额
        /// </summary>
        /// <param name="BankID"></param>
        /// <param name="BeginMoney"></param>
        /// <returns></returns>
        public void GetBankBeginMoney(int BankID,decimal BeginMoney)
        { 
            StringBuilder strSql = new StringBuilder();
            strSql.Append("if exists(select 0 from tbBankMoneyInfo where isBegin=1 and BankID=@BankID) ");
            strSql.Append("begin ");
            strSql.Append(" update  tbBankMoneyInfo set bMoney=@BeginMoney where isBegin=1 and BankID=@BankID;");
            strSql.Append("end ");
            strSql.Append("else ");
            strSql.Append("begin ");
            strSql.Append(" insert into tbBankMoneyInfo(BankID,bMoney,bUpdateTime,bAppendTime,isBegin) values(@BankID,@BeginMoney,getdate(),getdate(),1);");
            strSql.Append("end ");
            SqlParameter[] parameters = {
					new SqlParameter("@BankID", SqlDbType.Int,4),
                    new SqlParameter("@BeginMoney", SqlDbType.Money)};
            parameters[0].Value = BankID;
            parameters[1].Value = BeginMoney;

            DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        public decimal GetBankMoneyByEndDate(DateTime eDate, int BankID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 bMoney from tbBankMoneyInfo ");
            strSql.Append(" where BankID=@BankID and bUpdateTime<=@bUpdateTime order by bUpdateTime desc ");
            SqlParameter[] parameters = {
					new SqlParameter("@BankID", SqlDbType.Int,4),
                    new SqlParameter("@bUpdateTime", SqlDbType.DateTime,8)};
            parameters[0].Value = BankID;
            parameters[1].Value = eDate;
            DataSet ds = DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return decimal.Parse(ds.Tables[0].Rows[0]["bMoney"].ToString());
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetBankMoneyList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select BankMoneyID,BankID,bMoney,bUpdateTime,bAppendTime,isBegin ");
            strSql.Append(" FROM tbBankMoneyInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelper.ExecuteDataset(CommandType.Text,strSql.ToString());
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataTable GetBankMoneyList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
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
            parameters[0].Value = "tbBankMoneyInfo";
            parameters[1].Value = "BankMoneyID";
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
