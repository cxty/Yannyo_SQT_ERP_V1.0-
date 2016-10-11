using System;
namespace Yannyo.Entity
{
	/// <summary>
	/// ʵ����M_TimeOutInfo ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class M_TimeOutInfo
	{
		public M_TimeOutInfo()
		{}
		#region Model
		private int _m_timeoutinfoid;
		private int _m_configinfoid;
		private int _m_type;
		private int _m_objid;
		private int _remind_type;
		private bool _exist_timeout;
		private DateTime _timeout;
		/// <summary>
		/// ���׳�ʱ���
		/// </summary>
		public int m_TimeOutInfoID
		{
			set{ _m_timeoutinfoid=value;}
			get{return _m_timeoutinfoid;}
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
		/// ��Ӧ����
		/// </summary>
		public int m_Type
		{
			set{ _m_type=value;}
			get{return _m_type;}
		}
		/// <summary>
		/// ��Ӧ������
		/// </summary>
		public int m_ObjID
		{
			set{ _m_objid=value;}
			get{return _m_objid;}
		}
		/// <summary>
		/// ���ѵ�����
		/// </summary>
		public int remind_type
		{
			set{ _remind_type=value;}
			get{return _remind_type;}
		}
		/// <summary>
		/// �Ƿ���ڳ�ʱ
		/// </summary>
		public bool exist_timeout
		{
			set{ _exist_timeout=value;}
			get{return _exist_timeout;}
		}
		/// <summary>
		/// ��ʱʱ��
		/// </summary>
		public DateTime timeout
		{
			set{ _timeout=value;}
			get{return _timeout;}
		}
		#endregion Model

	}
}

