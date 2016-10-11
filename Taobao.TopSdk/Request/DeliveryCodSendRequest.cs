using System;
using System.Collections.Generic;
using Top.Api.Response;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.delivery.cod.send
    /// </summary>
    public class DeliveryCodSendRequest : ITopRequest<DeliveryCodSendResponse>
    {
        /// <summary>
        /// 物流公司代码.如"POST"就代表中国邮政,"ZJS"就代表宅急送.调用 taobao.logisticcompanies.get  获取.
        /// </summary>
        public string CompanyCode { get; set; }

        /// <summary>
        /// 物流公司取货地址.XXX街道XXX门牌,省市区不需要提供.目的在于让物流公司能清楚的知道在哪取货。<br> <font color="red"> 校验规则：<br> 1.4-60字符(字母\数字\汉字)<br> 2.不能全部数字<br> 3.不能全部字母<br> </font>
        /// </summary>
        public string FetcherAddress { get; set; }

        /// <summary>
        /// 取货地国家公布的标准地区码.参考:http://www.stats.gov.cn/tjbz/xzqhdm/t20080215_402462675.htm  或者调用 taobao.areas.get 获取
        /// </summary>
        public Nullable<long> FetcherAreaId { get; set; }

        /// <summary>
        /// 取货地手机号码
        /// </summary>
        public string FetcherMobile { get; set; }

        /// <summary>
        /// 联系人名称
        /// </summary>
        public string FetcherName { get; set; }

        /// <summary>
        /// 取货地固定电话.包含区号,电话,分机号,中间用 " – "; 取货地固定电话和取货地手机号码,必须填写一个.
        /// </summary>
        public string FetcherPhone { get; set; }

        /// <summary>
        /// 取货地邮编
        /// </summary>
        public string FetcherZip { get; set; }

        /// <summary>
        /// 发货类型.cod(货到付款)
        /// </summary>
        public string OrderType { get; set; }

        /// <summary>
        /// 运单号.具体一个物流公司的真实运单号码。淘宝官方物流会校验，请谨慎传入；若company_code中传入的代码非淘宝官方物流合作公司，此处运单号不校验。
        /// </summary>
        public string OutSid { get; set; }

        /// <summary>
        /// 卖家地址(详细地址).如:XXX街道XXX门牌,省市区不需要提供.<br> <font color="red"> 校验规则：<br> 1.4-60字符(字母\数字\汉字)<br> 2.不能全部数字<br> 3.不能全部字母<br> </font>
        /// </summary>
        public string SellerAddress { get; set; }

        /// <summary>
        /// 卖家所在地国家公布的标准地区码.参考:http://www.stats.gov.cn/tjbz/xzqhdm/t20080215_402462675.htm  或者调用 taobao.areas.get 获取
        /// </summary>
        public Nullable<long> SellerAreaId { get; set; }

        /// <summary>
        /// 卖家手机号码<br> <font color="red">校验规则：<br> 1.8-16位数字<br> 2.不能数字全部相同<br> 3.不能全为字符格式</font>
        /// </summary>
        public string SellerMobile { get; set; }

        /// <summary>
        /// 卖家姓名
        /// </summary>
        public string SellerName { get; set; }

        /// <summary>
        /// 卖家固定电话.包含区号,电话,分机号,中间用 " – "; 卖家固定电话和卖家手机号码,必须填写一个.<br> <font color="red">校验规则：<br> 1.字符不能全部相同<br> 2.长度：5-24位<br> 3.只能包含数字和横杠‘-’</font>
        /// </summary>
        public string SellerPhone { get; set; }

        /// <summary>
        /// 卖家邮编
        /// </summary>
        public string SellerZip { get; set; }

        /// <summary>
        /// 交易ID
        /// </summary>
        public Nullable<long> Tid { get; set; }

        #region ITopRequest Members

        public string GetApiName()
        {
            return "taobao.delivery.cod.send";
        }

        public IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("company_code", this.CompanyCode);
            parameters.Add("fetcher_address", this.FetcherAddress);
            parameters.Add("fetcher_area_id", this.FetcherAreaId);
            parameters.Add("fetcher_mobile", this.FetcherMobile);
            parameters.Add("fetcher_name", this.FetcherName);
            parameters.Add("fetcher_phone", this.FetcherPhone);
            parameters.Add("fetcher_zip", this.FetcherZip);
            parameters.Add("order_type", this.OrderType);
            parameters.Add("out_sid", this.OutSid);
            parameters.Add("seller_address", this.SellerAddress);
            parameters.Add("seller_area_id", this.SellerAreaId);
            parameters.Add("seller_mobile", this.SellerMobile);
            parameters.Add("seller_name", this.SellerName);
            parameters.Add("seller_phone", this.SellerPhone);
            parameters.Add("seller_zip", this.SellerZip);
            parameters.Add("tid", this.Tid);
            return parameters;
        }

        #endregion
    }
}
