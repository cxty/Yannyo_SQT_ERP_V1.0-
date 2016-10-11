using System;
using System.Collections.Generic;
using Top.Api.Response;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.taobaoke.report.get
    /// </summary>
    public class TaobaokeReportGetRequest : ITopRequest<TaobaokeReportGetResponse>
    {
        /// <summary>
        /// 需要查询报表的日期，有效的日期为最近3个月内的某一天，格式为:yyyyMMdd,如20090520.
        /// </summary>
        public string Date { get; set; }

        /// <summary>
        /// 需返回的字段列表.可选值:TaobaokeReportMember淘宝客报表成员结构体中的所有字段;字段之间用","分隔.
        /// </summary>
        public string Fields { get; set; }

        /// <summary>
        /// 当前页数.只能获取1-99页数据
        /// </summary>
        public Nullable<long> PageNo { get; set; }

        /// <summary>
        /// 每页返回结果数,默认是40条.最大每页40
        /// </summary>
        public Nullable<long> PageSize { get; set; }

        #region ITopRequest Members

        public string GetApiName()
        {
            return "taobao.taobaoke.report.get";
        }

        public IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("date", this.Date);
            parameters.Add("fields", this.Fields);
            parameters.Add("page_no", this.PageNo);
            parameters.Add("page_size", this.PageSize);
            return parameters;
        }

        #endregion
    }
}
