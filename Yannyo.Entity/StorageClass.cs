using System;


namespace Yannyo.Entity
{
    public class StorageClass
    {
        //仓库信息列表
        private int _StorageClassID;
        private int _sParentID;
        private string _sClassName;
        private int _sOrder;
        private DateTime _sAppendTime;

        /// <summary>
        /// 分类编号
        /// </summary>
        public int StorageClassID
        {
            get { return _StorageClassID; }
            set { _StorageClassID = value; }
        }
       
        /// <summary>
        /// 上级分类编号
        /// </summary>
        public int SParentID
        {
            get { return _sParentID; }
            set { _sParentID = value; }
        }
        
        /// <summary>
        /// 名称
        /// </summary>
        public string SClassName
        {
            get { return _sClassName; }
            set { _sClassName = value; }
        }
       
        /// <summary>
        /// 显示排序
        /// </summary>
        public int SOrder
        {
            get { return _sOrder; }
            set { _sOrder = value; }
        }
       
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime SAppendTime
        {
            get { return _sAppendTime; }
            set { _sAppendTime = value; }
        }
    }
}
