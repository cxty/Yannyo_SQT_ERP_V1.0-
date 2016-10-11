using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// FollowerInfo Data Structure.
    /// </summary>
    [Serializable]
    public class FollowerInfo : TopObject
    {
        /// <summary>
        /// 用户的昵称
        /// </summary>
        [XmlElement("nick")]
        public string Nick { get; set; }

        /// <summary>
        /// 用户的userid
        /// </summary>
        [XmlElement("user_id")]
        public long UserId { get; set; }
    }
}
