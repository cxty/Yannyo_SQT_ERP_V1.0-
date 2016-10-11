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
    public class tbAPMoneyInfo
    {
        #region APMoneyInfo
        public static bool ExistsAPMoneyInfo(int APMoneyID)
        {
            return DatabaseProvider.GetInstance().ExistsAPMoneyInfo(APMoneyID);
        }
        public static int AddAPMoneyInfo(APMoneyInfo model)
        {
            return DatabaseProvider.GetInstance().AddAPMoneyInfo(model);
        }
        public static void UpdateAPMoneyInfo(APMoneyInfo model)
        {
            DatabaseProvider.GetInstance().UpdateAPMoneyInfo(model);
        }
        public static void DeleteAPMoneyInfo(int APMoneyID)
        {
            DatabaseProvider.GetInstance().DeleteAPMoneyInfo(APMoneyID);
        }
        public static void DeleteAPMoneyInfo(string APMoneyID)
        {
            if (APMoneyID.Trim() != "")
            {
                APMoneyID = "," + APMoneyID + ",";
                APMoneyID = Utils.ReSQLSetTxt(APMoneyID);
                //修改单据对账状态
                string[] APMoneyIDArray = Utils.SplitString(APMoneyID, ",");
                if (APMoneyIDArray.Length > 0)
                {
                    APMoneyInfo api = new APMoneyInfo();
                    try
                    {
                        foreach (string _APMoneyID in APMoneyIDArray)
                        {
                            if (_APMoneyID.Trim() != "")
                            {
                                api = GetAPMoneyInfoModel(Utils.StrToInt(_APMoneyID.Trim(), 0));
                                if (api != null)
                                {
                                    if (api.aErpOrderIDStr.Trim() != "")
                                    {
                                        api.aErpOrderIDStr = "," + api.aErpOrderIDStr + ",";
                                        api.aErpOrderIDStr = Utils.ReSQLSetTxt(api.aErpOrderIDStr);

                                        tbErpOrderInfo.UpdateErpOrderIsCheck(api.aErpOrderIDStr, 0);
                                    }
                                }
                            }
                        }
                    }
                    finally
                    {
                        api = null;
                    }
                }
                DatabaseProvider.GetInstance().DeleteAPMoneyInfo(APMoneyID);
            }
        }
        public static APMoneyInfo GetAPMoneyInfoModel(int APMoneyID)
        {
            return DatabaseProvider.GetInstance().GetAPMoneyInfoModel(APMoneyID);
        }
        public static DataSet GetAPMoneyInfoList(string strWhere)
        {
            return DatabaseProvider.GetInstance().GetAPMoneyInfoList(strWhere);
        }
        public static DataTable GetAPMoneyInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
        {
            return DatabaseProvider.GetInstance().GetAPMoneyInfoList(PageSize, PageIndex, strWhere, out  pagetotal, OrderType, showFName);
        }
        /// <summary>
        /// 指定时间段内应付数据
        /// </summary>
        /// <param name="bDate">开始时间</param>
        /// <param name="eDate">结束时间</param>
        public static DataTable GetErpWillPay(DateTime bDate, DateTime eDate)
        {
            return DatabaseProvider.GetInstance().GetErpWillPay(bDate, eDate);
        }
        #endregion
    }
}
