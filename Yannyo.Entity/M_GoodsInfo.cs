using System;
namespace Yannyo.Entity
{
	/// <summary>
	/// ʵ����M_GoodsInfo ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class M_GoodsInfo
	{
		public M_GoodsInfo()
		{}
		#region Model
		private int _m_goodsid;
		private int _m_configinfoid;
		private int _productsid;
		private int _m_productinfoid;
		private long _product_id;

        private string _ProductsName;

		private string _outer_id;
		private long _num_iid;
		private string _detail_url;
		private string _title;
		private string _nick;
		private string _type;
		private string _props_name;
		private string _promoted_service;
		private long _cid;
		private string _seller_cids;
        private string _mCatName;
		private string _props;
		private string _input_pids;
		private string _input_str;
		private string _m_desc;
		private string _pic_url;
		private int _num;
		private int _valid_thru;
		private DateTime _list_time;
		private DateTime _delist_time;
		private string _stuff_status;
		private decimal _price;
		private decimal _post_fee;
		private decimal _express_fee;
		private decimal _ems_fee;
		private bool _has_discount;
		private string _freight_payer;
		private bool _has_invoice;
		private bool _has_warranty;
		private bool _has_showcase;
		private DateTime _modified;
		private string _increment;
		private string _approve_status;
		private long _postage_id;
		private int _auction_point;
		private string _property_alias;
		private bool _is_virtual;
		private bool _is_taobao;
		private bool _is_ex;
		private bool _is_timing;
		private bool _is_3d;
		private bool _one_station;
		private string _second_kill;
		private string _auto_fill;
		private bool _violation;
		private DateTime _created;
		private long _cod_postage_id;
		private bool _sell_promise;

        private bool _m_IsDeltet;
        private DateTime _m_UpdateTime;

        private M_GoodsSkuInfo[] _skus;
        private M_LocationInfo _location;
        private M_ImgInfo[] _item_imgs;
        private M_PropImgInfo[] _prop_imgs;
        private M_VideoInfo[] _videos;

		/// <summary>
		/// ��Ʒ��Ϣϵͳ���
		/// </summary>
		public int m_GoodsID
		{
			set{ _m_goodsid=value;}
			get{return _m_goodsid;}
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
		/// ����Erpϵͳ��Ʒ���
		/// </summary>
		public int ProductsID
		{
			set{ _productsid=value;}
			get{return _productsid;}
		}
		/// <summary>
		/// ����ϵͳ��Ʒ���
		/// </summary>
		public int m_ProductInfoID
		{
			set{ _m_productinfoid=value;}
			get{return _m_productinfoid;}
		}
		/// <summary>
		/// ������Ʒ��id
		/// </summary>
		public long product_id
		{
			set{ _product_id=value;}
			get{return _product_id;}
		}
        /// <summary>
        /// ������Ʒ����
        /// </summary>
        public string ProductsName
        {
            set { _ProductsName = value; }
            get { return _ProductsName; }
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
		/// ������Ʒ���
		/// </summary>
		public long num_iid
		{
			set{ _num_iid=value;}
			get{return _num_iid;}
		}
		/// <summary>
		/// ��ƷURL
		/// </summary>
		public string detail_url
		{
			set{ _detail_url=value;}
			get{return _detail_url;}
		}
		/// <summary>
		/// ����
		/// </summary>
		public string title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// �����ǳ�
		/// </summary>
		public string nick
		{
			set{ _nick=value;}
			get{return _nick;}
		}
		/// <summary>
		/// ��Ʒ����
		/// </summary>
		public string type
		{
			set{ _type=value;}
			get{return _type;}
		}
		/// <summary>
		/// ��Ʒ��������
		/// </summary>
		public string props_name
		{
			set{ _props_name=value;}
			get{return _props_name;}
		}
		/// <summary>
		/// �������ͣ����������,�ָ�
		/// </summary>
		public string promoted_service
		{
			set{ _promoted_service=value;}
			get{return _promoted_service;}
		}
		/// <summary>
		/// ��Ʒ������Ҷ����Ŀ id
		/// </summary>
		public long cid
		{
			set{ _cid=value;}
			get{return _cid;}
		}
		/// <summary>
		/// ��Ʒ�����ĵ����������Զ�����Ŀ�б�
		/// </summary>
		public string seller_cids
		{
			set{ _seller_cids=value;}
			get{return _seller_cids;}
		}
        /// <summary>
        /// �����̳���Ŀ����
        /// </summary>
        public string mCatName
        {
            set { _mCatName = value; }
            get { return _mCatName; }
        }
		/// <summary>
		/// ��Ʒ����
		/// </summary>
		public string props
		{
			set{ _props=value;}
			get{return _props;}
		}
		/// <summary>
		/// �û������������Ŀ����ID��
		/// </summary>
		public string input_pids
		{
			set{ _input_pids=value;}
			get{return _input_pids;}
		}
		/// <summary>
		/// �û������������������������ֵ
		/// </summary>
		public string input_str
		{
			set{ _input_str=value;}
			get{return _input_str;}
		}
		/// <summary>
		/// ��Ʒ����
		/// </summary>
		public string m_desc
		{
			set{ _m_desc=value;}
			get{return _m_desc;}
		}
		/// <summary>
		/// ��Ʒ��ͼƬ��ַ
		/// </summary>
		public string pic_url
		{
			set{ _pic_url=value;}
			get{return _pic_url;}
		}
		/// <summary>
		/// ����
		/// </summary>
		public int num
		{
			set{ _num=value;}
			get{return _num;}
		}
		/// <summary>
		/// ��Ч��
		/// </summary>
		public int valid_thru
		{
			set{ _valid_thru=value;}
			get{return _valid_thru;}
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
		/// ��Ʒ�¾ɳ̶�
		/// </summary>
		public string stuff_status
		{
			set{ _stuff_status=value;}
			get{return _stuff_status;}
		}
		/// <summary>
		/// ��Ʒ�۸�
		/// </summary>
		public decimal price
		{
			set{ _price=value;}
			get{return _price;}
		}
		/// <summary>
		/// ƽ��
		/// </summary>
		public decimal post_fee
		{
			set{ _post_fee=value;}
			get{return _post_fee;}
		}
		/// <summary>
		/// ���
		/// </summary>
		public decimal express_fee
		{
			set{ _express_fee=value;}
			get{return _express_fee;}
		}
		/// <summary>
		/// Ems
		/// </summary>
		public decimal ems_fee
		{
			set{ _ems_fee=value;}
			get{return _ems_fee;}
		}
		/// <summary>
		/// �Ƿ��Ա����
		/// </summary>
		public bool has_discount
		{
			set{ _has_discount=value;}
			get{return _has_discount;}
		}
		/// <summary>
		/// �˷ѳе���ʽ
		/// </summary>
		public string freight_payer
		{
			set{ _freight_payer=value;}
			get{return _freight_payer;}
		}
		/// <summary>
		/// �Ƿ񺬷�Ʊ
		/// </summary>
		public bool has_invoice
		{
			set{ _has_invoice=value;}
			get{return _has_invoice;}
		}
		/// <summary>
		/// �Ƿ��б���
		/// </summary>
		public bool has_warranty
		{
			set{ _has_warranty=value;}
			get{return _has_warranty;}
		}
		/// <summary>
		/// �Ƿ�����Ƽ�
		/// </summary>
		public bool has_showcase
		{
			set{ _has_showcase=value;}
			get{return _has_showcase;}
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
		/// �Ӽ۷���
		/// </summary>
		public string increment
		{
			set{ _increment=value;}
			get{return _increment;}
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
		/// �����������˷�ģ��ID
		/// </summary>
		public long postage_id
		{
			set{ _postage_id=value;}
			get{return _postage_id;}
		}
		/// <summary>
		/// �������
		/// </summary>
		public int auction_point
		{
			set{ _auction_point=value;}
			get{return _auction_point;}
		}
		/// <summary>
		/// ����ֵ����
		/// </summary>
		public string property_alias
		{
			set{ _property_alias=value;}
			get{return _property_alias;}
		}
		/// <summary>
		/// �Ƿ�Ϊ������Ʒ
		/// </summary>
		public bool is_virtual
		{
			set{ _is_virtual=value;}
			get{return _is_virtual;}
		}
		/// <summary>
		/// �Ƿ����Ա���ʾ
		/// </summary>
		public bool is_taobao
		{
			set{ _is_taobao=value;}
			get{return _is_taobao;}
		}
		/// <summary>
		/// �Ƿ����ⲿ����ʹ��
		/// </summary>
		public bool is_ex
		{
			set{ _is_ex=value;}
			get{return _is_ex;}
		}
		/// <summary>
		/// �Ƿ�ʱ�ϼ�
		/// </summary>
		public bool is_timing
		{
			set{ _is_timing=value;}
			get{return _is_timing;}
		}
		/// <summary>
		/// �Ƿ��Ա�3D��Ʒ
		/// </summary>
		public bool is_3D
		{
			set{ _is_3d=value;}
			get{return _is_3d;}
		}
		/// <summary>
		/// �Ƿ���1վ��Ʒ
		/// </summary>
		public bool one_station
		{
			set{ _one_station=value;}
			get{return _one_station;}
		}
		/// <summary>
		/// ��ɱ����
		/// </summary>
		public string second_kill
		{
			set{ _second_kill=value;}
			get{return _second_kill;}
		}
		/// <summary>
		/// ������Ʒ����
		/// </summary>
		public string auto_fill
		{
			set{ _auto_fill=value;}
			get{return _auto_fill;}
		}
		/// <summary>
		/// ��Ʒ�Ƿ�Υ��
		/// </summary>
		public bool violation
		{
			set{ _violation=value;}
			get{return _violation;}
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
		/// ���������˷�ģ��ID
		/// </summary>
		public long cod_postage_id
		{
			set{ _cod_postage_id=value;}
			get{return _cod_postage_id;}
		}
		/// <summary>
		/// �Ƿ��ŵ�˻�������
		/// </summary>
		public bool sell_promise
		{
			set{ _sell_promise=value;}
			get{return _sell_promise;}
		}
        /// <summary>
        /// sku��Ϣ
        /// </summary>
        public M_GoodsSkuInfo[] skus
        {
            set { _skus = value; }
            get { return _skus; }
        }
        /// <summary>
        /// ��Ʒ���ڵ�
        /// </summary>
        public M_LocationInfo location
        {
            set { _location = value; }
            get { return _location; }
        }
        /// <summary>
        /// ��ƷͼƬ�б�
        /// </summary>
        public M_ImgInfo[] item_imgs
        {
            set { _item_imgs = value; }
            get { return _item_imgs; }
        }
        /// <summary>
        /// ��Ʒ����ͼƬ�б�
        /// </summary>
        public M_PropImgInfo[] prop_imgs
        {
            set { _prop_imgs = value; }
            get { return _prop_imgs; }
        }
        /// <summary>
        /// ��Ʒ��Ƶ�б�
        /// </summary>
        public M_VideoInfo[] videos
        {
            set { _videos = value; }
            get { return _videos; }
        }
        /// <summary>
        /// �Ƿ���ɾ��
        /// </summary>
        public bool m_IsDeltet
        {
            set { _m_IsDeltet = value; }
            get { return _m_IsDeltet; }
        }
        /// <summary>
        /// ϵͳ����ʱ��
        /// </summary>
        public DateTime m_UpdateTime
        {
            set { _m_UpdateTime = value; }
            get { return _m_UpdateTime; }
        }
		#endregion Model

	}
}

