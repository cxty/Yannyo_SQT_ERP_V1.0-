using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Top.Api.Domain;

namespace Top.Api.Response
{
    /// <summary>
    /// TaobaokeItemsConvertResponse.
    /// </summary>
    public class TaobaokeItemsConvertResponse : TopResponse
    {
        /// <summary>
        /// 淘宝客商品对象列表
        /// </summary>
        [XmlArray("taobaoke_items")]
        [XmlArrayItem("taobaoke_item")]
        public List<TaobaokeItem> TaobaokeItems { get; set; }

        /// <summary>
        /// 返回的结果总数
        /// </summary>
        [XmlElement("total_results")]
        public long TotalResults { get; set; }
    }
}
