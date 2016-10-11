using System;
using System.Xml.Serialization;
using Top.Api.Domain;

namespace Top.Api.Response
{
    /// <summary>
    /// WarehouseItemsPageGetResponse.
    /// </summary>
    public class WarehouseItemsPageGetResponse : TopResponse
    {
        /// <summary>
        /// 搜索到符合条件的结果总数
        /// </summary>
        [XmlElement("total_result")]
        public long TotalResult { get; set; }

        /// <summary>
        /// 商品相关信息，包括商品信息列表，库存信息列表和自定义仓库信息列表组成的JSON格式的字符串
        /// </summary>
        [XmlElement("warehouse_page_items")]
        public WarehouseItems WarehousePageItems { get; set; }
    }
}
