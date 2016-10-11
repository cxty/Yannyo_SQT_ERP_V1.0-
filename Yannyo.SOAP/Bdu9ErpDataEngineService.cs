using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data;
using System.Web;

using Yannyo.Entity;
using Yannyo.Common;
using Yannyo.Config;

namespace Yannyo.SOAP
{
    public class Bdu9ErpDataEngineService
    {
        private static string erpkey = GeneralConfigs.GetConfig().ErpWebServicePWD.Trim();
        /// <summary>
        /// 获取SOAP实例
        /// </summary>
        public static object GetSOAP()
        {
            bdu9erpDataEngineRe.DataEngine pp = new bdu9erpDataEngineRe.DataEngine();
            pp.Url = GeneralConfigs.GetConfig().ErpWebServiceURL.Trim();
            return pp;
        }

        /// <summary>
        /// 获取产品列表
        /// </summary>
        public static DataTable getProductList(string tSQL)
        {
            bdu9erpDataEngineRe.DataEngine pp = (bdu9erpDataEngineRe.DataEngine)GetSOAP();
            try
            {
                DataTable dt = new DataTable();
                dt = pp.GetProductList(erpkey, tSQL);
                return dt;
            }
            finally
            {
                pp = null;
            }
        }
        /// <summary>
        /// 获取产品单据列表
        /// </summary>
        public static DataTable getProductOrderList(int ProduceID, int OrderType, DateTime bDate, DateTime eDate)
        {
            bdu9erpDataEngineRe.DataEngine pp = (bdu9erpDataEngineRe.DataEngine)GetSOAP();
            try
            {
                DataTable dt = new DataTable();
                dt = pp.GetProductOrderList(erpkey, ProduceID, OrderType, bDate, eDate);
                return dt;
            }
            finally
            {
                pp = null;
            }
        }
        /// <summary>
        /// 获取订单单据列表
        /// </summary>
        public static DataTable GetOrderList(string OrderStr)
        { 
            bdu9erpDataEngineRe.DataEngine pp = (bdu9erpDataEngineRe.DataEngine)GetSOAP();
            try
            {
                DataTable dt = new DataTable();
                dt = pp.GetOrderList(erpkey, OrderStr);
                return dt;
            }
            finally
            {
                pp = null;
            }
        }
        /// <summary>
        /// 获取客户列表
        /// </summary>
        public static DataTable GetStoresList()
        {
            bdu9erpDataEngineRe.DataEngine pp = (bdu9erpDataEngineRe.DataEngine)GetSOAP();
            try
            {
                DataTable dt = new DataTable();
                dt = pp.GetStoresList(erpkey);
                return dt;
            }
            finally
            {
                pp = null;
            }
        }
    }
}
