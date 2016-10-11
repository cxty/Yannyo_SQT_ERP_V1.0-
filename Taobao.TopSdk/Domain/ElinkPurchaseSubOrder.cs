using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// ElinkPurchaseSubOrder Data Structure.
    /// </summary>
    [Serializable]
    public class ElinkPurchaseSubOrder : TopObject
    {
        /// <summary>
        /// 实际采购数量
        /// </summary>
        [XmlElement("actual_num")]
        public long ActualNum { get; set; }

        /// <summary>
        /// 库存锁定期（以明细表为准）
        /// </summary>
        [XmlElement("inventory_lockdays")]
        public long InventoryLockdays { get; set; }

        /// <summary>
        /// 物料编号ID
        /// </summary>
        [XmlElement("materials_id")]
        public string MaterialsId { get; set; }

        /// <summary>
        /// 商品数字ID
        /// </summary>
        [XmlElement("num_iid")]
        public long NumIid { get; set; }

        /// <summary>
        /// 商家编码
        /// </summary>
        [XmlElement("outer_id")]
        public string OuterId { get; set; }

        /// <summary>
        /// 计划采购数量
        /// </summary>
        [XmlElement("plans_num")]
        public long PlansNum { get; set; }

        /// <summary>
        /// 价损比例（以明细表为准）
        /// </summary>
        [XmlElement("priceloss_scale")]
        public string PricelossScale { get; set; }

        /// <summary>
        /// 产品描述
        /// </summary>
        [XmlElement("product_description")]
        public string ProductDescription { get; set; }

        /// <summary>
        /// 产品名称
        /// </summary>
        [XmlElement("product_name")]
        public string ProductName { get; set; }

        /// <summary>
        /// 采购明细ID
        /// </summary>
        [XmlElement("purchase_detailsid")]
        public string PurchaseDetailsid { get; set; }

        /// <summary>
        /// 采购单编号（跟采购单主表关联）
        /// </summary>
        [XmlElement("purchase_oid")]
        public string PurchaseOid { get; set; }

        /// <summary>
        /// 进货价
        /// </summary>
        [XmlElement("purchase_price")]
        public string PurchasePrice { get; set; }

        /// <summary>
        /// 库存锁定期结束时间
        /// </summary>
        [XmlElement("stock_end")]
        public string StockEnd { get; set; }

        /// <summary>
        /// 库存锁定期开始时间
        /// </summary>
        [XmlElement("stock_start")]
        public string StockStart { get; set; }

        /// <summary>
        /// 采购明细单总金额(进货价*计划采购数量)
        /// </summary>
        [XmlElement("total_price")]
        public string TotalPrice { get; set; }
    }
}
