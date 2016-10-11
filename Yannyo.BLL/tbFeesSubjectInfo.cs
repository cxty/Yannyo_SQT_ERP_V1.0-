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
    public class tbFeesSubjectInfo
    {
        #region  FeesSubjectInfo
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool ExistsFeesSubjectInfo(string fName)
        {
            return DatabaseProvider.GetInstance().ExistsFeesSubjectInfo(fName);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddFeesSubjectInfo(FeesSubjectInfo model)
        {
            return DatabaseProvider.GetInstance().AddFeesSubjectInfo(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateFeesSubjectInfo(FeesSubjectInfo model)
        {
            DatabaseProvider.GetInstance().UpdateFeesSubjectInfo(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteFeesSubjectInfo(int FeesSubjectID)
        {
            DatabaseProvider.GetInstance().DeleteFeesSubjectInfo(FeesSubjectID);
        }
        /// <summary>
        /// 删除一组数据
        /// </summary>
        public static void DeleteFeesSubjectInfo(string FeesSubjectID)
        {
            if (FeesSubjectID.Trim() != "")
            {
                FeesSubjectID = "," + FeesSubjectID + ",";
                FeesSubjectID = Utils.ReSQLSetTxt(FeesSubjectID);
                DatabaseProvider.GetInstance().DeleteFeesSubjectInfo(FeesSubjectID);
            }
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static FeesSubjectInfo GetFeesSubjectInfoModel(int FeesSubjectID)
        {
            return DatabaseProvider.GetInstance().GetFeesSubjectInfoModel(FeesSubjectID);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static FeesSubjectInfo GetFeesSubjectInfoModelByName(string fName)
        {
            return DatabaseProvider.GetInstance().GetFeesSubjectInfoModelByName(fName);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataSet GetFeesSubjectInfoList(string strWhere)
        {
            return DatabaseProvider.GetInstance().GetFeesSubjectInfoList(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public static DataTable GetFeesSubjectInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
        {
            return DatabaseProvider.GetInstance().GetFeesSubjectInfoList(PageSize, PageIndex, strWhere, out  pagetotal, OrderType, showFName);
        }
        #endregion
    }
}
