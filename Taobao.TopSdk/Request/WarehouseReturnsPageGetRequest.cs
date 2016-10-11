using System;
using System.Collections.Generic;
using Top.Api.Response;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.warehouse.returns.page.get
    /// </summary>
    public class WarehouseReturnsPageGetRequest : ITopRequest<WarehouseReturnsPageGetResponse>
    {
        /// <summary>
        /// 退货单号
        /// </summary>
        public string CrkCode { get; set; }

        /// <summary>
        /// 原物流订单号
        /// </summary>
        public string OrderCode { get; set; }

        /// <summary>
        /// 当前页(默认为1)
        /// </summary>
        public Nullable<long> PageNo { get; set; }

        /// <summary>
        /// 分页参数,每页所包含的记录条数,正整数，默认20，最大50,超过50默认50.
        /// </summary>
        public Nullable<long> PageSize { get; set; }

        /// <summary>
        /// 结束退货时间,查出当前时间之前的所有记录数
        /// </summary>
        public Nullable<DateTime> ReturnDateEnd { get; set; }

        /// <summary>
        /// 起始退货时间，查出从当前时间起的所有记录
        /// </summary>
        public Nullable<DateTime> ReturnDateStart { get; set; }

        /// <summary>
        /// 配送中心
        /// </summary>
        public Nullable<long> SellerStoreId { get; set; }

        /// <summary>
        /// 原订单编号
        /// </summary>
        public Nullable<long> TaobaoTradeId { get; set; }

        #region ITopRequest Members

        public string GetApiName()
        {
            return "taobao.warehouse.returns.page.get";
        }

        public IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("crk_code", this.CrkCode);
            parameters.Add("order_code", this.OrderCode);
            parameters.Add("page_no", this.PageNo);
            parameters.Add("page_size", this.PageSize);
            parameters.Add("return_date_end", this.ReturnDateEnd);
            parameters.Add("return_date_start", this.ReturnDateStart);
            parameters.Add("seller_store_id", this.SellerStoreId);
            parameters.Add("taobao_trade_id", this.TaobaoTradeId);
            return parameters;
        }

        #endregion
    }
}
