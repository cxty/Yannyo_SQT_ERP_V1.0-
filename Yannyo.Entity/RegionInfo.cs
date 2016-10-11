using System;

namespace Yannyo.Entity
{
    public class RegionInfo
    {
        public RegionInfo()
        { }
        #region Model
        private int _regionid;
        private string _rname;
        private int _rupid;
        private int _rorder;
        private int _rstate;
        private DateTime _rappendtime;
        /// <summary>
        /// 地区编号
        /// </summary>
        public int RegionID
        {
            set { _regionid = value; }
            get { return _regionid; }
        }
        /// <summary>
        /// 名称
        /// </summary>
        public string rName
        {
            set { _rname = value; }
            get { return _rname; }
        }
        /// <summary>
        /// 所属上级编号
        /// </summary>
        public int rUpID
        {
            set { _rupid = value; }
            get { return _rupid; }
        }
        /// <summary>
        /// 显示排序
        /// </summary>
        public int rOrder
        {
            set { _rorder = value; }
            get { return _rorder; }
        }
        /// <summary>
        /// 系统状态
        /// </summary>
        public int rState
        {
            set { _rstate = value; }
            get { return _rstate; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime rAppendTime
        {
            set { _rappendtime = value; }
            get { return _rappendtime; }
        }
        #endregion Model
    }
}
