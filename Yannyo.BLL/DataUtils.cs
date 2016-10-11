using System;
using System.Data;
using System.Data.Common;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Collections.Generic;
using System.IO;

using Yannyo.Common;
using Yannyo.Data;
using Yannyo.Config;
using Yannyo.Entity;
using System.Collections;


namespace Yannyo.BLL
{
    public class DataUtils
    {
        public static DataTable getStoresList(DateTime bDate, DateTime eDate)
        {
            return DatabaseProvider.GetInstance().getStoresList(bDate, eDate);
        }
        public static DataTable GetSales_analysis(int StoresID, int StaffID, int StaffIDB, string Brand, int RegionID, int ProductID, int YHsysID, DateTime bDate, DateTime eDate, int ShowType, int DateType, out decimal AllSumValue)
        {
            return DatabaseProvider.GetInstance().GetSales_analysis(StoresID, StaffID, StaffIDB, Brand, RegionID, ProductID, YHsysID, bDate, eDate, ShowType, DateType, out AllSumValue);
        }
        /// <summary>
        /// 返回一个时间段内指定格式的日期，dType:1=日,2=月,3=年
        /// </summary>
        public static DataTable GetDateTimeList(DateTime bDate, DateTime eDate, int dType)
        {
            return DatabaseProvider.GetInstance().GetDateTimeList(bDate, eDate, dType);
        }
        /// <summary>
        /// 返回一个时间段内:销售额,成本,退货,坏货,赠品,销售费用,公司费用
        /// </summary>
        /// <param name="dType">类型(7:综合(含公司费用), 1:门店/客户, 2:业务员, 3:促销员, 4:产品, 5:品牌, 6:系统)</param>
        public static DataTable GetErpData_analysis(DateTime bDate, DateTime eDate, int dType)
        {
            return DatabaseProvider.GetInstance().GetErpData_analysis(bDate, eDate, dType);
        }
        /// <summary>
        /// 返回一个时间段内:销售额,成本,退货,坏货,赠品,销售费用,公司费用
        /// </summary>
        /// <param name="dType">类型(7:综合(含公司费用), 1:门店/客户, 2:业务员, 3:促销员, 4:产品, 5:品牌, 6:系统)</param>
        /// <param name="StoresID">@StoresID int = 0,			--门店客户编号</param>
        /// <param name="StaffID">@StaffID int = 0,			--业务员编号</param>
        /// <param name="StaffIDB">@StaffIDB int = 0,			--促销员编号</param>
        /// <param name="Brand">@Brand varchar(128) = '',	--品牌名称,模糊</param>
        /// <param name="RegionID">@RegionID int = 0,			--地区编号</param>
        /// <param name="ProductID">@ProductID int = 0,			--产品编号</param>
        /// <param name="YHsysID">@YHsysID int = 0			--系统编号</param>
        public static DataTable GetErpData_analysis(DateTime bDate, DateTime eDate, int dType, int StoresID, int StaffID, int StaffIDB, string Brand, int RegionID, int ProductID, int YHsysID)
        {
            return DatabaseProvider.GetInstance().GetErpData_analysis(bDate, eDate, dType, StoresID, StaffID, StaffIDB, Brand, RegionID, ProductID, YHsysID);
        }
        /// <summary>
        /// 返回一个时间段内:费用
        /// </summary>
        /// <param name="mType">类型(销售费用=0,公司管理费用=1)</param>
        public static DataTable Get_Fees_analysis(DateTime bDate, DateTime eDate, int mType)
        {
            return DatabaseProvider.GetInstance().Get_Fees_analysis(bDate, eDate, mType);
        }
        /// <summary>
        /// 库存情况
        /// </summary>
        /// <param name="storageid">仓库编号</param>
        /// <param name="eDate">库存点</param>
        /// <param name="ProductID">产品编号</param>
        public static DataTable GetStock_analysis(int storageid, DateTime eDate, int ProductID)
        {
            return DatabaseProvider.GetInstance().GetStock_analysis(storageid, eDate, ProductID);
        }

        /// <summary>
        /// 应收应付
        /// </summary>
        /// <param name="gettype">客户应收=0,人员应收=1,供货商应付=2,人员应付=3</param>
        /// <param name="eDate">截止时间点</param>
        /// <param name="ObjID">指定对象编号</param>
        public static DataTable GetAPARMoney(int gettype, DateTime eDate, int ObjID)
        {
            return DatabaseProvider.GetInstance().GetAPARMoney(gettype, eDate, ObjID);
        }
        /// <summary>
        /// 返回净资产
        /// </summary>
        /// <param name="eDate">截止时间点</param>
        public static DataTable GetNetAssets(DateTime eDate)
        {
            return DatabaseProvider.GetInstance().GetNetAssets(eDate);
        }
        /// <summary>
        /// 返回人员带身份证列表
        /// </summary>
        public static DataTable GetStaffBirthdayList()
        {
            return DatabaseProvider.GetInstance().GetStaffBirthdayList();
        }
        /// <summary>
        /// 取指定门店的费用明细
        /// </summary>
        /// <param name="bDate"></param>
        /// <param name="eDate"></param>
        /// <param name="StoresID"></param>
        /// <returns></returns>
        public static DataTable Get_Fees_by_StoresID(DateTime bDate, DateTime eDate, int StoresID)
        {
            return DatabaseProvider.GetInstance().Get_Fees_by_StoresID(bDate, eDate, StoresID);
        }

        /// <summary>
        /// 取指定科目费用明细
        /// </summary>
        /// <param name="bDate"></param>
        /// <param name="eDate"></param>
        /// <param name="FeesSubjectID"></param>
        /// <returns></returns>
        public static DataTable Get_Fees_by_FeesSubjectID(DateTime bDate, DateTime eDate, int FeesSubjectID)
        {
            return DatabaseProvider.GetInstance().Get_Fees_by_FeesSubjectID(bDate, eDate, FeesSubjectID);
        }

        /// <summary>
        /// 取销售统计表
        /// </summary>
        /// <param name="ReType">商品销售=1,客户销售=2,销售成本,利润=3</param>
        /// <param name="bDate">开始时间</param>
        /// <param name="eDate">结束时间</param>
        /// <param name="NOJoinSales">是否剔除联营数据</param>
        /// <returns></returns>
        public static DataTable GetSalesReport(int ReType, DateTime bDate, DateTime eDate, int NOJoinSales)
        {
            return DatabaseProvider.GetInstance().GetSalesReport(ReType, bDate, eDate, NOJoinSales);
        }
        /// <summary>
        /// 取销售统计表
        /// </summary>
        /// <param name="ReType"></param>
        /// <param name="bDate"></param>
        /// <param name="eDate"></param>
        /// <param name="NOJoinSales"></param>
        /// <param name="StoresID"></param>
        /// <returns></returns>
		public static DataTable GetSalesReport(int ReType, DateTime bDate, DateTime eDate, int NOJoinSales, int StoresID,int SingleMemberID)
        {
			return DatabaseProvider.GetInstance().GetSalesReport(ReType, bDate, eDate, NOJoinSales, StoresID,SingleMemberID);
        }
        /// <summary>
        /// 取销售统计表
        /// </summary>
        /// <param name="ReType"></param>
        /// <param name="bDate"></param>
        /// <param name="eDate"></param>
        /// <param name="NOJoinSales"></param>
        /// <param name="StoresID"></param>
        /// <param name="PaymentSystemID"></param>
        /// <returns></returns>
		public static DataTable GetSalesReport(int ReType, DateTime bDate, DateTime eDate, int NOJoinSales, int StoresID, int PaymentSystemID,int SingleMemberID)
        {
			return DatabaseProvider.GetInstance().GetSalesReport(ReType, bDate, eDate, NOJoinSales, StoresID, PaymentSystemID,SingleMemberID);
        }
		public static DataTable GetSalesReport(int ReType, DateTime bDate, DateTime eDate, int NOJoinSales, int StoresID, int PaymentSystemID, int oSteps,int SingleMemberID)
        {
			return DatabaseProvider.GetInstance().GetSalesReport(ReType, bDate, eDate, NOJoinSales, StoresID, PaymentSystemID, oSteps,SingleMemberID);
        }
		public static DataTable GetSalesReport(int ReType, DateTime bDate, DateTime eDate, int NOJoinSales, int StoresID, int PaymentSystemID, int oSteps, int dType,int SingleMemberID)
        {
			return DatabaseProvider.GetInstance().GetSalesReport(ReType, bDate, eDate, NOJoinSales, StoresID, PaymentSystemID, oSteps, dType,SingleMemberID);
        }
		public static DataTable GetSalesReport(int ReType, DateTime bDate, DateTime eDate, int NOJoinSales, int StoresID, int PaymentSystemID, int oSteps, int dType, int CostPrice,int SingleMemberID)
        {
			return DatabaseProvider.GetInstance().GetSalesReport(ReType, bDate, eDate, NOJoinSales, StoresID, PaymentSystemID, oSteps, dType, CostPrice,SingleMemberID);
        }
		public static DataTable GetSalesReport(int ReDateType,int ReType, DateTime bDate, DateTime eDate, int NOJoinSales, int StoresID, int PaymentSystemID, int oSteps, int dType, int CostPrice,int SingleMemberID,string OrderNumber)
		{
            return DatabaseProvider.GetInstance().GetSalesReport(ReDateType,ReType, bDate, eDate, NOJoinSales, StoresID, PaymentSystemID, oSteps, dType, CostPrice, SingleMemberID, OrderNumber);
		}
        /// <summary>
        /// 取进货统计表
        /// </summary>
        /// <param name="ReType"></param>
        /// <param name="bDate"></param>
        /// <param name="eDate"></param>
        /// <returns></returns>
        public static DataTable GetPurchaseReport(int ReType, DateTime bDate, DateTime eDate)
        {
            return DatabaseProvider.GetInstance().GetPurchaseReport( ReType,  bDate,  eDate);
        }
        /// <summary>
        /// 出库统计
        /// </summary>
        /// <param name="ReType">商品=1,客户=2</param>
        /// <param name="bDate"></param>
        /// <param name="eDate"></param>
        /// <param name="NOJoinSales"></param>
        /// <returns></returns>
        public static DataTable GetOutReport(int ReType, DateTime bDate, DateTime eDate, int NOJoinSales)
        {
            return DatabaseProvider.GetInstance().GetOutReport(ReType, bDate, eDate, NOJoinSales);
        }
        /// <summary>
        /// 去除重复项
        /// </summary>
        /// <param name="needToPurge"></param>
        public static void Purge(ref List<string> needToPurge)
        {
            for (int i = 0; i < needToPurge.Count - 1; i++)
            {
                string deststring = needToPurge[i];
                for (int j = i + 1; j < needToPurge.Count; j++)
                {
                    if (deststring.CompareTo(needToPurge[j]) == 0)
                    {
                        needToPurge.RemoveAt(j);
                        continue;
                    }
                }
            }
        }
        /// <summary>
        /// 库存商品明细
        /// </summary>
        /// <param name="bDate">开始时间</param>
        /// <param name="eDate">结束时间</param>
        /// <param name="ProductsID">商品编号</param>
        /// <param name="CostPrice">是否计算成本，0计算，1不计算</param>
        /// <param name="StorageID">仓库名称</param>
        /// <param name="Product_UPYear">上年结转，out</param>
        /// <returns></returns>
        public static DataSet GetProductLogDetails(DateTime bDate, DateTime eDate, int ProductsID, int CostPrice, int StorageID)
        {
            return DatabaseProvider.GetInstance().GetProductLogDetails(bDate, eDate, ProductsID, CostPrice, StorageID);
        }
        /// <summary>
        /// 返回客户销售统计数据
        /// </summary>
        /// <param name="ShowType">显示类型,1=按客户,2=业务员,3=促销员,4=产品,5=品牌(产品分类),6=系统</param>
        /// <param name="bDate"></param>
        /// <param name="eDate"></param>
        /// <returns></returns>
        public static DataTable GetCustomers_DataAnalysis(int ShowType, DateTime bDate, DateTime eDate, out decimal AllSumMoney, int storesID, int isIsPool)
        {
            return DatabaseProvider.GetInstance().GetCustomers_DataAnalysis(ShowType, bDate, eDate, out AllSumMoney, storesID, isIsPool);
        }
        /// <summary>
        /// 导出数据
        /// </summary>
        /// <param name="bDate"></param>
        /// <param name="Type"></param>
        /// <param name="checkValue"></param>
        /// <returns></returns>
        public static DataTable getStorageSalesExportData(DateTime bDate, int Type, int checkValue)
        {
            return DatabaseProvider.GetInstance().getStorageSalesExportData(bDate, Type, checkValue);
        }
        /// <summary>
        /// 导出出货数据
        /// </summary>
        /// <param name="bDate"></param>
        /// <param name="checkValue"></param>
        /// <returns></returns>
        public static DataTable getReportOutExport(DateTime bDate, int checkValue)
        {
            return DatabaseProvider.GetInstance().getReportOutExport(bDate, checkValue);
        }

        #region 数据导出邮件发送
        
