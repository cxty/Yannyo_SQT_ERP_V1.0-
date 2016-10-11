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
        #region  StaffStoresInfo

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddStaffStoresInfo(StaffStoresInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tbStaffStoresInfo(");
            strSql.Append("StaffID,StoresID,sType,sDateTime,sAppendTime)");
            strSql.Append(" values (");
            strSql.Append("@StaffID,@StoresID,@sType,@sDateTime,@sAppendTime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@StaffID", SqlDbType.Int,4),
					new SqlParameter("@StoresID", SqlDbType.Int,4),
					new SqlParameter("@sType", SqlDbType.Int,4),
					new SqlParameter("@sDateTime", SqlDbType.DateTime),
					new SqlParameter("@sAppendTime", SqlDbType.DateTime)};
            parameters[0].Value = model.StaffID;
            parameters[1].Value = model.StoresID;
            parameters[2].Value = model.sType;
            parameters[3].Value = model.sDateTime;
            parameters[4].Value = model.sAppendTime;

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
        public void UpdateStaffStoresInfo(StaffStoresInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbStaffStoresInfo set ");
            strSql.Append("StaffID=@StaffID,");
            strSql.Append("StoresID=@StoresID,");
            strSql.Append("sType=@sType,");
            strSql.Append("sDateTime=@sDateTime,");
            strSql.Append("sAppendTime=@sAppendTime");
            strSql.Append(" where StaffStoresID=@StaffStoresID ");
            SqlParameter[] parameters = {
					new SqlParameter("@StaffStoresID", SqlDbType.Int,4),
					new SqlParameter("@StaffID", SqlDbType.Int,4),
					new SqlParameter("@StoresID", SqlDbType.Int,4),
					new SqlParameter("@sType", SqlDbType.Int,4),
					new SqlParameter("@sDateTime", SqlDbType.DateTime),
					new SqlParameter("@sAppendTime", SqlDbType.DateTime)};
            parameters[0].Value = model.StaffStoresID;
            parameters[1].Value = model.StaffID;
            parameters[2].Value = model.StoresID;
            parameters[3].Value = model.sType;
            parameters[4].Value = model.sDateTime;
            parameters[5].Value = model.sAppendTime;

            DbHelper.ExecuteNonQuery(CommandType.Text,strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void DeleteStaffStoresInfo(int StaffStoresID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbStaffStoresInfo ");
            strSql.Append(" where StaffStoresID=@StaffStoresID ");
            SqlParameter[] parameters = {
					new SqlParameter("@StaffStoresID", SqlDbType.Int,4)};
            parameters[0].Value = StaffStoresID;

            DbHelper.ExecuteNonQuery(CommandType.Text,strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一组数据
        /// </summary>
        public void DeleteStaffStoresInfo(string StaffStoresID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbStaffStoresInfo ");
            strSql.Append(" where StaffStoresID in(" + StaffStoresID + ") ");


            DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString());
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public StaffStoresInfo GetStaffStoresInfoModel(int StaffStoresID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 StaffStoresID,StaffID,StoresID,sType,sDateTime,sAppendTime,(select sName from tbStoresInfo where StoresID=tbStaffStoresInfo.StoresID) as StoresName,(select sName from tbStaffInfo where StaffID=tbStaffStoresInfo.StaffID) as StaffName from tbStaffStoresInfo ");
            strSql.Append(" where StaffStoresID=@StaffStoresID ");
            SqlParameter[] parameters = {
					new SqlParameter("@StaffStoresID", SqlDbType.Int,4)};
            parameters[0].Value = StaffStoresID;

            StaffStoresInfo model = new StaffStoresInfo();
            DataSet ds = DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["StaffStoresID"].ToString() != "")
                {
                    model.StaffStoresID = int.Parse(ds.Tables[0].Rows[0]["StaffStoresID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["StaffID"].ToString() != "")
                {
                    model.StaffID = int.Parse(ds.Tables[0].Rows[0]["StaffID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["StoresID"].ToString() != "")
                {
                    model.StoresID = int.Parse(ds.Tables[0].Rows[0]["StoresID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["sType"].ToString() != "")
                {
                    model.sType = int.Parse(ds.Tables[0].Rows[0]["sType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["sDateTime"].ToString() != "")
                {
                    model.sDateTime = DateTime.Parse(ds.Tables[0].Rows[0]["sDateTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["sAppendTime"].ToString() != "")
                {
                    model.sAppendTime = DateTime.Parse(ds.Tables[0].Rows[0]["sAppendTime"].ToString());
                }

                model.StaffName = ds.Tables[0].Rows[0]["StaffName"].ToString();
                model.StoresName = ds.Tables[0].Rows[0]["StoresName"].ToString();

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
        public DataSet GetStaffStoresInfoList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *,(select sName from tbStoresInfo where StoresID=tbStaffStoresInfo.StoresID) as StoresName,(select sName from tbStaffInfo where StaffID=tbStaffStoresInfo.StaffID) as StaffName ");
            strSql.Append(" FROM tbStaffStoresInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelper.ExecuteDataset(CommandType.Text,strSql.ToString());
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataTable GetStaffStoresInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
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
            parameters[0].Value = "tbStaffStoresInfo";
            parameters[1].Value = "StaffStoresID";
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
        /// 取指定门店目前上岗中的人员信息
        /// </summary>
        /// <param name="StoresID"></param>
        /// <param name="sType">人员类型,公司=0,业务员=1,促销员=2,其他=3</param>
        /// <returns></returns>
        public StaffInfo GetStaffByStores(int StoresID, int sType)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from tbStaffInfo where StaffID in( "+
	                                "select top 1 ss.StaffID from tbStaffStoresInfo ss "+
                                    "where ss.StoresID=@StoresID and ss.sType=0 and ss.StaffID in(select StaffID from tbStaffInfo where sType =@sType) " +
	                                "and ss.StaffID not in(select StaffID from tbStaffStoresInfo where StoresID=ss.StoresID and sType=1 and sDateTime<GETDATE()) "+
                                    " order by ss.sDateTime desc " +
                                    ") and sType=@sType and sState = 0");
            SqlParameter[] parameters = {
                    new SqlParameter("@StoresID", SqlDbType.Int, 4),
                    new SqlParameter("@sType", SqlDbType.Int, 4)
                                        };
            parameters[0].Value = StoresID;
            parameters[1].Value = sType;

            StaffInfo model = new StaffInfo();
            DataSet ds = DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["StaffID"].ToString() != "")
                {
                    model.StaffID = int.Parse(ds.Tables[0].Rows[0]["StaffID"].ToString());
                }
                model.sName = ds.Tables[0].Rows[0]["sName"].ToString();
                model.sSex = ds.Tables[0].Rows[0]["sSex"].ToString();
                model.sTel = ds.Tables[0].Rows[0]["sTel"].ToString();
                model.sCarID = ds.Tables[0].Rows[0]["sCarID"].ToString();
                if (ds.Tables[0].Rows[0]["sType"].ToString() != "")
                {
                    model.sType = int.Parse(ds.Tables[0].Rows[0]["sType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["sState"].ToString() != "")
                {
                    model.sState = int.Parse(ds.Tables[0].Rows[0]["sState"].ToString());
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
        /// 人员上离岗记录
        /// </summary>
        public DataTable GetStaff_StoresList(int StaffID, DateTime bDate, DateTime eDate, int sType)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@StaffID", SqlDbType.Int),
                    new SqlParameter("@bDate", SqlDbType.DateTime),
                    new SqlParameter("@eDate", SqlDbType.DateTime),
                    new SqlParameter("@sType", SqlDbType.Int),
                    new SqlParameter("@StoresID", SqlDbType.Int)
                    };
            parameters[0].Value = StaffID;
            parameters[1].Value = bDate;
            parameters[2].Value = eDate;
            parameters[3].Value = sType;
            parameters[4].Value = 0;

            DataSet ds = DbHelper.ExecuteDataset(CommandType.StoredProcedure, "sp_GetStaff_StoresList", parameters);
            if (ds != null)
            {
                return ds.Tables[0];
            }
            else 
            {
                return null;
            }
        }
        public DataTable GetStaff_StoresList(int StaffID, int StoresID, DateTime bDate, DateTime eDate, int sType)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@StaffID", SqlDbType.Int),
                    new SqlParameter("@bDate", SqlDbType.DateTime),
                    new SqlParameter("@eDate", SqlDbType.DateTime),
                    new SqlParameter("@sType", SqlDbType.Int),
                    new SqlParameter("@StoresID", SqlDbType.Int)
                    };
            parameters[0].Value = StaffID;
            parameters[1].Value = bDate;
            parameters[2].Value = eDate;
            parameters[3].Value = sType;
            parameters[4].Value = StoresID;

            DataSet ds = DbHelper.ExecuteDataset(CommandType.StoredProcedure, "sp_GetStaff_StoresList", parameters);
            if (ds != null)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }
        #endregion  成员方法
    }
}
