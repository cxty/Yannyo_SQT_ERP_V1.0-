using System;
using System.Collections.Generic;
using Top.Api.Response;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.taobaoke.items.detail.get
    /// </summary>
    public class TaobaokeItemsDetailGetRequest : ITopRequest<TaobaokeItemsDetailGetResponse>
    {
        /// <summary>
        /// 需返回的字段列表.可选值:TaobaokeItemDetail淘宝客商品结构体中的所有字段;字段之间用","分隔。item_detail需要设置到Item模型下的字段,如设置:num_iid,detail_url等; 只设置item_detail,则不返回的Item下的所有信息.注：item结构中的skus和videos不返回
        /// </summary>
        public string Fields { get; set; }

        /// <summary>
        /// 淘宝用户昵称，注：指的是淘宝的会员登录名.如果昵称错误,那么客户就收不到佣金.每个淘宝昵称都对应于一个pid，在这里输入要结算佣金的淘宝昵称，当推广的商品成功后，佣金会打入此输入的淘宝昵称的账户。具体的信息可以登入阿里妈妈的网站查看.
        /// </summary>
        public string Nick { get; set; }

        /// <summary>
        /// 淘宝客商品数字id串.最大输入10个.格式如:"value1,value2,value3" 用" , "号分隔商品id.
        /// </summary>
        public string NumIids { get; set; }

        /// <summary>
        /// 自定义输入串.格式:英文和数字组成;长度不能大于12个字符,区分不同的推广渠道,如:bbs,表示bbs为推广渠道;blog,表示blog为推广渠道.
        /// </summary>
        public string OuterCode { get; set; }

        /// <summary>
        /// 淘客用户的pid,用于生成点击串.nick和pid都传入的话,以pid为准
        /// </summary>
        public Nullable<long> Pid { get; set; }

        #region ITopRequest Members

        public string GetApiName()
        {
            return "taobao.taobaoke.items.detail.get";
        }

        public IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("fields", this.Fields);
            parameters.Add("nick", this.Nick);
            parameters.Add("num_iids", this.NumIids);
            parameters.Add("outer_code", this.OuterCode);
            parameters.Add("pid", this.Pid);
            return parameters;
        }

        #endregion
    }
}
