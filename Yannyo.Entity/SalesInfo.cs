using System;
namespace Yannyo.Entity
{
    public class SalesInfo
    {
        public SalesInfo()
        { }
        #region Model
        private int _salesid;
        private int _storesid;
        private string _sStoresID;
        private int _productsid;
        private int _snum;
        private decimal _sprice;
        private DateTime _sdatetime;
        private DateTime _sappendtime;
        private string _StoresName;
        private string _ProductsName;
        private int _sIsYH;
        /// <summary>
        /// 销售数据编号
        /// </summary>
        public int SalesID
        {
            set { _salesid = value; }
            get { return _salesid; }
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
        /// 产品编号
        /// </summary>
        public int ProductsID
        {
            set { _productsid = value; }
            get { return _productsid; }
        }
        /// <summary>
        /// 销售数量
        /// </summary>
        public int sNum
        {
            set { _snum = value; }
            get { return _snum; }
        }
        /// <summary>
        /// 销售金额
        /// </summary>
        public decimal sPrice
        {
            set { _sprice = value; }
            get { return _sprice; }
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
        /// 创建时间
        /// </summary>
        public DateTime sAppendTime
        {
            set { _sappendtime = value; }
            get { return _sappendtime; }
        }
        /// <summary>
        /// 门店编号
        /// </summary>
        public string sStoresID
        {
            set { _sStoresID = value; }
            get { return _sStoresID; }
        }
        /// <summary>
        /// 门店名称
        /// </summary>
        public string StoresName
        {
            set { _StoresName = value; }
            get { return _StoresName; }
        }
        /// <summary>
        /// 产品名称
        /// </summary>
        public string ProductsName
        {
            set { _ProductsName = value; }
            get { return _ProductsName; }
        }
        /// <summary>
        /// 是否永辉数据导入
        /// </summary>
        public int sIsYH
        {
            set { _sIsYH = value; }
            get { return _sIsYH; }
        }
        #endregion Model
    }
}
