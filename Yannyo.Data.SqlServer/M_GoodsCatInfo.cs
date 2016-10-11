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
        public bool ExistsM_GoodsCatInfo(int m_ConfigInfoID, long cid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_M_GoodsCatInfo");
            strSql.Append(" where m_ConfigInfoID=@m_ConfigInfoID and cid=@cid ");
            SqlParameter[] parameters = {
					new SqlParameter("@m_ConfigInfoID", SqlDbType.Int,4),
                                        new SqlParameter("@cid", SqlDbType.BigInt)};
            parameters[0].Value = m_ConfigInfoID;
            parameters[1].Value = cid;

            return ((int)DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters)) > 0;
        }

        /// <summary>
        /// 取商品类目最后更新时间
        /// </summary>
        /// <returns></returns>
        public DateTime GetM_GoodsCatLastTime(int m_ConfigInfoID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top  1 mUpdateTime from tb_M_GoodsCatInfo");
            strSql.Append(" where m_ConfigInfoID=@m_ConfigInfoID order by mUpdateTime desc ");
            SqlParameter[] parameters = {
					new SqlParameter("@m_ConfigInfoID", SqlDbType.Int,4)};
            parameters[0].Value = m_ConfigInfoID;

            object o = DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
            if (o != null)
            {
                return Convert.ToDateTime(o);
            }
            else {
                return DateTime.Now.AddYears(-1);
            }
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddM_GoodsCatInfo(M_GoodsCatInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_M_GoodsCatInfo(");
            strSql.Append("m_ConfigInfoID,cid,parent_cid,name,is_parent,status,sort_order,mUpdateTime)");
            strSql.Append(" values (");
            strSql.Append("@m_ConfigInfoID,@cid,@parent_cid,@name,@is_parent,@status,@sort_order,@mUpdateTime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@m_ConfigInfoID", SqlDbType.Int,4),
					new SqlParameter("@cid", SqlDbType.BigInt,8),
					new SqlParameter("@parent_cid", SqlDbType.BigInt,8),
					new SqlParameter("@name", SqlDbType.VarChar,50),
					new SqlParameter("@is_parent", SqlDbType.Bit,1),
					new SqlParameter("@status", SqlDbType.VarChar,50),
					new SqlParameter("@sort_order", SqlDbType.Int,4),
                                        new SqlParameter("@mUpdateTime", SqlDbType.DateTime)};
            parameters[0].Value = model.m_ConfigInfoID;
            parameters[1].Value = model.cid;
            parameters[2].Value = model.parent_cid;
            parameters[3].Value = model.name;
            parameters[4].Value = model.is_parent;
            parameters[5].Value = model.status;
            parameters[6].Value = model.sort_order;
            parameters[7].Value = model.mUpdateTime;

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
        /// 批量添加商品类目
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public bool AddM_GoodsCatInfoByDataTable(DataTable dt, int m_ConfigInfoID)
        {
            if (dt != null)
            {
                try
                {
                    StringBuilder strSql = new StringBuilder();
                    
                    foreach (DataRow dr in dt.Rows)
                    {
                        strSql.Append("insert into tb_M_GoodsCatInfo(");
                        strSql.Append("m_ConfigInfoID,cid,parent_cid,name,is_parent,status,sort_order,mUpdateTime)");
                        strSql.Append(" values (");
                        strSql.Append("@m_ConfigInfoID," + dr["cid"].ToString() + "," + dr["parent_cid"].ToString() + ",'" + dr["name"].ToString() + "'," + (dr["is_parent"].ToString() == "1" ? 1 : ((dr["is_parent"].ToString().ToString().ToLower() == "true" ? 1 : 0))).ToString() + ",'" + dr["status"].ToString() + "'," + dr["sort_order"].ToString() + ",getdate());");
                    }
                    SqlParameter[] parameters = {
					new SqlParameter("@m_ConfigInfoID", SqlDbType.Int,4),
                                                 };
                    parameters[0].Value = m_ConfigInfoID;
                    DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
                    return true;
                }
                catch {
                    return false;
                }
            }
            else {
                return false;
            }
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void UpdateM_GoodsCatInfo(M_GoodsCatInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_M_GoodsCatInfo set ");
            strSql.Append("m_ConfigInfoID=@m_ConfigInfoID,");
            strSql.Append("cid=@cid,");
            strSql.Append("parent_cid=@parent_cid,");
            strSql.Append("name=@name,");
            strSql.Append("is_parent=@is_parent,");
            strSql.Append("status=@status,");
            strSql.Append("sort_order=@sort_order,");
            strSql.Append("mUpdateTime=@mUpdateTime");
            strSql.Append(" where m_GoodsCatInfoID=@m_GoodsCatInfoID ");
            SqlParameter[] parameters = {
					new SqlParameter("@m_GoodsCatInfoID", SqlDbType.Int,4),
					new SqlParameter("@m_ConfigInfoID", SqlDbType.Int,4),
					new SqlParameter("@cid", SqlDbType.BigInt,8),
					new SqlParameter("@parent_cid", SqlDbType.BigInt,8),
					new SqlParameter("@name", SqlDbType.VarChar,50),
					new SqlParameter("@is_parent", SqlDbType.Bit,1),
					new SqlParameter("@status", SqlDbType.VarChar,50),
					new SqlParameter("@sort_order", SqlDbType.Int,4),
                                        new SqlParameter("@mUpdateTime", SqlDbType.DateTime)};
            parameters[0].Value = model.m_GoodsCatInfoID;
            parameters[1].Value = model.m_ConfigInfoID;
            parameters[2].Value = model.cid;
            parameters[3].Value = model.parent_cid;
            parameters[4].Value = model.name;
            parameters[5].Value = model.is_parent;
            parameters[6].Value = model.status;
            parameters[7].Value = model.sort_order;
            parameters[8].Value = model.mUpdateTime;

            DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void DeleteM_GoodsCatInfo(int m_GoodsCatInfoID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_M_GoodsCatInfo ");
            strSql.Append(" where m_GoodsCatInfoID=@m_GoodsCatInfoID ");
            SqlParameter[] parameters = {
					new SqlParameter("@m_GoodsCatInfoID", SqlDbType.Int,4)};
            parameters[0].Value = m_GoodsCatInfoID;

            DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        /// <summary>
        /// 清理商品类目库
        /// </summary>
        /// <param name="m_ConfigInfoID"></param>
        public void DeleteM_GoodsCatAll(int m_ConfigInfoID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_M_GoodsCatInfo ");
            strSql.Append(" where m_ConfigInfoID=@m_ConfigInfoID ");
            SqlParameter[] parameters = {
					new SqlParameter("@m_ConfigInfoID", SqlDbType.Int,4)};
            parameters[0].Value = m_ConfigInfoID;

            DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public M_GoodsCatInfo GetM_GoodsCatInfoModel(int m_GoodsCatInfoID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 m_GoodsCatInfoID,m_ConfigInfoID,cid,parent_cid,name,is_parent,status,sort_order,mUpdateTime from tb_M_GoodsCatInfo ");
            strSql.Append(" where m_GoodsCatInfoID=@m_GoodsCatInfoID ");
            SqlParameter[] parameters = {
					new SqlParameter("@m_GoodsCatInfoID", SqlDbType.Int,4)};
            parameters[0].Value = m_GoodsCatInfoID;

            M_GoodsCatInfo model = new M_GoodsCatInfo();
            DataSet ds = DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["m_GoodsCatInfoID"].ToString() != "")
                {
                    model.m_GoodsCatInfoID = int.Parse(ds.Tables[0].Rows[0]["m_GoodsCatInfoID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["m_ConfigInfoID"].ToString() != "")
                {
                    model.m_ConfigInfoID = int.Parse(ds.Tables[0].Rows[0]["m_ConfigInfoID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["cid"].ToString() != "")
                {
                    model.cid = long.Parse(ds.Tables[0].Rows[0]["cid"].ToString());
                }
                if (ds.Tables[0].Rows[0]["parent_cid"].ToString() != "")
                {
                    model.parent_cid = long.Parse(ds.Tables[0].Rows[0]["parent_cid"].ToString());
                }
                model.name = ds.Tables[0].Rows[0]["name"].ToString();
                if (ds.Tables[0].Rows[0]["is_parent"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["is_parent"].ToString() == "1") || (ds.Tables[0].Rows[0]["is_parent"].ToString().ToLower() == "true"))
                    {
                        model.is_parent = true;
                    }
                    else
                    {
                        model.is_parent = false;
                    }
                }
                model.status = ds.Tables[0].Rows[0]["status"].ToString();
                if (ds.Tables[0].Rows[0]["sort_order"].ToString() != "")
                {
                    model.sort_order = int.Parse(ds.Tables[0].Rows[0]["sort_order"].ToString());
                }
                if (ds.Tables[0].Rows[0]["mUpdateTime"].ToString() != "")
                {
                    model.mUpdateTime = DateTime.Parse(ds.Tables[0].Rows[0]["mUpdateTime"].ToString());
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
        public DataSet GetM_GoodsCatInfoList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select m_GoodsCatInfoID,m_ConfigInfoID,cid,parent_cid,name,is_parent,status,sort_order,mUpdateTime ");
            strSql.Append(" FROM tb_M_GoodsCatInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetM_GoodsCatInfoList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" m_GoodsCatInfoID,m_ConfigInfoID,cid,parent_cid,name,is_parent,status,sort_order,mUpdateTime ");
            strSql.Append(" FROM tb_M_GoodsCatInfo ");
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
        public DataTable GetM_GoodsCatInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
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
            parameters[0].Value = "tb_M_GoodsCatInfo";
            parameters[1].Value = "M_GoodsCatInfoID";
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
    }
}
