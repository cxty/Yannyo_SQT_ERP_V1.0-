using System;
using System.Collections.Generic;
using Top.Api.Response;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.taohua.boughtitem.is
    /// </summary>
    public class TaohuaBoughtitemIsRequest : ITopRequest<TaohuaBoughtitemIsResponse>
    {
        /// <summary>
        /// 商品ID
        /// </summary>
        public Nullable<long> ItemId { get; set; }

        #region ITopRequest Members

        public string GetApiName()
        {
            return "taobao.taohua.boughtitem.is";
        }

        public IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("item_id", this.ItemId);
            return parameters;
        }

        #endregion
    }
}
