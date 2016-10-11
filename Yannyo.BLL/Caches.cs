using System;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

using Yannyo.Common;
using Yannyo.Data;
using Yannyo.Config;
using Yannyo.Entity;
using Yannyo.Cache;
using Yannyo.SOAP;

namespace Yannyo.BLL
{
    public class Caches
    {
        private static object lockHelper = new object();

        /// <summary>
        /// 重置缓存
        /// </summary>
        public static void ReSet()
        {
            Yannyo.Cache.YannyoCache.GetCacheService().TimerOut();
        }
        /// <summary>
        /// 获得天气预报
        /// </summary>
        public static Weather GetWeather(string CityName)
        {
            Yannyo.Cache.YannyoCache cache = Yannyo.Cache.YannyoCache.GetCacheService();
            Weather w = cache.RetrieveObject("/Sys/Weather" + Utils.MD5(CityName)) as Weather;
            if (w == null)
            {
                w = WeatherWebService.getWeatherbyCityName(CityName);//接口获取天气数据
                cache.AddObject("/Sys/Weather" + Utils.MD5(CityName), w);
                
            }

            return w;
        }
        /// <summary>
        /// 获得地区列表XML
        /// </summary>
        public static string GetRegionListToXML()
        {
            Yannyo.Cache.YannyoCache cache = Yannyo.Cache.YannyoCache.GetCacheService();
            string x = cache.RetrieveObject("/Sys/RegionList") as string;
            if (x == null)
            {
                x = tbRegionInfo.GetRegionListToXML();
                cache.AddObject("/Sys/RegionList", x);
            }
            return x;
        }
        /// <summary>
        /// 获得地区列表XML
        /// </summary>
        public static string GetRegionListToXML(int PRegionID)
        {
            Yannyo.Cache.YannyoCache cache = Yannyo.Cache.YannyoCache.GetCacheService();
            string x = cache.RetrieveObject("/Sys/RegionList_" + PRegionID.ToString()) as string;
            if (x == null)
            {
                x = tbRegionInfo.GetRegionListToXML(PRegionID);
                cache.AddObject("/Sys/RegionList_" + PRegionID.ToString(), x);
            }
            return x;
        }

