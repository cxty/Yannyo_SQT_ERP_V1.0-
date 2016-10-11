using System;
using System.Collections.Generic;
using Top.Api.Response;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.taobaoke.listurl.get
    /// </summary>
    public class TaobaokeListurlGetRequest : ITopRequest<TaobaokeListurlGetResponse>
    {
        /// <summary>
        /// 推广者的淘宝会员昵称.注：这里指的是淘宝的登录会员名
        /// </summary>
        public string Nick { get; set; }

        /// <summary>
        /// 自定义输入串.格式:英文和数字组成;长度不能大于12个字符,区分不同的推广渠道,如:bbs,表示bbs为推广渠道;blog,表示blog为推广渠道.
        /// </summary>
        public string OuterCode { get; set; }

        /// <summary>
        /// 淘客用户的pid,用于生成点击串.nick和pid都传入的话,以pid为准
        /// </summary>
        public Nullable<long> Pid { get; set; }

        /// <summary>
        /// 关键词
        /// </summary>
        public string Q { get; set; }

        #region ITopRequest Members

        public string GetApiName()
        {
            return "taobao.taobaoke.listurl.get";
        }

        public IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("nick", this.Nick);
            parameters.Add("outer_code", this.OuterCode);
            parameters.Add("pid", this.Pid);
            parameters.Add("q", this.Q);
            return parameters;
        }

        #endregion
    }
}
