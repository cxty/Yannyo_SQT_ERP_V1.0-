using System;

namespace Yannyo.Entity
{
    public class PaymentSystemInfo
    {
        private int _paymentsystemid;
        private string _pname;
        private DateTime _pappendtime;
        /// <summary>
        /// 客户结算系统编号
        /// </summary>
        public int PaymentSystemID
        {
            set { _paymentsystemid = value; }
            get { return _paymentsystemid; }
        }
        /// <summary>
        /// 名称
        /// </summary>
        public string pName
        {
            set { _pname = value; }
            get { return _pname; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime pAppendTime
        {
            set { _pappendtime = value; }
            get { return _pappendtime; }
        }
    }
}
