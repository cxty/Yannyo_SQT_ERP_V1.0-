using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Top.Api.Domain;

namespace Top.Api.Response
{
    /// <summary>
    /// CubeXsdzinfoGetResponse.
    /// </summary>
    public class CubeXsdzinfoGetResponse : TopResponse
    {
        /// <summary>
        /// 限时打折行业汇总统计
        /// </summary>
        [XmlArray("cube_xsdzinfo_gets")]
        [XmlArrayItem("cube_xsdzinfo_get")]
        public List<CubeXsdzinfoGet> CubeXsdzinfoGets { get; set; }
    }
}
