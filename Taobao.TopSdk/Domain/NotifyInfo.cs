using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// NotifyInfo Data Structure.
    /// </summary>
    [Serializable]
    public class NotifyInfo : TopObject
    {
        /// <summary>
        /// 增量消息的状态（隶属于主题）。具体选值请见：商品消息状态、退款消息状态、交易消息状态中的说明。isNotify应为隶属于topic类型的子类型，比如topic为trade，则isNotify应为TradeCreate
        /// </summary>
        [XmlElement("is_notify")]
        public string IsNotify { get; set; }

        /// <summary>
        /// 增量消息所属的主题。可选值 trade（交易类型） item（商品类型） refund（退款类型）
        /// </summary>
        [XmlElement("topic")]
        public string Topic { get; set; }
    }
}
