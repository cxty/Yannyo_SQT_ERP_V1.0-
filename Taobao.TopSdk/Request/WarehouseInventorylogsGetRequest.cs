using System;
using System.Collections.Generic;
using Top.Api.Response;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.warehouse.inventorylogs.get
    /// </summary>
    public class WarehouseInventorylogsGetRequest : ITopRequest<WarehouseInventorylogsGetResponse>
    {
        /// <summary>
        /// 库存记录id,可从taobao.warehouse.inventories.get获
        /// </summary>
        public Nullable<long> InventoryId { get; set; }

        /// <summary>
        /// 库存变更状态,可选值: UNCONFIRMED(待确认) ,CONFIRMED(已确认)
        /// </summary>
        public string Status { get; set; }

        #region ITopRequest Members

        public string GetApiName()
        {
            return "taobao.warehouse.inventorylogs.get";
        }

        public IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("inventory_id", this.InventoryId);
            parameters.Add("status", this.Status);
            return parameters;
        }

        #endregion
    }
}
