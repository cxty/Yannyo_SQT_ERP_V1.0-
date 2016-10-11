using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Top.Api.Domain;

namespace Top.Api.Response
{
    /// <summary>
    /// CubeMjsinfoGetResponse.
    /// </summary>
    public class CubeMjsinfoGetResponse : TopResponse
    {
        /// <summary>
        /// 满就送行业汇总统计数据
        /// </summary>
        [XmlArray("cube_mjsinfo_gets")]
        [XmlArrayItem("cube_mjsinfo_get")]
        public List<CubeMjsinfoGet> CubeMjsinfoGets { get; set; }
    }
}
