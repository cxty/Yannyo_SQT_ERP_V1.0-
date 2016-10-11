using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// ElinkOrderLogistics Data Structure.
    /// </summary>
    [Serializable]
    public class ElinkOrderLogistics : TopObject
    {
        /// <summary>
        /// 发票金额
        /// </summary>
        [XmlElement("invoice_price")]
        public string InvoicePrice { get; set; }

        /// <summary>
        /// 物料编码
        /// </summary>
        [XmlElement("materials_id")]
        public string MaterialsId { get; set; }

        /// <summary>
        /// 商品数量
        /// </summary>
        [XmlElement("num")]
        public long Num { get; set; }

        /// <summary>
        /// 商品ID
        /// </summary>
        [XmlElement("num_iid")]
        public long NumIid { get; set; }

        /// <summary>
        /// 子订单编号
        /// </summary>
        [XmlElement("oid")]
        public long Oid { get; set; }

        /// <summary>
        /// 商家编码
        /// </summary>
        [XmlElement("outer_id")]
        public string OuterId { get; set; }

        /// <summary>
        /// 采购单编号
        /// </summary>
        [XmlElement("purchase_oid")]
        public string PurchaseOid { get; set; }

        /// <summary>
        /// 采购明细单ID
        /// </summary>
        [XmlElement("purchase_order_id")]
        public string PurchaseOrderId { get; set; }

        /// <summary>
        /// 零售商留言
        /// </summary>
        [XmlElement("retailers_message")]
        public string RetailersMessage { get; set; }

        /// <summary>
        /// 销售属性
        /// </summary>
        [XmlElement("sku_properties")]
        public string SkuProperties { get; set; }

        /// <summary>
        /// 物流订单状态。可选值：*WAIT_SEND_GOODS(等待发货)：*WAIT_CONFIRM_GOODS(已发货)
        /// </summary>
        [XmlElement("status")]
        public string Status { get; set; }

        /// <summary>
        /// 淘宝订单ID
        /// </summary>
        [XmlElement("tid")]
        public long Tid { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        [XmlElement("title")]
        public string Title { get; set; }

        /// <summary>
        /// 发货类型。*TRADE_GHS(供货商需发货订单);
        /// </summary>
        [XmlElement("type")]
        public string Type { get; set; }
    }
}
