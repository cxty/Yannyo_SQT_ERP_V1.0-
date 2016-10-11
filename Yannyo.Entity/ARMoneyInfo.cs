using System;

namespace Yannyo.Entity
{
    public class ARMoneyInfo
    {
        private int _armoneyid;
        private int _arobjid;
        private string _arobjName;
        private int _arobjtype;
        private decimal _aamoney;
        private decimal _abmoney;
        private DateTime? _aopendate;
        private decimal? _aopenmoney;
        private DateTime? _adate;
        private DateTime? _aactualdate;
        private decimal _aactualmoney;
        private DateTime _aupdatetime;
        private int _asteps;
        private DateTime _aappendtime;
        private string _aErpOrderIDStr;
        /// <summary>
        /// 
        /// </summary>
        public int ARMoneyID
        {
            set { _armoneyid = value; }
            get { return _armoneyid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int ARObjID
        {
            set { _arobjid = value; }
            get { return _arobjid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ARObjName
        {
            set { _arobjName = value; }
            get { return _arobjName; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int ARObjType
        {
            set { _arobjtype = value; }
            get { return _arobjtype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal aAMoney
        {
            set { _aamoney = value; }
            get { return _aamoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal aBMoney
        {
            set { _abmoney = value; }
            get { return _abmoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? aOpenDate
        {
            set { _aopendate = value; }
            get { return _aopendate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? aOpenMoney
        {
            set { _aopenmoney = value; }
            get { return _aopenmoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? aDate
        {
            set { _adate = value; }
            get { return _adate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? aActualDate
        {
            set { _aactualdate = value; }
            get { return _aactualdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal aActualMoney
        {
            set { _aactualmoney = value; }
            get { return _aactualmoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime aUpdateTime
        {
            set { _aupdatetime = value; }
            get { return _aupdatetime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int aSteps
        {
            set { _asteps = value; }
            get { return _asteps; }
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
        /// 
        /// </summary>
        public string aErpOrderIDStr
        {
            set { _aErpOrderIDStr = value; }
            get { return _aErpOrderIDStr; }
        }
    }
}
