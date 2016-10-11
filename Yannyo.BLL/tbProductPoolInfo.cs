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
    public class tbProductPoolInfo
    {
        #region ProductPoolInfo
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddProductPool(ProductPoolInfo model)
        {
            return DatabaseProvider.GetInstance().AddProductPool(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateProductPool(ProductPoolInfo model)
        {
            DatabaseProvider.GetInstance().UpdateProductPool(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteProductPool(int ProductPoolID)
        {
            DatabaseProvider.GetInstance().DeleteProductPool(ProductPoolID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteProductPool(string ProductPoolID)
        {
            if (ProductPoolID.Trim() != "")
            {
                ProductPoolID = "," + ProductPoolID + ",";
                ProductPoolID = Utils.ReSQLSetTxt(ProductPoolID);
                DatabaseProvider.GetInstance().DeleteProductPool(ProductPoolID);
            }
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static ProductPoolInfo GetProductPoolModel(int ProductPoolID)
        {
            return DatabaseProvider.GetInstance().GetProductPoolModel(ProductPoolID);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataSet GetProductPoolList(string strWhere)
        {
            return DatabaseProvider.GetInstance().GetProductPoolList(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public static DataTable GetProductPoolList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
        {
            return DatabaseProvider.GetInstance().GetProductPoolList(PageSize, PageIndex, strWhere, out  pagetotal, OrderType, showFName);
        }
        #endregion
    }
}
