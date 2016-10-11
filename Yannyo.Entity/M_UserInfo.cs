using System;
namespace Yannyo.Entity
{
	/// <summary>
	/// 实体类M_UserInfo 。(属性说明自动提取数据库字段的描述信息)
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
		/// 系统编号
		/// </summary>
		public int m_UserInfoID
		{
			set{ _m_userinfoid=value;}
			get{return _m_userinfoid;}
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
		/// 网店用户系统编号
		/// </summary>
		public Int64 user_id
		{
			set{ _user_id=value;}
			get{return _user_id;}
		}
		/// <summary>
		/// 网店用户系统内部编号
		/// </summary>
		public string uid
		{
			set{ _uid=value;}
			get{return _uid;}
		}
		/// <summary>
		/// 昵称
		/// </summary>
		public string nick
		{
			set{ _nick=value;}
			get{return _nick;}
		}
		/// <summary>
		/// 性别
		/// </summary>
		public string sex
		{
			set{ _sex=value;}
			get{return _sex;}
		}
		/// <summary>
		/// 用户注册时间
		/// </summary>
		public DateTime created
		{
			set{ _created=value;}
			get{return _created;}
		}
		/// <summary>
		/// 最近登录时间
		/// </summary>
		public DateTime last_visit
		{
			set{ _last_visit=value;}
			get{return _last_visit;}
		}
		/// <summary>
		/// 生日
		/// </summary>
		public string birthday
		{
			set{ _birthday=value;}
			get{return _birthday;}
		}
		/// <summary>
		/// 用户类型
		/// </summary>
		public string type
		{
			set{ _type=value;}
			get{return _type;}
		}
		/// <summary>
		/// 是否购买多图服务
		/// </summary>
		public bool has_more_pic
		{
			set{ _has_more_pic=value;}
			get{return _has_more_pic;}
		}
		/// <summary>
		/// 可上传图片数量
		/// </summary>
		public int item_img_num
		{
			set{ _item_img_num=value;}
			get{return _item_img_num;}
		}
		/// <summary>
		/// 上传单张图片大小
		/// </summary>
		public int item_img_size
		{
			set{ _item_img_size=value;}
			get{return _item_img_size;}
		}
		/// <summary>
		/// 可上传属性图片数量
		/// </summary>
		public int prop_img_num
		{
			set{ _prop_img_num=value;}
			get{return _prop_img_num;}
		}
		/// <summary>
		/// 单张销售属性图片最大容量
		/// </summary>
		public int prop_img_sizec
		{
			set{ _prop_img_sizec=value;}
			get{return _prop_img_sizec;}
		}
		/// <summary>
		/// 是否受限制
		/// </summary>
		public string auto_repost
		{
			set{ _auto_repost=value;}
			get{return _auto_repost;}
		}
		/// <summary>
		/// 有无实名认证
		/// </summary>
		public string promoted_type
		{
			set{ _promoted_type=value;}
			get{return _promoted_type;}
		}
		/// <summary>
		/// 状态
		/// </summary>
		public string status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// 支付宝绑定
		/// </summary>
		public string alipay_bind
		{
			set{ _alipay_bind=value;}
			get{return _alipay_bind;}
		}
		/// <summary>
		/// 是否消保
		/// </summary>
		public int consumer_protection
		{
			set{ _consumer_protection=value;}
			get{return _consumer_protection;}
		}
		/// <summary>
		/// 支付宝帐号
		/// </summary>
		public string alipay_account
		{
			set{ _alipay_account=value;}
			get{return _alipay_account;}
		}
		/// <summary>
		/// 支付宝ID
		/// </summary>
		public string alipay_no
		{
			set{ _alipay_no=value;}
			get{return _alipay_no;}
		}
		/// <summary>
		/// 联系人邮箱
		/// </summary>
		public string email
		{
			set{ _email=value;}
			get{return _email;}
		}
		/// <summary>
		/// 是否订阅淘天下
		/// </summary>
		public bool magazine_subscribe
		{
			set{ _magazine_subscribe=value;}
			get{return _magazine_subscribe;}
		}
		/// <summary>
		/// 用户参与垂直市场类型
		/// </summary>
		public string vertical_market
		{
			set{ _vertical_market=value;}
			get{return _vertical_market;}
		}
		/// <summary>
		/// 头像
		/// </summary>
		public string avatar
		{
			set{ _avatar=value;}
			get{return _avatar;}
		}
		/// <summary>
		/// 是否网游用户
		/// </summary>
		public bool online_gaming
		{
			set{ _online_gaming=value;}
			get{return _online_gaming;}
		}
		/// <summary>
		/// 系统创建时间
		/// </summary>
		public DateTime m_AppendTime
		{
			set{ _m_appendtime=value;}
			get{return _m_appendtime;}
		}
		/// <summary>
		/// 系统更新时间
		/// </summary>
		public DateTime m_UpdateTime
		{
			set{ _m_updatetime=value;}
			get{return _m_updatetime;}
		}

        /// <summary>
        /// 买家信用
        /// </summary>
        public M_CreditInfo buyer_credit
        {
            set { _buyer_credit = value; }
            get { return _buyer_credit; }
        }
        /// <summary>
        /// 卖家信用
        /// </summary>
        public M_CreditInfo seller_credit
        {
            set { _seller_credit = value; }
            get { return _seller_credit; }
        }
        /// <summary>
        /// 居住地址
        /// </summary>
        public M_LocationInfo location
        {
            set { _location = value; }
            get { return _location; }
        }
		#endregion Model

	}
}

