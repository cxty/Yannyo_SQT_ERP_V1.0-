using System;
namespace Yannyo.Entity
{
	/// <summary>
	/// 实体类M_LocationInfo 。(属性说明自动提取数据库字段的描述信息)
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
		/// 地址编号
		/// </summary>
		public int m_LocationID
		{
			set{ _m_locationid=value;}
			get{return _m_locationid;}
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
		/// 所属客户编号
		/// </summary>
		public int m_ObjID
		{
			set{ _m_objid=value;}
			get{return _m_objid;}
		}
		/// <summary>
		/// 邮政编码
		/// </summary>
		public string zip
		{
			set{ _zip=value;}
			get{return _zip;}
		}
		/// <summary>
		/// 地址
		/// </summary>
		public string address
		{
			set{ _address=value;}
			get{return _address;}
		}
		/// <summary>
		/// 城市
		/// </summary>
		public string city
		{
			set{ _city=value;}
			get{return _city;}
		}
		/// <summary>
		/// 身份
		/// </summary>
		public string state
		{
			set{ _state=value;}
			get{return _state;}
		}
		/// <summary>
		/// 国家
		/// </summary>
		public string country
		{
			set{ _country=value;}
			get{return _country;}
		}
		/// <summary>
		/// 区县
		/// </summary>
		public string district
		{
			set{ _district=value;}
			get{return _district;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime m_AppendTime
		{
			set{ _m_appendtime=value;}
			get{return _m_appendtime;}
		}
		#endregion Model

	}
}

