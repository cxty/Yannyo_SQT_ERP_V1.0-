using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// GuarantyFund Data Structure.
    /// </summary>
    [Serializable]
    public class GuarantyFund : TopObject
    {
        /// <summary>
        /// 投诉编号（退款ID）
        /// </summary>
        [XmlElement("accuse_id")]
        public long AccuseId { get; set; }

        /// <summary>
        /// 保证金金额
        /// </summary>
        [XmlElement("amount")]
        public long Amount { get; set; }

        /// <summary>
        /// 保证金余额
        /// </summary>
        [XmlElement("balance")]
        public long Balance { get; set; }

        /// <summary>
        /// 买家编号
        /// </summary>
        [XmlElement("buyer_id")]
        public long BuyerId { get; set; }

        /// <summary>
        /// 买家昵称
        /// </summary>
        [XmlElement("buyer_nick")]
        public string BuyerNick { get; set; }

        /// <summary>
        /// 保证金创建时间
        /// </summary>
        [XmlElement("created")]
        public string Created { get; set; }

        /// <summary>
        /// 保证金创建者
        /// </summary>
        [XmlElement("creator")]
        public string Creator { get; set; }

        /// <summary>
        /// 保证金编号
        /// </summary>
        [XmlElement("id")]
        public long Id { get; set; }

        /// <summary>
        /// 备注（一般为操作类型加上操作动作）
        /// </summary>
        [XmlElement("memo")]
        public string Memo { get; set; }

        /// <summary>
        /// 保证金修改时间
        /// </summary>
        [XmlElement("modified")]
        public string Modified { get; set; }

        /// <summary>
        /// 保证金操作动作
        /// </summary>
        [XmlElement("operation_action")]
        public string OperationAction { get; set; }

        /// <summary>
        /// 保证金操作类型 (入驻商城冻结1，补缴保证金2，交易纠纷3，退出商城解冻4，提高保证金额度5，降低保证金额度6，人工解冻保证金7，人工转移保证金8，返点9)
        /// </summary>
        [XmlElement("operation_type")]
        public long OperationType { get; set; }

        /// <summary>
        /// 保证金操作者
        /// </summary>
        [XmlElement("operator")]
        public string Operator { get; set; }

        /// <summary>
        /// 淘宝交易号（主订单的编号）
        /// </summary>
        [XmlElement("order_id")]
        public long OrderId { get; set; }

        /// <summary>
        /// 商家编号
        /// </summary>
        [XmlElement("seller_id")]
        public long SellerId { get; set; }

        /// <summary>
        /// 商家昵称
        /// </summary>
        [XmlElement("seller_nick")]
        public string SellerNick { get; set; }

        /// <summary>
        /// 保证金状态（失败0，成功1）
        /// </summary>
        [XmlElement("status")]
        public long Status { get; set; }

        /// <summary>
        /// 保证金类型（冻结保证金1，解冻保证金2，转移保证金3）
        /// </summary>
        [XmlElement("type")]
        public long Type { get; set; }
    }
}
