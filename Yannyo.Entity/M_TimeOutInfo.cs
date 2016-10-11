using System;
namespace Yannyo.Entity
{
	/// <summary>
	/// 实体类M_TimeOutInfo 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class M_TimeOutInfo
	{
		public M_TimeOutInfo()
		{}
		#region Model
		private int _m_timeoutinfoid;
		private int _m_configinfoid;
		private int _m_type;
		private int _m_objid;
		private int _remind_type;
		private bool _exist_timeout;
		private DateTime _timeout;
		/// <summary>
		/// 交易超时编号
		/// </summary>
		public int m_TimeOutInfoID
		{
			set{ _m_timeoutinfoid=value;}
			get{return _m_timeoutinfoid;}
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
		/// 对应对象编号
		/// </summary>
		public int m_ObjID
		{
			set{ _m_objid=value;}
			get{return _m_objid;}
		}
		/// <summary>
		/// 提醒的类型
		/// </summary>
		public int remind_type
		{
			set{ _remind_type=value;}
			get{return _remind_type;}
		}
		/// <summary>
		/// 是否存在超时
		/// </summary>
		public bool exist_timeout
		{
			set{ _exist_timeout=value;}
			get{return _exist_timeout;}
		}
		/// <summary>
		/// 超时时间
		/// </summary>
		public DateTime timeout
		{
			set{ _timeout=value;}
			get{return _timeout;}
		}
		#endregion Model

	}
}

