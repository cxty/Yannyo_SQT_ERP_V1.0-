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
using Yannyo.Cache;
using Yannyo.Common;
using Yannyo.Entity;
using Yannyo.BLL;

namespace Yannyo.Web
{
    public partial class mproduct : MPageBase
    {
        public DataTable dList = new DataTable();
        public int pagesize;
        public int pageindex;
        public int pagetotal;
        public string Act = "";
        public string S_key = "";
        protected virtual void Page_Load(object sender, EventArgs e)
        {
            pagesize = 30;
            PageBarHTML = "";
            if (this.userid > 0)
            {
                if (CheckUserPopedoms("X") || CheckUserPopedoms("8-1-1"))
                {
                    string tSQL = "";
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
                    if (M_Config != null)
                    {
                        tSQL = " m_ConfigInfoID = " + M_Config.m_ConfigInfoID + " and m_IsDeltet=0 ";
                        dList = M_Utils.GetM_GoodsInfoList(pagesize, pageindex, tSQL, out pagetotal, 1, "*");
                        PageBarHTML = Utils.TenPage(pageindex, pagetotal, 0, "&Act=" + Act + "&S_key=" + S_key);
                    }
                }
                else
                {
                    AddErrLine("权限不足!");
                    AddScript("window.parent.HidBox();");
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
            pagetitle = " 网店商品列表";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}