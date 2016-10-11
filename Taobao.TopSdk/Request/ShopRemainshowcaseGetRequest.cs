using System;
using System.Collections.Generic;
using Top.Api.Response;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.shop.remainshowcase.get
    /// </summary>
    public class ShopRemainshowcaseGetRequest : ITopRequest<ShopRemainshowcaseGetResponse>
    {
        #region ITopRequest Members

        public string GetApiName()
        {
            return "taobao.shop.remainshowcase.get";
        }

        public IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            return parameters;
        }

        #endregion
    }
}
