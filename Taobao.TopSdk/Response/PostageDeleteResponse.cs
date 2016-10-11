using System;
using System.Xml.Serialization;
using Top.Api.Domain;

namespace Top.Api.Response
{
    /// <summary>
    /// PostageDeleteResponse.
    /// </summary>
    public class PostageDeleteResponse : TopResponse
    {
        /// <summary>
        /// 邮费模板
        /// </summary>
        [XmlElement("postage")]
        public Postage Postage { get; set; }
    }
}
