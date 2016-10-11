using System;
using System.Collections.Generic;
using Top.Api.Response;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.warehouse.extstores.get
    /// </summary>
    public class WarehouseExtstoresGetRequest : ITopRequest<WarehouseExtstoresGetResponse>
    {
        #region ITopRequest Members

        public string GetApiName()
        {
            return "taobao.warehouse.extstores.get";
        }

        public IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            return parameters;
        }

        #endregion
    }
}
