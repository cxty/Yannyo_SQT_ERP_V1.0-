using System;
using System.Collections.Generic;
using Top.Api.Response;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.itemcats.get
    /// </summary>
    public class ItemcatsGetRequest : ITopRequest<ItemcatsGetResponse>
    {
        /// <summary>
        /// 商品所属类目ID列表，用半角逗号(,)分隔 例如:(18957,19562,) (cids、parent_cid至少传一个)
        /// </summary>
        public string Cids { get; set; }

        /// <summary>
        /// 时间戳（格式:yyyy-MM-dd HH:mm:ss ）如果该字段没有传，则取当前所有的类目信息,如果传了parent_cid或者cids，则忽略datetime，如果该字段传了，那么可以查询到该时间到现在为止的增量变化
        /// </summary>
        public Nullable<DateTime> Datetime { get; set; }

        /// <summary>
        /// 需要返回的字段列表，见ItemCat，默认返回：cid,parent_cid,name,is_parent
        /// </summary>
        public string Fields { get; set; }

        /// <summary>
        /// 父商品类目 id，0表示根节点, 传输该参数返回所有子类目。 (cids、parent_cid至少传一个)
        /// </summary>
        public Nullable<long> ParentCid { get; set; }

        #region ITopRequest Members

        public string GetApiName()
        {
            return "taobao.itemcats.get";
        }

        public IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("cids", this.Cids);
            parameters.Add("datetime", this.Datetime);
            parameters.Add("fields", this.Fields);
            parameters.Add("parent_cid", this.ParentCid);
            return parameters;
        }

        #endregion
    }
}
