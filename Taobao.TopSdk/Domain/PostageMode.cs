using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// PostageMode Data Structure.
    /// </summary>
    [Serializable]
    public class PostageMode : TopObject
    {
        /// <summary>
        /// 邮费子项涉及的地区,多个地区用逗号连接数量串;可以用taobao.areas.get接口获取.或者参考:http://www.stats.gov.cn/tjbz/xzqhdm/t20080215_402462675.htm 例 (110000,310000,320000,330000).就代表邮费子项涉   及(北京,上海,江苏,浙江)四个地区.填写时要注意对照地区代码值,如果填入错误地区代码,将会出现错误信息.
        /// </summary>
        [XmlElement("dests")]
        public string Dests { get; set; }

        /// <summary>
        /// 运费方式项id
        /// </summary>
        [XmlElement("id")]
        public long Id { get; set; }

        /// <summary>
        /// 运费增价
        /// </summary>
        [XmlElement("increase")]
        public string Increase { get; set; }

        /// <summary>
        /// 运费模板ID
        /// </summary>
        [XmlElement("postage_id")]
        public long PostageId { get; set; }

        /// <summary>
        /// 运费单价
        /// </summary>
        [XmlElement("price")]
        public string Price { get; set; }

        /// <summary>
        /// 运费方式(目前提供):平邮(post),快递公司(express),EMS(ems)
        /// </summary>
        [XmlElement("type")]
        public string Type { get; set; }
    }
}
