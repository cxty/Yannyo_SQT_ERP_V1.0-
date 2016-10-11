using System;
using System.Xml.Serialization;
using Top.Api.Domain;

namespace Top.Api.Response
{
    /// <summary>
    /// WarehouseStockoutAddResponse.
    /// </summary>
    public class WarehouseStockoutAddResponse : TopResponse
    {
        /// <summary>
        /// 出库单编号
        /// </summary>
        [XmlElement("crk_code")]
        public string CrkCode { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        [XmlElement("modify_time")]
        public string ModifyTime { get; set; }

        /// <summary>
        /// 新增入库单是否成功
        /// </summary>
        [XmlElement("success")]
        public bool Success { get; set; }
    }
}
