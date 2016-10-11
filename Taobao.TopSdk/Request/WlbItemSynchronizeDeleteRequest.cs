using System;
using System.Collections.Generic;
using Top.Api.Response;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.wlb.item.synchronize.delete
    /// </summary>
    public class WlbItemSynchronizeDeleteRequest : ITopRequest<WlbItemSynchronizeDeleteResponse>
    {
        /// <summary>
        /// 外部实体ID
        /// </summary>
        public Nullable<long> ExtEntityId { get; set; }

        /// <summary>
        /// 外部实体类型.存如下值 IC_ITEM --表示IC商品; IC_SKU --表示IC最小单位商品;若输入其他值，则按IC_ITEM处理
        /// </summary>
        public string ExtEntityType { get; set; }

        /// <summary>
        /// 物流宝商品ID
        /// </summary>
        public Nullable<long> ItemId { get; set; }

        #region ITopRequest Members

        public string GetApiName()
        {
            return "taobao.wlb.item.synchronize.delete";
        }

        public IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("ext_entity_id", this.ExtEntityId);
            parameters.Add("ext_entity_type", this.ExtEntityType);
            parameters.Add("item_id", this.ItemId);
            return parameters;
        }

        #endregion
    }
}
