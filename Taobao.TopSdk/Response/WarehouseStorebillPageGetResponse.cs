using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Top.Api.Domain;

namespace Top.Api.Response
{
    /// <summary>
    /// WarehouseStorebillPageGetResponse.
    /// </summary>
    public class WarehouseStorebillPageGetResponse : TopResponse
    {
        /// <summary>
        /// 商家的某个仓库某月的费用。JSON格式的字符串
        /// </summary>
        [XmlArray("store_bill_list")]
        [XmlArrayItem("store_bill")]
        public List<StoreBill> StoreBillList { get; set; }

        /// <summary>
        /// 搜索到符合条件的结果总数
        /// </summary>
        [XmlElement("total_result")]
        public long TotalResult { get; set; }
    }
}
