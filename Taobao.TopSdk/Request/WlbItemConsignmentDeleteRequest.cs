using System;
using System.Collections.Generic;
using Top.Api.Response;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.wlb.item.consignment.delete
    /// </summary>
    public class WlbItemConsignmentDeleteRequest : ITopRequest<WlbItemConsignmentDeleteResponse>
    {
        /// <summary>
        /// 商品id
        /// </summary>
        public Nullable<long> ItemId { get; set; }

        /// <summary>
        /// 货主商品id列表(支持多货主)
        /// </summary>
        public string OwnerItemList { get; set; }

        #region ITopRequest Members

        public string GetApiName()
        {
            return "taobao.wlb.item.consignment.delete";
        }

        public IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("item_id", this.ItemId);
            parameters.Add("owner_item_list", this.OwnerItemList);
            return parameters;
        }

        #endregion
    }
}
