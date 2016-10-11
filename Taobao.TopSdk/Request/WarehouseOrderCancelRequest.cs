using System;
using System.Collections.Generic;
using Top.Api.Response;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.warehouse.order.cancel
    /// </summary>
    public class WarehouseOrderCancelRequest : ITopRequest<WarehouseOrderCancelResponse>
    {
        /// <summary>
        /// 物流订单ID(order_id可以根据接口taobao.warehouse.orders.page.get得到)
        /// </summary>
        public Nullable<long> OrderId { get; set; }

        #region ITopRequest Members

        public string GetApiName()
        {
            return "taobao.warehouse.order.cancel";
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
