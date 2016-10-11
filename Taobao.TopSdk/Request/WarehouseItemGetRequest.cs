using System;
using System.Collections.Generic;
using Top.Api.Response;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.warehouse.item.get
    /// </summary>
    public class WarehouseItemGetRequest : ITopRequest<WarehouseItemGetResponse>
    {
        /// <summary>
        /// 商品id。可从taobao.warehouse.items.get获得。当type="item_id"时，根据输入的item_id查询，默认为0
        /// </summary>
        public Nullable<long> ItemId { get; set; }

        /// <summary>
        /// 商家编码.和卖家发布商品的商家编码一致,可从taobao.warehouse.items.get获得。当type="outer_id"时,根据输入的outer_id查询，默认为""
        /// </summary>
        public string OuterId { get; set; }

        /// <summary>
        /// 参数类型。必须传入"item_id"（根据商品Id查商品信息）或"outer_id"（根据商家编码查询商品信息）
        /// </summary>
        public string Type { get; set; }

        #region ITopRequest Members

        public string GetApiName()
        {
            return "taobao.warehouse.item.get";
        }

        public IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("item_id", this.ItemId);
            parameters.Add("outer_id", this.OuterId);
            parameters.Add("type", this.Type);
            return parameters;
        }

        #endregion
    }
}
