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
    public partial class report_certificate_summary : PageBase
    {
        public string bDate = "";//开始时间
        public string eDate = "";//结束时间
        public DataTable dList = new DataTable();
        public string bCode = "";//开始凭证号
        public string eCode = "";//结束凭证号
        public int cCount = 0;//凭证张数

        public decimal cdMoneySum = 0;//借方合计金额
        public decimal cdMoneyBSum = 0;//贷方合计金额

        protected virtual void Page_Load(object sender, EventArgs e)
        {
            if (this.userid > 0)
            {
                if (CheckUserPopedoms("X") || CheckUserPopedoms("6-7-7"))
                {
                    if (ispost)
                    {
                        bDate = HTTPRequest.GetString("bDate").Trim();
                        eDate = HTTPRequest.GetString("eDate").Trim();

                        DateTime  _bDate = Utils.IsDateString(bDate) ? DateTime.Parse(bDate) :DateTime.Parse(DateTime.Now.Year.ToString()+"-"+DateTime.Now.Month.ToString()+"-1");
                        DateTime _eDate = Utils.IsDateString(eDate) ? DateTime.Parse(eDate) : DateTime.Parse(DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-"+DateTime.Now.Day.ToString());

                        dList = Certificates.GetCertificate_Summary(_bDate, _eDate, out  cCount, out  bCode, out  eCode);
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
            pagetitle = config.CompanyName + " 凭证汇总";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}