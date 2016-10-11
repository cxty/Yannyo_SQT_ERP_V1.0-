using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// StoreBill Data Structure.
    /// </summary>
    [Serializable]
    public class StoreBill : TopObject
    {
        /// <summary>
        /// 运费, 以分为单位.
        /// </summary>
        [XmlElement("carriage_costs")]
        public string CarriageCosts { get; set; }

        /// <summary>
        /// 订单处理费, 以分为单位.
        /// </summary>
        [XmlElement("order_costs")]
        public string OrderCosts { get; set; }

        /// <summary>
        /// 仓库租赁费, 以分为单位.
        /// </summary>
        [XmlElement("rend_costs")]
        public string RendCosts { get; set; }

        /// <summary>
        /// 自定义仓库id
        /// </summary>
        [XmlElement("seller_store_id")]
        public string SellerStoreId { get; set; }
    }
}
