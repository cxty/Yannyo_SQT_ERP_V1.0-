using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// ApiruleParameter Data Structure.
    /// </summary>
    [Serializable]
    public class ApiruleParameter : TopObject
    {
        /// <summary>
        /// 当类型为byte[]时，支持的文件类型列表，以“,”分割。
        /// </summary>
        [XmlElement("file_exts")]
        public string FileExts { get; set; }

        /// <summary>
        /// 最大长度。当类型为string、number、field_list时为字符长度，当类型为byte[]时为字节长度。
        /// </summary>
        [XmlElement("length")]
        public long Length { get; set; }

        /// <summary>
        /// 基本类型以“;”号分割后的最大长度。
        /// </summary>
        [XmlElement("max_list_size")]
        public long MaxListSize { get; set; }

        /// <summary>
        /// 当类型为number时的最大值
        /// </summary>
        [XmlElement("max_value")]
        public long MaxValue { get; set; }

        /// <summary>
        /// 当类型为number时的最小值
        /// </summary>
        [XmlElement("min_value")]
        public long MinValue { get; set; }

        /// <summary>
        /// 是否必传
        /// </summary>
        [XmlElement("must")]
        public bool Must { get; set; }

        /// <summary>
        /// aip的参数名
        /// </summary>
        [XmlElement("name")]
        public string Name { get; set; }

        /// <summary>
        /// api的参数类型。目前有 string、int、number、field_list、date、boolean、price、byte[] 8种
        /// </summary>
        [XmlElement("type")]
        public string Type { get; set; }
    }
}