        /// <summary>
        /// 缓存单据自定义字段类型
        /// </summary>
        /// <returns></returns>
        public static Orders.OrderFieldTypes GetOrderFieldType()
        {
            Yannyo.Cache.YannyoCache cache = Yannyo.Cache.YannyoCache.GetCacheService();
            Orders.OrderFieldTypes x = cache.RetrieveObject("/Sys/OrderFieldTypes") as Orders.OrderFieldTypes;
            if (x == null)
            {
                x = Orders.OrderFieldTypes.GetOrderFieldType();
                cache.AddObject("/Sys/OrderFieldTypes", x);
            }
            return x;
        }
        /// <summary>
        /// 缓存单据步骤
        /// </summary>
        /// <returns></returns>
        public static Orders.OrderSteps GetOrderSteps()
        {
            Yannyo.Cache.YannyoCache cache = Yannyo.Cache.YannyoCache.GetCacheService();
            Orders.OrderSteps x = cache.RetrieveObject("/Sys/OrderSteps") as Orders.OrderSteps;
            if (x == null)
            {
                x = Orders.OrderSteps.GetOrderSteps();
                cache.AddObject("/Sys/OrderSteps", x);
            }
            return x;
        }
        /// <summary>
        /// 缓存权限列表
        /// </summary>
        /// <returns></returns>
        public static DataTable GetUserPopedom()
        {
            Yannyo.Cache.YannyoCache cache = Yannyo.Cache.YannyoCache.GetCacheService();
            DataTable x = cache.RetrieveObject("/Sys/UserPopedom") as DataTable;
            if (x == null)
            {
                x = UsersUtils.GetUserPopedom();
                cache.AddObject("/Sys/UserPopedom", x);
            }
            return x;
        }
        /// <summary>
        /// 缓存人员列表
        /// </summary>
        /// <returns></returns>
        public static DataTable GetStaffInfoList(string tSQL)
        {
            Yannyo.Cache.YannyoCache cache = Yannyo.Cache.YannyoCache.GetCacheService();
            DataTable x = cache.RetrieveObject("/Sys/StaffInfoList_" + Utils.MD5(tSQL)) as DataTable;
            if (x == null)
            {
                x = tbStaffInfo.GetStaffInfoList(tSQL).Tables[0];
                cache.AddObject("/Sys/StaffInfoList_" +Utils.MD5(tSQL), x);
            }
            return x;
        }
        /// <summary>
        /// 缓存产品列表
        /// </summary>
        /// <returns></returns>
        public static DataTable GetProductsInfoList(string tSQL)
        {
            Yannyo.Cache.YannyoCache cache = Yannyo.Cache.YannyoCache.GetCacheService();
            DataTable x = cache.RetrieveObject("/Sys/GetProductsInfoList_" + Utils.MD5(tSQL)) as DataTable;
            if (x == null)
            {
                x = tbProductsInfo.GetProductsInfoList(tSQL).Tables[0];
                cache.AddObject("/Sys/GetProductsInfoList_" + Utils.MD5(tSQL), x);
            }
            return x;
        }
        /// <summary>
        /// 缓存供货商列表
        /// </summary>
        /// <returns></returns>
        public static DataTable GetSupplierInfoList(string tSQL)
        {
            Yannyo.Cache.YannyoCache cache = Yannyo.Cache.YannyoCache.GetCacheService();
            DataTable x = cache.RetrieveObject("/Sys/GetSupplierInfoList_" + Utils.MD5(tSQL)) as DataTable;
            if (x == null)
            {
                x = tbSupplierInfo.GetSupplierInfoList(tSQL).Tables[0];
                cache.AddObject("/Sys/GetSupplierInfoList_" + Utils.MD5(tSQL), x);
            }
            return x;
        }
        /// <summary>
        /// 缓存客户列表
        /// </summary>
        /// <returns></returns>
        public static DataTable GetStoresInfoList(string tSQL)
        {
            Yannyo.Cache.YannyoCache cache = Yannyo.Cache.YannyoCache.GetCacheService();
            DataTable x = cache.RetrieveObject("/Sys/GetStoresInfoList_" + Utils.MD5(tSQL)) as DataTable;
            if (x == null)
            {
                x = tbStoresInfo.GetStoresInfoList(tSQL).Tables[0];
                cache.AddObject("/Sys/GetStoresInfoList_" + Utils.MD5(tSQL), x);
            }
            return x;
        }
        /// <summary>
        /// 缓存操作员列表
        /// </summary>
        /// <returns></returns>
        public static DataTable GetUserInfoList(string tSQL)
        {
            Yannyo.Cache.YannyoCache cache = Yannyo.Cache.YannyoCache.GetCacheService();
            DataTable x = cache.RetrieveObject("/Sys/GetUserInfoList_" + Utils.MD5(tSQL)) as DataTable;
            if (x == null)
            {
                x = tbUserInfo.GetUserInfoList(tSQL).Tables[0];
                cache.AddObject("/Sys/GetUserInfoList_" + Utils.MD5(tSQL), x);
            }
            return x;
        }
        /// <summary>
        /// 缓存仓库列表
        /// </summary>
        /// <returns></returns>
        public static DataTable GetStorageInfoList(string tSQL)
        {
            Yannyo.Cache.YannyoCache cache = Yannyo.Cache.YannyoCache.GetCacheService();
            DataTable x = cache.RetrieveObject("/Sys/GetStorageInfoList_" + Utils.MD5(tSQL)) as DataTable;
            if (x == null)
            {
                x = tbStorageInfo.GetStorageInfoList(tSQL).Tables[0];
                cache.AddObject("/Sys/GetStorageInfoList_" + Utils.MD5(tSQL), x);
            }
            return x;
        }
        #region DataClass
        public static string GetCustomersClassInfoToHTML()
        {
            Yannyo.Cache.YannyoCache cache = Yannyo.Cache.YannyoCache.GetCacheService();
            string x = cache.RetrieveObject("/Sys/GetCustomersClassInfoToHTML") as string;
            if (x == null)
            {
                x = DataClass.GetCustomersClassInfoToHTML();
                cache.AddObject("/Sys/GetCustomersClassInfoToHTML", x);
            }
            return x;
        }
        /// <summary>
        ///客户分类,客户列表,树
        /// </summary>
        /// <returns></returns>
        public static string GetCustomersClassInfoAndDataToHTML()
        {
            Yannyo.Cache.YannyoCache cache = Yannyo.Cache.YannyoCache.GetCacheService();
            string x = cache.RetrieveObject("/Sys/GetCustomersClassInfoAndDataToHTML") as string;
            if (x == null)
            {
                x = DataClass.GetCustomersClassInfoAndDataToHTML();
                cache.AddObject("/Sys/GetCustomersClassInfoAndDataToHTML", x);
            }
            return x;
        }
        public static string GetFeesSubjectClassInfoToHTML()
        {
            Yannyo.Cache.YannyoCache cache = Yannyo.Cache.YannyoCache.GetCacheService();
            string x = cache.RetrieveObject("/Sys/GetFeesSubjectClassInfoToHTML") as string;
            if (x == null)
            {
                x = DataClass.GetFeesSubjectClassInfoToHTML();
                cache.AddObject("/Sys/GetFeesSubjectClassInfoToHTML", x);
            }
            return x;
        }

