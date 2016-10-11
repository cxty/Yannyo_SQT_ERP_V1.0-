using System;
using System.Collections.Generic;
using Top.Api.Response;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.postage.get
    /// </summary>
    public class PostageGetRequest : ITopRequest<PostageGetResponse>
    {
        /// <summary>
        /// 需返回的字段列表.可选值:Postage结构体中的所有字段;字段之间用","隔开
        /// </summary>
        public string Fields { get; set; }

        /// <summary>
        /// 卖家昵称
        /// </summary>
        public string Nick { get; set; }

        /// <summary>
        /// 邮费模板id
        /// </summary>
        public Nullable<long> PostageId { get; set; }

        #region ITopRequest Members

        public string GetApiName()
        {
            return "taobao.postage.get";
        }

        public IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("fields", this.Fields);
            parameters.Add("nick", this.Nick);
            parameters.Add("postage_id", this.PostageId);
            return parameters;
        }

        #endregion
    }
}
