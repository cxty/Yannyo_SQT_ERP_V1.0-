using System;
using System.Collections.Generic;
using Top.Api.Response;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.cube.xsdzdist.get
    /// </summary>
    public class CubeXsdzdistGetRequest : ITopRequest<CubeXsdzdistGetResponse>
    {
        /// <summary>
        /// 淘宝后台类目id,  可以只写一个,如1101,  可以写多个,需要用逗号隔开,如1101,1512,11,  最多为10个
        /// </summary>
        public string Cids { get; set; }

        /// <summary>
        /// 结束日期,限制为最近3个月
        /// </summary>
        public Nullable<DateTime> End { get; set; }

        /// <summary>
        /// 开始日期,限制为最近3个月
        /// </summary>
        public Nullable<DateTime> Start { get; set; }

        #region ITopRequest Members

        public string GetApiName()
        {
            return "taobao.cube.xsdzdist.get";
        }

        public IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("cids", this.Cids);
            parameters.Add("end", this.End);
            parameters.Add("start", this.Start);
            return parameters;
        }

        #endregion
    }
}
