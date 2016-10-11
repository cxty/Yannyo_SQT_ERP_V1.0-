using System;

namespace Yannyo.Entity
{
    public class BankInfo
    {
        private int _bankid;
        private string _bname;
        private DateTime _bappendtime;
        private decimal _BeginMoney;
        /// <summary>
        /// 
        /// </summary>
        public int BankID
        {
            set { _bankid = value; }
            get { return _bankid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string bName
        {
            set { _bname = value; }
            get { return _bname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime bAppendTime
        {
            set { _bappendtime = value; }
            get { return _bappendtime; }
        }
        /// <summary>
        /// 期初金额
        /// </summary>
        public decimal BeginMoney
        {
            set { _BeginMoney = value; }
            get { return _BeginMoney; }
        }
    }
    public class BankMoneyInfo
    {
        private int _bankmoneyid;
        private int _bankid;
        private decimal _bmoney;
        private DateTime _bupdatetime;
        private DateTime _bappendtime;
        private int _isBegin;
        /// <summary>
        /// 
        /// </summary>
        public int BankMoneyID
        {
            set { _bankmoneyid = value; }
            get { return _bankmoneyid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int BankID
        {
            set { _bankid = value; }
            get { return _bankid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal bMoney
        {
            set { _bmoney = value; }
            get { return _bmoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime bUpdateTime
        {
            set { _bupdatetime = value; }
            get { return _bupdatetime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime bAppendTime
        {
            set { _bappendtime = value; }
            get { return _bappendtime; }
        }
        /// <summary>
        /// 是否为期初金额,是=1,默认=0
        /// </summary>
        public int isBegin
        {
            set { _isBegin = value; }
            get { return _isBegin; }
        }
    }
    public class BankAccount 
    {
        private int _CapitalAccountID;
        private string _cAccountName;
        private int _FeesSubjectClassID;
        private decimal _cAccountMoney;
        private int _cType;
        private int _cDirection;
        /// <summary>
        /// 借贷方向
        /// </summary>
        public int CDirection
        {
            get { return _cDirection; }
            set { _cDirection = value; }
        }
        private DateTime _pAppendTime;
        private DateTime _pUpdateTime;

        /// <summary>
        /// 编号
        /// </summary>
        public int CapitalAccountID
        {
            get { return _CapitalAccountID; }
            set { _CapitalAccountID = value; }
        }
        
        /// <summary>
        /// 账户名称
        /// </summary>
        public string CAccountName
        {
            get { return _cAccountName; }
            set { _cAccountName = value; }
        }
       
        /// <summary>
        /// 所属科目编号
        /// </summary>
        public int FeesSubjectClassID
        {
            get { return _FeesSubjectClassID; }
            set { _FeesSubjectClassID = value; }
        }
       
        /// <summary>
        /// 账户金额
        /// </summary>
        public decimal CAccountMoney
        {
            get { return _cAccountMoney; }
            set { _cAccountMoney = value; }
        }
        
        /// <summary>
        /// 账户类型
        /// </summary>
        public int CType
        {
            get { return _cType; }
            set { _cType = value; }
        }
        
        /// <summary>
        /// 操作日期
        /// </summary>
        public DateTime PAppendTime
        {
            get { return _pAppendTime; }
            set { _pAppendTime = value; }
        }
        
        /// <summary>
        /// 更新日期
        /// </summary>
        public DateTime PUpdateTime
        {
            get { return _pUpdateTime; }
            set { _pUpdateTime = value; }
        }
    }
}
