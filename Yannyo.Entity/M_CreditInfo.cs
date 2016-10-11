using System;
namespace Yannyo.Entity
{
	/// <summary>
	/// 实体类M_CreditInfo 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class M_CreditInfo
	{
		public M_CreditInfo()
		{}
		#region Model
		private int _m_creditinfoid;
		private int _m_userinfoid;
		private int _m_type;
		private int _m_level;
		private int _score;
		private int _total_num;
		private int _good_num;
		private DateTime _last_updatetime;
		/// <summary>
		/// 信用信息编号
		/// </summary>
		public int m_CreditInfoID
		{
			set{ _m_creditinfoid=value;}
			get{return _m_creditinfoid;}
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
		/// 信用类型
		/// </summary>
		public int m_Type
		{
			set{ _m_type=value;}
			get{return _m_type;}
		}
		/// <summary>
		/// 信用等级
		/// </summary>
		public int m_level
		{
			set{ _m_level=value;}
			get{return _m_level;}
		}
		/// <summary>
		/// 信用总分
		/// </summary>
		public int score
		{
			set{ _score=value;}
			get{return _score;}
		}
		/// <summary>
		/// 收到的评价总条数
		/// </summary>
		public int total_num
		{
			set{ _total_num=value;}
			get{return _total_num;}
		}
		/// <summary>
		/// 收到的好评总条数
		/// </summary>
		public int good_num
		{
			set{ _good_num=value;}
			get{return _good_num;}
		}
		/// <summary>
		/// 最后更新时间
		/// </summary>
		public DateTime last_updatetime
		{
			set{ _last_updatetime=value;}
			get{return _last_updatetime;}
		}
		#endregion Model

	}
}

