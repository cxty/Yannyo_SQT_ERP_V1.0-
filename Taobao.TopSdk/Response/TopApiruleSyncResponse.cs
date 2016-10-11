using System;
using System.Xml.Serialization;
using Top.Api.Domain;

namespace Top.Api.Response
{
    /// <summary>
    /// TopApiruleSyncResponse.
    /// </summary>
    public class TopApiruleSyncResponse : TopResponse
    {
        /// <summary>
        /// api请求规则
        /// </summary>
        [XmlElement("apirule")]
        public Apirule Apirule { get; set; }
    }
}
