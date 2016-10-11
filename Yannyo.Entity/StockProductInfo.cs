using System;

namespace Yannyo.Entity
{
    public class StockProductInfo
    {
        private int _stockproductid;
        private int _productsid;
        private decimal _isok;
        private decimal _isbad;
        private DateTime _sappendtime;
        private int _StorageID;
        private DateTime _sDateTime;
        private string _InventoryName;
        private string _sName;
        private string _sTel;
        private string _StaffAdress;
        private StorageInventoryDataJson _StorageInventoryDataJson;//json数据



        /// <summary>
        /// json数据
        /// </summary>
        public StorageInventoryDataJson StorageInventoryDataJson
        {
            get { return _StorageInventoryDataJson; }
            set { _StorageInventoryDataJson = value; }
        }


        /// <summary>
        /// 仓库地址
        /// </summary>
        public string StaffAdress
        {
            get { return _StaffAdress; }
            set { _StaffAdress = value; }
        }

        /// <summary>
        /// 联系电话
        /// </summary>
        public string STel
        {
            get { return _sTel; }
            set { _sTel = value; }
        }
        /// <summary>
        /// 仓管员
        /// </summary>
        public string SName
        {
            get { return _sName; }
            set { _sName = value; }
        }
        /// <summary>
        /// 盘点人姓名
        /// </summary>
        public string InventoryName
        {
            get { return _InventoryName; }
            set { _InventoryName = value; }
        }
        /// <summary>
        /// 盘点时间
        /// </summary>
        public DateTime SDateTime
        {
            get { return _sDateTime; }
            set { _sDateTime = value; }
        }
        /// <summary>
        /// 记录编号
        /// </summary>
        public int StockProductID
        {
            set { _stockproductid = value; }
            get { return _stockproductid; }
        }
        /// <summary>
        /// 仓库编号
        /// </summary>
        public int StorageID
        {
            set { _StorageID = value; }
            get { return _StorageID; }
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
        /// 可用数
        /// </summary>
        public decimal isOK
        {
            set { _isok = value; }
            get { return _isok; }
        }
        /// <summary>
        /// 不可用数
        /// </summary>
        public decimal isBad
        {
            set { _isbad = value; }
            get { return _isbad; }
        }
        /// <summary>
        /// 库存点
        /// </summary>
        public DateTime sAppendTime
        {
            set { _sappendtime = value; }
            get { return _sappendtime; }
        }
    }
    //获取json
    public class StorageInventoryDataJson
    {
        private InventoryDataJson[] _InventoryDataJson;

        public InventoryDataJson[] InventoryDataJson
        {
            get { return _InventoryDataJson; }
            set { _InventoryDataJson = value; }
        }
    }
    public class InventoryDataJson
    {
        private int _pid;
        private decimal _pnum;

        public int Pid
        {
            get { return _pid; }
            set { _pid = value; }
        }
        public decimal Pnum
        {
            get { return _pnum; }
            set { _pnum = value; }
        }
    }
}
