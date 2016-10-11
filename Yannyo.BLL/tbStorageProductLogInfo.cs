using System;
using System.Data;
using System.Data.Common;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

using Yannyo.Common;
using Yannyo.Data;
using Yannyo.Config;
using Yannyo.Entity;
using Yannyo.SOAP;

namespace Yannyo.BLL
{
	public class tbStorageProductLogInfo
	{
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public static int AddStorageProductLogInfo(StorageProductLogInfo model)
		{
			return DatabaseProvider.GetInstance().AddStorageProductLogInfo( model);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public static bool UpdateStorageProductLogInfo(StorageProductLogInfo model)
		{
			return DatabaseProvider.GetInstance().UpdateStorageProductLogInfo( model);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public static bool DeleteStorageProductLogInfo(int StorageProductLogID)
		{
			return DatabaseProvider.GetInstance().DeleteStorageProductLogInfo( StorageProductLogID);
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public static bool DeleteStorageProductLogInfoList(string StorageProductLogIDlist )
		{
			if (StorageProductLogIDlist.Trim () != "") {
				StorageProductLogIDlist = "," + StorageProductLogIDlist + ",";
				StorageProductLogIDlist = Utils.ReSQLSetTxt (StorageProductLogIDlist);
			}
			return DatabaseProvider.GetInstance().DeleteStorageProductLogInfoList( StorageProductLogIDlist);
		}
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public static StorageProductLogInfo GetStorageProductLogInfoModel(int StorageProductLogID)
		{
			return DatabaseProvider.GetInstance().GetStorageProductLogInfoModel( StorageProductLogID);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public static DataSet GetStorageProductLogInfoList(string strWhere)
		{
			return DatabaseProvider.GetInstance().GetStorageProductLogInfoList( strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public static DataSet GetStorageProductLogInfoList(int Top,string strWhere,string filedOrder)
		{
			return DatabaseProvider.GetInstance().GetStorageProductLogInfoList( Top, strWhere, filedOrder);
		}
		/// <summary>
		/// 获取记录总数
		/// </summary>
		public static int GetStorageProductLogInfoRecordCount(string strWhere)
		{
			return DatabaseProvider.GetInstance().GetStorageProductLogInfoRecordCount( strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public static DataSet GetStorageProductLogInfoListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return DatabaseProvider.GetInstance().GetStorageProductLogInfoListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public static DataTable GetStorageProductLogInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
		{
			return DatabaseProvider.GetInstance().GetStorageProductLogInfoList( PageSize,  PageIndex,  strWhere, out  pagetotal,  OrderType,  showFName);
		}

		public static int GetStorageProductLogCutLenFromOrderID(int OrderID){
			return DatabaseProvider.GetInstance ().GetStorageProductLogCutLenFromOrderID (OrderID);
		}

		/// <summary>
		/// 整理发货记录并入单据详细列表返回
		/// </summary>
		/// <returns>The storage product log list IN order list.</returns>
		/// <param name="OrderID">Order I.</param>
		public static DataSet GetStorageProductLogListINOrderList(int OrderID){
			return DatabaseProvider.GetInstance ().GetStorageProductLogListINOrderList (OrderID);
		}
		/// <summary>
		/// 仓库出入库明细表
		/// </summary>
		/// <returns>表1：上期结余，表2：本期明细</returns>
		/// <param name="StorageID">Storage I.</param>
		/// <param name="ProductsID">Products I.</param>
		/// <param name="bDate">B date.</param>
		/// <param name="eDate">E date.</param>
		public static DataSet GetStorageList(int StorageClassID,int StorageID,int ProductsID,DateTime bDate,DateTime eDate)
		{
			return DatabaseProvider.GetInstance ().GetStorageList (StorageClassID,StorageID, ProductsID, bDate, eDate);
		}
	}
}

