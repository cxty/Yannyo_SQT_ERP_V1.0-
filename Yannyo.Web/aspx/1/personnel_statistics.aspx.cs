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
    public partial class personnel_statistics : PageBase
    {
        public DataTable rList = new DataTable();       //人员岗位年份
        public DataTable yList = new DataTable();       //去年加入人员数量
        public DataTable mList = new DataTable();       //每月人员加入总数
        public string getYear;
        public int c_count;
        public int sumA;
        protected virtual void Page_Load(object sender, EventArgs e)
        {
             if (this.userid > 0)
            {
                if (CheckUserPopedoms("X") || CheckUserPopedoms("7-2-4-1"))
                {
                    rList = tbStaffInfo.getStaffDate();

                    getYear = HTTPRequest.GetString("getYear");
                    if (getYear == "")
                    {
                        getYear = DateTime.Now.ToString("yyyy") + "-01-01";
                    }
                    else
                    {
                        getYear = getYear + "-01-01";
                    }
                    if (ispost)
                    {
                        yList = tbStaffInfo.getStaffLastYear(Convert.ToDateTime(getYear));
                        mList = tbStaffInfo.getStaffOfMonth(Convert.ToDateTime(getYear).ToString("yyyy"));
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
            pagetitle = "人员岗位-月报表";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}