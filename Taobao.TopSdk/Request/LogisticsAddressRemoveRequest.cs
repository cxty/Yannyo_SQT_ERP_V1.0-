using System;
using System.Collections.Generic;
using Top.Api.Response;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.logistics.address.remove
    /// </summary>
    public class LogisticsAddressRemoveRequest : ITopRequest<LogisticsAddressRemoveResponse>
    {
        /// <summary>
        /// 地址库ID
        /// </summary>
        public Nullable<long> ContactId { get; set; }

        #region ITopRequest Members

        public string GetApiName()
        {
            return "taobao.logistics.address.remove";
        }

        public IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("contact_id", this.ContactId);
            return parameters;
        }

        #endregion
    }
}
