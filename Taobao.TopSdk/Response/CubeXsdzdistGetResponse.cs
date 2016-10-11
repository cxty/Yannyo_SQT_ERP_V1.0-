using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Top.Api.Domain;

namespace Top.Api.Response
{
    /// <summary>
    /// CubeXsdzdistGetResponse.
    /// </summary>
    public class CubeXsdzdistGetResponse : TopResponse
    {
        /// <summary>
        /// 限时打折分行业优惠幅度分段统计
        /// </summary>
        [XmlArray("cube_xsdzdist_gets")]
        [XmlArrayItem("cube_xsdzdist_get")]
        public List<CubeXsdzdistGet> CubeXsdzdistGets { get; set; }
    }
}
