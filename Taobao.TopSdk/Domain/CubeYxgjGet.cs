using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// CubeYxgjGet Data Structure.
    /// </summary>
    [Serializable]
    public class CubeYxgjGet : TopObject
    {
        /// <summary>
        /// 类目名称
        /// </summary>
        [XmlElement("category_name")]
        public string CategoryName { get; set; }

        /// <summary>
        /// 类目id
        /// </summary>
        [XmlElement("cid")]
        public long Cid { get; set; }

        /// <summary>
        /// 日期
        /// </summary>
        [XmlElement("date")]
        public string Date { get; set; }

        /// <summary>
        /// 当日有搭配套餐订单的店铺数
        /// </summary>
        [XmlElement("dptc_shop_num")]
        public long DptcShopNum { get; set; }

        /// <summary>
        /// 最近30天有搭配套餐订单的店铺数
        /// </summary>
        [XmlElement("dptc_total_shop_num")]
        public long DptcTotalShopNum { get; set; }

        /// <summary>
        /// 店铺级别id
        /// </summary>
        [XmlElement("level_id")]
        public long LevelId { get; set; }

        /// <summary>
        /// 当日有满就送订单的店铺数
        /// </summary>
        [XmlElement("mjs_shop_num")]
        public long MjsShopNum { get; set; }

        /// <summary>
        /// 最近30天有满就送订单的店铺数
        /// </summary>
        [XmlElement("mjs_total_shop_num")]
        public long MjsTotalShopNum { get; set; }

        /// <summary>
        /// 当日有限时打折订单的店铺数
        /// </summary>
        [XmlElement("xsdz_shop_num")]
        public long XsdzShopNum { get; set; }

        /// <summary>
        /// 最近30天有限时打折订单的店铺数
        /// </summary>
        [XmlElement("xsdz_total_shop_num")]
        public long XsdzTotalShopNum { get; set; }
    }
}
