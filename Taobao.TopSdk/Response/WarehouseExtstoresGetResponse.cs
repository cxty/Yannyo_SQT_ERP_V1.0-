using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Top.Api.Domain;

namespace Top.Api.Response
{
    /// <summary>
    /// WarehouseExtstoresGetResponse.
    /// </summary>
    public class WarehouseExtstoresGetResponse : TopResponse
    {
        /// <summary>
        /// 外部仓库的集合
        /// </summary>
        [XmlArray("ext_store_list")]
        [XmlArrayItem("ext_store")]
        public List<ExtStore> ExtStoreList { get; set; }
    }
}
