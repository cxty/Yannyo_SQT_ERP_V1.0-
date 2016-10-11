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
    public partial class stores_armoney_do : PageBase
    {
        public StoresInfo si = new StoresInfo();
        public string Act = "";
        public int StoresID = 0;

        public decimal sDoDayMoney = 0;

        protected virtual void Page_Load(object sender, EventArgs e)
        {
            if (this.userid > 0)
            {
                if (CheckUserPopedoms("X") || CheckUserPopedoms("6-1-5"))
                {
                    Act = HTTPRequest.GetString("Act");

                    if (Act == "Edit")
                    {
                        StoresID = Utils.StrToInt(HTTPRequest.GetString("sid"), 0);

                        si = tbStoresInfo.GetStoresInfoModel(StoresID);
                    }
                    if (ispost)
                    {
                        

                        sDoDayMoney = decimal.Parse(HTTPRequest.GetString("sDoDayMoney").Trim() != "" ? HTTPRequest.GetString("sDoDayMoney") : "0");

                        
                        si.sDoDayMoney = sDoDayMoney;

                       
                        if (Act == "Edit")
                        {
                            

                                try
                                {
                                    tbStoresInfo.UpdateStoresInfo(si);
                                    AddMsgLine("修改成功!");
                                    AddScript("window.setTimeout('window.parent.HidBox();',2000);");
                                }
                                catch (Exception ex)
                                {
                                    AddErrLine("修改失败!<br/>" + ex);
                                    AddScript("window.setTimeout('window.parent.HidBox();',5000);");
                                }
                        }
                    }
                }
                else
                {
                    AddErrLine("权限不足!");
                    AddScript("window.setTimeout('window.parent.HidBox();',5000);");
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
            pagetitle = " 设置客户期初应收信息";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}