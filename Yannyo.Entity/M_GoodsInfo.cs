using System;
namespace Yannyo.Entity
{
	/// <summary>
	/// 实体类M_GoodsInfo 。(属性说明自动提取数据库字段的描述信息)
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
		/// 商品信息系统编号
		/// </summary>
		public int m_GoodsID
		{
			set{ _m_goodsid=value;}
			get{return _m_goodsid;}
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
		/// 所属Erp系统产品编号
		/// </summary>
		public int ProductsID
		{
			set{ _productsid=value;}
			get{return _productsid;}
		}
		/// <summary>
		/// 所属系统产品编号
		/// </summary>
		public int m_ProductInfoID
		{
			set{ _m_productinfoid=value;}
			get{return _m_productinfoid;}
		}
		/// <summary>
		/// 所属产品的id
		/// </summary>
		public long product_id
		{
			set{ _product_id=value;}
			get{return _product_id;}
		}
        /// <summary>
        /// 所属产品名称
        /// </summary>
        public string ProductsName
        {
            set { _ProductsName = value; }
            get { return _ProductsName; }
        }
		/// <summary>
		/// 外部编号
		/// </summary>
		public string outer_id
		{
			set{ _outer_id=value;}
			get{return _outer_id;}
		}
		/// <summary>
		/// 网店商品编号
		/// </summary>
		public long num_iid
		{
			set{ _num_iid=value;}
			get{return _num_iid;}
		}
		/// <summary>
		/// 商品URL
		/// </summary>
		public string detail_url
		{
			set{ _detail_url=value;}
			get{return _detail_url;}
		}
		/// <summary>
		/// 标题
		/// </summary>
		public string title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 卖家昵称
		/// </summary>
		public string nick
		{
			set{ _nick=value;}
			get{return _nick;}
		}
		/// <summary>
		/// 商品类型
		/// </summary>
		public string type
		{
			set{ _type=value;}
			get{return _type;}
		}
		/// <summary>
		/// 商品属性名称
		/// </summary>
		public string props_name
		{
			set{ _props_name=value;}
			get{return _props_name;}
		}
		/// <summary>
		/// 消保类型，多个类型以,分割
		/// </summary>
		public string promoted_service
		{
			set{ _promoted_service=value;}
			get{return _promoted_service;}
		}
		/// <summary>
		/// 商品所属的叶子类目 id
		/// </summary>
		public long cid
		{
			set{ _cid=value;}
			get{return _cid;}
		}
		/// <summary>
		/// 商品所属的店铺内卖家自定义类目列表
		/// </summary>
		public string seller_cids
		{
			set{ _seller_cids=value;}
			get{return _seller_cids;}
		}
        /// <summary>
        /// 所属商城类目名称
        /// </summary>
        public string mCatName
        {
            set { _mCatName = value; }
            get { return _mCatName; }
        }
		/// <summary>
		/// 商品属性
		/// </summary>
		public string props
		{
			set{ _props=value;}
			get{return _props;}
		}
		/// <summary>
		/// 用户自行输入的类目属性ID串
		/// </summary>
		public string input_pids
		{
			set{ _input_pids=value;}
			get{return _input_pids;}
		}
		/// <summary>
		/// 用户自行输入的子属性名和属性值
		/// </summary>
		public string input_str
		{
			set{ _input_str=value;}
			get{return _input_str;}
		}
		/// <summary>
		/// 商品描述
		/// </summary>
		public string m_desc
		{
			set{ _m_desc=value;}
			get{return _m_desc;}
		}
		/// <summary>
		/// 商品主图片地址
		/// </summary>
		public string pic_url
		{
			set{ _pic_url=value;}
			get{return _pic_url;}
		}
		/// <summary>
		/// 数量
		/// </summary>
		public int num
		{
			set{ _num=value;}
			get{return _num;}
		}
		/// <summary>
		/// 有效期
		/// </summary>
		public int valid_thru
		{
			set{ _valid_thru=value;}
			get{return _valid_thru;}
		}
		/// <summary>
		/// 上架时间
		/// </summary>
		public DateTime list_time
		{
			set{ _list_time=value;}
			get{return _list_time;}
		}
		/// <summary>
		/// 下架时间
		/// </summary>
		public DateTime delist_time
		{
			set{ _delist_time=value;}
			get{return _delist_time;}
		}
		/// <summary>
		/// 商品新旧程度
		/// </summary>
		public string stuff_status
		{
			set{ _stuff_status=value;}
			get{return _stuff_status;}
		}
		/// <summary>
		/// 商品价格
		/// </summary>
		public decimal price
		{
			set{ _price=value;}
			get{return _price;}
		}
		/// <summary>
		/// 平邮
		/// </summary>
		public decimal post_fee
		{
			set{ _post_fee=value;}
			get{return _post_fee;}
		}
		/// <summary>
		/// 快递
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
		/// 是否会员打折
		/// </summary>
		public bool has_discount
		{
			set{ _has_discount=value;}
			get{return _has_discount;}
		}
		/// <summary>
		/// 运费承担方式
		/// </summary>
		public string freight_payer
		{
			set{ _freight_payer=value;}
			get{return _freight_payer;}
		}
		/// <summary>
		/// 是否含发票
		/// </summary>
		public bool has_invoice
		{
			set{ _has_invoice=value;}
			get{return _has_invoice;}
		}
		/// <summary>
		/// 是否有报修
		/// </summary>
		public bool has_warranty
		{
			set{ _has_warranty=value;}
			get{return _has_warranty;}
		}
		/// <summary>
		/// 是否橱窗推荐
		/// </summary>
		public bool has_showcase
		{
			set{ _has_showcase=value;}
			get{return _has_showcase;}
		}
		/// <summary>
		/// 修改时间
		/// </summary>
		public DateTime modified
		{
			set{ _modified=value;}
			get{return _modified;}
		}
		/// <summary>
		/// 加价幅度
		/// </summary>
		public string increment
		{
			set{ _increment=value;}
			get{return _increment;}
		}
		/// <summary>
		/// 商品上传后的状态
		/// </summary>
		public string approve_status
		{
			set{ _approve_status=value;}
			get{return _approve_status;}
		}
		/// <summary>
		/// 宝贝所属的运费模板ID
		/// </summary>
		public long postage_id
		{
			set{ _postage_id=value;}
			get{return _postage_id;}
		}
		/// <summary>
		/// 返点比例
		/// </summary>
		public int auction_point
		{
			set{ _auction_point=value;}
			get{return _auction_point;}
		}
		/// <summary>
		/// 属性值别名
		/// </summary>
		public string property_alias
		{
			set{ _property_alias=value;}
			get{return _property_alias;}
		}
		/// <summary>
		/// 是否为虚拟商品
		/// </summary>
		public bool is_virtual
		{
			set{ _is_virtual=value;}
			get{return _is_virtual;}
		}
		/// <summary>
		/// 是否在淘宝显示
		/// </summary>
		public bool is_taobao
		{
			set{ _is_taobao=value;}
			get{return _is_taobao;}
		}
		/// <summary>
		/// 是否在外部网店使用
		/// </summary>
		public bool is_ex
		{
			set{ _is_ex=value;}
			get{return _is_ex;}
		}
		/// <summary>
		/// 是否定时上架
		/// </summary>
		public bool is_timing
		{
			set{ _is_timing=value;}
			get{return _is_timing;}
		}
		/// <summary>
		/// 是否淘宝3D商品
		/// </summary>
		public bool is_3D
		{
			set{ _is_3d=value;}
			get{return _is_3d;}
		}
		/// <summary>
		/// 是否淘1站商品
		/// </summary>
		public bool one_station
		{
			set{ _one_station=value;}
			get{return _one_station;}
		}
		/// <summary>
		/// 秒杀类型
		/// </summary>
		public string second_kill
		{
			set{ _second_kill=value;}
			get{return _second_kill;}
		}
		/// <summary>
		/// 代充商品类型
		/// </summary>
		public string auto_fill
		{
			set{ _auto_fill=value;}
			get{return _auto_fill;}
		}
		/// <summary>
		/// 商品是否违规
		/// </summary>
		public bool violation
		{
			set{ _violation=value;}
			get{return _violation;}
		}
		/// <summary>
		/// 发布时间
		/// </summary>
		public DateTime created
		{
			set{ _created=value;}
			get{return _created;}
		}
		/// <summary>
		/// 货到付款运费模板ID
		/// </summary>
		public long cod_postage_id
		{
			set{ _cod_postage_id=value;}
			get{return _cod_postage_id;}
		}
		/// <summary>
		/// 是否承诺退换货服务
		/// </summary>
		public bool sell_promise
		{
			set{ _sell_promise=value;}
			get{return _sell_promise;}
		}
        /// <summary>
        /// sku信息
        /// </summary>
        public M_GoodsSkuInfo[] skus
        {
            set { _skus = value; }
            get { return _skus; }
        }
        /// <summary>
        /// 商品所在地
        /// </summary>
        public M_LocationInfo location
        {
            set { _location = value; }
            get { return _location; }
        }
        /// <summary>
        /// 商品图片列表
        /// </summary>
        public M_ImgInfo[] item_imgs
        {
            set { _item_imgs = value; }
            get { return _item_imgs; }
        }
        /// <summary>
        /// 商品属性图片列表
        /// </summary>
        public M_PropImgInfo[] prop_imgs
        {
            set { _prop_imgs = value; }
            get { return _prop_imgs; }
        }
        /// <summary>
        /// 商品视频列表
        /// </summary>
        public M_VideoInfo[] videos
        {
            set { _videos = value; }
            get { return _videos; }
        }
        /// <summary>
        /// 是否已删除
        /// </summary>
        public bool m_IsDeltet
        {
            set { _m_IsDeltet = value; }
            get { return _m_IsDeltet; }
        }
        /// <summary>
        /// 系统更新时间
        /// </summary>
        public DateTime m_UpdateTime
        {
            set { _m_UpdateTime = value; }
            get { return _m_UpdateTime; }
        }
		#endregion Model

	}
}

