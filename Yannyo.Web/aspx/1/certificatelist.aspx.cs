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
    public partial class certificatelist : PageBase
    {
        public DataTable dList = new DataTable();
        public int OrderID = 0;
        public int ordertype = 0;
        public int sObjectType = -1;
        public int sObjectID = -1;
        public string Act = "";
        public string cCode = "";
        public string cNumber = "";
        public int cType = -1;
        public int cState = -1;
        public string cDateTimeB = "";
        public string cDateTimeE = "";
        public decimal SumMoney = 0;
        public int pagesize;
        public int pageindex;
        public int pagetotal;
        public int cSteps = -1;
        protected virtual void Page_Load(object sender, EventArgs e)
        {
            if (this.userid > 0)
            {
                if (CheckUserPopedoms("X") || CheckUserPopedoms("6-5-2"))
                {
                    pagesize = 20;
                    PageBarHTML = "";
                    string tSQL = "";
                    OrderID = HTTPRequest.GetInt("orderid", 0);
                    ordertype = HTTPRequest.GetInt("ordertype", 0);
                     sObjectType = HTTPRequest.GetInt("sObjectType", -1);
                     sObjectID = HTTPRequest.GetInt("sObjectID", -1);
                     cSteps = HTTPRequest.GetInt("cSteps", -1);
                     cNumber = HTTPRequest.GetString("cNumber");
                     cState = HTTPRequest.GetInt("cState", -1);

                     if (HTTPRequest.GetString("page").Trim() != "" && Utils.IsInt(HTTPRequest.GetString("page").Trim()))
                     {
                         pageindex = int.Parse(HTTPRequest.GetString("page").Trim());
                     }
                     else
                     {
                         pageindex = 1;
                     }
                     tSQL = " 1=1 ";
                    //tSQL = "cObject=0 and toObject=" + sObjectType + " and toObjectID=" + sObjectID + " and cState=0";
                     
                    cCode = Utils.ChkSQL(HTTPRequest.GetString("cCode"));
                    if (cCode.Trim() != "")
                    {
                        tSQL += " and cCode like '%" + cCode + "%' ";
                    }
                    cType = HTTPRequest.GetInt("cType", -1);
                    if (cType > -1)
                    {
                        tSQL += " and cType=" + cType;
                    }
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

                    dList = Certificates.GetCertificateInfoList(pagesize, pageindex, tSQL, out pagetotal, 0, "*", "cDateTime desc,cNumber desc");
                    PageBarHTML = Utils.TenPage(pageindex, pagetotal, 0, "&cCode=" + cCode + "&cDateTimeB=" + cDateTimeB + "&cDateTimeE=" + cDateTimeE + "&cSteps=" + cSteps + "&cState=" + cState + "&cNumber=" + cNumber);

                    SumMoney = Certificates.GetCertificateSumMoney(tSQL);
                }
                else
                {
                    AddErrLine("权限不足!");
                    AddScript("window.setTimeout('window.parent.HidBox();',1000);");
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
            pagetitle = " 凭证管理";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}