        /// <summary>
        /// 部门树形
        /// </summary>
        /// <returns></returns>
        public static string GetDepartmentsClassInfoToHTML()
        {
            Yannyo.Cache.YannyoCache cache = Yannyo.Cache.YannyoCache.GetCacheService();
            string x = cache.RetrieveObject("/Sys/GetDepartmentsClassInfoToHTML") as string;
            if (x == null)
            {
                x = DataClass.GetDepartmentsClassInfoToHTML();
                cache.AddObject("/Sys/GetDepartmentsClassInfoToHTML", x);
            }
            return x;
        }
        /// <summary>
        /// 部门,人员,树形
        /// </summary>
        /// <returns></returns>
        public static string GetDepartmentsClassInfoAndStaffListToHTML()
        {
            Yannyo.Cache.YannyoCache cache = Yannyo.Cache.YannyoCache.GetCacheService();
            string x = cache.RetrieveObject("/Sys/GetDepartmentsClassInfoAndStaffListToHTML") as string;
            if (x == null)
            {
                x = DataClass.GetDepartmentsClassInfoAndStaffListToHTML();
                cache.AddObject("/Sys/GetDepartmentsClassInfoAndStaffListToHTML", x);
            }
            return x;
        }
        public static string GetPriceClassInfoToHTML()
        {
            Yannyo.Cache.YannyoCache cache = Yannyo.Cache.YannyoCache.GetCacheService();
            string x = cache.RetrieveObject("/Sys/GetPriceClassInfoToHTML") as string;
            if (x == null)
            {
                x = DataClass.GetPriceClassInfoToHTML();
                cache.AddObject("/Sys/GetPriceClassInfoToHTML", x);
            }
            return x;
        }
        public static string GetProductClassInfoToHTML()
        {
            Yannyo.Cache.YannyoCache cache = Yannyo.Cache.YannyoCache.GetCacheService();
            string x = cache.RetrieveObject("/Sys/GetProductClassInfoToHTML") as string;
            if (x == null)
            {
                x = DataClass.GetProductClassInfoToHTML();
                cache.AddObject("/Sys/GetProductClassInfoToHTML", x);
            }
            return x;
        }
        public static string GetSupplierClassInfoToHTML()
        {
            Yannyo.Cache.YannyoCache cache = Yannyo.Cache.YannyoCache.GetCacheService();
            string x = cache.RetrieveObject("/Sys/GetSupplierClassInfoToHTML") as string;
            if (x == null)
            {
                x = DataClass.GetSupplierClassInfoToHTML();
                cache.AddObject("/Sys/GetSupplierClassInfoToHTML", x);
            }
            return x;
        }
        /// <summary>
        /// 供应商分类,供应商列表,树
        /// </summary>
        /// <returns></returns>
        public static string GetSupplierClassInfoAndDataToHTML()
        {
            Yannyo.Cache.YannyoCache cache = Yannyo.Cache.YannyoCache.GetCacheService();
            string x = cache.RetrieveObject("/Sys/GetSupplierClassInfoAndDataToHTML") as string;
            if (x == null)
            {
                x = DataClass.GetSupplierClassInfoAndDataToHTML();
                cache.AddObject("/Sys/GetSupplierClassInfoAndDataToHTML", x);
            }
            return x;
        }
        public static string GetRegionInfoToHTML()
        {
            Yannyo.Cache.YannyoCache cache = Yannyo.Cache.YannyoCache.GetCacheService();
            string x = cache.RetrieveObject("/Sys/GetRegionInfoToHTML") as string;
            if (x == null)
            {
                x = DataClass.GetRegionInfoToHTML();
                cache.AddObject("/Sys/GetRegionInfoToHTML" , x);
            }
            return x;
        }
        public static string GetRegionInfoToHTML(int t)
        {
            Yannyo.Cache.YannyoCache cache = Yannyo.Cache.YannyoCache.GetCacheService();
            string x = cache.RetrieveObject("/Sys/GetRegionInfoToHTML_"+Utils.MD5(t.ToString())) as string;
            if (x == null)
            {
                x = DataClass.GetRegionInfoToHTML(t);
                cache.AddObject("/Sys/GetRegionInfoToHTML_" + Utils.MD5(t.ToString()), x);
            }
            return x;
        }

