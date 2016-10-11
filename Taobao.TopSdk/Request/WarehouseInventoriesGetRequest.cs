using System;
using System.Collections.Generic;
using Top.Api.Response;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.warehouse.inventories.get
    /// </summary>
    public class WarehouseInventoriesGetRequest : ITopRequest<WarehouseInventoriesGetResponse>
    {
        /// <summary>
        /// 商品ID(可从taobao.warehouse.items.get取
        /// </summary>
        public Nullable<long> ItemId { get; set; }

        #region ITopRequest Members

        public string GetApiName()
        {
            return "taobao.warehouse.inventories.get";
        }

        public IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("item_id", this.ItemId);
            return parameters;
        }

        #endregion
    }
}
