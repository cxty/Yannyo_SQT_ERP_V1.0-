using System;
using System.Collections.Generic;
using Top.Api.Response;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.wlb.wlborder.get
    /// </summary>
    public class WlbWlborderGetRequest : ITopRequest<WlbWlborderGetResponse>
    {
        /// <summary>
        /// 物流宝订单编码
        /// </summary>
        public string WlbOrderCode { get; set; }

        #region ITopRequest Members

        public string GetApiName()
        {
            return "taobao.wlb.wlborder.get";
        }

        public IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("wlb_order_code", this.WlbOrderCode);
            return parameters;
        }

        #endregion
    }
}
