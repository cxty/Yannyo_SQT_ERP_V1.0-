using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// Passenger Data Structure.
    /// </summary>
    [Serializable]
    public class Passenger : TopObject
    {
        /// <summary>
        /// 乘机人生日
        /// </summary>
        [XmlElement("birthday")]
        public string Birthday { get; set; }

        /// <summary>
        /// 机场建设费，单位分
        /// </summary>
        [XmlElement("build_price")]
        public long BuildPrice { get; set; }

        /// <summary>
        /// 证件号码，只显示前三位和后四位，其余部分屏蔽
        /// </summary>
        [XmlElement("cert_no")]
        public string CertNo { get; set; }

        /// <summary>
        /// （0：身份证，1：护照，2：学生证，3：军人证，4：回乡证，5：台胞证，6：港澳台胞，7：国际海员，8：外国人永久居留证，9：其他）
        /// </summary>
        [XmlElement("cert_type")]
        public long CertType { get; set; }

        /// <summary>
        /// 燃油附加税，单位分
        /// </summary>
        [XmlElement("oil_price")]
        public long OilPrice { get; set; }

        /// <summary>
        /// 乘机人标识
        /// </summary>
        [XmlElement("passenger_id")]
        public long PassengerId { get; set; }

        /// <summary>
        /// 乘机人姓名
        /// </summary>
        [XmlElement("passenger_name")]
        public string PassengerName { get; set; }

        /// <summary>
        /// 乘机人联系电话
        /// </summary>
        [XmlElement("passenger_phone")]
        public string PassengerPhone { get; set; }

        /// <summary>
        /// PNR信息
        /// </summary>
        [XmlElement("pnr")]
        public string Pnr { get; set; }

        /// <summary>
        /// 票号
        /// </summary>
        [XmlElement("ticket_no")]
        public string TicketNo { get; set; }

        /// <summary>
        /// 票价，单位分
        /// </summary>
        [XmlElement("ticket_price")]
        public long TicketPrice { get; set; }

        /// <summary>
        /// 票类型，0代表成人票，1代表儿童票
        /// </summary>
        [XmlElement("ticket_type")]
        public long TicketType { get; set; }
    }
}
