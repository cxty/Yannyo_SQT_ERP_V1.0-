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
    public partial class stores : PageBase
    {
        public DataTable dList = new DataTable();
        public int pagesize;
        public int pageindex;
        public int pagetotal;
        public string Act = "";
        public string S_key = "";
        public int sState = -1;
        protected virtual void Page_Load(object sender, EventArgs e)
        {
            pagesize = 20;
            PageBarHTML = "";
            string tSQL = "";

            if (this.userid > 0)
            {
                if (CheckUserPopedoms("X") || CheckUserPopedoms("2-2-4"))
                {
                    if (HTTPRequest.GetString("page").Trim() != "" && Utils.IsInt(HTTPRequest.GetString("page").Trim()))
                    {
                        pageindex = int.Parse(HTTPRequest.GetString("page").Trim());
                    }
                    else
                    {
                        pageindex = 1;
                    }
                    if (ispost)
                    {
                        Act = HTTPRequest.GetFormString("Act");
                        S_key = Utils.ChkSQL(HTTPRequest.GetFormString("S_key"));
                    }
                    else
                    {
                        Act = HTTPRequest.GetQueryString("Act");
                        S_key = Utils.ChkSQL(HTTPRequest.GetQueryString("S_key"));
                    }
                    sState = HTTPRequest.GetInt("sState", -1);
                    if (Act.Trim() == "Search" && S_key.Trim() != "")
                    {
                        tSQL = " tbStoresInfo.sName like'%" + S_key + "%' or tbStoresInfo.sCode like '%" + S_key + "%' ";

                        if (sState > -1)
                        {
                            tSQL += " and sState=" + sState + "";
                        }
                    }

                    dList = tbStoresInfo.GetStoresInfoList(pagesize, pageindex, tSQL, out pagetotal, 1, "*,(select yName from tbYHsysInfo where YHsysID=tbStoresInfo.[YHsysID]) as YHsysName,(select pName from tbPaymentSystemInfo where PaymentSystemID=tbStoresInfo.[PaymentSystemID]) as PaymentSystemName");

                    PageBarHTML = Utils.TenPage(pageindex, pagetotal, 0, "&Act=" + Act + "&S_key=" + S_key + "&sState=" + sState);
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
            pagetitle = " 客户管理";
            this.Load += new EventHandler(this.Page_Load);
        }
        public string GetRegionPaterStr(string rID)
        {
            return tbRegionInfo.GetRegionPaterStr(Utils.StrToInt(rID, 0));
        }
    }
}
