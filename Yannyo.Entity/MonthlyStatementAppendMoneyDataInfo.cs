using System;

namespace Yannyo.Entity
{
    public class MonthlyStatementAppendMoneyDataInfo
    {
        private int _monthlystatementappendmoneydataid;
        private int _monthlystatementid;
        private decimal _mmoney;
        private DateTime _mdatetime;
        private int _mstate;
        private string _mremake;
        private DateTime _mappendtime = DateTime.Now;

        /// <summary>
        /// 收付款记录编号
        /// </summary>
        public int MonthlyStatementAppendMoneyDataID
        {
            set { _monthlystatementappendmoneydataid = value; }
            get { return _monthlystatementappendmoneydataid; }
        }
        /// <summary>
        /// 所属对账单编号
        /// </summary>
        public int MonthlyStatementID
        {
            set { _monthlystatementid = value; }
            get { return _monthlystatementid; }
        }
        /// <summary>
        /// 发送金额
        /// </summary>
        public decimal mMoney
        {
            set { _mmoney = value; }
            get { return _mmoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime mDateTime
        {
            set { _mdatetime = value; }
            get { return _mdatetime; }
        }
        /// <summary>
        /// 系统状态
        /// </summary>
        public int mState
        {
            set { _mstate = value; }
            get { return _mstate; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string mRemake
        {
            set { _mremake = value; }
            get { return _mremake; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime mAppendTime
        {
            set { _mappendtime = value; }
            get { return _mappendtime; }
        }
    }
}
