using System;
namespace Yannyo.Entity
{
	/// <summary>
	/// ʵ����M_MessageImgInfo ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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
		/// ͼƬ���
		/// </summary>
		public int m_MessageImgInfoID
		{
			set{ _m_messageimginfoid=value;}
			get{return _m_messageimginfoid;}
		}
		/// <summary>
		/// �������Ա��
		/// </summary>
		public int m_MessageInfoID
		{
			set{ _m_messageinfoid=value;}
			get{return _m_messageinfoid;}
		}
		/// <summary>
		/// ͼƬ��ַ
		/// </summary>
		public string url
		{
			set{ _url=value;}
			get{return _url;}
		}
		#endregion Model

	}
}

