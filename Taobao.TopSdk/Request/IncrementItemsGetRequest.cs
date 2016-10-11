using System;
using System.Collections.Generic;
using Top.Api.Response;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.increment.items.get
    /// </summary>
    public class IncrementItemsGetRequest : ITopRequest<IncrementItemsGetResponse>
    {
        /// <summary>
        /// 消息所对应的操作时间的最大值。和start_modified搭配使用能过滤消通知消息的时间段。不传时：如果设置了start_modified，默认为与start_modified同一天的23:59:59；否则默认为调用接口当天的23:59:59。（格式：yyyy-MM-dd HH:mm:ss）<br> <font color="red">注意：start_modified和end_modified的日期必须在必须在同一天内，比如：start_modified设置2000-01-01 00:00:00，则end_modified必须设置为2000-01-01这个日期</font>
        /// </summary>
        public Nullable<DateTime> EndModified { get; set; }

        /// <summary>
        /// 消息所属于的用户的昵称。设置此参数，返回的消息会根据传入nick的进行过滤。自用型AppKey的昵称默认为自己的绑定昵称，此参数无效。
        /// </summary>
        public string Nick { get; set; }

        /// <summary>
        /// 页码。取值范围:大于零的整数; 默认值:1,即返回第一页数据。
        /// </summary>
        public Nullable<long> PageNo { get; set; }

        /// <summary>
        /// 每页条数。取值范围:大于零的整数;最大值:200;默认值:40。
        /// </summary>
        public Nullable<long> PageSize { get; set; }

        /// <summary>
        /// 消息所对应的操作时间的最小值和end_modified搭配使用能过滤消通知消息的时间段。不传时：如果设置了end_modified，默认为与 end_modified同一天的00:00:00，否则默认为调用接口当天的00:00:00。（格式：yyyy-MM-dd HH:mm:ss）<br> <font color="red">注意：start_modified和end_modified的日期必须在必须在同一天内，比如：start_modified设置2000-01-01 00:00:00，则end_modified必须设置为2000-01-01这个日期</font>
        /// </summary>
        public Nullable<DateTime> StartModified { get; set; }

        /// <summary>
        /// 商品操作状态，默认查询所有状态的数据，除了默认值外每次只能查询一种状态。具体类型列表见： ItemAdd（新增商品）  ItemUpshelf（上架商品，自动上架商品不能获取到增量信息）  ItemDownshelf（下架商品）  ItemDelete（删除商品）  ItemUpdate（更新商品）  ItemRecommendDelete（取消橱窗推荐商品）  ItemRecommendAdd（橱窗推荐商品）  ItemZeroStock（商品卖空）
        /// </summary>
        public string Status { get; set; }

        #region ITopRequest Members

        public string GetApiName()
        {
            return "taobao.increment.items.get";
        }

        public IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("end_modified", this.EndModified);
            parameters.Add("nick", this.Nick);
            parameters.Add("page_no", this.PageNo);
            parameters.Add("page_size", this.PageSize);
            parameters.Add("start_modified", this.StartModified);
            parameters.Add("status", this.Status);
            return parameters;
        }

        #endregion
    }
}
