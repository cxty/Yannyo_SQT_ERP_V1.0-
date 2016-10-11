using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// ProductProp Data Structure.
    /// </summary>
    [Serializable]
    public class ProductProp : TopObject
    {
        /// <summary>
        /// 类目属性ID
        /// </summary>
        [XmlElement("cid")]
        public string Cid { get; set; }

        /// <summary>
        /// 属性ID
        /// </summary>
        [XmlElement("pid")]
        public string Pid { get; set; }

        /// <summary>
        /// 属性名
        /// </summary>
        [XmlElement("prop_name")]
        public string PropName { get; set; }

        /// <summary>
        /// 属性值名称列表
        /// </summary>
        [XmlElement("prop_names")]
        public string PropNames { get; set; }

        /// <summary>
        /// 属性值列表
        /// </summary>
        [XmlElement("prop_values")]
        public string PropValues { get; set; }
    }
}
