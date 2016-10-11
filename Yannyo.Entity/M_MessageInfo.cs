using System;
namespace Yannyo.Entity
{
	/// <summary>
	/// 实体类M_MessageInfo 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class M_MessageInfo
	{
		public M_MessageInfo()
		{}
		#region Model
		private int _m_messageinfoid;
		private int _m_configinfoid;
		private int _m_type;
		private int _m_objid;
		private int _m_id;
		private int _refund_id;
		private int _owner_id;
		private string _owner_nick;
		private string _owner_role;
		private string _m_content;
		private DateTime _created;
		private string _message_type;
		/// <summary>
		/// 凭证信息系统编号
		/// </summary>
		public int m_MessageInfoID
		{
			set{ _m_messageinfoid=value;}
			get{return _m_messageinfoid;}
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
		/// 留言类型
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
		/// 网店系统留言编号
		/// </summary>
		public int m_id
		{
			set{ _m_id=value;}
			get{return _m_id;}
		}
		/// <summary>
		/// 网店系统预留编号
		/// </summary>
		public int refund_id
		{
			set{ _refund_id=value;}
			get{return _refund_id;}
		}
		/// <summary>
		/// 留言者编号
		/// </summary>
		public int owner_id
		{
			set{ _owner_id=value;}
			get{return _owner_id;}
		}
		/// <summary>
		/// 留言者昵称
		/// </summary>
		public string owner_nick
		{
			set{ _owner_nick=value;}
			get{return _owner_nick;}
		}
		/// <summary>
		/// 留言者身份
		/// </summary>
		public string owner_role
		{
			set{ _owner_role=value;}
			get{return _owner_role;}
		}
		/// <summary>
		/// 内容
		/// </summary>
		public string m_content
		{
			set{ _m_content=value;}
			get{return _m_content;}
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
		/// 信息类型
		/// </summary>
		public string message_type
		{
			set{ _message_type=value;}
			get{return _message_type;}
		}
		#endregion Model

	}
}

