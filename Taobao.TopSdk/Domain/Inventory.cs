using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// Inventory Data Structure.
    /// </summary>
    [Serializable]
    public class Inventory : TopObject
    {
        /// <summary>
        /// 仓库商品ID，同item_id，目前只有taobao.warehouse.items.page.get返回的是auction_id
        /// </summary>
        [XmlElement("auction_id")]
        public long AuctionId { get; set; }

        /// <summary>
        /// 库存ID
        /// </summary>
        [XmlElement("id")]
        public long Id { get; set; }

        /// <summary>
        /// 仓储商品ID
        /// </summary>
        [XmlElement("item_id")]
        public long ItemId { get; set; }

        /// <summary>
        /// 库存废品数量
        /// </summary>
        [XmlElement("junk_count")]
        public long JunkCount { get; set; }

        /// <summary>
        /// 商家编码 卖家用来识别淘宝店铺与外部网店之间产品、商品一致性的自定义编码方式，业务场景如卖家通过此商家编码定时把外部网店的商品销售数量更新到淘宝店铺。
        /// </summary>
        [XmlElement("outer_id")]
        public string OuterId { get; set; }

        /// <summary>
        /// 可销售库存数量
        /// </summary>
        [XmlElement("sell_count")]
        public long SellCount { get; set; }

        /// <summary>
        /// 商家标识
        /// </summary>
        [XmlElement("seller_code")]
        public string SellerCode { get; set; }

        /// <summary>
        /// 自定义仓库标识
        /// </summary>
        [XmlElement("sellerstore_id")]
        public long SellerstoreId { get; set; }

        /// <summary>
        /// 状态: 数字1代表ASYNCHRONISM(未同步) 数字2代表SYCHRONISM(同步) 数字3代表DELETED(删除)
        /// </summary>
        [XmlElement("status")]
        public long Status { get; set; }

        /// <summary>
        /// 外部仓库编码
        /// </summary>
        [XmlElement("store_code")]
        public string StoreCode { get; set; }

        /// <summary>
        /// 总库存数量
        /// </summary>
        [XmlElement("total_count")]
        public long TotalCount { get; set; }

        /// <summary>
        /// 库存警戒值
        /// </summary>
        [XmlElement("warn_line")]
        public long WarnLine { get; set; }
    }
}
