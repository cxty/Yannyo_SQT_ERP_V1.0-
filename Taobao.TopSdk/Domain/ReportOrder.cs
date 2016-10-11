using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// ReportOrder Data Structure.
    /// </summary>
    [Serializable]
    public class ReportOrder : TopObject
    {
        /// <summary>
        /// 商品描述
        /// </summary>
        [XmlElement("desc")]
        public string Desc { get; set; }

        /// <summary>
        /// 剩余数量
        /// </summary>
        [XmlElement("lave_count")]
        public long LaveCount { get; set; }

        /// <summary>
        /// 商家编码
        /// </summary>
        [XmlElement("outer_id")]
        public string OuterId { get; set; }

        /// <summary>
        /// 销售金额
        /// </summary>
        [XmlElement("price")]
        public string Price { get; set; }

        /// <summary>
        /// 进货数量
        /// </summary>
        [XmlElement("purchase_count")]
        public long PurchaseCount { get; set; }

        /// <summary>
        /// 采购单编号
        /// </summary>
        [XmlElement("purchase_oid")]
        public string PurchaseOid { get; set; }

        /// <summary>
        /// 进货价
        /// </summary>
        [XmlElement("purchase_price")]
        public string PurchasePrice { get; set; }

        /// <summary>
        /// 采购时间
        /// </summary>
        [XmlElement("purchase_time")]
        public string PurchaseTime { get; set; }

        /// <summary>
        /// 零售商名称
        /// </summary>
        [XmlElement("retailers_name")]
        public string RetailersName { get; set; }

        /// <summary>
        /// 销售数量
        /// </summary>
        [XmlElement("sale_count")]
        public long SaleCount { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        [XmlElement("title")]
        public string Title { get; set; }

        /// <summary>
        /// 合作模式。*DISTRIBUTE(经销)*VENDOR(代销)
        /// </summary>
        [XmlElement("tp_type")]
        public string TpType { get; set; }
    }
}
