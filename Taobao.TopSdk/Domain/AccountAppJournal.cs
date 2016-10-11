using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// AccountAppJournal Data Structure.
    /// </summary>
    [Serializable]
    public class AccountAppJournal : TopObject
    {
        /// <summary>
        /// 资产类型
        /// </summary>
        [XmlElement("balance_type")]
        public long BalanceType { get; set; }

        /// <summary>
        /// 操作金额
        /// </summary>
        [XmlElement("deal_amount")]
        public long DealAmount { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [XmlElement("gmt_create")]
        public string GmtCreate { get; set; }

        /// <summary>
        /// 流水类型
        /// </summary>
        [XmlElement("journal_type")]
        public long JournalType { get; set; }

        /// <summary>
        /// 请求时间
        /// </summary>
        [XmlElement("response_time")]
        public string ResponseTime { get; set; }

        /// <summary>
        /// 交易号
        /// </summary>
        [XmlElement("trade_no")]
        public string TradeNo { get; set; }

        /// <summary>
        /// 用户id
        /// </summary>
        [XmlElement("user_id")]
        public long UserId { get; set; }
    }
}
