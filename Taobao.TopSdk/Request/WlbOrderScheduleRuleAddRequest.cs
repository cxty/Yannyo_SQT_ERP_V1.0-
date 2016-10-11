using System;
using System.Collections.Generic;
using Top.Api.Response;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.wlb.order.schedule.rule.add
    /// </summary>
    public class WlbOrderScheduleRuleAddRequest : ITopRequest<WlbOrderScheduleRuleAddResponse>
    {
        /// <summary>
        /// 备用发货仓库服务id（通过taobao.wlb.subscription.query接口获得service_id）
        /// </summary>
        public Nullable<long> BackupStoreId { get; set; }

        /// <summary>
        /// 发货仓库服务id（通过taobao.wlb.subscription.query接口获得service_id）
        /// </summary>
        public Nullable<long> DefaultStoreId { get; set; }

        /// <summary>
        /// 发货规则的额外规则设置：  REMARK_STOP--有订单留言不自动下发  COD_STOP--货到付款订单不自动下发  CHECK_WAREHOUSE_DELIVER--检查仓库的配送范围
        /// </summary>
        public string Option { get; set; }

        /// <summary>
        /// 国家地区标准编码列表
        /// </summary>
        public string ProvAreaIds { get; set; }

        #region ITopRequest Members

        public string GetApiName()
        {
            return "taobao.wlb.order.schedule.rule.add";
        }

        public IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("backup_store_id", this.BackupStoreId);
            parameters.Add("default_store_id", this.DefaultStoreId);
            parameters.Add("option", this.Option);
            parameters.Add("prov_area_ids", this.ProvAreaIds);
            return parameters;
        }

        #endregion
    }
}
