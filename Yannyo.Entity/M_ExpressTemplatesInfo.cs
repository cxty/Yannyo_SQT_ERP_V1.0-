using System;

namespace Yannyo.Entity
{
    /// <summary>
    /// 快递单据模板
    /// </summary>
    public  class M_ExpressTemplatesInfo
    {
        private int _m_expresstemplatesid;
        private string _mname;
        private string _mpic;
        private string _mwidth;
        private string _mheight;
        private string _mexpname;
        private string _mdata;
        private DateTime _mappendtime = DateTime.Now;
        private int _m_ConfigInfoID;
        /// <summary>
        /// 模板编号
        /// </summary>
        public int m_ExpressTemplatesID
        {
            set { _m_expresstemplatesid = value; }
            get { return _m_expresstemplatesid; }
        }
        /// <summary>
        /// 所属网店系统编号
        /// </summary>
        public int m_ConfigInfoID
        {
            set { _m_ConfigInfoID = value; }
            get { return _m_ConfigInfoID; }
        }
        /// <summary>
        /// 名称
        /// </summary>
        public string mName
        {
            set { _mname = value; }
            get { return _mname; }
        }
        /// <summary>
        /// 背景图片
        /// </summary>
        public string mPIC
        {
            set { _mpic = value; }
            get { return _mpic; }
        }
        /// <summary>
        /// 宽度
        /// </summary>
        public string mWidth
        {
            set { _mwidth = value; }
            get { return _mwidth; }
        }
        /// <summary>
        /// 高度
        /// </summary>
        public string mHeight
        {
            set { _mheight = value; }
            get { return _mheight; }
        }
        /// <summary>
        /// 物流公司名称
        /// </summary>
        public string mExpName
        {
            set { _mexpname = value; }
            get { return _mexpname; }
        }
        /// <summary>
        /// 模板内容
        /// </summary>
        public string mData
        {
            set { _mdata = value; }
            get { return _mdata; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime mAppendTime
        {
            set { _mappendtime = value; }
            get { return _mappendtime; }
        }
    }
}
