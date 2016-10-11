using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Top.Api.Domain;

namespace Top.Api.Response
{
    /// <summary>
    /// WarehouseReturnsPageGetResponse.
    /// </summary>
    public class WarehouseReturnsPageGetResponse : TopResponse
    {
        /// <summary>
        /// 退货单明细单ID，若无数据则返回空
        /// </summary>
        [XmlArray("inventory_log_ids")]
        [XmlArrayItem("string")]
        public List<String> InventoryLogIds { get; set; }

        /// <summary>
        /// 退货单主信息列表
        /// </summary>
        [XmlArray("return_main_dos")]
        [XmlArrayItem("warehouse_return_main")]
        public List<WarehouseReturnMain> ReturnMainDos { get; set; }

        /// <summary>
        /// 查询结果总数
        /// </summary>
        [XmlElement("total_item")]
        public long TotalItem { get; set; }
    }
}
