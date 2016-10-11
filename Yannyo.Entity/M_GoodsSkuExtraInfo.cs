using System;
namespace Yannyo.Entity
{
	/// <summary>
	/// 实体类M_GoodsSkuExtraInfo 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class M_GoodsSkuExtraInfo
	{
		public M_GoodsSkuExtraInfo()
		{}
		#region Model
		private int _m_goodsskuextrainfoid;
		private int _m_goodsskuinfoid;
		private int _extra_id;
		private int _sku_id;
		private string _properties;
		private int _quantity;
		private decimal _price;
		private string _memo;
		private DateTime _created;
		private DateTime _modified;
		/// <summary>
		/// 扩展信息系统编号
		/// </summary>
		public int m_GoodsSkuExtraInfoID
		{
			set{ _m_goodsskuextrainfoid=value;}
			get{return _m_goodsskuextrainfoid;}
		}
		/// <summary>
		/// 所属系统Sku编号
		/// </summary>
		public int m_GoodsSkuInfoID
		{
			set{ _m_goodsskuinfoid=value;}
			get{return _m_goodsskuinfoid;}
		}
		/// <summary>
		/// 网店系统编号
		/// </summary>
		public int extra_id
		{
			set{ _extra_id=value;}
			get{return _extra_id;}
		}
		/// <summary>
		/// 所属网店系统Sku编号
		/// </summary>
		public int sku_id
		{
			set{ _sku_id=value;}
			get{return _sku_id;}
		}
		/// <summary>
		/// sku的销售属性组合字符串
		/// </summary>
		public string properties
		{
			set{ _properties=value;}
			get{return _properties;}
		}
		/// <summary>
		/// 属于这个sku的商品的数量
		/// </summary>
		public int quantity
		{
			set{ _quantity=value;}
			get{return _quantity;}
		}
		/// <summary>
		/// 属于这个sku的商品的价格
		/// </summary>
		public decimal price
		{
			set{ _price=value;}
			get{return _price;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string memo
		{
			set{ _memo=value;}
			get{return _memo;}
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
		#endregion Model

	}
}

