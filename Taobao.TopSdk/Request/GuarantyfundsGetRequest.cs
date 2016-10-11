using System;
using System.Collections.Generic;
using Top.Api.Response;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.guarantyfunds.get
    /// </summary>
    public class GuarantyfundsGetRequest : ITopRequest<GuarantyfundsGetResponse>
    {
        /// <summary>
        /// 查询保证金操作记录创建时间开始，格式为:yyyy-MM-dd
        /// </summary>
        public Nullable<DateTime> BeginDate { get; set; }

        /// <summary>
        /// 查询保证金操作记录创建时间结束，格式为:yyyy-MM-dd
        /// </summary>
        public Nullable<DateTime> EndDate { get; set; }

        #region ITopRequest Members

        public string GetApiName()
        {
            return "taobao.guarantyfunds.get";
        }

        public IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("begin_date", this.BeginDate);
            parameters.Add("end_date", this.EndDate);
            return parameters;
        }

        #endregion
    }
}
