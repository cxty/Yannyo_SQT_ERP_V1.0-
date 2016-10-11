using System;
namespace Yannyo.Entity
{
	/// <summary>
	/// ʵ����M_GoodsSkuInfo ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class M_GoodsSkuInfo
	{
		public M_GoodsSkuInfo()
		{}
		#region Model
		private int _m_goodsskuinfoid;
		private int _m_configinfoid;
		private int _m_type;
		private int _m_objid;
		private long _sku_id;
		private long _num_iid;
		private string _properties;
		private int _quantity;
		private decimal _price;
		private string _outer_id;
		private DateTime _created;
		private DateTime _modified;
		private string _status;
		/// <summary>
		/// ��ƷSkuϵͳ���
		/// </summary>
		public int m_GoodsSkuInfoID
		{
			set{ _m_goodsskuinfoid=value;}
			get{return _m_goodsskuinfoid;}
		}
		/// <summary>
		/// ����ϵͳ���
		/// </summary>
		public int m_ConfigInfoID
		{
			set{ _m_configinfoid=value;}
			get{return _m_configinfoid;}
		}
		/// <summary>
		/// ��Ӧ����
		/// </summary>
		public int m_Type
		{
			set{ _m_type=value;}
			get{return _m_type;}
		}
		/// <summary>
		/// ��Ӧ������
		/// </summary>
		public int m_ObjID
		{
			set{ _m_objid=value;}
			get{return _m_objid;}
		}
		/// <summary>
		/// ����Sku���
		/// </summary>
		public long sku_id
		{
			set{ _sku_id=value;}
			get{return _sku_id;}
		}
		/// <summary>
		/// �������������
		/// </summary>
		public long num_iid
		{
			set{ _num_iid=value;}
			get{return _num_iid;}
		}
		/// <summary>
		/// ������������ַ���
		/// </summary>
		public string properties
		{
			set{ _properties=value;}
			get{return _properties;}
		}
		/// <summary>
		/// ���ڸ�Sku����Ʒ����
		/// </summary>
		public int quantity
		{
			set{ _quantity=value;}
			get{return _quantity;}
		}
		/// <summary>
		/// ���ڸ�Sku����Ʒ�ļ۸�
		/// </summary>
		public decimal price
		{
			set{ _price=value;}
			get{return _price;}
		}
		/// <summary>
		/// �ⲿ���
		/// </summary>
		public string outer_id
		{
			set{ _outer_id=value;}
			get{return _outer_id;}
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
		/// ״̬
		/// </summary>
		public string status
		{
			set{ _status=value;}
			get{return _status;}
		}
		#endregion Model

	}
}

