using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// SellerStore Data Structure.
    /// </summary>
    [Serializable]
    public class SellerStore : TopObject
    {
        /// <summary>
        /// 卖家默认使用的淘宝合作物流公司ID
        /// </summary>
        [XmlElement("def_company_id")]
        public long DefCompanyId { get; set; }

        /// <summary>
        /// 备注，最大长度516字节
        /// </summary>
        [XmlElement("remark")]
        public string Remark { get; set; }

        /// <summary>
        /// 淘宝网为仓储用户分配的编号
        /// </summary>
        [XmlElement("seller_code")]
        public string SellerCode { get; set; }

        /// <summary>
        /// 卖家申请使用仓库的面积
        /// </summary>
        [XmlElement("square")]
        public long Square { get; set; }

        /// <summary>
        /// 自定义仓库状态: "WAIT”-待审核 “CANCEL”-撤销申请 “PASS”-审核通过 “UNPASS”-审核未通过
        /// </summary>
        [XmlElement("status")]
        public long Status { get; set; }

        /// <summary>
        /// 卖家申请使用的外部仓库代号，最大长度32字节
        /// </summary>
        [XmlElement("store_code")]
        public string StoreCode { get; set; }

        /// <summary>
        /// 自定义仓库唯一标识
        /// </summary>
        [XmlElement("store_id")]
        public long StoreId { get; set; }

        /// <summary>
        /// 卖家申请使用的外部仓库名称，最大长度64字节
        /// </summary>
        [XmlElement("store_name")]
        public string StoreName { get; set; }

        /// <summary>
        /// 每月补货次数
        /// </summary>
        [XmlElement("supply_times")]
        public long SupplyTimes { get; set; }
    }
}
