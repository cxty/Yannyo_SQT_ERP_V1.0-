using System;
using System.Collections.Generic;
using Top.Api.Response;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.wlb.item.consignment.page.get
    /// </summary>
    public class WlbItemConsignmentPageGetRequest : ITopRequest<WlbItemConsignmentPageGetResponse>
    {
        /// <summary>
        /// 代销商商品id
        /// </summary>
        public Nullable<long> ItemId { get; set; }

        /// <summary>
        /// 供应商商品id
        /// </summary>
        public Nullable<long> TgtItemId { get; set; }

        /// <summary>
        /// 供应商用户id
        /// </summary>
        public Nullable<long> TgtUserId { get; set; }

        #region ITopRequest Members

        public string GetApiName()
        {
            return "taobao.wlb.item.consignment.page.get";
        }

        public IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("item_id", this.ItemId);
            parameters.Add("tgt_item_id", this.TgtItemId);
            parameters.Add("tgt_user_id", this.TgtUserId);
            return parameters;
        }

        #endregion
    }
}
