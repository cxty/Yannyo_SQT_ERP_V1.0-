using System;
using System.Collections.Generic;
using Top.Api.Response;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.itemcats.authorize.get
    /// </summary>
    public class ItemcatsAuthorizeGetRequest : ITopRequest<ItemcatsAuthorizeGetResponse>
    {
        /// <summary>
        /// 需要返回的字段。目前支持有：  brand.vid, brand.name,   item_cat.cid, item_cat.name, item_cat.status,item_cat.sort_order,item_cat.parent_cid,item_cat.is_parent
        /// </summary>
        public string Fields { get; set; }

        #region ITopRequest Members

        public string GetApiName()
        {
            return "taobao.itemcats.authorize.get";
        }

        public IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("fields", this.Fields);
            return parameters;
        }

        #endregion
    }
}
