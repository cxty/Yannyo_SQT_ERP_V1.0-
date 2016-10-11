using System;
using System.Collections.Generic;
using Top.Api.Response;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.fenxiao.discount.add
    /// </summary>
    public class FenxiaoDiscountAddRequest : ITopRequest<FenxiaoDiscountAddResponse>
    {
        /// <summary>
        /// 折扣名称,长度不能超过25字节
        /// </summary>
        public string DiscountName { get; set; }

        /// <summary>
        /// PERCENT（按折扣优惠）、PRICE（按减价优惠），例如"PERCENT,PRICE,PERCENT"
        /// </summary>
        public string DiscountTypes { get; set; }

        /// <summary>
        /// 优惠比率或者优惠价格，例如：”81.31,-23.45,71.23”,大小为-100000000到100000000之间
        /// </summary>
        public string DiscountValues { get; set; }

        /// <summary>
        /// 会员等级的id或者分销商id，例如：”1001,2001,1002”
        /// </summary>
        public string TargetIds { get; set; }

        /// <summary>
        /// GRADE（按会员等级优惠）、DISTRIBUTOR（按分销商优惠），例如"GRADE,DISTRIBUTOR"
        /// </summary>
        public string TargetTypes { get; set; }

        #region ITopRequest Members

        public string GetApiName()
        {
            return "taobao.fenxiao.discount.add";
        }

        public IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("discount_name", this.DiscountName);
            parameters.Add("discount_types", this.DiscountTypes);
            parameters.Add("discount_values", this.DiscountValues);
            parameters.Add("target_ids", this.TargetIds);
            parameters.Add("target_types", this.TargetTypes);
            return parameters;
        }

        #endregion
    }
}
