using System;
using System.IO;
using System.Web;
using System.Text.RegularExpressions;
using System.Text;

using Yannyo.Common;
using Yannyo.Config;
using Yannyo.Entity;
using Yannyo.Data;
using Yannyo.Public;
using Yannyo.BLL;
using System.Data;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Collections.Generic;

namespace Yannyo.Web
{
    /// <summary>
    /// 商城页面专用
    /// </summary>
    public class MPageBase : PageBase
    {
        /// <summary>
        /// 商品类目最后更新时间
        /// </summary>
        protected internal DateTime GoodsCatLastTime;

        /// <summary>
        /// 商品类目最后更新时间天数
        /// </summary>
        protected internal int GoodsCatLastTimeDay=0;

        /// <summary>
        /// 交易状态
        /// </summary>
        protected internal string[] TradeStatus = new string[] { "TRADE_NO_CREATE_PAY", "WAIT_BUYER_PAY",
            "WAIT_SELLER_SEND_GOODS", "WAIT_BUYER_CONFIRM_GOODS", "TRADE_BUYER_SIGNED","TRADE_FINISHED","TRADE_CLOSED","TRADE_CLOSED_BY_TAOBAO","ALL_WAIT_PAY","ALL_CLOSED" };
        protected internal string[] TradeStatusStr = new string[] { "没有创建支付宝交易", "等待买家付款", "等待卖家发货", "等待买家确认收货", "买家已签收", "交易成功", "交易关闭", "交易被淘宝关闭", "ALL_WAIT_PAY","关闭" };

        /// <summary>
        /// 货到付款物流状态
        /// </summary>
        protected internal string[] TradeCodStatus = new string[] { "NEW_CREATED", "CANCELED", "CLOSED", "WAITING_TO_BE_SENT", 
            "SENT_WAIT_4_COMPANY_MAKE_SURE", "WAIT_4_COMPANY_MAKE_SURE","ACCEPTED_BY_COMPANY","REJECTED_BY_COMPANY","TAKEN_IN_SUCCESS","TAKEN_IN_FAILED","LOST","SIGN_IN","REJECTED_BY_OTHER_SIDE" };
        protected internal string[] TradeCodStatusStr = new string[] { "订单已创建", "订单已取消", "订单已关闭", "等候发送给物流公司", 
            "等待物流公司接单", "物流公司接收到下单消息，等待接单", "物流公司已接单", "物流公司不接单", "物流公司揽收成功", "物流公司揽收失败","物流公司丢单","对方已签收","对方拒绝签收" };

        /// <summary>
        /// 交易来源
        /// </summary>
        protected internal string[] TradeFroms = new string[] { "WAP", "HITAO", "TOP", "TAOBAO" };
        protected internal string[] TradeFromsStr = new string[] { "手机", "嗨淘", "TOP平台", "普通淘宝" };

        /// <summary>
        /// 交易退款状态
        /// </summary>
        protected internal string[] TradeRefundStatus = new string[] { "WAIT_SELLER_AGREE", "WAIT_BUYER_RETURN_GOODS", "WAIT_SELLER_CONFIRM_GOODS", "SELLER_REFUSE_BUYER", "CLOSED", "SUCCESS" };
        protected internal string[] TradeRefundStatusStr = new string[] { "买家已经申请退款，等待卖家同意", "卖家已经同意退款，等待买家退货", "买家已经退货，等待卖家确认收货", "卖家拒绝退款", "退款关闭", "退款成功" };

        /// <summary>
        /// 交易类型
        /// </summary>
        protected internal string[] TradeTypes = new string[] { "FIXED", "AUCTION", "GUARANTEE_TRADE", "AUTO_DELIVERY", "INDEPENDENT_SIMPLE_TRADE", "INDEPENDENT_SHOP_TRADE", "EC", "COD", "FENXIAO", "GAME_EQUIPMENT", "SHOPEX_TRADE", "NETCN_TRADE", "EXTERNAL_TRADE" };
        protected internal string[] TradeTypesStr = new string[] { "一口价", "拍卖", "一口价、拍卖", "自动发货", "旺店入门版交易", "旺店标准版交易", "直冲", "货到付款", "分销", "游戏装备", "ShopEX交易", "万网交易", "统一外部交易" };

