using System;
namespace Yannyo.Entity
{
	/// <summary>
	/// ʵ����M_ShoppingAddressInfo ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class M_ShoppingAddressInfo
	{
		public M_ShoppingAddressInfo()
		{}
		#region Model
		private int _m_shoppingaddressinfoid;
		private int _m_configinfoid;
		private int _m_type;
		private int _m_objid;
		private int _address_id;
		private string _receiver_name;
		private string _phone;
		private string _mobile;
		private bool _is_default;
		private DateTime _created;
		/// <summary>
		/// ���׵�ַϵͳ���
		/// </summary>
		public int m_ShoppingAddressInfoID
		{
			set{ _m_shoppingaddressinfoid=value;}
			get{return _m_shoppingaddressinfoid;}
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
		/// ����ϵͳ���
		/// </summary>
		public int address_id
		{
			set{ _address_id=value;}
			get{return _address_id;}
		}
		/// <summary>
		/// �ջ�������
		/// </summary>
		public string receiver_name
		{
			set{ _receiver_name=value;}
			get{return _receiver_name;}
		}
		/// <summary>
		/// �̶��绰
		/// </summary>
		public string phone
		{
			set{ _phone=value;}
			get{return _phone;}
		}
		/// <summary>
		/// �ƶ��绰
		/// </summary>
		public string mobile
		{
			set{ _mobile=value;}
			get{return _mobile;}
		}
		/// <summary>
		/// �Ƿ�ΪĬ���ջ���ַ
		/// </summary>
		public bool is_default
		{
			set{ _is_default=value;}
			get{return _is_default;}
		}
		/// <summary>
		/// ����ʱ��
		/// </summary>
		public DateTime created
		{
			set{ _created=value;}
			get{return _created;}
		}
		#endregion Model

	}
}

