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
    public class tbStorageInfo
    {
        public static DataTable getStorageClassList(int ParentID)
        {
            return DatabaseProvider.GetInstance().getStorageClassList(ParentID);
        }
        public static DataTable GetStorageDetails(int StorageClassID)
        {
            return DatabaseProvider.GetInstance().GetStorageDetails(StorageClassID);
        }

        public static bool ExistsStorageInfo(string sName)
        {
            return DatabaseProvider.GetInstance().ExistsStorageInfo(sName);
        }
        public static bool ExistsStorageInfoByCode(string sCode)
        {
            return DatabaseProvider.GetInstance().ExistsStorageInfoByCode(sCode);
        }
        public static int AddStorageInfo(StorageInfo model)
        {
            return DatabaseProvider.GetInstance().AddStorageInfo(model);
        }
        public static void UpdateStorageInfo(StorageInfo model)
        {
            DatabaseProvider.GetInstance().UpdateStorageInfo(model);
        }
        public static void DeleteStorageInfo(int StorageID)
        {
            DatabaseProvider.GetInstance().DeleteStorageInfo(StorageID);
        }
        public static void DeleteStorageInfo(string StorageID)
        {
            StorageID = "," + StorageID + ",";
            StorageID = Utils.ReSQLSetTxt(StorageID);
            DatabaseProvider.GetInstance().DeleteStorageInfo(StorageID);
        }
        public static StorageInfo GetStorageInfoModel(int StorageID)
        {
            return DatabaseProvider.GetInstance().GetStorageInfoModel(StorageID);
        }
        public static DataSet GetStorageInfoList(string strWhere)
        {
            return DatabaseProvider.GetInstance().GetStorageInfoList(strWhere);
        }
        public static DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return DatabaseProvider.GetInstance().GetList(Top, strWhere, filedOrder);
        }
        public static DataTable GetStorageInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
        {
            return DatabaseProvider.GetInstance().GetStorageInfoList(PageSize, PageIndex, strWhere, out  pagetotal, OrderType, showFName);
        }
        public static DataSet GetStoragesInfoList(string strWhere)
        {
            return DatabaseProvider.GetInstance().GetStoragesInfoList(strWhere);
        }
        public static bool ExistsStorageInfo(string sClassName, int sParentID)
        {
            return DatabaseProvider.GetInstance().ExistsStorageInfo(sClassName, sParentID);
        }
        public static int AddStorageListInfo(StorageClass model)
        {
            return DatabaseProvider.GetInstance().AddStorageListInfo(model);
        }
        public static StorageClass GetStoragesInfoModel(int StorageClassID)
        {
            return DatabaseProvider.GetInstance().GetStoragesInfoModel(StorageClassID);
        }
        public static int UpdateStoragesInfo(StorageClass model)
        {
            return DatabaseProvider.GetInstance().UpdateStoragesInfo(model);
        }
        public static int DeleteStoragesInfo(int StorageID)
        {
            return DatabaseProvider.GetInstance().DeleteStoragesInfo(StorageID);
        }

        public static StorageInfo GetStorageInfoModelBySCode(string sCode)
        {
            return DatabaseProvider.GetInstance().GetStorageInfoModelBySCode(sCode);
        }

        public static StorageInfo GetStorageInfoModelByName(string sName)
        {
            return DatabaseProvider.GetInstance().GetStorageInfoModelByName(sName);
        }
    }
}
