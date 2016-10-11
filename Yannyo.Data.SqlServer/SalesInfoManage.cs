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
        #region  SalesInfo
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistsSalesInfo(int SalesID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tbSalesInfo");
            strSql.Append(" where SalesID=@SalesID ");
            SqlParameter[] parameters = {
					new SqlParameter("@SalesID", SqlDbType.Int,4)};
            parameters[0].Value = SalesID;

            return ((int)DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters)) > 0;
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddSalesInfo(SalesInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tbSalesInfo(");
            strSql.Append("StoresID,ProductsID,sNum,sPrice,sDateTime,sAppendTime,sIsYH,sStoresName,sProductsName,sStoresID)");
            strSql.Append(" values (");
            strSql.Append("@StoresID,@ProductsID,@sNum,@sPrice,@sDateTime,@sAppendTime,@sIsYH,@StoresName,@ProductsName,@sStoresID)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@StoresID", SqlDbType.Int,4),
					new SqlParameter("@ProductsID", SqlDbType.Int,4),
					new SqlParameter("@sNum", SqlDbType.Int,4),
					new SqlParameter("@sPrice", SqlDbType.Money,8),
					new SqlParameter("@sDateTime", SqlDbType.DateTime),
					new SqlParameter("@sAppendTime", SqlDbType.DateTime),
                    new SqlParameter("@sIsYH", SqlDbType.Int,4),
                    new SqlParameter("@StoresName", SqlDbType.VarChar,128),
                    new SqlParameter("@ProductsName", SqlDbType.VarChar,128),
                                        new SqlParameter("@sStoresID", SqlDbType.VarChar,50),};
            parameters[0].Value = model.StoresID;
            parameters[1].Value = model.ProductsID;
            parameters[2].Value = model.sNum;
            parameters[3].Value = model.sPrice;
            parameters[4].Value = model.sDateTime;
            parameters[5].Value = model.sAppendTime;
            parameters[6].Value = model.sIsYH;
            parameters[7].Value = model.StoresName;
            parameters[8].Value = model.ProductsName;
            parameters[9].Value = model.sStoresID;

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
        public void UpdateSalesInfo(SalesInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbSalesInfo set ");
            strSql.Append("StoresID=@StoresID,");
            strSql.Append("ProductsID=@ProductsID,");
            strSql.Append("sNum=@sNum,");
            strSql.Append("sPrice=@sPrice,");
            strSql.Append("sDateTime=@sDateTime,");
            strSql.Append("sIsYH=@sIsYH,");
            strSql.Append("sAppendTime=@sAppendTime,");
            strSql.Append("sStoresName=@StoresName,");
            strSql.Append("sProductsName=@ProductsName");
            strSql.Append(" where SalesID=@SalesID ");
            SqlParameter[] parameters = {
					new SqlParameter("@SalesID", SqlDbType.Int,4),
					new SqlParameter("@StoresID", SqlDbType.Int,4),
					new SqlParameter("@ProductsID", SqlDbType.Int,4),
					new SqlParameter("@sNum", SqlDbType.Int,4),
					new SqlParameter("@sPrice", SqlDbType.Money,8),
                    new SqlParameter("@sIsYH", SqlDbType.Int,4),
					new SqlParameter("@sDateTime", SqlDbType.DateTime),
					new SqlParameter("@sAppendTime", SqlDbType.DateTime),
                    new SqlParameter("@StoresName", SqlDbType.VarChar,128),
                    new SqlParameter("@ProductsName", SqlDbType.VarChar,128)};
            parameters[0].Value = model.SalesID;
            parameters[1].Value = model.StoresID;
            parameters[2].Value = model.ProductsID;
            parameters[3].Value = model.sNum;
            parameters[4].Value = model.sPrice;
            parameters[5].Value = model.sIsYH;
            parameters[6].Value = model.sDateTime;
            parameters[7].Value = model.sAppendTime;
            parameters[8].Value = model.StoresName;
            parameters[9].Value = model.ProductsName;

            DbHelper.ExecuteNonQuery(CommandType.Text,strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void DeleteSalesInfo(int SalesID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbSalesInfo ");
            strSql.Append(" where SalesID=@SalesID ");
            SqlParameter[] parameters = {
					new SqlParameter("@SalesID", SqlDbType.Int,4)};
            parameters[0].Value = SalesID;

            DbHelper.ExecuteNonQuery(CommandType.Text,strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一组数据
        /// </summary>
        public void DeleteSalesInfo(string SalesID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbSalesInfo ");
            strSql.Append(" where SalesID in(" + SalesID + ") ");

            DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString());
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="SalesID"></param>
        /// <param name="sDateTime"></param>
        public void DeleteSalesInfo(string SalesID, DateTime sDateTime)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbSalesInfo ");
            strSql.Append(" where SalesID in(" + SalesID + ")  and sDateTime=@sDateTime");
            SqlParameter[] parameters = {
					new SqlParameter("@sDateTime", SqlDbType.DateTime)};
            parameters[0].Value = sDateTime;

            DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public SalesInfo GetSalesInfoModel(int SalesID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 SalesID,StoresID,ProductsID,sNum,sPrice,sDateTime,sAppendTime,sIsYH,sStoresName,sProductsName,(select sName from tbStoresInfo where StoresID=tbSalesInfo.StoresID) as StoresName,(select pName from tbProductsInfo where ProductsID=tbSalesInfo.ProductsID) as ProductsName from tbSalesInfo ");
            strSql.Append(" where SalesID=@SalesID ");
            SqlParameter[] parameters = {
					new SqlParameter("@SalesID", SqlDbType.Int,4)};
            parameters[0].Value = SalesID;

            SalesInfo model = new SalesInfo();
            DataSet ds = DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["SalesID"].ToString() != "")
                {
                    model.SalesID = int.Parse(ds.Tables[0].Rows[0]["SalesID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["StoresID"].ToString() != "")
                {
                    model.StoresID = int.Parse(ds.Tables[0].Rows[0]["StoresID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ProductsID"].ToString() != "")
                {
                    model.ProductsID = int.Parse(ds.Tables[0].Rows[0]["ProductsID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["sNum"].ToString() != "")
                {
                    model.sNum = int.Parse(ds.Tables[0].Rows[0]["sNum"].ToString());
                }
                if (ds.Tables[0].Rows[0]["sPrice"].ToString() != "")
                {
                    model.sPrice = decimal.Parse(ds.Tables[0].Rows[0]["sPrice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["sDateTime"].ToString() != "")
                {
                    model.sDateTime = DateTime.Parse(ds.Tables[0].Rows[0]["sDateTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["sAppendTime"].ToString() != "")
                {
                    model.sAppendTime = DateTime.Parse(ds.Tables[0].Rows[0]["sAppendTime"].ToString());
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
        public DataSet GetSalesInfoList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SalesID,StoresID,ProductsID,sNum,sPrice,sDateTime,sAppendTime,sIsYH,sStoresName,sProductsName,(select sName from tbStoresInfo where StoresID=tbSalesInfo.StoresID) as StoresName,(select pName from tbProductsInfo where ProductsID=tbSalesInfo.ProductsID) as ProductsName ");
            strSql.Append(" FROM tbSalesInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelper.ExecuteDataset(CommandType.Text,strSql.ToString());
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataTable GetSalesInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
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
            parameters[0].Value = "tbSalesInfo";
            parameters[1].Value = "SalesID";
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
        /// 取未匹配数据
        /// </summary>
        /// <returns></returns>
        public DataTable GetNOJoinDataSalesInfoList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select sStoresName ");
            strSql.Append(" FROM tbSalesInfo where StoresID=0 group by sStoresName");
           
            return DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString()).Tables[0];
        }

        /// <summary>
        /// 匹配数据,单据/产品匹配
        /// </summary>
        public int[] SyncSalesInfo()
        {
            int[] ReCount = { 0, 0, 0};
            /*
            ProductsInfo pi = new ProductsInfo();
            StoresInfo si = new StoresInfo();
            try
            {
                string strSql = "select * from tbSalesInfo";
                StringBuilder strSqlt = new StringBuilder();

                DataTable dt = DbHelper.ExecuteDataset(CommandType.Text, strSql).Tables[0];
                foreach (DataRow dr in dt.Rows)
                {

                    strSqlt.Append("update tbSalesInfo set tbSalesInfo.ProductsID=p.ProductsID from tbProductsInfo as p where p.pName='" + dr["sProductsName"].ToString().Trim() + "' and tbSalesInfo.SalesID=" + dr["SalesID"].ToString() + ";\n ");
                    ReCount[0] ++;

                    strSqlt.Append("update tbSalesInfo set tbSalesInfo.StoresID=s.StoresID from tbStoresInfo as s where s.sName='" + dr["sStoresName"].ToString().Trim() + "' and  tbSalesInfo.SalesID=" + dr["SalesID"].ToString() + ";\n ");
                    ReCount[2] ++;

                    if (strSqlt.Length > 100)
                    {
                        ReCount[1] += DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString());
                        strSqlt.Remove(0, 99);
                    }

                }
                if (strSqlt.ToString().Trim() != "")
                {
                    ReCount[1] += DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString());
                }
            }
            finally
            {
                pi = null;
                si = null;
            }
             */
            DataSet ds = DbHelper.ExecuteDataset(CommandType.StoredProcedure, "sp_" + BaseConfigs.GetTablePrefix + "SyncSalesInfo");
            if (ds.Tables.Count > 1)
            {
                ReCount[0] = (int)ds.Tables[0].Rows[0][0];
                ReCount[1] = (int)ds.Tables[0].Rows[0][1];
            }
            ds.Clear();
            ds.Dispose();
            return ReCount;
        }

        #endregion  成员方法
    }
}
