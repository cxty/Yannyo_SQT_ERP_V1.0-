using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Domain
{
    /// <summary>
    /// Apirule Data Structure.
    /// </summary>
    [Serializable]
    public class Apirule : TopObject
    {
        /// <summary>
        /// api名称
        /// </summary>
        [XmlElement("api_name")]
        public string ApiName { get; set; }

        /// <summary>
        /// api请求参数具体规则结构
        /// </summary>
        [XmlArray("apirule_parameters")]
        [XmlArrayItem("apirule_parameter")]
        public List<ApiruleParameter> ApiruleParameters { get; set; }

        /// <summary>
        /// api请求参数规则最后修改时间
        /// </summary>
        [XmlElement("last_modified")]
        public string LastModified { get; set; }

        /// <summary>
        /// 是否需要session（即登录）
        /// </summary>
        [XmlElement("need_session")]
        public bool NeedSession { get; set; }
    }
}
