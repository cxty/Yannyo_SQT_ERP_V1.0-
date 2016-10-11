using System;
using System.Collections.Generic;
using Top.Api.Response;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.huabao.channels.get
    /// </summary>
    public class HuabaoChannelsGetRequest : ITopRequest<HuabaoChannelsGetResponse>
    {
        #region ITopRequest Members

        public string GetApiName()
        {
            return "taobao.huabao.channels.get";
        }

        public IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            return parameters;
        }

        #endregion
    }
}
