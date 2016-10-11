using System;

namespace Yannyo.Entity
{
	public class StorageProductLogDataInfo
	{
		private int _storageproductlogdataid;
		private int _storageproductlogid;
		private int _storageid;
		private int _productsid;
		private int _pquantity;
		private int _OrderListID;
		/// <summary>
		/// 
		/// </summary>
		public int StorageProductLogDataID
		{
			set{ _storageproductlogdataid=value;}
			get{return _storageproductlogdataid;}
		}
		public int OrderListID
		{
			set{ _OrderListID=value;}
			get{return _OrderListID;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int StorageProductLogID
		{
			set{ _storageproductlogid=value;}
			get{return _storageproductlogid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int StorageID
		{
			set{ _storageid=value;}
			get{return _storageid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int ProductsID
		{
			set{ _productsid=value;}
			get{return _productsid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int pQuantity
		{
			set{ _pquantity=value;}
			get{return _pquantity;}
		}
	}
}

