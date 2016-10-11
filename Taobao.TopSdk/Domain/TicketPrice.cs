using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// TicketPrice Data Structure.
    /// </summary>
    [Serializable]
    public class TicketPrice : TopObject
    {
        /// <summary>
        /// 机场建设费 以分为单位
        /// </summary>
        [XmlElement("build_price")]
        public long BuildPrice { get; set; }

        /// <summary>
        /// 燃油附加税，以分为单位
        /// </summary>
        [XmlElement("oil_price")]
        public long OilPrice { get; set; }

        /// <summary>
        /// 机票价格 以分为单位
        /// </summary>
        [XmlElement("tkt_price")]
        public long TktPrice { get; set; }

        /// <summary>
        /// 0:成人价,1:儿童价
        /// </summary>
        [XmlElement("type")]
        public long Type { get; set; }
    }
}
