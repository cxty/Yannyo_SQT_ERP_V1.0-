using System;

namespace Yannyo.Entity
{
    public class ProductsStorageInfo
    {
        #region Model
        private int _productsstorageid;
        private int _storageid;
        private int _productsid;
        private decimal _pstorage;
        private decimal _pstoragein;
        private decimal _pstorageout;
        private DateTime _pupdatetime;
        private decimal _pstoragebad;
        /// <summary>
        /// 
        /// </summary>
        public int ProductsStorageID
        {
            set { _productsstorageid = value; }
            get { return _productsstorageid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int StorageID
        {
            set { _storageid = value; }
            get { return _storageid; }
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
        public decimal pStorage
        {
            set { _pstorage = value; }
            get { return _pstorage; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal pStorageIn
        {
            set { _pstoragein = value; }
            get { return _pstoragein; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal pStorageOut
        {
            set { _pstorageout = value; }
            get { return _pstorageout; }
        }
        /// <summary>
        /// 坏货
        /// </summary>
        public decimal pStorageBad
        {
            set { _pstoragebad = value; }
            get { return _pstoragebad; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime pUpdateTime
        {
            set { _pupdatetime = value; }
            get { return _pupdatetime; }
        }
        #endregion Model

    }
    public class ProductsStorageLogInfo
    {
        #region Model
        private int _productsstoragelogid;
        private int _storageid;
        private int _productsid;
        private int _orderid;
        private decimal _pquantity;
        private int _ptype;
        private DateTime _pappendtime;
        private int _pstate;
        /// <summary>
        /// 
        /// </summary>
        public int ProductsStorageLogID
        {
            set { _productsstoragelogid = value; }
            get { return _productsstoragelogid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int StorageID
        {
            set { _storageid = value; }
            get { return _storageid; }
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
        public int OrderID
        {
            set { _orderid = value; }
            get { return _orderid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal pQuantity
        {
            set { _pquantity = value; }
            get { return _pquantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int pType
        {
            set { _ptype = value; }
            get { return _ptype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime pAppendTime
        {
            set { _pappendtime = value; }
            get { return _pappendtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int pState
        {
            set { _pstate = value; }
            get { return _pstate; }
        }
        #endregion Model

    }
}
