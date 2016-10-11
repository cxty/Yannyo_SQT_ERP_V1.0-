using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Top.Api.Domain;

namespace Top.Api.Response
{
    /// <summary>
    /// TaobaokeShopsConvertResponse.
    /// </summary>
    public class TaobaokeShopsConvertResponse : TopResponse
    {
        /// <summary>
        /// 淘宝客店铺对象列表,不能返回shop_type,seller_credit,auction_coun, total_auction
        /// </summary>
        [XmlArray("taobaoke_shops")]
        [XmlArrayItem("taobaoke_shop")]
        public List<TaobaokeShop> TaobaokeShops { get; set; }
    }
}
