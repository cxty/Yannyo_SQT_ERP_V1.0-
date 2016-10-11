using System;
using System.Collections.Generic;
using Top.Api.Response;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.wlb.item.combination.get
    /// </summary>
    public class WlbItemCombinationGetRequest : ITopRequest<WlbItemCombinationGetResponse>
    {
        /// <summary>
        /// 要查询的组合商品id
        /// </summary>
        public Nullable<long> ItemId { get; set; }

        #region ITopRequest Members

        public string GetApiName()
        {
            return "taobao.wlb.item.combination.get";
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
