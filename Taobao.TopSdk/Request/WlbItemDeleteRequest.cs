using System;
using System.Collections.Generic;
using Top.Api.Response;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.wlb.item.delete
    /// </summary>
    public class WlbItemDeleteRequest : ITopRequest<WlbItemDeleteResponse>
    {
        /// <summary>
        /// 商品ID
        /// </summary>
        public Nullable<long> ItemId { get; set; }

        /// <summary>
        /// 商品所有人淘宝nick
        /// </summary>
        public string UserNick { get; set; }

        #region ITopRequest Members

        public string GetApiName()
        {
            return "taobao.wlb.item.delete";
        }

        public IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("item_id", this.ItemId);
            parameters.Add("user_nick", this.UserNick);
            return parameters;
        }

        #endregion
    }
}
