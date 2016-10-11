using System;
using System.Collections.Generic;
using Top.Api.Response;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.wangwang.eservice.groupmember.get
    /// </summary>
    public class WangwangEserviceGroupmemberGetRequest : ITopRequest<WangwangEserviceGroupmemberGetResponse>
    {
        /// <summary>
        /// 被查询用户组管理员ID：cntaobao+淘宝nick，例如cntaobaotest
        /// </summary>
        public string ManagerId { get; set; }

        #region ITopRequest Members

        public string GetApiName()
        {
            return "taobao.wangwang.eservice.groupmember.get";
        }

        public IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("manager_id", this.ManagerId);
            return parameters;
        }

        #endregion
    }
}
