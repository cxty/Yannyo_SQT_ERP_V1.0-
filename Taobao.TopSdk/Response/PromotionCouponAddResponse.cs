using System;
using System.Xml.Serialization;
using Top.Api.Domain;

namespace Top.Api.Response
{
    /// <summary>
    /// PromotionCouponAddResponse.
    /// </summary>
    public class PromotionCouponAddResponse : TopResponse
    {
        /// <summary>
        /// 优惠券的id
        /// </summary>
        [XmlElement("coupon_id")]
        public long CouponId { get; set; }
    }
}
