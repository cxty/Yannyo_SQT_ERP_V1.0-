using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Top.Api.Domain;

namespace Top.Api.Response
{
    /// <summary>
    /// WarehouseOrderStatusGetResponse.
    /// </summary>
    public class WarehouseOrderStatusGetResponse : TopResponse
    {
        /// <summary>
        /// 订单信息返回以list形式返回
        /// </summary>
        [XmlArray("tran_status_list")]
        [XmlArrayItem("tran_status")]
        public List<TranStatus> TranStatusList { get; set; }
    }
}
