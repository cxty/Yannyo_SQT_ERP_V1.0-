using System;
using System.Collections.Generic;
using Top.Api.Response;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.wlb.item.combination.create
    /// </summary>
    public class WlbItemCombinationCreateRequest : ITopRequest<WlbItemCombinationCreateResponse>
    {
        /// <summary>
        /// 组合商品的id列表
        /// </summary>
        public string DestItemList { get; set; }

        /// <summary>
        /// 要建立组合关系的商品id
        /// </summary>
        public Nullable<long> ItemId { get; set; }

        /// <summary>
        /// 组成组合商品的比例列表，描述组合商品的组合比例，默认为1,1,1
        /// </summary>
        public string ProportionList { get; set; }

        #region ITopRequest Members

        public string GetApiName()
        {
            return "taobao.wlb.item.combination.create";
        }

        public IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("dest_item_list", this.DestItemList);
            parameters.Add("item_id", this.ItemId);
            parameters.Add("proportion_list", this.ProportionList);
            return parameters;
        }

        #endregion
    }
}
