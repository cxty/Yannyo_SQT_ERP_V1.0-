using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// RwtPrice Data Structure.
    /// </summary>
    [Serializable]
    public class RwtPrice : TopObject
    {
        /// <summary>
        /// 月租时长，单位月，一个月：1；季度：3；半年；6；一年：12；
        /// </summary>
        [XmlElement("duration")]
        public long Duration { get; set; }

        /// <summary>
        /// 插件价格的id
        /// </summary>
        [XmlElement("id")]
        public long Id { get; set; }

        /// <summary>
        /// 是否是默认价格，0 不是 ；1 是
        /// </summary>
        [XmlElement("is_default")]
        public long IsDefault { get; set; }

        /// <summary>
        /// 价格描述，最大长度64个字符
        /// </summary>
        [XmlElement("price_desc")]
        public string PriceDesc { get; set; }

        /// <summary>
        /// 价格 单位：元
        /// </summary>
        [XmlElement("rent_price")]
        public string RentPrice { get; set; }

        /// <summary>
        /// 月租单位 如:月、季、半年、年
        /// </summary>
        [XmlElement("rent_unit")]
        public string RentUnit { get; set; }
    }
}
