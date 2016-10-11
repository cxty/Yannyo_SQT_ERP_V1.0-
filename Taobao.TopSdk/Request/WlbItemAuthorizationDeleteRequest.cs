using System;
using System.Collections.Generic;
using Top.Api.Response;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.wlb.item.authorization.delete
    /// </summary>
    public class WlbItemAuthorizationDeleteRequest : ITopRequest<WlbItemAuthorizationDeleteResponse>
    {
        /// <summary>
        /// 授权关系ID
        /// </summary>
        public Nullable<long> AuthorizeId { get; set; }

        #region ITopRequest Members

        public string GetApiName()
        {
            return "taobao.wlb.item.authorization.delete";
        }

        public IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("authorize_id", this.AuthorizeId);
            return parameters;
        }

        #endregion
    }
}
