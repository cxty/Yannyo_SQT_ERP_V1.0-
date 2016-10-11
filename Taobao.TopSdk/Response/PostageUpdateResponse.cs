using System;
using System.Xml.Serialization;
using Top.Api.Domain;

namespace Top.Api.Response
{
    /// <summary>
    /// PostageUpdateResponse.
    /// </summary>
    public class PostageUpdateResponse : TopResponse
    {
        /// <summary>
        /// 修改后的邮费模板信息
        /// </summary>
        [XmlElement("postage")]
        public Postage Postage { get; set; }
    }
}
