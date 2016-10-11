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
    public partial class dataanalysis_tvalue : PageBase
    {
        public string Act = "A1";
        public DataTable dList = new DataTable();

        protected virtual void Page_Load(object sender, EventArgs e)
        {
            
            if (this.userid > 0)
            {
                if (CheckUserPopedoms("X") || CheckUserPopedoms("11"))
                {
                    Act = HTTPRequest.GetString("Act").Trim() != "" ? HTTPRequest.GetString("Act").Trim() : "A1";
                    switch(Act)
                    {
                        case "A1":
                        case "E1":
                        case "F1"://客户、门店
                            dList = tbStoresInfo.GetStoresInfoList("").Tables[0];
                            break;
                        case "A2":
                        case "E2":
                        case "F2"://业务员
                            dList = tbStaffInfo.GetStaffInfoList(" sType=1").Tables[0];
                            break;
                        case "A3":
                        case "E3":
                        case "F3"://促销员
                            dList = tbStaffInfo.GetStaffInfoList(" sType=2").Tables[0];
                            break;
                        case "A4":
                        case "E4":
                        case "F4"://产品
                            dList = tbProductsInfo.GetProductsInfoList("").Tables[0];
                            break;
                        case "A5":
                        case "E5":
                        case "F5"://品牌
                            dList = tbProductsInfo.GetProductsBrandList("").Tables[0];
                            break;
                        case "A6":
                        case "E6":
                        case "F6"://系统
                            dList = tbYHsysInfo.GetYHsysInfoList("").Tables[0];
                            break;
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
            pagetitle = " 数据分析";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}
