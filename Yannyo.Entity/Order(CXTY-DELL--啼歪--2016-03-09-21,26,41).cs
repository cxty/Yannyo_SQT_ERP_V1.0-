using System;
using System.Data;

namespace Yannyo.Entity
{
    public class OrderInfo
    {
        #region Model
        private int _orderid;
        private string _oordernum;
        private int _otype;
        private int _storesid;
        private string _ocustomersname;
        private string _ocustomerscontact;
        private string _ocustomerstel;
        private string _ocustomersaddress;
        private string _ocustomersorderid;
        private string _ocustomersnameb;
        private int _staffid;
        private int _userid;
        private DateTime _oappendtime;
        private DateTime _oorderdatetime;
        private int _ostate;
        private int _osteps;
        private OrderListDataJson _OrderListDataJson;
        private int _StoresSupplierID;
        private string _StoresSupplierName;
        private string _StoresSupplierCode;
        private string _UserName;
        private string _staffname;
        private DateTime _LastPrintDateTime;
        private int _PriceClassID;
        private int _oPrepay;
        private string _oReMake;
        /// <summary>
        /// 
        /// </summary>
        public int OrderID
        {
            set { _orderid = value; }
            get { return _orderid; }
        }
        /// <summary>
        /// 是否需预付款,0不需要,1需要,默认0
        /// </summary>
        public int oPrepay
        {
            set { _oPrepay = value; }
            get { return _oPrepay; }
        }
        /// <summary>
        /// 价格类型
        /// </summary>
        public int PriceClassID
        {
            set { _PriceClassID = value; }
            get { return _PriceClassID; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string oOrderNum
        {
            set { _oordernum = value; }
            get { return _oordernum; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string oReMake
        {
            set { _oReMake = value; }
            get { return _oReMake; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int StoresSupplierID
        {
            set { _StoresSupplierID = value; }
            get { return _StoresSupplierID; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string StoresSupplierName
        {
            set { _StoresSupplierName = value; }
            get { return _StoresSupplierName; }
        }
        public string StoresSupplierCode
        {
            set { _StoresSupplierCode = value; }
            get { return _StoresSupplierCode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int oType
        {
            set { _otype = value; }
            get { return _otype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int StoresID
        {
            set { _storesid = value; }
            get { return _storesid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string oCustomersName
        {
            set { _ocustomersname = value; }
            get { return _ocustomersname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string oCustomersContact
        {
            set { _ocustomerscontact = value; }
            get { return _ocustomerscontact; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string oCustomersTel
        {
            set { _ocustomerstel = value; }
            get { return _ocustomerstel; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string oCustomersAddress
        {
            set { _ocustomersaddress = value; }
            get { return _ocustomersaddress; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string oCustomersOrderID
        {
            set { _ocustomersorderid = value; }
            get { return _ocustomersorderid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string oCustomersNameB
        {
            set { _ocustomersnameb = value; }
            get { return _ocustomersnameb; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int StaffID
        {
            set { _staffid = value; }
            get { return _staffid; }
        }
        public string StaffName
        {
            set { _staffname = value; }
            get { return _staffname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int UserID
        {
            set { _userid = value; }
            get { return _userid; }
        }
        public string UserName
        {
            set { _UserName = value; }
            get { return _UserName; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime oAppendTime
        {
            set { _oappendtime = value; }
            get { return _oappendtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime oOrderDateTime
        {
            set { _oorderdatetime = value; }
            get { return _oorderdatetime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int oState
        {
            set { _ostate = value; }
            get { return _ostate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int oSteps
        {
            set { _osteps = value; }
            get { return _osteps; }
        }

        /// <summary>
        /// 最后一次打印时间
        /// </summary>
        public DateTime LastPrintDateTime
        {
            set { _LastPrintDateTime = value; }
            get { return _LastPrintDateTime; }
        }
        /// <summary>
        /// Json格式的单据体数据
        /// OrderListDataJson:{OrderListJson:[{
        ///     OrderID:单据头编号,
        ///     StorageID:仓库编号,
        ///     ProductsID:产品编号,
        ///     oQuantity:数量,
        ///     oPrice:单价,
        ///     oMoney:金额,
        ///     StoresSupplierID:客户/供应商编号,
        ///     IsPromotions:是否促销,
        ///     oWorkType:单据步骤类型
        ///     OrderFieldValueInfo:[{
        ///         OrderFieldID:所属字段编号,
        ///         oFieldValue:字段值,
        ///         IsVerify:所属单据体审核类型
        ///     },]},]
        ///  }
        /// </summary>
        public OrderListDataJson OrderListDataJson
        {
            set { _OrderListDataJson = value; }
            get { return _OrderListDataJson; }
        }
        #endregion Model
    }
    public class OrderListDataJson
    {
        private OrderListJson[] _OrderListJson;
        public OrderListJson[] OrderListJson
        {
            set { _OrderListJson = value; }
            get { return _OrderListJson; }
        }
    }
    public class OrderListJson
    {
        private int _orderlistid;
        private int _orderid;
        private int _storageid;
        private int _productsid;
        private decimal _oquantity;
        private decimal _oprice;
        private decimal _omoney;
        private int _storessupplierid;
        private int _ispromotions;
        private int _oworktype;
        private int _IsGifts;
        private int _PriceClassID;
        private DateTime _oappendtime;
        private OrderFieldValueInfo[] _OrderFieldValueInfo;
        /// <summary>
        /// 
        /// </summary>
        public int OrderListID
        {
            set { _orderlistid = value; }
            get { return _orderlistid; }
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
        public decimal oQuantity
        {
            set { _oquantity = value; }
            get { return _oquantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal oPrice
        {
            set { _oprice = value; }
            get { return _oprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal oMoney
        {
            set { _omoney = value; }
            get { return _omoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int StoresSupplierID
        {
            set { _storessupplierid = value; }
            get { return _storessupplierid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int IsPromotions
        {
            set { _ispromotions = value; }
            get { return _ispromotions; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int oWorkType
        {
            set { _oworktype = value; }
            get { return _oworktype; }
        }
        /// <summary>
        /// 是否为赠品,非赠品=0,赠品=附属产品编号(ProductsID)
        /// </summary>
        public int IsGifts
        {
            set { _IsGifts = value; }
            get { return _IsGifts; }
        }
        public int PriceClassID
        {
            set { _PriceClassID = value; }
            get { return _PriceClassID; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime oAppendTime
        {
            set { _oappendtime = value; }
            get { return _oappendtime; }
        }
        public OrderFieldValueInfo[] OrderFieldValueInfo
        {
            set { _OrderFieldValueInfo = value; }
            get { return _OrderFieldValueInfo; }
        }
    }

    public class OrderListInfo
    {
        #region Model
        private int _orderlistid;
        private int _orderid;
        private int _storageid;
        private int _productsid;
        private decimal _oquantity;
        private decimal _oprice;
        private decimal _omoney;
        private int _storessupplierid;
        private int _ispromotions;
        private int _oworktype;
        private int _IsGifts;
        private DateTime _oappendtime;
        private int _PriceClassID;

        /// <summary>
        /// 
        /// </summary>
        public int OrderListID
        {
            set { _orderlistid = value; }
            get { return _orderlistid; }
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
        public decimal oQuantity
        {
            set { _oquantity = value; }
            get { return _oquantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal oPrice
        {
            set { _oprice = value; }
            get { return _oprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal oMoney
        {
            set { _omoney = value; }
            get { return _omoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int StoresSupplierID
        {
            set { _storessupplierid = value; }
            get { return _storessupplierid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int IsPromotions
        {
            set { _ispromotions = value; }
            get { return _ispromotions; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int oWorkType
        {
            set { _oworktype = value; }
            get { return _oworktype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int IsGifts
        {
            set { _IsGifts = value; }
            get { return _IsGifts; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime oAppendTime
        {
            set { _oappendtime = value; }
            get { return _oappendtime; }
        }
        public int PriceClassID
        {
            set { _PriceClassID = value; }
            get { return _PriceClassID; }
        }
        #endregion Model

    }

    public class OrderFieldInfo
    {
        #region Model
        private int _orderfieldid;
        private int _ordertype;
        private string _fname;
        private int _ftype;
        private int _fstate;
        private int _fPrint;
        private int _fPrintAdd;

        private string _fProductField;
        /// <summary>
        /// 
        /// </summary>
        public int OrderFieldID
        {
            set { _orderfieldid = value; }
            get { return _orderfieldid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int OrderType
        {
            set { _ordertype = value; }
            get { return _ordertype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string fName
        {
            set { _fname = value; }
            get { return _fname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int fType
        {
            set { _ftype = value; }
            get { return _ftype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int fState
        {
            set { _fstate = value; }
            get { return _fstate; }
        }

        /// <summary>
        /// 打印时显示,0=显示,1=不显示
        /// </summary>
        public int fPrint
        {
            set { _fPrint = value; }
            get { return _fPrint; }
        }
        /// <summary>
        /// 打印随附单时显示,0=显示,1=不显示
        /// </summary>
        public int fPrintAdd
        {
            set { _fPrintAdd = value; }
            get { return _fPrintAdd; }
        }
        /// <summary>
        /// 对应产品表字段,实现产品信息自动填充
        /// </summary>
        public string fProductField
        {
            set { _fProductField = value; }
            get { return _fProductField; }
        }
        #endregion Model

    }

    public class OrderFieldValueInfo
    {
        #region Model
        private int _orderfieldvalueid;
        private int _orderfieldid;
        private int _orderlistid;
        private string _ofieldvalue;
        private int _isverify;
        private DateTime _oappendtime;
        /// <summary>
        /// 
        /// </summary>
        public int OrderFieldValueID
        {
            set { _orderfieldvalueid = value; }
            get { return _orderfieldvalueid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int OrderFieldID
        {
            set { _orderfieldid = value; }
            get { return _orderfieldid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int OrderListID
        {
            set { _orderlistid = value; }
            get { return _orderlistid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string oFieldValue
        {
            set { _ofieldvalue = value; }
            get { return _ofieldvalue; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int IsVerify
        {
            set { _isverify = value; }
            get { return _isverify; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime oAppendTime
        {
            set { _oappendtime = value; }
            get { return _oappendtime; }
        }
        #endregion Model

    }


	/*
	 * "{"OrderListJson":[
	 * 		{"OrderListID":5,"OrderID":2,"StorageID":1,"ProductsID":1,"pQuantity:"-123},
	 * 		{"OrderListID":6,"OrderID":2,"StorageID":1,"ProductsID":2,"pQuantity:"-111}
	 * ]}"
	 */
	public class StorageOrderListDataJson
	{
		private StorageOrder[] _StorageOrder;

		public StorageOrder[] OrderListJson
		{
			set { _StorageOrder = value; }
			get { return _StorageOrder;}
		}
	}

	public class StorageOrder
	{
		private int _OrderListID;
		private int _OrderID;
		private int _StorageID;
		private int _ProductsID;
		private int _pQuantity;

		public int OrderListID
		{
			set { _OrderListID = value; }
			get { return _OrderListID;}
		}

		public int OrderID
		{
			set { _OrderID = value; }
			get { return _OrderID;}
		}

		public int StorageID
		{
			set { _StorageID = value; }
			get { return _StorageID;}
		}

		public int ProductsID
		{
			set { _ProductsID = value; }
			get { return _ProductsID;}
		}

		public int pQuantity
		{
			set { _pQuantity = value; }
			get { return _pQuantity;}
		}
	}

    public class OrderWorkingLogInfo
    {
        #region Model
        private int _orderworkinglogid;
        private int _orderid;
        private int _userid;
        private int _otype;
        private string _omsg;
        private DateTime _pappendtime;
        /// <summary>
        /// 
        /// </summary>
        public int OrderWorkingLogID
        {
            set { _orderworkinglogid = value; }
            get { return _orderworkinglogid; }
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
        public int UserID
        {
            set { _userid = value; }
            get { return _userid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int oType
        {
            set { _otype = value; }
            get { return _otype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string oMsg
        {
            set { _omsg = value; }
            get { return _omsg; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime pAppendTime
        {
            set { _pappendtime = value; }
            get { return _pappendtime; }
        }
        #endregion Model

    }

    #region 导入数据使用
    public class Order
    {
        private string _O_ID;
        public string O_ID
        {
            set { _O_ID = value; }
            get { return _O_ID; }
        }

        private string _O_ORDERNUM;
        public string O_ORDERNUM
        {
            set { _O_ORDERNUM = value; }
            get { return _O_ORDERNUM; }
        }

        private string _O_CID;
        public string O_CID
        {
            set { _O_CID = value; }
            get { return _O_CID; }
        }

        private string _c_name;
        public string c_name
        {
            set { _c_name = value; }
            get { return _c_name; }
        }

        private string _O_CPEOPLE;
        public string O_CPEOPLE
        {
            set { _O_CPEOPLE = value; }
            get { return _O_CPEOPLE; }
        }

        private string _sa_name;
        public string sa_name
        {
            set { _sa_name = value; }
            get { return _sa_name; }
        }

        private string _O_ISCHECK;
        public string O_ISCHECK
        {
            set { _O_ISCHECK = value; }
            get { return _O_ISCHECK; }
        }

        private string _O_CHECK;
        public string O_CHECK
        {
            set { _O_CHECK = value; }
            get { return _O_CHECK; }
        }

        private string _O_REMARK;
        public string O_REMARK
        {
            set { _O_REMARK = value; }
            get { return _O_REMARK; }
        }

        private string _O_SET;
        public string O_SET
        {
            set { _O_SET = value; }
            get { return _O_SET; }
        }

        private string _O_CREATETIME;
        public string O_CREATETIME
        {
            set { _O_CREATETIME = value; }
            get { return _O_CREATETIME; }
        }

        private string _O_TIME;
        public string O_TIME
        {
            set { _O_TIME = value; }
            get { return _O_TIME; }
        }

        private string _O_SUID;
        public string O_SUID
        {
            set { _O_SUID = value; }
            get { return _O_SUID; }
        }

        private string _C_ORDERID;
        public string C_ORDERID
        {
            set { _C_ORDERID = value; }
            get { return _C_ORDERID; }
        }

        private string _C_MD;
        public string C_MD
        {
            set { _C_MD = value; }
            get { return _C_MD; }
        }

        private OrderData[] _OrderData;
        public OrderData[] OrderData
        {
            set { _OrderData = value; }
            get { return _OrderData; }
        }
    }
    public class OrderData
    {
        private string _p_code;
        public string p_code
        {
            set { _p_code = value; }
            get { return _p_code; }
        }

        private string _p_name;
        public string p_name
        {
            set { _p_name = value; }
            get { return _p_name; }
        }

        private string _s_price;
        public string s_price
        {
            set { _s_price = value; }
            get { return _s_price; }
        }

        private string _s_quantity;
        public string s_quantity
        {
            set { _s_quantity = value; }
            get { return _s_quantity; }
        }

        private string _s_total;
        public string s_total
        {
            set { _s_total = value; }
            get { return _s_total; }
        }

        private string _makedate;
        public string makedate
        {
            set { _makedate = value; }
            get { return _makedate; }
        }

        private string _Manufacturers;
        public string Manufacturers
        {
            set { _Manufacturers = value; }
            get { return _Manufacturers; }
        }

        private string _Durability;
        public string Durability
        {
            set { _Durability = value; }
            get { return _Durability; }
        }

        private string _Node;
        public string Node
        {
            set { _Node = value; }
            get { return _Node; }
        }

        private string _PROMOTIONS;
        public string PROMOTIONS
        {
            set { _PROMOTIONS = value; }
            get { return _PROMOTIONS; }
        }
    }
    public class PAttribute {
        private int _productid;
        private PAttributePrice[] _PAttributePrice;
        public int Productid
        {
            set { _productid = value; }
            get { return _productid; }
        }
        public PAttributePrice[] PAttributePrice
        {
            set { _PAttributePrice = value; }
            get { return _PAttributePrice; }
        }
    }
    public class PAttributePrice {
        private string _pr_Name = "";
        private string _a_Price = "";
        public string pr_Name
        {
            set { _pr_Name = value; }
            get { return _pr_Name; }
        }
        public string a_Price
        {
            set { _a_Price = value; }
            get { return _a_Price; }
        }
    }
   
    #endregion

    public class OrderNOFullInfo
    {
        private int _orderid;
        private int _ordertoid;
        private int _productsid;
        private int _formstorageid;
        private int _tostorageid;
        private decimal _oquantity;
        private int _ostate;
        private DateTime _oappendtimie;
        private int _userid;
        private int _oNextOrderID;
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
        public int OrderToID
        {
            set { _ordertoid = value; }
            get { return _ordertoid; }
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
        public int FormStorageID
        {
            set { _formstorageid = value; }
            get { return _formstorageid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int ToStorageID
        {
            set { _tostorageid = value; }
            get { return _tostorageid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal oQuantity
        {
            set { _oquantity = value; }
            get { return _oquantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int oState
        {
            set { _ostate = value; }
            get { return _ostate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime oAppendTimie
        {
            set { _oappendtimie = value; }
            get { return _oappendtimie; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int UserID
        {
            set { _userid = value; }
            get { return _userid; }
        }
        /// <summary>
        /// 后续处理单据编号,不需要后续处理=-1,未处理=0
        /// </summary>
        public int oNextOrderID
        {
            set { _oNextOrderID = value; }
            get { return _oNextOrderID; }
        }
    }

    #region 批量打印使用
    public class OrderPrintObj {
        private Order _order;
        private DataTable _OrderFieldList;//自定义字段
        private DataTable _OrderFieldValueList;//自定义字段值
        private DataTable _OrderList;//单据体列表
        private DataSet _OrderListSet;//分页后的单据体集合

        private decimal _summoney;//合计
        private string _summoney_str;//大写
        private decimal _sumQuantityM;//合计数量,小单位
        private decimal _sumQuantityB;//合计数量,大单位

        private decimal _summoney_page;//合计
        private string _summoney_str_page;//大写
        private decimal _sumQuantityM_page;//合计数量,小单位
        private decimal _sumQuantityB_page;//合计数量,大单位

        private int _print_page_sum;//打印分页合计页数
        private int _print_page_index;//打印分页当前页码

        private int _OrderFieldCount;//自定义字段数
        private bool _ShowMoney;//是否显示金额
        private UserInfo _print_ui;//开单人员
        private UserInfo _print_v_ui;//审核人员

        public Order Order {
            set { _order = value; }
            get { return _order; }
        }

        public DataTable OrderFieldList {
            set { _OrderFieldList = value; }
            get { return _OrderFieldList; }
        }

        public DataTable OrderFieldValueList
        {
            set { _OrderFieldValueList = value; }
            get { return _OrderFieldValueList; }
        }

        public DataTable OrderList
        {
            set { _OrderList = value; }
            get { return _OrderList; }
        }

        public DataSet OrderListSet
        {
            set { _OrderListSet = value; }
            get { return _OrderListSet; }
        }

        public decimal summoney {
            set { _summoney = value; }
            get { return _summoney; }
        }
        public string summoney_str {
            set { _summoney_str = value; }
            get { return _summoney_str; }
        }
        public decimal sumQuantityM = 0;//合计数量,小单位
        public decimal sumQuantityB = 0;//合计数量,大单位

        public decimal summoney_page = 0;//合计
        public string summoney_str_page = "";//大写
        public decimal sumQuantityM_page = 0;//合计数量,小单位
        public decimal sumQuantityB_page = 0;//合计数量,大单位

        public int print_page_sum = 0;//打印分页合计页数
        public int print_page_index = 0;//打印分页当前页码

        public int OrderFieldCount = 0;//自定义字段数
        public bool ShowMoney = false;//是否显示金额
        public UserInfo print_ui = new UserInfo();//开单人员
        public UserInfo print_v_ui = new UserInfo();//审核人员
    }
    #endregion

}
