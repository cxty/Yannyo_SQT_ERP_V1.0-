using System;
using System.Collections.Generic;
using Top.Api.Response;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.fenxiao.product.add
    /// </summary>
    public class FenxiaoProductAddRequest : ITopRequest<FenxiaoProductAddResponse>
    {
        /// <summary>
        /// 警戒库存必须是0到29999。
        /// </summary>
        public Nullable<long> AlarmNumber { get; set; }

        /// <summary>
        /// 所属类目id，参考Taobao.itemcats.get，不支持成人等类目，输入成人类目id保存提示类目属性错误。
        /// </summary>
        public Nullable<long> CategoryId { get; set; }

        /// <summary>
        /// 所在地：市，例：“杭州”
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// 采购价格，单位：元。例：“10.56”。必须在0.01元到10000000元之间。
        /// </summary>
        public string CostPrice { get; set; }

        /// <summary>
        /// 产品描述，长度为5到25000字符。
        /// </summary>
        public string Desc { get; set; }

        /// <summary>
        /// 折扣ID
        /// </summary>
        public Nullable<long> DiscountId { get; set; }

        /// <summary>
        /// 是否有保修，可选值：false（否）、true（是），默认false。
        /// </summary>
        public string HaveGuarantee { get; set; }

        /// <summary>
        /// 是否有发票，可选值：false（否）、true（是），默认false。
        /// </summary>
        public string HaveInvoice { get; set; }

        /// <summary>
        /// 产品名称，长度不超过60个字节。
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 商家编码，长度不能超过60个字节。
        /// </summary>
        public string OuterId { get; set; }

        /// <summary>
        /// ems费用，单位：元。例：“10.56”。 大小为0.00元到999999元之间。
        /// </summary>
        public string PostageEms { get; set; }

        /// <summary>
        /// 快递费用，单位：元。例：“10.56”。 大小为0.01元到999999元之间。
        /// </summary>
        public string PostageFast { get; set; }

        /// <summary>
        /// 运费模板ID，参考taobao.postages.get。
        /// </summary>
        public Nullable<long> PostageId { get; set; }

        /// <summary>
        /// 平邮费用，单位：元。例：“10.56”。 大小为0.01元到999999元之间。
        /// </summary>
        public string PostageOrdinary { get; set; }

        /// <summary>
        /// 运费类型，可选值：seller（供应商承担运费）、buyer（分销商承担运费）,默认seller。
        /// </summary>
        public string PostageType { get; set; }

        /// <summary>
        /// 产品线ID
        /// </summary>
        public Nullable<long> ProductcatId { get; set; }

        /// <summary>
        /// 所在地：省，例：“浙江”
        /// </summary>
        public string Prov { get; set; }

        /// <summary>
        /// 产品库存必须是1到999999。
        /// </summary>
        public Nullable<long> Quantity { get; set; }

        /// <summary>
        /// 最高零售价，单位：元。例：“10.56”。必须在0.01元到10000000元之间，最高零售价必须大于最低零售价。
        /// </summary>
        public string RetailPriceHigh { get; set; }

        /// <summary>
        /// 最低零售价，单位：元。例：“10.56”。必须在0.01元到10000000元之间。
        /// </summary>
        public string RetailPriceLow { get; set; }

        /// <summary>
        /// 标准价格，单位：元。例：“10.56”。必须在0.01元到10000000元之间。
        /// </summary>
        public string StandardPrice { get; set; }

        /// <summary>
        /// 分销方式：AGENT（只做代销，默认值）、DEALER（只做经销）、ALL（代销和经销都做）
        /// </summary>
        public string TradeType { get; set; }

        #region ITopRequest Members

        public string GetApiName()
        {
            return "taobao.fenxiao.product.add";
        }

        public IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("alarm_number", this.AlarmNumber);
            parameters.Add("category_id", this.CategoryId);
            parameters.Add("city", this.City);
            parameters.Add("cost_price", this.CostPrice);
            parameters.Add("desc", this.Desc);
            parameters.Add("discount_id", this.DiscountId);
            parameters.Add("have_guarantee", this.HaveGuarantee);
            parameters.Add("have_invoice", this.HaveInvoice);
            parameters.Add("name", this.Name);
            parameters.Add("outer_id", this.OuterId);
            parameters.Add("postage_ems", this.PostageEms);
            parameters.Add("postage_fast", this.PostageFast);
            parameters.Add("postage_id", this.PostageId);
            parameters.Add("postage_ordinary", this.PostageOrdinary);
            parameters.Add("postage_type", this.PostageType);
            parameters.Add("productcat_id", this.ProductcatId);
            parameters.Add("prov", this.Prov);
            parameters.Add("quantity", this.Quantity);
            parameters.Add("retail_price_high", this.RetailPriceHigh);
            parameters.Add("retail_price_low", this.RetailPriceLow);
            parameters.Add("standard_price", this.StandardPrice);
            parameters.Add("trade_type", this.TradeType);
            return parameters;
        }

        #endregion
    }
}
