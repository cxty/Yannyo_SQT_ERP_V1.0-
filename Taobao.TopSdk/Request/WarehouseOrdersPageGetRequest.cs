using System;
using System.Collections.Generic;
using Top.Api.Response;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.warehouse.orders.page.get
    /// </summary>
    public class WarehouseOrdersPageGetRequest : ITopRequest<WarehouseOrdersPageGetResponse>
    {
        /// <summary>
        /// 物流公司ID
        /// </summary>
        public Nullable<long> CompanyId { get; set; }

        /// <summary>
        /// 订单创建结束时间
        /// </summary>
        public Nullable<DateTime> GmtcreateEnd { get; set; }

        /// <summary>
        /// 订单创建开始时间
        /// </summary>
        public Nullable<DateTime> GmtcreateStart { get; set; }

        /// <summary>
        /// 物流订单状态TO_BE_SENT（待处理）SIGN_IN（已签收）REJECTED_BY_OTHER_SIDE(签收失败)
        /// </summary>
        public string OrderStatus { get; set; }

        /// <summary>
        /// 运单号
        /// </summary>
        public string OutSid { get; set; }

        /// <summary>
        /// 当前页 (默认为1)
        /// </summary>
        public Nullable<long> PageNo { get; set; }

        /// <summary>
        /// 分页参数,每页所包含的记录条数,正整数，默认20，最大50超过50默认50
        /// </summary>
        public Nullable<long> PageSize { get; set; }

        /// <summary>
        /// 收货人名字
        /// </summary>
        public string ReceiverName { get; set; }

        /// <summary>
        /// 自定义仓库ID
        /// </summary>
        public string SellerStoreId { get; set; }

        /// <summary>
        /// 淘宝交易号
        /// </summary>
        public Nullable<long> Tid { get; set; }

        #region ITopRequest Members

        public string GetApiName()
        {
            return "taobao.warehouse.orders.page.get";
        }

        public IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("company_id", this.CompanyId);
            parameters.Add("gmtcreate_end", this.GmtcreateEnd);
            parameters.Add("gmtcreate_start", this.GmtcreateStart);
            parameters.Add("order_status", this.OrderStatus);
            parameters.Add("out_sid", this.OutSid);
            parameters.Add("page_no", this.PageNo);
            parameters.Add("page_size", this.PageSize);
            parameters.Add("receiver_name", this.ReceiverName);
            parameters.Add("seller_store_id", this.SellerStoreId);
            parameters.Add("tid", this.Tid);
            return parameters;
        }

        #endregion
    }
}
