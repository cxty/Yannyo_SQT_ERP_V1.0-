using System;
using System.Collections.Generic;
using Top.Api.Response;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.wlb.orderstatus.get
    /// </summary>
    public class WlbOrderstatusGetRequest : ITopRequest<WlbOrderstatusGetResponse>
    {
        /// <summary>
        /// 物流宝订单编码
        /// </summary>
        public string OrderCode { get; set; }

        #region ITopRequest Members

        public string GetApiName()
        {
            return "taobao.wlb.orderstatus.get";
        }

        public IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("order_code", this.OrderCode);
            return parameters;
        }

        #endregion
    }
}
