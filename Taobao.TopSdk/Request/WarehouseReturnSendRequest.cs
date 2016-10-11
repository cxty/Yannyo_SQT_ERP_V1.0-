using System;
using System.Collections.Generic;
using Top.Api.Response;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.warehouse.return.send
    /// </summary>
    public class WarehouseReturnSendRequest : ITopRequest<WarehouseReturnSendResponse>
    {
        /// <summary>
        /// 退货单号
        /// </summary>
        public string CrkCode { get; set; }

        #region ITopRequest Members

        public string GetApiName()
        {
            return "taobao.warehouse.return.send";
        }

        public IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("crk_code", this.CrkCode);
            return parameters;
        }

        #endregion
    }
}
