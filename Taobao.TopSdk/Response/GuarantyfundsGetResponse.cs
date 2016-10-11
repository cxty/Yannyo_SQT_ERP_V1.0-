using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Top.Api.Domain;

namespace Top.Api.Response
{
    /// <summary>
    /// GuarantyfundsGetResponse.
    /// </summary>
    public class GuarantyfundsGetResponse : TopResponse
    {
        /// <summary>
        /// B商家保证金使用记录，最大返回1000条记录。   如果不传入开始日期和结束日期，则返回所有不超过1000条的记录   如果只传入开始日期，不传入结束日期，则返回开始日期以后创建的所有不超过1000条的记录   如果只传入结束日期，不传入开始日期，则返回结束日期以前创建的所有不超过1000条的记录
        /// </summary>
        [XmlArray("guarantyFunds")]
        [XmlArrayItem("guaranty_fund")]
        public List<GuarantyFund> GuarantyFunds { get; set; }
    }
}
