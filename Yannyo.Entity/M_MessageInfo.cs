using System;
namespace Yannyo.Entity
{
	/// <summary>
	/// ʵ����M_MessageInfo ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class M_MessageInfo
	{
		public M_MessageInfo()
		{}
		#region Model
		private int _m_messageinfoid;
		private int _m_configinfoid;
		private int _m_type;
		private int _m_objid;
		private int _m_id;
		private int _refund_id;
		private int _owner_id;
		private string _owner_nick;
		private string _owner_role;
		private string _m_content;
		private DateTime _created;
		private string _message_type;
		/// <summary>
		/// ƾ֤��Ϣϵͳ���
		/// </summary>
		public int m_MessageInfoID
		{
			set{ _m_messageinfoid=value;}
			get{return _m_messageinfoid;}
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
		/// ��������
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
		/// ����ϵͳ���Ա��
		/// </summary>
		public int m_id
		{
			set{ _m_id=value;}
			get{return _m_id;}
		}
		/// <summary>
		/// ����ϵͳԤ�����
		/// </summary>
		public int refund_id
		{
			set{ _refund_id=value;}
			get{return _refund_id;}
		}
		/// <summary>
		/// �����߱��
		/// </summary>
		public int owner_id
		{
			set{ _owner_id=value;}
			get{return _owner_id;}
		}
		/// <summary>
		/// �������ǳ�
		/// </summary>
		public string owner_nick
		{
			set{ _owner_nick=value;}
			get{return _owner_nick;}
		}
		/// <summary>
		/// ���������
		/// </summary>
		public string owner_role
		{
			set{ _owner_role=value;}
			get{return _owner_role;}
		}
		/// <summary>
		/// ����
		/// </summary>
		public string m_content
		{
			set{ _m_content=value;}
			get{return _m_content;}
		}
		/// <summary>
		/// ����ʱ��
		/// </summary>
		public DateTime created
		{
			set{ _created=value;}
			get{return _created;}
		}
		/// <summary>
		/// ��Ϣ����
		/// </summary>
		public string message_type
		{
			set{ _message_type=value;}
			get{return _message_type;}
		}
		#endregion Model

	}
}

