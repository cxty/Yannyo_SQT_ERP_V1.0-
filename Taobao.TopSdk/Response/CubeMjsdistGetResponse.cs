using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Top.Api.Domain;

namespace Top.Api.Response
{
    /// <summary>
    /// CubeMjsdistGetResponse.
    /// </summary>
    public class CubeMjsdistGetResponse : TopResponse
    {
        /// <summary>
        /// 满就送行业优惠幅度数据
        /// </summary>
        [XmlArray("cube_mjsdist_gets")]
        [XmlArrayItem("cube_mjsdist_get")]
        public List<CubeMjsdistGet> CubeMjsdistGets { get; set; }
    }
}
