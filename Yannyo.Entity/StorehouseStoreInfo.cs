using System;

namespace Yannyo.Entity
{
    public class StorehouseStoreInfo
    {
        public StorehouseStoreInfo()
        { }
        #region storehouseStorage
        private string _sCode;    //门店自编号
        private int _StoresID;    //门店系统编号
        private string _sName;  //门店名称
        private string _stCode;   //仓库编号--预留
        private string _stName; //仓库名称--预留
        private int _ProductsID;//产品编号
        private string _pName; //产品名称
        private string _pBarcode;//产品条码
        private string _proCode;//产品自编号
        private string _pBrand;//品牌
        private string _pStandard;//规格
        private int _pNum;//数量
        private DateTime _pAppendTime;//创建时间
        private DateTime _pUpdateTime;//更新时间
        private int _productStorageID;
        private string _pMoney;//产品单价

        public string PMoney
        {
            get { return _pMoney; }
            set { _pMoney = value; }
        }

        public int ProductStorageID
        {
            get { return _productStorageID; }
            set { _productStorageID = value; }
        }

        /// <summary>
        /// 产品自编码
        /// </summary>
        public string ProCode
        {
            get { return _proCode; }
            set { _proCode = value; }
        }

        /// <summary>
        /// 商品条码
        /// </summary>
        public string PBarcode
        {
            get { return _pBarcode; }
            set { _pBarcode = value; }
        }

        /// <summary>
        /// 系统编号
        /// </summary>
        public int StoresID
        {
            get { return _StoresID; }
            set { _StoresID = value; }
        }

        /// <summary>
        /// 门店编号
        /// </summary>
        public string SCode
        {
            get { return _sCode; }
            set { _sCode = value; }
        }
        /// <summary>
        /// 门店名称
        /// </summary>
        public string SName
        {
            get { return _sName; }
            set { _sName = value; }
        }

        /// <summary>
        /// 仓库编号
        /// </summary>
        public string StCode
        {
            get { return _stCode; }
            set { _stCode = value; }
        }
        /// <summary>
        /// 仓库名称
        /// </summary>
        public string StName
        {
            get { return _stName; }
            set { _stName = value; }
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
        /// 产品名称
        /// </summary>
        public string PName
        {
            get { return _pName; }
            set { _pName = value; }
        }
        /// <summary>
        /// 产品品牌
        /// </summary>
        public string PBrand
        {
            get { return _pBrand; }
            set { _pBrand = value; }
        }
        /// <summary>
        /// 产品规格
        /// </summary>
        public string PStandard
        {
            get { return _pStandard; }
            set { _pStandard = value; }
        }
        /// <summary>
        /// 实际数量
        /// </summary>
        public int PNum
        {
            get { return _pNum; }
            set { _pNum = value; }
        }
        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime PAppendTime
        {
            get { return _pAppendTime; }
            set { _pAppendTime = value; }
        }
        /// <summary>
        /// 系统时间
        /// </summary>
        public DateTime PUpdateTime
        {
            get { return _pUpdateTime; }
            set { _pUpdateTime = value; }
        }
        #endregion
    }
}
