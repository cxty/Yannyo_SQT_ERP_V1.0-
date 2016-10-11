using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Top.Api.Domain;

namespace Top.Api.Response
{
    /// <summary>
    /// WarehouseItemsGetResponse.
    /// </summary>
    public class WarehouseItemsGetResponse : TopResponse
    {
        /// <summary>
        /// 商品相关信息
        /// </summary>
        [XmlArray("warehouse_item_list")]
        [XmlArrayItem("warehouse_item")]
        public List<WarehouseItem> WarehouseItemList { get; set; }
    }
}
