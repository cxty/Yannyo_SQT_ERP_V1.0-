using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Domain
{
    /// <summary>
    /// Cooperation Data Structure.
    /// </summary>
    [Serializable]
    public class Cooperation : TopObject
    {
        /// <summary>
        /// 供应商授权的支付方式：ALIPAY(支付宝)、OFFPREPAY(预付款)、OFFTRANSFER(转帐)、OFFSETTLEMENT(后期结算)
        /// </summary>
        [XmlArray("auth_payway")]
        [XmlArrayItem("string")]
        public List<string> AuthPayway { get; set; }

        /// <summary>
        /// 合作关系ID
        /// </summary>
        [XmlElement("cooperate_id")]
        public long CooperateId { get; set; }

        /// <summary>
        /// 分销商ID
        /// </summary>
        [XmlElement("distributor_id")]
        public long DistributorId { get; set; }

        /// <summary>
        /// 分销商nick
        /// </summary>
        [XmlElement("distributor_nick")]
        public string DistributorNick { get; set; }

        /// <summary>
        /// 等级ID
        /// </summary>
        [XmlElement("grade_id")]
        public long GradeId { get; set; }

        /// <summary>
        /// 授权产品线
        /// </summary>
        [XmlElement("product_line")]
        public string ProductLine { get; set; }

        /// <summary>
        /// 分销方式： AGENT(代销) 、DEALER(经销)
        /// </summary>
        [XmlElement("trade_type")]
        public string TradeType { get; set; }
    }
}
