using System;

namespace Yannyo.Entity
{
    public class APMoneyInfo
    {
        private int _apmoneyid;
        private int _apobjid;
        private int _apobjtype;
        private string _apobjName;
        private decimal _aNPMoney;
        private decimal _apmoney;
        private decimal _apaymoney;
        private decimal _aothermoney;
        private string _aremake;
        private string _FeesSubjectName;
        private int _FeesSubjectID;
        private DateTime _adodatetime;
        private DateTime _aappendtime;
        private string _aErpOrderIDStr;
        /// <summary>
        /// 
        /// </summary>
        public int APMoneyID
        {
            set { _apmoneyid = value; }
            get { return _apmoneyid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int APObjID
        {
            set { _apobjid = value; }
            get { return _apobjid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string APObjName
        {
            set { _apobjName = value; }
            get { return _apobjName; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FeesSubjectName
        {
            set { _FeesSubjectName = value; }
            get { return _FeesSubjectName; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int APObjType
        {
            set { _apobjtype = value; }
            get { return _apobjtype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal aNPMoney
        {
            set { _aNPMoney = value; }
            get { return _aNPMoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal aPMoney
        {
            set { _apmoney = value; }
            get { return _apmoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal aPayMoney
        {
            set { _apaymoney = value; }
            get { return _apaymoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal aOtherMoney
        {
            set { _aothermoney = value; }
            get { return _aothermoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string aReMake
        {
            set { _aremake = value; }
            get { return _aremake; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime aDoDateTime
        {
            set { _adodatetime = value; }
            get { return _adodatetime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime aAppendTime
        {
            set { _aappendtime = value; }
            get { return _aappendtime; }
        }
        /// <summary>
        /// 科目编号
        /// </summary>
        public int FeesSubjectID
        {
            set { _FeesSubjectID = value; }
            get { return _FeesSubjectID; }
        }
        public string aErpOrderIDStr
        {
            set { _aErpOrderIDStr = value; }
            get { return _aErpOrderIDStr; }
        }
    }
}
