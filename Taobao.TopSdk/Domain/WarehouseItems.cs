using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Domain
{
    /// <summary>
    /// WarehouseItems Data Structure.
    /// </summary>
    [Serializable]
    public class WarehouseItems : TopObject
    {
        /// <summary>
        /// 库存列表
        /// </summary>
        [XmlArray("inventory_list")]
        [XmlArrayItem("inventory")]
        public List<Inventory> InventoryList { get; set; }

        /// <summary>
        /// 商品列表
        /// </summary>
        [XmlArray("warehouse_item_list")]
        [XmlArrayItem("warehouse_item")]
        public List<WarehouseItem> WarehouseItemList { get; set; }
    }
}
