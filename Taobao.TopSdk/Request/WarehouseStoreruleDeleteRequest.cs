using System;
using System.Collections.Generic;
using Top.Api.Response;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.warehouse.storerule.delete
    /// </summary>
    public class WarehouseStoreruleDeleteRequest : ITopRequest<WarehouseStoreruleDeleteResponse>
    {
        /// <summary>
        /// 发货规则id
        /// </summary>
        public string Id { get; set; }

        #region ITopRequest Members

        public string GetApiName()
        {
            return "taobao.warehouse.storerule.delete";
        }

        public IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("id", this.Id);
            return parameters;
        }

        #endregion
    }
}
