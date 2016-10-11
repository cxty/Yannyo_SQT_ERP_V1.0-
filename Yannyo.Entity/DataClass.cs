using System;

namespace Yannyo.Entity
{
    public class CustomersClassInfo
    {
        public CustomersClassInfo()
        { }
        #region Model
        private int _customersclassid;
        private int _cparentid;
        private string _cclassname;
        private int _corder;
        private DateTime _cappendtime;
        /// <summary>
        /// 
        /// </summary>
        public int CustomersClassID
        {
            set { _customersclassid = value; }
            get { return _customersclassid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int cParentID
        {
            set { _cparentid = value; }
            get { return _cparentid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cClassName
        {
            set { _cclassname = value; }
            get { return _cclassname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int cOrder
        {
            set { _corder = value; }
            get { return _corder; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime cAppendTime
        {
            set { _cappendtime = value; }
            get { return _cappendtime; }
        }
        #endregion
    }
    public class DepartmentsClassInfo
    {
        #region Model
        private int _departmentsclassid;
        private int _dparentid;
        private string _dclassname;
        private int _dorder;
        private DateTime _dappendtime;
        /// <summary>
        /// 
        /// </summary>
        public int DepartmentsClassID
        {
            set { _departmentsclassid = value; }
            get { return _departmentsclassid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int dParentID
        {
            set { _dparentid = value; }
            get { return _dparentid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string dClassName
        {
            set { _dclassname = value; }
            get { return _dclassname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int dOrder
        {
            set { _dorder = value; }
            get { return _dorder; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime dAppendTime
        {
            set { _dappendtime = value; }
            get { return _dappendtime; }
        }
        #endregion 

    }
    public class PriceClassInfo
	{
		#region Model
		private int _priceclassid;
		private int _pparentid;
		private string _pclassname;
		private int _porder;
		private DateTime _pappendtime;
		/// <summary>
		/// 
		/// </summary>
		public int PriceClassID
		{
			set{ _priceclassid=value;}
			get{return _priceclassid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int pParentID
		{
			set{ _pparentid=value;}
			get{return _pparentid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string pClassName
		{
			set{ _pclassname=value;}
			get{return _pclassname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int pOrder
		{
			set{ _porder=value;}
			get{return _porder;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime pAppendTime
		{
			set{ _pappendtime=value;}
			get{return _pappendtime;}
		}
		#endregion 

	}
    public class ProductClassInfo
    {

        #region Model
        private int _productclassid;
        private int _pparentid;
        private string _pclassname;
        private int _porder;
        private DateTime _pappendtime;
        /// <summary>
        /// 
        /// </summary>
        public int ProductClassID
        {
            set { _productclassid = value; }
            get { return _productclassid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int pParentID
        {
            set { _pparentid = value; }
            get { return _pparentid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string pClassName
        {
            set { _pclassname = value; }
            get { return _pclassname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int pOrder
        {
            set { _porder = value; }
            get { return _porder; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime pAppendTime
        {
            set { _pappendtime = value; }
            get { return _pappendtime; }
        }
        #endregion 

    }
    public class SupplierClassInfo
    {
        #region Model
        private int _supplierclassid;
        private int _sparentid;
        private string _sclassname;
        private int _sorder;
        private DateTime _sappendtime;
        /// <summary>
        /// 
        /// </summary>
        public int SupplierClassID
        {
            set { _supplierclassid = value; }
            get { return _supplierclassid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int sParentID
        {
            set { _sparentid = value; }
            get { return _sparentid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string sClassName
        {
            set { _sclassname = value; }
            get { return _sclassname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int sOrder
        {
            set { _sorder = value; }
            get { return _sorder; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime sAppendTime
        {
            set { _sappendtime = value; }
            get { return _sappendtime; }
        }
        #endregion 

    }
    public class FeesSubjectClassInfo
    {
        public FeesSubjectClassInfo()
        { }
        #region Model
        private int _FeesSubjectClassID;
        private int _cparentid;
        private string _cclassname;
        private int _corder;
        private DateTime _cappendtime;
        private int _cDirection;
        private string _cCode;
        private int _cType;
        /// <summary>
        /// 
        /// </summary>
        public int FeesSubjectClassID
        {
            set { _FeesSubjectClassID = value; }
            get { return _FeesSubjectClassID; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int cParentID
        {
            set { _cparentid = value; }
            get { return _cparentid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cClassName
        {
            set { _cclassname = value; }
            get { return _cclassname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int cOrder
        {
            set { _corder = value; }
            get { return _corder; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime cAppendTime
        {
            set { _cappendtime = value; }
            get { return _cappendtime; }
        }
        /// <summary>
        /// 科目编码
        /// </summary>
        public string cCode
        {
            set { _cCode = value; }
            get { return _cCode; }
        }
        /// <summary>
        /// 借贷关系(余额方向)
        /// </summary>
        public int cDirection
        {
            set { _cDirection = value; }
            get { return _cDirection; }
        }
        /// <summary>
        /// 类型
        /// </summary>
        public int cType
        {
            set { _cType = value; }
            get { return _cType; }
        }
        #endregion
    }
}
