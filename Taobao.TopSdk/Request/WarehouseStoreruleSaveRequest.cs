using System;
using System.Collections.Generic;
using Top.Api.Response;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.warehouse.storerule.save
    /// </summary>
    public class WarehouseStoreruleSaveRequest : ITopRequest<WarehouseStoreruleSaveResponse>
    {
        /// <summary>
        /// 发货规则中的备用仓库
        /// </summary>
        public Nullable<long> BackSellerStoreId { get; set; }

        /// <summary>
        /// 仓库覆盖地区代码.如"310000,320000"代表"上海 江苏".地区代码可调用 taobao.areas.get 获取.
        /// </summary>
        public string ProvAreaIds { get; set; }

        /// <summary>
        /// 要设置发货规则的自定义仓库的id,可调用 taobao.warehouse.sellerstores.get 获取.
        /// </summary>
        public Nullable<long> SellerStoreId { get; set; }

        #region ITopRequest Members

        public string GetApiName()
        {
            return "taobao.warehouse.storerule.save";
        }

        public IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("back_seller_store_id", this.BackSellerStoreId);
            parameters.Add("prov_area_ids", this.ProvAreaIds);
            parameters.Add("seller_store_id", this.SellerStoreId);
            return parameters;
        }

        #endregion
    }
}
