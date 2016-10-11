using System;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Yannyo.Data;
using Yannyo.Config;
using Yannyo.Common;
using Yannyo.Entity;

namespace Yannyo.Data.SqlServer
{
    //购销明细排行
    public partial class DataProvider : IDataProvider
    {
        #region  购销明细
        /// <summary>
        /// 获得类别为：客户
        /// </summary>
        /// <param name="bDate"></param>
        /// <param name="eDate"></param>
        /// <param name="classes"></param>
        /// <returns></returns>
        public DataTable getBuySaleDetalsOfStorehouse(DateTime bDate, DateTime eDate, int classes)
        {
            SqlParameter[] parameter = { 
                          new SqlParameter("@dtmbDate",SqlDbType.DateTime), 
                          new SqlParameter("@dtmeDate",SqlDbType.DateTime), 
                          new SqlParameter("@inyBuySales",SqlDbType.Int), 
                                       };
            parameter[0].Value = bDate;
            parameter[1].Value = eDate;
            parameter[2].Value = classes;

            return DbHelper.ExecuteDataset(CommandType.StoredProcedure, "sp_" + BaseConfigs.GetTablePrefix + "Buy_Sales_Detals", parameter).Tables[0];
        }
        #endregion
    }
}
