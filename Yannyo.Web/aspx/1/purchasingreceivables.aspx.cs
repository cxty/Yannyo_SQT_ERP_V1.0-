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
using System.IO;
using Yannyo.Public;

namespace Yannyo.Web
{
    public partial class purchasingreceivables : PageBase
    {
        public DataTable dList = new DataTable();
        public int pagesize;
        public int pageindex;
        public int pagetotal;
        public int APObjID = 0;
        public int APMoneyID = 0;
        public DateTime sDate = DateTime.Now;


        public int payType = 0; //付款类型  0=客户;1=供应商;2=个人;3=超市系统
        public int ReType;      //统计类型   0=月;1=年

        protected void Page_Load(object sender, EventArgs e)
        {
            pagesize = 20;
            PageBarHTML = "";
            if (this.userid > 0)
            {
                if (CheckUserPopedoms("X") || CheckUserPopedoms("3-4-1-2"))
                {
                   if (HTTPRequest.GetString("page").Trim() != "" && Utils.IsInt(HTTPRequest.GetString("page").Trim()))
                    {
                        pageindex = int.Parse(HTTPRequest.GetString("page").Trim());
                    }
                    else
                    {
                        pageindex = 1;
                    }
                    
                   PageBarHTML = Utils.TenPage(pageindex, pagetotal, 0);
                   //当选择查询条件以后实现数据绑定到报表中
                   if (ispost)
                   {
                       payType = HTTPRequest.GetInt("_payType", 0);//获取前台付款类型
                       ReType = HTTPRequest.GetInt("_ReType", 0); //获取前台日期类型
                       sDate = Utils.IsDateString(Utils.ChkSQL(HTTPRequest.GetString("sDate"))) ? DateTime.Parse(Utils.ChkSQL(HTTPRequest.GetString("sDate"))) : DateTime.Now;//获取日期
                       dList = Purchasingpayment.GetProceedsReport(payType, sDate, ReType);
                   }
                }
                else
                {
                    AddErrLine("权限不足! ");
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
            pagetitle = " 采购付款详情表";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}