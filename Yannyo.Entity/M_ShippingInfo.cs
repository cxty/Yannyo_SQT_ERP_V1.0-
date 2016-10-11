using System;

namespace Yannyo.Entity
{
  public   class M_ShippingInfo
    {
        public M_ShippingInfo()
        { }
        #region Model
        private int _m_shippinginfoid;
        private int _m_tradeinfoid;
        private long _tid;
        private string _seller_nick;
        private string _buyer_nick;
        private DateTime _delivery_start;
        private DateTime _delivery_end;
        private string _out_sid;
        private string _item_title;
        private string _receiver_name;
        private string _receiver_phone;
        private string _receiver_mobile;
        private string _status;
        private string _type;
        private string _freight_payer;
        private string _seller_confirm;
        private string _company_name;
        private bool _is_success;
        private DateTime _created;
        private DateTime _modified;
        /// <summary>
        /// 物流信息编号
        /// </summary>
        public int m_ShippingInfoID
        {
            set { _m_shippinginfoid = value; }
            get { return _m_shippinginfoid; }
        }
        /// <summary>
        /// 所属交易编号
        /// </summary>
        public int m_TradeInfoID
        {
            set { _m_tradeinfoid = value; }
            get { return _m_tradeinfoid; }
        }
        /// <summary>
        /// 交易编号
        /// </summary>
        public long tid
        {
            set { _tid = value; }
            get { return _tid; }
        }
        /// <summary>
        /// 卖家昵称
        /// </summary>
        public string seller_nick
        {
            set { _seller_nick = value; }
            get { return _seller_nick; }
        }
        /// <summary>
        /// 买家昵称
        /// </summary>
        public string buyer_nick
        {
            set { _buyer_nick = value; }
            get { return _buyer_nick; }
        }
        /// <summary>
        /// 预约取货开始时间
        /// </summary>
        public DateTime delivery_start
        {
            set { _delivery_start = value; }
            get { return _delivery_start; }
        }
        /// <summary>
        /// 预约取货结束时间
        /// </summary>
        public DateTime delivery_end
        {
            set { _delivery_end = value; }
            get { return _delivery_end; }
        }
        /// <summary>
        /// 运单号
        /// </summary>
        public string out_sid
        {
            set { _out_sid = value; }
            get { return _out_sid; }
        }
        /// <summary>
        /// 货物名称
        /// </summary>
        public string item_title
        {
            set { _item_title = value; }
            get { return _item_title; }
        }
        /// <summary>
        /// 收件人
        /// </summary>
        public string receiver_name
        {
            set { _receiver_name = value; }
            get { return _receiver_name; }
        }
        /// <summary>
        /// 收件人电话
        /// </summary>
        public string receiver_phone
        {
            set { _receiver_phone = value; }
            get { return _receiver_phone; }
        }
        /// <summary>
        /// 收件人手机号
        /// </summary>
        public string receiver_mobile
        {
            set { _receiver_mobile = value; }
            get { return _receiver_mobile; }
        }
        /// <summary>
        /// 状态
        /// </summary>
        public string status
        {
            set { _status = value; }
            get { return _status; }
        }
        /// <summary>
        /// 物流方式
        /// </summary>
        public string type
        {
            set { _type = value; }
            get { return _type; }
        }
        /// <summary>
        /// 谁承担运费
        /// </summary>
        public string freight_payer
        {
            set { _freight_payer = value; }
            get { return _freight_payer; }
        }
        /// <summary>
        /// 是否确认发货
        /// </summary>
        public string seller_confirm
        {
            set { _seller_confirm = value; }
            get { return _seller_confirm; }
        }
        /// <summary>
        /// 物流公司名称
        /// </summary>
        public string company_name
        {
            set { _company_name = value; }
            get { return _company_name; }
        }
        /// <summary>
        /// 发货是否成功
        /// </summary>
        public bool is_success
        {
            set { _is_success = value; }
            get { return _is_success; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime created
        {
            set { _created = value; }
            get { return _created; }
        }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime modified
        {
            set { _modified = value; }
            get { return _modified; }
        }
        #endregion Model
    }
}
