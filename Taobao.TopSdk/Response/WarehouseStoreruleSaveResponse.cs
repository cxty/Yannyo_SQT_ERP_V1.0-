using System;
using System.Xml.Serialization;
using Top.Api.Domain;

namespace Top.Api.Response
{
    /// <summary>
    /// WarehouseStoreruleSaveResponse.
    /// </summary>
    public class WarehouseStoreruleSaveResponse : TopResponse
    {
        /// <summary>
        /// 是否保存成功
        /// </summary>
        [XmlElement("is_success")]
        public bool IsSuccess { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        [XmlElement("modify_time")]
        public string ModifyTime { get; set; }
    }
}
