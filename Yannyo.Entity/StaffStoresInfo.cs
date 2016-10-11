using System;

namespace Yannyo.Entity
{
    public class StaffStoresInfo
    {
        public StaffStoresInfo()
        { }
        #region Model
        private int _staffstoresid;
        private int _staffid;
        private int _storesid;
        private string _staffName;
        private string _storesName;
        private int _stype;
        private DateTime _sdatetime;
        private DateTime _sappendtime;
        /// <summary>
        /// 编号
        /// </summary>
        public int StaffStoresID
        {
            set { _staffstoresid = value; }
            get { return _staffstoresid; }
        }
        /// <summary>
        /// 人员编号
        /// </summary>
        public int StaffID
        {
            set { _staffid = value; }
            get { return _staffid; }
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
        /// 人员名称
        /// </summary>
        public string StaffName
        {
            set { _staffName = value; }
            get { return _staffName; }
        }
        /// <summary>
        /// 门店名称
        /// </summary>
        public string StoresName
        {
            set { _storesName = value; }
            get { return _storesName; }
        }
        /// <summary>
        /// 发生类型,上岗=0,离岗=1
        /// </summary>
        public int sType
        {
            set { _stype = value; }
            get { return _stype; }
        }
        /// <summary>
        /// 发生时间
        /// </summary>
        public DateTime sDateTime
        {
            set { _sdatetime = value; }
            get { return _sdatetime; }
        }
        /// <summary>
        /// 系统创建时间
        /// </summary>
        public DateTime sAppendTime
        {
            set { _sappendtime = value; }
            get { return _sappendtime; }
        }
        #endregion Model
    }
}
