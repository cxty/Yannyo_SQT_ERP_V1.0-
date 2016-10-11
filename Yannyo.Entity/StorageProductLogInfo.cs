using System;

namespace Yannyo.Entity
{
	public class StorageProductLogInfo
	{
		private int _storageproductlogid;
		private int _OrderListID;
		private int _storageid;
		private int _staffid;
		private int _orderid;
		private string _splremake;
		private DateTime _splappendtime;


		private StorageOrderListDataJson _StorageOrderListDataJson;

		/// <summary>
		/// 
		/// </summary>
		public int StorageProductLogID
		{
			set{ _storageproductlogid=value;}
			get{return _storageproductlogid;}
		}
		public int OrderListID
		{
			set{ _OrderListID=value;}
			get{return _OrderListID;}
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
		public int StaffID
		{
			set{ _staffid=value;}
			get{return _staffid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int OrderID
		{
			set{ _orderid=value;}
			get{return _orderid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string splRemake
		{
			set{ _splremake=value;}
			get{return _splremake;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime splAppendTime
		{
			set{ _splappendtime=value;}
			get{return _splappendtime;}
		}

		public StorageOrderListDataJson StorageOrderListDataJson
		{
			set { _StorageOrderListDataJson = value;}
			get { return _StorageOrderListDataJson; }
		}
	}
}

