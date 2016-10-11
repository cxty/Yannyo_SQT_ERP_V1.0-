using System;

namespace Yannyo.Entity
{
	public class ProductsFieldValueInfo
	{
		private int _ProductsFieldValueID;
		private int _ProductsID;
		private int _ProductFieldID;
		private int _pfvType;
		private string _pfvData;
		private DateTime _pfvAppendTime;

		public int ProductsFieldValueID
		{
			set { _ProductsFieldValueID = value; }
			get { return _ProductsFieldValueID; }
		}
		public int ProductsID
		{
			set { _ProductsID = value; }
			get { return _ProductsID; }
		}
		public int ProductFieldID
		{
			set { _ProductFieldID = value; }
			get { return _ProductFieldID; }
		}
		public int pfvType
		{
			set { _pfvType = value; }
			get { return _pfvType; }
		}
		public string pfvData
		{
			set { _pfvData = value; }
			get { return _pfvData; }
		}
		public DateTime pfvAppendTime
		{
			set { _pfvAppendTime = value; }
			get { return _pfvAppendTime; }
		}

	}
	public class ProductFieldValueJson{
		private FieldValue[] _FieldValue;
		public FieldValue[] FieldValue
		{
			set { _FieldValue = value; }
			get { return _FieldValue; }
		}
	}
	public class FieldValue{
		private int _ProductFieldValueID;
		private int _ProductFieldID;
		private string _value;
		private int _Type;

		public int ProductFieldValueID
		{
			set { _ProductFieldValueID = value; }
			get { return _ProductFieldValueID; }
		}
		public int ProductFieldID
		{
			set { _ProductFieldID = value; }
			get { return _ProductFieldID; }
		}
		public int Type
		{
			set { _Type = value; }
			get { return _Type; }
		}
		public string value
		{
			set { _value = value; }
			get { return _value; }
		}
	}
}

