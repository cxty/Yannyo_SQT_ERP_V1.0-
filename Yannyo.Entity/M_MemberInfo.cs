using System;

namespace Yannyo.Entity
{
    public class M_MemberInfo
    {
        private int _m_memberinfoid;
        private int _m_configinfoid;
        private string _buyer_id;
        private string _buyer_nick;
        private string _member_grade;
        private decimal _trade_amount;
        private decimal _trade_count;
        private DateTime _laste_time;
        private string _status;
        /// <summary>
        /// 会员系统编号
        /// </summary>
        public int m_MemberInfoID
        {
            set { _m_memberinfoid = value; }
            get { return _m_memberinfoid; }
        }
        /// <summary>
        /// 网店系统编号
        /// </summary>
        public int m_ConfigInfoID
        {
            set { _m_configinfoid = value; }
            get { return _m_configinfoid; }
        }
        /// <summary>
        /// 买家数字ID
        /// </summary>
        public string buyer_id
        {
            set { _buyer_id = value; }
            get { return _buyer_id; }
        }
        /// <summary>
        /// 昵称
        /// </summary>
        public string buyer_nick
        {
            set { _buyer_nick = value; }
            get { return _buyer_nick; }
        }
        /// <summary>
        /// 会员级别
        /// </summary>
        public string member_grade
        {
            set { _member_grade = value; }
            get { return _member_grade; }
        }
        /// <summary>
        /// 总交易额
        /// </summary>
        public decimal trade_amount
        {
            set { _trade_amount = value; }
            get { return _trade_amount; }
        }
        /// <summary>
        /// 总交易量
        /// </summary>
        public decimal trade_count
        {
            set { _trade_count = value; }
            get { return _trade_count; }
        }
        /// <summary>
        /// 上次交易时间
        /// </summary>
        public DateTime laste_time
        {
            set { _laste_time = value; }
            get { return _laste_time; }
        }
        /// <summary>
        /// 状态
        /// </summary>
        public string status
        {
            set { _status = value; }
            get { return _status; }
        }
    }
}
