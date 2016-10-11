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
    public partial class mtrade_do : MPageBase
    {
        public string Act = "";
        public DataTable dList = new DataTable();
        public int pagesize;
        public int pageindex;
        public int pagetotal;
        public string reformat = "";
        public string reVal = "";
        public PublicReMSG reValue = new PublicReMSG();
        public M_TradeInfo mTrade = new M_TradeInfo();
        public string tid = "";//交易号
        public int m_TradeInfoID = 0;

        protected virtual void Page_Load(object sender, EventArgs e)
        {
            reformat = HTTPRequest.GetString("reformat");
            if (this.userid > 0)
            {
                if (CheckUserPopedoms("X") || CheckUserPopedoms("8-2-1") || CheckUserPopedoms("8-2-2-1") || CheckUserPopedoms("8-2-2-2") || CheckUserPopedoms("8-2-2-3") || CheckUserPopedoms("8-2-2-4") || CheckUserPopedoms("8-2-2-5") || CheckUserPopedoms("8-2-2-6"))
                {
                    Act = HTTPRequest.GetString("Act");
                    
                    if (HTTPRequest.GetString("page").Trim() != "" && Utils.IsInt(HTTPRequest.GetString("page").Trim()))
                    {
                        pageindex = int.Parse(HTTPRequest.GetString("page").Trim());
                    }
                    else
                    {
                        pageindex = 1;
                    }
                    tid = Utils.ChkSQL(HTTPRequest.GetString("tid"));

                    #region 下载交易列表
                    if (Act == "DownLoad")
                    {
                        if (CheckUserPopedoms("X") || CheckUserPopedoms("8-2-1"))
                        {
                            if (!ispost)
                            {
                                //取两个月数据
                                reValue = TopApiUtils.GetTradesList(M_Config, DateTime.Now.AddMonths(-2).ToString(), DateTime.Now.ToString(), null, null, null, null, null, pageindex, 100);
                                if (reValue.reCode == 0)
                                {
                                    dList = reValue.reObj as DataTable;
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
                            else
                            {
                                if (tid.Trim() != "")
                                {
                                    reVal = ",\"ReValue\":{\"tid\":\"" + tid + "\"}";
                                    reValue = TopApiUtils.GetTradesFullInfo(M_Config, long.Parse(tid));
                                    try
                                    {
                                        if (reValue.reCode == 0)
                                        {
                                            mTrade = reValue.reObj as M_TradeInfo;
                                            if (mTrade != null)
                                            {
                                                reVal += ",\"Trade\":{\"type\":\"" + GetTrade_Types(mTrade.type.ToString()) + "\",\"shipping_type\":\"" + GetTradeShippingTypes(mTrade.shipping_type.ToString()) + "\",\"status\":\"" + GetTradeStatus(mTrade.status.ToString()) + "\",\"trade_from\":\"" + GetTradeFroms(mTrade.trade_from.ToString()) + "\","+
                                                    "\"seller_rate\":\"" + (mTrade.seller_rate ? "是" : "否") + "\",\"buyer_rate\":\"" + (mTrade.buyer_rate ? "是" : "否") + "\",\"pay_time\":\"" + mTrade.pay_time + "\",\"modified\":\"" + mTrade.modified + "\",\"total_fee\":\"" + mTrade.total_fee + "\",\"post_fee\":\"" + mTrade.post_fee + "\"}";
                                                m_TradeInfoID = M_Utils.ExistsM_TradeInfoAndReID(M_Config.m_ConfigInfoID, long.Parse(tid));
                                                if (m_TradeInfoID > 0)
                                                {
                                                    mTrade.m_TradeInfoID = m_TradeInfoID;
                                                    mTrade.m_ConfigInfoID = M_Config.m_ConfigInfoID;

                                                    M_Utils.UpdateM_TradeInfo(mTrade);
                                                }
                                                else
                                                {
                                                    mTrade.m_ConfigInfoID = M_Config.m_ConfigInfoID;

                                                    M_Utils.AddM_TradeInfo(mTrade);
                                                }
                                            }
                                            else
                                            {
                                                AddErrLine("交易信息获取失败!");
                                            }
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
                                    catch (Exception ex)
                                    {
                                        AddErrLine("系统错误:" + ex.Message);
                                    }
                                    finally
                                    {
                                        reValue = null;
                                    }
                                }
                                else {
                                    AddErrLine("参数错误:交易号不能为空!");
                                }
                            }
                        }else{
                            AddErrLine("权限不足!");
                        }
                    }
                    #endregion

                    #region 删除
                    if (Act == "Delete")
                    {
                        if (CheckUserPopedoms("X") || CheckUserPopedoms("8-2-2-7"))
                        {
                            if(ispost)
                            {
                                if (tid.Trim() != "")
                                {
                                    int m_TradeInfoID = HTTPRequest.GetInt("m_TradeInfoID",0);
                                    reVal = ",\"ReValue\":{\"tid\":\"" + tid + "\"}";
                                    try
                                    {
                                        M_Utils.DeleteM_TradeInfo(M_Config.m_ConfigInfoID, m_TradeInfoID);
                                        AddMsgLine("删除成功.");
                                    }
                                    catch (Exception ex)
                                    {
                                        AddErrLine("系统错误:" + ex.Message);
                                    }
                                }else {
                                    AddErrLine("参数错误:交易号不能为空!");
                                }
                            }
                        }
                        else
                        {
                            AddErrLine("权限不足!");
                        }
                    }
                    #endregion

                    #region 关闭
                    if (Act == "Close")
                    {
                        if (CheckUserPopedoms("X") || CheckUserPopedoms("8-2-2-1"))
                        {
                            if (ispost)
                            {
                                if (tid.Trim() != "")
                                {
                                    int m_TradeInfoID = HTTPRequest.GetInt("m_TradeInfoID", 0);
                                    string Close_Str = HTTPRequest.GetString("Close_Msg");
                                    reVal = ",\"ReValue\":{\"tid\":\"" + tid + "\"}";
                                    try
                                    {
                                        reValue = TopApiUtils.CloseTrade(M_Config, long.Parse(tid), Close_Str);
                                        try
                                        {
                                            if (reValue.reCode == 0)
                                            {
                                                M_Utils.UpdateM_TradeStatus(m_TradeInfoID, "TRADE_CLOSED");
                                                AddMsgLine("关闭成功.");
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
                                        finally {
                                            reValue = null;
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        AddErrLine("系统错误:" + ex.Message);
                                    }
                                }
                                else
                                {
                                    AddErrLine("参数错误:交易号不能为空!");
                                }
                            }
                        }
                        else
                        {
                            AddErrLine("权限不足!");
                        }
                    }
                    #endregion
                }
                else
                {
                    AddErrLine("权限不足!");
                    AddScript("window.setTimeout('window.parent.HidBox();',1000);");
                }
            }
            else
            {
                AddErrLine("请先登录!");
                SetBackLink("login.aspx?referer=" + Utils.UrlEncode(Utils.GetUrlReferrer()));
                SetMetaRefresh(1, "login.aspx?referer=" + Utils.UrlEncode(Utils.GetUrlReferrer()));
            }
            if (reformat == "json")
            {
                Response.ClearContent();
                Response.Buffer = true;
                Response.ExpiresAbsolute = System.DateTime.Now.AddYears(-1);
                Response.Expires = 0;

                Response.Charset = "utf-8";
                Response.ContentEncoding = System.Text.Encoding.GetEncoding("utf-8");
                Response.ContentType = "application/json";
                string Json_Str = "{\"results\": {\"msg\":\"" + this.msgbox_text + "\",\"state\":\"" + (!IsErr()).ToString() + "\"" + reVal + "}}";
                Response.Write(Json_Str);
                Response.End();
            }
        }
        protected override void ShowPage()
        {
            pagetitle = " 网店交易列表";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}