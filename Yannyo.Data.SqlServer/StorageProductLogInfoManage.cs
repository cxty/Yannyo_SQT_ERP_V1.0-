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
		/// 增加一条数据
		/// </summary>
		public int AddStorageProductLogInfo(StorageProductLogInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("declare @StorageProductLogDataID int;");
			strSql.Append("insert into tbStorageProductLogInfo(");
			strSql.Append("StorageID,StaffID,OrderID,splRemake,splAppendTime)");
			strSql.Append(" values (");
			strSql.Append("@StorageID,@StaffID,@OrderID,@splRemake,@splAppendTime)");
			strSql.Append(";SET @StorageProductLogDataID = SCOPE_IDENTITY();select @StorageProductLogDataID;");

			if (model.StorageOrderListDataJson != null) {
				foreach (StorageOrder sol in model.StorageOrderListDataJson.OrderListJson) {
					if (sol != null) {
						strSql.Append(" insert into tbStorageProductLogDataInfo(OrderListID,StorageProductLogID,StorageID,ProductsID,pQuantity)");
						strSql.Append (" values("+sol.OrderListID+",@StorageProductLogDataID,"+sol.StorageID+","+sol.ProductsID+","+sol.pQuantity+");");
					}
				}
			}

			SqlParameter[] parameters = {

				new SqlParameter("@StorageID", SqlDbType.Int,4),
				new SqlParameter("@StaffID", SqlDbType.Int,4),
				new SqlParameter("@OrderID", SqlDbType.Int,4),
				new SqlParameter("@splRemake", SqlDbType.VarChar,512),
				new SqlParameter("@splAppendTime", SqlDbType.DateTime)};

			parameters[0].Value = model.StorageID;
			parameters[1].Value = model.StaffID;
			parameters[2].Value = model.OrderID;
			parameters[3].Value = model.splRemake;
			parameters[4].Value = model.splAppendTime;

			object obj = DbHelper.ExecuteScalar(CommandType.Text,strSql.ToString(),parameters);
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
		public bool UpdateStorageProductLogInfo(StorageProductLogInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tbStorageProductLogInfo set ");

			strSql.Append("StorageID=@StorageID,");
			strSql.Append("StaffID=@StaffID,");
			strSql.Append("OrderID=@OrderID,");
			strSql.Append("splRemake=@splRemake,");
			strSql.Append("splAppendTime=@splAppendTime");
			strSql.Append(" where StorageProductLogID=@StorageProductLogID");
			SqlParameter[] parameters = {
				new SqlParameter("@StorageID", SqlDbType.Int,4),
				new SqlParameter("@StaffID", SqlDbType.Int,4),
				new SqlParameter("@OrderID", SqlDbType.Int,4),
				new SqlParameter("@splRemake", SqlDbType.VarChar,512),
				new SqlParameter("@splAppendTime", SqlDbType.DateTime),
				new SqlParameter("@StorageProductLogID", SqlDbType.Int,4)};
			parameters[0].Value = model.StorageID;
			parameters[1].Value = model.StaffID;
			parameters[2].Value = model.OrderID;
			parameters[3].Value = model.splRemake;
			parameters[4].Value = model.splAppendTime;
			parameters[5].Value = model.StorageProductLogID;


			int rows=DbHelper.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
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
		public bool DeleteStorageProductLogInfo(int StorageProductLogID)
		{

			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tbStorageProductLogInfo ");
			strSql.Append(" where StorageProductLogID=@StorageProductLogID");
			SqlParameter[] parameters = {
				new SqlParameter("@StorageProductLogID", SqlDbType.Int,4)
			};
			parameters[0].Value = StorageProductLogID;

			int rows=DbHelper.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
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
		/// 批量删除数据
		/// </summary>
		public bool DeleteStorageProductLogInfoList(string StorageProductLogIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tbStorageProductLogInfo ");
			strSql.Append(" where StorageProductLogID in ("+StorageProductLogIDlist + ")  ");
			int rows=DbHelper.ExecuteNonQuery(CommandType.Text,strSql.ToString());
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
		public StorageProductLogInfo DataRowToStorageProductLogInfoModel(DataRow row)
		{
			StorageProductLogInfo model=new StorageProductLogInfo();
			if (row != null)
			{
				if(row["StorageProductLogID"]!=null && row["StorageProductLogID"].ToString()!="")
				{
					model.StorageProductLogID=int.Parse(row["StorageProductLogID"].ToString());
				}
				if(row["StorageID"]!=null && row["StorageID"].ToString()!="")
				{
					model.StorageID=int.Parse(row["StorageID"].ToString());
				}
				if(row["StaffID"]!=null && row["StaffID"].ToString()!="")
				{
					model.StaffID=int.Parse(row["StaffID"].ToString());
				}
				if(row["OrderID"]!=null && row["OrderID"].ToString()!="")
				{
					model.OrderID=int.Parse(row["OrderID"].ToString());
				}
				if(row["splRemake"]!=null)
				{
					model.splRemake=row["splRemake"].ToString();
				}
				if(row["splAppendTime"]!=null && row["splAppendTime"].ToString()!="")
				{
					model.splAppendTime=DateTime.Parse(row["splAppendTime"].ToString());
				}

			}
			return model;
		}
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public StorageProductLogInfo GetStorageProductLogInfoModel(int StorageProductLogID)
		{

			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 StorageProductLogID,StorageID,StaffID,OrderID,splRemake,splAppendTime from tbStorageProductLogInfo ");
			strSql.Append(" where StorageProductLogID=@StorageProductLogID");
			SqlParameter[] parameters = {
				new SqlParameter("@StorageProductLogID", SqlDbType.Int,4)
			};
			parameters[0].Value = StorageProductLogID;

			//StorageProductLogInfo model=new StorageProductLogInfo();
			DataSet ds=DbHelper.ExecuteDataset(CommandType.Text,strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToStorageProductLogInfoModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}




		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetStorageProductLogInfoList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select StorageProductLogID,StorageID,StaffID,OrderID,splRemake,splAppendTime ");
			strSql.Append(" FROM tbStorageProductLogInfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelper.ExecuteDataset(CommandType.Text,strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetStorageProductLogInfoList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" StorageProductLogID,StorageID,StaffID,OrderID,splRemake,splAppendTime ");
			strSql.Append(" FROM tbStorageProductLogInfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelper.ExecuteDataset(CommandType.Text,strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetStorageProductLogInfoRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM tbStorageProductLogInfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelper.ExecuteScalar(CommandType.Text,strSql.ToString());
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
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetStorageProductLogInfoListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.StorageProductLogID desc");
			}
			strSql.Append(")AS Row, T.*  from tbStorageProductLogInfo T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelper.ExecuteDataset(CommandType.Text,strSql.ToString());
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataTable GetStorageProductLogInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
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
			parameters[0].Value = "tbStorageProductLogInfo";
			parameters[1].Value = "StorageProductLogID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 1;
			parameters[5].Value = OrderType;
			parameters[6].Value = strWhere;
			parameters[7].Value = showFName + ",(select sName from tbStaffInfo where StaffID=tbStorageProductLogInfo.StaffID) as StaffName,"+
			                      "(select sName from tbStorageInfo where StorageID=tbStorageProductLogInfo.StorageID) as StorageName,"+
			                      "(select oOrderNum from tbOrderInfo where OrderID=tbStorageProductLogInfo.OrderID) as OrderNum ";
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
		/// 取未完成发货商品总数
		/// </summary>
		/// <returns>The storage product log cut length from order I.</returns>
		/// <param name="OrderID">Order I.</param>
		public int GetStorageProductLogCutLenFromOrderID(int OrderID){
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ISNULL((SELECT sum(oQuantity) FROM tbOrderListInfo where OrderID=@OrderID and oWorkType<>0),0)- ");
			strSql.Append ("ISNULL((select sum(d.pQuantity) from tbStorageProductLogDataInfo as d left join tbStorageProductLogInfo as l on d.StorageProductLogID=l.StorageProductLogID where l.OrderID=@OrderID),0)");
			SqlParameter[] parameters = {
				new SqlParameter("@OrderID", SqlDbType.Int),
			};
			parameters [0].Value = OrderID;
			object obj = DbHelper.ExecuteScalar(CommandType.Text,strSql.ToString(),parameters);
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
		/// 整理发货记录并入单据详细列表返回
		/// </summary>
		/// <returns>The storage product log list IN order list.</returns>
		/// <param name="OrderID">Order I.</param>
		public DataSet GetStorageProductLogListINOrderList(int OrderID){
			StringBuilder strSql=new StringBuilder();
			strSql.Append ("select ol.OrderListID,ol.StorageID,ol.ProductsID,ol.oQuantity,ISNULL(sl.pQuantity,0) as pQuantity ");
			strSql.Append (" from (select OrderListID,StorageID,ProductsID,oQuantity from tbOrderListInfo where OrderID=@OrderID and oWorkType<>0) as ol ");
			strSql.Append (" left join (select d.OrderListID,d.StorageID,d.ProductsID,sum(ISNULL(d.pQuantity,0)) as pQuantity from tbStorageProductLogDataInfo as d left join tbStorageProductLogInfo as l on d.StorageProductLogID=l.StorageProductLogID where l.OrderID=@OrderID group by d.OrderListID,d.StorageID,d.ProductsID) as sl ");
			strSql.Append (" on ol.OrderListID = sl.OrderListID and ol.StorageID=sl.StorageID and ol.ProductsID=sl.ProductsID ");
			SqlParameter[] parameters = {
				new SqlParameter("@OrderID", SqlDbType.Int),
			};
			parameters [0].Value = OrderID;
			return DbHelper.ExecuteDataset(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// 取仓库操作报表，table[0]为起初表，table[1]为区间列表
		/// </summary>
		/// <returns>The storage list.</returns>
		/// <param name="StorageID">Storage I.</param>
		/// <param name="ProductsID">Products I.</param>
		/// <param name="bDate">B date.</param>
		/// <param name="eDate">E date.</param>
		public DataSet GetStorageList(int StorageClassID,int StorageID,int ProductsID,DateTime bDate,DateTime eDate)
		{
			string _where = " where 1=1 ";
			if(StorageClassID > 0){
				_where += " and p.StorageID in(select StorageID from tbStorageInfo where StorageClassID="+StorageClassID+") ";
			}
			if (StorageID > 0) {
				_where += " and p.StorageID="+StorageID;
			}
			if (ProductsID > 0) {
				_where += " and p.ProductsID="+ProductsID;
			}
			StringBuilder strSql=new StringBuilder();
			/*指定时间范围前合计数，期初数*/
			strSql.Append ("select p.StorageID,isnull(ss.Quantity,0) Quantity,p.ProductsID,p.pBarcode,p.pName,p.pUnits,p.pMaxUnits,p.pToBoxNo ");
			strSql.Append ("from (select * from tbProductsInfo,tbStorageInfo where tbProductsInfo.pState=0 and tbStorageInfo.sState=0 ) as p left join ");
			strSql.Append ("(select so.StorageID,so.ProductsID,");
			strSql.Append ("sum(case when so.oType in(1,4) then isnull(so.pQuantity,0) else -isnull(so.pQuantity,0) end) as Quantity ");
			strSql.Append ("from ( ");
			strSql.Append ("select ");
			strSql.Append ("dl.StorageID,");
			strSql.Append ("dl.ProductsID,");
			strSql.Append ("dl.pQuantity,");
			strSql.Append ("o.OrderID,");
			strSql.Append ("o.oOrderNum,");
			strSql.Append ("o.oType,");
			strSql.Append ("o.oAppendTime,");
			strSql.Append ("o.oOrderDateTime,");
			strSql.Append ("o.oState,");
			strSql.Append ("o.oSteps ");
			strSql.Append ("from ( ");
			strSql.Append ("select ");
			strSql.Append ("	l.OrderID,");
			strSql.Append ("	d.StorageID,");
			strSql.Append ("	d.ProductsID,");
			strSql.Append ("	d.pQuantity ");
			strSql.Append ("from tbStorageProductLogDataInfo as d left join tbStorageProductLogInfo as l on d.StorageProductLogID=l.StorageProductLogID ");
			strSql.Append ("	where (l.splAppendTime < @bDate) ");
			strSql.Append ("	group by d.StorageID,d.ProductsID,d.pQuantity,l.OrderID ");
			strSql.Append (") as dl left join tbOrderInfo as o on dl.OrderID=o.OrderID ");
			strSql.Append (") as so ");
			strSql.Append ("group by so.StorageID,so.ProductsID ");
			strSql.Append (") as ss on p.ProductsID=ss.ProductsID and p.StorageID=ss.StorageID "+_where+"; ");


			/*指定时间范围内列表*/

			strSql.Append ("select ");
			strSql.Append ("p.StaffID, ");
			strSql.Append ("p.splRemake, ");
			strSql.Append ("p.splAppendTime, ");
			strSql.Append ("p.OrderListID, ");
			strSql.Append ("p.StorageID, ");
			strSql.Append ("p.ProductsID, ");
			strSql.Append ("(case when o.oType in(1,4) then isnull(p.pQuantity,0) else -isnull(p.pQuantity,0) end) Quantity, ");
			strSql.Append ("o.OrderID, ");
			strSql.Append ("o.oOrderNum, ");
			strSql.Append ("o.oType, ");
			strSql.Append ("o.oAppendTime, ");
			strSql.Append ("o.oOrderDateTime, ");
			strSql.Append ("o.oState, ");
			strSql.Append ("o.oSteps, ");
			strSql.Append ("o.StoresID, ");
			strSql.Append ("o.oCustomersName, ");
			strSql.Append ("(case ");
			strSql.Append ("     when  o.oType in(1,2) then ");
			strSql.Append ("     (select su.sName from tbSupplierInfo su where su.SupplierID=o.StoresID) ");
			strSql.Append ("     when  o.oType in(3,4,5,6,7,11) then ");
			strSql.Append ("     (select so.sName from tbStoresInfo so where so.StoresID=o.StoresID) ");
			strSql.Append ("	  when  o.oType = 9 then ");
			strSql.Append ("     (select ss.sName from tbStorageInfo ss where ss.StorageID=o.StoresID) ");
			strSql.Append ("     end) as StoresSupplierName ");
			strSql.Append ("from ( ");
			strSql.Append ("	select l.StaffID, ");
			strSql.Append ("	l.OrderID, ");
			strSql.Append ("	l.splRemake, ");
			strSql.Append ("	l.splAppendTime, ");
			strSql.Append ("	d.OrderListID, ");
			strSql.Append ("	d.StorageID, ");
			strSql.Append ("	d.ProductsID, ");
			strSql.Append ("	d.pQuantity ");
			strSql.Append ("	from tbStorageProductLogDataInfo as d left join tbStorageProductLogInfo as l on d.StorageProductLogID=l.StorageProductLogID ");
			strSql.Append ("	where (l.splAppendTime between @bDate and @eDate) ");
			strSql.Append ("	) as p left join tbOrderInfo as o on p.OrderID=o.OrderID "+_where+" ; ");

			/*商品表*/
			strSql.Append ("select * from tbProductsInfo where pState=0; ");
			/*仓库表*/
			strSql.Append ("select * from tbStorageInfo where sState=0; ");


			SqlParameter[] parameters = {
				new SqlParameter("@bDate", SqlDbType.DateTime),
				new SqlParameter("@eDate", SqlDbType.DateTime),
			};

			parameters [0].Value = bDate;
			parameters [1].Value = eDate;

			return DbHelper.ExecuteDataset(CommandType.Text,strSql.ToString(),parameters);

		}

	}
}