        /// <summary>
        /// 客户销售自动发邮件
        /// </summary>
        /// <param name="dType">1=客户；2=业务员；3=促销员；4=单品；5=品牌</param>
        /// <param name="bDate">查询日期</param>
        /// <param name="checkValue">0=日；1=周；2=月</param>
        /// <param name="toEmail">收件人邮箱地址</param>
        /// <returns></returns>
        public static void getStorageSalesDetails( int dType, string bDate, int checkValue, string toEmail)
        {
            GeneralConfigInfo config = GeneralConfigs.GetConfig();
            string tbDate = bDate + " 00:00:00";
            string FileURL = "";

            {
                DataTable dcList = getStorageSalesExportData(Convert.ToDateTime(tbDate), dType, checkValue);
                DataTable dt = dcList.Copy();
                DataSet ds = new DataSet();
                ds.Tables.Add(dt);
                //客户
                if (dType == 1)
                {
                    ds.Tables[0].Columns[0].ColumnName = "客户名称";
                    ds.Tables[0].Columns[1].ColumnName = "销售数量";
                    ds.Tables[0].Columns[2].ColumnName = "销售金额";
                    if (toEmail.Trim() != "")
                    {
                        //每日
                        if (checkValue == 0)
                        {
                            FileURL = GreateExcelToFile(ds.Tables[0], "客户销售数据 客户每日 " + Convert.ToDateTime(tbDate).ToShortDateString() + ".xls");
                            UsersUtils.SendMailToEmail(toEmail.Trim(), config.CompanyName + " 客户销售数据 客户每日 ", "请下载:<br><a href=\"" + config.Sysurl + FileURL + "\">" + config.Sysurl + FileURL + "</a><br>若不能下载请复制右侧连接:<br>" + config.Sysurl + FileURL + " 到浏览器地址栏(或下载软件任务栏)下载,下载地址永久有效. ");
                        }
                        //每周
                        if (checkValue == 1)
                        {
                            FileURL = GreateExcelToFile(ds.Tables[0], "客户销售数据 客户每周 " + Convert.ToDateTime(tbDate).ToShortDateString() + ".xls");
                            UsersUtils.SendMailToEmail(toEmail.Trim(), config.CompanyName + " 客户销售数据 客户每周", "请下载:<br><a href=\"" + config.Sysurl + FileURL + "\">" + config.Sysurl + FileURL + "</a><br>若不能下载请复制右侧连接:<br>" + config.Sysurl + FileURL + " 到浏览器地址栏(或下载软件任务栏)下载,下载地址永久有效. ");
                        }
                        //每月
                        if (checkValue == 2)
                        {
                            FileURL = GreateExcelToFile(ds.Tables[0], "客户销售数据 客户每月" + Convert.ToDateTime(tbDate).ToShortDateString() + ".xls");
                            UsersUtils.SendMailToEmail(toEmail.Trim(), config.CompanyName + " 客户销售数据 客户每月", "请下载:<br><a href=\"" + config.Sysurl + FileURL + "\">" + config.Sysurl + FileURL + "</a><br>若不能下载请复制右侧连接:<br>" + config.Sysurl + FileURL + " 到浏览器地址栏(或下载软件任务栏)下载,下载地址永久有效. ");
                        }
                    }
                }
                //业务员
                if (dType == 2)
                {
                    ds.Tables[0].Columns[0].ColumnName = "业务员名称";
                    ds.Tables[0].Columns[1].ColumnName = "销售数量";
                    ds.Tables[0].Columns[2].ColumnName = "销售金额";
                    if (toEmail.Trim() != "")
                    {
                        //每日
                        if (checkValue == 0)
                        {
                            FileURL = GreateExcelToFile(ds.Tables[0], "客户销售数据 业务员每日" + Convert.ToDateTime(tbDate).ToShortDateString() + ".xls");
                            UsersUtils.SendMailToEmail(toEmail.Trim(), config.CompanyName + " 客户销售数据 业务员每日", "请下载:<br><a href=\"" + config.Sysurl + FileURL + "\">" + config.Sysurl + FileURL + "</a><br>若不能下载请复制右侧连接:<br>" + config.Sysurl + FileURL + " 到浏览器地址栏(或下载软件任务栏)下载,下载地址永久有效. ");
                        }
                        //每周
                        if (checkValue == 1)
                        {
                            FileURL = GreateExcelToFile(ds.Tables[0], "客户销售数据 业务员每周" + Convert.ToDateTime(tbDate).ToShortDateString() + ".xls");
                            UsersUtils.SendMailToEmail(toEmail.Trim(), config.CompanyName + " 客户销售数据 业务员每周", "请下载:<br><a href=\"" + config.Sysurl + FileURL + "\">" + config.Sysurl + FileURL + "</a><br>若不能下载请复制右侧连接:<br>" + config.Sysurl + FileURL + " 到浏览器地址栏(或下载软件任务栏)下载,下载地址永久有效. ");
                        }
                        //每月
                        if (checkValue == 2)
                        {
                            FileURL = GreateExcelToFile(ds.Tables[0], "客户销售数据 业务员每月" + Convert.ToDateTime(tbDate).ToShortDateString() + ".xls");
                            UsersUtils.SendMailToEmail(toEmail.Trim(), config.CompanyName + " 客户销售数据 业务员每月", "请下载:<br><a href=\"" + config.Sysurl + FileURL + "\">" + config.Sysurl + FileURL + "</a><br>若不能下载请复制右侧连接:<br>" + config.Sysurl + FileURL + " 到浏览器地址栏(或下载软件任务栏)下载,下载地址永久有效. ");
                        }
                    }
                }
                //促销员
                if (dType == 3)
                {
                    ds.Tables[0].Columns[0].ColumnName = "促销员名称";
                    ds.Tables[0].Columns[1].ColumnName = "销售数量";
                    ds.Tables[0].Columns[2].ColumnName = "销售金额";
                    if (toEmail.Trim() != "")
                    {
                        //每日
                        if (checkValue == 0)
                        {
                            FileURL = GreateExcelToFile(ds.Tables[0], "客户销售数据 促销员每日" + Convert.ToDateTime(tbDate).ToShortDateString() + ".xls");
                            UsersUtils.SendMailToEmail(toEmail.Trim(), config.CompanyName + " 客户销售数据 促销员每日", "请下载:<br><a href=\"" + config.Sysurl + FileURL + "\">" + config.Sysurl + FileURL + "</a><br>若不能下载请复制右侧连接:<br>" + config.Sysurl + FileURL + " 到浏览器地址栏(或下载软件任务栏)下载,下载地址永久有效. ");
                        }
                        //每周
                        if (checkValue == 1)
                        {
                            FileURL = GreateExcelToFile(ds.Tables[0], "客户销售数据 促销员每周" + Convert.ToDateTime(tbDate).ToShortDateString() + ".xls");
                            UsersUtils.SendMailToEmail(toEmail.Trim(), config.CompanyName + " 客户销售数据 促销员每周", "请下载:<br><a href=\"" + config.Sysurl + FileURL + "\">" + config.Sysurl + FileURL + "</a><br>若不能下载请复制右侧连接:<br>" + config.Sysurl + FileURL + " 到浏览器地址栏(或下载软件任务栏)下载,下载地址永久有效. ");
                        }
                        //每月
                        if (checkValue == 2)
                        {
                            FileURL = GreateExcelToFile(ds.Tables[0], "客户销售数据 促销员每月" + Convert.ToDateTime(tbDate).ToShortDateString() + ".xls");
                            UsersUtils.SendMailToEmail(toEmail.Trim(), config.CompanyName + " 客户销售数据 促销员每月", "请下载:<br><a href=\"" + config.Sysurl + FileURL + "\">" + config.Sysurl + FileURL + "</a><br>若不能下载请复制右侧连接:<br>" + config.Sysurl + FileURL + " 到浏览器地址栏(或下载软件任务栏)下载,下载地址永久有效. ");
                        }
                    }
                }
                //单品
                if (dType == 4)
                {
                    ds.Tables[0].Columns[0].ColumnName = "商品名称";
                    ds.Tables[0].Columns[1].ColumnName = "销售数量";
                    ds.Tables[0].Columns[2].ColumnName = "销售金额";
                    if (toEmail.Trim() != "")
                    {
                        //每日
                        if (checkValue == 0)
                        {
                            FileURL = GreateExcelToFile(ds.Tables[0], "客户销售数据 商品每日" + Convert.ToDateTime(tbDate).ToShortDateString() + ".xls");
                            UsersUtils.SendMailToEmail(toEmail.Trim(), config.CompanyName + " 客户销售数据 商品每日", "请下载:<br><a href=\"" + config.Sysurl + FileURL + "\">" + config.Sysurl + FileURL + "</a><br>若不能下载请复制右侧连接:<br>" + config.Sysurl + FileURL + " 到浏览器地址栏(或下载软件任务栏)下载,下载地址永久有效. ");
                        }
                        //每周
                        if (checkValue == 1)
                        {
                            FileURL = GreateExcelToFile(ds.Tables[0], "客户销售数据 商品每周" + Convert.ToDateTime(tbDate).ToShortDateString() + ".xls");
                            UsersUtils.SendMailToEmail(toEmail.Trim(), config.CompanyName + " 客户销售数据 商品每周", "请下载:<br><a href=\"" + config.Sysurl + FileURL + "\">" + config.Sysurl + FileURL + "</a><br>若不能下载请复制右侧连接:<br>" + config.Sysurl + FileURL + " 到浏览器地址栏(或下载软件任务栏)下载,下载地址永久有效. ");
                        }
                        //每月
                        if (checkValue == 2)
                        {
                            FileURL = GreateExcelToFile(ds.Tables[0], "客户销售数据 商品每月" + Convert.ToDateTime(tbDate).ToShortDateString() + ".xls");
                            UsersUtils.SendMailToEmail(toEmail.Trim(), config.CompanyName + " 客户销售数据 商品每月", "请下载:<br><a href=\"" + config.Sysurl + FileURL + "\">" + config.Sysurl + FileURL + "</a><br>若不能下载请复制右侧连接:<br>" + config.Sysurl + FileURL + " 到浏览器地址栏(或下载软件任务栏)下载,下载地址永久有效. ");
                        }
                    }
                }
                //品牌
                if (dType == 5)
                {
                    ds.Tables[0].Columns[0].ColumnName = "品牌名称";
                    ds.Tables[0].Columns[1].ColumnName = "销售数量";
                    ds.Tables[0].Columns[2].ColumnName = "销售金额";
                    if (toEmail.Trim() != "")
                    {
                        //每日
                        if (checkValue == 0)
                        {
                            FileURL = GreateExcelToFile(ds.Tables[0], "客户销售数据 品牌每日" + Convert.ToDateTime(tbDate).ToShortDateString() + ".xls");
                            UsersUtils.SendMailToEmail(toEmail.Trim(), config.CompanyName + " 客户销售数据 品牌每日", "请下载:<br><a href=\"" + config.Sysurl + FileURL + "\">" + config.Sysurl + FileURL + "</a><br>若不能下载请复制右侧连接:<br>" + config.Sysurl + FileURL + " 到浏览器地址栏(或下载软件任务栏)下载,下载地址永久有效. ");
                        }
                        //每周
                        if (checkValue == 1)
                        {
                            FileURL = GreateExcelToFile(ds.Tables[0], "客户销售数据 品牌每周" + Convert.ToDateTime(tbDate).ToShortDateString() + ".xls");
                            UsersUtils.SendMailToEmail(toEmail.Trim(), config.CompanyName + " 客户销售数据 品牌每周", "请下载:<br><a href=\"" + config.Sysurl + FileURL + "\">" + config.Sysurl + FileURL + "</a><br>若不能下载请复制右侧连接:<br>" + config.Sysurl + FileURL + " 到浏览器地址栏(或下载软件任务栏)下载,下载地址永久有效. ");
                        }
                        //每月
                        if (checkValue == 2)
                        {
                            FileURL = GreateExcelToFile(ds.Tables[0], "客户销售数据 品牌每月" + Convert.ToDateTime(tbDate).ToShortDateString() + ".xls");
                            UsersUtils.SendMailToEmail(toEmail.Trim(), config.CompanyName + " 客户销售数据 品牌每月", "请下载:<br><a href=\"" + config.Sysurl + FileURL + "\">" + config.Sysurl + FileURL + "</a><br>若不能下载请复制右侧连接:<br>" + config.Sysurl + FileURL + " 到浏览器地址栏(或下载软件任务栏)下载,下载地址永久有效. ");
                        }
                    }
                }
            }

        }

        /// <summary>
        /// 联营库存自动发邮件
        /// </summary>
        /// <param name="bDate">导出日期</param>
        /// <param name="tType">0=合成统计；1=分步统计</param>
        /// <param name="sType">-1=包含联营；0=剔除联营；1=仅联营</param>
        public static void getJointInventoryDetails(DateTime bDate, int tType, int sType, string toEmail)
        {
            GeneralConfigInfo config = GeneralConfigs.GetConfig();
            string FileURL = "";

            {
                DataTable dList = ProductsLossInfo.getProductsLossExportData(DateTime.Parse(bDate.Date.Year + "-" + bDate.Date.Month+"-1"), bDate.Date.AddDays(-2), sType);
                DataTable dt = new DataTable();
                dt = dList.Copy();
                dt.Columns.RemoveAt(0);
                dt.Columns.RemoveAt(0);
                DataSet ds = new DataSet();
                ds.Tables.Add(dt);
                //合成统计
                if (tType == 0)
                {
                    ds.Tables[0].Columns[0].ColumnName = "门店名称";
                    ds.Tables[0].Columns[1].ColumnName = "商品名称";
                    ds.Tables[0].Columns[2].ColumnName = "商品条码";
                    ds.Tables[0].Columns[3].ColumnName = "商品品牌";
                    ds.Tables[0].Columns[4].ColumnName = "库存数量";

                    if (toEmail.Trim() != "")
                    {
                        FileURL = GreateExcelToFile(ds.Tables[0], "联营库存数据 " + bDate.Date.AddDays(-2).ToShortDateString() + ".xls");
                        UsersUtils.SendMailToEmail(toEmail.Trim(), config.CompanyName + "联营库存数据 每日", "请下载:<br><a href=\"" + config.Sysurl + FileURL + "\">" + config.Sysurl + FileURL + "</a><br>若不能下载请复制右侧连接:<br>" + config.Sysurl + FileURL + " 到浏览器地址栏(或下载软件任务栏)下载,下载地址永久有效. ");
                    }
                }
            }
        }

        /// <summary>
        /// 公司销售月数据自动发送
        /// </summary>
        /// <param name="toEmail">收件人邮箱</param>
        /// <param name="bDate">开始日期</param>
        public static void getIslandSalesDetails(string toEmail, DateTime bDate)
        {
            GeneralConfigInfo config = GeneralConfigs.GetConfig();
            string FileURL = "";

            {
                DataTable eList = tbStoresInfo.getSalesExportData(bDate, 0);
                DataTable dt = eList.Copy();
                DataSet ds = new DataSet();
                ds.Tables.Add(dt);
                ds.Tables[0].Columns[0].ColumnName = "门店名称";
                ds.Tables[0].Columns[1].ColumnName = "销售金额";

                if (toEmail.Trim() != "")
                {
                    FileURL = GreateExcelToFile(ds.Tables[0], "公司月销售统计 " + bDate.ToShortDateString() + ".xls");
                    UsersUtils.SendMailToEmail(toEmail.Trim(), config.CompanyName + " 公司月销售统计", "请下载:<br><a href=\"" + config.Sysurl + FileURL + "\">" + config.Sysurl + FileURL + "</a><br>若不能下载请复制右侧连接:<br>" + config.Sysurl + FileURL + " 到浏览器地址栏(或下载软件任务栏)下载,下载地址永久有效. ");
                }
            }
        }
        /// <summary>
        /// 公司销售月数据自动发送
        /// </summary>
        /// <param name="toEmail">收件人邮箱</param>
        /// <param name="bDate">开始日期</param>
        /// <param name="eDate">结束日期</param>
        public static void getIslandSalesDetails(string toEmail, DateTime bDate, DateTime eDate)
        {
            GeneralConfigInfo config = GeneralConfigs.GetConfig();
            string FileURL = "";

            {
                DataTable eList = tbStoresInfo.getSalesExportData(bDate, 0);
                DataTable dt = eList.Copy();
                DataSet ds = new DataSet();
                ds.Tables.Add(dt);
                ds.Tables[0].Columns[0].ColumnName = "门店名称";
                ds.Tables[0].Columns[1].ColumnName = "销售金额";

                if (toEmail.Trim() != "")
                {
                    FileURL = GreateExcelToFile(ds.Tables[0], "公司月销售统计 " + bDate.ToShortDateString() + ".xls");
                    UsersUtils.SendMailToEmail(toEmail.Trim(), config.CompanyName + " 公司月销售统计", "请下载:<br><a href=\"" + config.Sysurl + FileURL + "\">" + config.Sysurl + FileURL + "</a><br>若不能下载请复制右侧连接:<br>" + config.Sysurl + FileURL + " 到浏览器地址栏(或下载软件任务栏)下载,下载地址永久有效. ");
                }
            }
        }
        /// <summary>
        /// 公司出货月数据自动发送邮件
        /// </summary>
        /// <param name="toEmail">收件人邮箱</param>
        /// <param name="bDate">开始日期</param>
        /// <param name="checkValue">0=单品；1=客户；2=品牌；3=区域；4=业务员</param>
        public static void getIslandShipmentDetails( string toEmail, DateTime bDate, int checkValue)
        {
            GeneralConfigInfo config = GeneralConfigs.GetConfig();
            string FileURL = "";

            {
                DataTable dcList = DataUtils.getReportOutExport(bDate, checkValue);
                DataTable dt = dcList.Copy();
                DataSet ds = new DataSet();
                ds.Tables.Add(dt);
                //单品
                if (checkValue == 0)
                {
                    ds.Tables[0].Columns[0].ColumnName = "商品名称";
                    ds.Tables[0].Columns[1].ColumnName = "销售数量";
                    ds.Tables[0].Columns[2].ColumnName = "销售金额";

                    if (toEmail.Trim() != "")
                    {
                        FileURL = GreateExcelToFile(ds.Tables[0], "公司月出货统计 商品" + bDate.ToShortDateString() + ".xls");
                        UsersUtils.SendMailToEmail(toEmail.Trim(), config.CompanyName + "公司月出货统计 商品", "请下载 :<br><a href=\"" + config.Sysurl + FileURL + "\">" + config.Sysurl + FileURL + "</a><br>若不能下载请复制右侧连接:<br>" + config.Sysurl + FileURL + " 到浏览器地址栏(或下载软件任务栏)下载,下载地址永久有效. ");
                    }
                }
                //客户
                if (checkValue == 1)
                {
                    ds.Tables[0].Columns[0].ColumnName = "客户名称";
                    ds.Tables[0].Columns[1].ColumnName = "销售数量";
                    ds.Tables[0].Columns[2].ColumnName = "销售金额";

                    if (toEmail.Trim() != "")
                    {
                        FileURL = GreateExcelToFile(ds.Tables[0], "公司月出货统计 客户" + bDate.ToShortDateString() + ".xls");
                        UsersUtils.SendMailToEmail(toEmail.Trim(), config.CompanyName + " 公司月出货统计 商品", "请下载 :<br><a href=\"" + config.Sysurl + FileURL + "\">" + config.Sysurl + FileURL + "</a><br>若不能下载请复制右侧连接:<br>" + config.Sysurl + FileURL + " 到浏览器地址栏(或下载软件任务栏)下载,下载地址永久有效. ");
                    }
                }
                //品牌
                if (checkValue == 2)
                {
                    ds.Tables[0].Columns[0].ColumnName = "品牌名称";
                    ds.Tables[0].Columns[1].ColumnName = "销售数量";
                    ds.Tables[0].Columns[2].ColumnName = "销售金额";

                    if (toEmail.Trim() != "")
                    {
                        FileURL = GreateExcelToFile(ds.Tables[0], "公司月出货统计 品牌" + bDate.ToShortDateString() + ".xls");
                        UsersUtils.SendMailToEmail(toEmail.Trim(), config.CompanyName + " 公司月出货统计 品牌", "请下载 :<br><a href=\"" + config.Sysurl + FileURL + "\">" + config.Sysurl + FileURL + "</a><br>若不能下载请复制右侧连接:<br>" + config.Sysurl + FileURL + " 到浏览器地址栏(或下载软件任务栏)下载,下载地址永久有效. ");
                    }
                }
                //区域
                if (checkValue == 3)
                {
                    ds.Tables[0].Columns[0].ColumnName = "区域名称";
                    ds.Tables[0].Columns[1].ColumnName = "销售数量";
                    ds.Tables[0].Columns[2].ColumnName = "销售金额";

                    if (toEmail.Trim() != "")
                    {
                        FileURL = GreateExcelToFile(ds.Tables[0], "公司月出货统计 区域" + bDate.ToShortDateString() + ".xls");
                        UsersUtils.SendMailToEmail(toEmail.Trim(), config.CompanyName + " 公司月出货统计 区域", "请下载 :<br><a href=\"" + config.Sysurl + FileURL + "\">" + config.Sysurl + FileURL + "</a><br>若不能下载请复制右侧连接:<br>" + config.Sysurl + FileURL + " 到浏览器地址栏(或下载软件任务栏)下载,下载地址永久有效. ");
                    }
                }
                //业务员
                if (checkValue == 4)
                {
                    ds.Tables[0].Columns[0].ColumnName = "业务员名称";
                    ds.Tables[0].Columns[1].ColumnName = "销售数量";
                    ds.Tables[0].Columns[2].ColumnName = "销售金额";

                    if (toEmail.Trim() != "")
                    {
                        FileURL = GreateExcelToFile(ds.Tables[0], "公司月出货统计 业务员" + bDate.ToShortDateString() + ".xls");
                        UsersUtils.SendMailToEmail(toEmail.Trim(), config.CompanyName + " 公司月出货统计 业务员", "请下载 :<br><a href=\"" + config.Sysurl + FileURL + "\">" + config.Sysurl + FileURL + "</a><br>若不能下载请复制右侧连接:<br>" + config.Sysurl + FileURL + " 到浏览器地址栏(或下载软件任务栏)下载,下载地址永久有效. ");
                    }
                }
            }
        }
        /// <summary>
        /// 仓库库存自动发送邮件
        /// </summary>
        /// <param name="toEmail">收件人邮件</param>
        /// <param name="StorageID">门店ID=0</param>
        /// <param name="sDate">查询日期</param>
        /// <param name="ProductID">产品ID=0</param>
        public static void getStockDetails(string toEmail, int StorageID, DateTime sDate, int ProductID)
        {
            GeneralConfigInfo config = GeneralConfigs.GetConfig();
            string FileURL = "";

            {
                DataTable dList = tbProductsInfo.GetProductsStorageInfoByStorageID(0,StorageID, sDate, ProductID);
                DataTable dt = dList.Copy();
                dt.Columns.RemoveAt(0);
                dt.Columns.RemoveAt(0);
                dt.Columns.RemoveAt(5);
                dt.Columns.RemoveAt(5);
                dt.Columns.RemoveAt(5);
                dt.Columns.RemoveAt(6);
                DataSet dset = new DataSet();
                dt.Columns["sName"].SetOrdinal(0);
                dset.Tables.Add(dt);

                dset.Tables[0].Columns[0].ColumnName = "仓库名称";
                dset.Tables[0].Columns[1].ColumnName = "商品条码";
                dset.Tables[0].Columns[2].ColumnName = "商品名称";
                dset.Tables[0].Columns[3].ColumnName = "库存数量";
                dset.Tables[0].Columns[4].ColumnName = "入库未核销";
                dset.Tables[0].Columns[5].ColumnName = "出库未核销";
                dset.Tables[0].Columns[6].ColumnName = "不可用库存";


                if (toEmail.Trim() != "")
                {
                    FileURL = GreateExcelToFile(dset.Tables[0], "公司日库存数据 " + sDate.ToShortDateString() + ".xls");
                    UsersUtils.SendMailToEmail(toEmail.Trim(), config.CompanyName + " 公司日库存数据", "请下载:<br><a href=\"" + config.Sysurl + FileURL + "\">" + config.Sysurl + FileURL + "</a><br>若不能下载请复制右侧连接:<br>" + config.Sysurl + FileURL + " 到浏览器地址栏(或下载软件任务栏)下载,下载地址永久有效. ");
                }
            }
        }

