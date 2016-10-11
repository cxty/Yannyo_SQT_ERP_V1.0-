using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Domain
{
    /// <summary>
    /// PurchaseOrder Data Structure.
    /// </summary>
    [Serializable]
    public class PurchaseOrder : TopObject
    {
        /// <summary>
        /// 支付宝交易号。
        /// </summary>
        [XmlElement("alipay_no")]
        public string AlipayNo { get; set; }

        /// <summary>
        /// 买家nick，供应商查询不会返回买家昵称，分销商查询才会返回。
        /// </summary>
        [XmlElement("buyer_nick")]
        public string BuyerNick { get; set; }

        /// <summary>
        /// 物流发货时间。格式:yyyy-MM-dd HH:mm:ss
        /// </summary>
        [XmlElement("consign_time")]
        public string ConsignTime { get; set; }

        /// <summary>
        /// 采购单创建时间。格式:yyyy-MM-dd HH:mm:ss
        /// </summary>
        [XmlElement("created")]
        public string Created { get; set; }

        /// <summary>
        /// 分销商来源网站（taobao）。
        /// </summary>
        [XmlElement("distributor_from")]
        public string DistributorFrom { get; set; }

        /// <summary>
        /// 分销商实付金额。(精确到2位小数;单位:元。如:200.07，表示:200元7分 )
        /// </summary>
        [XmlElement("distributor_payment")]
        public string DistributorPayment { get; set; }

        /// <summary>
        /// 分销商在来源网站的帐号名。
        /// </summary>
        [XmlElement("distributor_username")]
        public string DistributorUsername { get; set; }

        /// <summary>
        /// 分销平台产生的采购单主键
        /// </summary>
        [XmlElement("fenxiao_id")]
        public long FenxiaoId { get; set; }

        /// <summary>
        /// 采购单编号。(淘宝交易编号)
        /// </summary>
        [XmlElement("id")]
        public long Id { get; set; }

        /// <summary>
        /// 采购单留言。
        /// </summary>
        [XmlElement("memo")]
        public string Memo { get; set; }

        /// <summary>
        /// 交易修改时间。格式:yyyy-MM-dd HH:mm:ss
        /// </summary>
        [XmlElement("modified")]
        public string Modified { get; set; }

        /// <summary>
        /// 付款时间。格式:yyyy-MM-dd HH:mm:ss
        /// </summary>
        [XmlElement("pay_time")]
        public string PayTime { get; set; }

        /// <summary>
        /// 支付方式：ALIPAY_SURETY（支付宝担保交易）、TRANSFER（转账汇款）、PREPAY（企业预存款）、SETTLEMENT（后期结算）
        /// </summary>
        [XmlElement("pay_type")]
        public string PayType { get; set; }

        /// <summary>
        /// 采购单邮费。(精确到2位小数;单位:元。如:200.07，表示:200元7分 )
        /// </summary>
        [XmlElement("post_fee")]
        public string PostFee { get; set; }

        /// <summary>
        /// 买家详细的信息。
        /// </summary>
        [XmlElement("receiver")]
        public Receiver Receiver { get; set; }

        /// <summary>
        /// 订单快照URL
        /// </summary>
        [XmlElement("snapshot_url")]
        public string SnapshotUrl { get; set; }

        /// <summary>
        /// 采购单交易状态。可选值：<br> WAIT_BUYER_PAY(等待付款)<br> WAIT_CONFIRM(付款信息待确认)<br> WAIT_CONFIRM_WAIT_SEND_GOODS(付款信息待确认，待发货)<br> WAIT_CONFIRM_SEND_GOODS(付款信息待确认，已发货)<br> WAIT_CONFIRM_GOODS_CONFIRM(付款信息待确认，已收货)<br> WAIT_SELLER_SEND_GOODS(已付款，待发货<br> WAIT_BUYER_CONFIRM_GOODS(已付款，已发货)<br> CONFIRM_WAIT_SEND_GOODS(付款信息已确认，待发货)<br> CONFIRM_SEND_GOODS(付款信息已确认，已发货)<br> TRADE_FINISHED(交易成功)<br> TRADE_CLOSED(交易关闭)
        /// </summary>
        [XmlElement("status")]
        public string Status { get; set; }

        /// <summary>
        /// 子订单的详细信息列表。
        /// </summary>
        [XmlArray("sub_purchase_orders")]
        [XmlArrayItem("sub_purchase_order")]
        public List<SubPurchaseOrder> SubPurchaseOrders { get; set; }

        /// <summary>
        /// 供应商来源网站, values: taobao, alibaba
        /// </summary>
        [XmlElement("supplier_from")]
        public string SupplierFrom { get; set; }

        /// <summary>
        /// 供应商备注
        /// </summary>
        [XmlElement("supplier_memo")]
        public string SupplierMemo { get; set; }

        /// <summary>
        /// 供应商在来源网站的帐号名。
        /// </summary>
        [XmlElement("supplier_username")]
        public string SupplierUsername { get; set; }

        /// <summary>
        /// 主订单ID （经销不显示）
        /// </summary>
        [XmlElement("tc_order_id")]
        public long TcOrderId { get; set; }

        /// <summary>
        /// 采购单总额（不含邮费,精确到2位小数;单位:元。如:200.07，表示:200元7分 )
        /// </summary>
        [XmlElement("total_fee")]
        public string TotalFee { get; set; }

        /// <summary>
        /// 分销方式：AGENT（代销）、DEALER（经销）
        /// </summary>
        [XmlElement("trade_type")]
        public string TradeType { get; set; }
    }
}
