using System;
using System.Collections.Generic;
using Top.Api.Response;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.sellercats.list.get
    /// </summary>
    public class SellercatsListGetRequest : ITopRequest<SellercatsListGetResponse>
    {
        /// <summary>
        /// fields参数
        /// </summary>
        public string Fields { get; set; }

        /// <summary>
        /// 卖家昵称
        /// </summary>
        public string Nick { get; set; }

        #region ITopRequest Members

        public string GetApiName()
        {
            return "taobao.sellercats.list.get";
        }

        public IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("fields", this.Fields);
            parameters.Add("nick", this.Nick);
            return parameters;
        }

        #endregion
    }
}
