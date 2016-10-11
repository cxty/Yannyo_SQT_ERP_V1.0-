using System;

namespace Yannyo.Entity
{
    public class ErpOrderInfo
    {
        private int _erporderid;
        private int _o_id;
        private string _o_ordernum;
        private DateTime _o_createtime;
        private int _productsid;
        private int _p_id;
        private string _p_code;
        private string _p_name;
        private string _p_rules;
        private int _s_id;
        private decimal _s_price;
        private int _s_quantity;
        private decimal _s_total;
        private string _c_name;
        private string _c_code;
        private string _r_name;
        private int _r_id;
        private string _sa_name;
        private DateTime _eappendtime;
        private string _ProductsName;
        private int _StoresID;
        private string _StoresName;
        private int _StaffID;
        private int _PROMOTIONS;
        private int _IsCheck;
        private int _storageid;

        /// <summary>
        /// 系统编号
        /// </summary>
        public int ErpOrderID
        {
            set { _erporderid = value; }
            get { return _erporderid; }
        }
        /// <summary>
        /// 单据头系统编号
        /// </summary>
        public int O_ID
        {
            set { _o_id = value; }
            get { return _o_id; }
        }
        /// <summary>
        /// 单据头编号
        /// </summary>
        public string O_ORDERNUM
        {
            set { _o_ordernum = value; }
            get { return _o_ordernum; }
        }
        /// <summary>
        /// 单据头创建时间
        /// </summary>
        public DateTime O_CREATETIME
        {
            set { _o_createtime = value; }
            get { return _o_createtime; }
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
        /// Erp产品编号
        /// </summary>
        public int P_ID
        {
            set { _p_id = value; }
            get { return _p_id; }
        }
        /// <summary>
        /// 条码
        /// </summary>
        public string P_CODE
        {
            set { _p_code = value; }
            get { return _p_code; }
        }
        /// <summary>
        /// 名称
        /// </summary>
        public string P_NAME
        {
            set { _p_name = value; }
            get { return _p_name; }
        }
        /// <summary>
        /// 规格
        /// </summary>
        public string P_RULES
        {
            set { _p_rules = value; }
            get { return _p_rules; }
        }
        /// <summary>
        /// 子单据编号
        /// </summary>
        public int S_ID
        {
            set { _s_id = value; }
            get { return _s_id; }
        }
        /// <summary>
        /// 子单金额
        /// </summary>
        public decimal S_PRICE
        {
            set { _s_price = value; }
            get { return _s_price; }
        }
        /// <summary>
        /// 子单数量
        /// </summary>
        public int S_QUANTITY
        {
            set { _s_quantity = value; }
            get { return _s_quantity; }
        }
        /// <summary>
        /// 子单总额
        /// </summary>
        public decimal S_TOTAL
        {
            set { _s_total = value; }
            get { return _s_total; }
        }
        /// <summary>
        /// 客户编号
        /// </summary>
        public string C_CODE
        {
            set { _c_code = value; }
            get { return _c_code; }
        }
        /// <summary>
        /// 客户名称
        /// </summary>
        public string C_NAME
        {
            set { _c_name = value; }
            get { return _c_name; }
        }
        /// <summary>
        /// 单据名称
        /// </summary>
        public string R_NAME
        {
            set { _r_name = value; }
            get { return _r_name; }
        }
        /// <summary>
        /// 单据类型
        /// </summary>
        public int R_ID
        {
            set { _r_id = value; }
            get { return _r_id; }
        }
        /// <summary>
        /// 业务员名称
        /// </summary>
        public string SA_NAME
        {
            set { _sa_name = value; }
            get { return _sa_name; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime eAppendTime
        {
            set { _eappendtime = value; }
            get { return _eappendtime; }
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
        /// 门店客户编号
        /// </summary>
        public int StoresID
        {
            set { _StoresID = value; }
            get { return _StoresID; }
        }
        /// <summary>
        /// 门店客户名称
        /// </summary>
        public string StoresName
        {
            set { _StoresName = value; }
            get { return _StoresName; }
        }
        /// <summary>
        /// 人员编号
        /// </summary>
        public int StaffID
        {
            set { _StaffID = value; }
            get { return _StaffID; }
        }
        /// <summary>
        /// 是否促销品
        /// </summary>
        public int PROMOTIONS
        {
            set { _PROMOTIONS = value; }
            get { return _PROMOTIONS; }
        }
        /// <summary>
        /// 是否已对账,未对账=0,已对账=1
        /// </summary>
        public int IsCheck
        {
            set { _IsCheck = value; }
            get { return _IsCheck; }
        }
        /// <summary>
        /// 仓库编号
        /// </summary>
        public int storageid
        {
            set { _storageid = value; }
            get { return _storageid; }
        }
    }
}
