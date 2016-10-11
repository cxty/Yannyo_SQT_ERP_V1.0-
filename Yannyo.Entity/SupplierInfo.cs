using System;

namespace Yannyo.Entity
{
    public class SupplierInfo
    {
        private int _supplierid;
        private string _sname;
        private string _scode;
        private string _saddress;
        private string _stel;
        private string _slinkman;
        private int _sdoday;
        private decimal _sdodaymoney;
        private DateTime _sappendtime;
        private int _SupplierClassID;
        private string _SupplierClassName;
        private string _sLicense;
        /// <summary>
        /// 
        /// </summary>
        public int SupplierID
        {
            set { _supplierid = value; }
            get { return _supplierid; }
        }
        public int SupplierClassID
        {
            set { _SupplierClassID = value; }
            get { return _SupplierClassID; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string sName
        {
            set { _sname = value; }
            get { return _sname; }
        }
        public string SupplierClassName
        {
            set { _SupplierClassName = value; }
            get { return _SupplierClassName; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string sCode
        {
            set { _scode = value; }
            get { return _scode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string sAddress
        {
            set { _saddress = value; }
            get { return _saddress; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string sTel
        {
            set { _stel = value; }
            get { return _stel; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string sLinkMan
        {
            set { _slinkman = value; }
            get { return _slinkman; }
        }
        /// <summary>
        /// 企业公司注册号
        /// </summary>
        public string sLicense
        {
            set { _sLicense = value; }
            get { return _sLicense; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int sDoDay
        {
            set { _sdoday = value; }
            get { return _sdoday; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal sDoDayMoney
        {
            set { _sdodaymoney = value; }
            get { return _sdodaymoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime sAppendTime
        {
            set { _sappendtime = value; }
            get { return _sappendtime; }
        }
    }
}
