using System;
using System.Collections.Generic;
using Top.Api.Response;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.wlb.item.authorization.add
    /// </summary>
    public class WlbItemAuthorizationAddRequest : ITopRequest<WlbItemAuthorizationAddResponse>
    {
        /// <summary>
        /// 授权结束时间
        /// </summary>
        public Nullable<DateTime> AuthorizeEndTime { get; set; }

        /// <summary>
        /// 授权开始时间
        /// </summary>
        public Nullable<DateTime> AuthorizeStartTime { get; set; }

        /// <summary>
        /// 被授权人用户id
        /// </summary>
        public Nullable<long> ConsignUserId { get; set; }

        /// <summary>
        /// 商品id
        /// </summary>
        public Nullable<long> ItemId { get; set; }

        /// <summary>
        /// 规则名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 授权数量
        /// </summary>
        public Nullable<long> Quantity { get; set; }

        /// <summary>
        /// 授权规则：目前只有GRANT_FIX，按照数量授权
        /// </summary>
        public string RuleCode { get; set; }

        #region ITopRequest Members

        public string GetApiName()
        {
            return "taobao.wlb.item.authorization.add";
        }

        public IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("authorize_end_time", this.AuthorizeEndTime);
            parameters.Add("authorize_start_time", this.AuthorizeStartTime);
            parameters.Add("consign_user_id", this.ConsignUserId);
            parameters.Add("item_id", this.ItemId);
            parameters.Add("name", this.Name);
            parameters.Add("quantity", this.Quantity);
            parameters.Add("rule_code", this.RuleCode);
            return parameters;
        }

        #endregion
    }
}
