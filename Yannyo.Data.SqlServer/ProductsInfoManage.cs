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
        #region  ProductsInfo
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistsProductsInfo(string pName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tbProductsInfo");
            strSql.Append(" where pName=@pName ");
            SqlParameter[] parameters = {
					new SqlParameter("@pName", SqlDbType.VarChar,128)};
            parameters[0].Value = pName;

            return ((int)DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters)) > 0;
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistsProductsInfo_pCode(string pCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tbProductsInfo");
            strSql.Append(" where pCode=@pCode ");
            SqlParameter[] parameters = {
					new SqlParameter("@pCode", SqlDbType.VarChar,50)};
            parameters[0].Value = pCode;

            return ((int)DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters)) > 0;
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistsProductsInfo_pBarcode(string pBarcode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tbProductsInfo");
            strSql.Append(" where pBarcode=@pBarcode ");
            SqlParameter[] parameters = {
					new SqlParameter("@pBarcode", SqlDbType.VarChar,50)};
            parameters[0].Value = pBarcode;

            return ((int)DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters)) > 0;
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddProductsInfo(ProductsInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tbProductsInfo(");
            strSql.Append("pCode,pBarcode,pName,pEnName,pBrand,pStandard,pUnits,pToBoxNo,pState,pAppendTime,pPrice,pDoDayQuantity,ProductClassID,pMaxUnits,pProducer,pExpireDay,pAddress)");
            strSql.Append(" values (");
            strSql.Append("@pCode,@pBarcode,@pName,@pEnName,@pBrand,@pStandard,@pUnits,@pToBoxNo,@pState,@pAppendTime,@pPrice,@pDoDayQuantity,@ProductClassID,@pMaxUnits,@pProducer,@pExpireDay,@pAddress)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@pCode", SqlDbType.VarChar,50),
					new SqlParameter("@pBarcode", SqlDbType.VarChar,50),
					new SqlParameter("@pName", SqlDbType.VarChar,128),
					new SqlParameter("@pBrand", SqlDbType.VarChar,128),
					new SqlParameter("@pStandard", SqlDbType.VarChar,50),
					new SqlParameter("@pUnits", SqlDbType.VarChar,50),
					new SqlParameter("@pToBoxNo", SqlDbType.Int,4),
					new SqlParameter("@pState", SqlDbType.Int,4),
					new SqlParameter("@pAppendTime", SqlDbType.DateTime),
                    new SqlParameter("@pPrice", SqlDbType.Money,8),
                    new SqlParameter("@pDoDayQuantity",SqlDbType.Decimal),
                                        new SqlParameter("@ProductClassID", SqlDbType.Int,4),
                                        new SqlParameter("@pMaxUnits", SqlDbType.VarChar,50),
                                        new SqlParameter("@pProducer", SqlDbType.VarChar,512),
                                        new SqlParameter("@pExpireDay", SqlDbType.VarChar,50),
                                         new SqlParameter("@pAddress", SqlDbType.VarChar,512),
                    new SqlParameter("@pEnName", SqlDbType.VarChar,128),};
            parameters[0].Value = model.pCode;
            parameters[1].Value = model.pBarcode;
            parameters[2].Value = model.pName;
            parameters[3].Value = model.pBrand;
            parameters[4].Value = model.pStandard;
            parameters[5].Value = model.pUnits;
            parameters[6].Value = model.pToBoxNo;
            parameters[7].Value = model.pState;
            parameters[8].Value = model.pAppendTime;
            parameters[9].Value = model.pPrice;
            parameters[10].Value = model.pDoDayQuantity;
            parameters[11].Value = model.ProductClassID;
            parameters[12].Value = model.pMaxUnits;
            parameters[13].Value = model.pProducer;
            parameters[14].Value = model.pExpireDay;
            parameters[15].Value = model.pAddress;
            parameters[16].Value = model.pEnName;

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
        public void UpdateProductsInfo(ProductsInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbProductsInfo set ");
            strSql.Append("pCode=@pCode,");
            strSql.Append("pBarcode=@pBarcode,");
            strSql.Append("pName=@pName,");
            strSql.Append("pBrand=@pBrand,");
            strSql.Append("pStandard=@pStandard,");
            strSql.Append("pUnits=@pUnits,");
            strSql.Append("pToBoxNo=@pToBoxNo,");
            strSql.Append("pState=@pState,");
            strSql.Append("pPrice=@pPrice,");
            strSql.Append("pAppendTime=@pAppendTime,");
            strSql.Append("pDoDayQuantity=@pDoDayQuantity,");
            strSql.Append("ProductClassID=@ProductClassID,");
            strSql.Append("pMaxUnits=@pMaxUnits,");
            strSql.Append("pProducer=@pProducer,");
            strSql.Append("pExpireDay=@pExpireDay,");
            strSql.Append("pEnName=@pEnName,");
            strSql.Append("pAddress=@pAddress");
            strSql.Append(" where ProductsID=@ProductsID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ProductsID", SqlDbType.Int,4),
					new SqlParameter("@pCode", SqlDbType.VarChar,50),
					new SqlParameter("@pBarcode", SqlDbType.VarChar,50),
					new SqlParameter("@pName", SqlDbType.VarChar,128),
					new SqlParameter("@pBrand", SqlDbType.VarChar,128),
					new SqlParameter("@pStandard", SqlDbType.VarChar,50),
					new SqlParameter("@pUnits", SqlDbType.VarChar,50),
					new SqlParameter("@pToBoxNo", SqlDbType.Int,4),
					new SqlParameter("@pState", SqlDbType.Int,4),
                    new SqlParameter("@pPrice", SqlDbType.Money,8),
					new SqlParameter("@pAppendTime", SqlDbType.DateTime),
					new SqlParameter("@pDoDayQuantity", SqlDbType.Decimal),
                                        new SqlParameter("@ProductClassID", SqlDbType.Int,4),
                                        new SqlParameter("@pMaxUnits", SqlDbType.VarChar,50),
                                        new SqlParameter("@pProducer", SqlDbType.VarChar,512),
                                        new SqlParameter("@pExpireDay", SqlDbType.VarChar,50),
                                        new SqlParameter("@pAddress", SqlDbType.VarChar,512),
                    new SqlParameter("@pEnName", SqlDbType.VarChar,128),};
            parameters[0].Value = model.ProductsID;
            parameters[1].Value = model.pCode;
            parameters[2].Value = model.pBarcode;
            parameters[3].Value = model.pName;
            parameters[4].Value = model.pBrand;
            parameters[5].Value = model.pStandard;
            parameters[6].Value = model.pUnits;
            parameters[7].Value = model.pToBoxNo;
            parameters[8].Value = model.pState;
            parameters[9].Value = model.pPrice;
            parameters[10].Value = model.pAppendTime;
            parameters[11].Value = model.pDoDayQuantity;
            parameters[12].Value = model.ProductClassID;
            parameters[13].Value = model.pMaxUnits;
            parameters[14].Value = model.pProducer;
            parameters[15].Value = model.pExpireDay;
            parameters[16].Value = model.pAddress;
            parameters[17].Value = model.pEnName;

            DbHelper.ExecuteNonQuery(CommandType.Text,strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void DeleteProductsInfo(int ProductsID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbProductsInfo ");
            strSql.Append(" where ProductsID=@ProductsID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ProductsID", SqlDbType.Int,4)};
            parameters[0].Value = ProductsID;

            DbHelper.ExecuteNonQuery(CommandType.Text,strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一组数据
        /// </summary>
        public void DeleteProductsInfo(string ProductsID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbProductsInfo ");
            strSql.Append(" where ProductsID in(" + ProductsID + ") ");

            DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString());
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ProductsInfo GetProductsInfoModel(int ProductsID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ProductsID,pCode,pBarcode,pName,pEnName,pBrand,pStandard,pUnits,pMaxUnits,pToBoxNo,pState,pAppendTime,pPrice,pDoDayQuantity,ProductClassID,(select tbProductClassInfo.pClassName from tbProductClassInfo where tbProductClassInfo.ProductClassID=tbProductsInfo.ProductClassID) as ProductClass,pProducer,pExpireDay,pAddress,isnull((select top 1 cPrice from tbCostValenceInfo where ProductsID=tbProductsInfo.ProductsID order by cDateTime desc),0) as NowPrice from tbProductsInfo ");
            strSql.Append(" where ProductsID=@ProductsID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ProductsID", SqlDbType.Int,4)};
            parameters[0].Value = ProductsID;

            ProductsInfo model = new ProductsInfo();
            DataSet ds = DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ProductsID"].ToString() != "")
                {
                    model.ProductsID = int.Parse(ds.Tables[0].Rows[0]["ProductsID"].ToString());
                }
                model.pCode = ds.Tables[0].Rows[0]["pCode"].ToString();
                model.pBarcode = ds.Tables[0].Rows[0]["pBarcode"].ToString();
                model.pName = ds.Tables[0].Rows[0]["pName"].ToString();
                model.pBrand = ds.Tables[0].Rows[0]["pBrand"].ToString();
                model.pStandard = ds.Tables[0].Rows[0]["pStandard"].ToString();
                model.pUnits = ds.Tables[0].Rows[0]["pUnits"].ToString();
                model.pMaxUnits = ds.Tables[0].Rows[0]["pMaxUnits"].ToString();
                model.pProducer = ds.Tables[0].Rows[0]["pProducer"].ToString();
                model.pExpireDay = ds.Tables[0].Rows[0]["pExpireDay"].ToString();
                model.pAddress = ds.Tables[0].Rows[0]["pAddress"].ToString();

                model.pEnName = ds.Tables[0].Rows[0]["pEnName"].ToString();
                if (ds.Tables[0].Rows[0]["ProductClassID"].ToString() != "")
                {
                    model.ProductClassID = int.Parse(ds.Tables[0].Rows[0]["ProductClassID"].ToString());
                }
                model.ProductClass = ds.Tables[0].Rows[0]["ProductClass"].ToString();
                if (ds.Tables[0].Rows[0]["pToBoxNo"].ToString() != "")
                {
                    model.pToBoxNo = int.Parse(ds.Tables[0].Rows[0]["pToBoxNo"].ToString());
                }
                if (ds.Tables[0].Rows[0]["pState"].ToString() != "")
                {
                    model.pState = int.Parse(ds.Tables[0].Rows[0]["pState"].ToString());
                }
                if (ds.Tables[0].Rows[0]["pAppendTime"].ToString() != "")
                {
                    model.pAppendTime = DateTime.Parse(ds.Tables[0].Rows[0]["pAppendTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["pPrice"].ToString() != "")
                {
                    model.pPrice = decimal.Parse(ds.Tables[0].Rows[0]["pPrice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["NowPrice"].ToString() != "")
                {
                    model.NowPrice = decimal.Parse(ds.Tables[0].Rows[0]["NowPrice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["pDoDayQuantity"].ToString() != "")
                {
                    model.pDoDayQuantity = decimal.Parse(ds.Tables[0].Rows[0]["pDoDayQuantity"].ToString());
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
		public ProductsInfo GetProductsInfoModelByCode(string Code)
		{

			StringBuilder strSql = new StringBuilder();
			strSql.Append("select  top 1 ProductsID,pCode,pBarcode,pName,pEnName,pBrand,pStandard,pUnits,pMaxUnits,pToBoxNo,pState,pAppendTime,pPrice,pDoDayQuantity,ProductClassID,(select tbProductClassInfo.pClassName from tbProductClassInfo where tbProductClassInfo.ProductClassID=tbProductsInfo.ProductClassID) as ProductClass,pProducer,pExpireDay,pAddress,isnull((select top 1 cPrice from tbCostValenceInfo where ProductsID=tbProductsInfo.ProductsID order by cDateTime desc),0) as NowPrice from tbProductsInfo ");
			strSql.Append(" where pCode=@pCode ");
			SqlParameter[] parameters = {
				new SqlParameter("@pCode", SqlDbType.VarChar,50)};
			parameters[0].Value = Code;

			ProductsInfo model = new ProductsInfo();
			DataSet ds = DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(), parameters);
			if (ds.Tables[0].Rows.Count > 0)
			{
				if (ds.Tables[0].Rows[0]["ProductsID"].ToString() != "")
				{
					model.ProductsID = int.Parse(ds.Tables[0].Rows[0]["ProductsID"].ToString());
				}
				model.pCode = ds.Tables[0].Rows[0]["pCode"].ToString();
				model.pBarcode = ds.Tables[0].Rows[0]["pBarcode"].ToString();
				model.pName = ds.Tables[0].Rows[0]["pName"].ToString();
				model.pBrand = ds.Tables[0].Rows[0]["pBrand"].ToString();
				model.pStandard = ds.Tables[0].Rows[0]["pStandard"].ToString();
				model.pUnits = ds.Tables[0].Rows[0]["pUnits"].ToString();
				model.pMaxUnits = ds.Tables[0].Rows[0]["pMaxUnits"].ToString();
				model.pProducer = ds.Tables[0].Rows[0]["pProducer"].ToString();
				model.pExpireDay = ds.Tables[0].Rows[0]["pExpireDay"].ToString();
				model.pAddress = ds.Tables[0].Rows[0]["pAddress"].ToString();
                model.pEnName = ds.Tables[0].Rows[0]["pEnName"].ToString();

                if (ds.Tables[0].Rows[0]["ProductClassID"].ToString() != "")
				{
					model.ProductClassID = int.Parse(ds.Tables[0].Rows[0]["ProductClassID"].ToString());
				}
				model.ProductClass = ds.Tables[0].Rows[0]["ProductClass"].ToString();
				if (ds.Tables[0].Rows[0]["pToBoxNo"].ToString() != "")
				{
					model.pToBoxNo = int.Parse(ds.Tables[0].Rows[0]["pToBoxNo"].ToString());
				}
				if (ds.Tables[0].Rows[0]["pState"].ToString() != "")
				{
					model.pState = int.Parse(ds.Tables[0].Rows[0]["pState"].ToString());
				}
				if (ds.Tables[0].Rows[0]["pAppendTime"].ToString() != "")
				{
					model.pAppendTime = DateTime.Parse(ds.Tables[0].Rows[0]["pAppendTime"].ToString());
				}
				if (ds.Tables[0].Rows[0]["pPrice"].ToString() != "")
				{
					model.pPrice = decimal.Parse(ds.Tables[0].Rows[0]["pPrice"].ToString());
				}
				if (ds.Tables[0].Rows[0]["NowPrice"].ToString() != "")
				{
					model.NowPrice = decimal.Parse(ds.Tables[0].Rows[0]["NowPrice"].ToString());
				}
				if (ds.Tables[0].Rows[0]["pDoDayQuantity"].ToString() != "")
				{
					model.pDoDayQuantity = decimal.Parse(ds.Tables[0].Rows[0]["pDoDayQuantity"].ToString());
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
        public ProductsInfo GetProductsInfoModelByName(string pName)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ProductsID,pCode,pBarcode,pName,pEnName,pBrand,pStandard,pUnits,pToBoxNo,pMaxUnits,pState,pAppendTime,pPrice,pDoDayQuantity,ProductClassID,(select tbProductClassInfo.pClassName from tbProductClassInfo where tbProductClassInfo.ProductClassID=tbProductsInfo.ProductClassID) as ProductClass,pProducer,pExpireDay,pAddress from tbProductsInfo ");
            strSql.Append(" where pName=@pName ");
            SqlParameter[] parameters = {
					new SqlParameter("@pName", SqlDbType.VarChar,128)};
            parameters[0].Value = pName;

            ProductsInfo model = new ProductsInfo();
            DataSet ds = DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ProductsID"].ToString() != "")
                {
                    model.ProductsID = int.Parse(ds.Tables[0].Rows[0]["ProductsID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ProductClassID"].ToString() != "")
                {
                    model.ProductClassID = int.Parse(ds.Tables[0].Rows[0]["ProductClassID"].ToString());
                }
                model.ProductClass = ds.Tables[0].Rows[0]["ProductClass"].ToString();
                model.pCode = ds.Tables[0].Rows[0]["pCode"].ToString();
                model.pBarcode = ds.Tables[0].Rows[0]["pBarcode"].ToString();
                model.pName = ds.Tables[0].Rows[0]["pName"].ToString();
                model.pBrand = ds.Tables[0].Rows[0]["pBrand"].ToString();
                model.pStandard = ds.Tables[0].Rows[0]["pStandard"].ToString();
                model.pUnits = ds.Tables[0].Rows[0]["pUnits"].ToString();
                model.pMaxUnits = ds.Tables[0].Rows[0]["pMaxUnits"].ToString();
                model.pProducer = ds.Tables[0].Rows[0]["pProducer"].ToString();
                model.pExpireDay = ds.Tables[0].Rows[0]["pExpireDay"].ToString();
                model.pAddress = ds.Tables[0].Rows[0]["pAddress"].ToString();

                model.pEnName = ds.Tables[0].Rows[0]["pEnName"].ToString();
                if (ds.Tables[0].Rows[0]["pToBoxNo"].ToString() != "")
                {
                    model.pToBoxNo = int.Parse(ds.Tables[0].Rows[0]["pToBoxNo"].ToString());
                }
                if (ds.Tables[0].Rows[0]["pState"].ToString() != "")
                {
                    model.pState = int.Parse(ds.Tables[0].Rows[0]["pState"].ToString());
                }
                if (ds.Tables[0].Rows[0]["pAppendTime"].ToString() != "")
                {
                    model.pAppendTime = DateTime.Parse(ds.Tables[0].Rows[0]["pAppendTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["pPrice"].ToString() != "")
                {
                    model.pPrice = decimal.Parse(ds.Tables[0].Rows[0]["pPrice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["pDoDayQuantity"].ToString() != "")
                {
                    model.pDoDayQuantity = decimal.Parse(ds.Tables[0].Rows[0]["pDoDayQuantity"].ToString());
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
        public ProductsInfo GetProductsInfoModelByBarcode(string pBarcode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ProductsID,pCode,pBarcode,pName,pEnName,pBrand,pStandard,pUnits,pMaxUnits,pToBoxNo,pState,pAppendTime,pPrice,pDoDayQuantity,ProductClassID,(select tbProductClassInfo.pClassName from tbProductClassInfo where tbProductClassInfo.ProductClassID=tbProductsInfo.ProductClassID) as ProductClass,pProducer,pExpireDay,pAddress from tbProductsInfo ");
            strSql.Append(" where pBarcode=@pBarcode ");
            SqlParameter[] parameters = {
					new SqlParameter("@pBarcode", SqlDbType.VarChar,50)};
            parameters[0].Value = pBarcode;

            ProductsInfo model = new ProductsInfo();
            DataSet ds = DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ProductsID"].ToString() != "")
                {
                    model.ProductsID = int.Parse(ds.Tables[0].Rows[0]["ProductsID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ProductClassID"].ToString() != "")
                {
                    model.ProductClassID = int.Parse(ds.Tables[0].Rows[0]["ProductClassID"].ToString());
                }
                model.ProductClass = ds.Tables[0].Rows[0]["ProductClass"].ToString();
                model.pCode = ds.Tables[0].Rows[0]["pCode"].ToString();
                model.pBarcode = ds.Tables[0].Rows[0]["pBarcode"].ToString();
                model.pName = ds.Tables[0].Rows[0]["pName"].ToString();
                model.pBrand = ds.Tables[0].Rows[0]["pBrand"].ToString();
                model.pStandard = ds.Tables[0].Rows[0]["pStandard"].ToString();
                model.pUnits = ds.Tables[0].Rows[0]["pUnits"].ToString();
                model.pMaxUnits = ds.Tables[0].Rows[0]["pMaxUnits"].ToString();
                model.pProducer = ds.Tables[0].Rows[0]["pProducer"].ToString();
                model.pExpireDay = ds.Tables[0].Rows[0]["pExpireDay"].ToString();
                model.pAddress = ds.Tables[0].Rows[0]["pAddress"].ToString();

                model.pEnName = ds.Tables[0].Rows[0]["pEnName"].ToString();
                if (ds.Tables[0].Rows[0]["pToBoxNo"].ToString() != "")
                {
                    model.pToBoxNo = int.Parse(ds.Tables[0].Rows[0]["pToBoxNo"].ToString());
                }
                if (ds.Tables[0].Rows[0]["pState"].ToString() != "")
                {
                    model.pState = int.Parse(ds.Tables[0].Rows[0]["pState"].ToString());
                }
                if (ds.Tables[0].Rows[0]["pAppendTime"].ToString() != "")
                {
                    model.pAppendTime = DateTime.Parse(ds.Tables[0].Rows[0]["pAppendTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["pPrice"].ToString() != "")
                {
                    model.pPrice = decimal.Parse(ds.Tables[0].Rows[0]["pPrice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["pDoDayQuantity"].ToString() != "")
                {
                    model.pDoDayQuantity = decimal.Parse(ds.Tables[0].Rows[0]["pDoDayQuantity"].ToString());
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
        public DataSet GetProductsInfoListAndQuantity(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("declare @ProductsQuantity Table( "+
	                            "ProductsID	int, "+
	                            "pQuantity numeric(18,6) "+
                            ");"+

                            "insert into @ProductsQuantity(ProductsID,pQuantity) "+ 
                            "select op.ProductsID,(SUM(BStorage)+SUM(pStorage)+SUM(pStorageIn)-SUM(pStorageOut)) as oQ from ( "+
		                            "select ProductsStorageID,StorageID,ProductsID,pStorage,pStorageIn,pStorageOut, "+
		                             "isnull((select pQuantity from tbProductsStorageLogInfo where  pType=-1 and pState=0 and StorageID=tbProductsStorageInfo.StorageID and ProductsID=tbProductsStorageInfo.ProductsID),0) as BStorage from tbProductsStorageInfo where ProductsStorageID in( "+
			                            "select MAX(ProductsStorageID) ProductsStorageID from tbProductsStorageInfo group by StorageID,ProductsID "+
		                             ") "+
	                            ") as op group by op.ProductsID;"+
	
                           

                            "select p.ProductsID,p.pCode,p.pBarcode,p.pName,p.pBrand,p.pStandard,p.pUnits,p.pMaxUnits,p.pToBoxNo,p.pState,p.pAppendTime,p.pPrice,p.pDoDayQuantity,p.ProductClassID,(select tbProductClassInfo.pClassName from tbProductClassInfo where tbProductClassInfo.ProductClassID=p.ProductClassID) as ProductClass,p.pProducer,p.pExpireDay,p.pAddress,pq.pQuantity from tbProductsInfo as p left join @ProductsQuantity as pq on p.ProductsID=pq.ProductsID ");


            //strSql.Append("select ProductsID,pCode,pBarcode,pName,pBrand,pStandard,pUnits,pMaxUnits,pToBoxNo,pState,pAppendTime,pPrice,pDoDayQuantity,ProductClassID,(select tbProductClassInfo.pClassName from tbProductClassInfo where tbProductClassInfo.ProductClassID=tbProductsInfo.ProductClassID) as ProductClass,pProducer,pExpireDay,pAddress ");
            //strSql.Append(" FROM tbProductsInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }

            strSql.Append(";");

            return DbHelper.ExecuteDataset(CommandType.Text,strSql.ToString());
        }


        public DataSet GetProductsInfoList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ProductsID,pCode,pBarcode,pName,pEnName,pBrand,pStandard,pUnits,pMaxUnits,pToBoxNo,pState,pAppendTime,pPrice,pDoDayQuantity,ProductClassID,(select tbProductClassInfo.pClassName from tbProductClassInfo where tbProductClassInfo.ProductClassID=tbProductsInfo.ProductClassID) as ProductClass,pProducer,pExpireDay,pAddress ");
            strSql.Append(" FROM tbProductsInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }

            return DbHelper.ExecuteDataset(CommandType.Text,strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetProductsBrandList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM viProductBrand ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString());
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataTable GetProductsInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
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
            parameters[0].Value = "tbProductsInfo";
            parameters[1].Value = "ProductsID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 1;
            parameters[5].Value = OrderType;
            parameters[6].Value = strWhere;
            parameters[7].Value = showFName + ",(select isnull(sum(tbProductsStorageLogInfo.pQuantity),0) from tbProductsStorageLogInfo  where tbProductsStorageLogInfo.pType=-1 and tbProductsStorageLogInfo.ProductsID=tbProductsInfo.ProductsID and tbProductsStorageLogInfo.pState=0) Beginning";
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
        /// 获得数据列表
        /// </summary>
        public DataSet GetProductsList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *,(select pClassName from tbProductClassInfo where ProductClassID=tbProductsInfo.ProductClassID) as pClassName from tbProductsInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString());
        }
        #endregion

        #region productsGraphManage
        /// <summary>
        /// 返回购销或联营销售月数据及月每天数据百分比
        /// </summary>
        /// <param name="GraphType">统计类型</param>
        /// <param name="SalesType">销售类型</param>
        /// <param name="dt">日期</param>
        /// <returns></returns>
        public DataTable getProductsSaleDetails(int GraphType, int SalesType, DateTime dt,string regionID,int sType)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@inyGraphType", SqlDbType.Int),
                    new SqlParameter("@inySalesType", SqlDbType.Int),
                    new SqlParameter("@dtmDateTime", SqlDbType.DateTime),
                    new SqlParameter("@inyRegionID", SqlDbType.VarChar),
                    new SqlParameter("@inyStype", SqlDbType.Int),
                    };
            parameters[0].Value = GraphType;
            parameters[1].Value = SalesType;
            parameters[2].Value = dt;
            parameters[3].Value = regionID;
            parameters[4].Value = sType;

            return DbHelper.ExecuteDataset(CommandType.StoredProcedure, "sp_" + BaseConfigs.GetTablePrefix + "Products_Graph_Details", parameters).Tables[0];
        }

		/// <summary>
		/// Checks the products by order.
		/// </summary>
		/// <returns><c>true</c>, if products by order was checked, <c>false</c> otherwise.</returns>
		/// <param name="ProductsID">Products I.</param>
		public bool CheckProductsByOrder(int ProductsID){
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select count(0) from tbOrderListInfo where ProductsID=@ProductsID and oWorkType<>0");

			SqlParameter[] parameters = {
				new SqlParameter("@ProductsID", SqlDbType.Int,4)};
			parameters[0].Value = ProductsID;

			return ((int)DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters)) > 0;
		}
        #endregion
    }
}
