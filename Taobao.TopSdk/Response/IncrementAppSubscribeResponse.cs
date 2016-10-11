using System;
using System.Xml.Serialization;
using Top.Api.Domain;

namespace Top.Api.Response
{
    /// <summary>
    /// IncrementAppSubscribeResponse.
    /// </summary>
    public class IncrementAppSubscribeResponse : TopResponse
    {
        /// <summary>
        /// ISV的订购信息
        /// </summary>
        [XmlElement("subscribe_message")]
        public SubscribeMessage SubscribeMessage { get; set; }
    }
}
