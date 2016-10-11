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
    public partial class indexpage : PageBase
    {
        public string Erp_Name = "";
        public string Erp_Pwd = "";
        public DataTable Order = new DataTable();
        public DataTable ProductAlarm = new DataTable();
        //public Weather weathers = new Weather();
        protected virtual void Page_Load(object sender, EventArgs e)
        {
            //weathers = Caches.GetWeather("福州");
            if (this.userid != -1)
            {
                
                if (this.username != "")
                {
                    pagetitle = " 您好 [" + this.username + "]";
                    Order = Orders.GetOrderStateList().Tables[0];
                    ProductAlarm = Orders.GetProductAlarm();
                    UserPassportInfo pi = new UserPassportInfo();
                    try
                    {
                        pi = tbUserInfo.GetUserPassportInfoModel(this.userid);
                        if (pi != null)
                        {
                            Erp_Name = pi.Erp_Name;
                            Erp_Pwd = pi.Erp_Pwd;
                        }
                    }
                    finally
                    {
                        pi = null;
                    }
                }
                else
                {
                    pagetitle = " 请先登录!";
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
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}
