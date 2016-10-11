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
    public partial class monthlystatementlist_orderlist : PageBase
    {
        public int pagesize;
        public int pageindex;
        public int pagetotal;
        public int OrderType = 0;//单据类型,1=采购,2=销售
        public int StoresSupplierID = 0;//客户,供应商编号
        public string OrderTypeStr = "";//单据类型集合
        public string oOrderNum = "";
        public string oCustomersOrderID = "";//客户单号
        public string oOrderDateTimeB = "";
        public string oOrderDateTimeE = "";
        

        public DataTable dList = new DataTable();
        protected virtual void Page_Load(object sender, EventArgs e)
        {
            if (this.userid > 0)
            {
                pagesize = 30;
                PageBarHTML = "";
                if (HTTPRequest.GetString("page").Trim() != "" && Utils.IsInt(HTTPRequest.GetString("page").Trim()))
                {
                    pageindex = int.Parse(HTTPRequest.GetString("page").Trim());
                }
                else
                {
                    pageindex = 1;
                }
                OrderType = HTTPRequest.GetInt("OrderType", 0);
                if (OrderType > 0)
                {
                    string tSQL = "";
                    if (OrderType == 1)
                    {
                        OrderTypeStr = "1,2";
                    }
                    else if (OrderType == 2)
                    {
                        OrderTypeStr = "3,4";
                    }
                    else if (OrderType == 3)
                    {
                        OrderTypeStr = "5,6,7,8,9,10,11";
                    }
                    else {
                        OrderTypeStr = "0";
                    }
                    tSQL = " tbOrderInfo.oType in(" + OrderTypeStr + ") ";
                    StoresSupplierID = HTTPRequest.GetInt("StoresSupplierID", 0);
                    if (StoresSupplierID > 0)
                    {
                        tSQL += " and tbOrderInfo.StoresID=" + StoresSupplierID;
                    }
                    oOrderNum = Utils.ChkSQL(HTTPRequest.GetString("oOrderNum"));
                    if (oOrderNum.Trim() != "")
                    {
                        tSQL += " and tbOrderInfo.oOrderNum like '%" + oOrderNum + "%'";
                    }
                    oCustomersOrderID = Utils.ChkSQL(HTTPRequest.GetString("oCustomersOrderID"));
                    if (oCustomersOrderID.Trim() != "")
                    {
                        tSQL += " and tbOrderInfo.oCustomersOrderID like '%" + oCustomersOrderID + "%'";
                    }
                    oOrderDateTimeB = Utils.ChkSQL(HTTPRequest.GetString("oOrderDateTimeB"));
                    if (oOrderDateTimeB.Trim() != "" && Utils.IsDateString(oOrderDateTimeB.Trim()))
                    {
                        tSQL += " and tbOrderInfo.oOrderDateTime>='" + Convert.ToDateTime(oOrderDateTimeB.Trim()).ToShortDateString() + " 00:00:00 '";
                    }
                    oOrderDateTimeE = Utils.ChkSQL(HTTPRequest.GetString("oOrderDateTimeE"));
                    if (oOrderDateTimeE.Trim() != "" && Utils.IsDateString(oOrderDateTimeE.Trim()))
                    {
                        tSQL += " and tbOrderInfo.oOrderDateTime<='" + Convert.ToDateTime(oOrderDateTimeE.Trim()).ToShortDateString() + " 23:59:59 '";
                    }
                    tSQL += " and tbOrderInfo.oState=0";
                    tSQL += " and tbOrderInfo.oSteps=5";

                    dList = Orders.GetOrderInfoList(pagesize, pageindex, tSQL, out pagetotal, 1, "*,"+
                        " (case " +
                        " when  tbOrderInfo.oType in(1,2) then " +
                        " (select su.sName from tbSupplierInfo su where su.SupplierID=tbOrderInfo.StoresID) " +
                        " when  tbOrderInfo.oType in(3,4,5,6,7,11) then " +
                        " (select so.sName from tbStoresInfo so where so.StoresID=tbOrderInfo.StoresID) " +
                        " end) as StoresSupplierName," +
                        "isnull((case when tbOrderInfo.oType in(2,4) then -1 else 1 end)*(select sum(isnull(ol.oMoney,0)) from tbOrderListInfo ol where ol.OrderID=tbOrderInfo.OrderID and ol.oWorkType=(select max(oll.oWorkType) from tbOrderListInfo oll where oll.OrderID=tbOrderInfo.OrderID)),0) as SumMoney,"+
                        "(select s.sName from tbStaffInfo s where s.StaffID=tbOrderInfo.StaffID) as StaffName,"+
                        "(select u.uName from tbUserInfo u where u.UserID=tbOrderInfo.UserID) as UserName,"+
                        "(select top 1 us.sName from tbStaffInfo us where us.StaffID=(select top 1 StaffID from tbUserInfo where UserID=tbOrderInfo.UserID )) as UserStaffName");
                    PageBarHTML = Utils.TenPage(pageindex, pagetotal, 0, "&oOrderNum=" + oOrderNum + "&oCustomersOrderID=" + oCustomersOrderID + "&oOrderDateTimeB=" + oOrderDateTimeB + "&oOrderDateTimeE=" + oOrderDateTimeE + "");

                    
                }
                else {
                    AddErrLine("参数错误!");
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
            pagetitle = " 单据信息";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}