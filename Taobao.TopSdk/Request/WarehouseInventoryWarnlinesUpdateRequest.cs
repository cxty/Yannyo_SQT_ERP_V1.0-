using System;
using System.Collections.Generic;
using Top.Api.Response;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.warehouse.inventory.warnlines.update
    /// </summary>
    public class WarehouseInventoryWarnlinesUpdateRequest : ITopRequest<WarehouseInventoryWarnlinesUpdateResponse>
    {
        /// <summary>
        /// 库存警戒值
        /// </summary>
        public Nullable<long> WarnValue { get; set; }

        #region ITopRequest Members

        public string GetApiName()
        {
            return "taobao.warehouse.inventory.warnlines.update";
        }

        public IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("warn_value", this.WarnValue);
            return parameters;
        }

        #endregion
    }
}
