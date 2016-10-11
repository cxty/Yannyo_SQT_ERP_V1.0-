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
    public partial class bankmoney : PageBase
    {
        public DataTable fList = new DataTable();
        public DataTable dList = new DataTable();

        public int pageindex;
        public int pagetotal;
        public DateTime bDate;
        public DateTime eDate;
        public decimal sumMoney =0;

        public string tStr = "";

        protected virtual void Page_Load(object sender, EventArgs e)
        {
            
            PageBarHTML = "";
            int year = DateTime.Now.Year;
            int month = DateTime.Now.Month;

            DateTime _l = DateTime.Now.AddMonths(-1);

            int _l_year = _l.Year;
            int _l_month = _l.Month;

            DateTime firstDayOfThisMonth = new DateTime(_l_year, _l_month, 1);
            DateTime lastDayOfThisMonth = new DateTime(year, month, DateTime.DaysInMonth(year, month));

            bDate = firstDayOfThisMonth;
            eDate = lastDayOfThisMonth;

            if (this.userid > 0)
            {
                if (CheckUserPopedoms("X") || CheckUserPopedoms("7-2-3-3"))
                {
                    if (HTTPRequest.GetString("page").Trim() != "" && Utils.IsInt(HTTPRequest.GetString("page").Trim()))
                    {
                        pageindex = int.Parse(HTTPRequest.GetString("page").Trim());
                    }
                    else
                    {
                        pageindex = 1;
                    }
                    fList = tbBankInfo.GetBankList(" 1=1 order by bAppendTime desc").Tables[0];
                    dList = tbBankMoneyInfo.GetBankMoneyTable(firstDayOfThisMonth, lastDayOfThisMonth, 0);

                    PageBarHTML = "";
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
            pagetitle = " 银行明细管理";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}
