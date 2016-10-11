using System;

namespace Yannyo.Entity
{
    public class ProductsInfo
    {
        public ProductsInfo()
        { }
        #region Model
        private int _productsid;
        private string _pcode;
        private string _pbarcode;
        private string _pname;
        private string _penName;
        private int _ProductClassID;
        private string _ProductClass;
        private string _pbrand;
        private string _pstandard;
        private string _punits;
        private string _pMaxUnits;
        private int _ptoboxno;
        private int _pstate;
        private DateTime _pappendtime;
        private decimal _pPrice;
        private decimal _pDoDayQuantity;
        private string _pProducer;
        private string _pExpireDay;
        private string _pAddress;
        private decimal _NowPrice;
        private decimal _pSellingPrice;
		private ProductFieldValueJson _ProductFieldValueJson;

		public ProductFieldValueJson ProductFieldValueJson
		{
			set{_ProductFieldValueJson = value;}
			get{return _ProductFieldValueJson;}
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
        /// 商品编码
        /// </summary>
        public string pCode
        {
            set { _pcode = value; }
            get { return _pcode; }
        }
        /// <summary>
        /// 厂家
        /// </summary>
        public string pProducer
        {
            set { _pProducer = value; }
            get { return _pProducer; }
        }
        /// <summary>
        /// 保质期
        /// </summary>
        public string pExpireDay
        {
            set { _pExpireDay = value; }
            get { return _pExpireDay; }
        }
        /// <summary>
        /// 产地
        /// </summary>
        public string pAddress
        {
            set { _pAddress = value; }
            get { return _pAddress; }
        }
        /// <summary>
        /// 商品条码
        /// </summary>
        public string pBarcode
        {
            set { _pbarcode = value; }
            get { return _pbarcode; }
        }
        /// <summary>
        /// 商品名称
        /// </summary>
        public string pName
        {
            set { _pname = value; }
            get { return _pname; }
        }
        public string pEnName
        {
            set { _penName = value; }
            get { return _penName; }
        }
        /// <summary>
        /// 品牌
        /// </summary>
        public string pBrand
        {
            set { _pbrand = value; }
            get { return _pbrand; }
        }
        /// <summary>
        /// 所属产品分类
        /// </summary>
        public int ProductClassID
        {
            set { _ProductClassID = value; }
            get { return _ProductClassID; }
        }
        /// <summary>
        /// 所属产品分类名称
        /// </summary>
        public string ProductClass
        {
            set { _ProductClass = value; }
            get { return _ProductClass; }
        }
        /// <summary>
        /// 商品规格
        /// </summary>
        public string pStandard
        {
            set { _pstandard = value; }
            get { return _pstandard; }
        }
        /// <summary>
        /// 最小单位
        /// </summary>
        public string pUnits
        {
            set { _punits = value; }
            get { return _punits; }
        }
        /// <summary>
        /// 最大单位
        /// </summary>
        public string pMaxUnits
        {
            set { _pMaxUnits = value; }
            get { return _pMaxUnits; }
        }
        
        /// <summary>
        /// 件装数
        /// </summary>
        public int pToBoxNo
        {
            set { _ptoboxno = value; }
            get { return _ptoboxno; }
        }
        /// <summary>
        /// 系统状态
        /// </summary>
        public int pState
        {
            set { _pstate = value; }
            get { return _pstate; }
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
        /// 默认成本
        /// </summary>
        public decimal pPrice
        {
            set { _pPrice = value; }
            get { return _pPrice; }
        }
        /// <summary>
        /// 当前最新成本
        /// </summary>
        public decimal NowPrice
        {
            set { _NowPrice = value; }
            get { return _NowPrice; }
        }
        /// <summary>
        /// 默认销售价格
        /// </summary>
        public decimal pSellingPrice
        {
            set { _pSellingPrice = value; }
            get { return _pSellingPrice; }
        }
        /// <summary>
        /// 期初库存量
        /// </summary>
        public decimal pDoDayQuantity
        {
            set { _pDoDayQuantity = value; }
            get { return _pDoDayQuantity; }
        }
        #endregion Model
    }
}
