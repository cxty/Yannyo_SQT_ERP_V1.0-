using System;
namespace Yannyo.Entity
{
	/// <summary>
	/// ʵ����M_UserInfo ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class M_UserInfo
	{
		public M_UserInfo()
		{}
		#region Model
		private int _m_userinfoid;
		private int _m_configinfoid;
		private Int64 _user_id;
		private string _uid;
		private string _nick;
		private string _sex;
		private DateTime _created;
		private DateTime _last_visit;
		private string _birthday;
		private string _type;
		private bool _has_more_pic;
		private int _item_img_num;
		private int _item_img_size;
		private int _prop_img_num;
		private int _prop_img_sizec;
		private string _auto_repost;
		private string _promoted_type;
		private string _status;
		private string _alipay_bind;
		private int _consumer_protection;
		private string _alipay_account;
		private string _alipay_no;
		private string _email;
		private bool _magazine_subscribe;
		private string _vertical_market;
		private string _avatar;
		private bool _online_gaming;
		private DateTime _m_appendtime;
		private DateTime _m_updatetime;

        public M_CreditInfo _buyer_credit;
        public M_CreditInfo _seller_credit;
        public M_LocationInfo _location;
		/// <summary>
		/// ϵͳ���
		/// </summary>
		public int m_UserInfoID
		{
			set{ _m_userinfoid=value;}
			get{return _m_userinfoid;}
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
		/// �����û�ϵͳ���
		/// </summary>
		public Int64 user_id
		{
			set{ _user_id=value;}
			get{return _user_id;}
		}
		/// <summary>
		/// �����û�ϵͳ�ڲ����
		/// </summary>
		public string uid
		{
			set{ _uid=value;}
			get{return _uid;}
		}
		/// <summary>
		/// �ǳ�
		/// </summary>
		public string nick
		{
			set{ _nick=value;}
			get{return _nick;}
		}
		/// <summary>
		/// �Ա�
		/// </summary>
		public string sex
		{
			set{ _sex=value;}
			get{return _sex;}
		}
		/// <summary>
		/// �û�ע��ʱ��
		/// </summary>
		public DateTime created
		{
			set{ _created=value;}
			get{return _created;}
		}
		/// <summary>
		/// �����¼ʱ��
		/// </summary>
		public DateTime last_visit
		{
			set{ _last_visit=value;}
			get{return _last_visit;}
		}
		/// <summary>
		/// ����
		/// </summary>
		public string birthday
		{
			set{ _birthday=value;}
			get{return _birthday;}
		}
		/// <summary>
		/// �û�����
		/// </summary>
		public string type
		{
			set{ _type=value;}
			get{return _type;}
		}
		/// <summary>
		/// �Ƿ����ͼ����
		/// </summary>
		public bool has_more_pic
		{
			set{ _has_more_pic=value;}
			get{return _has_more_pic;}
		}
		/// <summary>
		/// ���ϴ�ͼƬ����
		/// </summary>
		public int item_img_num
		{
			set{ _item_img_num=value;}
			get{return _item_img_num;}
		}
		/// <summary>
		/// �ϴ�����ͼƬ��С
		/// </summary>
		public int item_img_size
		{
			set{ _item_img_size=value;}
			get{return _item_img_size;}
		}
		/// <summary>
		/// ���ϴ�����ͼƬ����
		/// </summary>
		public int prop_img_num
		{
			set{ _prop_img_num=value;}
			get{return _prop_img_num;}
		}
		/// <summary>
		/// ������������ͼƬ�������
		/// </summary>
		public int prop_img_sizec
		{
			set{ _prop_img_sizec=value;}
			get{return _prop_img_sizec;}
		}
		/// <summary>
		/// �Ƿ�������
		/// </summary>
		public string auto_repost
		{
			set{ _auto_repost=value;}
			get{return _auto_repost;}
		}
		/// <summary>
		/// ����ʵ����֤
		/// </summary>
		public string promoted_type
		{
			set{ _promoted_type=value;}
			get{return _promoted_type;}
		}
		/// <summary>
		/// ״̬
		/// </summary>
		public string status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// ֧������
		/// </summary>
		public string alipay_bind
		{
			set{ _alipay_bind=value;}
			get{return _alipay_bind;}
		}
		/// <summary>
		/// �Ƿ�����
		/// </summary>
		public int consumer_protection
		{
			set{ _consumer_protection=value;}
			get{return _consumer_protection;}
		}
		/// <summary>
		/// ֧�����ʺ�
		/// </summary>
		public string alipay_account
		{
			set{ _alipay_account=value;}
			get{return _alipay_account;}
		}
		/// <summary>
		/// ֧����ID
		/// </summary>
		public string alipay_no
		{
			set{ _alipay_no=value;}
			get{return _alipay_no;}
		}
		/// <summary>
		/// ��ϵ������
		/// </summary>
		public string email
		{
			set{ _email=value;}
			get{return _email;}
		}
		/// <summary>
		/// �Ƿ���������
		/// </summary>
		public bool magazine_subscribe
		{
			set{ _magazine_subscribe=value;}
			get{return _magazine_subscribe;}
		}
		/// <summary>
		/// �û����봹ֱ�г�����
		/// </summary>
		public string vertical_market
		{
			set{ _vertical_market=value;}
			get{return _vertical_market;}
		}
		/// <summary>
		/// ͷ��
		/// </summary>
		public string avatar
		{
			set{ _avatar=value;}
			get{return _avatar;}
		}
		/// <summary>
		/// �Ƿ������û�
		/// </summary>
		public bool online_gaming
		{
			set{ _online_gaming=value;}
			get{return _online_gaming;}
		}
		/// <summary>
		/// ϵͳ����ʱ��
		/// </summary>
		public DateTime m_AppendTime
		{
			set{ _m_appendtime=value;}
			get{return _m_appendtime;}
		}
		/// <summary>
		/// ϵͳ����ʱ��
		/// </summary>
		public DateTime m_UpdateTime
		{
			set{ _m_updatetime=value;}
			get{return _m_updatetime;}
		}

        /// <summary>
        /// �������
        /// </summary>
        public M_CreditInfo buyer_credit
        {
            set { _buyer_credit = value; }
            get { return _buyer_credit; }
        }
        /// <summary>
        /// ��������
        /// </summary>
        public M_CreditInfo seller_credit
        {
            set { _seller_credit = value; }
            get { return _seller_credit; }
        }
        /// <summary>
        /// ��ס��ַ
        /// </summary>
        public M_LocationInfo location
        {
            set { _location = value; }
            get { return _location; }
        }
		#endregion Model

	}
}

