using System;
using System.Xml.Serialization;
using Top.Api.Domain;

namespace Top.Api.Response
{
    /// <summary>
    /// WarehouseOrderGetResponse.
    /// </summary>
    public class WarehouseOrderGetResponse : TopResponse
    {
        /// <summary>
        /// 物流公司编码
        /// </summary>
        [XmlElement("company_code")]
        public string CompanyCode { get; set; }

        /// <summary>
        /// 物流公司id
        /// </summary>
        [XmlElement("company_id")]
        public long CompanyId { get; set; }

        /// <summary>
        /// 淘宝物流平台物流订单编号
        /// </summary>
        [XmlElement("order_code")]
        public string OrderCode { get; set; }

        /// <summary>
        /// 物流订单ID
        /// </summary>
        [XmlElement("order_id")]
        public string OrderId { get; set; }

        /// <summary>
        /// 物流订单状态。  返回值如下：HANGUP(订单挂起)；CLOSED(订单已关闭)；  WAITING_TO_BE_SENT(等待下单给物流公司)；  SENT_COMPANY_MAKE_SURE(订单已发给物流公司)；  COMPANY_MAKE_SURE(物流公司已确认收到下单消息)；  ACCEPTED_BY_COMPANY(物流公司已接单)；  REJECTED_BY_COMPANY(物流公司不接单)；  TAKEN_IN_SUCCESS(揽收成功)；  TAKEN_IN_FAILED(揽收失败)；  LOST(丢单)；  SIGN_IN(签收成功)；  REJECTED_BY_OTHER_SIDE(签收失败)；
        /// </summary>
        [XmlElement("order_status")]
        public string OrderStatus { get; set; }

        /// <summary>
        /// 物流公司运单号
        /// </summary>
        [XmlElement("out_sid")]
        public string OutSid { get; set; }

        /// <summary>
        /// 收货人详细地址
        /// </summary>
        [XmlElement("receiver_address")]
        public string ReceiverAddress { get; set; }

        /// <summary>
        /// 收货人姓名
        /// </summary>
        [XmlElement("receiver_name")]
        public string ReceiverName { get; set; }

        /// <summary>
        /// 卖家默认发货所在区域详细地址
        /// </summary>
        [XmlElement("seller_address")]
        public string SellerAddress { get; set; }

        /// <summary>
        /// 卖家默认发货所在区域ID;  如浙江省杭州市区湖区对应seller_are_id=330106;
        /// </summary>
        [XmlElement("seller_area_id")]
        public string SellerAreaId { get; set; }

        /// <summary>
        /// 卖家移动电话
        /// </summary>
        [XmlElement("seller_mobile")]
        public string SellerMobile { get; set; }

        /// <summary>
        /// 卖家姓名
        /// </summary>
        [XmlElement("seller_name")]
        public string SellerName { get; set; }

        /// <summary>
        /// 卖家联系电话
        /// </summary>
        [XmlElement("seller_phone")]
        public string SellerPhone { get; set; }

        /// <summary>
        /// 自定义仓储ID
        /// </summary>
        [XmlElement("seller_store_id")]
        public string SellerStoreId { get; set; }

        /// <summary>
        /// 卖家默认邮编
        /// </summary>
        [XmlElement("seller_zip")]
        public string SellerZip { get; set; }

        /// <summary>
        /// 淘宝交易号
        /// </summary>
        [XmlElement("tid")]
        public string Tid { get; set; }

        /// <summary>
        /// 支付宝交易号
        /// </summary>
        [XmlElement("trade_id")]
        public string TradeId { get; set; }
    }
}
