using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Top.Api.Domain;

namespace Top.Api.Response
{
    /// <summary>
    /// WarehouseInventorylogsGetResponse.
    /// </summary>
    public class WarehouseInventorylogsGetResponse : TopResponse
    {
        /// <summary>
        /// 对应的库存变更记录信息,JSON格式的字符串
        /// </summary>
        [XmlArray("inventory_log_list")]
        [XmlArrayItem("inventory_log")]
        public List<InventoryLog> InventoryLogList { get; set; }
    }
}
