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
        public bool ExistsARMoneyInfo(int ARMoneyID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tbARMoneyInfo");
            strSql.Append(" where ARMoneyID=@ARMoneyID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ARMoneyID", SqlDbType.Int,4)};
            parameters[0].Value = ARMoneyID;

            return ((int)DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters)) > 0;
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddARMoneyInfo(ARMoneyInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tbARMoneyInfo(");
            strSql.Append("ARObjID,ARObjType,aAMoney,aBMoney,aOpenDate,aOpenMoney,aDate,aActualDate,aActualMoney,aUpdateTime,aSteps,aAppendTime,aErpOrderIDStr)");
            strSql.Append(" values (");
            strSql.Append("@ARObjID,@ARObjType,@aAMoney,@aBMoney,@aOpenDate,@aOpenMoney,@aDate,@aActualDate,@aActualMoney,@aUpdateTime,@aSteps,@aAppendTime,@aErpOrderIDStr)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@ARObjID", SqlDbType.Int,4),
					new SqlParameter("@ARObjType", SqlDbType.Int,4),
					new SqlParameter("@aAMoney", SqlDbType.Money,8),
					new SqlParameter("@aBMoney", SqlDbType.Money,8),
					new SqlParameter("@aOpenDate", SqlDbType.DateTime),
					new SqlParameter("@aOpenMoney", SqlDbType.Money,8),
					new SqlParameter("@aDate", SqlDbType.DateTime),
					new SqlParameter("@aActualDate", SqlDbType.DateTime),
					new SqlParameter("@aActualMoney", SqlDbType.Money,8),
					new SqlParameter("@aUpdateTime", SqlDbType.DateTime),
					new SqlParameter("@aSteps", SqlDbType.Int,4),
					new SqlParameter("@aAppendTime", SqlDbType.DateTime),
                                        new SqlParameter("@aErpOrderIDStr", SqlDbType.NText)};
            parameters[0].Value = model.ARObjID;
            parameters[1].Value = model.ARObjType;
            parameters[2].Value = model.aAMoney;
            parameters[3].Value = model.aBMoney;
            parameters[4].Value = model.aOpenDate;
            parameters[5].Value = model.aOpenMoney;
            parameters[6].Value = model.aDate;
            parameters[7].Value = model.aActualDate;
            parameters[8].Value = model.aActualMoney;
            parameters[9].Value = model.aUpdateTime;
            parameters[10].Value = model.aSteps;
            parameters[11].Value = model.aAppendTime;
            parameters[12].Value = model.aErpOrderIDStr;

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
        public void UpdateARMoneyInfo(ARMoneyInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbARMoneyInfo set ");
            strSql.Append("ARObjID=@ARObjID,");
            strSql.Append("ARObjType=@ARObjType,");
            strSql.Append("aAMoney=@aAMoney,");
            strSql.Append("aBMoney=@aBMoney,");
            strSql.Append("aOpenDate=@aOpenDate,");
            strSql.Append("aOpenMoney=@aOpenMoney,");
            strSql.Append("aDate=@aDate,");
            strSql.Append("aActualDate=@aActualDate,");
            strSql.Append("aActualMoney=@aActualMoney,");
            strSql.Append("aUpdateTime=@aUpdateTime,");
            strSql.Append("aSteps=@aSteps,");
            strSql.Append("aAppendTime=@aAppendTime,");
            strSql.Append("aErpOrderIDStr=@aErpOrderIDStr");
            strSql.Append(" where ARMoneyID=@ARMoneyID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ARMoneyID", SqlDbType.Int,4),
					new SqlParameter("@ARObjID", SqlDbType.Int,4),
					new SqlParameter("@ARObjType", SqlDbType.Int,4),
					new SqlParameter("@aAMoney", SqlDbType.Money,8),
					new SqlParameter("@aBMoney", SqlDbType.Money,8),
					new SqlParameter("@aOpenDate", SqlDbType.DateTime),
					new SqlParameter("@aOpenMoney", SqlDbType.Money,8),
					new SqlParameter("@aDate", SqlDbType.DateTime),
					new SqlParameter("@aActualDate", SqlDbType.DateTime),
					new SqlParameter("@aActualMoney", SqlDbType.Money,8),
					new SqlParameter("@aUpdateTime", SqlDbType.DateTime),
					new SqlParameter("@aSteps", SqlDbType.Int,4),
					new SqlParameter("@aAppendTime", SqlDbType.DateTime),
                                        new SqlParameter("@aErpOrderIDStr", SqlDbType.NText)};
            parameters[0].Value = model.ARMoneyID;
            parameters[1].Value = model.ARObjID;
            parameters[2].Value = model.ARObjType;
            parameters[3].Value = model.aAMoney;
            parameters[4].Value = model.aBMoney;
            parameters[5].Value = model.aOpenDate;
            parameters[6].Value = model.aOpenMoney;
            parameters[7].Value = model.aDate;
            parameters[8].Value = model.aActualDate;
            parameters[9].Value = model.aActualMoney;
            parameters[10].Value = model.aUpdateTime;
            parameters[11].Value = model.aSteps;
            parameters[12].Value = model.aAppendTime;
            parameters[13].Value = model.aErpOrderIDStr;

            DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void DeleteARMoneyInfo(int ARMoneyID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbARMoneyInfo ");
            strSql.Append(" where ARMoneyID=@ARMoneyID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ARMoneyID", SqlDbType.Int,4)};
            parameters[0].Value = ARMoneyID;

            DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void DeleteARMoneyInfo(string ARMoneyID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbARMoneyInfo ");
            strSql.Append(" where ARMoneyID in(" + ARMoneyID + ") ");

            DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString());
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ARMoneyInfo GetARMoneyInfoModel(int ARMoneyID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ARMoneyID,ARObjID,ARObjType,aAMoney,aBMoney,aOpenDate,aOpenMoney,aDate,aActualDate,aActualMoney,aUpdateTime,aSteps,aAppendTime,aErpOrderIDStr," +
                "(CASE ARObjType "+
                " when 0 then dbo.fun_GetNameForObjID(ARObjID,0) " +
                " when 1 then dbo.fun_GetNameForObjID(ARObjID,1) " +
                " when 2 then dbo.fun_GetNameForObjID(ARObjID,3) " +
                "end) as ARObjName from tbARMoneyInfo ");
            strSql.Append(" where ARMoneyID=@ARMoneyID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ARMoneyID", SqlDbType.Int,4)};
            parameters[0].Value = ARMoneyID;

            ARMoneyInfo model = new ARMoneyInfo();
            DataSet ds = DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ARMoneyID"].ToString() != "")
                {
                    model.ARMoneyID = int.Parse(ds.Tables[0].Rows[0]["ARMoneyID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ARObjID"].ToString() != "")
                {
                    model.ARObjID = int.Parse(ds.Tables[0].Rows[0]["ARObjID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ARObjType"].ToString() != "")
                {
                    model.ARObjType = int.Parse(ds.Tables[0].Rows[0]["ARObjType"].ToString());
                }
                model.ARObjName = ds.Tables[0].Rows[0]["ARObjName"].ToString();
                model.aErpOrderIDStr = ds.Tables[0].Rows[0]["aErpOrderIDStr"].ToString();
                if (ds.Tables[0].Rows[0]["aAMoney"].ToString() != "")
                {
                    model.aAMoney = decimal.Parse(ds.Tables[0].Rows[0]["aAMoney"].ToString());
                }
                if (ds.Tables[0].Rows[0]["aBMoney"].ToString() != "")
                {
                    model.aBMoney = decimal.Parse(ds.Tables[0].Rows[0]["aBMoney"].ToString());
                }
                if (ds.Tables[0].Rows[0]["aOpenDate"].ToString() != "")
                {
                    model.aOpenDate = DateTime.Parse(ds.Tables[0].Rows[0]["aOpenDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["aOpenMoney"].ToString() != "")
                {
                    model.aOpenMoney = decimal.Parse(ds.Tables[0].Rows[0]["aOpenMoney"].ToString());
                }
                if (ds.Tables[0].Rows[0]["aDate"].ToString() != "")
                {
                    model.aDate = DateTime.Parse(ds.Tables[0].Rows[0]["aDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["aActualDate"].ToString() != "")
                {
                    model.aActualDate = DateTime.Parse(ds.Tables[0].Rows[0]["aActualDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["aActualMoney"].ToString() != "")
                {
                    model.aActualMoney = decimal.Parse(ds.Tables[0].Rows[0]["aActualMoney"].ToString());
                }
                if (ds.Tables[0].Rows[0]["aUpdateTime"].ToString() != "")
                {
                    model.aUpdateTime = DateTime.Parse(ds.Tables[0].Rows[0]["aUpdateTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["aSteps"].ToString() != "")
                {
                    model.aSteps = int.Parse(ds.Tables[0].Rows[0]["aSteps"].ToString());
                }
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
        public DataSet GetARMoneyInfoList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ARMoneyID,ARObjID,ARObjType,aAMoney,aBMoney,aOpenDate,aOpenMoney,aDate,aActualDate,aActualMoney,aUpdateTime,aSteps,aAppendTime,aErpOrderIDStr ");
            strSql.Append(" FROM tbARMoneyInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelper.ExecuteDataset(CommandType.Text,strSql.ToString());
        }

        
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataTable GetARMoneyInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
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
            parameters[0].Value = "tbARMoneyInfo";
            parameters[1].Value = "ARMoneyID";
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
        /// <param name="C_CODE">门店,客户编码</param>
        /// <param name="C_NAME">门店名称</param>
        /// <param name="bDate">开始时间</param>
        /// <param name="eDate">结束时间</param>
        public DataTable GetErpCustomerPay(string C_CODE, string C_NAME, DateTime bDate, DateTime eDate)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@C_CODE", SqlDbType.VarChar, 50),
                    new SqlParameter("@C_NAME", SqlDbType.VarChar, 128),
                    new SqlParameter("@bDate", SqlDbType.DateTime),
                    new SqlParameter("@eDate", SqlDbType.DateTime),
                    new SqlParameter("@PaySystemName",SqlDbType.VarChar, 128),
                    };
            parameters[0].Value = C_CODE;
            parameters[1].Value = C_NAME;
            parameters[2].Value = bDate;
            parameters[3].Value = eDate;
            parameters[4].Value = "";
            DataSet ds = DbHelper.ExecuteDataset(CommandType.StoredProcedure, "sp_ErpCustomerPay", parameters);
            if (ds != null)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 指定时间段内应收数据
        /// </summary>
        /// <param name="C_CODE">门店,客户编码</param>
        /// <param name="C_NAME">门店名称</param>
        /// <param name="bDate">开始时间</param>
        /// <param name="eDate">结束时间</param>
        /// <param name="PaySystemName">结算系统名称</param>
        public DataTable GetErpCustomerPay(string C_CODE, string C_NAME, DateTime bDate, DateTime eDate, string PaySystemName)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@C_CODE", SqlDbType.VarChar, 50),
                    new SqlParameter("@C_NAME", SqlDbType.VarChar, 128),
                    new SqlParameter("@bDate", SqlDbType.DateTime),
                    new SqlParameter("@eDate", SqlDbType.DateTime),
                    new SqlParameter("@PaySystemName",SqlDbType.VarChar, 128),
                    };
            parameters[0].Value = C_CODE;
            parameters[1].Value = C_NAME;
            parameters[2].Value = bDate;
            parameters[3].Value = eDate;
            parameters[4].Value = PaySystemName;
            DataSet ds = DbHelper.ExecuteDataset(CommandType.StoredProcedure, "sp_ErpCustomerPay", parameters);
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
