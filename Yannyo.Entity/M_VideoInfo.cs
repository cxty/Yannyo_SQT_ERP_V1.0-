using System;
namespace Yannyo.Entity
{
	/// <summary>
	/// 实体类M_VideoInfo 。(属性说明自动提取数据库字段的描述信息)
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
		/// 视频系统编号
		/// </summary>
		public int m_VideoInfoID
		{
			set{ _m_videoinfoid=value;}
			get{return _m_videoinfoid;}
		}
		/// <summary>
		/// 网店系统编号
		/// </summary>
		public int m_ConfigInfoID
		{
			set{ _m_configinfoid=value;}
			get{return _m_configinfoid;}
		}
		/// <summary>
		/// 对应类型
		/// </summary>
		public int m_Type
		{
			set{ _m_type=value;}
			get{return _m_type;}
		}
		/// <summary>
		/// 所属对象系统编号
		/// </summary>
		public int m_ObjID
		{
			set{ _m_objid=value;}
			get{return _m_objid;}
		}
		/// <summary>
		/// 网店系统视频编号
		/// </summary>
		public long video_id
		{
			set{ _video_id=value;}
			get{return _video_id;}
		}
		/// <summary>
		/// 绝对地址
		/// </summary>
		public string url
		{
			set{ _url=value;}
			get{return _url;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime created
		{
			set{ _created=value;}
			get{return _created;}
		}
		/// <summary>
		/// 更新时间
		/// </summary>
		public DateTime modified
		{
			set{ _modified=value;}
			get{return _modified;}
		}
		/// <summary>
		/// 视频记录所关联的商品的数字id
		/// </summary>
		public long num_iid
		{
			set{ _num_iid=value;}
			get{return _num_iid;}
		}
		#endregion Model

	}
}

