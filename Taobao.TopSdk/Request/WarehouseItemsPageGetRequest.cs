using System;
using System.Collections.Generic;
using Top.Api.Response;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.warehouse.items.page.get
    /// </summary>
    public class WarehouseItemsPageGetRequest : ITopRequest<WarehouseItemsPageGetResponse>
    {
        /// <summary>
        /// 商品名称。可从taobao.warehouse.items.get处获得
        /// </summary>
        public string ItemName { get; set; }

        /// <summary>
        /// 商家编码。可从taobao.warehouse.items.get处获得
        /// </summary>
        public string OuterId { get; set; }

        /// <summary>
        /// 当前页，默认为1，最大页数取决于用户拥有的商品数和一页显示的记录数
        /// </summary>
        public string PageNo { get; set; }

        /// <summary>
        /// 一页显示记录数，默认为20。最多为50，如果用户输入的记录数大于50，则按默认一页显示50条记录
        /// </summary>
        public string PageSize { get; set; }

        #region ITopRequest Members

        public string GetApiName()
        {
            return "taobao.warehouse.items.page.get";
        }

        public IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("item_name", this.ItemName);
            parameters.Add("outer_id", this.OuterId);
            parameters.Add("page_no", this.PageNo);
            parameters.Add("page_size", this.PageSize);
            return parameters;
        }

        #endregion
    }
}
