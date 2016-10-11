using System;
namespace Yannyo.Entity
{
	/// <summary>
	/// ʵ����M_OrderRefundInfo ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class M_OrderRefundInfo
	{
		public M_OrderRefundInfo()
		{}
		#region Model
		private int _m_orderrefundinfoid;
		private int _m_configinfoid;
		private long _num_iid;
		private long _refund_id;
		private long _tid;
		private long _oid;
		private string _alipay_no;
		private decimal _total_fee;
		private string _buyer_nick;
		private string _seller_nick;
		private DateTime _created;
		private DateTime _modified;
		private string _order_status;
		private string _status;
		private string _good_status;
		private bool _has_good_return;
		private decimal _refund_fee;
		private decimal _payment;
		private string _reason;
		private string _m_desc;
		private string _title;
		private decimal _price;
		private int _num;
		private DateTime _good_return_time;
		private string _company_name;
		private string _sid;
		private string _address;
		private string _shipping_type;

        private M_TimeOutInfo _refund_remind_timeout;
		/// <summary>
		/// �˿���Ϣ���
		/// </summary>
		public int m_OrderRefundInfoID
		{
			set{ _m_orderrefundinfoid=value;}
			get{return _m_orderrefundinfoid;}
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
		/// �˿���Ʒ���
		/// </summary>
		public long num_iid
		{
			set{ _num_iid=value;}
			get{return _num_iid;}
		}
		/// <summary>
		/// �˿��
		/// </summary>
		public long refund_id
		{
			set{ _refund_id=value;}
			get{return _refund_id;}
		}
		/// <summary>
		/// ���꽻�׵���
		/// </summary>
		public long tid
		{
			set{ _tid=value;}
			get{return _tid;}
		}
		/// <summary>
		/// �Ӷ�����
		/// </summary>
		public long oid
		{
			set{ _oid=value;}
			get{return _oid;}
		}
		/// <summary>
		/// ֧�������׺�
		/// </summary>
		public string alipay_no
		{
			set{ _alipay_no=value;}
			get{return _alipay_no;}
		}
		/// <summary>
		/// �����ܽ��
		/// </summary>
		public decimal total_fee
		{
			set{ _total_fee=value;}
			get{return _total_fee;}
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
		/// �����ǳ�
		/// </summary>
		public string seller_nick
		{
			set{ _seller_nick=value;}
			get{return _seller_nick;}
		}
		/// <summary>
		/// �˿�����ʱ��
		/// </summary>
		public DateTime created
		{
			set{ _created=value;}
			get{return _created;}
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
		/// �˿��Ӧ�Ķ�������״̬
		/// </summary>
		public string order_status
		{
			set{ _order_status=value;}
			get{return _order_status;}
		}
		/// <summary>
		/// �˿�״̬
		/// </summary>
		public string status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// ����״̬
		/// </summary>
		public string good_status
		{
			set{ _good_status=value;}
			get{return _good_status;}
		}
		/// <summary>
		/// ����Ƿ���Ҫ�˻�
		/// </summary>
		public bool has_good_return
		{
			set{ _has_good_return=value;}
			get{return _has_good_return;}
		}
		/// <summary>
		/// �˻����
		/// </summary>
		public decimal refund_fee
		{
			set{ _refund_fee=value;}
			get{return _refund_fee;}
		}
		/// <summary>
		/// ֧�������ҵĽ��
		/// </summary>
		public decimal payment
		{
			set{ _payment=value;}
			get{return _payment;}
		}
		/// <summary>
		/// �˿�ԭ��
		/// </summary>
		public string reason
		{
			set{ _reason=value;}
			get{return _reason;}
		}
		/// <summary>
		/// �˿�˵��
		/// </summary>
		public string m_desc
		{
			set{ _m_desc=value;}
			get{return _m_desc;}
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
		/// ��Ʒ�۸�
		/// </summary>
		public decimal price
		{
			set{ _price=value;}
			get{return _price;}
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
		/// �˻�ʱ��
		/// </summary>
		public DateTime good_return_time
		{
			set{ _good_return_time=value;}
			get{return _good_return_time;}
		}
		/// <summary>
		/// ������˾����
		/// </summary>
		public string company_name
		{
			set{ _company_name=value;}
			get{return _company_name;}
		}
		/// <summary>
		/// �˻��˵���
		/// </summary>
		public string sid
		{
			set{ _sid=value;}
			get{return _sid;}
		}
		/// <summary>
		/// �����ջ���ַ
		/// </summary>
		public string address
		{
			set{ _address=value;}
			get{return _address;}
		}
		/// <summary>
		/// ������ʽ
		/// </summary>
		public string shipping_type
		{
			set{ _shipping_type=value;}
			get{return _shipping_type;}
		}
        /// <summary>
        /// �˿ʱ�ṹ
        /// </summary>
        public M_TimeOutInfo refund_remind_timeout
        {
            set { _refund_remind_timeout = value; }
            get { return _refund_remind_timeout; }
        }

		#endregion Model

	}
}

