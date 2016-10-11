using System;
using System.Collections.Generic;
using Top.Api.Response;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.huabao.poster.get
    /// </summary>
    public class HuabaoPosterGetRequest : ITopRequest<HuabaoPosterGetResponse>
    {
        /// <summary>
        /// 画报的Id值
        /// </summary>
        public Nullable<long> PosterId { get; set; }

        #region ITopRequest Members

        public string GetApiName()
        {
            return "taobao.huabao.poster.get";
        }

        public IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("poster_id", this.PosterId);
            return parameters;
        }

        #endregion
    }
}
