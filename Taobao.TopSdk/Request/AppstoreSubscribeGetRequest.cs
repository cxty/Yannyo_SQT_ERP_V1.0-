using System;
using System.Collections.Generic;
using Top.Api.Response;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.appstore.subscribe.get
    /// </summary>
    public class AppstoreSubscribeGetRequest : ITopRequest<AppstoreSubscribeGetResponse>
    {
        /// <summary>
        /// 插件实例ID
        /// </summary>
        public Nullable<long> LeaseId { get; set; }

        /// <summary>
        /// 用户昵称
        /// </summary>
        public string Nick { get; set; }

        #region ITopRequest Members

        public string GetApiName()
        {
            return "taobao.appstore.subscribe.get";
        }

        public IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("lease_id", this.LeaseId);
            parameters.Add("nick", this.Nick);
            return parameters;
        }

        #endregion
    }
}
