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
        #region ProductsStorage
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public int ExistsProductsStorage(int StorageID, int ProductsID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 ProductsStorageID from tbProductsStorageInfo");
            strSql.Append(" where StorageID=@StorageID and ProductsID=@ProductsID and datediff(day,pUpdateTime,getdate())=0");
            SqlParameter[] parameters = {
					new SqlParameter("@StorageID", SqlDbType.Int,4),
                                        new SqlParameter("@ProductsID", SqlDbType.Int,4)};
            parameters[0].Value = StorageID;
            parameters[1].Value = ProductsID;
            try
            {
                return Convert.ToInt32(DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters));
            }
            catch
            {
                return -1;
            }
        }
        public int ExistsProductsStorage(int StorageID, int ProductsID, DateTime dT)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 ProductsStorageID from tbProductsStorageInfo");
            strSql.Append(" where StorageID=@StorageID and ProductsID=@ProductsID and datediff(day,pUpdateTime,@dT)=0");
            SqlParameter[] parameters = {
					new SqlParameter("@StorageID", SqlDbType.Int,4),
                                        new SqlParameter("@ProductsID", SqlDbType.Int,4),
                                        new SqlParameter("@dT", SqlDbType.DateTime)};
            parameters[0].Value = StorageID;
            parameters[1].Value = ProductsID;
            parameters[2].Value = dT;

            try
            {
                return Convert.ToInt32(DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters));
            }
            catch
            {
                return -1;
            }
        }

        /// <summary>
        /// 设置产品期初库存
        /// </summary>
        /// <param name="StorageID"></param>
        /// <param name="ProductsID"></param>
        /// <param name="pQuantity"></param>
        /// <returns></returns>
        public bool UpdateProductsBeginningStorage(int StorageID, int ProductsID, decimal pQuantity)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 ProductsStorageLogID from tbProductsStorageLogInfo where StorageID=@StorageID and ProductsID=@ProductsID and pType=-1 and pState=0");
            SqlParameter[] parameters = {
					new SqlParameter("@StorageID", SqlDbType.Int,4),
                                        new SqlParameter("@ProductsID", SqlDbType.Int,4)};
            parameters[0].Value = StorageID;
            parameters[1].Value = ProductsID;
            int ProductsStorageLogID = Convert.ToInt32(DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters));
            if (ProductsStorageLogID > 0)
            {
                strSql.Remove(0, strSql.Length);
                strSql.Append("update tbProductsStorageLogInfo set pQuantity=@pQuantity where StorageID=@StorageID and ProductsID=@ProductsID and pType=-1 and pState=0 and ProductsStorageLogID=@ProductsStorageLogID");
                SqlParameter[] parameters_b ={
                    new SqlParameter("@pQuantity", SqlDbType.Decimal),
                    new SqlParameter("@StorageID", SqlDbType.Int,4),
                    new SqlParameter("@ProductsID", SqlDbType.Int,4),
                    new SqlParameter("@ProductsStorageLogID", SqlDbType.Int,4)
                };
                parameters_b[0].Value = pQuantity;
                parameters_b[1].Value = StorageID;
                parameters_b[2].Value = ProductsID;
                parameters_b[3].Value = ProductsStorageLogID;
                DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters_b);
            }
            else
            {
                strSql.Remove(0, strSql.Length);
                strSql.Append("insert into tbProductsStorageLogInfo(StorageID,ProductsID,OrderID,pQuantity,pType,pAppendTime,pState) ");
                strSql.Append(" values(@StorageID,@ProductsID,0,@pQuantity,-1,getdate(),0)");
                
                SqlParameter[] parameters_b ={
                    new SqlParameter("@pQuantity", SqlDbType.Decimal),
                    new SqlParameter("@StorageID", SqlDbType.Int,4),
                    new SqlParameter("@ProductsID", SqlDbType.Int,4)
                };
                parameters_b[0].Value = pQuantity;
                parameters_b[1].Value = StorageID;
                parameters_b[2].Value = ProductsID;
                DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters_b);
            }
            return true;
        }
        /// <summary>
        /// 取产品指定仓库期初库存
        /// </summary>
        /// <param name="StorageID"></param>
        /// <param name="ProductsID"></param>
        /// <returns></returns>
        public decimal GetProductsBeginningStorage(int StorageID, int ProductsID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 pQuantity from tbProductsStorageLogInfo where StorageID=@StorageID and ProductsID=@ProductsID and pType=-1 and pState=0");
            SqlParameter[] parameters = {
					new SqlParameter("@StorageID", SqlDbType.Int,4),
                                        new SqlParameter("@ProductsID", SqlDbType.Int,4)};
            parameters[0].Value = StorageID;
            parameters[1].Value = ProductsID;
            return Convert.ToDecimal(DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters));
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddProductsStorage(ProductsStorageInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tbProductsStorageInfo(");
            strSql.Append("StorageID,ProductsID,pStorage,pStorageIn,pStorageOut,pUpdateTime)");
            strSql.Append(" values (");
            strSql.Append("@StorageID,@ProductsID,@pStorage,@pStorageIn,@pStorageOut,@pUpdateTime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@StorageID", SqlDbType.Int,4),
					new SqlParameter("@ProductsID", SqlDbType.Int,4),
					new SqlParameter("@pStorage", SqlDbType.Decimal,9),
					new SqlParameter("@pStorageIn", SqlDbType.Decimal,9),
					new SqlParameter("@pStorageOut", SqlDbType.Decimal,9),
					new SqlParameter("@pUpdateTime", SqlDbType.DateTime)};
            parameters[0].Value = model.StorageID;
            parameters[1].Value = model.ProductsID;
            parameters[2].Value = model.pStorage;
            parameters[3].Value = model.pStorageIn;
            parameters[4].Value = model.pStorageOut;
            parameters[5].Value = model.pUpdateTime;

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
        /// 更新一条数据
        /// </summary>
        public void UpdateProductsStorage(ProductsStorageInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbProductsStorageInfo set ");
            strSql.Append("StorageID=@StorageID,");
            strSql.Append("ProductsID=@ProductsID,");
            strSql.Append("pStorage=@pStorage,");
            strSql.Append("pStorageIn=@pStorageIn,");
            strSql.Append("pStorageOut=@pStorageOut,");
            strSql.Append("pUpdateTime=@pUpdateTime");
            strSql.Append(" where ProductsStorageID=@ProductsStorageID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ProductsStorageID", SqlDbType.Int,4),
					new SqlParameter("@StorageID", SqlDbType.Int,4),
					new SqlParameter("@ProductsID", SqlDbType.Int,4),
					new SqlParameter("@pStorage", SqlDbType.Decimal,9),
					new SqlParameter("@pStorageIn", SqlDbType.Decimal,9),
					new SqlParameter("@pStorageOut", SqlDbType.Decimal,9),
					new SqlParameter("@pUpdateTime", SqlDbType.DateTime)};
            parameters[0].Value = model.ProductsStorageID;
            parameters[1].Value = model.StorageID;
            parameters[2].Value = model.ProductsID;
            parameters[3].Value = model.pStorage;
            parameters[4].Value = model.pStorageIn;
            parameters[5].Value = model.pStorageOut;
            parameters[6].Value = model.pUpdateTime;

            DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void DeleteProductsStorage(int ProductsStorageID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbProductsStorageInfo ");
            strSql.Append(" where ProductsStorageID=@ProductsStorageID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ProductsStorageID", SqlDbType.Int,4)};
            parameters[0].Value = ProductsStorageID;

            DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ProductsStorageInfo GetProductsStorageModel(int ProductsStorageID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ProductsStorageID,StorageID,ProductsID,pStorage,pStorageIn,pStorageOut,pUpdateTime from tbProductsStorageInfo ");
            strSql.Append(" where ProductsStorageID=@ProductsStorageID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ProductsStorageID", SqlDbType.Int,4)};
            parameters[0].Value = ProductsStorageID;

            ProductsStorageInfo model = new ProductsStorageInfo();
            DataSet ds = DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ProductsStorageID"].ToString() != "")
                {
                    model.ProductsStorageID = int.Parse(ds.Tables[0].Rows[0]["ProductsStorageID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["StorageID"].ToString() != "")
                {
                    model.StorageID = int.Parse(ds.Tables[0].Rows[0]["StorageID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ProductsID"].ToString() != "")
                {
                    model.ProductsID = int.Parse(ds.Tables[0].Rows[0]["ProductsID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["pStorage"].ToString() != "")
                {
                    model.pStorage = decimal.Parse(ds.Tables[0].Rows[0]["pStorage"].ToString());
                }
                if (ds.Tables[0].Rows[0]["pStorageIn"].ToString() != "")
                {
                    model.pStorageIn = decimal.Parse(ds.Tables[0].Rows[0]["pStorageIn"].ToString());
                }
                if (ds.Tables[0].Rows[0]["pStorageOut"].ToString() != "")
                {
                    model.pStorageOut = decimal.Parse(ds.Tables[0].Rows[0]["pStorageOut"].ToString());
                }
                if (ds.Tables[0].Rows[0]["pUpdateTime"].ToString() != "")
                {
                    model.pUpdateTime = DateTime.Parse(ds.Tables[0].Rows[0]["pUpdateTime"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 取当前指定仓库/产品,库存
        /// </summary>
        /// <param name="StorageID"></param>
        /// <param name="ProductsID"></param>
        /// <returns></returns>
        public ProductsStorageInfo GetProductsStorageModel(int StorageID, int ProductsID)
        {
            return GetProductsStorageModel(StorageID, ProductsID, DateTime.Now);
        }
        /// <summary>
        /// 取当指定时间指定仓库/产品,库存
        /// </summary>
        /// <param name="StorageID"></param>
        /// <param name="ProductsID"></param>
        /// <param name="dT"></param>
        /// <returns></returns>
        public ProductsStorageInfo GetProductsStorageModel(int StorageID, int ProductsID, DateTime dT)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ProductsStorageID,StorageID,ProductsID,pStorage,pStorageIn,pStorageOut,pUpdateTime,(select top 1 isBad from tbStockProductInfo where sAppendTime<=@dT and ProductsID=@ProductsID and StorageID=@StorageID  order by sAppendTime desc) as StorageBad  from tbProductsStorageInfo ");
            strSql.Append(" where StorageID=@StorageID and ProductsID=@ProductsID and datediff(day,pUpdateTime,@dT)=0");
            SqlParameter[] parameters = {
					new SqlParameter("@StorageID", SqlDbType.Int,4),
                                        new SqlParameter("@ProductsID", SqlDbType.Int,4),
                                        new SqlParameter("@dT", SqlDbType.DateTime)};
            parameters[0].Value = StorageID;
            parameters[1].Value = ProductsID;
            parameters[2].Value = dT;

            ProductsStorageInfo model = new ProductsStorageInfo();
            DataSet ds = DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ProductsStorageID"].ToString() != "")
                {
                    model.ProductsStorageID = int.Parse(ds.Tables[0].Rows[0]["ProductsStorageID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["StorageID"].ToString() != "")
                {
                    model.StorageID = int.Parse(ds.Tables[0].Rows[0]["StorageID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ProductsID"].ToString() != "")
                {
                    model.ProductsID = int.Parse(ds.Tables[0].Rows[0]["ProductsID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["pStorage"].ToString() != "")
                {
                    model.pStorage = decimal.Parse(ds.Tables[0].Rows[0]["pStorage"].ToString());
                }
                if (ds.Tables[0].Rows[0]["pStorageIn"].ToString() != "")
                {
                    model.pStorageIn = decimal.Parse(ds.Tables[0].Rows[0]["pStorageIn"].ToString());
                }
                if (ds.Tables[0].Rows[0]["pStorageOut"].ToString() != "")
                {
                    model.pStorageOut = decimal.Parse(ds.Tables[0].Rows[0]["pStorageOut"].ToString());
                }
                if (ds.Tables[0].Rows[0]["StorageBad"].ToString() != "")
                {
                    model.pStorageBad = decimal.Parse(ds.Tables[0].Rows[0]["StorageBad"].ToString());
                }
                if (ds.Tables[0].Rows[0]["pUpdateTime"].ToString() != "")
                {
                    model.pUpdateTime = DateTime.Parse(ds.Tables[0].Rows[0]["pUpdateTime"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 更是商品库存信息
        /// </summary>
        /// <param name="OrderID"></param>
        /// <returns></returns>
        public bool UpdateProductsStorageByOrderID(int OrderID)
        {

                DataTable dList = new DataTable();
                try
                {
                    dList = GetOrderListInfoList(" OrderID=" + OrderID + " and oWorkType<>0 order by OrderListID asc").Tables[0];
                    foreach (DataRow dr in dList.Rows)
                    {
                        if (Convert.ToInt32(dr["oWorkType"]) == 1)
                        {
                            AddProductsStorage(Convert.ToInt32(dr["StorageID"]), Convert.ToInt32(dr["ProductsID"]));
                        }
                    }
                    return true;
                }
                finally
                {
                    dList.Clear();
                }

        }
        /// <summary>
        /// 添加当前指定仓库/商品库存
        /// </summary>
        /// <param name="StorageID"></param>
        /// <param name="ProductsID"></param>
        /// <returns></returns>
        public int AddProductsStorage(int StorageID, int ProductsID)
        {
            return AddProductsStorage(StorageID, ProductsID, DateTime.Now);
        }
        /// <summary>
        /// 添加指定时间指定仓库/商品库存
        /// </summary>
        /// <param name="StorageID"></param>
        /// <param name="ProductsID"></param>
        /// <param name="dT"></param>
        /// <returns></returns>
        public int AddProductsStorage(int StorageID, int ProductsID, DateTime dT)
        {
            int ProductsStorageID = 0;
            decimal pStorage = 0;//计算实际库存
            decimal pStorageIn = 0;//入库未结存
            decimal pStorageOut = 0;//出库未结存

            StringBuilder strSql = new StringBuilder();

            //调拨单处理，正数为增加，负数为减少
            strSql.Append("declare @QuantityIn Decimal;"+
                                    "declare @QuantityOut Decimal;"+
            "select @QuantityIn = isnull(sum(oQuantity),0) from tbOrderListInfo where oWorkType=1 " +
                                    " and OrderID in(select OrderID from tbOrderInfo where oState=0 and oType =9 and oSteps>=4)" +
                                    " and StorageID=@StorageID and ProductsID=@ProductsID and oAppendTime<=@dT and oQuantity>0;"+
            "select @QuantityOut = isnull(sum(oQuantity),0)*-1 from tbOrderListInfo where oWorkType=1 " +
                                    " and OrderID in(select OrderID from tbOrderInfo where oState=0 and oType =9) " +
                                    " and StorageID=@StorageID and ProductsID=@ProductsID and oAppendTime<=@dT and oQuantity<0; ");

            strSql.Append("select vStorage.Quantity,vStorageIn.Quantity,vStorageOut.Quantity from ");

            //实际库存
            strSql.Append("(select  isnull(sum(pQuantity),0) as Quantity  from tbProductsStorageLogInfo ");
            strSql.Append(" where StorageID=@StorageID and ProductsID=@ProductsID and  pAppendTime<=@dT  and pType<>-1) as vStorage,");

            //开单后已审核未核销的单据
            //入库,已收货后途中库存增加
            strSql.Append("(select (isnull(sum(oQuantity),0)+@QuantityIn) as Quantity from tbOrderListInfo where oWorkType=1 ");//审核后核销前
            strSql.Append("and OrderID in(select OrderID from tbOrderInfo where oState=0 and oType in(1,4,8) and oSteps>=4) ");
            strSql.Append("and StorageID=@StorageID and ProductsID=@ProductsID and oAppendTime<=@dT ) as vStorageIn,");//oAppendTime<=@dT

            //特殊情况**********换货单(oType=11):审核后库存减少,核销后库存增加**********
            //所以未核销前属于 出库性质
            //出库
            strSql.Append("(select (isnull(sum(oQuantity),0)+@QuantityOut) as Quantity from tbOrderListInfo where oWorkType=1 ");//审核后核销前
            strSql.Append("and OrderID in(select OrderID from tbOrderInfo where oState=0 and oType in(2,3,5,6,7,10,11)) ");
            strSql.Append("and StorageID=@StorageID and ProductsID=@ProductsID and oAppendTime<=@dT ) as vStorageOut ");// oAppendTime<=@dT

            strSql.Append("");
            SqlParameter[] parameters = {
					new SqlParameter("@StorageID", SqlDbType.Int,4),
                                        new SqlParameter("@ProductsID", SqlDbType.Int,4),
                                        new SqlParameter("@dT", SqlDbType.DateTime)
                                        };
            parameters[0].Value = StorageID;
            parameters[1].Value = ProductsID;
            parameters[2].Value = dT;
            
            DataSet ds = DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(), parameters);
            if (ds != null)
            {
                pStorage = Convert.ToDecimal(ds.Tables[0].Rows[0][0]);
                pStorageIn = Convert.ToDecimal(ds.Tables[0].Rows[0][1]);
                pStorageOut = Convert.ToDecimal(ds.Tables[0].Rows[0][2]);
                ProductsStorageID = ExistsProductsStorage(StorageID, ProductsID, dT);//是否已经存在记录
                if (ProductsStorageID > 0)
                {
                    ProductsStorageInfo psi = GetProductsStorageModel(ProductsStorageID);
                    if (psi != null)
                    {
                        psi.pStorage = pStorage;
                        psi.pStorageIn = pStorageIn;
                        psi.pStorageOut = pStorageOut;
                        psi.pUpdateTime = DateTime.Now;
                        UpdateProductsStorage(psi);//已存在的更新
                    }
                }
                else
                {
                    ProductsStorageInfo psi = new ProductsStorageInfo();
                    psi.StorageID = StorageID;
                    psi.ProductsID = ProductsID;
                    psi.pStorage = pStorage;
                    psi.pStorageIn = pStorageIn;
                    psi.pStorageOut = pStorageOut;
                    psi.pUpdateTime = DateTime.Now;
                    ProductsStorageID = AddProductsStorage(psi);//不存在的创建
                }
            }
            return ProductsStorageID;
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetProductsStorageList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select s.ProductsStorageID,s.StorageID,s.ProductsID,s.pStorage,s.pStorageIn,s.pStorageOut,s.pUpdateTime ");
            strSql.Append(" FROM tbProductsStorageInfo as s ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString());
        }

        /// <summary>
        /// 产品库存列表
        /// </summary>
        /// <param name="StorageID">仓库编号</param>
        /// <param name="sDateTime">时间点</param>
        /// <returns></returns>
        public DataTable GetProductsStorageInfoByStorageID(int sClassID,int StorageID, DateTime sDateTime, int ProductsID)
        {
            
            DataTable dt = new DataTable();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select pps.ProductsID,pps.ProductClassID,pps.pBarcode,pps.pName,pps.pSellingPrice,pps.pStorage,pps.pStorageIn,pps.pStorageOut,s.StorageID,pps.pUpdateTime,s.sCode,s.sName,isnull((select top 1 isnull(pQuantity,0) from tbProductsStorageLogInfo where StorageID=pps.StorageID and ProductsID=pps.ProductsID and pType=-1 and pState=0),0) as Beginning, " +
                "isnull((select top 1 isnull(isBad,0) from tbStockProductInfo where sAppendTime<=@dT and ProductsID=pps.ProductsID and StorageID=pps.StorageID order by sAppendTime desc),0) as StorageBad " +
                "from (select p.ProductsID,p.ProductClassID, p.pBarcode,p.pName,p.pSellingPrice,ps.StorageID,isnull(ps.pStorage,0) pStorage,isnull(ps.pStorageIn,0) pStorageIn,isnull(ps.pStorageOut,0) pStorageOut,isnull(ps.pUpdateTime,getdate()) as pUpdateTime from tbProductsInfo as p left join tbProductsStorageInfo as ps on p.ProductsID=ps.ProductsID where p.pState<>1) as pps left join tbStorageInfo as s on pps.StorageID=s.StorageID ");
            strSql.Append(" where  datediff(day,pps.pUpdateTime,@dT)=0   ");
            if(StorageID>0){
                strSql.Append(" and pps.StorageID=" + StorageID);
            }
            if (StorageID == 0 && sClassID == 0)
            {

            }
            else if(StorageID == 0)
            {
                strSql.Append(" and pps.StorageID in (select StorageID from tbStorageInfo where StorageClassID='" + sClassID + "')");
            }
            if (ProductsID > 0)
            {
                strSql.Append(" and pps.ProductsID=" + ProductsID);
            }

            strSql.Append("  order by pps.ProductClassID,pps.ProductsID desc ");
           
            SqlParameter[] parameters = {
                    new SqlParameter("@dt", SqlDbType.DateTime)
                                        };
            parameters[0].Value = sDateTime;

            return DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(), parameters).Tables[0];
        }
        /// <summary>
        /// 产品库存列表,Cxty_20110712
        /// </summary>
        /// <param name="StorageID"></param>
        /// <param name="sDateTime"></param>
        /// <param name="ProductsID"></param>
        /// <returns></returns>
        public DataTable GetProductsStorageInfoByStorageID_XP(int StorageID, DateTime sDateTime, int ProductsID)
        {

            DataTable dt = new DataTable();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select pps.ProductsID,pps.ProductClassID,pps.pCode,(select pClassName from tbProductClassInfo where ProductClassID=pps.ProductClassID) as ProductClassName,pps.pSellingPrice,pps.pBarcode,pps.pName,pps.pStorage,pps.pStorageIn,pps.pStorageOut,pps.StorageID,pps.pUpdateTime,pps.sCode,pps.sName,isnull((select top 1 isnull(pQuantity,0) from tbProductsStorageLogInfo where StorageID=pps.StorageID and ProductsID=pps.ProductsID and pType=-1 and pState=0),0) as Beginning, " +
                                "isnull((select top 1 isnull(isBad,0) from tbStockProductInfo where sAppendTime<=@dT and ProductsID=pps.ProductsID and StorageID=pps.StorageID order by sAppendTime desc),0) as StorageBad "+
                                " from ( "+
                                "select pp.ProductsID,pp.ProductClassID,pp.pCode, pp.pBarcode,pp.pName,pp.pSellingPrice,pp.StorageID,pp.sName,pp.sCode,isnull(ps.pStorage,0) pStorage,isnull(ps.pStorageIn,0) pStorageIn,isnull(ps.pStorageOut,0) pStorageOut,isnull(ps.pUpdateTime,getdate()) as pUpdateTime from ( " +
                                "select p.ProductsID,p.ProductClassID, p.pBarcode,p.pName,p.pSellingPrice,p.pCode,s.StorageID,s.sName,s.sCode from tbProductsInfo as p,tbStorageInfo s where p.pState<>1 " +
                                ") as pp left join  "+
                                "(select * from tbProductsStorageInfo where datediff(day,pUpdateTime,@dT)=0 and ProductsStorageID in(select MIN(ProductsStorageID) from tbProductsStorageInfo where datediff(day,pUpdateTime,@dT)=0 group by ProductsID,StorageID)) as ps on ps.ProductsID=pp.ProductsID and ps.StorageID=pp.StorageID " +
                                ") as pps ");
            strSql.Append(" where  0=0   ");
            if (StorageID > 0)
            {
                strSql.Append(" and pps.StorageID=" + StorageID);
            }
            if (ProductsID > 0)
            {
                strSql.Append(" and pps.ProductsID=" + ProductsID);
            }
            strSql.Append("  order by pps.ProductClassID,pps.ProductsID desc ");

            SqlParameter[] parameters = {
                    new SqlParameter("@dt", SqlDbType.DateTime)
                                        };
            parameters[0].Value = sDateTime;

            return DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(), parameters).Tables[0];
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetProductsStorageInfoList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" ProductsStorageID,StorageID,ProductsID,pStorage,pStorageIn,pStorageOut,pUpdateTime ");
            strSql.Append(" FROM tbProductsStorageInfo ");
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
        public DataTable GetProductsStorageList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
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
            parameters[0].Value = "tbProductsStorageInfo";
            parameters[1].Value = "ProductsStorageID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 1;
            parameters[5].Value = OrderType;
            parameters[6].Value = strWhere;
            parameters[7].Value = showFName + ",";
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

        #region ProductsStorageLog
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddProductsStorageLog(ProductsStorageLogInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tbProductsStorageLogInfo(");
            strSql.Append("StorageID,ProductsID,OrderID,pQuantity,pType,pAppendTime,pState)");
            strSql.Append(" values (");
            strSql.Append("@StorageID,@ProductsID,@OrderID,@pQuantity,@pType,@pAppendTime,@pState)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@StorageID", SqlDbType.Int,4),
					new SqlParameter("@ProductsID", SqlDbType.Int,4),
					new SqlParameter("@OrderID", SqlDbType.Int,4),
					new SqlParameter("@pQuantity", SqlDbType.Decimal,9),
					new SqlParameter("@pType", SqlDbType.Int,4),
					new SqlParameter("@pAppendTime", SqlDbType.DateTime),
					new SqlParameter("@pState", SqlDbType.Int,4)};
            parameters[0].Value = model.StorageID;
            parameters[1].Value = model.ProductsID;
            parameters[2].Value = model.OrderID;
            parameters[3].Value = model.pQuantity;
            parameters[4].Value = model.pType;
            parameters[5].Value = model.pAppendTime;
            parameters[6].Value = model.pState;

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
        /// 更新一条数据
        /// </summary>
        public void UpdateProductsStorageLog(ProductsStorageLogInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbProductsStorageLogInfo set ");
            strSql.Append("StorageID=@StorageID,");
            strSql.Append("ProductsID=@ProductsID,");
            strSql.Append("OrderID=@OrderID,");
            strSql.Append("pQuantity=@pQuantity,");
            strSql.Append("pType=@pType,");
            strSql.Append("pAppendTime=@pAppendTime,");
            strSql.Append("pState=@pState");
            strSql.Append(" where ProductsStorageLogID=@ProductsStorageLogID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ProductsStorageLogID", SqlDbType.Int,4),
					new SqlParameter("@StorageID", SqlDbType.Int,4),
					new SqlParameter("@ProductsID", SqlDbType.Int,4),
					new SqlParameter("@OrderID", SqlDbType.Int,4),
					new SqlParameter("@pQuantity", SqlDbType.Decimal,9),
					new SqlParameter("@pType", SqlDbType.Int,4),
					new SqlParameter("@pAppendTime", SqlDbType.DateTime),
					new SqlParameter("@pState", SqlDbType.Int,4)};
            parameters[0].Value = model.ProductsStorageLogID;
            parameters[1].Value = model.StorageID;
            parameters[2].Value = model.ProductsID;
            parameters[3].Value = model.OrderID;
            parameters[4].Value = model.pQuantity;
            parameters[5].Value = model.pType;
            parameters[6].Value = model.pAppendTime;
            parameters[7].Value = model.pState;

            DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString());
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void DeleteProductsStorageLog(int ProductsStorageLogID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbProductsStorageLogInfo ");
            strSql.Append(" where ProductsStorageLogID=@ProductsStorageLogID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ProductsStorageLogID", SqlDbType.Int,4)};
            parameters[0].Value = ProductsStorageLogID;

            DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString());
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ProductsStorageLogInfo GetProductsStorageLogModel(int ProductsStorageLogID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ProductsStorageLogID,StorageID,ProductsID,OrderID,pQuantity,pType,pAppendTime,pState from tbProductsStorageLogInfo ");
            strSql.Append(" where ProductsStorageLogID=@ProductsStorageLogID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ProductsStorageLogID", SqlDbType.Int,4)};
            parameters[0].Value = ProductsStorageLogID;

            ProductsStorageLogInfo model = new ProductsStorageLogInfo();
            DataSet ds = DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ProductsStorageLogID"].ToString() != "")
                {
                    model.ProductsStorageLogID = int.Parse(ds.Tables[0].Rows[0]["ProductsStorageLogID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["StorageID"].ToString() != "")
                {
                    model.StorageID = int.Parse(ds.Tables[0].Rows[0]["StorageID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ProductsID"].ToString() != "")
                {
                    model.ProductsID = int.Parse(ds.Tables[0].Rows[0]["ProductsID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OrderID"].ToString() != "")
                {
                    model.OrderID = int.Parse(ds.Tables[0].Rows[0]["OrderID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["pQuantity"].ToString() != "")
                {
                    model.pQuantity = decimal.Parse(ds.Tables[0].Rows[0]["pQuantity"].ToString());
                }
                if (ds.Tables[0].Rows[0]["pType"].ToString() != "")
                {
                    model.pType = int.Parse(ds.Tables[0].Rows[0]["pType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["pAppendTime"].ToString() != "")
                {
                    model.pAppendTime = DateTime.Parse(ds.Tables[0].Rows[0]["pAppendTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["pState"].ToString() != "")
                {
                    model.pState = int.Parse(ds.Tables[0].Rows[0]["pState"].ToString());
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
        public DataSet GetProductsStorageLogList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ProductsStorageLogID,StorageID,ProductsID,OrderID,pQuantity,pType,pAppendTime,pState ");
            strSql.Append(" FROM tbProductsStorageLogInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetProductsStorageLogList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" ProductsStorageLogID,StorageID,ProductsID,OrderID,pQuantity,pType,pAppendTime,pState ");
            strSql.Append(" FROM tbProductsStorageLogInfo ");
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
        public DataTable GetProductsStorageLogList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
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
            parameters[0].Value = "tbProductsStorageLogInfo";
            parameters[1].Value = "ProductsStorageLogID";
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
