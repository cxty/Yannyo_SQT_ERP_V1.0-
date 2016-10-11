using System;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Yannyo.Data;
using Yannyo.Config;
using Yannyo.Common;
using Yannyo.Entity;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.IO;


namespace Yannyo.Data.SqlServer
{
    public partial class DataProvider : IDataProvider
    {
        #region price
        /// <summary>
        /// StoresID=门店系统编号；StCode=门店仓库编号；ProductsID=产品编号；ProductsName=产品名称;ProductsBarcode=产品条码;pPrice=产品单价；pAppendTime=发生时间
        /// </summary>
        /// <returns></returns>
        public bool GetStorehouseProductPriceInfoList(int StoresID, string StCode, int ProductsID, string ProductsName, string ProductsBarcode, decimal pPrice, DateTime pAppendTime)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(0) ");
            strSql.Append(" from tbStoreStorehouseProductsPriceInfo where StoresID='" + StoresID + "'and StCode='" + StCode + "'and pPrice='" + pPrice + "'and ProductsID='" + ProductsID + "' and ProductsName='" + ProductsName + "' and ProductsBarcode='" + ProductsBarcode + "' and pAppendTime='" + pAppendTime + "'");

            int state = Int32.Parse(DbHelper.ExecuteScalarToStr(CommandType.Text, strSql.ToString()));
            if (state > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool GetStorehousePriceInfoList(int StoresID, string StCode, int ProductsID, DateTime pAppendTime)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(0) ");
            strSql.Append(" from tbStoreStorehouseProductsPriceInfo where StoresID='" + StoresID + "'and StCode='" + StCode + "'and ProductsID='" + ProductsID + "'and pAppendTime='" + pAppendTime + "'");

            int state = Int32.Parse(DbHelper.ExecuteScalarToStr(CommandType.Text, strSql.ToString()));
            if (state > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        /// <summary>
        /// 获取表tbStoreStorehouseProductsPriceInfo 门店编号
        /// </summary>
        /// <returns></returns>
        public DataTable GetStNumByStName(string stName)
        {
            StringBuilder btr = new StringBuilder();
            btr.Append("select StCode from tbStoreStorehouseProductsPriceInfo ");
            DataTable tb = DbHelper.ExecuteDataset(CommandType.Text, btr.ToString()).Tables[0];
            if (tb.Rows.Count > 0)
            {
                return DbHelper.ExecuteDataset(CommandType.Text, btr.ToString()).Tables[0];
            }
            else
            {
                return null;
            }
        }
            /// <summary>
            /// 添加数据到表tbStoreStorehouseProductsPriceInfo 
            /// </summary>
            /// <returns></returns>
       public int AddStorehouseStorageProductsPriceInfo(storehouseproductsprice storehouseStorage)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tbStoreStorehouseProductsPriceInfo(");
            strSql.Append("StoresID,StoresName,StCode,stName,ProductsID,ProductsName,ProductsBarcode,pPrice,pAppendTime,pUpdateTime)");
            strSql.Append(" values (");
            strSql.Append("@inyStoresID,@chvStoresName,@chvStCode,@chvstName,@inyProductsID,@chvProductsName,@chvProductsBarcode,@delpPrice,@dtmDateTime,GETDATE())");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@inyStoresID",SqlDbType.Int),
                    new SqlParameter("@chvStoresName",SqlDbType.VarChar,50),
					new SqlParameter("@chvStCode",SqlDbType.VarChar,50),
                    new SqlParameter("@chvstName",SqlDbType.VarChar,50),
                    new SqlParameter("@inyProductsID",SqlDbType.Int),
                    new SqlParameter("@chvProductsName",SqlDbType.VarChar,50),
                    new SqlParameter("@chvProductsBarcode",SqlDbType.VarChar,50),
                    new SqlParameter("@delpPrice",SqlDbType.Money),
                    new SqlParameter("@dtmDateTime",SqlDbType.DateTime),};

            parameters[0].Value = storehouseStorage.StoresID;
            parameters[1].Value = storehouseStorage.StoresName;
            parameters[2].Value = storehouseStorage.StCode;
            parameters[3].Value = storehouseStorage.StName;
            parameters[4].Value = storehouseStorage.ProductsID;
            parameters[5].Value = storehouseStorage.ProductsName;
            parameters[6].Value = storehouseStorage.ProductsBarcode;
            parameters[7].Value = storehouseStorage.PPrice;
            parameters[8].Value = storehouseStorage.PAppendTime;

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
       /// 分页获取数据列表
       /// </summary>
       public DataTable GetStorehousePriceInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
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
           parameters[0].Value = "tbStoreStorehouseProductsPriceInfo";
           parameters[1].Value = "ProductPriceID";
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
       /// 匹配门店产品单价数据
       /// </summary>
       public int[] StorehouseStoragePriceSyn()
       {
           int[] ReCount = { 0, 0, 0 };
           DataSet ds = DbHelper.ExecuteDataset(CommandType.StoredProcedure, "sp_" + BaseConfigs.GetTablePrefix + "StorehouseStoragePriceSynInfo");
           if (ds.Tables.Count > 1)
           {
               ReCount[0] = (int)ds.Tables[0].Rows[0][0];
               ReCount[1] = (int)ds.Tables[0].Rows[0][1];
           }
           ds.Clear();
           ds.Dispose();
           return ReCount;
       }

       /// <summary>
       /// 删除一组数据
       /// </summary>
       public void DeleteStoragesPriceInfo(string ProductID)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("delete from tbStoreStorehouseProductsPriceInfo ");
           strSql.Append(" where ProductPriceID in(" + ProductID + ") ");
           DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString());
       }

