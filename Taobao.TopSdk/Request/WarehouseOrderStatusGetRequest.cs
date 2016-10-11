using System;
using System.Collections.Generic;
using Top.Api.Response;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.warehouse.order.status.get
    /// </summary>
    public class WarehouseOrderStatusGetRequest : ITopRequest<WarehouseOrderStatusGetResponse>
    {
        /// <summary>
        /// 物流订单号
        /// </summary>
        public string OrderCode { get; set; }

        #region ITopRequest Members

        public string GetApiName()
        {
            return "taobao.warehouse.order.status.get";
        }

        public IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("order_code", this.OrderCode);
            return parameters;
        }

        #endregion
    }
}
