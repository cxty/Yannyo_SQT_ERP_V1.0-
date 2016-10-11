using System;
namespace Yannyo.Entity
{
	/// <summary>
	/// ʵ����M_OrderPromotionDetailInfo ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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
		/// �Ż���Ϣ���
		/// </summary>
		public int m_Order_PromotionDetailInfoID
		{
			set{ _m_order_promotiondetailinfoid=value;}
			get{return _m_order_promotiondetailinfoid;}
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
		/// �������
		/// </summary>
		public int m_ObjID
		{
			set{ _m_objid=value;}
			get{return _m_objid;}
		}
		/// <summary>
		/// ����ϵͳ�������
		/// </summary>
		public long m_id
		{
			set{ _m_id=value;}
			get{return _m_id;}
		}
		/// <summary>
		/// �Ż���Ϣ����
		/// </summary>
		public string promotion_name
		{
			set{ _promotion_name=value;}
			get{return _promotion_name;}
		}
		/// <summary>
		/// �Żݽ��
		/// </summary>
		public decimal discount_fee
		{
			set{ _discount_fee=value;}
			get{return _discount_fee;}
		}
		/// <summary>
		/// ��������Ʒʱ��������Ʒ������
		/// </summary>
		public string gift_item_name
		{
			set{ _gift_item_name=value;}
			get{return _gift_item_name;}
		}
		#endregion Model

	}
}

