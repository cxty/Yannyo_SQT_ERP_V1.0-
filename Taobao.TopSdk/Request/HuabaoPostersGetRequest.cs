using System;
using System.Collections.Generic;
using Top.Api.Response;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.huabao.posters.get
    /// </summary>
    public class HuabaoPostersGetRequest : ITopRequest<HuabaoPostersGetResponse>
    {
        /// <summary>
        /// 频道的Id值
        /// </summary>
        public Nullable<long> ChannelId { get; set; }

        /// <summary>
        /// 当前页，默认为1（当输入为负，零，或者超出页数范围时，取默认值）
        /// </summary>
        public Nullable<long> PageNo { get; set; }

        /// <summary>
        /// 查询返回的记录数
        /// </summary>
        public Nullable<long> PageSize { get; set; }

        #region ITopRequest Members

        public string GetApiName()
        {
            return "taobao.huabao.posters.get";
        }

        public IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("channel_id", this.ChannelId);
            parameters.Add("page_no", this.PageNo);
            parameters.Add("page_size", this.PageSize);
            return parameters;
        }

        #endregion
    }
}
