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
    public class tbBankInfo
    {
        #region BankInfo
        public static bool ExistsBank(int bID)
        {
            return DatabaseProvider.GetInstance().ExistsBank(bID);
        }
        public static int AddBank(BankAccount model)
        {
            return DatabaseProvider.GetInstance().AddBank(model);
        }
        public static void UpdateBank(BankAccount model)
        {
            DatabaseProvider.GetInstance().UpdateBank(model);
        }
        public static void DeleteBank(int BankID)
        {
            DatabaseProvider.GetInstance().DeleteBank(BankID);
        }
        public static void DeleteBank(string BankID)
        {
            if (BankID.Trim() != "")
            {
                BankID = "," + BankID + ",";
                BankID = Utils.ReSQLSetTxt(BankID);
                DatabaseProvider.GetInstance().DeleteBank(BankID);
            }
        }
        public static BankAccount GetBankModel(int BankID)
        {
            return DatabaseProvider.GetInstance().GetBankModel(BankID);
        }
        public static DataSet GetBankList(string strWhere)
        {
            return DatabaseProvider.GetInstance().GetBankList(strWhere);
        }
        public static DataTable GetBankList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
        {
            return DatabaseProvider.GetInstance().GetBankList(PageSize, PageIndex, strWhere, out  pagetotal, OrderType, showFName);
        }
        /// <summary>
        /// 获得科目方向
        /// </summary>
        /// <param name="classID"></param>
        /// <returns></returns>
        public static string ClassDiretion(int classID)
        {
            return DatabaseProvider.GetInstance().ClassDiretion(classID);
        }
        /// <summary>
        /// 返回科目的使用情况
        /// </summary>
        /// <param name="classID"></param>
        /// <returns></returns>
        public static int getClassCount(int classID)
        {
            return DatabaseProvider.GetInstance().getClassCount(classID);
        }
        #endregion
    }
}
