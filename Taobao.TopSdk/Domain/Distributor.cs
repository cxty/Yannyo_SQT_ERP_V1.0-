using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// Distributor Data Structure.
    /// </summary>
    [Serializable]
    public class Distributor : TopObject
    {
        /// <summary>
        /// 分销商的支付宝帐户
        /// </summary>
        [XmlElement("alipay_account")]
        public string AlipayAccount { get; set; }

        /// <summary>
        /// 联系人
        /// </summary>
        [XmlElement("contact_person")]
        public string ContactPerson { get; set; }

        /// <summary>
        /// 分销商创建时间 时间格式：yyyy-MM-dd HH:mm:ss
        /// </summary>
        [XmlElement("created")]
        public string Created { get; set; }

        /// <summary>
        /// 分销商Id
        /// </summary>
        [XmlElement("distributor_id")]
        public string DistributorId { get; set; }

        /// <summary>
        /// 分销商姓名
        /// </summary>
        [XmlElement("distributor_name")]
        public string DistributorName { get; set; }

        /// <summary>
        /// 分销商的email
        /// </summary>
        [XmlElement("email")]
        public string Email { get; set; }

        /// <summary>
        /// 分销商的手机号
        /// </summary>
        [XmlElement("mobile_phone")]
        public string MobilePhone { get; set; }

        /// <summary>
        /// 分销商的电话
        /// </summary>
        [XmlElement("phone")]
        public string Phone { get; set; }

        /// <summary>
        /// 分销商的网店链接
        /// </summary>
        [XmlElement("shop_web_link")]
        public string ShopWebLink { get; set; }
    }
}