        public static void getStockDetails_all_file(string toEmail, DateTime bDate)
        {
            int cDay = bDate.Day;
            GeneralConfigInfo config = GeneralConfigs.GetConfig();
            string MailBody = "";
            string FilePath = "/Data/ExportData/" + bDate.Year + "-" + bDate.Month + "/";
            string FileName = "";
            string file_str = "";
            string FileURL = "";

            DataTable _dt = tbStorageInfo.GetStorageInfoList(" sState = 0 ").Tables[0];
            foreach (DataRow dr in _dt.Rows)
            {
                FileName = bDate.Year + "年" + bDate.Month + "月" + dr["sName"].ToString() + "实时库存统计.xls";
                file_str = Utils.GetMapPath(@"\\") + FilePath + FileName;

                if (CheckFileIsDay(file_str))
                {
                    string SheetStr = "";
                    string Sheet_Head = "";
                    string Sheet_Body = "";

                    string Sheet_a = "";
                    ArrayList Sheet_Data = new ArrayList();
                    SheetStr = "<?xml version=\"1.0\"?>" +
                                       "<Workbook xmlns=\"urn:schemas-microsoft-com:office:spreadsheet\" " +
                                        "xmlns:o=\"urn:schemas-microsoft-com:office:office\" " +
                                        "xmlns:x=\"urn:schemas-microsoft-com:office:excel\" " +
                                        "xmlns:ss=\"urn:schemas-microsoft-com:office:spreadsheet\" " +
                                        "xmlns:html=\"http://www.w3.org/TR/REC-html40\">" +
                                       "<Styles>" +
                                     "<Style ss:ID=\"Default\" ss:Name=\"Normal\">" +
                                      "<Alignment ss:Vertical=\"Center\"/>" +
                                      "<Borders/>" +
                                      "<Font ss:FontName=\"宋体\" x:CharSet=\"134\" ss:Size=\"11\" ss:Color=\"#000000\"/>" +
                                      "<Interior/>" +
                                      "<NumberFormat/>" +
                                      "<Protection/>" +
                                     "</Style>" +
                                     "<Style ss:ID=\"s62\">" +
                                     " <Alignment ss:Horizontal=\"Center\" ss:Vertical=\"Center\"/>" +
                                     "</Style>" +
                                    "</Styles>" +
                                       "{0}</Workbook>";
                    int i = 0;
                    //表头
                    for (i = 1; i <= cDay; i++)
                    {
                        Sheet_Head += "<Cell ss:StyleID=\"s62\"><Data ss:Type=\"String\">" + bDate.Month + "-" + i + "</Data></Cell>";
                    }
                    Sheet_Head = "<Row ss:AutoFitHeight=\"0\"><Cell><Data ss:Type=\"String\">序号</Data></Cell>" +
                        "<Cell><Data ss:Type=\"String\">商品分类</Data></Cell>" +
                        "<Cell><Data ss:Type=\"String\">条码</Data></Cell>" +
                        "<Cell><Data ss:Type=\"String\">商品名称</Data></Cell>" +
                        "<Cell><Data ss:Type=\"String\">默认销售价格</Data></Cell>" + Sheet_Head + "</Row>";
                    DataSet ds = new DataSet();
                    int j = 0;
                    Sheet_a += "<Worksheet ss:Name=\"仓库-" + dr["sName"].ToString() + "\"><Table>{0}</Table></Worksheet>";
                    ds = getStockDetails_copy(bDate, Convert.ToInt32(dr[0].ToString()));

                    foreach (DataTable dt in ds.Tables)
                    {
                        if (dt.TableName.IndexOf("Real_time_inventory_0") > -1)//第一天,需取第一列
                        {
                            for (j = 0; j < dt.Rows.Count; j++)
                            {
                                Sheet_Data.Add("<Cell><Data ss:Type=\"Number\">" + (j + 1) + "</Data></Cell><Cell><Data ss:Type=\"String\">" + dt.Rows[j]["ProductClassName"] + "</Data></Cell><Cell><Data ss:Type=\"String\">" + dt.Rows[j]["pBarcode"] + "</Data></Cell><Cell><Data ss:Type=\"String\">" + dt.Rows[j]["pName"] + "</Data></Cell><Cell><Data ss:Type=\"Number\">" + dt.Rows[j]["pSellingPrice"] + "</Data></Cell><Cell><Data ss:Type=\"Number\">" + (Convert.ToDecimal(dt.Rows[j]["pStorage"].ToString()) + Convert.ToDecimal(dt.Rows[j]["pStorageIn"].ToString()) - Convert.ToDecimal(dt.Rows[j]["pStorageOut"].ToString()) + Convert.ToDecimal(dt.Rows[j]["Beginning"].ToString())).ToString() + "</Data></Cell>");
                            }
                        }
                        else
                        {
                            for (j = 0; j < dt.Rows.Count; j++)
                            {
                                Sheet_Data[j] += "<Cell><Data ss:Type=\"Number\">" + (Convert.ToDecimal(dt.Rows[j]["pStorage"].ToString()) + Convert.ToDecimal(dt.Rows[j]["pStorageIn"].ToString()) - Convert.ToDecimal(dt.Rows[j]["pStorageOut"].ToString()) + Convert.ToDecimal(dt.Rows[j]["Beginning"].ToString())).ToString() + "</Data></Cell>";
                            }
                        }
                    }
                    for (j = 0; j < Sheet_Data.Count; j++)
                    {
                        Sheet_Body += "<Row ss:AutoFitHeight=\"0\">" + Sheet_Data[j].ToString() + "</Row>";
                    }
                    Sheet_a = string.Format(Sheet_a, Sheet_Head + Sheet_Body);

                    Sheet_Data.Clear();
                    Sheet_Body = "";

                    SheetStr = string.Format(SheetStr, Sheet_a);

                    StrToFile(SheetStr, FilePath, FileName, Encoding.UTF8, bDate);
                }

                FileURL = FilePath + FileName;

                MailBody += "<br><b>" + dr["sName"].ToString() + "</b>库存请下载:<br><a href=\"" + config.Sysurl + FileURL + "\">" + config.Sysurl + FileURL + "</a><br>若不能下载请复制右侧连接:<br>" + config.Sysurl + FileURL + " 到浏览器地址栏(或下载软件任务栏)下载,下载地址永久有效. <br>";
                
            }

            UsersUtils.SendMailToEmail(toEmail.Trim(), config.CompanyName + " " + bDate.Year + "年" + bDate.Month + "月 库存数据统计 ", "<b>" + config.CompanyName + " " + bDate.Year + "年" + bDate.Month + "月库存数据统计</b> " + MailBody);
        }

