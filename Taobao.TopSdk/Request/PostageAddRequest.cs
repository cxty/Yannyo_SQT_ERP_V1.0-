using System;
using System.Collections.Generic;
using Top.Api.Response;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.postage.add
    /// </summary>
    public class PostageAddRequest : ITopRequest<PostageAddResponse>
    {
        /// <summary>
        /// 默认EMS加价费用.精确到1位小数;单位:元。如:1.5
        /// </summary>
        public string EmsIncrease { get; set; }

        /// <summary>
        /// 默认EMS费用. 精确到1位小数;单位:元。如:200.5
        /// </summary>
        public string EmsPrice { get; set; }

        /// <summary>
        /// 默认快递加价费用.精确到1位小数;单位:元。如:1.5
        /// </summary>
        public string ExpressIncrease { get; set; }

        /// <summary>
        /// 默认快递费用. 精确到1位小数;单位:元。如:200.5
        /// </summary>
        public string ExpressPrice { get; set; }

        /// <summary>
        /// 邮费模板备注,不能超过200个字节
        /// </summary>
        public string Memo { get; set; }

        /// <summary>
        /// 邮费模板名称,不能超过50个字节
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 默认平邮加价费用. 精确到1位小数;单位:元。如:1.5
        /// </summary>
        public string PostIncrease { get; set; }

        /// <summary>
        /// 默认平邮费用. 注意:至少选择一组默认的邮费组,例如:post_price,post_increase . 精确到1位小数;单位:元。如:200.5
        /// </summary>
        public string PostPrice { get; set; }

        /// <summary>
        /// 邮费子项涉及的地区.结构: value1;value2;value3 如:110000;310000;320000,330000 就代表邮费子项涉及(北京;上海;江苏,浙江)四个地区. 可以用taobao.areas.get接口获取.或者参考：http://www.stats.gov.cn/tjbz/xzqhdm/t20080215_402462675.htm
        /// </summary>
        public string PostageModeDests { get; set; }

        /// <summary>
        /// 运费方式加件费用.结构: value1;value2;value3 如: 1.5;2;4 .精确到1位小数;单位:元。如:1.5
        /// </summary>
        public string PostageModeIncreases { get; set; }

        /// <summary>
        /// 运费方式单价. 结构: value1;value2;value3 如: 11.2;14;6 .精确到1位小数;单位:元。如:200.5
        /// </summary>
        public string PostageModePrices { get; set; }

        /// <summary>
        /// 运费方式:平邮 (post),快递公司(express),EMS (ems) 结构:value1;value2;value3 如: post;express;ems 注意:在添加多个PostageMode时,字符串中使用 ";" 分号区分.postage_mode.type,postage_mode.dest,postage_mode.price,postage_mode.increase, 数量必须一致.
        /// </summary>
        public string PostageModeTypes { get; set; }

        #region ITopRequest Members

        public string GetApiName()
        {
            return "taobao.postage.add";
        }

        public IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("ems_increase", this.EmsIncrease);
            parameters.Add("ems_price", this.EmsPrice);
            parameters.Add("express_increase", this.ExpressIncrease);
            parameters.Add("express_price", this.ExpressPrice);
            parameters.Add("memo", this.Memo);
            parameters.Add("name", this.Name);
            parameters.Add("post_increase", this.PostIncrease);
            parameters.Add("post_price", this.PostPrice);
            parameters.Add("postage_mode_dests", this.PostageModeDests);
            parameters.Add("postage_mode_increases", this.PostageModeIncreases);
            parameters.Add("postage_mode_prices", this.PostageModePrices);
            parameters.Add("postage_mode_types", this.PostageModeTypes);
            return parameters;
        }

        #endregion
    }
}
