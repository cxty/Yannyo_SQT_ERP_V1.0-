using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Xml;
using System.IO;
using System.Net;

using Yannyo.Common;
using Yannyo.Config;
using Yannyo.Entity;
using Yannyo.BLL;
using Yannyo.Public;

namespace Yannyo.Web
{
    public partial class personnel_statistics_details : PageBase
    {
        public DateTime bDate = DateTime.Now.AddDays(-(DateTime.Now.Day) + 1);
        public DateTime eDate = DateTime.Now;
        public DataTable mList = new DataTable();
        public int dType;
        protected virtual void Page_Load(object sender, EventArgs e)
        {
             if (this.userid > 0)
            {
                if (CheckUserPopedoms("X") || CheckUserPopedoms("7-2-4-2"))
                {
                    if (ispost)
                    {
                        dType = HTTPRequest.GetInt("dType", 0);
                        bDate = (HTTPRequest.GetString("bDate").Trim() != "") ? Convert.ToDateTime(HTTPRequest.GetString("bDate").Trim()) : DateTime.Now;
                        eDate = (HTTPRequest.GetString("eDate").Trim() != "") ? Convert.ToDateTime(HTTPRequest.GetString("eDate").Trim()) : DateTime.Now;
                        mList = tbStaffInfo.getStaffDetails(bDate, eDate, dType);
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
            pagetitle = "人员岗位-入离职报表";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}