		//仓库库存实时数据_多仓库单表单文件
		public static void getStockDetails_all_file_oneTable(string toEmail, DateTime bDate)
		{
			int cDay = bDate.Day;
			GeneralConfigInfo config = GeneralConfigs.GetConfig();
			string MailBody = "";
			string FilePath = "/Data/ExportData/" + bDate.Year + "-" + bDate.Month + "/";
			string FileName = "";
			string file_str = "";
			string FileURL = "";
			FileName = bDate.Year + "年" + bDate.Month + "月"+bDate.Day+"日实时库存统计.xls";
			file_str = Utils.GetMapPath(@"\\") + FilePath + FileName;

			if (CheckFileIsDay(file_str))
			{
				DataTable _dt_Storage = tbStorageInfo.GetStorageInfoList(" sState = 0 ").Tables[0];
				DataTable _dt_Product = tbProductsInfo.GetProductsInfoList(" pState = 0 ").Tables[0];
				DataTable _dt_data = tbProductsInfo.GetProductsStorageInfoByStorageID_XP (0, bDate, 0);

				string SheetStr = "";
				string Sheet_Head = "";
				string Sheet_Body = "";

				string Sheet_a = "";
				ArrayList Sheet_Data = new ArrayList();
				SheetStr = "<?xml version=\"1.0\"?>" +
				           "<Workbook xmlns=\"urn:schemas-microsoft-com:office:spreadsheet\" " +
				           "xmlns:o=\"urn:schemas-microsoft-com:office:office\" " +
				           "xmlns:x=\"urn:schemas-microsoft-com:office:excel\" " +
				           "xmlns:ss=\"urn:schemas-microsoft-com:office:spreadsheet\" " +
				           "xmlns:html=\"http://www.w3.org/TR/REC-html40\">" +
				           "<Styles>" +
				           "<Style ss:ID=\"Default\" ss:Name=\"Normal\">" +
				           "<Alignment ss:Vertical=\"Center\"/>" +
				           "<Borders/>" +
				           "<Font ss:FontName=\"宋体\" x:CharSet=\"134\" ss:Size=\"11\" ss:Color=\"#000000\"/>" +
				           "<Interior/>" +
				           "<NumberFormat/>" +
				           "<Protection/>" +
				           "</Style>" +
				           "<Style ss:ID=\"s62\">" +
				           " <Alignment ss:Horizontal=\"Center\" ss:Vertical=\"Center\"/>" +
				           "</Style>" +
				           "</Styles>" +
				           "{0}</Workbook>";
				Sheet_a += "<Worksheet ss:Name=\"" +bDate.Year+"-"+bDate.Month+"-"+bDate.Day + "\"><Table>{0}</Table></Worksheet>";

				int j = 0;
				int k = 0;
				int l = 0;

				foreach (DataRow dr in _dt_Storage.Rows) {
					//表头
					Sheet_Head += "<Cell ss:StyleID=\"s62\"><Data ss:Type=\"String\">" + dr ["sName"].ToString () + "</Data></Cell>";

				}
				for (k = 0; k < _dt_Product.Rows.Count; k++) {
					string _storage_str = "";
					Decimal _sum_products = 0;
					Decimal _all_sum = 0;
					foreach (DataRow dr in _dt_Storage.Rows) {
						//data
						for (j = 0; j < _dt_data.Rows.Count; j++) {
							if ( _dt_data.Rows [j] ["StorageID"].ToString () == dr[0].ToString() && _dt_data.Rows [j] ["ProductsID"].ToString () == _dt_Product.Rows [k] ["ProductsID"].ToString ()) {
								_sum_products = Convert.ToDecimal (_dt_data.Rows [j] ["pStorage"].ToString ()) + Convert.ToDecimal (_dt_data.Rows [j] ["pStorageIn"].ToString ()) - Convert.ToDecimal (_dt_data.Rows [j] ["pStorageOut"].ToString ()) + Convert.ToDecimal (_dt_data.Rows [j] ["Beginning"].ToString ());
							}
						}

						_storage_str += "<Cell><Data ss:Type=\"Number\">"+_sum_products.ToString()+"</Data></Cell>";
						_all_sum += _sum_products;
					}
					Sheet_Data.Add("<Cell><Data ss:Type=\"Number\">" + (l + 1) + "</Data></Cell><Cell><Data ss:Type=\"String\">" + _dt_Product.Rows[k]["ProductClass"] + "</Data></Cell><Cell><Data ss:Type=\"String\">" + _dt_Product.Rows[k]["pBarcode"] + "</Data></Cell><Cell><Data ss:Type=\"String\">" + _dt_Product.Rows[k]["pName"] + "</Data></Cell>"+_storage_str+"<Cell><Data ss:Type=\"Number\">"+_all_sum.ToString()+"</Data></Cell>");
				}


				Sheet_Head = "<Row ss:AutoFitHeight=\"0\"><Cell><Data ss:Type=\"String\">序号</Data></Cell>" +
				             "<Cell><Data ss:Type=\"String\">商品分类</Data></Cell>" +
				             "<Cell><Data ss:Type=\"String\">条码</Data></Cell>" +
				             "<Cell><Data ss:Type=\"String\">商品名称</Data></Cell>" + Sheet_Head + "<Cell><Data ss:Type=\"String\">合计</Data></Cell></Row>";


				for (j = 0; j < Sheet_Data.Count; j++)
				{
					Sheet_Body += "<Row ss:AutoFitHeight=\"0\">" + Sheet_Data[j].ToString() + "</Row>";
				}
				Sheet_a = string.Format(Sheet_a, Sheet_Head + Sheet_Body);

				Sheet_Data.Clear();
				Sheet_Body = "";

				SheetStr = string.Format(SheetStr, Sheet_a);

				StrToFile(SheetStr, FilePath, FileName, Encoding.UTF8, bDate);

			}

			FileURL = FilePath + FileName;
			MailBody += "<br><b>" + config.CompanyName + "</b>" + bDate.Year + "年" + bDate.Month + "月"+bDate.Day +"日库存请下载:<br><a href=\"" + config.Sysurl + FileURL + "\">" + config.Sysurl + FileURL + "</a><br>若不能下载请复制右侧连接:<br><span><b>" + config.Sysurl + FileURL + "</b></span> 到浏览器地址栏(或下载软件任务栏)下载,下载地址永久有效. <br>";
			UsersUtils.SendMailToEmail(toEmail.Trim(), config.CompanyName + ":" + bDate.Year + "年" + bDate.Month + "月" +bDate.Day +"日库存数据统计", "<b>" + config.CompanyName + ":" + bDate.Year + "年" + bDate.Month + "月"+bDate.Day +"日库存数据统计</b>" + MailBody);
		}
        /// <summary>
        /// 服务端生成Excel
        /// </summary>
        /// <returns></returns>
        public static string GreateExcelToFile(DataTable dt, string fileName)
        {
            fileName = fileName.Replace("/", "-");
            string FilePath = "/Data/ExportData/" + DateTime.Now.Year + "-" + DateTime.Now.Month + "/";
            string colHeaders = "", ls_item = "";

            ////定义表对象与行对象，同时用DataSet对其值进行初始化 
            //DataTable dt = ds.Tables[0]; 
            DataRow[] myRow = dt.Select();//可以类似dt.Select("id>10")之形式达到数据筛选目的 
            int i = 0;
            int cl = dt.Columns.Count;

            //取得数据表各列标题，各标题之间以t分割，最后一个列标题后加回车符 
            for (i = 0; i < cl; i++)
            {
                if (i == (cl - 1))//最后一列，加n 
                {
                    colHeaders += dt.Columns[i].Caption.ToString() + "\n";
                }
                else
                {
                    colHeaders += dt.Columns[i].Caption.ToString() + "\t";
                }

            }

            //向HTTP输出流中写入取得的数据信息 

            //逐行处理数据 
            foreach (DataRow row in myRow)
            {

                //当前行数据写入HTTP输出流，并且置空ls_item以便下行数据 
                for (i = 0; i < cl; i++)
                {
                    if (i == (cl - 1))//最后一列，加n 
                    {
                        ls_item += row[i].ToString() + "\n";
                    }
                    else
                    {
                        ls_item += row[i].ToString() + "\t";
                    }

                }

            }
            if (StrToFile(colHeaders + ls_item, FilePath, fileName))
            {
                return FilePath + fileName;
            }
            else
            {
                return "";
            }
        }
        /// <summary>
        /// 字符串保存成文件
        /// </summary>
        /// <returns></returns>
        public static bool StrToFile(string Str, string FilePath, string FileName)
        {
            try
            {
                string _FilePath = FilePath;
                FilePath = Utils.GetMapPath(@"\\Data\\ExportData\\" + DateTime.Now.Year + "-" + DateTime.Now.Month + "\\");
                if (!Directory.Exists(FilePath))
                {
                    Directory.CreateDirectory(FilePath);
                }
                StreamWriter sw = new StreamWriter(File.Create(FilePath + "/" + FileName.Replace("/", "-")), Encoding.Default);
                //StreamWriter sw = File.CreateText(FilePath + "/" + FileName.Replace("/","-"));
                try
                {
                    sw.Write(Str);
                }
                finally
                {
                    sw.Flush();
                    sw.Close();
                    sw.Dispose();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool StrToFile(string Str, string FilePath, string FileName, Encoding encod, DateTime bDate)
        {
            try
            {
                string _FilePath = FilePath;
                FilePath = Utils.GetMapPath(@"\\Data\\ExportData\\" + bDate.Year + "-" + bDate.Month + "\\");
                if (!Directory.Exists(FilePath))
                {
                    Directory.CreateDirectory(FilePath);
                }
                StreamWriter sw = new StreamWriter(File.Create(FilePath + "/" + FileName.Replace("/", "-")), encod);
                //StreamWriter sw = File.CreateText(FilePath + "/" + FileName.Replace("/","-"));
                try
                {
                    sw.Write(Str);
                }
                finally
                {
                    sw.Flush();
                    sw.Close();
                    sw.Dispose();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool CheckFileIsDay(string file_str)
        {
            if (File.Exists(file_str))
            {
                FileInfo fi = new FileInfo(file_str);
                if (Math.Abs(DateTime.Now.Subtract(fi.LastWriteTime).TotalHours) >= 12)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else {
                return true;
            }
        }
        #endregion

        #region  数据导出邮件发送_副本
        /// 客户销售自动发邮件_副本
        /// </summary>
        /// <param name="dType">1=客户；2=业务员；3=促销员；4=单品；5=品牌</param>
        /// <param name="bDate">查询日期</param>
        /// <param name="checkValue">0=日</param>
        /// <param name="toEmail">收件人邮箱地址</param>
        /// <returns></returns>
        public static DataSet getStorageSalesDetails_copy(string bDate)
        {
            DataTable dt = new DataTable();        //表复制  
            DataSet ds = new DataSet();            //数据集  
            DataTable tbClone = new DataTable();   //克隆表结构
            DataTable nTable = new DataTable();    //合成一张新的表
            int dType = 5;

            GeneralConfigInfo config = GeneralConfigs.GetConfig();
            DateTime tDate = Convert.ToDateTime(bDate);

            //获取每月的第一天
            DateTime mbDate = tDate.AddDays(-(tDate.Day) + 1);
            //计算两个时间之间的天数
            //TimeSpan tSpan = (TimeSpan)(tDate - mbDate);
            //然后将其转换为int类型
            int dCount = tDate.Day;

            for (int m = 1; m <= dType; m++)
            {
                //本来就是1月1日
                if (dCount == 0)
                {
                    //客户
                    if (m == 1)
                    {
                        DataTable dcList = getStorageSalesExportData(tDate, dType, 0);
                        dt = dcList.Copy();
                        dt.TableName = "t_Custorms_0-" + tDate.ToString("yyyy-MM-dd");
                        ds.Tables.Add(dt);
                    }
                    //业务员
                    if (m == 2)
                    {
                        DataTable dcList = getStorageSalesExportData(tDate, dType, 0);
                        dt = dcList.Copy();
                        dt.TableName = "t_Staff_0-" + tDate.ToString("yyyy-MM-dd");
                        ds.Tables.Add(dt);
                    }
                    //促销员
                    if (m == 3)
                    {
                        DataTable dcList = getStorageSalesExportData(tDate, dType, 0);
                        dt = dcList.Copy();
                        dt.TableName = "t_Sales_Promotion_0-" + tDate.ToString("yyyy-MM-dd");
                        ds.Tables.Add(dt);
                    }
                    //单品
                    if (m == 4)
                    {
                        DataTable dcList = getStorageSalesExportData(tDate, dType, 0);
                        dt = dcList.Copy();
                        dt.TableName = "t_Goods_0-" + tDate.ToString("yyyy-MM-dd");
                        ds.Tables.Add(dt);
                    }
                    //品牌
                    if (m == 5)
                    {
                        DataTable dcList = getStorageSalesExportData(tDate, dType, 0);
                        dt = dcList.Copy();
                        dt.TableName = "t_Brand_0-" + tDate.ToString("yyyy-MM-dd");
                        ds.Tables.Add(dt);
                    }
                }
                else
                {
                    //客户
                    if (m == 1)
                    {
                        //循环日期，将每日的数据保存到数据集中
                        for (int i = 0; i < dCount; i++)
                        {
                            DataTable dcList = getStorageSalesExportData(mbDate, m, 0);
                            dt = dcList.Copy();
                            dt.TableName = "t_Custorms_" + i + "-" + mbDate.ToString("yyyy-MM-dd");
                            ds.Tables.Add(dt);
                            //日期加1
                            mbDate = mbDate.AddDays(1);
                        }

                    }
                    //业务员
                    if (m == 2)
                    {
                        mbDate = tDate.AddDays(-(tDate.Day) + 1);
                        //循环日期，将每日的数据保存到数据集中
                        for (int i = 0; i < dCount; i++)
                        {
                            DataTable dcList = getStorageSalesExportData(mbDate, m, 0);
                            dt = dcList.Copy();
                            dt.TableName = "t_Staff_" + i + "-" + mbDate.ToString("yyyy-MM-dd");
                            ds.Tables.Add(dt);
                            //日期加1
                            mbDate = mbDate.AddDays(1);
                        }
                    }
                    //促销员
                    if (m == 3)
                    {
                        mbDate = tDate.AddDays(-(tDate.Day) + 1);
                        //循环日期，将每日的数据保存到数据集中
                        for (int i = 0; i < dCount; i++)
                        {
                            DataTable dcList = getStorageSalesExportData(mbDate, m, 0);
                            dt = dcList.Copy();
                            dt.TableName = "t_Sales_Promotion_" + i + "-" + mbDate.ToString("yyyy-MM-dd");
                            ds.Tables.Add(dt);
                            //日期加1
                            mbDate = mbDate.AddDays(1);
                        }
                    }
                    //单品
                    if (m == 4)
                    {
                        mbDate = tDate.AddDays(-(tDate.Day) + 1);
                        //循环日期，将每日的数据保存到数据集中
                        for (int i = 0; i < dCount; i++)
                        {
                            DataTable dcList = getStorageSalesExportData(mbDate, m, 0);
                            dt = dcList.Copy();
                            dt.TableName = "t_Goods_" + i + "-" + mbDate.ToString("yyyy-MM-dd");
                            ds.Tables.Add(dt);
                            //日期加1
                            mbDate = mbDate.AddDays(1);
                        }
                    }
                    //品牌
                    if (m == 5)
                    {
                        mbDate = tDate.AddDays(-(tDate.Day) + 1);
                        //循环日期，将每日的数据保存到数据集中
                        for (int i = 0; i < dCount; i++)
                        {
                            DataTable dcList = getStorageSalesExportData(mbDate, m, 0);
                            dt = dcList.Copy();
                            dt.TableName = "t_Brand_" + i + "-" + mbDate.ToString("yyyy-MM-dd");
                            ds.Tables.Add(dt);
                            //日期加1
                            mbDate = mbDate.AddDays(1);
                        }
                    }
                }
            }
            return ds;
        }
        public static string getStorageSalesDetailsFile(string bDate)
        {
            try
            {
                int cDay = DateTime.Parse(bDate).Day;
                string FilePath = "/Data/ExportData/" + DateTime.Parse(bDate).Year + "-" + DateTime.Parse(bDate).Month + "/";
                string FileName = DateTime.Parse(bDate).Year + "年" + DateTime.Parse(bDate).Month + "月 客户销售统计.xls";

                string file_str = Utils.GetMapPath(@"\\") + FilePath + FileName;
                if (CheckFileIsDay(file_str))
                {

                    string SheetStr = "";
                    string Sheet_Custorms = "";//客户
                    string Sheet_Custorms_Head = "";
                    string Sheet_Custorms_Head_b = "";
                    string Sheet_Custorms_Body = "";
                    ArrayList Sheet_Custorms_Data = new ArrayList();

                    string Sheet_Staff = "";//业务员
                    string Sheet_Staff_Head = "";
                    string Sheet_Staff_Head_b = "";
                    string Sheet_Staff_Body = "";
                    ArrayList Sheet_Staff_Data = new ArrayList();

                    string Sheet_Sales_Promotion = "";//促销员
                    string Sheet_Sales_Promotion_Head = "";
                    string Sheet_Sales_Promotion_Head_b = "";
                    string Sheet_Sales_Promotion_Body = "";
                    ArrayList Sheet_Sales_Promotion_Data = new ArrayList();

                    string Sheet_Goods = "";//商品
                    string Sheet_Goods_Head = "";
                    string Sheet_Goods_Head_b = "";
                    string Sheet_Goods_Body = "";
                    ArrayList Sheet_Goods_Data = new ArrayList();

                    string Sheet_Brand = "";//品牌
                    string Sheet_Brand_Head = "";
                    string Sheet_Brand_Head_b = "";
                    string Sheet_Brand_Body = "";
                    ArrayList Sheet_Brand_Data = new ArrayList();

                    SheetStr = "<?xml version=\"1.0\"?>" +
                                        "<Workbook xmlns=\"urn:schemas-microsoft-com:office:spreadsheet\" " +
                                         "xmlns:o=\"urn:schemas-microsoft-com:office:office\" " +
                                         "xmlns:x=\"urn:schemas-microsoft-com:office:excel\" " +
                                         "xmlns:ss=\"urn:schemas-microsoft-com:office:spreadsheet\" " +
                                         "xmlns:html=\"http://www.w3.org/TR/REC-html40\">" +
                                        "<Styles>" +
                                      "<Style ss:ID=\"Default\" ss:Name=\"Normal\">" +
                                       "<Alignment ss:Vertical=\"Center\"/>" +
                                       "<Borders/>" +
                                       "<Font ss:FontName=\"宋体\" x:CharSet=\"134\" ss:Size=\"11\" ss:Color=\"#000000\"/>" +
                                       "<Interior/>" +
                                       "<NumberFormat/>" +
                                       "<Protection/>" +
                                      "</Style>" +
                                      "<Style ss:ID=\"s62\">" +
                                      " <Alignment ss:Horizontal=\"Center\" ss:Vertical=\"Center\"/>" +
                                      "</Style>" +
                                     "</Styles>" +
                                        "{0}</Workbook>";
                    Sheet_Custorms = "<Worksheet ss:Name=\"客户\"><Table>{0}</Table></Worksheet>";
                    Sheet_Staff = "<Worksheet ss:Name=\"业务员\"><Table>{0}</Table></Worksheet>";
                    Sheet_Sales_Promotion = "<Worksheet ss:Name=\"促销员\"><Table>{0}</Table></Worksheet>";
                    Sheet_Goods = "<Worksheet ss:Name=\"商品\"><Table>{0}</Table></Worksheet>";
                    Sheet_Brand = "<Worksheet ss:Name=\"品牌\"><Table>{0}</Table></Worksheet>";

                    int i = 0;
                    //表头
                    for (i = 1; i <= cDay; i++)
                    {
                        Sheet_Custorms_Head += "<Cell ss:MergeAcross=\"1\" ss:StyleID=\"s62\"><Data ss:Type=\"String\">" + DateTime.Parse(bDate).Month + "-" + i + "</Data></Cell>";
                        Sheet_Staff_Head += "<Cell ss:MergeAcross=\"1\" ss:StyleID=\"s62\"><Data ss:Type=\"String\">" + DateTime.Parse(bDate).Month + "-" + i + "</Data></Cell>";
                        Sheet_Sales_Promotion_Head += "<Cell ss:MergeAcross=\"1\" ss:StyleID=\"s62\"><Data ss:Type=\"String\">" + DateTime.Parse(bDate).Month + "-" + i + "</Data></Cell>";
                        Sheet_Goods_Head += "<Cell ss:MergeAcross=\"1\" ss:StyleID=\"s62\"><Data ss:Type=\"String\">" + DateTime.Parse(bDate).Month + "-" + i + "</Data></Cell>";
                        Sheet_Brand_Head += "<Cell ss:MergeAcross=\"1\" ss:StyleID=\"s62\" ><Data ss:Type=\"String\">" + DateTime.Parse(bDate).Month + "-" + i + "</Data></Cell>";
                    }
                    //第二行少一格
                    for (i = 1; i < cDay; i++)
                    {
                        Sheet_Custorms_Head_b += "<Cell ss:StyleID=\"s62\"><Data ss:Type=\"String\">数量</Data></Cell><Cell ss:StyleID=\"s62\"><Data ss:Type=\"String\">金额</Data></Cell>";
                        Sheet_Staff_Head_b += "<Cell ss:StyleID=\"s62\"><Data ss:Type=\"String\">数量</Data></Cell><Cell ss:StyleID=\"s62\"><Data ss:Type=\"String\">金额</Data></Cell>";
                        Sheet_Sales_Promotion_Head_b += "<Cell ss:StyleID=\"s62\"><Data ss:Type=\"String\">数量</Data></Cell><Cell ss:StyleID=\"s62\"><Data ss:Type=\"String\">金额</Data></Cell>";
                        Sheet_Goods_Head_b += "<Cell ss:StyleID=\"s62\"><Data ss:Type=\"String\">数量</Data></Cell><Cell ss:StyleID=\"s62\"><Data ss:Type=\"String\">金额</Data></Cell>";
                        Sheet_Brand_Head_b += "<Cell ss:StyleID=\"s62\"><Data ss:Type=\"String\">数量</Data></Cell><Cell ss:StyleID=\"s62\"><Data ss:Type=\"String\">金额</Data></Cell>";
                    }
                    Sheet_Custorms_Head = "<Row ss:AutoFitHeight=\"0\"><Cell ss:MergeDown=\"1\" ss:StyleID=\"s62\"><Data ss:Type=\"String\">序号</Data></Cell><Cell ss:MergeDown=\"1\" ss:StyleID=\"s62\"><Data ss:Type=\"String\">客户</Data></Cell>" + Sheet_Custorms_Head + "</Row><Row ss:AutoFitHeight=\"0\"><Cell ss:Index=\"3\" ss:StyleID=\"s62\"><Data ss:Type=\"String\">数量</Data></Cell><Cell ss:StyleID=\"s62\"><Data ss:Type=\"String\" >金额</Data></Cell>" + Sheet_Custorms_Head_b + "</Row>";
                    Sheet_Staff_Head = "<Row ss:AutoFitHeight=\"0\"><Cell ss:MergeDown=\"1\" ss:StyleID=\"s62\"><Data ss:Type=\"String\">序号</Data></Cell><Cell ss:MergeDown=\"1\" ss:StyleID=\"s62\"><Data ss:Type=\"String\">业务员</Data></Cell>" + Sheet_Staff_Head + "</Row><Row ss:AutoFitHeight=\"0\"><Cell ss:Index=\"3\" ss:StyleID=\"s62\"><Data ss:Type=\"String\">数量</Data></Cell><Cell ss:StyleID=\"s62\"><Data ss:Type=\"String\">金额</Data></Cell>" + Sheet_Staff_Head_b + "</Row>";
                    Sheet_Sales_Promotion_Head = "<Row ss:AutoFitHeight=\"0\"><Cell ss:MergeDown=\"1\" ss:StyleID=\"s62\"><Data ss:Type=\"String\">序号</Data></Cell><Cell ss:MergeDown=\"1\" ss:StyleID=\"s62\" ><Data ss:Type=\"String\">促销员</Data></Cell>" + Sheet_Sales_Promotion_Head + "</Row><Row ss:AutoFitHeight=\"0\"><Cell ss:Index=\"3\" ss:StyleID=\"s62\"><Data ss:Type=\"String\">数量</Data></Cell><Cell ss:StyleID=\"s62\"><Data ss:Type=\"String\">金额</Data></Cell>" + Sheet_Sales_Promotion_Head_b + "</Row>";
                    Sheet_Goods_Head = "<Row ss:AutoFitHeight=\"0\"><Cell ss:MergeDown=\"1\" ss:StyleID=\"s62\"><Data ss:Type=\"String\">序号</Data></Cell><Cell ss:MergeDown=\"1\" ss:StyleID=\"s62\"><Data ss:Type=\"String\">商品名称</Data></Cell>" + Sheet_Goods_Head + "</Row><Row ss:AutoFitHeight=\"0\"><Cell ss:Index=\"3\" ss:StyleID=\"s62\"><Data ss:Type=\"String\">数量</Data></Cell><Cell ss:StyleID=\"s62\" ><Data ss:Type=\"String\">金额</Data></Cell>" + Sheet_Goods_Head_b + "</Row>";
                    Sheet_Brand_Head = "<Row ss:AutoFitHeight=\"0\"><Cell ss:MergeDown=\"1\" ss:StyleID=\"s62\"><Data ss:Type=\"String\">序号</Data></Cell><Cell ss:MergeDown=\"1\" ss:StyleID=\"s62\"><Data ss:Type=\"String\">品牌</Data></Cell>" + Sheet_Brand_Head + "</Row><Row ss:AutoFitHeight=\"0\"><Cell ss:Index=\"3\" ss:StyleID=\"s62\"><Data ss:Type=\"String\">数量</Data></Cell><Cell ss:StyleID=\"s62\"><Data ss:Type=\"String\">金额</Data></Cell>" + Sheet_Brand_Head_b + "</Row>";

                    DataSet ds = getStorageSalesDetails_copy(bDate);
                    int j = 0;
                    foreach (DataTable dt in ds.Tables)
                    {
                        #region 客户
                        if (dt.TableName.IndexOf("t_Custorms") > -1)
                        {
                            if (dt.TableName.IndexOf("t_Custorms_0") > -1)//第一天,需取第一列
                            {
                                for (j = 0; j < dt.Rows.Count; j++)
                                {
                                    Sheet_Custorms_Data.Add("<Cell><Data ss:Type=\"Number\">" + (j + 1) + "</Data></Cell><Cell><Data ss:Type=\"String\">" + dt.Rows[j][1] + "</Data></Cell><Cell><Data ss:Type=\"Number\">" + dt.Rows[j][2] + "</Data></Cell><Cell><Data ss:Type=\"Number\">" + dt.Rows[j][3] + "</Data></Cell>");
                                }
                            }
                            else
                            {
                                for (j = 0; j < dt.Rows.Count; j++)
                                {
                                    Sheet_Custorms_Data[j] += "<Cell><Data ss:Type=\"Number\">" + dt.Rows[j][2] + "</Data></Cell><Cell><Data ss:Type=\"Number\">" + dt.Rows[j][3] + "</Data></Cell>";
                                }
                            }
                        }
                        #endregion
                        #region 业务员
                        if (dt.TableName.IndexOf("t_Staff") > -1)
                        {
                            if (dt.TableName.IndexOf("t_Staff_0") > -1)//第一天,需取第一列
                            {
                                for (j = 0; j < dt.Rows.Count; j++)
                                {
                                    Sheet_Staff_Data.Add("<Cell><Data ss:Type=\"Number\">" + (j + 1) + "</Data></Cell><Cell><Data ss:Type=\"String\">" + dt.Rows[j][1] + "</Data></Cell><Cell><Data ss:Type=\"Number\">" + dt.Rows[j][2] + "</Data></Cell><Cell><Data ss:Type=\"Number\">" + dt.Rows[j][3] + "</Data></Cell>");
                                }
                            }
                            else
                            {
                                for (j = 0; j < dt.Rows.Count; j++)
                                {
                                    Sheet_Staff_Data[j] += "<Cell><Data ss:Type=\"Number\">" + dt.Rows[j][2] + "</Data></Cell><Cell><Data ss:Type=\"Number\">" + dt.Rows[j][3] + "</Data></Cell>";
                                }
                            }
                        }
                        #endregion
                        #region 促销员
                        if (dt.TableName.IndexOf("t_Sales_Promotion") > -1)
                        {
                            if (dt.TableName.IndexOf("t_Sales_Promotion_0") > -1)//第一天,需取第一列
                            {
                                for (j = 0; j < dt.Rows.Count; j++)
                                {
                                    Sheet_Sales_Promotion_Data.Add("<Cell><Data ss:Type=\"Number\">" + (j + 1) + "</Data></Cell><Cell><Data ss:Type=\"String\">" + dt.Rows[j][1] + "</Data></Cell><Cell><Data ss:Type=\"Number\">" + dt.Rows[j][2] + "</Data></Cell><Cell><Data ss:Type=\"Number\">" + dt.Rows[j][3] + "</Data></Cell>");
                                }
                            }
                            else
                            {
                                for (j = 0; j < dt.Rows.Count; j++)
                                {
                                    Sheet_Sales_Promotion_Data[j] += "<Cell><Data ss:Type=\"Number\">" + dt.Rows[j][2] + "</Data></Cell><Cell><Data ss:Type=\"Number\">" + dt.Rows[j][3] + "</Data></Cell>";
                                }
                            }
                        }
                        #endregion
                        #region 商品
                        if (dt.TableName.IndexOf("t_Goods") > -1)
                        {
                            if (dt.TableName.IndexOf("t_Goods_0") > -1)//第一天,需取第一列
                            {
                                for (j = 0; j < dt.Rows.Count; j++)
                                {
                                    Sheet_Goods_Data.Add("<Cell><Data ss:Type=\"Number\">" + (j + 1) + "</Data></Cell><Cell><Data ss:Type=\"String\">" + dt.Rows[j][1] + "</Data></Cell><Cell><Data ss:Type=\"Number\">" + dt.Rows[j][2] + "</Data></Cell><Cell><Data ss:Type=\"Number\">" + dt.Rows[j][3] + "</Data></Cell>");
                                }
                            }
                            else
                            {
                                for (j = 0; j < dt.Rows.Count; j++)
                                {
                                    Sheet_Goods_Data[j] += "<Cell><Data ss:Type=\"Number\">" + dt.Rows[j][2] + "</Data></Cell><Cell><Data ss:Type=\"Number\">" + dt.Rows[j][3] + "</Data></Cell>";
                                }
                            }
                        }
                        #endregion
                        #region 品牌
                        if (dt.TableName.IndexOf("t_Brand") > -1)
                        {
                            if (dt.TableName.IndexOf("t_Brand_0") > -1)//第一天,需取第一列
                            {
                                for (j = 0; j < dt.Rows.Count; j++)
                                {
                                    Sheet_Brand_Data.Add("<Cell><Data ss:Type=\"Number\">" + (j + 1) + "</Data></Cell><Cell><Data ss:Type=\"String\">" + dt.Rows[j][0] + "</Data></Cell><Cell><Data ss:Type=\"Number\">" + dt.Rows[j][1] + "</Data></Cell><Cell><Data ss:Type=\"Number\">" + dt.Rows[j][2] + "</Data></Cell>");
                                }
                            }
                            else
                            {
                                for (j = 0; j < dt.Rows.Count; j++)
                                {
                                    Sheet_Brand_Data[j] += "<Cell><Data ss:Type=\"Number\">" + dt.Rows[j][1] + "</Data></Cell><Cell><Data ss:Type=\"Number\">" + dt.Rows[j][2] + "</Data></Cell>";
                                }
                            }
                        }
                        #endregion
                    }

                    for (j = 0; j < Sheet_Custorms_Data.Count; j++)
                    {
                        Sheet_Custorms_Body += "<Row ss:AutoFitHeight=\"0\">" + Sheet_Custorms_Data[j].ToString() + "</Row>";
                    }
                    for (j = 0; j < Sheet_Staff_Data.Count; j++)
                    {
                        Sheet_Staff_Body += "<Row ss:AutoFitHeight=\"0\">" + Sheet_Staff_Data[j].ToString() + "</Row>";
                    }
                    for (j = 0; j < Sheet_Sales_Promotion_Data.Count; j++)
                    {
                        Sheet_Sales_Promotion_Body += "<Row ss:AutoFitHeight=\"0\">" + Sheet_Sales_Promotion_Data[j].ToString() + "</Row>";
                    }
                    for (j = 0; j < Sheet_Goods_Data.Count; j++)
                    {
                        Sheet_Goods_Body += "<Row ss:AutoFitHeight=\"0\">" + Sheet_Goods_Data[j].ToString() + "</Row>";
                    }
                    for (j = 0; j < Sheet_Brand_Data.Count; j++)
                    {
                        Sheet_Brand_Body += "<Row ss:AutoFitHeight=\"0\">" + Sheet_Brand_Data[j].ToString() + "</Row>";
                    }
                    Sheet_Custorms = string.Format(Sheet_Custorms, Sheet_Custorms_Head + Sheet_Custorms_Body);
                    Sheet_Staff = string.Format(Sheet_Staff, Sheet_Staff_Head + Sheet_Staff_Body);
                    Sheet_Sales_Promotion = string.Format(Sheet_Sales_Promotion, Sheet_Sales_Promotion_Head + Sheet_Sales_Promotion_Body);
                    Sheet_Goods = string.Format(Sheet_Goods, Sheet_Goods_Head + Sheet_Goods_Body);
                    Sheet_Brand = string.Format(Sheet_Brand, Sheet_Brand_Head + Sheet_Brand_Body);

                    SheetStr = string.Format(SheetStr, Sheet_Custorms + Sheet_Staff + Sheet_Sales_Promotion + Sheet_Goods + Sheet_Brand);
                    StrToFile(SheetStr, FilePath, FileName, Encoding.UTF8, DateTime.Parse(bDate));
                }
                string FileURL = FilePath + FileName;
                return FileURL;

            }
            catch
            {
                return "";
            }
        }
        //生成xls并发送邮件
        public static bool getStorageSalesDetails_ToMail(string bDate, string toEmail)
        {
            string FileURL = getStorageSalesDetailsFile(bDate);
            if (FileURL.Trim() != "")
            {
                GeneralConfigInfo config = GeneralConfigs.GetConfig();

                UsersUtils.SendMailToEmail(toEmail.Trim(), config.CompanyName + " " + DateTime.Parse(bDate).Year + "年" + DateTime.Parse(bDate).Month + "月 客户销售统计 ", "<b>" + config.CompanyName + " " + DateTime.Parse(bDate).Year + "年" + DateTime.Parse(bDate).Month + "月 客户销售统计</b> <br>请下载:<br><a href=\"" + config.Sysurl + FileURL + "\">" + config.Sysurl + FileURL + "</a><br>若不能下载请复制右侧连接:<br>" + config.Sysurl + FileURL + " 到浏览器地址栏(或下载软件任务栏)下载,下载地址永久有效. ");
                return true;
            }
            else {
                return false;
            }
        }

        /// <summary>
        /// 联营库存自动发邮件_副本
        /// </summary>
        /// <param name="bDate">导出日期:【默认值给当前日期】</param>
        /// <param name="sType">-1=包含联营；0=剔除联营；1=仅联营</param>
        /// 输出为是否联营，距离今日前两日的时候的数据,sType=1
        public static DataSet getJointInventoryDetails_copy(DateTime bDate, int sType)
        {
            GeneralConfigInfo config = GeneralConfigs.GetConfig();
            DataSet ds = new DataSet();
            bDate = bDate.Date.AddDays(-2);
            DataTable dt = new DataTable();
            DataTable dList = new DataTable();

            //获取每月的第一天
            DateTime mbDate = bDate.AddDays(-(bDate.Day) + 1);
            //计算两个时间之间的天数
            //TimeSpan tSpan = (TimeSpan)(bDate - mbDate);
            //然后将其转换为int类型
            int dCount = bDate.Day;


            if (dCount == 0)
            {
                dList = ProductsLossInfo.getProductsLossExportData(DateTime.Parse(bDate.Date.Year + "-" + bDate.Date.Month + "-1"), bDate, sType);
                if (sType == -1)
                {
                    dt = dList.Copy();
                    dt.Columns.RemoveAt(0);
                    dt.Columns.RemoveAt(0);
                    dt.TableName = "Joint_Inventory_Contains_Associates_0-" + mbDate.ToString("yyyy-MM-dd");
                    ds.Tables.Add(dt);
                }
                if (sType == 0)
                {
                    dt = dList.Copy();
                    dt.Columns.RemoveAt(0);
                    dt.Columns.RemoveAt(0);
                    dt.TableName = "Joint_Inventory_Elimination_of_joint_venture_0-" + mbDate.ToString("yyyy-MM-dd");
                    ds.Tables.Add(dt);
                }
                if (sType == 1)
                {
                    dt = dList.Copy();
                    dt.Columns.RemoveAt(0);
                    dt.Columns.RemoveAt(0);
                    dt.TableName = "Joint_Inventory_Only_associates_0-" + mbDate.ToString("yyyy-MM-dd");
                    ds.Tables.Add(dt);
                }
            }
            else
            {
                //包含联营
                if (sType == -1)
                {
                    for (int j = 0; j < dCount; j++)
                    {
                        dList = ProductsLossInfo.getProductsLossExportData(DateTime.Parse(bDate.Date.Year + "-" + bDate.Date.Month + "-1"), mbDate, sType);

                        dt = dList.Copy();
                        dt.Columns.RemoveAt(0);
                        dt.Columns.RemoveAt(0);
                        dt.TableName = "Joint_Inventory_Contains_Associates_" + j + "-" + mbDate.ToString("yyyy-MM-dd");
                        ds.Tables.Add(dt);
                        mbDate = mbDate.AddDays(1);
                    }
                }
                //剔除联营
                if (sType == 0)
                {
                    for (int j = 0; j < dCount; j++)
                    {
                        dList = ProductsLossInfo.getProductsLossExportData(DateTime.Parse(bDate.Date.Year + "-" + bDate.Date.Month + "-1"), mbDate, sType);

                        dt = dList.Copy();
                        dt.Columns.RemoveAt(0);
                        dt.Columns.RemoveAt(0);
                        dt.TableName = "Joint_Inventory_Elimination_of_joint_venture_" + j + "-" + mbDate.ToString("yyyy-MM-dd");
                        ds.Tables.Add(dt);
                        mbDate = mbDate.AddDays(1);
                    }
                }
                //仅联营
                if (sType == 1)
                {
                    for (int j = 0; j < dCount; j++)
                    {
                        dList = ProductsLossInfo.getProductsLossExportData(DateTime.Parse(bDate.Date.Year + "-" + bDate.Date.Month + "-1"), mbDate, sType);

                        dt = dList.Copy();
                        dt.Columns.RemoveAt(0);
                        dt.Columns.RemoveAt(0);
                        dt.TableName = "Joint_Inventory_Only_associates_" + j + "-" + mbDate.ToString("yyyy-MM-dd");
                        ds.Tables.Add(dt);
                        mbDate = mbDate.AddDays(1);
                    }
                }
            }
            return ds;
        }
        public static string getJointInventoryDetailsFile(DateTime bDate, int sType)
        {
            try
            {
                int cDay = bDate.Day;

                string SheetStr = "";
                string Sheet_Head = "";
                string Sheet_Body = "";

                string Sheet_a = "";


                ArrayList Sheet_Data = new ArrayList();
                string FilePath = "/Data/ExportData/" + bDate.Year + "-" + bDate.Month + "/";
                string FileName = "";


                SheetStr = "<?xml version=\"1.0\"?>" +
                                    "<Workbook xmlns=\"urn:schemas-microsoft-com:office:spreadsheet\" " +
                                     "xmlns:o=\"urn:schemas-microsoft-com:office:office\" " +
                                     "xmlns:x=\"urn:schemas-microsoft-com:office:excel\" " +
                                     "xmlns:ss=\"urn:schemas-microsoft-com:office:spreadsheet\" " +
                                     "xmlns:html=\"http://www.w3.org/TR/REC-html40\">" +
                                    "<Styles>" +
                                  "<Style ss:ID=\"Default\" ss:Name=\"Normal\">" +
                                   "<Alignment ss:Vertical=\"Center\"/>" +
                                   "<Borders/>" +
                                   "<Font ss:FontName=\"宋体\" x:CharSet=\"134\" ss:Size=\"11\" ss:Color=\"#000000\"/>" +
                                   "<Interior/>" +
                                   "<NumberFormat/>" +
                                   "<Protection/>" +
                                  "</Style>" +
                                  "<Style ss:ID=\"s62\">" +
                                  " <Alignment ss:Horizontal=\"Center\" ss:Vertical=\"Center\"/>" +
                                  "</Style>" +
                                 "</Styles>" +
                                    "{0}</Workbook>";
                switch (sType)
                {
                    case -1:
                        Sheet_a = "<Worksheet ss:Name=\"客户商品库存\"><Table>{0}</Table></Worksheet>";
                        FileName = bDate.Year + "年" + bDate.Month + "月 客户库存统计.xls";
                        break;
                    case 0:
                        Sheet_a = "<Worksheet ss:Name=\"客户商品库存-剔除联营\"><Table>{0}</Table></Worksheet>";
                        FileName = bDate.Year + "年" + bDate.Month + "月 客户库存统计 剔除联营.xls";
                        break;
                    case 1:
                        Sheet_a = "<Worksheet ss:Name=\"客户商品库存-仅联营\"><Table>{0}</Table></Worksheet>";
                        FileName = bDate.Year + "年" + bDate.Month + "月 客户库存统计 仅联营.xls";
                        break;
                }
                int i = 0;
                //表头
                for (i = 1; i <= cDay; i++)
                {
                    Sheet_Head += "<Cell><Data ss:Type=\"String\">" + bDate.Month + "-" + i + "</Data></Cell>";
                }
                Sheet_Head = "<Row ss:AutoFitHeight=\"0\"><Cell><Data ss:Type=\"String\">序号</Data></Cell>" +
                    "<Cell><Data ss:Type=\"String\">商品分类</Data></Cell>" +
                    "<Cell><Data ss:Type=\"String\">条码</Data></Cell>" +
                    "<Cell><Data ss:Type=\"String\">商品名称</Data></Cell>" +
                    "<Cell><Data ss:Type=\"String\">品牌</Data></Cell>" + Sheet_Head + "</Row>";

                string file_str = Utils.GetMapPath(@"\\") + FilePath + FileName;

                if (CheckFileIsDay(file_str))
                {
                    DataSet ds = getJointInventoryDetails_copy(bDate, sType);

                    int j = 0;
                    foreach (DataTable dt in ds.Tables)
                    {
                        //全部
                        if (dt.TableName.IndexOf("Joint_Inventory_Contains_Associates") > -1)
                        {
                            if (dt.TableName.IndexOf("Joint_Inventory_Contains_Associates_0") > -1)
                            {
                                for (j = 0; j < dt.Rows.Count; j++)
                                {
                                    Sheet_Data.Add("<Cell><Data ss:Type=\"Number\">" + (j + 1) + "</Data></Cell><Cell><Data ss:Type=\"String\">" + dt.Rows[j][0] + "</Data></Cell><Cell><Data ss:Type=\"String\">" + dt.Rows[j][2] + "</Data></Cell><Cell><Data ss:Type=\"String\">" + dt.Rows[j][1] + "</Data></Cell><Cell><Cell><Data ss:Type=\"String\">" + dt.Rows[j][3] + "</Data></Cell><Cell><Data ss:Type=\"Number\">" + dt.Rows[j][4] + "</Data></Cell>");
                                }
                            }
                            else
                            {
                                for (j = 0; j < dt.Rows.Count; j++)
                                {
                                    Sheet_Data[j] += "<Cell><Data ss:Type=\"Number\">" + dt.Rows[j][4] + "</Data></Cell>";
                                }
                            }
                        }
                        //剔除
                        if (dt.TableName.IndexOf("Joint_Inventory_Elimination_of_joint_venture") > -1)
                        {
                            if (dt.TableName.IndexOf("Joint_Inventory_Elimination_of_joint_venture_0") > -1)
                            {
                                for (j = 0; j < dt.Rows.Count; j++)
                                {
                                    Sheet_Data.Add("<Cell><Data ss:Type=\"Number\">" + (j + 1) + "</Data></Cell><Cell><Data ss:Type=\"String\">" + dt.Rows[j][0] + "</Data></Cell><Cell><Data ss:Type=\"String\">" + dt.Rows[j][2] + "</Data></Cell><Cell><Data ss:Type=\"String\">" + dt.Rows[j][1] + "</Data></Cell><Cell><Cell><Data ss:Type=\"String\">" + dt.Rows[j][3] + "</Data></Cell><Cell><Data ss:Type=\"Number\">" + dt.Rows[j][4] + "</Data></Cell>");
                                }
                            }
                            else
                            {
                                for (j = 0; j < dt.Rows.Count; j++)
                                {
                                    Sheet_Data[j] += "<Cell><Data ss:Type=\"Number\">" + dt.Rows[j][4] + "</Data></Cell>";
                                }
                            }
                        }
                        //仅联营
                        if (dt.TableName.IndexOf("Joint_Inventory_Only_associates") > -1)
                        {
                            if (dt.TableName.IndexOf("Joint_Inventory_Only_associates_0") > -1)
                            {
                                for (j = 0; j < dt.Rows.Count; j++)
                                {
                                    Sheet_Data.Add("<Cell><Data ss:Type=\"Number\">" + (j + 1) + "</Data></Cell><Cell><Data ss:Type=\"String\">" + dt.Rows[j][0] + "</Data></Cell><Cell><Data ss:Type=\"String\">" + dt.Rows[j][2] + "</Data></Cell><Cell><Data ss:Type=\"String\">" + dt.Rows[j][1] + "</Data></Cell><Cell><Cell><Data ss:Type=\"String\">" + dt.Rows[j][3] + "</Data></Cell><Cell><Data ss:Type=\"Number\">" + dt.Rows[j][4] + "</Data></Cell>");
                                }
                            }
                            else
                            {
                                for (j = 0; j < dt.Rows.Count; j++)
                                {
                                    Sheet_Data[j] += "<Cell><Data ss:Type=\"Number\">" + dt.Rows[j][4] + "</Data></Cell>";
                                }
                            }
                        }
                    }
                    for (j = 0; j < Sheet_Data.Count; j++)
                    {
                        Sheet_Body += "<Row ss:AutoFitHeight=\"0\">" + Sheet_Data[j].ToString() + "</Row>";
                    }
                    Sheet_a = string.Format(Sheet_a, Sheet_Head + Sheet_Body);
                    SheetStr = string.Format(SheetStr, Sheet_a);

                    StrToFile(SheetStr, FilePath, FileName, Encoding.UTF8, bDate);
                }

                GeneralConfigInfo config = GeneralConfigs.GetConfig();

                string FileURL = FilePath + FileName;

                return FileURL;

            }
            catch
            {
                return "";
            }
        }
        public static bool getJointInventoryDetails_ToMail(DateTime bDate, int sType, string toEmail)
        {
            string FileURL = getJointInventoryDetailsFile(bDate, sType);
            if (FileURL.Trim() != "")
            {
                GeneralConfigInfo config = GeneralConfigs.GetConfig();
                UsersUtils.SendMailToEmail(toEmail.Trim(), config.CompanyName + " " + bDate.Year + "年" + bDate.Month + "月 客户库存统计 ", "<b>" + config.CompanyName + " " + bDate.Year + "年" + bDate.Month + "月 客户库存统计</b> <br>请下载:<br><a href=\"" + config.Sysurl + FileURL + "\">" + config.Sysurl + FileURL + "</a><br>若不能下载请复制右侧连接:<br>" + config.Sysurl + FileURL + " 到浏览器地址栏(或下载软件任务栏)下载,下载地址永久有效. ");
                return true;
            }
            else {
                return false;
            }
        }

        /// <summary>
        /// 公司销售每日数据自动发送_副本
        /// </summary>
        /// <param name="toEmail">收件人邮箱</param>
        /// <param name="bDate">开始日期</param>
        /// <param name="eDate">结束日期</param>
        /// 0=客户，1=商品，2=品牌，3=业务员，4=促销员
        public static DataSet getIslandSalesDetails_copy(DateTime bDate)
        {
            GeneralConfigInfo config = GeneralConfigs.GetConfig();
            DataSet ds = new DataSet();
            int dType = 5;

            bDate = Convert.ToDateTime(bDate.ToString("yyyy-MM-dd"));
            //获取每月的第一天
            DateTime mbDate = bDate.AddDays(-(bDate.Day) + 1);
            //计算两个时间之间的天数
            //TimeSpan tSpan = (TimeSpan)(bDate - mbDate);
            //然后将其转换为int类型
            int dCount = bDate.Day;

            if (dCount == 0)
            {
                for (int m = 0; m < dType; m++)
                {
                    if (m == 0)
                    {
                        //GetCustomers_DataAnalysis
                        DataTable eList = tbStoresInfo.getSalesExportData(bDate, m);
                        DataTable dt = eList.Copy();
                        dt.TableName = "Company_sales_data_custorm_0-" + bDate.ToString("yyyy-MM-dd");
                        ds.Tables.Add(dt);
                    }
                    if (m == 1)
                    {
                        DataTable eList = tbStoresInfo.getSalesExportData(bDate, m);
                        DataTable dt = eList.Copy();
                        dt.TableName = "Company_sales_data_goods_0-" + bDate.ToString("yyyy-MM-dd");
                        ds.Tables.Add(dt);
                    }
                    if (m == 2)
                    {
                        DataTable eList = tbStoresInfo.getSalesExportData(bDate, m);
                        DataTable dt = eList.Copy();
                        dt.TableName = "Company_sales_data_brand_0-" + bDate.ToString("yyyy-MM-dd");
                        ds.Tables.Add(dt);
                    }
                    if (m == 3)
                    {
                        DataTable eList = tbStoresInfo.getSalesExportData(bDate, m);
                        DataTable dt = eList.Copy();
                        dt.TableName = "Company_sales_data_staff_0-" + bDate.ToString("yyyy-MM-dd");
                        ds.Tables.Add(dt);
                    }
                    if (m == 4)
                    {
                        DataTable eList = tbStoresInfo.getSalesExportData(bDate, m);
                        DataTable dt = eList.Copy();
                        dt.TableName = "Company_sales_data_promotion_0-" + bDate.ToString("yyyy-MM-dd");
                        ds.Tables.Add(dt);
                    }
                }
            }
            else
            {
                for (int m = 0; m < dType; m++)
                {
                    if (m == 0)
                    {
                        for (int i = 0; i < dCount; i++)
                        {
                            DataTable eList = tbStoresInfo.getSalesExportData(mbDate, m);
                            DataTable dt = eList.Copy();
                            dt.TableName = "Company_sales_data_custorm_" + i + "-" + mbDate.ToString("yyyy-MM-dd");
                            ds.Tables.Add(dt);
                            mbDate = mbDate.AddDays(1);
                        }
                    }
                    if (m == 1)
                    {
                        mbDate = bDate.AddDays(-(bDate.Day) + 1);
                        for (int i = 0; i < dCount; i++)
                        {
                            DataTable eList = tbStoresInfo.getSalesExportData(mbDate, m);
                            DataTable dt = eList.Copy();
                            dt.TableName = "Company_sales_data_goods_" + i + "-" + mbDate.ToString("yyyy-MM-dd");
                            ds.Tables.Add(dt);
                            mbDate = mbDate.AddDays(1);
                        }
                    }
                    if (m == 2)
                    {
                        mbDate = bDate.AddDays(-(bDate.Day) + 1);
                        for (int i = 0; i < dCount; i++)
                        {
                            DataTable eList = tbStoresInfo.getSalesExportData(mbDate, m);
                            DataTable dt = eList.Copy();
                            dt.TableName = "Company_sales_data_brand_" + i + "-" + mbDate.ToString("yyyy-MM-dd");
                            ds.Tables.Add(dt);
                            mbDate = mbDate.AddDays(1);
                        }
                    }
                    if (m == 3)
                    {
                        mbDate = bDate.AddDays(-(bDate.Day) + 1);
                        for (int i = 0; i < dCount; i++)
                        {
                            DataTable eList = tbStoresInfo.getSalesExportData(mbDate, m);
                            DataTable dt = eList.Copy();
                            dt.TableName = "Company_sales_data_staff_" + i + "-" + mbDate.ToString("yyyy-MM-dd");
                            ds.Tables.Add(dt);
                            mbDate = mbDate.AddDays(1);
                        }
                    }
                    if (m == 4)
                    {
                        mbDate = bDate.AddDays(-(bDate.Day) + 1);
                        for (int i = 0; i < dCount; i++)
                        {
                            DataTable eList = tbStoresInfo.getSalesExportData(mbDate, m);
                            DataTable dt = eList.Copy();
                            dt.TableName = "Company_sales_data_promotion_" + i + "-" + mbDate.ToString("yyyy-MM-dd");
                            ds.Tables.Add(dt);
                            mbDate = mbDate.AddDays(1);
                        }
                    }
                }
            }
            return ds;
        }
        public static string getIslandSalesDetailsFile(DateTime bDate)
        {
            try
            {
                int cDay = bDate.Day;

                string FilePath = "/Data/ExportData/" + bDate.Year + "-" + bDate.Month + "/";
                string FileName = bDate.Year + "年" + bDate.Month + "月 公司销售统计.xls";

                string file_str = Utils.GetMapPath(@"\\") + FilePath + FileName;
                if (CheckFileIsDay(file_str))
                {
                    string SheetStr = "";
                    string Sheet_Custorms = "";//客户
                    string Sheet_Custorms_Head = "";
                    string Sheet_Custorms_Head_b = "";
                    string Sheet_Custorms_Body = "";
                    ArrayList Sheet_Custorms_Data = new ArrayList();

                    string Sheet_Staff = "";//业务员
                    string Sheet_Staff_Head = "";
                    string Sheet_Staff_Head_b = "";
                    string Sheet_Staff_Body = "";
                    ArrayList Sheet_Staff_Data = new ArrayList();

                    string Sheet_Sales_Promotion = "";//促销员
                    string Sheet_Sales_Promotion_Head = "";
                    string Sheet_Sales_Promotion_Head_b = "";
                    string Sheet_Sales_Promotion_Body = "";
                    ArrayList Sheet_Sales_Promotion_Data = new ArrayList();

                    string Sheet_Goods = "";//商品
                    string Sheet_Goods_Head = "";
                    string Sheet_Goods_Head_b = "";
                    string Sheet_Goods_Body = "";
                    ArrayList Sheet_Goods_Data = new ArrayList();

                    string Sheet_Brand = "";//品牌
                    string Sheet_Brand_Head = "";
                    string Sheet_Brand_Head_b = "";
                    string Sheet_Brand_Body = "";
                    ArrayList Sheet_Brand_Data = new ArrayList();



                    SheetStr = "<?xml version=\"1.0\"?>" +
                                        "<Workbook xmlns=\"urn:schemas-microsoft-com:office:spreadsheet\" " +
                                         "xmlns:o=\"urn:schemas-microsoft-com:office:office\" " +
                                         "xmlns:x=\"urn:schemas-microsoft-com:office:excel\" " +
                                         "xmlns:ss=\"urn:schemas-microsoft-com:office:spreadsheet\" " +
                                         "xmlns:html=\"http://www.w3.org/TR/REC-html40\">" +
                                        "<Styles>" +
                                      "<Style ss:ID=\"Default\" ss:Name=\"Normal\">" +
                                       "<Alignment ss:Vertical=\"Center\"/>" +
                                       "<Borders/>" +
                                       "<Font ss:FontName=\"宋体\" x:CharSet=\"134\" ss:Size=\"11\" ss:Color=\"#000000\"/>" +
                                       "<Interior/>" +
                                       "<NumberFormat/>" +
                                       "<Protection/>" +
                                      "</Style>" +
                                      "<Style ss:ID=\"s62\">" +
                                      " <Alignment ss:Horizontal=\"Center\" ss:Vertical=\"Center\"/>" +
                                      "</Style>" +
                                     "</Styles>" +
                                        "{0}</Workbook>";
                    Sheet_Custorms = "<Worksheet ss:Name=\"客户\"><Table>{0}</Table></Worksheet>";
                    Sheet_Staff = "<Worksheet ss:Name=\"业务员\"><Table>{0}</Table></Worksheet>";
                    Sheet_Sales_Promotion = "<Worksheet ss:Name=\"促销员\"><Table>{0}</Table></Worksheet>";
                    Sheet_Goods = "<Worksheet ss:Name=\"商品\"><Table>{0}</Table></Worksheet>";
                    Sheet_Brand = "<Worksheet ss:Name=\"品牌\"><Table>{0}</Table></Worksheet>";

                    int i = 0;
                    //表头
                    for (i = 1; i <= cDay; i++)
                    {
                        Sheet_Custorms_Head += "<Cell ss:MergeAcross=\"1\" ss:StyleID=\"s62\"><Data ss:Type=\"String\">" + bDate.Month + "-" + i + "</Data></Cell>";
                        Sheet_Staff_Head += "<Cell ss:MergeAcross=\"1\" ss:StyleID=\"s62\"><Data ss:Type=\"String\">" + bDate.Month + "-" + i + "</Data></Cell>";
                        Sheet_Sales_Promotion_Head += "<Cell ss:MergeAcross=\"1\" ss:StyleID=\"s62\"><Data ss:Type=\"String\">" + bDate.Month + "-" + i + "</Data></Cell>";
                        Sheet_Goods_Head += "<Cell ss:MergeAcross=\"1\" ss:StyleID=\"s62\"><Data ss:Type=\"String\">" + bDate.Month + "-" + i + "</Data></Cell>";
                        Sheet_Brand_Head += "<Cell ss:MergeAcross=\"1\" ss:StyleID=\"s62\" ><Data ss:Type=\"String\">" + bDate.Month + "-" + i + "</Data></Cell>";
                    }
                    //第二行少一格
                    for (i = 1; i < cDay; i++)
                    {
                        Sheet_Custorms_Head_b += "<Cell ss:StyleID=\"s62\"><Data ss:Type=\"String\">数量</Data></Cell><Cell ss:StyleID=\"s62\"><Data ss:Type=\"String\">金额</Data></Cell>";
                        Sheet_Staff_Head_b += "<Cell ss:StyleID=\"s62\"><Data ss:Type=\"String\">数量</Data></Cell><Cell ss:StyleID=\"s62\"><Data ss:Type=\"String\">金额</Data></Cell>";
                        Sheet_Sales_Promotion_Head_b += "<Cell ss:StyleID=\"s62\"><Data ss:Type=\"String\">数量</Data></Cell><Cell ss:StyleID=\"s62\"><Data ss:Type=\"String\">金额</Data></Cell>";
                        Sheet_Goods_Head_b += "<Cell ss:StyleID=\"s62\"><Data ss:Type=\"String\">数量</Data></Cell><Cell ss:StyleID=\"s62\"><Data ss:Type=\"String\">金额</Data></Cell>";
                        Sheet_Brand_Head_b += "<Cell ss:StyleID=\"s62\"><Data ss:Type=\"String\">数量</Data></Cell><Cell ss:StyleID=\"s62\"><Data ss:Type=\"String\">金额</Data></Cell>";
                    }
                    Sheet_Custorms_Head = "<Row ss:AutoFitHeight=\"0\"><Cell ss:MergeDown=\"1\" ss:StyleID=\"s62\"><Data ss:Type=\"String\">序号</Data></Cell><Cell ss:MergeDown=\"1\" ss:StyleID=\"s62\"><Data ss:Type=\"String\">客户</Data></Cell>" + Sheet_Custorms_Head + "</Row><Row ss:AutoFitHeight=\"0\"><Cell ss:Index=\"3\" ss:StyleID=\"s62\"><Data ss:Type=\"String\">数量</Data></Cell><Cell ss:StyleID=\"s62\"><Data ss:Type=\"String\" >金额</Data></Cell>" + Sheet_Custorms_Head_b + "</Row>";
                    Sheet_Staff_Head = "<Row ss:AutoFitHeight=\"0\"><Cell ss:MergeDown=\"1\" ss:StyleID=\"s62\"><Data ss:Type=\"String\">序号</Data></Cell><Cell ss:MergeDown=\"1\" ss:StyleID=\"s62\"><Data ss:Type=\"String\">业务员</Data></Cell>" + Sheet_Staff_Head + "</Row><Row ss:AutoFitHeight=\"0\"><Cell ss:Index=\"3\" ss:StyleID=\"s62\"><Data ss:Type=\"String\">数量</Data></Cell><Cell ss:StyleID=\"s62\"><Data ss:Type=\"String\">金额</Data></Cell>" + Sheet_Staff_Head_b + "</Row>";
                    Sheet_Sales_Promotion_Head = "<Row ss:AutoFitHeight=\"0\"><Cell ss:MergeDown=\"1\" ss:StyleID=\"s62\"><Data ss:Type=\"String\">序号</Data></Cell><Cell ss:MergeDown=\"1\" ss:StyleID=\"s62\" ><Data ss:Type=\"String\">促销员</Data></Cell>" + Sheet_Sales_Promotion_Head + "</Row><Row ss:AutoFitHeight=\"0\"><Cell ss:Index=\"3\" ss:StyleID=\"s62\"><Data ss:Type=\"String\">数量</Data></Cell><Cell ss:StyleID=\"s62\"><Data ss:Type=\"String\">金额</Data></Cell>" + Sheet_Sales_Promotion_Head_b + "</Row>";
                    Sheet_Goods_Head = "<Row ss:AutoFitHeight=\"0\"><Cell ss:MergeDown=\"1\" ss:StyleID=\"s62\"><Data ss:Type=\"String\">序号</Data></Cell><Cell ss:MergeDown=\"1\" ss:StyleID=\"s62\"><Data ss:Type=\"String\">商品名称</Data></Cell>" + Sheet_Goods_Head + "</Row><Row ss:AutoFitHeight=\"0\"><Cell ss:Index=\"3\" ss:StyleID=\"s62\"><Data ss:Type=\"String\">数量</Data></Cell><Cell ss:StyleID=\"s62\" ><Data ss:Type=\"String\">金额</Data></Cell>" + Sheet_Goods_Head_b + "</Row>";
                    Sheet_Brand_Head = "<Row ss:AutoFitHeight=\"0\"><Cell ss:MergeDown=\"1\" ss:StyleID=\"s62\"><Data ss:Type=\"String\">序号</Data></Cell><Cell ss:MergeDown=\"1\" ss:StyleID=\"s62\"><Data ss:Type=\"String\">品牌</Data></Cell>" + Sheet_Brand_Head + "</Row><Row ss:AutoFitHeight=\"0\"><Cell ss:Index=\"3\" ss:StyleID=\"s62\"><Data ss:Type=\"String\">数量</Data></Cell><Cell ss:StyleID=\"s62\"><Data ss:Type=\"String\">金额</Data></Cell>" + Sheet_Brand_Head_b + "</Row>";

                    DataSet ds = getIslandSalesDetails_copy(bDate);

                    int j = 0;
                    foreach (DataTable dt in ds.Tables)
                    {
                        #region 客户
                        if (dt.TableName.IndexOf("Company_sales_data_custorm") > -1)
                        {
                            if (dt.TableName.IndexOf("Company_sales_data_custorm_0") > -1)//第一天,需取第一列
                            {
                                for (j = 0; j < dt.Rows.Count; j++)
                                {
                                    Sheet_Custorms_Data.Add("<Cell><Data ss:Type=\"Number\">" + (j + 1) + "</Data></Cell><Cell><Data ss:Type=\"String\">" + dt.Rows[j][1] + "</Data></Cell><Cell><Data ss:Type=\"Number\">" + dt.Rows[j][2] + "</Data></Cell><Cell><Data ss:Type=\"Number\">" + dt.Rows[j][3] + "</Data></Cell>");
                                }
                            }
                            else
                            {
                                for (j = 0; j < dt.Rows.Count; j++)
                                {
                                    Sheet_Custorms_Data[j] += "<Cell><Data ss:Type=\"Number\">" + dt.Rows[j][2] + "</Data></Cell><Cell><Data ss:Type=\"Number\">" + dt.Rows[j][3] + "</Data></Cell>";
                                }
                            }
                        }
                        #endregion
                        #region 业务员
                        if (dt.TableName.IndexOf("Company_sales_data_staff") > -1)
                        {
                            if (dt.TableName.IndexOf("Company_sales_data_staff_0") > -1)//第一天,需取第一列
                            {
                                for (j = 0; j < dt.Rows.Count; j++)
                                {
                                    Sheet_Staff_Data.Add("<Cell><Data ss:Type=\"Number\">" + (j + 1) + "</Data></Cell><Cell><Data ss:Type=\"String\">" + dt.Rows[j][1] + "</Data></Cell><Cell><Data ss:Type=\"Number\">" + dt.Rows[j][2] + "</Data></Cell><Cell><Data ss:Type=\"Number\">" + dt.Rows[j][3] + "</Data></Cell>");
                                }
                            }
                            else
                            {
                                for (j = 0; j < dt.Rows.Count; j++)
                                {
                                    Sheet_Staff_Data[j] += "<Cell><Data ss:Type=\"Number\">" + dt.Rows[j][2] + "</Data></Cell><Cell><Data ss:Type=\"Number\">" + dt.Rows[j][3] + "</Data></Cell>";
                                }
                            }
                        }
                        #endregion
                        #region 促销员
                        if (dt.TableName.IndexOf("Company_sales_data_promotion") > -1)
                        {
                            if (dt.TableName.IndexOf("Company_sales_data_promotion_0") > -1)//第一天,需取第一列
                            {
                                for (j = 0; j < dt.Rows.Count; j++)
                                {
                                    Sheet_Sales_Promotion_Data.Add("<Cell><Data ss:Type=\"Number\">" + (j + 1) + "</Data></Cell><Cell><Data ss:Type=\"String\">" + dt.Rows[j][1] + "</Data></Cell><Cell><Data ss:Type=\"Number\">" + dt.Rows[j][2] + "</Data></Cell><Cell><Data ss:Type=\"Number\">" + dt.Rows[j][3] + "</Data></Cell>");
                                }
                            }
                            else
                            {
                                for (j = 0; j < dt.Rows.Count; j++)
                                {
                                    Sheet_Sales_Promotion_Data[j] += "<Cell><Data ss:Type=\"Number\">" + dt.Rows[j][2] + "</Data></Cell><Cell><Data ss:Type=\"Number\">" + dt.Rows[j][3] + "</Data></Cell>";
                                }
                            }
                        }
                        #endregion
                        #region 商品
                        if (dt.TableName.IndexOf("Company_sales_data_goods") > -1)
                        {
                            if (dt.TableName.IndexOf("Company_sales_data_goods_0") > -1)//第一天,需取第一列
                            {
                                for (j = 0; j < dt.Rows.Count; j++)
                                {
                                    Sheet_Goods_Data.Add("<Cell><Data ss:Type=\"Number\">" + (j + 1) + "</Data></Cell><Cell><Data ss:Type=\"String\">" + dt.Rows[j][1] + "</Data></Cell><Cell><Data ss:Type=\"Number\">" + dt.Rows[j][2] + "</Data></Cell><Cell><Data ss:Type=\"Number\">" + dt.Rows[j][3] + "</Data></Cell>");
                                }
                            }
                            else
                            {
                                for (j = 0; j < dt.Rows.Count; j++)
                                {
                                    Sheet_Goods_Data[j] += "<Cell><Data ss:Type=\"Number\">" + dt.Rows[j][2] + "</Data></Cell><Cell><Data ss:Type=\"Number\">" + dt.Rows[j][3] + "</Data></Cell>";
                                }
                            }
                        }
                        #endregion
                        #region 品牌
                        if (dt.TableName.IndexOf("Company_sales_data_brand") > -1)
                        {
                            if (dt.TableName.IndexOf("Company_sales_data_brand_0") > -1)//第一天,需取第一列
                            {
                                for (j = 0; j < dt.Rows.Count; j++)
                                {
                                    Sheet_Brand_Data.Add("<Cell><Data ss:Type=\"Number\">" + (j + 1) + "</Data></Cell><Cell><Data ss:Type=\"String\">" + dt.Rows[j][0] + "</Data></Cell><Cell><Data ss:Type=\"Number\">" + dt.Rows[j][1] + "</Data></Cell><Cell><Data ss:Type=\"Number\">" + dt.Rows[j][2] + "</Data></Cell>");
                                }
                            }
                            else
                            {
                                for (j = 0; j < dt.Rows.Count; j++)
                                {
                                    Sheet_Brand_Data[j] += "<Cell><Data ss:Type=\"Number\">" + dt.Rows[j][1] + "</Data></Cell><Cell><Data ss:Type=\"Number\">" + dt.Rows[j][2] + "</Data></Cell>";
                                }
                            }
                        }
                        #endregion
                    }

                    for (j = 0; j < Sheet_Custorms_Data.Count; j++)
                    {
                        Sheet_Custorms_Body += "<Row ss:AutoFitHeight=\"0\">" + Sheet_Custorms_Data[j].ToString() + "</Row>";
                    }
                    for (j = 0; j < Sheet_Staff_Data.Count; j++)
                    {
                        Sheet_Staff_Body += "<Row ss:AutoFitHeight=\"0\">" + Sheet_Staff_Data[j].ToString() + "</Row>";
                    }
                    for (j = 0; j < Sheet_Sales_Promotion_Data.Count; j++)
                    {
                        Sheet_Sales_Promotion_Body += "<Row ss:AutoFitHeight=\"0\">" + Sheet_Sales_Promotion_Data[j].ToString() + "</Row>";
                    }
                    for (j = 0; j < Sheet_Goods_Data.Count; j++)
                    {
                        Sheet_Goods_Body += "<Row ss:AutoFitHeight=\"0\">" + Sheet_Goods_Data[j].ToString() + "</Row>";
                    }
                    for (j = 0; j < Sheet_Brand_Data.Count; j++)
                    {
                        Sheet_Brand_Body += "<Row ss:AutoFitHeight=\"0\">" + Sheet_Brand_Data[j].ToString() + "</Row>";
                    }
                    Sheet_Custorms = string.Format(Sheet_Custorms, Sheet_Custorms_Head + Sheet_Custorms_Body);
                    Sheet_Staff = string.Format(Sheet_Staff, Sheet_Staff_Head + Sheet_Staff_Body);
                    Sheet_Sales_Promotion = string.Format(Sheet_Sales_Promotion, Sheet_Sales_Promotion_Head + Sheet_Sales_Promotion_Body);
                    Sheet_Goods = string.Format(Sheet_Goods, Sheet_Goods_Head + Sheet_Goods_Body);
                    Sheet_Brand = string.Format(Sheet_Brand, Sheet_Brand_Head + Sheet_Brand_Body);

                    SheetStr = string.Format(SheetStr, Sheet_Custorms + Sheet_Staff + Sheet_Sales_Promotion + Sheet_Goods + Sheet_Brand);

                    StrToFile(SheetStr, FilePath, FileName, Encoding.UTF8, bDate);
                }
                string FileURL = FilePath + FileName;

                return FileURL;
            }
            catch
            {
                return "";
            }
        }
        public static bool getIslandSalesDetails_ToMail(DateTime bDate, string toEmail)
        {
            string FileURL = getIslandSalesDetailsFile(bDate);
            if (FileURL.Trim() != "")
            {
                GeneralConfigInfo config = GeneralConfigs.GetConfig();
                UsersUtils.SendMailToEmail(toEmail.Trim(), config.CompanyName + " " + bDate.Year + "年" + bDate.Month + "月 公司销售统计 ", "<b>" + config.CompanyName + " " + bDate.Year + "年" + bDate.Month + "月 公司销售统计</b> <br>请下载:<br><a href=\"" + config.Sysurl + FileURL + "\">" + config.Sysurl + FileURL + "</a><br>若不能下载请复制右侧连接:<br>" + config.Sysurl + FileURL + " 到浏览器地址栏(或下载软件任务栏)下载,下载地址永久有效. ");
                return true;
            }
            else {
                return false;
            }
        }
        /// <summary>
        /// 公司出货月数据自动发送邮件_副本
        /// </summary>
        /// <param name="toEmail">收件人邮箱</param>
        /// <param name="bDate">开始日期</param>
        /// <param name="checkValue">0=单品；1=客户；2=品牌；3=区域；4=业务员</param>
        public static DataSet getIslandShipmentDetails_copy(DateTime bDate)
        {
            GeneralConfigInfo config = GeneralConfigs.GetConfig();

            //获取每月的第一天
            DateTime mbDate = bDate.AddDays(-(bDate.Day) + 1);
            //计算两个时间之间的天数
            //TimeSpan tSpan = (TimeSpan)(bDate - mbDate);
            //然后将其转换为int类型
            int dCount = bDate.Day;// Convert.ToInt32(tSpan.Days.ToString());
            int checkValue = 5;
            DataSet ds = new DataSet();

            if (dCount == 0)
            {

                for (int i = 0; i < checkValue; i++)
                {
                    DataTable dcList = DataUtils.getReportOutExport(bDate, i);
                    DataTable dt = dcList.Copy();
                    if (i == 0)
                    {
                        dt.TableName = "Ship_the_goods_0-" + bDate.ToString("yyyy-MM-dd");
                    }
                    if (i == 1)
                    {
                        dt.TableName = "Ship_the_custorms_0-" + bDate.ToString("yyyy-MM-dd");
                    }
                    if (i == 2)
                    {
                        dt.TableName = "Ship_the_brand_0-" + bDate.ToString("yyyy-MM-dd");
                    }
                    if (i == 3)
                    {
                        dt.TableName = "Ship_the_region_0-" + bDate.ToString("yyyy-MM-dd");
                    }
                    if (i == 4)
                    {
                        dt.TableName = "Ship_the_staff_0-" + bDate.ToString("yyyy-MM-dd");
                    }
                    ds.Tables.Add(dt);
                }
            }
            else
            {

                for (int i = 0; i < checkValue; i++)
                {
                    //单品
                    if (i == 0)
                    {
                        for (int j = 0; j < dCount; j++)
                        {
                            DataTable dcList = DataUtils.getReportOutExport(mbDate, i);
                            DataTable dt = dcList.Copy();
                            dt.TableName = "Ship_the_goods_" + j + "-" + mbDate.ToString("yyyy-MM-dd");
                            ds.Tables.Add(dt);

                            mbDate = mbDate.AddDays(1);
                        }
                    }
                    //客户
                    if (i == 1)
                    {
                        mbDate = bDate.AddDays(-(bDate.Day) + 1);
                        for (int j = 0; j < dCount; j++)
                        {
                            DataTable dcList = DataUtils.getReportOutExport(mbDate, i);
                            DataTable dt = dcList.Copy();
                            dt.TableName = "Ship_the_custorms_" + j + "-" + mbDate.ToString("yyyy-MM-dd");
                            ds.Tables.Add(dt);

                            mbDate = mbDate.AddDays(1);
                        }
                    }
                    //品牌
                    if (i == 2)
                    {
                        mbDate = bDate.AddDays(-(bDate.Day) + 1);
                        for (int j = 0; j < dCount; j++)
                        {
                            DataTable dcList = DataUtils.getReportOutExport(mbDate, i);
                            DataTable dt = dcList.Copy();
                            dt.TableName = "Ship_the_brand_" + j + "-" + mbDate.ToString("yyyy-MM-dd");
                            ds.Tables.Add(dt);

                            mbDate = mbDate.AddDays(1);
                        }
                    }
                    //区域
                    if (i == 3)
                    {
                        mbDate = bDate.AddDays(-(bDate.Day) + 1);
                        for (int j = 0; j < dCount; j++)
                        {
                            DataTable dcList = DataUtils.getReportOutExport(mbDate, i);
                            DataTable dt = dcList.Copy();
                            dt.TableName = "Ship_the_region_" + j + "-" + mbDate.ToString("yyyy-MM-dd");
                            ds.Tables.Add(dt);

                            mbDate = mbDate.AddDays(1);
                        }
                    }
                    //业务员
                    if (i == 4)
                    {
                        mbDate = bDate.AddDays(-(bDate.Day) + 1);
                        for (int j = 0; j < dCount; j++)
                        {
                            DataTable dcList = DataUtils.getReportOutExport(mbDate, i);
                            DataTable dt = dcList.Copy();
                            dt.TableName = "Ship_the_staff_" + j + "-" + mbDate.ToString("yyyy-MM-dd");
                            ds.Tables.Add(dt);

                            mbDate = mbDate.AddDays(1);
                        }
                    }
                }
            }
            return ds;
        }
        public static string getIslandShipmentDetailsFile(DateTime bDate)
        {
            try
            {
                int cDay = bDate.Day;
                string FilePath = "/Data/ExportData/" + bDate.Year + "-" + bDate.Month + "/";
                string FileName = bDate.Year + "年" + bDate.Month + "月 公司出货统计.xls";

                string file_str = Utils.GetMapPath(@"\\") + FilePath + FileName;
                if (CheckFileIsDay(file_str))
                {
                    string SheetStr = "";

                    string Sheet_Custorms = "";//客户
                    string Sheet_Custorms_Head = "";
                    string Sheet_Custorms_Body = "";
                    ArrayList Sheet_Custorms_Data = new ArrayList();

                    string Sheet_Staff = "";//业务员
                    string Sheet_Staff_Head = "";
                    string Sheet_Staff_Body = "";
                    ArrayList Sheet_Staff_Data = new ArrayList();

                    string Sheet_Goods = "";//商品
                    string Sheet_Goods_Head = "";
                    string Sheet_Goods_Head_b = "";
                    string Sheet_Goods_Body = "";
                    ArrayList Sheet_Goods_Data = new ArrayList();

                    string Sheet_Brand = "";//品牌
                    string Sheet_Brand_Head = "";
                    string Sheet_Brand_Body = "";
                    ArrayList Sheet_Brand_Data = new ArrayList();

                    string Sheet_Region = "";//地区
                    string Sheet_Region_Head = "";
                    string Sheet_Region_Body = "";
                    ArrayList Sheet_Region_Data = new ArrayList();



                    SheetStr = "<?xml version=\"1.0\"?>" +
                                        "<Workbook xmlns=\"urn:schemas-microsoft-com:office:spreadsheet\" " +
                                         "xmlns:o=\"urn:schemas-microsoft-com:office:office\" " +
                                         "xmlns:x=\"urn:schemas-microsoft-com:office:excel\" " +
                                         "xmlns:ss=\"urn:schemas-microsoft-com:office:spreadsheet\" " +
                                         "xmlns:html=\"http://www.w3.org/TR/REC-html40\">" +
                                        "<Styles>" +
                                      "<Style ss:ID=\"Default\" ss:Name=\"Normal\">" +
                                       "<Alignment ss:Vertical=\"Center\"/>" +
                                       "<Borders/>" +
                                       "<Font ss:FontName=\"宋体\" x:CharSet=\"134\" ss:Size=\"11\" ss:Color=\"#000000\"/>" +
                                       "<Interior/>" +
                                       "<NumberFormat/>" +
                                       "<Protection/>" +
                                      "</Style>" +
                                      "<Style ss:ID=\"s62\">" +
                                      " <Alignment ss:Horizontal=\"Center\" ss:Vertical=\"Center\"/>" +
                                      "</Style>" +
                                     "</Styles>" +
                                        "{0}</Workbook>";
                    Sheet_Custorms = "<Worksheet ss:Name=\"客户\"><Table>{0}</Table></Worksheet>";
                    Sheet_Staff = "<Worksheet ss:Name=\"业务员\"><Table>{0}</Table></Worksheet>";
                    Sheet_Region = "<Worksheet ss:Name=\"地区\"><Table>{0}</Table></Worksheet>";
                    Sheet_Goods = "<Worksheet ss:Name=\"商品\"><Table>{0}</Table></Worksheet>";
                    Sheet_Brand = "<Worksheet ss:Name=\"品牌\"><Table>{0}</Table></Worksheet>";

                    int i = 0;
                    //表头
                    for (i = 1; i <= cDay; i++)
                    {
                        Sheet_Custorms_Head += "<Cell><Data ss:Type=\"String\">" + bDate.Month + "-" + i + "</Data></Cell>";
                        Sheet_Staff_Head += "<Cell><Data ss:Type=\"String\">" + bDate.Month + "-" + i + "</Data></Cell>";
                        Sheet_Region_Head += "<Cell><Data ss:Type=\"String\">" + bDate.Month + "-" + i + "</Data></Cell>";
                        Sheet_Goods_Head += "<Cell ss:MergeAcross=\"1\" ss:StyleID=\"s62\"><Data ss:Type=\"String\">" + bDate.Month + "-" + i + "</Data></Cell>";
                        Sheet_Brand_Head += "<Cell><Data ss:Type=\"String\">" + bDate.Month + "-" + i + "</Data></Cell>";
                    }
                    //第二行少一格
                    for (i = 1; i < cDay; i++)
                    {
                        //Sheet_Custorms_Head_b += "<Cell ss:StyleID=\"s62\"><Data ss:Type=\"String\">数量</Data></Cell><Cell ss:StyleID=\"s62\"><Data ss:Type=\"String\">金额</Data></Cell>";
                        //Sheet_Staff_Head_b += "<Cell ss:StyleID=\"s62\"><Data ss:Type=\"String\">数量</Data></Cell><Cell ss:StyleID=\"s62\"><Data ss:Type=\"String\">金额</Data></Cell>";
                        //Sheet_Region_Head_b += "<Cell ss:StyleID=\"s62\"><Data ss:Type=\"String\">数量</Data></Cell><Cell ss:StyleID=\"s62\"><Data ss:Type=\"String\">金额</Data></Cell>";
                        Sheet_Goods_Head_b += "<Cell ss:StyleID=\"s62\"><Data ss:Type=\"String\">数量</Data></Cell><Cell ss:StyleID=\"s62\"><Data ss:Type=\"String\">金额</Data></Cell>";
                        //Sheet_Brand_Head_b += "<Cell ss:StyleID=\"s62\"><Data ss:Type=\"String\">数量</Data></Cell><Cell ss:StyleID=\"s62\"><Data ss:Type=\"String\">金额</Data></Cell>";
                    }
                    Sheet_Custorms_Head = "<Row ss:AutoFitHeight=\"0\"><Cell><Data ss:Type=\"String\">序号</Data></Cell><Cell><Data ss:Type=\"String\">客户</Data></Cell>" + Sheet_Custorms_Head + "</Row>";
                    Sheet_Staff_Head = "<Row ss:AutoFitHeight=\"0\"><Cell><Data ss:Type=\"String\">序号</Data></Cell><Cell><Data ss:Type=\"String\">业务员</Data></Cell>" + Sheet_Staff_Head + "</Row>";
                    Sheet_Region_Head = "<Row ss:AutoFitHeight=\"0\"><Cell><Data ss:Type=\"String\">序号</Data></Cell><Cell ><Data ss:Type=\"String\">地区</Data></Cell>" + Sheet_Region_Head + "</Row>";
                    Sheet_Goods_Head = "<Row ss:AutoFitHeight=\"0\"><Cell ss:MergeDown=\"1\" ss:StyleID=\"s62\"><Data ss:Type=\"String\">序号</Data></Cell><Cell ss:MergeDown=\"1\" ss:StyleID=\"s62\"><Data ss:Type=\"String\">商品名称</Data></Cell>" + Sheet_Goods_Head + "</Row><Row ss:AutoFitHeight=\"0\"><Cell ss:Index=\"3\" ss:StyleID=\"s62\"><Data ss:Type=\"String\">数量</Data></Cell><Cell ss:StyleID=\"s62\" ><Data ss:Type=\"String\">金额</Data></Cell>" + Sheet_Goods_Head_b + "</Row>";
                    Sheet_Brand_Head = "<Row ss:AutoFitHeight=\"0\"><Cell><Data ss:Type=\"String\">序号</Data></Cell><Cell><Data ss:Type=\"String\">品牌</Data></Cell>" + Sheet_Brand_Head + "</Row>";

                    DataSet ds = getIslandShipmentDetails_copy(bDate);

                    int j = 0;
                    foreach (DataTable dt in ds.Tables)
                    {
                        #region 客户
                        if (dt.TableName.IndexOf("Ship_the_custorms") > -1)
                        {
                            if (dt.TableName.IndexOf("Ship_the_custorms_0") > -1)//第一天,需取第一列
                            {
                                for (j = 0; j < dt.Rows.Count; j++)
                                {
                                    Sheet_Custorms_Data.Add("<Cell><Data ss:Type=\"Number\">" + (j + 1) + "</Data></Cell><Cell><Data ss:Type=\"String\">" + dt.Rows[j][1] + "</Data></Cell><Cell><Data ss:Type=\"Number\">" + dt.Rows[j][3] + "</Data></Cell>");
                                }
                            }
                            else
                            {
                                for (j = 0; j < dt.Rows.Count; j++)
                                {
                                    Sheet_Custorms_Data[j] += "<Cell><Data ss:Type=\"Number\">" + dt.Rows[j][3] + "</Data></Cell>";
                                }
                            }
                        }
                        #endregion
                        #region 业务员
                        if (dt.TableName.IndexOf("Ship_the_staff") > -1)
                        {
                            if (dt.TableName.IndexOf("Ship_the_staff_0") > -1)//第一天,需取第一列
                            {
                                for (j = 0; j < dt.Rows.Count; j++)
                                {
                                    Sheet_Staff_Data.Add("<Cell><Data ss:Type=\"Number\">" + (j + 1) + "</Data></Cell><Cell><Data ss:Type=\"String\">" + dt.Rows[j][1] + "</Data></Cell><Cell><Data ss:Type=\"Number\">" + dt.Rows[j][3] + "</Data></Cell>");
                                }
                            }
                            else
                            {
                                for (j = 0; j < dt.Rows.Count; j++)
                                {
                                    Sheet_Staff_Data[j] += "<Cell><Data ss:Type=\"Number\">" + dt.Rows[j][3] + "</Data></Cell>";
                                }
                            }
                        }
                        #endregion
                        #region 地区
                        if (dt.TableName.IndexOf("Ship_the_region") > -1)
                        {
                            if (dt.TableName.IndexOf("Ship_the_region_0") > -1)//第一天,需取第一列
                            {
                                for (j = 0; j < dt.Rows.Count; j++)
                                {
                                    Sheet_Region_Data.Add("<Cell><Data ss:Type=\"Number\">" + (j + 1) + "</Data></Cell><Cell><Data ss:Type=\"String\">" + dt.Rows[j][1] + "</Data></Cell><Cell><Data ss:Type=\"Number\">" + dt.Rows[j][3] + "</Data></Cell>");
                                }
                            }
                            else
                            {
                                for (j = 0; j < dt.Rows.Count; j++)
                                {
                                    Sheet_Region_Data[j] += "<Cell><Data ss:Type=\"Number\">" + dt.Rows[j][3] + "</Data></Cell>";
                                }
                            }
                        }
                        #endregion
                        #region 商品
                        if (dt.TableName.IndexOf("Ship_the_goods") > -1)
                        {
                            if (dt.TableName.IndexOf("Ship_the_goods_0") > -1)//第一天,需取第一列
                            {
                                for (j = 0; j < dt.Rows.Count; j++)
                                {
                                    Sheet_Goods_Data.Add("<Cell><Data ss:Type=\"Number\">" + (j + 1) + "</Data></Cell><Cell><Data ss:Type=\"String\">" + dt.Rows[j][1] + "</Data></Cell><Cell><Data ss:Type=\"Number\">" + dt.Rows[j][2] + "</Data></Cell><Cell><Data ss:Type=\"Number\">" + dt.Rows[j][3] + "</Data></Cell>");
                                }
                            }
                            else
                            {
                                for (j = 0; j < dt.Rows.Count; j++)
                                {
                                    Sheet_Goods_Data[j] += "<Cell><Data ss:Type=\"Number\">" + dt.Rows[j][2] + "</Data></Cell><Cell><Data ss:Type=\"Number\">" + dt.Rows[j][3] + "</Data></Cell>";
                                }
                            }
                        }
                        #endregion
                        #region 品牌
                        if (dt.TableName.IndexOf("Ship_the_brand") > -1)
                        {
                            if (dt.TableName.IndexOf("Ship_the_brand_0") > -1)//第一天,需取第一列
                            {
                                for (j = 0; j < dt.Rows.Count; j++)
                                {
                                    Sheet_Brand_Data.Add("<Cell><Data ss:Type=\"Number\">" + (j + 1) + "</Data></Cell><Cell><Data ss:Type=\"String\">" + dt.Rows[j][0] + "</Data></Cell><Cell><Data ss:Type=\"Number\">" + dt.Rows[j][2] + "</Data></Cell>");
                                }
                            }
                            else
                            {
                                for (j = 0; j < dt.Rows.Count; j++)
                                {
                                    Sheet_Brand_Data[j] += "<Cell><Data ss:Type=\"Number\">" + dt.Rows[j][2] + "</Data></Cell>";
                                }
                            }
                        }
                        #endregion
                    }

                    for (j = 0; j < Sheet_Custorms_Data.Count; j++)
                    {
                        Sheet_Custorms_Body += "<Row ss:AutoFitHeight=\"0\">" + Sheet_Custorms_Data[j].ToString() + "</Row>";
                    }
                    for (j = 0; j < Sheet_Staff_Data.Count; j++)
                    {
                        Sheet_Staff_Body += "<Row ss:AutoFitHeight=\"0\">" + Sheet_Staff_Data[j].ToString() + "</Row>";
                    }
                    for (j = 0; j < Sheet_Region_Data.Count; j++)
                    {
                        Sheet_Region_Body += "<Row ss:AutoFitHeight=\"0\">" + Sheet_Region_Data[j].ToString() + "</Row>";
                    }
                    for (j = 0; j < Sheet_Goods_Data.Count; j++)
                    {
                        Sheet_Goods_Body += "<Row ss:AutoFitHeight=\"0\">" + Sheet_Goods_Data[j].ToString() + "</Row>";
                    }
                    for (j = 0; j < Sheet_Brand_Data.Count; j++)
                    {
                        Sheet_Brand_Body += "<Row ss:AutoFitHeight=\"0\">" + Sheet_Brand_Data[j].ToString() + "</Row>";
                    }
                    Sheet_Custorms = string.Format(Sheet_Custorms, Sheet_Custorms_Head + Sheet_Custorms_Body);
                    Sheet_Staff = string.Format(Sheet_Staff, Sheet_Staff_Head + Sheet_Staff_Body);
                    Sheet_Region = string.Format(Sheet_Region, Sheet_Region_Head + Sheet_Region_Body);
                    Sheet_Goods = string.Format(Sheet_Goods, Sheet_Goods_Head + Sheet_Goods_Body);
                    Sheet_Brand = string.Format(Sheet_Brand, Sheet_Brand_Head + Sheet_Brand_Body);

                    SheetStr = string.Format(SheetStr, Sheet_Custorms + Sheet_Staff + Sheet_Region + Sheet_Goods + Sheet_Brand);
                    StrToFile(SheetStr, FilePath, FileName, Encoding.UTF8, bDate);
                }
                string FileURL = FilePath + FileName;
                 return FileURL;
            }
            catch
            {
                return "";
            }
        }
        public static bool getIslandShipmentDetails_ToMail(DateTime bDate, string toEmail)
        {
            string FileURL = getIslandShipmentDetailsFile(bDate);
            if (FileURL.Trim() != "")
            {
                GeneralConfigInfo config = GeneralConfigs.GetConfig();

                UsersUtils.SendMailToEmail(toEmail.Trim(), config.CompanyName + " " + bDate.Year + "年" + bDate.Month + "月 公司出货统计 ", "<b>" + config.CompanyName + " " + bDate.Year + "年" + bDate.Month + "月 公司出货统计</b> <br>请下载:<br><a href=\"" + config.Sysurl + FileURL + "\">" + config.Sysurl + FileURL + "</a><br>若不能下载请复制右侧连接:<br>" + config.Sysurl + FileURL + " 到浏览器地址栏(或下载软件任务栏)下载,下载地址永久有效. ");
                return true;
            }
            else
            {
                return false;
            }
        }
        
        /// <summary>
        /// 仓库库存自动发送邮件_副本
        /// </summary>
        /// <param name="toEmail">收件人邮件</param>
        /// <param name="StorageID">门店ID=0</param>
        /// <param name="sDate">查询日期</param>
        /// <param name="ProductID">产品ID=0</param>
        public static DataSet getStockDetails_copy(DateTime sDate, int StorageID)
        {
            GeneralConfigInfo config = GeneralConfigs.GetConfig();
            //获取每月的第一天
            DateTime mbDate = sDate.AddDays(-(sDate.Day) + 1);
            //计算两个时间之间的天数
            //TimeSpan tSpan = (TimeSpan)(sDate - mbDate);
            //然后将其转换为int类型
            int dCount = sDate.Day;// Convert.ToInt32(tSpan.Days.ToString());

            int ProductID = 0;
            DataSet dset = new DataSet();

            if (dCount == 0)
            {
                DataTable dList = tbProductsInfo.GetProductsStorageInfoByStorageID_XP(StorageID, sDate, ProductID);
                DataTable dt = dList.Copy();
                dt.Columns.RemoveAt(0);
                dt.Columns.RemoveAt(0);
                dt.Columns.RemoveAt(7);
                dt.Columns.RemoveAt(7);
                dt.Columns.RemoveAt(7);
                //dt.Columns.RemoveAt(6);
                dt.Columns["sName"].SetOrdinal(0);
                dt.TableName = "Real_time_inventory_0-" + sDate.ToString("yyyy-MM-dd");
                dset.Tables.Add(dt);
            }
            else
            {
                for (int i = 0; i < dCount; i++)
                {
                    DataTable dList = tbProductsInfo.GetProductsStorageInfoByStorageID_XP(StorageID, mbDate, ProductID);
                    DataTable dt = dList.Copy();
                    dt.Columns.RemoveAt(0);
                    dt.Columns.RemoveAt(0);
                    dt.Columns.RemoveAt(7);
                    dt.Columns.RemoveAt(7);
                    dt.Columns.RemoveAt(7);
                    //dt.Columns.RemoveAt(6);
                    dt.Columns["sName"].SetOrdinal(0);
                    dt.TableName = "Real_time_inventory_" + i + "-" + mbDate.ToString("yyyy-MM-dd");
                    dset.Tables.Add(dt);
                    mbDate = mbDate.AddDays(1);
                }
            }
            return dset;
        }
        public static string getStockDetailsFile(DateTime bDate)
        {
            int cDay = bDate.Day;

            string FilePath = "/Data/ExportData/" + bDate.Year + "-" + bDate.Month + "/";
            string FileName = bDate.Year + "年" + bDate.Month + "月 实时库存统计.xls";
            string file_str = Utils.GetMapPath(@"\\") + FilePath + FileName;

            try
            {


                if (CheckFileIsDay(file_str))
                {
                    string SheetStr = "";
                    string Sheet_Head = "";
                    string Sheet_Body = "";

                    string Sheet_a = "";
                    ArrayList Sheet_Data = new ArrayList();

                    SheetStr = "<?xml version=\"1.0\"?>" +
                                       "<Workbook xmlns=\"urn:schemas-microsoft-com:office:spreadsheet\" " +
                                        "xmlns:o=\"urn:schemas-microsoft-com:office:office\" " +
                                        "xmlns:x=\"urn:schemas-microsoft-com:office:excel\" " +
                                        "xmlns:ss=\"urn:schemas-microsoft-com:office:spreadsheet\" " +
                                        "xmlns:html=\"http://www.w3.org/TR/REC-html40\">" +
                                       "<Styles>" +
                                     "<Style ss:ID=\"Default\" ss:Name=\"Normal\">" +
                                      "<Alignment ss:Vertical=\"Center\"/>" +
                                      "<Borders/>" +
                                      "<Font ss:FontName=\"宋体\" x:CharSet=\"134\" ss:Size=\"11\" ss:Color=\"#000000\"/>" +
                                      "<Interior/>" +
                                      "<NumberFormat/>" +
                                      "<Protection/>" +
                                     "</Style>" +
                                     "<Style ss:ID=\"s62\">" +
                                     " <Alignment ss:Horizontal=\"Center\" ss:Vertical=\"Center\"/>" +
                                     "</Style>" +
                                    "</Styles>" +
                                       "{0}</Workbook>";
                    int i = 0;
                    //表头
                    for (i = 1; i <= cDay; i++)
                    {
                        Sheet_Head += "<Cell ss:StyleID=\"s62\"><Data ss:Type=\"String\">" + bDate.Month + "-" + i + "</Data></Cell>";
                    }
                    Sheet_Head = "<Row ss:AutoFitHeight=\"0\"><Cell><Data ss:Type=\"String\">序号</Data></Cell>" +
                        "<Cell><Data ss:Type=\"String\">商品分类</Data></Cell>" +
                        "<Cell><Data ss:Type=\"String\">条码</Data></Cell>" +
                        "<Cell><Data ss:Type=\"String\">商品名称</Data></Cell>" +
                        "<Cell><Data ss:Type=\"String\">默认销售价格</Data></Cell>" + Sheet_Head + "</Row>";

                    DataTable _dt = tbStorageInfo.GetStorageInfoList(" sState = 0 ").Tables[0];
                    DataSet ds = new DataSet();
                    int j = 0;
                    for (int k = 0; k < _dt.Rows.Count; k++)
                    {
                        Sheet_a += "<Worksheet ss:Name=\"仓库-" + _dt.Rows[k]["sName"].ToString() + "\"><Table>{0}</Table></Worksheet>";

                        ds = getStockDetails_copy(bDate, Convert.ToInt32(_dt.Rows[k][0].ToString()));

                        foreach (DataTable dt in ds.Tables)
                        {
                            if (dt.TableName.IndexOf("Real_time_inventory_0") > -1)//第一天,需取第一列
                            {
                                for (j = 0; j < dt.Rows.Count; j++)
                                {
                                    Sheet_Data.Add("<Cell><Data ss:Type=\"Number\">" + (j + 1) + "</Data></Cell><Cell><Data ss:Type=\"String\">" + dt.Rows[j]["ProductClassName"] + "</Data></Cell><Cell><Data ss:Type=\"String\">" + dt.Rows[j]["pBarcode"] + "</Data></Cell><Cell><Data ss:Type=\"String\">" + dt.Rows[j]["pName"] + "</Data></Cell><Cell><Data ss:Type=\"Number\">" + dt.Rows[j]["pSellingPrice"] + "</Data></Cell><Cell><Data ss:Type=\"Number\">" + (Convert.ToDecimal(dt.Rows[j]["pStorage"].ToString()) + Convert.ToDecimal(dt.Rows[j]["pStorageIn"].ToString()) - Convert.ToDecimal(dt.Rows[j]["pStorageOut"].ToString()) + Convert.ToDecimal(dt.Rows[j]["Beginning"].ToString())).ToString() + "</Data></Cell>");
                                }
                            }
                            else
                            {
                                for (j = 0; j < dt.Rows.Count; j++)
                                {
                                    Sheet_Data[j] += "<Cell><Data ss:Type=\"Number\">" + (Convert.ToDecimal(dt.Rows[j]["pStorage"].ToString()) + Convert.ToDecimal(dt.Rows[j]["pStorageIn"].ToString()) - Convert.ToDecimal(dt.Rows[j]["pStorageOut"].ToString()) + Convert.ToDecimal(dt.Rows[j]["Beginning"].ToString())).ToString() + "</Data></Cell>";
                                }
                            }
                        }
                        for (j = 0; j < Sheet_Data.Count; j++)
                        {
                            Sheet_Body += "<Row ss:AutoFitHeight=\"0\">" + Sheet_Data[j].ToString() + "</Row>";
                        }
                        Sheet_a = string.Format(Sheet_a, Sheet_Head + Sheet_Body);

                        Sheet_Data.Clear();
                        Sheet_Body = "";
                    }
                    SheetStr = string.Format(SheetStr, Sheet_a);

                    StrToFile(SheetStr, FilePath, FileName, Encoding.UTF8, bDate);
                }
                string FileURL = FilePath + FileName;
                

                return FileURL;

            }
            catch(Exception ex)
            {
                StrToFile(ex.Message, FilePath, FileName, Encoding.UTF8, bDate);
                return "";
            }
        }
        public static bool getStockDetails_ToMail(DateTime bDate, string toEmail)
        {
            string FileURL = getStockDetailsFile(bDate);
            if (FileURL.Trim() != "")
            {
                GeneralConfigInfo config = GeneralConfigs.GetConfig();
                UsersUtils.SendMailToEmail(toEmail.Trim(), config.CompanyName + " " + bDate.Year + "年" + bDate.Month + "月 实时库存统计 ", "<b>" + config.CompanyName + " " + bDate.Year + "年" + bDate.Month + "月 实时库存统计</b> <br>请下载:<br><a href=\"" + config.Sysurl + FileURL + "\">" + config.Sysurl + FileURL + "</a><br>若不能下载请复制右侧连接:<br>" + config.Sysurl + FileURL + " 到浏览器地址栏(或下载软件任务栏)下载,下载地址永久有效. ");
                return true;
            }
            else {
                return false;
            }
        }

        
        /// <summary>
        /// 发送客户销售,联营库存,公司销售,公司出货,仓库库存
        /// </summary>
        /// <param name="bDate"></param>
        /// <param name="toEmail"></param>
        /// <returns></returns>
        public static bool getAll_ToMail(DateTime bDate, string toEmail)
        {
            try
            {
                GeneralConfigInfo config = GeneralConfigs.GetConfig();

                string StorageSalesDetailsFile = getStorageSalesDetailsFile(bDate.ToString("yyyy-MM-dd"));
                //string JointInventoryDetailsFile = getJointInventoryDetailsFile(bDate, 1);
                string SalesDetailsFile = getIslandSalesDetailsFile(bDate);
                string ShipmentDetailsFile = getIslandShipmentDetailsFile(bDate);
                string StockDetailsFile = "";// getStockDetailsFile(bDate);

                string MailBody = "";
                if (StorageSalesDetailsFile.Trim() != "")
                {
                    MailBody += "<br><b>客户销售数据</b>请下载:<br><a href=\"" + config.Sysurl + StorageSalesDetailsFile + "\">" + config.Sysurl + StorageSalesDetailsFile + "</a><br>若不能下载请复制右侧连接:<br>" + config.Sysurl + StorageSalesDetailsFile + " 到浏览器地址栏(或下载软件任务栏)下载,下载地址永久有效. <br>";
                }
                //if (JointInventoryDetailsFile.Trim() != "")
                //{
                //    MailBody += "<br><b>联营库存数据</b>请下载:<br><a href=\"" + config.Sysurl + JointInventoryDetailsFile + "\">" + config.Sysurl + JointInventoryDetailsFile + "</a><br>若不能下载请复制右侧连接:<br>" + config.Sysurl + JointInventoryDetailsFile + " 到浏览器地址栏(或下载软件任务栏)下载,下载地址永久有效. <br>";
               // }
                if (SalesDetailsFile.Trim() != "")
                {
                    MailBody += "<br><b>公司销售数据</b>请下载:<br><a href=\"" + config.Sysurl + SalesDetailsFile + "\">" + config.Sysurl + SalesDetailsFile + "</a><br>若不能下载请复制右侧连接:<br>" + config.Sysurl + SalesDetailsFile + " 到浏览器地址栏(或下载软件任务栏)下载,下载地址永久有效. <br>";
                }
                if (ShipmentDetailsFile.Trim() != "")
                {
                    MailBody += "<br><b>公司出货数据</b>请下载:<br><a href=\"" + config.Sysurl + ShipmentDetailsFile + "\">" + config.Sysurl + ShipmentDetailsFile + "</a><br>若不能下载请复制右侧连接:<br>" + config.Sysurl + ShipmentDetailsFile + " 到浏览器地址栏(或下载软件任务栏)下载,下载地址永久有效. <br>";
                }
                if (StockDetailsFile.Trim() != "")
                {
                    MailBody += "<br><b>公司仓库库存数据</b>请下载:<br><a href=\"" + config.Sysurl + StockDetailsFile + "\">" + config.Sysurl + StockDetailsFile + "</a><br>若不能下载请复制右侧连接:<br>" + config.Sysurl + StockDetailsFile + " 到浏览器地址栏(或下载软件任务栏)下载,下载地址永久有效. <br>";
                }

                UsersUtils.SendMailToEmail(toEmail.Trim(), config.CompanyName + " " + bDate.Year + "年" + bDate.Month + "月 数据统计 ", "<b>" + config.CompanyName + " " + bDate.Year + "年" + bDate.Month + "月数据统计</b> " + MailBody);

                return true;
            }
            catch {
                return false;
            }
        }
        #endregion
    }
}
