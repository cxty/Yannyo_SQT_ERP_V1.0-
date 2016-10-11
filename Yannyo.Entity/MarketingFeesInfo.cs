using System;

namespace Yannyo.Entity
{
    public class MarketingFeesInfo
    {
        public MarketingFeesInfo()
        { }
        #region Model
        private int _marketingfeesid;
        private int _storesid;
        private int _feessubjectid;
        private string _mremark;
        private decimal _mfees;
        private DateTime _mdatetime;
        private int _mtype;
        private int _staffid;
        private DateTime _mappendtime;
        private string _StoresName;
        private string _FeesSubjectName;
        private string _StaffName;
        private int _mIsIncomeExpenditure;
        /// <summary>
        /// 营销费用编号
        /// </summary>
        public int MarketingFeesID
        {
            set { _marketingfeesid = value; }
            get { return _marketingfeesid; }
        }
        /// <summary>
        /// 门店编号
        /// </summary>
        public int StoresID
        {
            set { _storesid = value; }
            get { return _storesid; }
        }
        /// <summary>
        /// 科目编号
        /// </summary>
        public int FeesSubjectID
        {
            set { _feessubjectid = value; }
            get { return _feessubjectid; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string mRemark
        {
            set { _mremark = value; }
            get { return _mremark; }
        }
        /// <summary>
        /// 发生费用
        /// </summary>
        public decimal mFees
        {
            set { _mfees = value; }
            get { return _mfees; }
        }
        /// <summary>
        /// 发生时间
        /// </summary>
        public DateTime mDateTime
        {
            set { _mdatetime = value; }
            get { return _mdatetime; }
        }
        /// <summary>
        /// 费用类型
        /// </summary>
        public int mType
        {
            set { _mtype = value; }
            get { return _mtype; }
        }
        /// <summary>
        /// 经办人编号
        /// </summary>
        public int StaffID
        {
            set { _staffid = value; }
            get { return _staffid; }
        }
        /// <summary>
        /// 系统创建时间
        /// </summary>
        public DateTime mAppendTime
        {
            set { _mappendtime = value; }
            get { return _mappendtime; }
        }
        /// <summary>
        /// 门面
        /// </summary>
        public string StoresName
        {
            set { _StoresName = value; }
            get { return _StoresName; }
        }
        /// <summary>
        /// 科目
        /// </summary>
        public string FeesSubjectName
        {
            set { _FeesSubjectName = value; }
            get { return _FeesSubjectName; }
        }
        /// <summary>
        /// 经办人
        /// </summary>
        public string StaffName
        {
            set { _StaffName = value; }
            get { return _StaffName; }
        }
        /// <summary>
        /// 支出=0,收入=1
        /// </summary>
        public int mIsIncomeExpenditure
        {
            set { _mIsIncomeExpenditure = value; }
            get { return _mIsIncomeExpenditure; }
        }
        #endregion
    }
}
