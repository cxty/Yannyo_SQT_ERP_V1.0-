using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// JPLocation Data Structure.
    /// </summary>
    [Serializable]
    public class JPLocation : TopObject
    {
        /// <summary>
        /// 机票测试数据类型地址信息
        /// </summary>
        [XmlElement("city")]
        public string City { get; set; }

        /// <summary>
        /// 机票测试数据类型，地址信息邮编
        /// </summary>
        [XmlElement("zip")]
        public string Zip { get; set; }
    }
}
