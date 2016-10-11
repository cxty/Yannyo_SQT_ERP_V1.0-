using System;
using System.Collections.Generic;
using Top.Api.Response;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.warehouse.stockin.add
    /// </summary>
    public class WarehouseStockinAddRequest : ITopRequest<WarehouseStockinAddResponse>
    {
        /// <summary>
        /// 预计到达时间（入参形式必须如示例所示）
        /// </summary>
        public Nullable<DateTime> ExpectCrkDate { get; set; }

        /// <summary>
        /// 要入库的商品的商家编码，以逗号隔开，一次最多500个商品
        /// </summary>
        public string OuterIds { get; set; }

        /// <summary>
        /// 要入库的商品的计划入库数量，以逗号隔开，数量必须和outer_ids字段中的out_id数量一致，并且一一对应
        /// </summary>
        public string PlanCount { get; set; }

        /// <summary>
        /// 每个商品的入库备注，以逗号隔开，和outer_ids中每个outer_id对应。值全为空时可不填，若最少有一条备注，则个数必需与outer_id个数对应，用逗号隔开来表示一条记录。
        /// </summary>
        public string Remarks { get; set; }

        /// <summary>
        /// 商家联系人
        /// </summary>
        public string SellerContactor { get; set; }

        /// <summary>
        /// 商家名称
        /// </summary>
        public string SellerName { get; set; }

        /// <summary>
        /// 商家联系电话
        /// </summary>
        public string SellerPhone { get; set; }

        /// <summary>
        /// 配送中心
        /// </summary>
        public Nullable<long> SellerStoreId { get; set; }

        /// <summary>
        /// 总箱数
        /// </summary>
        public Nullable<long> TotalPackage { get; set; }

        /// <summary>
        /// 运输公司名称
        /// </summary>
        public string TransportName { get; set; }

        /// <summary>
        /// 运输公司运单号
        /// </summary>
        public string TransportNo { get; set; }

        #region ITopRequest Members

        public string GetApiName()
        {
            return "taobao.warehouse.stockin.add";
        }

        public IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("expect_crk_date", this.ExpectCrkDate);
            parameters.Add("outer_ids", this.OuterIds);
            parameters.Add("plan_count", this.PlanCount);
            parameters.Add("remarks", this.Remarks);
            parameters.Add("seller_contactor", this.SellerContactor);
            parameters.Add("seller_name", this.SellerName);
            parameters.Add("seller_phone", this.SellerPhone);
            parameters.Add("seller_store_id", this.SellerStoreId);
            parameters.Add("total_package", this.TotalPackage);
            parameters.Add("transport_name", this.TransportName);
            parameters.Add("transport_no", this.TransportNo);
            return parameters;
        }

        #endregion
    }
}
