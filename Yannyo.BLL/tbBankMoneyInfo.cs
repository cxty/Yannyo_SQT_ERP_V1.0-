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
    public class tbBankMoneyInfo
    {
        #region BankMoneyInfo
        public static bool ExistsBankMoney(int BankMoneyID)
        {
            return DatabaseProvider.GetInstance().ExistsBankMoney(BankMoneyID);
        }
        public static int AddBankMoney(BankMoneyInfo model)
        {
            return DatabaseProvider.GetInstance().AddBankMoney(model);
        }
        public static void UpdateBankMoney(BankMoneyInfo model)
        {
            DatabaseProvider.GetInstance().UpdateBankMoney(model);
        }
        public static void DeleteBankMoney(int BankMoneyID)
        {
            DatabaseProvider.GetInstance().DeleteBankMoney(BankMoneyID);
        }
        public static void DeleteBankMoney(string BankMoneyID)
        {
            if (BankMoneyID.Trim() != "")
            {
                BankMoneyID = "," + BankMoneyID + ",";
                BankMoneyID = Utils.ReSQLSetTxt(BankMoneyID);
                DatabaseProvider.GetInstance().DeleteBankMoney(BankMoneyID);
            }
        }
        public static void DeleteBankMoneyForDate(string sDate)
        {
            if (sDate.Trim() != "")
            {
                sDate = "," + sDate + ",";
                sDate = Utils.ReSQLSetTxt(sDate,"'");
                DatabaseProvider.GetInstance().DeleteBankMoneyForDate(sDate);
            }
        }
        public static void DeleteBankMoneyForDate(DateTime sDate)
        {
            DatabaseProvider.GetInstance().DeleteBankMoneyForDate(sDate);
        }
        public static BankMoneyInfo GetBankMoneyModel(int BankMoneyID)
        {
            return DatabaseProvider.GetInstance().GetBankMoneyModel(BankMoneyID);
        }
        public static BankMoneyInfo GetBankMoneyModel(DateTime dDate, int BankID)
        {
            return DatabaseProvider.GetInstance().GetBankMoneyModel(dDate, BankID);
        }
        //返回指定时间的指定银行金额
        public static decimal GetBankMoney(DateTime dDate,int BankID)
        {
            return DatabaseProvider.GetInstance().GetBankMoney(dDate,BankID);
        }
        public static decimal GetBankMoneyByEndDate(DateTime eDate, int BankID)
        {
            return DatabaseProvider.GetInstance().GetBankMoneyByEndDate(eDate, BankID);
        }
        public static DataSet GetBankMoneyList(string strWhere)
        {
            return DatabaseProvider.GetInstance().GetBankMoneyList(strWhere);
        }
        public static DataTable GetBankMoneyList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
        {
            return DatabaseProvider.GetInstance().GetBankMoneyList(PageSize, PageIndex, strWhere, out  pagetotal, OrderType, showFName);
        }
        /// <summary>
        /// 取账户的期初金额
        /// </summary>
        /// <param name="BankID"></param>
        /// <returns></returns>
        public static decimal GetBankBeginMoney(int BankID)
        {
            return DatabaseProvider.GetInstance().GetBankBeginMoney(BankID);
        }
        public static DataTable GetBankMoneyTable(DateTime bDate, DateTime eDate, int BankID)
        {
            int t = 0;
            //建虚拟表
            DataTable rdt = new DataTable();

            //日期
            DataTable dt = new DataTable();
            dt = DataUtils.GetDateTimeList(bDate, eDate, 1);

            rdt.Columns.Add("tdate", typeof(string));

            //银行
            DataTable dt_yh = new DataTable();
            if (BankID > 0)
            {
                dt_yh = tbBankInfo.GetBankList(" BankID=" + BankID + " order by bAppendTime desc").Tables[0];
            }
            else
            {
                dt_yh = tbBankInfo.GetBankList(" 1=1 order by bAppendTime desc").Tables[0];
            }
            t = 0;
            foreach (DataRow dr in dt_yh.Rows)
            {
                rdt.Columns.Add("Bank_"+t, typeof(decimal));
                t++;
            }
            
            t = 0;
            //填充
            foreach (DataRow dr2 in dt.Rows)
            {
                DataRow dr_x = rdt.NewRow();
                dr_x["tdate"] = DateTime.Parse(dr2["tdate"].ToString()).ToShortDateString();

                t = 0;
                foreach (DataRow dr_y in dt_yh.Rows)
                {
                    dr_x["Bank_" + t] = GetBankBeginMoney(int.Parse(dr_y["BankID"].ToString())) + GetBankMoney(DateTime.Parse(dr2["tdate"].ToString()), int.Parse(dr_y["BankID"].ToString()));
                    t++;
                }

                rdt.Rows.Add(dr_x);
            }

            rdt.AcceptChanges();

            return rdt;
        }
        public static DataTable GetBankMoneyTableByOneDay(DateTime eDate)
        {
            //银行
            DataTable dt_yh = new DataTable();
            dt_yh = tbBankInfo.GetBankList(" 1=1 order by bAppendTime desc").Tables[0];

            if (dt_yh != null)
            {
                dt_yh.Columns.Add("BankMoney", typeof(decimal));
                foreach (DataRow dr in dt_yh.Rows)
                {
                    dr["BankMoney"] = GetBankMoneyByEndDate(eDate, int.Parse(dr["BankID"].ToString()));
                }

                dt_yh.AcceptChanges();
            }
            return dt_yh;
        }
        /// <summary>
        /// 设置资金帐户的期初金额
        /// </summary>
        /// <param name="BankID"></param>
        /// <param name="BeginMoney"></param>
        /// <returns></returns>
        public static void GetBankBeginMoney(int BankID, decimal BeginMoney)
        {
            DatabaseProvider.GetInstance().GetBankBeginMoney(BankID, BeginMoney);
        }
        #endregion
    }
}
