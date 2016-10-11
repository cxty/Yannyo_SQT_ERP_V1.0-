using System;
using System.Collections.Generic;
using Top.Api.Response;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.trade.receivetime.delay
    /// </summary>
    public class TradeReceivetimeDelayRequest : ITopRequest<TradeReceivetimeDelayResponse>
    {
        /// <summary>
        /// 延长收货的天数，可选值为：3, 5, 7, 10。
        /// </summary>
        public Nullable<long> Days { get; set; }

        /// <summary>
        /// 主订单号
        /// </summary>
        public Nullable<long> Tid { get; set; }

        #region ITopRequest Members

        public string GetApiName()
        {
            return "taobao.trade.receivetime.delay";
        }

        public IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("days", this.Days);
            parameters.Add("tid", this.Tid);
            return parameters;
        }

        #endregion
    }
}
