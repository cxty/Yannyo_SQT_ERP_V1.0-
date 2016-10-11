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
    public class tbYHsysInfo
    {
        #region YHsysInfo
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool ExistsYHsysInfo(string yName)
        {
            return DatabaseProvider.GetInstance().ExistsYHsysInfo(yName);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddYHsysInfo(YHsysInfo model)
        {
            return DatabaseProvider.GetInstance().AddYHsysInfo(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateYHsysInfo(YHsysInfo model)
        {
             DatabaseProvider.GetInstance().UpdateYHsysInfo(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteYHsysInfo(int YHsysID)
        {
            DatabaseProvider.GetInstance().DeleteYHsysInfo(YHsysID);
        }

        /// <summary>
        /// 删除一组数据
        /// </summary>
        public static void DeleteYHsysInfo(string YHsysID)
        {
            if (YHsysID.Trim() != "")
            {
                YHsysID = "," + YHsysID + ",";
                YHsysID = Utils.ReSQLSetTxt(YHsysID);
                DatabaseProvider.GetInstance().DeleteYHsysInfo(YHsysID);
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static YHsysInfo GetYHsysInfoModel(int YHsysID)
        {
            return DatabaseProvider.GetInstance().GetYHsysInfoModel(YHsysID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static YHsysInfo GetYHsysInfoModelByName(string yName)
        {
            return DatabaseProvider.GetInstance().GetYHsysInfoModelByName(yName);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataSet GetYHsysInfoList(string strWhere)
        {
            return DatabaseProvider.GetInstance().GetYHsysInfoList(strWhere);
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public static DataTable GetYHsysInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
        {
            return DatabaseProvider.GetInstance().GetYHsysInfoList(PageSize, PageIndex, strWhere, out pagetotal, OrderType, showFName);
        }
        #endregion
    }
}
