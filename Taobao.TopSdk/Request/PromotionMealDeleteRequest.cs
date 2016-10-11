using System;
using System.Collections.Generic;
using Top.Api.Response;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.promotion.meal.delete
    /// </summary>
    public class PromotionMealDeleteRequest : ITopRequest<PromotionMealDeleteResponse>
    {
        /// <summary>
        /// 搭配套餐id。
        /// </summary>
        public Nullable<long> MealId { get; set; }

        #region ITopRequest Members

        public string GetApiName()
        {
            return "taobao.promotion.meal.delete";
        }

        public IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("meal_id", this.MealId);
            return parameters;
        }

        #endregion
    }
}
