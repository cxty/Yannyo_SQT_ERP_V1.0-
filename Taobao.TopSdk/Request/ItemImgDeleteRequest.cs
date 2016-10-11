using System;
using System.Collections.Generic;
using Top.Api.Response;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.item.img.delete
    /// </summary>
    public class ItemImgDeleteRequest : ITopRequest<ItemImgDeleteResponse>
    {
        /// <summary>
        /// 商品图片ID
        /// </summary>
        public Nullable<long> Id { get; set; }

        /// <summary>
        /// 商品数字ID，必选
        /// </summary>
        public Nullable<long> NumIid { get; set; }

        #region ITopRequest Members

        public string GetApiName()
        {
            return "taobao.item.img.delete";
        }

        public IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("id", this.Id);
            parameters.Add("num_iid", this.NumIid);
            return parameters;
        }

        #endregion
    }
}
