using System;
namespace Yannyo.Entity
{
	/// <summary>
	/// ʵ����M_ConfigInfo ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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
		/// ������Ϣ���
		/// </summary>
		public int m_ConfigInfoID
		{
			set{ _m_configinfoid=value;}
			get{return _m_configinfoid;}
		}
		/// <summary>
		/// ����
		/// </summary>
		public string m_Name
		{
			set{ _m_name=value;}
			get{return _m_name;}
		}
		/// <summary>
		/// �Ա�AppKey
		/// </summary>
		public string m_AppKey
		{
			set{ _m_appkey=value;}
			get{return _m_appkey;}
		}
		/// <summary>
		/// �Ա�AppSecret
		/// </summary>
		public string m_AppSecret
		{
			set{ _m_appsecret=value;}
			get{return _m_appsecret;}
		}
        /// <summary>
		/// �Ա�API�ӿڵ�ַ
		/// </summary>
        public string m_APIURL
		{
            set { _m_APIURL = value; }
            get { return _m_APIURL; }
		}
        
		/// <summary>
		/// ��Ӧ�ͻ����
		/// </summary>
		public int StoresID
		{
			set{ _storesid=value;}
			get{return _storesid;}
		}
        /// <summary>
        /// ��Ӧ�ͻ�����
        /// </summary>
        public string StoresName
        {
            set { _storesname = value; }
            get { return _storesname; }
        }
		/// <summary>
		/// ϵͳ״̬
		/// </summary>
		public int m_State
		{
			set{ _m_state=value;}
			get{return _m_state;}
		}
		/// <summary>
		/// ����ʱ��
		/// </summary>
		public DateTime m_AppendTime
		{
			set{ _m_appendtime=value;}
			get{return _m_appendtime;}
		}
        /// <summary>
        /// �ỰSessionKey
        /// </summary>
        public string m_SessionKey
        {
            set { _m_SessionKey = value; }
            get { return _m_SessionKey; }
        }
        /// <summary>
        /// �ỰSessionKey����ʱ��
        /// </summary>
        public DateTime m_UpdateTime
        {
            set { _m_UpdateTime = value; }
            get { return _m_UpdateTime; }
        }
		#endregion Model

	}
}

