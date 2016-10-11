using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Top.Api.Domain;

namespace Top.Api.Response
{
    /// <summary>
    /// PromotionMembersGetResponse.
    /// </summary>
    public class PromotionMembersGetResponse : TopResponse
    {
        /// <summary>
        /// 会员列表
        /// </summary>
        [XmlArray("members")]
        [XmlArrayItem("member")]
        public List<Member> Members { get; set; }

        /// <summary>
        /// 一共有多少条
        /// </summary>
        [XmlElement("tot_count")]
        public long TotCount { get; set; }
    }
}
