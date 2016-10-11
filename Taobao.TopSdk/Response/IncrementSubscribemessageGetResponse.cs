using System;
using System.Xml.Serialization;
using Top.Api.Domain;

namespace Top.Api.Response
{
    /// <summary>
    /// IncrementSubscribemessageGetResponse.
    /// </summary>
    public class IncrementSubscribemessageGetResponse : TopResponse
    {
        /// <summary>
        /// ISV增量消息订阅信息
        /// </summary>
        [XmlElement("subscribe_message")]
        public SubscribeMessage SubscribeMessage { get; set; }
    }
}
