using System;
namespace Yannyo.Entity
{
	/// <summary>
	/// ʵ����M_GoodsSkuExtraInfo ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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
		/// ��չ��Ϣϵͳ���
		/// </summary>
		public int m_GoodsSkuExtraInfoID
		{
			set{ _m_goodsskuextrainfoid=value;}
			get{return _m_goodsskuextrainfoid;}
		}
		/// <summary>
		/// ����ϵͳSku���
		/// </summary>
		public int m_GoodsSkuInfoID
		{
			set{ _m_goodsskuinfoid=value;}
			get{return _m_goodsskuinfoid;}
		}
		/// <summary>
		/// ����ϵͳ���
		/// </summary>
		public int extra_id
		{
			set{ _extra_id=value;}
			get{return _extra_id;}
		}
		/// <summary>
		/// ��������ϵͳSku���
		/// </summary>
		public int sku_id
		{
			set{ _sku_id=value;}
			get{return _sku_id;}
		}
		/// <summary>
		/// sku��������������ַ���
		/// </summary>
		public string properties
		{
			set{ _properties=value;}
			get{return _properties;}
		}
		/// <summary>
		/// �������sku����Ʒ������
		/// </summary>
		public int quantity
		{
			set{ _quantity=value;}
			get{return _quantity;}
		}
		/// <summary>
		/// �������sku����Ʒ�ļ۸�
		/// </summary>
		public decimal price
		{
			set{ _price=value;}
			get{return _price;}
		}
		/// <summary>
		/// ��ע
		/// </summary>
		public string memo
		{
			set{ _memo=value;}
			get{return _memo;}
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
		/// �޸�ʱ��
		/// </summary>
		public DateTime modified
		{
			set{ _modified=value;}
			get{return _modified;}
		}
		#endregion Model

	}
}

