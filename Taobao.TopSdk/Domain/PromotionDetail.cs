using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// PromotionDetail Data Structure.
    /// </summary>
    [Serializable]
    public class PromotionDetail : TopObject
    {
        /// <summary>
        /// 优惠金额（免运费、限时打折时为空）,单位：元
        /// </summary>
        [XmlElement("discount_fee")]
        public string DiscountFee { get; set; }

        /// <summary>
        /// 满就送商品时，所送商品的名称
        /// </summary>
        [XmlElement("gift_item_name")]
        public string GiftItemName { get; set; }

        /// <summary>
        /// 交易的主订单或子订单号
        /// </summary>
        [XmlElement("id")]
        public long Id { get; set; }

        /// <summary>
        /// 优惠信息的名称
        /// </summary>
        [XmlElement("promotion_name")]
        public string PromotionName { get; set; }
    }
}
