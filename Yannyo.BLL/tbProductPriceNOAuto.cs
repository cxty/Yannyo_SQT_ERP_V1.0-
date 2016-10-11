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
	public class tbProductPriceNOAuto
	{
		public static int ExistsProductsStorage(int StorageID, int ProductsID) { 
			return DatabaseProvider.GetInstance().ExistsProductsStorage(StorageID, ProductsID); 
		}
		#region 商品成本（特）
		public static int AddProductPriceNOAuto (ProductPriceNOAutoInfo model){ 
			return DatabaseProvider.GetInstance().AddProductPriceNOAuto ( model);
		}
		public static void UpdateProductPriceNOAuto (ProductPriceNOAutoInfo model)
		{
			DatabaseProvider.GetInstance().UpdateProductPriceNOAuto ( model);
		}
		public static void DeleteProductPriceNOAuto (int ProductPriceNOAutoID)
		{
			DatabaseProvider.GetInstance().DeleteProductPriceNOAuto ( ProductPriceNOAutoID);
		}
		public static void DeleteProductPriceNOAuto (string ProductPriceNOAutoID)
		{
			DatabaseProvider.GetInstance().DeleteProductPriceNOAuto ( ProductPriceNOAutoID);
		}
		public static ProductPriceNOAutoInfo GetProductPriceNOAutoModel (int ProductPriceNOAutoID){ 
			return DatabaseProvider.GetInstance().GetProductPriceNOAutoModel ( ProductPriceNOAutoID);
		}
		public static DataSet GetProductPriceNOAutoList (string strWhere){ 
			return DatabaseProvider.GetInstance().GetProductPriceNOAutoList ( strWhere);
		}

		/// <summary>
		/// 获得最新的产品价格列表
		/// </summary>
		public static DataSet GetProductPriceNOAutoListNew(string strWhere)
		{
			return DatabaseProvider.GetInstance().GetProductPriceNOAutoListNew ( strWhere);

		}
		#endregion
	}
}

