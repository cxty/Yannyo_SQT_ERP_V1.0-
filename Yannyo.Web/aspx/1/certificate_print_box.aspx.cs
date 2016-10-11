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
    public partial class certificate_print_box : PageBase
    {
        public DataTable dList = new DataTable();
        public string cDateTimeB = "";
        public string cDateTimeE = "";
        public decimal SumMoney = 0;
        public string Act = "";
        public string cCode = "";
        public string cNumber = "";
        public int cState = -1;
        public int cSteps = -1;
         
        protected virtual void Page_Load(object sender, EventArgs e)
        {
            if (this.userid > 0)
            {
                if (CheckUserPopedoms("X") || CheckUserPopedoms("6-5-6"))
                {
                    string tSQL = " 1=1 ";
                    Act = HTTPRequest.GetString("Act");
                    if (Act == "do")
                    {
                        cSteps = HTTPRequest.GetInt("cSteps", -1);
                        cNumber = HTTPRequest.GetString("cNumber");
                        cState = HTTPRequest.GetInt("cState", -1);
                        if (cState > -1)
                        {
                            tSQL += " and cState=" + cState;
                        }
                        cDateTimeB = Utils.ChkSQL(HTTPRequest.GetString("cDateTimeB"));
                        if (cDateTimeB.Trim() != "" && Utils.IsDateString(cDateTimeB.Trim()))
                        {
                            tSQL += " and cDateTime>='" + cDateTimeB.Trim() + "  00:00:00 '";
                        }
                        cDateTimeE = Utils.ChkSQL(HTTPRequest.GetString("cDateTimeE"));
                        if (cDateTimeE.Trim() != "" && Utils.IsDateString(cDateTimeE.Trim()))
                        {
                            tSQL += " and cDateTime<='" + cDateTimeE.Trim() + "  23:59:59 '";
                        }
                        if (cSteps != -1)
                        {
                            tSQL += " and cSteps=" + cSteps;
                        }
                        if (cNumber.Trim() != "")
                        {
                            if (Utils.StrToInt(cNumber, 0) > 0)
                            {
                                tSQL += " and cNumber=" + cNumber;
                            }
                        }
                        dList = Certificates.GetCertificateInfoList(tSQL).Tables[0];
                        SumMoney = Certificates.GetCertificateSumMoney(tSQL);
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
            pagetitle = " 批量打印凭证";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}