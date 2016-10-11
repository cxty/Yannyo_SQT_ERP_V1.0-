using System;
namespace Yannyo.Entity
{
	/// <summary>
	/// ʵ����M_PropImgInfo ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class M_PropImgInfo
	{
		public M_PropImgInfo()
		{}
		#region Model
		private int _m_propimginfoid;
		private int _m_configinfoid;
		private int _m_type;
		private int _m_objid;
		private long _m_id;
		private long _product_id;
		private string _props;
		private string _url;
		private int _position;
		private DateTime _created;
		private DateTime _modified;
		/// <summary>
		/// ��Ʒ����ͼƬϵͳ���
		/// </summary>
		public int m_PropImgInfoID
		{
			set{ _m_propimginfoid=value;}
			get{return _m_propimginfoid;}
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
		/// ��������ϵͳ���
		/// </summary>
		public int m_ObjID
		{
			set{ _m_objid=value;}
			get{return _m_objid;}
		}
		/// <summary>
		/// ��Ʒ����ͼƬ���
		/// </summary>
		public long m_id
		{
			set{ _m_id=value;}
			get{return _m_id;}
		}
		/// <summary>
		/// ͼƬ������Ʒ��ID
		/// </summary>
		public long product_id
		{
			set{ _product_id=value;}
			get{return _product_id;}
		}
		/// <summary>
		/// ���Դ�(pid:vid)
		/// </summary>
		public string props
		{
			set{ _props=value;}
			get{return _props;}
		}
		/// <summary>
		/// ͼƬ��ַ
		/// </summary>
		public string url
		{
			set{ _url=value;}
			get{return _url;}
		}
		/// <summary>
		/// ͼƬ���
		/// </summary>
		public int position
		{
			set{ _position=value;}
			get{return _position;}
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
		/// �޸�ʱ��
		/// </summary>
		public DateTime modified
		{
			set{ _modified=value;}
			get{return _modified;}
		}
		#endregion Model

	}
}

