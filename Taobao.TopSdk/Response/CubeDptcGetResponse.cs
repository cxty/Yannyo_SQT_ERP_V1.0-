using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Top.Api.Domain;

namespace Top.Api.Response
{
    /// <summary>
    /// CubeDptcGetResponse.
    /// </summary>
    public class CubeDptcGetResponse : TopResponse
    {
        /// <summary>
        /// 搭配套餐数据
        /// </summary>
        [XmlArray("cube_dptc_gets")]
        [XmlArrayItem("cube_dptc_get")]
        public List<CubeDptcGet> CubeDptcGets { get; set; }
    }
}
