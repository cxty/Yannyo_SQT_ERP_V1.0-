using System;
namespace Yannyo.Entity
{
	/// <summary>
	/// 实体类M_AppSubscribeInfo 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class M_AppSubscribeInfo
	{
		public M_AppSubscribeInfo()
		{}
		#region Model
		private int _m_appsubscribeinfoid;
		private int _m_userinfoid;
		private string _lease_id;
		private string _status;
		private DateTime _start_date;
		private DateTime _end_date;
		private int _version_no;
		/// <summary>
		/// 应用订购编号
		/// </summary>
		public int m_AppSubscribeInfoID
		{
			set{ _m_appsubscribeinfoid=value;}
			get{return _m_appsubscribeinfoid;}
		}
		/// <summary>
		/// 所属客户编号
		/// </summary>
		public int m_UserInfoID
		{
			set{ _m_userinfoid=value;}
			get{return _m_userinfoid;}
		}
		/// <summary>
		/// 插件实例ID
		/// </summary>
		public string lease_id
		{
			set{ _lease_id=value;}
			get{return _lease_id;}
		}
		/// <summary>
		/// 订购状况
		/// </summary>
		public string status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// 开始时间
		/// </summary>
		public DateTime start_date
		{
			set{ _start_date=value;}
			get{return _start_date;}
		}
		/// <summary>
		/// 结束时间
		/// </summary>
		public DateTime end_date
		{
			set{ _end_date=value;}
			get{return _end_date;}
		}
		/// <summary>
		/// 版本信息
		/// </summary>
		public int version_no
		{
			set{ _version_no=value;}
			get{return _version_no;}
		}
		#endregion Model

	}
}

