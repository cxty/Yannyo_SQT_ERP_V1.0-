using System;
using System.Collections.Generic;
using Top.Api.Response;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.promotion.activity.add
    /// </summary>
    public class PromotionActivityAddRequest : ITopRequest<PromotionActivityAddResponse>
    {
        /// <summary>
        /// 优惠券总领用数量
        /// </summary>
        public Nullable<long> CouponCount { get; set; }

        /// <summary>
        /// 优惠券的id，唯一标识这个优惠券
        /// </summary>
        public Nullable<long> CouponId { get; set; }

        /// <summary>
        /// 每个人最多领用数量，0代表不限
        /// </summary>
        public Nullable<long> PersonLimitCount { get; set; }

        #region ITopRequest Members

        public string GetApiName()
        {
            return "taobao.promotion.activity.add";
        }

        public IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("coupon_count", this.CouponCount);
            parameters.Add("coupon_id", this.CouponId);
            parameters.Add("person_limit_count", this.PersonLimitCount);
            return parameters;
        }

        #endregion
    }
}
