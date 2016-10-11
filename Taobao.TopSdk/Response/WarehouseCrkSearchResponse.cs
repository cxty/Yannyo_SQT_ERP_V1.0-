using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Top.Api.Domain;

namespace Top.Api.Response
{
    /// <summary>
    /// WarehouseCrkSearchResponse.
    /// </summary>
    public class WarehouseCrkSearchResponse : TopResponse
    {
        /// <summary>
        /// 出入库单对应数据信息
        /// </summary>
        [XmlArray("crk_main_dos")]
        [XmlArrayItem("warehouse_crk_main")]
        public List<WarehouseCrkMain> CrkMainDos { get; set; }

        /// <summary>
        /// 出入库单商品库存变更记录ID，若无数据则返回空
        /// </summary>
        [XmlArray("inventory_log_ids")]
        [XmlArrayItem("string")]
        public List<String> InventoryLogIds { get; set; }

        /// <summary>
        /// 查询结果总数
        /// </summary>
        [XmlElement("total_item")]
        public long TotalItem { get; set; }
    }
}
