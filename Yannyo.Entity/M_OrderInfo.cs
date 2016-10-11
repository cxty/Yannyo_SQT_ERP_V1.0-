using System;
namespace Yannyo.Entity
{
	/// <summary>
	/// 实体类M_OrderInfo 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class M_OrderInfo
	{
		public M_OrderInfo()
		{}
		#region Model
		private int _m_orderinfoid;
		private int _m_configinfoid;
		private int _m_tradeinfoid;
		private long _num_iid;
		private decimal _total_fee;
		private decimal _discount_fee;
		private decimal _adjust_fee;
		private string _sku_id;
		private string _sku_properties_name;
		private string _item_meal_name;
		private int _num;
		private string _title;
		private decimal _price;
		private string _pic_path;
		private string _seller_nick;
		private string _buyer_nick;
		private DateTime _created;
		private string _refund_status;
		private long _oid;
		private string _outer_iid;
		private string _outer_sku_id;
		private decimal _payment;
		private string _status;
		private string _snapshot_url;
		private string _snapshot;
		private DateTime _timeout_action_time;
		private bool _buyer_rate;
		private bool _seller_rate;
		private long _refund_id;
		private string _seller_type;
		private DateTime _modified;
		private long _cid;
		private bool _is_oversold;
		/// <summary>
		/// 订单系统编号
		/// </summary>
		public int m_OrderInfoID
		{
			set{ _m_orderinfoid=value;}
			get{return _m_orderinfoid;}
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
		/// 所属交易编号
		/// </summary>
		public int m_TradeInfoID
		{
			set{ _m_tradeinfoid=value;}
			get{return _m_tradeinfoid;}
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
		/// 应付金额
		/// </summary>
		public decimal total_fee
		{
			set{ _total_fee=value;}
			get{return _total_fee;}
		}
		/// <summary>
		/// 订单优惠金额
		/// </summary>
		public decimal discount_fee
		{
			set{ _discount_fee=value;}
			get{return _discount_fee;}
		}
		/// <summary>
		/// 手工调整金额
		/// </summary>
		public decimal adjust_fee
		{
			set{ _adjust_fee=value;}
			get{return _adjust_fee;}
		}
		/// <summary>
		/// 商品的最小库存单位Sku的id
		/// </summary>
		public string sku_id
		{
			set{ _sku_id=value;}
			get{return _sku_id;}
		}
		/// <summary>
		/// SKU的值
		/// </summary>
		public string sku_properties_name
		{
			set{ _sku_properties_name=value;}
			get{return _sku_properties_name;}
		}
		/// <summary>
		/// 套餐的值
		/// </summary>
		public string item_meal_name
		{
			set{ _item_meal_name=value;}
			get{return _item_meal_name;}
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
		/// 商品标题
		/// </summary>
		public string title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 价格
		/// </summary>
		public decimal price
		{
			set{ _price=value;}
			get{return _price;}
		}
		/// <summary>
		/// 图片
		/// </summary>
		public string pic_path
		{
			set{ _pic_path=value;}
			get{return _pic_path;}
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
		/// 交易创建时间
		/// </summary>
		public DateTime created
		{
			set{ _created=value;}
			get{return _created;}
		}
		/// <summary>
		/// 退款状态
		/// </summary>
		public string refund_status
		{
			set{ _refund_status=value;}
			get{return _refund_status;}
		}
		/// <summary>
		/// 子订单编号
		/// </summary>
		public long oid
		{
			set{ _oid=value;}
			get{return _oid;}
		}
		/// <summary>
		/// 商家外部编码
		/// </summary>
		public string outer_iid
		{
			set{ _outer_iid=value;}
			get{return _outer_iid;}
		}
		/// <summary>
		/// 外部网店自己定义的Sku编号
		/// </summary>
		public string outer_sku_id
		{
			set{ _outer_sku_id=value;}
			get{return _outer_sku_id;}
		}
		/// <summary>
		/// 买家实付金额
		/// </summary>
		public decimal payment
		{
			set{ _payment=value;}
			get{return _payment;}
		}
		/// <summary>
		/// 订单状态
		/// </summary>
		public string status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// 订单快照URL
		/// </summary>
		public string snapshot_url
		{
			set{ _snapshot_url=value;}
			get{return _snapshot_url;}
		}
		/// <summary>
		/// 订单快照详细信息
		/// </summary>
		public string snapshot
		{
			set{ _snapshot=value;}
			get{return _snapshot;}
		}
		/// <summary>
		/// 订单超时到期时间
		/// </summary>
		public DateTime timeout_action_time
		{
			set{ _timeout_action_time=value;}
			get{return _timeout_action_time;}
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
		/// 卖家是否已平价
		/// </summary>
		public bool seller_rate
		{
			set{ _seller_rate=value;}
			get{return _seller_rate;}
		}
		/// <summary>
		/// 退款中的退款ID
		/// </summary>
		public long refund_id
		{
			set{ _refund_id=value;}
			get{return _refund_id;}
		}
		/// <summary>
		/// 卖家类型
		/// </summary>
		public string seller_type
		{
			set{ _seller_type=value;}
			get{return _seller_type;}
		}
		/// <summary>
		/// 更新时间
		/// </summary>
		public DateTime modified
		{
			set{ _modified=value;}
			get{return _modified;}
		}
		/// <summary>
		/// 交易商品对应的类目ID
		/// </summary>
		public long cid
		{
			set{ _cid=value;}
			get{return _cid;}
		}
		/// <summary>
		/// 是否超卖
		/// </summary>
		public bool is_oversold
		{
			set{ _is_oversold=value;}
			get{return _is_oversold;}
		}
		#endregion Model

	}
}

