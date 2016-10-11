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
        #region  MarketingFeesInfo

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddMarketingFeesInfo(MarketingFeesInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tbMarketingFeesInfo(");
            strSql.Append("StoresID,FeesSubjectID,mRemark,mFees,mDateTime,mType,StaffID,mAppendTime,mIsIncomeExpenditure)");
            strSql.Append(" values (");
            strSql.Append("@StoresID,@FeesSubjectID,@mRemark,@mFees,@mDateTime,@mType,@StaffID,@mAppendTime,@mIsIncomeExpenditure)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@StoresID", SqlDbType.Int,4),
					new SqlParameter("@FeesSubjectID", SqlDbType.Int,4),
					new SqlParameter("@mRemark", SqlDbType.VarChar,1024),
					new SqlParameter("@mFees", SqlDbType.Money,8),
					new SqlParameter("@mDateTime", SqlDbType.DateTime),
					new SqlParameter("@mType", SqlDbType.Int,4),
					new SqlParameter("@StaffID", SqlDbType.Int,4),
					new SqlParameter("@mAppendTime", SqlDbType.DateTime),
                                        new SqlParameter("@mIsIncomeExpenditure", SqlDbType.Int,4)};
            parameters[0].Value = model.StoresID;
            parameters[1].Value = model.FeesSubjectID;
            parameters[2].Value = model.mRemark;
            parameters[3].Value = model.mFees;
            parameters[4].Value = model.mDateTime;
            parameters[5].Value = model.mType;
            parameters[6].Value = model.StaffID;
            parameters[7].Value = model.mAppendTime;
            parameters[8].Value = model.mIsIncomeExpenditure;

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
        public void UpdateMarketingFeesInfo(MarketingFeesInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbMarketingFeesInfo set ");
            strSql.Append("StoresID=@StoresID,");
            strSql.Append("FeesSubjectID=@FeesSubjectID,");
            strSql.Append("mRemark=@mRemark,");
            strSql.Append("mFees=@mFees,");
            strSql.Append("mDateTime=@mDateTime,");
            strSql.Append("mType=@mType,");
            strSql.Append("StaffID=@StaffID,");
            strSql.Append("mIsIncomeExpenditure=@mIsIncomeExpenditure,");
            strSql.Append("mAppendTime=@mAppendTime");
            strSql.Append(" where MarketingFeesID=@MarketingFeesID ");
            SqlParameter[] parameters = {
					new SqlParameter("@MarketingFeesID", SqlDbType.Int,4),
					new SqlParameter("@StoresID", SqlDbType.Int,4),
					new SqlParameter("@FeesSubjectID", SqlDbType.Int,4),
					new SqlParameter("@mRemark", SqlDbType.VarChar,1024),
					new SqlParameter("@mFees", SqlDbType.Money,8),
					new SqlParameter("@mDateTime", SqlDbType.DateTime),
					new SqlParameter("@mType", SqlDbType.Int,4),
					new SqlParameter("@StaffID", SqlDbType.Int,4),
                    new SqlParameter("@mIsIncomeExpenditure", SqlDbType.Int,4),
					new SqlParameter("@mAppendTime", SqlDbType.DateTime)};
            parameters[0].Value = model.MarketingFeesID;
            parameters[1].Value = model.StoresID;
            parameters[2].Value = model.FeesSubjectID;
            parameters[3].Value = model.mRemark;
            parameters[4].Value = model.mFees;
            parameters[5].Value = model.mDateTime;
            parameters[6].Value = model.mType;
            parameters[7].Value = model.StaffID;
            parameters[8].Value = model.mIsIncomeExpenditure;
            parameters[9].Value = model.mAppendTime;

            DbHelper.ExecuteNonQuery(CommandType.Text,strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void DeleteMarketingFeesInfo(int MarketingFeesID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbMarketingFeesInfo ");
            strSql.Append(" where MarketingFeesID=@MarketingFeesID ");
            SqlParameter[] parameters = {
					new SqlParameter("@MarketingFeesID", SqlDbType.Int,4)};
            parameters[0].Value = MarketingFeesID;

            DbHelper.ExecuteNonQuery(CommandType.Text,strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一组数据
        /// </summary>
        public void DeleteMarketingFeesInfo(string MarketingFeesID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbMarketingFeesInfo ");
            strSql.Append(" where MarketingFeesID in(" + MarketingFeesID + ") ");

            DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString());
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public MarketingFeesInfo GetMarketingFeesInfoModel(int MarketingFeesID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 MarketingFeesID,StoresID,FeesSubjectID,mRemark,mFees,mDateTime,mType,StaffID,mAppendTime,(select tbStoresInfo.sName from tbStoresInfo where tbStoresInfo.StoresID=tbMarketingFeesInfo.[StoresID]) as StoresName,(select tbFeesSubjectInfo.fName from tbFeesSubjectInfo where tbFeesSubjectInfo.FeesSubjectID=tbMarketingFeesInfo.[FeesSubjectID]) as FeesSubjectName,(select tbStaffInfo.sName from tbStaffInfo where tbStaffInfo.StaffID=tbMarketingFeesInfo.StaffID) as StaffName,mIsIncomeExpenditure from tbMarketingFeesInfo ");
            strSql.Append(" where MarketingFeesID=@MarketingFeesID ");
            SqlParameter[] parameters = {
					new SqlParameter("@MarketingFeesID", SqlDbType.Int,4)};
            parameters[0].Value = MarketingFeesID;

            MarketingFeesInfo model = new MarketingFeesInfo();
            DataSet ds = DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["MarketingFeesID"].ToString() != "")
                {
                    model.MarketingFeesID = int.Parse(ds.Tables[0].Rows[0]["MarketingFeesID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["StoresID"].ToString() != "")
                {
                    model.StoresID = int.Parse(ds.Tables[0].Rows[0]["StoresID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["FeesSubjectID"].ToString() != "")
                {
                    model.FeesSubjectID = int.Parse(ds.Tables[0].Rows[0]["FeesSubjectID"].ToString());
                }
                model.mRemark = ds.Tables[0].Rows[0]["mRemark"].ToString();
                if (ds.Tables[0].Rows[0]["mFees"].ToString() != "")
                {
                    model.mFees = decimal.Parse(ds.Tables[0].Rows[0]["mFees"].ToString());
                }
                if (ds.Tables[0].Rows[0]["mDateTime"].ToString() != "")
                {
                    model.mDateTime = DateTime.Parse(ds.Tables[0].Rows[0]["mDateTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["mType"].ToString() != "")
                {
                    model.mType = int.Parse(ds.Tables[0].Rows[0]["mType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["StaffID"].ToString() != "")
                {
                    model.StaffID = int.Parse(ds.Tables[0].Rows[0]["StaffID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["mIsIncomeExpenditure"].ToString() != "")
                {
                    model.mIsIncomeExpenditure = int.Parse(ds.Tables[0].Rows[0]["mIsIncomeExpenditure"].ToString());
                }
                if (ds.Tables[0].Rows[0]["mAppendTime"].ToString() != "")
                {
                    model.mAppendTime = DateTime.Parse(ds.Tables[0].Rows[0]["mAppendTime"].ToString());
                }
                model.StoresName = ds.Tables[0].Rows[0]["StoresName"].ToString();
                model.FeesSubjectName = ds.Tables[0].Rows[0]["FeesSubjectName"].ToString();
                model.StaffName = ds.Tables[0].Rows[0]["StaffName"].ToString();
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
        public DataSet GetMarketingFeesInfoList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select MarketingFeesID,StoresID,FeesSubjectID,mRemark,mFees,mDateTime,mType,StaffID,mAppendTime,(select tbStoresInfo.sName from tbStoresInfo where tbStoresInfo.StoresID=tbMarketingFeesInfo.[StoresID]) as StoresName,(select tbFeesSubjectInfo.fName from tbFeesSubjectInfo where tbFeesSubjectInfo.FeesSubjectID=tbMarketingFeesInfo.[FeesSubjectID]) as FeesSubjectName,(select tbStaffInfo.sName from tbStaffInfo where tbStaffInfo.StaffID=tbMarketingFeesInfo.StaffID) as StaffName,mIsIncomeExpenditure ");
            strSql.Append(" FROM tbMarketingFeesInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelper.ExecuteDataset(CommandType.Text,strSql.ToString());
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataTable GetMarketingFeesInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
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
            parameters[0].Value = "tbMarketingFeesInfo";
            parameters[1].Value = "MarketingFeesID";
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
