using System;
using System.Xml.Serialization;
using Top.Api.Domain;

namespace Top.Api.Response
{
    /// <summary>
    /// WarehouseOutsideOrderImportResponse.
    /// </summary>
    public class WarehouseOutsideOrderImportResponse : TopResponse
    {
        /// <summary>
        /// 修改时间 格式:yyyy-mm-dd hh:mm:ss
        /// </summary>
        [XmlElement("modify_time")]
        public string ModifyTime { get; set; }

        /// <summary>
        /// 物流订单唯一标识
        /// </summary>
        [XmlElement("order_id")]
        public string OrderId { get; set; }

        /// <summary>
        /// 是否成功
        /// </summary>
        [XmlElement("success")]
        public bool Success { get; set; }
    }
}
