using System;
using System.Xml.Serialization;
using Top.Api.Domain;

namespace Top.Api.Response
{
    /// <summary>
    /// WarehouseInventorylogGetResponse.
    /// </summary>
    public class WarehouseInventorylogGetResponse : TopResponse
    {
        /// <summary>
        /// 对应的库存变更记录信息
        /// </summary>
        [XmlElement("inventory_log")]
        public InventoryLog InventoryLog { get; set; }
    }
}
