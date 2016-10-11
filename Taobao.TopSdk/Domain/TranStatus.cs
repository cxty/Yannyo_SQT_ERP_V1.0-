using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// TranStatus Data Structure.
    /// </summary>
    [Serializable]
    public class TranStatus : TopObject
    {
        /// <summary>
        /// 该记录的创建时间
        /// </summary>
        [XmlElement("create_date")]
        public string CreateDate { get; set; }

        /// <summary>
        /// 操作人
        /// </summary>
        [XmlElement("operator")]
        public string Operator { get; set; }

        /// <summary>
        /// 操作人员的操作时间,由接口传过来后存入数据库的
        /// </summary>
        [XmlElement("operator_date")]
        public string OperatorDate { get; set; }

        /// <summary>
        /// 即传过来的物流订单号
        /// </summary>
        [XmlElement("order_code")]
        public string OrderCode { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [XmlElement("remark")]
        public string Remark { get; set; }

        /// <summary>
        /// 物流订单的状态:  ACCEPT  接单;  PRINT   打印;  PICK    捡货;  CHECK   复核;  PACKAGE 打包;  CONSIGN 已发货;    PAY     支付成功;  SIGN    签收成功;  FAILED  签收失败;  ERROR   异常;
        /// </summary>
        [XmlElement("tran_status")]
        public string TranStatus_ { get; set; }
    }
}
