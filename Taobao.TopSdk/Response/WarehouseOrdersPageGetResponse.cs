using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Top.Api.Domain;

namespace Top.Api.Response
{
    /// <summary>
    /// WarehouseOrdersPageGetResponse.
    /// </summary>
    public class WarehouseOrdersPageGetResponse : TopResponse
    {
        /// <summary>
        /// 仓储的物流订单列表
        /// </summary>
        [XmlArray("order_list")]
        [XmlArrayItem("warehouse_order")]
        public List<WarehouseOrder> OrderList { get; set; }

        /// <summary>
        /// 总的记录数
        /// </summary>
        [XmlElement("total_result")]
        public long TotalResult { get; set; }
    }
}
