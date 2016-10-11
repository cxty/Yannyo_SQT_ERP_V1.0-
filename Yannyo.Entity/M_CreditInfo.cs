using System;
namespace Yannyo.Entity
{
	/// <summary>
	/// ʵ����M_CreditInfo ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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
		/// ������Ϣ���
		/// </summary>
		public int m_CreditInfoID
		{
			set{ _m_creditinfoid=value;}
			get{return _m_creditinfoid;}
		}
		/// <summary>
		/// �����ͻ����
		/// </summary>
		public int m_UserInfoID
		{
			set{ _m_userinfoid=value;}
			get{return _m_userinfoid;}
		}
		/// <summary>
		/// ��������
		/// </summary>
		public int m_Type
		{
			set{ _m_type=value;}
			get{return _m_type;}
		}
		/// <summary>
		/// ���õȼ�
		/// </summary>
		public int m_level
		{
			set{ _m_level=value;}
			get{return _m_level;}
		}
		/// <summary>
		/// �����ܷ�
		/// </summary>
		public int score
		{
			set{ _score=value;}
			get{return _score;}
		}
		/// <summary>
		/// �յ�������������
		/// </summary>
		public int total_num
		{
			set{ _total_num=value;}
			get{return _total_num;}
		}
		/// <summary>
		/// �յ��ĺ���������
		/// </summary>
		public int good_num
		{
			set{ _good_num=value;}
			get{return _good_num;}
		}
		/// <summary>
		/// ������ʱ��
		/// </summary>
		public DateTime last_updatetime
		{
			set{ _last_updatetime=value;}
			get{return _last_updatetime;}
		}
		#endregion Model

	}
}

