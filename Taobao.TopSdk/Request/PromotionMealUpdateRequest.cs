using System;
using System.Collections.Generic;
using Top.Api.Response;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.promotion.meal.update
    /// </summary>
    public class PromotionMealUpdateRequest : ITopRequest<PromotionMealUpdateResponse>
    {
        /// <summary>
        /// 搭配套餐商品列表。item_id为商品的id(数字类型);item_show_name为商品显示名。最多允许5个商品进行搭配，最少是2个商品，且虚拟商品和拍卖商品不能参加套餐活动。以json格式传入。item_show_name最大长度为8,可以为空。
        /// </summary>
        public string ItemList { get; set; }

        /// <summary>
        /// 搭配套餐id
        /// </summary>
        public Nullable<long> MealId { get; set; }

        /// <summary>
        /// 套餐描述。
        /// </summary>
        public string MealMemo { get; set; }

        /// <summary>
        /// 搭配套餐名称。(30个汉字以下)
        /// </summary>
        public string MealName { get; set; }

        /// <summary>
        /// 搭配套餐一口价。这个值要大于0.01，小于商品的价值总和。
        /// </summary>
        public string MealPrice { get; set; }

        /// <summary>
        /// 普通运费模板id。商品API:taobao.postages.get获取卖家的运费模板。
        /// </summary>
        public Nullable<long> PostageId { get; set; }

        /// <summary>
        /// 运费模板类型。卖家标识'SELL';买家标识'BUY'。若为'SELL',则字段postage_id忽略。若为'BUY'，则postage_id为运费模板id，为必填项。
        /// </summary>
        public string TypePostage { get; set; }

        #region ITopRequest Members

        public string GetApiName()
        {
            return "taobao.promotion.meal.update";
        }

        public IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("item_list", this.ItemList);
            parameters.Add("meal_id", this.MealId);
            parameters.Add("meal_memo", this.MealMemo);
            parameters.Add("meal_name", this.MealName);
            parameters.Add("meal_price", this.MealPrice);
            parameters.Add("postage_id", this.PostageId);
            parameters.Add("type_postage", this.TypePostage);
            return parameters;
        }

        #endregion
    }
}
