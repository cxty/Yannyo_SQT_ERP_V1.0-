using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// SkuExtra Data Structure.
    /// </summary>
    [Serializable]
    public class SkuExtra : TopObject
    {
        /// <summary>
        /// sku创建日期
        /// </summary>
        [XmlElement("created")]
        public string Created { get; set; }

        /// <summary>
        /// 主键
        /// </summary>
        [XmlElement("extra_id")]
        public long ExtraId { get; set; }

        /// <summary>
        /// 备注，不能大于1000个字节
        /// </summary>
        [XmlElement("memo")]
        public string Memo { get; set; }

        /// <summary>
        /// sku最后修改日期
        /// </summary>
        [XmlElement("modified")]
        public string Modified { get; set; }

        /// <summary>
        /// 属于这个sku的商品的价格 取值范围:0-100000000;精确到2位小数;单位:元。如:200.07，表示:200元7分。
        /// </summary>
        [XmlElement("price")]
        public string Price { get; set; }

        /// <summary>
        /// sku的销售属性组合字符串（颜色，大小，等等）,调用taobao.itemprops.get获取类目属性，如果属性是颜色属性，再用taobao.itempropvalues.get取得vid。格式:pid:vid;pid:vid。
        /// </summary>
        [XmlElement("properties")]
        public string Properties { get; set; }

        /// <summary>
        /// 属于这个sku的商品的数量,取值范围大于0的整数
        /// </summary>
        [XmlElement("quantity")]
        public long Quantity { get; set; }

        /// <summary>
        /// 扩展sku的id
        /// </summary>
        [XmlElement("sku_id")]
        public long SkuId { get; set; }
    }
}
