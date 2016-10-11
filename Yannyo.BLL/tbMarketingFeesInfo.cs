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
    public class tbMarketingFeesInfo
    {
        #region  MarketingFeesInfo

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddMarketingFeesInfo(MarketingFeesInfo model)
        {
            return DatabaseProvider.GetInstance().AddMarketingFeesInfo(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateMarketingFeesInfo(MarketingFeesInfo model)
        {
            DatabaseProvider.GetInstance().UpdateMarketingFeesInfo(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteMarketingFeesInfo(int MarketingFeesID)
        {
            DatabaseProvider.GetInstance().DeleteMarketingFeesInfo(MarketingFeesID);
        }
        /// <summary>
        /// 删除一组数据
        /// </summary>
        public static void DeleteMarketingFeesInfo(string MarketingFeesID)
        {
            if (MarketingFeesID.Trim() != "")
            {
                MarketingFeesID = "," + MarketingFeesID + ",";
                MarketingFeesID = Utils.ReSQLSetTxt(MarketingFeesID);
                DatabaseProvider.GetInstance().DeleteMarketingFeesInfo(MarketingFeesID);
            }
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static MarketingFeesInfo GetMarketingFeesInfoModel(int MarketingFeesID)
        {
            return DatabaseProvider.GetInstance().GetMarketingFeesInfoModel(MarketingFeesID);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataSet GetMarketingFeesInfoList(string strWhere)
        {
            return DatabaseProvider.GetInstance().GetMarketingFeesInfoList(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public static DataTable GetMarketingFeesInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
        {
            return DatabaseProvider.GetInstance().GetMarketingFeesInfoList(PageSize, PageIndex, strWhere, out  pagetotal, OrderType, showFName);
        }
        #endregion
    }
}
