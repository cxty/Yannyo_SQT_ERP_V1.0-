using System;
using System.Collections.Generic;
using Top.Api.Response;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.warehouse.inventorylogs.page.get
    /// </summary>
    public class WarehouseInventorylogsPageGetRequest : ITopRequest<WarehouseInventorylogsPageGetResponse>
    {
        /// <summary>
        /// 查询结束时间
        /// </summary>
        public Nullable<DateTime> GmtcreateEnd { get; set; }

        /// <summary>
        /// 查询开始时间
        /// </summary>
        public Nullable<DateTime> GmtcreateStart { get; set; }

        /// <summary>
        /// 分页参数,当前页码,默认为1
        /// </summary>
        public string PageNo { get; set; }

        /// <summary>
        /// 分页参数,每页所包含的记录条数,正整数，默认20，最大50超过50默认50
        /// </summary>
        public string PageSize { get; set; }

        /// <summary>
        /// 库存变更状态PUT_IN_STOCK(入库),STOCK_TRANSFER(出库) ，STOCKTAKING（盘点）,SELL（正常销售）
        /// </summary>
        public string Reason { get; set; }

        /// <summary>
        /// 自定义仓库id 可以根据taobao.warehouse.sellerstores.get接口得到
        /// </summary>
        public string SellerStoreId { get; set; }

        /// <summary>
        /// 库存变更状态UNCONFIRMED(待确认),CONFIRMED(已确认)
        /// </summary>
        public string Status { get; set; }

        #region ITopRequest Members

        public string GetApiName()
        {
            return "taobao.warehouse.inventorylogs.page.get";
        }

        public IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("gmtcreate_end", this.GmtcreateEnd);
            parameters.Add("gmtcreate_start", this.GmtcreateStart);
            parameters.Add("page_no", this.PageNo);
            parameters.Add("page_size", this.PageSize);
            parameters.Add("reason", this.Reason);
            parameters.Add("seller_store_id", this.SellerStoreId);
            parameters.Add("status", this.Status);
            return parameters;
        }

        #endregion
    }
}
