using System;
using System.Collections.Generic;
using Top.Api.Response;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.topats.trade.accountreport.get
    /// </summary>
    public class TopatsTradeAccountreportGetRequest : ITopRequest<TopatsTradeAccountreportGetResponse>
    {
        /// <summary>
        /// 账务日期查询结束时间。查询结束时间必须大于查询开始时间，并且时间跨度不能超过3个月。
        /// </summary>
        public Nullable<DateTime> EndCreated { get; set; }

        /// <summary>
        /// 返回信息包含的字段，详情请见TradeAccountDetail结构体说明
        /// </summary>
        public string Fields { get; set; }

        /// <summary>
        /// 账务日期开始时间，时间必须大于2010-06-10 00:00:00
        /// </summary>
        public Nullable<DateTime> StartCreated { get; set; }

        #region ITopRequest Members

        public string GetApiName()
        {
            return "taobao.topats.trade.accountreport.get";
        }

        public IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("end_created", this.EndCreated);
            parameters.Add("fields", this.Fields);
            parameters.Add("start_created", this.StartCreated);
            return parameters;
        }

        #endregion
    }
}
