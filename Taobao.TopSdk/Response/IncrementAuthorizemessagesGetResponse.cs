using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Top.Api.Domain;

namespace Top.Api.Response
{
    /// <summary>
    /// IncrementAuthorizemessagesGetResponse.
    /// </summary>
    public class IncrementAuthorizemessagesGetResponse : TopResponse
    {
        /// <summary>
        /// 用户授权信息列表
        /// </summary>
        [XmlArray("authorize_messages")]
        [XmlArrayItem("authorize_message")]
        public List<AuthorizeMessage> AuthorizeMessages { get; set; }

        /// <summary>
        /// 符合条件的结果总数
        /// </summary>
        [XmlElement("total_results")]
        public long TotalResults { get; set; }
    }
}
