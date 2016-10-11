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
    public partial class orderprint_add : PageBase
    {
        public int orderid = 0;
        public int ordertype = 0;
        public int pageindex = 0;
        public string strHtml = "";
        public string strHtmlb = "";
        public OrderInfo oi = new OrderInfo();
        public DataTable OrderFieldList = new DataTable();//自定义字段
        public DataTable OrderFieldValueList = new DataTable();//自定义字段值
        public DataTable OrderList = new DataTable();//单据体列表
        public UserInfo print_ui = new UserInfo();//开单人员

        public DataSet OrderListDataSet = new DataSet();//分页时使用,存储分页后的多个表

        protected virtual void Page_Load(object sender, EventArgs e)
        {
            if (this.userid > 0)
            {
                if (CheckUserPopedoms("X") || CheckUserPopedoms("3-1-1-8") || CheckUserPopedoms("3-1-2-8") || CheckUserPopedoms("3-2-1-8") || CheckUserPopedoms("3-2-2-8") || CheckUserPopedoms("3-2-3-8") || CheckUserPopedoms("3-2-4-8") || CheckUserPopedoms("3-2-5-8") || CheckUserPopedoms("3-3-1-8") || CheckUserPopedoms("3-3-2-8") || CheckUserPopedoms("3-3-3-8"))
                {
                    orderid = HTTPRequest.GetInt("orderid", 0);
                    ordertype = HTTPRequest.GetInt("ordertype", 0);
                    
                    if (orderid > 0)
                    {
                        oi = Orders.GetOrderInfoModel(orderid);
                        if (oi != null)
                        {
                            string tSteps = ((oi.oSteps == 1) ? "  tbOrderListInfo.oWorkType=0 " : "  tbOrderListInfo.oWorkType<>0 ").ToString();
                            string tSteps_b = ((oi.oSteps == 1) ? " IsVerify=0 " : " IsVerify<>0 ").ToString();

                            OrderList = Orders.GetOrderListInfoList(" OrderID=" + oi.OrderID + " and IsGifts=0 and " + tSteps + " order by OrderListID asc").Tables[0];

                            OrderFieldList = Orders.GetOrderFieldInfoList(" OrderType=" + ordertype + " and fState=0 and fPrintAdd=0").Tables[0];
                            if (OrderFieldList != null)
                            {
                                OrderFieldValueList = Orders.GetOrderFieldValueInfoList(" OrderListID in(select tbOrderListInfo.OrderListID from tbOrderListInfo where tbOrderListInfo.OrderID=" + oi.OrderID + " and tbOrderListInfo.IsGifts=0 and " + tSteps + ") and " + tSteps_b + "").Tables[0];
                            }

                            if (OrderFieldList != null)
                            {
                                int i = 0;
                                DataTable dt = OrderList.Clone();
                                foreach (DataRow dr in OrderList.Rows)
                                {
                                    dt.ImportRow(dr);
                                    i++;
                                    if (i % config.PrintAddRow == 0)
                                    {
                                        OrderListDataSet.Tables.Add(dt);
                                        dt = OrderList.Clone();
                                        dt.TableName = "t_" + i;
                                    }
                                }
                                if (dt.Rows.Count > 0)
                                {
                                    //剩下的行数
                                    OrderListDataSet.Tables.Add(dt);
                                    dt = OrderList.Clone();
                                    dt.TableName = "t_" + (i + 1);
                                }
                            }

                            //制单人
                            print_ui = tbUserInfo.GetUserInfoModel(oi.UserID);

                            OrderWorkingLogInfo owl = new OrderWorkingLogInfo();
                            owl.OrderID = oi.OrderID;
                            owl.UserID = this.userid;
                            owl.oType = 10;
                            owl.oMsg = "打印随附单";
                            owl.pAppendTime = DateTime.Now;
                            Orders.AddOrderWorkingLogInfo(owl);
                        }
                        else
                        {
                            AddErrLine("参数错误,单据不存在!");
                        }
                    }
                    else
                    {
                        AddErrLine("参数错误!");
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
            pagetitle = " 打印随附单据";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}