        public static string GetCustomersClassInfoToJson()
        {
            Yannyo.Cache.YannyoCache cache = Yannyo.Cache.YannyoCache.GetCacheService();
            string x = cache.RetrieveObject("/Sys/GetCustomersClassInfoToJson") as string;
            if (x == null)
            {
                x = DataClass.GetCustomersClassInfoToJson();
                cache.AddObject("/Sys/GetCustomersClassInfoToJson", x);
            }
            return x;
        }
        public static string GetFeesSubjectClassInfoToJson()
        {
            Yannyo.Cache.YannyoCache cache = Yannyo.Cache.YannyoCache.GetCacheService();
            string x = cache.RetrieveObject("/Sys/GetFeesSubjectClassInfoToJson") as string;
            if (x == null)
            {
                x = DataClass.GetFeesSubjectClassInfoToJson();
                cache.AddObject("/Sys/GetFeesSubjectClassInfoToJson", x);
            }
            return x;
        }
        public static string GetDepartmentsClassInfoToJson()
        {
            Yannyo.Cache.YannyoCache cache = Yannyo.Cache.YannyoCache.GetCacheService();
            string x = cache.RetrieveObject("/Sys/GetDepartmentsClassInfoToJson") as string;
            if (x == null)
            {
                x = DataClass.GetDepartmentsClassInfoToJson();
                cache.AddObject("/Sys/GetDepartmentsClassInfoToJson", x);
            }
            return x;
        }
        public static string GetPriceClassInfoToJson()
        {
            Yannyo.Cache.YannyoCache cache = Yannyo.Cache.YannyoCache.GetCacheService();
            string x = cache.RetrieveObject("/Sys/GetPriceClassInfoToJson") as string;
            if (x == null)
            {
                x = DataClass.GetPriceClassInfoToJson();
                cache.AddObject("/Sys/GetPriceClassInfoToJson", x);
            }
            return x;
        }
        public static string GetProductClassInfoToJson()
        {
            Yannyo.Cache.YannyoCache cache = Yannyo.Cache.YannyoCache.GetCacheService();
            string x = cache.RetrieveObject("/Sys/GetProductClassInfoToJson") as string;
            if (x == null)
            {
                x = DataClass.GetProductClassInfoToJson();
                cache.AddObject("/Sys/GetProductClassInfoToJson", x);
            }
            return x;
        }
        public static string GetSupplierClassInfoToJson()
        {
            Yannyo.Cache.YannyoCache cache = Yannyo.Cache.YannyoCache.GetCacheService();
            string x = cache.RetrieveObject("/Sys/GetSupplierClassInfoToJson") as string;
            if (x == null)
            {
                x = DataClass.GetSupplierClassInfoToJson();
                cache.AddObject("/Sys/GetSupplierClassInfoToJson", x);
            }
            return x;
        }
        public static string GetRegionInfoToJson()
        {
            Yannyo.Cache.YannyoCache cache = Yannyo.Cache.YannyoCache.GetCacheService();
            string x = cache.RetrieveObject("/Sys/GetRegionInfoToJson") as string;
            if (x == null)
            {
                x = DataClass.GetRegionInfoToJson();
                cache.AddObject("/Sys/GetRegionInfoToJson", x);
            }
            return x;
        }
        //客户
        public static string GetCustomersClassInfoToJson(int t)
        {
            Yannyo.Cache.YannyoCache cache = Yannyo.Cache.YannyoCache.GetCacheService();
            string x = cache.RetrieveObject("/Sys/GetCustomersClassInfoToJson_" + Utils.MD5(t.ToString())) as string;
            if (x == null)
            {
                x = DataClass.GetCustomersClassInfoToJson(t);
                cache.AddObject("/Sys/GetCustomersClassInfoToJson_" + Utils.MD5(t.ToString()), x);
            }
            return x;
        }
        public static string GetFeesSubjectClassInfoToJson(int t)
        {
            Yannyo.Cache.YannyoCache cache = Yannyo.Cache.YannyoCache.GetCacheService();
            string x = cache.RetrieveObject("/Sys/GetFeesSubjectClassInfoToJson_" + Utils.MD5(t.ToString())) as string;
            if (x == null)
            {
                x = DataClass.GetFeesSubjectClassInfoToJson(t);
                cache.AddObject("/Sys/GetFeesSubjectClassInfoToJson_" + Utils.MD5(t.ToString()), x);
            }
            return x;
        }
        public static string GetDepartmentsClassInfoToJson(int t)
        {
            Yannyo.Cache.YannyoCache cache = Yannyo.Cache.YannyoCache.GetCacheService();
            string x = cache.RetrieveObject("/Sys/GetDepartmentsClassInfoToJson_" + Utils.MD5(t.ToString())) as string;
            if (x == null)
            {
                x = DataClass.GetDepartmentsClassInfoToJson(t);
                cache.AddObject("/Sys/GetDepartmentsClassInfoToJson_" + Utils.MD5(t.ToString()), x);
            }
            return x;
        }
        public static string GetPriceClassInfoToJson(int t)
        {
            Yannyo.Cache.YannyoCache cache = Yannyo.Cache.YannyoCache.GetCacheService();
            string x = cache.RetrieveObject("/Sys/GetPriceClassInfoToJson_" + Utils.MD5(t.ToString())) as string;
            if (x == null)
            {
                x = DataClass.GetPriceClassInfoToJson(t);
                cache.AddObject("/Sys/GetPriceClassInfoToJson_" + Utils.MD5(t.ToString()), x);
            }
            return x;
        }
		public static string GetProductClassInfoToJson(int t)
        {
            Yannyo.Cache.YannyoCache cache = Yannyo.Cache.YannyoCache.GetCacheService();
            string x = cache.RetrieveObject("/Sys/GetProductClassInfoToJson_" + Utils.MD5(t.ToString())) as string;
            if (x == null)
            {
				x = DataClass.GetProductClassInfoToJson(t);
                cache.AddObject("/Sys/GetProductClassInfoToJson_" + Utils.MD5(t.ToString()), x);
            }
            return x;
        }
        public static string GetSupplierClassInfoToJson(int t)
        {
            Yannyo.Cache.YannyoCache cache = Yannyo.Cache.YannyoCache.GetCacheService();
            string x = cache.RetrieveObject("/Sys/GetSupplierClassInfoToJson_" + Utils.MD5(t.ToString())) as string;
            if (x == null)
            {
                x = DataClass.GetSupplierClassInfoToJson(t);
                cache.AddObject("/Sys/GetSupplierClassInfoToJson_" + Utils.MD5(t.ToString()), x);
            }
            return x;
        }
        public static string GetRegionInfoToJson(int t)
        {
            Yannyo.Cache.YannyoCache cache = Yannyo.Cache.YannyoCache.GetCacheService();
            string x = cache.RetrieveObject("/Sys/GetRegionInfoToJson_" + Utils.MD5(t.ToString())) as string;
            if (x == null)
            {
                x = DataClass.GetRegionInfoToJson(t);
                cache.AddObject("/Sys/GetRegionInfoToJson_" + Utils.MD5(t.ToString()), x);
            }
            return x;
        }


        public static string GetStorageInfoToJson(int t)
        {
            Yannyo.Cache.YannyoCache cache = Yannyo.Cache.YannyoCache.GetCacheService();
            string x = cache.RetrieveObject("/Sys/GetStorageInfoToJson_" + Utils.MD5(t.ToString())) as string;
            if (x == null)
            {
                x = DataClass.GetStoragesClassInfoToJson(t);
                cache.AddObject("/Sys/GetStorageInfoToJson_" + Utils.MD5(t.ToString()), x);
            }
            return x;
        }
        //1.仓库分类
        public static string GetStorageInfoToJson(int pid, bool getdata, bool isAll)
        {
            Yannyo.Cache.YannyoCache cache = Yannyo.Cache.YannyoCache.GetCacheService();
            string x = cache.RetrieveObject("/Sys/GetStorageInfoToJson_" + Utils.MD5(pid.ToString() + getdata.ToString() + isAll.ToString())) as string;
            if (x == null)
            {
                x = DataClass.GetStorageClassInfoToJson(pid, getdata, isAll);
                cache.AddObject("/Sys/GetStorageInfoToJson_" + Utils.MD5(pid.ToString() + getdata.ToString() + isAll.ToString()), x);
            }
            return x;
        }
        //区域分类
        public static string GetRegionInfoToJson(int pid, bool getdata, bool isAll)
        {
            Yannyo.Cache.YannyoCache cache = Yannyo.Cache.YannyoCache.GetCacheService();
            string x = cache.RetrieveObject("/Sys/GetRegionInfoToJson_" + Utils.MD5(pid.ToString() + getdata.ToString() + isAll.ToString())) as string;
            if (x == null)
            {
                x = DataClass.GetRegionClassInfoToJson(pid, getdata, isAll);
                cache.AddObject("/Sys/GetRegionInfoToJson_" + Utils.MD5(pid.ToString() + getdata.ToString() + isAll.ToString()), x);
            }
            return x;
        }
        //客户分类
        public static string GetCustomersInfoToJson(int pid, bool getdata, bool isAll)
        {
            Yannyo.Cache.YannyoCache cache = Yannyo.Cache.YannyoCache.GetCacheService();
            string x = cache.RetrieveObject("/Sys/GetCustomersInfoToJson_" + Utils.MD5(pid.ToString() + getdata.ToString() + isAll.ToString())) as string;
            if (x == null)
            {
                x = DataClass.GetCustomersClassToJson(pid, getdata, isAll);
                cache.AddObject("/Sys/GetCustomersInfoToJson_" + Utils.MD5(pid.ToString() + getdata.ToString() + isAll.ToString()), x);
            }
            return x;
        }
        //商品分类
        public static string GetProductsInfoToJson(int pid, bool getdata, bool isAll)
        {
            Yannyo.Cache.YannyoCache cache = Yannyo.Cache.YannyoCache.GetCacheService();
            string x = cache.RetrieveObject("/Sys/GetProductsInfoToJson_" + Utils.MD5(pid.ToString() + getdata.ToString() + isAll.ToString())) as string;
            if (x == null)
            {
                x = DataClass.GetProductsClassToJson(pid, getdata, isAll);
                cache.AddObject("/Sys/GetProductsInfoToJson_" + Utils.MD5(pid.ToString() + getdata.ToString() + isAll.ToString()), x);
            }
            return x;
        }

