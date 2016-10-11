using System;

namespace Yannyo.Entity
{
   public class DataToMailInfo
    {
        private int _datatomaillid;
        private int _ddatatype;
        private int _ddatetype;
        private int _dstate;
        private string _demail;
        private DateTime _dappendtime = DateTime.Now;
        /// <summary>
        /// 设置编号
        /// </summary>
        public int DataToMaillID
        {
            set { _datatomaillid = value; }
            get { return _datatomaillid; }
        }
        /// <summary>
        /// 数据类型
        /// </summary>
        public int dDataType
        {
            set { _ddatatype = value; }
            get { return _ddatatype; }
        }
        /// <summary>
        /// 统计类型
        /// </summary>
        public int dDateType
        {
            set { _ddatetype = value; }
            get { return _ddatetype; }
        }
        /// <summary>
        /// 系统状态
        /// </summary>
        public int dState
        {
            set { _dstate = value; }
            get { return _dstate; }
        }
        /// <summary>
        /// 收件人
        /// </summary>
        public string dEmail
        {
            set { _demail = value; }
            get { return _demail; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime dAppendTime
        {
            set { _dappendtime = value; }
            get { return _dappendtime; }
        }
    }
}
