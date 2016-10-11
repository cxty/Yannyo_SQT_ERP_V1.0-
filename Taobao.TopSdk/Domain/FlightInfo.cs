using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Domain
{
    /// <summary>
    /// FlightInfo Data Structure.
    /// </summary>
    [Serializable]
    public class FlightInfo : TopObject
    {
        /// <summary>
        /// 航空公司二字码
        /// </summary>
        [XmlElement("airline_code")]
        public string AirlineCode { get; set; }

        /// <summary>
        /// 航空公司名称
        /// </summary>
        [XmlElement("airline_name")]
        public string AirlineName { get; set; }

        /// <summary>
        /// 到达机场三字吗
        /// </summary>
        [XmlElement("arr_airport_code")]
        public string ArrAirportCode { get; set; }

        /// <summary>
        /// 到达机场名称
        /// </summary>
        [XmlElement("arr_airport_name")]
        public string ArrAirportName { get; set; }

        /// <summary>
        /// 到达日期，根据需要进行格式化
        /// </summary>
        [XmlElement("arr_date")]
        public string ArrDate { get; set; }

        /// <summary>
        /// 到达时间，根据需要进行格式化
        /// </summary>
        [XmlElement("arr_time")]
        public string ArrTime { get; set; }

        /// <summary>
        /// 航班信息中的舱位信息列表
        /// </summary>
        [XmlArray("cabin_price_list")]
        [XmlArrayItem("cabin_price")]
        public List<CabinPrice> CabinPriceList { get; set; }

        /// <summary>
        /// 承运航班
        /// </summary>
        [XmlElement("carrier")]
        public string Carrier { get; set; }

        /// <summary>
        /// 出发机场三字吗
        /// </summary>
        [XmlElement("dep_airport_code")]
        public string DepAirportCode { get; set; }

        /// <summary>
        /// 出发机场名称
        /// </summary>
        [XmlElement("dep_airport_name")]
        public string DepAirportName { get; set; }

        /// <summary>
        /// 出发日期，根据需要进行格式化
        /// </summary>
        [XmlElement("dep_date")]
        public string DepDate { get; set; }

        /// <summary>
        /// 出发时间，根据需要进行格式化
        /// </summary>
        [XmlElement("dep_time")]
        public string DepTime { get; set; }

        /// <summary>
        /// 机场建设费，以分为单位
        /// </summary>
        [XmlElement("fees")]
        public long Fees { get; set; }

        /// <summary>
        /// 航班号
        /// </summary>
        [XmlElement("flight")]
        public string Flight { get; set; }

        /// <summary>
        /// 机型
        /// </summary>
        [XmlElement("flight_type")]
        public string FlightType { get; set; }

        /// <summary>
        /// 航班id，tb机票系统特有，方便查问题，下订单时必需字段
        /// </summary>
        [XmlElement("id")]
        public string Id { get; set; }

        /// <summary>
        /// 是否提供餐饮
        /// </summary>
        [XmlElement("meals")]
        public long Meals { get; set; }

        /// <summary>
        /// 里程
        /// </summary>
        [XmlElement("miles")]
        public long Miles { get; set; }

        /// <summary>
        /// 标准价格，Y舱价格，以分为单位
        /// </summary>
        [XmlElement("stand_price")]
        public long StandPrice { get; set; }

        /// <summary>
        /// 转停
        /// </summary>
        [XmlElement("stops")]
        public long Stops { get; set; }

        /// <summary>
        /// 燃油税，以分为单位
        /// </summary>
        [XmlElement("taxes")]
        public long Taxes { get; set; }
    }
}
