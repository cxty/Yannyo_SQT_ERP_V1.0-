using System;
using System.Collections.Generic;
using Top.Api.Response;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.warehouse.inventorylog.get
    /// </summary>
    public class WarehouseInventorylogGetRequest : ITopRequest<WarehouseInventorylogGetResponse>
    {
        /// <summary>
        /// 库存变更id,可以根据taobao.warehouse.inventorylogs.get接口得到
        /// </summary>
        public string InventoryLogId { get; set; }

        #region ITopRequest Members

        public string GetApiName()
        {
            return "taobao.warehouse.inventorylog.get";
        }

        public IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("inventory_log_id", this.InventoryLogId);
            return parameters;
        }

        #endregion
    }
}
