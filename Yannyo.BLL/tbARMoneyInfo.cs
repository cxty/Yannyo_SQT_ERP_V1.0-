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
    public class tbARMoneyInfo
    {
        #region ARMoneyInfo
        public static bool ExistsARMoneyInfo(int ARMoneyID)
        {
            return DatabaseProvider.GetInstance().ExistsARMoneyInfo(ARMoneyID);
        }
        public static int AddARMoneyInfo(ARMoneyInfo model)
        {
            return DatabaseProvider.GetInstance().AddARMoneyInfo(model);
        }
        public static void UpdateARMoneyInfo(ARMoneyInfo model)
        {
            DatabaseProvider.GetInstance().UpdateARMoneyInfo(model);
        }
        public static void DeleteARMoneyInfo(int ARMoneyID)
        {
            DatabaseProvider.GetInstance().DeleteARMoneyInfo(ARMoneyID);
        }
        public static void DeleteARMoneyInfo(string ARMoneyID)
        {
            if (ARMoneyID.Trim() != "")
            {
                ARMoneyID = "," + ARMoneyID + ",";
                ARMoneyID = Utils.ReSQLSetTxt(ARMoneyID);

                //修改单据对账状态
                string[] ARMoneyIDArray = Utils.SplitString(ARMoneyID, ",");
                if (ARMoneyIDArray.Length > 0)
                {
                    ARMoneyInfo ari = new ARMoneyInfo();
                    try
                    {
                        foreach (string _ARMoneyID in ARMoneyIDArray)
                        {
                            if (_ARMoneyID.Trim() != "")
                            {
                                ari = GetARMoneyInfoModel(Utils.StrToInt(_ARMoneyID.Trim(),0));
                                if (ari != null)
                                { 
                                    if(ari.aErpOrderIDStr.Trim()!="")
                                    {
                                        ari.aErpOrderIDStr = "," + ari.aErpOrderIDStr + ",";
                                        ari.aErpOrderIDStr = Utils.ReSQLSetTxt(ari.aErpOrderIDStr);

                                        tbErpOrderInfo.UpdateErpOrderIsCheck(ari.aErpOrderIDStr, 0);
                                    }
                                }
                            }
                        }
                    }
                    finally {
                        ari = null;
                    }
                }

                DatabaseProvider.GetInstance().DeleteARMoneyInfo(ARMoneyID);
            }
        }
        public static ARMoneyInfo GetARMoneyInfoModel(int ARMoneyID)
        {
            return DatabaseProvider.GetInstance().GetARMoneyInfoModel(ARMoneyID);
        }
        public static DataSet GetARMoneyInfoList(string strWhere)
        {
            return DatabaseProvider.GetInstance().GetARMoneyInfoList(strWhere);
        }
        public static DataTable GetARMoneyInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
        {
            return DatabaseProvider.GetInstance().GetARMoneyInfoList(PageSize, PageIndex, strWhere, out  pagetotal, OrderType, showFName);
        }
        /// <summary>
        /// 指定时间段内应收数据
        /// </summary>
        /// <param name="C_CODE">门店,客户编码</param>
        /// <param name="C_NAME">门店名称</param>
        /// <param name="bDate">开始时间</param>
        /// <param name="eDate">结束时间</param>
        public static DataTable GetErpCustomerPay(string C_CODE, string C_NAME, DateTime bDate, DateTime eDate)
        {
            return DatabaseProvider.GetInstance().GetErpCustomerPay(C_CODE, C_NAME, bDate, eDate);
        }
        /// <summary>
        /// 指定时间段内应收数据
        /// </summary>
        /// <param name="C_CODE">门店,客户编码</param>
        /// <param name="C_NAME">门店名称</param>
        /// <param name="bDate">开始时间</param>
        /// <param name="eDate">结束时间</param>
        /// <param name="PaySystemName">结算系统名称</param>
        public static DataTable GetErpCustomerPay(string C_CODE, string C_NAME, DateTime bDate, DateTime eDate, string PaySystemName)
        {
            return DatabaseProvider.GetInstance().GetErpCustomerPay(C_CODE, C_NAME, bDate, eDate, PaySystemName);
        }
        #endregion
    }
}
