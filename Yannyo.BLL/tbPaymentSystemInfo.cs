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
    public class tbPaymentSystemInfo
    {
        #region PaymentSystemInfo
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool ExistsPaymentSystem(string pName)
        {
            return DatabaseProvider.GetInstance().ExistsPaymentSystem(pName);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddPaymentSystem(PaymentSystemInfo model)
        {
            return DatabaseProvider.GetInstance().AddPaymentSystem(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdatePaymentSystem(PaymentSystemInfo model)
        {
            DatabaseProvider.GetInstance().UpdatePaymentSystem(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeletePaymentSystem(int PaymentSystemID)
        {
            DatabaseProvider.GetInstance().DeletePaymentSystem(PaymentSystemID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeletePaymentSystem(string PaymentSystemID)
        {
            if (PaymentSystemID.Trim() != "")
            {
                PaymentSystemID = "," + PaymentSystemID + ",";
                PaymentSystemID = Utils.ReSQLSetTxt(PaymentSystemID);
                DatabaseProvider.GetInstance().DeletePaymentSystem(PaymentSystemID);
            }
        }
        
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static PaymentSystemInfo GetPaymentSystemModel(int PaymentSystemID)
        {
            return DatabaseProvider.GetInstance().GetPaymentSystemModel(PaymentSystemID);
        }
        public static PaymentSystemInfo GetPaymentSystemModel(string PaymentSystemName)
        {
            return DatabaseProvider.GetInstance().GetPaymentSystemModel(PaymentSystemName);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataSet GetPaymentSystemList(string strWhere)
        {
            return DatabaseProvider.GetInstance().GetPaymentSystemList(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public static DataTable GetPaymentSystemList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
        {
            return DatabaseProvider.GetInstance().GetPaymentSystemList(PageSize, PageIndex, strWhere, out  pagetotal, OrderType, showFName);
        }
        #endregion
    }
}
