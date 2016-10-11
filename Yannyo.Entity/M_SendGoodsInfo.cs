using System;


namespace Yannyo.Entity
{
   public  class M_SendGoodsInfo
    {
        private int _m_sendgoodsid;
        private int _m_configinfoid;
        private int _orderid;
        private string _m_tradeinfoid;
        private string _receiver_name;
        private string _receiver_state;
        private string _receiver_city;
        private string _receiver_district;
        private string _receiver_address;
        private string _receiver_zip;
        private string _receiver_mobile;
        private string _receiver_phone;
        private string _from_name;
        private string _from_state;
        private string _from_city;
        private string _from_district;
        private string _from_address;
        private string _from_zip;
        private string _from_mobile;
        private string _from_phone;
        private int _mexpname;
        private string _mexpno;
        private string _mmemo;
        private int _mstate;
        private DateTime _mappendtime = DateTime.Now;
        /// <summary>
        /// 发货单编号
        /// </summary>
        public int m_SendGoodsID
        {
            set { _m_sendgoodsid = value; }
            get { return _m_sendgoodsid; }
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
        /// 发货单号
        /// </summary>
        public int OrderID
        {
            set { _orderid = value; }
            get { return _orderid; }
        }
        /// <summary>
        /// 交易单号
        /// </summary>
        public string m_TradeInfoID
        {
            set { _m_tradeinfoid = value; }
            get { return _m_tradeinfoid; }
        }
        /// <summary>
        /// 收货人姓名
        /// </summary>
        public string receiver_name
        {
            set { _receiver_name = value; }
            get { return _receiver_name; }
        }
        /// <summary>
        /// 收货人省份
        /// </summary>
        public string receiver_state
        {
            set { _receiver_state = value; }
            get { return _receiver_state; }
        }
        /// <summary>
        /// 收货人城市
        /// </summary>
        public string receiver_city
        {
            set { _receiver_city = value; }
            get { return _receiver_city; }
        }
        /// <summary>
        /// 收货人地区
        /// </summary>
        public string receiver_district
        {
            set { _receiver_district = value; }
            get { return _receiver_district; }
        }
        /// <summary>
        /// 收货人地址
        /// </summary>
        public string receiver_address
        {
            set { _receiver_address = value; }
            get { return _receiver_address; }
        }
        /// <summary>
        /// 收货人邮编
        /// </summary>
        public string receiver_zip
        {
            set { _receiver_zip = value; }
            get { return _receiver_zip; }
        }
        /// <summary>
        /// 收货人手机
        /// </summary>
        public string receiver_mobile
        {
            set { _receiver_mobile = value; }
            get { return _receiver_mobile; }
        }
        /// <summary>
        /// 收货人电话
        /// </summary>
        public string receiver_phone
        {
            set { _receiver_phone = value; }
            get { return _receiver_phone; }
        }
        /// <summary>
        /// 发件人姓名
        /// </summary>
        public string from_name
        {
            set { _from_name = value; }
            get { return _from_name; }
        }
        /// <summary>
        /// 发件人省份
        /// </summary>
        public string from_state
        {
            set { _from_state = value; }
            get { return _from_state; }
        }
        /// <summary>
        /// 发件人城市
        /// </summary>
        public string from_city
        {
            set { _from_city = value; }
            get { return _from_city; }
        }
        /// <summary>
        /// 发件人地区
        /// </summary>
        public string from_district
        {
            set { _from_district = value; }
            get { return _from_district; }
        }
        /// <summary>
        /// 发件人地址
        /// </summary>
        public string from_address
        {
            set { _from_address = value; }
            get { return _from_address; }
        }
        /// <summary>
        /// 发件人邮编
        /// </summary>
        public string from_zip
        {
            set { _from_zip = value; }
            get { return _from_zip; }
        }
        /// <summary>
        /// 发件人手机
        /// </summary>
        public string from_mobile
        {
            set { _from_mobile = value; }
            get { return _from_mobile; }
        }
        /// <summary>
        /// 发件人电话
        /// </summary>
        public string from_phone
        {
            set { _from_phone = value; }
            get { return _from_phone; }
        }
        /// <summary>
        /// 物流公司
        /// </summary>
        public int mExpName
        {
            set { _mexpname = value; }
            get { return _mexpname; }
        }
        /// <summary>
        /// 运单号
        /// </summary>
        public string mExpNO
        {
            set { _mexpno = value; }
            get { return _mexpno; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string mMemo
        {
            set { _mmemo = value; }
            get { return _mmemo; }
        }
        /// <summary>
        /// 状态
        /// </summary>
        public int mState
        {
            set { _mstate = value; }
            get { return _mstate; }
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
