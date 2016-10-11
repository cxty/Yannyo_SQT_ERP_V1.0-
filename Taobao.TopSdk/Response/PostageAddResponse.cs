using System;
using System.Xml.Serialization;
using Top.Api.Domain;

namespace Top.Api.Response
{
    /// <summary>
    /// PostageAddResponse.
    /// </summary>
    public class PostageAddResponse : TopResponse
    {
        /// <summary>
        /// 新增的商品信息
        /// </summary>
        [XmlElement("postage")]
        public Postage Postage { get; set; }
    }
}
