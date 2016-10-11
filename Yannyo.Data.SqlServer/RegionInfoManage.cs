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
        #region  RegionInfo
       
        /// <summary>
        /// 获得客户上级分类信息
        /// </summary>
        /// <param name="ParentID"></param>
        /// <returns></returns>
        public DataTable geAreaClassList(int ParentID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("  select RegionID,rUpID,rName,rOrder,rAppendTime,");
            strSql.Append(" case when rUpID='" + ParentID + "' then ");
            strSql.Append(" (select rName from tbRegionInfo where RegionID='" + ParentID + "') else 'null' ");
            strSql.Append(" end as parentName  from tbRegionInfo where rUpID='" + ParentID + "' and rState=0");
            return DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString()).Tables[0];
        }
        /// <summary>
        /// 获得客户分类明细
        /// </summary>
        /// <param name="ProductClassID"></param>
        /// <returns></returns>
        public DataTable GetAreaDetails(int AreaClassID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select RegionID,rUpID,rName,rOrder,rAppendTime from tbRegionInfo ");
            if (AreaClassID > -1)
            {
                strSql.Append(" where rUpID= '" + AreaClassID + "' and rState=0");
            }
            return DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString()).Tables[0];
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistsRegionInfo(string rName, int rUpID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tbRegionInfo");
            strSql.Append(" where rUpID=@rUpID and rName=@rName ");
            SqlParameter[] parameters = {
					new SqlParameter("@rUpID", SqlDbType.Int,4),
                                        new SqlParameter("@rName", SqlDbType.VarChar,50)};
            parameters[0].Value = rUpID;
            parameters[1].Value = rName;

            return ((int)DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters)) > 0;
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddRegionInfo(RegionInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tbRegionInfo(");
            strSql.Append("rName,rUpID,rOrder,rState,rAppendTime)");
            strSql.Append(" values (");
            strSql.Append("@rName,@rUpID,@rOrder,@rState,@rAppendTime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@rName", SqlDbType.VarChar,50),
					new SqlParameter("@rUpID", SqlDbType.Int,4),
					new SqlParameter("@rOrder", SqlDbType.Int,4),
					new SqlParameter("@rState", SqlDbType.Int,4),
					new SqlParameter("@rAppendTime", SqlDbType.DateTime)};
            parameters[0].Value = model.rName;
            parameters[1].Value = model.rUpID;
            parameters[2].Value = model.rOrder;
            parameters[3].Value = model.rState;
            parameters[4].Value = model.rAppendTime;

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
        public int UpdateRegionInfo(RegionInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbRegionInfo set ");
            strSql.Append("rName=@rName,");
            strSql.Append("rUpID=@rUpID,");
            strSql.Append("rOrder=@rOrder,");
            strSql.Append("rState=@rState,");
            strSql.Append("rAppendTime=@rAppendTime");
            strSql.Append(" where RegionID=@RegionID ");
            SqlParameter[] parameters = {
					new SqlParameter("@RegionID", SqlDbType.Int,4),
					new SqlParameter("@rName", SqlDbType.VarChar,50),
					new SqlParameter("@rUpID", SqlDbType.Int,4),
					new SqlParameter("@rOrder", SqlDbType.Int,4),
					new SqlParameter("@rState", SqlDbType.Int,4),
					new SqlParameter("@rAppendTime", SqlDbType.DateTime)};
            parameters[0].Value = model.RegionID;
            parameters[1].Value = model.rName;
            parameters[2].Value = model.rUpID;
            parameters[3].Value = model.rOrder;
            parameters[4].Value = model.rState;
            parameters[5].Value = model.rAppendTime;

            return DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int DeleteRegionInfo(int RegionID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbRegionInfo ");
            strSql.Append(" where RegionID=@RegionID ");
            SqlParameter[] parameters = {
					new SqlParameter("@RegionID", SqlDbType.Int,4)};
            parameters[0].Value = RegionID;

           return  DbHelper.ExecuteNonQuery(CommandType.Text,strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public RegionInfo GetRegionInfoModel(int RegionID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 RegionID,rName,rUpID,rOrder,rState,rAppendTime from tbRegionInfo ");
            strSql.Append(" where RegionID=@RegionID ");
            SqlParameter[] parameters = {
					new SqlParameter("@RegionID", SqlDbType.Int,4)};
            parameters[0].Value = RegionID;

            RegionInfo model = new RegionInfo();
            DataSet ds = DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["RegionID"].ToString() != "")
                {
                    model.RegionID = int.Parse(ds.Tables[0].Rows[0]["RegionID"].ToString());
                }
                model.rName = ds.Tables[0].Rows[0]["rName"].ToString();
                if (ds.Tables[0].Rows[0]["rUpID"].ToString() != "")
                {
                    model.rUpID = int.Parse(ds.Tables[0].Rows[0]["rUpID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["rOrder"].ToString() != "")
                {
                    model.rOrder = int.Parse(ds.Tables[0].Rows[0]["rOrder"].ToString());
                }
                if (ds.Tables[0].Rows[0]["rState"].ToString() != "")
                {
                    model.rState = int.Parse(ds.Tables[0].Rows[0]["rState"].ToString());
                }
                if (ds.Tables[0].Rows[0]["rAppendTime"].ToString() != "")
                {
                    model.rAppendTime = DateTime.Parse(ds.Tables[0].Rows[0]["rAppendTime"].ToString());
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
        public RegionInfo GetRegionInfoModelByName(string rName)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 RegionID,rName,rUpID,rOrder,rState,rAppendTime from tbRegionInfo ");
            strSql.Append(" where rName=@rName ");
            SqlParameter[] parameters = {
					new SqlParameter("@rName", SqlDbType.VarChar,50)};
            parameters[0].Value = rName;

            RegionInfo model = new RegionInfo();
            DataSet ds = DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["RegionID"].ToString() != "")
                {
                    model.RegionID = int.Parse(ds.Tables[0].Rows[0]["RegionID"].ToString());
                }
                model.rName = ds.Tables[0].Rows[0]["rName"].ToString();
                if (ds.Tables[0].Rows[0]["rUpID"].ToString() != "")
                {
                    model.rUpID = int.Parse(ds.Tables[0].Rows[0]["rUpID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["rOrder"].ToString() != "")
                {
                    model.rOrder = int.Parse(ds.Tables[0].Rows[0]["rOrder"].ToString());
                }
                if (ds.Tables[0].Rows[0]["rState"].ToString() != "")
                {
                    model.rState = int.Parse(ds.Tables[0].Rows[0]["rState"].ToString());
                }
                if (ds.Tables[0].Rows[0]["rAppendTime"].ToString() != "")
                {
                    model.rAppendTime = DateTime.Parse(ds.Tables[0].Rows[0]["rAppendTime"].ToString());
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
        public RegionInfo GetRegionInfoModelLikeName(string rName)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 RegionID,rName,rUpID,rOrder,rState,rAppendTime from tbRegionInfo ");
            strSql.Append(" where rName like '%" + rName + "%' ");

            RegionInfo model = new RegionInfo();
            DataSet ds = DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["RegionID"].ToString() != "")
                {
                    model.RegionID = int.Parse(ds.Tables[0].Rows[0]["RegionID"].ToString());
                }
                model.rName = ds.Tables[0].Rows[0]["rName"].ToString();
                if (ds.Tables[0].Rows[0]["rUpID"].ToString() != "")
                {
                    model.rUpID = int.Parse(ds.Tables[0].Rows[0]["rUpID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["rOrder"].ToString() != "")
                {
                    model.rOrder = int.Parse(ds.Tables[0].Rows[0]["rOrder"].ToString());
                }
                if (ds.Tables[0].Rows[0]["rState"].ToString() != "")
                {
                    model.rState = int.Parse(ds.Tables[0].Rows[0]["rState"].ToString());
                }
                if (ds.Tables[0].Rows[0]["rAppendTime"].ToString() != "")
                {
                    model.rAppendTime = DateTime.Parse(ds.Tables[0].Rows[0]["rAppendTime"].ToString());
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
        public DataSet GetRegionInfoList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select RegionID,rName,rUpID,rOrder,rState,rAppendTime ");
            strSql.Append(" FROM tbRegionInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelper.ExecuteDataset(CommandType.Text,strSql.ToString());
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataTable GetRegionInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
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
            parameters[0].Value = "tbRegionInfo";
            parameters[1].Value = "RegionID";
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
        /// 更新排序
        /// </summary>
        /// <param name="sCID">源</param>
        /// <param name="tCID">目标</param>
        /// <param name="nCIDstr">排序后的目标同级ID串</param>
        /// <param name="pCID">目标父级编号</param>
        public void UpdateRegionOrder(string sCID, string tCID, string nCIDstr, string pCID)
        {
            if (sCID.Trim() != "" && tCID.Trim() != "" && nCIDstr.Trim() != "" && pCID.Trim() != "")
            {
                string[] nCIDstrArray = Utils.SplitString(nCIDstr, ",");
                StringBuilder strSql = new StringBuilder();
                if (nCIDstrArray.Length > 0)
                {
                    int total = 0;
                    for (int i = 0; i < nCIDstrArray.Length; i++)
                    {
                        if (nCIDstrArray[i].Trim() != "")
                        {
                            strSql.Append("update tbRegionInfo set rUpID=" + pCID + ",rOrder=" + total.ToString() + " where RegionID=" + nCIDstrArray[i].Trim() + ";");
                            total++;
                        }
                    }
                }
                if (strSql.ToString().Trim() != "")
                {
                    DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString());
                }
            }
        }
        #endregion
    }
}
