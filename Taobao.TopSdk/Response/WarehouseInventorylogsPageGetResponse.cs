using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Top.Api.Domain;

namespace Top.Api.Response
{
    /// <summary>
    /// WarehouseInventorylogsPageGetResponse.
    /// </summary>
    public class WarehouseInventorylogsPageGetResponse : TopResponse
    {
        /// <summary>
        /// 库存变更列表
        /// </summary>
        [XmlArray("inventory_logs")]
        [XmlArrayItem("inventory_log")]
        public List<InventoryLog> InventoryLogs { get; set; }

        /// <summary>
        /// 总的记录数
        /// </summary>
        [XmlElement("total_result")]
        public long TotalResult { get; set; }
    }
}
