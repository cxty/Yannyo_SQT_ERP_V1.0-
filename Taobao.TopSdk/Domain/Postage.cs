using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Domain
{
    /// <summary>
    /// Postage Data Structure.
    /// </summary>
    [Serializable]
    public class Postage : TopObject
    {
        /// <summary>
        /// 创建日期
        /// </summary>
        [XmlElement("created")]
        public string Created { get; set; }

        /// <summary>
        /// EMS加件费用
        /// </summary>
        [XmlElement("ems_increase")]
        public string EmsIncrease { get; set; }

        /// <summary>
        /// EMS收费
        /// </summary>
        [XmlElement("ems_price")]
        public string EmsPrice { get; set; }

        /// <summary>
        /// 快递加件费用
        /// </summary>
        [XmlElement("express_increase")]
        public string ExpressIncrease { get; set; }

        /// <summary>
        /// 快递收费
        /// </summary>
        [XmlElement("express_price")]
        public string ExpressPrice { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [XmlElement("memo")]
        public string Memo { get; set; }

        /// <summary>
        /// 最后修改日期
        /// </summary>
        [XmlElement("modified")]
        public string Modified { get; set; }

        /// <summary>
        /// 运费模板名称
        /// </summary>
        [XmlElement("name")]
        public string Name { get; set; }

        /// <summary>
        /// 平邮加件收费
        /// </summary>
        [XmlElement("post_increase")]
        public string PostIncrease { get; set; }

        /// <summary>
        /// 平邮收费
        /// </summary>
        [XmlElement("post_price")]
        public string PostPrice { get; set; }

        /// <summary>
        /// 运费模板ID
        /// </summary>
        [XmlElement("postage_id")]
        public long PostageId { get; set; }

        /// <summary>
        /// 运费方式模板收费方式。如果需要获取邮费子模板的相关数据，请设置为postage_mode.id,postage_mode.type,postage_mode.dests,postage_mode.price等形式
        /// </summary>
        [XmlArray("postage_modes")]
        [XmlArrayItem("postage_mode")]
        public List<PostageMode> PostageModes { get; set; }
    }
}
