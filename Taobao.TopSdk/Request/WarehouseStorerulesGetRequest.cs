using System;
using System.Collections.Generic;
using Top.Api.Response;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.warehouse.storerules.get
    /// </summary>
    public class WarehouseStorerulesGetRequest : ITopRequest<WarehouseStorerulesGetResponse>
    {
        #region ITopRequest Members

        public string GetApiName()
        {
            return "taobao.warehouse.storerules.get";
        }

        public IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            return parameters;
        }

        #endregion
    }
}
