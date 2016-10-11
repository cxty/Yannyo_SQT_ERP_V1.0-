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
    public class tbErpOrderInfo
    {
        #region ErpOrderInfo
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool ExistsErpOrderInfo(int O_ID, string O_ORDERNUM, int P_ID, int S_ID, int R_ID, DateTime O_CREATETIME)
        {
            return DatabaseProvider.GetInstance().ExistsErpOrderInfo(O_ID, O_ORDERNUM, P_ID, S_ID, R_ID, O_CREATETIME);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddErpOrderInfo(ErpOrderInfo model)
        {
            return DatabaseProvider.GetInstance().AddErpOrderInfo(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateErpOrderInfo(ErpOrderInfo model)
        {
            DatabaseProvider.GetInstance().UpdateErpOrderInfo(model);
        }

        /// <summary>
        /// 匹配数据,单据/产品匹配
        /// </summary>
        public static int[] SyncErpOrderInfo()
        {
            return DatabaseProvider.GetInstance().SyncErpOrderInfo();
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteErpOrderInfo(int ErpOrderID)
        {
            DatabaseProvider.GetInstance().DeleteErpOrderInfo(ErpOrderID);
        }
        public static void DeleteErpOrderInfoByOID(int O_ID)
        {
            DatabaseProvider.GetInstance().DeleteErpOrderInfoByOID(O_ID);
        }
        /// <summary>
        /// 删除一组数据
        /// </summary>
        public static void DeleteErpOrderInfo(string ErpOrderID)
        {
            if (ErpOrderID.Trim() != "")
            {
                ErpOrderID = "," + ErpOrderID + ",";
                ErpOrderID = Utils.ReSQLSetTxt(ErpOrderID);
                DatabaseProvider.GetInstance().DeleteErpOrderInfo(ErpOrderID);
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static ErpOrderInfo GetErpOrderInfoModel(int ErpOrderID)
        {
            return DatabaseProvider.GetInstance().GetErpOrderInfoModel(ErpOrderID);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataSet GetErpOrderInfoList(string strWhere)
        {
            return DatabaseProvider.GetInstance().GetErpOrderInfoList(strWhere);
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public static DataTable GetErpOrderInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
        {
            return DatabaseProvider.GetInstance().GetErpOrderInfoList(PageSize, PageIndex, strWhere, out pagetotal, OrderType, showFName);
        }

        /// <summary>
        /// 获取指定条件下的订单编号集合
        /// </summary>
        /// <param name="StoresID">门店客户编号</param>
        /// <param name="R_ID">单据类型编号</param>
        /// <param name="eDate">结束时间</param>
        public static string GetErpOrderIDStr(int StoresID, int R_ID, DateTime eDate)
        {
            return DatabaseProvider.GetInstance().GetErpOrderIDStr(StoresID, R_ID, eDate);
        }

        /// <summary>
        /// 修改订单标记
        /// </summary>
        /// <param name="StoresID">门店客户编号</param>
        /// <param name="R_ID">单据类型编号</param>
        /// <param name="eDate">结束时间</param>
        /// <param name="IsCheck">修改后标记,未对账=0,已对账=1</param>
        public static bool UpdateErpOrderCheck(int StoresID, int R_ID, DateTime eDate, int IsCheck)
        {
            return DatabaseProvider.GetInstance().UpdateErpOrderCheck(StoresID, R_ID, eDate, IsCheck);
        }
        /// <summary>
        /// 更新对账状态
        /// </summary>
        /// <param name="ErpOrderID">订单编号集合</param>
        /// <param name="t">对账状态:未对账=0,已对账=1</param>
        public static void UpdateErpOrderIsCheck(string ErpOrderID, int t)
        {
            DatabaseProvider.GetInstance().UpdateErpOrderIsCheck(ErpOrderID,t);
        }
        #endregion
    }
}
