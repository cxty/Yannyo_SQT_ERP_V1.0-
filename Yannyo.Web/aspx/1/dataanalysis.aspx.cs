using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using Yannyo.Config;
using Yannyo.Common;
using Yannyo.Entity;
using Yannyo.BLL;

using InfoSoftGlobal;
using System.Text;
using System.Drawing;


namespace Yannyo.Web
{
    public partial class dataanalysis : PageBase
    {
        public string Act = "A";
        public int RegionID = Utils.StrToInt(HTTPRequest.GetString("RegionID").Trim(),0);

        public string StoresName = Utils.ChkSQL(HTTPRequest.GetString("StoresName").Trim());
        public int StoresID = Utils.StrToInt(HTTPRequest.GetString("StoresID").Trim(), 0);

        public string StaffName = Utils.ChkSQL(HTTPRequest.GetString("StaffName").Trim());
        public int StaffID = Utils.StrToInt(HTTPRequest.GetString("StaffID").Trim(), 0);

        public string StaffNameB = Utils.ChkSQL(HTTPRequest.GetString("StaffNameB").Trim());
        public int StaffIDB = Utils.StrToInt(HTTPRequest.GetString("StaffIDB").Trim(), 0);

        public string ProductName = Utils.ChkSQL(HTTPRequest.GetString("ProductName").Trim());
        public int ProductID = Utils.StrToInt(HTTPRequest.GetString("ProductID").Trim(), 0);

        public string SupplierName = Utils.ChkSQL(HTTPRequest.GetString("SupplierName").Trim());
        public int SupplierID = Utils.StrToInt(HTTPRequest.GetString("SupplierID").Trim(), 0);

        public string pBrand = Utils.ChkSQL(HTTPRequest.GetString("pBrand").Trim());

        public string bDateTime = Utils.ChkSQL(HTTPRequest.GetString("bDateTime").Trim());
        public string eDateTime = Utils.ChkSQL(HTTPRequest.GetString("eDateTime").Trim());

        public int ShowType = Utils.StrToInt(HTTPRequest.GetString("ShowType").Trim(), 7);
        public int AShowType = Utils.StrToInt(HTTPRequest.GetString("AShowType").Trim(), 0);

        public string A_Value = Utils.ChkSQL(HTTPRequest.GetString("A_Value").Trim());
        public string A_Value_ID = Utils.ChkSQL(HTTPRequest.GetString("A_Value_ID").Trim());

        public string YHsysName = Utils.ChkSQL(HTTPRequest.GetString("YHsysName").Trim());
        public int YHsysID = Utils.StrToInt(HTTPRequest.GetString("YHsysID").Trim(), 0);

        public DataTable fList = new DataTable();
        public DataTable dList = new DataTable();

        public string Region = "";

        //综合报表使用
        public DataTable BankMoneyList = new DataTable();
        public decimal BankMoney_Sum = 0;
        //应收 公司
        public DataTable ARMoney_E_List = new DataTable();
        public decimal ARMoney_E_Sum = 0;
        //应收 个人
        public DataTable ARMoney_P_List = new DataTable();
        public decimal ARMoney_P_Sum = 0;
        //应付 公司
        public DataTable APMoney_E_List = new DataTable();
        public decimal APMoney_E_Sum = 0;
        //应付 个人
        public DataTable APMoney_P_List = new DataTable();
        public decimal APMoney_P_Sum = 0;
        //应收 结算系统
        public DataTable ARMoney_PaySystem_List = new DataTable();
        public decimal APMoney_PaySystem_Sum = 0;
        
        //实时库存
        public DataTable StockDataList = new DataTable();
        public decimal StockData_Sum = 0;

        public string ReHTML = "";

        public decimal AllSumValue = 0;
        public decimal AllSumValue1 = 0;
        public decimal AllSumValue2 = 0;
        public decimal AllSumValue3 = 0;
        public decimal AllSumValue4 = 0;
        public decimal AllSumValue5 = 0;

        public decimal AllSales = 0;
        public decimal AllSalesFees = 0;
        public decimal AllGiftsFees = 0;
        public decimal AllBadgoodsFees = 0;
        public decimal AllReturnsFees = 0;
        public decimal AllCostFees = 0;
        public decimal AllProfit = 0;
        public int ALLS_QUANTITY = 0;

