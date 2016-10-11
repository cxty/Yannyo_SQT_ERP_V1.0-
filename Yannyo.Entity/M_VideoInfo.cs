using System;
namespace Yannyo.Entity
{
	/// <summary>
	/// ʵ����M_VideoInfo ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class M_VideoInfo
	{
		public M_VideoInfo()
		{}
		#region Model
		private int _m_videoinfoid;
		private int _m_configinfoid;
		private int _m_type;
		private int _m_objid;
		private long _video_id;
		private string _url;
		private DateTime _created;
		private DateTime _modified;
		private long _num_iid;
		/// <summary>
		/// ��Ƶϵͳ���
		/// </summary>
		public int m_VideoInfoID
		{
			set{ _m_videoinfoid=value;}
			get{return _m_videoinfoid;}
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
		/// ����ϵͳ��Ƶ���
		/// </summary>
		public long video_id
		{
			set{ _video_id=value;}
			get{return _video_id;}
		}
		/// <summary>
		/// ���Ե�ַ
		/// </summary>
		public string url
		{
			set{ _url=value;}
			get{return _url;}
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
		/// ����ʱ��
		/// </summary>
		public DateTime modified
		{
			set{ _modified=value;}
			get{return _modified;}
		}
		/// <summary>
		/// ��Ƶ��¼����������Ʒ������id
		/// </summary>
		public long num_iid
		{
			set{ _num_iid=value;}
			get{return _num_iid;}
		}
		#endregion Model

	}
}

