using System;
using System.Collections.Generic;
using Top.Api.Response;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.warehouse.inventory.warnline.update
    /// </summary>
    public class WarehouseInventoryWarnlineUpdateRequest : ITopRequest<WarehouseInventoryWarnlineUpdateResponse>
    {
        /// <summary>
        /// 库存id列表，形式如"111,222,333,444"的库存id列表，可以根据taobao.warehouse.inventories.get接口得到,每个id必须为数值型
        /// </summary>
        public string InventoryIds { get; set; }

        /// <summary>
        /// 库存警戒值列表,形式如"11，22，33，44"的警戒值列表，每个id必须为数值型
        /// </summary>
        public string WarnValues { get; set; }

        #region ITopRequest Members

        public string GetApiName()
        {
            return "taobao.warehouse.inventory.warnline.update";
        }

        public IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("inventory_ids", this.InventoryIds);
            parameters.Add("warn_values", this.WarnValues);
            return parameters;
        }

        #endregion
    }
}
