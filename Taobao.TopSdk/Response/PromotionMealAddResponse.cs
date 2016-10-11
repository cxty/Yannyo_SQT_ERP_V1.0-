using System;
using System.Xml.Serialization;
using Top.Api.Domain;

namespace Top.Api.Response
{
    /// <summary>
    /// PromotionMealAddResponse.
    /// </summary>
    public class PromotionMealAddResponse : TopResponse
    {
        /// <summary>
        /// true：成功 false：失败
        /// </summary>
        [XmlElement("is_success")]
        public bool IsSuccess { get; set; }

        /// <summary>
        /// 搭配套餐id。
        /// </summary>
        [XmlElement("meal_id")]
        public long MealId { get; set; }

        /// <summary>
        /// 创建时间。
        /// </summary>
        [XmlElement("modify_time")]
        public string ModifyTime { get; set; }
    }
}
