using System;
using System.Collections.Generic;
using Top.Api.Response;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.logistics.dummy.send
    /// </summary>
    public class LogisticsDummySendRequest : ITopRequest<LogisticsDummySendResponse>
    {
        /// <summary>
        /// 淘宝交易ID
        /// </summary>
        public Nullable<long> Tid { get; set; }

        #region ITopRequest Members

        public string GetApiName()
        {
            return "taobao.logistics.dummy.send";
        }

        public IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("tid", this.Tid);
            return parameters;
        }

        #endregion
    }
}
