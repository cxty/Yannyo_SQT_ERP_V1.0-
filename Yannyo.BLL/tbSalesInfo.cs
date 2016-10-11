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
    public class tbSalesInfo
    {
        #region  SalesInfo
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool ExistsSalesInfo(int SalesID)
        {
            return DatabaseProvider.GetInstance().ExistsSalesInfo(SalesID);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddSalesInfo(SalesInfo model)
        {
            return DatabaseProvider.GetInstance().AddSalesInfo(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateSalesInfo(SalesInfo model)
        {
            DatabaseProvider.GetInstance().UpdateSalesInfo(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteSalesInfo(int SalesID)
        {
            DatabaseProvider.GetInstance().DeleteSalesInfo(SalesID);
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="SalesID"></param>
        /// <param name="sDateTime"></param>
        public static void DeleteSalesInfo(string SalesID, DateTime sDateTime)
        { 
            DatabaseProvider.GetInstance().DeleteSalesInfo( SalesID,  sDateTime);
        }
        /// <summary>
        /// 删除一组数据
        /// </summary>
        public static void DeleteSalesInfo(string SalesID)
        {
            if (SalesID.Trim() != "")
            {
                SalesID = "," + SalesID + ",";
                SalesID = Utils.ReSQLSetTxt(SalesID);
                DatabaseProvider.GetInstance().DeleteSalesInfo(SalesID);
            }
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static SalesInfo GetSalesInfoModel(int SalesID)
        {
            return DatabaseProvider.GetInstance().GetSalesInfoModel(SalesID);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataSet GetSalesInfoList(string strWhere)
        {
            return DatabaseProvider.GetInstance().GetSalesInfoList(strWhere);
        }
        /// <summary>
        /// 匹配数据,单据/产品匹配
        /// </summary>
        public static int[] SyncSalesInfo()
        {
            return DatabaseProvider.GetInstance().SyncSalesInfo();
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public static DataTable GetSalesInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
        {
            return DatabaseProvider.GetInstance().GetSalesInfoList(PageSize, PageIndex, strWhere, out  pagetotal, OrderType, showFName);
        }
        /// <summary>
        /// 取未匹配数据
        /// </summary>
        /// <returns></returns>
        public static DataTable GetNOJoinDataSalesInfoList()
        {
            return DatabaseProvider.GetInstance().GetNOJoinDataSalesInfoList();
        }
        #endregion
    }
}
