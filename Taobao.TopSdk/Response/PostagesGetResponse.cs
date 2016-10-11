using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Top.Api.Domain;

namespace Top.Api.Response
{
    /// <summary>
    /// PostagesGetResponse.
    /// </summary>
    public class PostagesGetResponse : TopResponse
    {
        /// <summary>
        /// 运费模板列表
        /// </summary>
        [XmlArray("postages")]
        [XmlArrayItem("postage")]
        public List<Postage> Postages { get; set; }

        /// <summary>
        /// 获得到符合条件的结果总数
        /// </summary>
        [XmlElement("total_results")]
        public long TotalResults { get; set; }
    }
}
