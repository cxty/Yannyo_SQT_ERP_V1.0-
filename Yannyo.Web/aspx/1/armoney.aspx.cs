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
    public partial class armoney : PageBase
    {
        public DataTable dList = new DataTable();
        public int pagesize;
        public int pageindex;
        public int pagetotal;
        protected virtual void Page_Load(object sender, EventArgs e)
        {
            pagesize = 20;
            PageBarHTML = "";

            if (this.userid > 0)
            {
                 if (CheckUserPopedoms("X") || CheckUserPopedoms("6-3"))
                {
                if (HTTPRequest.GetString("page").Trim() != "" && Utils.IsInt(HTTPRequest.GetString("page").Trim()))
                {
                    pageindex = int.Parse(HTTPRequest.GetString("page").Trim());
                }
                else
                {
                    pageindex = 1;
                }

                dList = tbARMoneyInfo.GetARMoneyInfoList(pagesize, pageindex, "", out pagetotal, 1, "*,("+
                                                                                                        " CASE ARObjType "+
	                                                                                                        " when 0 then dbo.fun_GetNameForObjID(ARObjID,0) "+
                                                                                                            " when 1 then dbo.fun_GetNameForObjID(ARObjID,1) " +
                                                                                                            " when 2 then dbo.fun_GetNameForObjID(ARObjID,3) " +
                                                                                                        " end) as ARObjName");

                PageBarHTML = Utils.TenPage(pageindex, pagetotal, 0);
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
            pagetitle = " 应收账款管理";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}
