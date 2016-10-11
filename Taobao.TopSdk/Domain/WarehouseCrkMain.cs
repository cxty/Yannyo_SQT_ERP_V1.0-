using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// WarehouseCrkMain Data Structure.
    /// </summary>
    [Serializable]
    public class WarehouseCrkMain : TopObject
    {
        /// <summary>
        /// 商品种类数量
        /// </summary>
        [XmlElement("auction_count")]
        public long AuctionCount { get; set; }

        /// <summary>
        /// 运输公司联系人身份证号
        /// </summary>
        [XmlElement("card_id")]
        public string CardId { get; set; }

        /// <summary>
        /// 出入库单唯一标识
        /// </summary>
        [XmlElement("crk_code")]
        public string CrkCode { get; set; }

        /// <summary>
        /// 出入库实际日期
        /// </summary>
        [XmlElement("crk_date")]
        public string CrkDate { get; set; }

        /// <summary>
        /// 出库运输目的地
        /// </summary>
        [XmlElement("destination")]
        public string Destination { get; set; }

        /// <summary>
        /// 预计出入库时间
        /// </summary>
        [XmlElement("expect_crk_date")]
        public string ExpectCrkDate { get; set; }

        /// <summary>
        /// 已返回的出入库商品数量
        /// </summary>
        [XmlElement("return_count")]
        public long ReturnCount { get; set; }

        /// <summary>
        /// 商家联系人
        /// </summary>
        [XmlElement("seller_contactor")]
        public string SellerContactor { get; set; }

        /// <summary>
        /// 商家名称
        /// </summary>
        [XmlElement("seller_name")]
        public string SellerName { get; set; }

        /// <summary>
        /// 商家联系电话
        /// </summary>
        [XmlElement("seller_phone")]
        public string SellerPhone { get; set; }

        /// <summary>
        /// 出入库状态：   (编辑中) STATUS_EDIT;  (同步中) STATUS_SYN;  (已同步) STATUS_SYNCHRONIZED;  (待确认库存) STATUS_WAIT_CONFIRM;  (已完成) STATUS_COMPLETED;
        /// </summary>
        [XmlElement("status")]
        public string Status { get; set; }

        /// <summary>
        /// 总箱数
        /// </summary>
        [XmlElement("total_package")]
        public long TotalPackage { get; set; }

        /// <summary>
        /// 运输公司联系人
        /// </summary>
        [XmlElement("transport_contactor")]
        public string TransportContactor { get; set; }

        /// <summary>
        /// 运输公司联系电话
        /// </summary>
        [XmlElement("transport_contactor_phone")]
        public string TransportContactorPhone { get; set; }

        /// <summary>
        /// 运输公司名称
        /// </summary>
        [XmlElement("transport_name")]
        public string TransportName { get; set; }

        /// <summary>
        /// 运输公司运单号
        /// </summary>
        [XmlElement("transport_no")]
        public string TransportNo { get; set; }

        /// <summary>
        /// 出入库类型:TYPE_STOCK_IN  TYPE_STOCK_OUT
        /// </summary>
        [XmlElement("type")]
        public string Type { get; set; }

        /// <summary>
        /// 待确认的库存变更数
        /// </summary>
        [XmlElement("wait_confirm")]
        public long WaitConfirm { get; set; }
    }
}
