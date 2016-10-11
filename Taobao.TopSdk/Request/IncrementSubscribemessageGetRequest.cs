using System;
using System.Collections.Generic;
using Top.Api.Response;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.increment.subscribemessage.get
    /// </summary>
    public class IncrementSubscribemessageGetRequest : ITopRequest<IncrementSubscribemessageGetResponse>
    {
        /// <summary>
        /// 需要返回的字段。具体字段间SubscribeMessage说明
        /// </summary>
        public string Fields { get; set; }

        #region ITopRequest Members

        public string GetApiName()
        {
            return "taobao.increment.subscribemessage.get";
        }

        public IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("fields", this.Fields);
            return parameters;
        }

        #endregion
    }
}
