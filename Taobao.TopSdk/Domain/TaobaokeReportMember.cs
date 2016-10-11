using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// TaobaokeReportMember Data Structure.
    /// </summary>
    [Serializable]
    public class TaobaokeReportMember : TopObject
    {
        /// <summary>
        /// 应用授权码
        /// </summary>
        [XmlElement("app_key")]
        public string AppKey { get; set; }

        /// <summary>
        /// 所购买商品的类目ID
        /// </summary>
        [XmlElement("category_id")]
        public long CategoryId { get; set; }

        /// <summary>
        /// 所购买商品的类目名称
        /// </summary>
        [XmlElement("category_name")]
        public string CategoryName { get; set; }

        /// <summary>
        /// 用户获得的佣金
        /// </summary>
        [XmlElement("commission")]
        public string Commission { get; set; }

        /// <summary>
        /// 佣金比率。比如：0.01代表1%
        /// </summary>
        [XmlElement("commission_rate")]
        public string CommissionRate { get; set; }

        /// <summary>
        /// 商品字符串ID(注意：iid近期即将废弃，请用num_iid参数)
        /// </summary>
        [XmlElement("iid")]
        public string Iid { get; set; }

        /// <summary>
        /// 商品成交数量
        /// </summary>
        [XmlElement("item_num")]
        public long ItemNum { get; set; }

        /// <summary>
        /// 商品标题
        /// </summary>
        [XmlElement("item_title")]
        public string ItemTitle { get; set; }

        /// <summary>
        /// 商品ID
        /// </summary>
        [XmlElement("num_iid")]
        public long NumIid { get; set; }

        /// <summary>
        /// 推广渠道
        /// </summary>
        [XmlElement("outer_code")]
        public string OuterCode { get; set; }

        /// <summary>
        /// 成交价格
        /// </summary>
        [XmlElement("pay_price")]
        public string PayPrice { get; set; }

        /// <summary>
        /// 成交时间
        /// </summary>
        [XmlElement("pay_time")]
        public string PayTime { get; set; }

        /// <summary>
        /// 实际支付金额
        /// </summary>
        [XmlElement("real_pay_fee")]
        public string RealPayFee { get; set; }

        /// <summary>
        /// 卖家昵称
        /// </summary>
        [XmlElement("seller_nick")]
        public string SellerNick { get; set; }

        /// <summary>
        /// 店铺名称
        /// </summary>
        [XmlElement("shop_title")]
        public string ShopTitle { get; set; }

        /// <summary>
        /// 淘宝交易号
        /// </summary>
        [XmlElement("trade_id")]
        public long TradeId { get; set; }
    }
}
