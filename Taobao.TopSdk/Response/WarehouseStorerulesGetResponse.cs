using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Top.Api.Domain;

namespace Top.Api.Response
{
    /// <summary>
    /// WarehouseStorerulesGetResponse.
    /// </summary>
    public class WarehouseStorerulesGetResponse : TopResponse
    {
        /// <summary>
        /// 仓储用户所有自定义仓库发货规则
        /// </summary>
        [XmlArray("store_rule_list")]
        [XmlArrayItem("store_rule")]
        public List<StoreRule> StoreRuleList { get; set; }
    }
}
