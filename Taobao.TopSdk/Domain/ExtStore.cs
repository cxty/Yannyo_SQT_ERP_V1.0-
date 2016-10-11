using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// ExtStore Data Structure.
    /// </summary>
    [Serializable]
    public class ExtStore : TopObject
    {
        /// <summary>
        /// 仓库联系地址，最大长度为128个字节
        /// </summary>
        [XmlElement("address")]
        public string Address { get; set; }

        /// <summary>
        /// 仓库所在地
        /// </summary>
        [XmlElement("city")]
        public string City { get; set; }

        /// <summary>
        /// 仓库所属公司代号,从原来的Number类型变更为String,支持字母。
        /// </summary>
        [XmlElement("company_code")]
        public string CompanyCode { get; set; }

        /// <summary>
        /// 仓库所属公司在淘宝网的记录ID
        /// </summary>
        [XmlElement("company_id")]
        public long CompanyId { get; set; }

        /// <summary>
        /// 仓库的传真号，最大长度为32个字节
        /// </summary>
        [XmlElement("contact_fax")]
        public string ContactFax { get; set; }

        /// <summary>
        /// 联系人姓名，最大长度为32个字节
        /// </summary>
        [XmlElement("contact_name")]
        public string ContactName { get; set; }

        /// <summary>
        /// 仓库的联系电话，最大长度为64个字节
        /// </summary>
        [XmlElement("contact_phone")]
        public string ContactPhone { get; set; }

        /// <summary>
        /// 仓库的租赁费介绍，最大长度为1024个字节
        /// </summary>
        [XmlElement("price_desc")]
        public string PriceDesc { get; set; }

        /// <summary>
        /// 仓库面积
        /// </summary>
        [XmlElement("square")]
        public long Square { get; set; }

        /// <summary>
        /// 仓库代号，最大长度为32个字节
        /// </summary>
        [XmlElement("store_code")]
        public string StoreCode { get; set; }

        /// <summary>
        /// 仓库描述，最大长度为1024个字节
        /// </summary>
        [XmlElement("store_desc")]
        public string StoreDesc { get; set; }

        /// <summary>
        /// 仓库名称，最大长度为64个字节
        /// </summary>
        [XmlElement("store_name")]
        public string StoreName { get; set; }

        /// <summary>
        /// 仓库的租用单价(元/平方米)
        /// </summary>
        [XmlElement("unit_price")]
        public string UnitPrice { get; set; }

        /// <summary>
        /// 邮政编码
        /// </summary>
        [XmlElement("zip_code")]
        public string ZipCode { get; set; }
    }
}
