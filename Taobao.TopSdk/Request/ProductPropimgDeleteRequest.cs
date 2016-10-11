using System;
using System.Collections.Generic;
using Top.Api.Response;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.product.propimg.delete
    /// </summary>
    public class ProductPropimgDeleteRequest : ITopRequest<ProductPropimgDeleteResponse>
    {
        /// <summary>
        /// 属性图片ID
        /// </summary>
        public Nullable<long> Id { get; set; }

        /// <summary>
        /// 产品ID.Product的id.
        /// </summary>
        public Nullable<long> ProductId { get; set; }

        #region ITopRequest Members

        public string GetApiName()
        {
            return "taobao.product.propimg.delete";
        }

        public IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("id", this.Id);
            parameters.Add("product_id", this.ProductId);
            return parameters;
        }

        #endregion
    }
}
