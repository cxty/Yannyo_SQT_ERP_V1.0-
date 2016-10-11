using System;
using System.Xml.Serialization;
using Top.Api.Domain;

namespace Top.Api.Response
{
    /// <summary>
    /// WarehouseStockinAddResponse.
    /// </summary>
    public class WarehouseStockinAddResponse : TopResponse
    {
        /// <summary>
        /// 入库单编号
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
