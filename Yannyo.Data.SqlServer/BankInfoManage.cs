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

        /// 返回科目的使用情况
        /// </summary>
        /// <param name="classID"></param>
        /// <returns></returns>
        public int getClassCount(int classID)
        { 
            StringBuilder strSql = new StringBuilder();
            strSql.Append("  select * from tbCertificateDataInfo as ci left join tbCertificateWorkingLogInfo as cli");
            strSql.Append("  on ci.CertificateID=cli.CertificateID where cli.cType in(0,1,2,3) and ci.FeesSubjectID='" + classID + "'");
            DataTable dt= DbHelper.ExecuteDataset(CommandType.Text,strSql.ToString()).Tables[0];
            if (dt.Rows.Count > 0)
            {
                return dt.Rows.Count;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// 获得科目方向
        /// </summary>
        /// <param name="classID"></param>
        /// <returns></returns>
        public string ClassDiretion(int classID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select cDirection from tbFeesSubjectClassInfo where FeesSubjectClassID='" + classID + "'");
            return DbHelper.ExecuteScalarToStr(CommandType.Text, strSql.ToString());
        }

        /// 是否存在该记录
        /// </summary>
        public bool ExistsBank(int bID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tbBankCapitalAccountInfo");
            strSql.Append(" where FeesSubjectClassID=@bID ");
            SqlParameter[] parameters = {
					new SqlParameter("@bID", SqlDbType.Int)};
            parameters[0].Value = bID;

            return ((int)DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters)) > 0;
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddBank(BankAccount model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tbBankCapitalAccountInfo(");
            strSql.Append("cAccountName,FeesSubjectClassID,cAccountMoney,cType,cDirection,pAppendTime,pUpdateTime)");
            strSql.Append(" values (");
            strSql.Append("@cAccountName,@FeesSubjectClassID,@cAccountMoney,@cType,@cDirection,@pAppendTime,Getdate())");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@cAccountName", SqlDbType.NVarChar,500),
					new SqlParameter("@FeesSubjectClassID", SqlDbType.Int),
                    new SqlParameter("@cAccountMoney", SqlDbType.Money),
                    new SqlParameter("@cType", SqlDbType.Int),
                    new SqlParameter("@cDirection", SqlDbType.Int),
                    new SqlParameter("@pAppendTime", SqlDbType.DateTime),
                                        };
            parameters[0].Value = model.CAccountName;
            parameters[1].Value = model.FeesSubjectClassID;
            parameters[2].Value = model.CAccountMoney;
            parameters[3].Value = model.CType;
            parameters[4].Value = model.CDirection;
            parameters[5].Value = model.PAppendTime;

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
        public void UpdateBank(BankAccount model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbBankCapitalAccountInfo set ");
            strSql.Append("cAccountMoney=@cAccountMoney,");
            strSql.Append("pUpdateTime=GETDATE()");
            strSql.Append(" where CapitalAccountID=@CapitalAccountID ");
            SqlParameter[] parameters = {
					new SqlParameter("@CapitalAccountID", SqlDbType.Int),
					new SqlParameter("@cAccountMoney", SqlDbType.Money),
					};
            parameters[0].Value = model.CapitalAccountID;
            parameters[1].Value = model.CAccountMoney;

            DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void DeleteBank(int BankID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbBankCapitalAccountInfo ");
            strSql.Append(" where CapitalAccountID=@CapitalAccountID ");
            SqlParameter[] parameters = {
					new SqlParameter("@CapitalAccountID", SqlDbType.Int)};
            parameters[0].Value = BankID;

            DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void DeleteBank(string BankID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbBankCapitalAccountInfo ");
            strSql.Append(" where CapitalAccountID in(" + BankID + ") ");

            DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString());
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public BankAccount GetBankModel(int BankID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 CapitalAccountID,cAccountName,FeesSubjectClassID,cAccountMoney,cType,pAppendTime from tbBankCapitalAccountInfo ");
            strSql.Append(" where CapitalAccountID=@CapitalAccountID ");
            SqlParameter[] parameters = {
					new SqlParameter("@CapitalAccountID", SqlDbType.Int)};
            parameters[0].Value = BankID;

            BankAccount model = new BankAccount();
            DataSet ds = DbHelper.ExecuteDataset(CommandType.Text,strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["CapitalAccountID"].ToString() != "")
                {
                    model.CapitalAccountID = int.Parse(ds.Tables[0].Rows[0]["CapitalAccountID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["cAccountName"].ToString() != "")
                {
                    model.CAccountName = ds.Tables[0].Rows[0]["cAccountName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["FeesSubjectClassID"].ToString() != "")
                {
                    model.FeesSubjectClassID = int.Parse(ds.Tables[0].Rows[0]["FeesSubjectClassID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["cAccountMoney"].ToString() != "")
                {

                    model.CAccountMoney =decimal.Parse(ds.Tables[0].Rows[0]["cAccountMoney"].ToString());
                }
                if (ds.Tables[0].Rows[0]["cType"].ToString() != "")
                {

                    model.CType = int.Parse(ds.Tables[0].Rows[0]["cType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["pAppendTime"].ToString() != "")
                {

                    model.PAppendTime = DateTime.Parse(ds.Tables[0].Rows[0]["pAppendTime"].ToString());
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
        public DataSet GetBankList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select b.CapitalAccountID,b.cAccountName,b.FeesSubjectClassID,b.cAccountMoney,b.cType,b.pAppendTime,b.pUpdateTime,c.cClassName,c.cDirection,c.cCode,c.cType");
            strSql.Append(" FROM tbBankCapitalAccountInfo b left join tbFeesSubjectClassInfo c on b.FeesSubjectClassID=c.FeesSubjectClassID ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelper.ExecuteDataset(CommandType.Text,strSql.ToString());
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataTable GetBankList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
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
            parameters[0].Value = "tbBankInfo";
            parameters[1].Value = "BankID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 1;
            parameters[5].Value = OrderType;
            parameters[6].Value = strWhere;
            parameters[7].Value = showFName + ",isnull((select top 1 bMoney from tbBankMoneyInfo where BankID=tbBankInfo.BankID and isBegin=1),0) as BeginMoney";
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
