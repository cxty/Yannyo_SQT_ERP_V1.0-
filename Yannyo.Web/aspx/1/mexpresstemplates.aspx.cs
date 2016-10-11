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
    public partial class mexpresstemplates : MPageBase
    {
        public DataTable dList = new DataTable();
        protected virtual void Page_Load(object sender, EventArgs e)
        {
            if (this.userid > 0)
            {
                
                if (CheckUserPopedoms("X") || CheckUserPopedoms("8-6"))
                {
                    dList = M_Utils.GetM_ExpressTemplatesInfoList(" m_ConfigInfoID=" + M_Config.m_ConfigInfoID + " order by mAppendTime  desc").Tables[0];
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
            pagetitle = config.CompanyName + " 快递运单模板";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}