        public static string GetCustomersClassInfoToJson(int t, bool p)
        {
            Yannyo.Cache.YannyoCache cache = Yannyo.Cache.YannyoCache.GetCacheService();
            string x = cache.RetrieveObject("/Sys/GetCustomersClassInfoToJson_" + Utils.MD5(t.ToString()+p.ToString())) as string;
            if (x == null)
            {
                x = DataClass.GetCustomersClassInfoToJson(t,p);
                cache.AddObject("/Sys/GetCustomersClassInfoToJson_" + Utils.MD5(t.ToString() + p.ToString()), x);
            }
            return x;
        }
        public static string GetFeesSubjectClassInfoToJson(int t, bool p)
        {
            Yannyo.Cache.YannyoCache cache = Yannyo.Cache.YannyoCache.GetCacheService();
            string x = cache.RetrieveObject("/Sys/GetFeesSubjectClassInfoToJson_" + Utils.MD5(t.ToString() + p.ToString())) as string;
            if (x == null)
            {
                x = DataClass.GetFeesSubjectClassInfoToJson(t, p);
                cache.AddObject("/Sys/GetFeesSubjectClassInfoToJson_" + Utils.MD5(t.ToString() + p.ToString()), x);
            }
            return x;
        }
        public static string GetDepartmentsClassInfoToJson(int t, bool p)
        {
            Yannyo.Cache.YannyoCache cache = Yannyo.Cache.YannyoCache.GetCacheService();
            string x = cache.RetrieveObject("/Sys/GetDepartmentsClassInfoToJson_" + Utils.MD5(t.ToString() + p.ToString())) as string;
            if (x == null)
            {
                x = DataClass.GetDepartmentsClassInfoToJson(t, p);
                cache.AddObject("/Sys/GetDepartmentsClassInfoToJson_" + Utils.MD5(t.ToString() + p.ToString()), x);
            }
            return x;
        }
        public static string GetPriceClassInfoToJson(int t, bool p)
        {
            Yannyo.Cache.YannyoCache cache = Yannyo.Cache.YannyoCache.GetCacheService();
            string x = cache.RetrieveObject("/Sys/GetPriceClassInfoToJson_" + Utils.MD5(t.ToString() + p.ToString())) as string;
            if (x == null)
            {
                x = DataClass.GetPriceClassInfoToJson(t, p);
                cache.AddObject("/Sys/GetPriceClassInfoToJson_" + Utils.MD5(t.ToString() + p.ToString()), x);
            }
            return x;
        }
		public static string GetProductClassInfoToJson(int t, bool p,int orderType = 0)
        {
            Yannyo.Cache.YannyoCache cache = Yannyo.Cache.YannyoCache.GetCacheService();
			string x = cache.RetrieveObject("/Sys/GetProductClassInfoToJson_" + Utils.MD5(t.ToString() + p.ToString()+orderType.ToString())) as string;
            if (x == null)
            {
				x = DataClass.GetProductClassInfoToJson(t, p,orderType);
				cache.AddObject("/Sys/GetProductClassInfoToJson_" + Utils.MD5(t.ToString() + p.ToString()+orderType.ToString()), x);
            }
            return x;
        }
        public static string GetSupplierClassInfoToJson(int t, bool p)
        {
            Yannyo.Cache.YannyoCache cache = Yannyo.Cache.YannyoCache.GetCacheService();
            string x = cache.RetrieveObject("/Sys/GetSupplierClassInfoToJson_" + Utils.MD5(t.ToString() + p.ToString())) as string;
            if (x == null)
            {
                x = DataClass.GetSupplierClassInfoToJson(t, p);
                cache.AddObject("/Sys/GetSupplierClassInfoToJson_" + Utils.MD5(t.ToString() + p.ToString()), x);
            }
            return x;
        }
        /// <summary>
        /// 仓库信息分类
        /// </summary>
        /// <param name="t"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static string GetStorageClassInfoToJson(int t, bool p)
        {
            Yannyo.Cache.YannyoCache cache = Yannyo.Cache.YannyoCache.GetCacheService();
            string x = cache.RetrieveObject("/Sys/GetStorageClassInfoToJson_" + Utils.MD5(t.ToString() + p.ToString())) as string;
            if (x == null)
            {
                x = DataClass.GetStoragesClassInfoToJson(t, p);
                cache.AddObject("/Sys/GetStorageClassInfoToJson_" + Utils.MD5(t.ToString() + p.ToString()), x);
            }
            return x;
        }
        /// <summary>
        /// 部门,人员
        /// </summary>
        /// <param name="pid"></param>
        /// <param name="getdata"></param>
        /// <param name="isAll"></param>
        /// <returns></returns>
        public static string GetDepartmentsClassInfoToJson(int pid, bool getdata, bool isAll)
        {
            Yannyo.Cache.YannyoCache cache = Yannyo.Cache.YannyoCache.GetCacheService();
            string x = cache.RetrieveObject("/Sys/GetDepartmentsClassInfoToJson_" + Utils.MD5(pid.ToString() + getdata.ToString() + isAll.ToString())) as string;
            if (x == null)
            {
                x = DataClass.GetDepartmentsClassInfoToJson(pid, getdata, isAll);
                cache.AddObject("/Sys/GetDepartmentsClassInfoToJson_" + Utils.MD5(pid.ToString() + getdata.ToString() + isAll.ToString()), x);
            }
            return x;
        }
        /// <summary>
        /// 供应商
        /// </summary>
        /// <param name="pid"></param>
        /// <param name="getdata"></param>
        /// <param name="isAll"></param>
        /// <returns></returns>
        public static string GetSupplierClassInfoToJson(int pid, bool getdata, bool isAll)
        {
            Yannyo.Cache.YannyoCache cache = Yannyo.Cache.YannyoCache.GetCacheService();
            string x = cache.RetrieveObject("/Sys/GetSupplierClassInfoToJson_" + Utils.MD5(pid.ToString() + getdata.ToString() + isAll.ToString())) as string;
            if (x == null)
            {
                x = DataClass.GetSupplierClassInfoToJson(pid, getdata, isAll);
                cache.AddObject("/Sys/GetSupplierClassInfoToJson_" + Utils.MD5(pid.ToString() + getdata.ToString() + isAll.ToString()), x);
            }
            return x;
        }
        /// <summary>
        /// 客户
        /// </summary>
        /// <param name="pid"></param>
        /// <param name="getdata"></param>
        /// <param name="isAll"></param>
        /// <returns></returns>
        public static string GetCustomersClassInfoToJson(int pid, bool getdata, bool isAll)
        {
            Yannyo.Cache.YannyoCache cache = Yannyo.Cache.YannyoCache.GetCacheService();
            string x = cache.RetrieveObject("/Sys/GetCustomersClassInfoToJson_" + Utils.MD5(pid.ToString() + getdata.ToString() + isAll.ToString())) as string;
            if (x == null)
            {
                x = DataClass.GetCustomersClassInfoToJson(pid, getdata, isAll);
                cache.AddObject("/Sys/GetCustomersClassInfoToJson_" + Utils.MD5(pid.ToString() + getdata.ToString() + isAll.ToString()), x);
            }
            return x;
        }
        /// <summary>
        /// 科目
        /// </summary>
        /// <param name="pid"></param>
        /// <param name="getdata"></param>
        /// <param name="isAll"></param>
        /// <returns></returns>
        public static string GetFeesSubjectClassInfoToJson(int pid, bool getdata, bool isAll)
        {
            Yannyo.Cache.YannyoCache cache = Yannyo.Cache.YannyoCache.GetCacheService();
            string x = cache.RetrieveObject("/Sys/GetFeesSubjectClassInfoToJson_" + Utils.MD5(pid.ToString() + getdata.ToString() + isAll.ToString())) as string;
            if (x == null)
            {
                x = DataClass.GetFeesSubjectClassInfoToJson(pid, getdata, isAll);
                cache.AddObject("/Sys/GetFeesSubjectClassInfoToJson_" + Utils.MD5(pid.ToString() + getdata.ToString() + isAll.ToString()), x);
            }
            return x;
        }
        /// <summary>
        /// 结算系统列表
        /// </summary>
        /// <returns></returns>
        public static DataTable GetPaymentSystemData()
        {
            Yannyo.Cache.YannyoCache cache = Yannyo.Cache.YannyoCache.GetCacheService();
            DataTable x = cache.RetrieveObject("/Sys/GetPaymentSystemData") as DataTable;
            if (x == null)
            {
                x = tbPaymentSystemInfo.GetPaymentSystemList("").Tables[0];
                cache.AddObject("/Sys/GetPaymentSystemData", x);
            }
            return x;
        }
        /// <summary>
        /// 结算系统Json
        /// </summary>
        /// <returns></returns>
        public static string GetPaymentSystemJson()
        {
            Yannyo.Cache.YannyoCache cache = Yannyo.Cache.YannyoCache.GetCacheService();
            string x = cache.RetrieveObject("/Sys/GetPaymentSystemDataJson") as string;
            if (x == null)
            {
                string _x = "";
                DataTable _ps = new DataTable();
                _ps = Caches.GetPaymentSystemData();
                if (_ps != null)
                {
                    foreach (DataRow _dr in _ps.Rows)
                    {
                        _x += "{\"data\":\"" + _dr["pName"] + "\",\"state\":\"closed\",\"attr\":{\"id\":\"d_" + _dr["PaymentSystemID"] + "\",\"rel\":\"dt\",\"pid\":\"0\",\"cDirection\":\"\",\"cCode\":\"\",\"otype\":\"3\",\"children\":[]}},";
                    }
                  x =  Utils.ReSQLSetTxt(_x);
                }

                cache.AddObject("/Sys/GetPaymentSystemDataJson", x);
            }
            return x;
        }
        #endregion

