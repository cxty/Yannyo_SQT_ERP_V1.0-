using System;

namespace Yannyo.Entity
{
	public class ProductFieldInfo
	{
		private int _ProductFieldID;
		private int _ProductClassID;
		private string _pfName;
		private int _pfType;
		private int _pfOrder;
		private int _pfState;
		private DateTime _pfAppendTime;
		private string _ProductClassName;


		public int ProductFieldID
		{
			set { _ProductFieldID = value; }
			get { return _ProductFieldID; }
		}
		public int ProductClassID
		{
			set { _ProductClassID = value; }
			get { return _ProductClassID; }
		}
		public string ProductClassName
		{
			set{_ProductClassName = value;}
			get{return _ProductClassName;}
		}
		public string pfName
		{
			set { _pfName = value; }
			get { return _pfName; }
		}
		public int pfType
		{
			set { _pfType = value; }
			get { return _pfType; }
		}
		public int pfOrder
		{
			set { _pfOrder = value; }
			get { return _pfOrder; }
		}
		public int pfState
		{
			set { _pfState = value; }
			get { return _pfState; }
		}
		public DateTime pfAppendTime
		{
			set { _pfAppendTime = value; }
			get { return _pfAppendTime; }
		}
	}
}

