using System;
using System.Xml.Serialization;
using Top.Api.Domain;

namespace Top.Api.Response
{
    /// <summary>
    /// PromotionMealDeleteResponse.
    /// </summary>
    public class PromotionMealDeleteResponse : TopResponse
    {
        /// <summary>
        /// true：成功 false：失败
        /// </summary>
        [XmlElement("is_success")]
        public bool IsSuccess { get; set; }

        /// <summary>
        /// 修改时间。
        /// </summary>
        [XmlElement("modify_time")]
        public string ModifyTime { get; set; }
    }
}
