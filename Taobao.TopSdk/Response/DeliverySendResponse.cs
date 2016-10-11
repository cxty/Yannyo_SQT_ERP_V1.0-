using System;
using System.Xml.Serialization;
using Top.Api.Domain;

namespace Top.Api.Response
{
    /// <summary>
    /// DeliverySendResponse.
    /// </summary>
    public class DeliverySendResponse : TopResponse
    {
        /// <summary>
        /// 只返回is_success
        /// </summary>
        [XmlElement("shipping")]
        public Shipping Shipping { get; set; }
    }
}
