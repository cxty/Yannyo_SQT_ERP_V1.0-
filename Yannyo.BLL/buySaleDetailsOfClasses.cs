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
    public  class buySaleDetailsOfClasses
    {
        /// <summary>
        /// 获得购销明细，类别为：客户
        /// </summary>
        /// <param name="bDate"></param>
        /// <param name="eDate"></param>
        /// <param name="classes"></param>
        /// <returns></returns>
        public static DataTable getBuySaleDetalsOfStorehouse(DateTime bDate, DateTime eDate, int classes)
        {
            return DatabaseProvider.GetInstance().getBuySaleDetalsOfStorehouse(bDate, eDate, classes);
        }
    }
}
