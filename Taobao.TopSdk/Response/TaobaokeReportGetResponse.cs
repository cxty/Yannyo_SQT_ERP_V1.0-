using System;
using System.Xml.Serialization;
using Top.Api.Domain;

namespace Top.Api.Response
{
    /// <summary>
    /// TaobaokeReportGetResponse.
    /// </summary>
    public class TaobaokeReportGetResponse : TopResponse
    {
        /// <summary>
        /// 淘宝客报表
        /// </summary>
        [XmlElement("taobaoke_report")]
        public TaobaokeReport TaobaokeReport { get; set; }
    }
}
