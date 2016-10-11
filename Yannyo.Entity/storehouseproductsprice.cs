using System;

namespace Yannyo.Entity
{
    public class storehouseproductsprice
    {
        public storehouseproductsprice()
        { }

        #region storehouseProductsPrice
        private int _StoresID;
        private string _StoresName;
        private string _StCode;
        private string _stName;
        private int _ProductsID;
        private string _ProductsName;
        private string _ProductsBarcode;
        private int _ProductPriceID;

        public int ProductPriceID
        {
            get { return _ProductPriceID; }
            set { _ProductPriceID = value; }
        }

        public string StoresName
        {
            get { return _StoresName; }
            set { _StoresName = value; }
        }
       

        public string StName
        {
            get { return _stName; }
            set { _stName = value; }
        }
      

        public string ProductsName
        {
            get { return _ProductsName; }
            set { _ProductsName = value; }
        }
       

        public string ProductsBarcode
        {
            get { return _ProductsBarcode; }
            set { _ProductsBarcode = value; }
        }
        private decimal _pPrice;
        private DateTime _pAppendTime;

        public int StoresID
        {
            get { return _StoresID; }
            set { _StoresID = value; }
        }
   
        public string StCode
        {
            get { return _StCode; }
            set { _StCode = value; }
        }

        public int ProductsID
        {
            get { return _ProductsID; }
            set { _ProductsID = value; }
        }

        public decimal PPrice
        {
            get { return _pPrice; }
            set { _pPrice = value; }
        }

        public DateTime PAppendTime
        {
            get { return _pAppendTime; }
            set { _pAppendTime = value; }
        }
        #endregion
    }
}
