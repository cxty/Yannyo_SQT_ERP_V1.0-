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
    public partial class monthlystatementworkinglog : PageBase
    {
        public DataTable dList = new DataTable();
        public int pagesize;
        public int pageindex;
        public int pagetotal;
        public MonthlyStatementInfo msi = new MonthlyStatementInfo();
        public int MonthlyStatementID = 0;
        protected virtual void Page_Load(object sender, EventArgs e)
        {
            pagesize = 20;
            PageBarHTML = "";
            if (HTTPRequest.GetString("page").Trim() != "" && Utils.IsInt(HTTPRequest.GetString("page").Trim()))
            {
                pageindex = int.Parse(HTTPRequest.GetString("page").Trim());
            }
            else
            {
                pageindex = 1;
            }
            MonthlyStatementID = HTTPRequest.GetInt("msid", 0);
            if (MonthlyStatementID > 0)
            {
                msi = MonthlyStatements.GetMonthlyStatementInfoModel(MonthlyStatementID);
                if (msi != null)
                {
                    dList = MonthlyStatements.GetMonthlyStatementWorkingLogInfoList(pagesize, pageindex, " MonthlyStatementID=" + MonthlyStatementID, out pagetotal, 1, "*");

                    PageBarHTML = Utils.TenPage(pageindex, pagetotal, 0, "");
                }
                else {
                    AddErrLine("参数错误!");
                }
            }
            else {
                AddErrLine("参数错误!");
            }
        }
        protected override void ShowPage()
        {
            pagetitle = " 对账单操作记录";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}