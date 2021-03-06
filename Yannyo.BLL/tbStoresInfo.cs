﻿using System;
using System.Data;
using System.Data.Common;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

using Yannyo.Common;
using Yannyo.Data;
using Yannyo.Config;
using Yannyo.Entity;
using Yannyo.SOAP;

namespace Yannyo.BLL
{
    public class tbStoresInfo
    {
        #region  StoresInfo
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool ExistsStoresInfo(string sName)
        {
            return DatabaseProvider.GetInstance().ExistsStoresInfo(sName);
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool ExistsStoresInfoCode(string sCode)
        {
            return DatabaseProvider.GetInstance().ExistsStoresInfoCode(sCode);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddStoresInfo(StoresInfo model)
        {
            return DatabaseProvider.GetInstance().AddStoresInfo(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateStoresInfo(StoresInfo model)
        {
            DatabaseProvider.GetInstance().UpdateStoresInfo(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteStoresInfo(int StoresID)
        {
            DatabaseProvider.GetInstance().DeleteStoresInfo(StoresID);
        }
        /// <summary>
        /// 删除一组数据
        /// </summary>
        public static void DeleteStoresInfo(string StoresID)
        {
            if (StoresID.Trim() != "")
            {
                StoresID = "," + StoresID + ",";
                StoresID = Utils.ReSQLSetTxt(StoresID);
                DatabaseProvider.GetInstance().DeleteStoresInfo(StoresID);
            }
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static StoresInfo GetStoresInfoModel(int StoresID)
        {
            return DatabaseProvider.GetInstance().GetStoresInfoModel(StoresID);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static StoresInfo GetStoresInfoModelByName(string sName)
        {
            return DatabaseProvider.GetInstance().GetStoresInfoModelByName(sName);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static StoresInfo GetStoresInfoModelByCode(string sCode)
        {
            return DatabaseProvider.GetInstance().GetStoresInfoModelByCode(sCode);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataSet GetStoresInfoList(string strWhere)
        {
            return DatabaseProvider.GetInstance().GetStoresInfoList(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public static DataTable GetStoresInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
        {
            return DatabaseProvider.GetInstance().GetStoresInfoList(PageSize, PageIndex, strWhere, out pagetotal, OrderType, showFName);
        }

        /// <summary>
        /// 获取erp中客户列表
        /// </summary>
        public static DataTable GetStoresList()
        {
            return Bdu9ErpDataEngineService.GetStoresList();
        }

        /// <summary>
        /// 给客户发送邮件
        /// </summary>
        /// <param name="StoresID"></param>
        /// <param name="MailSubject"></param>
        /// <param name="MailMsg"></param>
        public static void SendMailToStores(int StoresID, string MailSubject, string MailMsg)
        {
            string Mail = tbStoresInfo.GetStoresInfoModel(StoresID).sEmail;
            if (Mail.Trim() != "")
            {
                GeneralConfigInfo configs = Config.GeneralConfigs.GetConfig();
                string[] MailArray = Utils.SplitString(Mail, ",");
                string SendedStr = ",";
                foreach (string _mail in MailArray)
                {
                    if (_mail.Trim() != "")
                    {
                        if (!(SendedStr.IndexOf("," + _mail.Trim() + ",") > -1))
                        {
                            MailQueueService.SendMail(configs.SendMailUserName, configs.SendMailUserPWD, MailSubject, MailMsg, configs.CompanyName, configs.SendMailUserName, _mail.Trim(), _mail.Trim(), true, DateTime.Now.AddSeconds(10));
                            SendedStr += _mail.Trim() + ",";
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 获取erp中客户列表
        /// </summary>
        public static int ImportErpStores()
        {
            int re = 0;
            DataTable td = new DataTable();
            td = GetStoresList();
            if (td != null)
            {
                StoresInfo si = new StoresInfo();
                try
                {
                    foreach (DataRow dr in td.Rows)
                    {
                        if (dr["C_NAME"].ToString().Trim() != "")
                        {
                            if (!tbStoresInfo.ExistsStoresInfo(dr["C_NAME"].ToString().Trim()))
                            {
                                si.sName = dr["C_NAME"].ToString().Trim();
                                si.sCode = dr["C_CODE"].ToString().Trim();
                                si.sType = "";
                                si.YHsysID = 0;
                                si.RegionID = 0;
                                si.sState = 0;
                                si.sIsFZYH = 0;
                                si.sDoDay = 0;
                                si.sDoDayMoney = 0;
                                si.sAppendTime = DateTime.Now;

                                if (tbStoresInfo.AddStoresInfo(si) > 0)
                                {
                                    re++;
                                }
                            }
                        }
                    }
                }
                finally {
                    si = null;
                }
            }
            return re;
        }
        /// <summary>
        /// 导出数据
        /// </summary>
        /// <param name="bDate"></param>
        /// <param name="eDate"></param>
        /// <returns></returns>
        public static DataTable getSalesExportData(DateTime bDate,  int dType)
        {
            return DatabaseProvider.GetInstance().getSalesExportData( bDate,    dType);
        }
       /// <summary>
       /// Checks the stores by order.
       /// </summary>
       /// <returns><c>true</c>, if stores by order was checked, <c>false</c> otherwise.</returns>
       /// <param name="StoresID">Stores I.</param>
		public static bool CheckStoresByOrder (int StoresID)
		{
			return DatabaseProvider.GetInstance().CheckStoresByOrder (StoresID);
		}
        #endregion
    }
}
