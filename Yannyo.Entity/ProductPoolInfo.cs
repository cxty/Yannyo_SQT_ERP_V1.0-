using System;

namespace Yannyo.Entity
{
    public class ProductPoolInfo
    {
        private int _productpoolid;
        private int _productsid;
        private DateTime _pdatetime;
        private int _ptype;
        private DateTime _pappendtime;
        private string _ProductsName;
        /// <summary>
        /// 产品联营编号
        /// </summary>
        public int ProductPoolID
        {
            set { _productpoolid = value; }
            get { return _productpoolid; }
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
        /// 发生时间
        /// </summary>
        public DateTime pDateTime
        {
            set { _pdatetime = value; }
            get { return _pdatetime; }
        }
        /// <summary>
        /// 发生状态,开始联营=0,结束联营=1
        /// </summary>
        public int pType
        {
            set { _ptype = value; }
            get { return _ptype; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime pAppendTime
        {
            set { _pappendtime = value; }
            get { return _pappendtime; }
        }
        /// <summary>
        /// 产品名称
        /// </summary>
        public string ProductsName
        {
            set { _ProductsName = value; }
            get { return _ProductsName; }
        }
    }
}
