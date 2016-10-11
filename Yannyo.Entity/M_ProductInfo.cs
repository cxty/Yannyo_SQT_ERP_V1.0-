using System;
namespace Yannyo.Entity
{
	/// <summary>
	/// ʵ����M_ProductInfo ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class M_ProductInfo
	{
		public M_ProductInfo()
		{}
		#region Model
		private int _m_productinfoid;
		private int _m_configinfoid;
		private int _productsid;
		private long _product_id;
		private string _outer_id;
		private DateTime _created;
		private string _tsc;
		private string _cid;
		private string _cat_name;
		private string _props;
		private string _props_str;
		private string _binds_str;
		private string _sale_props_str;
		private string _name;
		private string _binds;
		private string _sale_props;
		private decimal _price;
		private string _m_desc;
		private string _pic_url;
		private DateTime _modified;
		private int _status;
		private int _collect_num;
		private int _m_level;
		private string _pic_path;
		private int _vertical_market;
		private string _customer_props;
		private string _property_alias;
		/// <summary>
		/// �����Ʒϵͳ���
		/// </summary>
		public int m_ProductInfoID
		{
			set{ _m_productinfoid=value;}
			get{return _m_productinfoid;}
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
		/// Erpϵͳ��Ʒ���
		/// </summary>
		public int ProductsID
		{
			set{ _productsid=value;}
			get{return _productsid;}
		}
		/// <summary>
		/// �����Ʒ���
		/// </summary>
		public long product_id
		{
			set{ _product_id=value;}
			get{return _product_id;}
		}
		/// <summary>
		/// �ⲿ��Ʒ���
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
		/// �Ա���׼��Ʒ����
		/// </summary>
		public string tsc
		{
			set{ _tsc=value;}
			get{return _tsc;}
		}
		/// <summary>
		/// ��Ʒ��ĿID
		/// </summary>
		public string cid
		{
			set{ _cid=value;}
			get{return _cid;}
		}
		/// <summary>
		/// ������
		/// </summary>
		public string cat_name
		{
			set{ _cat_name=value;}
			get{return _cat_name;}
		}
		/// <summary>
		/// ��Ʒ�Ĺؼ������б�
		/// </summary>
		public string props
		{
			set{ _props=value;}
			get{return _props;}
		}
		/// <summary>
		/// ��Ʒ�Ĺؼ������ַ����б�
		/// </summary>
		public string props_str
		{
			set{ _props_str=value;}
			get{return _props_str;}
		}
		/// <summary>
		/// ��Ʒ�ķǹؼ������ַ����б�
		/// </summary>
		public string binds_str
		{
			set{ _binds_str=value;}
			get{return _binds_str;}
		}
		/// <summary>
		/// ��Ʒ�����������ַ����б�
		/// </summary>
		public string sale_props_str
		{
			set{ _sale_props_str=value;}
			get{return _sale_props_str;}
		}
		/// <summary>
		/// ������
		/// </summary>
		public string name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// ��Ʒ�ķǹؼ������б�
		/// </summary>
		public string binds
		{
			set{ _binds=value;}
			get{return _binds;}
		}
		/// <summary>
		/// ��Ʒ�����������б�
		/// </summary>
		public string sale_props
		{
			set{ _sale_props=value;}
			get{return _sale_props;}
		}
		/// <summary>
		/// ��Ʒ���г���
		/// </summary>
		public decimal price
		{
			set{ _price=value;}
			get{return _price;}
		}
		/// <summary>
		/// ��Ʒ������
		/// </summary>
		public string m_desc
		{
			set{ _m_desc=value;}
			get{return _m_desc;}
		}
		/// <summary>
		/// ��Ʒ����ͼƬ��ַ
		/// </summary>
		public string pic_url
		{
			set{ _pic_url=value;}
			get{return _pic_url;}
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
		/// ��ǰ״̬
		/// </summary>
		public int status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// ��Ʒ��collect����
		/// </summary>
		public int collect_num
		{
			set{ _collect_num=value;}
			get{return _collect_num;}
		}
		/// <summary>
		/// ��Ʒ�ļ���level
		/// </summary>
		public int m_level
		{
			set{ _m_level=value;}
			get{return _m_level;}
		}
		/// <summary>
		/// ��Ʒ��Ӧ��ͼƬ·��
		/// </summary>
		public string pic_path
		{
			set{ _pic_path=value;}
			get{return _pic_path;}
		}
		/// <summary>
		/// ��ֱ�г�
		/// </summary>
		public int vertical_market
		{
			set{ _vertical_market=value;}
			get{return _vertical_market;}
		}
		/// <summary>
		/// �û��Զ�������
		/// </summary>
		public string customer_props
		{
			set{ _customer_props=value;}
			get{return _customer_props;}
		}
		/// <summary>
		/// ��������ֵ����
		/// </summary>
		public string property_alias
		{
			set{ _property_alias=value;}
			get{return _property_alias;}
		}
		#endregion Model

	}
}

