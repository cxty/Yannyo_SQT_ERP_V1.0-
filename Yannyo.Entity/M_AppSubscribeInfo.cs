using System;
namespace Yannyo.Entity
{
	/// <summary>
	/// ʵ����M_AppSubscribeInfo ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class M_AppSubscribeInfo
	{
		public M_AppSubscribeInfo()
		{}
		#region Model
		private int _m_appsubscribeinfoid;
		private int _m_userinfoid;
		private string _lease_id;
		private string _status;
		private DateTime _start_date;
		private DateTime _end_date;
		private int _version_no;
		/// <summary>
		/// Ӧ�ö������
		/// </summary>
		public int m_AppSubscribeInfoID
		{
			set{ _m_appsubscribeinfoid=value;}
			get{return _m_appsubscribeinfoid;}
		}
		/// <summary>
		/// �����ͻ����
		/// </summary>
		public int m_UserInfoID
		{
			set{ _m_userinfoid=value;}
			get{return _m_userinfoid;}
		}
		/// <summary>
		/// ���ʵ��ID
		/// </summary>
		public string lease_id
		{
			set{ _lease_id=value;}
			get{return _lease_id;}
		}
		/// <summary>
		/// ����״��
		/// </summary>
		public string status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// ��ʼʱ��
		/// </summary>
		public DateTime start_date
		{
			set{ _start_date=value;}
			get{return _start_date;}
		}
		/// <summary>
		/// ����ʱ��
		/// </summary>
		public DateTime end_date
		{
			set{ _end_date=value;}
			get{return _end_date;}
		}
		/// <summary>
		/// �汾��Ϣ
		/// </summary>
		public int version_no
		{
			set{ _version_no=value;}
			get{return _version_no;}
		}
		#endregion Model

	}
}

