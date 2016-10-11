using System;
using System.Collections.Generic;
using Top.Api.Response;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.warehouse.storebill.page.get
    /// </summary>
    public class WarehouseStorebillPageGetRequest : ITopRequest<WarehouseStorebillPageGetResponse>
    {
        /// <summary>
        /// 结束月份,格式为年+月,如:201001
        /// </summary>
        public Nullable<long> MonthEnd { get; set; }

        /// <summary>
        /// 起始月份,格式为年+月,如:200912
        /// </summary>
        public Nullable<long> MonthStart { get; set; }

        /// <summary>
        /// 当前页，正整数,默认为1.
        /// </summary>
        public Nullable<long> PageNo { get; set; }

        /// <summary>
        /// 分页记录个数，正整数,默认为20条,最多为50条，如果用户输入的记录数大于50，则一页显示50条记录
        /// </summary>
        public Nullable<long> PageSize { get; set; }

        /// <summary>
        /// 自定义仓库id,可以从接口taobao.warehouse.sellerstores.get中得到
        /// </summary>
        public Nullable<long> SellerStoreId { get; set; }

        #region ITopRequest Members

        public string GetApiName()
        {
            return "taobao.warehouse.storebill.page.get";
        }

        public IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("month_end", this.MonthEnd);
            parameters.Add("month_start", this.MonthStart);
            parameters.Add("page_no", this.PageNo);
            parameters.Add("page_size", this.PageSize);
            parameters.Add("seller_store_id", this.SellerStoreId);
            return parameters;
        }

        #endregion
    }
}
