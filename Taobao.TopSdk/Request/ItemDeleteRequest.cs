using System;
using System.Collections.Generic;
using Top.Api.Response;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.item.delete
    /// </summary>
    public class ItemDeleteRequest : ITopRequest<ItemDeleteResponse>
    {
        /// <summary>
        /// 商品数字ID，该参数必须
        /// </summary>
        public Nullable<long> NumIid { get; set; }

        #region ITopRequest Members

        public string GetApiName()
        {
            return "taobao.item.delete";
        }

        public IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("num_iid", this.NumIid);
            return parameters;
        }

        #endregion
    }
}
