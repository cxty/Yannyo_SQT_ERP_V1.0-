using System;
using System.Xml.Serialization;
using Top.Api.Domain;

namespace Top.Api.Response
{
    /// <summary>
    /// ItemcatsAuthorizeGetResponse.
    /// </summary>
    public class ItemcatsAuthorizeGetResponse : TopResponse
    {
        /// <summary>
        /// 里面有2个数组：  Brand[]品牌列表,  ItemCat[] 类目列表
        /// </summary>
        [XmlElement("seller_authorize")]
        public SellerAuthorize SellerAuthorize { get; set; }
    }
}
