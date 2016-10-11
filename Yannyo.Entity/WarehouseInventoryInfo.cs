using System;


namespace Yannyo.Entity
{
    public class WarehouseInventoryInfo
    {
        //表体
        private int _ProductsID;
        private int _StorageID;
        private decimal _Quantity;
        private decimal _sQuantity;
        private DateTime _sDateTime;
        private DateTime _sAppendTime;
        private int _StaffID;
        private int _sSteps;
        private GetWarehouseDateJsonList _GetWarehouseDateJson;
        private int _StocktakeID;
       

 
        //表头
        private string _StorageStaff;//仓管员
        private string _StaffPhoneNum;//联系电话
        private string _StaffAdress;//联系地址
        private string _InventoryName;//盘点人
        private string _StaffName;
        private string _StorageName;
        private int _StockID;

        public int StockID
        {
            get { return _StockID; }
            set { _StockID = value; }
        }
         

        public string StaffName
        {
            get { return _StaffName; }
            set { _StaffName = value; }
        }

        public string StorageName
        {
            get { return _StorageName; }
            set { _StorageName = value; }
        }

        public int StocktakeID
        {
            get { return _StocktakeID; }
            set { _StocktakeID = value; }
        }

        public string StorageStaff
        {
            get { return _StorageStaff; }
            set { _StorageStaff = value; }
        }


        public string StaffPhoneNum
        {
            get { return _StaffPhoneNum; }
            set { _StaffPhoneNum = value; }
        }


        public string StaffAdress
        {
            get { return _StaffAdress; }
            set { _StaffAdress = value; }
        }


        public string InventoryName
        {
            get { return _InventoryName; }
            set { _InventoryName = value; }
        }
 

        /// <summary>
        /// 产品编号
        /// </summary>
        public int ProductsID
        {
            get { return _ProductsID; }
            set { _ProductsID = value; }
        }
       
        /// <summary>
        /// 仓库编号
        /// </summary>
        public int StorageID
        {
            get { return _StorageID; }
            set { _StorageID = value; }
        }
        
        /// <summary>
        /// 库存数量
        /// </summary>
        public decimal Quantity
        {
            get { return _Quantity; }
            set { _Quantity = value; }
        }
        /// <summary>
        /// 盘点数量
        /// </summary>

        public decimal SQuantity
        {
            get { return _sQuantity; }
            set { _sQuantity = value; }
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
        /// 创建时间
        /// </summary>

        public DateTime SAppendTime
        {
            get { return _sAppendTime; }
            set { _sAppendTime = value; }
        }
        /// <summary>
        /// 操作员编号
        /// </summary>

        public int StaffID
        {
            get { return _StaffID; }
            set { _StaffID = value; }
        }
        
        /// <summary>
        /// 操作步骤
        /// </summary>
        public int SSteps
        {
            get { return _sSteps; }
            set { _sSteps = value; }
        }
        /// <summary>
        /// 获得json
        /// </summary>
        public GetWarehouseDateJsonList GetWarehouseDateJson
        {
            get { return _GetWarehouseDateJson; }
            set { _GetWarehouseDateJson = value; }
        }
    }
    /// <summary>
    /// 将传过来的json值放在数组中
    /// </summary>
    public class GetWarehouseDateJsonList
    {
        private WarehouseInventory[] _WarehouseInventory;

        public WarehouseInventory[] WarehouseInventory
        {
            get { return _WarehouseInventory; }
            set { _WarehouseInventory = value; }
        }
    }
    /// <summary>
    /// 获得json传过来的id和num
    /// </summary>
    public class WarehouseInventory 
    {
        private int _stocktakeid;
        private int _pid;
        private decimal _pnum;
        private decimal _oQuantity;
        //表头
        private string _StorageStaff;//仓管员
        private string _StaffPhoneNum;//联系电话
        private string _StaffAdress;//联系地址
        private string _InventoryName;//盘点人

        public string StorageStaff
        {
            get { return _StorageStaff; }
            set { _StorageStaff = value; }
        }


        public string StaffPhoneNum
        {
            get { return _StaffPhoneNum; }
            set { _StaffPhoneNum = value; }
        }


        public string StaffAdress
        {
            get { return _StaffAdress; }
            set { _StaffAdress = value; }
        }


        public string InventoryName
        {
            get { return _InventoryName; }
            set { _InventoryName = value; }
        }

        /// <summary>
        /// 盘点单头编号
        /// </summary>
        public int stocktakeid
        {
            get { return _stocktakeid; }
            set { _stocktakeid = value; }
        }
        /// <summary>
        /// 产品编号
        /// </summary>
        public int pid
        {
            get { return _pid; }
            set { _pid = value; }
        }
        /// <summary>
        /// 盘点
        /// </summary>
        public decimal pnum
        {
            get { return _pnum; }
            set { _pnum = value; }
        }
        /// <summary>
        /// 库存
        /// </summary>
        public decimal oQuantity
        {
            get { return _oQuantity; }
            set { _oQuantity = value; }
        }
    }
}
