using System;
using System.Collections.Generic;
using Top.Api.Response;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.warehouse.outside.order.import
    /// </summary>
    public class WarehouseOutsideOrderImportRequest : ITopRequest<WarehouseOutsideOrderImportResponse>
    {
        /// <summary>
        /// 自动发货标识,ENABLED(已废弃)和DISABLED(不采用自动发货),默认为DISABLED
        /// </summary>
        public string AutoConsign { get; set; }

        /// <summary>
        /// json格式的货物列表，形式如：{"goods_list":[{"goods_name":"name","single_price":"100","goods_quantity":"10","outer_id":"abcd"},{"goods_name":"name1","single_price":"101","goods_quantity":"11","outer_id":"abcd1"}]}其中只有outer_id是可选的，outer_id可以根据接口taobao.warehouse.items.get得到
        /// </summary>
        public string GoodsListJson { get; set; }

        /// <summary>
        /// 货物备注（长度不大于125字符）
        /// </summary>
        public string Memo { get; set; }

        /// <summary>
        /// 外部订单业务唯一标识：对于同一订单，在重复导入时必须保证该标识是相同的，并且相对于其它订单是唯一的（用于标识导入订单的唯一性，长度不大于64字符）
        /// </summary>
        public string OuterBizId { get; set; }

        /// <summary>
        /// 收货人详细地址（长度在4-60字符之间）
        /// </summary>
        public string ReceiverAddress { get; set; }

        /// <summary>
        /// 中国地区编码值(必须为地区叶子节点)如"110101"(北京市市辖区东城区)，获取参见taobao.areas.get
        /// </summary>
        public Nullable<long> ReceiverCountryId { get; set; }

        /// <summary>
        /// 收货人手机号
        /// </summary>
        public Nullable<long> ReceiverMobilePhone { get; set; }

        /// <summary>
        /// 收货人姓名（长度不大于20字节）
        /// </summary>
        public string ReceiverName { get; set; }

        /// <summary>
        /// 收货人电话号
        /// </summary>
        public string ReceiverTelephone { get; set; }

        /// <summary>
        /// 收货人邮编
        /// </summary>
        public string ReceiverZipCode { get; set; }

        #region ITopRequest Members

        public string GetApiName()
        {
            return "taobao.warehouse.outside.order.import";
        }

        public IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("auto_consign", this.AutoConsign);
            parameters.Add("goods_list_json", this.GoodsListJson);
            parameters.Add("memo", this.Memo);
            parameters.Add("outer_biz_id", this.OuterBizId);
            parameters.Add("receiver_address", this.ReceiverAddress);
            parameters.Add("receiver_country_id", this.ReceiverCountryId);
            parameters.Add("receiver_mobile_phone", this.ReceiverMobilePhone);
            parameters.Add("receiver_name", this.ReceiverName);
            parameters.Add("receiver_telephone", this.ReceiverTelephone);
            parameters.Add("receiver_zip_code", this.ReceiverZipCode);
            return parameters;
        }

        #endregion
    }
}
