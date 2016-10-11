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
    public class tbStaffStoresInfo
    {
        #region  StaffStoresInfo

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddStaffStoresInfo(StaffStoresInfo model)
        {
            return DatabaseProvider.GetInstance().AddStaffStoresInfo(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateStaffStoresInfo(StaffStoresInfo model)
        {
            DatabaseProvider.GetInstance().UpdateStaffStoresInfo(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteStaffStoresInfo(int StaffStoresID)
        {
            DatabaseProvider.GetInstance().DeleteStaffStoresInfo(StaffStoresID);
        }
        /// <summary>
        /// 删除一组数据
        /// </summary>
        public static void DeleteStaffStoresInfo(string StaffStoresID)
        {
            if (StaffStoresID.Trim() != "")
            {
                StaffStoresID = "," + StaffStoresID + ",";
                StaffStoresID = Utils.ReSQLSetTxt(StaffStoresID);
                DatabaseProvider.GetInstance().DeleteStaffStoresInfo(StaffStoresID);
            }
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static StaffStoresInfo GetStaffStoresInfoModel(int StaffStoresID)
        {
            return DatabaseProvider.GetInstance().GetStaffStoresInfoModel(StaffStoresID);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataSet GetStaffStoresInfoList(string strWhere)
        {
            return DatabaseProvider.GetInstance().GetStaffStoresInfoList(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public static DataTable GetStaffStoresInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
        {
            return DatabaseProvider.GetInstance().GetStaffStoresInfoList(PageSize, PageIndex, strWhere, out  pagetotal, OrderType, showFName);
        }
        /// <summary>
        /// 人员上离岗记录
        /// </summary>
        public static DataTable GetStaff_StoresList(int StaffID, DateTime bDate, DateTime eDate, int sType)
        {
            return DatabaseProvider.GetInstance().GetStaff_StoresList(StaffID, bDate, eDate, sType);
        }
        public static DataTable GetStaff_StoresList(int StaffID, int StoresID, DateTime bDate, DateTime eDate, int sType)
        {
            return DatabaseProvider.GetInstance().GetStaff_StoresList(StaffID, StoresID, bDate, eDate, sType);
        }
        /// <summary>
        /// 取指定门店目前上岗中的人员信息
        /// </summary>
        /// <param name="StoresID"></param>
        /// <param name="sType">人员类型,公司=0,业务员=1,促销员=2,其他=3</param>
        /// <returns></returns>
        public static StaffInfo GetStaffByStores(int StoresID, int sType)
        { 
            return DatabaseProvider.GetInstance().GetStaffByStores( StoresID,  sType);
        }
        #endregion
    }
}
