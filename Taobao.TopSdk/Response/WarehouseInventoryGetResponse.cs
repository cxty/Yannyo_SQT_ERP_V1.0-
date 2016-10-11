using System;
using System.Xml.Serialization;
using Top.Api.Domain;

namespace Top.Api.Response
{
    /// <summary>
    /// WarehouseInventoryGetResponse.
    /// </summary>
    public class WarehouseInventoryGetResponse : TopResponse
    {
        /// <summary>
        /// 库存信息。返回JSON格式的字符串
        /// </summary>
        [XmlElement("inventory")]
        public Inventory Inventory { get; set; }
    }
}
