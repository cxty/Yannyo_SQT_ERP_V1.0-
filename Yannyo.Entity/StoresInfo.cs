using System;

namespace Yannyo.Entity
{
    public class StoresInfo
    {
        public StoresInfo()
        { }
        #region Model
        private int _storesid;
        private string _sname;
        private string _scode;
        private string _stype;
        private int _regionid;
        private int _sstate;
        private DateTime _sappendtime;
        private int _YHsysID;
        private int _sIsFZYH;
        private string _YHsysName;
        private int _PaymentSystemID;
        private string _PaymentSystemName;
        private int _sDoDay;
        private decimal _sDoDayMoney;
        private int _CustomersClassID;
        private string _CustomersClassName;
        private int _PriceClassID;
        private string _PriceClassName;
        private string _sContact;
        private string _sTel;
        private string _sAddress;
        private string _sEmail;
        private string _sLicense;
        /// <summary>
        /// 门店系统编号
        /// </summary>
        public int StoresID
        {
            set { _storesid = value; }
            get { return _storesid; }
        }
        public int CustomersClassID
        {
            set { _CustomersClassID = value; }
            get { return _CustomersClassID; }
        }
        public string CustomersClassName
        {
            set { _CustomersClassName = value; }
            get { return _CustomersClassName; }
        }
        public int PriceClassID
        {
            set { _PriceClassID = value; }
            get { return _PriceClassID; }
        }
        public string PriceClassName
        {
            set { _PriceClassName = value; }
            get { return _PriceClassName; }
        }
        /// <summary>
        /// 结算系统编号
        /// </summary>
        public int PaymentSystemID
        {
            set { _PaymentSystemID = value; }
            get { return _PaymentSystemID; }
        }
        /// <summary>
        /// 门店名称
        /// </summary>
        public string sName
        {
            set { _sname = value; }
            get { return _sname; }
        }
        /// <summary>
        /// 结算系统名称
        /// </summary>
        public string PaymentSystemName
        {
            set { _PaymentSystemName = value; }
            get { return _PaymentSystemName; }
        }
        /// <summary>
        /// 门店编号
        /// </summary>
        public string sCode
        {
            set { _scode = value; }
            get { return _scode; }
        }
        /// <summary>
        /// 类型
        /// </summary>
        public string sType
        {
            set { _stype = value; }
            get { return _stype; }
        }
        /// <summary>
        /// 所属地区
        /// </summary>
        public int RegionID
        {
            set { _regionid = value; }
            get { return _regionid; }
        }
        /// <summary>
        /// 系统状态
        /// </summary>
        public int sState
        {
            set { _sstate = value; }
            get { return _sstate; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime sAppendTime
        {
            set { _sappendtime = value; }
            get { return _sappendtime; }
        }
        /// <summary>
        /// 所属超市系统编号
        /// </summary>
        public int YHsysID
        {
            set { _YHsysID = value; }
            get { return _YHsysID; }
        }
        /// <summary>
        /// 是否所属福州永辉超市，否=0，是=1
        /// </summary>
        public int sIsFZYH
        {
            set { _sIsFZYH = value; }
            get { return _sIsFZYH; }
        }
        /// <summary>
        /// 超市系统名称
        /// </summary>
        public string YHsysName
        {
            set { _YHsysName = value; }
            get { return _YHsysName; }
        }
        /// <summary>
        /// 对账日
        /// </summary>
        public int sDoDay
        {
            set { _sDoDay = value; }
            get { return _sDoDay; }
        }
        /// <summary>
        /// 期初应收款
        /// </summary>
        public decimal sDoDayMoney
        {
            set { _sDoDayMoney = value; }
            get { return _sDoDayMoney; }
        }
        /// <summary>
        /// 联系人
        /// </summary>
        public string sContact
        {
            set { _sContact = value; }
            get { return _sContact; }
        }
        /// <summary>
        /// 电话
        /// </summary>
        public string sTel
        {
            set { _sTel = value; }
            get { return _sTel; }
        }
        /// <summary>
        /// 地址
        /// </summary>
        public string sAddress
        {
            set { _sAddress = value; }
            get { return _sAddress; }
        }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string sEmail
        {
            set { _sEmail = value; }
            get { return _sEmail; }
        }
        /// <summary>
        /// 企业注册号
        /// </summary>
        public string sLicense
        {
            set { _sLicense = value; }
            get { return _sLicense; }
        }
        #endregion
    }
}
