using System;
namespace Yannyo.Entity
{
	/// <summary>
	/// 实体类M_GoodsExtraInfo 。(属性说明自动提取数据库字段的描述信息)
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
		/// 商品扩展信息系统编号
		/// </summary>
		public int m_GoodsExtraInfoID
		{
			set{ _m_goodsextrainfoid=value;}
			get{return _m_goodsextrainfoid;}
		}
		/// <summary>
		/// 所属系统商品编号
		/// </summary>
		public int m_GoodsID
		{
			set{ _m_goodsid=value;}
			get{return _m_goodsid;}
		}
		/// <summary>
		/// 网店系统扩展信息编号
		/// </summary>
		public int eid
		{
			set{ _eid=value;}
			get{return _eid;}
		}
		/// <summary>
		/// 商品网店系统编号
		/// </summary>
		public int num_iid
		{
			set{ _num_iid=value;}
			get{return _num_iid;}
		}
		/// <summary>
		/// 扩展标题
		/// </summary>
		public string title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 扩展描述
		/// </summary>
		public string m_desc
		{
			set{ _m_desc=value;}
			get{return _m_desc;}
		}
		/// <summary>
		/// 自定义信息
		/// </summary>
		public string feature
		{
			set{ _feature=value;}
			get{return _feature;}
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
		/// 扩展商品的类型
		/// </summary>
		public string type
		{
			set{ _type=value;}
			get{return _type;}
		}
		/// <summary>
		/// 扩展商品的价格
		/// </summary>
		public decimal reserve_price
		{
			set{ _reserve_price=value;}
			get{return _reserve_price;}
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
		/// 商品上传后的状态
		/// </summary>
		public string approve_status
		{
			set{ _approve_status=value;}
			get{return _approve_status;}
		}
		/// <summary>
		/// 图片地址
		/// </summary>
		public string pic_url
		{
			set{ _pic_url=value;}
			get{return _pic_url;}
		}
		/// <summary>
		/// options字段，用于对扩展商品按位打某些标记
		/// </summary>
		public int options
		{
			set{ _options=value;}
			get{return _options;}
		}
		/// <summary>
		/// 商品里面的主图地址
		/// </summary>
		public string item_pic_url
		{
			set{ _item_pic_url=value;}
			get{return _item_pic_url;}
		}
		/// <summary>
		/// 商品Item里面的options字段
		/// </summary>
		public int item_options
		{
			set{ _item_options=value;}
			get{return _item_options;}
		}
		/// <summary>
		/// 商品Item库存
		/// </summary>
		public int item_num
		{
			set{ _item_num=value;}
			get{return _item_num;}
		}
		#endregion Model

	}
}

