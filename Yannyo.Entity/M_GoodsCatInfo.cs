using System;

namespace Yannyo.Entity
{
    public class M_GoodsCatInfo
    {
        public M_GoodsCatInfo()
        { }
        private int _m_goodscatinfoid;
        private int _m_configinfoid;
        private long _cid;
        private long _parent_cid;
        private string _name;
        private bool _is_parent;
        private string _status;
        private int _sort_order;
        private DateTime _mUpdateTime;
        /// <summary>
        /// 类目编号
        /// </summary>
        public int m_GoodsCatInfoID
        {
            set { _m_goodscatinfoid = value; }
            get { return _m_goodscatinfoid; }
        }
        /// <summary>
        /// 网店系统编号
        /// </summary>
        public int m_ConfigInfoID
        {
            set { _m_configinfoid = value; }
            get { return _m_configinfoid; }
        }
        /// <summary>
        /// 类目编号
        /// </summary>
        public long cid
        {
            set { _cid = value; }
            get { return _cid; }
        }
        /// <summary>
        /// 父编号
        /// </summary>
        public long parent_cid
        {
            set { _parent_cid = value; }
            get { return _parent_cid; }
        }
        /// <summary>
        /// 名称
        /// </summary>
        public string name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 是否为父类目
        /// </summary>
        public bool is_parent
        {
            set { _is_parent = value; }
            get { return _is_parent; }
        }
        /// <summary>
        /// 状态
        /// </summary>
        public string status
        {
            set { _status = value; }
            get { return _status; }
        }
        /// <summary>
        /// 排序
        /// </summary>
        public int sort_order
        {
            set { _sort_order = value; }
            get { return _sort_order; }
        }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime mUpdateTime
        {
            set { _mUpdateTime = value; }
            get { return _mUpdateTime; }
        }
    }
}
