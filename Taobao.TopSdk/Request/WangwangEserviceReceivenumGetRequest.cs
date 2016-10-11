using System;
using System.Collections.Generic;
using Top.Api.Response;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.wangwang.eservice.receivenum.get
    /// </summary>
    public class WangwangEserviceReceivenumGetRequest : ITopRequest<WangwangEserviceReceivenumGetResponse>
    {
        /// <summary>
        /// 查询接待人数的结束日期
        /// </summary>
        public Nullable<DateTime> EndDate { get; set; }

        /// <summary>
        /// 客服人员id：cntaobao+淘宝nick，例如cntaobaotest
        /// </summary>
        public string ServiceStaffId { get; set; }

        /// <summary>
        /// 查询接待人数的开始日期
        /// </summary>
        public Nullable<DateTime> StartDate { get; set; }

        #region ITopRequest Members

        public string GetApiName()
        {
            return "taobao.wangwang.eservice.receivenum.get";
        }

        public IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("end_date", this.EndDate);
            parameters.Add("service_staff_id", this.ServiceStaffId);
            parameters.Add("start_date", this.StartDate);
            return parameters;
        }

        #endregion
    }
}
