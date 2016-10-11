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
    public class tbValenceInfo
    {
        #region  ValenceInfo

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddValenceInfo(ValenceInfo model)
        {
            return DatabaseProvider.GetInstance().AddValenceInfo(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateValenceInfo(ValenceInfo model)
        {
            DatabaseProvider.GetInstance().UpdateValenceInfo(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteValenceInfo(int ValenceID)
        {
            DatabaseProvider.GetInstance().DeleteValenceInfo(ValenceID);
        }
        /// <summary>
        /// 删除一组数据
        /// </summary>
        public static void DeleteValenceInfo(string ValenceID)
        {
            if (ValenceID.Trim() != "")
            {
                ValenceID = "," + ValenceID + ",";
                ValenceID = Utils.ReSQLSetTxt(ValenceID);
                DatabaseProvider.GetInstance().DeleteValenceInfo(ValenceID);
            }
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static ValenceInfo GetValenceInfoModel(int ValenceID)
        {
            return DatabaseProvider.GetInstance().GetValenceInfoModel(ValenceID);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataSet GetValenceInfoList(string strWhere)
        {
            return DatabaseProvider.GetInstance().GetValenceInfoList(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public static DataTable GetValenceInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
        {
            return DatabaseProvider.GetInstance().GetValenceInfoList(PageSize, PageIndex, strWhere, out  pagetotal, OrderType, showFName);
        }
        #endregion
    }
}
