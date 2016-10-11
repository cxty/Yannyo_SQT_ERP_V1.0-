using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// Media Data Structure.
    /// </summary>
    [Serializable]
    public class Media : TopObject
    {
        /// <summary>
        /// media的url
        /// </summary>
        [XmlElement("media")]
        public string Media_ { get; set; }

        /// <summary>
        /// media_desc描述
        /// </summary>
        [XmlElement("media_desc")]
        public string MediaDesc { get; set; }

        /// <summary>
        /// media_link
        /// </summary>
        [XmlElement("media_link")]
        public string MediaLink { get; set; }

        /// <summary>
        /// 多媒体名称
        /// </summary>
        [XmlElement("media_name")]
        public string MediaName { get; set; }

        /// <summary>
        /// media_type
        /// </summary>
        [XmlElement("media_type")]
        public long MediaType { get; set; }
    }
}
