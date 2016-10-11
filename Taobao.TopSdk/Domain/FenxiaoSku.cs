using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// FenxiaoSku Data Structure.
    /// </summary>
    [Serializable]
    public class FenxiaoSku : TopObject
    {
        /// <summary>
        /// 采购价格，单位：元
        /// </summary>
        [XmlElement("cost_price")]
        public string CostPrice { get; set; }

        /// <summary>
        /// SkuID
        /// </summary>
        [XmlElement("id")]
        public string Id { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [XmlElement("name")]
        public string Name { get; set; }

        /// <summary>
        /// 商家编码
        /// </summary>
        [XmlElement("outer_id")]
        public string OuterId { get; set; }

        /// <summary>
        /// 库存
        /// </summary>
        [XmlElement("quantity")]
        public string Quantity { get; set; }

        /// <summary>
        /// 市场价
        /// </summary>
        [XmlElement("standard_price")]
        public string StandardPrice { get; set; }
    }
}
