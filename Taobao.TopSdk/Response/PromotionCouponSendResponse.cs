using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Top.Api.Domain;

namespace Top.Api.Response
{
    /// <summary>
    /// PromotionCouponSendResponse.
    /// </summary>
    public class PromotionCouponSendResponse : TopResponse
    {
        /// <summary>
        /// 没有发送成功的买家
        /// </summary>
        [XmlArray("failure_buyers")]
        [XmlArrayItem("error_message")]
        public List<ErrorMessage> FailureBuyers { get; set; }

        /// <summary>
        /// true 成功，false失败
        /// </summary>
        [XmlElement("is_success")]
        public bool IsSuccess { get; set; }
    }
}
