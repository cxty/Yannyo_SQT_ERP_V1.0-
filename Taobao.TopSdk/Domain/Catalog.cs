using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// Catalog Data Structure.
    /// </summary>
    [Serializable]
    public class Catalog : TopObject
    {
        /// <summary>
        /// 类目id
        /// </summary>
        [XmlElement("catalog_id")]
        public long CatalogId { get; set; }

        /// <summary>
        /// 类目名称
        /// </summary>
        [XmlElement("catalog_name")]
        public string CatalogName { get; set; }
    }
}
