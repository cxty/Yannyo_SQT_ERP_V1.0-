using System;
using System.Collections.Generic;
using Top.Api.Response;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.promotion.activity.cancel
    /// </summary>
    public class PromotionActivityCancelRequest : ITopRequest<PromotionActivityCancelResponse>
    {
        /// <summary>
        /// 活动id
        /// </summary>
        public Nullable<long> ActivityId { get; set; }

        #region ITopRequest Members

        public string GetApiName()
        {
            return "taobao.promotion.activity.cancel";
        }

        public IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("activity_id", this.ActivityId);
            return parameters;
        }

        #endregion
    }
}
