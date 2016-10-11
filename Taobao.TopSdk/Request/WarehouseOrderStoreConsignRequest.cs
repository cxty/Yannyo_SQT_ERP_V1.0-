using System;
using System.Collections.Generic;
using Top.Api.Response;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.warehouse.order.storeConsign
    /// </summary>
    public class WarehouseOrderStoreConsignRequest : ITopRequest<WarehouseOrderStoreConsignResponse>
    {
        /// <summary>
        /// 此字段为物流订单编号。订单id、淘宝交易号、物流订单编号这三个至少有个一不为空。优先级为 淘宝交易号 > 物流订单编号 > 订单id。(若淘宝交易号不为空，则就用淘宝交易号来查,其他两个字段忽略;若淘宝交易号为空，物流订单编号不为空，则用物流订单编号来查，订单id字段忽略;若淘宝交易号和物流订单编号都为空，订单id不为空，则用订单id来查;三者都为空返回错误信息。)
        /// </summary>
        public string OrderCode { get; set; }

        /// <summary>
        /// 此字段为订单id。  订单id、淘宝交易号、物流订单编号这三个至少有个一不为空。优先级为 淘宝交易号 > 物流订单编号 > 订单id。(若淘宝交易号不为空，则就用淘宝交易号来查,其他两个字段忽略;若淘宝交易号为空，物流订单编号不为空，则用物流订单编号来查，订单id字段忽略;若淘宝交易号和物流订单编号都为空，订单id不为空，则用订单id来查;三者都为空返回错误信息。)
        /// </summary>
        public string OrderId { get; set; }

        /// <summary>
        /// 发货仓储id可以从接口taobao.warehouse.sellerstores.get中得到
        /// </summary>
        public string SellerStoreId { get; set; }

        /// <summary>
        /// 此字段为淘宝交易号。订单id、淘宝交易号、物流订单编号这三个至少有个一不为空。优先级为 淘宝交易号 > 物流订单编号 > 订单id。(若淘宝交易号不为空，则就用淘宝交易号来查,其他两个字段忽略;若淘宝交易号为空，物流订单编号不为空，则用物流订单编号来查，订单id字段忽略;若淘宝交易号和物流订单编号都为空，订单id不为空，则用订单id来查;三者都为空返回错误信息。)
        /// </summary>
        public Nullable<long> Tid { get; set; }

        #region ITopRequest Members

        public string GetApiName()
        {
            return "taobao.warehouse.order.storeConsign";
        }

        public IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("order_code", this.OrderCode);
            parameters.Add("order_id", this.OrderId);
            parameters.Add("seller_store_id", this.SellerStoreId);
            parameters.Add("tid", this.Tid);
            return parameters;
        }

        #endregion
    }
}
