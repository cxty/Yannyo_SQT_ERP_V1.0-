using System;
using System.Xml.Serialization;
using Top.Api.Domain;

namespace Top.Api.Response
{
    /// <summary>
    /// WlbItemAuthorizationAddResponse.
    /// </summary>
    public class WlbItemAuthorizationAddResponse : TopResponse
    {
        /// <summary>
        /// 授权关系id
        /// </summary>
        [XmlElement("rule_id")]
        public long RuleId { get; set; }
    }
}
