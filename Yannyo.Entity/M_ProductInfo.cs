using System;
namespace Yannyo.Entity
{
	/// <summary>
	/// 实体类M_ProductInfo 。(属性说明自动提取数据库字段的描述信息)
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
		/// 网店产品系统编号
		/// </summary>
		public int m_ProductInfoID
		{
			set{ _m_productinfoid=value;}
			get{return _m_productinfoid;}
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
		/// Erp系统产品编号
		/// </summary>
		public int ProductsID
		{
			set{ _productsid=value;}
			get{return _productsid;}
		}
		/// <summary>
		/// 网店产品编号
		/// </summary>
		public long product_id
		{
			set{ _product_id=value;}
			get{return _product_id;}
		}
		/// <summary>
		/// 外部产品编号
		/// </summary>
		public string outer_id
		{
			set{ _outer_id=value;}
			get{return _outer_id;}
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
		/// 淘宝标准产品编码
		/// </summary>
		public string tsc
		{
			set{ _tsc=value;}
			get{return _tsc;}
		}
		/// <summary>
		/// 产品类目ID
		/// </summary>
		public string cid
		{
			set{ _cid=value;}
			get{return _cid;}
		}
		/// <summary>
		/// 短名称
		/// </summary>
		public string cat_name
		{
			set{ _cat_name=value;}
			get{return _cat_name;}
		}
		/// <summary>
		/// 产品的关键属性列表
		/// </summary>
		public string props
		{
			set{ _props=value;}
			get{return _props;}
		}
		/// <summary>
		/// 产品的关键属性字符串列表
		/// </summary>
		public string props_str
		{
			set{ _props_str=value;}
			get{return _props_str;}
		}
		/// <summary>
		/// 产品的非关键属性字符串列表
		/// </summary>
		public string binds_str
		{
			set{ _binds_str=value;}
			get{return _binds_str;}
		}
		/// <summary>
		/// 产品的销售属性字符串列表
		/// </summary>
		public string sale_props_str
		{
			set{ _sale_props_str=value;}
			get{return _sale_props_str;}
		}
		/// <summary>
		/// 长名称
		/// </summary>
		public string name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 产品的非关键属性列表
		/// </summary>
		public string binds
		{
			set{ _binds=value;}
			get{return _binds;}
		}
		/// <summary>
		/// 产品的销售属性列表
		/// </summary>
		public string sale_props
		{
			set{ _sale_props=value;}
			get{return _sale_props;}
		}
		/// <summary>
		/// 产品的市场价
		/// </summary>
		public decimal price
		{
			set{ _price=value;}
			get{return _price;}
		}
		/// <summary>
		/// 产品的描述
		/// </summary>
		public string m_desc
		{
			set{ _m_desc=value;}
			get{return _m_desc;}
		}
		/// <summary>
		/// 产品的主图片地址
		/// </summary>
		public string pic_url
		{
			set{ _pic_url=value;}
			get{return _pic_url;}
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
		/// 当前状态
		/// </summary>
		public int status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// 产品的collect次数
		/// </summary>
		public int collect_num
		{
			set{ _collect_num=value;}
			get{return _collect_num;}
		}
		/// <summary>
		/// 产品的级别level
		/// </summary>
		public int m_level
		{
			set{ _m_level=value;}
			get{return _m_level;}
		}
		/// <summary>
		/// 产品对应的图片路径
		/// </summary>
		public string pic_path
		{
			set{ _pic_path=value;}
			get{return _pic_path;}
		}
		/// <summary>
		/// 垂直市场
		/// </summary>
		public int vertical_market
		{
			set{ _vertical_market=value;}
			get{return _vertical_market;}
		}
		/// <summary>
		/// 用户自定义属性
		/// </summary>
		public string customer_props
		{
			set{ _customer_props=value;}
			get{return _customer_props;}
		}
		/// <summary>
		/// 销售属性值别名
		/// </summary>
		public string property_alias
		{
			set{ _property_alias=value;}
			get{return _property_alias;}
		}
		#endregion Model

	}
}

