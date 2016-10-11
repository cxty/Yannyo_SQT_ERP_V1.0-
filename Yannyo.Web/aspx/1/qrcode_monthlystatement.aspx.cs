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
    public partial class qrcode_monthlystatement : PageBase
    {
        MonthlyStatementInfo msi = new MonthlyStatementInfo();
        public DataTable dList = new DataTable();
        public string printdatetime = "";
        protected virtual void Page_Load(object sender, EventArgs e)
        {
            int msid = HTTPRequest.GetInt("msid", 0);
            string rc = HTTPRequest.GetString("rc");
            if (msid > 0)
            {
                
                rc = Utils.UrlDecode(DES.Decode(rc, config.Passwordkey));
                if (rc.Trim() != "")
                {
                    string[] rearray = Utils.SplitString(rc, "|");
                    if (rearray.Length > 0) {
                        msi = MonthlyStatements.GetMonthlyStatementInfoModel(msid);
                        if (msi != null)
                        {
                            if (rearray[1].Trim() == msi.sCode.Trim())
                            {
                                printdatetime = rearray[0].Trim();
                                dList = MonthlyStatements.GetMonthlyStatementWorkingLogInfoList(" MonthlyStatementID=" + msid + " order by mAppendTime desc").Tables[0];
                            }
                            else
                            {
                                AddErrLine("掩码被修改!");
                            }
                        }
                        else {
                            AddErrLine("参数错误,对账单不存在!");
                        }
                    }
                    else
                    {
                        AddErrLine("掩码被修改!");
                    }
                }
                else
                {
                    AddErrLine("参数错误!");
                }
            }
            else
            {
                AddErrLine("参数错误!");
            }
        }
        protected override void ShowPage()
        {
            pagetitle = " 对账单信息";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}