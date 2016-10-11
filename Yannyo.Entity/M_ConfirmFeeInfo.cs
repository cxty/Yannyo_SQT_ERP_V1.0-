using System;

namespace Yannyo.Entity
{
   public  class M_ConfirmFeeInfo
    {
       public M_ConfirmFeeInfo()
		{}
		private int _m_confirmfeeinfoid;
		private int _m_type;
		private int _m_objid;
		private decimal _confirm_fee;
		private decimal _confirm_post_fee;
		private bool _is_last_order;
		private DateTime _mappendtime;
		/// <summary>
		/// 费用编号
		/// </summary>
		public int m_ConfirmFeeInfoID
		{
			set{ _m_confirmfeeinfoid=value;}
			get{return _m_confirmfeeinfoid;}
		}
		/// <summary>
		/// 费用类型
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
		/// 确认收货的金额
		/// </summary>
		public decimal confirm_fee
		{
			set{ _confirm_fee=value;}
			get{return _confirm_fee;}
		}
		/// <summary>
		/// 需确认收货的邮费
		/// </summary>
		public decimal confirm_post_fee
		{
			set{ _confirm_post_fee=value;}
			get{return _confirm_post_fee;}
		}
		/// <summary>
		/// 是否是最后一笔订单
		/// </summary>
		public bool is_last_order
		{
			set{ _is_last_order=value;}
			get{return _is_last_order;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime mAppendTime
		{
			set{ _mappendtime=value;}
			get{return _mappendtime;}
		}
    }
}