        protected virtual void Page_Load(object sender, EventArgs e)
        {
            
            if (this.userid > 0)
            {
                if (CheckUserPopedoms("X") || CheckUserPopedoms("11"))
                {

                    string Rss_XML_B = "";
                    string Rss_XML_C = "";
                    string Rss_XML_D = "";
                    string Rss_XML_E = "";
                    string Rss_XML = "";
                    string tTitle = "";
                    string tTitleB = "";
                    string tbDateTime = "";
                    string teDateTime = eDateTime + " 23:59:59";
                    
                    decimal tAvValue = 0;
                    int tI = 0;
                    StringBuilder xmlData = new StringBuilder();

                    Act = HTTPRequest.GetString("Act").Trim() != "" ? HTTPRequest.GetString("Act").Trim() : "A";
                    ShowType = (Act == "H1") ? ((ShowType == 7) ? 8 : ShowType) : ShowType;
                    ShowType = (Act == "A") ? ((ShowType == 7) ? 1 : ShowType) : ShowType;
                    ShowType = (Act == "H2") ? ((ShowType == 7) ? 1 : ShowType) : ShowType;
                    if (Act.Length > 1)
                    {
                        ShowType = (Act.IndexOf("E") > -1) ? ((ShowType == 7) ? 2 : ShowType) : ShowType;
                        ShowType = (Act.IndexOf("F") > -1) ? ((ShowType == 7) ? 2 : ShowType) : ShowType;
                    }
                    Region = Caches.GetRegionInfoToHTML();
                    if (ispost)
                    {
                        switch (Act)
                        {
                            case "A":

                                dList = DataUtils.GetSales_analysis(StoresID, StaffID, StaffIDB, pBrand, RegionID, ProductID, YHsysID, DateTime.Parse(bDateTime), DateTime.Parse(teDateTime), ShowType, 1, out AllSumValue);
                                break;
                            case "A1"://客户、门店 
                            case "A2"://业务员 
                            case "A3"://促销务员 
                            case "A4"://产品 
                            case "A5"://品牌
                            case "A6"://系统
                                if (A_Value.Trim() != "" && A_Value_ID.Trim() != "")
                                {


                                    DataTable dt_X = new DataTable();
                                    //制作X轴
                                    DataTable dt = new DataTable();
                                    try
                                    {
                                        dt = DataUtils.GetDateTimeList(DateTime.Parse(bDateTime), DateTime.Parse(teDateTime), ShowType);
                                        if (dt != null)
                                        {
                                            foreach (DataRow dr in dt.Rows)
                                            {
                                                if (ShowType == 1)
                                                {
                                                    tTitleB = "日";
                                                    Rss_XML_B += "<category label='" + DateTime.Parse(dr[0].ToString()).ToShortDateString() + "' /> ";
                                                }
                                                if (ShowType == 2)
                                                {
                                                    tTitleB = "月";
                                                    Rss_XML_B += "<category label='" + DateTime.Parse(dr[0].ToString()).Year.ToString() + "-" + DateTime.Parse(dr[0].ToString()).Month.ToString() + "' /> ";
                                                }
                                                if (ShowType == 3)
                                                {
                                                    tTitleB = "年";
                                                    Rss_XML_B += "<category label='" + DateTime.Parse(dr[0].ToString()).Year.ToString() + "' /> ";
                                                }
                                            }

                                            string[] A_ValueArray = Utils.SplitString(A_Value + ",", ",");
                                            string[] A_Value_IDArray = Utils.SplitString(A_Value_ID + ",", ",");

                                            for (int i = 0; i < A_ValueArray.Length; i++)
                                            {
                                                Rss_XML_D = "";
                                                AllSumValue = 0;
                                                tI = 0;
                                                tAvValue = 0;
                                                if (A_ValueArray[i].Trim() != "")
                                                {
                                                    foreach (DataRow dr in dt.Rows)
                                                    {
                                                        tI++;
                                                        if (ShowType == 1)
                                                        {
                                                            tbDateTime = DateTime.Parse(dr[0].ToString()).ToShortDateString();
                                                            teDateTime = tbDateTime + " 23:59:59";
                                                        }
                                                        if (ShowType == 2)
                                                        {
                                                            tbDateTime = DateTime.Parse(dr[0].ToString()).Year.ToString() + "-" + DateTime.Parse(dr[0].ToString()).Month.ToString() + "-1";
                                                            teDateTime = DateTime.Parse(dr[0].ToString()).Year.ToString() + "-" + DateTime.Parse(dr[0].ToString()).Month.ToString() + "-" + DateTime.Parse(dr[0].ToString()).AddMonths(1).AddDays(-1).Day.ToString() + " 23:59:59";
                                                        }
                                                        if (ShowType == 3)
                                                        {
                                                            tbDateTime = DateTime.Parse(dr[0].ToString()).Year.ToString() + "-1-1";
                                                            teDateTime = DateTime.Parse(dr[0].ToString()).Year.ToString() + "-12-31 23:59:59";
                                                        }

                                                        if (Act == "A1")
                                                        {
                                                            tTitle = "客户、门店";
                                                            dt_X = DataUtils.GetSales_analysis(Utils.StrToInt(A_Value_IDArray[i], 0), StaffID, StaffIDB, pBrand, RegionID, ProductID, YHsysID, DateTime.Parse(tbDateTime), DateTime.Parse(teDateTime), 1, 1, out AllSumValue);
                                                        }
                                                        if (Act == "A2")
                                                        {
                                                            tTitle = "业务员";
                                                            dt_X = DataUtils.GetSales_analysis(StoresID, Utils.StrToInt(A_Value_IDArray[i], 0), StaffIDB, pBrand, RegionID, ProductID, YHsysID, DateTime.Parse(tbDateTime), DateTime.Parse(teDateTime), 2, 1, out AllSumValue);
                                                        }
                                                        if (Act == "A3")
                                                        {
                                                            tTitle = "促销员";
                                                            dt_X = DataUtils.GetSales_analysis(StoresID, Utils.StrToInt(A_Value_IDArray[i], 0), StaffIDB, pBrand, RegionID, ProductID, YHsysID, DateTime.Parse(tbDateTime), DateTime.Parse(teDateTime), 3, 1, out AllSumValue);
                                                        }
                                                        if (Act == "A4")
                                                        {
                                                            tTitle = "产品";
                                                            dt_X = DataUtils.GetSales_analysis(StoresID, StaffID, StaffIDB, pBrand, RegionID, Utils.StrToInt(A_Value_IDArray[i], 0), YHsysID, DateTime.Parse(tbDateTime), DateTime.Parse(teDateTime), 3, 1, out AllSumValue);
                                                        }
                                                        if (Act == "A5")
                                                        {
                                                            tTitle = "品牌";
                                                            dt_X = DataUtils.GetSales_analysis(StoresID, StaffID, StaffIDB, A_Value_IDArray[i], RegionID, ProductID, YHsysID, DateTime.Parse(tbDateTime), DateTime.Parse(teDateTime), 5, 1, out AllSumValue);
                                                        }
                                                        if (Act == "A6")
                                                        {
                                                            tTitle = "系统";
                                                            dt_X = DataUtils.GetSales_analysis(StoresID, StaffID, StaffIDB, pBrand, RegionID, ProductID, Utils.StrToInt(A_Value_IDArray[i], 0), DateTime.Parse(tbDateTime), DateTime.Parse(teDateTime), 5, 1, out AllSumValue);
                                                        }
                                                        Rss_XML_D += "<set value='" + AllSumValue.ToString() + "'/>";
                                                        tAvValue += AllSumValue;

                                                    }
                                                    tAvValue = tAvValue / tI;
                                                    System.Random r = new Random(unchecked((int)DateTime.Now.Millisecond));
                                                    try
                                                    {
                                                        Rss_XML_C += "<dataset seriesName='" + A_ValueArray[i] + "(" + tTitleB + "均" + tAvValue.ToString("C") + ")' showValues='0' >" + Rss_XML_D + "</dataset>";
                                                        Rss_XML_E += "<line startValue='" + tAvValue + "'  color='" + Color.FromArgb(r.Next(10, 200), r.Next(10, 200), r.Next(10, 200)).Name + "'  displayValue='" + A_ValueArray[i].Trim() + "(" + tAvValue.ToString("C") + ")' showOnTop='1'/>";
                                                    }
                                                    finally
                                                    {
                                                        r = null;
                                                    }
                                                }
                                            }
                                            Rss_XML = "<chart palette='2' showBorder='1' caption='" + tTitle + " 销售数据分析' yAxisName='销售额' numberPrefix='￥' baseFontSize='12' yAxisMinValue='0' shownames='1' formatNumberScale='0' decimals='0' showvalues='0' useRoundEdges='1' legendBorderAlpha='0'>" +
                                                        "<categories>" + Rss_XML_B + "</categories>" + Rss_XML_C + "<trendlines>" + Rss_XML_E + "</trendlines></chart>";
                                            xmlData.Append(Rss_XML);
                                            ReHTML = FusionCharts.RenderChartHTML("public/Charts/ScrollColumn2D.swf", "", xmlData.ToString(), "myNext", "100%", "500", false);
                                        }
                                    }
                                    finally
                                    {
                                        dt_X.Clear();
                                        dt.Clear();
                                    }
                                }
                                break;
                            case "E"://利润
                                if (bDateTime.Trim() != "" && eDateTime.Trim() != "")
                                {
                                    teDateTime = eDateTime + " 23:59:59";
                                    if (AShowType == 0)//饼图
                                    {
                                        dList = DataUtils.GetErpData_analysis(DateTime.Parse(bDateTime), DateTime.Parse(teDateTime), ShowType);
                                        if (ShowType == 7)
                                        {
                                            if (dList != null)
                                            {
                                                tAvValue = Convert.ToDecimal(dList.Rows[0][0]) - Convert.ToDecimal(dList.Rows[0][1]) - Convert.ToDecimal(dList.Rows[0][5]) - Convert.ToDecimal(dList.Rows[0][6]);
                                                Rss_XML_B = "" +
                                                            "<set label='成本(" + Convert.ToDecimal(dList.Rows[0][1]).ToString("C") + ")' value='" + dList.Rows[0][1].ToString() + "' />" +
                                                            "<set label='退货(" + Convert.ToDecimal(dList.Rows[0][2]).ToString("C") + ")' value='" + dList.Rows[0][2].ToString() + "' />" +
                                                            "<set label='坏货(" + Convert.ToDecimal(dList.Rows[0][3]).ToString("C") + ")' value='" + dList.Rows[0][3].ToString() + "' />" +
                                                            "<set label='赠品(" + Convert.ToDecimal(dList.Rows[0][4]).ToString("C") + ")' value='" + dList.Rows[0][4].ToString() + "' />" +
                                                            "<set label='销售费用(" + Convert.ToDecimal(dList.Rows[0][5]).ToString("C") + ")' value='" + dList.Rows[0][5].ToString() + "' />" +
                                                            "<set label='公司费用(" + Convert.ToDecimal(dList.Rows[0][6]).ToString("C") + ")' value='" + dList.Rows[0][6].ToString() + "' />" +
                                                            "<set label='利润(" + tAvValue.ToString("C") + ")' value='" + tAvValue.ToString() + "' />";
                                                Rss_XML = "<chart palette='4' showBorder='1' bgRatio='0,100' bgAngle='360' caption='" + bDateTime + " - " + eDateTime + " 销售额(" + Convert.ToDecimal(dList.Rows[0][0]).ToString("C") + ")利润(" + tAvValue.ToString("C") + ")' startingAngle='70' numberPrefix='￥' baseFontSize='12' yAxisMinValue='0' shownames='1' formatNumberScale='0' decimals='0' showvalues='0' useRoundEdges='1' legendBorderAlpha='0' showPercentageValues='1' showPercentInToolTip='1'>" +
                                                                        "" + Rss_XML_B + "</chart>";
                                                xmlData.Append(Rss_XML);
                                                ReHTML = FusionCharts.RenderChartHTML("public/Charts/Pie3D.swf", "", xmlData.ToString(), "myNext", "100%", "500", false);
                                            }
                                        }
                                        else
                                        {
                                            if (ShowType == 4 || ShowType == 5)
                                            {
                                                foreach (DataRow dr in dList.Rows)
                                                {
                                                    AllSales += Convert.ToDecimal(dr["S_TOTAL"]);
                                                    ALLS_QUANTITY += Convert.ToInt32(dr["S_QUANTITY"]);
                                                    AllBadgoodsFees += Convert.ToDecimal(dr["BadgoodsFees"]);
                                                    AllReturnsFees += Convert.ToDecimal(dr["ReturnsFees"]);
                                                    AllCostFees += Convert.ToDecimal(dr["CostFees"]);
                                                    AllProfit += Convert.ToDecimal(dr["Profit"]);
                                                }
                                            }
                                            else
                                            {
                                                foreach (DataRow dr in dList.Rows)
                                                {
                                                    AllSales += Convert.ToDecimal(dr["Sales"]);
                                                    AllSalesFees += Convert.ToDecimal(dr["SalesFees"]);
                                                    AllGiftsFees += Convert.ToDecimal(dr["GiftsFees"]);
                                                    AllBadgoodsFees += Convert.ToDecimal(dr["BadgoodsFees"]);
                                                    AllReturnsFees += Convert.ToDecimal(dr["ReturnsFees"]);
                                                    AllCostFees += Convert.ToDecimal(dr["CostFees"]);
                                                    AllProfit += Convert.ToDecimal(dr["Profit"]);
                                                }
                                            }
                                        }
                                    }
                                    else//柱状图
                                    {
                                        //制作X轴
                                        DataTable dt = new DataTable();
                                        try
                                        {
                                            dt = DataUtils.GetDateTimeList(DateTime.Parse(bDateTime), DateTime.Parse(teDateTime), AShowType);
                                            if (dt != null)
                                            {
                                                Rss_XML_D = "";
                                                AllSumValue = 0;
                                                tI = 0;
                                                tAvValue = 0;
                                                string eValue_a = "";
                                                string eValue_b = "";
                                                string eValue_c = "";
                                                string eValue_d = "";
                                                string eValue_e = "";

                                                foreach (DataRow dr in dt.Rows)
                                                {
                                                    tI++;

                                                    if (AShowType == 1)
                                                    {
                                                        tbDateTime = DateTime.Parse(dr[0].ToString()).ToShortDateString();
                                                        teDateTime = tbDateTime + " 23:59:59";

                                                        tTitleB = "日";
                                                        Rss_XML_B += "<category label='" + DateTime.Parse(dr[0].ToString()).ToShortDateString() + "' /> ";
                                                    }
                                                    if (AShowType == 2)
                                                    {
                                                        tbDateTime = DateTime.Parse(dr[0].ToString()).Year.ToString() + "-" + DateTime.Parse(dr[0].ToString()).Month.ToString() + "-1";
                                                        teDateTime = DateTime.Parse(dr[0].ToString()).Year.ToString() + "-" + DateTime.Parse(dr[0].ToString()).Month.ToString() + "-" + DateTime.Parse(dr[0].ToString()).AddMonths(1).AddDays(-1).Day.ToString() + " 23:59:59";

                                                        tTitleB = "月";
                                                        Rss_XML_B += "<category label='" + DateTime.Parse(dr[0].ToString()).Year.ToString() + "-" + DateTime.Parse(dr[0].ToString()).Month.ToString() + "' /> ";
                                                    }
                                                    if (AShowType == 3)
                                                    {
                                                        tbDateTime = DateTime.Parse(dr[0].ToString()).Year.ToString() + "-1-1";
                                                        teDateTime = DateTime.Parse(dr[0].ToString()).Year.ToString() + "-12-31 23:59:59";

                                                        tTitleB = "年";
                                                        Rss_XML_B += "<category label='" + DateTime.Parse(dr[0].ToString()).Year.ToString() + "' /> ";
                                                    }


                                                    dList = new DataTable();
                                                    try
                                                    {
                                                        dList = DataUtils.GetErpData_analysis(DateTime.Parse(tbDateTime), DateTime.Parse(teDateTime), ShowType);

                                                        if (dList != null)
                                                        {
                                                            tAvValue = Convert.ToDecimal(dList.Rows[0][0]) - Convert.ToDecimal(dList.Rows[0][1]) - Convert.ToDecimal(dList.Rows[0][5]) - Convert.ToDecimal(dList.Rows[0][6]);

                                                            //销售额
                                                            eValue_a += "<set value='" + Convert.ToDecimal(dList.Rows[0][0]) + "' /> ";

                                                            //成本
                                                            eValue_b += "<set value='" + Convert.ToDecimal(dList.Rows[0][1]) + "' /> ";

                                                            //销售费用
                                                            eValue_c += "<set value='" + Convert.ToDecimal(dList.Rows[0][5]) + "' /> ";

                                                            //公司费用
                                                            eValue_d += "<set value='" + Convert.ToDecimal(dList.Rows[0][6]) + "' /> ";

                                                            //利润
                                                            eValue_e += "<set value='" + tAvValue + "' /> ";
                                                        }
                                                        else
                                                        {
                                                            //销售额
                                                            eValue_a += "<set value='0' /> ";

                                                            //成本
                                                            eValue_b += "<set value='0' /> ";

                                                            //销售费用
                                                            eValue_c += "<set value='0' /> ";

                                                            //公司费用
                                                            eValue_d += "<set value='0' /> ";

                                                            //利润
                                                            eValue_e += "<set value='0' /> ";
                                                        }
                                                    }
                                                    finally
                                                    {
                                                        dList.Dispose();
                                                    }

                                                }

                                                Rss_XML = "<chart showBorder='1' lineThickness='2' areaOverColumns='0' numberPrefix='￥' baseFontSize='12' formatNumberScale='0' decimals='0' shownames='1' showvalues='0' useRoundEdges='1' legendBorderAlpha='0' palette='2' showPercentageValues='1'>" +
                                                            "<categories >" + Rss_XML_B + "</categories>" +
                                                            "<dataset seriesName='销售额' showValues='0' color='f9bb0e'>" + eValue_a + "</dataset>" +
                                                            "<dataset seriesName='成本' showValues='0' color='8cbb00'>" + eValue_b + "</dataset>" +
                                                            "<dataset seriesName='销售费用' showValues='0' color='ff8e4a'>" + eValue_c + "</dataset>" +
                                                            "<dataset seriesName='公司费用' showValues='0' color='009190'>" + eValue_d + "</dataset>" +
                                                            "<dataset seriesName='利润' showValues='0' color='b0d2ff'>" + eValue_e + "</dataset>" +

                                                            //"<dataset seriesName='销售额' renderAs='Line' lineThickness='2' color='f9bb0e'>" + eValue_a + "</dataset>" +
                                                    //"<dataset seriesName='成本' renderAs='Line' lineThickness='2' color='8cbb00'>" + eValue_b + "</dataset>" +
                                                    //"<dataset seriesName='销售费用' renderAs='Line' lineThickness='2' color='ff8e4a'>" + eValue_c + "</dataset>" +
                                                    //"<dataset seriesName='公司费用' renderAs='Line' lineThickness='2' color='009190'>" + eValue_d + "</dataset>" +
                                                            "<dataset seriesName='利润' renderAs='Line' lineThickness='2' color='b0d2ff'>" + eValue_e + "</dataset>" +
                                                            "</chart>";
                                                xmlData.Append(Rss_XML);
                                                ReHTML = FusionCharts.RenderChartHTML("public/Charts/ScrollCombi2D.swf", "", xmlData.ToString(), "myNext", "100%", "500", false);
                                            }
                                            dList = new DataTable();
                                            dList = DataUtils.GetErpData_analysis(DateTime.Parse(bDateTime), DateTime.Parse(teDateTime), ShowType);
                                        }
                                        finally
                                        {
                                            dt.Clear();
                                        }
                                    }
                                }
                                break;
                            case "F"://毛利
                                if (bDateTime.Trim() != "" && eDateTime.Trim() != "")
                                {
                                    teDateTime = eDateTime + " 23:59:59";
                                    if (AShowType == 0)//饼图
                                    {
                                        dList = DataUtils.GetErpData_analysis(DateTime.Parse(bDateTime), DateTime.Parse(teDateTime), ShowType);
                                        if (ShowType == 7)
                                        {
                                            if (dList != null)
                                            {

                                                tAvValue = Convert.ToDecimal(dList.Rows[0][0]) - Convert.ToDecimal(dList.Rows[0][1]) - Convert.ToDecimal(dList.Rows[0][5]);
                                                Rss_XML_B = "" +
                                                            "<set label='成本(" + Convert.ToDecimal(dList.Rows[0][1]).ToString("C") + ")' value='" + dList.Rows[0][1].ToString() + "' />" +
                                                            "<set label='退货(" + Convert.ToDecimal(dList.Rows[0][2]).ToString("C") + ")' value='" + dList.Rows[0][2].ToString() + "' />" +
                                                            "<set label='坏货(" + Convert.ToDecimal(dList.Rows[0][3]).ToString("C") + ")' value='" + dList.Rows[0][3].ToString() + "' />" +
                                                            "<set label='赠品(" + Convert.ToDecimal(dList.Rows[0][4]).ToString("C") + ")' value='" + dList.Rows[0][4].ToString() + "' />" +
                                                            "<set label='销售费用(" + Convert.ToDecimal(dList.Rows[0][5]).ToString("C") + ")' value='" + dList.Rows[0][5].ToString() + "' />" +
                                                            "<set label='毛利(" + tAvValue.ToString("C") + ")' value='" + tAvValue.ToString() + "' />";

                                                Rss_XML = "<chart palette='4' showBorder='1' bgRatio='0,100' bgAngle='360' caption='" + bDateTime + " - " + eDateTime + " 销售额(" + Convert.ToDecimal(dList.Rows[0][0]).ToString("C") + ")毛利(" + tAvValue.ToString("C") + ")' startingAngle='70' numberPrefix='￥' baseFontSize='12' yAxisMinValue='0' shownames='1' formatNumberScale='0' decimals='0' showvalues='0' useRoundEdges='1' legendBorderAlpha='0' showPercentageValues='1' showPercentInToolTip='1' >" +
                                                                        "" + Rss_XML_B + "</chart>";
                                                xmlData.Append(Rss_XML);
                                                ReHTML = FusionCharts.RenderChartHTML("public/Charts/Pie3D.swf", "", xmlData.ToString(), "myNext", "100%", "500", false);
                                            }
                                        }
                                    }
                                    else //柱状图
                                    {
                                        //制作X轴
                                        DataTable dt = new DataTable();
                                        try
                                        {
                                            dt = DataUtils.GetDateTimeList(DateTime.Parse(bDateTime), DateTime.Parse(teDateTime), AShowType);
                                            if (dt != null)
                                            {
                                                Rss_XML_D = "";
                                                AllSumValue = 0;
                                                tI = 0;
                                                tAvValue = 0;
                                                string eValue_a = "";
                                                string eValue_b = "";
                                                string eValue_c = "";
                                                string eValue_e = "";

                                                foreach (DataRow dr in dt.Rows)
                                                {
                                                    tI++;

                                                    if (AShowType == 1)
                                                    {
                                                        tbDateTime = DateTime.Parse(dr[0].ToString()).ToShortDateString();
                                                        teDateTime = tbDateTime + " 23:59:59";

                                                        tTitleB = "日";
                                                        Rss_XML_B += "<category label='" + DateTime.Parse(dr[0].ToString()).ToShortDateString() + "' /> ";
                                                    }
                                                    if (AShowType == 2)
                                                    {
                                                        tbDateTime = DateTime.Parse(dr[0].ToString()).Year.ToString() + "-" + DateTime.Parse(dr[0].ToString()).Month.ToString() + "-1";
                                                        teDateTime = DateTime.Parse(dr[0].ToString()).Year.ToString() + "-" + DateTime.Parse(dr[0].ToString()).Month.ToString() + "-" + DateTime.Parse(dr[0].ToString()).AddMonths(1).AddDays(-1).Day.ToString() + " 23:59:59";

                                                        tTitleB = "月";
                                                        Rss_XML_B += "<category label='" + DateTime.Parse(dr[0].ToString()).Year.ToString() + "-" + DateTime.Parse(dr[0].ToString()).Month.ToString() + "' /> ";
                                                    }
                                                    if (AShowType == 3)
                                                    {
                                                        tbDateTime = DateTime.Parse(dr[0].ToString()).Year.ToString() + "-1-1";
                                                        teDateTime = DateTime.Parse(dr[0].ToString()).Year.ToString() + "-12-31 23:59:59";

                                                        tTitleB = "年";
                                                        Rss_XML_B += "<category label='" + DateTime.Parse(dr[0].ToString()).Year.ToString() + "' /> ";
                                                    }


                                                    dList = new DataTable();
                                                    try
                                                    {
                                                        dList = DataUtils.GetErpData_analysis(DateTime.Parse(tbDateTime), DateTime.Parse(teDateTime), ShowType);

                                                        if (dList != null)
                                                        {
                                                            tAvValue = Convert.ToDecimal(dList.Rows[0][0]) - Convert.ToDecimal(dList.Rows[0][1]) - Convert.ToDecimal(dList.Rows[0][5]);

                                                            //销售额
                                                            eValue_a += "<set value='" + Convert.ToDecimal(dList.Rows[0][0]) + "' /> ";

                                                            //成本
                                                            eValue_b += "<set value='" + Convert.ToDecimal(dList.Rows[0][1]) + "' /> ";

                                                            //销售费用
                                                            eValue_c += "<set value='" + Convert.ToDecimal(dList.Rows[0][5]) + "' /> ";

                                                            //利润
                                                            eValue_e += "<set value='" + tAvValue + "' /> ";
                                                        }
                                                        else
                                                        {
                                                            //销售额
                                                            eValue_a += "<set value='0' /> ";

                                                            //成本
                                                            eValue_b += "<set value='0' /> ";

                                                            //销售费用
                                                            eValue_c += "<set value='0' /> ";

                                                            //利润
                                                            eValue_e += "<set value='0' /> ";
                                                        }
                                                    }
                                                    finally
                                                    {
                                                        dList.Dispose();
                                                    }

                                                }

                                                Rss_XML = "<chart showBorder='1' lineThickness='2' areaOverColumns='0' numberPrefix='￥' baseFontSize='12' formatNumberScale='0' decimals='0' shownames='1' showvalues='0' useRoundEdges='1' legendBorderAlpha='0' palette='2'>" +
                                                            "<categories >" + Rss_XML_B + "</categories>" +
                                                            "<dataset seriesName='销售额' showValues='0' color='f9bb0e'>" + eValue_a + "</dataset>" +
                                                            "<dataset seriesName='成本' showValues='0' color='8cbb00'>" + eValue_b + "</dataset>" +
                                                            "<dataset seriesName='销售费用' showValues='0' color='ff8e4a'>" + eValue_c + "</dataset>" +

                                                            "<dataset seriesName='毛利' showValues='0' color='b0d2ff'>" + eValue_e + "</dataset>" +

                                                            //"<dataset seriesName='销售额' renderAs='Line' lineThickness='2' color='f9bb0e'>" + eValue_a + "</dataset>" +
                                                    //"<dataset seriesName='成本' renderAs='Line' lineThickness='2' color='8cbb00'>" + eValue_b + "</dataset>" +
                                                    //"<dataset seriesName='销售费用' renderAs='Line' lineThickness='2' color='ff8e4a'>" + eValue_c + "</dataset>" +
                                                    //"<dataset seriesName='公司费用' renderAs='Line' lineThickness='2' color='009190'>" + eValue_d + "</dataset>" +
                                                            "<dataset seriesName='毛利' renderAs='Line' lineThickness='2' color='b0d2ff'>" + eValue_e + "</dataset>" +
                                                            "</chart>";
                                                xmlData.Append(Rss_XML);
                                                ReHTML = FusionCharts.RenderChartHTML("public/Charts/ScrollCombi2D.swf", "", xmlData.ToString(), "myNext", "100%", "500", false);
                                            }
                                            dList = new DataTable();
                                            dList = DataUtils.GetErpData_analysis(DateTime.Parse(bDateTime), DateTime.Parse(teDateTime), ShowType);
                                        }
                                        finally
                                        {
                                            dt.Clear();
                                        }
                                    }
                                }
                                break;

                            case "E1"://客户、门店 
                            case "E2"://业务员 
                            case "E3"://促销务员 
                            case "E4"://产品 
                            case "E5"://品牌
                            case "E6"://系统
                            case "F1"://客户、门店 
                            case "F2"://业务员 
                            case "F3"://促销务员 
                            case "F4"://产品 
                            case "F5"://品牌
                            case "F6"://系统
                                string yAxisName = "";
                                //制作X轴
                                DataTable dt_X_b = new DataTable();
                                DataTable dt_b = new DataTable();
                                try
                                {
                                    dt_b = DataUtils.GetDateTimeList(DateTime.Parse(bDateTime), DateTime.Parse(teDateTime), ShowType);
                                    if (dt_b != null)
                                    {
                                        foreach (DataRow dr in dt_b.Rows)
                                        {
                                            if (ShowType == 1)
                                            {
                                                tTitleB = "日";
                                                Rss_XML_B += "<category label='" + DateTime.Parse(dr[0].ToString()).ToShortDateString() + "' /> ";
                                            }
                                            if (ShowType == 2)
                                            {
                                                tTitleB = "月";
                                                Rss_XML_B += "<category label='" + DateTime.Parse(dr[0].ToString()).Year.ToString() + "-" + DateTime.Parse(dr[0].ToString()).Month.ToString() + "' /> ";
                                            }
                                            if (ShowType == 3)
                                            {
                                                tTitleB = "年";
                                                Rss_XML_B += "<category label='" + DateTime.Parse(dr[0].ToString()).Year.ToString() + "' /> ";
                                            }
                                        }

                                        string[] A_ValueArray = Utils.SplitString(A_Value + ",", ",");
                                        string[] A_Value_IDArray = Utils.SplitString(A_Value_ID + ",", ",");

                                        for (int i = 0; i < A_ValueArray.Length; i++)
                                        {
                                            Rss_XML_D = "";
                                            AllSumValue = 0;
                                            tI = 0;
                                            tAvValue = 0;
                                            if (A_ValueArray[i].Trim() != "")
                                            {
                                                foreach (DataRow dr in dt_b.Rows)
                                                {
                                                    tI++;
                                                    AllSumValue = 0;
                                                    if (ShowType == 1)
                                                    {
                                                        tbDateTime = DateTime.Parse(dr[0].ToString()).ToShortDateString();
                                                        teDateTime = tbDateTime + " 23:59:59";
                                                    }
                                                    if (ShowType == 2)
                                                    {
                                                        tbDateTime = DateTime.Parse(dr[0].ToString()).Year.ToString() + "-" + DateTime.Parse(dr[0].ToString()).Month.ToString() + "-1";
                                                        teDateTime = DateTime.Parse(dr[0].ToString()).Year.ToString() + "-" + DateTime.Parse(dr[0].ToString()).Month.ToString() + "-" + DateTime.Parse(dr[0].ToString()).AddMonths(1).AddDays(-1).Day.ToString() + " 23:59:59";
                                                    }
                                                    if (ShowType == 3)
                                                    {
                                                        tbDateTime = DateTime.Parse(dr[0].ToString()).Year.ToString() + "-1-1";
                                                        teDateTime = DateTime.Parse(dr[0].ToString()).Year.ToString() + "-12-31 23:59:59";
                                                    }

                                                    if (Act == "E1" || Act == "F1")
                                                    {
                                                        tTitle = "客户、门店";
                                                        dt_X_b = DataUtils.GetErpData_analysis(DateTime.Parse(bDateTime), DateTime.Parse(teDateTime), 1, Utils.StrToInt(A_Value_IDArray[i], 0), 0, 0, "", 0, 0, 0);
                                                        if (dt_X_b != null)
                                                        {
                                                            if (Act == "E1")
                                                            {
                                                                yAxisName = "利润";
                                                                AllSumValue = decimal.Parse(dt_X_b.Rows[0]["Profit"].ToString());
                                                            }
                                                            if (Act == "F1")
                                                            {
                                                                yAxisName = "毛利";
                                                                AllSumValue = decimal.Parse(dt_X_b.Rows[0]["Sales"].ToString()) - decimal.Parse(dt_X_b.Rows[0]["CostFees"].ToString());
                                                            }
                                                        }
                                                    }
                                                    if (Act == "E2" || Act == "F2")
                                                    {
                                                        tTitle = "业务员";
                                                        dt_X_b = DataUtils.GetErpData_analysis(DateTime.Parse(tbDateTime), DateTime.Parse(teDateTime), 2, 0, Utils.StrToInt(A_Value_IDArray[i], 0), 0, "", 0, 0, 0);
                                                        if (dt_X_b != null)
                                                        {
                                                            if (Act == "E2")
                                                            {
                                                                yAxisName = "利润";
                                                                AllSumValue = decimal.Parse(dt_X_b.Rows[0]["Profit"].ToString());
                                                            }
                                                            if (Act == "F2")
                                                            {
                                                                yAxisName = "毛利";
                                                                AllSumValue = decimal.Parse(dt_X_b.Rows[0]["Sales"].ToString()) - decimal.Parse(dt_X_b.Rows[0]["CostFees"].ToString());
                                                            }
                                                        }
                                                    }
                                                    if (Act == "E3" || Act == "F3")
                                                    {
                                                        tTitle = "促销员";
                                                        dt_X_b = DataUtils.GetErpData_analysis(DateTime.Parse(tbDateTime), DateTime.Parse(teDateTime), 3, 0, 0, Utils.StrToInt(A_Value_IDArray[i], 0), "", 0, 0, 0);
                                                        if (dt_X_b != null)
                                                        {
                                                            if (Act == "E3")
                                                            {
                                                                yAxisName = "利润";
                                                                AllSumValue = decimal.Parse(dt_X_b.Rows[0]["Profit"].ToString());
                                                            }
                                                            if (Act == "F3")
                                                            {
                                                                yAxisName = "毛利";
                                                                AllSumValue = decimal.Parse(dt_X_b.Rows[0]["Sales"].ToString()) - decimal.Parse(dt_X_b.Rows[0]["CostFees"].ToString());
                                                            }
                                                        }
                                                    }
                                                    if (Act == "E4" || Act == "F4")
                                                    {
                                                        tTitle = "产品";
                                                        dt_X_b = DataUtils.GetErpData_analysis(DateTime.Parse(tbDateTime), DateTime.Parse(teDateTime), 4, 0, 0, 0, "", 0, Utils.StrToInt(A_Value_IDArray[i], 0), 0);
                                                        if (dt_X_b != null)
                                                        {
                                                            if (Act == "E4")
                                                            {
                                                                yAxisName = "利润";
                                                                AllSumValue = decimal.Parse(dt_X_b.Rows[0]["Profit"].ToString());
                                                            }
                                                            if (Act == "F4")
                                                            {
                                                                yAxisName = "毛利";
                                                                AllSumValue = decimal.Parse(dt_X_b.Rows[0]["Sales"].ToString()) - decimal.Parse(dt_X_b.Rows[0]["CostFees"].ToString());
                                                            }
                                                        }
                                                    }
                                                    if (Act == "E5" || Act == "F5")
                                                    {
                                                        tTitle = "品牌";
                                                        dt_X_b = DataUtils.GetErpData_analysis(DateTime.Parse(tbDateTime), DateTime.Parse(teDateTime), 5, 0, 0, 0, A_Value_IDArray[i], 0, 0, 0);
                                                        if (dt_X_b != null)
                                                        {
                                                            if (Act == "E5")
                                                            {
                                                                yAxisName = "利润";
                                                                AllSumValue = decimal.Parse(dt_X_b.Rows[0]["Profit"].ToString());
                                                            }
                                                            if (Act == "F5")
                                                            {
                                                                yAxisName = "毛利";
                                                                AllSumValue = decimal.Parse(dt_X_b.Rows[0]["Sales"].ToString()) - decimal.Parse(dt_X_b.Rows[0]["CostFees"].ToString());
                                                            }
                                                        }
                                                    }

                                                    Rss_XML_D += "<set value='" + AllSumValue.ToString() + "'/>";
                                                    tAvValue += AllSumValue;

                                                }
                                                System.Random r = new Random(unchecked((int)DateTime.Now.Millisecond));
                                                try
                                                {
                                                    tAvValue = tAvValue / tI;
                                                    Rss_XML_C += "<dataset seriesName='" + A_ValueArray[i] + "(" + tTitleB + "均" + tAvValue.ToString("C") + ")' showValues='0' >" + Rss_XML_D + "</dataset>";
                                                    Rss_XML_E += "<line startValue='" + tAvValue + "' color='" + Color.FromArgb(r.Next(10, 200), r.Next(10, 200), r.Next(10, 200)).Name + "' displayValue='" + A_ValueArray[i].Trim() + "(" + tAvValue.ToString("C") + ")' showOnTop='1'/>";
                                                }
                                                finally
                                                {
                                                    r = null;
                                                }
                                            }
                                        }
                                        Rss_XML = "<chart palette='2' showBorder='1' caption='" + tTitle + " " + yAxisName + "分析' yAxisName='" + yAxisName + "' numberPrefix='￥' baseFontSize='12' yAxisMinValue='0' shownames='1' formatNumberScale='0' decimals='0' showvalues='0' useRoundEdges='1' legendBorderAlpha='0'>" +
                                                        "<categories>" + Rss_XML_B + "</categories>" + Rss_XML_C + "<trendlines>" + Rss_XML_E + "</trendlines></chart>";
                                        xmlData.Append(Rss_XML);
                                        ReHTML = FusionCharts.RenderChartHTML("public/Charts/ScrollColumn2D.swf", "", xmlData.ToString(), "myNext", "100%", "500", false);
                                    }
                                }
                                finally
                                {
                                    dt_X_b.Clear();
                                    dt_b.Clear();
                                }
                                break;
                            case "H1"://费用,收入
                                ShowType = (ShowType == 7) ? 8 : ShowType;
                                if (bDateTime.Trim() != "" && eDateTime.Trim() != "")
                                {
                                    teDateTime = eDateTime + " 23:59:59";
                                }

                                int mType = (ShowType == 10) ? -1 : (ShowType == 8) ? 1 : 0;
                                dList = DataUtils.Get_Fees_analysis(DateTime.Parse(bDateTime), DateTime.Parse(teDateTime), mType);

                                if (dList != null)
                                {
                                    foreach (DataRow dr in dList.Rows)
                                    {
                                        AllSumValue += Convert.ToDecimal(dr[1]);
                                    }
                                }
                                break;
                            case "H2"://应收应付
                                if (eDateTime.Trim() != "")
                                {
                                    teDateTime = eDateTime + " 23:59:59";
                                }
                                int tObjID = 0;
                                tObjID = (ShowType == 1) ? StoresID : (ShowType == 2 || ShowType == 4) ? StaffID : SupplierID;
                                dList = DataUtils.GetAPARMoney(ShowType, DateTime.Parse(teDateTime), tObjID);
                                if (dList != null)
                                {
                                    foreach (DataRow dr in dList.Rows)
                                    {
                                        if (ShowType == 1 || ShowType == 2)
                                        {
                                            AllSumValue1 += Convert.ToDecimal(dr["ASumAMoney"]);
                                            AllSumValue2 += Convert.ToDecimal(dr["BSumAMoney"]);
                                            AllSumValue3 += Convert.ToDecimal(dr["BSumBMoney"]);
                                            AllSumValue4 += Convert.ToDecimal(dr["BSumActualMoney"]);
                                            AllSumValue5 += Convert.ToDecimal(dr["SYMoney"]);
                                        }
                                        if (ShowType == 3 || ShowType == 4)
                                        {
                                            AllSumValue1 += Convert.ToDecimal(dr["SumPMoney"]);
                                            AllSumValue2 += Convert.ToDecimal(dr["SumPayMoney"]);
                                            AllSumValue3 += Convert.ToDecimal(dr["SumOtherMoney"]);
                                            AllSumValue4 += Convert.ToDecimal(dr["SYMoney"]);
                                        }
                                    }
                                }
                                break;
                            case "H3"://库存
                                if (eDateTime.Trim() != "")
                                {
                                    teDateTime = eDateTime + " 23:59:59";
                                }
                                dList = DataUtils.GetStock_analysis(0, DateTime.Parse(teDateTime), ProductID);
                                if (dList != null)
                                {
                                    foreach (DataRow dr in dList.Rows)
                                    {
                                        AllSumValue += Convert.ToDecimal(dr["sumPrice"]);
                                    }
                                }
                                break;
                            case "H4"://现金银行
                                int year = 0;
                                int month = 0;
                                if (teDateTime.Trim() != "")
                                {
                                    year = DateTime.Parse(teDateTime).Year;
                                    month = DateTime.Parse(teDateTime).Month;
                                }
                                else
                                {
                                    year = DateTime.Now.Year;
                                    month = DateTime.Now.Month;
                                }

                                DateTime firstDayOfThisMonth = new DateTime(year, month, 1);
                                DateTime lastDayOfThisMonth = new DateTime(year, month, DateTime.DaysInMonth(year, month));

                                fList = tbBankInfo.GetBankList(" 1=1 order by bAppendTime desc").Tables[0];
                                dList = tbBankMoneyInfo.GetBankMoneyTable(firstDayOfThisMonth, lastDayOfThisMonth, 0);

                                break;
                            case "H5"://固定资产
                                break;
                            case "H6"://净资产
                                if (eDateTime.Trim() != "")
                                {
                                    teDateTime = eDateTime + " 23:59:59";
                                }
                                dList = DataUtils.GetNetAssets(DateTime.Parse(teDateTime));
                                break;
                            case "H"://综合报表
                                if (eDateTime.Trim() != "")
                                {
                                    teDateTime = eDateTime + " 23:59:59";
                                }
                                BankMoneyList = tbBankMoneyInfo.GetBankMoneyTableByOneDay(DateTime.Parse(teDateTime));

                                ARMoney_E_List = DataUtils.GetAPARMoney(1, DateTime.Parse(teDateTime), 0);
                                ARMoney_P_List = DataUtils.GetAPARMoney(2, DateTime.Parse(teDateTime), 0);
                                APMoney_E_List = DataUtils.GetAPARMoney(3, DateTime.Parse(teDateTime), 0);
                                APMoney_P_List = DataUtils.GetAPARMoney(4, DateTime.Parse(teDateTime), 0);

                                ARMoney_PaySystem_List = DataUtils.GetAPARMoney(5, DateTime.Parse(teDateTime), 0);

                                StockDataList = DataUtils.GetStock_analysis(0, DateTime.Parse(teDateTime), 0);

                                break;
                        }
                    }

                }
                else
                {
                    AddErrLine("权限不足!");
                }
            }
            else
            {
                AddErrLine("请先登录!");
                SetBackLink("login.aspx?referer=" + Utils.UrlEncode(Utils.GetUrlReferrer()));
                SetMetaRefresh(1, "login.aspx?referer=" + Utils.UrlEncode(Utils.GetUrlReferrer()));
            }
        }
        protected override void ShowPage()
        {
            pagetitle = " 数据分析";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}
