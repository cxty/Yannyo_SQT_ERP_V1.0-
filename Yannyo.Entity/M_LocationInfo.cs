using System;
namespace Yannyo.Entity
{
	/// <summary>
	/// ʵ����M_LocationInfo ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class M_LocationInfo
	{
		public M_LocationInfo()
		{}
		#region Model
		private int _m_locationid;
		private int _m_configinfoid;
		private int _m_type;
		private int _m_objid;
		private string _zip;
		private string _address;
		private string _city;
		private string _state;
		private string _country;
		private string _district;
		private DateTime _m_appendtime;
		/// <summary>
		/// ��ַ���
		/// </summary>
		public int m_LocationID
		{
			set{ _m_locationid=value;}
			get{return _m_locationid;}
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
		/// �����ͻ����
		/// </summary>
		public int m_ObjID
		{
			set{ _m_objid=value;}
			get{return _m_objid;}
		}
		/// <summary>
		/// ��������
		/// </summary>
		public string zip
		{
			set{ _zip=value;}
			get{return _zip;}
		}
		/// <summary>
		/// ��ַ
		/// </summary>
		public string address
		{
			set{ _address=value;}
			get{return _address;}
		}
		/// <summary>
		/// ����
		/// </summary>
		public string city
		{
			set{ _city=value;}
			get{return _city;}
		}
		/// <summary>
		/// ���
		/// </summary>
		public string state
		{
			set{ _state=value;}
			get{return _state;}
		}
		/// <summary>
		/// ����
		/// </summary>
		public string country
		{
			set{ _country=value;}
			get{return _country;}
		}
		/// <summary>
		/// ����
		/// </summary>
		public string district
		{
			set{ _district=value;}
			get{return _district;}
		}
		/// <summary>
		/// ����ʱ��
		/// </summary>
		public DateTime m_AppendTime
		{
			set{ _m_appendtime=value;}
			get{return _m_appendtime;}
		}
		#endregion Model

	}
}

