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
        #region Order
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistsOrderInfo(string oOrderNum)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tbOrderInfo");
            strSql.Append(" where oOrderNum=@oOrderNum ");
            SqlParameter[] parameters = {
					new SqlParameter("@oOrderNum", SqlDbType.VarChar,50)};
            parameters[0].Value = oOrderNum;

            return  ((int)DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters)) > 0;
        }

        /// <summary>
        /// 取当前系统最后一个单据号
        /// </summary>
        /// <returns></returns>
        public string GetMaxOrderNum()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 oOrderNum from tbOrderInfo order by OrderID desc");
            return DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString()).ToString();
        }
		/// <summary>
		/// 取同类型的最新的单据
		/// </summary>
		/// <returns>The next order.</returns>
		/// <param name="oType">单据类型</param>
		/// <param name="oState">查询状态，0正常，1屏蔽</param>
		/// <param name="oSteps">查询进度，新开单=1
		/// 新单已审核=2
		/// 已发货=3
		/// 已收货=4
		/// 收货已确认(验收单已回)=5
		/// 未对账=6(正在对账中)
		/// 已对账=7
		/// 完成收付款=8
		/// 已结账=9
		/// </param>
		public OrderInfo GetNextOrder(int oType,int oState,int oSteps){
			StringBuilder strSql = new StringBuilder();
			strSql.Append ("select top 1 OrderID,oOrderNum,oType,StoresID,oCustomersName,oCustomersContact,oCustomersTel,oCustomersAddress,oCustomersOrderID,oCustomersNameB,StaffID,UserID,oAppendTime,oOrderDateTime,oState,oPrepay,oSteps,oReMake ");
			strSql.Append (" from tbOrderInfo where oType=@oType and oState=@oState and oSteps=@oSteps order by OrderID desc");

			SqlParameter[] parameters = {
				new SqlParameter("@oType", SqlDbType.Int,4),
				new SqlParameter("@oState", SqlDbType.Int,4),
				new SqlParameter("@oSteps", SqlDbType.Int,4)
			};
			parameters[0].Value = oType;
			parameters[1].Value = oState;
			parameters[2].Value = oSteps;

			OrderInfo model = new OrderInfo();
			DataSet ds = DbHelper.ExecuteDataset(CommandType.Text,strSql.ToString(),parameters);
			if (ds.Tables[0].Rows.Count > 0)
			{
				if (ds.Tables[0].Rows[0]["OrderID"].ToString() != "")
				{
					model.OrderID = int.Parse(ds.Tables[0].Rows[0]["OrderID"].ToString());
				}

				model.oOrderNum = ds.Tables[0].Rows[0]["oOrderNum"].ToString();
				model.oReMake = ds.Tables[0].Rows[0]["oReMake"].ToString();
				if (ds.Tables[0].Rows[0]["oType"].ToString() != "")
				{
					model.oType = int.Parse(ds.Tables[0].Rows[0]["oType"].ToString());
				}
				if (ds.Tables[0].Rows[0]["StoresID"].ToString() != "")
				{
					model.StoresID = int.Parse(ds.Tables[0].Rows[0]["StoresID"].ToString());
				}
				model.oCustomersName = ds.Tables[0].Rows[0]["oCustomersName"].ToString();
				if (ds.Tables[0].Rows[0]["StoresID"].ToString() != "")
				{
					model.StoresSupplierID = int.Parse(ds.Tables[0].Rows[0]["StoresID"].ToString());
				}
				model.oCustomersContact = ds.Tables[0].Rows[0]["oCustomersContact"].ToString();
				model.oCustomersTel = ds.Tables[0].Rows[0]["oCustomersTel"].ToString();
				model.oCustomersAddress = ds.Tables[0].Rows[0]["oCustomersAddress"].ToString();
				model.oCustomersOrderID = ds.Tables[0].Rows[0]["oCustomersOrderID"].ToString();
				model.oCustomersNameB = ds.Tables[0].Rows[0]["oCustomersNameB"].ToString();
				if (ds.Tables[0].Rows[0]["StaffID"].ToString() != "")
				{
					model.StaffID = int.Parse(ds.Tables[0].Rows[0]["StaffID"].ToString());
				}
				if (ds.Tables[0].Rows[0]["UserID"].ToString() != "")
				{
					model.UserID = int.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
				}

				if (ds.Tables[0].Rows[0]["oAppendTime"].ToString() != "")
				{
					model.oAppendTime = DateTime.Parse(ds.Tables[0].Rows[0]["oAppendTime"].ToString());
				}
				if (ds.Tables[0].Rows[0]["oOrderDateTime"].ToString() != "")
				{
					model.oOrderDateTime = DateTime.Parse(ds.Tables[0].Rows[0]["oOrderDateTime"].ToString());
				}
				if (ds.Tables[0].Rows[0]["oState"].ToString() != "")
				{
					model.oState = int.Parse(ds.Tables[0].Rows[0]["oState"].ToString());
				}
				if (ds.Tables[0].Rows[0]["oSteps"].ToString() != "")
				{
					model.oSteps = int.Parse(ds.Tables[0].Rows[0]["oSteps"].ToString());
				}
				if (ds.Tables[0].Rows[0]["oPrepay"].ToString() != "")
				{
					model.oPrepay = int.Parse(ds.Tables[0].Rows[0]["oPrepay"].ToString());
				}
				return model;
			}
			else
			{
				return null;
			}
		}

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddOrderInfo(OrderInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tbOrderInfo(");
            strSql.Append("oOrderNum,oType,StoresID,oCustomersName,oCustomersContact,oCustomersTel,oCustomersAddress,oCustomersOrderID,oCustomersNameB,StaffID,UserID,oAppendTime,oOrderDateTime,oState,oSteps,oPrepay,oReMake)");
            strSql.Append(" values (");
            strSql.Append("@oOrderNum,@oType,@StoresID,@oCustomersName,@oCustomersContact,@oCustomersTel,@oCustomersAddress,@oCustomersOrderID,@oCustomersNameB,@StaffID,@UserID,@oAppendTime,@oOrderDateTime,@oState,@oSteps,@oPrepay,@oReMake)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@oOrderNum", SqlDbType.VarChar,50),
					new SqlParameter("@oType", SqlDbType.Int,4),
					new SqlParameter("@StoresID", SqlDbType.Int,4),
					new SqlParameter("@oCustomersName", SqlDbType.VarChar,128),
					new SqlParameter("@oCustomersContact", SqlDbType.VarChar,50),
					new SqlParameter("@oCustomersTel", SqlDbType.VarChar,50),
					new SqlParameter("@oCustomersAddress", SqlDbType.VarChar,512),
					new SqlParameter("@oCustomersOrderID", SqlDbType.VarChar,50),
					new SqlParameter("@oCustomersNameB", SqlDbType.VarChar,128),
					new SqlParameter("@StaffID", SqlDbType.Int,4),
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@oAppendTime", SqlDbType.DateTime),
					new SqlParameter("@oOrderDateTime", SqlDbType.DateTime),
					new SqlParameter("@oState", SqlDbType.Int,4),
					new SqlParameter("@oSteps", SqlDbType.Int,4),
					new SqlParameter("@oPrepay", SqlDbType.Int,4),
                    new SqlParameter("@oReMake", SqlDbType.VarChar,512), };
            parameters[0].Value = model.oOrderNum;
            parameters[1].Value = model.oType;
            parameters[2].Value = model.StoresID;
            parameters[3].Value = model.oCustomersName;
            parameters[4].Value = model.oCustomersContact;
            parameters[5].Value = model.oCustomersTel;
            parameters[6].Value = model.oCustomersAddress;
            parameters[7].Value = model.oCustomersOrderID;
            parameters[8].Value = model.oCustomersNameB;
            parameters[9].Value = model.StaffID;
            parameters[10].Value = model.UserID;
            parameters[11].Value = model.oAppendTime;
            parameters[12].Value = model.oOrderDateTime;
            parameters[13].Value = model.oState;
            parameters[14].Value = model.oSteps;
            parameters[15].Value = model.oPrepay;
            parameters[16].Value = model.oReMake;

            object obj = DbHelper.ExecuteScalar(CommandType.Text,strSql.ToString(), parameters);
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
        /// 带单据体的创建
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddOrderInfoAndList(OrderInfo model)
        {
            if (model.OrderListDataJson != null)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("declare @OrderID int;");
                strSql.Append("declare @OrderListID int;");
                strSql.Append("insert into tbOrderInfo(");
                strSql.Append("oOrderNum,oType,StoresID,oCustomersName,oCustomersContact,oCustomersTel,oCustomersAddress,oCustomersOrderID,oCustomersNameB,StaffID,UserID,oAppendTime,oOrderDateTime,oState,oSteps,oPrepay,oReMake)");
                strSql.Append(" values (");
                strSql.Append("@oOrderNum,@oType,@StoresID,@oCustomersName,@oCustomersContact,@oCustomersTel,@oCustomersAddress,@oCustomersOrderID,@oCustomersNameB,@StaffID,@UserID,@oAppendTime,@oOrderDateTime,@oState,@oSteps,@oPrepay,@oReMake)");
                strSql.Append(";SET @OrderID = SCOPE_IDENTITY();select @OrderID;");
                foreach (OrderListJson ol in model.OrderListDataJson.OrderListJson)
                {
                    if (ol != null)
                    {
                        strSql.Append(" insert into tbOrderListInfo(OrderID,StorageID,ProductsID,oQuantity,oPrice,oMoney,StoresSupplierID,IsPromotions,oWorkType,oAppendTime,IsGifts,PriceClassID)");
                        strSql.Append(" values(@OrderID," + ol.StorageID + "," + ol.ProductsID + "," + ol.oQuantity + "," + ol.oPrice + "," + ol.oMoney + "," + ol.StoresSupplierID + "," + ol.IsPromotions + "," + ol.oWorkType + ",Getdate()," + ol.IsGifts + "," + ol.PriceClassID + ");SET @OrderListID = SCOPE_IDENTITY();");
                        if (ol.OrderFieldValueInfo != null)
                        {
                            foreach (OrderFieldValueInfo ofv in ol.OrderFieldValueInfo)
                            {
                                if (ofv != null)
                                {
                                    strSql.Append("  insert into tbOrderFieldValueInfo(OrderFieldID,OrderListID,oFieldValue,IsVerify,oAppendTime)");
                                    strSql.Append("     values(" + ofv.OrderFieldID + ",@OrderListID,'" + ofv.oFieldValue + "'," + ofv.IsVerify + ",getdate());");
                                }
                            }
                        }
                    }
                }
                
                SqlParameter[] parameters = {
					new SqlParameter("@oOrderNum", SqlDbType.VarChar,50),
					new SqlParameter("@oType", SqlDbType.Int,4),
					new SqlParameter("@StoresID", SqlDbType.Int,4),
					new SqlParameter("@oCustomersName", SqlDbType.VarChar,128),
					new SqlParameter("@oCustomersContact", SqlDbType.VarChar,50),
					new SqlParameter("@oCustomersTel", SqlDbType.VarChar,50),
					new SqlParameter("@oCustomersAddress", SqlDbType.VarChar,512),
					new SqlParameter("@oCustomersOrderID", SqlDbType.VarChar,50),
					new SqlParameter("@oCustomersNameB", SqlDbType.VarChar,128),
					new SqlParameter("@StaffID", SqlDbType.Int,4),
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@oAppendTime", SqlDbType.DateTime),
					new SqlParameter("@oOrderDateTime", SqlDbType.DateTime),
					new SqlParameter("@oState", SqlDbType.Int,4),
					new SqlParameter("@oSteps", SqlDbType.Int,4),
					new SqlParameter("@oPrepay", SqlDbType.Int,4),
                                            new SqlParameter("@oReMake", SqlDbType.VarChar,512),};
                parameters[0].Value = model.oOrderNum;
                parameters[1].Value = model.oType;
                parameters[2].Value = model.StoresID;
                parameters[3].Value = model.oCustomersName;
                parameters[4].Value = model.oCustomersContact;
                parameters[5].Value = model.oCustomersTel;
                parameters[6].Value = model.oCustomersAddress;
                parameters[7].Value = model.oCustomersOrderID;
                parameters[8].Value = model.oCustomersNameB;
                parameters[9].Value = model.StaffID;
                parameters[10].Value = model.UserID;
                parameters[11].Value = model.oAppendTime;
                parameters[12].Value = model.oOrderDateTime;
                parameters[13].Value = model.oState;
                parameters[14].Value = model.oSteps;
                parameters[15].Value = model.oPrepay;
                parameters[16].Value = model.oReMake;

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
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// 更新单据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateOrderInfoAndList(OrderInfo model)
        {
            bool re = false;
            if (model.OrderListDataJson != null)
            {
                string tID = "'0',";
                StringBuilder strSql = new StringBuilder();
                strSql.Append("declare @tSQL varchar(2048);");
                strSql.Append("declare @OrderListIDStr varchar(1024);");
                strSql.Append("declare @OrderListIDNew int;");
                strSql.Append("set @tSQL='';");
                strSql.Append("set @OrderListIDStr='';");
                strSql.Append("update tbOrderInfo set StoresID=@StoresID,oCustomersName=@oCustomersName,oCustomersContact=@oCustomersContact,oCustomersTel=@oCustomersTel,"+
                                        "oCustomersAddress=@oCustomersAddress,oCustomersOrderID=@oCustomersOrderID,oCustomersNameB=@oCustomersNameB,StaffID=@StaffID,oOrderDateTime=@oOrderDateTime,oPrepay=@oPrepay,oReMake=@oReMake" +
                                        " where OrderID=@OrderID;");
                int IsVerify = (model.oSteps == 1) ? 0 : 1;
                foreach (OrderListJson ol in model.OrderListDataJson.OrderListJson)
                {
                    if (ol != null)
                    {
                        ol.StoresSupplierID = (ol.StoresSupplierID > 0) ? ol.StoresSupplierID : model.StoresID;
                        if (ol.OrderListID > 0)
                        {
                            //更新旧记录
                            strSql.Append(" update tbOrderListInfo set StorageID=" + ol.StorageID + ",ProductsID=" + ol.ProductsID + ",oQuantity=" + ol.oQuantity + ",oPrice=" + ol.oPrice + ",oMoney=" + ol.oMoney + ",StoresSupplierID=" + ol.StoresSupplierID + ",IsPromotions=" + ol.IsPromotions + ",PriceClassID=" + ol.PriceClassID + " " +
                                " where OrderListID="+ol.OrderListID+" and OrderID=@OrderID;set @OrderListIDStr=@OrderListIDStr+'"+ol.OrderListID+",';");
                            tID += "'"+ol.OrderListID+"',";
                            if (ol.OrderFieldValueInfo != null)
                            {
                                foreach (OrderFieldValueInfo ofv in ol.OrderFieldValueInfo)
                                {
                                    if (ofv != null)
                                    {
                                        if (ofv.OrderFieldValueID > 0)
                                        {
                                            strSql.Append(" update tbOrderFieldValueInfo set oFieldValue='" + ofv.oFieldValue + "' where OrderFieldValueID=" + ofv.OrderFieldValueID + " and OrderListID=" + ol.OrderListID + " ;");
                                        }
                                        else
                                        {
                                            strSql.Append("  insert into tbOrderFieldValueInfo(OrderFieldID,OrderListID,oFieldValue,IsVerify,oAppendTime)");
                                            strSql.Append("     values(" + ofv.OrderFieldID + "," + ol.OrderListID + ",'" + ofv.oFieldValue + "'," + IsVerify + ",getdate());");
                                        }
                                    }
                                }
                            }
                        }
                        /*
                        else
                        {
                            //添加新纪录
                            strSql.Append("  insert into tbOrderListInfo(OrderID,StorageID,ProductsID,oQuantity,oPrice,oMoney,StoresSupplierID,IsPromotions,oWorkType,oAppendTime)");
                            strSql.Append(" values(@OrderID," + ol.StorageID + "," + ol.ProductsID + "," + ol.oQuantity + "," + ol.oPrice + "," + ol.oMoney + "," + ol.StoresSupplierID + "," + ol.IsPromotions + "," + IsVerify + ",Getdate());" +
                                "SET @OrderListIDNew = SCOPE_IDENTITY();set @OrderListIDStr=@OrderListIDStr+CAST(@OrderListIDNew as varchar(10))+',';");
                            if (ol.OrderFieldValueInfo != null)
                            {
                                foreach (OrderFieldValueInfo ofv in ol.OrderFieldValueInfo)
                                {
                                    if (ofv != null)
                                    {
                                        strSql.Append("  insert into tbOrderFieldValueInfo(OrderFieldID,OrderListID,oFieldValue,IsVerify,oAppendTime)");
                                        strSql.Append("     values(" + ofv.OrderFieldID + ",@OrderListIDNew,'" + ofv.oFieldValue + "'," + IsVerify + ",getdate());");
                                    }
                                }
                            }
                        }*/
                    }
                }

                //删除不在该列表内的记录
                if (tID.Trim()!="")
                {
                    tID = Utils.ReSQLSetTxt(tID);
                    strSql.Append("delete from tbOrderListInfo where OrderListID not in(" + tID + ") and oWorkType=" + IsVerify + " and OrderID=" + model.OrderID + ";");
                    strSql.Append("delete from tbOrderFieldValueInfo where OrderListID not in(" + tID + ") and IsVerify=" + IsVerify + " and OrderListID in(select OrderListID from tbOrderListInfo where OrderID=" + model.OrderID + ");");
                }
                /*
                strSql.Append("set @OrderListIDStr=SUBSTRING(@OrderListIDStr,0,LEN(@OrderListIDStr));");
                strSql.Append("set @tSQL='delete from tbOrderListInfo where OrderListID not in('+CAST(@OrderListIDStr as varchar)+') and oWorkType=" + IsVerify + " and OrderID=" + model.OrderID + ";';");
                strSql.Append("set @tSQL=@tSQL+'delete from tbOrderFieldValueInfo where OrderListID not in('+CAST(@OrderListIDStr as varchar)+') and IsVerify=" + IsVerify + " and OrderListID in(select OrderListID from tbOrderListInfo where OrderID=" + model.OrderID + ");';");
                strSql.Append("exec(@tSQL);");
                */
                foreach (OrderListJson ol in model.OrderListDataJson.OrderListJson)
                {
                    if (ol != null)
                    {
                        ol.StoresSupplierID = (ol.StoresSupplierID > 0) ? ol.StoresSupplierID : model.StoresID;
                        if (ol.OrderListID <= 0)
                        {
                            //添加新纪录
                            strSql.Append("  insert into tbOrderListInfo(OrderID,StorageID,ProductsID,oQuantity,oPrice,oMoney,StoresSupplierID,IsPromotions,oWorkType,oAppendTime,IsGifts,PriceClassID)");
                            strSql.Append(" values(@OrderID," + ol.StorageID + "," + ol.ProductsID + "," + ol.oQuantity + "," + ol.oPrice + "," + ol.oMoney + "," + ol.StoresSupplierID + "," + ol.IsPromotions + "," + IsVerify + ",Getdate()," + ol.IsGifts + "," + ol.PriceClassID + ");" +
                                "SET @OrderListIDNew = SCOPE_IDENTITY();set @OrderListIDStr=@OrderListIDStr+CAST(@OrderListIDNew as varchar(10))+',';");
                            if (ol.OrderFieldValueInfo != null)
                            {
                                foreach (OrderFieldValueInfo ofv in ol.OrderFieldValueInfo)
                                {
                                    if (ofv != null)
                                    {
                                        strSql.Append("  insert into tbOrderFieldValueInfo(OrderFieldID,OrderListID,oFieldValue,IsVerify,oAppendTime)");
                                        strSql.Append("     values(" + ofv.OrderFieldID + ",@OrderListIDNew,'" + ofv.oFieldValue + "'," + IsVerify + ",getdate());");
                                    }
                                }
                            }
                        }
                    }
                }

                try
                {
                    SqlParameter[] parameters = {
                                                    new SqlParameter("@OrderID", SqlDbType.Int,4),
					new SqlParameter("@StoresID", SqlDbType.Int,4),
					new SqlParameter("@oCustomersName", SqlDbType.VarChar,128),
					new SqlParameter("@oCustomersContact", SqlDbType.VarChar,50),
					new SqlParameter("@oCustomersTel", SqlDbType.VarChar,50),
					new SqlParameter("@oCustomersAddress", SqlDbType.VarChar,512),
					new SqlParameter("@oCustomersOrderID", SqlDbType.VarChar,50),
					new SqlParameter("@oCustomersNameB", SqlDbType.VarChar,128),
					new SqlParameter("@StaffID", SqlDbType.Int,4),
					new SqlParameter("@oOrderDateTime", SqlDbType.DateTime),
                                                new SqlParameter("@oPrepay", SqlDbType.Int,4),
                                                new SqlParameter("@oReMake", SqlDbType.VarChar,512),};

                    parameters[0].Value = model.OrderID;
                    parameters[1].Value = model.StoresID;
                    parameters[2].Value = model.oCustomersName;
                    parameters[3].Value = model.oCustomersContact;
                    parameters[4].Value = model.oCustomersTel;
                    parameters[5].Value = model.oCustomersAddress;
                    parameters[6].Value = model.oCustomersOrderID;
                    parameters[7].Value = model.oCustomersNameB;
                    parameters[8].Value = model.StaffID;
                    parameters[9].Value = model.oOrderDateTime;
                    parameters[10].Value = model.oPrepay;
                    parameters[11].Value = model.oReMake;

                    DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
                    re = true;
                }
                catch
                {
                    re = false;
                }
            }
            return re;
        }

        /// <summary>
        /// 审核单据
        /// </summary>
        /// <param name="OrderID"></param>
        public void VerifyOrder(int OrderID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@OrderID", SqlDbType.Int,4)};
            parameters[0].Value = OrderID;

            DbHelper.ExecuteDataset(CommandType.StoredProcedure, "sp_" + BaseConfigs.GetTablePrefix + "VerifyOrder", parameters);

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void UpdateOrderInfo(OrderInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbOrderInfo set ");
            strSql.Append("oOrderNum=@oOrderNum,");
            strSql.Append("oType=@oType,");
            strSql.Append("StoresID=@StoresID,");
            strSql.Append("oCustomersName=@oCustomersName,");
            strSql.Append("oCustomersContact=@oCustomersContact,");
            strSql.Append("oCustomersTel=@oCustomersTel,");
            strSql.Append("oCustomersAddress=@oCustomersAddress,");
            strSql.Append("oCustomersOrderID=@oCustomersOrderID,");
            strSql.Append("oCustomersNameB=@oCustomersNameB,");
            strSql.Append("StaffID=@StaffID,");
            strSql.Append("UserID=@UserID,");
            strSql.Append("oAppendTime=@oAppendTime,");
            strSql.Append("oOrderDateTime=@oOrderDateTime,");
            strSql.Append("oState=@oState,");
            strSql.Append("oSteps=@oSteps,");
            strSql.Append("oPrepay=@oPrepay,");
            strSql.Append("oReMake=@oReMake");
            strSql.Append(" where OrderID=@OrderID ;");

            //核销操作
            if (model.oSteps == 5)
            {
                //特殊情况**********换货单(oType=11):审核后库存减少,核销后库存增加**********
                //所以核销后属于 抵消途中出库
                if (model.oType == 1 || model.oType == 4 || model.oType == 8 || model.oType == 9 )//入库
                {
                    strSql.Append("insert into tbProductsStorageLogInfo(StorageID,ProductsID,OrderID,pQuantity,pType,pAppendTime,pState) "+
                        " select StorageID,ProductsID,OrderID,oQuantity,0,getdate(),0 from tbOrderListInfo where OrderID=@OrderID and oWorkType=1 ;");
                }
                else if (model.oType == 2 || model.oType == 3 || model.oType == 5 || model.oType == 6 || model.oType==7)//出库
                {
                    strSql.Append("insert into tbProductsStorageLogInfo(StorageID,ProductsID,OrderID,pQuantity,pType,pAppendTime,pState) " +
                        " select StorageID,ProductsID,OrderID,0-oQuantity,1,getdate(),0 from tbOrderListInfo where OrderID=@OrderID and oWorkType=1 ;");
                }else if(model.oType == 10)//损耗
                {
                    strSql.Append("insert into tbProductsStorageLogInfo(StorageID,ProductsID,OrderID,pQuantity,pType,pAppendTime,pState) " +
                        " select StorageID,ProductsID,OrderID,0-oQuantity,2,getdate(),0 from tbOrderListInfo where OrderID=@OrderID and oWorkType=1 ;");
                }
                strSql.Append("update tbOrderListInfo set oWorkType=2 where OrderID=@OrderID and oWorkType=1;");
            }

            SqlParameter[] parameters = {
					new SqlParameter("@OrderID", SqlDbType.Int,4),
					new SqlParameter("@oOrderNum", SqlDbType.VarChar,50),
					new SqlParameter("@oType", SqlDbType.Int,4),
					new SqlParameter("@StoresID", SqlDbType.Int,4),
					new SqlParameter("@oCustomersName", SqlDbType.VarChar,128),
					new SqlParameter("@oCustomersContact", SqlDbType.VarChar,50),
					new SqlParameter("@oCustomersTel", SqlDbType.VarChar,50),
					new SqlParameter("@oCustomersAddress", SqlDbType.VarChar,512),
					new SqlParameter("@oCustomersOrderID", SqlDbType.VarChar,50),
					new SqlParameter("@oCustomersNameB", SqlDbType.VarChar,128),
					new SqlParameter("@StaffID", SqlDbType.Int,4),
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@oAppendTime", SqlDbType.DateTime),
					new SqlParameter("@oOrderDateTime", SqlDbType.DateTime),
					new SqlParameter("@oState", SqlDbType.Int,4),
					new SqlParameter("@oSteps", SqlDbType.Int,4),
					new SqlParameter("@oPrepay", SqlDbType.Int,4),
                                        new SqlParameter("@oReMake", SqlDbType.VarChar,512),};
            parameters[0].Value = model.OrderID;
            parameters[1].Value = model.oOrderNum;
            parameters[2].Value = model.oType;
            parameters[3].Value = model.StoresID;
            parameters[4].Value = model.oCustomersName;
            parameters[5].Value = model.oCustomersContact;
            parameters[6].Value = model.oCustomersTel;
            parameters[7].Value = model.oCustomersAddress;
            parameters[8].Value = model.oCustomersOrderID;
            parameters[9].Value = model.oCustomersNameB;
            parameters[10].Value = model.StaffID;
            parameters[11].Value = model.UserID;
            parameters[12].Value = model.oAppendTime;
            parameters[13].Value = model.oOrderDateTime;
            parameters[14].Value = model.oState;
            parameters[15].Value = model.oSteps;
            parameters[16].Value = model.oPrepay;
            parameters[17].Value = model.oReMake;

            DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void DeleteOrderInfo(int OrderID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbOrderInfo ");
            strSql.Append(" where OrderID=@OrderID ");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderID", SqlDbType.Int,4)};
            parameters[0].Value = OrderID;

            DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public OrderInfo GetOrderInfoModel(int OrderID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 OrderID,oOrderNum,oType,StoresID,oCustomersName,oCustomersContact,oCustomersTel,oCustomersAddress,oCustomersOrderID,oCustomersNameB,StaffID,UserID,oAppendTime,oOrderDateTime,oState,oSteps,oPrepay,oReMake," +
                "(select tbStaffInfo.sName from tbStaffInfo where tbStaffInfo.StaffID=tbOrderInfo.StaffID) as StaffName,"+
                "(select tbUserInfo.uName from tbUserInfo where tbUserInfo.UserID=tbOrderInfo.UserID) as UserName," +
                "(case " +
                " when  tbOrderInfo.oType in(1,2) then " +
                " (select su.sName from tbSupplierInfo su where su.SupplierID=tbOrderInfo.StoresID) " +
                " when  tbOrderInfo.oType in(3,4,5,6,7,11) then " +
                " (select so.sName from tbStoresInfo so where so.StoresID=tbOrderInfo.StoresID) " +
                " when  tbOrderInfo.oType = 9 then " +
                " (select ss.sName from tbStorageInfo ss where ss.StorageID=tbOrderInfo.StoresID) " +
                " end) as StoresSupplierName, "+

                "(case " +
                " when  tbOrderInfo.oType in(1,2) then " +
                " (select su.sCode from tbSupplierInfo su where su.SupplierID=tbOrderInfo.StoresID) " +
                " when  tbOrderInfo.oType in(3,4,5,6,7,11) then " +
                " (select so.sCode from tbStoresInfo so where so.StoresID=tbOrderInfo.StoresID) " +
                " when  tbOrderInfo.oType = 9 then " +
                " (select ss.sCode from tbStorageInfo ss where ss.StorageID=tbOrderInfo.StoresID) " +
                " end) as StoresSupplierCode, " +

                "(select sso.PriceClassID from tbStoresInfo sso where sso.StoresID=tbOrderInfo.StoresID) PriceClassID," +
                "(select top 1 tbOrderWorkingLogInfo.pAppendTime from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.OrderID=tbOrderInfo.OrderID and tbOrderWorkingLogInfo.oType=6 order by tbOrderWorkingLogInfo.pAppendTime desc) as LastPrintDateTime " +
                "from tbOrderInfo ");
            strSql.Append(" where OrderID=@OrderID ");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderID", SqlDbType.Int,4)};
            parameters[0].Value = OrderID;

            OrderInfo model = new OrderInfo();
            DataSet ds = DbHelper.ExecuteDataset(CommandType.Text,strSql.ToString(),parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["OrderID"].ToString() != "")
                {
                    model.OrderID = int.Parse(ds.Tables[0].Rows[0]["OrderID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PriceClassID"].ToString() != "")
                {
                    model.PriceClassID = int.Parse(ds.Tables[0].Rows[0]["PriceClassID"].ToString());
                }
                model.oOrderNum = ds.Tables[0].Rows[0]["oOrderNum"].ToString();
                model.oReMake = ds.Tables[0].Rows[0]["oReMake"].ToString();
                if (ds.Tables[0].Rows[0]["oType"].ToString() != "")
                {
                    model.oType = int.Parse(ds.Tables[0].Rows[0]["oType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["StoresID"].ToString() != "")
                {
                    model.StoresID = int.Parse(ds.Tables[0].Rows[0]["StoresID"].ToString());
                }
                model.oCustomersName = ds.Tables[0].Rows[0]["oCustomersName"].ToString();
                if (ds.Tables[0].Rows[0]["StoresID"].ToString() != "")
                {
                    model.StoresSupplierID = int.Parse(ds.Tables[0].Rows[0]["StoresID"].ToString());
                }
                model.StoresSupplierName = ds.Tables[0].Rows[0]["StoresSupplierName"].ToString();
                model.StoresSupplierCode = ds.Tables[0].Rows[0]["StoresSupplierCode"].ToString();

                model.oCustomersContact = ds.Tables[0].Rows[0]["oCustomersContact"].ToString();
                model.oCustomersTel = ds.Tables[0].Rows[0]["oCustomersTel"].ToString();
                model.oCustomersAddress = ds.Tables[0].Rows[0]["oCustomersAddress"].ToString();
                model.oCustomersOrderID = ds.Tables[0].Rows[0]["oCustomersOrderID"].ToString();
                model.oCustomersNameB = ds.Tables[0].Rows[0]["oCustomersNameB"].ToString();
                if (ds.Tables[0].Rows[0]["StaffID"].ToString() != "")
                {
                    model.StaffID = int.Parse(ds.Tables[0].Rows[0]["StaffID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserID"].ToString() != "")
                {
                    model.UserID = int.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
                }
                model.UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                model.StaffName = ds.Tables[0].Rows[0]["StaffName"].ToString();
                if (ds.Tables[0].Rows[0]["LastPrintDateTime"].ToString() != "")
                {
                    model.LastPrintDateTime = DateTime.Parse(ds.Tables[0].Rows[0]["LastPrintDateTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["oAppendTime"].ToString() != "")
                {
                    model.oAppendTime = DateTime.Parse(ds.Tables[0].Rows[0]["oAppendTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["oOrderDateTime"].ToString() != "")
                {
                    model.oOrderDateTime = DateTime.Parse(ds.Tables[0].Rows[0]["oOrderDateTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["oState"].ToString() != "")
                {
                    model.oState = int.Parse(ds.Tables[0].Rows[0]["oState"].ToString());
                }
                if (ds.Tables[0].Rows[0]["oSteps"].ToString() != "")
                {
                    model.oSteps = int.Parse(ds.Tables[0].Rows[0]["oSteps"].ToString());
                }
                if (ds.Tables[0].Rows[0]["oPrepay"].ToString() != "")
                {
                    model.oPrepay = int.Parse(ds.Tables[0].Rows[0]["oPrepay"].ToString());
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
        public DataSet GetOrderInfoList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select OrderID,oOrderNum,oType,StoresID,oCustomersName,oCustomersContact,oCustomersTel,oCustomersAddress,oCustomersOrderID,oCustomersNameB,StaffID,UserID,oAppendTime,oOrderDateTime,oState,oSteps,oPrepay,(case " +
                " when  tbOrderInfo.oType in(1,2) then " +
                " (select su.sName from tbSupplierInfo su where su.SupplierID=tbOrderInfo.StoresID) " +
                " when  tbOrderInfo.oType in(3,4,5,6,7,11) then " +
                " (select so.sName from tbStoresInfo so where so.StoresID=tbOrderInfo.StoresID) " +
                " when  tbOrderInfo.oType =9 then " +
                " (select ss.sName from tbStorageInfo ss where ss.StorageID=tbOrderInfo.StoresID) " +
                " end) as StoresSupplierName," +
                "isnull((case when tbOrderInfo.oType in(2,4) then -1 else 1 end)*(select sum(isnull(ol.oMoney,0)) from tbOrderListInfo ol where ol.OrderID=tbOrderInfo.OrderID and ol.oWorkType=(select max(oll.oWorkType) from tbOrderListInfo oll where oll.OrderID=tbOrderInfo.OrderID)),0) as SumMoney," +
                "(select s.sName from tbStaffInfo s where s.StaffID=tbOrderInfo.StaffID) as StaffName," +
                "(select u.uName from tbUserInfo u where u.UserID=tbOrderInfo.UserID) as UserName," +
                "(select top 1 us.sName from tbStaffInfo us where us.StaffID=(select top 1 StaffID from tbUserInfo where UserID=tbOrderInfo.UserID )) as UserStaffName," +
                "(select top 1 w.pAppendTime from tbOrderWorkingLogInfo w where w.OrderID=tbOrderInfo.OrderID and w.oType=6 order by pAppendTime desc) as PrintTime ");
            strSql.Append(" FROM tbOrderInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelper.ExecuteDataset(CommandType.Text,strSql.ToString());
        }
			
		/// <summary>
		/// OrderList查询条件下的所有子单据列表
		/// </summary>
		/// <returns>The order list by order where.</returns>
		/// <param name="strWhere">String where.</param>
		public DataSet GetOrderListByOrderWhere(string strWhere,bool getWorkType0)
		{
            string _getWorkTypeSQL = "";

            StringBuilder strSql = new StringBuilder();
			string _sql = "select OrderID FROM tbOrderInfo";
			if (strWhere.Trim() != "")
			{
				_sql = _sql + " where " + strWhere;
			}
            //取未审核单据
            if (getWorkType0)
            {
                _getWorkTypeSQL = " and oWorkType=0";
            }
            else {
                _getWorkTypeSQL = " and oWorkType<>0";
            }

			strSql.Append ("select _order.oOrderNum,"+
				" (case "+
				" when _order.oType = 1 then '采购入库' "+
				" when _order.oType = 2 then '采购退货' "+
				" when _order.oType = 3 then '销售发货' "+
				" when _order.oType = 4 then '销售退货' "+
				" when _order.oType = 5 then '赠品' "+
				" when _order.oType = 6 then '样品' "+
				" when _order.oType = 7 then '代购' "+
				" when _order.oType = 8 then '库存调整' "+
				" when _order.oType = 9 then '库存调拨' "+
				" end) as OrderType,"+
				" (case "+
				" when  _order.oType in(1,2) then " +
				" (select su.sName from tbSupplierInfo su where su.SupplierID=_order.StoresID) " +
				" when  _order.oType in(3,4,5,6,7,11) then " +
				" (select so.sName from tbStoresInfo so where so.StoresID=_order.StoresID) " +
				" when  _order.oType =9 then " +
				" (select ss.sName from tbStorageInfo ss where ss.StorageID=_order.StoresID) " +
				" end) as StoresSupplierName," +
				" _order.oCustomersContact,_order.oCustomersTel,_order.oCustomersAddress,_order.oCustomersOrderID,_order.oCustomersNameB,"+
				" _order.StaffName,_order.UserName,"+
				" _order.oAppendTime,_order.oOrderDateTime,"+
				" (case "+
				" when _order.oState = 0 then '正常' "+
				" when _order.oState = 1 then '作废' "+
			    " end) as oState,"+
				" (case "+
				" when _order.oSteps = 1 then '新单未审核' "+
				" when _order.oSteps = 2 then '新单已审核' "+
				" when _order.oSteps = 3 then '已发货' "+
				" when _order.oSteps = 4 then '已收货' "+
				" when _order.oSteps = 5 then '已核销' "+
				" when _order.oSteps = 6 then '对账中' "+
				" when _order.oSteps = 7 then '已对账' "+
				" when _order.oSteps = 8 then '完成收付款' "+
				" when _order.oSteps = 9 then '已结账' "+
				" end) as oSteps,"+
                " olist.StorageName,olist.IsGifts, olist.ProductsName,olist.ProductsBarcode,olist.ProductsToBoxNo,olist.ProductsUnits,olist.ProductsMaxUnits,olist.oQuantity,olist.oPrice,olist.oMoney" +
				" from ");
			strSql.Append("(select OrderID,oOrderNum,oType,StoresID,oCustomersName,oCustomersContact,oCustomersTel,oCustomersAddress,oCustomersOrderID,oCustomersNameB,StaffID,UserID,oAppendTime,oOrderDateTime,oState,oSteps,oPrepay,"+
				"(case " +
				" when  tbOrderInfo.oType in(1,2) then " +
				" (select su.sName from tbSupplierInfo su where su.SupplierID=tbOrderInfo.StoresID) " +
				" when  tbOrderInfo.oType in(3,4,5,6,7,11) then " +
				" (select so.sName from tbStoresInfo so where so.StoresID=tbOrderInfo.StoresID) " +
				" when  tbOrderInfo.oType =9 then " +
				" (select ss.sName from tbStorageInfo ss where ss.StorageID=tbOrderInfo.StoresID) " +
				" end) as StoresSupplierName," +
				"isnull((case when tbOrderInfo.oType in(2,4) then -1 else 1 end)*(select sum(isnull(ol.oMoney,0)) from tbOrderListInfo ol where ol.OrderID=tbOrderInfo.OrderID and ol.oWorkType=(select max(oll.oWorkType) from tbOrderListInfo oll where oll.OrderID=tbOrderInfo.OrderID)),0) as SumMoney," +
				"(select s.sName from tbStaffInfo s where s.StaffID=tbOrderInfo.StaffID) as StaffName," +
				"(select u.uName from tbUserInfo u where u.UserID=tbOrderInfo.UserID) as UserName," +
				"(select top 1 us.sName from tbStaffInfo us where us.StaffID=(select top 1 StaffID from tbUserInfo where UserID=tbOrderInfo.UserID )) as UserStaffName," +
				"(select top 1 w.pAppendTime from tbOrderWorkingLogInfo w where w.OrderID=tbOrderInfo.OrderID and w.oType=6 order by pAppendTime desc) as PrintTime ");
			strSql.Append(" FROM tbOrderInfo ");
			if (strWhere.Trim() != "")
			{
				strSql.Append(" where " + strWhere);
			}
			strSql.Append(" ) as _order right join");

			strSql.Append ("(select OrderID,"+
				" StorageID,"+
				" ProductsID,"+
				" oQuantity,oPrice,oMoney,"+
				"(case when IsGifts<>0 then '赠品' else '' end) as IsGifts,"+
				"(select tbStorageInfo.sName from tbStorageInfo where tbStorageInfo.StorageID=tbOrderListInfo.StorageID ) as  StorageName,"+
				"(select tbProductsInfo.pName from tbProductsInfo where tbProductsInfo.ProductsID=tbOrderListInfo.ProductsID) as ProductsName,"+
				"(select tbProductsInfo.pBarcode from tbProductsInfo where tbProductsInfo.ProductsID=tbOrderListInfo.ProductsID) as ProductsBarcode,"+
				"(select tbProductsInfo.pToBoxNo from tbProductsInfo where tbProductsInfo.ProductsID=tbOrderListInfo.ProductsID) as ProductsToBoxNo,"+
				"(select tbProductsInfo.pUnits from tbProductsInfo where tbProductsInfo.ProductsID=tbOrderListInfo.ProductsID) as ProductsUnits,"+
				"(select tbProductsInfo.pMaxUnits from tbProductsInfo where tbProductsInfo.ProductsID=tbOrderListInfo.ProductsID) as ProductsMaxUnits "+
				" from tbOrderListInfo where OrderID in("+_sql+") "+ _getWorkTypeSQL + " ) as olist");
			strSql.Append (" on _order.OrderID = olist.OrderID");

				//throw(new System.Exception(strSql.ToString()));
			
			return DbHelper.ExecuteDataset(CommandType.Text,strSql.ToString());
		}

        /// <summary>
        /// 返回当前各种单据基础统计信息
        /// </summary>
        /// <returns></returns>
        public DataSet GetOrderStateList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select (select COUNT(0) from tbOrderInfo where oState=0 and oSteps=1  and  oType  in (3,4,5,6,7)) as steps_s_a," +//销售开单
                                    "(select COUNT(0) from tbOrderInfo where oState=0 and oSteps=2 and oType  in (3,4,5,6,7)) as steps_s_b," +//销售已审核
                                    "(select COUNT(0) from tbOrderInfo where oState=0 and oSteps=3 and oType  in (3,4,5,6,7)) as steps_s_c," +//销售已发货
                                    "(select COUNT(0) from tbOrderInfo where oState=0 and oSteps=4 and oType  in (3,4,5,6,7)) as steps_s_d," +//销售已收货

                                    "(select COUNT(0) from tbOrderInfo where oState=0 and oSteps=1  and  oType  in (1,2)) as steps_c_a," +//采购开单
                                    "(select COUNT(0) from tbOrderInfo where oState=0 and oSteps=2 and oType  in (1,2)) as steps_c_b," +//采购已审核
                                    "(select COUNT(0) from tbOrderInfo where oState=0 and oSteps=3 and oType  in (1,2)) as steps_c_c," +//采购已发货
                                    "(select COUNT(0) from tbOrderInfo where oState=0 and oSteps=4 and oType  in (1,2)) as steps_c_d," +//采购已收货

                                    "(select COUNT(0) from tbOrderInfo where oState=0 and oSteps=1  and  oType  in (1,2)) as steps_c_a," +//采购开单
                                    "(select COUNT(0) from tbOrderInfo where oState=0 and oSteps=2 and oType  in (1,2)) as steps_c_b," +//采购已审核
                                    "(select COUNT(0) from tbOrderInfo where oState=0 and oSteps=3 and oType  in (1,2)) as steps_c_c," +//采购已发货
                                    "(select COUNT(0) from tbOrderInfo where oState=0 and oSteps=4 and oType  in (1,2)) as steps_c_d," +//采购已收货

                                    "(select COUNT(0) from tbOrderInfo where oState=0 and oSteps=1  and  oType =8) as steps_k_t_a," +//库存调整开单
                                    "(select COUNT(0) from tbOrderInfo where oState=0 and oSteps=2 and oType =8) as steps_k_t_b," +//库存调整已审核
                                    "(select COUNT(0) from tbOrderInfo where oState=0 and oSteps=3 and oType =8) as steps_k_t_c," +//库存调整已发货
                                    "(select COUNT(0) from tbOrderInfo where oState=0 and oSteps=4 and oType =8) as steps_k_t_d," +//库存调整已收货

                                    "(select COUNT(0) from tbOrderInfo where oState=0 and oSteps=1  and  oType =9) as steps_k_d_a," +//库存调拨开单
                                    "(select COUNT(0) from tbOrderInfo where oState=0 and oSteps=2 and oType =9) as steps_k_d_b," +//库存调拨已审核
                                    "(select COUNT(0) from tbOrderInfo where oState=0 and oSteps=3 and oType =9) as steps_k_d_c," +//库存调拨已发货
                                    "(select COUNT(0) from tbOrderInfo where oState=0 and oSteps=4 and oType =9) as steps_k_d_d," +//库存调拨已收货

                                     "(select COUNT(0) from tbOrderInfo where oState=0 and oSteps=1  and  oType =10) as steps_k_b_a," +//库存报损开单
                                    "(select COUNT(0) from tbOrderInfo where oState=0 and oSteps=2 and oType =10) as steps_k_b_b," +//库存报损已审核
                                    "(select COUNT(0) from tbOrderInfo where oState=0 and oSteps=3 and oType =10) as steps_k_b_c," +//库存报损已发货
                                    "(select COUNT(0) from tbOrderInfo where oState=0 and oSteps=4 and oType =10) as steps_k_b_d," +//库存报损已收货

                                    "(select COUNT(0) from tbOrderInfo where oState=0 and oSteps=5 and oType<>11 and oType in(3,4,5,6,7,10)) as steps_e," +
                                    "(select COUNT(0) from tbOrderInfo where oState=0 and oSteps=5 and oType<>11 and oType in(1,2)) as steps_eb," +
                                    "(select COUNT(0) from tbOrderInfo where oState=0 and oSteps=6 and oType<>11) as steps_f," +
                                    "(select COUNT(0) from tbOrderInfo where oState=0 and oSteps=7 and oType<>11) as steps_g," +
                                    "(select COUNT(0) from(select distinct ooool.OrderID from ( " +
                                    "select oool.ProductsID,oool.OrderID,SUM(oool.oQuantity) as oQuantity,SUM(oool.oldQuantity) as oldQuantity from ( " +
                                    "select  osl.ProductsID,osl.OrderListID, osl.OrderID,osl.oQuantity,oosl.oQuantity as oldQuantity from  " +
                                    "(select ol.ProductsID,ol.OrderListID,ol.OrderID, ol.oQuantity,ol.StorageID from tbOrderListInfo as ol where ol.oWorkType<>0) as osl left join " +
                                    "(select ool.oQuantity,ool.ProductsID,ool.StorageID,ool.OrderID from tbOrderListInfo as ool where ool.oWorkType=0) as oosl on osl.ProductsID = oosl.ProductsID and osl.OrderID=oosl.OrderID and osl.StorageID=oosl.StorageID " +
                                    ") as oool " +
                                    "group by oool.ProductsID,oool.OrderID " +
                                    ") as ooool where ooool.oQuantity<>ooool.oldQuantity and ooool.OrderID in(select o.OrderID from tbOrderInfo as o where o.oSteps not in(1,2,3) and o.OrderID not in(select OrderID from tbOrderNOFullInfo where oState=0) and o.oType in(1,2,3,4,5,6,7,10)) ) as oc ) as steps_h,"+
                                    "(select count(0) from (select distinct OrderID from tbOrderNOFullInfo where oNextOrderID=0) as tnofull) as steps_i ,"+
                                    "(select COUNT(0) from tbOrderInfo where oState=0 and oSteps=1 and oType=11) as steps_aa," +
                                    "(select COUNT(0) from tbOrderInfo where oState=0 and oSteps=2  and oType=11) as steps_bb," +
                                    "(select COUNT(0) from tbOrderInfo where oState=0 and oSteps=3  and oType=11) as steps_cc," +
                                    "(select COUNT(0) from tbOrderInfo where oState=0 and oSteps=4  and oType=11) as steps_dd," +
                                    "(select COUNT(0) from tbOrderInfo where oState=0 and oSteps=5  and oType=11) as steps_ee,"+
                                    "(select COUNT(0) from tbOrderInfo where oState=0 and oSteps=1  and oType in (1,2) ) as steps_j,"+
                                    "(select COUNT(0) from tbOrderInfo where oState=0 and oSteps=2  and oType in (1,2) and oPrepay=1 ) as steps_k,"+

                                    "(select count(0) from tbMonthlyStatementInfo where sType=2 and sSteps=0 and sState=0) as steps_l,"+                                        //应收新建
                                    "(select count(0) from tbMonthlyStatementInfo where sType=2 and sSteps=1 and sState=0) as steps_la," +                                      //应收已对账
                                    "(select count(0) from tbMonthlyStatementInfo where sType=2 and sSteps=2 and sState=0) as steps_ld," +                                      //应收以到款
                                    "(select count(0) from tbMonthlyStatementInfo where sType=2 and sSteps=1 and isnull((select sum(mMoney) from tbMonthlyStatementAppendMoneyDataInfo where MonthlyStatementID=tbMonthlyStatementInfo.MonthlyStatementID and mState=0),0)!=sThisMoney and sState=0) as steps_lb," +  //应收已结账有余款
                                    "(select count(0) from tbMonthlyStatementInfo where sType=2 and sSteps=3 and sState=0) as steps_lc," +                                      //应收已结账

                                    "(select count(0) from tbMonthlyStatementInfo where sType=1 and sSteps=0 and sState=0) as steps_m,"+                                        //应付新建
                                    "(select count(0) from tbMonthlyStatementInfo where sType=1 and sSteps=1 and sState=0) as steps_ma,"+                                       //应付已对账
                                    "(select count(0) from tbMonthlyStatementInfo where sType=1 and sSteps=2 and sState=0) as steps_md," +                                      //应付已到款
                                    "(select count(0) from tbMonthlyStatementInfo where sType=1 and sSteps=1 and isnull((select sum(mMoney) from tbMonthlyStatementAppendMoneyDataInfo where MonthlyStatementID=tbMonthlyStatementInfo.MonthlyStatementID and mState=0),0)!=sThisMoney and sState=0) as steps_mb," +   //应付已结账有余款
                                    "(select count(0) from tbMonthlyStatementInfo where sType=1 and sSteps=3 and sState=0) as steps_mc");                                        //应收已结账
            

            return DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString());
        }

        /// <summary>
        /// 验证指定单据是否为全额收货
        /// </summary>
        /// <param name="OrderID"></param>
        /// <returns></returns>
        public bool CheckOrderIsFull(int OrderID)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("select count(ooool.OrderID) from ( "+
                                    "select oool.ProductsID,oool.OrderID,SUM(oool.oQuantity) as oQuantity,SUM(oool.oldQuantity) as oldQuantity from ( "+
                                    "select osl.ProductsID,osl.OrderListID, osl.OrderID,osl.oQuantity,oosl.oQuantity as oldQuantity from  "+
                                    "(select ol.ProductsID,ol.OrderListID,ol.OrderID, ol.oQuantity,ol.StorageID from tbOrderListInfo as ol where ol.oWorkType<>0 and ol.OrderID=@OrderID) as osl left join " +
                                    "(select ool.oQuantity,ool.ProductsID,ool.StorageID,ool.OrderID from tbOrderListInfo as ool where ool.oWorkType=0 and ool.OrderID=@OrderID) as oosl on osl.ProductsID = oosl.ProductsID and osl.OrderID=oosl.OrderID and osl.StorageID=oosl.StorageID " +
                                    ") as oool group by oool.ProductsID,oool.OrderID " +
                                    ") as ooool where ooool.oQuantity<>ooool.oldQuantity and ooool.OrderID=@OrderID and ooool.OrderID in(select o.OrderID from tbOrderInfo as o where o.oSteps not in(1,2,3) and o.OrderID not in(select OrderID from tbOrderNOFullInfo where oState=0) and o.oType in(1,2,3,4,5,6,7,10))");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderID", SqlDbType.Int,4)};
            parameters[0].Value = OrderID;

            return ((int)DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters)) > 0;

        }

        /// <summary>
        /// 返回非全额收货单据体
        /// </summary>
        /// <param name="OrderID"></param>
        /// <returns></returns>
        public DataTable GetOrderNOFullList(int OrderID)
        {
            DataTable dt = new DataTable();
            StringBuilder strSql = new StringBuilder();

            strSql.Append("select s.StorageID,s.sName,op.ProductsID,op.pBarcode,op.pName,op.oQuantity,op.oldQuantity from tbStorageInfo s right join ( "+
                                    "select p.ProductsID,p.pBarcode,p.pName,o.StorageID,o.oQuantity,o.oldQuantity from tbProductsInfo p right join ( "+
                                    "select ol.ProductsID,ol.StorageID,SUM(ol.oQuantity) oQuantity,SUM(ool.oQuantity) oldQuantity from tbOrderListInfo ol left join tbOrderListInfo ool  "+
                                    "on ol.OrderID=ool.OrderID and ol.StorageID=ool.StorageID and ol.ProductsID=ool.ProductsID   "+
                                    " where ol.oWorkType<>0 and ool.oWorkType=0 and ol.OrderID=@OrderID group by ol.ProductsID,ol.StorageID) as o  " +
                                    " on p.ProductsID = o.ProductsID) op on s.StorageID=op.StorageID");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderID", SqlDbType.Int,4)};
            parameters[0].Value = OrderID;

            return DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(), parameters).Tables[0]; 
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetOrderInfoList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" OrderID,oOrderNum,oType,StoresID,oCustomersName,oCustomersContact,oCustomersTel,oCustomersAddress,oCustomersOrderID,oCustomersNameB,StaffID,UserID,oAppendTime,oOrderDateTime,oState,oSteps,oPrepay,(case " +
                " when  tbOrderInfo.oType in(1,2) then " +
                " (select su.sName from tbSupplierInfo su where su.SupplierID=tbOrderInfo.StoresID) " +
                " when  tbOrderInfo.oType in(3,4,5,6,7,11) then " +
                " (select so.sName from tbStoresInfo so where so.StoresID=tbOrderInfo.StoresID) " +
                 " when  tbOrderInfo.oType = 9 then " +
                " (select ss.sName from tbStorageInfo ss where ss.StorageID=tbOrderInfo.StoresID) " +
                " end) as StoresSupplierName," +
                "isnull((case when tbOrderInfo.oType in(2,4) then -1 else 1 end)*(select sum(isnull(ol.oMoney,0)) from tbOrderListInfo ol where ol.OrderID=tbOrderInfo.OrderID and ol.oWorkType=(select max(oll.oWorkType) from tbOrderListInfo oll where oll.OrderID=tbOrderInfo.OrderID)),0) as SumMoney," +
                "(select s.sName from tbStaffInfo s where s.StaffID=tbOrderInfo.StaffID) as StaffName," +
                "(select u.uName from tbUserInfo u where u.UserID=tbOrderInfo.UserID) as UserName," +
                "(select top 1 us.sName from tbStaffInfo us where us.StaffID=(select top 1 StaffID from tbUserInfo where UserID=tbOrderInfo.UserID )) as UserStaffName," +
                "(select top 1 w.pAppendTime from tbOrderWorkingLogInfo w where w.OrderID=tbOrderInfo.OrderID and w.oType=6 order by pAppendTime desc) as PrintTime ");
            strSql.Append(" FROM tbOrderInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelper.ExecuteDataset(CommandType.Text,strSql.ToString());
        }

        /// <summary>
        /// 取单据总金额
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public decimal GetOrderSumMoney(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select sum(sss.SumMoney) from (");
            strSql.Append("select isnull((case when tbOrderInfo.oType in(2,4) then -1 else 1 end)*(select sum(isnull(ol.oMoney,0)) from tbOrderListInfo ol where ol.OrderID=tbOrderInfo.OrderID and ol.oWorkType=(select max(oll.oWorkType) from tbOrderListInfo oll where oll.OrderID=tbOrderInfo.OrderID)),0) as SumMoney from tbOrderInfo where " + strWhere + ") as sss");

            object reobj = DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString());
            if (reobj != null)
            {
                try
                {
                    return Convert.ToDecimal(reobj);
                }
                catch {
                    return 0;
                }
            }
            else {
                return 0;
            }
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataTable GetOrderInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,2000),
                    new SqlParameter("@showFName", SqlDbType.VarChar,2550),
                    
                    };
            parameters[0].Value = "tbOrderInfo";
            parameters[1].Value = "OrderID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 1;
            parameters[5].Value = OrderType;
            parameters[6].Value = strWhere;
            parameters[7].Value = showFName + ",(case " +
                " when  tbOrderInfo.oType in(1,2) then " +
                " (select su.sName from tbSupplierInfo su where su.SupplierID=tbOrderInfo.StoresID) " +
                " when  tbOrderInfo.oType in(3,4,5,6,7,11) then " +
                " (select so.sName from tbStoresInfo so where so.StoresID=tbOrderInfo.StoresID) " +
                 " when  tbOrderInfo.oType = 9  then " +
                " (select ss.sName from tbStorageInfo ss where ss.StorageID=tbOrderInfo.StoresID) " +
                " end) as StoresSupplierName," +
                "isnull((select sum(isnull(ol.oMoney,0)) from tbOrderListInfo ol where ol.OrderID=tbOrderInfo.OrderID and ol.oWorkType=(select max(oll.oWorkType) from tbOrderListInfo oll where oll.OrderID=tbOrderInfo.OrderID))*(case when tbOrderInfo.oType in(2,4) then -1 else 1 end),0) as SumMoney," +
                "(select s.sName from tbStaffInfo s where s.StaffID=tbOrderInfo.StaffID) as StaffName," +
                "(select u.uName from tbUserInfo u where u.UserID=tbOrderInfo.UserID) as UserName," +
                "(select top 1 us.sName from tbStaffInfo us where us.StaffID=(select top 1 StaffID from tbUserInfo where UserID=tbOrderInfo.UserID )) as UserStaffName," +
                "(select top 1 w.pAppendTime from tbOrderWorkingLogInfo w where w.OrderID=tbOrderInfo.OrderID and w.oType=6 order by pAppendTime desc) as PrintTime";

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

        public DataTable GetOrderInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName, string filedOrder, string OrderfldName)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,2000),
                    new SqlParameter("@showFName", SqlDbType.VarChar,2550),
                    new SqlParameter("@OrderfldName", SqlDbType.VarChar, 255),
                    };
            parameters[0].Value = "tbOrderInfo";
            parameters[1].Value = filedOrder;
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 1;
            parameters[5].Value = OrderType;
            parameters[6].Value = strWhere;
            parameters[7].Value = showFName + ",(case " +
                " when  tbOrderInfo.oType in(1,2) then " +
                " (select su.sName from tbSupplierInfo su where su.SupplierID=tbOrderInfo.StoresID) " +
                " when  tbOrderInfo.oType in(3,4,5,6,7,11) then " +
                " (select so.sName from tbStoresInfo so where so.StoresID=tbOrderInfo.StoresID) " +
                 " when  tbOrderInfo.oType  = 9 then " +
                " (select ss.sName from tbStorageInfo ss where ss.StorageID=tbOrderInfo.StoresID) " +
                " end) as StoresSupplierName," +
                "isnull((select sum(isnull(ol.oMoney,0)) from tbOrderListInfo ol where ol.OrderID=tbOrderInfo.OrderID and ol.oWorkType=(select max(oll.oWorkType) from tbOrderListInfo oll where oll.OrderID=tbOrderInfo.OrderID))*(case when tbOrderInfo.oType in(2,4) then -1 else 1 end),0) as SumMoney," +
                "(select s.sName from tbStaffInfo s where s.StaffID=tbOrderInfo.StaffID) as StaffName," +
                "(select u.uName from tbUserInfo u where u.UserID=tbOrderInfo.UserID) as UserName," +
                "(select top 1 us.sName from tbStaffInfo us where us.StaffID=(select top 1 StaffID from tbUserInfo where UserID=tbOrderInfo.UserID )) as UserStaffName," +
                "(select top 1 w.pAppendTime from tbOrderWorkingLogInfo w where w.OrderID=tbOrderInfo.OrderID and w.oType=6 order by pAppendTime desc) as PrintTime";
            parameters[8].Value = OrderfldName;

            DataSet ds = DbHelper.ExecuteDataset(CommandType.StoredProcedure, "sp_" + BaseConfigs.GetTablePrefix + "getorderlist", parameters);
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
        public DataTable GetOrderInfoList_xp(int PageSize, int PageIndex, string strWhere, out int pagetotal, string OrderfldName)
        {

            SqlParameter[] parameters = {
                    new SqlParameter("@Page", SqlDbType.Int),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@OrderBy", SqlDbType.NVarChar, 100),
                    new SqlParameter("@Filter", SqlDbType.NVarChar, 2000),
                                         };
            parameters[0].Value = PageIndex;
            parameters[1].Value = PageSize;
            parameters[2].Value = OrderfldName;
            parameters[3].Value = strWhere;
            DataSet ds = DbHelper.ExecuteDataset(CommandType.StoredProcedure, "sp_" + BaseConfigs.GetTablePrefix + "getorderlist", parameters);
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
        /// 返回单据合计金额
        /// </summary>
        /// <param name="OrderID"></param>
        /// <returns></returns>
        public decimal GetOrderSumMoney(int OrderID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select sum(isnull(ol.oMoney,0)*(case when o.oType in(2,4) then -1 else 1 end)) from tbOrderListInfo ol left join tbOrderInfo as o on ol.OrderID=o.OrderID where ol.oWorkType=(select max(oll.oWorkType) from tbOrderListInfo oll where oll.OrderID=o.OrderID and o.OrderID=@OrderID)");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderID", SqlDbType.Int,4),
                                        };
            parameters[0].Value = OrderID;
            object obj = DbHelper.ExecuteScalar(CommandType.Text,strSql.ToString(),parameters);
            if(obj!=null)
            {
                try{
                    return Convert.ToDecimal(obj.ToString());
                }catch{
                    return 0;
                }
            }else{
                return 0;
            }
        }

        /// <summary>
        /// 取单据的操作员,人员,打印时间,合计数 等信息
        /// </summary>
        /// <param name="OrderID"></param>
        /// <returns></returns>
        public string[] GetOrderOtherInfo(int OrderID)
        {
            string[] re = new string[6];
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select (case "+
            "when  tbOrderInfo.oType in(1,2) then  (select su.sName from tbSupplierInfo su where su.SupplierID=tbOrderInfo.StoresID)  "+
            "when  tbOrderInfo.oType in(3,4,5,6,7,11) then  (select so.sName from tbStoresInfo so where so.StoresID=tbOrderInfo.StoresID)  end) as StoresSupplierName,"+
            "isnull((select sum(isnull(ol.oMoney,0)) from tbOrderListInfo ol where ol.OrderID=tbOrderInfo.OrderID and ol.oWorkType=(select max(oll.oWorkType) from tbOrderListInfo oll where oll.OrderID=tbOrderInfo.OrderID))*(case when tbOrderInfo.oType in(2,4) then -1 else 1 end),0) as SumMoney,"+
            "(select s.sName from tbStaffInfo s where s.StaffID=tbOrderInfo.StaffID) as StaffName,"+
            "(select u.uName from tbUserInfo u where u.UserID=tbOrderInfo.UserID) as UserName,"+
            "(select top 1 us.sName from tbStaffInfo us where us.StaffID=(select top 1 StaffID from tbUserInfo where UserID=tbOrderInfo.UserID )) as UserStaffName,"+
            "(select top 1 w.pAppendTime from tbOrderWorkingLogInfo w where w.OrderID=tbOrderInfo.OrderID and w.oType=6 order by pAppendTime desc) as PrintTime from tbOrderInfo where OrderID=@OrderID");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderID", SqlDbType.Int,4),
                                        };
            parameters[0].Value = OrderID;

            DataSet ds = DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(), parameters);
            if (ds != null)
            {
                if (ds.Tables[0] != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        re[0] = ds.Tables[0].Rows[0]["StoresSupplierName"].ToString();
                        re[1] = ds.Tables[0].Rows[0]["SumMoney"].ToString();
                        re[2] = ds.Tables[0].Rows[0]["StaffName"].ToString();
                        re[3] = ds.Tables[0].Rows[0]["UserName"].ToString();
                        re[4] = ds.Tables[0].Rows[0]["UserStaffName"].ToString();
                        re[5] = ds.Tables[0].Rows[0]["PrintTime"].ToString();
                    }
                }
            }
            return re;
        }

        /// <summary>
        /// 进销存报表
        /// </summary>
        /// <param name="ProductsID"></param>
        /// <param name="StorageID"></param>
        /// <param name="sDate">选择的时间点</param>
        /// <param name="ReType">返回类型,月表=1,年表=2,区间 =3</param>
        /// <param name="DataType">返回表类型,1存档记录,2实算记录</param>
        /// <param name="sDataType">统计数据方式,0=取上期结存成本,1=取本期发生成本</param>
        /// <returns></returns>
        public DataTable GetInvoicingReport(int ProductsID, int StorageID, DateTime sDate, int ReType, out int DataType, int sDataType)
        { 
            return GetInvoicingReport( ProductsID,  StorageID,  sDate,  ReType, out  DataType,  sDataType,DateTime.Now);
        }
        public DataTable GetInvoicingReport(int ProductsID, int StorageID,DateTime sDate,int ReType,out int DataType,int sDataType,DateTime eDate)
        {
            bool GetLog = false;
            //是否取存档记录
            if (ReType == 1 || ReType == 2)
            {
                if (sDate.Year == DateTime.Now.Year)
                {
                    if (sDate.Month < DateTime.Now.Month)
                    {
                        if (ReType == 1)
                        {
                            GetLog = true;
                        }
                    }
                }
                else if (sDate.Year < DateTime.Now.Year)
                {
                    GetLog = true;
                }
            }
            else {
                if (ReType != 3)
                {
                    GetLog = true;
                }
            }

            SqlParameter[] parameters = {
                    new SqlParameter("@dT", SqlDbType.DateTime),
                     new SqlParameter("@ProductsID", SqlDbType.Int,4),
                      new SqlParameter("@StorageID", SqlDbType.Int,4),
                       new SqlParameter("@ReType", SqlDbType.Int,4),
                       new SqlParameter("@sDataType",SqlDbType.Int,4),
                       new SqlParameter("@edT", SqlDbType.DateTime),
                                        };
            parameters[0].Value = sDate;
            parameters[1].Value = ProductsID;
            parameters[2].Value = StorageID;
            parameters[3].Value = ReType;
            parameters[4].Value = sDataType;
            parameters[5].Value = eDate;

            /**/
            //GetLog = false;

            if (GetLog)
            {
                //取历史存档记录
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select r.ReportInvoicingID,p.ProductsID,p.pBarcode,p.pName,p.pToBoxNo,p.pPrice,r.StorageID,r.bQuantity,r.InQuantity,r.OutQuantity,r.eQuantity,r.BadQuantity,r.rType,r.rDateTime,r.rBDateTime,r.rEdateTime,r.bMoney,r.InMoney,r.OutMoney,r.eMoney,r.BadMoney from tbReportInvoicingDataInfo r left join tbProductsInfo p on p.ProductsID=r.ProductsID ");

                switch (ReType)
                {
                    case 0://日
                        strSql.Append(" where rbdatetime>=convert(datetime,convert(varchar,DATEPART(year,@dT))+'-'+convert(varchar,DATEPART(month,@dT))+'-'+convert(varchar,DATEPART(day,@dT))+' 00:00:00') and redatetime<=convert(datetime,convert(varchar,DATEPART(year,@dT))+'-'+convert(varchar,DATEPART(month,@dT))+'-'+convert(varchar,DATEPART(day,@dT))+' 23:59:59') and rType=0 ");
                        break;
                    case 1://月
                        strSql.Append(" where rbdatetime>=dateadd(dd,-datepart(dd,@dT)+1,@dT) and redatetime<=convert(datetime,convert(varchar(10),dateadd(day,-1,dateadd(month,1,@dT-day(@dT)+1)),23)+' 23:59:59') and rType=1 ");
                        break;
                    case 2://年
                        strSql.Append(" where rbdatetime>=DATEADD(year, DATEDIFF(year, '', @dT), '') and redatetime<=dateadd(ms,-3,DATEADD(yy, DATEDIFF(yy,0,@dT)+1, 0)) and rType=2 ");
                        break;
                }
                if (ProductsID > 0)
                {
                    strSql.Append(" and ProductsID=@ProductsID ");
                }
                if (StorageID > 0)
                {
                    strSql.Append(" and StorageID = @StorageID ");
                }
                DataTable dt = new DataTable();
                
                dt = DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(), parameters).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    DataType = 1;
                    return dt;
                }
                else
                {
                    DataType = 2;
                    return DbHelper.ExecuteDataset(CommandType.StoredProcedure, "sp_" + BaseConfigs.GetTablePrefix + "GetInvoicingReport", parameters).Tables[0];
                }
            }
            else {
                DataType = 2;
                return DbHelper.ExecuteDataset(CommandType.StoredProcedure, "sp_" + BaseConfigs.GetTablePrefix + "GetInvoicingReport", parameters).Tables[0];
            }
        }

        #region ReportInvoicingDataInfo
        /// <summary>
        /// 返回产品进销存缓存数据
        /// </summary>
        /// <param name="StorageID"></param>
        /// <param name="ProductsID"></param>
        /// <param name="sDate"></param>
        /// <param name="rType"></param>
        /// <returns></returns>
        public DataTable GetReportInvoicingDataInfoList(int StorageID, int ProductsID, DateTime sDate, int rType)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select r.ReportInvoicingID,p.ProductsID,p.pBarcode,p.pName,p.pToBoxNo,p.pPrice,r.StorageID,r.bQuantity,r.InQuantity,r.OutQuantity,r.eQuantity,r.BadQuantity,r.rType,r.rDateTime,r.rBDateTime,r.rEdateTime,r.bMoney,r.InMoney,r.OutMoney,r.eMoney,r.BadMoney from tbReportInvoicingDataInfo r left join tbProductsInfo p on p.ProductsID=r.ProductsID ");
            switch (rType)
            {
                case 0://日
                    strSql.Append(" where rbdatetime>=convert(datetime,convert(varchar,DATEPART(year,@dT))+'-'+convert(varchar,DATEPART(month,@dT))+'-'+convert(varchar,DATEPART(day,@dT))+' 00:00:00') and redatetime<=convert(datetime,convert(varchar,DATEPART(year,@dT))+'-'+convert(varchar,DATEPART(month,@dT))+'-'+convert(varchar,DATEPART(day,@dT))+' 23:59:59') and rType=0 ");
                    break;
                case 1://月
                    strSql.Append(" where rbdatetime>=dateadd(dd,-datepart(dd,@dT)+1,@dT) and redatetime<=convert(datetime,convert(varchar(10),dateadd(day,-1,dateadd(month,1,@dT-day(@dT)+1)),23)+' 23:59:59') and rType=1 ");
                    break;
                case 2://年
                    strSql.Append(" where rbdatetime>=DATEADD(year, DATEDIFF(year, '', @dT), '') and redatetime<=dateadd(ms,-3,DATEADD(yy, DATEDIFF(yy,0,@dT)+1, 0)) and rType=2 ");
                    break;
            }
            if (ProductsID > 0)
            {
                strSql.Append(" and ProductsID=@ProductsID ");
            }
            if (StorageID > 0)
            {
                strSql.Append(" and StorageID = @StorageID ");
            }
            strSql.Append(" order by r.ProductClassID,r.ProductsID desc");
            SqlParameter[] parameters = {
                    new SqlParameter("@dT", SqlDbType.DateTime),
                     new SqlParameter("@ProductsID", SqlDbType.Int,4),
                      new SqlParameter("@StorageID", SqlDbType.Int,4),
                       new SqlParameter("@rType", SqlDbType.Int,4),
             };
            parameters[0].Value = sDate;
            parameters[1].Value = ProductsID;
            parameters[2].Value = StorageID;
            parameters[3].Value = rType;

            return DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(), parameters).Tables[0];
        }

        /// <summary>
        /// 重置进销存数据,已加一天
        /// </summary>
        /// <param name="sDate"></param>
        /// <returns></returns>
        public bool ReSetInvoicingData(DateTime sDate)
        {
            try
            {
                sDate = sDate.AddDays(1);
                StringBuilder strSql = new StringBuilder();
                strSql.Append("delete tbReportInvoicingDataInfo where rDateTime>=@sDate;");

                SqlParameter[] parameters = {
                    new SqlParameter("@sDate", SqlDbType.DateTime,8),
                };
                parameters[0].Value = sDate;

                if (DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters) > 0)
                {
                    SqlParameter[] parameters_b = {
                     new SqlParameter("@dT", SqlDbType.DateTime,8),
                    };

                    for (int i = 0; i < (DateTime.Now - sDate).Days; i++)
                    {

                        parameters_b[0].Value = sDate.AddDays(i);

                        DataSet ds = DbHelper.ExecuteDataset(CommandType.StoredProcedure, "sp_" + BaseConfigs.GetTablePrefix + "DayReportInvoicing", parameters_b);
                    }
                }
                return true;
            }
            catch {
                return false;
            }
        }

        /// <summary>
        /// 更新进销存数据结存数据
        /// </summary>
        /// <param name="eQuantity"></param>
        /// <param name="eMoney"></param>
        /// <param name="ReportInvoicingID"></param>
        /// <returns></returns>
        public bool UpdateReportInvoicingDataInfoByEndData(decimal eQuantity, decimal eMoney, int ReportInvoicingID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update  tbReportInvoicingDataInfo set eQuantity=@eQuantity,eMoney=@eMoney where ReportInvoicingID=@ReportInvoicingID");
            SqlParameter[] parameters = {
                    new SqlParameter("@eQuantity", SqlDbType.Decimal,6),
                    new SqlParameter("@eMoney", SqlDbType.Decimal,6),
                    new SqlParameter("@ReportInvoicingID", SqlDbType.Int,4),
                                        };
            parameters[0].Value = eQuantity;
            parameters[1].Value = eMoney;
            parameters[2].Value = ReportInvoicingID;

          return  DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters)>0;
        }
        /// <summary>
        /// 更新进销存数据结存数据
        /// </summary>
        /// <param name="eQuantity"></param>
        /// <param name="eMoney"></param>
        /// <param name="ReportInvoicingID"></param>
        /// <returns></returns>
        public bool UpdateReportInvoicingDataInfoByEndData(decimal eQuantity, decimal eMoney,decimal bQuantity,decimal bMoney,decimal InQuantity,decimal InMoney,decimal OutQuantity,decimal OutMoney, int ReportInvoicingID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update  tbReportInvoicingDataInfo set eQuantity=@eQuantity,eMoney=@eMoney,bQuantity=@bQuantity,bMoney=@bMoney,InQuantity=@InQuantity,InMoney=@InMoney,OutQuantity=@OutQuantity,OutMoney=@OutMoney where ReportInvoicingID=@ReportInvoicingID");
            SqlParameter[] parameters = {
                    new SqlParameter("@eQuantity", SqlDbType.Decimal,6),
                    new SqlParameter("@eMoney", SqlDbType.Decimal,6),
                    new SqlParameter("@bQuantity", SqlDbType.Decimal,6),
                    new SqlParameter("@bMoney", SqlDbType.Decimal,6),
                    new SqlParameter("@InQuantity", SqlDbType.Decimal,6),
                    new SqlParameter("@InMoney", SqlDbType.Decimal,6),
                    new SqlParameter("@OutQuantity", SqlDbType.Decimal,6),
                    new SqlParameter("@OutMoney", SqlDbType.Decimal,6),
                    new SqlParameter("@ReportInvoicingID", SqlDbType.Int,4),
                                        };
            parameters[0].Value = eQuantity;
            parameters[1].Value = eMoney;
            parameters[2].Value = bQuantity;
            parameters[3].Value = bMoney;
            parameters[4].Value = InQuantity;
            parameters[5].Value = InMoney;
            parameters[6].Value = OutQuantity;
            parameters[7].Value = OutMoney;
            parameters[8].Value = ReportInvoicingID;

            return DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters) > 0;
        }
        #endregion

        #endregion

        #region OrderList
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistsOrderListInfo(int OrderID, int StorageID, int ProductsID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tbOrderListInfo");
            strSql.Append(" where OrderID=@OrderID and StorageID = @StorageID and ProductsID=@ProductsID");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderID", SqlDbType.Int,4),
                                        new SqlParameter("@StorageID", SqlDbType.Int,4),
                                        new SqlParameter("@ProductsID", SqlDbType.Int,4)};
            parameters[0].Value = OrderID;
            parameters[1].Value = StorageID;
            parameters[2].Value = ProductsID;

            return  ((int)DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters)) > 0;
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddOrderListInfo(OrderListInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tbOrderListInfo(");
            strSql.Append("OrderID,StorageID,ProductsID,oQuantity,oPrice,oMoney,StoresSupplierID,IsPromotions,oWorkType,oAppendTime,IsGifts,PriceClassID)");
            strSql.Append(" values (");
            strSql.Append("@OrderID,@StorageID,@ProductsID,@oQuantity,@oPrice,@oMoney,@StoresSupplierID,@IsPromotions,@oWorkType,@oAppendTime,@IsGifts,@PriceClassID)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderID", SqlDbType.Int,4),
					new SqlParameter("@StorageID", SqlDbType.Int,4),
					new SqlParameter("@ProductsID", SqlDbType.Int,4),
					new SqlParameter("@oQuantity", SqlDbType.Decimal,9),
					new SqlParameter("@oPrice", SqlDbType.Money,8),
					new SqlParameter("@oMoney", SqlDbType.Money,8),
					new SqlParameter("@StoresSupplierID", SqlDbType.Int,4),
					new SqlParameter("@IsPromotions", SqlDbType.Int,4),
					new SqlParameter("@oWorkType", SqlDbType.Int,4),
					new SqlParameter("@oAppendTime", SqlDbType.DateTime),
                                        new SqlParameter("@IsGifts", SqlDbType.Int,4),
                                        new SqlParameter("@PriceClassID", SqlDbType.Int,4),};
            parameters[0].Value = model.OrderID;
            parameters[1].Value = model.StorageID;
            parameters[2].Value = model.ProductsID;
            parameters[3].Value = model.oQuantity;
            parameters[4].Value = model.oPrice;
            parameters[5].Value = model.oMoney;
            parameters[6].Value = model.StoresSupplierID;
            parameters[7].Value = model.IsPromotions;
            parameters[8].Value = model.oWorkType;
            parameters[9].Value = model.oAppendTime;
            parameters[10].Value = model.IsGifts;
            parameters[11].Value = model.PriceClassID;

            object obj = DbHelper.ExecuteScalar(CommandType.Text,strSql.ToString(), parameters);
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
        public void UpdateOrderListInfo(OrderListInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbOrderListInfo set ");
            strSql.Append("OrderID=@OrderID,");
            strSql.Append("StorageID=@StorageID,");
            strSql.Append("ProductsID=@ProductsID,");
            strSql.Append("oQuantity=@oQuantity,");
            strSql.Append("oPrice=@oPrice,");
            strSql.Append("oMoney=@oMoney,");
            strSql.Append("StoresSupplierID=@StoresSupplierID,");
            strSql.Append("IsPromotions=@IsPromotions,");
            strSql.Append("oWorkType=@oWorkType,");
            strSql.Append("oAppendTime=@oAppendTime,");
            strSql.Append("IsGifts=@IsGifts,");
            strSql.Append("PriceClassID=@PriceClassID");
            strSql.Append(" where OrderListID=@OrderListID ");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderListID", SqlDbType.Int,4),
					new SqlParameter("@OrderID", SqlDbType.Int,4),
					new SqlParameter("@StorageID", SqlDbType.Int,4),
					new SqlParameter("@ProductsID", SqlDbType.Int,4),
					new SqlParameter("@oQuantity", SqlDbType.Decimal,9),
					new SqlParameter("@oPrice", SqlDbType.Money,8),
					new SqlParameter("@oMoney", SqlDbType.Money,8),
					new SqlParameter("@StoresSupplierID", SqlDbType.Int,4),
					new SqlParameter("@IsPromotions", SqlDbType.Int,4),
					new SqlParameter("@oWorkType", SqlDbType.Int,4),
					new SqlParameter("@oAppendTime", SqlDbType.DateTime),
                                        new SqlParameter("@IsGifts", SqlDbType.Int,4),
                                        new SqlParameter("@PriceClassID", SqlDbType.Int,4),};
            parameters[0].Value = model.OrderListID;
            parameters[1].Value = model.OrderID;
            parameters[2].Value = model.StorageID;
            parameters[3].Value = model.ProductsID;
            parameters[4].Value = model.oQuantity;
            parameters[5].Value = model.oPrice;
            parameters[6].Value = model.oMoney;
            parameters[7].Value = model.StoresSupplierID;
            parameters[8].Value = model.IsPromotions;
            parameters[9].Value = model.oWorkType;
            parameters[10].Value = model.oAppendTime;
            parameters[11].Value = model.IsGifts;
            parameters[12].Value = model.PriceClassID;

            DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void DeleteOrderListInfo(int OrderListID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbOrderListInfo ");
            strSql.Append(" where OrderListID=@OrderListID ");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderListID", SqlDbType.Int,4)};
            parameters[0].Value = OrderListID;

            DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public OrderListInfo GetOrderListInfoModel(int OrderListID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 OrderListID,OrderID,StorageID,ProductsID,oQuantity,oPrice,oMoney,StoresSupplierID,IsPromotions,oWorkType,IsGifts,oAppendTime,PriceClassID from tbOrderListInfo ");
            strSql.Append(" where OrderListID=@OrderListID ");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderListID", SqlDbType.Int,4)};
            parameters[0].Value = OrderListID;

            OrderListInfo model = new OrderListInfo();
            DataSet ds = DbHelper.ExecuteDataset(CommandType.Text,strSql.ToString(),parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["OrderListID"].ToString() != "")
                {
                    model.OrderListID = int.Parse(ds.Tables[0].Rows[0]["OrderListID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OrderID"].ToString() != "")
                {
                    model.OrderID = int.Parse(ds.Tables[0].Rows[0]["OrderID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["StorageID"].ToString() != "")
                {
                    model.StorageID = int.Parse(ds.Tables[0].Rows[0]["StorageID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ProductsID"].ToString() != "")
                {
                    model.ProductsID = int.Parse(ds.Tables[0].Rows[0]["ProductsID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["oQuantity"].ToString() != "")
                {
                    model.oQuantity = decimal.Parse(ds.Tables[0].Rows[0]["oQuantity"].ToString());
                }
                if (ds.Tables[0].Rows[0]["oPrice"].ToString() != "")
                {
                    model.oPrice = decimal.Parse(ds.Tables[0].Rows[0]["oPrice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["oMoney"].ToString() != "")
                {
                    model.oMoney = decimal.Parse(ds.Tables[0].Rows[0]["oMoney"].ToString());
                }
                if (ds.Tables[0].Rows[0]["StoresSupplierID"].ToString() != "")
                {
                    model.StoresSupplierID = int.Parse(ds.Tables[0].Rows[0]["StoresSupplierID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsPromotions"].ToString() != "")
                {
                    model.IsPromotions = int.Parse(ds.Tables[0].Rows[0]["IsPromotions"].ToString());
                }
                if (ds.Tables[0].Rows[0]["oWorkType"].ToString() != "")
                {
                    model.oWorkType = int.Parse(ds.Tables[0].Rows[0]["oWorkType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsGifts"].ToString() != "")
                {
                    model.IsGifts = int.Parse(ds.Tables[0].Rows[0]["IsGifts"].ToString());
                }
                if (ds.Tables[0].Rows[0]["oAppendTime"].ToString() != "")
                {
                    model.oAppendTime = DateTime.Parse(ds.Tables[0].Rows[0]["oAppendTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PriceClassID"].ToString() != "")
                {
                    model.PriceClassID = int.Parse(ds.Tables[0].Rows[0]["PriceClassID"].ToString());
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
        public DataSet GetOrderListInfoList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select OrderListID,OrderID,StorageID,ProductsID,oQuantity,oPrice,oMoney,StoresSupplierID,IsPromotions,oWorkType,IsGifts,oAppendTime,PriceClassID," +
                "(select tbStorageInfo.sName from tbStorageInfo where tbStorageInfo.StorageID=tbOrderListInfo.StorageID ) as  StorageName,"+
                "(select tbProductsInfo.pName from tbProductsInfo where tbProductsInfo.ProductsID=tbOrderListInfo.ProductsID) as ProductsName,"+
                "(select tbProductsInfo.pBarcode from tbProductsInfo where tbProductsInfo.ProductsID=tbOrderListInfo.ProductsID) as ProductsBarcode,"+
                "(select tbProductsInfo.pToBoxNo from tbProductsInfo where tbProductsInfo.ProductsID=tbOrderListInfo.ProductsID) as ProductsToBoxNo,"+
                "(select tbProductsInfo.pUnits from tbProductsInfo where tbProductsInfo.ProductsID=tbOrderListInfo.ProductsID) as ProductsUnits,"+
                "(select tbProductsInfo.pAddress from tbProductsInfo where tbProductsInfo.ProductsID=tbOrderListInfo.ProductsID) as ProductsAddress," +
                "(select tbProductsInfo.pMaxUnits from tbProductsInfo where tbProductsInfo.ProductsID=tbOrderListInfo.ProductsID) as ProductsMaxUnits ");
            strSql.Append(" FROM tbOrderListInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelper.ExecuteDataset(CommandType.Text,strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetOrderListInfoList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" OrderListID,OrderID,StorageID,ProductsID,oQuantity,oPrice,oMoney,StoresSupplierID,IsPromotions,oWorkType,IsGifts,oAppendTime,PriceClassID,(select tbStorageInfo.sName from tbStorageInfo where tbStorageInfo.StorageID=tbOrderListInfo.StorageID ) as  StorageName,(select tbProductsInfo.pName from tbProductsInfo where tbProductsInfo.ProductsID=tbOrderListInfo.ProductsID) as ProductsName  ");
            strSql.Append(" FROM tbOrderListInfo ");
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
        public DataTable GetOrderListInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
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
            parameters[0].Value = "tbOrderListInfo";
            parameters[1].Value = "OrderListID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 1;
            parameters[5].Value = OrderType;
            parameters[6].Value = strWhere;
            parameters[7].Value = showFName + ",(select tbStorageInfo.sName from tbStorageInfo where tbStorageInfo.StorageID=tbOrderListInfo.StorageID ) as  StorageName,(select tbProductsInfo.pName from tbProductsInfo where tbProductsInfo.ProductsID=tbOrderListInfo.ProductsID) as ProductsName ";
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

        #region OrderField
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistsOrderFieldInfo(int OrderType, string fName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tbOrderFieldInfo");
            strSql.Append(" where OrderType=@OrderType and fName=@fName");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderType", SqlDbType.Int,4),
                                        new SqlParameter("@fName", SqlDbType.VarChar,50)};
            parameters[0].Value = OrderType;
            parameters[1].Value = fName;

            return  ((int)DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters)) > 0;
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddOrderFieldInfo(OrderFieldInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tbOrderFieldInfo(");
            strSql.Append("OrderType,fName,fType,fState,fPrint,fProductField,fPrintAdd)");
            strSql.Append(" values (");
            strSql.Append("@OrderType,@fName,@fType,@fState,@fPrint,@fProductField,@fPrintAdd)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderType", SqlDbType.Int,4),
					new SqlParameter("@fName", SqlDbType.VarChar,50),
					new SqlParameter("@fType", SqlDbType.Int,4),
					new SqlParameter("@fState", SqlDbType.Int,4),
                                        new SqlParameter("@fPrint", SqlDbType.Int,4),
                                        new SqlParameter("@fProductField", SqlDbType.VarChar,50),
                                        new SqlParameter("@fPrintAdd", SqlDbType.Int,4),};
            parameters[0].Value = model.OrderType;
            parameters[1].Value = model.fName;
            parameters[2].Value = model.fType;
            parameters[3].Value = model.fState;
            parameters[4].Value = model.fPrint;
            parameters[5].Value = model.fProductField;
            parameters[6].Value = model.fPrintAdd;

            object obj = DbHelper.ExecuteScalar(CommandType.Text,strSql.ToString(), parameters);
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
        public void UpdateOrderFieldInfo(OrderFieldInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbOrderFieldInfo set ");
            strSql.Append("OrderType=@OrderType,");
            strSql.Append("fName=@fName,");
            strSql.Append("fType=@fType,");
            strSql.Append("fState=@fState,");
            strSql.Append("fPrint=@fPrint,");
            strSql.Append("fProductField=@fProductField,");
            strSql.Append("fPrintAdd=@fPrintAdd");
            strSql.Append(" where OrderFieldID=@OrderFieldID ");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderFieldID", SqlDbType.Int,4),
					new SqlParameter("@OrderType", SqlDbType.Int,4),
					new SqlParameter("@fName", SqlDbType.VarChar,50),
					new SqlParameter("@fType", SqlDbType.Int,4),
					new SqlParameter("@fState", SqlDbType.Int,4),
                                        new SqlParameter("@fPrint", SqlDbType.Int,4),
                                        new SqlParameter("@fProductField", SqlDbType.VarChar,50),
                                        new SqlParameter("@fPrintAdd", SqlDbType.Int,4),};
            parameters[0].Value = model.OrderFieldID;
            parameters[1].Value = model.OrderType;
            parameters[2].Value = model.fName;
            parameters[3].Value = model.fType;
            parameters[4].Value = model.fState;
            parameters[5].Value = model.fPrint;
            parameters[6].Value = model.fProductField;
            parameters[7].Value = model.fPrintAdd;

            DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void DeleteOrderFieldInfo(int OrderFieldID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbOrderFieldInfo ");
            strSql.Append(" where OrderFieldID=@OrderFieldID ");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderFieldID", SqlDbType.Int,4)};
            parameters[0].Value = OrderFieldID;

            DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        public void DeleteOrderFieldInfo(string OrderFieldID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbOrderFieldInfo ");
            strSql.Append(" where OrderFieldID in("+OrderFieldID+") ");

            DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString());
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public OrderFieldInfo GetOrderFieldInfoModel(int OrderFieldID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 OrderFieldID,OrderType,fName,fType,fState,fPrint,fProductField,fPrintAdd from tbOrderFieldInfo ");
            strSql.Append(" where OrderFieldID=@OrderFieldID ");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderFieldID", SqlDbType.Int,4)};
            parameters[0].Value = OrderFieldID;

            OrderFieldInfo model = new OrderFieldInfo();
            DataSet ds = DbHelper.ExecuteDataset(CommandType.Text,strSql.ToString(),parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["OrderFieldID"].ToString() != "")
                {
                    model.OrderFieldID = int.Parse(ds.Tables[0].Rows[0]["OrderFieldID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OrderType"].ToString() != "")
                {
                    model.OrderType = int.Parse(ds.Tables[0].Rows[0]["OrderType"].ToString());
                }
                model.fName = ds.Tables[0].Rows[0]["fName"].ToString();
                model.fProductField = ds.Tables[0].Rows[0]["fProductField"].ToString();
                if (ds.Tables[0].Rows[0]["fType"].ToString() != "")
                {
                    model.fType = int.Parse(ds.Tables[0].Rows[0]["fType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["fState"].ToString() != "")
                {
                    model.fState = int.Parse(ds.Tables[0].Rows[0]["fState"].ToString());
                }
                if (ds.Tables[0].Rows[0]["fPrint"].ToString() != "")
                {
                    model.fPrint = int.Parse(ds.Tables[0].Rows[0]["fPrint"].ToString());
                }
                if (ds.Tables[0].Rows[0]["fPrintAdd"].ToString() != "")
                {
                    model.fPrintAdd = int.Parse(ds.Tables[0].Rows[0]["fPrintAdd"].ToString());
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
        public DataSet GetOrderFieldInfoList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select OrderFieldID,OrderType,fName,fType,fState,fPrint,fProductField,fPrintAdd ");
            strSql.Append(" FROM tbOrderFieldInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelper.ExecuteDataset(CommandType.Text,strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetOrderFieldInfoList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" OrderFieldID,OrderType,fName,fType,fState,fPrint,fProductField,fPrintAdd ");
            strSql.Append(" FROM tbOrderFieldInfo ");
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
        public DataTable GetOrderFieldInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
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
            parameters[0].Value = "tbOrderFieldInfo";
            parameters[1].Value = "OrderFieldID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 1;
            parameters[5].Value = OrderType;
            parameters[6].Value = strWhere;
            parameters[7].Value = showFName ;
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

        #region OrderFieldValue
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistsOrderFieldValueInfo(int OrderFieldID, int OrderListID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tbOrderFieldValueInfo");
            strSql.Append(" where OrderFieldID=@OrderFieldID and OrderListID=@OrderListID");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderFieldID", SqlDbType.Int,4),
                                        new SqlParameter("@OrderListID", SqlDbType.Int,4)};
            parameters[0].Value = OrderFieldID;
            parameters[1].Value = OrderListID;

            return  ((int)DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters)) > 0;
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddOrderFieldValueInfo(OrderFieldValueInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tbOrderFieldValueInfo(");
            strSql.Append("OrderFieldID,OrderListID,oFieldValue,IsVerify,oAppendTime)");
            strSql.Append(" values (");
            strSql.Append("@OrderFieldID,@OrderListID,@oFieldValue,@IsVerify,@oAppendTime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderFieldID", SqlDbType.Int,4),
					new SqlParameter("@OrderListID", SqlDbType.Int,4),
					new SqlParameter("@oFieldValue", SqlDbType.VarChar,128),
					new SqlParameter("@IsVerify", SqlDbType.Int,4),
					new SqlParameter("@oAppendTime", SqlDbType.DateTime)};
            parameters[0].Value = model.OrderFieldID;
            parameters[1].Value = model.OrderListID;
            parameters[2].Value = model.oFieldValue;
            parameters[3].Value = model.IsVerify;
            parameters[4].Value = model.oAppendTime;

            object obj = DbHelper.ExecuteScalar(CommandType.Text,strSql.ToString(), parameters);
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
        public void UpdateOrderFieldValueInfo(OrderFieldValueInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbOrderFieldValueInfo set ");
            strSql.Append("OrderFieldID=@OrderFieldID,");
            strSql.Append("OrderListID=@OrderListID,");
            strSql.Append("oFieldValue=@oFieldValue,");
            strSql.Append("IsVerify=@IsVerify,");
            strSql.Append("oAppendTime=@oAppendTime");
            strSql.Append(" where OrderFieldValueID=@OrderFieldValueID ");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderFieldValueID", SqlDbType.Int,4),
					new SqlParameter("@OrderFieldID", SqlDbType.Int,4),
					new SqlParameter("@OrderListID", SqlDbType.Int,4),
					new SqlParameter("@oFieldValue", SqlDbType.VarChar,128),
					new SqlParameter("@IsVerify", SqlDbType.Int,4),
					new SqlParameter("@oAppendTime", SqlDbType.DateTime)};
            parameters[0].Value = model.OrderFieldValueID;
            parameters[1].Value = model.OrderFieldID;
            parameters[2].Value = model.OrderListID;
            parameters[3].Value = model.oFieldValue;
            parameters[4].Value = model.IsVerify;
            parameters[5].Value = model.oAppendTime;

            DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void DeleteOrderFieldValueInfo(int OrderFieldValueID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbOrderFieldValueInfo ");
            strSql.Append(" where OrderFieldValueID=@OrderFieldValueID ");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderFieldValueID", SqlDbType.Int,4)};
            parameters[0].Value = OrderFieldValueID;

            DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public OrderFieldValueInfo GetOrderFieldValueInfoModel(int OrderFieldValueID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 OrderFieldValueID,OrderFieldID,OrderListID,oFieldValue,IsVerify,oAppendTime from tbOrderFieldValueInfo ");
            strSql.Append(" where OrderFieldValueID=@OrderFieldValueID ");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderFieldValueID", SqlDbType.Int,4)};
            parameters[0].Value = OrderFieldValueID;

            OrderFieldValueInfo model = new OrderFieldValueInfo();
            DataSet ds = DbHelper.ExecuteDataset(CommandType.Text,strSql.ToString(),parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["OrderFieldValueID"].ToString() != "")
                {
                    model.OrderFieldValueID = int.Parse(ds.Tables[0].Rows[0]["OrderFieldValueID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OrderFieldID"].ToString() != "")
                {
                    model.OrderFieldID = int.Parse(ds.Tables[0].Rows[0]["OrderFieldID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OrderListID"].ToString() != "")
                {
                    model.OrderListID = int.Parse(ds.Tables[0].Rows[0]["OrderListID"].ToString());
                }
                model.oFieldValue = ds.Tables[0].Rows[0]["oFieldValue"].ToString();
                if (ds.Tables[0].Rows[0]["IsVerify"].ToString() != "")
                {
                    model.IsVerify = int.Parse(ds.Tables[0].Rows[0]["IsVerify"].ToString());
                }
                if (ds.Tables[0].Rows[0]["oAppendTime"].ToString() != "")
                {
                    model.oAppendTime = DateTime.Parse(ds.Tables[0].Rows[0]["oAppendTime"].ToString());
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
        public DataSet GetOrderFieldValueInfoList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select OrderFieldValueID,OrderFieldID,OrderListID,oFieldValue,IsVerify,oAppendTime ");
            strSql.Append(" FROM tbOrderFieldValueInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelper.ExecuteDataset(CommandType.Text,strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetOrderFieldValueInfoList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" OrderFieldValueID,OrderFieldID,OrderListID,oFieldValue,IsVerify,oAppendTime ");
            strSql.Append(" FROM tbOrderFieldValueInfo ");
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
        public DataTable GetOrderFieldValueInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
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
            parameters[0].Value = "tbOrderFieldValueInfo";
            parameters[1].Value = "OrderFieldValueID";
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

        #region OrderWorkingLogInfo
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddOrderWorkingLogInfo(OrderWorkingLogInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tbOrderWorkingLogInfo(");
            strSql.Append("OrderID,UserID,oType,oMsg,pAppendTime)");
            strSql.Append(" values (");
            strSql.Append("@OrderID,@UserID,@oType,@oMsg,@pAppendTime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderID", SqlDbType.Int,4),
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@oType", SqlDbType.Int,4),
					new SqlParameter("@oMsg", SqlDbType.VarChar,512),
					new SqlParameter("@pAppendTime", SqlDbType.DateTime)};
            parameters[0].Value = model.OrderID;
            parameters[1].Value = model.UserID;
            parameters[2].Value = model.oType;
            parameters[3].Value = model.oMsg;
            parameters[4].Value = model.pAppendTime;

            object obj = DbHelper.ExecuteScalar(CommandType.Text,strSql.ToString(), parameters);
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
        public void UpdateOrderWorkingLogInfo(OrderWorkingLogInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbOrderWorkingLogInfo set ");
            strSql.Append("OrderID=@OrderID,");
            strSql.Append("UserID=@UserID,");
            strSql.Append("oType=@oType,");
            strSql.Append("oMsg=@oMsg,");
            strSql.Append("pAppendTime=@pAppendTime");
            strSql.Append(" where OrderWorkingLogID=@OrderWorkingLogID ");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderWorkingLogID", SqlDbType.Int,4),
					new SqlParameter("@OrderID", SqlDbType.Int,4),
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@oType", SqlDbType.Int,4),
					new SqlParameter("@oMsg", SqlDbType.VarChar,512),
					new SqlParameter("@pAppendTime", SqlDbType.DateTime)};
            parameters[0].Value = model.OrderWorkingLogID;
            parameters[1].Value = model.OrderID;
            parameters[2].Value = model.UserID;
            parameters[3].Value = model.oType;
            parameters[4].Value = model.oMsg;
            parameters[5].Value = model.pAppendTime;

            DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void DeleteOrderWorkingLogInfo(int OrderWorkingLogID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbOrderWorkingLogInfo ");
            strSql.Append(" where OrderWorkingLogID=@OrderWorkingLogID ");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderWorkingLogID", SqlDbType.Int,4)};
            parameters[0].Value = OrderWorkingLogID;

            DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        /// <summary>
        /// 返回产品库存报警列表,库存数 <=10出库, >=20天出库
        /// </summary>
        /// <returns></returns>
        public DataTable GetProductAlarm()
        {
            /*
             
    
    select ppps.ProductsID,ppps.StorageID,(select top 1 sName from tbStorageInfo where StorageID=ppps.StorageID) as StorageName,ppps.pBarcode,ppps.pName,ppps.pStorage,ppps.pStorageIn,ppps.pStorageOut,ppps.pUpdateTime,ppps.QuantityA,ppps.QuantityB,ppps.BeginQuantity,(case when ((ppps.pStorage+ppps.BeginQuantity+ppps.pStorageIn-ppps.pStorageOut)<=ppps.QuantityA) then 1 
    else  2 end) as tx from (
    select p.pBarcode,p.pName,pps.ProductsID,pps.QuantityA,pps.QuantityB,pps.pStorage,pps.pStorageIn,pps.pStorageOut,pps.pUpdateTime,pps.StorageID,isnull((select top 1 pQuantity from tbProductsStorageLogInfo where pType=-1 and ProductsID=p.ProductsID and StorageID=pps.StorageID and pState=0),0) as BeginQuantity from tbProductsInfo p right join (
    select ooo.ProductsID,ooo.QuantityA,ooo.QuantityB,ooo.StorageID,ps.pStorage,ps.pStorageIn,ps.pStorageOut,ps.pUpdateTime from tbProductsStorageInfo ps left join (
    select o.ProductsID,o.StorageID,isnull(SUM(QuantityA),0) as QuantityA,ISNULL(SUM(QuantityB),0) as QuantityB from (
    select ProductsID,StorageID,isnull(sum(oQuantity),0) as QuantityA from tbOrderListInfo 
	where OrderID in(select OrderID from tbOrderInfo where oType in(3,5,6,7) and oState=0 and oSteps>1 and datediff(day,oOrderDateTime,getdate())<10) 
	and oWorkType>0 group by StorageID,ProductsID) as o left join (select ProductsID,StorageID,isnull(sum(oQuantity),0) as QuantityB from tbOrderListInfo 
	where OrderID in(select OrderID from tbOrderInfo where oType in(3,5,6,7) and oState=0 and oSteps>1 and datediff(day,oOrderDateTime,getdate())<20) 
    and oWorkType>0 group by StorageID,ProductsID) as oo on o.ProductsID=oo.ProductsID and o.StorageID=oo.StorageID group by o.StorageID,o.ProductsID ) as ooo
    on ps.ProductsID=ooo.ProductsID and ps.StorageID=ooo.StorageID where datediff(day,ps.pUpdateTime,getdate())=0) as pps
    on pps.ProductsID=p.ProductsID) ppps where ((ppps.pStorage+ppps.BeginQuantity+ppps.pStorageIn-ppps.pStorageOut)<=ppps.QuantityA or (ppps.pStorage+ppps.BeginQuantity+ppps.pStorageIn-ppps.pStorageOut)>=ppps.QuantityB) order by tx asc        */

            /*
             select ps.ProductsID,ps.StorageID,(select top 1 tbStoresInfo.sName from tbStorageInfo where tbStoresInfo.StorageID=ps.StorageID) as StorageName,ps.pStorage,ps.pStorageIn,ps.pStorageOut,ooo.BeginQuantity,ooo.QuantityA,ooo.QuantityB,ooo.pName,ooo.pBarcode,(case when ((ps.pStorage+ooo.BeginQuantity+ps.pStorageIn-ps.pStorageOut)<=ooo.QuantityA) then 1 " +
    "else  2 end) as tx from tbProductsStorageInfo ps left join ( "+
    "select p.ProductsID,p.pName,p.pBarcode,o.QuantityA,o.StorageID,oo.QuantityB,isnull((select top 1 pQuantity from tbProductsStorageLogInfo where pType=-1 and ProductsID=p.ProductsID and StorageID=o.StorageID and pState=0),0) as BeginQuantity from  tbProductsInfo p left join ( " +
    "select ProductsID,StorageID,isnull(sum(oQuantity),0) as QuantityA from tbOrderListInfo "+
    "where OrderID in(select OrderID from tbOrderInfo where oType in(3,5,6,7) and oState=0 and oSteps>1 and datediff(day,oOrderDateTime,getdate())<10) "+
    "and oWorkType>0 group by StorageID,ProductsID) as o on p.ProductsID=o.ProductsID "+
    "left join (select ProductsID,StorageID,isnull(sum(oQuantity),0) as QuantityB from tbOrderListInfo "+
    "where OrderID in(select OrderID from tbOrderInfo where oType in(3,5,6,7) and oState=0 and oSteps>1 and datediff(day,oOrderDateTime,getdate())<20) "+
    "and oWorkType>0 group by StorageID,ProductsID) oo on p.ProductsID = oo.ProductsID and o.StorageID=oo.StorageID  "+
    ") as ooo on ps.ProductsID=ooo.ProductsID and ps.StorageID=ooo.StorageID where datediff(day,ps.pUpdateTime,getdate())=0 and ((ps.pStorage+ooo.BeginQuantity+ps.pStorageIn-ps.pStorageOut)<=ooo.QuantityA or (ps.pStorage+ooo.BeginQuantity+ps.pStorageIn-ps.pStorageOut)>=ooo.QuantityB) order by tx asc
             */

            //DataTable dt = new DataTable();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select ppps.ProductsID,ppps.StorageID,(select top 1 sName from tbStorageInfo where StorageID=ppps.StorageID) as StorageName,ppps.pBarcode,ppps.pName,ppps.pStorage,ppps.pStorageIn,ppps.pStorageOut,ppps.pUpdateTime,ppps.QuantityA,ppps.QuantityB,ppps.BeginQuantity,(case when ((ppps.pStorage+ppps.BeginQuantity+ppps.pStorageIn-ppps.pStorageOut)<=ppps.QuantityA) then 1 " +
            "else  2 end) as tx from (  "+
            "select p.pBarcode,p.pName,pps.ProductsID,pps.QuantityA,pps.QuantityB,pps.pStorage,pps.pStorageIn,pps.pStorageOut,pps.pUpdateTime,pps.StorageID,isnull((select top 1 pQuantity from tbProductsStorageLogInfo where pType=-1 and ProductsID=p.ProductsID and StorageID=pps.StorageID and pState=0),0) as BeginQuantity from tbProductsInfo p right join ( "+
            "select ooo.ProductsID,ooo.QuantityA,ooo.QuantityB,ooo.StorageID,ps.pStorage,ps.pStorageIn,ps.pStorageOut,ps.pUpdateTime from tbProductsStorageInfo ps left join ( "+
            "select o.ProductsID,o.StorageID,isnull(SUM(QuantityA),0) as QuantityA,ISNULL(SUM(QuantityB),0) as QuantityB from ( "+
            "select ProductsID,StorageID,isnull(sum(oQuantity),0) as QuantityA from tbOrderListInfo  "+
	        "where OrderID in(select OrderID from tbOrderInfo where oType in(3,5,6,7) and oState=0 and oSteps>1 and datediff(day,oOrderDateTime,getdate())<10)  "+
	        "and oWorkType>0 group by StorageID,ProductsID) as o left join (select ProductsID,StorageID,isnull(sum(oQuantity),0) as QuantityB from tbOrderListInfo  "+
	        "where OrderID in(select OrderID from tbOrderInfo where oType in(3,5,6,7) and oState=0 and oSteps>1 and datediff(day,oOrderDateTime,getdate())<20)  "+
            "and oWorkType>0 group by StorageID,ProductsID) as oo on o.ProductsID=oo.ProductsID and o.StorageID=oo.StorageID group by o.StorageID,o.ProductsID ) as ooo "+
            "on ps.ProductsID=ooo.ProductsID and ps.StorageID=ooo.StorageID where datediff(day,ps.pUpdateTime,getdate())=0) as pps " +
            "on pps.ProductsID=p.ProductsID) ppps where ((ppps.pStorage+ppps.BeginQuantity+ppps.pStorageIn-ppps.pStorageOut)<=ppps.QuantityA or (ppps.pStorage+ppps.BeginQuantity+ppps.pStorageIn-ppps.pStorageOut)>=ppps.QuantityB) order by tx asc");
             return DbHelper.ExecuteDataset(strSql.ToString()).Tables[0];
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public OrderWorkingLogInfo GetOrderWorkingLogInfoModel(int OrderWorkingLogID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 OrderWorkingLogID,OrderID,UserID,oType,oMsg,pAppendTime,(select tbUserInfo.uName from tbUserInfo where tbOrderWorkingLogInfo.UserID=tbUserInfo.UserID) as UserName from tbOrderWorkingLogInfo ");
            strSql.Append(" where OrderWorkingLogID=@OrderWorkingLogID ");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderWorkingLogID", SqlDbType.Int,4)};
            parameters[0].Value = OrderWorkingLogID;

            OrderWorkingLogInfo model = new OrderWorkingLogInfo();
            DataSet ds = DbHelper.ExecuteDataset(CommandType.Text,strSql.ToString(),parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["OrderWorkingLogID"].ToString() != "")
                {
                    model.OrderWorkingLogID = int.Parse(ds.Tables[0].Rows[0]["OrderWorkingLogID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OrderID"].ToString() != "")
                {
                    model.OrderID = int.Parse(ds.Tables[0].Rows[0]["OrderID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserID"].ToString() != "")
                {
                    model.UserID = int.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["oType"].ToString() != "")
                {
                    model.oType = int.Parse(ds.Tables[0].Rows[0]["oType"].ToString());
                }
                model.oMsg = ds.Tables[0].Rows[0]["oMsg"].ToString();
                if (ds.Tables[0].Rows[0]["pAppendTime"].ToString() != "")
                {
                    model.pAppendTime = DateTime.Parse(ds.Tables[0].Rows[0]["pAppendTime"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 指定单据编号,工作类型,获得工作记录
        /// </summary>
        /// <param name="OrderID"></param>
        /// <param name="WorkType"></param>
        /// <returns></returns>
        public OrderWorkingLogInfo GetOrderWorkingLogInfoModelByOrderIDAndWorkType(int OrderID,int WorkType)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 OrderWorkingLogID,OrderID,UserID,oType,oMsg,pAppendTime,(select tbUserInfo.uName from tbUserInfo where tbOrderWorkingLogInfo.UserID=tbUserInfo.UserID) as UserName from tbOrderWorkingLogInfo ");
            strSql.Append(" where oType=@WorkType and OrderID=@OrderID");
            SqlParameter[] parameters = {
					new SqlParameter("@WorkType", SqlDbType.Int,4),
                                        new SqlParameter("@OrderID", SqlDbType.Int,4)};
            parameters[0].Value = WorkType;
            parameters[1].Value = OrderID;

            OrderWorkingLogInfo model = new OrderWorkingLogInfo();
            DataSet ds = DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["OrderWorkingLogID"].ToString() != "")
                {
                    model.OrderWorkingLogID = int.Parse(ds.Tables[0].Rows[0]["OrderWorkingLogID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OrderID"].ToString() != "")
                {
                    model.OrderID = int.Parse(ds.Tables[0].Rows[0]["OrderID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserID"].ToString() != "")
                {
                    model.UserID = int.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["oType"].ToString() != "")
                {
                    model.oType = int.Parse(ds.Tables[0].Rows[0]["oType"].ToString());
                }
                model.oMsg = ds.Tables[0].Rows[0]["oMsg"].ToString();
                if (ds.Tables[0].Rows[0]["pAppendTime"].ToString() != "")
                {
                    model.pAppendTime = DateTime.Parse(ds.Tables[0].Rows[0]["pAppendTime"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 取单据指定操作类型的操作信息
        /// </summary>
        /// <param name="OrderID"></param>
        /// <param name="WorkType"></param>
        /// <returns></returns>
        public OrderWorkingLogInfo GetOrderWorkingUserID(int OrderID, int WorkType)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 OrderWorkingLogID,OrderID,UserID,oType,oMsg,pAppendTime,(select tbUserInfo.uName from tbUserInfo where tbOrderWorkingLogInfo.UserID=tbUserInfo.UserID) as UserName from tbOrderWorkingLogInfo ");
            strSql.Append(" where OrderID=@OrderID and oType=@WorkType");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderID", SqlDbType.Int,4),
                                        new SqlParameter("@WorkType", SqlDbType.Int,4)};
            parameters[0].Value = OrderID;
            parameters[1].Value = WorkType;

            OrderWorkingLogInfo model = new OrderWorkingLogInfo();
            DataSet ds = DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["OrderWorkingLogID"].ToString() != "")
                {
                    model.OrderWorkingLogID = int.Parse(ds.Tables[0].Rows[0]["OrderWorkingLogID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OrderID"].ToString() != "")
                {
                    model.OrderID = int.Parse(ds.Tables[0].Rows[0]["OrderID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserID"].ToString() != "")
                {
                    model.UserID = int.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["oType"].ToString() != "")
                {
                    model.oType = int.Parse(ds.Tables[0].Rows[0]["oType"].ToString());
                }
                model.oMsg = ds.Tables[0].Rows[0]["oMsg"].ToString();
                if (ds.Tables[0].Rows[0]["pAppendTime"].ToString() != "")
                {
                    model.pAppendTime = DateTime.Parse(ds.Tables[0].Rows[0]["pAppendTime"].ToString());
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
        public DataSet GetOrderWorkingLogInfoList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select OrderWorkingLogID,OrderID,UserID,oType,oMsg,pAppendTime,(select tbUserInfo.uName from tbUserInfo where tbOrderWorkingLogInfo.UserID=tbUserInfo.UserID) as UserName,(select top 1 us.sName from tbStaffInfo us where us.StaffID=(select top 1 StaffID from tbUserInfo where UserID=tbOrderWorkingLogInfo.UserID )) as UserStaffName ");
            strSql.Append(" FROM tbOrderWorkingLogInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelper.ExecuteDataset(CommandType.Text,strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetOrderWorkingLogInfoList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" OrderWorkingLogID,OrderID,UserID,oType,oMsg,pAppendTime,(select tbUserInfo.uName from tbUserInfo where tbOrderWorkingLogInfo.UserID=tbUserInfo.UserID) as UserName,(select top 1 us.sName from tbStaffInfo us where us.StaffID=(select top 1 StaffID from tbUserInfo where UserID=tbOrderWorkingLogInfo.UserID )) as UserStaffName ");
            strSql.Append(" FROM tbOrderWorkingLogInfo ");
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
        public DataTable GetOrderWorkingLogInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
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
            parameters[0].Value = "tbOrderWorkingLogInfo";
            parameters[1].Value = "OrderWorkingLogID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 1;
            parameters[5].Value = OrderType;
            parameters[6].Value = strWhere;
            parameters[7].Value = showFName + ",(select tbUserInfo.uName from tbUserInfo where tbOrderWorkingLogInfo.UserID=tbUserInfo.UserID) as UserName,(select top 1 us.sName from tbStaffInfo us where us.StaffID=(select top 1 StaffID from tbUserInfo where UserID=tbOrderWorkingLogInfo.UserID )) as UserStaffName";
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

        #region OrderNOFullInfo

        /// <summary>
        /// 验证指定非全额单据是否已处理差额
        /// </summary>
        /// <param name="OrderID"></param>
        /// <returns></returns>
        public bool CheckOrderNOFullToDo(int OrderID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(0) from tbOrderNOFullInfo where OrderID=@OrderID and oNextOrderID=0 and oState=0");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderID", SqlDbType.Int,4),
                                        };
            parameters[0].Value = OrderID;
            return ((int)DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters)) > 0;
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistsOrderNOFullInfo(int OrderID, int OrderToID, int ProductsID, int FormStorageID, int ToStorageID, decimal oQuantity, int oState)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tbOrderNOFullInfo");
            strSql.Append(" where OrderID=@OrderID and OrderToID=@OrderToID and ProductsID=@ProductsID and FormStorageID=@FormStorageID and ToStorageID=@ToStorageID and oQuantity=@oQuantity and oState=@oState  ");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderID", SqlDbType.Int,4),
					new SqlParameter("@OrderToID", SqlDbType.Int,4),
					new SqlParameter("@ProductsID", SqlDbType.Int,4),
					new SqlParameter("@FormStorageID", SqlDbType.Int,4),
					new SqlParameter("@ToStorageID", SqlDbType.Int,4),
					new SqlParameter("@oQuantity", SqlDbType.Decimal),
					new SqlParameter("@oState", SqlDbType.Int,4),};
            parameters[0].Value = OrderID;
            parameters[1].Value = OrderToID;
            parameters[2].Value = ProductsID;
            parameters[3].Value = FormStorageID;
            parameters[4].Value = ToStorageID;
            parameters[5].Value = oQuantity;
            parameters[6].Value = oState;

            return ((int)DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters)) > 0;
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void AddOrderNOFullInfo(OrderNOFullInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tbOrderNOFullInfo(");
            strSql.Append("OrderID,OrderToID,ProductsID,FormStorageID,ToStorageID,oQuantity,oState,oAppendTimie,UserID,oNextOrderID)");
            strSql.Append(" values (");
            strSql.Append("@OrderID,@OrderToID,@ProductsID,@FormStorageID,@ToStorageID,@oQuantity,@oState,@oAppendTimie,@UserID,@oNextOrderID)");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderID", SqlDbType.Int,4),
					new SqlParameter("@OrderToID", SqlDbType.Int,4),
					new SqlParameter("@ProductsID", SqlDbType.Int,4),
					new SqlParameter("@FormStorageID", SqlDbType.Int,4),
					new SqlParameter("@ToStorageID", SqlDbType.Int,4),
					new SqlParameter("@oQuantity", SqlDbType.Decimal,9),
					new SqlParameter("@oState", SqlDbType.Int,4),
					new SqlParameter("@oAppendTimie", SqlDbType.DateTime),
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@oNextOrderID", SqlDbType.Int,4)};
            parameters[0].Value = model.OrderID;
            parameters[1].Value = model.OrderToID;
            parameters[2].Value = model.ProductsID;
            parameters[3].Value = model.FormStorageID;
            parameters[4].Value = model.ToStorageID;
            parameters[5].Value = model.oQuantity;
            parameters[6].Value = model.oState;
            parameters[7].Value = model.oAppendTimie;
            parameters[8].Value = model.UserID;
            parameters[9].Value = model.oNextOrderID;

            DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void UpdateOrderNOFullInfo(OrderNOFullInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbOrderNOFullInfo set ");
            strSql.Append("OrderID=@OrderID,");
            strSql.Append("OrderToID=@OrderToID,");
            strSql.Append("ProductsID=@ProductsID,");
            strSql.Append("FormStorageID=@FormStorageID,");
            strSql.Append("ToStorageID=@ToStorageID,");
            strSql.Append("oQuantity=@oQuantity,");
            strSql.Append("oState=@oState,");
            strSql.Append("oAppendTimie=@oAppendTimie,");
            strSql.Append("UserID=@UserID,");
            strSql.Append("oNextOrderID=@oNextOrderID");
            strSql.Append(" where OrderID=@OrderID and OrderToID=@OrderToID and ProductsID=@ProductsID and FormStorageID=@FormStorageID and ToStorageID=@ToStorageID and oQuantity=@oQuantity and oState=@oState and oAppendTimie=@oAppendTimie and UserID=@UserID ");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderID", SqlDbType.Int,4),
					new SqlParameter("@OrderToID", SqlDbType.Int,4),
					new SqlParameter("@ProductsID", SqlDbType.Int,4),
					new SqlParameter("@FormStorageID", SqlDbType.Int,4),
					new SqlParameter("@ToStorageID", SqlDbType.Int,4),
					new SqlParameter("@oQuantity", SqlDbType.Decimal,9),
					new SqlParameter("@oState", SqlDbType.Int,4),
					new SqlParameter("@oAppendTimie", SqlDbType.DateTime),
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@oNextOrderID", SqlDbType.Int,4)};
            parameters[0].Value = model.OrderID;
            parameters[1].Value = model.OrderToID;
            parameters[2].Value = model.ProductsID;
            parameters[3].Value = model.FormStorageID;
            parameters[4].Value = model.ToStorageID;
            parameters[5].Value = model.oQuantity;
            parameters[6].Value = model.oState;
            parameters[7].Value = model.oAppendTimie;
            parameters[8].Value = model.UserID;
            parameters[9].Value = model.oNextOrderID;

            DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        /// <summary>
        /// 更新待处理单据状态
        /// </summary>
        /// <param name="OrderID"></param>
        /// <param name="NextOrderID"></param>
        public void UpdateOrderNOFullNextOrder(int OrderID,int NextOrderID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbOrderNOFullInfo set oNextOrderID=@oNextOrderID where OrderID=@OrderID and oState=0");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderID", SqlDbType.Int,4),
                    new SqlParameter("@oNextOrderID", SqlDbType.Int,4),
                                        };
            parameters[0].Value = OrderID;
            parameters[1].Value = NextOrderID;
            DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void DeleteOrderNOFullInfo(int OrderID, int OrderToID, int ProductsID, int FormStorageID, int ToStorageID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbOrderNOFullInfo ");
            strSql.Append(" where OrderID=@OrderID and OrderToID=@OrderToID and ProductsID=@ProductsID and FormStorageID=@FormStorageID and ToStorageID=@ToStorageID  ");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderID", SqlDbType.Int,4),
					new SqlParameter("@OrderToID", SqlDbType.Int,4),
					new SqlParameter("@ProductsID", SqlDbType.Int,4),
					new SqlParameter("@FormStorageID", SqlDbType.Int,4),
					new SqlParameter("@ToStorageID", SqlDbType.Int,4),};
            parameters[0].Value = OrderID;
            parameters[1].Value = OrderToID;
            parameters[2].Value = ProductsID;
            parameters[3].Value = FormStorageID;
            parameters[4].Value = ToStorageID;

            DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public OrderNOFullInfo GetOrderNOFullInfoModel(int OrderID, int OrderToID, int ProductsID, int FormStorageID, int ToStorageID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 OrderID,OrderToID,ProductsID,FormStorageID,ToStorageID,oQuantity,oState,oAppendTimie,UserID,oNextOrderID from tbOrderNOFullInfo ");
            strSql.Append(" where OrderID=@OrderID and OrderToID=@OrderToID and ProductsID=@ProductsID and FormStorageID=@FormStorageID and ToStorageID=@ToStorageID  ");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderID", SqlDbType.Int,4),
					new SqlParameter("@OrderToID", SqlDbType.Int,4),
					new SqlParameter("@ProductsID", SqlDbType.Int,4),
					new SqlParameter("@FormStorageID", SqlDbType.Int,4),
					new SqlParameter("@ToStorageID", SqlDbType.Int,4),};
            parameters[0].Value = OrderID;
            parameters[1].Value = OrderToID;
            parameters[2].Value = ProductsID;
            parameters[3].Value = FormStorageID;
            parameters[4].Value = ToStorageID;

            OrderNOFullInfo model = new OrderNOFullInfo();
            DataSet ds = DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["OrderID"].ToString() != "")
                {
                    model.OrderID = int.Parse(ds.Tables[0].Rows[0]["OrderID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OrderToID"].ToString() != "")
                {
                    model.OrderToID = int.Parse(ds.Tables[0].Rows[0]["OrderToID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ProductsID"].ToString() != "")
                {
                    model.ProductsID = int.Parse(ds.Tables[0].Rows[0]["ProductsID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["FormStorageID"].ToString() != "")
                {
                    model.FormStorageID = int.Parse(ds.Tables[0].Rows[0]["FormStorageID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ToStorageID"].ToString() != "")
                {
                    model.ToStorageID = int.Parse(ds.Tables[0].Rows[0]["ToStorageID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["oQuantity"].ToString() != "")
                {
                    model.oQuantity = decimal.Parse(ds.Tables[0].Rows[0]["oQuantity"].ToString());
                }
                if (ds.Tables[0].Rows[0]["oState"].ToString() != "")
                {
                    model.oState = int.Parse(ds.Tables[0].Rows[0]["oState"].ToString());
                }
                if (ds.Tables[0].Rows[0]["oNextOrderID"].ToString() != "")
                {
                    model.oNextOrderID = int.Parse(ds.Tables[0].Rows[0]["oNextOrderID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["oAppendTimie"].ToString() != "")
                {
                    model.oAppendTimie = DateTime.Parse(ds.Tables[0].Rows[0]["oAppendTimie"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserID"].ToString() != "")
                {
                    model.UserID = int.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
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
        public DataSet GetOrderNOFullInfoList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select OrderID,OrderToID,ProductsID,FormStorageID,ToStorageID,oQuantity,oState,oAppendTimie,UserID,oNextOrderID ");
            strSql.Append(" FROM tbOrderNOFullInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetOrderNOFullInfoList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" OrderID,OrderToID,ProductsID,FormStorageID,ToStorageID,oQuantity,oState,oAppendTimie,UserID,oNextOrderID ");
            strSql.Append(" FROM tbOrderNOFullInfo ");
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
        public DataTable GetOrderNOFullInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
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
            parameters[0].Value = "tbOrderNOFullInfo";
            parameters[1].Value = "OrderID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 1;
            parameters[5].Value = OrderType;
            parameters[6].Value = strWhere;
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

		/// <summary>
		/// 验证单据库存数是否有超出
		/// </summary>
		/// <returns><c>true</c>, if order products stock was checked, <c>false</c> otherwise.</returns>
		/// <param name="OrderID">Order I.</param>
		public bool CheckOrderProductsStock(int OrderID)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append ("select oq.StorageID,oq.ProductsID,"+
				" (case"+
				" when oq.oType=2 then pq.oQ-oq.Quantity"+
				" when oq.oType=3 then pq.oQ-oq.Quantity"+
				" when oq.oType=5 then pq.oQ-oq.Quantity"+
				" when oq.oType=6 then pq.oQ-oq.Quantity"+
				" when oq.oType=7 then pq.oQ-oq.Quantity"+
				" when oq.oType=8 then pq.oQ-oq.Quantity"+
				//调拨单，计算源仓库库存，数量为负数的即为源仓库
				" when oq.oType=9 then case when oq.Quantity<0 then pq.oQ+oq.Quantity else 0 end"+
				" when oq.oType=10 then pq.oQ-oq.Quantity"+
				" when oq.oType=1 then pq.oQ+oq.Quantity"+
				" when oq.oType=4 then pq.oQ+oq.Quantity"+
				" else 0"+
				" end) as q"+
				" from ("+
				" select StorageID,ProductsID,sum(oQuantity) as Quantity,(select oType from tbOrderInfo where OrderID=@OrderID) as oType from tbOrderListInfo where OrderID=@OrderID and oWorkType=0 group by StorageID,ProductsID"+
				" ) as oq left join("+
				" select oop.ProductsID,oop.StorageID,oop.oQ from ("+
				" select op.ProductsID,op.StorageID,(SUM(BStorage)+SUM(pStorage)+SUM(pStorageIn)-SUM(pStorageOut)) as oQ from ("+
				" select ProductsStorageID,StorageID,ProductsID,pStorage,pStorageIn,pStorageOut,"+
				" isnull((select pQuantity from tbProductsStorageLogInfo where  pType=-1 and pState=0 and StorageID=tbProductsStorageInfo.StorageID and ProductsID=tbProductsStorageInfo.ProductsID),0) as BStorage from tbProductsStorageInfo where ProductsStorageID in("+
				" select MAX(ProductsStorageID) ProductsStorageID from tbProductsStorageInfo group by StorageID,ProductsID)"+
				" ) as op group by op.ProductsID,op.StorageID"+
				" ) as oop) as pq on oq.StorageID=pq.StorageID and oq.ProductsID=pq.ProductsID");
			SqlParameter[] parameters = {
				new SqlParameter("@OrderID", SqlDbType.Int,4),};
			parameters[0].Value = OrderID;
			bool _re = true;
			DataSet ds = DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(),parameters);
			if (ds.Tables.Count > 0) {
				DataTable dt = ds.Tables [0];
				for (int i = 0; i < dt.Rows.Count; i++) {
					if(decimal.Parse(dt.Rows[i]["q"].ToString())<0){
						_re = false;
						break;
					}
				}
			}
			return _re;
		}
    }
}
