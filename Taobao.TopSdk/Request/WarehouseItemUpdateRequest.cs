using System;
using System.Collections.Generic;
using Top.Api.Response;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.warehouse.item.update
    /// </summary>
    public class WarehouseItemUpdateRequest : ITopRequest<WarehouseItemUpdateResponse>
    {
        /// <summary>
        /// 商品Id.可从taobao.warehouse.items.get处获得
        /// </summary>
        public Nullable<long> ItemId { get; set; }

        /// <summary>
        /// 商品名称，不能超过256字符,一个汉字算两个字符
        /// </summary>
        public string ItemName { get; set; }

        /// <summary>
        /// 自定义属性。不能超过256字符，一个汉字算两个字符
        /// </summary>
        public string Memo { get; set; }

        /// <summary>
        /// 该字段已作废。商家编码。和卖家发布商品的商家编码保持一致。商家编码必须唯一，且不能超过64字符，一个汉字算两个字符
        /// </summary>
        public string OuterId { get; set; }

        #region ITopRequest Members

        public string GetApiName()
        {
            return "taobao.warehouse.item.update";
        }

        public IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("item_id", this.ItemId);
            parameters.Add("item_name", this.ItemName);
            parameters.Add("memo", this.Memo);
            parameters.Add("outer_id", this.OuterId);
            return parameters;
        }

        #endregion
    }
}
