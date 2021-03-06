﻿using System;
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
    public partial class orderworkinglog : PageBase
    {
        public DataTable dList = new DataTable();
        public int pagesize;
        public int pageindex;
        public int pagetotal;
        public string Act = "";
        public int orderid = 0;
        public int ordertype = 0;
        public OrderInfo oi = new OrderInfo();
        protected virtual void Page_Load(object sender, EventArgs e)
        {
            pagesize = 20;
            PageBarHTML = "";

            if (this.userid > 0)
            {
                if (CheckUserPopedoms("X") || CheckUserPopedoms("3-1-1-8") || CheckUserPopedoms("3-1-2-8") || CheckUserPopedoms("3-2-1-8") || CheckUserPopedoms("3-2-2-8") || CheckUserPopedoms("3-2-3-8") || CheckUserPopedoms("3-2-4-8") || CheckUserPopedoms("3-2-5-8") || CheckUserPopedoms("3-3-1-8") || CheckUserPopedoms("3-3-2-8") || CheckUserPopedoms("3-3-3-8"))
                {
                    if (HTTPRequest.GetString("page").Trim() != "" && Utils.IsInt(HTTPRequest.GetString("page").Trim()))
                    {
                        pageindex = int.Parse(HTTPRequest.GetString("page").Trim());
                    }
                    else
                    {
                        pageindex = 1;
                    }
                    if (ispost)
                    {
                        Act = HTTPRequest.GetFormString("Act"); 
                    }
                    else
                    {
                        Act = HTTPRequest.GetQueryString("Act");
                    }
                    orderid = HTTPRequest.GetInt("orderid", 0);
                    ordertype = HTTPRequest.GetInt("ordertype", 0);
                    if (orderid > 0)
                    {
                        oi = Orders.GetOrderInfoModel(orderid);
                        dList = Orders.GetOrderWorkingLogInfoList(pagesize, pageindex, " OrderID=" + orderid, out pagetotal, 1, "*");

                        PageBarHTML = Utils.TenPage(pageindex, pagetotal, 0, "&Act=" + Act);
                    }
                    else {
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
            pagetitle = " 单据操作记录";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}