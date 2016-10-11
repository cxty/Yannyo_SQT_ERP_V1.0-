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


namespace Yannyo.BLL
{
	public class tbStorageProductLogDataInfo
	{
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public static int AddStorageProductLogDataInfo(StorageProductLogDataInfo model)
		{
			return DatabaseProvider.GetInstance().AddStorageProductLogDataInfo( model);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public static bool UpdateStorageProductLogDataInfo(StorageProductLogDataInfo model)
		{
			return DatabaseProvider.GetInstance().UpdateStorageProductLogDataInfo( model);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public static bool DeleteStorageProductLogDataInfo(int StorageProductLogDataID)
		{
			return DatabaseProvider.GetInstance().DeleteStorageProductLogDataInfo( StorageProductLogDataID);
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public static bool DeleteStorageProductLogDataInfoList(string StorageProductLogDataIDlist )
		{
			if (StorageProductLogDataIDlist.Trim () != "") {
				StorageProductLogDataIDlist = "," + StorageProductLogDataIDlist + ",";
				StorageProductLogDataIDlist = Utils.ReSQLSetTxt (StorageProductLogDataIDlist);
			}
			return DatabaseProvider.GetInstance().DeleteStorageProductLogDataInfoList( StorageProductLogDataIDlist );
		}
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public static StorageProductLogDataInfo GetStorageProductLogDataInfoModel(int StorageProductLogDataID)
		{
			return DatabaseProvider.GetInstance().GetStorageProductLogDataInfoModel( StorageProductLogDataID);
		}
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public static StorageProductLogDataInfo DataRowToStorageProductLogDataInfoModel(DataRow row)
		{
			return DatabaseProvider.GetInstance().DataRowToStorageProductLogDataInfoModel( row);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public static DataSet GetStorageProductLogDataInfoList(string strWhere)
		{
			return DatabaseProvider.GetInstance().GetStorageProductLogDataInfoList( strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public static DataSet GetStorageProductLogDataInfoList(int Top,string strWhere,string filedOrder)
		{
			return DatabaseProvider.GetInstance().GetStorageProductLogDataInfoList( Top, strWhere, filedOrder);
		}
		/// <summary>
		/// 获取记录总数
		/// </summary>
		public static int GetStorageProductLogDataInfoRecordCount(string strWhere)
		{
			return DatabaseProvider.GetInstance().GetStorageProductLogDataInfoRecordCount( strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public static DataSet GetStorageProductLogDataInfoListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return DatabaseProvider.GetInstance().GetStorageProductLogDataInfoListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public static DataTable GetStorageProductLogDataInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
		{
			return DatabaseProvider.GetInstance().GetStorageProductLogDataInfoList( PageSize,  PageIndex,  strWhere, out  pagetotal,  OrderType,  showFName);
		}


	}
}

