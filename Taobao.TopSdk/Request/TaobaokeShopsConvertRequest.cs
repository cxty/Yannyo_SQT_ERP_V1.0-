using System;
using System.Collections.Generic;
using Top.Api.Response;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.taobaoke.shops.convert
    /// </summary>
    public class TaobaokeShopsConvertRequest : ITopRequest<TaobaokeShopsConvertResponse>
    {
        /// <summary>
        /// 需返回的字段列表.可选值:TaobaokeShop淘宝客商品结构体中的user_id,shop_title,click_url,commission_rate;字段之间用","分隔.
        /// </summary>
        public string Fields { get; set; }

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
        /// 店铺id串.最大输入10个.格式如:"value1,value2,value3" 用" , "号分隔店铺id.
        /// </summary>
        public string Sids { get; set; }

        #region ITopRequest Members

        public string GetApiName()
        {
            return "taobao.taobaoke.shops.convert";
        }

        public IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("fields", this.Fields);
            parameters.Add("nick", this.Nick);
            parameters.Add("outer_code", this.OuterCode);
            parameters.Add("pid", this.Pid);
            parameters.Add("sids", this.Sids);
            return parameters;
        }

        #endregion
    }
}
