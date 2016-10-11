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
    public partial class erpdata_sync : PageBase
    {
        protected virtual void Page_Load(object sender, EventArgs e)
        {
            if (this.userid > 0)
            {
                if (CheckUserPopedoms("X") || CheckUserPopedoms("13"))
                {
                    if (ispost)
                    {
                        int[] Re = tbErpOrderInfo.SyncErpOrderInfo();

                        AddMsgLine("成功匹配(" + Re[0].ToString() + ")条数据需匹配,失败(" + Re[1].ToString() + ")条!");
                        AddScript("window.setTimeout('window.parent.HidBox();',1500);");
                    }
                }
                else
                {
                    AddErrLine("权限不足!");
                    AddScript("window.setTimeout('window.parent.HidBox();',1500);");
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
            pagetitle = " Erp单据数据匹配";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}
