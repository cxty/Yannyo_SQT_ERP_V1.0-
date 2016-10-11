using System;
using System.Collections.Generic;
using Top.Api.Response;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.fenxiao.product.update
    /// </summary>
    public class FenxiaoProductUpdateRequest : ITopRequest<FenxiaoProductUpdateResponse>
    {
        /// <summary>
        /// 警戒库存必须是0到29999。
        /// </summary>
        public Nullable<long> AlarmNumber { get; set; }

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
        /// 产品ID
        /// </summary>
        public Nullable<long> Pid { get; set; }

        /// <summary>
        /// ems费用，单位：元。例：“10.56”。大小为0.01元到999999元之间。更新时必须指定运费类型为buyer，否则不更新。
        /// </summary>
        public string PostageEms { get; set; }

        /// <summary>
        /// 快递费用，单位：元。例：“10.56”。大小为0.01元到999999元之间。更新时必须指定运费类型为buyer，否则不更新。
        /// </summary>
        public string PostageFast { get; set; }

        /// <summary>
        /// 运费模板ID，参考taobao.postages.get。更新时必须指定运费类型为 buyer，否则不更新。
        /// </summary>
        public Nullable<long> PostageId { get; set; }

        /// <summary>
        /// 平邮费用，单位：元。例：“10.56”。大小为0.01元到999999元之间。更新时必须指定运费类型为buyer，否则不更新。
        /// </summary>
        public string PostageOrdinary { get; set; }

        /// <summary>
        /// 运费类型，可选值：seller（供应商承担运费）、buyer（分销商承担运费），默认seller。
        /// </summary>
        public string PostageType { get; set; }

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
        /// sku采购价格，单位元，例："10.50,11.00,20.50"，字段必须和上面的sku_ids保持一致。
        /// </summary>
        public string SkuCostPrices { get; set; }

        /// <summary>
        /// sku id列表，例：1001,1002,1003
        /// </summary>
        public string SkuIds { get; set; }

        /// <summary>
        /// sku商家编码 ，单位元，例："S1000,S1002,S1003"，字段必须和上面的id保持一致，如果没有可以写成",,"
        /// </summary>
        public string SkuOuterIds { get; set; }

        /// <summary>
        /// sku库存，单位元，例："10,20,30"，字段必须和sku_ids保持一致。
        /// </summary>
        public string SkuQuantitys { get; set; }

        /// <summary>
        /// sku市场价，单位元，例："10.50,11.00,20.50"，字段必须和上面的sku_ids保持一致。
        /// </summary>
        public string SkuStandardPrices { get; set; }

        /// <summary>
        /// 标准价格，单位：元。例：“10.56”。必须在0.01元到10000000元之间。
        /// </summary>
        public string StandardPrice { get; set; }

        /// <summary>
        /// 发布状态，可选值：up（上架）、down（下架）、delete（删除），输入非法字符则忽略。
        /// </summary>
        public string Status { get; set; }

        #region ITopRequest Members

        public string GetApiName()
        {
            return "taobao.fenxiao.product.update";
        }

        public IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("alarm_number", this.AlarmNumber);
            parameters.Add("city", this.City);
            parameters.Add("cost_price", this.CostPrice);
            parameters.Add("desc", this.Desc);
            parameters.Add("discount_id", this.DiscountId);
            parameters.Add("have_guarantee", this.HaveGuarantee);
            parameters.Add("have_invoice", this.HaveInvoice);
            parameters.Add("name", this.Name);
            parameters.Add("outer_id", this.OuterId);
            parameters.Add("pid", this.Pid);
            parameters.Add("postage_ems", this.PostageEms);
            parameters.Add("postage_fast", this.PostageFast);
            parameters.Add("postage_id", this.PostageId);
            parameters.Add("postage_ordinary", this.PostageOrdinary);
            parameters.Add("postage_type", this.PostageType);
            parameters.Add("prov", this.Prov);
            parameters.Add("quantity", this.Quantity);
            parameters.Add("retail_price_high", this.RetailPriceHigh);
            parameters.Add("retail_price_low", this.RetailPriceLow);
            parameters.Add("sku_cost_prices", this.SkuCostPrices);
            parameters.Add("sku_ids", this.SkuIds);
            parameters.Add("sku_outer_ids", this.SkuOuterIds);
            parameters.Add("sku_quantitys", this.SkuQuantitys);
            parameters.Add("sku_standard_prices", this.SkuStandardPrices);
            parameters.Add("standard_price", this.StandardPrice);
            parameters.Add("status", this.Status);
            return parameters;
        }

        #endregion
    }
}
