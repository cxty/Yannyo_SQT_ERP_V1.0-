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
    public class tbCostValenceInfo
    {
        #region CostValenceInfo
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool ExistsCostValenceInfo(int ProductsID, DateTime cDateTime)
        {
            return DatabaseProvider.GetInstance().ExistsCostValenceInfo(ProductsID, cDateTime);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddCostValenceInfo(CostValenceInfo model)
        {
            return DatabaseProvider.GetInstance().AddCostValenceInfo(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateCostValenceInfo(CostValenceInfo model)
        {
            DatabaseProvider.GetInstance().UpdateCostValenceInfo(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteCostValenceInfo(int CostVelenceID)
        {
            DatabaseProvider.GetInstance().DeleteCostValenceInfo(CostVelenceID);
        }

        /// <summary>
        /// 删除一组数据
        /// </summary>
        public static void DeleteCostValenceInfo(string CostVelenceID)
        {
            if (CostVelenceID.Trim() != "")
            {
                CostVelenceID = "," + CostVelenceID + ",";
                CostVelenceID = Utils.ReSQLSetTxt(CostVelenceID);
                DatabaseProvider.GetInstance().DeleteCostValenceInfo(CostVelenceID);
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static CostValenceInfo GetCostValenceInfoModel(int CostVelenceID)
        {
            return DatabaseProvider.GetInstance().GetCostValenceInfoModel(CostVelenceID);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataSet GetCostValenceInfoList(string strWhere)
        {
            return DatabaseProvider.GetInstance().GetCostValenceInfoList(strWhere);
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public static DataTable GetCostValenceInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
        {
            return DatabaseProvider.GetInstance().GetCostValenceInfoList(PageSize, PageIndex, strWhere, out pagetotal, OrderType, showFName);
        }
        #endregion
    }
}
