using System;

namespace Yannyo.Entity
{
    public class ValenceInfo
    {
        public ValenceInfo()
        { }
        #region Model
        private int _valenceid;
        private int _productsid;
        private DateTime _bdatetime;
        private DateTime _edatetime;
        private decimal _vprice;
        private DateTime _vappendtime;
        private string _ProductsName;
        /// <summary>
        /// 变价编号
        /// </summary>
        public int ValenceID
        {
            set { _valenceid = value; }
            get { return _valenceid; }
        }
        /// <summary>
        /// 产品编号
        /// </summary>
        public int ProductsID
        {
            set { _productsid = value; }
            get { return _productsid; }
        }
        /// <summary>
        /// 变价起始时间
        /// </summary>
        public DateTime bDateTime
        {
            set { _bdatetime = value; }
            get { return _bdatetime; }
        }
        /// <summary>
        /// 变价结束时间
        /// </summary>
        public DateTime eDateTime
        {
            set { _edatetime = value; }
            get { return _edatetime; }
        }
        /// <summary>
        /// 变价期间价格
        /// </summary>
        public decimal vPrice
        {
            set { _vprice = value; }
            get { return _vprice; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime vAppendTime
        {
            set { _vappendtime = value; }
            get { return _vappendtime; }
        }
        /// <summary>
        /// 产品
        /// </summary>
        public string ProductsName
        {
            set { _ProductsName = value; }
            get { return _ProductsName; }
        }
        #endregion Model
    }
}
