using System;
using System.Xml.Serialization;
using Top.Api.Domain;

namespace Top.Api.Response
{
    /// <summary>
    /// WarehouseOrderCancelResponse.
    /// </summary>
    public class WarehouseOrderCancelResponse : TopResponse
    {
        /// <summary>
        /// 修改时间
        /// </summary>
        [XmlElement("modify_time")]
        public string ModifyTime { get; set; }

        /// <summary>
        /// 重新创建订单id
        /// </summary>
        [XmlElement("recreated_order_id")]
        public long RecreatedOrderId { get; set; }

        /// <summary>
        /// 是否成功
        /// </summary>
        [XmlElement("success")]
        public bool Success { get; set; }
    }
}
