using System;
using System.Collections.Generic;
using Top.Api.Response;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.wlb.item.combination.delete
    /// </summary>
    public class WlbItemCombinationDeleteRequest : ITopRequest<WlbItemCombinationDeleteResponse>
    {
        /// <summary>
        /// 组合商品的id列表
        /// </summary>
        public string DestItemList { get; set; }

        /// <summary>
        /// 组合关系的商品id
        /// </summary>
        public Nullable<long> ItemId { get; set; }

        #region ITopRequest Members

        public string GetApiName()
        {
            return "taobao.wlb.item.combination.delete";
        }

        public IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("dest_item_list", this.DestItemList);
            parameters.Add("item_id", this.ItemId);
            return parameters;
        }

        #endregion
    }
}
