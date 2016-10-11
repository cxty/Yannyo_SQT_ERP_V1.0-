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
    public class tbPriceClassDefaultPriceInfo
    {
        public static bool ExistsPriceClassDefaultPriceInfo(int PriceClassID, int ProductsID)
        {
            return DatabaseProvider.GetInstance().ExistsPriceClassDefaultPriceInfo(PriceClassID, ProductsID);
        }
        public static int AddPriceClassDefaultPriceInfo(PriceClassDefaultPriceInfo model)
        {
            return DatabaseProvider.GetInstance().AddPriceClassDefaultPriceInfo(model);
        }
        public static void UpdatePriceClassDefaultPriceInfo(PriceClassDefaultPriceInfo model)
        {
            DatabaseProvider.GetInstance().UpdatePriceClassDefaultPriceInfo(model);
        }
        public static void DeletePriceClassDefaultPriceInfo(int PriceClassDefaultPriceID)
        {
            DatabaseProvider.GetInstance().DeletePriceClassDefaultPriceInfo(PriceClassDefaultPriceID);
        }
        public static PriceClassDefaultPriceInfo GetPriceClassDefaultPriceInfoModel(int PriceClassDefaultPriceID)
        {
            return DatabaseProvider.GetInstance().GetPriceClassDefaultPriceInfoModel(PriceClassDefaultPriceID);
        }
        public static PriceClassDefaultPriceInfo GetPriceClassDefaultPriceInfoModel(int PriceClassID, int ProductsID)
        {
            return DatabaseProvider.GetInstance().GetPriceClassDefaultPriceInfoModel(PriceClassID, ProductsID);
        }
        public static DataSet GetPriceClassDefaultPriceInfoList(string strWhere)
        {
            return DatabaseProvider.GetInstance().GetPriceClassDefaultPriceInfoList(strWhere);
        }
        public static DataSet GetPriceClassDefaultPriceInfoList(int Top, string strWhere, string filedOrder)
        {
            return DatabaseProvider.GetInstance().GetPriceClassDefaultPriceInfoList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 取指定商品指定门店默认价格
        /// </summary>
        /// <param name="ProductID"></param>
        /// <param name="StoresID"></param>
        /// <returns></returns>
        public static decimal GetProductsPiceByStoresID(int ProductsID, int StoresID)
        {
            return DatabaseProvider.GetInstance().GetProductsPiceByStoresID(ProductsID, StoresID);
        }
        /// <summary>
        /// 保存价格类型默认价格
        /// </summary>
        /// <param name="PriceClassID"></param>
        /// <param name="ProductsID"></param>
        /// <param name="pPrice"></param>
        /// <returns></returns>
        public static bool SavePriceClassDefaultPrice(int PriceClassID, int ProductsID, decimal pPrice, int pIsEdit)
        {
            bool re = false;
            PriceClassDefaultPriceInfo pci = DatabaseProvider.GetInstance().GetPriceClassDefaultPriceInfoModel( PriceClassID,  ProductsID);
            if (pci != null)
            {
                pci.pPrice = pPrice;
                pci.pIsEdit = pIsEdit;
                tbPriceClassDefaultPriceInfo.UpdatePriceClassDefaultPriceInfo(pci);
                re = true;
            }
            else {
                pci = new PriceClassDefaultPriceInfo();
                pci.ProductsID = ProductsID;
                pci.PriceClassID = PriceClassID;
                pci.pPrice = pPrice;
                pci.pIsEdit = pIsEdit;

                if (tbPriceClassDefaultPriceInfo.AddPriceClassDefaultPriceInfo(pci) > 0)
                {
                    re = true;
                }
                else {
                    re = false;
                }
            }
            return re;
        }
    }
}
