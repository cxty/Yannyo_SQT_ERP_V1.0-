using System;
using System.Xml.Serialization;
using Top.Api.Domain;

namespace Top.Api.Response
{
    /// <summary>
    /// WlbOrderScheduleRuleAddResponse.
    /// </summary>
    public class WlbOrderScheduleRuleAddResponse : TopResponse
    {
        /// <summary>
        /// 新增成功的发货规则id
        /// </summary>
        [XmlElement("schedule_rule_id")]
        public long ScheduleRuleId { get; set; }
    }
}