       /// <summary>
       /// 得到一个对象实体
       /// </summary>
       public storehouseproductsprice GetStorehouseProductsPriceInfoModel(int ProductPriceID)
       {

           StringBuilder strSql = new StringBuilder();
           strSql.Append("select top 1 StoresID,StoresName,stName,StCode,ProductsID,ProductsName,ProductsBarcode,pPrice,pAppendTime from tbStoreStorehouseProductsPriceInfo  ");
           strSql.Append(" where ProductPriceID=@ProductPriceID ");
           SqlParameter[] parameters = {
					new SqlParameter("@ProductPriceID", SqlDbType.Int,4)};
           parameters[0].Value = ProductPriceID;

           storehouseproductsprice model = new storehouseproductsprice();
           DataSet ds = DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(), parameters);
           if (ds.Tables[0].Rows.Count > 0)
           {
               if (ds.Tables[0].Rows[0]["StoresID"].ToString() != "")
               {
                   model.StoresID = int.Parse(ds.Tables[0].Rows[0]["StoresID"].ToString());
               }
               if (ds.Tables[0].Rows[0]["StoresName"].ToString() != "")
               {
                   model.StoresName = ds.Tables[0].Rows[0]["StoresName"].ToString();
               }
               if (ds.Tables[0].Rows[0]["stName"].ToString() != "")
               {
                   model.StName = ds.Tables[0].Rows[0]["stName"].ToString();
               }
               if (ds.Tables[0].Rows[0]["StCode"].ToString() != "")
               {
                   model.StCode = ds.Tables[0].Rows[0]["StCode"].ToString();
               }
               if (ds.Tables[0].Rows[0]["ProductsID"].ToString() != "")
               {
                   model.ProductsID = int.Parse(ds.Tables[0].Rows[0]["ProductsID"].ToString());
               }
               if (ds.Tables[0].Rows[0]["ProductsName"].ToString() != "")
               {
                   model.ProductsName = ds.Tables[0].Rows[0]["ProductsName"].ToString();
               }
               if (ds.Tables[0].Rows[0]["ProductsBarcode"].ToString() != "")
               {
                   model.ProductsBarcode = ds.Tables[0].Rows[0]["ProductsBarcode"].ToString();
               }
               if (ds.Tables[0].Rows[0]["pPrice"].ToString() != "")
               {
                   model.PPrice =decimal.Parse(ds.Tables[0].Rows[0]["pPrice"].ToString());
               }
               if (ds.Tables[0].Rows[0]["pAppendTime"].ToString() != "")
               {
                   model.PAppendTime =DateTime.Parse(ds.Tables[0].Rows[0]["pAppendTime"].ToString());
               }
               return model;
           }
           else
           {
               return null;
           }
       }

       /// <summary>
       /// 更新数据
       /// </summary>
       /// <returns></returns>
       public int UpdateStorehouseStoragePriceInfo(storehouseproductsprice pp)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("update tbStoreStorehouseProductsPriceInfo set ");
           strSql.Append(" pPrice=@mnypPrice,");
           strSql.Append(" ProductsBarcode=@chvProductsBarcode ");
           strSql.Append(" where ProductPriceID=@inyProductPriceID");

           SqlParameter[] parm ={
                               new SqlParameter("@inyProductPriceID",SqlDbType.Int),
                               new SqlParameter("@mnypPrice",SqlDbType.Money),
                               new SqlParameter("@chvProductsBarcode",SqlDbType.VarChar,50),
                               };
           parm[0].Value = pp.ProductPriceID;
           parm[1].Value = pp.PPrice;
           parm[2].Value = pp.ProductsBarcode;

           int state = DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parm);
          if (state > 0)
          {
              return state;
          }
          else
          {
              return -1;
          }

       }
        /// <summary>
        /// 根据产品名称找到产品编号
        /// </summary>
        /// <returns></returns>
       public string getPricePnumByPname(string pName)
       {
           StringBuilder tbr = new StringBuilder();
           tbr.Append("select ProductsID from tbStoreStorehouseProductsPriceInfo where ProductsName='"+pName+"' ");

          return DbHelper.ExecuteScalar(CommandType.Text, tbr.ToString()).ToString();
       }
    }
        #endregion
}