        /// <summary>
        /// 物流状态
        /// </summary>
        protected internal string[] TradeShippingTypes = new string[] { "FREE", "POST", "EXPRESS", "EMS", "VIRTUAL" };
        protected internal string[] TradeShippingTypesStr = new string[] { "卖家承担运费", "平邮", "快递", "EMS", "虚拟物品" };

        public MPageBase()
        {
            GoodsCatLastTime = M_Utils.GetM_GoodsCatLastTime(M_Config.m_ConfigInfoID);

            GoodsCatLastTimeDay = Convert.ToInt32(DateTime.Now.Subtract(GoodsCatLastTime).TotalDays);
        }
        /// <summary>
        /// 商品状态
        /// </summary>
        /// <returns></returns>
        public string GetApprove_status(string str)
        {
            string reStr = "";
            if (str.ToLower() == "onsale") {
                reStr = "已上架";
            }
            if (str.ToLower() == "instock")
            {
                reStr = "已下架";
            }
            return reStr;
        }
        /// <summary>
        /// 商品类型
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string GetGoods_Typess(string str)
        {
            string reStr = "";
            if (str.ToLower() == "fixed")
            {
                reStr = "一口价";
            }
            if (str.ToLower() == "auction")
            {
                reStr = "拍卖";
            }
            return reStr;
        }

        /// <summary>
        /// 交易类型
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string GetTrade_Types(string str)
        {
            return TradeTypesStr[GetArrayIndex(TradeTypes, str)];
        }
        /// <summary>
        /// 退款状态
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string GetTradeRefundStatus(string str)
        {
            return TradeRefundStatusStr[GetArrayIndex(TradeRefundStatus, str)];
        }
        /// <summary>
        /// 交易来源
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string GetTradeFroms(string str)
        {
            return TradeFromsStr[GetArrayIndex(TradeFroms, str)];
        }
        /// <summary>
        /// 货到付款物流状态
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string GetTradeCodStatus(string str)
        {
            return TradeCodStatusStr[GetArrayIndex(TradeCodStatus, str)];
        }
        /// <summary>
        /// 交易状态
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string GetTradeStatus(string str)
        {
            return TradeStatusStr[GetArrayIndex(TradeStatus, str)];
        }
        /// <summary>
        /// 交易状态
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public int GetTradeStatusIndex(string str)
        {
            return GetArrayIndex(TradeStatus, str);
        }
        /// <summary>
        /// 物流方式
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string GetTradeShippingTypes(string str)
        {
            return TradeShippingTypesStr[GetArrayIndex(TradeShippingTypes, str)];
        }
        /// <summary>
        /// 返回数组index
        /// </summary>
        /// <param name="sArray"></param>
        /// <param name="str"></param>
        /// <returns></returns>
        public int GetArrayIndex(string[] sArray,string str)
        {
            int reIndex = 0;
            for (int i = 0; i < sArray.Length;i++ )
            {
                if (sArray[i].ToUpper().Trim() == str.ToUpper().Trim())
                {
                    reIndex = i;
                    break;
                }
            }
            return reIndex;
        }

        /// <summary>
        /// 格式化时间
        /// </summary>
        /// <param name="tObj"></param>
        /// <returns></returns>
        public string FormatDateTime(object tObj)
        {
            if (tObj != null)
            {
                try
                {
                    DateTime nObj = Convert.ToDateTime(tObj);
                    if (nObj.Year == 1984)
                    {
                        return "";
                    }
                    else
                    {
                        return nObj.ToString();
                    }
                }
                catch
                {
                    return tObj.ToString();
                }
            }
            else {
                return "";
            }
        }

        /// <summary>
        /// 获取商品类目
        /// </summary>
        /// <returns></returns>
        public bool CheckGetGoodsCat()
        {
            //获取商品类目
            DataTable dt = Caches.GetGoodsCatList(M_Config.m_ConfigInfoID);
            try
            {
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        DataView dv = dt.DefaultView;
                        dv.Sort = "mUpdateTime";
                        dt = dv.ToTable();
                        if (DateTime.Now.Subtract(Convert.ToDateTime(dt.Rows[0]["m_UpdateTime"].ToString())).TotalDays >= 1)//一天获取一次
                        {
                            M_Utils.DeleteM_GoodsCatAll(M_Config.m_ConfigInfoID);
                            return TopApiUtils.GetGoodsCatListAll(M_Config, 0);
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return TopApiUtils.GetGoodsCatListAll(M_Config, 0);
                    }
                }
                else
                {
                    return true;
                }
            }
            finally {
                dt = null;
            }
        }
    }
}