using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// WarehouseReturnMain Data Structure.
    /// </summary>
    [Serializable]
    public class WarehouseReturnMain : TopObject
    {
        /// <summary>
        /// 买家地址
        /// </summary>
        [XmlElement("buyer_address")]
        public string BuyerAddress { get; set; }

        /// <summary>
        /// 买家联系人
        /// </summary>
        [XmlElement("buyer_contactor")]
        public string BuyerContactor { get; set; }

        /// <summary>
        /// 买家联系电话
        /// </summary>
        [XmlElement("buyer_phone")]
        public string BuyerPhone { get; set; }

        /// <summary>
        /// 联系方式,得到如下值： CONTACT_MODE_STORE -- 配送中心联系 CONTACT_MODE_DEALER -- 买家联系
        /// </summary>
        [XmlElement("contact_express_mode")]
        public string ContactExpressMode { get; set; }

        /// <summary>
        /// 退货单唯一标识
        /// </summary>
        [XmlElement("crk_code")]
        public string CrkCode { get; set; }

        /// <summary>
        /// 退货时间
        /// </summary>
        [XmlElement("crk_date")]
        public string CrkDate { get; set; }

        /// <summary>
        /// 服务方式，得到如下值(英文): OPTIONS_STORE -- 配送中心处理 OPTIONS_DEALER -- 商家处理
        /// </summary>
        [XmlElement("options")]
        public string Options { get; set; }

        /// <summary>
        /// 原物流编号
        /// </summary>
        [XmlElement("order_code")]
        public string OrderCode { get; set; }

        /// <summary>
        /// 原因描述
        /// </summary>
        [XmlElement("return_reason")]
        public string ReturnReason { get; set; }

        /// <summary>
        /// 退货原因,得到如下值(英文)： REASON_QUALITY -- 商品质量问题 REASON_UNCONFORMITY -- 收到的商品不符 REASON_REBATE -- 折扣、赠品、发票问题 REASON_HEBDOMAD -- 7天无理由退货 REASON_OTHER -- 其他
        /// </summary>
        [XmlElement("return_reason_code")]
        public string ReturnReasonCode { get; set; }

        /// <summary>
        /// 商家联系人
        /// </summary>
        [XmlElement("seller_contactor")]
        public string SellerContactor { get; set; }

        /// <summary>
        /// 商家联系电话
        /// </summary>
        [XmlElement("seller_phone")]
        public string SellerPhone { get; set; }

        /// <summary>
        /// 配送中心，若服务方式为配送中心，则该字段必填，反之则不填
        /// </summary>
        [XmlElement("seller_store_id")]
        public long SellerStoreId { get; set; }

        /// <summary>
        /// 退货单状态：   (编辑中) STATUS_EDIT;   (同步中) STATUS_SYN;   (已同步) STATUS_SYNCHRONIZED;   (待确认库存) STATUS_WAIT_CONFIRM;   (已完成) STATUS_COMPLETED;
        /// </summary>
        [XmlElement("status")]
        public string Status { get; set; }

        /// <summary>
        /// 原订单编号
        /// </summary>
        [XmlElement("taobao_trade_id")]
        public long TaobaoTradeId { get; set; }

        /// <summary>
        /// 物流公司
        /// </summary>
        [XmlElement("transport_name")]
        public string TransportName { get; set; }

        /// <summary>
        /// 运单号码,若联系方式选择配送中心，则该字段必填，反之则不填。
        /// </summary>
        [XmlElement("transport_no")]
        public string TransportNo { get; set; }
    }
}
