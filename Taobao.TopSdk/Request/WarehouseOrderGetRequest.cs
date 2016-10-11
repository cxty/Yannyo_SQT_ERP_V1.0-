using System;
using System.Collections.Generic;
using Top.Api.Response;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.warehouse.order.get
    /// </summary>
    public class WarehouseOrderGetRequest : ITopRequest<WarehouseOrderGetResponse>
    {
        /// <summary>
        /// 物流订单ID
        /// </summary>
        public Nullable<long> OrderId { get; set; }

        #region ITopRequest Members

        public string GetApiName()
        {
            return "taobao.warehouse.order.get";
        }

        public IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("order_id", this.OrderId);
            return parameters;
        }

        #endregion
    }
}
