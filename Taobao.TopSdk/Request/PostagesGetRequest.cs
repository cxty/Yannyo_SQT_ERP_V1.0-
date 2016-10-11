using System;
using System.Collections.Generic;
using Top.Api.Response;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.postages.get
    /// </summary>
    public class PostagesGetRequest : ITopRequest<PostagesGetResponse>
    {
        /// <summary>
        /// 需返回的字段列表.可选值:Postage结构体中的所有字段;字段之间用","分隔.
        /// </summary>
        public string Fields { get; set; }

        #region ITopRequest Members

        public string GetApiName()
        {
            return "taobao.postages.get";
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
