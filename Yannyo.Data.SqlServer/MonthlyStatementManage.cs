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
        #region MonthlyStatementInfo
        /// <summary>
        ///   是否存在该记录
        /// </summary>
        public bool ExistsMonthlyStatementInfo(string sCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tbMonthlyStatementInfo");
            strSql.Append(" where sCode=@sCode ");
            SqlParameter[] parameters = {
					new SqlParameter("@sCode", SqlDbType.VarChar,50)};
            parameters[0].Value = sCode;

            return ((int)DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters)) > 0;
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddMonthlyStatementInfo(MonthlyStatementInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("declare @MonthlyStatementID int;");
            strSql.Append("insert into tbMonthlyStatementInfo(");
            strSql.Append("sCode,sObjectID,sObjectType,sType,sUpMoney,sThisMoney,sMoney,sToMoney,sBalanceMoney,sSteps,sBalanceType,sReceiptState,sDateTime,sState,UserID,sAppendTime)");
            strSql.Append(" values (");
            strSql.Append("@sCode,@sObjectID,@sObjectType,@sType,@sUpMoney,@sThisMoney,@sMoney,@sToMoney,@sBalanceMoney,@sSteps,@sBalanceType,@sReceiptState,@sDateTime,@sState,@UserID,@sAppendTime)");
            strSql.Append(";SET @MonthlyStatementID = SCOPE_IDENTITY();select @MonthlyStatementID;");

            if (model.MonthlyStatementDataJson != null)
            {
                //单据
                foreach (MonthlyStatementDataInfo md in model.MonthlyStatementDataJson.MonthlyStatementData)
                {
                    if (md != null)
                    {
                        strSql.Append(" insert into tbMonthlyStatementDataInfo(MonthlyStatementID,OrderID,oMoney,sRemake,sAppendTime)");
                        strSql.Append(" values(@MonthlyStatementID," + md.OrderID + "," + md.oMoney + ",'" + md.sRemake + "',getdate());");
                    }
                }
                //凭证
                foreach (MonthlyStatementAppendDataInfo mad in model.MonthlyStatementDataJson.MonthlyStatementAppendData)
                {
                    if (mad != null)
                    {
                        strSql.Append(" insert into tbMonthlyStatementAppendDataInfo(MonthlyStatementID,CertificateID,cMoney,aState,aRemake,aAppendTime)");
                        strSql.Append(" values(@MonthlyStatementID," + mad.CertificateID + "," + mad.cMoney + "," + mad.aState + ",'" + mad.aRemake + "',getdate());");
                    }
                }
                //发生金额
                foreach (MonthlyStatementAppendMoneyDataInfo mmd in model.MonthlyStatementDataJson.MonthlyStatementAppendMoneyData)
                {
                    if (mmd != null)
                    {
                        strSql.Append(" insert into tbMonthlyStatementAppendMoneyDataInfo(MonthlyStatementID,mMoney,mDateTime,mState,mRemake,mAppendTime)");
                        strSql.Append(" values(@MonthlyStatementID," + mmd.mMoney + "," + mmd.mDateTime + "," + mmd.mState + ",'" + mmd.mRemake + "',getdate());");
                    }
                }
            }

            SqlParameter[] parameters = {
					new SqlParameter("@sCode", SqlDbType.VarChar,50),
					new SqlParameter("@sObjectID", SqlDbType.Int,4),
					new SqlParameter("@sObjectType", SqlDbType.Int,4),
					new SqlParameter("@sType", SqlDbType.Int,4),
					new SqlParameter("@sUpMoney", SqlDbType.Money,8),
					new SqlParameter("@sThisMoney", SqlDbType.Money,8),
					new SqlParameter("@sMoney", SqlDbType.Money,8),
					new SqlParameter("@sToMoney", SqlDbType.Money,8),
					new SqlParameter("@sBalanceMoney", SqlDbType.Money,8),
					new SqlParameter("@sSteps", SqlDbType.Int,4),
					new SqlParameter("@sBalanceType", SqlDbType.Int,4),
					new SqlParameter("@sReceiptState", SqlDbType.Int,4),
					new SqlParameter("@sDateTime", SqlDbType.DateTime),
					new SqlParameter("@sState", SqlDbType.Int,4),
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@sAppendTime", SqlDbType.DateTime)};
            parameters[0].Value = model.sCode;
            parameters[1].Value = model.sObjectID;
            parameters[2].Value = model.sObjectType;
            parameters[3].Value = model.sType;
            parameters[4].Value = model.sUpMoney;
            parameters[5].Value = model.sThisMoney;
            parameters[6].Value = model.sMoney;
            parameters[7].Value = model.sToMoney;
            parameters[8].Value = model.sBalanceMoney;
            parameters[9].Value = model.sSteps;
            parameters[10].Value = model.sBalanceType;
            parameters[11].Value = model.sReceiptState;
            parameters[12].Value = model.sDateTime;
            parameters[13].Value = model.sState;
            parameters[14].Value = model.UserID;
            parameters[15].Value = model.sAppendTime;

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
        public void UpdateMonthlyStatementInfo(MonthlyStatementInfo model)
        {
            string tID = "";
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbMonthlyStatementInfo set ");
            strSql.Append("sCode=@sCode,");
            strSql.Append("sObjectID=@sObjectID,");
            strSql.Append("sObjectType=@sObjectType,");
            strSql.Append("sType=@sType,");
            strSql.Append("sUpMoney=@sUpMoney,");
            strSql.Append("sThisMoney=@sThisMoney,");
            strSql.Append("sMoney=@sMoney,");
            strSql.Append("sToMoney=@sToMoney,");
            strSql.Append("sBalanceMoney=@sBalanceMoney,");
            strSql.Append("sSteps=@sSteps,");
            strSql.Append("sBalanceType=@sBalanceType,");
            strSql.Append("sReceiptState=@sReceiptState,");
            strSql.Append("sDateTime=@sDateTime,");
            strSql.Append("sState=@sState,");
            strSql.Append("UserID=@UserID,");
            strSql.Append("sAppendTime=@sAppendTime");
            strSql.Append(" where MonthlyStatementID=@MonthlyStatementID ;");


            if (model.MonthlyStatementDataJson != null)
            {
                tID = "";
                //单据
                foreach (MonthlyStatementDataInfo md in model.MonthlyStatementDataJson.MonthlyStatementData)
                {
                    if (md != null)
                    {
                        if (md.MonthlyStatementDataID > 0)
                        {
                            strSql.Append(" update tbMonthlyStatementDataInfo set OrderID=" + md.OrderID + ",oMoney=" + md.oMoney + ",sRemake='" + md.sRemake + "' ");
                            strSql.Append(" where MonthlyStatementID=@MonthlyStatementID and MonthlyStatementDataID=" + md.MonthlyStatementDataID + ";");
                            tID += "'" + md.MonthlyStatementDataID + "',";
                        }
                    }
                }
                if (tID.Trim() != "")
                {
                    tID = Utils.ReSQLSetTxt(tID);
                    //删除单据
                    strSql.Append(" declare @OldOrderList Table(OrderID int);");
                    strSql.Append(" insert into @OldOrderList(OrderID) select OrderID from tbMonthlyStatementDataInfo where MonthlyStatementDataID not in (" + tID + ") and MonthlyStatementID=@MonthlyStatementID;");
                    strSql.Append(" delete from tbMonthlyStatementDataInfo where MonthlyStatementDataID not in (" + tID + ") and MonthlyStatementID=@MonthlyStatementID ;");
                    //更改单据状态为等待对账
                    strSql.Append(" update tbOrderInfo set oSteps=5 where OrderID in(select OrderID from @OldOrderList);");
                }

                //单据
                foreach (MonthlyStatementDataInfo md in model.MonthlyStatementDataJson.MonthlyStatementData)
                {
                    if (md != null)
                    {
                        if (md.MonthlyStatementDataID <= 0)
                        {
                            strSql.Append(" insert into tbMonthlyStatementDataInfo(MonthlyStatementID,OrderID,oMoney,sRemake,sAppendTime)");
                            strSql.Append(" values(@MonthlyStatementID," + md.OrderID + "," + md.oMoney + ",'" + md.sRemake + "',getdate());");
                        }
                    }
                }

                //凭证
                tID = "";
                foreach (MonthlyStatementAppendDataInfo mad in model.MonthlyStatementDataJson.MonthlyStatementAppendData)
                {
                    if (mad != null)
                    {
                        if (mad.MonthlyStatementAppendDataID > 0)
                        {
                            strSql.Append(" update tbMonthlyStatementAppendDataInfo set CertificateID=" + mad.CertificateID + ",cMoney=" + mad.cMoney + ",aState=" + mad.aState + ",aRemake='" + mad.aRemake + "' ");
                            strSql.Append(" where MonthlyStatementID=@MonthlyStatementID and MonthlyStatementAppendDataID=" + mad.MonthlyStatementAppendDataID + ";");
                            tID += "'" + mad.MonthlyStatementAppendDataID + "',";
                        }
                    }
                }
                if (tID.Trim() != "")
                {
                    tID = Utils.ReSQLSetTxt(tID);
                    strSql.Append("delete from tbMonthlyStatementAppendDataInfo where MonthlyStatementAppendDataID not in (" + tID + ") and MonthlyStatementID=@MonthlyStatementID ;");
                }
                //凭证
                foreach (MonthlyStatementAppendDataInfo mad in model.MonthlyStatementDataJson.MonthlyStatementAppendData)
                {
                    if (mad != null)
                    {
                        if (mad.MonthlyStatementAppendDataID <= 0)
                        {
                            strSql.Append(" insert into tbMonthlyStatementAppendDataInfo(MonthlyStatementID,CertificateID,cMoney,aState,aRemake,aAppendTime)");
                            strSql.Append(" values(@MonthlyStatementID," + mad.CertificateID + "," + mad.cMoney + "," + mad.aState + ",'" + mad.aRemake + "',getdate());");
                        }
                    }
                }

                //发生金额
                tID = "";
                foreach (MonthlyStatementAppendMoneyDataInfo mmd in model.MonthlyStatementDataJson.MonthlyStatementAppendMoneyData)
                {
                    if (mmd != null)
                    {
                        if (mmd.MonthlyStatementAppendMoneyDataID > 0)
                        {
                            strSql.Append(" update tbMonthlyStatementAppendMoneyDataInfo set  mMoney=" + mmd.mMoney + ",mDateTime='" + mmd.mDateTime + "',mRemake='" + mmd.mRemake + "' ");
                            strSql.Append(" where MonthlyStatementID=@MonthlyStatementID and MonthlyStatementAppendMoneyDataID=" + mmd.MonthlyStatementAppendMoneyDataID + ";");
                            tID += "'" + mmd.MonthlyStatementAppendMoneyDataID + "',";
                        }
                    }
                }
                if (tID.Trim() != "")
                {
                    tID = Utils.ReSQLSetTxt(tID);
                    strSql.Append("delete from tbMonthlyStatementAppendMoneyDataInfo where MonthlyStatementAppendMoneyDataID not in (" + tID + ") and MonthlyStatementID=@MonthlyStatementID ;");
                }
                //发生金额
                foreach (MonthlyStatementAppendMoneyDataInfo mmd in model.MonthlyStatementDataJson.MonthlyStatementAppendMoneyData)
                {
                    if (mmd != null)
                    {
                        if (mmd.MonthlyStatementAppendMoneyDataID <= 0)
                        {
                            strSql.Append(" insert into tbMonthlyStatementAppendMoneyDataInfo(MonthlyStatementID,mMoney,mDateTime,mState,mRemake,mAppendTime)");
                            strSql.Append(" values(@MonthlyStatementID," + mmd.mMoney + ",'" + mmd.mDateTime + "'," + mmd.mState + ",'" + mmd.mRemake + "',getdate());");
                        }
                    }
                }
            }


            SqlParameter[] parameters = {
					new SqlParameter("@MonthlyStatementID", SqlDbType.Int,4),
					new SqlParameter("@sCode", SqlDbType.VarChar,50),
					new SqlParameter("@sObjectID", SqlDbType.Int,4),
					new SqlParameter("@sObjectType", SqlDbType.Int,4),
					new SqlParameter("@sType", SqlDbType.Int,4),
					new SqlParameter("@sUpMoney", SqlDbType.Money,8),
					new SqlParameter("@sThisMoney", SqlDbType.Money,8),
					new SqlParameter("@sMoney", SqlDbType.Money,8),
					new SqlParameter("@sToMoney", SqlDbType.Money,8),
					new SqlParameter("@sBalanceMoney", SqlDbType.Money,8),
					new SqlParameter("@sSteps", SqlDbType.Int,4),
					new SqlParameter("@sBalanceType", SqlDbType.Int,4),
					new SqlParameter("@sReceiptState", SqlDbType.Int,4),
					new SqlParameter("@sDateTime", SqlDbType.DateTime),
					new SqlParameter("@sState", SqlDbType.Int,4),
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@sAppendTime", SqlDbType.DateTime)};
            parameters[0].Value = model.MonthlyStatementID;
            parameters[1].Value = model.sCode;
            parameters[2].Value = model.sObjectID;
            parameters[3].Value = model.sObjectType;
            parameters[4].Value = model.sType;
            parameters[5].Value = model.sUpMoney;
            parameters[6].Value = model.sThisMoney;
            parameters[7].Value = model.sMoney;
            parameters[8].Value = model.sToMoney;
            parameters[9].Value = model.sBalanceMoney;
            parameters[10].Value = model.sSteps;
            parameters[11].Value = model.sBalanceType;
            parameters[12].Value = model.sReceiptState;
            parameters[13].Value = model.sDateTime;
            parameters[14].Value = model.sState;
            parameters[15].Value = model.UserID;
            parameters[16].Value = model.sAppendTime;

            DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        /// <summary>
        /// 更新对账单步骤
        /// </summary>
        /// <param name="MonthlyStatementID"></param>
        /// <param name="sSteps"></param>
        public void UpdateMonthlyStatementSteps(int MonthlyStatementID, int sSteps)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbMonthlyStatementInfo set sSteps=@sSteps where MonthlyStatementID=@MonthlyStatementID and sSteps<@sSteps;");
            //进入对账
            if (sSteps == 0)
            {
                strSql.Append("update tbOrderInfo set oSteps=6 where OrderID in(select OrderID from tbMonthlyStatementDataInfo where MonthlyStatementID=@MonthlyStatementID);");
                strSql.Append("insert into tbOrderWorkingLogInfo(OrderID,UserID,oType,oMsg,pAppendTime) select OrderID,0,11,('对账单:'+(select sCode from tbMonthlyStatementInfo where MonthlyStatementID=@MonthlyStatementID)),getdate() from tbMonthlyStatementDataInfo where MonthlyStatementID=@MonthlyStatementID;");
            }
            //对账确认,更新单据状态
            if (sSteps==1)
            {
                strSql.Append("update tbOrderInfo set oSteps=7 where OrderID in(select OrderID from tbMonthlyStatementDataInfo where MonthlyStatementID=@MonthlyStatementID);");
                strSql.Append("insert into tbOrderWorkingLogInfo(OrderID,UserID,oType,oMsg,pAppendTime) select OrderID,0,12,('对账单:'+(select sCode from tbMonthlyStatementInfo where MonthlyStatementID=@MonthlyStatementID)),getdate() from tbMonthlyStatementDataInfo where MonthlyStatementID=@MonthlyStatementID;");
            }
            //完成收付款
            if (sSteps == 2)
            {
                strSql.Append("update tbOrderInfo set oSteps=8 where OrderID in(select OrderID from tbMonthlyStatementDataInfo where MonthlyStatementID=@MonthlyStatementID);");
                strSql.Append("insert into tbOrderWorkingLogInfo(OrderID,UserID,oType,oMsg,pAppendTime) select OrderID,0,13,('对账单:'+(select sCode from tbMonthlyStatementInfo where MonthlyStatementID=@MonthlyStatementID)),getdate() from tbMonthlyStatementDataInfo where MonthlyStatementID=@MonthlyStatementID;");
            }
            //已结账
            if (sSteps == 3)
            {
                strSql.Append("update tbOrderInfo set oSteps=9 where OrderID in(select OrderID from tbMonthlyStatementDataInfo where MonthlyStatementID=@MonthlyStatementID);");
                strSql.Append("insert into tbOrderWorkingLogInfo(OrderID,UserID,oType,oMsg,pAppendTime) select OrderID,0,14,('对账单:'+(select sCode from tbMonthlyStatementInfo where MonthlyStatementID=@MonthlyStatementID)),getdate() from tbMonthlyStatementDataInfo where MonthlyStatementID=@MonthlyStatementID;");
            }

            SqlParameter[] parameters = {
					new SqlParameter("@MonthlyStatementID", SqlDbType.Int,4),
                                        new SqlParameter("@sSteps", SqlDbType.Int,4)};
            parameters[0].Value = MonthlyStatementID;
            parameters[1].Value = sSteps;

            DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        /// <summary>
        /// 更新凭证系统状态,只允许作废
        /// </summary>
        /// <param name="MonthlyStatementID"></param>
        /// <param name="state">state只能等于1</param>
        public void UpdateMonthlyStatementState(int MonthlyStatementID,int state)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbMonthlyStatementInfo set sState=@sState where sState = 0 and MonthlyStatementID=@MonthlyStatementID ;");

            //更新单据状态,回待对账状态
            if (state == 1)
            {
                strSql.Append("update tbOrderInfo set oSteps=5 where OrderID in(select OrderID from tbMonthlyStatementDataInfo where MonthlyStatementID=@MonthlyStatementID);");
                strSql.Append("insert into tbOrderWorkingLogInfo(OrderID,UserID,oType,oMsg,pAppendTime) select OrderID,0,15,('对账单:'+(select sCode from tbMonthlyStatementInfo where MonthlyStatementID=@MonthlyStatementID)),getdate() from tbMonthlyStatementDataInfo where MonthlyStatementID=@MonthlyStatementID;");
            }
            SqlParameter[] parameters = {
					new SqlParameter("@MonthlyStatementID", SqlDbType.Int,4),
                                        new SqlParameter("@sState", SqlDbType.Int,4)};
            parameters[0].Value = MonthlyStatementID;
            parameters[1].Value = state;

            DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void DeleteMonthlyStatementInfo(int MonthlyStatementID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbMonthlyStatementInfo ");
            strSql.Append(" where MonthlyStatementID=@MonthlyStatementID ");
            SqlParameter[] parameters = {
					new SqlParameter("@MonthlyStatementID", SqlDbType.Int,4)};
            parameters[0].Value = MonthlyStatementID;

            DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public MonthlyStatementInfo GetMonthlyStatementInfoModel(int MonthlyStatementID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 MonthlyStatementID,sCode,sObjectID,sObjectType,sType,sUpMoney,sThisMoney,sMoney,sToMoney,sBalanceMoney,sSteps,sBalanceType,sReceiptState,sDateTime,sState,UserID,sAppendTime, "+
                "(case when sObjectType=0 then (select sName from tbStoresInfo where StoresID=sObjectID) " +//客户
                " when sObjectType=1 then (select sName from tbSupplierInfo where SupplierID=sObjectID) " +//供应商
                " when sObjectType=2 then (select sName from tbStaffInfo where StaffID=sObjectID) " +//人员
                " when sObjectType=3 then (select pName from tbPaymentSystemInfo where PaymentSystemID=sObjectID) " +//超市系统
                "end) as sObjectName, " +
                "(select top 1 tbMonthlyStatementWorkingLogInfo.mAppendTime from tbMonthlyStatementWorkingLogInfo where tbMonthlyStatementWorkingLogInfo.MonthlyStatementID=tbMonthlyStatementInfo.MonthlyStatementID and tbMonthlyStatementWorkingLogInfo.mType=5 order by tbMonthlyStatementWorkingLogInfo.mAppendTime desc) as LastPrintDateTime " +
                "from tbMonthlyStatementInfo ");
            strSql.Append(" where MonthlyStatementID=@MonthlyStatementID ");
            SqlParameter[] parameters = {
					new SqlParameter("@MonthlyStatementID", SqlDbType.Int,4)};
            parameters[0].Value = MonthlyStatementID;

            MonthlyStatementInfo model = new MonthlyStatementInfo();
            DataSet ds = DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["MonthlyStatementID"].ToString() != "")
                {
                    model.MonthlyStatementID = int.Parse(ds.Tables[0].Rows[0]["MonthlyStatementID"].ToString());
                }
                model.sCode = ds.Tables[0].Rows[0]["sCode"].ToString();
                model.sObjectName = ds.Tables[0].Rows[0]["sObjectName"].ToString();
                if (ds.Tables[0].Rows[0]["sObjectID"].ToString() != "")
                {
                    model.sObjectID = int.Parse(ds.Tables[0].Rows[0]["sObjectID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["sObjectType"].ToString() != "")
                {
                    model.sObjectType = int.Parse(ds.Tables[0].Rows[0]["sObjectType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["sType"].ToString() != "")
                {
                    model.sType = int.Parse(ds.Tables[0].Rows[0]["sType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["sUpMoney"].ToString() != "")
                {
                    model.sUpMoney = decimal.Parse(ds.Tables[0].Rows[0]["sUpMoney"].ToString());
                }
                if (ds.Tables[0].Rows[0]["sThisMoney"].ToString() != "")
                {
                    model.sThisMoney = decimal.Parse(ds.Tables[0].Rows[0]["sThisMoney"].ToString());
                }
                if (ds.Tables[0].Rows[0]["sMoney"].ToString() != "")
                {
                    model.sMoney = decimal.Parse(ds.Tables[0].Rows[0]["sMoney"].ToString());
                }
                if (ds.Tables[0].Rows[0]["sToMoney"].ToString() != "")
                {
                    model.sToMoney = decimal.Parse(ds.Tables[0].Rows[0]["sToMoney"].ToString());
                }
                if (ds.Tables[0].Rows[0]["sBalanceMoney"].ToString() != "")
                {
                    model.sBalanceMoney = decimal.Parse(ds.Tables[0].Rows[0]["sBalanceMoney"].ToString());
                }
                if (ds.Tables[0].Rows[0]["sSteps"].ToString() != "")
                {
                    model.sSteps = int.Parse(ds.Tables[0].Rows[0]["sSteps"].ToString());
                }
                if (ds.Tables[0].Rows[0]["sBalanceType"].ToString() != "")
                {
                    model.sBalanceType = int.Parse(ds.Tables[0].Rows[0]["sBalanceType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["sReceiptState"].ToString() != "")
                {
                    model.sReceiptState = int.Parse(ds.Tables[0].Rows[0]["sReceiptState"].ToString());
                }
                if (ds.Tables[0].Rows[0]["sDateTime"].ToString() != "")
                {
                    model.sDateTime = DateTime.Parse(ds.Tables[0].Rows[0]["sDateTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["LastPrintDateTime"].ToString() != "")
                {
                    model.LastPrintDateTime = DateTime.Parse(ds.Tables[0].Rows[0]["LastPrintDateTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["sState"].ToString() != "")
                {
                    model.sState = int.Parse(ds.Tables[0].Rows[0]["sState"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserID"].ToString() != "")
                {
                    model.UserID = int.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["sAppendTime"].ToString() != "")
                {
                    model.sAppendTime = DateTime.Parse(ds.Tables[0].Rows[0]["sAppendTime"].ToString());
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
        public DataSet GetMonthlyStatementInfoList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select MonthlyStatementID,sCode,sObjectID,sObjectType,sType,sUpMoney,sThisMoney,sMoney,sToMoney,sBalanceMoney,sSteps,sBalanceType,sReceiptState,sDateTime,sState,UserID,sAppendTime,"+
               "(case when sObjectType=0 then (select sName from tbStoresInfo where StoresID=sObjectID) " +//客户
                " when sObjectType=1 then (select sName from tbSupplierInfo where SupplierID=sObjectID) " +//供应商
                " when sObjectType=2 then (select sName from tbStaffInfo where StaffID=sObjectID) " +//人员
                " when sObjectType=3 then (select pName from tbPaymentSystemInfo where PaymentSystemID=sObjectID) " +//超市系统
                "end) as sObjectName " +
                "");
            strSql.Append(" FROM tbMonthlyStatementInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelper.ExecuteDataset(CommandType.Text,strSql.ToString());
        }
        /// <summary>
        /// 合计本期金额
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public decimal GetMonthlyStatementInfoListSumMoney(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select isnull(sum(isnull(sThisMoney,0)),0)  ");
            strSql.Append(" FROM tbMonthlyStatementInfo ");
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
        /// 获得前几行数据
        /// </summary>
        public DataSet GetMonthlyStatementInfoList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" MonthlyStatementID,sCode,sObjectID,sObjectType,sType,sUpMoney,sThisMoney,sMoney,sToMoney,sBalanceMoney,sSteps,sBalanceType,sReceiptState,sDateTime,sState,UserID,sAppendTime,"+
                "(case when sObjectType=0 then (select sName from tbStoresInfo where StoresID=sObjectID) " +//客户
                " when sObjectType=1 then (select sName from tbSupplierInfo where SupplierID=sObjectID) " +//供应商
                " when sObjectType=2 then (select sName from tbStaffInfo where StaffID=sObjectID) " +//人员
                " when sObjectType=3 then (select pName from tbPaymentSystemInfo where PaymentSystemID=sObjectID) " +//超市系统
                "end) as sObjectName " +
                "");
            strSql.Append(" FROM tbMonthlyStatementInfo ");
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
        public DataTable GetMonthlyStatementInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
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
            parameters[0].Value = "tbMonthlyStatementInfo";
            parameters[1].Value = "MonthlyStatementID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 1;
            parameters[5].Value = OrderType;
            parameters[6].Value = strWhere;
            parameters[7].Value = showFName+",(case when sObjectType=0 then (select sName from tbStoresInfo where StoresID=sObjectID) " +//客户
                " when sObjectType=1 then (select sName from tbSupplierInfo where SupplierID=sObjectID) " +//供应商
                " when sObjectType=2 then (select sName from tbStaffInfo where StaffID=sObjectID) " +//人员
                " when sObjectType=3 then (select pName from tbPaymentSystemInfo where PaymentSystemID=sObjectID) " +//超市系统
                "end) as sObjectName ";
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
        /// 取指定对象上期余额
        /// </summary>
        /// <param name="sObjectID"></param>
        /// <param name="sObjectType"></param>
        /// <param name="sType"></param>
        /// <returns></returns>
        public decimal GetSObjectUpMoney(int sObjectID,int sObjectType, int sType)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 isnull(sBalanceMoney,0) from tbMonthlyStatementInfo where sObjectID=@sObjectID and sObjectType=@sObjectType and sType=@sType and sSteps=3 and sState=0 order by  sDateTime desc");
            SqlParameter[] parameters = {
                    new SqlParameter("@sObjectID", SqlDbType.Int, 4),
                    new SqlParameter("@sObjectType", SqlDbType.Int, 4),
                    new SqlParameter("@sType", SqlDbType.Int, 4),
                                         };
            parameters[0].Value = sObjectID;
            parameters[1].Value = sObjectType;
            parameters[2].Value = sType;

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
        #endregion

        #region MonthlyStatementDataInfo
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistsMonthlyStatementDataInfo(int MonthlyStatementID, int OrderID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tbMonthlyStatementDataInfo");
            strSql.Append(" where MonthlyStatementID=@MonthlyStatementID and OrderID=@OrderID");
            SqlParameter[] parameters = {
					new SqlParameter("@MonthlyStatementID", SqlDbType.Int,4),
                                        new SqlParameter("@OrderID", SqlDbType.Int,4)};
            parameters[0].Value = MonthlyStatementID;
            parameters[1].Value = OrderID;

            return ((int)DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters)) > 0;
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddMonthlyStatementDataInfo(MonthlyStatementDataInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tbMonthlyStatementDataInfo(");
            strSql.Append("MonthlyStatementID,OrderID,oMoney,sRemake,sAppendTime)");
            strSql.Append(" values (");
            strSql.Append("@MonthlyStatementID,@OrderID,@oMoney,@sRemake,@sAppendTime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@MonthlyStatementID", SqlDbType.Int,4),
					new SqlParameter("@OrderID", SqlDbType.Int,4),
					new SqlParameter("@oMoney", SqlDbType.Money,8),
					new SqlParameter("@sRemake", SqlDbType.VarChar,512),
					new SqlParameter("@sAppendTime", SqlDbType.DateTime)};
            parameters[0].Value = model.MonthlyStatementID;
            parameters[1].Value = model.OrderID;
            parameters[2].Value = model.oMoney;
            parameters[3].Value = model.sRemake;
            parameters[4].Value = model.sAppendTime;

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
        public void UpdateMonthlyStatementDataInfo(MonthlyStatementDataInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbMonthlyStatementDataInfo set ");
            strSql.Append("MonthlyStatementID=@MonthlyStatementID,");
            strSql.Append("OrderID=@OrderID,");
            strSql.Append("oMoney=@oMoney,");
            strSql.Append("sRemake=@sRemake,");
            strSql.Append("sAppendTime=@sAppendTime");
            strSql.Append(" where MonthlyStatementDataID=@MonthlyStatementDataID ");
            SqlParameter[] parameters = {
					new SqlParameter("@MonthlyStatementDataID", SqlDbType.Int,4),
					new SqlParameter("@MonthlyStatementID", SqlDbType.Int,4),
					new SqlParameter("@OrderID", SqlDbType.Int,4),
					new SqlParameter("@oMoney", SqlDbType.Money,8),
					new SqlParameter("@sRemake", SqlDbType.VarChar,512),
					new SqlParameter("@sAppendTime", SqlDbType.DateTime)};
            parameters[0].Value = model.MonthlyStatementDataID;
            parameters[1].Value = model.MonthlyStatementID;
            parameters[2].Value = model.OrderID;
            parameters[3].Value = model.oMoney;
            parameters[4].Value = model.sRemake;
            parameters[5].Value = model.sAppendTime;

            DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString());
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void DeleteMonthlyStatementDataInfo(int MonthlyStatementDataID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbMonthlyStatementDataInfo ");
            strSql.Append(" where MonthlyStatementDataID=@MonthlyStatementDataID ");
            SqlParameter[] parameters = {
					new SqlParameter("@MonthlyStatementDataID", SqlDbType.Int,4)};
            parameters[0].Value = MonthlyStatementDataID;

            DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString());
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public MonthlyStatementDataInfo GetMonthlyStatementDataInfoModel(int MonthlyStatementDataID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 MonthlyStatementDataID,MonthlyStatementID,OrderID,oMoney,sRemake,sAppendTime from tbMonthlyStatementDataInfo ");
            strSql.Append(" where MonthlyStatementDataID=@MonthlyStatementDataID ");
            SqlParameter[] parameters = {
					new SqlParameter("@MonthlyStatementDataID", SqlDbType.Int,4)};
            parameters[0].Value = MonthlyStatementDataID;

            MonthlyStatementDataInfo model = new MonthlyStatementDataInfo();
            DataSet ds = DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["MonthlyStatementDataID"].ToString() != "")
                {
                    model.MonthlyStatementDataID = int.Parse(ds.Tables[0].Rows[0]["MonthlyStatementDataID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["MonthlyStatementID"].ToString() != "")
                {
                    model.MonthlyStatementID = int.Parse(ds.Tables[0].Rows[0]["MonthlyStatementID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OrderID"].ToString() != "")
                {
                    model.OrderID = int.Parse(ds.Tables[0].Rows[0]["OrderID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["oMoney"].ToString() != "")
                {
                    model.oMoney = decimal.Parse(ds.Tables[0].Rows[0]["oMoney"].ToString());
                }
                model.sRemake = ds.Tables[0].Rows[0]["sRemake"].ToString();
                if (ds.Tables[0].Rows[0]["sAppendTime"].ToString() != "")
                {
                    model.sAppendTime = DateTime.Parse(ds.Tables[0].Rows[0]["sAppendTime"].ToString());
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
        public DataSet GetMonthlyStatementDataInfoList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select m.MonthlyStatementDataID,m.MonthlyStatementID,m.oMoney,m.sRemake,m.sAppendTime,o.OrderID,o.oOrderNum,o.oType,o.StoresID,o.oCustomersName,o.oCustomersContact,o.oCustomersTel,o.oCustomersAddress,o.oCustomersOrderID,o.oCustomersNameB,o.StaffID,o.UserID,o.oAppendTime,o.oOrderDateTime,o.oState,o.oSteps,o.oPrepay,(case  " +
                " when  o.oType in(1,2) then " +
                " (select su.sName from tbSupplierInfo su where su.SupplierID=o.StoresID) " +
                " when  o.oType in(3,4,5,6,7,11) then " +
                " (select so.sName from tbStoresInfo so where so.StoresID=o.StoresID) " +
                " end) as StoresSupplierName," +
                " isnull((select sum(isnull(ol.oMoney,0)) from tbOrderListInfo ol where ol.OrderID=o.OrderID and ol.oWorkType=(select max(oll.oWorkType) from tbOrderListInfo oll where oll.OrderID=o.OrderID)),0) as SumMoney," +
                "(select s.sName from tbStaffInfo s where s.StaffID=o.StaffID) as StaffName," +
                "(select u.uName from tbUserInfo u where u.UserID=o.UserID) as UserName," +
                "(select top 1 us.sName from tbStaffInfo us where us.StaffID=(select top 1 StaffID from tbUserInfo where UserID=o.UserID )) as UserStaffName," +
                "(select top 1 w.pAppendTime from tbOrderWorkingLogInfo w where w.OrderID=o.OrderID and w.oType=6 order by pAppendTime desc) as PrintTime  ");
            strSql.Append(" FROM tbMonthlyStatementDataInfo as m left join tbOrderInfo o on m.OrderID=o.OrderID ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelper.ExecuteDataset(CommandType.Text,strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetMonthlyStatementDataInfoList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" m.MonthlyStatementDataID,m.MonthlyStatementID,m.oMoney,m.sRemake,m.sAppendTime,o.OrderID,o.oOrderNum,o.oType,o.StoresID,o.oCustomersName,o.oCustomersContact,o.oCustomersTel,o.oCustomersAddress,o.oCustomersOrderID,o.oCustomersNameB,o.StaffID,o.UserID,o.oAppendTime,o.oOrderDateTime,o.oState,o.oSteps,o.oPrepay,(case  " +
                " when  o.oType in(1,2) then " +
                " (select su.sName from tbSupplierInfo su where su.SupplierID=o.StoresID) " +
                " when  o.oType in(3,4,5,6,7,11) then " +
                " (select so.sName from tbStoresInfo so where so.StoresID=o.StoresID) " +
                " end) as StoresSupplierName," +
                " isnull((select sum(isnull(ol.oMoney,0)) from tbOrderListInfo ol where ol.OrderID=o.OrderID and ol.oWorkType=(select max(oll.oWorkType) from tbOrderListInfo oll where oll.OrderID=o.OrderID)),0) as SumMoney," +
                "(select s.sName from tbStaffInfo s where s.StaffID=o.StaffID) as StaffName," +
                "(select u.uName from tbUserInfo u where u.UserID=o.UserID) as UserName," +
                "(select top 1 us.sName from tbStaffInfo us where us.StaffID=(select top 1 StaffID from tbUserInfo where UserID=o.UserID )) as UserStaffName," +
                "(select top 1 w.pAppendTime from tbOrderWorkingLogInfo w where w.OrderID=o.OrderID and w.oType=6 order by pAppendTime desc) as PrintTime  ");
            strSql.Append(" FROM tbMonthlyStatementDataInfo as m left join tbOrderInfo o on m.OrderID=o.OrderID ");
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
        public DataTable GetMonthlyStatementDataInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
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
            parameters[0].Value = "tbMonthlyStatementDataInfo";
            parameters[1].Value = "MonthlyStatementDataID";
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

        #region MonthlyStatementAppendDataInfo
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistsMonthlyStatementAppendDataInfo(int MonthlyStatementID, int CertificateID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tbMonthlyStatementAppendDataInfo");
            strSql.Append(" where MonthlyStatementID=@MonthlyStatementID and  CertificateID=@CertificateID");
            SqlParameter[] parameters = {
					new SqlParameter("@MonthlyStatementID", SqlDbType.Int,4),
                                        new SqlParameter("@CertificateID", SqlDbType.Int,4)};
            parameters[0].Value = MonthlyStatementID;
            parameters[1].Value = CertificateID;

            return ((int)DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters)) > 0;
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddMonthlyStatementAppendDataInfo(MonthlyStatementAppendDataInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tbMonthlyStatementAppendDataInfo(");
            strSql.Append("MonthlyStatementID,CertificateID,aState,aRemake,aAppendTime,cMoney)");
            strSql.Append(" values (");
            strSql.Append("@MonthlyStatementID,@CertificateID,@aState,@aRemake,@aAppendTime,@cMoney)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@MonthlyStatementID", SqlDbType.Int,4),
					new SqlParameter("@CertificateID", SqlDbType.Int,4),
					new SqlParameter("@aState", SqlDbType.Int,4),
					new SqlParameter("@aRemake", SqlDbType.VarChar,512),
					new SqlParameter("@aAppendTime", SqlDbType.DateTime),
					new SqlParameter("@cMoney", SqlDbType.Decimal)};
            parameters[0].Value = model.MonthlyStatementID;
            parameters[1].Value = model.CertificateID;
            parameters[2].Value = model.aState;
            parameters[3].Value = model.aRemake;
            parameters[4].Value = model.aAppendTime;
            parameters[5].Value = model.cMoney;

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
        public void UpdateMonthlyStatementAppendDataInfo(MonthlyStatementAppendDataInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbMonthlyStatementAppendDataInfo set ");
            strSql.Append("MonthlyStatementID=@MonthlyStatementID,");
            strSql.Append("CertificateID=@CertificateID,");
            strSql.Append("aState=@aState,");
            strSql.Append("aRemake=@aRemake,");
            strSql.Append("aAppendTime=@aAppendTime,");
            strSql.Append("cMoney=@cMoney");
            strSql.Append(" where MonthlyStatementAppendDataID=@MonthlyStatementAppendDataID ");
            SqlParameter[] parameters = {
					new SqlParameter("@MonthlyStatementAppendDataID", SqlDbType.Int,4),
					new SqlParameter("@MonthlyStatementID", SqlDbType.Int,4),
					new SqlParameter("@CertificateID", SqlDbType.Int,4),
					new SqlParameter("@aState", SqlDbType.Int,4),
					new SqlParameter("@aRemake", SqlDbType.VarChar,512),
					new SqlParameter("@aAppendTime", SqlDbType.DateTime),
					new SqlParameter("@cMoney", SqlDbType.Decimal)};
            parameters[0].Value = model.MonthlyStatementAppendDataID;
            parameters[1].Value = model.MonthlyStatementID;
            parameters[2].Value = model.CertificateID;
            parameters[3].Value = model.aState;
            parameters[4].Value = model.aRemake;
            parameters[5].Value = model.aAppendTime;
            parameters[6].Value = model.cMoney;

            DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString());
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void DeleteMonthlyStatementAppendDataInfo(int MonthlyStatementAppendDataID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbMonthlyStatementAppendDataInfo ");
            strSql.Append(" where MonthlyStatementAppendDataID=@MonthlyStatementAppendDataID ");
            SqlParameter[] parameters = {
					new SqlParameter("@MonthlyStatementAppendDataID", SqlDbType.Int,4)};
            parameters[0].Value = MonthlyStatementAppendDataID;

            DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString());
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public MonthlyStatementAppendDataInfo GetMonthlyStatementAppendDataInfoModel(int MonthlyStatementAppendDataID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 MonthlyStatementAppendDataID,MonthlyStatementID,CertificateID,aState,aRemake,aAppendTime,cMoney from tbMonthlyStatementAppendDataInfo ");
            strSql.Append(" where MonthlyStatementAppendDataID=@MonthlyStatementAppendDataID ");
            SqlParameter[] parameters = {
					new SqlParameter("@MonthlyStatementAppendDataID", SqlDbType.Int,4)};
            parameters[0].Value = MonthlyStatementAppendDataID;

            MonthlyStatementAppendDataInfo model = new MonthlyStatementAppendDataInfo();
            DataSet ds = DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["MonthlyStatementAppendDataID"].ToString() != "")
                {
                    model.MonthlyStatementAppendDataID = int.Parse(ds.Tables[0].Rows[0]["MonthlyStatementAppendDataID"].ToString());
                }
                
                if (ds.Tables[0].Rows[0]["cMoney"].ToString() != "")
                {
                    model.cMoney = decimal.Parse(ds.Tables[0].Rows[0]["cMoney"].ToString());
                }
                if (ds.Tables[0].Rows[0]["MonthlyStatementID"].ToString() != "")
                {
                    model.MonthlyStatementID = int.Parse(ds.Tables[0].Rows[0]["MonthlyStatementID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CertificateID"].ToString() != "")
                {
                    model.CertificateID = int.Parse(ds.Tables[0].Rows[0]["CertificateID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["aState"].ToString() != "")
                {
                    model.aState = int.Parse(ds.Tables[0].Rows[0]["aState"].ToString());
                }
                model.aRemake = ds.Tables[0].Rows[0]["aRemake"].ToString();
                if (ds.Tables[0].Rows[0]["aAppendTime"].ToString() != "")
                {
                    model.aAppendTime = DateTime.Parse(ds.Tables[0].Rows[0]["aAppendTime"].ToString());
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
        public DataSet GetMonthlyStatementAppendDataInfoList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select m.MonthlyStatementAppendDataID,m.MonthlyStatementID,m.aState,m.aRemake,m.aAppendTime,m.cMoney,c.cNumber,c.CertificateID,c.cCode,c.cMoney,c.cType,c.UserID,c.StaffID,c.cRemake,c.cObject,c.cObjectID,c.cState,c.cDateTime,c.cAppendTime,c.toObject,c.toObjectID,c.BankID," +
                "(select bName from tbBankInfo where BankID=c.BankID) as BankName," +
                "(case when c.toObject=1 then (select sName from tbSupplierInfo where SupplierID=c.toObjectID) " +
                " when c.toObject=2 then (select sName from tbStoresInfo where StoresID=c.toObjectID) " +
                " when c.toObject=3 then (select sName from tbStaffInfo where StaffID=c.toObjectID) " +
                " end ) as toObjectName," +
                "(select uName from tbUserInfo where UserID=c.UserID) as UserName," +
                "(select sName from tbStaffInfo where StaffID=(select StaffID from tbUserInfo where UserID=c.UserID)) as UserStaffName," +
                "(select sName from tbStaffInfo where StaffID=c.StaffID) as StaffName ");
            strSql.Append(" FROM tbMonthlyStatementAppendDataInfo as m left join tbCertificateInfo as c on m.CertificateID=c.CertificateID ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelper.ExecuteDataset(CommandType.Text,strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetMonthlyStatementAppendDataInfoList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" m.MonthlyStatementAppendDataID,m.MonthlyStatementID,m.aState,m.aRemake,m.aAppendTime,m.cMoney,c.cNumber,c.CertificateID,c.cCode,c.cMoney,c.cType,c.UserID,c.StaffID,c.cRemake,c.cObject,c.cObjectID,c.cState,c.cDateTime,c.cAppendTime,c.toObject,c.toObjectID,c.BankID," +
                "(select bName from tbBankInfo where BankID=c.BankID) as BankName," +
                "(case when c.toObject=1 then (select sName from tbSupplierInfo where SupplierID=c.toObjectID) " +
                " when c.toObject=2 then (select sName from tbStoresInfo where StoresID=c.toObjectID) " +
                " when c.toObject=3 then (select sName from tbStaffInfo where StaffID=c.toObjectID) " +
                " end ) as toObjectName," +
                "(select uName from tbUserInfo where UserID=c.UserID) as UserName," +
                "(select sName from tbStaffInfo where StaffID=(select StaffID from tbUserInfo where UserID=c.UserID)) as UserStaffName," +
                "(select sName from tbStaffInfo where StaffID=c.StaffID) as StaffName ");
            strSql.Append(" FROM tbMonthlyStatementAppendDataInfo as m left join tbCertificateInfo as c on m.CertificateID=c.CertificateID ");
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
        public DataTable GetMonthlyStatementAppendDataInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
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
            parameters[0].Value = "tbMonthlyStatementAppendDataInfo";
            parameters[1].Value = "MonthlyStatementAppendDataID";
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

        #region MonthlyStatementWorkingLogInfo
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddMonthlyStatementWorkingLogInfo(MonthlyStatementWorkingLogInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tbMonthlyStatementWorkingLogInfo(");
            strSql.Append("MonthlyStatementID,UserID,mType,mMsg,mAppendTime)");
            strSql.Append(" values (");
            strSql.Append("@MonthlyStatementID,@UserID,@mType,@mMsg,@mAppendTime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@MonthlyStatementID", SqlDbType.Int,4),
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@mType", SqlDbType.Int,4),
					new SqlParameter("@mMsg", SqlDbType.VarChar,512),
					new SqlParameter("@mAppendTime", SqlDbType.DateTime)};
            parameters[0].Value = model.MonthlyStatementID;
            parameters[1].Value = model.UserID;
            parameters[2].Value = model.mType;
            parameters[3].Value = model.mMsg;
            parameters[4].Value = model.mAppendTime;

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
        public void UpdateMonthlyStatementWorkingLogInfo(MonthlyStatementWorkingLogInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbMonthlyStatementWorkingLogInfo set ");
            strSql.Append("MonthlyStatementID=@MonthlyStatementID,");
            strSql.Append("UserID=@UserID,");
            strSql.Append("mType=@mType,");
            strSql.Append("mMsg=@mMsg,");
            strSql.Append("mAppendTime=@mAppendTime");
            strSql.Append(" where MonthlyStatementWorkingLogID=@MonthlyStatementWorkingLogID ");
            SqlParameter[] parameters = {
					new SqlParameter("@MonthlyStatementWorkingLogID", SqlDbType.Int,4),
					new SqlParameter("@MonthlyStatementID", SqlDbType.Int,4),
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@mType", SqlDbType.Int,4),
					new SqlParameter("@mMsg", SqlDbType.VarChar,512),
					new SqlParameter("@mAppendTime", SqlDbType.DateTime)};
            parameters[0].Value = model.MonthlyStatementWorkingLogID;
            parameters[1].Value = model.MonthlyStatementID;
            parameters[2].Value = model.UserID;
            parameters[3].Value = model.mType;
            parameters[4].Value = model.mMsg;
            parameters[5].Value = model.mAppendTime;

            DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void DeleteMonthlyStatementWorkingLogInfo(int MonthlyStatementWorkingLogID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbMonthlyStatementWorkingLogInfo ");
            strSql.Append(" where MonthlyStatementWorkingLogID=@MonthlyStatementWorkingLogID ");
            SqlParameter[] parameters = {
					new SqlParameter("@MonthlyStatementWorkingLogID", SqlDbType.Int,4)};
            parameters[0].Value = MonthlyStatementWorkingLogID;

            DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public MonthlyStatementWorkingLogInfo GetMonthlyStatementWorkingLogInfoModel(int MonthlyStatementWorkingLogID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 MonthlyStatementWorkingLogID,MonthlyStatementID,UserID,mType,mMsg,mAppendTime,(select tbUserInfo.uName from tbUserInfo where tbMonthlyStatementWorkingLogInfo.UserID=tbUserInfo.UserID) as UserName,(select top 1 us.sName from tbStaffInfo us where us.StaffID=(select top 1 StaffID from tbUserInfo where UserID=tbMonthlyStatementWorkingLogInfo.UserID )) as UserStaffName from tbMonthlyStatementWorkingLogInfo ");
            strSql.Append(" where MonthlyStatementWorkingLogID=@MonthlyStatementWorkingLogID ");
            SqlParameter[] parameters = {
					new SqlParameter("@MonthlyStatementWorkingLogID", SqlDbType.Int,4)};
            parameters[0].Value = MonthlyStatementWorkingLogID;

            MonthlyStatementWorkingLogInfo model = new MonthlyStatementWorkingLogInfo();
            DataSet ds = DbHelper.ExecuteDataset(CommandType.Text,strSql.ToString(),parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["MonthlyStatementWorkingLogID"].ToString() != "")
                {
                    model.MonthlyStatementWorkingLogID = int.Parse(ds.Tables[0].Rows[0]["MonthlyStatementWorkingLogID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["MonthlyStatementID"].ToString() != "")
                {
                    model.MonthlyStatementID = int.Parse(ds.Tables[0].Rows[0]["MonthlyStatementID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserID"].ToString() != "")
                {
                    model.UserID = int.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["mType"].ToString() != "")
                {
                    model.mType = int.Parse(ds.Tables[0].Rows[0]["mType"].ToString());
                }
                model.mMsg = ds.Tables[0].Rows[0]["mMsg"].ToString();
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
        public DataSet GetMonthlyStatementWorkingLogInfoList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select MonthlyStatementWorkingLogID,MonthlyStatementID,UserID,mType,mMsg,mAppendTime,(select tbUserInfo.uName from tbUserInfo where tbMonthlyStatementWorkingLogInfo.UserID=tbUserInfo.UserID) as UserName,(select top 1 us.sName from tbStaffInfo us where us.StaffID=(select top 1 StaffID from tbUserInfo where UserID=tbMonthlyStatementWorkingLogInfo.UserID )) as UserStaffName ");
            strSql.Append(" FROM tbMonthlyStatementWorkingLogInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelper.ExecuteDataset(CommandType.Text,strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetMonthlyStatementWorkingLogInfoList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" MonthlyStatementWorkingLogID,MonthlyStatementID,UserID,mType,mMsg,mAppendTime,(select tbUserInfo.uName from tbUserInfo where tbMonthlyStatementWorkingLogInfo.UserID=tbUserInfo.UserID) as UserName,(select top 1 us.sName from tbStaffInfo us where us.StaffID=(select top 1 StaffID from tbUserInfo where UserID=tbMonthlyStatementWorkingLogInfo.UserID )) as UserStaffName ");
            strSql.Append(" FROM tbMonthlyStatementWorkingLogInfo ");
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
        public DataTable GetMonthlyStatementWorkingLogInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
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
            parameters[0].Value = "tbMonthlyStatementWorkingLogInfo";
            parameters[1].Value = "MonthlyStatementWorkingLogID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 1;
            parameters[5].Value = OrderType;
            parameters[6].Value = strWhere;
            parameters[7].Value = showFName + ",(select tbUserInfo.uName from tbUserInfo where tbMonthlyStatementWorkingLogInfo.UserID=tbUserInfo.UserID) as UserName,(select top 1 us.sName from tbStaffInfo us where us.StaffID=(select top 1 StaffID from tbUserInfo where UserID=tbMonthlyStatementWorkingLogInfo.UserID )) as UserStaffName";
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
