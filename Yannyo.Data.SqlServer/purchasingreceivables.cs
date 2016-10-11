﻿using System;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Yannyo.Data;
using Yannyo.Config;
using Yannyo.Common;
using Yannyo.Entity;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.IO;

namespace Yannyo.Data.SqlServer
{
    public partial class DataProvider : IDataProvider
    {
        #region proceeds

        /// <summary>
        /// 财务应收款项报表
        /// </summary>
        /// <param name="ProductsID"></param>
        /// <param name="StorageID"></param>
        /// <param name="sDate">选择的时间点</param>
        /// <param name="ReType">返回类型,月表=0,年表=1</param>
        /// <returns></returns>
        public DataTable GetProceedsReport(int sObjectType, DateTime sDate, int ReType)
        {
            SqlParameter[] parameters = {
                            new SqlParameter("@sObjectType", SqlDbType.Int),
                            new SqlParameter("@dT", SqlDbType.DateTime),
                            new SqlParameter("@ReType", SqlDbType.Int,4),
                                            };
            parameters[0].Value = sObjectType;
            parameters[1].Value = sDate;
            parameters[2].Value = ReType;

            StringBuilder strSql = new StringBuilder();

            strSql.Append("  select pp.sObjectType,pp.sCode,pp.sObjectName,isnull(pp.sUpMoney,0) as sUpMoney,isnull(pp.sThisMoney,0) as sThisMoney,");
            strSql.Append("  isnull(pp.sMoney,0) as sMoney,isnull(pp.sToMoney,0) as sToMoney,isnull(pp.sBalanceMoney,0)as sBalanceMoney,");
            strSql.Append("  pp.sReceiptState,ui.uName,pp.sDateTime from (");
            strSql.Append("  select sObjectType,sCode,");
	        strSql.Append("  isnull(sUpMoney,0) as sUpMoney,");			    //--上期余额
            strSql.Append("  isnull(sThisMoney,0) as sThisMoney,");		    //--本期对账金额
            strSql.Append("  isnull(sMoney,0) as sMoney,");				    //--实际对账金额
            strSql.Append("  isnull(sToMoney,0) as sToMoney,");			    //--到款金额
            strSql.Append("  isnull(sBalanceMoney,0) as sBalanceMoney, ");  //-本期余额
            strSql.Append("   sReceiptState,");							    //票是否已开/收
            strSql.Append("   UserID,");									//经办人编号
            strSql.Append("   sDateTime,");								    //对账时间
            strSql.Append("    (case when sObjectType=0 then (select sName from tbStoresInfo where StoresID=sObjectID)"); //客户
            strSql.Append("          when sObjectType=1 then (select sName from tbSupplierInfo where SupplierID=sObjectID)");//供货商
            strSql.Append("          when sObjectType=2 then (select sName from tbStaffInfo where StaffID=sObjectID)");//人员
            strSql.Append("          when sObjectType=3 then (select pName from tbPaymentSystemInfo where PaymentSystemID=sObjectID)");//商超系统
            strSql.Append("     end ) as sObjectName");
            strSql.Append("         from tbMonthlyStatementInfo as mi ");
            strSql.Append("            where sState=0 and sType=2 and sObjectType='" + sObjectType + "' and sSteps=1");
           
           
            switch (ReType)
            {
                case 0:
                    strSql.Append("  and datediff(month,mi.sDateTime,'" + sDate + "')=0");
                    break;
                case 1:
                    strSql.Append("  and datediff(year,mi.sDateTime,'" + sDate + "')=0");
                    break;
            }
            strSql.Append("               ) as pp left join tbUserInfo as ui on pp.UserID=ui.UserID");
            DataTable dt = DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(), parameters).Tables[0];
            if (dt.Rows.Count > 0)
            {
                return dt;
            }
            else
            {
                return null;
            }
        }
        #endregion
    }
}

