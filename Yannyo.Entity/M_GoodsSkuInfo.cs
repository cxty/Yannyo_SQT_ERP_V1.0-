using System;
namespace Yannyo.Entity
{
	/// <summary>
	/// 实体类M_GoodsSkuInfo 。(属性说明自动提取数据库字段的描述信息)
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
		/// 商品Sku系统编号
		/// </summary>
		public int m_GoodsSkuInfoID
		{
			set{ _m_goodsskuinfoid=value;}
			get{return _m_goodsskuinfoid;}
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
		/// 对应类型
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
		/// 网店Sku编号
		/// </summary>
		public long sku_id
		{
			set{ _sku_id=value;}
			get{return _sku_id;}
		}
		/// <summary>
		/// 所属网店对象编号
		/// </summary>
		public long num_iid
		{
			set{ _num_iid=value;}
			get{return _num_iid;}
		}
		/// <summary>
		/// 销售属性组合字符串
		/// </summary>
		public string properties
		{
			set{ _properties=value;}
			get{return _properties;}
		}
		/// <summary>
		/// 属于该Sku的商品数量
		/// </summary>
		public int quantity
		{
			set{ _quantity=value;}
			get{return _quantity;}
		}
		/// <summary>
		/// 属于该Sku的商品的价格
		/// </summary>
		public decimal price
		{
			set{ _price=value;}
			get{return _price;}
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
		/// 创建时间
		/// </summary>
		public DateTime created
		{
			set{ _created=value;}
			get{return _created;}
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
		/// 状态
		/// </summary>
		public string status
		{
			set{ _status=value;}
			get{return _status;}
		}
		#endregion Model

	}
}

