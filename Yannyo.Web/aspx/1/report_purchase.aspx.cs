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
    public partial class report_purchase : PageBase
    {
        public DataTable dList = new DataTable();
        public DataTable sdList = new DataTable();
        public bool ShowPrice = false;
        public DateTime bDate = DateTime.Now;
        public DateTime eDate = DateTime.Now;
        public int ReType = 1;//商品=1,供货商=2
        public decimal MoneyAAA, MoneyAA, MoneyA;
        public decimal MoneyBBB, MoneyBB, MoneyB;

        public decimal MoneyAAAo, MoneyAAo, MoneyAo;
        public decimal MoneyBBBo, MoneyBBo, MoneyBo;

        public decimal sMoneyAAA, sMoneyAA, sMoneyA;
        public decimal sMoneyBBB, sMoneyBB, sMoneyB;

        public decimal sMoneyAAAo, sMoneyAAo, sMoneyAo;
        public decimal sMoneyBBBo, sMoneyBBo, sMoneyBo;

        public int DateType = 0;
        public string S_key = "";
        public int tLoopid = 0;
        public int tLoopid_a = 0;
        protected virtual void Page_Load(object sender, EventArgs e)
        {
            if (this.userid > 0)
            {
                if (CheckUserPopedoms("X") || CheckUserPopedoms("7-2-1-5-2-1"))
                {
                    S_key =Utils.ChkSQL(HTTPRequest.GetString("S_key"));
                    ShowPrice = (CheckUserPopedoms("X") == true) ? true : CheckUserPopedoms("7-2-1-5-2-2");
                    bDate = (HTTPRequest.GetString("bDate").Trim() != "") ? Convert.ToDateTime(HTTPRequest.GetString("bDate").Trim()) : Convert.ToDateTime(DateTime.Now.Year + "-" + DateTime.Now.Month + "-1");
                    eDate = (HTTPRequest.GetString("eDate").Trim() != "") ? Convert.ToDateTime(HTTPRequest.GetString("eDate").Trim()) : DateTime.Now;

                    ReType = HTTPRequest.GetInt("ReType", 1);
                    if (ispost)
                    {
                        
                        dList = DataUtils.GetPurchaseReport(ReType, bDate, eDate);
                        //按供应商统计
                        if (ReType == 2)
                        {
                            sdList = tbSupplierInfo.GetSupplierInfoList("").Tables[0];
                            int pCount = 0;

                            sdList.Columns.Add("pCount", typeof(System.Int32));

                            foreach (DataRow dr in sdList.Rows)
                            {
                                pCount = 0;
                                foreach (DataRow ddr in dList.Rows)
                                {
                                    if (dr["SupplierID"].ToString() == ddr["SupplierID"].ToString())
                                    {
                                            pCount++;
                                    }
                                }
                                dr["pCount"] = pCount > 0 ? pCount  : 0;
                            }

                        }
                    }
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
            pagetitle = " 进货统计";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}