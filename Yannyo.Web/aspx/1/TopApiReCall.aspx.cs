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
    /// <summary>
    /// 取淘宝API回调生成的客户SessionKey,通知等
    /// SessionKey:需通过 TopApiUtils.GetAuthorizeKey 获得授权码:AuthorizeKey,后才有回调
    /// </summary>
    public partial class topapirecall : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string ReStr = "";//返回字符串
            string ReType = (new string[] { "Buyer", "Seller", "Other", "request" })[HTTPRequest.GetInt("ReFormat", 1)];//返回类型
            string doAction = (new string[] { "top_appkey", "top_parameters", "top_session", "top_sign", "encode","notify" })[HTTPRequest.GetInt("Act", 2)];//动作类型,top_appkey,top_parameters,top_session,top_sign,encode
            
            ReStr = HTTPRequest.GetString(doAction);

            if (ReType != "request")
            {
                //获取SessionKey,更新配置信息
                if (doAction == "top_session")
                {
                    string AppKey = HTTPRequest.GetString("top_appkey");
                    M_ConfigInfo _mc = M_Utils.GetM_ConfigInfoModelByAppKey(AppKey);
                    if (_mc != null)
                    {
                        _mc.m_SessionKey = HTTPRequest.GetString("top_session");
                        _mc.m_UpdateTime = DateTime.Now;
                        try
                        {
                            M_Utils.UpdateM_ConfigInfo(_mc);
                            Caches.ReSet();//重置缓存
                            AddMsgLine("鉴权成功,请关闭该页面!");
                            AddScript("window.setTimeout('window.parent.HidBox();',1000);");
                        }
                        catch (Exception ex)
                        {
                            AddErrLine("系统内部错误:" + ex.Message);
                        }
                    }
                }
            }
            #region 通知
            if (ReType == "request")
            {
                //返回通知
                if (doAction == "notify")
                {
                    string method = Utils.ChkSQL(HTTPRequest.GetString("method"));
                    string timestamp = Utils.ChkSQL(HTTPRequest.GetString("timestamp"));
                    string format = Utils.ChkSQL(HTTPRequest.GetString("format"));
                    string app_key = Utils.ChkSQL(HTTPRequest.GetString("app_key"));
                    string v = Utils.ChkSQL(HTTPRequest.GetString("v"));
                    string sign = Utils.ChkSQL(HTTPRequest.GetString("sign"));
                    string message = Utils.ChkSQL(HTTPRequest.GetString("message"));
                    /*
                    商品相关

                    1) 新增商品（ItemAdd） ：通过taobao.item.add 添加一个商品 

                    2) 上架商品（ItemUpshelf）：通过taobao.item.update.listing 进行一口价商品上架 

                    3) 下架商品ItemDownshelf ：通过taobao.item.update.delisting 使商品下架 

                    4) 删除商品（ItemDelete）：通过taobao.item.delete 删除了单条商品 

                    5) 更新商品（ItemUpdate）：通过taobao.item.update 更新了商品信息 

                    6) 取消橱窗推荐商品（temRecommendDelete）：通过调用taobao.item.recommend.delete 取消橱窗推荐一个商品 

                    7) 橱窗推荐商品（ItemRecommendAdd）：通过taobao.item.recommend.add 橱窗推荐一个商品 

                    8) 商品卖空（ItemZeroStock）：架上数量为0的时候 

                    9) 小二删除商品 （ItemPunishDelete）：由于商品违规等原因被小二删除 

                    交易相关
                    1) 创建交易TradeCreate：买家点击了购买，交易状态为创建交易 

                    2) 修改交易费用TradeModifyFee：在买家未付款之前，卖家根据实际情况能修改交易费用 

                    3) 关闭或修改子订单TradeCloseAndModifyDetailOrder：在买家未付款之前，卖家可以关闭或者修改子订单信息 

                    4) 关闭交易TradeClose：在买家未付款之前，卖家或买家关闭这笔交易 

                    5) 买家付款TradeBuyerPay：买家以支付宝等形式进行付款 

                    6) 卖家发货TradeSellerShip：买家付款后，卖家进行发货操作 

                    7) 延长收货时间TradeDelayConfirmPay：买家延长收货的时间 

                    8) 子订单退款成功TradePartlyRefund：买家对一笔交易中的子订单中的商品不满意，申请退款，卖家同意后进行退款 

                    9) 子订单打款成功TradePartlyConfirmPay 买家对交易中的子订单付款成功 

                    10) 交易成功TradeSuccess 

                    11) 交易超时提醒TradeTimeoutRemind 

                    12) 交易评价变更TradeRated：买家改变原先的评价 

                    13) 交易备注修改TradeMemoModified：在交易创建后，买家或者卖家修改交易备注 

                    14) 修改交易收货地址TradeLogisticsAddressChanged 

                    15) 修改订单信息（SKU等）TradeChanged：买家未付款之前，卖家修改sku等信息 
 
                    退款相关
                    1) 退款成功RefundSuccess 

                    2) 退款关闭RefundClosed：退款申请未成功然后退款关闭 

                    3) 退款创建RefundCreated：买家收到货，不满意可以进入“我的淘宝”—“我是买家”—“已买到的宝贝”页面找到对应交易订单，点击“申请退款” 

                    4) 卖家同意退款协议RefundSellerAgreeAgreement：卖家收到退款申请，点击同意退款协议 

                    5) 卖家拒绝退款协议RefundSellerRefuseAgreement：卖家收到退款申请，点击拒绝退款协议 

                    6) 买家修改退款协议RefundBuyerModifyAgreement：如果买家开始是拒绝退款协议，修改成了同意，订阅后返回买家修改退款协议信息 

                    7) 买家退货给卖家RefundBuyerReturnGoods：买家收到货不满意申请退货 

                    8) 发表退款留言RefundCreateMessage：在退款协议中发表留言 

                    9) 屏蔽退款留言RefundBlockMessage 

                    10) 退款超时提醒RefundTimeoutRemind：根据退款超时规则，超过规则中的期限。
                    */
                    if (app_key.Trim() != "")
                    {
                        try
                        {
                            M_ConfigInfo mc = new M_ConfigInfo();
                            mc = M_Utils.GetM_ConfigInfoModelByAppKey(app_key.Trim());
                            if (mc != null)
                            {
                                switch (method)
                                {
                                    case "TradeCreate":
                                    case "TradeModifyFee":
                                    case "TradeCloseAndModifyDetailOrder":
                                    case "TradeClose":
                                    case "TradeBuyerPay":
                                    case "TradeSellerShip":
                                    case "TradeDelayConfirmPay":
                                    case "TradePartlyRefund":
                                    case "TradePartlyConfirmPay":
                                    case "TradeSuccess":
                                    case "TradeTimeoutRemind":
                                    case "TradeMemoModified":
                                    case "TradeLogisticsAddressChanged":
                                    case "TradeChanged":
                                    case "TradeRated":
                                        GetTrades(mc);
                                        break;
                                }
                            }
                        }
                        catch { 
                        
                        }
                    }
                }

                Response.Charset = "utf-8";
                Response.ContentEncoding = System.Text.Encoding.GetEncoding("utf-8");
                Response.ContentType = "text/html";
                Response.Write("true");
                Response.End();
            }
            #endregion
        }
        public void GetTrades(M_ConfigInfo mc)
        {
            PublicReMSG reValue = new PublicReMSG();
            DataTable dList = new DataTable();
            try
            {
                reValue = TopApiUtils.GetTradesList(mc, DateTime.Now.AddMonths(-2).ToString(), DateTime.Now.ToString(), null, null, null, null, null, 1, 100);
                if (reValue.reCode == 0)
                {
                     dList = reValue.reObj as DataTable;
                     if (dList != null)
                     {
                         foreach (DataRow dr in dList.Rows)
                         {
                             reValue = TopApiUtils.GetTradesFullInfo(mc, long.Parse(dr["tid"].ToString()));
                             try
                             {
                                 if (reValue.reCode == 0)
                                 {
                                     M_TradeInfo mTrade = new M_TradeInfo();
                                     try
                                     {
                                         mTrade = reValue.reObj as M_TradeInfo;
                                         if (mTrade != null)
                                         {
                                             int m_TradeInfoID = M_Utils.ExistsM_TradeInfoAndReID(mc.m_ConfigInfoID, long.Parse(dr["tid"].ToString()));
                                             if (m_TradeInfoID > 0)
                                             {
                                                 mTrade.m_TradeInfoID = m_TradeInfoID;
                                                 mTrade.m_ConfigInfoID = mc.m_ConfigInfoID;

                                                 M_Utils.UpdateM_TradeInfo(mTrade);
                                             }
                                             else
                                             {
                                                 mTrade.m_ConfigInfoID = mc.m_ConfigInfoID;

                                                 M_Utils.AddM_TradeInfo(mTrade);
                                             }
                                         }
                                     }
                                     finally {
                                         mTrade = null;
                                     }
                                 }
                             }
                             catch (Exception ex)
                             {
                                 
                             }
                             finally
                             {
                                 reValue = null;
                             }
                         }
                     }
                }
            }
            finally {
                dList = null;
                reValue = null;
            }
        }
        protected override void ShowPage()
        {
            pagetitle = " 回调";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}