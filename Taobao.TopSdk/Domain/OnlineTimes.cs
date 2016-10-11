using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// OnlineTimes Data Structure.
    /// </summary>
    [Serializable]
    public class OnlineTimes : TopObject
    {
        /// <summary>
        /// 客服在线时间长度（秒）
        /// </summary>
        [XmlElement("online_times")]
        public long OnlineTimes_ { get; set; }

        /// <summary>
        /// 客服人员ID
        /// </summary>
        [XmlElement("service_staff_id")]
        public string ServiceStaffId { get; set; }
    }
}