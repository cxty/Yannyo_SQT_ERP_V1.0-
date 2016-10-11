using System;
using System.Xml.Serialization;
using Top.Api.Domain;

namespace Top.Api.Response
{
    /// <summary>
    /// WarehouseItemGetResponse.
    /// </summary>
    public class WarehouseItemGetResponse : TopResponse
    {
        /// <summary>
        /// 商品信息。返回JSON格式的字符串，包括商家编码，商品名称，条形码/货号，自定义属性
        /// </summary>
        [XmlElement("warehouse_item")]
        public WarehouseItem WarehouseItem { get; set; }
    }
}
