using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// AwardOnline Data Structure.
    /// </summary>
    [Serializable]
    public class AwardOnline : TopObject
    {
        /// <summary>
        /// 奖品的名称
        /// </summary>
        [XmlElement("award_name")]
        public string AwardName { get; set; }

        /// <summary>
        /// 奖品图片的url
        /// </summary>
        [XmlElement("award_pic_url")]
        public string AwardPicUrl { get; set; }

        /// <summary>
        /// 商品的原价
        /// </summary>
        [XmlElement("award_price")]
        public string AwardPrice { get; set; }

        /// <summary>
        /// 所属类目的id
        /// </summary>
        [XmlElement("category_id")]
        public long CategoryId { get; set; }

        /// <summary>
        /// 在交易线的detailUrl
        /// </summary>
        [XmlElement("detail_url")]
        public string DetailUrl { get; set; }

        /// <summary>
        /// 剩余数量
        /// </summary>
        [XmlElement("left_count")]
        public long LeftCount { get; set; }

        /// <summary>
        /// 上架的总数量
        /// </summary>
        [XmlElement("online_count")]
        public long OnlineCount { get; set; }

        /// <summary>
        /// 结束时间，精确到日
        /// </summary>
        [XmlElement("online_ec_end")]
        public string OnlineEcEnd { get; set; }

        /// <summary>
        /// 可以兑换的时间段。
        /// </summary>
        [XmlElement("online_ec_range")]
        public string OnlineEcRange { get; set; }

        /// <summary>
        /// 开始日期，精确到日的。
        /// </summary>
        [XmlElement("online_ec_start")]
        public string OnlineEcStart { get; set; }

        /// <summary>
        /// 奖品的在线id，用于发起领奖请求
        /// </summary>
        [XmlElement("online_id")]
        public long OnlineId { get; set; }
    }
}
