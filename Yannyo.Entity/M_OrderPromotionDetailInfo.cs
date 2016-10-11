using System;
namespace Yannyo.Entity
{
	/// <summary>
	/// 实体类M_OrderPromotionDetailInfo 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class M_OrderPromotionDetailInfo
	{
		public M_OrderPromotionDetailInfo()
		{}
		#region Model
		private int _m_order_promotiondetailinfoid;
		private int _m_type;
		private int _m_objid;
		private long _m_id;
		private string _promotion_name;
		private decimal _discount_fee;
		private string _gift_item_name;
		/// <summary>
		/// 优惠信息编号
		/// </summary>
		public int m_Order_PromotionDetailInfoID
		{
			set{ _m_order_promotiondetailinfoid=value;}
			get{return _m_order_promotiondetailinfoid;}
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
		/// 订单编号
		/// </summary>
		public int m_ObjID
		{
			set{ _m_objid=value;}
			get{return _m_objid;}
		}
		/// <summary>
		/// 网店系统订单编号
		/// </summary>
		public long m_id
		{
			set{ _m_id=value;}
			get{return _m_id;}
		}
		/// <summary>
		/// 优惠信息名称
		/// </summary>
		public string promotion_name
		{
			set{ _promotion_name=value;}
			get{return _promotion_name;}
		}
		/// <summary>
		/// 优惠金额
		/// </summary>
		public decimal discount_fee
		{
			set{ _discount_fee=value;}
			get{return _discount_fee;}
		}
		/// <summary>
		/// 满就送商品时，所送商品的名称
		/// </summary>
		public string gift_item_name
		{
			set{ _gift_item_name=value;}
			get{return _gift_item_name;}
		}
		#endregion Model

	}
}

