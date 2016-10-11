using System;
using System.Xml.Serialization;
using Top.Api.Domain;

namespace Top.Api.Response
{
    /// <summary>
    /// WarehouseInventoryWarnlineUpdateResponse.
    /// </summary>
    public class WarehouseInventoryWarnlineUpdateResponse : TopResponse
    {
        /// <summary>
        /// 部分成功时返回操作失败的库存id
        /// </summary>
        [XmlElement("failed_inventory_ids")]
        public string FailedInventoryIds { get; set; }

        /// <summary>
        /// 修改时间.格式:yyyy-mm-dd hh:mm:ss
        /// </summary>
        [XmlElement("modify_time")]
        public string ModifyTime { get; set; }

        /// <summary>
        /// 是否成功 (返回失败:P01为参数为空)
        /// </summary>
        [XmlElement("success")]
        public bool Success { get; set; }
    }
}
