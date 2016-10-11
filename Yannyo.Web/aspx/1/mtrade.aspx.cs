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
    public partial class mtrade : MPageBase
    {
        public DataTable dList = new DataTable();//交易列表
        public DataTable oList = new DataTable();//订单列表
        public int pagesize;
        public int pageindex;
        public int pagetotal;
        public string Act = "";
        public string S_key = "";
        public int status = -1;//交易状态
        public int sendgoods = -1;//发货状态
        public int rate = -1;//平价状态
        public string status_str = "";//交易状态字符串

        public decimal sum_a = 0;
        public decimal sum_b = 0;
        public decimal sum_c = 0;
        public decimal sum_d = 0;
        public decimal sum_e = 0;

        public string oDateTimeB = "";
        public string oDateTimeE = "";

        protected virtual void Page_Load(object sender, EventArgs e)
        {
            pagesize = 30;
            PageBarHTML = "";
            if (this.userid > 0)
            {
                if (CheckUserPopedoms("X") || CheckUserPopedoms("8-2-1"))
                {
                    string tSQL = "";
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
                        S_key = Utils.ChkSQL(HTTPRequest.GetFormString("S_key"));
                    }
                    else
                    {
                        Act = HTTPRequest.GetQueryString("Act");
                        S_key = Utils.ChkSQL(HTTPRequest.GetQueryString("S_key"));
                    }
                    if (M_Config != null)
                    {
                        status = HTTPRequest.GetInt("status", -1);
                        sendgoods = HTTPRequest.GetInt("sendgoods", -1);
                        rate = HTTPRequest.GetInt("rate", -1);

                        oDateTimeB =Utils.ChkSQL(HTTPRequest.GetString("oDateTimeB"));
                        oDateTimeE = Utils.ChkSQL(HTTPRequest.GetString("oDateTimeE"));

                        tSQL = " m_ConfigInfoID = " + M_Config.m_ConfigInfoID;

                        //交易状态
                        if (status > -1)
                        {
                            if (status <= TradeStatusStr.Length)
                            {
                                status_str = TradeStatus[status];
                            }
                        }
                        //发货状态
                        if (sendgoods > -1)
                        { 
                        }
                       //平价状态
                        if (rate > -1)
                        {
                            switch (rate)
                            {
                                case 0://买家未评价
                                    tSQL += " and m_TradeInfoID in(select m_TradeInfoID from tb_M_OrderInfo where buyer_rate=0)";
                                    break;
                                case 1://买家已经评价
                                    tSQL += " and m_TradeInfoID in(select m_TradeInfoID from tb_M_OrderInfo where buyer_rate=1)";
                                    break;
                                case 2://卖家未评价
                                    tSQL += " and m_TradeInfoID in(select m_TradeInfoID from tb_M_OrderInfo where seller_rate=0)";
                                    break;
                                case 3://卖家已评价
                                    tSQL += " and m_TradeInfoID in(select m_TradeInfoID from tb_M_OrderInfo where seller_rate=1)";
                                    break;
                                case 4://双方未评价
                                    tSQL += " and m_TradeInfoID in(select m_TradeInfoID from tb_M_OrderInfo where buyer_rate=0 and seller_rate=0)";
                                    break;
                                case 5://双方已评价
                                    tSQL += " and m_TradeInfoID in(select m_TradeInfoID from tb_M_OrderInfo where buyer_rate=1 and seller_rate=1)";
                                    break;
                            }
                        }

                        if (Utils.IsDateString(oDateTimeB))
                        {
                            tSQL += " and created>='" + oDateTimeB + "'";
                        }
                        if (Utils.IsDateString(oDateTimeE))
                        {
                            tSQL += " and created<='" + oDateTimeE + "'";
                        }
                        //退款交易
                        //if (Act == "refund")
                        //{
                            //tSQL += " and m_OrderRefundInfoID in(select m_OrderRefundInfoID from tb_M_OrderRefundInfo where m_ConfigInfoID=tb_M_TradeInfo.m_ConfigInfoID and tid=tb_M_TradeInfo.tid)";
                        //}
                        //已完成的交易
                        //if(Act=="ok")
                        //{
                        //    tSQL += " and status in('TRADE_FINISHED','TRADE_CLOSED','TRADE_CLOSED_BY_TAOBAO','ALL_CLOSED')";
                        //}

                        if (status_str.Trim() != "")
                        {
                            tSQL += " and status = '" + status_str.Trim() + "'";
                        }

                        if (S_key.Trim() != "")
                        {
                            tSQL += " and (charindex('" + S_key.Trim() + "',[title])>0 "+
                                "or charindex('" + S_key.Trim() + "',[buyer_message])>0 "+
                                "or charindex('" + S_key.Trim() + "',[buyer_memo])>0 "+
                                "or charindex('" + S_key.Trim() + "',[seller_memo])>0 "+
                                "or charindex('" + S_key.Trim() + "',[trade_memo])>0 "+
                                "or charindex('" + S_key.Trim() + "',[buyer_alipay_no])>0 "+
                                "or charindex('" + S_key.Trim() + "',[receiver_name])>0 "+
                                "or charindex('" + S_key.Trim() + "',[receiver_state])>0 "+
                                "or charindex('" + S_key.Trim() + "',[receiver_city])>0 "+
                                "or charindex('" + S_key.Trim() + "',[receiver_district])>0 " +
                                "or charindex('" + S_key.Trim() + "',[receiver_address])>0 " +
                                "or charindex('" + S_key.Trim() + "',[receiver_zip])>0 " +
                                "or charindex('" + S_key.Trim() + "',[receiver_mobile])>0 " +
                                "or charindex('" + S_key.Trim() + "',[receiver_phone])>0 " +
                                "or charindex('" + S_key.Trim() + "',[buyer_email])>0 " +
                                "or charindex('" + S_key.Trim() + "',[promotion])>0 " +
                                "or charindex('" + S_key.Trim() + "',[invoice_name])>0 " +
                                ")";
                        }

                       
                        dList = M_Utils.GetM_TradeInfoList(pagesize, pageindex, tSQL, out pagetotal, 1, "*");
                        
                        if (dList != null)
                        {
                            //取交易号列表
                            string m_TradeInfoIDStr = "0";
                            foreach(DataRow dr in dList.Rows)
                            {
                                m_TradeInfoIDStr += "," + dr["m_TradeInfoID"].ToString();
                            }
                            oList = M_Utils.GetM_OrderInfoList(" m_ConfigInfoID=" + M_Config.m_ConfigInfoID + " and m_TradeInfoID in(" + m_TradeInfoIDStr + ")").Tables[0];
                        }
                        PageBarHTML = Utils.TenPage(pageindex, pagetotal, 0, "&Act=" + Act + "&S_key=" + S_key);
                    }
                }
                else
                {
                    AddErrLine("权限不足!");
                    AddScript("window.parent.HidBox();");
                }
            }
            else
            {
                AddErrLine("请先登录!");
                SetBackLink("login.aspx?referer=" + Utils.UrlEncode(Utils.GetUrlReferrer()));
                SetMetaRefresh(1, "login.aspx?referer=" + Utils.UrlEncode(Utils.GetUrlReferrer()));
            }
        }
        //外部页面调用,取发货单信息
        public M_SendGoodsInfo GetSendGoods(string m_TradeInfoID)
        {
            M_SendGoodsInfo _ms = new M_SendGoodsInfo();
            _ms = M_Utils.GetM_SendGoodsInfoModelBym_TradeInfoID(Convert.ToInt32(m_TradeInfoID));
            if (_ms != null)
            {
                return _ms;
            }
            else {
                return null;
            }
        }
        protected override void ShowPage()
        {
            pagetitle = " 网店交易列表";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}