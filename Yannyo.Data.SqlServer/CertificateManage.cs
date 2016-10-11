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
        #region 凭证头
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistsCertificateInfo(string cCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tbCertificateInfo");
            strSql.Append(" where cCode=@cCode ");
            SqlParameter[] parameters = {
					new SqlParameter("@cCode", SqlDbType.VarChar,50)};
            parameters[0].Value = cCode;

             return ((int)DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters)) > 0;
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddCertificateInfo(CertificateInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("declare @CertificateID int;");
            strSql.Append("insert into tbCertificateInfo(");
            strSql.Append("cCode,cMoney,cType,UserID,StaffID,cRemake,cObject,cObjectID,cState,cDateTime,cAppendTime,toObject,toObjectID,BankID,cSteps,cNumber)");
            strSql.Append(" values (");
            strSql.Append("@cCode,@cMoney,@cType,@UserID,@StaffID,@cRemake,@cObject,@cObjectID,@cState,@cDateTime,@cAppendTime,@toObject,@toObjectID,@BankID,@cSteps,@cNumber)");
            strSql.Append(";SET @CertificateID = SCOPE_IDENTITY();select @CertificateID;");

            if (model.CertificateDataJson != null)
            {
                foreach (CertificateDataInfo cd in model.CertificateDataJson.CertificateDataInfoJson)
                {
                    if (cd != null)
                    {
                        strSql.Append(" insert into tbCertificateDataInfo(CertificateID,FeesSubjectID,cdName,cdMoney,cdRemake,cdAppendTime,toObject,toObjectID,cdMoneyB)");
                        strSql.Append(" values(@CertificateID," + cd.FeesSubjectID + ",'" + cd.cdName + "'," + cd.cdMoney + ",'" + cd.cdRemake + "',getdate()," + cd.toObject + "," + cd.toObjectID + "," + cd.cdMoneyB + ");");
                    }
                }
            }

            SqlParameter[] parameters = {
					new SqlParameter("@cCode", SqlDbType.VarChar,50),
					new SqlParameter("@cMoney", SqlDbType.Money,8),
					new SqlParameter("@cType", SqlDbType.Int,4),
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@StaffID", SqlDbType.Int,4),
					new SqlParameter("@cRemake", SqlDbType.VarChar,512),
					new SqlParameter("@cObject", SqlDbType.Int,4),
					new SqlParameter("@cObjectID", SqlDbType.Int,4),
					new SqlParameter("@cState", SqlDbType.Int,4),
					new SqlParameter("@cDateTime", SqlDbType.DateTime),
					new SqlParameter("@cAppendTime", SqlDbType.DateTime),
                                        new SqlParameter("@toObject", SqlDbType.Int,4),
                                        new SqlParameter("@toObjectID", SqlDbType.Int,4),
                                        new SqlParameter("@BankID", SqlDbType.Int,4),
                                        new SqlParameter("@cSteps", SqlDbType.Int,4),
                                        new SqlParameter("@cNumber", SqlDbType.Int,4),};
            parameters[0].Value = model.cCode;
            parameters[1].Value = model.cMoney;
            parameters[2].Value = model.cType;
            parameters[3].Value = model.UserID;
            parameters[4].Value = model.StaffID;
            parameters[5].Value = model.cRemake;
            parameters[6].Value = model.cObject;
            parameters[7].Value = model.cObjectID;
            parameters[8].Value = model.cState;
            parameters[9].Value = model.cDateTime;
            parameters[10].Value = model.cAppendTime;
            parameters[11].Value = model.toObject;
            parameters[12].Value = model.toObjectID;
            parameters[13].Value = model.BankID;
            parameters[14].Value = model.cSteps;
            parameters[15].Value = model.cNumber;

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
        public void UpdateCertificateInfo(CertificateInfo model)
        {
            string tID = "";
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbCertificateInfo set ");
            strSql.Append("cCode=@cCode,");
            strSql.Append("cMoney=@cMoney,");
            strSql.Append("cType=@cType,");
            strSql.Append("UserID=@UserID,");
            strSql.Append("StaffID=@StaffID,");
            strSql.Append("cRemake=@cRemake,");
            strSql.Append("cObject=@cObject,");
            strSql.Append("cObjectID=@cObjectID,");
            strSql.Append("cState=@cState,");
            strSql.Append("cDateTime=@cDateTime,");
            strSql.Append("cAppendTime=@cAppendTime,");
            strSql.Append("toObject=@toObject,");
            strSql.Append("toObjectID=@toObjectID,");
            strSql.Append("BankID=@BankID,");
            strSql.Append("cSteps=@cSteps,");
            strSql.Append("cNumber=@cNumber");
            strSql.Append(" where CertificateID=@CertificateID ;");

            if (model.CertificateDataJson != null)
            {
                foreach (CertificateDataInfo cd in model.CertificateDataJson.CertificateDataInfoJson)
                {
                    if (cd != null)
                    {
                        if (cd.CertificateDataID > 0)
                        {
                            //更新旧记录
                            strSql.Append(" update tbCertificateDataInfo set FeesSubjectID=" + cd.FeesSubjectID + ",cdName='" + cd.cdName + "',cdMoney=" + cd.cdMoney + ",cdMoneyB=" + cd.cdMoneyB + ",cdRemake='" + cd.cdRemake + "',toObject=" + cd.toObject + ",toObjectID=" + cd.toObjectID + "" +
                                " where CertificateDataID=" + cd.CertificateDataID + " and CertificateID=@CertificateID ;");
                            tID += "'" + cd.CertificateDataID + "',";
                        }
                    }
                }
                if (tID.Trim() != "")
                {
                    tID = Utils.ReSQLSetTxt(tID);
                    strSql.Append("delete from tbCertificateDataInfo where CertificateDataID not in (" + tID + ") and CertificateID=@CertificateID ;");
                }

                foreach (CertificateDataInfo cd in model.CertificateDataJson.CertificateDataInfoJson)
                {
                    if (cd != null)
                    {
                        if (cd.CertificateDataID <= 0)
                        {
                            strSql.Append(" insert into tbCertificateDataInfo(CertificateID,FeesSubjectID,cdName,cdMoney,cdRemake,cdAppendTime,toObject,toObjectID,cdMoneyB)");
                            strSql.Append(" values(@CertificateID," + cd.FeesSubjectID + ",'" + cd.cdName + "'," + cd.cdMoney + ",'" + cd.cdRemake + "',getdate()," + cd.toObject + "," + cd.toObjectID + "," + cd.cdMoneyB + ");");
                        }
                    }
                }
            }

            SqlParameter[] parameters = {
					new SqlParameter("@CertificateID", SqlDbType.Int,4),
					new SqlParameter("@cCode", SqlDbType.VarChar,50),
					new SqlParameter("@cMoney", SqlDbType.Money,8),
					new SqlParameter("@cType", SqlDbType.Int,4),
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@StaffID", SqlDbType.Int,4),
					new SqlParameter("@cRemake", SqlDbType.VarChar,512),
					new SqlParameter("@cObject", SqlDbType.Int,4),
					new SqlParameter("@cObjectID", SqlDbType.Int,4),
					new SqlParameter("@cState", SqlDbType.Int,4),
					new SqlParameter("@cDateTime", SqlDbType.DateTime),
					new SqlParameter("@cAppendTime", SqlDbType.DateTime),
                                        new SqlParameter("@toObject", SqlDbType.Int,4),
                                        new SqlParameter("@toObjectID", SqlDbType.Int,4),
                                        new SqlParameter("@BankID", SqlDbType.Int,4),
                                        new SqlParameter("@cSteps", SqlDbType.Int,4),
                                        new SqlParameter("@cNumber", SqlDbType.Int,4),};
            parameters[0].Value = model.CertificateID;
            parameters[1].Value = model.cCode;
            parameters[2].Value = model.cMoney;
            parameters[3].Value = model.cType;
            parameters[4].Value = model.UserID;
            parameters[5].Value = model.StaffID;
            parameters[6].Value = model.cRemake;
            parameters[7].Value = model.cObject;
            parameters[8].Value = model.cObjectID;
            parameters[9].Value = model.cState;
            parameters[10].Value = model.cDateTime;
            parameters[11].Value = model.cAppendTime;
            parameters[12].Value = model.toObject;
            parameters[13].Value = model.toObjectID;
            parameters[14].Value = model.BankID;
            parameters[15].Value = model.cSteps;
            parameters[16].Value = model.cNumber;

            DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新凭证头信息
        /// </summary>
        /// <param name="model"></param>
        public void UpdateCertificateInfoNOListData(CertificateInfo model)
        {
            string tID = "";
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbCertificateInfo set ");
            strSql.Append("cCode=@cCode,");
            strSql.Append("cMoney=@cMoney,");
            strSql.Append("cType=@cType,");
            strSql.Append("UserID=@UserID,");
            strSql.Append("StaffID=@StaffID,");
            strSql.Append("cRemake=@cRemake,");
            strSql.Append("cObject=@cObject,");
            strSql.Append("cObjectID=@cObjectID,");
            strSql.Append("cState=@cState,");
            strSql.Append("cDateTime=@cDateTime,");
            strSql.Append("cAppendTime=@cAppendTime,");
            strSql.Append("toObject=@toObject,");
            strSql.Append("toObjectID=@toObjectID,");
            strSql.Append("BankID=@BankID,");
            strSql.Append("cSteps=@cSteps,");
            strSql.Append("cNumber=@cNumber");
            strSql.Append(" where CertificateID=@CertificateID ;");

            
            SqlParameter[] parameters = {
					new SqlParameter("@CertificateID", SqlDbType.Int,4),
					new SqlParameter("@cCode", SqlDbType.VarChar,50),
					new SqlParameter("@cMoney", SqlDbType.Money,8),
					new SqlParameter("@cType", SqlDbType.Int,4),
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@StaffID", SqlDbType.Int,4),
					new SqlParameter("@cRemake", SqlDbType.VarChar,512),
					new SqlParameter("@cObject", SqlDbType.Int,4),
					new SqlParameter("@cObjectID", SqlDbType.Int,4),
					new SqlParameter("@cState", SqlDbType.Int,4),
					new SqlParameter("@cDateTime", SqlDbType.DateTime),
					new SqlParameter("@cAppendTime", SqlDbType.DateTime),
                                        new SqlParameter("@toObject", SqlDbType.Int,4),
                                        new SqlParameter("@toObjectID", SqlDbType.Int,4),
                                        new SqlParameter("@BankID", SqlDbType.Int,4),
                                        new SqlParameter("@cSteps", SqlDbType.Int,4),
                                        new SqlParameter("@cNumber", SqlDbType.Int,4),};
            parameters[0].Value = model.CertificateID;
            parameters[1].Value = model.cCode;
            parameters[2].Value = model.cMoney;
            parameters[3].Value = model.cType;
            parameters[4].Value = model.UserID;
            parameters[5].Value = model.StaffID;
            parameters[6].Value = model.cRemake;
            parameters[7].Value = model.cObject;
            parameters[8].Value = model.cObjectID;
            parameters[9].Value = model.cState;
            parameters[10].Value = model.cDateTime;
            parameters[11].Value = model.cAppendTime;
            parameters[12].Value = model.toObject;
            parameters[13].Value = model.toObjectID;
            parameters[14].Value = model.BankID;
            parameters[15].Value = model.cSteps;
            parameters[16].Value = model.cNumber;

            DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 返回指定单号预付款合计金额
        /// </summary>
        /// <param name="OrderID"></param>
        /// <returns></returns>
        public decimal GetPrepayMoneyByOrderID(int OrderID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select isnull(sum(cMoney),0) from tbCertificateInfo where cObject=1 and cObjectID=@cObjectID and cState=0");
            SqlParameter[] parameters = {
					new SqlParameter("@cObjectID", SqlDbType.Int,4)};
            parameters[0].Value = OrderID;
            object obj = DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToDecimal(obj);
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void DeleteCertificateInfo(int CertificateID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbCertificateInfo ");
            strSql.Append(" where CertificateID=@CertificateID ");
            SqlParameter[] parameters = {
					new SqlParameter("@CertificateID", SqlDbType.Int,4)};
            parameters[0].Value = CertificateID;

            DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        /// <summary>
        /// 获取指定凭证编号的前后凭证编号
        /// </summary>
        /// <param name="CertificateID"></param>
        /// <returns></returns>
        public long[] GetCertificateUpDownID(int CertificateID)
        {
            long[] ReVal = new long[2];
            ReVal[0]=0;
            ReVal[1]=0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select isnull((select top 1 CertificateID from tbCertificateInfo where CertificateID<c.CertificateID order by cDateTime desc,cNumber desc),0) as UpID,isnull((select top 1 CertificateID from tbCertificateInfo where CertificateID>c.CertificateID order by cDateTime asc,cNumber asc),0) as DuwnID from tbCertificateInfo as c where CertificateID=@CertificateID");
            SqlParameter[] parameters = {
					new SqlParameter("@CertificateID", SqlDbType.Int,4)};
            parameters[0].Value = CertificateID;
            DataSet ds = DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(), parameters);
            if (ds != null)
            { 
                if(ds.Tables[0].Rows.Count>0){
                    ReVal[0]=Convert.ToInt64( ds.Tables[0].Rows[0][0].ToString());
                    ReVal[1]=Convert.ToInt64( ds.Tables[0].Rows[0][1].ToString());
                }
            }
            return ReVal;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CertificateInfo GetCertificateInfoModel(int CertificateID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 CertificateID,cCode,cNumber,cMoney,cType,UserID,StaffID,cRemake,cObject,cObjectID,cState,cDateTime,cAppendTime,toObject,toObjectID,BankID,cSteps," +
                "(select bName from tbBankInfo where BankID=tbCertificateInfo.BankID) as BankName," +
                "(case when toObject=1 then (select sName from tbSupplierInfo where SupplierID=toObjectID) " +
                " when toObject=0 then (select sName from tbStoresInfo where StoresID=toObjectID) " +
                " when toObject=2 then (select sName from tbStaffInfo where StaffID=toObjectID) " +
                 " when toObject=3 then (select pName from tbPaymentSystemInfo where PaymentSystemID=toObjectID) " +
                " end ) as toObjectName," +
                "(select uName from tbUserInfo where UserID=tbCertificateInfo.UserID) as UserName,"+
                "(select sName from tbStaffInfo where StaffID=(select StaffID from tbUserInfo where UserID=tbCertificateInfo.UserID)) as UserStaffName," +
                "(select sName from tbStaffInfo where StaffID=tbCertificateInfo.StaffID) as StaffName " +
                " from tbCertificateInfo ");
            strSql.Append(" where CertificateID=@CertificateID ");
            SqlParameter[] parameters = {
					new SqlParameter("@CertificateID", SqlDbType.Int,4)};
            parameters[0].Value = CertificateID;

            CertificateInfo model = new CertificateInfo();
            DataSet ds = DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["CertificateID"].ToString() != "")
                {
                    model.CertificateID = int.Parse(ds.Tables[0].Rows[0]["CertificateID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["toObject"].ToString() != "")
                {
                    model.toObject = int.Parse(ds.Tables[0].Rows[0]["toObject"].ToString());
                }
                if (ds.Tables[0].Rows[0]["toObjectID"].ToString() != "")
                {
                    model.toObjectID = int.Parse(ds.Tables[0].Rows[0]["toObjectID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["BankID"].ToString() != "")
                {
                    model.BankID = int.Parse(ds.Tables[0].Rows[0]["BankID"].ToString());
                }
                model.BankName = ds.Tables[0].Rows[0]["BankName"].ToString();
                model.toObjectName = ds.Tables[0].Rows[0]["toObjectName"].ToString();
                model.cCode = ds.Tables[0].Rows[0]["cCode"].ToString();
                model.UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                model.UserStaffName = ds.Tables[0].Rows[0]["UserStaffName"].ToString();
                model.StaffName = ds.Tables[0].Rows[0]["StaffName"].ToString();
                if (ds.Tables[0].Rows[0]["cMoney"].ToString() != "")
                {
                    model.cMoney = decimal.Parse(ds.Tables[0].Rows[0]["cMoney"].ToString());
                }
                if (ds.Tables[0].Rows[0]["cNumber"].ToString() != "")
                {
                    model.cNumber = int.Parse(ds.Tables[0].Rows[0]["cNumber"].ToString());
                }
                if (ds.Tables[0].Rows[0]["cType"].ToString() != "")
                {
                    model.cType = int.Parse(ds.Tables[0].Rows[0]["cType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserID"].ToString() != "")
                {
                    model.UserID = int.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["StaffID"].ToString() != "")
                {
                    model.StaffID = int.Parse(ds.Tables[0].Rows[0]["StaffID"].ToString());
                }
                model.cRemake = ds.Tables[0].Rows[0]["cRemake"].ToString();
                if (ds.Tables[0].Rows[0]["cObject"].ToString() != "")
                {
                    model.cObject = int.Parse(ds.Tables[0].Rows[0]["cObject"].ToString());
                }
                if (ds.Tables[0].Rows[0]["cObjectID"].ToString() != "")
                {
                    model.cObjectID = int.Parse(ds.Tables[0].Rows[0]["cObjectID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["cState"].ToString() != "")
                {
                    model.cState = int.Parse(ds.Tables[0].Rows[0]["cState"].ToString());
                }
                if (ds.Tables[0].Rows[0]["cDateTime"].ToString() != "")
                {
                    model.cDateTime = DateTime.Parse(ds.Tables[0].Rows[0]["cDateTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["cAppendTime"].ToString() != "")
                {
                    model.cAppendTime = DateTime.Parse(ds.Tables[0].Rows[0]["cAppendTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["cSteps"].ToString() != "")
                {
                    model.cSteps = int.Parse(ds.Tables[0].Rows[0]["cSteps"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }
        public CertificateInfo GetCertificateInfoModel(string cCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 CertificateID,cCode,cNumber,cMoney,cType,UserID,StaffID,cRemake,cObject,cObjectID,cState,cDateTime,cAppendTime,toObject,toObjectID,BankID,cSteps," +
                "(select bName from tbBankInfo where BankID=tbCertificateInfo.BankID) as BankName," +
                "(case when toObject=1 then (select sName from tbSupplierInfo where SupplierID=toObjectID) " +
                " when toObject=0 then (select sName from tbStoresInfo where StoresID=toObjectID) " +
                " when toObject=2 then (select sName from tbStaffInfo where StaffID=toObjectID) " +
                 " when toObject=3 then (select pName from tbPaymentSystemInfo where PaymentSystemID=toObjectID) " +
                " end ) as toObjectName," +
                "(select uName from tbUserInfo where UserID=tbCertificateInfo.UserID) as UserName," +
                "(select sName from tbStaffInfo where StaffID=(select StaffID from tbUserInfo where UserID=tbCertificateInfo.UserID)) as UserStaffName," +
                "(select sName from tbStaffInfo where StaffID=tbCertificateInfo.StaffID) as StaffName " +
                " from tbCertificateInfo ");
            strSql.Append(" where cCode=@cCode ");
            SqlParameter[] parameters = {
					new SqlParameter("@cCode", SqlDbType.VarChar,50)};
            parameters[0].Value = cCode;

            CertificateInfo model = new CertificateInfo();
            DataSet ds = DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["CertificateID"].ToString() != "")
                {
                    model.CertificateID = int.Parse(ds.Tables[0].Rows[0]["CertificateID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["toObject"].ToString() != "")
                {
                    model.toObject = int.Parse(ds.Tables[0].Rows[0]["toObject"].ToString());
                }
                if (ds.Tables[0].Rows[0]["toObjectID"].ToString() != "")
                {
                    model.toObjectID = int.Parse(ds.Tables[0].Rows[0]["toObjectID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["BankID"].ToString() != "")
                {
                    model.BankID = int.Parse(ds.Tables[0].Rows[0]["BankID"].ToString());
                }
                model.BankName = ds.Tables[0].Rows[0]["BankName"].ToString();
                model.toObjectName = ds.Tables[0].Rows[0]["toObjectName"].ToString();
                model.cCode = ds.Tables[0].Rows[0]["cCode"].ToString();
                model.UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                model.UserStaffName = ds.Tables[0].Rows[0]["UserStaffName"].ToString();
                model.StaffName = ds.Tables[0].Rows[0]["StaffName"].ToString();
                if (ds.Tables[0].Rows[0]["cMoney"].ToString() != "")
                {
                    model.cMoney = decimal.Parse(ds.Tables[0].Rows[0]["cMoney"].ToString());
                }
                if (ds.Tables[0].Rows[0]["cNumber"].ToString() != "")
                {
                    model.cNumber = int.Parse(ds.Tables[0].Rows[0]["cNumber"].ToString());
                }
                if (ds.Tables[0].Rows[0]["cType"].ToString() != "")
                {
                    model.cType = int.Parse(ds.Tables[0].Rows[0]["cType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserID"].ToString() != "")
                {
                    model.UserID = int.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["StaffID"].ToString() != "")
                {
                    model.StaffID = int.Parse(ds.Tables[0].Rows[0]["StaffID"].ToString());
                }
                model.cRemake = ds.Tables[0].Rows[0]["cRemake"].ToString();
                if (ds.Tables[0].Rows[0]["cObject"].ToString() != "")
                {
                    model.cObject = int.Parse(ds.Tables[0].Rows[0]["cObject"].ToString());
                }
                if (ds.Tables[0].Rows[0]["cObjectID"].ToString() != "")
                {
                    model.cObjectID = int.Parse(ds.Tables[0].Rows[0]["cObjectID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["cState"].ToString() != "")
                {
                    model.cState = int.Parse(ds.Tables[0].Rows[0]["cState"].ToString());
                }
                if (ds.Tables[0].Rows[0]["cDateTime"].ToString() != "")
                {
                    model.cDateTime = DateTime.Parse(ds.Tables[0].Rows[0]["cDateTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["cAppendTime"].ToString() != "")
                {
                    model.cAppendTime = DateTime.Parse(ds.Tables[0].Rows[0]["cAppendTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["cSteps"].ToString() != "")
                {
                    model.cSteps = int.Parse(ds.Tables[0].Rows[0]["cSteps"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 移除凭证随附信息
        /// </summary>
        /// <param name="CertificateID"></param>
        public void RemoveCertificateToObject(int CertificateID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbCertificateInfo set cObject=0,cObjectID=0 where CertificateID=@CertificateID");
            SqlParameter[] parameters = {
                    new SqlParameter("@CertificateID", SqlDbType.Int, 4),
                                        };
            parameters[0].Value = CertificateID;
            DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 设置凭证随附信息
        /// </summary>
        /// <param name="CertificateID"></param>
        public void SetCertificateToObject(int CertificateID, int cObject, int cObjectID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbCertificateInfo set cObject=@cObject,cObjectID=@cObjectID where CertificateID=@CertificateID");
            SqlParameter[] parameters = {
                                            new SqlParameter("@cObject", SqlDbType.Int, 4),
                                            new SqlParameter("@cObjectID", SqlDbType.Int, 4),
                    new SqlParameter("@CertificateID", SqlDbType.Int, 4),
                                        };
            parameters[0].Value = cObject;
            parameters[1].Value = cObjectID;
            parameters[2].Value = CertificateID;
            DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新步骤
        /// </summary>
        /// <param name="CertificateID"></param>
        /// <param name="cSteps"></param>
        public void SetCertificateSteps(int CertificateID, int cSteps)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbCertificateInfo set cSteps=@cSteps where CertificateID=@CertificateID");
            SqlParameter[] parameters = {
                                            new SqlParameter("@cSteps", SqlDbType.Int, 4),
                                            new SqlParameter("@CertificateID", SqlDbType.Int, 4),
                                        };
            parameters[0].Value = cSteps;
            parameters[1].Value = CertificateID;
            DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 金额合计
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public decimal GetCertificateSumMoney(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select isnull(sum(isnull(cMoney,0)),0)  ");
            strSql.Append(" FROM tbCertificateInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToDecimal(obj);
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetCertificateInfoList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select CertificateID,cCode,cNumber,cMoney,cType,UserID,StaffID,cRemake,cObject,cObjectID,cState,cDateTime,cAppendTime,toObject,toObjectID,BankID,cSteps," +
                "(select bName from tbBankInfo where BankID=tbCertificateInfo.BankID) as BankName," +
                "(case when toObject=1 then (select sName from tbSupplierInfo where SupplierID=toObjectID) " +
                " when toObject=0 then (select sName from tbStoresInfo where StoresID=toObjectID) " +
                " when toObject=2 then (select sName from tbStaffInfo where StaffID=toObjectID) " +
                 " when toObject=3 then (select pName from tbPaymentSystemInfo where PaymentSystemID=toObjectID) " +
                " end ) as toObjectName," +
                "(select uName from tbUserInfo where UserID=tbCertificateInfo.UserID) as UserName," +
                "(select sName from tbStaffInfo where StaffID=(select StaffID from tbUserInfo where UserID=tbCertificateInfo.UserID)) as UserStaffName," +
                "(select sName from tbStaffInfo where StaffID=tbCertificateInfo.StaffID) as StaffName  ");
            strSql.Append(" FROM tbCertificateInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelper.ExecuteDataset(CommandType.Text,strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetCertificateInfoList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" CertificateID,cCode,cNumber,cMoney,cType,UserID,StaffID,cRemake,cObject,cObjectID,cState,cDateTime,cAppendTime,toObject,toObjectID,BankID,cSteps," +
                "(select bName from tbBankInfo where BankID=tbCertificateInfo.BankID) as BankName," +
                "(case when toObject=1 then (select sName from tbSupplierInfo where SupplierID=toObjectID) " +
                " when toObject=0 then (select sName from tbStoresInfo where StoresID=toObjectID) " +
                " when toObject=2 then (select sName from tbStaffInfo where StaffID=toObjectID) " +
                 " when toObject=3 then (select pName from tbPaymentSystemInfo where PaymentSystemID=toObjectID) " +
                " end ) as toObjectName," +
                "(select uName from tbUserInfo where UserID=tbCertificateInfo.UserID) as UserName," +
                "(select sName from tbStaffInfo where StaffID=(select StaffID from tbUserInfo where UserID=tbCertificateInfo.UserID)) as UserStaffName," +
                "(select sName from tbStaffInfo where StaffID=tbCertificateInfo.StaffID) as StaffName ");
            strSql.Append(" FROM tbCertificateInfo ");
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
        public DataTable GetCertificateInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
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
            parameters[0].Value = "tbCertificateInfo";
            parameters[1].Value = "CertificateID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 1;
            parameters[5].Value = OrderType;
            parameters[6].Value = strWhere;
            parameters[7].Value = showFName + ",isnull((select bName from tbBankInfo where BankID=tbCertificateInfo.BankID),'') as BankName," +
                "isnull((case when toObject=1 then (select sName from tbSupplierInfo where SupplierID=toObjectID) " +
                " when toObject=0 then (select sName from tbStoresInfo where StoresID=toObjectID) " +
                " when toObject=2 then (select sName from tbStaffInfo where StaffID=toObjectID) " +
                 " when toObject=3 then (select pName from tbPaymentSystemInfo where PaymentSystemID=toObjectID) " +
                " end ),'') as toObjectName," +
                "(select uName from tbUserInfo where UserID=tbCertificateInfo.UserID) as UserName," +
                "(select sName from tbStaffInfo where StaffID=(select StaffID from tbUserInfo where UserID=tbCertificateInfo.UserID)) as UserStaffName," +
                "(select sName from tbStaffInfo where StaffID=tbCertificateInfo.StaffID) as StaffName " ;
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
        public DataTable GetCertificateInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName, string OrderFldName)
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
                    new SqlParameter("@OrderFldName", SqlDbType.VarChar, 255),
                    };
            parameters[0].Value = "tbCertificateInfo";
            parameters[1].Value = "CertificateID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 1;
            parameters[5].Value = OrderType;
            parameters[6].Value = strWhere;
            parameters[7].Value = showFName + ",isnull((select bName from tbBankInfo where BankID=tbCertificateInfo.BankID),'') as BankName," +
                "isnull((case when toObject=1 then (select sName from tbSupplierInfo where SupplierID=toObjectID) " +
                " when toObject=0 then (select sName from tbStoresInfo where StoresID=toObjectID) " +
                " when toObject=2 then (select sName from tbStaffInfo where StaffID=toObjectID) " +
                 " when toObject=3 then (select pName from tbPaymentSystemInfo where PaymentSystemID=toObjectID) " +
                " end ),'') as toObjectName," +
                "(select uName from tbUserInfo where UserID=tbCertificateInfo.UserID) as UserName," +
                "(select sName from tbStaffInfo where StaffID=(select StaffID from tbUserInfo where UserID=tbCertificateInfo.UserID)) as UserStaffName," +
                "(select sName from tbStaffInfo where StaffID=tbCertificateInfo.StaffID) as StaffName ";
            parameters[8].Value = OrderFldName;
            DataSet ds = DbHelper.ExecuteDataset(CommandType.StoredProcedure, "UP_" + BaseConfigs.GetTablePrefix + "GetRecordByPage_mFld", parameters);
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
        /// <summary>
        /// 验证指定单据是否附加凭证信息
        /// </summary>
        /// <param name="OrderID"></param>
        /// <returns></returns>
        public bool CheckCertificateByOrderID(int OrderID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tbCertificateInfo where cObject=1 and cObjectID=@OrderID and cState=0");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderID", SqlDbType.Int,4),};
            parameters[0].Value = OrderID;
            return ((int)DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters)) > 0;
        }
        /// <summary>
        /// 根据时间返回新的凭证序号,已自动加1
        /// </summary>
        /// <param name="sDate">时间</param>
        /// <returns></returns>
        public int GetCertificateNewNumber(DateTime sDate)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Isnull(max(cNumber),0)+1 from tbCertificateInfo where DATEDIFF(MM,cDateTime,@sDate)=0");
            SqlParameter[] parameters = {
					new SqlParameter("@sDate", SqlDbType.DateTime,8),};
            parameters[0].Value = sDate;
            object obj = DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        /// <summary>
        /// 验证凭证序号是否重复
        /// </summary>
        /// <param name="sDate"></param>
        /// <param name="cNumber"></param>
        /// <returns></returns>
        public bool CheckCertificateNumber(DateTime sDate,int cNumber)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select COUNT(0) from tbCertificateInfo where DATEDIFF(MM,cDateTime,@sDate)=0 and cNumber=@cNumber");
            SqlParameter[] parameters = {
					new SqlParameter("@sDate", SqlDbType.DateTime,8),
                                        new SqlParameter("@cNumber", SqlDbType.Int,4),};
            parameters[0].Value = sDate;
            parameters[1].Value = cNumber;
            object obj = DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
            if (obj == null)
            {
                return false;
            }
            else
            {
                return Convert.ToInt32(obj)>0;
            }
        }
        /// <summary>
        /// 去凭证最大日期
        /// </summary>
        /// <returns></returns>
        public DateTime GetMaxCertificateData() 
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 cDateTime from tbCertificateInfo where cState=0 order by cDateTime desc");
            object _dt = DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString());
            if (_dt != null)
            {
                return Convert.ToDateTime(_dt);
            }
            else {
                return DateTime.Now;
            }            
        }
        /// <summary>
        /// 去凭证最大日期,排除指定ID
        /// </summary>
        /// <returns></returns>
        public DateTime GetMaxCertificateData(Int32 CertificateID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 cDateTime from tbCertificateInfo where cState=0 and CertificateID<>" + CertificateID.ToString() + " order by cDateTime desc");
            object _dt = DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString());
            if (_dt != null)
            {
                return Convert.ToDateTime(_dt);
            }
            else
            {
                return DateTime.Now;
            }
        }
        #endregion 
        #region 凭证内容
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistsCertificateDataInfo(int CertificateID, int FeesSubjectID, string cdName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tbCertificateDataInfo");
            strSql.Append(" where CertificateID=@CertificateID and FeesSubjectID=@FeesSubjectID and cdName=@cdName");
            SqlParameter[] parameters = {
					new SqlParameter("@CertificateID", SqlDbType.Int,4),
                                        new SqlParameter("@FeesSubjectID", SqlDbType.Int,4),
                                        new SqlParameter("@cdName", SqlDbType.VarChar,50)};
            parameters[0].Value = CertificateID;
            parameters[1].Value = FeesSubjectID;
            parameters[2].Value = cdName;

             return ((int)DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters)) > 0;
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddCertificateDataInfo(CertificateDataInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tbCertificateDataInfo(");
            strSql.Append("CertificateID,FeesSubjectID,cdName,cdMoney,cdRemake,cdAppendTime,toObject,toObjectID,cdMoneyB)");
            strSql.Append(" values (");
            strSql.Append("@CertificateID,@FeesSubjectID,@cdName,@cdMoney,@cdRemake,@cdAppendTime,@toObject,@toObjectID,@cdMoneyB)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@CertificateID", SqlDbType.Int,4),
					new SqlParameter("@FeesSubjectID", SqlDbType.Int,4),
					new SqlParameter("@cdName", SqlDbType.VarChar,50),
					new SqlParameter("@cdMoney", SqlDbType.Money,8),
					new SqlParameter("@cdRemake", SqlDbType.VarChar,512),
					new SqlParameter("@cdAppendTime", SqlDbType.DateTime),
                                        new SqlParameter("@toObject", SqlDbType.Int,4),
                                        new SqlParameter("@toObjectID", SqlDbType.Int,4),
                                        new SqlParameter("@cdMoneyB", SqlDbType.Money,8),};
            parameters[0].Value = model.CertificateID;
            parameters[1].Value = model.FeesSubjectID;
            parameters[2].Value = model.cdName;
            parameters[3].Value = model.cdMoney;
            parameters[4].Value = model.cdRemake;
            parameters[5].Value = model.cdAppendTime;
            parameters[6].Value = model.toObject;
            parameters[7].Value = model.toObjectID;
            parameters[8].Value = model.cdMoneyB;

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
        public void UpdateCertificateDataInfo(CertificateDataInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbCertificateDataInfo set ");
            strSql.Append("CertificateID=@CertificateID,");
            strSql.Append("FeesSubjectID=@FeesSubjectID,");
            strSql.Append("cdName=@cdName,");
            strSql.Append("cdMoney=@cdMoney,");
            strSql.Append("cdRemake=@cdRemake,");
            strSql.Append("cdAppendTime=@cdAppendTime,");
            strSql.Append("toObject=@toObject,");
            strSql.Append("toObjectID=@toObjectID,");
            strSql.Append("cdMoneyB=@cdMoneyB");
            strSql.Append(" where CertificateDataID=@CertificateDataID ");
            SqlParameter[] parameters = {
					new SqlParameter("@CertificateDataID", SqlDbType.Int,4),
					new SqlParameter("@CertificateID", SqlDbType.Int,4),
					new SqlParameter("@FeesSubjectID", SqlDbType.Int,4),
					new SqlParameter("@cdName", SqlDbType.VarChar,50),
					new SqlParameter("@cdMoney", SqlDbType.Money,8),
					new SqlParameter("@cdRemake", SqlDbType.VarChar,512),
					new SqlParameter("@cdAppendTime", SqlDbType.DateTime),
                                        new SqlParameter("@toObject", SqlDbType.Int,4),
					new SqlParameter("@toObjectID", SqlDbType.Int,4),
                                        new SqlParameter("@cdMoneyB", SqlDbType.Money,8),};
            parameters[0].Value = model.CertificateDataID;
            parameters[1].Value = model.CertificateID;
            parameters[2].Value = model.FeesSubjectID;
            parameters[3].Value = model.cdName;
            parameters[4].Value = model.cdMoney;
            parameters[5].Value = model.cdRemake;
            parameters[6].Value = model.cdAppendTime;
            parameters[7].Value = model.toObject;
            parameters[8].Value = model.toObjectID;
            parameters[9].Value = model.cdMoneyB;

            DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString());
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void DeleteCertificateDataInfo(int CertificateDataID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbCertificateDataInfo ");
            strSql.Append(" where CertificateDataID=@CertificateDataID ");
            SqlParameter[] parameters = {
					new SqlParameter("@CertificateDataID", SqlDbType.Int,4)};
            parameters[0].Value = CertificateDataID;

            DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString());
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CertificateDataInfo GetCertificateDataInfoModel(int CertificateDataID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 CertificateDataID,CertificateID,FeesSubjectID,cdName,cdMoney,cdMoneyB,cdRemake,cdAppendTime,(select cClassName from tbFeesSubjectClassInfo where FeesSubjectClassID=tbCertificateDataInfo.FeesSubjectID) as FeesSubjectName " +
                ",(case toObject " +
                " when 0 then (select sName from tbStoresInfo where StoresID=toObjectID) " +
                " when 1 then (select sName from tbSupplierInfo where SupplierID=toObjectID) " +
                " when 2 then (select sName from tbStaffInfo where StaffID=toObjectID) " +
                " when 3 then (select pName from tbPaymentSystemInfo where PaymentSystemID=toObjectID) " +
                " end) as ObjectName,toObject,toObjectID " +
                " from tbCertificateDataInfo ");
            strSql.Append(" where CertificateDataID=@CertificateDataID ");
            SqlParameter[] parameters = {
					new SqlParameter("@CertificateDataID", SqlDbType.Int,4)};
            parameters[0].Value = CertificateDataID;

            CertificateDataInfo model = new CertificateDataInfo();
            DataSet ds = DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["CertificateDataID"].ToString() != "")
                {
                    model.CertificateDataID = int.Parse(ds.Tables[0].Rows[0]["CertificateDataID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CertificateID"].ToString() != "")
                {
                    model.CertificateID = int.Parse(ds.Tables[0].Rows[0]["CertificateID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["FeesSubjectID"].ToString() != "")
                {
                    model.FeesSubjectID = int.Parse(ds.Tables[0].Rows[0]["FeesSubjectID"].ToString());
                }
                model.cdName = ds.Tables[0].Rows[0]["cdName"].ToString();
                model.FeesSubjectName = ds.Tables[0].Rows[0]["FeesSubjectName"].ToString();
                model.ObjectName = ds.Tables[0].Rows[0]["ObjectName"].ToString();
                if (ds.Tables[0].Rows[0]["toObjectID"].ToString() != "")
                {
                    model.toObjectID = int.Parse(ds.Tables[0].Rows[0]["toObjectID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["toObject"].ToString() != "")
                {
                    model.toObject = int.Parse(ds.Tables[0].Rows[0]["toObject"].ToString());
                }
                if (ds.Tables[0].Rows[0]["cdMoney"].ToString() != "")
                {
                    model.cdMoney = decimal.Parse(ds.Tables[0].Rows[0]["cdMoney"].ToString());
                }
                if (ds.Tables[0].Rows[0]["cdMoneyB"].ToString() != "")
                {
                    model.cdMoneyB = decimal.Parse(ds.Tables[0].Rows[0]["cdMoneyB"].ToString());
                }
                model.cdRemake = ds.Tables[0].Rows[0]["cdRemake"].ToString();
                if (ds.Tables[0].Rows[0]["cdAppendTime"].ToString() != "")
                {
                    model.cdAppendTime = DateTime.Parse(ds.Tables[0].Rows[0]["cdAppendTime"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 取指定条件下的合计数
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public decimal[] GetCertificateDataSumMoney(string strWhere)
        {
            decimal[] ReMoney = new decimal[2];
            ReMoney[0] = 0;
            ReMoney[1] = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select sum(isnull(tbCertificateDataInfo.cdMoney,0)),sum(isnull(tbCertificateDataInfo.cdMoneyB,0)) as SumMoney from tbCertificateDataInfo");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            DataSet ds = DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString());
            if (ds != null)
            {
                try
                {
                    ReMoney[0] = decimal.Parse(ds.Tables[0].Rows[0][0].ToString());
                }
                catch {
                    ReMoney[0] = 0;
                }

                try
                {
                    ReMoney[1] = decimal.Parse(ds.Tables[0].Rows[0][1].ToString());
                }
                catch {
                    ReMoney[1] = 0;
                }
            }
            return ReMoney;
            
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetCertificateDataInfoList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select cd.CertificateDataID,cd.CertificateID,cd.FeesSubjectID,cd.cdName,cd.cdMoney,cd.cdMoneyB,cd.cdRemake,cd.cdAppendTime,(select cClassName from tbFeesSubjectClassInfo where FeesSubjectClassID=cd.FeesSubjectID) as FeesSubjectName " +
               ",(select cDirection from tbFeesSubjectClassInfo where FeesSubjectClassID=cd.FeesSubjectID) as cDirection " +
                ",(case cd.toObject " +
                " when 0 then (select sName from tbStoresInfo where StoresID=cd.toObjectID) " +
                " when 1 then (select sName from tbSupplierInfo where SupplierID=cd.toObjectID) " +
                " when 2 then (select sName from tbStaffInfo where StaffID=cd.toObjectID) " +
                " when 3 then (select pName from tbPaymentSystemInfo where PaymentSystemID=cd.toObjectID) " +
                " end) as ObjectName,cd.toObject,cd.toObjectID, " +
                "c.StaffID," +
                "(select tbStaffInfo.sName from tbStaffInfo where tbStaffInfo.StaffID=c.StaffID) as StaffName,c.cDateTime,c.cType,c.cCode,c.cNumber" +
                "");
            strSql.Append(" FROM tbCertificateDataInfo as cd left join tbCertificateInfo as c on cd.CertificateID=c.CertificateID");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelper.ExecuteDataset(CommandType.Text,strSql.ToString());
        }
        public DataSet GetCertificateDataInfoListB(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select c.cCode,"+
                "(case c.cType when 0 then '无' when 1 then '无' end) cType," +
                "c.cDateTime,cd.cdName,cd.cdMoney,(select cClassName from tbFeesSubjectClassInfo where FeesSubjectClassID=cd.FeesSubjectID) as FeesSubjectName " +
                ",(case cd.toObject when 0 then '客户' when 1 then '供应商' when 2 then '人员' end) toObject,"+
                "(case cd.toObject " +
                " when 0 then (select sName from tbStoresInfo where StoresID=cd.toObjectID) " +
                " when 1 then (select sName from tbSupplierInfo where SupplierID=cd.toObjectID) " +
                " when 2 then (select sName from tbStaffInfo where StaffID=cd.toObjectID) " +
                " when 3 then (select pName from tbPaymentSystemInfo where PaymentSystemID=cd.toObjectID) " +
                " end) as ObjectName,"+
                "(select tbStaffInfo.sName from tbStaffInfo where tbStaffInfo.StaffID=c.StaffID) as StaffName," +
                "cd.cdRemake,cd.cdAppendTime");
            strSql.Append(" FROM tbCertificateDataInfo as cd left join tbCertificateInfo as c on cd.CertificateID=c.CertificateID");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString());
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetCertificateDataInfoList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" cd.CertificateDataID,cd.CertificateID,cd.FeesSubjectID,cd.cdName,cd.cdMoney,cd.cdMoneyB,cd.cdRemake,cd.cdAppendTime,(select cClassName from tbFeesSubjectClassInfo where FeesSubjectClassID=cd.FeesSubjectID) as FeesSubjectName " +
                ",(select cDirection from tbFeesSubjectClassInfo where FeesSubjectClassID=cd.FeesSubjectID) as cDirection " +
                ",(case cd.toObject " +
                " when 0 then (select sName from tbStoresInfo where StoresID=cd.toObjectID) " +
                " when 1 then (select sName from tbSupplierInfo where SupplierID=cd.toObjectID) " +
                " when 2 then (select sName from tbStaffInfo where StaffID=cd.toObjectID) " +
                " when 3 then (select pName from tbPaymentSystemInfo where PaymentSystemID=cd.toObjectID) " +
                " end) as ObjectName,cd.toObject,cd.toObjectID, " +
                "c.StaffID," +
                "(select tbStaffInfo.sName from tbStaffInfo where tbStaffInfo.StaffID=c.StaffID) as StaffName,c.cDateTime,c.cType,c.cCode,c.cNumber " +
                "");
            strSql.Append(" FROM tbCertificateDataInfo as cd left join tbCertificateInfo as c on cd.CertificateID=c.CertificateID");
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
        public DataTable GetCertificateDataInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,2000),
                    new SqlParameter("@showFName", SqlDbType.VarChar,2000),
                    };
            parameters[0].Value = "tbCertificateDataInfo ";
            parameters[1].Value = "CertificateDataID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 1;
            parameters[5].Value = OrderType;
            parameters[6].Value =  strWhere;
            parameters[7].Value = showFName + ",(select cClassName from tbFeesSubjectClassInfo where FeesSubjectClassID=tbCertificateDataInfo.FeesSubjectID) as FeesSubjectName ,(case tbCertificateDataInfo.toObject " +
                " when 0 then (select sName from tbStoresInfo where StoresID=tbCertificateDataInfo.toObjectID) " +
                " when 1 then (select sName from tbSupplierInfo where SupplierID=tbCertificateDataInfo.toObjectID) " +
                " when 2 then (select sName from tbStaffInfo where StaffID=tbCertificateDataInfo.toObjectID) " +
                " when 3 then (select pName from tbPaymentSystemInfo where PaymentSystemID=tbCertificateDataInfo.toObjectID) " +
                " end) as ObjectName,(select StaffID from tbCertificateInfo where CertificateID=tbCertificateDataInfo.CertificateID) as StaffID," +
                "(select cDirection from tbFeesSubjectClassInfo where FeesSubjectClassID=tbCertificateDataInfo.FeesSubjectID) as cDirection, " +
                "(select tbStaffInfo.sName from tbStaffInfo where tbStaffInfo.StaffID=(select StaffID from tbCertificateInfo where CertificateID=tbCertificateDataInfo.CertificateID)) as StaffName," +
                "(select cCode from tbCertificateInfo where CertificateID=tbCertificateDataInfo.CertificateID) as cCode," +
                "(select cNumber from tbCertificateInfo where CertificateID=tbCertificateDataInfo.CertificateID) as cNumber," +
                "(select cDateTime from tbCertificateInfo where CertificateID=tbCertificateDataInfo.CertificateID) as cDateTime, " +
                "isnull((tbCertificateDataInfo.cdMoney+tbCertificateDataInfo.cdMoneyB),0) as cdMoney ";
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
        #region 凭证照片
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddCertificatePicInfo(CertificatePicInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tbCertificatePicInfo(");
            strSql.Append("CertificateID,cCode,cPic,cAppendTime,UserID)");
            strSql.Append(" values (");
            strSql.Append("@CertificateID,@cCode,@cPic,@cAppendTime,@UserID)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@CertificateID", SqlDbType.Int,4),
					new SqlParameter("@cCode", SqlDbType.VarChar,32),
					new SqlParameter("@cPic", SqlDbType.VarChar,512),
					new SqlParameter("@cAppendTime", SqlDbType.DateTime),
                                        new SqlParameter("@UserID", SqlDbType.Int,4),};
            parameters[0].Value = model.CertificateID;
            parameters[1].Value = model.cCode;
            parameters[2].Value = model.cPic;
            parameters[3].Value = model.cAppendTime;
            parameters[4].Value = model.UserID;

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
        public void UpdateCertificatePicInfo(CertificatePicInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbCertificatePicInfo set ");
            strSql.Append("CertificateID=@CertificateID,");
            strSql.Append("cCode=@cCode,");
            strSql.Append("cPic=@cPic,");
            strSql.Append("cAppendTime=@cAppendTime,");
            strSql.Append("UserID=@UserID");
            strSql.Append(" where CertificatePicID=@CertificatePicID ");
            SqlParameter[] parameters = {
					new SqlParameter("@CertificatePicID", SqlDbType.Int,4),
					new SqlParameter("@CertificateID", SqlDbType.Int,4),
					new SqlParameter("@cCode", SqlDbType.VarChar,32),
					new SqlParameter("@cPic", SqlDbType.VarChar,512),
					new SqlParameter("@cAppendTime", SqlDbType.DateTime),
                                        new SqlParameter("@UserID", SqlDbType.Int,4),};
            parameters[0].Value = model.CertificatePicID;
            parameters[1].Value = model.CertificateID;
            parameters[2].Value = model.cCode;
            parameters[3].Value = model.cPic;
            parameters[4].Value = model.cAppendTime;
            parameters[5].Value = model.UserID;

            DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        /// <summary>
        /// 更新指定凭证照片的凭证编号
        /// </summary>
        /// <param name="CertificatePicID"></param>
        /// <param name="CertificateID"></param>
        public void UpdateCertificatePicCertificateID(int CertificatePicID, int CertificateID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbCertificatePicInfo set CertificateID=@CertificateID where CertificatePicID=@CertificatePicID");
            SqlParameter[] parameters = {
					new SqlParameter("@CertificatePicID", SqlDbType.Int,4),
                    new SqlParameter("@CertificateID", SqlDbType.Int,4),
                                        };
            parameters[0].Value = CertificatePicID;
            parameters[1].Value = CertificateID;
            DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void DeleteCertificatePicInfo(int CertificatePicID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbCertificatePicInfo ");
            strSql.Append(" where CertificatePicID=@CertificatePicID ");
            SqlParameter[] parameters = {
					new SqlParameter("@CertificatePicID", SqlDbType.Int,4)};
            parameters[0].Value = CertificatePicID;

            DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString());
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CertificatePicInfo GetCertificatePicInfoModel(int CertificatePicID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 CertificatePicID,CertificateID,cCode,cPic,cAppendTime,UserID from tbCertificatePicInfo ");
            strSql.Append(" where CertificatePicID=@CertificatePicID ");
            SqlParameter[] parameters = {
					new SqlParameter("@CertificatePicID", SqlDbType.Int,4)};
            parameters[0].Value = CertificatePicID;

            CertificatePicInfo model = new CertificatePicInfo();
            DataSet ds = DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["CertificatePicID"].ToString() != "")
                {
                    model.CertificatePicID = int.Parse(ds.Tables[0].Rows[0]["CertificatePicID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserID"].ToString() != "")
                {
                    model.UserID = int.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CertificateID"].ToString() != "")
                {
                    model.CertificateID = int.Parse(ds.Tables[0].Rows[0]["CertificateID"].ToString());
                }
                model.cCode = ds.Tables[0].Rows[0]["cCode"].ToString();
                model.cPic = ds.Tables[0].Rows[0]["cPic"].ToString();
                if (ds.Tables[0].Rows[0]["cAppendTime"].ToString() != "")
                {
                    model.cAppendTime = DateTime.Parse(ds.Tables[0].Rows[0]["cAppendTime"].ToString());
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
        public DataSet GetCertificatePicInfoList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select CertificatePicID,CertificateID,cCode,cPic,cAppendTime,UserID ");
            strSql.Append(" FROM tbCertificatePicInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelper.ExecuteDataset(CommandType.Text,strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetCertificatePicInfoList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" CertificatePicID,CertificateID,cCode,cPic,cAppendTime,UserID ");
            strSql.Append(" FROM tbCertificatePicInfo ");
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
        public DataTable GetCertificatePicInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
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
            parameters[0].Value = "tbCertificatePicInfo";
            parameters[1].Value = "CertificatePicID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 1;
            parameters[5].Value = OrderType;
            parameters[6].Value = strWhere;
            parameters[7].Value = showFName + ",(select cClassName from tbFeesSubjectClassInfo where FeesSubjectClassID=tbCertificateDataInfo.FeesSubjectID) as FeesSubjectName";
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
        #region 凭证操作记录
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddCertificateWorkingLog(CertificateWorkingLogInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tbCertificateWorkingLogInfo(");
            strSql.Append("CertificateID,UserID,cType,cMsg,cAppendTime)");
            strSql.Append(" values (");
            strSql.Append("@CertificateID,@UserID,@cType,@cMsg,@cAppendTime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@CertificateID", SqlDbType.Int,4),
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@cType", SqlDbType.Int,4),
					new SqlParameter("@cMsg", SqlDbType.VarChar,512),
					new SqlParameter("@cAppendTime", SqlDbType.DateTime)};
            parameters[0].Value = model.CertificateID;
            parameters[1].Value = model.UserID;
            parameters[2].Value = model.cType;
            parameters[3].Value = model.cMsg;
            parameters[4].Value = model.cAppendTime;

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
        public bool UpdateCertificateWorkingLog(CertificateWorkingLogInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbCertificateWorkingLogInfo set ");
            strSql.Append("CertificateID=@CertificateID,");
            strSql.Append("UserID=@UserID,");
            strSql.Append("cType=@cType,");
            strSql.Append("cMsg=@cMsg,");
            strSql.Append("cAppendTime=@cAppendTime");
            strSql.Append(" where CertificateWorkingLogID=@CertificateWorkingLogID");
            SqlParameter[] parameters = {
					new SqlParameter("@CertificateID", SqlDbType.Int,4),
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@cType", SqlDbType.Int,4),
					new SqlParameter("@cMsg", SqlDbType.VarChar,512),
					new SqlParameter("@cAppendTime", SqlDbType.DateTime),
					new SqlParameter("@CertificateWorkingLogID", SqlDbType.Int,4)};
            parameters[0].Value = model.CertificateID;
            parameters[1].Value = model.UserID;
            parameters[2].Value = model.cType;
            parameters[3].Value = model.cMsg;
            parameters[4].Value = model.cAppendTime;
            parameters[5].Value = model.CertificateWorkingLogID;

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
        /// 删除一条数据
        /// </summary>
        public bool DeleteCertificateWorkingLog(int CertificateWorkingLogID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbCertificateWorkingLogInfo ");
            strSql.Append(" where CertificateWorkingLogID=@CertificateWorkingLogID");
            SqlParameter[] parameters = {
					new SqlParameter("@CertificateWorkingLogID", SqlDbType.Int,4)
};
            parameters[0].Value = CertificateWorkingLogID;

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
        /// 删除一条数据
        /// </summary>
        public bool DeleteCertificateWorkingLogList(string CertificateWorkingLogIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbCertificateWorkingLogInfo ");
            strSql.Append(" where CertificateWorkingLogID in (" + CertificateWorkingLogIDlist + ")  ");
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
        public CertificateWorkingLogInfo GetCertificateWorkingLogModel(int CertificateWorkingLogID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 CertificateWorkingLogID,CertificateID,UserID,cType,cMsg,cAppendTime from tbCertificateWorkingLogInfo ");
            strSql.Append(" where CertificateWorkingLogID=@CertificateWorkingLogID");
            SqlParameter[] parameters = {
					new SqlParameter("@CertificateWorkingLogID", SqlDbType.Int,4)
};
            parameters[0].Value = CertificateWorkingLogID;

            CertificateWorkingLogInfo model = new CertificateWorkingLogInfo();
            DataSet ds = DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["CertificateWorkingLogID"].ToString() != "")
                {
                    model.CertificateWorkingLogID = int.Parse(ds.Tables[0].Rows[0]["CertificateWorkingLogID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CertificateID"].ToString() != "")
                {
                    model.CertificateID = int.Parse(ds.Tables[0].Rows[0]["CertificateID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserID"].ToString() != "")
                {
                    model.UserID = int.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["cType"].ToString() != "")
                {
                    model.cType = int.Parse(ds.Tables[0].Rows[0]["cType"].ToString());
                }
                model.cMsg = ds.Tables[0].Rows[0]["cMsg"].ToString();
                if (ds.Tables[0].Rows[0]["cAppendTime"].ToString() != "")
                {
                    model.cAppendTime = DateTime.Parse(ds.Tables[0].Rows[0]["cAppendTime"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 取指定类型记录下的记录
        /// </summary>
        /// <param name="CertificateID"></param>
        /// <param name="cType"></param>
        /// <returns></returns>
        public CertificateWorkingLogInfo GetCertificateWorkingLogUserID(int CertificateID, int cType)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 CertificateWorkingLogID,CertificateID,UserID,cType,cMsg,cAppendTime from tbCertificateWorkingLogInfo ");
            strSql.Append(" where CertificateID=@CertificateID and cType=@cType");
            SqlParameter[] parameters = {
					new SqlParameter("@CertificateID", SqlDbType.Int,4),
                    new SqlParameter("@cType", SqlDbType.Int,4)
};
            parameters[0].Value = CertificateID;
            parameters[1].Value = cType;

            CertificateWorkingLogInfo model = new CertificateWorkingLogInfo();
            DataSet ds = DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["CertificateWorkingLogID"].ToString() != "")
                {
                    model.CertificateWorkingLogID = int.Parse(ds.Tables[0].Rows[0]["CertificateWorkingLogID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CertificateID"].ToString() != "")
                {
                    model.CertificateID = int.Parse(ds.Tables[0].Rows[0]["CertificateID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserID"].ToString() != "")
                {
                    model.UserID = int.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["cType"].ToString() != "")
                {
                    model.cType = int.Parse(ds.Tables[0].Rows[0]["cType"].ToString());
                }
                model.cMsg = ds.Tables[0].Rows[0]["cMsg"].ToString();
                if (ds.Tables[0].Rows[0]["cAppendTime"].ToString() != "")
                {
                    model.cAppendTime = DateTime.Parse(ds.Tables[0].Rows[0]["cAppendTime"].ToString());
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
        public DataSet GetCertificateWorkingLogList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select CertificateWorkingLogID,CertificateID,UserID,cType,cMsg,cAppendTime,(select tbUserInfo.uName from tbUserInfo where tbCertificateWorkingLogInfo.UserID=tbUserInfo.UserID) as UserName,(select top 1 us.sName from tbStaffInfo us where us.StaffID=(select top 1 StaffID from tbUserInfo where UserID=tbCertificateWorkingLogInfo.UserID )) as UserStaffName ");
            strSql.Append(" FROM tbCertificateWorkingLogInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetCertificateWorkingLogList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" CertificateWorkingLogID,CertificateID,UserID,cType,cMsg,cAppendTime,(select tbUserInfo.uName from tbUserInfo where tbCertificateWorkingLogInfo.UserID=tbUserInfo.UserID) as UserName,(select top 1 us.sName from tbStaffInfo us where us.StaffID=(select top 1 StaffID from tbUserInfo where UserID=tbCertificateWorkingLogInfo.UserID )) as UserStaffName ");
            strSql.Append(" FROM tbCertificateWorkingLogInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString());
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataTable GetCertificateWorkingLogList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
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
            parameters[0].Value = "tbCertificateWorkingLogInfo";
            parameters[1].Value = "CertificateWorkingLogID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 1;
            parameters[5].Value = OrderType;
            parameters[6].Value = strWhere;
            parameters[7].Value = showFName + ",(select tbUserInfo.uName from tbUserInfo where tbCertificateWorkingLogInfo.UserID=tbUserInfo.UserID) as UserName,(select top 1 us.sName from tbStaffInfo us where us.StaffID=(select top 1 StaffID from tbUserInfo where UserID=tbCertificateWorkingLogInfo.UserID )) as UserStaffName";
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
        /// <summary>
        /// 取指定凭证最后一次审核时间
        /// </summary>
        /// <param name="CertificateID"></param>
        /// <returns></returns>
        public DateTime GetLastVerifyTime(int CertificateID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 cAppendTime from tbCertificateWorkingLogInfo where CertificateID=@CertificateID order by cAppendTime desc");
            SqlParameter[] parameters = {
					new SqlParameter("@CertificateID", SqlDbType.Int, 4),
                                        };
            parameters[0].Value = CertificateID;
            object obj = DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
            if (obj == null)
            {
                return DateTime.Now;
            }
            else
            {
                return DateTime.Parse(obj.ToString());
            }
        }
        #endregion

        #region 汇总
        public DataTable GetCertificate_Summary(DateTime bDate,DateTime eDate,out int cCount,out string bCode,out string eCode)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@bDate", SqlDbType.DateTime, 8),
                    new SqlParameter("@eDate", SqlDbType.DateTime, 8),
					};
            parameters[0].Value = bDate;
            parameters[1].Value = eDate;
            DataSet ds = DbHelper.ExecuteDataset(CommandType.StoredProcedure, "sp_" + BaseConfigs.GetTablePrefix + "certificate_summary", parameters);
            if (ds.Tables.Count > 1)
            {
                if (ds.Tables[0] != null)
                {
                    cCount = (int)ds.Tables[0].Rows[0][2];
                    bCode = ds.Tables[0].Rows[0][3].ToString();
                    eCode = ds.Tables[0].Rows[0][4].ToString();
                    return ds.Tables[1];
                }
                else {
                    cCount = 0;
                    bCode = "";
                    eCode = "";
                    return null;
                }
            }
            else {
                cCount = 0;
                bCode = "";
                eCode = "";
                return null;
            }
        }
        #endregion
    }
}
