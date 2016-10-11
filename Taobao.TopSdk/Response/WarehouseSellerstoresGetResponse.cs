using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Top.Api.Domain;

namespace Top.Api.Response
{
    /// <summary>
    /// WarehouseSellerstoresGetResponse.
    /// </summary>
    public class WarehouseSellerstoresGetResponse : TopResponse
    {
        /// <summary>
        /// 自定义仓库集合
        /// </summary>
        [XmlArray("seller_store_list")]
        [XmlArrayItem("seller_store")]
        public List<SellerStore> SellerStoreList { get; set; }
    }
}
