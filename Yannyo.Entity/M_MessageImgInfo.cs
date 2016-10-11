using System;
namespace Yannyo.Entity
{
	/// <summary>
	/// 实体类M_MessageImgInfo 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class M_MessageImgInfo
	{
		public M_MessageImgInfo()
		{}
		#region Model
		private int _m_messageimginfoid;
		private int _m_messageinfoid;
		private string _url;
		/// <summary>
		/// 图片编号
		/// </summary>
		public int m_MessageImgInfoID
		{
			set{ _m_messageimginfoid=value;}
			get{return _m_messageimginfoid;}
		}
		/// <summary>
		/// 所属留言编号
		/// </summary>
		public int m_MessageInfoID
		{
			set{ _m_messageinfoid=value;}
			get{return _m_messageinfoid;}
		}
		/// <summary>
		/// 图片地址
		/// </summary>
		public string url
		{
			set{ _url=value;}
			get{return _url;}
		}
		#endregion Model

	}
}

