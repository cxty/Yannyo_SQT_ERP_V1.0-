using System;
using System.Collections.Generic;
using Top.Api.Response;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.logistics.offline.send
    /// </summary>
    public class LogisticsOfflineSendRequest : ITopRequest<LogisticsOfflineSendResponse>
    {
        /// <summary>
        /// 卖家联系人地址库ID，可以通过taobao.logistics.address.search接口查询到地址库ID。<br><font color='red'>如果为空，取的卖家的默认退货地址</font><br>  <font color='red'><b>注：默认退货地址暂不支持</b></font>
        /// </summary>
        public Nullable<long> CancelId { get; set; }

        /// <summary>
        /// 物流公司代码.如"POST"就代表中国邮政,"ZJS"就代表宅急送.调用 taobao.logistics.companies.get 获取。如传入的代码非淘宝官方物流合作公司，默认是“其他”物流的方式，在淘宝不显示物流具体进度，故传入需谨慎。
        /// </summary>
        public string CompanyCode { get; set; }

        /// <summary>
        /// 运单号.具体一个物流公司的真实运单号码。淘宝官方物流会校验，请谨慎传入；若company_code中传入的代码非淘宝官方物流合作公司，此处运单号不校验。
        /// </summary>
        public string OutSid { get; set; }

        /// <summary>
        /// 卖家联系人地址库ID，可以通过taobao.logistics.address.search接口查询到地址库ID。br><font color='red'>如果为空，取的卖家的默认取货地址</font>
        /// </summary>
        public Nullable<long> SenderId { get; set; }

        /// <summary>
        /// 淘宝交易ID
        /// </summary>
        public Nullable<long> Tid { get; set; }

        #region ITopRequest Members

        public string GetApiName()
        {
            return "taobao.logistics.offline.send";
        }

        public IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("cancel_id", this.CancelId);
            parameters.Add("company_code", this.CompanyCode);
            parameters.Add("out_sid", this.OutSid);
            parameters.Add("sender_id", this.SenderId);
            parameters.Add("tid", this.Tid);
            return parameters;
        }

        #endregion
    }
}
