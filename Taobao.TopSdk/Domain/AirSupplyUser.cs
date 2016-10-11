using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// AirSupplyUser Data Structure.
    /// </summary>
    [Serializable]
    public class AirSupplyUser : TopObject
    {
        /// <summary>
        /// Email
        /// </summary>
        [XmlElement("email")]
        public string Email { get; set; }

        /// <summary>
        /// 24小时客户电话
        /// </summary>
        [XmlElement("hotline24h")]
        public string Hotline24h { get; set; }

        /// <summary>
        /// 代理商id
        /// </summary>
        [XmlElement("id")]
        public long Id { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        [XmlElement("mobile_phone")]
        public string MobilePhone { get; set; }

        /// <summary>
        /// 代理商简称
        /// </summary>
        [XmlElement("name")]
        public string Name { get; set; }

        /// <summary>
        /// 代理商昵称
        /// </summary>
        [XmlElement("nick")]
        public string Nick { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        [XmlElement("phone")]
        public string Phone { get; set; }

        /// <summary>
        /// 总单子数量
        /// </summary>
        [XmlElement("score_order_num")]
        public long ScoreOrderNum { get; set; }

        /// <summary>
        /// 服务总积分，字符串表示的 double 类型
        /// </summary>
        [XmlElement("total_score")]
        public string TotalScore { get; set; }

        /// <summary>
        /// 代理商旺旺帐号
        /// </summary>
        [XmlElement("wangwang")]
        public string Wangwang { get; set; }
    }
}
