using System;
using System.Collections.Generic;
using Top.Api.Response;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.warehouse.sellerstores.get
    /// </summary>
    public class WarehouseSellerstoresGetRequest : ITopRequest<WarehouseSellerstoresGetResponse>
    {
        /// <summary>
        /// 自定义仓库状态，如果不传，则返回所有
        /// </summary>
        public string Status { get; set; }

        #region ITopRequest Members

        public string GetApiName()
        {
            return "taobao.warehouse.sellerstores.get";
        }

        public IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("status", this.Status);
            return parameters;
        }

        #endregion
    }
}
