using System;

namespace Yannyo.Entity
{
	public class ProductPriceNOAutoInfo
	{
		public ProductPriceNOAutoInfo ()
		{
		}
		private int _ProductPriceNOAutoID;
		private int _productsid;
		private DateTime _ppappendtime;
		private decimal _NowPrice;
		private decimal _NowPriceRMB;

		/// <summary>
		/// 产品编号
		/// </summary>
		public int ProductsID
		{
			set { _productsid = value; }
			get { return _productsid; }
		}

		public int ProductPriceNOAutoID
		{
			set{ _ProductPriceNOAutoID = value;}
			get{ return _ProductPriceNOAutoID;}
		}
		public DateTime ppAppendTime
		{
			set{ _ppappendtime = value;}
			get{ return _ppappendtime;}
		}
		public decimal Price
		{
			set{ _NowPrice = value;}
			get{ return _NowPrice;}
		}
		public decimal PriceRMB
		{
			set{ _NowPriceRMB = value;}
			get{ return _NowPriceRMB;}
		}
	}
}

