using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// CabinPrice Data Structure.
    /// </summary>
    [Serializable]
    public class CabinPrice : TopObject
    {
        /// <summary>
        /// 可以销售当前舱位的代理商id列表
        /// </summary>
        [XmlElement("air_supply_ids")]
        public string AirSupplyIds { get; set; }

        /// <summary>
        /// 舱位等级：  -1，不确定；  0：头等舱；  1：商务舱；  2：经济舱
        /// </summary>
        [XmlElement("cabin_class")]
        public long CabinClass { get; set; }

        /// <summary>
        /// 舱位代码：【A-Z】，航空公司的舱位代码
        /// </summary>
        [XmlElement("cabin_code")]
        public string CabinCode { get; set; }

        /// <summary>
        /// 产品规则说明，特殊产品
        /// </summary>
        [XmlElement("cabin_memo")]
        public string CabinMemo { get; set; }

        /// <summary>
        /// 剩余可售票数，  0～9，表示剩余0~9张  A，表示大于9张
        /// </summary>
        [XmlElement("cabin_num")]
        public string CabinNum { get; set; }

        /// <summary>
        /// 实际销售价格，以分为单位
        /// </summary>
        [XmlElement("cabin_price")]
        public long CabinPrice_ { get; set; }

        /// <summary>
        /// 产品类型：  6，普通特价；  8，让利产品；  10，特殊产品
        /// </summary>
        [XmlElement("cabin_type")]
        public string CabinType { get; set; }

        /// <summary>
        /// 儿童票价格，以分为单位
        /// </summary>
        [XmlElement("child_cabin_price")]
        public long ChildCabinPrice { get; set; }

        /// <summary>
        /// 舱位折扣：10~90
        /// </summary>
        [XmlElement("discount")]
        public long Discount { get; set; }

        /// <summary>
        /// 航班id
        /// </summary>
        [XmlElement("flight_id")]
        public long FlightId { get; set; }

        /// <summary>
        /// 舱位id
        /// </summary>
        [XmlElement("id")]
        public long Id { get; set; }

        /// <summary>
        /// 外部产品类型，即航空公司产品类型，如果存在，下单时必须参数
        /// </summary>
        [XmlElement("out_product_id")]
        public string OutProductId { get; set; }

        /// <summary>
        /// 扣减的钱，以分为单位
        /// </summary>
        [XmlElement("return_fee")]
        public long ReturnFee { get; set; }

        /// <summary>
        /// 特价/让利/特殊产品id；如果为这三类产品之一，下单时必需参数
        /// </summary>
        [XmlElement("special_product_id")]
        public long SpecialProductId { get; set; }

        /// <summary>
        /// 退改签规则
        /// </summary>
        [XmlElement("tui_gai_qian")]
        public string TuiGaiQian { get; set; }
    }
}
