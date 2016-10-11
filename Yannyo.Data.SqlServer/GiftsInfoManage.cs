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
        #region  GiftsInfo

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddGiftsInfo(GiftsInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tbGiftsInfo(");
            strSql.Append("ProductsID,StoresID,gNum,gDateTime,gAppendTime)");
            strSql.Append(" values (");
            strSql.Append("@ProductsID,@StoresID,@gNum,@gDateTime,@gAppendTime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@ProductsID", SqlDbType.Int,4),
					new SqlParameter("@StoresID", SqlDbType.Int,4),
					new SqlParameter("@gNum", SqlDbType.Int,4),
					new SqlParameter("@gDateTime", SqlDbType.DateTime),
					new SqlParameter("@gAppendTime", SqlDbType.DateTime)};
            parameters[0].Value = model.ProductsID;
            parameters[1].Value = model.StoresID;
            parameters[2].Value = model.gNum;
            parameters[3].Value = model.gDateTime;
            parameters[4].Value = model.gAppendTime;

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
        public void UpdateGiftsInfo(GiftsInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbGiftsInfo set ");
            strSql.Append("ProductsID=@ProductsID,");
            strSql.Append("StoresID=@StoresID,");
            strSql.Append("gNum=@gNum,");
            strSql.Append("gDateTime=@gDateTime,");
            strSql.Append("gAppendTime=@gAppendTime");
            strSql.Append(" where GiftsID=@GiftsID ");
            SqlParameter[] parameters = {
					new SqlParameter("@GiftsID", SqlDbType.Int,4),
					new SqlParameter("@ProductsID", SqlDbType.Int,4),
					new SqlParameter("@StoresID", SqlDbType.Int,4),
					new SqlParameter("@gNum", SqlDbType.Int,4),
					new SqlParameter("@gDateTime", SqlDbType.DateTime),
					new SqlParameter("@gAppendTime", SqlDbType.DateTime)};
            parameters[0].Value = model.GiftsID;
            parameters[1].Value = model.ProductsID;
            parameters[2].Value = model.StoresID;
            parameters[3].Value = model.gNum;
            parameters[4].Value = model.gDateTime;
            parameters[5].Value = model.gAppendTime;

            DbHelper.ExecuteNonQuery(CommandType.Text,strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void DeleteGiftsInfo(int GiftsID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbGiftsInfo ");
            strSql.Append(" where GiftsID=@GiftsID ");
            SqlParameter[] parameters = {
					new SqlParameter("@GiftsID", SqlDbType.Int,4)};
            parameters[0].Value = GiftsID;

            DbHelper.ExecuteNonQuery(CommandType.Text,strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一组数据
        /// </summary>
        public void DeleteGiftsInfo(string GiftsID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbGiftsInfo ");
            strSql.Append(" where GiftsID in(" + GiftsID + ") ");

            DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString());
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public GiftsInfo GetGiftsInfoModel(int GiftsID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 GiftsID,ProductsID,StoresID,gNum,gDateTime,gAppendTime,(select sName from tbStoresInfo where StoresID=tbGiftsInfo.StoresID) as StoresName,(select pName from tbProductsInfo where ProductsID=tbGiftsInfo.ProductsID) as ProductsName from tbGiftsInfo ");
            strSql.Append(" where GiftsID=@GiftsID ");
            SqlParameter[] parameters = {
					new SqlParameter("@GiftsID", SqlDbType.Int,4)};
            parameters[0].Value = GiftsID;

            GiftsInfo model = new GiftsInfo();
            DataSet ds = DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["GiftsID"].ToString() != "")
                {
                    model.GiftsID = int.Parse(ds.Tables[0].Rows[0]["GiftsID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ProductsID"].ToString() != "")
                {
                    model.ProductsID = int.Parse(ds.Tables[0].Rows[0]["ProductsID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["StoresID"].ToString() != "")
                {
                    model.StoresID = int.Parse(ds.Tables[0].Rows[0]["StoresID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["gNum"].ToString() != "")
                {
                    model.gNum = int.Parse(ds.Tables[0].Rows[0]["gNum"].ToString());
                }
                if (ds.Tables[0].Rows[0]["gDateTime"].ToString() != "")
                {
                    model.gDateTime = DateTime.Parse(ds.Tables[0].Rows[0]["gDateTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["gAppendTime"].ToString() != "")
                {
                    model.gAppendTime = DateTime.Parse(ds.Tables[0].Rows[0]["gAppendTime"].ToString());
                }
                model.StoresName = ds.Tables[0].Rows[0]["StoresName"].ToString();
                model.ProductsName = ds.Tables[0].Rows[0]["ProductsName"].ToString();
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
        public DataSet GetGiftsInfoList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select GiftsID,ProductsID,StoresID,gNum,gDateTime,gAppendTime,(select sName from tbStoresInfo where StoresID=tbGiftsInfo.StoresID) as StoresName,(select pName from tbProductsInfo where ProductsID=tbGiftsInfo.ProductsID) as ProductsName ");
            strSql.Append(" FROM tbGiftsInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelper.ExecuteDataset(CommandType.Text,strSql.ToString());
        }


        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataTable GetGiftsInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
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
            parameters[0].Value = "tbGiftsInfo";
            parameters[1].Value = "GiftsID";
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
