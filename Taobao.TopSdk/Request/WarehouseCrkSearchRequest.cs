using System;
using System.Collections.Generic;
using Top.Api.Response;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.warehouse.crk.search
    /// </summary>
    public class WarehouseCrkSearchRequest : ITopRequest<WarehouseCrkSearchResponse>
    {
        /// <summary>
        /// 出入库单号
        /// </summary>
        public string CrkCode { get; set; }

        /// <summary>
        /// 结束创建时间，查出当前时间之前的所有记录数
        /// </summary>
        public Nullable<DateTime> CrkDateEnd { get; set; }

        /// <summary>
        /// 起始创建时间，查出从当前时间起的所有记录
        /// </summary>
        public Nullable<DateTime> CrkDateStart { get; set; }

        /// <summary>
        /// 当前页(默认为1)
        /// </summary>
        public Nullable<long> PageNo { get; set; }

        /// <summary>
        /// 分页参数,每页所包含的记录条数,正整数，默认20，最大50,超过50默认50.
        /// </summary>
        public Nullable<long> PageSize { get; set; }

        /// <summary>
        /// 出入库类型：  入库：TYPE_STOCK_IN  出库：TYPE_STOCK_OUT
        /// </summary>
        public string Type { get; set; }

        #region ITopRequest Members

        public string GetApiName()
        {
            return "taobao.warehouse.crk.search";
        }

        public IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("crk_code", this.CrkCode);
            parameters.Add("crk_date_end", this.CrkDateEnd);
            parameters.Add("crk_date_start", this.CrkDateStart);
            parameters.Add("page_no", this.PageNo);
            parameters.Add("page_size", this.PageSize);
            parameters.Add("type", this.Type);
            return parameters;
        }

        #endregion
    }
}
