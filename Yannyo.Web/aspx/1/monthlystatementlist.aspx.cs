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

namespace Yannyo.Web
{
    public partial class monthlystatementlist : PageBase
    {
        public DataTable dList = new DataTable();
        public DataTable sStepsList = new DataTable();//步骤
        public int pagesize;
        public int pageindex;
        public int pagetotal;
        public string Act = "";
        public string y = "";//未全额收款的对账单

        public int sType = -1;//对账单类型
        public string sCode = "";//对账单号
        public int sObjectType = -1;//对象类型
        public string sObjectName = "";//对账对象
        public int sObjectID = 0;
        public int sSteps = 0;//步骤
        public string sDateTimeB = "";//对账时间,起点
        public string sDateTimeE = "";//对账时间,结束
        public int sReceiptState = -1;//发票是否已开
        public string cCode = "";//凭证号
        public int sState = -1;//状态
        public decimal SumMoney = 0;
        protected virtual void Page_Load(object sender, EventArgs e)
        {
            pagesize = 30;
            PageBarHTML = "";
            string tSQL = " 1=1 ";
            if (this.userid > 0)
            {

                if (HTTPRequest.GetString("page").Trim() != "" && Utils.IsInt(HTTPRequest.GetString("page").Trim()))
                {
                    pageindex = int.Parse(HTTPRequest.GetString("page").Trim());
                }
                else
                {
                    pageindex = 1;
                }
                y = HTTPRequest.GetString("y");
                sType = HTTPRequest.GetInt("sType", -1);
                string _sType = "0";
                switch (sType)
                { 
                    case 2://应收
                        if (CheckUserPopedoms("X") || CheckUserPopedoms("6-6-1-1"))
                        {
                            _sType += ",2";
                        }
                       // tSQL += " and tbMonthlyStatementInfo.sType=1";
                        break;
                    case 1://应付
                        if (CheckUserPopedoms("X") || CheckUserPopedoms("6-6-2-1"))
                        {
                            _sType += ",1";
                        }
                       // tSQL += " and tbMonthlyStatementInfo.sType=2";
                        break;
                    case 3://其他
                        if (CheckUserPopedoms("X") || CheckUserPopedoms("6-6-3-1"))
                        {
                            _sType += ",3";
                        }
                        // tSQL += " and tbMonthlyStatementInfo.sType=2";
                        break;
                    default:
                        if (CheckUserPopedoms("X") || CheckUserPopedoms("6-6-1-1"))
                        {
                            _sType += ",2";
                        }
                        if (CheckUserPopedoms("X") || CheckUserPopedoms("6-6-2-1"))
                        {
                            _sType += ",1";
                        }
                        if (CheckUserPopedoms("X") || CheckUserPopedoms("6-6-3-1"))
                        {
                            _sType += ",3";
                        }
                        break;
                }
                tSQL += " and tbMonthlyStatementInfo.sType in(" + _sType + ") ";
                sCode = Utils.ChkSQL(HTTPRequest.GetString("sCode"));
                if (sCode.Trim() != "")
                {
                    tSQL += " and tbMonthlyStatementInfo.sCode like '%" + sCode + "%'";
                }
                sObjectType = HTTPRequest.GetInt("sObjectType", -1);
                if (sObjectType > -1)
                {
                    tSQL += " and tbMonthlyStatementInfo.sObjectType=" + sObjectType;
                }
                sObjectID = HTTPRequest.GetInt("sObjectID", -1);
                if (sObjectID > -1)
                {
                    tSQL += " and tbMonthlyStatementInfo.sObjectID=" + sObjectID;
                }
                sSteps = HTTPRequest.GetInt("sSteps", -1);
                if (sSteps > -1)
                {
                    tSQL += " and tbMonthlyStatementInfo.sSteps=" + sSteps;
                }
                sState = HTTPRequest.GetInt("sState", -1);
                if (sState > -1)
                {
                    tSQL += " and tbMonthlyStatementInfo.sState=" + sState;
                }
                sDateTimeB = Utils.ChkSQL(HTTPRequest.GetString("sDateTimeB"));
                if (sDateTimeB.Trim() != "" && Utils.IsDateString(sDateTimeB.Trim()))
                {
                    tSQL += " and tbMonthlyStatementInfo.sDateTime>='" + Convert.ToDateTime(sDateTimeB.Trim()).ToShortDateString() + " 00:00:00 '";
                }
                sDateTimeE = Utils.ChkSQL(HTTPRequest.GetString("sDateTimeE"));
                if (sDateTimeE.Trim() != "" && Utils.IsDateString(sDateTimeE.Trim()))
                {
                    tSQL += " and tbMonthlyStatementInfo.sDateTime<='" + Convert.ToDateTime(sDateTimeE.Trim()).ToShortDateString() + " 23:59:59 '";
                }

                if (y == "y")
                {
                    tSQL += " and tbMonthlyStatementInfo.sThisMoney !=isnull((select sum(mMoney) from tbMonthlyStatementAppendMoneyDataInfo where MonthlyStatementID=tbMonthlyStatementInfo.MonthlyStatementID and mState=0),0)";
                }

                sStepsList = MonthlyStatements.GetMonthlyStatementSteps();

                if (!IsErr())
                {
                    dList = MonthlyStatements.GetMonthlyStatementInfoList(pagesize, pageindex, tSQL, out pagetotal, 1, "*");
                    PageBarHTML = Utils.TenPage(pageindex, pagetotal, 0, "&Act=" + Act + "&sType=" + sType + "&sCode=" + sCode + "&sObjectType=" + sObjectType + "&sObjectName=" + sObjectName + "&sObjectID=" + sObjectID + "&sSteps=" + sSteps + "&sDateTimeB=" + sDateTimeB + "&sDateTimeE=" + sDateTimeE + "&sReceiptState=" + sReceiptState + "&cCode=" + cCode + "&sState=" + sState+"&y="+y);
                    SumMoney = MonthlyStatements.GetMonthlyStatementInfoListSumMoney(tSQL);
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
            pagetitle = " 对账单信息";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}