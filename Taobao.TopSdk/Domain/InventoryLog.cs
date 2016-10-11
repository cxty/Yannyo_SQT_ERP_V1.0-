using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// InventoryLog Data Structure.
    /// </summary>
    [Serializable]
    public class InventoryLog : TopObject
    {
        /// <summary>
        /// 变更正品数量
        /// </summary>
        [XmlElement("change_count")]
        public long ChangeCount { get; set; }

        /// <summary>
        /// 商品出入库标识PUT_IN(入库),OUT(出库)
        /// </summary>
        [XmlElement("flag")]
        public string Flag { get; set; }

        /// <summary>
        /// 记录创建时间
        /// </summary>
        [XmlElement("gmt_create")]
        public string GmtCreate { get; set; }

        /// <summary>
        /// 记录修改时间
        /// </summary>
        [XmlElement("gmt_modified")]
        public string GmtModified { get; set; }

        /// <summary>
        /// 库存id
        /// </summary>
        [XmlElement("inventory_id")]
        public string InventoryId { get; set; }

        /// <summary>
        /// 库存变更记录id
        /// </summary>
        [XmlElement("inventory_log_id")]
        public string InventoryLogId { get; set; }

        /// <summary>
        /// 商品id
        /// </summary>
        [XmlElement("item_id")]
        public string ItemId { get; set; }

        /// <summary>
        /// 变更废品数量
        /// </summary>
        [XmlElement("junk_count")]
        public long JunkCount { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [XmlElement("operate_remark")]
        public string OperateRemark { get; set; }

        /// <summary>
        /// 商家编码
        /// </summary>
        [XmlElement("outer_id")]
        public string OuterId { get; set; }

        /// <summary>
        /// 库存变更原因PUT_IN_STOCK(入库),STOCK_TRANSFER(出库),STOCKTAKING(盘点),SELL(正常销售),RETURN_GOODS(退货)
        /// </summary>
        [XmlElement("reason")]
        public string Reason { get; set; }

        /// <summary>
        /// 自定义仓库id
        /// </summary>
        [XmlElement("seller_store_id")]
        public string SellerStoreId { get; set; }

        /// <summary>
        /// 库存变更状态UNCONFIRMED(待确认),CONFIRMED(已确认)
        /// </summary>
        [XmlElement("status")]
        public string Status { get; set; }
    }
}
