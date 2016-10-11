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
     public class CostDetails
     {
         #region  费用统计_门店
         /// <summary>
         /// 获得科目详细
         /// </summary>
         /// <returns></returns>
         public static DataTable getObjectsList()
         {
             return DatabaseProvider.GetInstance().getObjectsList();
         }
         /// <summary>
         /// 获得科目名称
         /// </summary>
         /// <param name="sid"></param>
         /// <returns></returns>
         public static DataTable getObjectsListName(int sid)
         {
             return DatabaseProvider.GetInstance().getObjectsListName(sid);
         }
         /// <summary>
         /// 获得区域名称
         /// </summary>
         /// <returns></returns>
         public static DataTable getRegionList(int sid, string kid, DateTime bDate, DateTime eDate)
         {
             return DatabaseProvider.GetInstance().getRegionList(sid, kid, bDate, eDate);
         }
         /// <summary>
         /// 获得门店名称
         /// </summary>
         /// <param name="rID"></param>
         /// <returns></returns>
         public static DataTable getStorsList(int sid, string rID, DateTime bDate, DateTime eDate)
         {
             return DatabaseProvider.GetInstance().getStorsList(sid, rID, bDate, eDate);
         }
         /// <summary>
         /// 获得科目选择的名称
         /// </summary>
         /// <param name="treeNode"></param>
         /// <returns></returns>
         public static DataTable getTreeName(string treeNode)
         {
             return DatabaseProvider.GetInstance().getTreeName(treeNode);
         }
         /// <summary>
         /// 费用统计：客户—科目
         /// </summary>
         /// <param name="storesId"></param>
         /// <param name="kType"></param>
         /// <param name="type"></param>
         /// <param name="bDate"></param>
         /// <param name="eDate"></param>
         /// <returns></returns>
         public static DataTable getCostOfStorehouse(int storesId, string kType, int type, DateTime bDate, DateTime eDate)
         {
             return DatabaseProvider.GetInstance().getCostOfStorehouse(storesId, kType, type, bDate, eDate);
         }
         /// <summary>
         /// 门店费用详细
         /// </summary>
         /// <param name="selectID"></param>
         /// <param name="sid"></param>
         /// <param name="kid"></param>
         /// <param name="bDate"></param>
         /// <param name="eDate"></param>
         /// <returns></returns>
         public static DataTable getCostOfStorehouseDetails(int selectID, int sid, string kid, DateTime bDate, DateTime eDate)
         {
             return DatabaseProvider.GetInstance().getCostOfStorehouseDetails(selectID, sid, kid, bDate, eDate);
         }
         /// <summary>
         /// 循环找到科目孩节点
         /// </summary>
         /// <param name="kid"></param>
         /// <returns></returns>
         public static string getTreeChildrenCount(string kid)
         {
             return DatabaseProvider.GetInstance().getTreeChildrenCount(kid);
         }
         #endregion
         #region 费用统计_科目
         /// <summary>
         /// 获得科目选择时候科目名称
         /// </summary>
         /// <param name="kid"></param>
         /// <returns></returns>
         public static DataTable getClassName(string kid)
         {
             return DatabaseProvider.GetInstance().getClassName(kid);
         }
         /// <summary>
         /// 获得科目的统计费用
         /// </summary>
         /// <param name="type">借方或贷方</param>
         /// <param name="kid">科目</param>
         /// <param name="bDate">开始日期</param>
         /// <param name="eDate">结束日期</param>
         /// <returns></returns>
         public static DataTable getClassCost(int type, string kid, DateTime bDate, DateTime eDate)
         {
             return DatabaseProvider.GetInstance().getClassCost(type, kid, bDate, eDate);
         }
         /// <summary>
         /// 费用科目统计详细
         /// </summary>
         /// <param name="sID"></param>
         /// <param name="bDate"></param>
         /// <param name="eDate"></param>
         /// <param name="kID"></param>
         /// <returns></returns>
         public static DataTable getCostOfClassDetails(int sID, DateTime bDate, DateTime eDate, int kID)
         {
             return DatabaseProvider.GetInstance().getCostOfClassDetails(sID, bDate, eDate, kID);
         }
         #endregion
         #region 费用统计_业务员
         /// <summary>
         /// 获得业务员名称
         /// </summary>
         /// <param name="sid"></param>
         /// <param name="bDate"></param>
         /// <param name="eDate"></param>
         /// <returns></returns>
         public static DataTable getStaffName(int sid, DateTime bDate, DateTime eDate, int kID)
         {
             return DatabaseProvider.GetInstance().getStaffName(sid, bDate, eDate, kID);
         }
         /// <summary>
         /// 获得业务员费用
         /// </summary>
         /// <param name="sid"></param>
         /// <param name="bDate"></param>
         /// <param name="eDate"></param>
         /// <param name="kID"></param>
         /// <param name="staffID"></param>
         /// <returns></returns>
         public static DataTable getCostOfStaffID(int sid, DateTime bDate, DateTime eDate, int kID, int staffID)
         {
             return DatabaseProvider.GetInstance().getCostOfStaffID(sid, bDate, eDate, kID, staffID);
         }
         /// <summary>
         /// 获得业务费用明细
         /// </summary>
         /// <param name="sid"></param>
         /// <param name="bDate"></param>
         /// <param name="eDate"></param>
         /// <param name="staffID"></param>
         /// <param name="kID"></param>
         /// <returns></returns>
         public static DataTable getCostOfStaffDetails(int sid, DateTime bDate, DateTime eDate, int staffID, string kID)
         {
             return DatabaseProvider.GetInstance().getCostOfStaffDetails(sid, bDate, eDate, staffID, kID);
         }
         #endregion
         #region 费用统计_赠品

         /// <summary>
         /// 获得门店赠品费用
         /// </summary>
         /// <param name="bDate"></param>
         /// <param name="eDate"></param>
         /// <returns></returns>
         public static DataTable getGiftCost(int sID, DateTime bDate, DateTime eDate)
         {
             return DatabaseProvider.GetInstance().getGiftCost(sID, bDate, eDate);
         }
         /// <summary>
         /// 获得门店
         /// </summary>
         /// <param name="bDate"></param>
         /// <param name="eDate"></param>
         /// <returns></returns>
         public static DataTable getGiftCost_storehouse(DateTime bDate, DateTime eDate)
         {
             return DatabaseProvider.GetInstance().getGiftCost_storehouse(bDate, eDate);
         }
         /// <summary>
         /// 获得赠品费用明细
         /// </summary>
         /// <param name="sid"></param>
         /// <param name="pid"></param>
         /// <param name="bDate"></param>
         /// <param name="eDate"></param>
         /// <returns></returns>
         public static DataTable getGiftCost_details(int sid, int pid, DateTime bDate, DateTime eDate)
         {
             return DatabaseProvider.GetInstance().getGiftCost_details(sid, pid, bDate, eDate);
         }
         /// <summary>
         /// 获得区域毛利
         /// </summary>
         /// <param name="moriType"></param>
         /// <param name="saleType"></param>
         /// <param name="bDate"></param>
         /// <param name="eDate"></param>
         /// <returns></returns>
         public static DataTable getMoriOfRegion(int moriType, int saleType, DateTime bDate, DateTime eDate)
         {
             return DatabaseProvider.GetInstance().getMoriOfRegion(moriType, saleType, bDate, eDate);
         }
         #endregion
         #region 发生额及余额统计
         public static DataTable getOccurrenceAndBalanceDetails(DateTime bDate, DateTime eDate, int feeID, int status)
         {
             return DatabaseProvider.GetInstance().getOccurrenceAndBalanceDetails(bDate, eDate, feeID, status);
         }

         public static DataTable get_Occurrence_Balance_Details(int objectID, DateTime bDate, DateTime eDate)
         {
             return DatabaseProvider.GetInstance().get_Occurrence_Balance_Details(objectID, bDate, eDate);
         }
         /// <summary>
         /// 返回受影响的行数
         /// </summary>
         /// <param name="objectID"></param>
         /// <param name="bDate"></param>
         /// <param name="eDate"></param>
         /// <returns></returns>
         public static int get_Occurrence_Balance_Details_Count(int objectID, DateTime bDate, DateTime eDate)
         {
             return DatabaseProvider.GetInstance().get_Occurrence_Balance_Details_Count(objectID, bDate, eDate);
         }
         /// <summary>
         /// 本月累计
         /// </summary>
         /// <param name="objectID"></param>
         /// <param name="bDate"></param>
         /// <param name="eDate"></param>
         /// <returns></returns>
         public static DataTable get_Occurrence_Balance_addMonth(int objectID, DateTime bDate, DateTime eDate)
         {
             return DatabaseProvider.GetInstance().get_Occurrence_Balance_addMonth(objectID, bDate, eDate);
         }
         /// <summary>
         /// 上年结转余额
         /// </summary>
         /// <param name="objectID"></param>
         /// <returns></returns>
         public static DataTable getLastYearMoney(int objectID)
         {
             return DatabaseProvider.GetInstance().getLastYearMoney(objectID);
         }
         /// <summary>
         /// 待摊费用明细
         /// </summary>
         /// <param name="objectID"></param>
         /// <param name="bDate"></param>
         /// <param name="eDate"></param>
         /// <returns></returns>
         public static DataTable getMonthCost(int objectID, DateTime bDate, DateTime eDate, int oMonth, int sType,int status)
         {
             return DatabaseProvider.GetInstance().getMonthCost(objectID, bDate, eDate, oMonth, sType, status);
         }
         /// <summary>
         /// 获得科目名称及编码
         /// </summary>
         /// <param name="objectID"></param>
         /// <returns></returns>
         public static DataTable getSubjectNameAndID(int objectID)
         {
             return DatabaseProvider.GetInstance().getSubjectNameAndID(objectID);
         }
         /// <summary>
         /// 获得月份
         /// </summary>
         /// <param name="objectID"></param>
         /// <param name="bDate"></param>
         /// <param name="eDate"></param>
         /// <returns></returns>
         public static DataTable getMonthBySubjectAndDateTime(int objectID, DateTime bDate, DateTime eDate)
         {
             return DatabaseProvider.GetInstance().getMonthBySubjectAndDateTime(objectID, bDate, eDate);
         }
         /// <summary>
         /// 获得最大月
         /// </summary>
         /// <param name="objectID"></param>
         /// <param name="bDate"></param>
         /// <param name="eDate"></param>
         /// <returns></returns>
         public static string getMonthBySubjectAndDateTime_Max(int objectID, DateTime bDate, DateTime eDate)
         {
             return DatabaseProvider.GetInstance().getMonthBySubjectAndDateTime_Max(objectID, bDate, eDate);
         }
         /// <summary>
         /// 获取科目编号
         /// </summary>
         /// <param name="bDate"></param>
         /// <param name="eDate"></param>
         /// <returns></returns>
         public static DataTable getFeeSubjectID(DateTime bDate, DateTime eDate)
         {
             return DatabaseProvider.GetInstance().getFeeSubjectID(bDate, eDate);
         }
         #endregion
     }
}
