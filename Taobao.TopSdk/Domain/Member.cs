using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// Member Data Structure.
    /// </summary>
    [Serializable]
    public class Member : TopObject
    {
        /// <summary>
        /// 买家数字ID
        /// </summary>
        [XmlElement("buyer_id")]
        public string BuyerId { get; set; }

        /// <summary>
        /// 买家昵称
        /// </summary>
        [XmlElement("buyer_nick")]
        public string BuyerNick { get; set; }

        /// <summary>
        /// 上次交易时间：会员在该卖家店铺最后的交易时间
        /// </summary>
        [XmlElement("laste_time")]
        public string LasteTime { get; set; }

        /// <summary>
        /// 买家会员级别 general：普通会员 senior ：高级会员 vip：VIP会员 king：至尊VIP
        /// </summary>
        [XmlElement("member_grade")]
        public string MemberGrade { get; set; }

        /// <summary>
        /// 状态：  normal：正常  deleted：删除  blacklist ：黑名单
        /// </summary>
        [XmlElement("status")]
        public string Status { get; set; }

        /// <summary>
        /// 总交易额用分表示
        /// </summary>
        [XmlElement("trade_amount")]
        public long TradeAmount { get; set; }

        /// <summary>
        /// 总交易量：会员在该卖家的交易笔数
        /// </summary>
        [XmlElement("trade_count")]
        public long TradeCount { get; set; }
    }
}
