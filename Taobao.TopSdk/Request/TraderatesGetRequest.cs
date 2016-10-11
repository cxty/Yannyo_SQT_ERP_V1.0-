using System;
using System.Collections.Generic;
using Top.Api.Response;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.traderates.get
    /// </summary>
    public class TraderatesGetRequest : ITopRequest<TraderatesGetResponse>
    {
        /// <summary>
        /// 评价结束时间
        /// </summary>
        public Nullable<DateTime> EndDate { get; set; }

        /// <summary>
        /// 需返回的字段列表。可选值：TradeRate 结构中的所有字段，多个字段之间用“,”分隔
        /// </summary>
        public string Fields { get; set; }

        /// <summary>
        /// 页码。取值范围:大于零的整数; 默认值:1
        /// </summary>
        public Nullable<long> PageNo { get; set; }

        /// <summary>
        /// 每页条数。取值范围:大于零的整数; 默认值:40;最大值:200
        /// </summary>
        public Nullable<long> PageSize { get; set; }

        /// <summary>
        /// 评价类型。可选值:get(得到),give(给出)
        /// </summary>
        public string RateType { get; set; }

        /// <summary>
        /// 评价结果。可选值:good(好评),neutral(中评),bad(差评)
        /// </summary>
        public string Result { get; set; }

        /// <summary>
        /// 评价者角色。可选值:seller(卖家),buyer(买家)
        /// </summary>
        public string Role { get; set; }

        /// <summary>
        /// 评价开始时间
        /// </summary>
        public Nullable<DateTime> StartDate { get; set; }

        /// <summary>
        /// 交易订单id，可以是父订单id号，也可以是子订单id号
        /// </summary>
        public Nullable<long> Tid { get; set; }

        #region ITopRequest Members

        public string GetApiName()
        {
            return "taobao.traderates.get";
        }

        public IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("end_date", this.EndDate);
            parameters.Add("fields", this.Fields);
            parameters.Add("page_no", this.PageNo);
            parameters.Add("page_size", this.PageSize);
            parameters.Add("rate_type", this.RateType);
            parameters.Add("result", this.Result);
            parameters.Add("role", this.Role);
            parameters.Add("start_date", this.StartDate);
            parameters.Add("tid", this.Tid);
            return parameters;
        }

        #endregion
    }
}
