using System;
using System.Xml.Serialization;
using Top.Api.Domain;

namespace Top.Api.Response
{
    /// <summary>
    /// WlbItemAuthorizationDeleteResponse.
    /// </summary>
    public class WlbItemAuthorizationDeleteResponse : TopResponse
    {
        /// <summary>
        /// 修改时间
        /// </summary>
        [XmlElement("gmt_modified")]
        public string GmtModified { get; set; }
    }
}
