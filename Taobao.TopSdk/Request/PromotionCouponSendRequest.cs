using System;
using System.Collections.Generic;
using Top.Api.Response;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.promotion.coupon.send
    /// </summary>
    public class PromotionCouponSendRequest : ITopRequest<PromotionCouponSendResponse>
    {
        /// <summary>
        /// 买家昵称用半角';'号分割
        /// </summary>
        public string BuyerNick { get; set; }

        /// <summary>
        /// 优惠券的id
        /// </summary>
        public Nullable<long> CouponId { get; set; }

        #region ITopRequest Members

        public string GetApiName()
        {
            return "taobao.promotion.coupon.send";
        }

        public IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("buyer_nick", this.BuyerNick);
            parameters.Add("coupon_id", this.CouponId);
            return parameters;
        }

        #endregion
    }
}
