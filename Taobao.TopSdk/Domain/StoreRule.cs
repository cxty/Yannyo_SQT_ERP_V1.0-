using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// StoreRule Data Structure.
    /// </summary>
    [Serializable]
    public class StoreRule : TopObject
    {
        /// <summary>
        /// 发货规则中的备用仓库ID
        /// </summary>
        [XmlElement("back_seller_store_id")]
        public string BackSellerStoreId { get; set; }

        /// <summary>
        /// 发货规则id
        /// </summary>
        [XmlElement("id")]
        public long Id { get; set; }

        /// <summary>
        /// 自定义仓库附带地区ID串
        /// </summary>
        [XmlElement("prov_area_ids")]
        public string ProvAreaIds { get; set; }

        /// <summary>
        /// 自定义仓库ID
        /// </summary>
        [XmlElement("seller_store_id")]
        public long SellerStoreId { get; set; }
    }
}
