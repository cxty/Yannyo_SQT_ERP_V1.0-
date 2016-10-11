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
        /// 仓库管理员信息
        /// </summary>
        /// <returns></returns>
        public DataTable getsManagerByStorage()
        {
            StringBuilder tbr = new StringBuilder();
            tbr.Append("select sName from tbStaffInfo where StaffID in (select sManager from tbStorageInfo )");
            return DbHelper.ExecuteDataset(CommandType.Text,tbr.ToString()).Tables[0];
        }
        /// <summary>
        /// 根据仓库编号找到仓库名称
        /// </summary>
        /// <param name="storageID"></param>
        /// <returns></returns>
        public DataTable getStorageNameByID(int storageID)
        {
            StringBuilder tbr = new StringBuilder();
            tbr.Append("select sName from tbStorageInfo where StorageID='"+storageID+"'");
            return DbHelper.ExecuteDataset(CommandType.Text, tbr.ToString()).Tables[0];
        }
        /// <summary>
        /// 根据产品ID获得产品名称
        /// </summary>
        /// <param name="productID"></param>
        /// <returns></returns>
        public DataTable getProductsNameByID(int productID)
        {
            StringBuilder tbr = new StringBuilder();
            tbr.Append("select pName from tbProductsInfo where ProductsID='" + productID + "'");
            return DbHelper.ExecuteDataset(CommandType.Text, tbr.ToString()).Tables[0];
        }
        /// <summary>
        /// 添加仓库盘点信息
        /// </summary>
        /// <remarks>Cxty_20110711,tbStocktakeInfo中增加字段StockID</remarks>
        /// <returns></returns>
        public bool AddWarehouseList(WarehouseInventoryInfo sInventoryInfo)
        {
            StringBuilder btr = new StringBuilder();

            if (sInventoryInfo.GetWarehouseDateJson != null)
            {
                if (sInventoryInfo.GetWarehouseDateJson.WarehouseInventory != null)
                {
                    DateTime sDateTime = sInventoryInfo.SDateTime;      //盘点时间
                    DateTime sAppendTime = sInventoryInfo.SAppendTime;  //库存点
                    int StorageID = sInventoryInfo.StorageID;//仓库编号
                    string StorageStaff = sInventoryInfo.StorageStaff;//仓管员
                    string StaffPhoneNum = sInventoryInfo.StaffPhoneNum;//联系电话
                    string StaffAdress = sInventoryInfo.StaffAdress;//联系地址
                    string InventoryName = sInventoryInfo.InventoryName;//盘点人
                    int uerID = sInventoryInfo.StaffID;//操作员编号
                    string userName = sInventoryInfo.StaffName;//操作员名称
                    string StorageName = sInventoryInfo.StorageName;//仓库名称

                    btr.Append("declare @StockID int;");
                    btr.Append("insert into tbStocktakeInventoryInfo(StorageID,StorageStaff,StaffPhoneNum,StaffAdress,sAppendTime,sUpdateTime,InventoryName,StaffID,StorageName,StaffName)");
                    btr.Append(" values('" + StorageID + "','" + StorageStaff + "','" + StaffPhoneNum + "','" + StaffAdress + "','" + sDateTime + "','" + sAppendTime + "','" + InventoryName + "','" + uerID + "','" + StorageName + "','" + userName + "')");
                    btr.Append(";SET @StockID = SCOPE_IDENTITY();");
                    try
                    {
                        foreach (WarehouseInventory ol in sInventoryInfo.GetWarehouseDateJson.WarehouseInventory)
                        {
                            if (ol != null)
                            {
                                btr.Append("insert  into tbStocktakeInfo(StockID,ProductsID,StorageID,Quantity,sQuantity,sDateTime,sAppendTime,StaffID,sSteps)");
                                btr.Append(" values(@StockID,'" + ol.pid + "','" + StorageID + "','" + ol.pnum + "','" + ol.oQuantity + "','" + sDateTime + "','" + sAppendTime + "','" + uerID + "',0)"); 
                            } 
                        }
                       
                        DbHelper.ExecuteNonQuery(CommandType.Text, btr.ToString());
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
        /// 更新盘点数据
        /// </summary>
        /// <remarks>Cxty_20110711</remarks>
        /// <param name="sInventoryInfo"></param>
        /// <returns></returns>
        public bool UpdateWarehouseList(WarehouseInventoryInfo sInventoryInfo)
        { 
            StringBuilder btr = new StringBuilder();

            if (sInventoryInfo.GetWarehouseDateJson != null)
            {
                if (sInventoryInfo.GetWarehouseDateJson.WarehouseInventory != null)
                {
                    btr.Append("update tbStocktakeInventoryInfo set SAppendTime=@SAppendTime,StorageStaff=@StorageStaff,StaffPhoneNum=@StaffPhoneNum,StaffAdress=@StaffAdress,InventoryName=@InventoryName where StockID=@StockID;");
                    try
                    {
                        foreach (WarehouseInventory ol in sInventoryInfo.GetWarehouseDateJson.WarehouseInventory)
                        {
                            if (ol.stocktakeid > 0)
                            {
                                btr.Append("update tbStocktakeInfo set Quantity='" + ol.pnum + "',sQuantity='" + ol.oQuantity + "',sAppendTime=@SAppendTime where StocktakeID=" + ol.stocktakeid+" ;");
                            }
                            else {
                                btr.Append("insert  into tbStocktakeInfo(StockID,ProductsID,StorageID,Quantity,sQuantity,sDateTime,sAppendTime,StaffID,sSteps)");
                                btr.Append(" values(" + sInventoryInfo.StockID + ",'" + ol.pid + "','" + sInventoryInfo.StorageID + "','" + ol.pnum + "','" + ol.oQuantity + "','" + sInventoryInfo.SDateTime + "',@SAppendTime,'" + sInventoryInfo.StaffID + "',0);");
                            }
                        }
                        SqlParameter[] parameters = {
					        new SqlParameter("@SAppendTime", SqlDbType.DateTime,8),
                            new SqlParameter("@StorageStaff", SqlDbType.VarChar,50),
                            new SqlParameter("@StaffPhoneNum", SqlDbType.VarChar,50),
                            new SqlParameter("@StaffAdress", SqlDbType.VarChar,50),
                            new SqlParameter("@InventoryName", SqlDbType.VarChar,50), 
                            new SqlParameter("@StockID", SqlDbType.Int,4) 
                                                    };
                        parameters[0].Value = sInventoryInfo.SAppendTime;
                        parameters[1].Value = sInventoryInfo.StorageStaff;
                        parameters[2].Value = sInventoryInfo.StaffPhoneNum;
                        parameters[3].Value = sInventoryInfo.StaffAdress;
                        parameters[4].Value = sInventoryInfo.InventoryName;
                        parameters[5].Value = sInventoryInfo.StockID;

                        DbHelper.ExecuteNonQuery(CommandType.Text, btr.ToString(), parameters);
                        return true;
                    }
                    catch {
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
        /// 查询盘点数据列表
        /// </summary>
        /// <param name="storageID"></param>
        /// <param name="sAppendTime"></param>
        /// <returns></returns>
        public DataTable getInventoryInfoList(int storageID, DateTime sAppendTime)
        {
            StringBuilder btr = new StringBuilder();
            btr.Append(" select tbi.StocktakeID,pif.pName,pif.pBarcode,tbi.ProductsID,Quantity,sQuantity,sDateTime,sAppendTime,");
            btr.Append(" (select top 1 sName from tbStorageInfo where StorageID='"+storageID+"') as sName");
            btr.Append(" from tbStocktakeInfo  as tbi left join tbProductsInfo as pif on pif.ProductsID=tbi.ProductsID  where StorageID='" + storageID + "' and tbi.sAppendTime='" + sAppendTime + "' order by pif.ProductClassID,pif.ProductsID desc");
            DataTable state = DbHelper.ExecuteDataset(CommandType.Text, btr.ToString()).Tables[0];
            if (state.Rows.Count > 0)
            {
                return state;
            }
            else
            {
                return null;
            }
        }
        public DataSet getStockInfo()
        {
            StringBuilder btr = new StringBuilder();
            btr.Append("select sName,StorageID from tbStorageInfo");
            return DbHelper.ExecuteDataset(CommandType.Text, btr.ToString());
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public WarehouseInventoryInfo GetWarehouseInventoryInfoModel(int StocktakeID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 ProductsID,StorageID,Quantity,sQuantity,sDateTime,sAppendTime,StaffID,sSteps from tbStocktakeInfo  ");
            strSql.Append(" where StocktakeID=@StocktakeID ");
            SqlParameter[] parameters = {
					new SqlParameter("@StocktakeID", SqlDbType.Int,4)};
            parameters[0].Value = StocktakeID;

            WarehouseInventoryInfo model = new WarehouseInventoryInfo();
            DataSet ds = DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ProductsID"].ToString() != "")
                {
                    model.ProductsID = int.Parse(ds.Tables[0].Rows[0]["ProductsID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["StorageID"].ToString() != "")
                {
                    model.StorageID = int.Parse( ds.Tables[0].Rows[0]["StorageID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Quantity"].ToString() != "")
                {
                    model.Quantity =decimal.Parse(ds.Tables[0].Rows[0]["Quantity"].ToString());
                }
                if (ds.Tables[0].Rows[0]["sQuantity"].ToString() != "")
                {
                    model.SQuantity =decimal.Parse(ds.Tables[0].Rows[0]["sQuantity"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ProductsID"].ToString() != "")
                {
                    model.ProductsID = int.Parse(ds.Tables[0].Rows[0]["ProductsID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["sDateTime"].ToString() != "")
                {
                    model.SDateTime =DateTime.Parse(ds.Tables[0].Rows[0]["sDateTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["sAppendTime"].ToString() != "")
                {
                    model.SAppendTime = DateTime.Parse(ds.Tables[0].Rows[0]["sAppendTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["StaffID"].ToString() != "")
                {
                    model.StaffID = int.Parse(ds.Tables[0].Rows[0]["StaffID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["sSteps"].ToString() != "")
                {
                    model.SSteps = int.Parse(ds.Tables[0].Rows[0]["sSteps"].ToString());
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
        public int UpdateStorageInventoryInfo(WarehouseInventoryInfo pp)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbStocktakeInfo set ");
            strSql.Append(" Quantity=@Quantity ");
            strSql.Append(" where StocktakeID=@StocktakeID");

            SqlParameter[] parm ={
                               new SqlParameter("@StocktakeID",SqlDbType.Int),
                               new SqlParameter("@Quantity",SqlDbType.Decimal),
                               };
            parm[0].Value = pp.StocktakeID;
            parm[1].Value = pp.Quantity;

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
        /// 检查重复数据
        /// </summary>
        /// <param name="sID"></param>
        /// <param name="sAppendTime"></param>
        /// <param name="pID"></param>
        /// <returns></returns>
        public bool getWarehouseInfo(int sID,DateTime sAppendTime)
        {
            StringBuilder btr = new StringBuilder();
            btr.Append("  select COUNT(0) from tbStocktakeInfo where StorageID='" + sID + "' and sAppendTime='" + sAppendTime + "'");
            int dt= Int32.Parse(DbHelper.ExecuteScalarToStr(CommandType.Text, btr.ToString()));
            if (dt > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataTable GetWarehouseViewInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
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
            parameters[0].Value = "tbStocktakeInventoryInfo";
            parameters[1].Value = "StockID";
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

        public string getSnameByScode(int sCode)
        {
            StringBuilder btr = new StringBuilder();
            btr.Append(" select sName from tbStorageInfo where StorageID='"+sCode+"'");
            return DbHelper.ExecuteScalarToStr(CommandType.Text,btr.ToString());
        }
        /// <summary>
        /// 得到一个对象实体tbStocktakeInventoryInfo
        /// </summary>
        public WarehouseInventoryInfo GetInventoryInfoModel(int StockID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 StorageName,StorageID,StorageStaff,StaffPhoneNum,StaffAdress,sUpdateTime,sAppendTime,InventoryName,StaffID,StaffName from tbStocktakeInventoryInfo  ");
            strSql.Append(" where StockID=@StockID ");
            SqlParameter[] parameters = {
					new SqlParameter("@StockID", SqlDbType.Int,4)};
            parameters[0].Value = StockID;

            WarehouseInventoryInfo model = new WarehouseInventoryInfo();
            DataSet ds = DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.StockID = StockID;
                if (ds.Tables[0].Rows[0]["StorageName"].ToString() != "")
                {
                    model.StorageName = ds.Tables[0].Rows[0]["StorageName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["StorageID"].ToString() != "")
                {
                    model.StorageID = int.Parse(ds.Tables[0].Rows[0]["StorageID"].ToString());
                }
                //if (ds.Tables[0].Rows[0]["StorageStaff"].ToString() != "")
                {
                    model.StorageStaff= ds.Tables[0].Rows[0]["StorageStaff"].ToString();
                }
               // if (ds.Tables[0].Rows[0]["StaffPhoneNum"].ToString() != "")
                {
                    model.StaffPhoneNum = ds.Tables[0].Rows[0]["StaffPhoneNum"].ToString();
                }
              //  if (ds.Tables[0].Rows[0]["StaffAdress"].ToString() != "")
                {
                    model.StaffAdress =ds.Tables[0].Rows[0]["StaffAdress"].ToString();
                }
                if (ds.Tables[0].Rows[0]["sUpdateTime"].ToString() != "")
                {
                    model.SDateTime = DateTime.Parse(ds.Tables[0].Rows[0]["sUpdateTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["sAppendTime"].ToString() != "")
                {
                    model.SAppendTime = DateTime.Parse(ds.Tables[0].Rows[0]["sAppendTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["InventoryName"].ToString() != "")
                {
                    model.InventoryName = ds.Tables[0].Rows[0]["InventoryName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["StaffID"].ToString() != "")
                {
                    model.StaffID = int.Parse(ds.Tables[0].Rows[0]["StaffID"].ToString());
                }
               // if (ds.Tables[0].Rows[0]["StaffName"].ToString() != "")
                {
                    model.StaffName = ds.Tables[0].Rows[0]["StaffName"].ToString();
                }
                return model;
            }
            else
            {
                return null;
            }
        }
    }
}
