using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// StaffEvalStatistics Data Structure.
    /// </summary>
    [Serializable]
    public class StaffEvalStatistics : TopObject
    {
        /// <summary>
        /// 客服评价代码
        /// </summary>
        [XmlElement("evaluations")]
        public string Evaluations { get; set; }

        /// <summary>
        /// 客服人员ID
        /// </summary>
        [XmlElement("service_staff_id")]
        public string ServiceStaffId { get; set; }
    }
}
