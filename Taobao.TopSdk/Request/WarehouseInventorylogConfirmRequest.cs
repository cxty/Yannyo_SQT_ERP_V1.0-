using System;
using System.Collections.Generic;
using Top.Api.Response;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.warehouse.inventorylog.confirm
    /// </summary>
    public class WarehouseInventorylogConfirmRequest : ITopRequest<WarehouseInventorylogConfirmResponse>
    {
        /// <summary>
        /// 库存变更id，可以根据接口taobao.warehouse.inventorylogs.page.get得到
        /// </summary>
        public string InventoryLogId { get; set; }

        #region ITopRequest Members

        public string GetApiName()
        {
            return "taobao.warehouse.inventorylog.confirm";
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
