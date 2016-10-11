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
        public bool ExistsAPMoneyInfo(int APMoneyID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tbAPMoneyInfo");
            strSql.Append(" where APMoneyID=@APMoneyID ");
            SqlParameter[] parameters = {
					new SqlParameter("@APMoneyID", SqlDbType.Int,4)};
            parameters[0].Value = APMoneyID;

            return ((int)DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters)) > 0;
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddAPMoneyInfo(APMoneyInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tbAPMoneyInfo(");
            strSql.Append("APObjID,APObjType,aPMoney,aPayMoney,aOtherMoney,aReMake,aDoDateTime,aAppendTime,FeesSubjectID,aErpOrderIDStr,aNPMoney)");
            strSql.Append(" values (");
            strSql.Append("@APObjID,@APObjType,@aPMoney,@aPayMoney,@aOtherMoney,@aReMake,@aDoDateTime,@aAppendTime,@FeesSubjectID,@aErpOrderIDStr,@aNPMoney)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@APObjID", SqlDbType.Int,4),
					new SqlParameter("@APObjType", SqlDbType.Int,4),
					new SqlParameter("@aPMoney", SqlDbType.Money,8),
					new SqlParameter("@aPayMoney", SqlDbType.Money,8),
					new SqlParameter("@aOtherMoney", SqlDbType.Money,8),
					new SqlParameter("@aReMake", SqlDbType.VarChar,256),
					new SqlParameter("@aDoDateTime", SqlDbType.DateTime),
					new SqlParameter("@aAppendTime", SqlDbType.DateTime),
                                        new SqlParameter("@FeesSubjectID", SqlDbType.Int,4),
                                        new SqlParameter("@aErpOrderIDStr", SqlDbType.NText),
                                        new SqlParameter("@aNPMoney", SqlDbType.Money,8),};
            parameters[0].Value = model.APObjID;
            parameters[1].Value = model.APObjType;
            parameters[2].Value = model.aPMoney;
            parameters[3].Value = model.aPayMoney;
            parameters[4].Value = model.aOtherMoney;
            parameters[5].Value = model.aReMake;
            parameters[6].Value = model.aDoDateTime;
            parameters[7].Value = model.aAppendTime;
            parameters[8].Value = model.FeesSubjectID;
            parameters[9].Value = model.aErpOrderIDStr;
            parameters[10].Value = model.aNPMoney;

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
        public void UpdateAPMoneyInfo(APMoneyInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbAPMoneyInfo set ");
            strSql.Append("APObjID=@APObjID,");
            strSql.Append("APObjType=@APObjType,");
            strSql.Append("aPMoney=@aPMoney,");
            strSql.Append("aPayMoney=@aPayMoney,");
            strSql.Append("aOtherMoney=@aOtherMoney,");
            strSql.Append("aReMake=@aReMake,");
            strSql.Append("aDoDateTime=@aDoDateTime,");
            strSql.Append("aAppendTime=@aAppendTime,");
            strSql.Append("FeesSubjectID=@FeesSubjectID,");
            strSql.Append("aErpOrderIDStr=@aErpOrderIDStr,");
            strSql.Append("aNPMoney=@aNPMoney");
            strSql.Append(" where APMoneyID=@APMoneyID ");
            SqlParameter[] parameters = {
					new SqlParameter("@APMoneyID", SqlDbType.Int,4),
					new SqlParameter("@APObjID", SqlDbType.Int,4),
					new SqlParameter("@APObjType", SqlDbType.Int,4),
					new SqlParameter("@aPMoney", SqlDbType.Money,8),
					new SqlParameter("@aPayMoney", SqlDbType.Money,8),
					new SqlParameter("@aOtherMoney", SqlDbType.Money,8),
					new SqlParameter("@aReMake", SqlDbType.VarChar,256),
					new SqlParameter("@aDoDateTime", SqlDbType.DateTime),
					new SqlParameter("@aAppendTime", SqlDbType.DateTime),
                    new SqlParameter("@FeesSubjectID", SqlDbType.Int,4),
                    new SqlParameter("@aErpOrderIDStr", SqlDbType.NText),
                                        new SqlParameter("@aNPMoney", SqlDbType.Money,8)};
            parameters[0].Value = model.APMoneyID;
            parameters[1].Value = model.APObjID;
            parameters[2].Value = model.APObjType;
            parameters[3].Value = model.aPMoney;
            parameters[4].Value = model.aPayMoney;
            parameters[5].Value = model.aOtherMoney;
            parameters[6].Value = model.aReMake;
            parameters[7].Value = model.aDoDateTime;
            
            
            parameters[8].Value = model.aAppendTime;
            parameters[9].Value = model.FeesSubjectID;
            parameters[10].Value = model.aErpOrderIDStr;
            parameters[11].Value = model.aNPMoney;

            DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void DeleteAPMoneyInfo(int APMoneyID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbAPMoneyInfo ");
            strSql.Append(" where APMoneyID=@APMoneyID ");
            SqlParameter[] parameters = {
					new SqlParameter("@APMoneyID", SqlDbType.Int,4)};
            parameters[0].Value = APMoneyID;

            DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void DeleteAPMoneyInfo(string APMoneyID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbAPMoneyInfo ");
            strSql.Append(" where APMoneyID in(" + APMoneyID + ") ");

            DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString());
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public APMoneyInfo GetAPMoneyInfoModel(int APMoneyID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 APMoneyID,APObjID,APObjType,aPMoney,aPayMoney,aOtherMoney,aReMake,aDoDateTime,aAppendTime,FeesSubjectID,aErpOrderIDStr,aNPMoney," +
                "(CASE APObjType " +
                " when 0 then dbo.fun_GetNameForObjID(APObjID,0) " +
                " when 1 then dbo.fun_GetNameForObjID(APObjID,1) " +
                " when 2 then dbo.fun_GetNameForObjID(APObjID,2) " +
                "end) as APObjName,(select tbFeesSubjectInfo.fName from tbFeesSubjectInfo where tbFeesSubjectInfo.FeesSubjectID=tbAPMoneyInfo.[FeesSubjectID]) as FeesSubjectName from tbAPMoneyInfo ");
            strSql.Append(" where APMoneyID=@APMoneyID ");
            SqlParameter[] parameters = {
					new SqlParameter("@APMoneyID", SqlDbType.Int,4)};
            parameters[0].Value = APMoneyID;

            APMoneyInfo model = new APMoneyInfo();
            DataSet ds = DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["APMoneyID"].ToString() != "")
                {
                    model.APMoneyID = int.Parse(ds.Tables[0].Rows[0]["APMoneyID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["APObjID"].ToString() != "")
                {
                    model.APObjID = int.Parse(ds.Tables[0].Rows[0]["APObjID"].ToString());
                }
                model.APObjName = ds.Tables[0].Rows[0]["APObjName"].ToString();
                model.FeesSubjectName = ds.Tables[0].Rows[0]["FeesSubjectName"].ToString();
                model.aErpOrderIDStr = ds.Tables[0].Rows[0]["aErpOrderIDStr"].ToString();
                if (ds.Tables[0].Rows[0]["APObjType"].ToString() != "")
                {
                    model.APObjType = int.Parse(ds.Tables[0].Rows[0]["APObjType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["aNPMoney"].ToString() != "")
                {
                    model.aNPMoney = decimal.Parse(ds.Tables[0].Rows[0]["aNPMoney"].ToString());
                }
                if (ds.Tables[0].Rows[0]["aPMoney"].ToString() != "")
                {
                    model.aPMoney = decimal.Parse(ds.Tables[0].Rows[0]["aPMoney"].ToString());
                }
                if (ds.Tables[0].Rows[0]["aPayMoney"].ToString() != "")
                {
                    model.aPayMoney = decimal.Parse(ds.Tables[0].Rows[0]["aPayMoney"].ToString());
                }
                if (ds.Tables[0].Rows[0]["aOtherMoney"].ToString() != "")
                {
                    model.aOtherMoney = decimal.Parse(ds.Tables[0].Rows[0]["aOtherMoney"].ToString());
                }
                model.aReMake = ds.Tables[0].Rows[0]["aReMake"].ToString();
                if (ds.Tables[0].Rows[0]["aDoDateTime"].ToString() != "")
                {
                    model.aDoDateTime = DateTime.Parse(ds.Tables[0].Rows[0]["aDoDateTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["aAppendTime"].ToString() != "")
                {
                    model.aAppendTime = DateTime.Parse(ds.Tables[0].Rows[0]["aAppendTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["FeesSubjectID"].ToString() != "")
                {
                    model.FeesSubjectID = int.Parse(ds.Tables[0].Rows[0]["FeesSubjectID"].ToString());
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
        public DataSet GetAPMoneyInfoList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select APMoneyID,APObjID,APObjType,aPMoney,aPayMoney,aOtherMoney,aReMake,aDoDateTime,aAppendTime,FeesSubjectID,aErpOrderIDStr,aNPMoney ");
            strSql.Append(" FROM tbAPMoneyInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelper.ExecuteDataset(CommandType.Text,strSql.ToString());
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataTable GetAPMoneyInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
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
            parameters[0].Value = "tbAPMoneyInfo";
            parameters[1].Value = "APMoneyID";
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
        /// <summary>
        /// 指定时间段内应收数据
        /// </summary>
        /// <param name="bDate">开始时间</param>
        /// <param name="eDate">结束时间</param>
        public DataTable GetErpWillPay(DateTime bDate, DateTime eDate)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@bDate", SqlDbType.DateTime),
                    new SqlParameter("@eDate", SqlDbType.DateTime),
                    };
            parameters[0].Value = bDate;
            parameters[1].Value = eDate;
            DataSet ds = DbHelper.ExecuteDataset(CommandType.StoredProcedure, "sp_ErpWillPay", parameters);
            if (ds != null)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }
    }
}
