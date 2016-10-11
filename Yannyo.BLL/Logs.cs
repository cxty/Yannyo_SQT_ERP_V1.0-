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
    public class Logs
    {
        #region EventLogInfo
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddEventLog(EventLogInfo model)
        {
            return DatabaseProvider.GetInstance().AddEventLog(model);
        }
        public static int AddEventLog(int UserID, string eMSG)
        {
            EventLogInfo model = new EventLogInfo();
            model.UserID = UserID;
            model.eMSG = eMSG;
            model.eAppendTime = DateTime.Now;
            return DatabaseProvider.GetInstance().AddEventLog(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool UpdateEventLog(EventLogInfo model)
        {
            return DatabaseProvider.GetInstance().UpdateEventLog(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static bool DeleteEventLog(int EventLogID)
        {
            return DatabaseProvider.GetInstance().DeleteEventLog(EventLogID);
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public static bool DeleteListEventLog(string EventLogIDlist)
        {
            if (EventLogIDlist.Trim() != "")
            {
                EventLogIDlist = "," + EventLogIDlist + ",";
                EventLogIDlist = Utils.ReSQLSetTxt(EventLogIDlist);
                return DatabaseProvider.GetInstance().DeleteListEventLog(EventLogIDlist);
            }
            else {
                return false;
            }
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static EventLogInfo GetEventLogModel(int EventLogID)
        {
            return DatabaseProvider.GetInstance().GetEventLogModel(EventLogID);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataSet GetEventLogList(string strWhere)
        {
            return DatabaseProvider.GetInstance().GetEventLogList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public static DataSet GetEventLogList(int Top, string strWhere, string filedOrder)
        {
            return DatabaseProvider.GetInstance().GetEventLogList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public static DataTable GetEventLogList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
        {
            return DatabaseProvider.GetInstance().GetEventLogList(PageSize, PageIndex, strWhere, out  pagetotal, OrderType, showFName);
        }
        #endregion
    }
}
