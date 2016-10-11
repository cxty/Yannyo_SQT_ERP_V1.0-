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
    public class DataClass
    {

        #region
        /// <summary>
        /// 返回指定分类HTML字符串
        /// </summary>
        /// <param name="DataType"></param>
        /// <returns></returns>
        public static string GetDataClassToHTML(string DataType)
        {
            string re = "";
            switch (DataType)
            {
                case "Customers":
                    re =Caches.GetCustomersClassInfoToHTML();
                    break;
                case "Departments":
                    re = Caches.GetDepartmentsClassInfoToHTML();
                    break;
                case "PriceClass":
                    re = Caches.GetPriceClassInfoToHTML();
                    break;
                case "ProductClass":
                    re = Caches.GetProductClassInfoToHTML();
                    break;
                case "SupplierClass":
                    re = Caches.GetSupplierClassInfoToHTML();
                    break;
                case "FeesSubjectClass":
                    re = Caches.GetFeesSubjectClassInfoToHTML();
                    break;
                case "Region":
                    re = Caches.GetRegionInfoToHTML(-1);
                    break;
            }
            return re;
        }

        /// <summary>
        /// 返回指定分类Json字符串
        /// </summary>
        /// <param name="DataType"></param>
        /// <returns></returns>
        public static string GetDataClassToJson(string DataType)
        {
            string re = "";
            switch (DataType)
            {
                case "Customers":
                    re =Caches.GetCustomersClassInfoToJson();
                    break;
                case "Departments":
                    re =Caches.GetDepartmentsClassInfoToJson();
                    break;
                case "PriceClass":
                    re =Caches.GetPriceClassInfoToJson();
                    break;
                case "ProductClass":
                    re =Caches.GetProductClassInfoToJson();
                    break;
                case "SupplierClass":
                    re =Caches.GetSupplierClassInfoToJson();
                    break;
                case "FeesSubjectClass":
                    re = Caches.GetFeesSubjectClassInfoToJson();
                    break;
                case "Region":
                    re =Caches.GetRegionInfoToJson();
                    break;
            }
            return re;
        }
        /// <summary>
        /// 返回指定分类Json字符串
        /// </summary>
        /// <param name="DataType"></param>
        /// <returns></returns>
		public static string GetDataClassToJson(string DataType,int pid)
        {
            string re = "";
            switch (DataType)
            {
                case "Customers":
                    re =Caches.GetCustomersClassInfoToJson(pid);
                    break;
                case "Departments":
                    re =Caches.GetDepartmentsClassInfoToJson(pid);
                    break;
                case "PriceClass":
                    re =Caches.GetPriceClassInfoToJson(pid);
                    break;
                case "ProductClass":
					re =Caches.GetProductClassInfoToJson(pid);
                    break;
                case "SupplierClass":
                    re =Caches.GetSupplierClassInfoToJson(pid);
                    break;
                case "FeesSubjectClass":
                    re = Caches.GetFeesSubjectClassInfoToJson(pid);
                    break;
                case "Region":
                    re =Caches.GetRegionInfoToJson(pid);
                    break;
                case "Storage":
                    re = Caches.GetStorageInfoToJson(pid);
                    break;

            }
            if (pid == -1) 
            {
                re = "{\"attr\":{\"id\":\"t_0\",\"value\":\"0\"},\"data\":\"分类\",\"state\":\"closed\"}";
            }
            return re;
        }
        public static string GetDataClassToJsonNOCaches(string DataType, int pid)
        {
            string re = "";
            switch (DataType)
            {
                case "Customers":
                    re = GetCustomersClassInfoToJson(pid);
                    break;
                case "Departments":
                    re = GetDepartmentsClassInfoToJson(pid);
                    break;
                case "PriceClass":
                    re = GetPriceClassInfoToJson(pid);
                    break;
                case "ProductClass":
                    re = GetProductClassInfoToJson(pid);
                    break;
                case "SupplierClass":
                    re = GetSupplierClassInfoToJson(pid);
                    break;
                case "FeesSubjectClass":
                    re = GetFeesSubjectClassInfoToJson(pid);
                    break;
                case "Region":
                    re = GetRegionInfoToJson(pid);
                    break;
                case "Storage":
                    re = GetStoragesClassInfoToJson(pid);
                    break;
            }
            if (pid == -1)
            {
                re = "{\"attr\":{\"id\":\"t_0\",\"value\":\"0\"},\"data\":\"分类\",\"state\":\"closed\"}";
            }
            return re;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="DataType"></param>
        /// <param name="pid"></param>
        /// <param name="getdata">是否显示该分类下的具体数据</param>
        /// <returns></returns>
		public static string GetDataClassToJson(string DataType, int pid,bool getdata,int orderType = 0)
        {
            string re = "";

            switch (DataType)
            {
                case "Customers":
                    re =Caches.GetCustomersClassInfoToJson(pid, getdata);
                    break;
                case "Departments":
                    re =Caches.GetDepartmentsClassInfoToJson(pid, getdata);
                    break;
                case "PriceClass":
                    re =Caches.GetPriceClassInfoToJson(pid, getdata);
                    break;
				case "ProductClass":

					re = DataClass.GetProductClassInfoToJson(pid, getdata,orderType);//Caches.GetProductClassInfoToJson(pid, getdata,orderType);
                    //re = Caches.GetProductClassInfoToJson(pid, getdata, orderType);
                    break;
                case "FeesSubjectClass":
                    re = Caches.GetFeesSubjectClassInfoToJson(pid, getdata);
                    break;
                case "SupplierClass":
                    re =Caches.GetSupplierClassInfoToJson(pid, getdata);
                    break;
                case "Storage":
                    re = Caches.GetStorageClassInfoToJson(pid,getdata);
                    break;
            }
            if (pid == -1)
            {
                re = "{\"attr\":{\"id\":\"t_0\",\"value\":\"0\"},\"data\":\"分类\",\"state\":\"closed\"}";
            }
            return re;
        }
        public static int CreateDataClass(string DataType, int pid,string ClassName)
        {
            int re = 0;
            switch (DataType)
            {
                case "Customers":
                    if (!ExistsCustomersClassInfo(ClassName, pid))
                    {
                        CustomersClassInfo Customers = new CustomersClassInfo();
                        try
                        {
                            Customers.cAppendTime = DateTime.Now;
                            Customers.cClassName = ClassName;
                            Customers.cOrder = 0;
                            Customers.cParentID = pid;

                            re = AddCustomersClassInfo(Customers);
                        }
                        finally {
                            Customers = null;
                        }
                    }
                    break;
                case "Departments":
                    if (!ExistsDepartmentsClassInfo(ClassName, pid))
                    {
                        DepartmentsClassInfo Departments = new DepartmentsClassInfo();
                        try
                        {
                            Departments.dAppendTime = DateTime.Now;
                            Departments.dClassName = ClassName;
                            Departments.dOrder = 0;
                            Departments.dParentID = pid;

                            re = AddDepartmentsClassInfo(Departments);
                        }
                        finally
                        {
                            Departments = null;
                        }
                    }
                    break;
                case "PriceClass":
                    if (!ExistsPriceClassInfo(ClassName, pid))
                    {
                        PriceClassInfo PriceClass = new PriceClassInfo();
                        try
                        {
                            PriceClass.pAppendTime = DateTime.Now;
                            PriceClass.pClassName = ClassName;
                            PriceClass.pOrder = 0;
                            PriceClass.pParentID = pid;

                            re = AddPriceClassInfo(PriceClass);
                        }
                        finally
                        {
                            PriceClass = null;
                        }
                    }
                    break;
                case "ProductClass":
                    if (!ExistsProductClassInfo(ClassName, pid))
                    {
                        ProductClassInfo ProductClass = new ProductClassInfo();
                        try
                        {
                            ProductClass.pAppendTime = DateTime.Now;
                            ProductClass.pClassName = ClassName;
                            ProductClass.pOrder = 0;
                            ProductClass.pParentID = pid;

                            re = AddProductClassInfo(ProductClass);
                        }
                        finally
                        {
                            ProductClass = null;
                        }
                    }
                    break;
                case "SupplierClass":
                    if (!ExistsSupplierClassInfo(ClassName, pid))
                    {
                        SupplierClassInfo SupplierClass = new SupplierClassInfo();
                        try
                        {
                            SupplierClass.sAppendTime = DateTime.Now;
                            SupplierClass.sClassName = ClassName;
                            SupplierClass.sOrder = 0;
                            SupplierClass.sParentID = pid;

                            re = AddSupplierClassInfo(SupplierClass);
                        }
                        finally
                        {
                            SupplierClass = null;
                        }
                    }
                    break;
                case "FeesSubjectClass":
                    if (!ExistsFeesSubjectClassInfo(ClassName, pid))
                    {
                        FeesSubjectClassInfo FeesSubjectClass = new FeesSubjectClassInfo();
                        try
                        {
                            FeesSubjectClass.cAppendTime = DateTime.Now;
                            FeesSubjectClass.cClassName = ClassName;
                            FeesSubjectClass.cOrder = 0;
                            FeesSubjectClass.cParentID = pid;

                            re = AddFeesSubjectClassInfo(FeesSubjectClass);
                        }
                        finally
                        {
                            FeesSubjectClass = null;
                        }
                    }
                    break;
                case "Region":
                    if (!tbRegionInfo.ExistsRegionInfo(ClassName, pid))
                    {
                        RegionInfo Region = new RegionInfo();
                        try
                        {
                            Region.rAppendTime = DateTime.Now;
                            Region.rName = ClassName;
                            Region.rOrder = 0;
                            Region.rUpID = pid;
                            Region.rState = 0;

                            re = tbRegionInfo.AddRegionInfo(Region);
                        }
                        finally
                        {
                            Region = null;
                        }
                    }
                    break;
                case "Storage":
                     if (!tbStorageInfo.ExistsStorageInfo(ClassName, pid))
                    {
                        StorageClass storage = new StorageClass();
                        try
                        {
                            storage.SAppendTime = DateTime.Now;
                            storage.SClassName = ClassName;
                            storage.SOrder = 0;
                            storage.SParentID = pid;

                            re = tbStorageInfo.AddStorageListInfo(storage);
                        }
                        finally
                        {
                            storage = null;
                        }
                    }
                    break;
            }
            return re;
        }
        public static bool UpdateDataClass(string DataType,int pid, int cid, string ClassName)
        {
            bool re = false;
            switch (DataType)
            {
                case "Customers":
                    if (!ExistsCustomersClassInfo(ClassName, pid))
                    {
                        CustomersClassInfo Customers = new CustomersClassInfo();
                        try
                        {
                            Customers = GetCustomersClassInfoModel(cid);
                            
                            Customers.cClassName = ClassName;
                            
                            Customers.cParentID = pid;

                             UpdateCustomersClassInfo(Customers);

                             re = true;
                        }
                        finally
                        {
                            Customers = null;
                        }
                    }
                    break;
                case "Departments":
                    if (!ExistsDepartmentsClassInfo(ClassName, pid))
                    {
                        DepartmentsClassInfo Departments = new DepartmentsClassInfo();
                        try
                        {
                            Departments = GetDepartmentsClassInfoModel(cid);
 
                            Departments.dClassName = ClassName;
                            
                            Departments.dParentID = pid;

                            UpdateDepartmentsClassInfo(Departments);
                            re = true;
                        }
                        finally
                        {
                            Departments = null;
                        }
                    }
                    break;
                case "PriceClass":
                    if (!ExistsPriceClassInfo(ClassName, pid))
                    {
                        PriceClassInfo PriceClass = new PriceClassInfo();
                        try
                        {
                            PriceClass = GetPriceClassInfoModel(cid);
                            
                            PriceClass.pClassName = ClassName;
                            
                            PriceClass.pParentID = pid;

                            UpdatePriceClassInfo(PriceClass);

                            re = true;
                        }
                        finally
                        {
                            PriceClass = null;
                        }
                    }
                    break;
                case "ProductClass":
                    if (!ExistsProductClassInfo(ClassName, pid))
                    {
                        ProductClassInfo ProductClass = new ProductClassInfo();
                        try
                        {
                            ProductClass = GetProductClassInfoModel(cid);
                            
                            ProductClass.pClassName = ClassName;
                            
                            ProductClass.pParentID = pid;

                            UpdateProductClassInfo(ProductClass);

                            re = true;
                        }
                        finally
                        {
                            ProductClass = null;
                        }
                    }
                    break;
                case "SupplierClass":
                    if (!ExistsSupplierClassInfo(ClassName, pid))
                    {
                        SupplierClassInfo SupplierClass = new SupplierClassInfo();
                        try
                        {
                            SupplierClass = GetSupplierClassInfoModel(cid);
                            
                            SupplierClass.sClassName = ClassName;
                            
                            SupplierClass.sParentID = pid;

                            UpdateSupplierClassInfo(SupplierClass);

                            re = true;
                        }
                        finally
                        {
                            SupplierClass = null;
                        }
                    }
                    break;
                case "FeesSubjectClass":
                    if (!ExistsFeesSubjectClassInfo(ClassName, pid))
                    {
                        FeesSubjectClassInfo FeesSubjectClass = new FeesSubjectClassInfo();
                        try
                        {
                            FeesSubjectClass = GetFeesSubjectClassInfoModel(cid);

                            FeesSubjectClass.cClassName = ClassName;

                            FeesSubjectClass.cParentID = pid;

                            UpdateFeesSubjectClassInfo(FeesSubjectClass);

                            re = true;
                        }
                        finally
                        {
                            FeesSubjectClass = null;
                        }
                    }
                    break;
                case "Region":
                    if (!tbRegionInfo.ExistsRegionInfo(ClassName, pid))
                    {
                        RegionInfo Region = new RegionInfo();
                        try
                        {
                            Region = tbRegionInfo.GetRegionInfoModel(cid);

                            Region.rName = ClassName;

                            Region.rUpID = pid;

                            tbRegionInfo.UpdateRegionInfo(Region);

                            re = true;
                        }
                        finally
                        {
                            Region = null;
                        }
                    }
                    break;
                case "Storage":
                    if (!tbStorageInfo.ExistsStorageInfo(ClassName, pid))
                    {
                        StorageClass Storage = new StorageClass();
                        try
                        {
                            Storage = tbStorageInfo.GetStoragesInfoModel(cid);

                            Storage.SClassName = ClassName;

                            Storage.SParentID = pid;

                            tbStorageInfo.UpdateStoragesInfo(Storage);

                            re = true;
                        }
                        finally
                        {
                            Storage = null;
                        }
                    }
                    break;
            }
            return re;
        }
        public static bool DelDataClass(string DataType, int pid, int cid)
        {
            bool re = false;
            switch (DataType)
            {
                case "Customers":
                    {
                        
                        try
                        {
                            DeleteCustomersClassInfo(cid);
                            re = true;
                        }
                        finally
                        {
                            
                        }
                    }
                    break;
                case "Departments":
                    {
                        try
                        {
                            DeleteDepartmentsClassInfo(cid);
                            re = true;
                        }
                        finally
                        {
                        }
                    }
                    break;
                case "PriceClass":
                    {
                        try
                        {
                            DeletePriceClassInfo(cid);
                            re = true;
                        }
                        finally
                        {

                        }
                    }
                    break;
                case "ProductClass":
                    {
                        try
                        {
                            DeleteProductClassInfo(cid);
                            re = true;
                        }
                        finally
                        {
                        }
                    }
                    break;
                case "SupplierClass":
                    {
                        try
                        {
                            DeleteSupplierClassInfo(cid);
                            re = true;
                        }
                        finally
                        {
                        }
                    }
                    break;
                case "FeesSubjectClass":
                    {

                        try
                        {
                            DeleteFeesSubjectClassInfo(cid);
                            re = true;
                        }
                        finally
                        {

                        }
                    }
                    break;
                case "Region":
                    {
                        try
                        {
                          tbRegionInfo.DeleteRegionInfo(cid);
                            re = true;
                        }
                        finally
                        {
                        }
                    }
                    break;
                case "Storage":
                    {
                        try
                        {
                            tbStorageInfo.DeleteStoragesInfo(cid);
                            re = true;
                        }
                        finally
                        {
                        }
                    }
                    break;
            }
            return re;
        }
        #endregion
        #region  CustomersClass

        public static DataTable getCustomersClassList(int ParentID)
        {
            return DatabaseProvider.GetInstance().getCustomersClassList(ParentID);
        }
        public static DataTable GetCustomersDetails(int CustomersClassID)
        {
            return DatabaseProvider.GetInstance().GetCustomersDetails(CustomersClassID);
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool ExistsCustomersClassInfo(string cClassName, int cParentID)
        {
            return DatabaseProvider.GetInstance().ExistsCustomersClassInfo(cClassName, cParentID);
        }
        /// <summary>
        /// 是否有子节点,即是否为叶节点
        /// </summary>
        /// <param name="CustomersClassID"></param>
        /// <returns></returns>
        public static bool ExistsCustomersClassChild(int CustomersClassID)
        {
            return DatabaseProvider.GetInstance().ExistsCustomersClassChild(CustomersClassID);
        }
        public static int AddCustomersClassInfo(CustomersClassInfo model)
        {
            return DatabaseProvider.GetInstance().AddCustomersClassInfo(model);
        }
        public static int UpdateCustomersClassInfo(CustomersClassInfo model)
        {
            return DatabaseProvider.GetInstance().UpdateCustomersClassInfo(model);
        }
        public static int DeleteCustomersClassInfo(int CustomersClassID)
        {
            return DatabaseProvider.GetInstance().DeleteCustomersClassInfo(CustomersClassID);
        }
        public static CustomersClassInfo GetCustomersClassInfoModel(int CustomersClassID)
        {
            return DatabaseProvider.GetInstance().GetCustomersClassInfoModel(CustomersClassID);
        }
        public static DataSet GetCustomersClassInfoList(string strWhere)
        {
            return DatabaseProvider.GetInstance().GetCustomersClassInfoList(strWhere);
        }
        public static DataSet GetCustomersClassInfoList(int Top, string strWhere, string filedOrder)
        {
            return DatabaseProvider.GetInstance().GetCustomersClassInfoList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 取指定客户分类下的所有编号列表
        /// </summary>
        /// <param name="CustomersClassID"></param>
        /// <returns></returns>
        public static string GetCustomersClassChildStr(int CustomersClassID)
        {
            return  Utils.ReSQLSetTxt(DatabaseProvider.GetInstance().GetDataFieldStr("tbCustomersClassInfo", "CustomersClassID", "cParentID", CustomersClassID,""));
        }
        #region Json
        /// <summary>
        /// Json
        /// </summary>
        /// <returns></returns>
        public static string GetCustomersClassInfoToJson()
        {
            string json = "";
            DataTable dt = GetCustomersClassInfoList("").Tables[0];
            json = GetCustomersClassInfoToJson_Loop(dt, 0);
            return Utils.ReSQLSetTxt(json);
        }
        public static string GetCustomersClassInfoToJson(int pid)
        {
            string json = "";
            DataTable dt = GetCustomersClassInfoList(" cParentID="+pid).Tables[0];
            json = GetCustomersClassInfoToJson_Loop_b(dt, pid);
            return Utils.ReSQLSetTxt(json);
        }
        public static string GetCustomersClassInfoToJson(int pid, bool getdata)
        {
            string json = "";
            DataTable dt = GetCustomersClassInfoList(" cParentID=" + pid).Tables[0];
            json = GetCustomersClassInfoToJson_Loop_b(dt, pid, getdata);
            return Utils.ReSQLSetTxt(json);
        }
        public static string GetCustomersClassInfoToJson(int pid, bool getdata,bool isAll)
        {
            string json = "";
            DataTable dt = GetCustomersClassInfoList(pid != -1 ? " cParentID=" + pid : "").Tables[0];
            json = GetCustomersClassInfoToJson_Loop_c(dt, pid != -1 ? pid : 0, getdata);

            if (json == "")
            {
                getdata = false;
            }
            //未归类,或类丢失的
            if (getdata)
            {
                DataTable dtt = new DataTable();
                try
                {
                    dtt = tbStoresInfo.GetStoresInfoList(" CustomersClassID not in(select CustomersClassID from tbCustomersClassInfo ) and CustomersClassID<>0").Tables[0];
                    if (dtt != null)
                    {
                        foreach (DataRow drr in dtt.Rows)
                        {
                            json = json + ",{\"data\":\"" + drr["sName"].ToString() + "\",\"state\":\"closed\",\"attr\":{\"id\":\"d_" + drr["StoresID"].ToString() + "\",\"rel\":\"dt\",\"value\":\"" + drr["StoresID"].ToString() + "\",\"otype\":\"0\"}}";
                        }
                    }

                }
                finally
                {
                    dtt.Clear();
                }
            }

            return Utils.ReSQLSetTxt(json);
        }

        public static string GetCustomersClassInfoToJson_Loop(DataTable dt, int sParentID)
        {
            string json = "";
            foreach (DataRow dr in dt.Rows)
            {
                if (Convert.ToInt32(dr["cParentID"].ToString()) == sParentID)
                {
                    json = json + "{\"data\":\"" + dr["cClassName"].ToString() + "\",\"state\":\"closed\",\"attr\":{\"id\":\"t_" + dr["CustomersClassID"].ToString() + "\",\"value\":\"" + dr["CustomersClassID"].ToString() + "\",\"pid\":\"" + sParentID + "\"},\"children\":[" + GetCustomersClassInfoToJson_Loop(dt, Convert.ToInt32(dr["CustomersClassID"].ToString())) + "]},";
                }
            }
            return Utils.ReSQLSetTxt(json);
        }
        public static string GetCustomersClassInfoToJson_Loop_b(DataTable dt, int sParentID)
        {
            string json = "";
            foreach (DataRow dr in dt.Rows)
            {
                if (Convert.ToInt32(dr["cParentID"].ToString()) == sParentID)
                {
                    json = json + "{\"data\":\"" + dr["cClassName"].ToString() + "\",\"state\":\"closed\",\"attr\":{\"id\":\"t_" + dr["CustomersClassID"].ToString() + "\",\"value\":\"" + dr["CustomersClassID"].ToString() + "\",\"pid\":\"" + sParentID + "\"}},";
                }
            }
            return Utils.ReSQLSetTxt(json);
        }
        public static string GetCustomersClassInfoToJson_Loop_b(DataTable dt, int sParentID, bool getdata)
        {
            string json = "";
            foreach (DataRow dr in dt.Rows)
            {
                if (Convert.ToInt32(dr["cParentID"].ToString()) == sParentID)
                {
                    json = json + "{\"data\":\"" + dr["cClassName"].ToString() + "\",\"state\":\"closed\",\"attr\":{\"id\":\"t_" + dr["CustomersClassID"].ToString() + "\",\"rel\":\"root\",\"value\":\"" + dr["CustomersClassID"].ToString() + "\",\"pid\":\"" + sParentID + "\"}},";
                }
            }
            if (getdata)
            {
                DataTable dtt = new DataTable();
                try
                {
                    dtt = tbStoresInfo.GetStoresInfoList(" CustomersClassID=" + sParentID).Tables[0];
                    if (dtt != null)
                    {
                        foreach (DataRow drr in dtt.Rows)
                        {
                            json = json + "{\"data\":\"" + drr["sName"].ToString() + "\",\"state\":\"closed\",\"attr\":{\"id\":\"d_" + drr["StoresID"].ToString() + "\",\"rel\":\"dt\",\"value\":\"" + drr["StoresID"].ToString() + "\"}},";
                        }
                    }
                }
                finally
                {
                    dtt.Clear();
                }
            }
            return Utils.ReSQLSetTxt(json);
        }
        public static string GetCustomersClassInfoToJson_Loop_c(DataTable dt, int sParentID, bool getdata)
        {
            string json = "";
            foreach (DataRow dr in dt.Rows)
            {
                if (Convert.ToInt32(dr["cParentID"].ToString()) == sParentID)
                {
                    json = json + "{\"data\":\"" + dr["cClassName"].ToString() + "\",\"state\":\"closed\",\"attr\":{\"id\":\"t_" + dr["CustomersClassID"].ToString() + "\",\"rel\":\"root\",\"value\":\"" + dr["CustomersClassID"].ToString() + "\",\"pid\":\"" + sParentID + "\"},\"children\":[" + GetCustomersClassInfoToJson_Loop_c(dt, Convert.ToInt32(dr["CustomersClassID"].ToString()), getdata) + "]},";
                }
            }
            if (getdata)
            {
                DataTable dtt = new DataTable();
                try
                {
                    dtt = tbStoresInfo.GetStoresInfoList(" CustomersClassID=" + sParentID).Tables[0];
                    if (dtt != null)
                    {
                        foreach (DataRow drr in dtt.Rows)
                        {
                            json = json + "{\"data\":\"" + drr["sName"].ToString() + "\",\"state\":\"closed\",\"attr\":{\"id\":\"d_" + drr["StoresID"].ToString() + "\",\"rel\":\"dt\",\"value\":\"" + drr["StoresID"].ToString() + "\",\"otype\":\"0\"}},";
                        }
                    }
                   
                }
                finally
                {
                    dtt.Clear();
                }
            }
            return Utils.ReSQLSetTxt(json);
        }
        #endregion

        #region HTML
        /// <summary>
        /// HTML
        /// </summary>
        /// <returns></returns>
        public static string GetCustomersClassInfoToHTML()
        {
            string thtml = "";
            DataTable dt = GetCustomersClassInfoList("").Tables[0];
            thtml = GetCustomersClassInfoToHTML_Loop(dt, 0);
            return Utils.ReSQLSetTxt(thtml);
        }
        public static string GetCustomersClassInfoAndDataToHTML()
        {
            string thtml = "";
            DataTable dt = GetCustomersClassInfoList("").Tables[0];
            thtml = GetCustomersClassInfoToHTML_Loop_c(dt, 0);
            return Utils.ReSQLSetTxt(thtml);
        }
        public static string GetCustomersClassInfoToHTML(int pid)
        {
            string thtml = "";
            DataTable dt = GetCustomersClassInfoList(" cParentID=" + pid).Tables[0];
            thtml = GetCustomersClassInfoToHTML_Loop_b(dt, pid);
            return Utils.ReSQLSetTxt(thtml);
        }
        public static string GetCustomersClassInfoToHTML_Loop(DataTable dt, int sParentID)
        {
            string thtml = "";
            foreach (DataRow dr in dt.Rows)
            {
                if (Convert.ToInt32(dr["cParentID"].ToString()) == sParentID)
                {
                    thtml = thtml + "<li rel=\"" + dr["CustomersClassID"].ToString() + "\">" + dr["cClassName"].ToString() + GetCustomersClassInfoToHTML_Loop(dt, Convert.ToInt32(dr["CustomersClassID"].ToString())) + "</li>";
                }
            }
            if (sParentID > 0)
            {
                return (thtml.Trim() != "") ? "<ul>" + thtml + "</ul>" : "";
            }
            else {
                return thtml;
            }
        }
        public static string GetCustomersClassInfoToHTML_Loop_b(DataTable dt, int sParentID)
        {
            string thtml = "";
            foreach (DataRow dr in dt.Rows)
            {
                if (Convert.ToInt32(dr["cParentID"].ToString()) == sParentID)
                {
                    thtml = thtml + "<li rel=\"" + dr["CustomersClassID"].ToString() + "\">" + dr["cClassName"].ToString() +  "</li>";
                }
            }
            if (sParentID > 0)
            {
                return "<ul>" + thtml + "</ul>";
            }
            else
            {
                return thtml;
            }
        }
        public static string GetCustomersClassInfoToHTML_Loop_c(DataTable dt, int sParentID)
        {
            string thtml = "";
            string dthtml = "";
            foreach (DataRow dr in dt.Rows)
            {
                if (Convert.ToInt32(dr["cParentID"].ToString()) == sParentID)
                {
                    dthtml = "";
                    DataTable dtt = new DataTable();
                    try
                    {
                        dtt = tbStoresInfo.GetStoresInfoList(" CustomersClassID=" + sParentID).Tables[0];
                        if (dtt != null)
                        {
                            foreach (DataRow drr in dtt.Rows)
                            {
                                dthtml = dthtml + "<li rel=\"c_" + drr["StoresID"].ToString() + "\" tag=\"dt\">" + drr["sName"].ToString() + "</li>";
                            }
                        }
                        dthtml = (dthtml.Trim() != "") ? "<ul>" + dthtml + "</ul>" : "";
                    }
                    finally
                    {
                        dtt.Clear();
                    }
                    thtml = thtml + "<li rel=\"" + dr["CustomersClassID"].ToString() + "\" tag=\"root\">" + dr["cClassName"].ToString() + dthtml + GetCustomersClassInfoToHTML_Loop_c(dt, Convert.ToInt32(dr["CustomersClassID"].ToString())) + "</li>";
                }
            }
            if (sParentID > 0)
            {
                return "<ul>" + thtml + "</ul>";
            }
            else
            {
                return thtml;
            }
        }
        #endregion

        #endregion
        #region DepartmentsClass
        public static DataTable getDepartmentClassList(int ParentID)
        {
            return DatabaseProvider.GetInstance().getDepartmentClassList(ParentID);
        }
        public static DataTable GetDepartmentClassDetails(int DepartClassID)
        {
            return DatabaseProvider.GetInstance().GetDepartmentClassDetails(DepartClassID);
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool ExistsDepartmentsClassInfo(string dClassName, int dParentID)
        {
            return DatabaseProvider.GetInstance().ExistsDepartmentsClassInfo(dClassName, dParentID);
        }
        /// <summary>
        /// 是否有子节点,即是否为叶节点
        /// </summary>
        /// <param name="DepartmentsClassID"></param>
        /// <returns></returns>
        public static bool ExistsDepartmentsClassChild(int DepartmentsClassID)
        { 
            return DatabaseProvider.GetInstance().ExistsDepartmentsClassChild( DepartmentsClassID);
        }
        public static int AddDepartmentsClassInfo(DepartmentsClassInfo model)
        {
            return DatabaseProvider.GetInstance().AddDepartmentsClassInfo(model);
        }
        public static int UpdateDepartmentsClassInfo(DepartmentsClassInfo model)
        {
            return DatabaseProvider.GetInstance().UpdateDepartmentsClassInfo(model);
        }
        public static int DeleteDepartmentsClassInfo(int DepartmentsClassID)
        {
            return DatabaseProvider.GetInstance().DeleteDepartmentsClassInfo(DepartmentsClassID);
        }
        public static DepartmentsClassInfo GetDepartmentsClassInfoModel(int DepartmentsClassID)
        {
            return DatabaseProvider.GetInstance().GetDepartmentsClassInfoModel(DepartmentsClassID);
        }
        public static DataSet GetDepartmentsClassInfoList(string strWhere)
        {
            return DatabaseProvider.GetInstance().GetDepartmentsClassInfoList(strWhere);
        }
        public static DataSet GetDepartmentsClassInfoList(int Top, string strWhere, string filedOrder)
        {
            return DatabaseProvider.GetInstance().GetDepartmentsClassInfoList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 取指定部门分类下的所有编号列表
        /// </summary>
        /// <param name="DepartmentsClassID"></param>
        /// <returns></returns>
        public static string GetDepartmentsClassChildStr(int DepartmentsClassID)
        {
            return Utils.ReSQLSetTxt(DatabaseProvider.GetInstance().GetDataFieldStr("tbDepartmentsClassInfo", "DepartmentsClassID", "dParentID", DepartmentsClassID, ""));
        }
        //取部门分类的父列表
        public static string GetDepartmentsClassPaterStr(int DepartmentsClassID, string sStr)
        {
            string reStr = DatabaseProvider.GetInstance().GetDataFieldStr("tbDepartmentsClassInfo", "dClassName", "dParentID", "DepartmentsClassID", DepartmentsClassID, "", sStr);
            if (reStr.Trim() != "")
            {
                return (reStr.Substring(0, sStr.Length) == sStr) ? reStr.Substring(sStr.Length) : reStr;
            }
            else
            {
                return "";
            }
        }
        #region Json
        /// <summary>
        /// Json
        /// </summary>
        /// <returns></returns>
        public static string GetDepartmentsClassInfoToJson()
        {
            string json = "";
            DataTable dt = GetDepartmentsClassInfoList("").Tables[0];
            json = GetDepartmentsClassInfoToJson_Loop(dt, 0);
            return Utils.ReSQLSetTxt(json);
        }
        public static string GetDepartmentsClassInfoToJson(int pid)
        {
            string json = "";
            DataTable dt = GetDepartmentsClassInfoList(" dParentID="+pid).Tables[0];
            json = GetDepartmentsClassInfoToJson_Loop_b(dt, pid);
            return Utils.ReSQLSetTxt(json);
        }
        /// <summary>
        /// 含部门人员
        /// </summary>
        /// <param name="pid"></param>
        /// <param name="getdata"></param>
        /// <returns></returns>
        public static string GetDepartmentsClassInfoToJson(int pid, bool getdata)
        {
            string json = "";
            DataTable dt = GetDepartmentsClassInfoList(" dParentID=" + pid).Tables[0];
            json = GetDepartmentsClassInfoToJson_Loop_b(dt, pid, getdata);
            return Utils.ReSQLSetTxt(json);
        }
        /// <summary>
        /// 含部门人员,全部数据
        /// </summary>
        /// <param name="pid"></param>
        /// <param name="getdata"></param>
        /// <param name="isAll"></param>
        /// <returns></returns>
        public static string GetDepartmentsClassInfoToJson(int pid, bool getdata,bool isAll)
        {
            string json = "";
            DataTable dt = GetDepartmentsClassInfoList(pid != -1 ? " dParentID=" + pid : "").Tables[0];
            json = GetDepartmentsClassInfoToJson_Loop_c(dt, pid != -1 ? pid : 0, getdata);
            if (getdata)
            {
                DataTable dtt = new DataTable();
                try
                {
                    dtt = tbStaffInfo.GetStaffInfoList(" DepartmentsClassID not in(select DepartmentsClassID from tbDepartmentsClassInfo) and DepartmentsClassID<>0").Tables[0];
                    if (dtt != null)
                    {
                        foreach (DataRow drr in dtt.Rows)
                        {
                            json = json + ",{\"data\":\"" + drr["sName"].ToString() + "\",\"state\":\"closed\",\"attr\":{\"id\":\"d_" + drr["StaffID"].ToString() + "\",\"rel\":\"dt\",\"value\":\"" + drr["StaffID"].ToString() + "\",\"otype\":\"2\"}}";
                        }
                    }
                }
                finally
                {
                    dtt.Clear();
                }
            }
            return Utils.ReSQLSetTxt(json);
        }
        public static string GetDepartmentsClassInfoToJson_Loop(DataTable dt, int sParentID)
        {
            string json = "";
            foreach (DataRow dr in dt.Rows)
            {
                if (Convert.ToInt32(dr["dParentID"].ToString()) == sParentID)
                {
                    json = json + "{\"data\":\"" + dr["dClassName"].ToString() + "\",\"state\":\"closed\",\"attr\":{\"id\":\"t_" + dr["DepartmentsClassID"].ToString() + "\",\"value\":\"" + dr["DepartmentsClassID"].ToString() + "\",\"pid\":\"" + sParentID + "\"},\"children\":[" + GetDepartmentsClassInfoToJson_Loop(dt, Convert.ToInt32(dr["DepartmentsClassID"].ToString())) + "]},";
                }
            }
            return Utils.ReSQLSetTxt(json);
        }
        public static string GetDepartmentsClassInfoToJson_Loop_b(DataTable dt, int sParentID)
        {
            string json = "";
            foreach (DataRow dr in dt.Rows)
            {
                if (Convert.ToInt32(dr["dParentID"].ToString()) == sParentID)
                {
                    json = json + "{\"data\":\"" + dr["dClassName"].ToString() + "\",\"state\":\"closed\",\"attr\":{\"id\":\"t_" + dr["DepartmentsClassID"].ToString() + "\",\"value\":\"" + dr["DepartmentsClassID"].ToString() + "\",\"pid\":\"" + sParentID + "\"}},";
                }
            }
            return Utils.ReSQLSetTxt(json);
        }
        public static string GetDepartmentsClassInfoToJson_Loop_b(DataTable dt, int sParentID, bool getdata)
        {
            string json = "";
            foreach (DataRow dr in dt.Rows)
            {
                if (Convert.ToInt32(dr["dParentID"].ToString()) == sParentID)
                {
                    json = json + "{\"data\":\"" + dr["dClassName"].ToString() + "\",\"state\":\"closed\",\"attr\":{\"id\":\"t_" + dr["DepartmentsClassID"].ToString() + "\",\"rel\":\"root\",\"value\":\"" + dr["DepartmentsClassID"].ToString() + "\",\"pid\":\"" + sParentID + "\"}},";
                    
                }
            }
            if (getdata)
            {
                DataTable dtt = new DataTable();
                try
                {
                    dtt = tbStaffInfo.GetStaffInfoList(" DepartmentsClassID=" + sParentID).Tables[0];
                    if (dtt != null)
                    {
                        foreach (DataRow drr in dtt.Rows)
                        {
                            json = json + "{\"data\":\"" + drr["sName"].ToString() + "\",\"state\":\"closed\",\"attr\":{\"id\":\"d_" + drr["StaffID"].ToString() + "\",\"rel\":\"dt\",\"value\":\"" + drr["StaffID"].ToString() + "\"}},";
                        }
                    }
                }
                finally
                {
                    dtt.Clear();
                }
            }
            return Utils.ReSQLSetTxt(json);
        }
        public static string GetDepartmentsClassInfoToJson_Loop_c(DataTable dt, int sParentID, bool getdata)
        {
            string json = "";
            foreach (DataRow dr in dt.Rows)
            {
                if (Convert.ToInt32(dr["dParentID"].ToString()) == sParentID)
                {
                    json = json + "{\"data\":\"" + dr["dClassName"].ToString() + "\",\"state\":\"closed\",\"attr\":{\"id\":\"t_" + dr["DepartmentsClassID"].ToString() + "\",\"rel\":\"root\",\"value\":\"" + dr["DepartmentsClassID"].ToString() + "\",\"pid\":\"" + sParentID + "\"},\"children\":[" + GetDepartmentsClassInfoToJson_Loop_c(dt, Convert.ToInt32(dr["DepartmentsClassID"].ToString()), getdata) + "]},";

                }
            }
            if (getdata)
            {
                DataTable dtt = new DataTable();
                try
                {
                    dtt = tbStaffInfo.GetStaffInfoList(" DepartmentsClassID=" + sParentID).Tables[0];
                    if (dtt != null)
                    {
                        foreach (DataRow drr in dtt.Rows)
                        {
                            json = json + "{\"data\":\"" + drr["sName"].ToString() + "\",\"state\":\"closed\",\"attr\":{\"id\":\"d_" + drr["StaffID"].ToString() + "\",\"rel\":\"dt\",\"value\":\"" + drr["StaffID"].ToString() + "\",\"otype\":\"2\"}},";
                        }
                    }
                }
                finally
                {
                    dtt.Clear();
                }
            }
            return Utils.ReSQLSetTxt(json);
        }
        #endregion

        #region HTML
        /// <summary>
        /// HTML
        /// </summary>
        /// <returns></returns>
        public static string GetDepartmentsClassInfoToHTML()
        {
            string thtml = "";
            DataTable dt = GetDepartmentsClassInfoList("").Tables[0];
            thtml = GetDepartmentsClassInfoToHTML_Loop(dt, 0);
            return thtml;
        }
        public static string GetDepartmentsClassInfoAndStaffListToHTML()
        {
            string thtml = "";
            DataTable dt = GetDepartmentsClassInfoList("").Tables[0];
            thtml = GetDepartmentsClassInfoToHTML_Loop_c(dt, 0);
            return thtml;
        }
        public static string GetDepartmentsClassInfoToHTML_ToolBar()
        {
            string thtml = "";
            DataTable dt = GetDepartmentsClassInfoList("").Tables[0];
            thtml = GetDepartmentsClassInfoToHTML_Loop_ToolBar(dt, 0, "cat-item cat-item-41");
            return thtml;
        }
        public static string GetDepartmentsClassInfoToHTML(int pid)
        {
            string thtml = "";
            DataTable dt = GetDepartmentsClassInfoList(" dParentID=" + pid).Tables[0];
            thtml = GetDepartmentsClassInfoToHTML_Loop_b(dt, pid);
            return thtml;
        }
        public static string GetDepartmentsClassInfoToHTML_Loop(DataTable dt, int sParentID)
        {
            string thtml = "";
            foreach (DataRow dr in dt.Rows)
            {
                if (Convert.ToInt32(dr["dParentID"].ToString()) == sParentID)
                {
                    thtml = thtml + "<li rel=\"" + dr["DepartmentsClassID"].ToString() + "\">" + dr["dClassName"].ToString() + GetDepartmentsClassInfoToHTML_Loop(dt, Convert.ToInt32(dr["DepartmentsClassID"].ToString())) + "</li>";
                }
            }
            if (sParentID > 0)
            {
                return (thtml.Trim() != "") ? "<ul>" + thtml + "</ul>" : "";
            }
            else
            {
                return thtml;
            }
        }
        public static string GetDepartmentsClassInfoToHTML_Loop_ToolBar(DataTable dt, int sParentID,string tStr)
        {
            string thtml = "";
            int l = 1;
            foreach (DataRow dr in dt.Rows)
            {
                if (Convert.ToInt32(dr["dParentID"].ToString()) == sParentID)
                {
                    thtml = thtml + "<li class=\"cat-item " + tStr + "" + l + "\" ><a href=\"/staff.aspx?DepartmentsClassID=" + dr["DepartmentsClassID"].ToString() + "\">" + dr["dClassName"].ToString() + "</a>" + GetDepartmentsClassInfoToHTML_Loop_ToolBar(dt, Convert.ToInt32(dr["DepartmentsClassID"].ToString()), tStr+l) + "</li>";
                    l++;
                }
            }

                return (thtml.Trim() != "") ? "<ul class=\"children\">" + thtml + "</ul>" : "";

        }
        public static string GetDepartmentsClassInfoToHTML_Loop_b(DataTable dt, int sParentID)
        {
            string thtml = "";
            foreach (DataRow dr in dt.Rows)
            {
                if (Convert.ToInt32(dr["dParentID"].ToString()) == sParentID)
                {
                    thtml = thtml + "<li rel=\"" + dr["DepartmentsClassID"].ToString() + "\">" + dr["dClassName"].ToString() + "</li>";
                }
            }
            if (sParentID > 0)
            {
                return (thtml.Trim() != "") ? "<ul>" + thtml + "</ul>" : "";
            }
            else
            {
                return thtml;
            }
        }
        public static string GetDepartmentsClassInfoToHTML_Loop_c(DataTable dt, int sParentID)
        {
            string thtml = "";
            string dthtml = "";
            
            foreach (DataRow dr in dt.Rows)
            {
                if (Convert.ToInt32(dr["dParentID"].ToString()) == sParentID)
                {
                    dthtml = "";
                    DataTable dtt = new DataTable();
                    try
                    {
                        dtt = tbStaffInfo.GetStaffInfoList(" DepartmentsClassID=" + dr["DepartmentsClassID"].ToString()).Tables[0];
                        if (dtt != null)
                        {
                            foreach (DataRow drr in dtt.Rows)
                            {
                                dthtml += "<li rel=\"s_" + drr["StaffID"].ToString() + "\" tag=\"dt\">" + drr["sName"].ToString() + "</li>";
                            }
                        }
                        dthtml = (dthtml.Trim() != "") ? "<ul>" + dthtml + "</ul>" : "";
                    }
                    finally
                    {
                        dtt.Clear();
                    }
                    thtml = thtml + "<li rel=\"" + dr["DepartmentsClassID"].ToString() + "\" tag=\"root\">" + dr["dClassName"].ToString() + dthtml+  GetDepartmentsClassInfoToHTML_Loop_c(dt, Convert.ToInt32(dr["DepartmentsClassID"].ToString())) + "</li>";
                }
            }
            if (sParentID > 0)
            {
                return (thtml.Trim() != "") ? "<ul>" + thtml + "</ul>" : "";
            }
            else
            {
                return thtml;
            }
        }
        #endregion
        #endregion
        #region PriceClass

        public static DataTable getPriceClassList(int ParentID)
        {
            return DatabaseProvider.GetInstance().getPriceClassList(ParentID);
        }

        public static DataTable GetPriceDetails(int PriceClassID)
        {
            return DatabaseProvider.GetInstance().GetPriceDetails(PriceClassID);
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool ExistsPriceClassInfo(string pClassName, int pParentID)
        {
            return DatabaseProvider.GetInstance().ExistsPriceClassInfo(pClassName, pParentID);
        }
        /// <summary>
        /// 是否有子节点,即是否为叶节点
        /// </summary>
        /// <param name="PriceClassID"></param>
        /// <returns></returns>
        public static bool ExistsPriceClassChild(int PriceClassID)
        { 
            return DatabaseProvider.GetInstance().ExistsPriceClassChild( PriceClassID);
        }
        public static int AddPriceClassInfo(PriceClassInfo model)
        {
            return DatabaseProvider.GetInstance().AddPriceClassInfo(model);
        }
        public static int UpdatePriceClassInfo(PriceClassInfo model)
        {
            return DatabaseProvider.GetInstance().UpdatePriceClassInfo(model);
        }
        public static int DeletePriceClassInfo(int PriceClassID)
        {
            return DatabaseProvider.GetInstance().DeletePriceClassInfo(PriceClassID);
        }
        public static PriceClassInfo GetPriceClassInfoModel(int PriceClassID)
        {
            return DatabaseProvider.GetInstance().GetPriceClassInfoModel(PriceClassID);
        }
        public static PriceClassInfo GetPriceClassInfoModel(string pClassName)
        {
            return DatabaseProvider.GetInstance().GetPriceClassInfoModel(pClassName);
        }
        public static DataSet GetPriceClassInfoList(string strWhere)
        {
            return DatabaseProvider.GetInstance().GetPriceClassInfoList(strWhere);
        }
        public static DataSet GetPriceClassInfoList(int Top, string strWhere, string filedOrder)
        {
            return DatabaseProvider.GetInstance().GetPriceClassInfoList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 取指定价格分类下的所有编号列表
        /// </summary>
        /// <param name="PriceClassID"></param>
        /// <returns></returns>
        public static string GetPriceClassChildStr(int PriceClassID)
        {
            return Utils.ReSQLSetTxt(DatabaseProvider.GetInstance().GetDataFieldStr("tbPriceClassInfo", "PriceClassID", "pParentID", PriceClassID, ""));
        }
        #region Json
        /// <summary>
        /// Json
        /// </summary>
        /// <returns></returns>
        public static string GetPriceClassInfoToJson()
        {
            string json = "";
            DataTable dt = GetPriceClassInfoList("").Tables[0];
            json = GetPriceClassInfoToJson_Loop(dt, 0);
            return Utils.ReSQLSetTxt(json);
        }
        public static string GetPriceClassInfoToJson(int pid)
        {
            string json = "";
            DataTable dt = GetPriceClassInfoList(" pParentID="+pid).Tables[0];
            json = GetPriceClassInfoToJson_Loop_b(dt, pid);
            return Utils.ReSQLSetTxt(json);
        }
        public static string GetPriceClassInfoToJson(int pid, bool getdata)
        {
            string json = "";
            DataTable dt = GetPriceClassInfoList(" pParentID=" + pid).Tables[0];
            json = GetPriceClassInfoToJson_Loop_b(dt, pid, getdata);
            return Utils.ReSQLSetTxt(json);
        }
        public static string GetPriceClassInfoToJson_Loop(DataTable dt, int sParentID)
        {
            string json = "";
            foreach (DataRow dr in dt.Rows)
            {
                if (Convert.ToInt32(dr["pParentID"].ToString()) == sParentID)
                {
                    json = json + "{\"data\":\"" + dr["pClassName"].ToString() + "\",\"rel\":\"root\",\"state\":\"closed\",\"attr\":{\"id\":\"t_" + dr["PriceClassID"].ToString() + "\",\"value\":\"" + dr["PriceClassID"].ToString() + "\",\"pid\":\"" + sParentID + "\"},\"children\":[" + GetPriceClassInfoToJson_Loop(dt, Convert.ToInt32(dr["PriceClassID"].ToString())) + "]},";
                }
            }
            return Utils.ReSQLSetTxt(json);
        }
        public static string GetPriceClassInfoToJson_Loop_b(DataTable dt, int sParentID)
        {
            string json = "";
            foreach (DataRow dr in dt.Rows)
            {
                if (Convert.ToInt32(dr["pParentID"].ToString()) == sParentID)
                {
                    json = json + "{\"data\":\"" + dr["pClassName"].ToString() + "\",\"state\":\"closed\",\"attr\":{\"id\":\"t_" + dr["PriceClassID"].ToString() + "\",\"value\":\"" + dr["PriceClassID"].ToString() + "\",\"pid\":\"" + sParentID + "\"}},";
                }
            }
            return Utils.ReSQLSetTxt(json);
        }
        public static string GetPriceClassInfoToJson_Loop_b(DataTable dt, int sParentID, bool getdata)
        {
            string json = "";
            foreach (DataRow dr in dt.Rows)
            {
                if (Convert.ToInt32(dr["pParentID"].ToString()) == sParentID)
                {
                    json = json + "{\"data\":\"" + dr["pClassName"].ToString() + "\",\"state\":\"closed\",\"attr\":{\"id\":\"t_" + dr["PriceClassID"].ToString() + "\",\"rel\":\"root\",\"value\":\"" + dr["PriceClassID"].ToString() + "\",\"pid\":\"" + sParentID + "\"}},";
                   
                }
            }
            if (getdata)
            {
                DataTable dtt = new DataTable();
                try
                {
                    dtt = tbPriceClassDefaultPriceInfo.GetPriceClassDefaultPriceInfoList(" PriceClassID=" + sParentID).Tables[0];
                    if (dtt != null)
                    {
                        foreach (DataRow drr in dtt.Rows)
                        {
                            json = json + "{\"data\":\"" + drr["ProductName"].ToString() + "\",\"state\":\"closed\",\"attr\":{\"id\":\"d_" + drr["ProductsID"].ToString() + "\",\"rel\":\"dt\",\"value\":\"" + drr["ProductsID"].ToString() + "\"}},";
                        }
                    }
                }
                finally
                {
                    dtt.Clear();
                }
            }
            return Utils.ReSQLSetTxt(json);
        }
        #endregion

        #region HTML
        /// <summary>
        /// HTML
        /// </summary>
        /// <returns></returns>
        public static string GetPriceClassInfoToHTML()
        {
            string thtml = "";
            DataTable dt = GetPriceClassInfoList("").Tables[0];
            thtml = GetPriceClassInfoToHTML_Loop(dt, 0);
            return thtml;
        }
        public static string GetPriceClassInfoToHTML(int pid)
        {
            string thtml = "";
            DataTable dt = GetPriceClassInfoList(" pParentID=" + pid).Tables[0];
            thtml = GetPriceClassInfoToHTML_Loop_b(dt, pid);
            return thtml;
        }
        public static string GetPriceClassInfoToHTML_Loop(DataTable dt, int sParentID)
        {
            string thtml = "";
            foreach (DataRow dr in dt.Rows)
            {
                if (Convert.ToInt32(dr["pParentID"].ToString()) == sParentID)
                {
                    thtml = thtml + "<li rel=\"" + dr["PriceClassID"].ToString() + "\">" + dr["pClassName"].ToString() + GetPriceClassInfoToHTML_Loop(dt, Convert.ToInt32(dr["PriceClassID"].ToString())) + "</li>";
                }
            }
            if (sParentID > 0)
            {
                return (thtml.Trim() != "") ? "<ul>" + thtml + "</ul>" : "";
            }
            else {
                return thtml;
            }
        }
        public static string GetPriceClassInfoToHTML_Loop_b(DataTable dt, int sParentID)
        {
            string thtml = "";
            foreach (DataRow dr in dt.Rows)
            {
                if (Convert.ToInt32(dr["pParentID"].ToString()) == sParentID)
                {
                    thtml = thtml + "<li rel=\"" + dr["PriceClassID"].ToString() + "\">" + dr["pClassName"].ToString() + "</li>";
                }
            }
            if (sParentID > 0)
            {
                return (thtml.Trim() != "") ? "<ul>" + thtml + "</ul>" : "";
            }
            else
            {
                return thtml;
            }
        }
        #endregion
        #endregion
        #region ProductClass
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool ExistsProductClassInfo(string pClassName, int pParentID)
        {
            return DatabaseProvider.GetInstance().ExistsProductClassInfo(pClassName, pParentID);
        }
        /// <summary>
        /// 是否有子节点,即是否为叶节点
        /// </summary>
        /// <param name="ProductClassID"></param>
        /// <returns></returns>
        public static bool ExistsProductClassChild(int ProductClassID)
        {
            return DatabaseProvider.GetInstance().ExistsProductClassChild(ProductClassID);
        }
        public static int AddProductClassInfo(ProductClassInfo model)
        {
            return DatabaseProvider.GetInstance().AddProductClassInfo(model);
        }
        public static int UpdateProductClassInfo(ProductClassInfo model)
        {
            return DatabaseProvider.GetInstance().UpdateProductClassInfo(model);
        }
        public static int DeleteProductClassInfo(int ProductClassID)
        {
            return DatabaseProvider.GetInstance().DeleteProductClassInfo(ProductClassID);
        }
        public static ProductClassInfo GetProductClassInfoModel(int ProductClassID)
        {
            return DatabaseProvider.GetInstance().GetProductClassInfoModel(ProductClassID);
        }
        public static ProductClassInfo GetProductClassInfoModel(string pClassName)
        {
            return DatabaseProvider.GetInstance().GetProductClassInfoModel(pClassName);
        }
        public static DataSet GetProductClassInfoList(string strWhere)
        {
            return DatabaseProvider.GetInstance().GetProductClassInfoList(strWhere);
        }
        public static DataSet GetProductClassInfoList(int Top, string strWhere, string filedOrder)
        {
            return DatabaseProvider.GetInstance().GetProductClassInfoList(Top, strWhere, filedOrder);
        }
        public static DataTable getProductsClassList(int ParentID)
        {
            return DatabaseProvider.GetInstance().getProductsClassList(ParentID);
        }

        public static DataSet GetStorageClassInfoList(string strWhere)
        {
            return DatabaseProvider.GetInstance().GetStorageClassInfoList(strWhere);
        }

		/// <summary>
		/// 取指定产品分类下的所有编号列表
		/// </summary>
		/// <param name="ProductClassID"></param>
		/// <returns></returns>
        public static string GetProductClassChildStr(int ProductClassID)
        {
            return Utils.ReSQLSetTxt(DatabaseProvider.GetInstance().GetDataFieldStr("tbProductClassInfo", "ProductClassID", "pParentID", ProductClassID, ""));
        }

		/// <summary>
		/// Gets the product class parent string.
		/// </summary>
		/// <returns>The product class parent string.</returns>
		/// <param name="ProductClassID">Product class I.</param>
		public static string GetProductClassParentStr(int ProductClassID){
			return Utils.ReSQLSetTxt(DatabaseProvider.GetInstance().GetDataFieldStr("tbProductClassInfo", "pParentID", "ProductClassID", ProductClassID, ""));
		}

        #region Json
        /// <summary>
        /// Gets the product class info to json.
        /// </summary>
        /// <returns>The product class info to json.</returns>
        public static string GetProductClassInfoToJson()
        {
            string json = "";
            DataTable dt = GetProductClassInfoList("").Tables[0];
            json = GetProductClassInfoToJson_Loop(dt, 0);
            return Utils.ReSQLSetTxt(json);
        }
		/// <summary>
		/// Gets the product class info to json.
		/// </summary>
		/// <returns>The product class info to json.</returns>
		/// <param name="pid">Pid.</param>
		public static string GetProductClassInfoToJson(int pid)
        {
            string json = "";
            DataTable dt = GetProductClassInfoList(" pParentID="+pid).Tables[0];
			json = GetProductClassInfoToJson_Loop_b(dt, pid);
            return Utils.ReSQLSetTxt(json);
        }
		/// <summary>
		/// Gets the product class info to json.
		/// </summary>
		/// <returns>The product class info to json.</returns>
		/// <param name="pid">Pid.</param>
		/// <param name="getdata">If set to <c>true</c> getdata.</param>
		public static string GetProductClassInfoToJson(int pid, bool getdata,int orderType = 0)
        {
            string json = "";
            DataTable dt = GetProductClassInfoList(" pParentID=" + pid).Tables[0];
			json = GetProductClassInfoToJson_Loop_b(dt, pid, getdata,orderType);
            return Utils.ReSQLSetTxt(json);
        }
		/// <summary>
		/// Gets the product class info to json_ loop.
		/// </summary>
		/// <returns>The product class info to json_ loop.</returns>
		/// <param name="dt">Dt.</param>
		/// <param name="sParentID">S parent I.</param>
        public static string GetProductClassInfoToJson_Loop(DataTable dt, int sParentID)
        {
            string json = "";
            foreach (DataRow dr in dt.Rows)
            {
                if (Convert.ToInt32(dr["pParentID"].ToString()) == sParentID)
                {
                    json = json + "{\"data\":\"" + dr["pClassName"].ToString() + "\",\"state\":\"closed\",\"attr\":{\"id\":\"t_" + dr["ProductClassID"].ToString() + "\",\"value\":\"" + dr["ProductClassID"].ToString() + "\",\"pid\":\"" + sParentID + "\"},\"children\":[" + GetProductClassInfoToJson_Loop(dt, Convert.ToInt32(dr["ProductClassID"].ToString())) + "]},";
                }
            }
            return Utils.ReSQLSetTxt(json);
        }
		/// <summary>
		/// Gets the product class info to json_ loop_b.
		/// </summary>
		/// <returns>The product class info to json_ loop_b.</returns>
		/// <param name="dt">Dt.</param>
		/// <param name="sParentID">S parent I.</param>
		public static string GetProductClassInfoToJson_Loop_b(DataTable dt, int sParentID)
        {
            string json = "";
            foreach (DataRow dr in dt.Rows)
            {
                if (Convert.ToInt32(dr["pParentID"].ToString()) == sParentID)
                {
                    json = json + "{\"data\":\"" + dr["pClassName"].ToString() + "\",\"state\":\"closed\",\"attr\":{\"id\":\"t_" + dr["ProductClassID"].ToString() + "\",\"value\":\"" + dr["ProductClassID"].ToString() + "\",\"pid\":\"" + sParentID + "\"}},";
                }
            }
            return Utils.ReSQLSetTxt(json);
        }
		public static string GetProductClassInfoToJson_Loop_b(DataTable dt, int sParentID, bool getdata,int orderType = 0)
        {
            string json = "";
            foreach (DataRow dr in dt.Rows)
            {
                if (Convert.ToInt32(dr["pParentID"].ToString()) == sParentID)
                {
                    json = json + "{\"data\":\"" + dr["pClassName"].ToString() + "\",\"state\":\"closed\",\"attr\":{\"id\":\"t_" + dr["ProductClassID"].ToString() + "\",\"rel\":\"root\",\"value\":\"" + dr["ProductClassID"].ToString() + "\",\"pid\":\"" + sParentID + "\"}},";
                    
                }
            }
            if (getdata)
            {
                DataTable dtt = new DataTable();
                try
                {
					string _sql = "";
					if(orderType>0){
                        /*
						_sql = " and ProductsID in(select oop.ProductsID from ("+
								" select op.ProductsID,(SUM(BStorage)+SUM(pStorage)+SUM(pStorageIn)-SUM(pStorageOut)) as oQ from ("+
								" select ProductsStorageID,StorageID,ProductsID,pStorage,pStorageIn,pStorageOut,"+
								" isnull((select pQuantity from tbProductsStorageLogInfo where  pType=-1 and pState=0 and StorageID=tbProductsStorageInfo.StorageID and ProductsID=tbProductsStorageInfo.ProductsID),0) as BStorage from tbProductsStorageInfo where ProductsStorageID in("+
								" select MAX(ProductsStorageID) ProductsStorageID from tbProductsStorageInfo group by StorageID,ProductsID)) as op group by op.ProductsID) as oop where oQ<>0)";
                        */
                         _sql = " and pq.pQuantity<>0";
                    }

                    dtt = tbProductsInfo.GetProductsInfoListAndQuantity(" p.ProductClassID=" + sParentID + " and p.pState!=1 " + _sql).Tables[0];
					//dtt = tbProductsInfo.GetProductsInfoList(" ProductClassID=" + sParentID + " and pState!=1 "+_sql).Tables[0];

					if (dtt != null)
                    {
                        foreach (DataRow drr in dtt.Rows)
                        {
                            json = json + "{\"data\":\"" + drr["pName"].ToString() + "\",\"state\":\"closed\",\"attr\":{\"id\":\"d_" + drr["ProductsID"].ToString() + "\",\"rel\":\"dt\",\"value\":\"" + drr["ProductsID"].ToString() + "\"}},";
                        }
                    }
                }
                finally
                {
                    dtt.Clear();
                }
            }
            return Utils.ReSQLSetTxt(json);
        }

        public static DataTable GetProductClassDetails(int ProductClassID)
        {
            return DatabaseProvider.GetInstance().GetProductClassDetails(ProductClassID);
        }
        public static DataTable GetProductClassInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
        {
            return DatabaseProvider.GetInstance().GetProductClassInfoList(PageSize, PageIndex, strWhere, out pagetotal, OrderType, showFName);
        }
        #endregion

        #region HTML
        /// <summary>
        /// HTML
        /// </summary>
        /// <returns></returns>
        public static string GetProductClassInfoToHTML()
        {
            string thtml = "";
            DataTable dt = GetProductClassInfoList("").Tables[0];
            thtml = GetProductClassInfoToHTML_Loop(dt, 0);
            return thtml;
        }
        public static string GetProductClassInfoToHTML(int pid)
        {
            string thtml = "";
            DataTable dt = GetProductClassInfoList(" pParentID=" + pid).Tables[0];
            thtml = GetProductClassInfoToHTML_Loop_b(dt, pid);
            return thtml;
        }
        public static string GetProductClassInfoToHTML_Loop(DataTable dt, int sParentID)
        {
            string thtml = "";
            foreach (DataRow dr in dt.Rows)
            {
                if (Convert.ToInt32(dr["pParentID"].ToString()) == sParentID)
                {
                    thtml = thtml + "<li rel=\"" + dr["ProductClassID"].ToString() + "\">" + dr["pClassName"].ToString() + GetProductClassInfoToHTML_Loop(dt, Convert.ToInt32(dr["ProductClassID"].ToString())) + "</li>";
                }
            }
            if (sParentID > 0)
            {
                return (thtml.Trim() != "") ? "<ul>" + thtml + "</ul>" : "";
            }
            else
            {
                return thtml;
            }
        }
        public static string GetProductClassInfoToHTML_Loop_b(DataTable dt, int sParentID)
        {
            string thtml = "";
            foreach (DataRow dr in dt.Rows)
            {
                if (Convert.ToInt32(dr["pParentID"].ToString()) == sParentID)
                {
                    thtml = thtml + "<li rel=\"" + dr["ProductClassID"].ToString() + "\">" + dr["pClassName"].ToString() +  "</li>";
                }
            }
            if (sParentID > 0)
            {
                return (thtml.Trim() != "") ? "<ul>" + thtml + "</ul>" : "";
            }
            else
            {
                return thtml;
            }
        }
        #endregion
        #endregion

        #region StorageClass
        public static string GetStorageClassInfoToHTML()
        {
            string thtml = "";
            DataTable dt = GetStorageClassInfoList("").Tables[0];
            thtml = GetStorageClassInfoToHTML_Loop(dt, 0);
            return thtml;
        }
        public static string GetStorageClassInfoToHTML_Loop(DataTable dt, int sParentID)
        {
            string thtml = "";
            foreach (DataRow dr in dt.Rows)
            {
                if (Convert.ToInt32(dr["sParentID"].ToString()) == sParentID)
                {
                    thtml = thtml + "<li rel=\"" + dr["StorageClassID"].ToString() + "\">" + dr["sClassName"].ToString() + GetStorageClassInfoToHTML_Loop(dt, Convert.ToInt32(dr["StorageClassID"].ToString())) + "</li>";
                }
            }
            if (sParentID > 0)
            {
                return (thtml.Trim() != "") ? "<ul>" + thtml + "</ul>" : "";
            }
            else
            {
                return thtml;
            }
        }
        #endregion

        #region  FeesSubjectClass
        public static int updateCertificateToFeessubjects(string certificateID, int feesubjectID, int lastFeeID)
        {
            return DatabaseProvider.GetInstance().updateCertificateToFeessubjects(certificateID, feesubjectID, lastFeeID);
        }
        public static DataTable getCertificateDate(int fid)
        {
            return DatabaseProvider.GetInstance().getCertificateDate(fid);
        }
        public static int getFeeState(int fid)
        {
            return DatabaseProvider.GetInstance().getFeeState(fid);
        }

        public static DataTable getFeesSubjectClassList(int ParentID)
        {
            return DatabaseProvider.GetInstance().getFeesSubjectClassList(ParentID);
        }
        public static DataTable GetFeesSubjectDetails(int CustomersClassID)
        {
            return DatabaseProvider.GetInstance().GetFeesSubjectDetails(CustomersClassID);
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool ExistsFeesSubjectClassInfo(string cClassName, int cParentID)
        {
            return DatabaseProvider.GetInstance().ExistsFeesSubjectClassInfo(cClassName, cParentID);
        }
        /// <summary>
        /// 是否有子节点,即是否为叶节点
        /// </summary>
        /// <param name="FeesSubjectClassID"></param>
        /// <returns></returns>
        public static bool ExistsFeesSubjectClassChild(int FeesSubjectClassID)
        {
            return DatabaseProvider.GetInstance().ExistsFeesSubjectClassChild(FeesSubjectClassID);
        }
        public static bool ExistsFeesSubjectClassInfoByCode(string cCode)
        {
            return DatabaseProvider.GetInstance().ExistsFeesSubjectClassInfoByCode(cCode);
        }
        public static int AddFeesSubjectClassInfo(FeesSubjectClassInfo model)
        {
            return DatabaseProvider.GetInstance().AddFeesSubjectClassInfo(model);
        }
        public static int UpdateFeesSubjectClassInfo(FeesSubjectClassInfo model)
        {
            return DatabaseProvider.GetInstance().UpdateFeesSubjectClassInfo(model);
        }
        public static int DeleteFeesSubjectClassInfo(int FeesSubjectClassID)
        {
            return DatabaseProvider.GetInstance().DeleteFeesSubjectClassInfo(FeesSubjectClassID);
        }
        public static FeesSubjectClassInfo GetFeesSubjectClassInfoModel(int FeesSubjectClassID)
        {
            return DatabaseProvider.GetInstance().GetFeesSubjectClassInfoModel(FeesSubjectClassID);
        }
        public static DataSet GetFeesSubjectClassInfoList(string strWhere)
        {
            return DatabaseProvider.GetInstance().GetFeesSubjectClassInfoList(strWhere);
        }
        public static DataSet GetFeesSubjectClassInfoList(int Top, string strWhere, string filedOrder)
        {
            return DatabaseProvider.GetInstance().GetFeesSubjectClassInfoList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 取指定科目分类下的所有编号列表
        /// </summary>
        /// <param name="FeesSubjectClassID"></param>
        /// <returns></returns>
        public static string GetFeesSubjectClassChildStr(int FeesSubjectClassID)
        {
            return Utils.ReSQLSetTxt(DatabaseProvider.GetInstance().GetDataFieldStr("tbFeesSubjectClassInfo", "FeesSubjectClassID", "cParentID", FeesSubjectClassID, ""));
        }
        public static string GetFeesSubjectClassParentStr(int FeesSubjectClassID)
        {
            return DatabaseProvider.GetInstance().GetDataFieldStr("tbFeesSubjectClassInfo", "cClassName", "cParentID", "FeesSubjectClassID", FeesSubjectClassID, "");
        }
        //public static string GetFeesSubjectClassParentStr(int FeesSubjectClassID,string sStr)
        //{
        //    return DatabaseProvider.GetInstance().GetDataFieldStr("tbFeesSubjectClassInfo", "cClassName", "cParentID", "FeesSubjectClassID", FeesSubjectClassID, "", sStr);
        //}
        public static string GetFeesSubjectClassParentStr(int FeesSubjectClassID, string sStr)
        {
            string reStr = DatabaseProvider.GetInstance().GetDataFieldStr("tbFeesSubjectClassInfo", "cClassName", "cParentID", "FeesSubjectClassID", FeesSubjectClassID, "", sStr);
            if (reStr.Trim() != "")
            {
                return (reStr.Substring(0, sStr.Length) == sStr) ? reStr.Substring(sStr.Length) : reStr;
            }
            else
            {
                return "";
            }
        }

        #region Json
        /// <summary>
        /// Json
        /// </summary>
        /// <returns></returns>
        public static string GetFeesSubjectClassInfoToJson()
        {
            string json = "";
            DataTable dt = GetFeesSubjectClassInfoList(" 1=1 order by cCode asc").Tables[0];
            json = GetFeesSubjectClassInfoToJson_Loop(dt, 0);
            return Utils.ReSQLSetTxt(json);
        }
        public static string GetFeesSubjectClassInfoToJson(int pid)
        {
            string json = "";
            //pid = pid == -1 ? 0 : pid;
            DataTable dt = GetFeesSubjectClassInfoList(" cParentID=" + pid + " order by cCode asc").Tables[0];
            json = GetFeesSubjectClassInfoToJson_Loop_b(dt, pid);
            return Utils.ReSQLSetTxt(json);
        }
        public static string GetFeesSubjectClassInfoToJson(int pid, bool getdata)
        {
            string json = "";
            //pid = pid == -1 ? 0 : pid;
            DataTable dt = GetFeesSubjectClassInfoList(" cParentID=" + pid + " order by cCode asc").Tables[0];
            json = GetFeesSubjectClassInfoToJson_Loop_b(dt, pid, getdata);
            return Utils.ReSQLSetTxt(json);
        }
        public static string GetFeesSubjectClassInfoToJson(int pid, bool getdata, bool isAll)
        {
            string json = "";
            DataTable dt = GetFeesSubjectClassInfoList((pid != -1 ? " cParentID=" + pid : " 1=1 ") + " order by cCode asc").Tables[0];
            json = GetFeesSubjectClassInfoToJson_Loop_c(dt, pid != -1 ? pid : 0, getdata);
            return Utils.ReSQLSetTxt(json);
        }
        public static string GetFeesSubjectClassInfoToJson_Loop(DataTable dt, int sParentID)
        {
            string json = "";
            foreach (DataRow dr in dt.Rows)
            {
                if (Convert.ToInt32(dr["cParentID"].ToString()) == sParentID)
                {
                    json = json + "{\"data\":\"" + dr["cClassName"].ToString() + "\",\"state\":\"closed\",\"attr\":{\"id\":\"t_" + dr["FeesSubjectClassID"].ToString() + "\",\"value\":\"" + dr["FeesSubjectClassID"].ToString() + "\",\"pid\":\"" + sParentID + "\",\"cDirection\":\"" + dr["cDirection"].ToString() + "\",\"cCode\":\"" + dr["cCode"].ToString() + "\",\"cType\":\"" + dr["cType"].ToString() + "\"},\"children\":[" + GetFeesSubjectClassInfoToJson_Loop(dt, Convert.ToInt32(dr["FeesSubjectClassID"].ToString())) + "]},";
                }
            }
            return Utils.ReSQLSetTxt(json);
        }
        public static string GetFeesSubjectClassInfoToJson_Loop_b(DataTable dt, int sParentID)
        {
            string json = "";
            foreach (DataRow dr in dt.Rows)
            {
                if (Convert.ToInt32(dr["cParentID"].ToString()) == sParentID)
                {
                    json = json + "{\"data\":\"" + dr["cClassName"].ToString() + "\",\"state\":\"closed\",\"attr\":{\"id\":\"t_" + dr["FeesSubjectClassID"].ToString() + "\",\"value\":\"" + dr["FeesSubjectClassID"].ToString() + "\",\"pid\":\"" + sParentID + "\",\"cDirection\":\"" + dr["cDirection"].ToString() + "\",\"cCode\":\"" + dr["cCode"].ToString() + "\",\"cType\":\"" + dr["cType"].ToString() + "\"}},";
                }
            }
            return Utils.ReSQLSetTxt(json);
        }
        public static string GetFeesSubjectClassInfoToJson_Loop_b(DataTable dt, int sParentID, bool getdata)
        {
            string json = "";
            foreach (DataRow dr in dt.Rows)
            {
                if (Convert.ToInt32(dr["cParentID"].ToString()) == sParentID)
                {
                    json = json + "{\"data\":\"" + dr["cClassName"].ToString() + "\",\"state\":\"closed\",\"attr\":{\"id\":\"t_" + dr["FeesSubjectClassID"].ToString() + "\",\"rel\":\"root\",\"value\":\"" + dr["FeesSubjectClassID"].ToString() + "\",\"pid\":\"" + sParentID + "\",\"cDirection\":\"" + dr["cDirection"].ToString() + "\",\"cCode\":\"" + dr["cCode"].ToString() + "\",\"cType\":\"" + dr["cType"].ToString() + "\"}},";
                }
            }
            if (getdata)
            {
                DataTable dtt = new DataTable();
                try
                {
                    dtt = tbFeesSubjectInfo.GetFeesSubjectInfoList(" FeesSubjectClassID=" + sParentID).Tables[0];
                    if (dtt != null)
                    {
                        foreach (DataRow drr in dtt.Rows)
                        {
                            json = json + "{\"data\":\"" + drr["fName"].ToString() + "\",\"state\":\"closed\",\"attr\":{\"id\":\"d_" + drr["FeesSubjectID"].ToString() + "\",\"rel\":\"dt\",\"value\":\"" + drr["FeesSubjectID"].ToString() + "\"}},";
                        }
                    }
                }
                finally
                {
                    dtt.Clear();
                }
            }
            return Utils.ReSQLSetTxt(json);
        }
        public static string GetFeesSubjectClassInfoToJson_Loop_c(DataTable dt, int sParentID, bool getdata)
        {
            string json = "";
            foreach (DataRow dr in dt.Rows)
            {
                if (Convert.ToInt32(dr["cParentID"].ToString()) == sParentID)
                {
                    json = json + "{\"data\":\"" + dr["cClassName"].ToString() + "\",\"state\":\"closed\",\"attr\":{\"id\":\"t_" + dr["FeesSubjectClassID"].ToString() + "\",\"rel\":\"" + (ExistsFeesSubjectClassChild(Convert.ToInt32(dr["FeesSubjectClassID"].ToString())) ? "root" : "dt") + "\",\"value\":\"" + dr["FeesSubjectClassID"].ToString() + "\",\"pid\":\"" + sParentID + "\",\"cDirection\":\"" + dr["cDirection"].ToString() + "\",\"cCode\":\"" + dr["cCode"].ToString() + "\",\"cType\":\"" + dr["cType"].ToString() + "\"},\"children\":[" + GetFeesSubjectClassInfoToJson_Loop_c(dt, Convert.ToInt32(dr["FeesSubjectClassID"].ToString()), getdata) + "]},";
                }
            }
            if (getdata)
            {
                DataTable dtt = new DataTable();
                try
                {
                    dtt = tbFeesSubjectInfo.GetFeesSubjectInfoList(" FeesSubjectClassID=" + sParentID).Tables[0];
                    if (dtt != null)
                    {
                        foreach (DataRow drr in dtt.Rows)
                        {
                            json = json + "{\"data\":\"" + drr["fName"].ToString() + "\",\"state\":\"closed\",\"attr\":{\"id\":\"d_" + drr["FeesSubjectID"].ToString() + "\",\"rel\":\"dt\",\"value\":\"" + drr["FeesSubjectID"].ToString() + "\"}},";
                        }
                    }
                }
                finally
                {
                    dtt.Clear();
                }
            }
            return Utils.ReSQLSetTxt(json);
        }
        #endregion

        #region HTML
        /// <summary>
        /// HTML
        /// </summary>
        /// <returns></returns>
        public static string GetFeesSubjectClassInfoToHTML()
        {
            string thtml = "";
            DataTable dt = GetFeesSubjectClassInfoList(" 1=1 order by cCode asc").Tables[0];
            thtml = GetFeesSubjectClassInfoToHTML_Loop(dt, 0);
            return Utils.ReSQLSetTxt(thtml);
        }
        public static string GetFeesSubjectClassInfoToHTML(int pid)
        {
            string thtml = "";
            DataTable dt = GetFeesSubjectClassInfoList(" cParentID=" + pid + " order by cCode asc").Tables[0];
            thtml = GetFeesSubjectClassInfoToHTML_Loop_b(dt, pid);
            return Utils.ReSQLSetTxt(thtml);
        }
        public static string GetFeesSubjectClassInfoToHTML_Loop(DataTable dt, int sParentID)
        {
            string thtml = "";
            foreach (DataRow dr in dt.Rows)
            {
                if (Convert.ToInt32(dr["cParentID"].ToString()) == sParentID)
                {
                    thtml = thtml + "<li rel=\"" + dr["FeesSubjectClassID"].ToString() + "\">" + dr["cClassName"].ToString() + GetFeesSubjectClassInfoToHTML_Loop(dt, Convert.ToInt32(dr["FeesSubjectClassID"].ToString())) + "</li>";
                }
            }
            if (sParentID > 0)
            {
                return (thtml.Trim() != "") ? "<ul>" + thtml + "</ul>" : "";
            }
            else
            {
                return thtml;
            }
        }
        public static string GetFeesSubjectClassInfoToHTML_Loop_b(DataTable dt, int sParentID)
        {
            string thtml = "";
            foreach (DataRow dr in dt.Rows)
            {
                if (Convert.ToInt32(dr["cParentID"].ToString()) == sParentID)
                {
                    thtml = thtml + "<li rel=\"" + dr["FeesSubjectClassID"].ToString() + "\">" + dr["cClassName"].ToString() + "</li>";
                }
            }
            if (sParentID > 0)
            {
                return "<ul>" + thtml + "</ul>";
            }
            else
            {
                return thtml;
            }
        }
        #endregion
        /// <summary>
        /// 获取所有父列表
        /// </summary>
        public static string GetFeesSubjectClassPaterStr(int FeesSubjectClassID)
        {
            return UsersUtils.GetDataFieldStr("tbFeesSubjectClassInfo", "cClassName", "cParentID", "FeesSubjectClassID", FeesSubjectClassID, "");
        }

        public static string GetProductClassPaterStr(int ProductClassID)
        {
            return UsersUtils.GetDataFieldStr("tbProductClassInfo", "pClassName", "pParentID", "ProductClassID", ProductClassID, "");
        }
        /// <summary>
        /// 单据步骤为DataTable
        /// </summary>
        public static DataTable GetFeesSubjectClassType()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("ID", typeof(string));
            dt.Columns.Add("Other", typeof(string));

            foreach (FeesSubjectClassTypes.Rewrite _FeesSubjectClassType in FeesSubjectClassTypes.GetFeesSubjectClassTypes().FeesSubjectClassType)
            {
                DataRow dr = dt.NewRow();
                dr["Name"] = _FeesSubjectClassType.Name;
                dr["ID"] = _FeesSubjectClassType.ID;
                dr["Other"] = _FeesSubjectClassType.Other;

                dt.Rows.Add(dr);
            }
            dt.AcceptChanges();
            return dt;
        }
        /// <summary>
        /// 单据步骤
        /// </summary>
        public class FeesSubjectClassTypes
        {
            private static object lockHelper = new object();
            private static volatile FeesSubjectClassTypes instance = null;
            string Files = HttpContext.Current.Server.MapPath(BaseConfigs.GetSysPath + "config/feessubjectclasstype.config");
            private System.Collections.ArrayList _FeesSubjectClassTypes;
            public System.Collections.ArrayList FeesSubjectClassType
            {
                get
                {
                    return _FeesSubjectClassTypes;
                }
                set
                {
                    _FeesSubjectClassTypes = value;
                }
            }
            private FeesSubjectClassTypes()
            {
                FeesSubjectClassType = new ArrayList();
                XmlDocument xml = new XmlDocument();
                xml.Load(Files);
                try
                {
                    XmlNode root = xml.SelectSingleNode("//FeesSubjectClassTypes");
                    foreach (XmlNode n in root.ChildNodes)
                    {
                        if (n.NodeType != XmlNodeType.Comment && n.Name.ToLower() == "feessubjectclasstype")
                        {
                            XmlAttribute _Name = n.Attributes["name"];//类型
                            XmlAttribute _ID = n.Attributes["id"];//系统识别编号

                            if (_Name != null && _ID != null)
                            {
                                FeesSubjectClassType.Add(new Rewrite(_Name.Value, _ID.Value, n.InnerText));
                            }
                        }
                    }
                }
                finally
                {
                    xml = null;
                }
            }
            public static FeesSubjectClassTypes GetFeesSubjectClassTypes()
            {
                if (instance == null)
                {
                    lock (lockHelper)
                    {
                        if (instance == null)
                        {
                            instance = new FeesSubjectClassTypes();
                        }
                    }
                }
                return instance;

            }

            public static void SetInstance(FeesSubjectClassTypes anInstance)
            {
                if (anInstance != null)
                    instance = anInstance;
            }

            public static void SetInstance()
            {
                SetInstance(new FeesSubjectClassTypes());
            }
            public class Rewrite
            {
                #region 成员变量
                private string _Name;
                public string Name
                {
                    get
                    {
                        return _Name;
                    }
                    set
                    {
                        _Name = value;
                    }
                }
                private string _ID;
                public string ID
                {
                    get
                    {
                        return _ID;
                    }
                    set
                    {
                        _ID = value;
                    }
                }

                private string _Other;
                public string Other
                {
                    get
                    {
                        return _Other;
                    }
                    set
                    {
                        _Other = value;
                    }
                }
                #endregion
                #region 构造函数
                public Rewrite(string name, string id, string other)
                {
                    _Name = name;
                    _ID = id;
                    _Other = other;
                }
                #endregion
            }
        }

        #endregion

        #region SupplierClass
        public static DataTable getSupplierClassList(int ParentID)
        {
            return DatabaseProvider.GetInstance().getSupplierClassList(ParentID);
        }

        public static DataTable GetSupplierClassDetails(int SupplierClassID)
        {
            return DatabaseProvider.GetInstance().GetSupplierClassDetails(SupplierClassID);
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool ExistsSupplierClassInfo(string sClassName, int sParentID)
        {
            return DatabaseProvider.GetInstance().ExistsSupplierClassInfo(sClassName, sParentID);
        }
        /// <summary>
        /// 是否有子节点,即是否为叶节点
        /// </summary>
        /// <param name="SupplierClassID"></param>
        /// <returns></returns>
        public static bool ExistsSupplierClassChild(int SupplierClassID)
        { 
            return DatabaseProvider.GetInstance().ExistsSupplierClassChild( SupplierClassID);
        }
        public static int AddSupplierClassInfo(SupplierClassInfo model)
        {
            return DatabaseProvider.GetInstance().AddSupplierClassInfo(model);
        }
        public static int UpdateSupplierClassInfo(SupplierClassInfo model)
        {
            return DatabaseProvider.GetInstance().UpdateSupplierClassInfo(model);
        }
        public static int DeleteSupplierClassInfo(int SupplierClassID)
        {
            return DatabaseProvider.GetInstance().DeleteSupplierClassInfo(SupplierClassID);
        }
        public static SupplierClassInfo GetSupplierClassInfoModel(int SupplierClassID)
        {
            return DatabaseProvider.GetInstance().GetSupplierClassInfoModel(SupplierClassID);
        }
        public static DataSet GetSupplierClassInfoList(string strWhere)
        {
            return DatabaseProvider.GetInstance().GetSupplierClassInfoList(strWhere);
        }
        public static DataSet GetSupplierClassInfoList(int Top, string strWhere, string filedOrder)
        {
            return DatabaseProvider.GetInstance().GetSupplierClassInfoList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 取指定供应商分类下的所有编号列表
        /// </summary>
        /// <param name="SupplierClassID"></param>
        /// <returns></returns>
        public static string GetSupplierClassChildStr(int SupplierClassID)
        {
            return Utils.ReSQLSetTxt(DatabaseProvider.GetInstance().GetDataFieldStr("tbSupplierClassInfo", "SupplierClassID", "sParentID", SupplierClassID, ""));
        }
        #region Json
        /// <summary>
        /// Json
        /// </summary>
        /// <returns></returns>
        public static string GetSupplierClassInfoToJson()
        {
            string json = "";
            DataTable dt = GetSupplierClassInfoList("").Tables[0];
            json = GetSupplierClassInfoToJson_Loop(dt, 0);
            return Utils.ReSQLSetTxt(json);
        }
        public static string GetSupplierClassInfoToJson(int pid)
        {
            string json = "";
            DataTable dt = GetSupplierClassInfoList(" sParentID="+pid).Tables[0];
            json = GetSupplierClassInfoToJson_Loop_b(dt, pid);
            return Utils.ReSQLSetTxt(json);
        }
        public static string GetSupplierClassInfoToJson(int pid, bool getdata)
        {
            string json = "";
            DataTable dt = GetSupplierClassInfoList(" sParentID=" + pid).Tables[0];
            json = GetSupplierClassInfoToJson_Loop_b(dt, pid, getdata);
            return Utils.ReSQLSetTxt(json);
        }
        public static string GetSupplierClassInfoToJson(int pid, bool getdata,bool isAll)
        {
            string json = "";
            DataTable dt = GetSupplierClassInfoList(pid != -1 ? " sParentID=" + pid : "").Tables[0];
            json = GetSupplierClassInfoToJson_Loop_c(dt, pid != -1 ? pid : 0, getdata);
            if (getdata)
            {
                DataTable dtt = new DataTable();
                try
                {
                    dtt = tbSupplierInfo.GetSupplierInfoList(" SupplierClassID not in(select SupplierClassID from tbSupplierClassInfo ) and SupplierClassID<>0").Tables[0];
                    if (dtt != null)
                    {
                        foreach (DataRow drr in dtt.Rows)
                        {
                            json = json + ",{\"data\":\"" + drr["sName"].ToString() + "\",\"state\":\"closed\",\"attr\":{\"id\":\"d_" + drr["SupplierID"].ToString() + "\",\"rel\":\"dt\",\"value\":\"" + drr["SupplierID"].ToString() + "\",\"otype\":\"1\"}}";
                        }
                    }
                }
                finally
                {
                    dtt.Clear();
                }
            }
            return Utils.ReSQLSetTxt(json);
        }
        public static string GetSupplierClassInfoToJson_Loop(DataTable dt, int sParentID)
        {
            string json = "";
            foreach (DataRow dr in dt.Rows)
            {
                if (Convert.ToInt32(dr["sParentID"].ToString()) == sParentID)
                {
                    json = json + "{\"data\":\"" + dr["sClassName"].ToString() + "\",\"state\":\"closed\",\"attr\":{\"id\":\"t_" + dr["SupplierClassID"].ToString() + "\",\"value\":\"" + dr["SupplierClassID"].ToString() + "\",\"pid\":\"" + sParentID + "\"},\"children\":[" + GetSupplierClassInfoToJson_Loop(dt, Convert.ToInt32(dr["SupplierClassID"].ToString())) + "]},";
                }
            }
            return Utils.ReSQLSetTxt(json);
        }
        public static string GetSupplierClassInfoToJson_Loop_b(DataTable dt, int sParentID)
        {
            string json = "";
            foreach (DataRow dr in dt.Rows)
            {
                if (Convert.ToInt32(dr["sParentID"].ToString()) == sParentID)
                {
                    json = json + "{\"data\":\"" + dr["sClassName"].ToString() + "\",\"state\":\"closed\",\"attr\":{\"id\":\"t_" + dr["SupplierClassID"].ToString() + "\",\"value\":\"" + dr["SupplierClassID"].ToString() + "\",\"pid\":\"" + sParentID + "\"}},";
                }
            }
            return Utils.ReSQLSetTxt(json);
        }
        public static string GetSupplierClassInfoToJson_Loop_b(DataTable dt, int sParentID, bool getdata)
        {
            string json = "";
            foreach (DataRow dr in dt.Rows)
            {
                if (Convert.ToInt32(dr["sParentID"].ToString()) == sParentID)
                {
                    json = json + "{\"data\":\"" + dr["sClassName"].ToString() + "\",\"state\":\"closed\",\"attr\":{\"id\":\"t_" + dr["SupplierClassID"].ToString() + "\",\"rel\":\"root\",\"value\":\"" + dr["SupplierClassID"].ToString() + "\",\"pid\":\"" + sParentID + "\"}},";
                    
                }
            }
            if (getdata)
            {
                DataTable dtt = new DataTable();
                try
                {
                    dtt = tbSupplierInfo.GetSupplierInfoList(" SupplierClassID=" + sParentID).Tables[0];
                    if (dtt != null)
                    {
                        foreach (DataRow drr in dtt.Rows)
                        {
                            json = json + "{\"data\":\"" + drr["sName"].ToString() + "\",\"state\":\"closed\",\"attr\":{\"id\":\"d_" + drr["SupplierID"].ToString() + "\",\"rel\":\"dt\",\"value\":\"" + drr["SupplierID"].ToString() + "\"}},";
                        }
                    }
                }
                finally
                {
                    dtt.Clear();
                }
            }
            return Utils.ReSQLSetTxt(json);
        }
        public static string GetSupplierClassInfoToJson_Loop_c(DataTable dt, int sParentID, bool getdata)
        {
            string json = "";
            foreach (DataRow dr in dt.Rows)
            {
                if (Convert.ToInt32(dr["sParentID"].ToString()) == sParentID)
                {
                    json = json + "{\"data\":\"" + dr["sClassName"].ToString() + "\",\"state\":\"closed\",\"attr\":{\"id\":\"t_" + dr["SupplierClassID"].ToString() + "\",\"rel\":\"root\",\"value\":\"" + dr["SupplierClassID"].ToString() + "\",\"pid\":\"" + sParentID + "\"},\"children\":[" + GetSupplierClassInfoToJson_Loop_c(dt, Convert.ToInt32(dr["SupplierClassID"].ToString()), getdata) + "]},";

                }
            }
            if (getdata)
            {
                DataTable dtt = new DataTable();
                try
                {
                    dtt = tbSupplierInfo.GetSupplierInfoList(" SupplierClassID=" + sParentID).Tables[0];
                    if (dtt != null)
                    {
                        foreach (DataRow drr in dtt.Rows)
                        {
                            json = json + "{\"data\":\"" + drr["sName"].ToString() + "\",\"state\":\"closed\",\"attr\":{\"id\":\"d_" + drr["SupplierID"].ToString() + "\",\"rel\":\"dt\",\"value\":\"" + drr["SupplierID"].ToString() + "\",\"otype\":\"1\"}},";
                        }
                    }
                }
                finally
                {
                    dtt.Clear();
                }
            }
            return Utils.ReSQLSetTxt(json);
        }
        #endregion

        #region HTML
        /// <summary>
        /// HTML
        /// </summary>
        /// <returns></returns>
        public static string GetSupplierClassInfoToHTML()
        {
            string thtml = "";
            DataTable dt = GetSupplierClassInfoList("").Tables[0];
            thtml = GetSupplierClassInfoToHTML_Loop(dt, 0);
            return thtml;
        }
        public static string GetSupplierClassInfoAndDataToHTML()
        {
            string thtml = "";
            DataTable dt = GetSupplierClassInfoList("").Tables[0];
            thtml = GetSupplierClassInfoToHTML_Loop_c(dt, 0);
            return thtml;
        }
        public static string GetSupplierClassInfoToHTML(int pid)
        {
            string thtml = "";
            DataTable dt = GetSupplierClassInfoList(" sParentID=" + pid).Tables[0];
            thtml = GetSupplierClassInfoToHTML_Loop_b(dt, pid);
            return thtml;
        }
        public static string GetSupplierClassInfoToHTML_Loop(DataTable dt, int sParentID)
        {
            string thtml = "";
            foreach (DataRow dr in dt.Rows)
            {
                if (Convert.ToInt32(dr["sParentID"].ToString()) == sParentID)
                {
                    thtml = thtml + "<li rel=\"" + dr["SupplierClassID"].ToString() + "\">" + dr["sClassName"].ToString() + GetSupplierClassInfoToHTML_Loop(dt, Convert.ToInt32(dr["SupplierClassID"].ToString())) + "</li>";
                }
            }
            if (sParentID > 0)
            {
                return (thtml.Trim() != "") ? "<ul>" + thtml + "</ul>" : "";
            }
            else
            {
                return thtml;
            }
        }
        public static string GetSupplierClassInfoToHTML_Loop_b(DataTable dt, int sParentID)
        {
            string thtml = "";
            foreach (DataRow dr in dt.Rows)
            {
                if (Convert.ToInt32(dr["sParentID"].ToString()) == sParentID)
                {
                    thtml = thtml + "<li rel=\"" + dr["SupplierClassID"].ToString() + "\">" + dr["sClassName"].ToString() +  "</li>";
                }
            }
            if (sParentID > 0)
            {
                return (thtml.Trim() != "") ? "<ul>" + thtml + "</ul>" : "";
            }
            else
            {
                return thtml;
            }
        }
        public static string GetSupplierClassInfoToHTML_Loop_c(DataTable dt, int sParentID)
        {
            string thtml = "";
            string dthtml = "";

            foreach (DataRow dr in dt.Rows)
            {
                if (Convert.ToInt32(dr["sParentID"].ToString()) == sParentID)
                {
                    dthtml = "";
                    DataTable dtt = new DataTable();
                    try
                    {

                        dtt = tbSupplierInfo.GetSupplierInfoList(" SupplierClassID=" + dr["SupplierClassID"].ToString()).Tables[0];
                        if (dtt != null)
                        {
                            foreach (DataRow drr in dtt.Rows)
                            {
                                dthtml += "<li rel=\"s_" + drr["SupplierID"].ToString() + "\" tag=\"dt\">" + drr["sName"].ToString() + "</li>";
                            }
                        }
                        dthtml = (dthtml.Trim() != "") ? "<ul>" + dthtml + "</ul>" : "";
                    }
                    finally
                    {

                        dtt.Clear();
                    }
                    thtml = thtml + "<li rel=\"" + dr["SupplierClassID"].ToString() + "\" tag=\"root\">" + dr["sClassName"].ToString() + dthtml + GetSupplierClassInfoToHTML_Loop_c(dt, Convert.ToInt32(dr["SupplierClassID"].ToString())) + "</li>";
                }
            }
            if (sParentID > 0)
            {
                return (thtml.Trim() != "") ? "<ul>" + thtml + "</ul>" : "";
            }
            else
            {
                return thtml;
            }
        }
        #endregion
        #endregion

        #region Region
        #region Json
        /// <summary>
        /// Json
        /// </summary>
        /// <returns></returns>
        public static string GetRegionInfoToJson()
        {
            string json = "";
            DataTable dt = tbRegionInfo.GetRegionInfoList(" rState=0").Tables[0];
            json = GetRegionInfoToJson_Loop(dt, 0);
            return Utils.ReSQLSetTxt(json);
        }
        public static string GetRegionInfoToJson(int pid)
        {
            string json = "";
            DataTable dt = tbRegionInfo.GetRegionInfoList(" rState=0 and rUpID=" + pid).Tables[0];
            json = GetRegionInfoToJson_Loop_b(dt, pid);
            return Utils.ReSQLSetTxt(json);
        }
        public static string GetRegionInfoToJson_Loop(DataTable dt, int sParentID)
        {
            string json = "";
            foreach (DataRow dr in dt.Rows)
            {
                if (Convert.ToInt32(dr["rUpID"].ToString()) == sParentID)
                {
                    json = json + "{\"data\":\"" + dr["rName"].ToString() + "\",\"state\":\"closed\",\"attr\":{\"id\":\"t_" + dr["RegionID"].ToString() + "\",\"value\":\"" + dr["RegionID"].ToString() + "\",\"pid\":\"" + sParentID + "\"},\"children\":[" + GetRegionInfoToJson_Loop(dt, Convert.ToInt32(dr["RegionID"].ToString())) + "]},";
                }
            }
            return Utils.ReSQLSetTxt(json);
        }
        public static string GetRegionInfoToJson_Loop_b(DataTable dt, int sParentID)
        {
            string json = "";
            foreach (DataRow dr in dt.Rows)
            {
                if (Convert.ToInt32(dr["rUpID"].ToString()) == sParentID)
                {
                    json = json + "{\"data\":\"" + dr["rName"].ToString() + "\",\"state\":\"closed\",\"attr\":{\"id\":\"t_" + dr["RegionID"].ToString() + "\",\"value\":\"" + dr["RegionID"].ToString() + "\",\"pid\":\"" + sParentID + "\"}},";
                }
            }
            return Utils.ReSQLSetTxt(json);
        }
        #endregion

        #region HTML
        /// <summary>
        /// HTML
        /// </summary>
        /// <returns></returns>
        public static string GetRegionInfoToHTML()
        {
            string thtml = "";
            DataTable dt = tbRegionInfo.GetRegionInfoList(" rState=0").Tables[0];
            thtml = GetRegionInfoToHTML_Loop(dt, 0);
            return thtml;
        }
        public static string GetRegionInfoToHTML(int pid)
        {
            string thtml = "";
            DataTable dt = tbRegionInfo.GetRegionInfoList(" rState=0 and rUpID=" + pid).Tables[0];
            thtml = GetRegionInfoToHTML_Loop_b(dt, pid);
            return thtml;
        }
        public static string GetRegionInfoToHTML_Loop(DataTable dt, int sParentID)
        {
            string thtml = "";
            foreach (DataRow dr in dt.Rows)
            {
                if (Convert.ToInt32(dr["rUpID"].ToString()) == sParentID)
                {
                    thtml = thtml + "<li rel=\"" + dr["RegionID"].ToString() + "\">" + dr["rName"].ToString() + GetRegionInfoToHTML_Loop(dt, Convert.ToInt32(dr["RegionID"].ToString())) + "</li>";
                }
            }
            if (sParentID > 0)
            {
                return (thtml.Trim() != "") ? "<ul>" + thtml + "</ul>" : "";
            }
            else
            {
                return thtml;
            }
        }
        public static string GetRegionInfoToHTML_Loop_b(DataTable dt, int sParentID)
        {
            string thtml = "";
            foreach (DataRow dr in dt.Rows)
            {
                if (Convert.ToInt32(dr["rUpID"].ToString()) == sParentID)
                {
                    thtml = thtml + "<li rel=\"" + dr["RegionID"].ToString() + "\">" + dr["rName"].ToString() +  "</li>";
                }
            }
            if (sParentID > 0)
            {
                return (thtml.Trim() != "") ? "<ul>" + thtml + "</ul>" : "";
            }
            else
            {
                return thtml;
            }
        }
        #endregion
        #endregion

        #region Storage

        public static string GetStoragesClassInfoToJson(int pid, bool getdata)
        {
            string json = "";
            DataTable dt = tbStorageInfo.GetStoragesInfoList("sParentID=" + pid).Tables[0];
            json = GetStorageInfoToJson_Loop_b(dt, pid, getdata);
            return Utils.ReSQLSetTxt(json);
        }
        public static string GetStoragesClassInfoToJson(int pid)
        {
            string json = "";
            DataTable dt = tbStorageInfo.GetStoragesInfoList("sParentID=" + pid).Tables[0];
            json = GetStorageInfoToJson_Loop_b(dt, pid);
            return Utils.ReSQLSetTxt(json);
        }
        public static string GetStorageInfoToJson_Loop_b(DataTable dt, int sParentID)
        {
            string json = "";
            foreach (DataRow dr in dt.Rows)
            {
                if (Convert.ToInt32(dr["sParentID"].ToString()) == sParentID)
                {
                    json = json + "{\"data\":\"" + dr["sClassName"].ToString() + "\",\"state\":\"closed\",\"attr\":{\"id\":\"t_" + dr["StorageClassID"].ToString() + "\",\"value\":\"" + dr["sParentID"].ToString() + "\",\"pid\":\"" + sParentID + "\"}},";
                }
            }
            return Utils.ReSQLSetTxt(json);
        }
        //仓库分类
        public static string GetStorageInfoToJson_Loop_b(DataTable dt, int sParentID, bool getdata)
        {
            string json = "";
            foreach (DataRow dr in dt.Rows)
            {
                if (Convert.ToInt32(dr["sParentID"].ToString()) == sParentID)
                {
                    json = json + "{\"data\":\"" + dr["sClassName"].ToString() + "\",\"state\":\"closed\",\"attr\":{\"id\":\"t_" + dr["StorageClassID"].ToString() + "\",\"rel\":\"" + (ExistsStorageClassChild(Convert.ToInt32(dr["StorageClassID"].ToString())) ? "root" : "dt") + "\",\"value\":\"" + dr["StorageClassID"].ToString() + "\",\"pid\":\"" + sParentID + "\"},\"children\":[" + GetStorageInfoToJson_Loop_b(dt, Convert.ToInt32(dr["StorageClassID"].ToString()), getdata) + "]},";

                }
            }
            if (getdata)
            {
                DataTable dtt = new DataTable();
                try
                {
                    dtt = tbStorageInfo.GetStoragesInfoList(" StorageClassID=" + sParentID).Tables[0];
                    if (dtt != null)
                    {
                        foreach (DataRow drr in dtt.Rows)
                        {
                            json = json + "{\"data\":\"" + drr["sClassName"].ToString() + "\",\"state\":\"closed\",\"attr\":{\"id\":\"d_" + drr["sParentID"].ToString() + "\",\"rel\":\"dt\",\"value\":\"" + drr["sParentID"].ToString() + "\",\"otype\":\"1\"}},";
                        }
                    }
                }
                finally
                {
                    dtt.Clear();
                }
            }
            return Utils.ReSQLSetTxt(json);
        }
        //客户分类
        public static string GetCustomersInfoToJson_Loop_b(DataTable dt, int sParentID, bool getdata)
        {
            string json = "";
            foreach (DataRow dr in dt.Rows)
            {
                if (Convert.ToInt32(dr["cParentID"].ToString()) == sParentID)
                {
                    json = json + "{\"data\":\"" + dr["cClassName"].ToString() + "\",\"state\":\"closed\",\"attr\":{\"id\":\"t_" + dr["CustomersClassID"].ToString() + "\",\"rel\":\"" + (ExistsStorageClassChild(Convert.ToInt32(dr["CustomersClassID"].ToString())) ? "root" : "dt") + "\",\"value\":\"" + dr["CustomersClassID"].ToString() + "\",\"pid\":\"" + sParentID + "\"},\"children\":[" + GetCustomersInfoToJson_Loop_b(dt, Convert.ToInt32(dr["CustomersClassID"].ToString()), getdata) + "]},";

                }
            }
            if (getdata)
            {
                DataTable dtt = new DataTable();
                try
                {
                    dtt = DataClass.GetCustomersClassInfoList(" CustomersClassID=" + sParentID).Tables[0];
                    if (dtt != null)
                    {
                        foreach (DataRow drr in dtt.Rows)
                        {
                            json = json + "{\"data\":\"" + drr["cClassName"].ToString() + "\",\"state\":\"closed\",\"attr\":{\"id\":\"d_" + drr["cParentID"].ToString() + "\",\"rel\":\"dt\",\"value\":\"" + drr["cParentID"].ToString() + "\",\"otype\":\"1\"}},";
                        }
                    }
                }
                finally
                {
                    dtt.Clear();
                }
            }
            return Utils.ReSQLSetTxt(json);
        }
        /// <summary>
        /// 仓库分类树
        /// </summary>
        /// <param name="pid"></param>
        /// <param name="getdata"></param>
        /// <param name="isAll"></param>
        /// <returns></returns>
        public static string GetStorageClassInfoToJson(int pid, bool getdata, bool isAll)
        {
            string json = "";
            DataTable dt = GetStorageClassInfoList((pid != -1 ? " cParentID=" + pid : " 1=1 ") + " order by StorageClassID asc").Tables[0];
            json = GetStorageInfoToJson_Loop_b(dt, pid != -1 ? pid : 0, getdata);
            return Utils.ReSQLSetTxt(json);
        }
       
        /// <summary>
        /// 找到子节点
        /// </summary>
        /// <param name="StorageClassID"></param>
        /// <returns></returns>
        public static bool ExistsStorageClassChild(int StorageClassID)
        {
            return DatabaseProvider.GetInstance().ExistsStorageClassChild(StorageClassID);
        }
        #endregion

        #region 区域分类
        /// <summary>
        /// 区域分类
        /// </summary>
        /// <param name="pid"></param>
        /// <param name="getdata"></param>
        /// <param name="isAll"></param>
        /// <returns></returns>
        public static string GetRegionClassInfoToJson(int pid, bool getdata, bool isAll)
        {
            string json = "";
            DataTable dt = GetRegionClassInfoList((pid != -1 ? " rUpID=" + pid : " 1=1 ") + " and rState=0 order by RegionID asc").Tables[0];
            json = GetRegionInfoToJson_Loop_b(dt, pid != -1 ? pid : 0, getdata);
            return Utils.ReSQLSetTxt(json);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static DataSet GetRegionClassInfoList(string strWhere)
        {
            return DatabaseProvider.GetInstance().GetRegionClassInfoList(strWhere);
        }
        /// <summary>
        /// 是否有子节点,即是否为叶节点
        /// </summary>
        /// <param name="RegionID"></param>
        /// <returns></returns>
        public static bool ExistsRegionClassChild(int RegionID)
        {
            return DatabaseProvider.GetInstance().ExistsRegionClassChild(RegionID);
        }
        public static string GetRegionInfoToJson_Loop_b(DataTable dt, int sParentID, bool getdata)
        {
            string json = "";
            foreach (DataRow dr in dt.Rows)
            {
                if (Convert.ToInt32(dr["rUpID"].ToString()) == sParentID)
                {
                    json = json + "{\"data\":\"" + dr["rName"].ToString() + "\",\"state\":\"closed\",\"attr\":{\"id\":\"t_" + dr["RegionID"].ToString() + "," + dr["rName"].ToString() + "\",\"rel\":\"" + (ExistsRegionClassChild(Convert.ToInt32(dr["RegionID"].ToString())) ? "root" : "dt") + "\",\"value\":\"" + dr["RegionID"].ToString() + "\",\"pid\":\"" + sParentID + "\"},\"children\":[" + GetRegionInfoToJson_Loop_b(dt, Convert.ToInt32(dr["RegionID"].ToString()), getdata) + "]},";

                }
            }
            if (getdata)
            {
                DataTable dtt = new DataTable();
                try
                {
                    dtt = tbRegionInfo.GetRegionInfoList(" RegionID=" + sParentID).Tables[0];
                    if (dtt != null)
                    {
                        foreach (DataRow drr in dtt.Rows)
                        {
                            json = json + "{\"data\":\"" + drr["rName"].ToString() + "\",\"state\":\"closed\",\"attr\":{\"id\":\"d_" + drr["rUpID"].ToString() + "\",\"rel\":\"dt\",\"value\":\"" + drr["rUpID"].ToString() + "\",\"otype\":\"1\"}},";
                        }
                    }
                }
                finally
                {
                    dtt.Clear();
                }
            }
            return Utils.ReSQLSetTxt(json);
        }
        #endregion

        #region 客户分类
        public static bool ExistsCustormClassChild(int Custorm)
        {
            return DatabaseProvider.GetInstance().ExistsCustormClassChild(Custorm);
        }
        public static string getCustormChildrenCount(string kid)
        {
            return DatabaseProvider.GetInstance().getCustormChildrenCount(kid);
        }
        public static string GetCustomersClassToJson(int pid, bool getdata, bool isAll)
        {
            string json = "";
            DataTable dt = GetCustomersClassInfoList(pid != -1 ? " cParentID=" + pid : "").Tables[0];
            json = GetCustomersClassInfoToJson_Loop_cg(dt, pid != -1 ? pid : 0, getdata);

            if (json == "")
            {
                getdata = false;
            }
            //未归类,或类丢失的
            if (getdata)
            {
                DataTable dtt = new DataTable();
                try
                {
                    dtt = tbStoresInfo.GetStoresInfoList(" CustomersClassID not in(select CustomersClassID from tbCustomersClassInfo ) and CustomersClassID<>0").Tables[0];
                    if (dtt != null)
                    {
                        foreach (DataRow drr in dtt.Rows)
                        {
                            json = json + ",{\"data\":\"" + drr["sName"].ToString() + "\",\"state\":\"closed\",\"attr\":{\"id\":\"t_" + drr["StoresID"].ToString() + "," + drr["sName"].ToString() + "\",\"rel\":\"dt\",\"value\":\"" + drr["StoresID"].ToString() + "\",\"otype\":\"0\"}}";
                        }
                    }

                }
                finally
                {
                    dtt.Clear();
                }
            }

            return Utils.ReSQLSetTxt(json);
        }
        public static string GetCustomersClassInfoToJson_Loop_cg(DataTable dt, int sParentID, bool getdata)
        {
            string json = "";
            foreach (DataRow dr in dt.Rows)
            {
                if (Convert.ToInt32(dr["cParentID"].ToString()) == sParentID)
                {
                    json = json + "{\"data\":\"" + dr["cClassName"].ToString() + "\",\"state\":\"closed\",\"attr\":{\"id\":\"t_" + dr["CustomersClassID"].ToString() + "," + dr["cClassName"].ToString() + "\",\"rel\":\"root\",\"value\":\"" + dr["CustomersClassID"].ToString() + "\",\"pid\":\"" + sParentID + "\"},\"children\":[" + GetCustomersClassInfoToJson_Loop_cg(dt, Convert.ToInt32(dr["CustomersClassID"].ToString()), getdata) + "]},";
                }
            }
            if (getdata)
            {
                DataTable dtt = new DataTable();
                try
                {
                    dtt = tbStoresInfo.GetStoresInfoList(" CustomersClassID=" + sParentID).Tables[0];
                    if (dtt != null)
                    {
                        foreach (DataRow drr in dtt.Rows)
                        {
                            json = json + "{\"data\":\"" + drr["sName"].ToString() + "\",\"state\":\"closed\",\"attr\":{\"id\":\"t_" + drr["StoresID"].ToString() + "," + drr["sName"].ToString() + "\",\"rel\":\"dt\",\"value\":\"" + drr["StoresID"].ToString() + "\",\"otype\":\"0\"}},";
                        }
                    }

                }
                finally
                {
                    dtt.Clear();
                }
            }
            return Utils.ReSQLSetTxt(json);
        }
        #endregion

        #region 商品分类
        public static DataSet GetProductsList(string strWhere)
        {
            return DatabaseProvider.GetInstance().GetProductsList(strWhere);
        }
        public static string getProductsChildrenCount(string kid)
        {
            return DatabaseProvider.GetInstance().getProductsChildrenCount(kid);
        }
        public static string GetProductsClassToJson(int pid, bool getdata, bool isAll)
        {
            string json = "";
            DataTable dt = GetProductClassInfoList(pid != -1 ? " pParentID=" + pid : "").Tables[0];
            json = GetProductClassInfoToJson_Loop_bg(dt, pid != -1 ? pid : 0, getdata);
            if (json == "")
            {
                getdata = false;
            }
            //未归类,或类丢失的
            if (getdata)
            {
                DataTable dtt = new DataTable();
                try
                {
                    dtt = GetProductsList(" ProductClassID not in(select ProductClassID from tbProductClassInfo ) and ProductClassID<>0").Tables[0];
                    if (dtt != null)
                    {
                        foreach (DataRow drr in dtt.Rows)
                        {
                            json = json + ",{\"data\":\"" + drr["pName"].ToString() + "\",\"state\":\"closed\",\"attr\":{\"id\":\"t_" + drr["ProductsID"].ToString() + "," + drr["pName"].ToString() + "\",\"rel\":\"dt\",\"value\":\"" + drr["ProductsID"].ToString() + "\",\"otype\":\"0\"}}";
                        }
                    }

                }
                finally
                {
                    dtt.Clear();
                }
            }

            return Utils.ReSQLSetTxt(json);
        }
        public static string GetProductClassInfoToJson_Loop_bg(DataTable dt, int sParentID, bool getdata)
        {
            string json = "";
            foreach (DataRow dr in dt.Rows)
            {
                if (Convert.ToInt32(dr["pParentID"].ToString()) == sParentID)
                {
                    json = json + "{\"data\":\"" + dr["pClassName"].ToString() + "\",\"state\":\"closed\",\"attr\":{\"id\":\"t_" + dr["ProductClassID"].ToString() + "," + dr["pClassName"].ToString() + "\",\"rel\":\"root\",\"value\":\"" + dr["ProductClassID"].ToString() + "\",\"pid\":\"" + sParentID + "\"},\"children\":[" + GetProductClassInfoToJson_Loop_bg(dt, Convert.ToInt32(dr["ProductClassID"].ToString()), getdata) + "]},";
                }
            }
            if (getdata)
            {
                DataTable dtt = new DataTable();
                try
                {
                    dtt = tbProductsInfo.GetProductsInfoList(" ProductClassID=" + sParentID + " and pState!=1").Tables[0];
                    if (dtt != null)
                    {
                        foreach (DataRow drr in dtt.Rows)
                        {
                            json = json + "{\"data\":\"" + drr["pName"].ToString() + "\",\"state\":\"closed\",\"attr\":{\"id\":\"t_" + drr["ProductsID"].ToString() + "," + drr["pName"].ToString() + "\",\"rel\":\"dt\",\"value\":\"" + drr["ProductsID"].ToString() + "\"}},";
                        }
                    }
                }
                finally
                {
                    dtt.Clear();
                }
            }
            return Utils.ReSQLSetTxt(json);
        }
        #endregion


    }
}
