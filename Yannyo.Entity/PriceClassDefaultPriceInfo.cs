using System;

namespace Yannyo.Entity
{
    public class PriceClassDefaultPriceInfo
    {
        private int _priceclassdefaultpriceid;
        private int _priceclassid;
        private int _productsid;
        private decimal _pprice;
        private int _pIsEdit;
        /// <summary>
        /// 
        /// </summary>
        public int PriceClassDefaultPriceID
        {
            set { _priceclassdefaultpriceid = value; }
            get { return _priceclassdefaultpriceid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int PriceClassID
        {
            set { _priceclassid = value; }
            get { return _priceclassid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int ProductsID
        {
            set { _productsid = value; }
            get { return _productsid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal pPrice
        {
            set { _pprice = value; }
            get { return _pprice; }
        }
        public int pIsEdit
        {
            set { _pIsEdit = value; }
            get { return _pIsEdit; }
        }
    }
}
