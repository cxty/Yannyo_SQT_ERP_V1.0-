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
using System.Web.Script.Serialization;
using System.Runtime.Serialization;
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
    public partial class cost_details_gifts : PageBase
    {
        public DataTable gList = new DataTable();
        public DateTime bDate = DateTime.Now;  //开始日期
        public DateTime eDate = DateTime.Now;  //结束日期
        public string sName;//门店名称
        public int sID;//门店编号
        public string pName;//产品名称
        public int pID;//产品编号
        public string pBarcode;//产品条码

        public string Act;
        protected void Page_Load(object sender, EventArgs e)
        {
             if (this.userid > 0)
            {
                if (CheckUserPopedoms("X") || CheckUserPopedoms("7-2-3-8"))
                {
                    sName = HTTPRequest.GetString("sname");
                    sID = HTTPRequest.GetInt("sid",0);
                    pName = HTTPRequest.GetString("pname");
                    pID = HTTPRequest.GetInt("pid",0);
                    pBarcode = HTTPRequest.GetString("pbarcode");
                    bDate = Convert.ToDateTime(HTTPRequest.GetString("bDate"));
                    eDate = Convert.ToDateTime(HTTPRequest.GetString("eDate"));
                    Act = HTTPRequest.GetString("Act");

                    gList = CostDetails.getGiftCost_details(sID, pID, bDate, eDate);
                 
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
            pagetitle = " 赠品费用详情";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}