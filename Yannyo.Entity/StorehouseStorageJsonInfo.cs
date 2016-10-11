using System;

namespace Yannyo.Entity
{
    public class StorehouseStorageJsonInfo
    {
        private string _sCode;    //门店编号
        private int _StoresID;    //门店系统编号
        private string _sName;    //门店名称
        private string _ProductsID;  //产品编号
        private string _pName;    //产品名称
        private string _pBarcode; //产品条码
        private DateTime _pAppendTime;//创建时间
        private StorehouseStorageDataJson _StorehouseStorageJson;//json数据 


        public string SCode
        {
            get { return _sCode; }
            set { _sCode = value; }
        }
        public int StoresID
        {
            get { return _StoresID; }
            set { _StoresID = value; }
        }  
        public string SName
        {
            get { return _sName; }
            set { _sName = value; }
        }
      
        public string ProductsID
        {
            get { return _ProductsID; }
            set { _ProductsID = value; }
        }
        
        public string PName
        {
            get { return _pName; }
            set { _pName = value; }
        }
        
        public string PBarcode
        {
            get { return _pBarcode; }
            set { _pBarcode = value; }
        }
        
      
        public DateTime PAppendTime
        {
            get { return _pAppendTime; }
            set { _pAppendTime = value; }
        }
      
        public StorehouseStorageDataJson StorehouseStorageJson
        {
            get { return _StorehouseStorageJson; }
            set { _StorehouseStorageJson = value; }
        }
    }

    //获取Json
    public class StorehouseStorageDataJson
    {
        private StoreHouseStorage[] _StoreHouseStorage;
        public StoreHouseStorage[] StoreHouseStorage
        {
            get { return _StoreHouseStorage; }
            set { _StoreHouseStorage = value; }
        }
    }
    public class StoreHouseStorage
    {
        private int _pid;
        private decimal _pnum;

        public int pid
        {
            get { return _pid; }
            set { _pid = value; }
        }
    
        public decimal pnum
        {
            get { return _pnum; }
            set { _pnum = value; }
        }

    }
}
