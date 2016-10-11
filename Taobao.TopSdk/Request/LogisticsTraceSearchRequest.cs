using System;
using System.Collections.Generic;
using Top.Api.Response;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.logistics.trace.search
    /// </summary>
    public class LogisticsTraceSearchRequest : ITopRequest<LogisticsTraceSearchResponse>
    {
        /// <summary>
        /// 卖家昵称
        /// </summary>
        public string SellerNick { get; set; }

        /// <summary>
        /// 交易号
        /// </summary>
        public Nullable<long> Tid { get; set; }

        #region ITopRequest Members

        public string GetApiName()
        {
            return "taobao.logistics.trace.search";
        }

        public IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("seller_nick", this.SellerNick);
            parameters.Add("tid", this.Tid);
            return parameters;
        }

        #endregion
    }
}
