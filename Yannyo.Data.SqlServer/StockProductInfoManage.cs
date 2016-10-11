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
        public bool ExistsStockProductInfo(int StockProductID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tbStockProductInfo");
            strSql.Append(" where StockProductID=@StockProductID ");
            SqlParameter[] parameters = {
					new SqlParameter("@StockProductID", SqlDbType.Int,4)};
            parameters[0].Value = StockProductID;

            return ((int)DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters)) > 0;
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddStockProductInfo(StockProductInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tbStockProductInfo(");
            strSql.Append("ProductsID,isOK,isBad,sAppendTime,StorageID)");
            strSql.Append(" values (");
            strSql.Append("@ProductsID,@isOK,@isBad,@sAppendTime,@StorageID)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@ProductsID", SqlDbType.Int,4),
					new SqlParameter("@isOK", SqlDbType.Decimal),
					new SqlParameter("@isBad", SqlDbType.Decimal),
					new SqlParameter("@sAppendTime", SqlDbType.DateTime),
                                        new SqlParameter("@StorageID", SqlDbType.Int,4)};
            parameters[0].Value = model.ProductsID;
            parameters[1].Value = model.isOK;
            parameters[2].Value = model.isBad;
            parameters[3].Value = model.sAppendTime;
            parameters[4].Value = model.StorageID;

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
        public void UpdateStockProductInfo(StockProductInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbStockProductInfo set ");
            strSql.Append("ProductsID=@ProductsID,");
            strSql.Append("isOK=@isOK,");
            strSql.Append("isBad=@isBad,");
            strSql.Append("sAppendTime=@sAppendTime,");
            strSql.Append("StorageID=@StorageID");
            strSql.Append(" where StockProductID=@StockProductID ");
            SqlParameter[] parameters = {
					new SqlParameter("@StockProductID", SqlDbType.Int,4),
					new SqlParameter("@ProductsID", SqlDbType.Int,4),
					new SqlParameter("@isOK", SqlDbType.Decimal),
					new SqlParameter("@isBad", SqlDbType.Decimal),
					new SqlParameter("@sAppendTime", SqlDbType.DateTime),
                                        new SqlParameter("@StorageID", SqlDbType.Int,4)};
            parameters[0].Value = model.StockProductID;
            parameters[1].Value = model.ProductsID;
            parameters[2].Value = model.isOK;
            parameters[3].Value = model.isBad;
            parameters[4].Value = model.sAppendTime;
            parameters[5].Value = model.StorageID;

            DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void DeleteStockProductInfo(int StockProductID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbStockProductInfo ");
            strSql.Append(" where StockProductID=@StockProductID ");
            SqlParameter[] parameters = {
					new SqlParameter("@StockProductID", SqlDbType.Int,4)};
            parameters[0].Value = StockProductID;

            DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public StockProductInfo GetStockProductInfoModel(int StockProductID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 StockProductID,ProductsID,isOK,isBad,sAppendTime,StorageID from tbStockProductInfo ");
            strSql.Append(" where StockProductID=@StockProductID ");
            SqlParameter[] parameters = {
					new SqlParameter("@StockProductID", SqlDbType.Int,4)};
            parameters[0].Value = StockProductID;

            StockProductInfo model = new StockProductInfo();
            DataSet ds = DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["StockProductID"].ToString() != "")
                {
                    model.StockProductID = int.Parse(ds.Tables[0].Rows[0]["StockProductID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["StorageID"].ToString() != "")
                {
                    model.StorageID = int.Parse(ds.Tables[0].Rows[0]["StorageID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ProductsID"].ToString() != "")
                {
                    model.ProductsID = int.Parse(ds.Tables[0].Rows[0]["ProductsID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["isOK"].ToString() != "")
                {
                    model.isOK = decimal.Parse(ds.Tables[0].Rows[0]["isOK"].ToString());
                }
                if (ds.Tables[0].Rows[0]["isBad"].ToString() != "")
                {
                    model.isBad = decimal.Parse(ds.Tables[0].Rows[0]["isBad"].ToString());
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

        public StockProductInfo GetStockProductInfoModelByProductsID(int ProductsID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 StockProductID,ProductsID,isOK,isBad,sAppendTime,StorageID from tbStockProductInfo ");
            strSql.Append(" where ProductsID=@ProductsID order by sAppendTime desc ");
            SqlParameter[] parameters = {
					new SqlParameter("@ProductsID", SqlDbType.Int,4)};
            parameters[0].Value = ProductsID;

            StockProductInfo model = new StockProductInfo();
            DataSet ds = DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["StockProductID"].ToString() != "")
                {
                    model.StockProductID = int.Parse(ds.Tables[0].Rows[0]["StockProductID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["StorageID"].ToString() != "")
                {
                    model.StorageID = int.Parse(ds.Tables[0].Rows[0]["StorageID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ProductsID"].ToString() != "")
                {
                    model.ProductsID = int.Parse(ds.Tables[0].Rows[0]["ProductsID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["isOK"].ToString() != "")
                {
                    model.isOK = decimal.Parse(ds.Tables[0].Rows[0]["isOK"].ToString());
                }
                if (ds.Tables[0].Rows[0]["isBad"].ToString() != "")
                {
                    model.isBad = decimal.Parse(ds.Tables[0].Rows[0]["isBad"].ToString());
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
        /// 获得数据列表
        /// </summary>
        public DataSet GetStockProductInfoList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select StockProductID,ProductsID,isOK,isBad,sAppendTime,StorageID ");
            strSql.Append(" FROM tbStockProductInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelper.ExecuteDataset(CommandType.Text,strSql.ToString());
        }
        public DataSet GetStockProductInfoListByNow(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from tbStockProductInfo where sAppendTime in("+
                        "select MAX(sp.sAppendTime) from tbStorageInfo s left join tbStockProductInfo sp on s.StorageID=sp.StorageID ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" group by s.StorageID)");
            return DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString());
        }
        
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataTable GetStockProductInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
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
            parameters[0].Value = "tbStockProductInfo";
            parameters[1].Value = "StockProductID";
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
        /// 根据仓库分类获得仓库信息
        /// </summary>
        /// <param name="sid"></param>
        public DataTable getStorageNameByClass(int sid)
        {
            StringBuilder btr=new StringBuilder();
            btr.Append("select * from tbStorageInfo where StorageClassID='"+sid+"'");
            return DbHelper.ExecuteDataset(CommandType.Text,btr.ToString()).Tables[0];
        }
    }
}
