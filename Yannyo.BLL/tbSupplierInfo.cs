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
    public class tbSupplierInfo
    {
        #region SupplierInfo
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool ExistsSupplierInfo(string sName)
        {
            return DatabaseProvider.GetInstance().ExistsSupplierInfo(sName);
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool ExistsSupplierInfoCode(string sCode)
        {
            return DatabaseProvider.GetInstance().ExistsSupplierInfoCode(sCode);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddSupplierInfo(SupplierInfo model)
        {
            return DatabaseProvider.GetInstance().AddSupplierInfo(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateSupplierInfo(SupplierInfo model)
        {
            DatabaseProvider.GetInstance().UpdateSupplierInfo(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteSupplierInfo(int SupplierID)
        {
            DatabaseProvider.GetInstance().DeleteSupplierInfo(SupplierID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteSupplierInfo(string SupplierID)
        {
            if (SupplierID.Trim() != "")
            {
                SupplierID = "," + SupplierID + ",";
                SupplierID = Utils.ReSQLSetTxt(SupplierID);
                DatabaseProvider.GetInstance().DeleteSupplierInfo(SupplierID);
            }
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static SupplierInfo GetSupplierInfoModel(int SupplierID)
        {
            return DatabaseProvider.GetInstance().GetSupplierInfoModel(SupplierID);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static SupplierInfo GetSupplierInfoModelByName(string sName)
        {
            return DatabaseProvider.GetInstance().GetSupplierInfoModelByName(sName);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static SupplierInfo GetSupplierInfoModelByCode(string sCode)
        {
            return DatabaseProvider.GetInstance().GetSupplierInfoModelByCode(sCode);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataSet GetSupplierInfoList(string strWhere)
        {
            return DatabaseProvider.GetInstance().GetSupplierInfoList(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public static DataTable GetSupplierInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
        {
            return DatabaseProvider.GetInstance().GetSupplierInfoList(PageSize, PageIndex, strWhere, out  pagetotal, OrderType, showFName);
        }
        /// <summary>
        /// 返回最新未使用的对账单号
        /// </summary>
        /// <returns></returns>
        public static string GetNewSupplierNum()
        {
            GeneralConfigInfo ManageConfig = GeneralConfigs.GetConfig();
            ManageConfig.SupplierCode = (Convert.ToInt64(Config.GeneralConfigs.GetConfig().SupplierCode.Trim()) + 1).ToString();

            GeneralConfigs.Serialiaze(ManageConfig, Utils.GetMapPath(BaseConfigs.GetSysPath + "config/general.config"));
            BaseConfigs.ResetConfig();

            return ManageConfig.SupplierCode;
        }

        #endregion
    }
}
