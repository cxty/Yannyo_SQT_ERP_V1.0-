using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// WarehouseItem Data Structure.
    /// </summary>
    [Serializable]
    public class WarehouseItem : TopObject
    {
        /// <summary>
        /// 条形码/货号。最大长度为64个字符，一个汉字算两个字符
        /// </summary>
        [XmlElement("bar_code")]
        public string BarCode { get; set; }

        /// <summary>
        /// 商品id
        /// </summary>
        [XmlElement("item_id")]
        public long ItemId { get; set; }

        /// <summary>
        /// 商品名称。最大长度为256字符，一个汉字算两个字符
        /// </summary>
        [XmlElement("item_name")]
        public string ItemName { get; set; }

        /// <summary>
        /// 自定义属性。最大长度为256字符，一个汉字算两个字符
        /// </summary>
        [XmlElement("memo")]
        public string Memo { get; set; }

        /// <summary>
        /// 商家编码。和卖家发布商品的商家编码保持一致，商家编码唯一，最大长度为64个字符
        /// </summary>
        [XmlElement("outer_id")]
        public string OuterId { get; set; }
    }
}
