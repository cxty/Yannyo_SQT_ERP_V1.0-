using System;
using System.Collections.Generic;
using Top.Api.Response;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.promotion.coupon.add
    /// </summary>
    public class PromotionCouponAddRequest : ITopRequest<PromotionCouponAddResponse>
    {
        /// <summary>
        /// 订单满多少元才能用这个优惠券，500就是满500才能使用
        /// </summary>
        public Nullable<long> Condition { get; set; }

        /// <summary>
        /// 优惠券的面额，必须是3，5，10，20，50，100
        /// </summary>
        public Nullable<long> Denominations { get; set; }

        /// <summary>
        /// 优惠券的截止日期
        /// </summary>
        public Nullable<DateTime> EndTime { get; set; }

        #region ITopRequest Members

        public string GetApiName()
        {
            return "taobao.promotion.coupon.add";
        }

        public IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("condition", this.Condition);
            parameters.Add("denominations", this.Denominations);
            parameters.Add("end_time", this.EndTime);
            return parameters;
        }

        #endregion
    }
}
