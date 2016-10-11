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
        #region storage
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistsStorageInfo(string sName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tbStorageInfo");
            strSql.Append(" where sName=@sName ");
            SqlParameter[] parameters = {
					new SqlParameter("@sName", SqlDbType.VarChar,50)};
            parameters[0].Value = sName;

            return ((int)DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters)) > 0;
        }
        public bool ExistsStorageInfoByCode(string sCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tbStorageInfo");
            strSql.Append(" where sCode=@sCode ");
            SqlParameter[] parameters = {
					new SqlParameter("@sCode", SqlDbType.VarChar,50)};
            parameters[0].Value = sCode;

            return ((int)DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters)) > 0;
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddStorageInfo(StorageInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tbStorageInfo(");
            strSql.Append("sCode,sName,sManager,sTel,sAddress,sRemake,sAppendTime,StorageClassID,sState)");
            strSql.Append(" values (");
            strSql.Append("@sCode,@sName,@sManager,@sTel,@sAddress,@sRemake,@sAppendTime,@StorageClassID,@sState)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@sCode", SqlDbType.VarChar,50),
					new SqlParameter("@sName", SqlDbType.VarChar,50),
					new SqlParameter("@sManager", SqlDbType.Int,4),
					new SqlParameter("@sTel", SqlDbType.VarChar,50),
					new SqlParameter("@sAddress", SqlDbType.VarChar,512),
					new SqlParameter("@sRemake", SqlDbType.VarChar,1024),
					new SqlParameter("@sAppendTime", SqlDbType.DateTime),
                    new SqlParameter("@StorageClassID", SqlDbType.Int,4),
                        new SqlParameter("@sState", SqlDbType.Int,4)
                                        };

            parameters[0].Value = model.sCode;
            parameters[1].Value = model.sName;
            parameters[2].Value = model.sManager;
            parameters[3].Value = model.sTel;
            parameters[4].Value = model.sAddress;
            parameters[5].Value = model.sRemake;
            parameters[6].Value = model.sAppendTime;
            parameters[7].Value = model.StorageClassID;
            parameters[8].Value = model.sState;

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
        public void UpdateStorageInfo(StorageInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbStorageInfo set ");
            strSql.Append("sCode=@sCode,");
            strSql.Append("StorageClassID=@StorageClassID,");
            strSql.Append("sName=@sName,");
            strSql.Append("sManager=@sManager,");
            strSql.Append("sTel=@sTel,");
            strSql.Append("sAddress=@sAddress,");
            strSql.Append("sRemake=@sRemake,");
            strSql.Append("sAppendTime=@sAppendTime,");
            strSql.Append("sState=@sState");
            strSql.Append(" where StorageID=@StorageID ");
            SqlParameter[] parameters = {
					new SqlParameter("@StorageID", SqlDbType.Int,4),
					new SqlParameter("@sCode", SqlDbType.VarChar,50),
                    new SqlParameter("@StorageClassID", SqlDbType.Int,4),
					new SqlParameter("@sName", SqlDbType.VarChar,50),
					new SqlParameter("@sManager", SqlDbType.Int,4),
					new SqlParameter("@sTel", SqlDbType.VarChar,50),
					new SqlParameter("@sAddress", SqlDbType.VarChar,512),
					new SqlParameter("@sRemake", SqlDbType.VarChar,1024),
					new SqlParameter("@sAppendTime", SqlDbType.DateTime),
                    new SqlParameter("@sState", SqlDbType.Int,4),
                    
                                        };
            parameters[0].Value = model.StorageID;
            parameters[1].Value = model.sCode;
            parameters[2].Value = model.StorageClassID;
            parameters[3].Value = model.sName;
            parameters[4].Value = model.sManager;
            parameters[5].Value = model.sTel;
            parameters[6].Value = model.sAddress;
            parameters[7].Value = model.sRemake;
            parameters[8].Value = model.sAppendTime;
            parameters[9].Value = model.sState;
           

            DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void DeleteStorageInfo(int StorageID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbStorageInfo ");
            strSql.Append(" where StorageID=@StorageID ");
            SqlParameter[] parameters = {
					new SqlParameter("@StorageID", SqlDbType.Int,4)};
            parameters[0].Value = StorageID;

            DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        public void DeleteStorageInfo(string StorageID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbStorageInfo ");
            strSql.Append(" where StorageID in("+StorageID+") ");


            DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString());
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public StorageInfo GetStorageInfoModel(int StorageID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select  top 1 StorageID,sCode,sName,sManager,sTel,sAddress,sRemake,sAppendTime,StorageClassID,sState,");
             strSql.Append("    (select tbStaffInfo.sName from tbStaffInfo where tbStaffInfo.StaffID = sManager) as  Manager ,");
             strSql.Append("   (select tbStorageClassInfo.sClassName from tbStorageClassInfo where tbStorageClassInfo.StorageClassID=tbStorageInfo.StorageClassID) as storageName from tbStorageInfo");
            strSql.Append(" where StorageID=@StorageID ");
            SqlParameter[] parameters = {
					new SqlParameter("@StorageID", SqlDbType.Int,4)};
            parameters[0].Value = StorageID;

            StorageInfo model = new StorageInfo();
            DataSet ds = DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["StorageID"].ToString() != "")
                {
                    model.StorageID = int.Parse(ds.Tables[0].Rows[0]["StorageID"].ToString());
                }
                model.sCode = ds.Tables[0].Rows[0]["sCode"].ToString();
                model.sName = ds.Tables[0].Rows[0]["sName"].ToString();
                model.ManagerName = ds.Tables[0].Rows[0]["Manager"].ToString();
                if (ds.Tables[0].Rows[0]["sManager"].ToString() != "")
                {
                    model.sManager = int.Parse(ds.Tables[0].Rows[0]["sManager"].ToString());
                }
                model.sTel = ds.Tables[0].Rows[0]["sTel"].ToString();
                model.sAddress = ds.Tables[0].Rows[0]["sAddress"].ToString();
                model.sRemake = ds.Tables[0].Rows[0]["sRemake"].ToString();
                if (ds.Tables[0].Rows[0]["sAppendTime"].ToString() != "")
                {
                    model.sAppendTime = DateTime.Parse(ds.Tables[0].Rows[0]["sAppendTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["StorageClassID"].ToString() != "")
                {
                    model.StorageClassID = int.Parse(ds.Tables[0].Rows[0]["StorageClassID"].ToString());
                }
                model.StorageName = ds.Tables[0].Rows[0]["storageName"].ToString();
                if (ds.Tables[0].Rows[0]["sState"].ToString() != "")
                {
                    model.sState = int.Parse(ds.Tables[0].Rows[0]["sState"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        public StorageInfo GetStorageInfoModelBySCode(string sCode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select  top 1 StorageID,sCode,sName,sManager,sTel,sAddress,sRemake,sAppendTime,StorageClassID,sState,");
            strSql.Append("    (select tbStaffInfo.sName from tbStaffInfo where tbStaffInfo.StaffID = sManager) as  Manager ,");
            strSql.Append("   (select tbStorageClassInfo.sClassName from tbStorageClassInfo where tbStorageClassInfo.StorageClassID=tbStorageInfo.StorageClassID) as storageName from tbStorageInfo");
            strSql.Append(" where sCode=@sCode ");
            SqlParameter[] parameters = {
					new SqlParameter("@sCode",  SqlDbType.VarChar,50)};
            parameters[0].Value = sCode;

            StorageInfo model = new StorageInfo();
            DataSet ds = DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["StorageID"].ToString() != "")
                {
                    model.StorageID = int.Parse(ds.Tables[0].Rows[0]["StorageID"].ToString());
                }
                model.sCode = ds.Tables[0].Rows[0]["sCode"].ToString();
                model.sName = ds.Tables[0].Rows[0]["sName"].ToString();
                model.ManagerName = ds.Tables[0].Rows[0]["Manager"].ToString();
                if (ds.Tables[0].Rows[0]["sManager"].ToString() != "")
                {
                    model.sManager = int.Parse(ds.Tables[0].Rows[0]["sManager"].ToString());
                }
                model.sTel = ds.Tables[0].Rows[0]["sTel"].ToString();
                model.sAddress = ds.Tables[0].Rows[0]["sAddress"].ToString();
                model.sRemake = ds.Tables[0].Rows[0]["sRemake"].ToString();
                if (ds.Tables[0].Rows[0]["sAppendTime"].ToString() != "")
                {
                    model.sAppendTime = DateTime.Parse(ds.Tables[0].Rows[0]["sAppendTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["StorageClassID"].ToString() != "")
                {
                    model.StorageClassID = int.Parse(ds.Tables[0].Rows[0]["StorageClassID"].ToString());
                }
                model.StorageName = ds.Tables[0].Rows[0]["storageName"].ToString();
                if (ds.Tables[0].Rows[0]["sState"].ToString() != "")
                {
                    model.sState = int.Parse(ds.Tables[0].Rows[0]["sState"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        public StorageInfo GetStorageInfoModelByName(string sName)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select  top 1 StorageID,sCode,sName,sManager,sTel,sAddress,sRemake,sAppendTime,StorageClassID,sState,");
            strSql.Append("    (select tbStaffInfo.sName from tbStaffInfo where tbStaffInfo.StaffID = sManager) as  Manager ,");
            strSql.Append("   (select tbStorageClassInfo.sClassName from tbStorageClassInfo where tbStorageClassInfo.StorageClassID=tbStorageInfo.StorageClassID) as storageName from tbStorageInfo");
            strSql.Append(" where sCode=@sCode ");
            SqlParameter[] parameters = {
					new SqlParameter("@sName",  SqlDbType.VarChar,50)};
            parameters[0].Value = sName;

            StorageInfo model = new StorageInfo();
            DataSet ds = DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["StorageID"].ToString() != "")
                {
                    model.StorageID = int.Parse(ds.Tables[0].Rows[0]["StorageID"].ToString());
                }
                model.sCode = ds.Tables[0].Rows[0]["sCode"].ToString();
                model.sName = ds.Tables[0].Rows[0]["sName"].ToString();
                model.ManagerName = ds.Tables[0].Rows[0]["Manager"].ToString();
                if (ds.Tables[0].Rows[0]["sManager"].ToString() != "")
                {
                    model.sManager = int.Parse(ds.Tables[0].Rows[0]["sManager"].ToString());
                }
                model.sTel = ds.Tables[0].Rows[0]["sTel"].ToString();
                model.sAddress = ds.Tables[0].Rows[0]["sAddress"].ToString();
                model.sRemake = ds.Tables[0].Rows[0]["sRemake"].ToString();
                if (ds.Tables[0].Rows[0]["sAppendTime"].ToString() != "")
                {
                    model.sAppendTime = DateTime.Parse(ds.Tables[0].Rows[0]["sAppendTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["StorageClassID"].ToString() != "")
                {
                    model.StorageClassID = int.Parse(ds.Tables[0].Rows[0]["StorageClassID"].ToString());
                }
                model.StorageName = ds.Tables[0].Rows[0]["storageName"].ToString();
                if (ds.Tables[0].Rows[0]["sState"].ToString() != "")
                {
                    model.sState = int.Parse(ds.Tables[0].Rows[0]["sState"].ToString());
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
        public DataSet GetStorageInfoList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select StorageID,sCode,sName,sManager,sTel,sAddress,sRemake,sAppendTime,sState ");
            strSql.Append(" FROM tbStorageInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelper.ExecuteDataset(CommandType.Text,strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" StorageID,sCode,sName,sManager,sTel,sAddress,sRemake,sAppendTime,sState ");
            strSql.Append(" FROM tbStorageInfo ");
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
        public DataTable GetStorageInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
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
            parameters[0].Value = "tbStorageInfo";
            parameters[1].Value = "StorageID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 1;
            parameters[5].Value = OrderType;
            parameters[6].Value = strWhere;
            parameters[7].Value = showFName+", (select tbStorageClassInfo.sClassName from tbStorageClassInfo where tbStorageClassInfo.StorageClassID=tbStorageInfo.StorageClassID) as storageName";

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

        #region storageClass
        /// <summary>
        /// 获得仓库上级分类信息
        /// </summary>
        /// <param name="ParentID"></param>
        /// <returns></returns>
        public DataTable getStorageClassList(int ParentID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("  select StorageClassID,sParentID,sClassName,sOrder,sAppendTime,");
            strSql.Append(" case when sParentID='" + ParentID + "' then ");
            strSql.Append(" (select sClassName from tbStorageClassInfo where StorageClassID='" + ParentID + "') else 'null' ");
            strSql.Append(" end as parentName  from tbStorageClassInfo where sParentID='" + ParentID + "'");
            return DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString()).Tables[0];
        }
        /// <summary>
        /// 获得仓库分类明细
        /// </summary>
        /// <param name="ProductClassID"></param>
        /// <returns></returns>
        public DataTable GetStorageDetails(int StorageClassID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select StorageClassID,sParentID,sClassName,sOrder,sAppendTime from tbStorageClassInfo ");
            if (StorageClassID > -1)
            {
                strSql.Append(" where sParentID= '" + StorageClassID + "'");
            }
            return DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString()).Tables[0];
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetStoragesInfoList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select StorageClassID,sParentID,sClassName,sOrder,sAppendTime ");
            strSql.Append(" FROM tbStorageClassInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString());
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistsStorageInfo(string sClassName, int sParentID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tbStorageClassInfo");
            strSql.Append(" where sParentID=@sParentID and sClassName=@sClassName ");
            SqlParameter[] parameters = {
					new SqlParameter("@sParentID", SqlDbType.Int,4),
                                        new SqlParameter("@sClassName", SqlDbType.VarChar,50)};
            parameters[0].Value = sParentID;
            parameters[1].Value = sClassName;

            return ((int)DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters)) > 0;
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddStorageListInfo(StorageClass model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tbStorageClassInfo(");
            strSql.Append("sParentID,sClassName,sOrder,sAppendTime)");
            strSql.Append(" values (");
            strSql.Append("@sParentID,@sClassName,@sOrder,@sAppendTime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@sParentID", SqlDbType.Int,4),
					new SqlParameter("@sClassName", SqlDbType.VarChar,50),
					new SqlParameter("@sOrder", SqlDbType.Int,4),
					new SqlParameter("@sAppendTime", SqlDbType.DateTime)};
            parameters[0].Value = model.SParentID;
            parameters[1].Value = model.SClassName;
            parameters[2].Value = model.SOrder;
            parameters[3].Value = model.SAppendTime;

            object obj = DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
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
        /// 得到一个对象实体
        /// </summary>
        public StorageClass GetStoragesInfoModel(int StorageClassID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 StorageClassID,sParentID,sClassName,sOrder,sAppendTime from tbStorageClassInfo ");
            strSql.Append(" where StorageClassID=@StorageClassID ");
            SqlParameter[] parameters = {
					new SqlParameter("@StorageClassID", SqlDbType.Int,4)};
            parameters[0].Value = StorageClassID;

            StorageClass model = new StorageClass();
            DataSet ds = DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["StorageClassID"].ToString() != "")
                {
                    model.StorageClassID = int.Parse(ds.Tables[0].Rows[0]["StorageClassID"].ToString());
                }
                model.SClassName = ds.Tables[0].Rows[0]["sClassName"].ToString();
                if (ds.Tables[0].Rows[0]["sParentID"].ToString() != "")
                {
                    model.SParentID = int.Parse(ds.Tables[0].Rows[0]["sParentID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["sOrder"].ToString() != "")
                {
                    model.SOrder = int.Parse(ds.Tables[0].Rows[0]["sOrder"].ToString());
                }
                if (ds.Tables[0].Rows[0]["sAppendTime"].ToString() != "")
                {
                    model.SAppendTime = DateTime.Parse(ds.Tables[0].Rows[0]["sAppendTime"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int UpdateStoragesInfo(StorageClass model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbStorageClassInfo set ");
            strSql.Append("sClassName=@sClassName,");
            strSql.Append("sOrder=@sOrder,");
            strSql.Append("sAppendTime=@sAppendTime");
            strSql.Append(" where StorageClassID=@StorageClassID ");
            SqlParameter[] parameters = {
					new SqlParameter("@StorageClassID", SqlDbType.Int,4),
					new SqlParameter("@sClassName", SqlDbType.VarChar,50),
					new SqlParameter("@sOrder", SqlDbType.Int,4),
					new SqlParameter("@sAppendTime", SqlDbType.DateTime)};
            parameters[0].Value = model.StorageClassID;
            parameters[1].Value = model.SClassName;
            parameters[2].Value = model.SOrder;
            parameters[3].Value = model.SAppendTime;

           return  DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int DeleteStoragesInfo(int StorageID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbStorageClassInfo ");
            strSql.Append(" where StorageClassID=@StorageClassID ");
            SqlParameter[] parameters = {
					new SqlParameter("@StorageClassID", SqlDbType.Int,4)};
           parameters[0].Value = StorageID;

           return DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
#endregion
    }
}
        