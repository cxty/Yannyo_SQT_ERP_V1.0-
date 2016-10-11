using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Top.Api.Domain;

namespace Top.Api.Response
{
    /// <summary>
    /// CubeYxgjGetResponse.
    /// </summary>
    public class CubeYxgjGetResponse : TopResponse
    {
        /// <summary>
        /// 营销工具汇总统计数据
        /// </summary>
        [XmlArray("cube_yxgj_gets")]
        [XmlArrayItem("cube_yxgj_get")]
        public List<CubeYxgjGet> CubeYxgjGets { get; set; }
    }
}
