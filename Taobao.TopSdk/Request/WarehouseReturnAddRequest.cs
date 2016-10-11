using System;
using System.Collections.Generic;
using Top.Api.Response;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.warehouse.return.add
    /// </summary>
    public class WarehouseReturnAddRequest : ITopRequest<WarehouseReturnAddResponse>
    {
        /// <summary>
        /// 买家地址
        /// </summary>
        public string BuyerAddress { get; set; }

        /// <summary>
        /// 买家联系人
        /// </summary>
        public string BuyerContactor { get; set; }

        /// <summary>
        /// 买家联系电话。格式：纯数字(手机) 或者 区号-数字
        /// </summary>
        public string BuyerPhone { get; set; }

        /// <summary>
        /// 联系方式,只能输入如下值：  CONTACT_MODE_STORE --  配送中心联系  CONTACT_MODE_DEALER --  买家联系
        /// </summary>
        public string ContactExpressMode { get; set; }

        /// <summary>
        /// 服务方式，只能输入如下值(英文):  OPTIONS_STORE --  配送中心处理  OPTIONS_DEALER --  商家处理
        /// </summary>
        public string Options { get; set; }

        /// <summary>
        /// 原物流编号，与“原订单编号”至少选填一个
        /// </summary>
        public string OrderCode { get; set; }

        /// <summary>
        /// 要退货的商品的商家编码，以逗号隔开
        /// </summary>
        public string OuterIds { get; set; }

        /// <summary>
        /// 计划退货数量，以逗号隔开，个数与商家编码一致。
        /// </summary>
        public string PlanCount { get; set; }

        /// <summary>
        /// 备注,个数与商家编码一致，以逗号隔开。若中间无值也需以占一个值. 例"test1,,test3".若全为空则不需要给值
        /// </summary>
        public string Remarks { get; set; }

        /// <summary>
        /// 原因描述
        /// </summary>
        public string ReturnReason { get; set; }

        /// <summary>
        /// 退货原因,只能输入如下值(英文)：  REASON_QUALITY -- 商品质量问题  REASON_UNCONFORMITY -- 收到的商品不符  REASON_REBATE  -- 折扣、赠品、发票问题  REASON_HEBDOMAD  -- 7天无理由退货  REASON_OTHER  -- 其他
        /// </summary>
        public string ReturnReasonCode { get; set; }

        /// <summary>
        /// 商家联系人
        /// </summary>
        public string SellerContactor { get; set; }

        /// <summary>
        /// 商家联系电话。格式：纯数字(手机) 或者 区号-数字
        /// </summary>
        public string SellerPhone { get; set; }

        /// <summary>
        /// 配送中心，若服务方式为配送中心处理，则该字段必填，反之则不填
        /// </summary>
        public Nullable<long> SellerStoreId { get; set; }

        /// <summary>
        /// 原订单编号，与“原物流编号”至少选填一个。
        /// </summary>
        public Nullable<long> TaobaoTradeId { get; set; }

        /// <summary>
        /// 物流公司
        /// </summary>
        public string TransportName { get; set; }

        /// <summary>
        /// 运单号码,若联系方式选择买家联系，则该字段必填，反之则不填。说明：退货快递公司运单上的运单号
        /// </summary>
        public string TransportNo { get; set; }

        #region ITopRequest Members

        public string GetApiName()
        {
            return "taobao.warehouse.return.add";
        }

        public IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("buyer_address", this.BuyerAddress);
            parameters.Add("buyer_contactor", this.BuyerContactor);
            parameters.Add("buyer_phone", this.BuyerPhone);
            parameters.Add("contact_express_mode", this.ContactExpressMode);
            parameters.Add("options", this.Options);
            parameters.Add("order_code", this.OrderCode);
            parameters.Add("outer_ids", this.OuterIds);
            parameters.Add("plan_count", this.PlanCount);
            parameters.Add("remarks", this.Remarks);
            parameters.Add("return_reason", this.ReturnReason);
            parameters.Add("return_reason_code", this.ReturnReasonCode);
            parameters.Add("seller_contactor", this.SellerContactor);
            parameters.Add("seller_phone", this.SellerPhone);
            parameters.Add("seller_store_id", this.SellerStoreId);
            parameters.Add("taobao_trade_id", this.TaobaoTradeId);
            parameters.Add("transport_name", this.TransportName);
            parameters.Add("transport_no", this.TransportNo);
            return parameters;
        }

        #endregion
    }
}
