using System;
using System.Collections.Generic;
using Top.Api.Response;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.warehouse.item.add
    /// </summary>
    public class WarehouseItemAddRequest : ITopRequest<WarehouseItemAddResponse>
    {
        /// <summary>
        /// 商品名称。最大长度为256字符，一个汉字算两个字符
        /// </summary>
        public string ItemName { get; set; }

        /// <summary>
        /// 自定义属性。最大长度为256字符，一个汉字算两个字符
        /// </summary>
        public string Memo { get; set; }

        /// <summary>
        /// 商家编码。商家编码唯一，最大长度为64个字符
        /// </summary>
        public string OuterId { get; set; }

        #region ITopRequest Members

        public string GetApiName()
        {
            return "taobao.warehouse.item.add";
        }

        public IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("item_name", this.ItemName);
            parameters.Add("memo", this.Memo);
            parameters.Add("outer_id", this.OuterId);
            return parameters;
        }

        #endregion
    }
}
