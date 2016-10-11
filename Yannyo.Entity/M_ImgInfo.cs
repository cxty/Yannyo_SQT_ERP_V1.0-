using System;
namespace Yannyo.Entity
{
	/// <summary>
	/// ʵ����M_ImgInfo ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class M_ImgInfo
	{
		public M_ImgInfo()
		{}
		#region Model
		private int _m_imginfoid;
		private int _m_configinfoid;
		private int _m_type;
		private int _m_objid;
		private long _m_id;
		private long _product_id;
		private string _url;
		private int _position;
		private DateTime _created;
		private DateTime _modified;
		/// <summary>
		/// ��ͼƬϵͳ���
		/// </summary>
		public int m_ImgInfoID
		{
			set{ _m_imginfoid=value;}
			get{return _m_imginfoid;}
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
		/// ��ƷͼƬID
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

