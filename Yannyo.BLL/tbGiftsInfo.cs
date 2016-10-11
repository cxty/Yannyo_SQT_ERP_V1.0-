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
    public class tbGiftsInfo
    {
        #region  GiftsInfo

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddGiftsInfo(GiftsInfo model)
        {
            return DatabaseProvider.GetInstance().AddGiftsInfo(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateGiftsInfo(GiftsInfo model)
        {
            DatabaseProvider.GetInstance().UpdateGiftsInfo(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteGiftsInfo(int GiftsID)
        {
            DatabaseProvider.GetInstance().DeleteGiftsInfo(GiftsID);
        }
        /// <summary>
        /// 删除一组数据
        /// </summary>
        public static void DeleteGiftsInfo(string GiftsID)
        {
            if (GiftsID.Trim() != "")
            {
                GiftsID = "," + GiftsID + ",";
                GiftsID = Utils.ReSQLSetTxt(GiftsID);
                DatabaseProvider.GetInstance().DeleteGiftsInfo(GiftsID);
            }
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static GiftsInfo GetGiftsInfoModel(int GiftsID)
        {
            return DatabaseProvider.GetInstance().GetGiftsInfoModel(GiftsID);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataSet GetGiftsInfoList(string strWhere)
        {
            return DatabaseProvider.GetInstance().GetGiftsInfoList(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public static DataTable GetGiftsInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
        {
            return DatabaseProvider.GetInstance().GetGiftsInfoList(PageSize, PageIndex, strWhere, out pagetotal, OrderType, showFName);
        }
        #endregion
    }
}
