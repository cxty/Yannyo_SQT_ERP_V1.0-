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
using System.Collections;
using System.Xml;

namespace Yannyo.BLL
{
    public class Purchasingpayment
    {
        public static DataTable getPayment()
        {
            return DatabaseProvider.GetInstance().getPayment();
        }
        public static DataTable GetPaymentInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
        {
            return DatabaseProvider.GetInstance().GetPaymentInfoList(PageSize, PageIndex, strWhere, out pagetotal, OrderType, showFName);
        }
        public static DataTable GetPurchasingPaymentReport(int sObjectType, DateTime sDate, int ReType)
        {
            return DatabaseProvider.GetInstance().GetPurchasingPaymentReport(sObjectType, sDate, ReType);
        }
        public static DataTable GetProceedsReport(int sObjectType, DateTime sDate, int ReType)
        {
            return DatabaseProvider.GetInstance().GetProceedsReport(sObjectType, sDate, ReType);
        }
    }
}
