using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// ProductCat Data Structure.
    /// </summary>
    [Serializable]
    public class ProductCat : TopObject
    {
        /// <summary>
        /// 产品线ID
        /// </summary>
        [XmlElement("id")]
        public string Id { get; set; }

        /// <summary>
        /// 产品线名称
        /// </summary>
        [XmlElement("name")]
        public string Name { get; set; }

        /// <summary>
        /// 产品数量
        /// </summary>
        [XmlElement("product_num")]
        public long ProductNum { get; set; }
    }
}
