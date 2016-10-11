using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// AuthorizeMessage Data Structure.
    /// </summary>
    [Serializable]
    public class AuthorizeMessage : TopObject
    {
        /// <summary>
        /// ISV的AppKey
        /// </summary>
        [XmlElement("app_key")]
        public string AppKey { get; set; }

        /// <summary>
        /// 用户创建授权给当前ISV的时间
        /// </summary>
        [XmlElement("created")]
        public string Created { get; set; }

        /// <summary>
        /// 用户的授权到期时间
        /// </summary>
        [XmlElement("end_date")]
        public string EndDate { get; set; }

        /// <summary>
        /// 用户的授权信息修改时间
        /// </summary>
        [XmlElement("modified")]
        public string Modified { get; set; }

        /// <summary>
        /// 授权用户的淘宝昵称
        /// </summary>
        [XmlElement("nick")]
        public string Nick { get; set; }

        /// <summary>
        /// 用户的授权开始时间。授权当天开始计算。start_date是每个授权周期开始的时间，如果这个周期没有结束用户就延长或修改了授权周期，这个开始时间是不会变的，除非这个周期结束以后再重新开始新的周期，这个字段才会被改变
        /// </summary>
        [XmlElement("start_date")]
        public string StartDate { get; set; }

        /// <summary>
        /// 用户的授权状态：normal（正常），expired（过期）
        /// </summary>
        [XmlElement("status")]
        public string Status { get; set; }

        /// <summary>
        /// 用户的授权是否已经生效（生效表示能够收到变更消息）
        /// </summary>
        [XmlElement("valid")]
        public bool Valid { get; set; }
    }
}
