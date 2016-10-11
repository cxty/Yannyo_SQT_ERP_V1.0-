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
	public class tbProductsFieldValueInfo
	{
		public static int AddProductsFieldValue(ProductsFieldValueInfo model)
		{
			return DatabaseProvider.GetInstance().AddProductsFieldValue (model);
		}
		public static void UpdateProductsFieldValue(ProductsFieldValueInfo model)
		{
			DatabaseProvider.GetInstance().UpdateProductsFieldValue(model);
		}
		public static void DeleteProductsFieldValue(int ProductsFieldValueID)
		{
			DatabaseProvider.GetInstance().DeleteProductsFieldValue (ProductsFieldValueID);
		}
		public static void DeleteProductsFieldValue(string ProductsFieldValueID)
		{
			DatabaseProvider.GetInstance().DeleteProductsFieldValue (ProductsFieldValueID);
		}
		public static ProductsFieldValueInfo GetProductsFieldValueModel(int ProductsFieldValueID)
		{
			return DatabaseProvider.GetInstance().GetProductsFieldValueModel (ProductsFieldValueID);
		}
		public static DataSet GetProductsFieldValueList(string strWhere)
		{
			return DatabaseProvider.GetInstance().GetProductsFieldValueList (strWhere);
		}
		public static DataTable GetProductsFieldValueList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
		{
			return DatabaseProvider.GetInstance().GetProductsFieldValueList( PageSize,  PageIndex,  strWhere, out  pagetotal,  OrderType,  showFName);
		}
		public static bool AddProductsFieldValue (int ProductsID, ProductFieldValueJson fJson)
		{
			return DatabaseProvider.GetInstance ().AddProductsFieldValue (ProductsID, fJson);
		}
		public static bool UpdateProductsFieldValue(int ProductsID,ProductFieldValueJson fJson)
		{
			return DatabaseProvider.GetInstance().UpdateProductsFieldValue( ProductsID, fJson);
		}
	}
}

