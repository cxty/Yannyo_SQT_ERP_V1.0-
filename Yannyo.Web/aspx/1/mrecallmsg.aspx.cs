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
using Yannyo.Cache;
using Yannyo.Common;
using Yannyo.Entity;
using Yannyo.BLL;

namespace Yannyo.Web
{
    public partial class mrecallmsg : MPageBase
    {
        public string Act = "";
        public int m_TradeInfoID = 0;
        public M_TradeInfo mTrade = new M_TradeInfo();
        public string tMsg = "";
        public int flag = 0;
        protected virtual void Page_Load(object sender, EventArgs e)
        {
            if (this.userid > 0)
            {
                Act = HTTPRequest.GetString("Act");
                tMsg = Utils.ChkSQL( HTTPRequest.GetString("tMsg"));
                flag = HTTPRequest.GetInt("flag",0);
                    if (Act == "TradeMemo")
                    {
                        if (CheckUserPopedoms("X") || CheckUserPopedoms("8-2-2-4"))
                        {
                            m_TradeInfoID = HTTPRequest.GetInt("m_TradeInfoID", 0);
                            if (m_TradeInfoID > 0)
                            {
                                mTrade = M_Utils.GetM_TradeInfoModel(m_TradeInfoID);
                                if (mTrade != null)
                                {
                                    if (mTrade.m_ConfigInfoID == M_Config.m_ConfigInfoID)
                                    {
                                        if (ispost)
                                        {
                                            mTrade.seller_memo = tMsg;
                                            PublicReMSG reValue = TopApiUtils.UpdateTradeMemo(M_Config, mTrade.tid, tMsg, flag, false);
                                            try
                                            {
                                                if (reValue.reCode == 0)
                                                {
                                                    M_Utils.UpdateM_TradeInfo(mTrade);
                                                    AddMsgLine("更新成功!");
                                                    AddScript("window.setTimeout('window.parent.HidBox();',1000);");
                                                }
                                                else
                                                {
                                                    //判断是否有Session相关错误
                                                    if (reValue.reCodeStr.ToLower().IndexOf("session") > 0)
                                                    {
                                                        ShowMSign = true;//前台弹出登录授权框
                                                    }
                                                    AddErrLine("远端错误:" + reValue.reCodeStr + "," + reValue.reMSG);
                                                }
                                            }
                                            finally
                                            {
                                                reValue = null;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        AddErrLine("参数错误!不匹配的配置编号!");
                                    }
                                }
                                else
                                {
                                    AddErrLine("参数错误!");
                                }
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
            pagetitle = " 消息输入框";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}