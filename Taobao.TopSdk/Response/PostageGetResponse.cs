using System;
using System.Xml.Serialization;
using Top.Api.Domain;

namespace Top.Api.Response
{
    /// <summary>
    /// PostageGetResponse.
    /// </summary>
    public class PostageGetResponse : TopResponse
    {
        /// <summary>
        /// 运费模板
        /// </summary>
        [XmlElement("postage")]
        public Postage Postage { get; set; }
    }
}
