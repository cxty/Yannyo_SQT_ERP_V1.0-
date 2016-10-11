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
        #region 永辉数据
        public DataTable GetSales_analysis(int StoresID, int StaffID, int StaffIDB, string Brand, int RegionID, int ProductID, int YHsysID, DateTime bDate, DateTime eDate, int ShowType, int DateType, out decimal AllSumValue)
        {
            DataTable dt = new DataTable();
            SqlParameter[] parameters = {
                    new SqlParameter("@StoresID", SqlDbType.Int),
                    new SqlParameter("@StaffID", SqlDbType.Int),
                    new SqlParameter("@StaffIDB", SqlDbType.Int),
                    new SqlParameter("@Brand", SqlDbType.VarChar,128),
                    new SqlParameter("@RegionID", SqlDbType.Int),
                    new SqlParameter("@bDate", SqlDbType.DateTime),
                    new SqlParameter("@eDate", SqlDbType.DateTime),
                    new SqlParameter("@ShowType", SqlDbType.Int),
                    new SqlParameter("@DateType", SqlDbType.Int),
                    new SqlParameter("@ProductID", SqlDbType.Int),
                    new SqlParameter("@YHsysID", SqlDbType.Int),
                    };
            parameters[0].Value = StoresID;
            parameters[1].Value = StaffID;
            parameters[2].Value = StaffIDB;
            parameters[3].Value = Brand;
            parameters[4].Value = RegionID;
            parameters[5].Value = bDate;
            parameters[6].Value = eDate;
            parameters[7].Value = ShowType;
            parameters[8].Value = DateType;
            parameters[9].Value = ProductID;
            parameters[10].Value = YHsysID;

            DataSet ds = DbHelper.ExecuteDataset(CommandType.StoredProcedure, "sp_" + BaseConfigs.GetTablePrefix + "Sales_analysis", parameters);
            if (ds.Tables.Count > 1)
            {
                AllSumValue = Convert.ToDecimal(ds.Tables[0].Rows[0][0]);
                return ds.Tables[1];
            }
            else
            {
                AllSumValue = 0;
                return null;
            }
        }
        #endregion

        public DataTable getStoresList(DateTime bDate, DateTime eDate)
        { 
            StringBuilder btr=new StringBuilder();
            btr.Append("  select  distinct(s.sName),s.StoresID from tbSalesInfo as si left join tbStoresInfo as s ");
            btr.Append("   on si.StoresID=s.StoresID where si.sDateTime between '" + bDate + "' and '" + eDate + "'");
            btr.Append("   and s.sState=0 order by s.StoresID asc");
            return DbHelper.ExecuteDataset(CommandType.Text, btr.ToString()).Tables[0];
        }
        /// <summary>
        /// 返回一个时间段内指定格式的日期，dType:1=日,2=月,3=年
        /// </summary>
        public DataTable GetDateTimeList(DateTime bDate,DateTime eDate,int dType)
        {
            DataTable dt = new DataTable();
            SqlParameter[] parameters = {
                    new SqlParameter("@begintime", SqlDbType.DateTime),
                    new SqlParameter("@endtime", SqlDbType.DateTime),
                    new SqlParameter("@dtype", SqlDbType.Int)
                                    };
            parameters[0].Value = bDate;
            parameters[1].Value = eDate;
            parameters[2].Value = dType;
            DataSet ds = DbHelper.ExecuteDataset(CommandType.StoredProcedure, "sp_" + BaseConfigs.GetTablePrefix + "GetDateTimeList", parameters);
            if (ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 返回一个时间段内:销售额,成本,退货,坏货,赠品,销售费用,公司费用
        /// </summary>
        /// <param name="dType">类型(7:综合(含公司费用), 1:门店/客户, 2:业务员, 3:促销员, 4:产品, 5:品牌, 6:系统)</param>
        public DataTable GetErpData_analysis(DateTime bDate, DateTime eDate, int dType)
        {
            DataTable dt = new DataTable();
            SqlParameter[] parameters = {
                    new SqlParameter("@bDate", SqlDbType.DateTime),
                    new SqlParameter("@eDate", SqlDbType.DateTime),
                    new SqlParameter("@ShowType", SqlDbType.Int)
                                    };
            parameters[0].Value = bDate;
            parameters[1].Value = eDate;
            parameters[2].Value = dType;

            DataSet ds = DbHelper.ExecuteDataset(CommandType.StoredProcedure, "sp_" + BaseConfigs.GetTablePrefix + "ErpData_analysis", parameters);
            if (ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
            
        }
        /// <summary>
        /// 返回一个时间段内:销售额,成本,退货,坏货,赠品,销售费用,公司费用
        /// </summary>
        /// <param name="dType">类型(7:综合(含公司费用), 1:门店/客户, 2:业务员, 3:促销员, 4:产品, 5:品牌, 6:系统)</param>
        /// <param name="StoresID">@StoresID int = 0,			--门店客户编号</param>
        /// <param name="StaffID">@StaffID int = 0,			--业务员编号</param>
        /// <param name="StaffIDB">@StaffIDB int = 0,			--促销员编号</param>
        /// <param name="Brand">@Brand varchar(128) = '',	--品牌名称,模糊</param>
        /// <param name="RegionID">@RegionID int = 0,			--地区编号</param>
        /// <param name="ProductID">@ProductID int = 0,			--产品编号</param>
        /// <param name="YHsysID">@YHsysID int = 0			--系统编号</param>
        public DataTable GetErpData_analysis(DateTime bDate, DateTime eDate, int dType, int StoresID, int StaffID, int StaffIDB, string Brand, int RegionID, int ProductID, int YHsysID)
        {
            DataTable dt = new DataTable();
            SqlParameter[] parameters = {
                    new SqlParameter("@bDate", SqlDbType.DateTime),
                    new SqlParameter("@eDate", SqlDbType.DateTime),
                    new SqlParameter("@ShowType", SqlDbType.Int),
                    new SqlParameter("@StoresID", SqlDbType.Int),
                    new SqlParameter("@StaffID", SqlDbType.Int),
                    new SqlParameter("@StaffIDB", SqlDbType.Int),
                    new SqlParameter("@Brand", SqlDbType.VarChar,128),
                    new SqlParameter("@RegionID", SqlDbType.Int),
                    new SqlParameter("@ProductID", SqlDbType.Int),
                    new SqlParameter("@YHsysID", SqlDbType.Int)
                                    };

            parameters[0].Value = bDate;
            parameters[1].Value = eDate;
            parameters[2].Value = dType;
            parameters[3].Value = StoresID;
            parameters[4].Value = StaffID;
            parameters[5].Value = StaffIDB;
            parameters[6].Value = Brand;
            parameters[7].Value = RegionID;
            parameters[8].Value = ProductID;
            parameters[9].Value = YHsysID;

            DataSet ds = DbHelper.ExecuteDataset(CommandType.StoredProcedure, "sp_" + BaseConfigs.GetTablePrefix + "ErpData_analysis", parameters);
            if (ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }

        }
        /// <summary>
        /// 返回一个时间段内:费用
        /// </summary>
        /// <param name="mType">类型(销售费用=0,公司管理费用=1)</param>
        public DataTable Get_Fees_analysis(DateTime bDate, DateTime eDate, int mType)
        {
            DataTable dt = new DataTable();
            SqlParameter[] parameters = {
                    new SqlParameter("@bDate", SqlDbType.DateTime),
                    new SqlParameter("@eDate", SqlDbType.DateTime),
                    new SqlParameter("@mType", SqlDbType.Int)
                                    };
            parameters[0].Value = bDate;
            parameters[1].Value = eDate;
            parameters[2].Value = mType;

            DataSet ds = DbHelper.ExecuteDataset(CommandType.StoredProcedure, "sp_" + BaseConfigs.GetTablePrefix + "Fees_analysis", parameters);
            if (ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 取指定门店的费用明细
        /// </summary>
        /// <param name="bDate"></param>
        /// <param name="eDate"></param>
        /// <param name="StoresID"></param>
        /// <returns></returns>
        public DataTable Get_Fees_by_StoresID(DateTime bDate, DateTime eDate, int StoresID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select mf.MarketingFeesID,mf.StoresID,mf.FeesSubjectID,mf.mRemark,mf.mFees,mf.mDateTime,mf.mType,mf.StaffID,mf.mAppendTime,(select fName from tbFeesSubjectInfo where FeesSubjectID=mf.FeesSubjectID) as FeesSubjectName,(select sName from tbStaffInfo where StaffID=mf.StaffID) as StaffName from tbMarketingFeesInfo as mf where mf.StoresID=@StoresID and mf.mDateTime>='" + bDate.Date + "' and mf.mDateTime<='" + eDate.Date + "' and mf.mIsIncomeExpenditure=0 and mf.mType=0 order by mf.mDateTime desc");
            SqlParameter[] parameters = {
					new SqlParameter("@StoresID", SqlDbType.Int,4)};
            parameters[0].Value = StoresID;

            DataSet ds = DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(), parameters);
            if (ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 取指定科目费用明细
        /// </summary>
        /// <param name="bDate"></param>
        /// <param name="eDate"></param>
        /// <param name="FeesSubjectID"></param>
        /// <returns></returns>
        public DataTable Get_Fees_by_FeesSubjectID(DateTime bDate, DateTime eDate, int FeesSubjectID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select mf.MarketingFeesID,mf.StoresID,mf.FeesSubjectID,mf.mRemark,mf.mFees,mf.mDateTime,mf.mType,mf.StaffID,mf.mAppendTime,(select fName from tbFeesSubjectInfo where FeesSubjectID=mf.FeesSubjectID) as FeesSubjectName,(select sName from tbStaffInfo where StaffID=mf.StaffID) as StaffName from tbMarketingFeesInfo as mf where mf.FeesSubjectID=@FeesSubjectID and mf.mDateTime>='" + bDate.Date + "' and mf.mDateTime<='" + eDate.Date + "' and mf.mIsIncomeExpenditure=0 and mf.mType=1 order by mf.mDateTime desc");
            SqlParameter[] parameters = {
					new SqlParameter("@FeesSubjectID", SqlDbType.Int,4)};
            parameters[0].Value = FeesSubjectID;

            DataSet ds = DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(), parameters);
            if (ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 库存情况
        /// </summary>
        /// <param name="storageid">仓库编号</param>
        /// <param name="eDate">库存点</param>
        /// <param name="ProductID">产品编号</param>
        public DataTable GetStock_analysis(int storageid, DateTime eDate, int ProductID)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@storageid", SqlDbType.Int),
                    new SqlParameter("@eDate", SqlDbType.DateTime),
                    new SqlParameter("@ProductID", SqlDbType.Int)
                                    };
            parameters[0].Value = storageid;
            parameters[1].Value = eDate;
            parameters[2].Value = ProductID;

            DataSet ds = DbHelper.ExecuteDataset(CommandType.StoredProcedure, "sp_" + BaseConfigs.GetTablePrefix + "Stock_analysis", parameters);
            if (ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 应收应付
        /// </summary>
        /// <param name="gettype">客户应收=0,人员应收=1,供货商应付=2,人员应付=3</param>
        /// <param name="eDate">截止时间点</param>
        /// <param name="ObjID">指定对象编号</param>
        public DataTable GetAPARMoney(int gettype, DateTime eDate, int ObjID)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@gettype", SqlDbType.Int),
                    new SqlParameter("@eDate", SqlDbType.DateTime),
                    new SqlParameter("@ObjID", SqlDbType.Int)
                                    };
            parameters[0].Value = gettype;
            parameters[1].Value = eDate;
            parameters[2].Value = ObjID;

            DataSet ds = DbHelper.ExecuteDataset(CommandType.StoredProcedure, "sp_" + BaseConfigs.GetTablePrefix + "APARMoney_analysis", parameters);
            if (ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 返回净资产
        /// </summary>
        /// <param name="eDate">截止时间点</param>
        public DataTable GetNetAssets(DateTime eDate)
        {
            decimal AllSumValue1 = 0;
            decimal AllSumValue2 = 0;
            decimal AllSumValue3 = 0;
            decimal AllSumValue4 = 0;
            decimal AllSumValue5 = 0;

            StringBuilder strSql = new StringBuilder();

            //银行现金
            strSql.Append(" select isnull(sum(isnull(bm.bMoney,0)),0) from (");
            strSql.Append(" select b.*,isnull(m.bMoney,0) bMoney from tbBankInfo as b left join (select top 1 * from tbBankMoneyInfo where bUpdateTime<=@eDate order by bUpdateTime desc) as m");
            strSql.Append(" on  b.BankID=m.BankID) as bm");

            SqlParameter[] parameters = {
					new SqlParameter("@eDate", SqlDbType.DateTime)};
            parameters[0].Value = eDate;


            decimal BankMoney = decimal.Parse(DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters).ToString());

            //库存
            SqlParameter[] parameters_b = {
                new SqlParameter("@storageid", SqlDbType.Int,4),
				new SqlParameter("@eDate", SqlDbType.DateTime),
                new SqlParameter("@ProductID", SqlDbType.Int,4)
                                          };
            parameters_b[0].Value = 0;
            parameters_b[1].Value = eDate;
            parameters_b[2].Value = 0;
            DataTable dt_b = DbHelper.ExecuteDataset(CommandType.StoredProcedure,"sp_Stock_analysis",parameters_b).Tables[0];

            if (dt_b != null)
            {
                foreach (DataRow dr in dt_b.Rows)
                {
                    AllSumValue1 += Convert.ToDecimal(dr["sumPrice"]);
                }
            }

            //个人应收
            SqlParameter[] parameters_c = {
                new SqlParameter("@gettype", SqlDbType.Int,4),
                new SqlParameter("@eDate", SqlDbType.DateTime),
                new SqlParameter("@ObjID", SqlDbType.Int,4)
                                          };
            parameters_c[0].Value = 1;
            parameters_c[1].Value = eDate;
            parameters_c[2].Value = 0;

            DataTable dt_c = DbHelper.ExecuteDataset(CommandType.StoredProcedure,"sp_APARMoney_analysis",parameters_c).Tables[0];

            if (dt_c != null)
            {
                foreach (DataRow dr in dt_c.Rows)
                {
                    AllSumValue2 += Convert.ToDecimal(dr["SYMoney"]);
                }
            }

            //公司应收
            SqlParameter[] parameters_d = {
                new SqlParameter("@gettype", SqlDbType.Int,4),
                new SqlParameter("@eDate", SqlDbType.DateTime),
                new SqlParameter("@ObjID", SqlDbType.Int,4)
                                          };
            parameters_d[0].Value = 2;
            parameters_d[1].Value = eDate;
            parameters_d[2].Value = 0;

            DataTable dt_d = DbHelper.ExecuteDataset(CommandType.StoredProcedure, "sp_APARMoney_analysis", parameters_d).Tables[0];
            if (dt_d != null)
            {
                foreach (DataRow dr in dt_d.Rows)
                {
                    AllSumValue3 += Convert.ToDecimal(dr["SYMoney"]);
                }
            }

            //公司应付
            SqlParameter[] parameters_e = {
                new SqlParameter("@gettype", SqlDbType.Int,4),
                new SqlParameter("@eDate", SqlDbType.DateTime),
                new SqlParameter("@ObjID", SqlDbType.Int,4)
                                          };
            parameters_e[0].Value = 3;
            parameters_e[1].Value = eDate;
            parameters_e[2].Value = 0;

            DataTable dt_e = DbHelper.ExecuteDataset(CommandType.StoredProcedure, "sp_APARMoney_analysis", parameters_e).Tables[0];
            if (dt_e != null)
            {
                foreach (DataRow dr in dt_e.Rows)
                {
                    AllSumValue4 += Convert.ToDecimal(dr["SYMoney"]);
                }
            }
            //公司应付
            SqlParameter[] parameters_f = {
                new SqlParameter("@gettype", SqlDbType.Int,4),
                new SqlParameter("@eDate", SqlDbType.DateTime),
                new SqlParameter("@ObjID", SqlDbType.Int,4)
                                          };
            parameters_f[0].Value = 4;
            parameters_f[1].Value = eDate;
            parameters_f[2].Value = 0;

            DataTable dt_f = DbHelper.ExecuteDataset(CommandType.StoredProcedure, "sp_APARMoney_analysis", parameters_f).Tables[0];
            if (dt_f != null)
            {
                foreach (DataRow dr in dt_f.Rows)
                {
                    AllSumValue5 += Convert.ToDecimal(dr["SYMoney"]);
                }
            }
            
            DataTable ReDt = new DataTable();
            DataColumn column = new DataColumn();
            column.DataType = System.Type.GetType("System.Decimal");
            column.ColumnName = "BankMoney";
            ReDt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Decimal");
            column.ColumnName = "StockMoney";
            ReDt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Decimal");
            column.ColumnName = "ARMoney_A";
            ReDt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Decimal");
            column.ColumnName = "ARMoney_B";
            ReDt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Decimal");
            column.ColumnName = "APMoney_A";
            ReDt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Decimal");
            column.ColumnName = "APMoney_B";
            ReDt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Decimal");
            column.ColumnName = "NetAssetsMoney";
            ReDt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Decimal");
            column.ColumnName = "FixedMoney";
            ReDt.Columns.Add(column);

            DataRow row = ReDt.NewRow();
            row["BankMoney"] = BankMoney;
            row["StockMoney"] = AllSumValue1;
            row["ARMoney_A"] = AllSumValue2;
            row["ARMoney_B"] = AllSumValue3;
            row["APMoney_A"] = AllSumValue4;
            row["APMoney_B"] = AllSumValue5;
            row["NetAssetsMoney"] = BankMoney + AllSumValue1 + AllSumValue2 + AllSumValue3 - AllSumValue4 - AllSumValue5;
            row["FixedMoney"] = 0;
            ReDt.Rows.Add(row);
            ReDt.AcceptChanges();
            
            return ReDt;
        }
        /// <summary>
        /// 返回人员带身份证列表
        /// </summary>
        public DataTable GetStaffBirthdayList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from tbStaffInfo");
            strSql.Append(" where sState=0 and sCarID is not null");

            DataSet ds = DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString());
            if (ds.Tables[0] != null)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 去销售统计小表
        /// </summary>
        /// <param name="ReType">商品销售=1,客户销售=2,销售成本,利润=3</param>
        /// <param name="bDate">开始时间</param>
        /// <param name="eDate">结束时间</param>
        /// <param name="NOJoinSales">是否剔除联营数据</param>
        /// <returns></returns>
        public DataTable GetSalesReport(int ReType, DateTime bDate, DateTime eDate, int NOJoinSales)
        {
            SqlParameter[] parameters = {
                new SqlParameter("@ReDateType", SqlDbType.Int,4),
                new SqlParameter("@ReType", SqlDbType.Int,4),
                new SqlParameter("@bDate", SqlDbType.DateTime),
                new SqlParameter("@eDate", SqlDbType.DateTime),
                new SqlParameter("@NOJoinSales", SqlDbType.Int,4),
                new SqlParameter("@StoresID", SqlDbType.Int,4),
                new SqlParameter("@PaymentSystemID", SqlDbType.Int,4),
                new SqlParameter("@oSteps", SqlDbType.Int,4),
                new SqlParameter("@dType", SqlDbType.Int,4),
                new SqlParameter("@CostPrice", SqlDbType.Int,4),
				new SqlParameter("@SingleMemberID", SqlDbType.Int,4),
				new SqlParameter("@OrderNumber", SqlDbType.VarChar,1024),
                                          };
            parameters[0].Value = 1;
            parameters[1].Value = ReType;
            parameters[2].Value = bDate;
            parameters[3].Value = eDate;
            parameters[4].Value = NOJoinSales;
            parameters[5].Value = 0;
            parameters[6].Value = 0;
            parameters[7].Value = 0;
            parameters[8].Value = 0;
            parameters[9].Value = 0;
			parameters[10].Value = 0;
			parameters [11].Value = "";

            DataSet ds = DbHelper.ExecuteDataset(CommandType.StoredProcedure, "sp_GetSalesReport_XP", parameters);
            if (ds.Tables[0] != null)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }
		public DataTable GetSalesReport(int ReType, DateTime bDate, DateTime eDate, int NOJoinSales, int StoresID,int SingleMemberID)
        {
            SqlParameter[] parameters = {
                new SqlParameter("@ReDateType", SqlDbType.Int,4),
                new SqlParameter("@ReType", SqlDbType.Int,4),
                new SqlParameter("@bDate", SqlDbType.DateTime),
                new SqlParameter("@eDate", SqlDbType.DateTime),
                new SqlParameter("@NOJoinSales", SqlDbType.Int,4),
                new SqlParameter("@StoresID", SqlDbType.Int,4),
                new SqlParameter("@PaymentSystemID", SqlDbType.Int,4),
                new SqlParameter("@oSteps", SqlDbType.Int,4),
                new SqlParameter("@dType", SqlDbType.Int,4),
                new SqlParameter("@CostPrice", SqlDbType.Int,4),
				new SqlParameter("@SingleMemberID", SqlDbType.Int,4),
				new SqlParameter("@OrderNumber", SqlDbType.VarChar,1024),
                                          };
            parameters[0].Value = 1;
            parameters[1].Value = ReType;
            parameters[2].Value = bDate;
            parameters[3].Value = eDate;
            parameters[4].Value = NOJoinSales;
            parameters[5].Value = StoresID;
            parameters[6].Value = 0;
            parameters[7].Value = 0;
            parameters[8].Value = 0;
            parameters[9].Value = 0;
			parameters[10].Value = SingleMemberID;
			parameters [11].Value = "";

            DataSet ds = DbHelper.ExecuteDataset(CommandType.StoredProcedure, "sp_GetSalesReport_XP", parameters);
            if (ds.Tables[0] != null)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }
		public DataTable GetSalesReport(int ReType, DateTime bDate, DateTime eDate, int NOJoinSales, int StoresID, int PaymentSystemID,int SingleMemberID)
        {
            SqlParameter[] parameters = {
                new SqlParameter("@ReDateType", SqlDbType.Int,4),
                new SqlParameter("@ReType", SqlDbType.Int,4),
                new SqlParameter("@bDate", SqlDbType.DateTime),
                new SqlParameter("@eDate", SqlDbType.DateTime),
                new SqlParameter("@NOJoinSales", SqlDbType.Int,4),
                new SqlParameter("@StoresID", SqlDbType.Int,4),
                new SqlParameter("@PaymentSystemID", SqlDbType.Int,4),
                new SqlParameter("@oSteps", SqlDbType.Int,4),
                new SqlParameter("@dType", SqlDbType.Int,4),
                new SqlParameter("@CostPrice", SqlDbType.Int,4),
				new SqlParameter("@SingleMemberID", SqlDbType.Int,4),
				new SqlParameter("@OrderNumber", SqlDbType.VarChar,1024),
                                          };
            parameters[0].Value = 1;
            parameters[1].Value = ReType;
            parameters[2].Value = bDate;
            parameters[3].Value = eDate;
            parameters[4].Value = NOJoinSales;
            parameters[5].Value = StoresID;
            parameters[6].Value = PaymentSystemID;
            parameters[7].Value = 0;
            parameters[8].Value = 0;
            parameters[9].Value = 0;
			parameters [10].Value = SingleMemberID;
			parameters [11].Value = "";

            DataSet ds = DbHelper.ExecuteDataset(CommandType.StoredProcedure, "sp_GetSalesReport_XP", parameters);
            if (ds.Tables[0] != null)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }
		public DataTable GetSalesReport(int ReType, DateTime bDate, DateTime eDate, int NOJoinSales, int StoresID, int PaymentSystemID, int oSteps,int SingleMemberID)
        {
            SqlParameter[] parameters = {
                new SqlParameter("@ReDateType", SqlDbType.Int,4),
                new SqlParameter("@ReType", SqlDbType.Int,4),
                new SqlParameter("@bDate", SqlDbType.DateTime),
                new SqlParameter("@eDate", SqlDbType.DateTime),
                new SqlParameter("@NOJoinSales", SqlDbType.Int,4),
                new SqlParameter("@StoresID", SqlDbType.Int,4),
                new SqlParameter("@PaymentSystemID", SqlDbType.Int,4),
                new SqlParameter("@oSteps", SqlDbType.Int,4),
                new SqlParameter("@dType", SqlDbType.Int,4),
                new SqlParameter("@CostPrice", SqlDbType.Int,4),
				new SqlParameter("@SingleMemberID", SqlDbType.Int,4),
				new SqlParameter("@OrderNumber", SqlDbType.VarChar,1024),
                                          };
            parameters[0].Value = 1;
            parameters[1].Value = ReType;
            parameters[2].Value = bDate;
            parameters[3].Value = eDate;
            parameters[4].Value = NOJoinSales;
            parameters[5].Value = StoresID;
            parameters[6].Value = PaymentSystemID;
            parameters[7].Value = oSteps;
            parameters[8].Value = 0;
            parameters[9].Value = 0;
			parameters [10].Value = SingleMemberID;
			parameters [11].Value = "";

            DataSet ds = DbHelper.ExecuteDataset(CommandType.StoredProcedure, "sp_GetSalesReport_XP", parameters);
            if (ds.Tables[0] != null)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }
		public DataTable GetSalesReport(int ReType, DateTime bDate, DateTime eDate, int NOJoinSales, int StoresID, int PaymentSystemID, int oSteps, int dType,int SingleMemberID)
        {
            SqlParameter[] parameters = {
                new SqlParameter("@ReDateType", SqlDbType.Int,4),
                new SqlParameter("@ReType", SqlDbType.Int,4),
                new SqlParameter("@bDate", SqlDbType.DateTime),
                new SqlParameter("@eDate", SqlDbType.DateTime),
                new SqlParameter("@NOJoinSales", SqlDbType.Int,4),
                new SqlParameter("@StoresID", SqlDbType.Int,4),
                new SqlParameter("@PaymentSystemID", SqlDbType.Int,4),
                new SqlParameter("@oSteps", SqlDbType.Int,4),
                new SqlParameter("@dType", SqlDbType.Int,4),
                new SqlParameter("@CostPrice", SqlDbType.Int,4),
				new SqlParameter("@SingleMemberID", SqlDbType.Int,4),
				new SqlParameter("@OrderNumber", SqlDbType.VarChar,1024),
                                          };
            parameters[0].Value = 1;
            parameters[1].Value = ReType;
            parameters[2].Value = bDate;
            parameters[3].Value = eDate;
            parameters[4].Value = NOJoinSales;
            parameters[5].Value = StoresID;
            parameters[6].Value = PaymentSystemID;
            parameters[7].Value = oSteps;
            parameters[8].Value = dType;
            parameters[9].Value = 0;
			parameters[10].Value = SingleMemberID;
			parameters [11].Value = "";

            DataSet ds = DbHelper.ExecuteDataset(CommandType.StoredProcedure, "sp_GetSalesReport_XP", parameters);
            if (ds.Tables[0] != null)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }
		public DataTable GetSalesReport(int ReType, DateTime bDate, DateTime eDate, int NOJoinSales, int StoresID, int PaymentSystemID, int oSteps, int dType, int CostPrice,int SingleMemberID)
        {
            SqlParameter[] parameters = {
                new SqlParameter("@ReDateType", SqlDbType.Int,4),
                new SqlParameter("@ReType", SqlDbType.Int,4),
                new SqlParameter("@bDate", SqlDbType.DateTime),
                new SqlParameter("@eDate", SqlDbType.DateTime),
                new SqlParameter("@NOJoinSales", SqlDbType.Int,4),
                new SqlParameter("@StoresID", SqlDbType.Int,4),
                new SqlParameter("@PaymentSystemID", SqlDbType.Int,4),
                new SqlParameter("@oSteps", SqlDbType.Int,4),
                new SqlParameter("@dType", SqlDbType.Int,4),
                new SqlParameter("@CostPrice", SqlDbType.Int,4),
				new SqlParameter("@SingleMemberID", SqlDbType.Int,4),
				new SqlParameter("@OrderNumber", SqlDbType.VarChar,1024),
                                          };
            parameters[0].Value = 1;
            parameters[1].Value = ReType;
            parameters[2].Value = bDate;
            parameters[3].Value = eDate;
            parameters[4].Value = NOJoinSales;
            parameters[5].Value = StoresID;
            parameters[6].Value = PaymentSystemID;
            parameters[7].Value = oSteps;
            parameters[8].Value = dType;
            parameters[9].Value = CostPrice;
			parameters[10].Value = SingleMemberID;
			parameters [11].Value = "";

            DataSet ds = DbHelper.ExecuteDataset(CommandType.StoredProcedure, "sp_GetSalesReport_XP", parameters);
            if (ds.Tables[0] != null)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }
		public DataTable GetSalesReport(int ReDateType,int ReType, DateTime bDate, DateTime eDate, int NOJoinSales, int StoresID, int PaymentSystemID, int oSteps, int dType, int CostPrice,int SingleMemberID,string OrderNumber)
		{
			SqlParameter[] parameters = {
                new SqlParameter("@ReDateType", SqlDbType.Int,4),
				new SqlParameter("@ReType", SqlDbType.Int,4),
				new SqlParameter("@bDate", SqlDbType.DateTime),
				new SqlParameter("@eDate", SqlDbType.DateTime),
				new SqlParameter("@NOJoinSales", SqlDbType.Int,4),
				new SqlParameter("@StoresID", SqlDbType.Int,4),
				new SqlParameter("@PaymentSystemID", SqlDbType.Int,4),
				new SqlParameter("@oSteps", SqlDbType.Int,4),
				new SqlParameter("@dType", SqlDbType.Int,4),
				new SqlParameter("@CostPrice", SqlDbType.Int,4),
				new SqlParameter("@SingleMemberID", SqlDbType.Int,4),
				new SqlParameter("@OrderNumber", SqlDbType.VarChar,1024),
			};

            parameters[0].Value = ReDateType;
			parameters[1].Value = ReType;
			parameters[2].Value = bDate;
			parameters[3].Value = eDate;
			parameters[4].Value = NOJoinSales;
			parameters[5].Value = StoresID;
			parameters[6].Value = PaymentSystemID;
			parameters[7].Value = oSteps;
			parameters[8].Value = dType;
			parameters[9].Value = CostPrice;
			parameters[10].Value = SingleMemberID;
			parameters [11].Value = OrderNumber;

			DataSet ds = DbHelper.ExecuteDataset(CommandType.StoredProcedure, "sp_GetSalesReport_XP", parameters);
			if (ds.Tables[0] != null)
			{
				return ds.Tables[0];
			}
			else
			{
				return null;
			}
		}
        /// <summary>
        /// 取进货统计表
        /// </summary>
        /// <param name="ReType"></param>
        /// <param name="bDate"></param>
        /// <param name="eDate"></param>
        /// <returns></returns>
        public DataTable GetPurchaseReport(int ReType, DateTime bDate, DateTime eDate)
        {
            SqlParameter[] parameters = {
                new SqlParameter("@ReType", SqlDbType.Int,4),
                new SqlParameter("@bDate", SqlDbType.DateTime),
                new SqlParameter("@eDate", SqlDbType.DateTime),
                                          };
            parameters[0].Value = ReType;
            parameters[1].Value = bDate;
            parameters[2].Value = eDate;
           
            DataSet ds = DbHelper.ExecuteDataset(CommandType.StoredProcedure, "sp_GetPurchaseReport", parameters);
            if (ds.Tables[0] != null)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 出库统计
        /// </summary>
        /// <param name="ReType">商品=1,客户=2</param>
        /// <param name="bDate"></param>
        /// <param name="eDate"></param>
        /// <param name="NOJoinSales"></param>
        /// <returns></returns>
        public DataTable GetOutReport(int ReType, DateTime bDate, DateTime eDate, int NOJoinSales)
        {
            SqlParameter[] parameters = {
                new SqlParameter("@ReType", SqlDbType.Int,4),
                new SqlParameter("@bDate", SqlDbType.DateTime),
                new SqlParameter("@eDate", SqlDbType.DateTime),
                new SqlParameter("@NOJoinSales", SqlDbType.Int,4),
                                          };
            parameters[0].Value = ReType;
            parameters[1].Value = bDate;
            parameters[2].Value = eDate;
            parameters[3].Value = NOJoinSales;

            DataSet ds = DbHelper.ExecuteDataset(CommandType.StoredProcedure, "sp_GetOutReport", parameters);
            if (ds.Tables[0] != null)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 库存商品明细
        /// </summary>
        /// <param name="bDate">开始时间</param>
        /// <param name="eDate">结束时间</param>
        /// <param name="ProductsID">商品编号</param>
        /// <param name="CostPrice">是否计算成本，0计算，1不计算</param>
        /// <param name="StorageID">仓库名称</param>
        /// <param name="Product_UPYear">上年结转，out</param>
        /// <param name="YearData">本年累计</param>
        /// <returns></returns>
        public DataSet GetProductLogDetails(DateTime bDate, DateTime eDate, int ProductsID, int CostPrice, int StorageID )
        {
            SqlParameter[] parameters = {
                new SqlParameter("@bDate",SqlDbType.DateTime),
                new SqlParameter("@eDate", SqlDbType.DateTime),
                new SqlParameter("@ProductsID", SqlDbType.Int,4),
                new SqlParameter("@CostPrice", SqlDbType.Int,4),
                new SqlParameter("@StorageID", SqlDbType.Int,4),
                                          };
            parameters[0].Value = bDate;
            parameters[1].Value = eDate;
            parameters[2].Value = ProductsID;
            parameters[3].Value = CostPrice;
            parameters[4].Value = StorageID;

            DataSet ds = DbHelper.ExecuteDataset(CommandType.StoredProcedure, "sp_GetProductLogDetails", parameters);
            if (ds!= null)
            {
                return ds;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 返回客户销售统计数据
        /// </summary>
        /// <param name="ShowType">显示类型,1=按客户,2=业务员,3=促销员,4=产品,5=品牌(产品分类),6=系统,7=客户与商品</param>
        /// <param name="bDate"></param>
        /// <param name="eDate"></param>
        /// <param name="isIsPool">是否联营,0=全部,1=仅联营,2=剔除联营</param>
        /// <returns></returns>
        public DataTable GetCustomers_DataAnalysis(int ShowType, DateTime bDate, DateTime eDate, out decimal AllSumMoney, int storesID, int isIsPool)
        {
            SqlParameter[] parameters = {
                new SqlParameter("@ShowType", SqlDbType.Int,4),
                new SqlParameter("@bDate", SqlDbType.DateTime),
                new SqlParameter("@eDate", SqlDbType.DateTime),
                new SqlParameter("@storesID", SqlDbType.Int,4),
                new SqlParameter("@isIsPool", SqlDbType.Int,4),
                                          };
            parameters[0].Value = ShowType;
            parameters[1].Value = bDate;
            parameters[2].Value = eDate;
            parameters[3].Value = storesID;
            parameters[4].Value = isIsPool;

            DataSet ds = DbHelper.ExecuteDataset(CommandType.StoredProcedure, "sp_Customers_DataAnlysis", parameters);
            if (ds.Tables[0] != null)
            {
                try
                {
                    AllSumMoney = Convert.ToDecimal(ds.Tables[1].Rows[0][0]);
                }
                catch {
                    AllSumMoney = 0;
                }
                return ds.Tables[0];
            }
            else
            {
                AllSumMoney = 0;
                return null;
            }
        }

        /// <summary>
        /// 导出永辉销售数据
        /// </summary>
        /// <param name="bDate"></param>
        /// <param name="Type"></param>
        /// <param name="checkValue"></param>
        /// <returns></returns>
        public DataTable getStorageSalesExportData(DateTime bDate, int Type, int checkValue)
        {
            SqlParameter[] parameters = {
                new SqlParameter("@dtmBdate", SqlDbType.DateTime),
                new SqlParameter("@inyType", SqlDbType.Int),
                new SqlParameter("@inycheckValue", SqlDbType.Int),
                                          };
            parameters[0].Value = bDate;
            parameters[1].Value = Type;
            parameters[2].Value = checkValue;

            return DbHelper.ExecuteDataset(CommandType.StoredProcedure, "sp_Customers_DataAnlysis_Export", parameters).Tables[0];
        }
         /// <summary>
         /// 导出出货数据
         /// </summary>
         /// <param name="bDate"></param>
         /// <param name="checkValue"></param>
         /// <returns></returns>
        public DataTable getReportOutExport(DateTime bDate, int checkValue)
        {
            SqlParameter[] parameters = {
                new SqlParameter("@dtmBdate", SqlDbType.DateTime),
                new SqlParameter("@inyCheckValue", SqlDbType.Int),
                                          };
            parameters[0].Value = bDate;
            parameters[1].Value = checkValue;

            return DbHelper.ExecuteDataset(CommandType.StoredProcedure, "sp_report_out_Export", parameters).Tables[0];
        }
    }
}
