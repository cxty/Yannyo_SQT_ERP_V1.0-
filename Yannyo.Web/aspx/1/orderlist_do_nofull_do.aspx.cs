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
    public partial class orderlist_do_nofull_do : PageBase
    {
        public int OrderID = 0;
        public int OrderType = 0;
        public string Act = "";
        public DataTable Order_Type = new DataTable();
        protected virtual void Page_Load(object sender, EventArgs e)
        {
            if (this.userid > 0)
            {
                if (CheckUserPopedoms("X") || CheckUserPopedoms("3-4-3") || CheckUserPopedoms("3-4-4"))
                {
                    OrderID = HTTPRequest.GetInt("orderid", 0);
                    OrderType = HTTPRequest.GetInt("ordertype", 0);
                    if (OrderID > 0)
                    {
                        //验证是否为待处理状态
                        if (Orders.CheckOrderNOFullToDo(OrderID))
                        {
                            if (Act == "NODo")//无需处理,直接改状态,单据处理结束
                            {
                                if (CheckUserPopedoms("X") || CheckUserPopedoms("3-4-4"))
                                {
                                    Orders.UpdateOrderNOFullNextOrder(OrderID, -1);
                                }
                                else
                                {
                                    AddErrLine("权限不足,无法处理该差额,需(非全额单据差额商品无需转新单处理)权限!");
                                }
                            }
                            else //转新单
                            {
                                if (CheckUserPopedoms("X") || CheckUserPopedoms("3-4-3"))
                                {
                                    Order_Type = Orders.GetOrder_Type();

                                    if (ispost)
                                    {

                                    }

                                }
                                else
                                {
                                    AddErrLine("权限不足,无法处理该差额,需(非全额单据差额商品需转新单处理)权限!");
                                }
                            }
                        }
                        else 
                        {
                            AddErrLine("该单据无法进行差额转单处理!");
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
            pagetitle = " 非全额收货单据差额商品处理";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}