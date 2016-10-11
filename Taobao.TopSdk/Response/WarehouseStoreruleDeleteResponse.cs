using System;
using System.Xml.Serialization;
using Top.Api.Domain;

namespace Top.Api.Response
{
    /// <summary>
    /// WarehouseStoreruleDeleteResponse.
    /// </summary>
    public class WarehouseStoreruleDeleteResponse : TopResponse
    {
        /// <summary>
        /// 操作时间
        /// </summary>
        [XmlElement("modify_time")]
        public string ModifyTime { get; set; }

        /// <summary>
        /// 操作是否成功
        /// </summary>
        [XmlElement("success")]
        public bool Success { get; set; }
    }
}
