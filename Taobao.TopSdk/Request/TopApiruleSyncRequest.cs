using System;
using System.Collections.Generic;
using Top.Api.Response;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.top.apirule.sync
    /// </summary>
    public class TopApiruleSyncRequest : ITopRequest<TopApiruleSyncResponse>
    {
        /// <summary>
        /// 已发布的api名称。
        /// </summary>
        public string ApiName { get; set; }

        #region ITopRequest Members

        public string GetApiName()
        {
            return "taobao.top.apirule.sync";
        }

        public IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("api_name", this.ApiName);
            return parameters;
        }

        #endregion
    }
}
