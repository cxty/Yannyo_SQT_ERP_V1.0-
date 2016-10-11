using System;
using System.Collections.Generic;
using Top.Api.Response;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.warehouse.items.get
    /// </summary>
    public class WarehouseItemsGetRequest : ITopRequest<WarehouseItemsGetResponse>
    {
        #region ITopRequest Members

        public string GetApiName()
        {
            return "taobao.warehouse.items.get";
        }

        public IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            return parameters;
        }

        #endregion
    }
}
