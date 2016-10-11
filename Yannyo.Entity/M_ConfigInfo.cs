using System;
namespace Yannyo.Entity
{
	/// <summary>
	/// 实体类M_ConfigInfo 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class M_ConfigInfo
	{
		public M_ConfigInfo()
		{}
		#region Model
		private int _m_configinfoid;
		private string _m_name;
		private string _m_appkey;
		private string _m_appsecret;
		private int _storesid;
        private string _storesname;
		private int _m_state;
		private DateTime _m_appendtime;
        private string _m_APIURL;
        private string _m_SessionKey;
        private DateTime _m_UpdateTime;
		/// <summary>
		/// 配置信息编号
		/// </summary>
		public int m_ConfigInfoID
		{
			set{ _m_configinfoid=value;}
			get{return _m_configinfoid;}
		}
		/// <summary>
		/// 名称
		/// </summary>
		public string m_Name
		{
			set{ _m_name=value;}
			get{return _m_name;}
		}
		/// <summary>
		/// 淘宝AppKey
		/// </summary>
		public string m_AppKey
		{
			set{ _m_appkey=value;}
			get{return _m_appkey;}
		}
		/// <summary>
		/// 淘宝AppSecret
		/// </summary>
		public string m_AppSecret
		{
			set{ _m_appsecret=value;}
			get{return _m_appsecret;}
		}
        /// <summary>
		/// 淘宝API接口地址
		/// </summary>
        public string m_APIURL
		{
            set { _m_APIURL = value; }
            get { return _m_APIURL; }
		}
        
		/// <summary>
		/// 对应客户编号
		/// </summary>
		public int StoresID
		{
			set{ _storesid=value;}
			get{return _storesid;}
		}
        /// <summary>
        /// 对应客户名称
        /// </summary>
        public string StoresName
        {
            set { _storesname = value; }
            get { return _storesname; }
        }
		/// <summary>
		/// 系统状态
		/// </summary>
		public int m_State
		{
			set{ _m_state=value;}
			get{return _m_state;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime m_AppendTime
		{
			set{ _m_appendtime=value;}
			get{return _m_appendtime;}
		}
        /// <summary>
        /// 会话SessionKey
        /// </summary>
        public string m_SessionKey
        {
            set { _m_SessionKey = value; }
            get { return _m_SessionKey; }
        }
        /// <summary>
        /// 会话SessionKey更新时间
        /// </summary>
        public DateTime m_UpdateTime
        {
            set { _m_UpdateTime = value; }
            get { return _m_UpdateTime; }
        }
		#endregion Model

	}
}

