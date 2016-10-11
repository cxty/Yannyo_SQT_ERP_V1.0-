using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// Partner Data Structure.
    /// </summary>
    [Serializable]
    public class Partner : TopObject
    {
        /// <summary>
        /// 地址
        /// </summary>
        [XmlElement("address")]
        public string Address { get; set; }

        /// <summary>
        /// 业务类型
        /// </summary>
        [XmlElement("biz_type")]
        public long BizType { get; set; }

        /// <summary>
        /// 认证状态 1未认证，2认证通过，3认证不通过
        /// </summary>
        [XmlElement("certify_status")]
        public long CertifyStatus { get; set; }

        /// <summary>
        /// 城市
        /// </summary>
        [XmlElement("city")]
        public string City { get; set; }

        /// <summary>
        /// 电子邮件
        /// </summary>
        [XmlElement("contact_email")]
        public string ContactEmail { get; set; }

        /// <summary>
        /// 联系人名称
        /// </summary>
        [XmlElement("contact_name")]
        public string ContactName { get; set; }

        /// <summary>
        /// 职位
        /// </summary>
        [XmlElement("contact_position")]
        public string ContactPosition { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        [XmlElement("contact_telephone")]
        public string ContactTelephone { get; set; }

        /// <summary>
        /// 合同开始时间
        /// </summary>
        [XmlElement("contract_begin_time")]
        public string ContractBeginTime { get; set; }

        /// <summary>
        /// 合同结束时间
        /// </summary>
        [XmlElement("contract_end_time")]
        public string ContractEndTime { get; set; }

        /// <summary>
        /// 创建者
        /// </summary>
        [XmlElement("creator")]
        public string Creator { get; set; }

        /// <summary>
        /// 客服经理小二
        /// </summary>
        [XmlElement("customer_manager")]
        public string CustomerManager { get; set; }

        /// <summary>
        /// 外部系统对应的合作伙伴ID
        /// </summary>
        [XmlElement("ext_partner_id")]
        public long ExtPartnerId { get; set; }

        /// <summary>
        /// 业务扩展属性
        /// </summary>
        [XmlElement("extend_info")]
        public string ExtendInfo { get; set; }

        /// <summary>
        /// 传真
        /// </summary>
        [XmlElement("fax")]
        public string Fax { get; set; }

        /// <summary>
        /// 公司负责人
        /// </summary>
        [XmlElement("leader")]
        public string Leader { get; set; }

        /// <summary>
        /// 公司负责人电话
        /// </summary>
        [XmlElement("leader_phone")]
        public string LeaderPhone { get; set; }

        /// <summary>
        /// 修改者
        /// </summary>
        [XmlElement("modifier")]
        public string Modifier { get; set; }

        /// <summary>
        /// 营业执照号
        /// </summary>
        [XmlElement("operating_license_id")]
        public string OperatingLicenseId { get; set; }

        /// <summary>
        /// 营业执照名称
        /// </summary>
        [XmlElement("operating_license_name")]
        public string OperatingLicenseName { get; set; }

        /// <summary>
        /// 商家类别
        /// </summary>
        [XmlElement("partner_level")]
        public string PartnerLevel { get; set; }

        /// <summary>
        /// 合作伙伴或公司名称
        /// </summary>
        [XmlElement("partner_name")]
        public string PartnerName { get; set; }

        /// <summary>
        /// 商家状态 1申请中，2审核通过，3审核不通过，4入驻成功，5已监管，6已退出
        /// </summary>
        [XmlElement("partner_status")]
        public long PartnerStatus { get; set; }

        /// <summary>
        /// 合作伙伴类型
        /// </summary>
        [XmlElement("partner_type")]
        public long PartnerType { get; set; }

        /// <summary>
        /// 合作伙伴用户id
        /// </summary>
        [XmlElement("partner_user_id")]
        public long PartnerUserId { get; set; }

        /// <summary>
        /// 合作伙伴昵称
        /// </summary>
        [XmlElement("partner_user_nick")]
        public string PartnerUserNick { get; set; }

        /// <summary>
        /// 支付宝数字ID或银行帐号
        /// </summary>
        [XmlElement("pay_account_id")]
        public string PayAccountId { get; set; }

        /// <summary>
        /// 支付账号类型 1-默认支付宝
        /// </summary>
        [XmlElement("pay_account_type")]
        public long PayAccountType { get; set; }

        /// <summary>
        /// 支付银行地址信息
        /// </summary>
        [XmlElement("pay_address")]
        public string PayAddress { get; set; }

        /// <summary>
        /// 支付宝email或银行账号名称
        /// </summary>
        [XmlElement("pay_email_name")]
        public string PayEmailName { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        [XmlElement("phone")]
        public string Phone { get; set; }

        /// <summary>
        /// 省份
        /// </summary>
        [XmlElement("province")]
        public string Province { get; set; }

        /// <summary>
        /// 备注信息
        /// </summary>
        [XmlElement("remarks")]
        public string Remarks { get; set; }

        /// <summary>
        /// 状态1，有效； 0，无效；2，冻结
        /// </summary>
        [XmlElement("status")]
        public long Status { get; set; }

        /// <summary>
        /// 商家标签，由不同的业务biz_type决定其含义
        /// </summary>
        [XmlElement("tag")]
        public string Tag { get; set; }

        /// <summary>
        /// 公司或个人网站
        /// </summary>
        [XmlElement("web_site")]
        public string WebSite { get; set; }

        /// <summary>
        /// 邮政编码
        /// </summary>
        [XmlElement("zip")]
        public string Zip { get; set; }
    }
}
