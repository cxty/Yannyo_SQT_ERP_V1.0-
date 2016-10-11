using System;
using System.Xml.Serialization;
using Top.Api.Domain;

namespace Top.Api.Response
{
    /// <summary>
    /// WarehouseReturnAddResponse.
    /// </summary>
    public class WarehouseReturnAddResponse : TopResponse
    {
        /// <summary>
        /// 退货单编号
        /// </summary>
        [XmlElement("crk_code")]
        public string CrkCode { get; set; }

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
