using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// WarehouseOrder Data Structure.
    /// </summary>
    [Serializable]
    public class WarehouseOrder : TopObject
    {
        /// <summary>
        /// 物流公司id
        /// </summary>
        [XmlElement("company_id")]
        public long CompanyId { get; set; }

        /// <summary>
        /// 淘宝物流平台物流订单编号
        /// </summary>
        [XmlElement("order_code")]
        public string OrderCode { get; set; }

        /// <summary>
        /// 订单唯一标识
        /// </summary>
        [XmlElement("order_id")]
        public string OrderId { get; set; }

        /// <summary>
        /// 物流订单状态TO_BE_SENT（待处理）SIGN_IN（已签收）REJECTED_BY_OTHER_SIDE（签收失败）
        /// </summary>
        [XmlElement("order_status")]
        public string OrderStatus { get; set; }

        /// <summary>
        /// 物流公司运单号
        /// </summary>
        [XmlElement("out_sid")]
        public string OutSid { get; set; }

        /// <summary>
        /// 收货人详细地址
        /// </summary>
        [XmlElement("receiver_address")]
        public string ReceiverAddress { get; set; }

        /// <summary>
        /// 收货人姓名
        /// </summary>
        [XmlElement("receiver_name")]
        public string ReceiverName { get; set; }

        /// <summary>
        /// 自定义仓库ID
        /// </summary>
        [XmlElement("seller_store_id")]
        public string SellerStoreId { get; set; }

        /// <summary>
        /// 淘宝业务订单号
        /// </summary>
        [XmlElement("tid")]
        public long Tid { get; set; }

        /// <summary>
        /// 支付宝交易号
        /// </summary>
        [XmlElement("trade_id")]
        public string TradeId { get; set; }
    }
}
