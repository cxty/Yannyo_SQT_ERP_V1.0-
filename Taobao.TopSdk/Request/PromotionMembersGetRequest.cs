using System;
using System.Collections.Generic;
using Top.Api.Response;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.promotion.members.get
    /// </summary>
    public class PromotionMembersGetRequest : ITopRequest<PromotionMembersGetResponse>
    {
        /// <summary>
        /// 会员昵称
        /// </summary>
        public string BuyerNick { get; set; }

        /// <summary>
        /// 要查询第几页
        /// </summary>
        public Nullable<long> CurrentPage { get; set; }

        /// <summary>
        /// 买家会员级别 general：普通会员 senior ：高级会员 vip：VIP会员 king：至尊VIP
        /// </summary>
        public string Grade { get; set; }

        /// <summary>
        /// 最大交易额，用分表示
        /// </summary>
        public Nullable<long> MaxTradeAmoun { get; set; }

        /// <summary>
        /// 最大交易量
        /// </summary>
        public Nullable<long> MaxTradeCount { get; set; }

        /// <summary>
        /// 最小交易额，用分表示
        /// </summary>
        public Nullable<long> MinTradeAmount { get; set; }

        /// <summary>
        /// 最小交易量
        /// </summary>
        public Nullable<long> MinTradeCount { get; set; }

        /// <summary>
        /// 每页行数
        /// </summary>
        public Nullable<long> PageSize { get; set; }

        #region ITopRequest Members

        public string GetApiName()
        {
            return "taobao.promotion.members.get";
        }

        public IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("buyer_nick", this.BuyerNick);
            parameters.Add("current_page", this.CurrentPage);
            parameters.Add("grade", this.Grade);
            parameters.Add("max_trade_amoun", this.MaxTradeAmoun);
            parameters.Add("max_trade_count", this.MaxTradeCount);
            parameters.Add("min_trade_amount", this.MinTradeAmount);
            parameters.Add("min_trade_count", this.MinTradeCount);
            parameters.Add("page_size", this.PageSize);
            return parameters;
        }

        #endregion
    }
}
