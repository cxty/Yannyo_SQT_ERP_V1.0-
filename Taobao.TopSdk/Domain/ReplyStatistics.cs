using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// ReplyStatistics Data Structure.
    /// </summary>
    [Serializable]
    public class ReplyStatistics : TopObject
    {
        /// <summary>
        /// 客服回复数
        /// </summary>
        [XmlElement("reply_num")]
        public long ReplyNum { get; set; }

        /// <summary>
        /// 客服ID
        /// </summary>
        [XmlElement("user_id")]
        public string UserId { get; set; }
    }
}
