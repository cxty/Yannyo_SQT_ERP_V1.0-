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
    public partial class banklist : PageBase
    {
        public DataTable dList = new DataTable();
        public decimal cMoney;
        public string cDirecion;
        public int count;
        public decimal sumA,sumB;

        public int count_x=0;
        public int getCount(string ID)
        {
            return count = tbBankInfo.getClassCount(Convert.ToInt32(ID));
        }
        protected virtual void Page_Load(object sender, EventArgs e)
        {
            if (this.userid > 0)
            {
                if (CheckUserPopedoms("X") || CheckUserPopedoms("6-1-2"))
                {
                    if (CheckUserPopedoms("X"))
                    {
                        count_x = 1;
                    }
                    dList = tbBankInfo.GetBankList(" 1=1 order by c.cCode asc").Tables[0];
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
            pagetitle = " 资金帐户管理";
            this.Load += new EventHandler(this.Page_Load);
        }
        public string GetFeesSubjectClassParentStr(int FeesSubjectClassID, string sStr)
        {
            return DataClass.GetFeesSubjectClassParentStr(FeesSubjectClassID, sStr);
        }
    }
}