        /// <summary>
        /// 网店列表
        /// </summary>
        /// <returns></returns>
        public static DataTable GetMConfigList()
        {
            Yannyo.Cache.YannyoCache cache = Yannyo.Cache.YannyoCache.GetCacheService();
            DataTable x = cache.RetrieveObject("/Sys/GetMConfigList") as DataTable;
            if (x == null)
            {
                x = M_Utils.GetM_ConfigInfoList(" m_State=0 order by m_ConfigInfoID desc").Tables[0];
                cache.AddObject("/Sys/GetMConfigList", x);
            }
            return x;
        }

        /// <summary>
        /// 取网店配置信息
        /// </summary>
        /// <param name="mconfigid"></param>
        /// <returns></returns>
        public static M_ConfigInfo GetMConfig(int mconfigid)
        {
            Yannyo.Cache.YannyoCache cache = Yannyo.Cache.YannyoCache.GetCacheService();
            M_ConfigInfo x = cache.RetrieveObject("/Sys/GetMConfigList_" + mconfigid) as M_ConfigInfo;
            if (x == null)
            {
                x = M_Utils.GetM_ConfigInfoModel(mconfigid);
                x.m_APIURL = GeneralConfigs.GetConfig().Taobao_Api.Trim();
                cache.AddObject("/Sys/GetMConfigList_" + mconfigid, x);
            }
            return x;
        }
        /// <summary>
        /// 获取商品类目列表
        /// </summary>
        /// <returns></returns>
        public static DataTable GetGoodsCatList(int mconfigid)
        {
            Yannyo.Cache.YannyoCache cache = Yannyo.Cache.YannyoCache.GetCacheService();
            DataTable x = cache.RetrieveObject("/Sys/GetGoodsCatList_" + mconfigid) as DataTable;
            if (x == null)
            {
                x = M_Utils.GetM_GoodsCatInfoList(" m_ConfigInfoID=" + mconfigid).Tables[0];
                cache.AddObject("/Sys/GetGoodsCatList_" + mconfigid, x);
            }
            return x;
        }
        /// <summary>
        /// 销售报表
        /// </summary>
        /// <param name="ReType"></param>
        /// <param name="bDate"></param>
        /// <param name="eDate"></param>
        /// <param name="NOJoinSales"></param>
        /// <param name="StoresID"></param>
        /// <param name="PaymentSystemID"></param>
        /// <param name="oSteps">步骤</param>
        /// <returns></returns>
		public static DataTable GetSalesReport(int ReType, DateTime bDate, DateTime eDate, int NOJoinSales, int StoresID, int PaymentSystemID, int oSteps ,int SingleMemberID)
        {
            Yannyo.Cache.YannyoCache cache = Yannyo.Cache.YannyoCache.GetCacheService();
			DataTable x = cache.RetrieveObject("/Sys/GetSalesReport_" + Utils.MD5(ReType.ToString() + bDate.ToString() + eDate.ToString() + NOJoinSales.ToString() + StoresID.ToString() + PaymentSystemID.ToString() + oSteps.ToString()+SingleMemberID.ToString())) as DataTable;
            if (x == null)
            {
				x = DataUtils.GetSalesReport(ReType, bDate, eDate, NOJoinSales, StoresID, PaymentSystemID, oSteps,SingleMemberID);
				cache.AddObject("/Sys/GetSalesReport_" + Utils.MD5(ReType.ToString() + bDate.ToString() + eDate.ToString() + NOJoinSales.ToString() + StoresID.ToString() + PaymentSystemID.ToString() + oSteps.ToString()+SingleMemberID.ToString()), x);
            }
            return x;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ReType"></param>
        /// <param name="bDate"></param>
        /// <param name="eDate"></param>
        /// <param name="NOJoinSales"></param>
        /// <param name="StoresID"></param>
        /// <param name="PaymentSystemID"></param>
        /// <param name="oSteps"></param>
        /// <param name="dType">统计类型,0=销售统计,1=发出商品统计(发货后,核销前)</param>
        /// <returns></returns>
		public static DataTable GetSalesReport(int ReType, DateTime bDate, DateTime eDate, int NOJoinSales, int StoresID, int PaymentSystemID, int oSteps, int dType,int SingleMemberID)
        {
            Yannyo.Cache.YannyoCache cache = Yannyo.Cache.YannyoCache.GetCacheService();
			DataTable x = cache.RetrieveObject("/Sys/GetSalesReport_" + Utils.MD5(ReType.ToString() + bDate.ToString() + eDate.ToString() + NOJoinSales.ToString() + StoresID.ToString() + PaymentSystemID.ToString() + oSteps.ToString() + dType.ToString()+SingleMemberID.ToString())) as DataTable;
            if (x == null)
            {
				x = DataUtils.GetSalesReport(ReType, bDate, eDate, NOJoinSales, StoresID, PaymentSystemID, oSteps, dType,SingleMemberID);
				cache.AddObject("/Sys/GetSalesReport_" + Utils.MD5(ReType.ToString() + bDate.ToString() + eDate.ToString() + NOJoinSales.ToString() + StoresID.ToString() + PaymentSystemID.ToString() + oSteps.ToString() + dType.ToString()+SingleMemberID.ToString()), x);
            }
            return x;
        }
		public static DataTable GetSalesReport(int ReType, DateTime bDate, DateTime eDate, int NOJoinSales, int StoresID, int PaymentSystemID, int oSteps, int dType, int CostPrice,int SingleMemberID)
        {
            Yannyo.Cache.YannyoCache cache = Yannyo.Cache.YannyoCache.GetCacheService();
			DataTable x = cache.RetrieveObject("/Sys/GetSalesReport_" + Utils.MD5(ReType.ToString() + bDate.ToString() + eDate.ToString() + NOJoinSales.ToString() + StoresID.ToString() + PaymentSystemID.ToString() + oSteps.ToString() + dType.ToString() + CostPrice.ToString()+SingleMemberID.ToString())) as DataTable;
            if (x == null)
            {
				x = DataUtils.GetSalesReport(ReType, bDate, eDate, NOJoinSales, StoresID, PaymentSystemID, oSteps, dType, CostPrice,SingleMemberID);
				cache.AddObject("/Sys/GetSalesReport_" + Utils.MD5(ReType.ToString() + bDate.ToString() + eDate.ToString() + NOJoinSales.ToString() + StoresID.ToString() + PaymentSystemID.ToString() + oSteps.ToString() + dType.ToString() + CostPrice.ToString()+SingleMemberID.ToString()), x);
            }
            return x;
        }
		public static DataTable GetSalesReport(int ReDateType,int ReType, DateTime bDate, DateTime eDate, int NOJoinSales, int StoresID, int PaymentSystemID, int oSteps, int dType, int CostPrice,int SingleMemberID,string OrderNumber)
		{
			Yannyo.Cache.YannyoCache cache = Yannyo.Cache.YannyoCache.GetCacheService();
            DataTable x = cache.RetrieveObject("/Sys/GetSalesReport_" + Utils.MD5(ReDateType.ToString() + ReType.ToString() + bDate.ToString() + eDate.ToString() + NOJoinSales.ToString() + StoresID.ToString() + PaymentSystemID.ToString() + oSteps.ToString() + dType.ToString() + CostPrice.ToString() + SingleMemberID.ToString() + OrderNumber)) as DataTable;
			if (x == null)
			{
                x = DataUtils.GetSalesReport(ReDateType,ReType, bDate, eDate, NOJoinSales, StoresID, PaymentSystemID, oSteps, dType, CostPrice, SingleMemberID, OrderNumber);
                cache.AddObject("/Sys/GetSalesReport_" + Utils.MD5(ReDateType.ToString() + ReType.ToString() + bDate.ToString() + eDate.ToString() + NOJoinSales.ToString() + StoresID.ToString() + PaymentSystemID.ToString() + oSteps.ToString() + dType.ToString() + CostPrice.ToString() + SingleMemberID.ToString() + OrderNumber), x);
			}
			return x;
		}
        public static DataSet GetProductLogDetails(DateTime bDate, DateTime eDate, int ProductsID, int CostPrice, int StorageID)
        {
            Yannyo.Cache.YannyoCache cache = Yannyo.Cache.YannyoCache.GetCacheService();
            DataSet x = cache.RetrieveObject("/Sys/GetProductLogDetails_" + Utils.MD5(ProductsID.ToString() + bDate.ToString() + eDate.ToString() + CostPrice.ToString() + StorageID.ToString() )) as DataSet;
            if (x == null)
            {
                x = DataUtils.GetProductLogDetails(bDate, eDate, ProductsID, CostPrice, StorageID);
                cache.AddObject("/Sys/GetProductLogDetails_" + Utils.MD5(ProductsID.ToString() + bDate.ToString() + eDate.ToString() + CostPrice.ToString() + StorageID.ToString() ), x);
            }
            return x;
        }
        /// <summary>
        /// 返回部门菜单HTML
        /// </summary>
        /// <returns></returns>
        public static string GetDepartmentsClassHTML()
        {
            Yannyo.Cache.YannyoCache cache = Yannyo.Cache.YannyoCache.GetCacheService();
            string x = cache.RetrieveObject("/Sys/DepartmentsClassHTML") as string;
            if (x == null)
            {
                x = DataClass.GetDepartmentsClassInfoToHTML_ToolBar();
                cache.AddObject("/Sys/DepartmentsClassHTML", x);
            }
            return x;
        }

        /// <summary>
        /// 超市系统列表
        /// </summary>
        /// <returns></returns>
        public static DataTable GetYHsysInfoList()
        {
            Yannyo.Cache.YannyoCache cache = Yannyo.Cache.YannyoCache.GetCacheService();
            DataTable x = cache.RetrieveObject("/Sys/GetYHsysInfoList") as DataTable;
            if (x == null)
            {
                x = tbYHsysInfo.GetYHsysInfoList("").Tables[0];
                cache.AddObject("/Sys/GetYHsysInfoList", x);
            }
            return x;
        }

        /// <summary>
        /// 结算系统列表
        /// </summary>
        /// <returns></returns>
        public static DataTable GetPaymentSystemList()
        {
            Yannyo.Cache.YannyoCache cache = Yannyo.Cache.YannyoCache.GetCacheService();
            DataTable x = cache.RetrieveObject("/Sys/GetPaymentSystemList") as DataTable;
            if (x == null)
            {
                x = tbPaymentSystemInfo.GetPaymentSystemList("").Tables[0];
                cache.AddObject("/Sys/GetPaymentSystemList", x);
            }
            return x;
        }
        /// <summary>
        /// 系统用户组列表
        /// </summary>
        /// <returns></returns>
        public static DataTable GetUserTypeList()
        {
            Yannyo.Cache.YannyoCache cache = Yannyo.Cache.YannyoCache.GetCacheService();
            DataTable x = cache.RetrieveObject("/Sys/GetUserTypeList") as DataTable;
            if (x == null)
            {
                x = UsersUtils.GetUserType();
                cache.AddObject("/Sys/GetUserTypeList", x);
            }
            return x;
        }
    }
}
