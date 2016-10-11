using System;
namespace Yannyo.Entity
{
	/// <summary>
	/// 实体类M_ImgInfo 。(属性说明自动提取数据库字段的描述信息)
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
		/// 子图片系统编号
		/// </summary>
		public int m_ImgInfoID
		{
			set{ _m_imginfoid=value;}
			get{return _m_imginfoid;}
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
		/// 产品图片ID
		/// </summary>
		public long m_id
		{
			set{ _m_id=value;}
			get{return _m_id;}
		}
		/// <summary>
		/// 图片所属产品的ID
		/// </summary>
		public long product_id
		{
			set{ _product_id=value;}
			get{return _product_id;}
		}
		/// <summary>
		/// 图片地址
		/// </summary>
		public string url
		{
			set{ _url=value;}
			get{return _url;}
		}
		/// <summary>
		/// 图片序号
		/// </summary>
		public int position
		{
			set{ _position=value;}
			get{return _position;}
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
		/// 修改时间
		/// </summary>
		public DateTime modified
		{
			set{ _modified=value;}
			get{return _modified;}
		}
		#endregion Model

	}
}

