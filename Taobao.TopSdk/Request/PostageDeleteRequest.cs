using System;
using System.Collections.Generic;
using Top.Api.Response;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.postage.delete
    /// </summary>
    public class PostageDeleteRequest : ITopRequest<PostageDeleteResponse>
    {
        /// <summary>
        /// 邮费模板id
        /// </summary>
        public Nullable<long> PostageId { get; set; }

        #region ITopRequest Members

        public string GetApiName()
        {
            return "taobao.postage.delete";
        }

        public IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("postage_id", this.PostageId);
            return parameters;
        }

        #endregion
    }
}
