using System;
using System.Collections.Generic;
using Top.Api.Response;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.taobaoke.tool.relation
    /// </summary>
    public class TaobaokeToolRelationRequest : ITopRequest<TaobaokeToolRelationResponse>
    {
        /// <summary>
        /// 用户的pubid 用来判断这个pubid是否是appkey关联的开发者的注册用户
        /// </summary>
        public Nullable<long> Pubid { get; set; }

        #region ITopRequest Members

        public string GetApiName()
        {
            return "taobao.taobaoke.tool.relation";
        }

        public IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("pubid", this.Pubid);
            return parameters;
        }

        #endregion
    }
}
