using System;
using System.Collections.Generic;
using Top.Api.Response;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.wlb.notify.message.confirm
    /// </summary>
    public class WlbNotifyMessageConfirmRequest : ITopRequest<WlbNotifyMessageConfirmResponse>
    {
        /// <summary>
        /// 物流宝通知消息的id，通过taobao.wlb.notify.message.page.get接口得到的WlbMessage数据结构中的id字段
        /// </summary>
        public Nullable<long> MessageId { get; set; }

        #region ITopRequest Members

        public string GetApiName()
        {
            return "taobao.wlb.notify.message.confirm";
        }

        public IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("message_id", this.MessageId);
            return parameters;
        }

        #endregion
    }
}
