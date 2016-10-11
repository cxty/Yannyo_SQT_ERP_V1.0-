using System;
using System.Xml.Serialization;
using Top.Api.Domain;

namespace Top.Api.Response
{
    /// <summary>
    /// WarehouseReturnSendResponse.
    /// </summary>
    public class WarehouseReturnSendResponse : TopResponse
    {
        /// <summary>
        /// 修改时间
        /// </summary>
        [XmlElement("modify_time")]
        public string ModifyTime { get; set; }

        /// <summary>
        /// 成功标志
        /// </summary>
        [XmlElement("success")]
        public bool Success { get; set; }
    }
}
