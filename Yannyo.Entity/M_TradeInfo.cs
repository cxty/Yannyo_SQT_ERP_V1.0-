using System;
namespace Yannyo.Entity
{
	/// <summary>
	/// 实体类M_TradeInfo 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class M_TradeInfo
	{
		public M_TradeInfo()
		{}
		#region Model
		private int _m_tradeinfoid;
		private int _m_configinfoid;
		private DateTime _end_time;
		private string _seller_nick;
		private string _buyer_nick;
		private string _title;
		private string _type;
		private DateTime _created;
		private long _num_iid;
		private decimal _price;
		private string _pic_path;
		private int _num;
		private long _tid;
		private string _buyer_message;
		private string _shipping_type;
		private string _alipay_no;
		private decimal _payment;
		private decimal _discount_fee;
		private decimal _adjust_fee;
		private string _snapshot_url;
		private string _snapshot;
		private string _status;
		private bool _seller_rate;
		private bool _buyer_rate;
		private string _buyer_memo;
		private string _seller_memo;
		private string _trade_memo;
		private DateTime _pay_time;
		private DateTime _modified;
		private int _buyer_obtain_point_fee;
		private int _point_fee;
		private int _real_point_fee;
		private decimal _total_fee;
		private decimal _post_fee;
		private string _buyer_alipay_no;
		private string _receiver_name;
		private string _receiver_state;
		private string _receiver_city;
		private string _receiver_district;
		private string _receiver_address;
		private string _receiver_zip;
		private string _receiver_mobile;
		private string _receiver_phone;
		private DateTime _consign_time;
		private string _buyer_email;
		private decimal _commission_fee;
		private string _seller_alipay_no;
		private string _seller_mobile;
		private string _seller_phone;
		private string _seller_name;
		private string _seller_email;
		private decimal _available_confirm_fee;
		private bool _has_post_fee;
		private decimal _received_payment;
		private decimal _cod_fee;
		private string _cod_status;
		private DateTime _timeout_action_time;
		private bool _is_3d;
		private int _buyer_flag;
		private int _seller_flag;
		private string _promotion;
		private string _invoice_name;
		private string _trade_from;
		private string _alipay_url;

        private M_OrderInfo[] _orders;
        private M_OrderPromotionDetailInfo[] _promotion_details;

		/// <summary>
		/// 交易编号
		/// </summary>
		public int m_TradeInfoID
		{
			set{ _m_tradeinfoid=value;}
			get{return _m_tradeinfoid;}
		}
		/// <summary>
		/// 网店系统编号
		/// </summary>
		public int m_ConfigInfoID
		{
			set{ _m_configinfoid=value;}
			get{return _m_configinfoid;}
		}
		/// <summary>
		/// 交易结束时间
		/// </summary>
		public DateTime end_time
		{
			set{ _end_time=value;}
			get{return _end_time;}
		}
		/// <summary>
		/// 卖家昵称
		/// </summary>
		public string seller_nick
		{
			set{ _seller_nick=value;}
			get{return _seller_nick;}
		}
		/// <summary>
		/// 买家昵称
		/// </summary>
		public string buyer_nick
		{
			set{ _buyer_nick=value;}
			get{return _buyer_nick;}
		}
		/// <summary>
		/// 交易标题
		/// </summary>
		public string title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 交易类型列表
		/// </summary>
		public string type
		{
			set{ _type=value;}
			get{return _type;}
		}
		/// <summary>
		/// 交易创建时间
		/// </summary>
		public DateTime created
		{
			set{ _created=value;}
			get{return _created;}
		}
		/// <summary>
		/// 商品编号
		/// </summary>
		public long num_iid
		{
			set{ _num_iid=value;}
			get{return _num_iid;}
		}
		/// <summary>
		/// 商品价格
		/// </summary>
		public decimal price
		{
			set{ _price=value;}
			get{return _price;}
		}
		/// <summary>
		/// 商品图片地址
		/// </summary>
		public string pic_path
		{
			set{ _pic_path=value;}
			get{return _pic_path;}
		}
		/// <summary>
		/// 数量
		/// </summary>
		public int num
		{
			set{ _num=value;}
			get{return _num;}
		}
		/// <summary>
		/// 交易编号
		/// </summary>
		public long tid
		{
			set{ _tid=value;}
			get{return _tid;}
		}
		/// <summary>
		/// 买家留言
		/// </summary>
		public string buyer_message
		{
			set{ _buyer_message=value;}
			get{return _buyer_message;}
		}
		/// <summary>
		/// 物流方式
		/// </summary>
		public string shipping_type
		{
			set{ _shipping_type=value;}
			get{return _shipping_type;}
		}
		/// <summary>
		/// 支付宝交易号
		/// </summary>
		public string alipay_no
		{
			set{ _alipay_no=value;}
			get{return _alipay_no;}
		}
		/// <summary>
		/// 实付金额
		/// </summary>
		public decimal payment
		{
			set{ _payment=value;}
			get{return _payment;}
		}
		/// <summary>
		/// 系统优惠金额
		/// </summary>
		public decimal discount_fee
		{
			set{ _discount_fee=value;}
			get{return _discount_fee;}
		}
		/// <summary>
		/// 卖家手工调整金额
		/// </summary>
		public decimal adjust_fee
		{
			set{ _adjust_fee=value;}
			get{return _adjust_fee;}
		}
		/// <summary>
		/// 交易快照地址
		/// </summary>
		public string snapshot_url
		{
			set{ _snapshot_url=value;}
			get{return _snapshot_url;}
		}
		/// <summary>
		/// 快照详细信息
		/// </summary>
		public string snapshot
		{
			set{ _snapshot=value;}
			get{return _snapshot;}
		}
		/// <summary>
		/// 交易状态
		/// </summary>
		public string status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// 卖家是否已评价
		/// </summary>
		public bool seller_rate
		{
			set{ _seller_rate=value;}
			get{return _seller_rate;}
		}
		/// <summary>
		/// 买家是否已评价
		/// </summary>
		public bool buyer_rate
		{
			set{ _buyer_rate=value;}
			get{return _buyer_rate;}
		}
		/// <summary>
		/// 买家备注
		/// </summary>
		public string buyer_memo
		{
			set{ _buyer_memo=value;}
			get{return _buyer_memo;}
		}
		/// <summary>
		/// 卖家备注
		/// </summary>
		public string seller_memo
		{
			set{ _seller_memo=value;}
			get{return _seller_memo;}
		}
		/// <summary>
		/// 交易备注
		/// </summary>
		public string trade_memo
		{
			set{ _trade_memo=value;}
			get{return _trade_memo;}
		}
		/// <summary>
		/// 付款时间
		/// </summary>
		public DateTime pay_time
		{
			set{ _pay_time=value;}
			get{return _pay_time;}
		}
		/// <summary>
		/// 交易修改时间
		/// </summary>
		public DateTime modified
		{
			set{ _modified=value;}
			get{return _modified;}
		}
		/// <summary>
		/// 买家获得积分,返点的积分
		/// </summary>
		public int buyer_obtain_point_fee
		{
			set{ _buyer_obtain_point_fee=value;}
			get{return _buyer_obtain_point_fee;}
		}
		/// <summary>
		/// 买家使用积分
		/// </summary>
		public int point_fee
		{
			set{ _point_fee=value;}
			get{return _point_fee;}
		}
		/// <summary>
		/// 买家实际使用积分
		/// </summary>
		public int real_point_fee
		{
			set{ _real_point_fee=value;}
			get{return _real_point_fee;}
		}
		/// <summary>
		/// 商品金额
		/// </summary>
		public decimal total_fee
		{
			set{ _total_fee=value;}
			get{return _total_fee;}
		}
		/// <summary>
		/// 邮费
		/// </summary>
		public decimal post_fee
		{
			set{ _post_fee=value;}
			get{return _post_fee;}
		}
		/// <summary>
		/// 买家支付宝账号
		/// </summary>
		public string buyer_alipay_no
		{
			set{ _buyer_alipay_no=value;}
			get{return _buyer_alipay_no;}
		}
		/// <summary>
		/// 收货人的姓名
		/// </summary>
		public string receiver_name
		{
			set{ _receiver_name=value;}
			get{return _receiver_name;}
		}
		/// <summary>
		/// 收货人的所在省份
		/// </summary>
		public string receiver_state
		{
			set{ _receiver_state=value;}
			get{return _receiver_state;}
		}
		/// <summary>
		/// 收货人的所在城市
		/// </summary>
		public string receiver_city
		{
			set{ _receiver_city=value;}
			get{return _receiver_city;}
		}
		/// <summary>
		/// 收货人的所在地区
		/// </summary>
		public string receiver_district
		{
			set{ _receiver_district=value;}
			get{return _receiver_district;}
		}
		/// <summary>
		/// 收货人的详细地址
		/// </summary>
		public string receiver_address
		{
			set{ _receiver_address=value;}
			get{return _receiver_address;}
		}
		/// <summary>
		/// 收货人的邮编
		/// </summary>
		public string receiver_zip
		{
			set{ _receiver_zip=value;}
			get{return _receiver_zip;}
		}
		/// <summary>
		/// 收货人的手机号码
		/// </summary>
		public string receiver_mobile
		{
			set{ _receiver_mobile=value;}
			get{return _receiver_mobile;}
		}
		/// <summary>
		/// 收货人的电话号码
		/// </summary>
		public string receiver_phone
		{
			set{ _receiver_phone=value;}
			get{return _receiver_phone;}
		}
		/// <summary>
		/// 卖家发货时间
		/// </summary>
		public DateTime consign_time
		{
			set{ _consign_time=value;}
			get{return _consign_time;}
		}
		/// <summary>
		/// 买家邮件地址
		/// </summary>
		public string buyer_email
		{
			set{ _buyer_email=value;}
			get{return _buyer_email;}
		}
		/// <summary>
		/// 交易佣金
		/// </summary>
		public decimal commission_fee
		{
			set{ _commission_fee=value;}
			get{return _commission_fee;}
		}
		/// <summary>
		/// 卖家支付宝帐号
		/// </summary>
		public string seller_alipay_no
		{
			set{ _seller_alipay_no=value;}
			get{return _seller_alipay_no;}
		}
		/// <summary>
		/// 卖家手机
		/// </summary>
		public string seller_mobile
		{
			set{ _seller_mobile=value;}
			get{return _seller_mobile;}
		}
		/// <summary>
		/// 卖家电话
		/// </summary>
		public string seller_phone
		{
			set{ _seller_phone=value;}
			get{return _seller_phone;}
		}
		/// <summary>
		/// 卖家姓名
		/// </summary>
		public string seller_name
		{
			set{ _seller_name=value;}
			get{return _seller_name;}
		}
		/// <summary>
		/// 卖家邮件地址
		/// </summary>
		public string seller_email
		{
			set{ _seller_email=value;}
			get{return _seller_email;}
		}
		/// <summary>
		/// 交易中剩余的确认收货金额
		/// </summary>
		public decimal available_confirm_fee
		{
			set{ _available_confirm_fee=value;}
			get{return _available_confirm_fee;}
		}
		/// <summary>
		/// 是否包含邮费
		/// </summary>
		public bool has_post_fee
		{
			set{ _has_post_fee=value;}
			get{return _has_post_fee;}
		}
		/// <summary>
		/// 卖家实际收到的支付宝打款金额
		/// </summary>
		public decimal received_payment
		{
			set{ _received_payment=value;}
			get{return _received_payment;}
		}
		/// <summary>
		/// 货到付款服务费
		/// </summary>
		public decimal cod_fee
		{
			set{ _cod_fee=value;}
			get{return _cod_fee;}
		}
		/// <summary>
		/// 货到付款物流状态
		/// </summary>
		public string cod_status
		{
			set{ _cod_status=value;}
			get{return _cod_status;}
		}
		/// <summary>
		/// 超时到期时间
		/// </summary>
		public DateTime timeout_action_time
		{
			set{ _timeout_action_time=value;}
			get{return _timeout_action_time;}
		}
		/// <summary>
		/// 是否是3D淘宝交易
		/// </summary>
		public bool is_3D
		{
			set{ _is_3d=value;}
			get{return _is_3d;}
		}
		/// <summary>
		/// 买家备注旗帜
		/// </summary>
		public int buyer_flag
		{
			set{ _buyer_flag=value;}
			get{return _buyer_flag;}
		}
		/// <summary>
		/// 卖家备注旗帜
		/// </summary>
		public int seller_flag
		{
			set{ _seller_flag=value;}
			get{return _seller_flag;}
		}
		/// <summary>
		/// 交易促销详细信息
		/// </summary>
		public string promotion
		{
			set{ _promotion=value;}
			get{return _promotion;}
		}
		/// <summary>
		/// 发票抬头
		/// </summary>
		public string invoice_name
		{
			set{ _invoice_name=value;}
			get{return _invoice_name;}
		}
		/// <summary>
		/// 交易来源
		/// </summary>
		public string trade_from
		{
			set{ _trade_from=value;}
			get{return _trade_from;}
		}
		/// <summary>
		/// 创建交易接口成功后，返回的支付url
		/// </summary>
		public string alipay_url
		{
			set{ _alipay_url=value;}
			get{return _alipay_url;}
		}

        /// <summary>
        /// 订单列表
        /// </summary>
        public M_OrderInfo[] orders
        {
            set { _orders = value; }
            get { return _orders; }
        }
        /// <summary>
        /// 优惠详情列表
        /// </summary>
        public M_OrderPromotionDetailInfo[] promotion_details
        {
            set { _promotion_details = value; }
            get { return _promotion_details; }
        }
		#endregion Model

	}
}

