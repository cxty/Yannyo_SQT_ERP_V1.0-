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
        public bool ExistsM_ExpressTemplatesInfo(string mName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_M_ExpressTemplatesInfo");
            strSql.Append(" where mName = @mName");
            SqlParameter[] parameters = {
                                            new SqlParameter("@mName", SqlDbType.VarChar,50),
            };
            parameters[0].Value = mName;

            return ((int)DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters)) > 0;
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddM_ExpressTemplatesInfo(M_ExpressTemplatesInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_M_ExpressTemplatesInfo(");
            strSql.Append("mName,mPIC,mWidth,mHeight,mExpName,mData,mAppendTime,m_ConfigInfoID)");
            strSql.Append(" values (");
            strSql.Append("@mName,@mPIC,@mWidth,@mHeight,@mExpName,@mData,@mAppendTime,@m_ConfigInfoID)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@mName", SqlDbType.VarChar,50),
					new SqlParameter("@mPIC", SqlDbType.VarChar,50),
					new SqlParameter("@mWidth", SqlDbType.VarChar,50),
					new SqlParameter("@mHeight", SqlDbType.VarChar,50),
					new SqlParameter("@mExpName", SqlDbType.VarChar,128),
					new SqlParameter("@mData", SqlDbType.NText),
					new SqlParameter("@mAppendTime", SqlDbType.DateTime),
                                        new SqlParameter("@m_ConfigInfoID", SqlDbType.Int,4),};
            parameters[0].Value = model.mName;
            parameters[1].Value = model.mPIC;
            parameters[2].Value = model.mWidth;
            parameters[3].Value = model.mHeight;
            parameters[4].Value = model.mExpName;
            parameters[5].Value = model.mData;
            parameters[6].Value = model.mAppendTime;
            parameters[7].Value = model.m_ConfigInfoID;

            object obj = DbHelper.ExecuteScalar(CommandType.Text,strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdateM_ExpressTemplatesInfo(M_ExpressTemplatesInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_M_ExpressTemplatesInfo set ");
            strSql.Append("mName=@mName,");
            strSql.Append("mPIC=@mPIC,");
            strSql.Append("mWidth=@mWidth,");
            strSql.Append("mHeight=@mHeight,");
            strSql.Append("mExpName=@mExpName,");
            strSql.Append("mData=@mData,");
            strSql.Append("mAppendTime=@mAppendTime,");
            strSql.Append("m_ConfigInfoID=@m_ConfigInfoID");
            strSql.Append(" where m_ExpressTemplatesID=@m_ExpressTemplatesID");
            SqlParameter[] parameters = {
					new SqlParameter("@m_ExpressTemplatesID", SqlDbType.Int,4),
					new SqlParameter("@mName", SqlDbType.VarChar,50),
					new SqlParameter("@mPIC", SqlDbType.VarChar,50),
					new SqlParameter("@mWidth", SqlDbType.VarChar,50),
					new SqlParameter("@mHeight", SqlDbType.VarChar,50),
					new SqlParameter("@mExpName", SqlDbType.VarChar,128),
					new SqlParameter("@mData", SqlDbType.NText),
					new SqlParameter("@mAppendTime", SqlDbType.DateTime),
                                        new SqlParameter("@m_ConfigInfoID", SqlDbType.Int,4),};
            parameters[0].Value = model.m_ExpressTemplatesID;
            parameters[1].Value = model.mName;
            parameters[2].Value = model.mPIC;
            parameters[3].Value = model.mWidth;
            parameters[4].Value = model.mHeight;
            parameters[5].Value = model.mExpName;
            parameters[6].Value = model.mData;
            parameters[7].Value = model.mAppendTime;
            parameters[8].Value = model.m_ConfigInfoID;

            int rows = DbHelper.ExecuteNonQuery(CommandType.Text,strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteM_ExpressTemplatesInfo(int m_ExpressTemplatesID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_M_ExpressTemplatesInfo ");
            strSql.Append(" where m_ExpressTemplatesID=@m_ExpressTemplatesID");
            SqlParameter[] parameters = {
					new SqlParameter("@m_ExpressTemplatesID", SqlDbType.Int,4)
};
            parameters[0].Value = m_ExpressTemplatesID;

            int rows = DbHelper.ExecuteNonQuery(CommandType.Text,strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteM_ExpressTemplatesInfoList(string m_ExpressTemplatesIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_M_ExpressTemplatesInfo ");
            strSql.Append(" where m_ExpressTemplatesID in (" + m_ExpressTemplatesIDlist + ")  ");
            int rows = DbHelper.ExecuteNonQuery(CommandType.Text,strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public M_ExpressTemplatesInfo GetM_ExpressTemplatesInfoModel(int m_ExpressTemplatesID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 m_ExpressTemplatesID,mName,mPIC,mWidth,mHeight,mExpName,mData,mAppendTime,m_ConfigInfoID from tb_M_ExpressTemplatesInfo ");
            strSql.Append(" where m_ExpressTemplatesID=@m_ExpressTemplatesID");
            SqlParameter[] parameters = {
					new SqlParameter("@m_ExpressTemplatesID", SqlDbType.Int,4)
};
            parameters[0].Value = m_ExpressTemplatesID;

            M_ExpressTemplatesInfo model = new M_ExpressTemplatesInfo();
            DataSet ds = DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["m_ExpressTemplatesID"].ToString() != "")
                {
                    model.m_ExpressTemplatesID = int.Parse(ds.Tables[0].Rows[0]["m_ExpressTemplatesID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["m_ConfigInfoID"].ToString() != "")
                {
                    model.m_ConfigInfoID = int.Parse(ds.Tables[0].Rows[0]["m_ConfigInfoID"].ToString());
                }
                model.mName = ds.Tables[0].Rows[0]["mName"].ToString();
                model.mPIC = ds.Tables[0].Rows[0]["mPIC"].ToString();
                model.mWidth = ds.Tables[0].Rows[0]["mWidth"].ToString();
                model.mHeight = ds.Tables[0].Rows[0]["mHeight"].ToString();
                model.mExpName = ds.Tables[0].Rows[0]["mExpName"].ToString();
                model.mData = ds.Tables[0].Rows[0]["mData"].ToString();
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
        public DataSet GetM_ExpressTemplatesInfoList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select m_ExpressTemplatesID,mName,mPIC,mWidth,mHeight,mExpName,mData,mAppendTime,m_ConfigInfoID ");
            strSql.Append(" FROM tb_M_ExpressTemplatesInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelper.ExecuteDataset(CommandType.Text,strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetM_ExpressTemplatesInfoList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" m_ExpressTemplatesID,mName,mPIC,mWidth,mHeight,mExpName,mData,mAppendTime,m_ConfigInfoID ");
            strSql.Append(" FROM tb_M_ExpressTemplatesInfo ");
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
        public DataTable GetM_ExpressTemplatesInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
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
            parameters[0].Value = "tb_M_ExpressTemplatesInfo";
            parameters[1].Value = "m_ExpressTemplatesID";
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
