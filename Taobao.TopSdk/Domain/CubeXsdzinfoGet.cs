using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// CubeXsdzinfoGet Data Structure.
    /// </summary>
    [Serializable]
    public class CubeXsdzinfoGet : TopObject
    {
        /// <summary>
        /// 类目名称
        /// </summary>
        [XmlElement("category_name")]
        public string CategoryName { get; set; }

        /// <summary>
        /// 类目id
        /// </summary>
        [XmlElement("cid")]
        public long Cid { get; set; }

        /// <summary>
        /// 日期
        /// </summary>
        [XmlElement("date")]
        public string Date { get; set; }

        /// <summary>
        /// 成交时段,如12表示中午12-下午13点
        /// </summary>
        [XmlElement("hour")]
        public long Hour { get; set; }

        /// <summary>
        /// 成交订单数
        /// </summary>
        [XmlElement("order_num")]
        public long OrderNum { get; set; }

        /// <summary>
        /// 优惠后总成交金额
        /// </summary>
        [XmlElement("post_total_fee")]
        public string PostTotalFee { get; set; }

        /// <summary>
        /// 优惠前总成交金额
        /// </summary>
        [XmlElement("pre_total_fee")]
        public string PreTotalFee { get; set; }

        /// <summary>
        /// 成交店铺数
        /// </summary>
        [XmlElement("shop_num")]
        public long ShopNum { get; set; }
    }
}
