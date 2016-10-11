using System;
namespace Yannyo.Entity
{
	/// <summary>
	/// ʵ����M_GoodsExtraInfo ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class M_GoodsExtraInfo
	{
		public M_GoodsExtraInfo()
		{}
		#region Model
		private int _m_goodsextrainfoid;
		private int _m_goodsid;
		private int _eid;
		private int _num_iid;
		private string _title;
		private string _m_desc;
		private string _feature;
		private string _memo;
		private string _type;
		private decimal _reserve_price;
		private DateTime _created;
		private DateTime _modified;
		private DateTime _list_time;
		private DateTime _delist_time;
		private string _approve_status;
		private string _pic_url;
		private int _options;
		private string _item_pic_url;
		private int _item_options;
		private int _item_num;
		/// <summary>
		/// ��Ʒ��չ��Ϣϵͳ���
		/// </summary>
		public int m_GoodsExtraInfoID
		{
			set{ _m_goodsextrainfoid=value;}
			get{return _m_goodsextrainfoid;}
		}
		/// <summary>
		/// ����ϵͳ��Ʒ���
		/// </summary>
		public int m_GoodsID
		{
			set{ _m_goodsid=value;}
			get{return _m_goodsid;}
		}
		/// <summary>
		/// ����ϵͳ��չ��Ϣ���
		/// </summary>
		public int eid
		{
			set{ _eid=value;}
			get{return _eid;}
		}
		/// <summary>
		/// ��Ʒ����ϵͳ���
		/// </summary>
		public int num_iid
		{
			set{ _num_iid=value;}
			get{return _num_iid;}
		}
		/// <summary>
		/// ��չ����
		/// </summary>
		public string title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// ��չ����
		/// </summary>
		public string m_desc
		{
			set{ _m_desc=value;}
			get{return _m_desc;}
		}
		/// <summary>
		/// �Զ�����Ϣ
		/// </summary>
		public string feature
		{
			set{ _feature=value;}
			get{return _feature;}
		}
		/// <summary>
		/// ��ע
		/// </summary>
		public string memo
		{
			set{ _memo=value;}
			get{return _memo;}
		}
		/// <summary>
		/// ��չ��Ʒ������
		/// </summary>
		public string type
		{
			set{ _type=value;}
			get{return _type;}
		}
		/// <summary>
		/// ��չ��Ʒ�ļ۸�
		/// </summary>
		public decimal reserve_price
		{
			set{ _reserve_price=value;}
			get{return _reserve_price;}
		}
		/// <summary>
		/// ����ʱ��
		/// </summary>
		public DateTime created
		{
			set{ _created=value;}
			get{return _created;}
		}
		/// <summary>
		/// �޸�ʱ��
		/// </summary>
		public DateTime modified
		{
			set{ _modified=value;}
			get{return _modified;}
		}
		/// <summary>
		/// �ϼ�ʱ��
		/// </summary>
		public DateTime list_time
		{
			set{ _list_time=value;}
			get{return _list_time;}
		}
		/// <summary>
		/// �¼�ʱ��
		/// </summary>
		public DateTime delist_time
		{
			set{ _delist_time=value;}
			get{return _delist_time;}
		}
		/// <summary>
		/// ��Ʒ�ϴ����״̬
		/// </summary>
		public string approve_status
		{
			set{ _approve_status=value;}
			get{return _approve_status;}
		}
		/// <summary>
		/// ͼƬ��ַ
		/// </summary>
		public string pic_url
		{
			set{ _pic_url=value;}
			get{return _pic_url;}
		}
		/// <summary>
		/// options�ֶΣ����ڶ���չ��Ʒ��λ��ĳЩ���
		/// </summary>
		public int options
		{
			set{ _options=value;}
			get{return _options;}
		}
		/// <summary>
		/// ��Ʒ�������ͼ��ַ
		/// </summary>
		public string item_pic_url
		{
			set{ _item_pic_url=value;}
			get{return _item_pic_url;}
		}
		/// <summary>
		/// ��ƷItem�����options�ֶ�
		/// </summary>
		public int item_options
		{
			set{ _item_options=value;}
			get{return _item_options;}
		}
		/// <summary>
		/// ��ƷItem���
		/// </summary>
		public int item_num
		{
			set{ _item_num=value;}
			get{return _item_num;}
		}
		#endregion Model

	}
}

