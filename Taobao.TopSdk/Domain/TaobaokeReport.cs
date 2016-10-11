using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Domain
{
    /// <summary>
    /// TaobaokeReport Data Structure.
    /// </summary>
    [Serializable]
    public class TaobaokeReport : TopObject
    {
        /// <summary>
        /// 淘宝客报表成员列表
        /// </summary>
        [XmlArray("taobaoke_report_members")]
        [XmlArrayItem("taobaoke_report_member")]
        public List<TaobaokeReportMember> TaobaokeReportMembers { get; set; }

        /// <summary>
        /// 搜索到的结果的总条数
        /// </summary>
        [XmlElement("total_results")]
        public long TotalResults { get; set; }
    }
}
