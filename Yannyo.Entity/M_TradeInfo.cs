using System;
namespace Yannyo.Entity
{
	/// <summary>
	/// ʵ����M_TradeInfo ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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
		/// ���ױ��
		/// </summary>
		public int m_TradeInfoID
		{
			set{ _m_tradeinfoid=value;}
			get{return _m_tradeinfoid;}
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
		/// ���׽���ʱ��
		/// </summary>
		public DateTime end_time
		{
			set{ _end_time=value;}
			get{return _end_time;}
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
		/// ���ױ���
		/// </summary>
		public string title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// ���������б�
		/// </summary>
		public string type
		{
			set{ _type=value;}
			get{return _type;}
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
		/// ��Ʒ���
		/// </summary>
		public long num_iid
		{
			set{ _num_iid=value;}
			get{return _num_iid;}
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
		/// ��ƷͼƬ��ַ
		/// </summary>
		public string pic_path
		{
			set{ _pic_path=value;}
			get{return _pic_path;}
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
		/// ���ױ��
		/// </summary>
		public long tid
		{
			set{ _tid=value;}
			get{return _tid;}
		}
		/// <summary>
		/// �������
		/// </summary>
		public string buyer_message
		{
			set{ _buyer_message=value;}
			get{return _buyer_message;}
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
		/// ֧�������׺�
		/// </summary>
		public string alipay_no
		{
			set{ _alipay_no=value;}
			get{return _alipay_no;}
		}
		/// <summary>
		/// ʵ�����
		/// </summary>
		public decimal payment
		{
			set{ _payment=value;}
			get{return _payment;}
		}
		/// <summary>
		/// ϵͳ�Żݽ��
		/// </summary>
		public decimal discount_fee
		{
			set{ _discount_fee=value;}
			get{return _discount_fee;}
		}
		/// <summary>
		/// �����ֹ��������
		/// </summary>
		public decimal adjust_fee
		{
			set{ _adjust_fee=value;}
			get{return _adjust_fee;}
		}
		/// <summary>
		/// ���׿��յ�ַ
		/// </summary>
		public string snapshot_url
		{
			set{ _snapshot_url=value;}
			get{return _snapshot_url;}
		}
		/// <summary>
		/// ������ϸ��Ϣ
		/// </summary>
		public string snapshot
		{
			set{ _snapshot=value;}
			get{return _snapshot;}
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
		/// �����Ƿ�������
		/// </summary>
		public bool seller_rate
		{
			set{ _seller_rate=value;}
			get{return _seller_rate;}
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
		/// ��ұ�ע
		/// </summary>
		public string buyer_memo
		{
			set{ _buyer_memo=value;}
			get{return _buyer_memo;}
		}
		/// <summary>
		/// ���ұ�ע
		/// </summary>
		public string seller_memo
		{
			set{ _seller_memo=value;}
			get{return _seller_memo;}
		}
		/// <summary>
		/// ���ױ�ע
		/// </summary>
		public string trade_memo
		{
			set{ _trade_memo=value;}
			get{return _trade_memo;}
		}
		/// <summary>
		/// ����ʱ��
		/// </summary>
		public DateTime pay_time
		{
			set{ _pay_time=value;}
			get{return _pay_time;}
		}
		/// <summary>
		/// �����޸�ʱ��
		/// </summary>
		public DateTime modified
		{
			set{ _modified=value;}
			get{return _modified;}
		}
		/// <summary>
		/// ��һ�û���,����Ļ���
		/// </summary>
		public int buyer_obtain_point_fee
		{
			set{ _buyer_obtain_point_fee=value;}
			get{return _buyer_obtain_point_fee;}
		}
		/// <summary>
		/// ���ʹ�û���
		/// </summary>
		public int point_fee
		{
			set{ _point_fee=value;}
			get{return _point_fee;}
		}
		/// <summary>
		/// ���ʵ��ʹ�û���
		/// </summary>
		public int real_point_fee
		{
			set{ _real_point_fee=value;}
			get{return _real_point_fee;}
		}
		/// <summary>
		/// ��Ʒ���
		/// </summary>
		public decimal total_fee
		{
			set{ _total_fee=value;}
			get{return _total_fee;}
		}
		/// <summary>
		/// �ʷ�
		/// </summary>
		public decimal post_fee
		{
			set{ _post_fee=value;}
			get{return _post_fee;}
		}
		/// <summary>
		/// ���֧�����˺�
		/// </summary>
		public string buyer_alipay_no
		{
			set{ _buyer_alipay_no=value;}
			get{return _buyer_alipay_no;}
		}
		/// <summary>
		/// �ջ��˵�����
		/// </summary>
		public string receiver_name
		{
			set{ _receiver_name=value;}
			get{return _receiver_name;}
		}
		/// <summary>
		/// �ջ��˵�����ʡ��
		/// </summary>
		public string receiver_state
		{
			set{ _receiver_state=value;}
			get{return _receiver_state;}
		}
		/// <summary>
		/// �ջ��˵����ڳ���
		/// </summary>
		public string receiver_city
		{
			set{ _receiver_city=value;}
			get{return _receiver_city;}
		}
		/// <summary>
		/// �ջ��˵����ڵ���
		/// </summary>
		public string receiver_district
		{
			set{ _receiver_district=value;}
			get{return _receiver_district;}
		}
		/// <summary>
		/// �ջ��˵���ϸ��ַ
		/// </summary>
		public string receiver_address
		{
			set{ _receiver_address=value;}
			get{return _receiver_address;}
		}
		/// <summary>
		/// �ջ��˵��ʱ�
		/// </summary>
		public string receiver_zip
		{
			set{ _receiver_zip=value;}
			get{return _receiver_zip;}
		}
		/// <summary>
		/// �ջ��˵��ֻ�����
		/// </summary>
		public string receiver_mobile
		{
			set{ _receiver_mobile=value;}
			get{return _receiver_mobile;}
		}
		/// <summary>
		/// �ջ��˵ĵ绰����
		/// </summary>
		public string receiver_phone
		{
			set{ _receiver_phone=value;}
			get{return _receiver_phone;}
		}
		/// <summary>
		/// ���ҷ���ʱ��
		/// </summary>
		public DateTime consign_time
		{
			set{ _consign_time=value;}
			get{return _consign_time;}
		}
		/// <summary>
		/// ����ʼ���ַ
		/// </summary>
		public string buyer_email
		{
			set{ _buyer_email=value;}
			get{return _buyer_email;}
		}
		/// <summary>
		/// ����Ӷ��
		/// </summary>
		public decimal commission_fee
		{
			set{ _commission_fee=value;}
			get{return _commission_fee;}
		}
		/// <summary>
		/// ����֧�����ʺ�
		/// </summary>
		public string seller_alipay_no
		{
			set{ _seller_alipay_no=value;}
			get{return _seller_alipay_no;}
		}
		/// <summary>
		/// �����ֻ�
		/// </summary>
		public string seller_mobile
		{
			set{ _seller_mobile=value;}
			get{return _seller_mobile;}
		}
		/// <summary>
		/// ���ҵ绰
		/// </summary>
		public string seller_phone
		{
			set{ _seller_phone=value;}
			get{return _seller_phone;}
		}
		/// <summary>
		/// ��������
		/// </summary>
		public string seller_name
		{
			set{ _seller_name=value;}
			get{return _seller_name;}
		}
		/// <summary>
		/// �����ʼ���ַ
		/// </summary>
		public string seller_email
		{
			set{ _seller_email=value;}
			get{return _seller_email;}
		}
		/// <summary>
		/// ������ʣ���ȷ���ջ����
		/// </summary>
		public decimal available_confirm_fee
		{
			set{ _available_confirm_fee=value;}
			get{return _available_confirm_fee;}
		}
		/// <summary>
		/// �Ƿ�����ʷ�
		/// </summary>
		public bool has_post_fee
		{
			set{ _has_post_fee=value;}
			get{return _has_post_fee;}
		}
		/// <summary>
		/// ����ʵ���յ���֧���������
		/// </summary>
		public decimal received_payment
		{
			set{ _received_payment=value;}
			get{return _received_payment;}
		}
		/// <summary>
		/// ������������
		/// </summary>
		public decimal cod_fee
		{
			set{ _cod_fee=value;}
			get{return _cod_fee;}
		}
		/// <summary>
		/// ������������״̬
		/// </summary>
		public string cod_status
		{
			set{ _cod_status=value;}
			get{return _cod_status;}
		}
		/// <summary>
		/// ��ʱ����ʱ��
		/// </summary>
		public DateTime timeout_action_time
		{
			set{ _timeout_action_time=value;}
			get{return _timeout_action_time;}
		}
		/// <summary>
		/// �Ƿ���3D�Ա�����
		/// </summary>
		public bool is_3D
		{
			set{ _is_3d=value;}
			get{return _is_3d;}
		}
		/// <summary>
		/// ��ұ�ע����
		/// </summary>
		public int buyer_flag
		{
			set{ _buyer_flag=value;}
			get{return _buyer_flag;}
		}
		/// <summary>
		/// ���ұ�ע����
		/// </summary>
		public int seller_flag
		{
			set{ _seller_flag=value;}
			get{return _seller_flag;}
		}
		/// <summary>
		/// ���״�����ϸ��Ϣ
		/// </summary>
		public string promotion
		{
			set{ _promotion=value;}
			get{return _promotion;}
		}
		/// <summary>
		/// ��Ʊ̧ͷ
		/// </summary>
		public string invoice_name
		{
			set{ _invoice_name=value;}
			get{return _invoice_name;}
		}
		/// <summary>
		/// ������Դ
		/// </summary>
		public string trade_from
		{
			set{ _trade_from=value;}
			get{return _trade_from;}
		}
		/// <summary>
		/// �������׽ӿڳɹ��󣬷��ص�֧��url
		/// </summary>
		public string alipay_url
		{
			set{ _alipay_url=value;}
			get{return _alipay_url;}
		}

        /// <summary>
        /// �����б�
        /// </summary>
        public M_OrderInfo[] orders
        {
            set { _orders = value; }
            get { return _orders; }
        }
        /// <summary>
        /// �Ż������б�
        /// </summary>
        public M_OrderPromotionDetailInfo[] promotion_details
        {
            set { _promotion_details = value; }
            get { return _promotion_details; }
        }
		#endregion Model

	}
}

