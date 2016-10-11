using System;
using System.Collections.Generic;
using Top.Api.Response;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.taobaoke.shops.get
    /// </summary>
    public class TaobaokeShopsGetRequest : ITopRequest<TaobaokeShopsGetResponse>
    {
        /// <summary>
        /// 前台类目id
        /// </summary>
        public Nullable<long> Cid { get; set; }

        /// <summary>
        /// 店铺商品数查询结束值
        /// </summary>
        public string EndAuctioncount { get; set; }

        /// <summary>
        /// 店铺佣金比例查询结束值
        /// </summary>
        public string EndCommissionrate { get; set; }

        /// <summary>
        /// 店铺掌柜信用等级查询结束
        /// </summary>
        public string EndCredit { get; set; }

        /// <summary>
        /// 店铺累计推广数查询结束值
        /// </summary>
        public string EndTotalaction { get; set; }

        /// <summary>
        /// 需要返回的字段，目前包括如下字段 user_id click_url shop_title commission_rate seller_credit shop_type auction_count total_auction
        /// </summary>
        public string Fields { get; set; }

        /// <summary>
        /// 店铺主题关键字查询
        /// </summary>
        public string Keyword { get; set; }

        /// <summary>
        /// 淘宝用户昵称，注：指的是淘宝的会员登录名.如果昵称错误,那么客户就收不到佣金.每个淘宝昵称都对应于一个pid，在这里输入要结算佣金的淘宝昵称，当推广的商品成功后，佣金会打入此输入的淘宝昵称的账户。具体的信息可以登入阿里妈妈的网站查看
        /// </summary>
        public string Nick { get; set; }

        /// <summary>
        /// 是否只显示商城店铺
        /// </summary>
        public Nullable<bool> OnlyMall { get; set; }

        /// <summary>
        /// 自定义输入串.格式:英文和数字组成;长度不能大于12个字符,区分不同的推广渠道,如:bbs,表示bbs为推广渠道;blog,表示blog为推广渠道.
        /// </summary>
        public string OuterCode { get; set; }

        /// <summary>
        /// 页码.结果页1~99
        /// </summary>
        public Nullable<long> PageNo { get; set; }

        /// <summary>
        /// 每页条数.最大每页40
        /// </summary>
        public Nullable<long> PageSize { get; set; }

        /// <summary>
        /// 淘客用户的pid,用于生成点击串.nick和pid都传入的话,以pid为准
        /// </summary>
        public Nullable<long> Pid { get; set; }

        /// <summary>
        /// 店铺宝贝数查询开始值
        /// </summary>
        public string StartAuctioncount { get; set; }

        /// <summary>
        /// 店铺佣金比例查询开始值，注意佣金比例是x10000的整数.50表示0.5%
        /// </summary>
        public string StartCommissionrate { get; set; }

        /// <summary>
        /// 店铺掌柜信用等级起始
        /// </summary>
        public string StartCredit { get; set; }

        /// <summary>
        /// 店铺累计推广量开始值
        /// </summary>
        public string StartTotalaction { get; set; }

        #region ITopRequest Members

        public string GetApiName()
        {
            return "taobao.taobaoke.shops.get";
        }

        public IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("cid", this.Cid);
            parameters.Add("end_auctioncount", this.EndAuctioncount);
            parameters.Add("end_commissionrate", this.EndCommissionrate);
            parameters.Add("end_credit", this.EndCredit);
            parameters.Add("end_totalaction", this.EndTotalaction);
            parameters.Add("fields", this.Fields);
            parameters.Add("keyword", this.Keyword);
            parameters.Add("nick", this.Nick);
            parameters.Add("only_mall", this.OnlyMall);
            parameters.Add("outer_code", this.OuterCode);
            parameters.Add("page_no", this.PageNo);
            parameters.Add("page_size", this.PageSize);
            parameters.Add("pid", this.Pid);
            parameters.Add("start_auctioncount", this.StartAuctioncount);
            parameters.Add("start_commissionrate", this.StartCommissionrate);
            parameters.Add("start_credit", this.StartCredit);
            parameters.Add("start_totalaction", this.StartTotalaction);
            return parameters;
        }

        #endregion
    }
}
