using System;
using System.Collections.Generic;
using Top.Api.Response;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.increment.authorizemessages.get
    /// </summary>
    public class IncrementAuthorizemessagesGetRequest : ITopRequest<IncrementAuthorizemessagesGetResponse>
    {
        /// <summary>
        /// 需要返回的字段。具体字段间AuthorizeMessage说明
        /// </summary>
        public string Fields { get; set; }

        /// <summary>
        /// 用户昵称列表，每个nick之间以","间隔，一次不超过20个
        /// </summary>
        public string Nicks { get; set; }

        /// <summary>
        /// 页码。取值范围:大于零的整数; 默认值:1,即返回第一页数据。
        /// </summary>
        public Nullable<long> PageNo { get; set; }

        /// <summary>
        /// 每页条数。取值范围:大于零的整数;最大值:200;默认值:40。注：只有不指定nick参数时分页才有作用。
        /// </summary>
        public Nullable<long> PageSize { get; set; }

        #region ITopRequest Members

        public string GetApiName()
        {
            return "taobao.increment.authorizemessages.get";
        }

        public IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("fields", this.Fields);
            parameters.Add("nicks", this.Nicks);
            parameters.Add("page_no", this.PageNo);
            parameters.Add("page_size", this.PageSize);
            return parameters;
        }

        #endregion
    }
}
