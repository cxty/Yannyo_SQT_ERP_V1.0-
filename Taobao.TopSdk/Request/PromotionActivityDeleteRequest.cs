using System;
using System.Collections.Generic;
using Top.Api.Response;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.promotion.activity.delete
    /// </summary>
    public class PromotionActivityDeleteRequest : ITopRequest<PromotionActivityDeleteResponse>
    {
        /// <summary>
        /// 优惠券的id
        /// </summary>
        public Nullable<long> ActivityId { get; set; }

        #region ITopRequest Members

        public string GetApiName()
        {
            return "taobao.promotion.activity.delete";
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
