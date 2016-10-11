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
    public partial class associated_details_do : PageBase
    {
        public DataTable pList = new DataTable();   //获得联营库存产品详情
        public int sID;                             //门店ID
        public int aID;                             //联营类型  -1：全部；0：剔除；1：仅联营
        public DateTime sDate;                      //日期
        public string sName;                        //门店名称
        public string Show;
        public decimal sumA, sumB, sumC;
        protected void Page_Load(object sender, EventArgs e)
        {
             if (this.userid > 0)
            {
                if (CheckUserPopedoms("X") || CheckUserPopedoms("7-1-1-6-1"))
                {
                    bool ShowMoney = CheckUserPopedoms("7-1-1-6-2");
                    bool xshowMoney = CheckUserPopedoms("X");
                    if (ShowMoney || xshowMoney)
                    {
                        Show = "1";
                    }
                    sID = HTTPRequest.GetInt("sid",0);    //门店编号
                    aID = HTTPRequest.GetInt("aid", -1);  //联营类别
                    sDate=DateTime.Parse(HTTPRequest.GetString("sDate"));
                    sName = HTTPRequest.GetString("sName");
                    pList = ProductsLossInfo.getProductDetailsByStorehouseID(sID, aID, sDate,1);
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
            pagetitle = "联营统计产品详情";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}