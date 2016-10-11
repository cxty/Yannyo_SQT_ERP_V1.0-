using System;
namespace Yannyo.Entity
{
	/// <summary>
	/// ʵ����M_OrderInfo ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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
		/// ����ϵͳ���
		/// </summary>
		public int m_OrderInfoID
		{
			set{ _m_orderinfoid=value;}
			get{return _m_orderinfoid;}
		}
		/// <summary>
		/// ����ϵͳ���
		/// </summary>
		public int m_ConfigInfoID
		{
			set{ _m_configinfoid=value;}
			get{return _m_configinfoid;}
		}
		/// <summary>
		/// �������ױ��
		/// </summary>
		public int m_TradeInfoID
		{
			set{ _m_tradeinfoid=value;}
			get{return _m_tradeinfoid;}
		}
		/// <summary>
		/// ��Ʒ���
		/// </summary>
		public long num_iid
		{
			set{ _num_iid=value;}
			get{return _num_iid;}
		}
		/// <summary>
		/// Ӧ�����
		/// </summary>
		public decimal total_fee
		{
			set{ _total_fee=value;}
			get{return _total_fee;}
		}
		/// <summary>
		/// �����Żݽ��
		/// </summary>
		public decimal discount_fee
		{
			set{ _discount_fee=value;}
			get{return _discount_fee;}
		}
		/// <summary>
		/// �ֹ��������
		/// </summary>
		public decimal adjust_fee
		{
			set{ _adjust_fee=value;}
			get{return _adjust_fee;}
		}
		/// <summary>
		/// ��Ʒ����С��浥λSku��id
		/// </summary>
		public string sku_id
		{
			set{ _sku_id=value;}
			get{return _sku_id;}
		}
		/// <summary>
		/// SKU��ֵ
		/// </summary>
		public string sku_properties_name
		{
			set{ _sku_properties_name=value;}
			get{return _sku_properties_name;}
		}
		/// <summary>
		/// �ײ͵�ֵ
		/// </summary>
		public string item_meal_name
		{
			set{ _item_meal_name=value;}
			get{return _item_meal_name;}
		}
		/// <summary>
		/// ����
		/// </summary>
		public int num
		{
			set{ _num=value;}
			get{return _num;}
		}
		/// <summary>
		/// ��Ʒ����
		/// </summary>
		public string title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// �۸�
		/// </summary>
		public decimal price
		{
			set{ _price=value;}
			get{return _price;}
		}
		/// <summary>
		/// ͼƬ
		/// </summary>
		public string pic_path
		{
			set{ _pic_path=value;}
			get{return _pic_path;}
		}
		/// <summary>
		/// �����ǳ�
		/// </summary>
		public string seller_nick
		{
			set{ _seller_nick=value;}
			get{return _seller_nick;}
		}
		/// <summary>
		/// ����ǳ�
		/// </summary>
		public string buyer_nick
		{
			set{ _buyer_nick=value;}
			get{return _buyer_nick;}
		}
		/// <summary>
		/// ���״���ʱ��
		/// </summary>
		public DateTime created
		{
			set{ _created=value;}
			get{return _created;}
		}
		/// <summary>
		/// �˿�״̬
		/// </summary>
		public string refund_status
		{
			set{ _refund_status=value;}
			get{return _refund_status;}
		}
		/// <summary>
		/// �Ӷ������
		/// </summary>
		public long oid
		{
			set{ _oid=value;}
			get{return _oid;}
		}
		/// <summary>
		/// �̼��ⲿ����
		/// </summary>
		public string outer_iid
		{
			set{ _outer_iid=value;}
			get{return _outer_iid;}
		}
		/// <summary>
		/// �ⲿ�����Լ������Sku���
		/// </summary>
		public string outer_sku_id
		{
			set{ _outer_sku_id=value;}
			get{return _outer_sku_id;}
		}
		/// <summary>
		/// ���ʵ�����
		/// </summary>
		public decimal payment
		{
			set{ _payment=value;}
			get{return _payment;}
		}
		/// <summary>
		/// ����״̬
		/// </summary>
		public string status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// ��������URL
		/// </summary>
		public string snapshot_url
		{
			set{ _snapshot_url=value;}
			get{return _snapshot_url;}
		}
		/// <summary>
		/// ����������ϸ��Ϣ
		/// </summary>
		public string snapshot
		{
			set{ _snapshot=value;}
			get{return _snapshot;}
		}
		/// <summary>
		/// ������ʱ����ʱ��
		/// </summary>
		public DateTime timeout_action_time
		{
			set{ _timeout_action_time=value;}
			get{return _timeout_action_time;}
		}
		/// <summary>
		/// ����Ƿ�������
		/// </summary>
		public bool buyer_rate
		{
			set{ _buyer_rate=value;}
			get{return _buyer_rate;}
		}
		/// <summary>
		/// �����Ƿ���ƽ��
		/// </summary>
		public bool seller_rate
		{
			set{ _seller_rate=value;}
			get{return _seller_rate;}
		}
		/// <summary>
		/// �˿��е��˿�ID
		/// </summary>
		public long refund_id
		{
			set{ _refund_id=value;}
			get{return _refund_id;}
		}
		/// <summary>
		/// ��������
		/// </summary>
		public string seller_type
		{
			set{ _seller_type=value;}
			get{return _seller_type;}
		}
		/// <summary>
		/// ����ʱ��
		/// </summary>
		public DateTime modified
		{
			set{ _modified=value;}
			get{return _modified;}
		}
		/// <summary>
		/// ������Ʒ��Ӧ����ĿID
		/// </summary>
		public long cid
		{
			set{ _cid=value;}
			get{return _cid;}
		}
		/// <summary>
		/// �Ƿ���
		/// </summary>
		public bool is_oversold
		{
			set{ _is_oversold=value;}
			get{return _is_oversold;}
		}
		#endregion Model

	}
}

