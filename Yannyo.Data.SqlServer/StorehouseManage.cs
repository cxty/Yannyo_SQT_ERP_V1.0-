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
        #region ScodeDataBindList
        /// <summary>
        /// 获得门店名称
        /// </summary>
        /// <returns></returns>
        public DataTable SnameBindDropdownlist()
        {
            StringBuilder tb = new StringBuilder();
            tb.Append("select distinct(sName) from tbStoresInfo");
            return DbHelper.ExecuteDataset(CommandType.Text, tb.ToString()).Tables[0];
        }
        /// <summary>
        /// 获得返回int，根据门店名称找到门店ID
        /// </summary>
        /// <param name="sName"></param>
        /// <returns></returns>
        public int GetStorageIDBySname(string sName)
        {
            StringBuilder tb = new StringBuilder();
            tb.Append("select StoresID from tbStoresInfo where sName='"+sName+"'");
            int state =Convert.ToInt32(DbHelper.ExecuteScalar(CommandType.Text, tb.ToString()));
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
        /// 根据营业员信息获得门店信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetStorageName(string rName,string StaffName)
        {
           
            StringBuilder tb = new StringBuilder();
            tb.Append("select sName from tbStoresInfo  where StoresID in (select StoresID from tbStaffStoresInfo where");
            tb.Append(" (RegionID in(select RegionID from tbRegionInfo where rName='"+rName+"')) and");
            tb.Append("  ( StaffID in(select StaffID from tbStaffInfo where sType=1 and sName ='"+StaffName+"' )))");
            return DbHelper.ExecuteDataset(CommandType.Text, tb.ToString()).Tables[0];
         
        }
        /// <summary>
        /// 根据营业员名称获得营业员ID
        /// </summary>
        /// <param name="StaffName"></param>
        /// <returns></returns>
        public int getStaffIDByName(string StaffName)
        {
            StringBuilder tb = new StringBuilder();
            tb.Append("select StaffID from tbStaffInfo where sName='" + StaffName + "'");
            int state= Convert.ToInt32(DbHelper.ExecuteScalar(CommandType.Text, tb.ToString()));
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
        /// 根据门店名称获得门店ID
        /// </summary>
        /// <param name="sName"></param>
        /// <returns></returns>
        public int getStorageIDByName(string sName) 
        {
            StringBuilder tb = new StringBuilder();
            tb.Append("select StoresID from tbStoresInfo where sName='" + sName + "'");
            int state = Convert.ToInt32(DbHelper.ExecuteScalar(CommandType.Text, tb.ToString()));
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
        /// 根据区域选择获得营业员信息
        /// </summary>
        /// <param name="RegionName"></param>
        /// <returns></returns>
        public DataTable StaffNameByRegionName(string RegionName)
        {
            StringBuilder tb = new StringBuilder();

           tb.Append(" select sName from tbStaffInfo where sType=1 and  StaffID ");
           tb.Append(" in (select StaffID from tbStaffStoresInfo where StoresID  ");
           tb.Append(" in (select StoresID from tbStoresInfo where RegionID  ");
           tb.Append(" in (select RegionID from tbRegionInfo where rName='" + RegionName + "')))");
            return DbHelper.ExecuteDataset(CommandType.Text, tb.ToString()).Tables[0];
        }
        /// <summary>
        /// 获得地区信息名称
        /// </summary>
        /// <returns></returns>
        public DataTable RegionName()
        {
            StringBuilder tb = new StringBuilder();
            tb.Append("select RegionID,rName from tbRegionInfo where RegionID in (select RegionID from tbStoresInfo)");
            return DbHelper.ExecuteDataset(CommandType.Text, tb.ToString()).Tables[0];
        }
        /// <summary>
        /// 根据地区名称得到地区ID
        /// </summary>
        /// <param name="RegionName"></param>
        /// <returns></returns>
        public int GetRegionIDByName(string RegionName) 
        {
            StringBuilder tb = new StringBuilder();
            tb.Append("select RegionID from tbRegionInfo where rName='" + RegionName + "'");
            int state = Convert.ToInt32(DbHelper.ExecuteScalar(CommandType.Text, tb.ToString()));
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
        /// 获得门店编号根据门店名称
        /// </summary>
        /// <returns></returns>
        public String SelectScodeBySname(string name)
        {
            StringBuilder tb = new StringBuilder();
            tb.Append("select StoresID from tbStoresInfo where sName='" + name + "'");
   
            DataTable state=DbHelper.ExecuteDataset(CommandType.Text, tb.ToString()).Tables[0];
            if (state.Rows.Count>0)
            {
                return DbHelper.ExecuteScalar(CommandType.Text, tb.ToString()).ToString();
            }
            else
            {
                return null;
            }
     
        }
        /// <summary>
        /// 获得产品编号根据门店名称
        /// </summary>
        /// <returns></returns>
        public String SelectPcodeBySname(string name)
        {
            StringBuilder tb = new StringBuilder();
            tb.Append("select ProductsID from tbStoreStorehouseInfo where sName='" + name + "'");
            try
            {
                return DbHelper.ExecuteScalar(CommandType.Text, tb.ToString()).ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        /// <summary>
        /// 获得产品编号根据产品名称
        /// </summary>
        /// <returns></returns>
        public String SelectPcodeByName(string name)
        {
            StringBuilder tb = new StringBuilder();
            tb.Append("select ProductsID from tbProductsInfo where pName='" + name + "'");
            try
            {
                return DbHelper.ExecuteScalar(CommandType.Text, tb.ToString()).ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public String SelectPcodeByPName(string[] name)
        {
            StringBuilder tb = new StringBuilder();
            tb.Append("select ProductsID from tbProductsInfo where pName='" + name + "'");
            try
            {
                return DbHelper.ExecuteScalar(CommandType.Text, tb.ToString()).ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        /// <summary>
        /// 获得产品编号根据产品条码
        /// </summary>
        /// <returns></returns>
        public String SelectpBarcodeByName(string name)
        {
            StringBuilder tb = new StringBuilder();
            tb.Append("select ProductsID from tbProductsInfo where pBarcode='" + name + "'");
            try
            {
                return DbHelper.ExecuteScalar(CommandType.Text, tb.ToString()).ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        /// <summary>
        /// 增加门店仓库数据
        /// </summary>
        /// <returns></returns>
        public int AddStorehouseStorageInfo(StorehouseStoreInfo storehouseStorage)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tbStoreStorehouseInfo(");
            strSql.Append("sCode,sName,StoresID,stCode,stName,ProductsID,pCode,pBarcode,pName,pBrand,pStandard,pRelityStorage,pAppendTime,pUpdateTime,pMoney)");
            strSql.Append(" values (");
            strSql.Append("@chvSCode,@chvSName,@inyStoresID,@chvStCode,@chvStName,@inyProductsID,@chvproCode,@inypBarcode,@chvPName,@chvPBrand,@chvPStandard,@inyStorage,@dtmDateTime,GETDATE(),@meyPMoney)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@chvSCode",SqlDbType.VarChar,50),
					new SqlParameter("@chvSName",SqlDbType.VarChar,128),
                    new SqlParameter("@inyStoresID",SqlDbType.Int),
                    new SqlParameter("@chvStCode",SqlDbType.VarChar,50),
                    new SqlParameter("@chvStName",SqlDbType.VarChar,128),
					new SqlParameter("@inyProductsID",SqlDbType.Int),
                    new SqlParameter("@chvproCode",SqlDbType.VarChar,50),
                    new SqlParameter("@inypBarcode",SqlDbType.VarChar,50),
					new SqlParameter("@chvPName",SqlDbType.VarChar,128),
					new SqlParameter("@chvPBrand", SqlDbType.VarChar,128),
					new SqlParameter("@chvPStandard", SqlDbType.VarChar, 50),
                    new SqlParameter("@inyStorage", SqlDbType.Int),
                    new SqlParameter("@dtmDateTime",SqlDbType.DateTime),
                    new SqlParameter("@meyPMoney",SqlDbType.Money),
                                        };

            parameters[0].Value = storehouseStorage.SCode;
            parameters[1].Value = storehouseStorage.SName;
            parameters[2].Value = storehouseStorage.StoresID;
            parameters[3].Value = storehouseStorage.StCode;
            parameters[4].Value = storehouseStorage.StName;
            parameters[5].Value = storehouseStorage.ProductsID;
            parameters[6].Value = storehouseStorage.ProCode;
            parameters[7].Value = storehouseStorage.PBarcode;
            parameters[8].Value = storehouseStorage.PName;
            parameters[9].Value = storehouseStorage.PBrand;
            parameters[10].Value = storehouseStorage.PStandard;
            parameters[11].Value = storehouseStorage.PNum;
            parameters[12].Value = storehouseStorage.PAppendTime;
            parameters[13].Value = storehouseStorage.PMoney;

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
        /// 导入门店库存书库副本
        /// </summary>
        /// <param name="storehouseStorage"></param>
        /// <returns></returns>
        public int AddStorehouseStorageInfo_calculate(StorehouseStoreInfo storehouseStorage)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tbStoreStorehouseInfo_calculate(");
            strSql.Append("sCode,sName,StoresID,stCode,stName,ProductsID,pCode,pBarcode,pName,pBrand,pStandard,pRelityStorage,pAppendTime,pUpdateTime,pMoney)");
            strSql.Append(" values (");
            strSql.Append("@chvSCode,@chvSName,@inyStoresID,@chvStCode,@chvStName,@inyProductsID,@chvproCode,@inypBarcode,@chvPName,@chvPBrand,@chvPStandard,@inyStorage,@dtmDateTime,GETDATE(),@meyPMoney)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@chvSCode",SqlDbType.VarChar,50),
					new SqlParameter("@chvSName",SqlDbType.VarChar,128),
                    new SqlParameter("@inyStoresID",SqlDbType.Int),
                    new SqlParameter("@chvStCode",SqlDbType.VarChar,50),
                    new SqlParameter("@chvStName",SqlDbType.VarChar,128),
					new SqlParameter("@inyProductsID",SqlDbType.Int),
                    new SqlParameter("@chvproCode",SqlDbType.VarChar,50),
                    new SqlParameter("@inypBarcode",SqlDbType.VarChar,50),
					new SqlParameter("@chvPName",SqlDbType.VarChar,128),
					new SqlParameter("@chvPBrand", SqlDbType.VarChar,128),
					new SqlParameter("@chvPStandard", SqlDbType.VarChar, 50),
                    new SqlParameter("@inyStorage", SqlDbType.Int),
                    new SqlParameter("@dtmDateTime",SqlDbType.DateTime),
                    new SqlParameter("@meyPMoney",SqlDbType.Money),
                                        };

            parameters[0].Value = storehouseStorage.SCode;
            parameters[1].Value = storehouseStorage.SName;
            parameters[2].Value = storehouseStorage.StoresID;
            parameters[3].Value = storehouseStorage.StCode;
            parameters[4].Value = storehouseStorage.StName;
            parameters[5].Value = storehouseStorage.ProductsID;
            parameters[6].Value = storehouseStorage.ProCode;
            parameters[7].Value = storehouseStorage.PBarcode;
            parameters[8].Value = storehouseStorage.PName;
            parameters[9].Value = storehouseStorage.PBrand;
            parameters[10].Value = storehouseStorage.PStandard;
            parameters[11].Value = storehouseStorage.PNum;
            parameters[12].Value = storehouseStorage.PAppendTime;
            parameters[13].Value = storehouseStorage.PMoney;

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
        /// 更新数据
        /// </summary>
        /// <returns></returns>
        public int UpdateStorehouseStorageInfo(StorehouseStoreInfo storehouseStorage)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbStoreStorehouseInfo set ");
            strSql.Append("pRelityStorage=@inypRelityStorage,");
            strSql.Append("pMoney=@pMoney");
            strSql.Append(" where productStorageID=@chvproductStorageID");
           
            SqlParameter[] parameters = {
                    new SqlParameter("@inypRelityStorage", SqlDbType.Int),
                    new SqlParameter("@pMoney", SqlDbType.Money),
                    new SqlParameter("@chvproductStorageID", SqlDbType.Int),
                                        };

            parameters[0].Value = storehouseStorage.PNum;
            parameters[1].Value = storehouseStorage.PMoney;
            parameters[2].Value = storehouseStorage.ProductStorageID;
           int state= DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
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
        /// 更新门店库存副本
        /// </summary>
        /// <param name="storehouseStorage"></param>
        /// <returns></returns>
        public int UpdateStorehouseStorageInfo_calculate(StorehouseStoreInfo storehouseStorage)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbStoreStorehouseInfo_calculate set ");
            strSql.Append("pRelityStorage=@inypRelityStorage,");
            strSql.Append("pMoney=@pMoney");
            strSql.Append(" where productStorageID=@chvproductStorageID");

            SqlParameter[] parameters = {
                    new SqlParameter("@inypRelityStorage", SqlDbType.Int),
                    new SqlParameter("@pMoney", SqlDbType.Money),
                    new SqlParameter("@chvproductStorageID", SqlDbType.Int),
                                        };

            parameters[0].Value = storehouseStorage.PNum;
            parameters[1].Value = storehouseStorage.PMoney;
            parameters[2].Value = storehouseStorage.ProductStorageID;
            int state = DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
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
        /// 获得数据列表
        /// </summary>
        public DataSet GetStorehouseInfoLists(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select sName,stName,ProductsID,pName,pRelityStorage,pAppendTime,pUpdateTime from tbStoreStorehouseInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString());
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataTable GetStorehouseInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
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
            parameters[0].Value = "tbStoreStorehouseInfo";
            parameters[1].Value = "productStorageID";
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
        /// 删除一条数据
        /// </summary>
        public void DeleteStorhouseStorageInfo(int ProductID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbStoreStorehouseInfo ");
            strSql.Append(" where ProductsID=@ProductsID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ProductsID", SqlDbType.Int,4)};
            parameters[0].Value = ProductID;

            DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一组数据
        /// </summary>
        public void DeleteStoragesInfo(string ProductID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbStoreStorehouseInfo ");
            strSql.Append(" where productStorageID in(" + ProductID + ") ");
            DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString());
        }
        /// <summary>
        /// 取日期、产品编号、产品名称、门店编号、仓库编号匹配数据
        /// </summary>
        /// <returns></returns>
        public bool GetDateTimeDataStorehouseInfoList(DateTime strDate, int sCode,string stNum,int pCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(0) ");
            strSql.Append(" from tbStoreStorehouseInfo where pAppendTime='" + strDate + "'and StoresID='" + sCode + "' and stCode='" + stNum + "' and ProductsID='" + pCode + "'");

            int state=Int32.Parse(DbHelper.ExecuteScalarToStr(CommandType.Text, strSql.ToString()));
            if(state >0)
            {
             return true;
            }
            else
            {
             return false;
            }
            
        }
        /// <summary>
        /// 导入门店重复数据判断
        /// </summary>
        /// <param name="StoresID"></param>
        /// <param name="StCode"></param>
        /// <param name="ProductsID"></param>
        /// <param name="ProductsName"></param>
        /// <param name="ProductsBarcode"></param>
        /// <param name="pPrice"></param>
        /// <param name="pAppendTime"></param>
        /// <returns></returns>
        public bool GetDateTimeDataStorehouse(int StoresID, string StCode, int ProductsID, string ProductsName, string ProductsBarcode, string pNum, DateTime pAppendTime)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(0) ");
            strSql.Append(" from tbStoreStorehouseInfo where StoresID='" + StoresID + "'and StCode='" + StCode + "'and ProductsID='" + ProductsID + "' and pName='" + ProductsName + "' and pBarcode='" + ProductsBarcode + "' and pRelityStorage='" + pNum + "'  and pAppendTime='" + pAppendTime + "'");

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
        ///<summary>
        /// 根据门店编号，获得门店名称
        ///<summary>
        public DataTable GetScodeBySname(string sname)
        {
            StringBuilder str = new StringBuilder();
            str.Append("select  StoresID  from tbStoresInfo where sName='" + sname + "'");
            return DbHelper.ExecuteDataset(CommandType.Text, str.ToString()).Tables[0];
        }
        public String GetScode(string sname)
        {
            StringBuilder str = new StringBuilder();
            str.Append("select sCode from tbStoresInfo where sName='" + sname + "'");
            try
            {
                return DbHelper.ExecuteScalar(CommandType.Text, str.ToString()).ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
      

        }

        /// <summary>
        /// 门店仓库进销存报表
        /// </summary>
        /// <param name="ProductsID"></param>
        /// <param name="StorageID"></param>
        /// <param name="sDate">选择的时间点</param>
        /// <param name="ReType">返回类型,月表=1,年表=2</param>
        /// <returns></returns>
        public DataTable GetStorehouseStorageReport(int regionID, int storageID, int staffID, DateTime bTime, DateTime eTime, int reType, int associated)
            {
                SqlParameter[] parameters = {
                            new SqlParameter("@inyRegionID", SqlDbType.Int),
                            new SqlParameter("@inyStorageID", SqlDbType.Int),
                            new SqlParameter("@chvStaffID", SqlDbType.Int),
                            new SqlParameter("@dtmbAppendTime", SqlDbType.DateTime),
                            new SqlParameter("@dtmeAppendTime", SqlDbType.DateTime),
                            new SqlParameter("@reType", SqlDbType.Int),
                            new SqlParameter("@associated",SqlDbType.Int),
                                            };
                parameters[0].Value = regionID;
                parameters[1].Value = storageID;
                parameters[2].Value = staffID;
                parameters[3].Value = bTime;
                parameters[4].Value = eTime;
                parameters[5].Value = reType;
                parameters[6].Value = associated;

                DataTable dt = DbHelper.ExecuteDataset(CommandType.StoredProcedure, "sp_" + BaseConfigs.GetTablePrefix + "ReportOfStorehouseStorage", parameters).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    return dt;
                }
                else
                {
                    return null;  
                }
        }

        //进货=3
        public String GetInQuantity(string ProductsID)
        {
            StringBuilder str = new StringBuilder();
            str.Append("select oli.oQuantity from tbOrderListInfo as oli left join tbOrderInfo as oi on oli.OrderID=oi.OrderID");
            str.Append(" where oi.oType=3 and ProductsID='"+ProductsID+"'");
            DataTable dt = DbHelper.ExecuteDataset(CommandType.Text, str.ToString()).Tables[0];
            if (dt.Rows.Count > 0)
            {
                return DbHelper.ExecuteScalar(CommandType.Text, str.ToString()).ToString();
            }
            else
            {
                return null;
            }

        }
        //退货=4
        public String OutQuantity(string ProductsID)
        {
            StringBuilder str = new StringBuilder();
            str.Append("select oli.oQuantity from tbOrderListInfo as oli left join tbOrderInfo as oi on oli.OrderID=oi.OrderID");
            str.Append(" where oi.oType=4 and ProductsID='" + ProductsID + "'");
            DataTable dt = DbHelper.ExecuteDataset(CommandType.Text, str.ToString()).Tables[0];
            if (dt.Rows.Count > 0)
            {
                return DbHelper.ExecuteScalar(CommandType.Text, str.ToString()).ToString();
            }
            else
            {
                return null;
            }

        }
        
        public int[] StorehouseStorageSyn()
        {
            int[] ReCount = { 0, 0, 0 };
            DataSet ds = DbHelper.ExecuteDataset(CommandType.StoredProcedure, "sp_" + BaseConfigs.GetTablePrefix + "StorehouseStorageSynInfo");
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
        /// 得到一个对象实体
        /// </summary>
        public StorehouseStoreInfo GetStorehouseProductsInfoModel(int ProductID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 StoresID,sCode,sName,StCode,stName,ProductsID,pCode,pBarcode,pName,pBrand,pStandard,pRelityStorage,pAppendTime,pMoney from tbStoreStorehouseInfo  ");
            strSql.Append(" where productStorageID=@productStorageID ");
            SqlParameter[] parameters = {
					new SqlParameter("@productStorageID", SqlDbType.Int,4)};
            parameters[0].Value = ProductID;

            StorehouseStoreInfo model = new StorehouseStoreInfo();
            DataSet ds = DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["StoresID"].ToString() != "")
                {
                    model.StoresID = int.Parse(ds.Tables[0].Rows[0]["StoresID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["sCode"].ToString() != "")
                {
                    model.SCode = ds.Tables[0].Rows[0]["sCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["sName"].ToString() != "")
                {
                    model.SName = ds.Tables[0].Rows[0]["sName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["StCode"].ToString() != "")
                {
                    model.StCode = ds.Tables[0].Rows[0]["StCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["stName"].ToString() != "")
                {
                    model.StName = ds.Tables[0].Rows[0]["stName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ProductsID"].ToString() != "")
                {
                    model.ProductsID = Int32.Parse(ds.Tables[0].Rows[0]["ProductsID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["pCode"].ToString() != "")
                {
                    model.ProCode = ds.Tables[0].Rows[0]["pCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["pBarcode"].ToString() != "")
                {
                    model.PBarcode = ds.Tables[0].Rows[0]["pBarcode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["pName"].ToString() != "")
                {
                    model.PName = ds.Tables[0].Rows[0]["pName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["pBrand"].ToString() != "")
                {
                    model.PBrand = ds.Tables[0].Rows[0]["pBrand"].ToString();
                }
                if (ds.Tables[0].Rows[0]["pStandard"].ToString() != "")
                {
                    model.PStandard = ds.Tables[0].Rows[0]["pStandard"].ToString();
                }
                if (ds.Tables[0].Rows[0]["pRelityStorage"].ToString() != "")
                {
                    model.PNum = Int32.Parse(ds.Tables[0].Rows[0]["pRelityStorage"].ToString());
                }
                if (ds.Tables[0].Rows[0]["pAppendTime"].ToString() != "")
                {
                    model.PAppendTime = DateTime.Parse(ds.Tables[0].Rows[0]["pAppendTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["pMoney"].ToString() != "")
                {
                    model.PMoney =ds.Tables[0].Rows[0]["pMoney"].ToString();
                }
                return model;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 实体副本
        /// </summary>
        /// <param name="ProductID"></param>
        /// <returns></returns>
        public StorehouseStoreInfo GetStorehouseProductsInfoModel_calculate(int ProductID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 StoresID,sCode,sName,StCode,stName,ProductsID,pCode,pBarcode,pName,pBrand,pStandard,pRelityStorage,pAppendTime,pMoney from tbStoreStorehouseInfo_calculate  ");
            strSql.Append(" where productStorageID=@productStorageID ");
            SqlParameter[] parameters = {
					new SqlParameter("@productStorageID", SqlDbType.Int,4)};
            parameters[0].Value = ProductID;

            StorehouseStoreInfo model = new StorehouseStoreInfo();
            DataSet ds = DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["StoresID"].ToString() != "")
                {
                    model.StoresID = int.Parse(ds.Tables[0].Rows[0]["StoresID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["sCode"].ToString() != "")
                {
                    model.SCode = ds.Tables[0].Rows[0]["sCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["sName"].ToString() != "")
                {
                    model.SName = ds.Tables[0].Rows[0]["sName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["StCode"].ToString() != "")
                {
                    model.StCode = ds.Tables[0].Rows[0]["StCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["stName"].ToString() != "")
                {
                    model.StName = ds.Tables[0].Rows[0]["stName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ProductsID"].ToString() != "")
                {
                    model.ProductsID = Int32.Parse(ds.Tables[0].Rows[0]["ProductsID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["pCode"].ToString() != "")
                {
                    model.ProCode = ds.Tables[0].Rows[0]["pCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["pBarcode"].ToString() != "")
                {
                    model.PBarcode = ds.Tables[0].Rows[0]["pBarcode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["pName"].ToString() != "")
                {
                    model.PName = ds.Tables[0].Rows[0]["pName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["pBrand"].ToString() != "")
                {
                    model.PBrand = ds.Tables[0].Rows[0]["pBrand"].ToString();
                }
                if (ds.Tables[0].Rows[0]["pStandard"].ToString() != "")
                {
                    model.PStandard = ds.Tables[0].Rows[0]["pStandard"].ToString();
                }
                if (ds.Tables[0].Rows[0]["pRelityStorage"].ToString() != "")
                {
                    model.PNum = Int32.Parse(ds.Tables[0].Rows[0]["pRelityStorage"].ToString());
                }
                if (ds.Tables[0].Rows[0]["pAppendTime"].ToString() != "")
                {
                    model.PAppendTime = DateTime.Parse(ds.Tables[0].Rows[0]["pAppendTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["pMoney"].ToString() != "")
                {
                    model.PMoney = ds.Tables[0].Rows[0]["pMoney"].ToString();
                }
                return model;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 查询客户库存导入详情
        /// </summary>
        /// <param name="sId"></param>
        /// <param name="bDate"></param>
        /// <param name="eDate"></param>
        /// <returns></returns>
        public DataTable SelectStorageData(int sId,DateTime bDate,DateTime eDate)
        {
            StringBuilder bt=new StringBuilder();
            if(sId>0)
            {
                bt.Append("select pBarcode,pName,pRelityStorage,pMoney,pAppendTime,pUpdateTime from tbStoreStorehouseInfo where (pAppendTime between '" + bDate + "' and '" + eDate + "' )and StoresID='" + sId + "'");
                return DbHelper.ExecuteDataset(CommandType.Text, bt.ToString()).Tables[0];
            }
            else
            {
                bt.Append("select pBarcode,pName,pRelityStorage,pMoney,pAppendTime,pUpdateTime from tbStoreStorehouseInfo where (pAppendTime between '" + bDate + "' and '" + eDate + "' )");
                return DbHelper.ExecuteDataset(CommandType.Text, bt.ToString()).Tables[0];
            }
        }
        #endregion
        #region JsonList
        public bool AddStorehouseStorageData(StorehouseStorageJsonInfo storehouseStorage)
        {
            StringBuilder strSql = new StringBuilder();

            if(storehouseStorage.StorehouseStorageJson!=null)
            {
                if(storehouseStorage.StorehouseStorageJson.StoreHouseStorage!=null)
                {
                    string sName = storehouseStorage.SName;
                    int sToresId = storehouseStorage.StoresID;
                    //string pBarcode = storehouseStorage.PBarcode;  
                    //string pName = storehouseStorage.PName;
                    DateTime pAppendTime = storehouseStorage.PAppendTime;
                    string sCode = storehouseStorage.SCode;
                   
                    try
                    {
                        int pId = 0;
                        decimal pNum = 0;
                        foreach (StoreHouseStorage shs in storehouseStorage.StorehouseStorageJson.StoreHouseStorage)
                        {
                            pId = shs.pid;
                            pNum = shs.pnum;
                            strSql.Append("insert into tbStoreStorehouseInfo(");
                            strSql.Append("sName,sCode,StoresID,stCode,stName,ProductsID,pBarcode,pName,pRelityStorage,pAppendTime,pUpdateTime)");
                            strSql.Append(" select '" + sName + "','" + sCode + "','" + sToresId + "','默认值','默认值',ProductsID,pBarcode,pName," + pNum + ",'" + pAppendTime + "',GETDATE() from tbProductsInfo where ProductsID=" + pId + ";");
                          
                        }
                        DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString());
                        return true;
                    }
                    catch
                    {
                        return false;
                    }
                }
       
                else
                {
                   return false;  
                }
                
            }
            else
            {
                return false;
            }
           
        }
        /// <summary>
        /// 产品表单提交验证信息
        /// </summary>
        /// <param name="strDate"></param>
        /// <param name="sCode"></param>
        /// <param name="stNum"></param>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public bool GetDateTimeDataStorehouseInfoLists(DateTime strDate, int sCode, string stNum, StorehouseStorageJsonInfo ssji)
        {
            StringBuilder strSql = new StringBuilder();
            if (ssji.StorehouseStorageJson != null)
            {
                if (ssji.StorehouseStorageJson.StoreHouseStorage != null)
                {
                    int pId = 0;
                    try
                    {
                        foreach (StoreHouseStorage shs in ssji.StorehouseStorageJson.StoreHouseStorage)
                        {
                            pId=shs.pid;
                            strSql.Append("select count(0) ");
                            strSql.Append(" from tbStoreStorehouseInfo where pAppendTime='" + strDate + "'and StoresID='" + sCode + "' and stCode='" + stNum + "' and ProductsID='" + pId + "'");
                        }
                        int state=Int32.Parse(DbHelper.ExecuteScalarToStr(CommandType.Text, strSql.ToString()));
                        if (state>0)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    catch
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        #endregion
        #region 单品选择地区详情
        public DataTable getProductsOfRegionDetails(int regionID, int productID, DateTime bDate, DateTime eDate)
        {
            SqlParameter[] parameters = {
                            new SqlParameter("@inyRegionID", SqlDbType.VarChar,50),
                            new SqlParameter("@inyProductsID", SqlDbType.Int),
                            new SqlParameter("@dtmbDate", SqlDbType.DateTime),
                            new SqlParameter("@dtmeDate", SqlDbType.DateTime),
                                            };
            parameters[0].Value = regionID;
            parameters[1].Value = productID;
            parameters[2].Value = bDate;
            parameters[3].Value = eDate;

            return DbHelper.ExecuteDataset(CommandType.StoredProcedure, "sp_" + BaseConfigs.GetTablePrefix + "ProductsRegionDetailes", parameters).Tables[0];

          
           
        }
        #endregion

        #region 店员门店报表查询
        /// <summary>
        /// 获得营业员名称
        /// </summary>
        /// <returns></returns>
        public DataTable getStaffName()
        {
            StringBuilder btr = new StringBuilder();
            btr.Append("select StaffID,sName from tbStaffInfo where sType=1");
            return DbHelper.ExecuteDataset(CommandType.Text,btr.ToString()).Tables[0];
        }
        /// <summary>
        /// 根据营业员名称获得对应门店名称
        /// </summary>
        /// <param name="staffName"></param>
        /// <returns></returns>
        public DataTable getStorehouseNameByStaffName(string staffName)
        {
            StringBuilder btr = new StringBuilder();
            btr.Append("select StoresID,sName from tbStoresInfo where StoresID in(select StoresID from tbStaffStoresInfo where sType=0 and StaffID in(");
            btr.Append(" select StaffID from tbStaffInfo where sName='"+staffName+"'))");
            return DbHelper.ExecuteDataset(CommandType.Text, btr.ToString()).Tables[0];
        }
        /// <summary>
        /// 根据营业员名称获得对应门店名称
        /// </summary>
        /// <param name="staffName"></param>
        /// <returns></returns>
        public DataTable getStorehouseNameByNameList(string staffName)
        {
            StringBuilder btr = new StringBuilder();
            btr.Append("select sName from tbStoresInfo where StoresID in(select StoresID from tbStaffStoresInfo where sType=0 and StaffID in(");
            btr.Append(" select StaffID from tbStaffInfo where sName='" + staffName + "'))");
            return DbHelper.ExecuteDataset(CommandType.Text, btr.ToString()).Tables[0];
        }
        /// <summary>
        /// 获得每个门店，每年，每月的销售数量及销售金额
        /// </summary>
        /// <param name="dtYear"></param>
        /// <param name="storesID"></param>
        /// <returns></returns>
        public DataTable getProductsDetaisMonth(string dtYear,int storesID)
        {
            //StringBuilder btr = new StringBuilder();
            //btr.Append(" select DATEPART(YEAR,sDateTime) as sYear,DATEPART(MONTH,sDateTime) as sMonth,isnull(sum(sNum),0) as sNum,isnull(sum(sNum*sPrice),0) as sPrice from tbSalesInfo");
            //btr.Append(" where  StoresID = '" + storesID + "'");
            //btr.Append(" group by DATEPART(YEAR,sDateTime),DATEPART(MONTH,sDateTime) having DATEPART(YEAR,sDateTime)='"+dtYear+"'");

            //return DbHelper.ExecuteDataset(CommandType.Text,btr.ToString()).Tables[0];
            SqlParameter[] parameters = {
                    new SqlParameter("@dbdate", SqlDbType.VarChar,20),
                    new SqlParameter("@inyStoresID", SqlDbType.Int),
                                        };

            parameters[0].Value = dtYear;
            parameters[1].Value = storesID;
            return DbHelper.ExecuteDataset(CommandType.StoredProcedure, "sp_" + BaseConfigs.GetTablePrefix + "ReprotOfStaffByStorehouse", parameters).Tables[0];

           
        }


        /// <summary>
        /// 获得销售年份
        /// </summary>
        /// <returns></returns>
        public DataTable getSalesYear()
        {
            StringBuilder btr = new StringBuilder();
            btr.Append("select distinct(datepart(year,sDateTime)) as sDateTime_year  from tbSalesInfo order by sDateTime_year desc");
            return DbHelper.ExecuteDataset(CommandType.Text, btr.ToString()).Tables[0];
        }
        /// <summary>
        /// 根据门店名称获得门店ID返回int类型
        /// </summary>
        /// <param name="sName"></param>
        /// <returns></returns>
        public int getStorageIDBystorageName(string sName)
        {
            StringBuilder tb = new StringBuilder();
            tb.Append("select StoresID from tbStoresInfo where sName='" + sName + "'");
            return Convert.ToInt32(DbHelper.ExecuteScalar(CommandType.Text, tb.ToString()));
        }
        /// <summary>
        /// 获得店员每月的门店数量
        /// </summary>
        /// <param name="sAppendDate"></param>
        /// <param name="staffID"></param>
        /// <returns></returns>
        public DataTable getStorageNum(string sAppendDate, int staffID)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@chvDate", SqlDbType.VarChar,20),
                    new SqlParameter("@inyStaffID", SqlDbType.Int),
                                        };

            parameters[0].Value = sAppendDate;
            parameters[1].Value = staffID;
            return DbHelper.ExecuteDataset(CommandType.StoredProcedure, "sp_" + BaseConfigs.GetTablePrefix + "GetStorageNumByMonthAndYear_Staff", parameters).Tables[0];

           
        }
        #endregion

    }
}
