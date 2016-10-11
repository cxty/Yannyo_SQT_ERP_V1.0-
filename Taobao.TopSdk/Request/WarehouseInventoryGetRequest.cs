using System;
using System.Collections.Generic;
using Top.Api.Response;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.warehouse.inventory.get
    /// </summary>
    public class WarehouseInventoryGetRequest : ITopRequest<WarehouseInventoryGetResponse>
    {
        /// <summary>
        /// 库存ID (可从taobao.warehouse.inventories.get取)
        /// </summary>
        public Nullable<long> InventoryId { get; set; }

        #region ITopRequest Members

        public string GetApiName()
        {
            return "taobao.warehouse.inventory.get";
        }

        public IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("inventory_id", this.InventoryId);
            return parameters;
        }

        #endregion
    }
}
