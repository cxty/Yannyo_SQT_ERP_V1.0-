using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Top.Api.Domain;

namespace Top.Api.Response
{
    /// <summary>
    /// WarehouseInventoriesGetResponse.
    /// </summary>
    public class WarehouseInventoriesGetResponse : TopResponse
    {
        /// <summary>
        /// 库存信息列表。返回JSON格式的字符串
        /// </summary>
        [XmlArray("inventory_list")]
        [XmlArrayItem("inventory")]
        public List<Inventory> InventoryList { get; set; }
    }
}
