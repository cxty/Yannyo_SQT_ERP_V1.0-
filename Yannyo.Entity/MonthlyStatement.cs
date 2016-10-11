using System;

namespace Yannyo.Entity
{
    /// <summary>
    /// 对账单头
    /// </summary>
   public  class MonthlyStatementInfo
    {
        private int _monthlystatementid;
        private string _sCode;
        private int _sobjectid;
        private string _sObjectName;
        private int _sobjecttype;
        private int _stype;
        private decimal _supmoney;
        private decimal _sthismoney;
        private decimal _smoney;
        private decimal _stomoney;
        private int _ssteps;
        private int _sbalancetype;
        private int _sreceiptstate;
        private DateTime _sdatetime;
        private int _sstate;
        private int _userid;
        private DateTime _sappendtime;
        private decimal _sBalanceMoney;
       private DateTime _LastPrintDateTime;
        private MonthlyStatementDataJson _MonthlyStatementDataJson;
        /// <summary>
        /// 对账单编号
        /// </summary>
        public int MonthlyStatementID
        {
            set { _monthlystatementid = value; }
            get { return _monthlystatementid; }
        }
       /// <summary>
       /// 对账单号
       /// </summary>
        public string sCode
        {
            set { _sCode = value; }
            get { return _sCode; }
        }
        /// <summary>
        /// 对账对象
        /// </summary>
        public int sObjectID
        {
            set { _sobjectid = value; }
            get { return _sobjectid; }
        }
        /// <summary>
        /// 对账对象名称
        /// </summary>
        public string sObjectName
        {
            set { _sObjectName = value; }
            get { return _sObjectName; }
        }
        /// <summary>
        /// 对象类型,客户=0,供应商=1,人员=2
        /// </summary>
        public int sObjectType
        {
            set { _sobjecttype = value; }
            get { return _sobjecttype; }
        }
        /// <summary>
        /// 账单类型,应收=1,应付=2
        /// </summary>
        public int sType
        {
            set { _stype = value; }
            get { return _stype; }
        }
        /// <summary>
        /// 上期余额
        /// </summary>
        public decimal sUpMoney
        {
            set { _supmoney = value; }
            get { return _supmoney; }
        }
        /// <summary>
        /// 本期对账金额
        /// </summary>
        public decimal sThisMoney
        {
            set { _sthismoney = value; }
            get { return _sthismoney; }
        }
        /// <summary>
        /// 实际对账金额
        /// </summary>
        public decimal sMoney
        {
            set { _smoney = value; }
            get { return _smoney; }
        }
        /// <summary>
        /// 到款金额
        /// </summary>
        public decimal sToMoney
        {
            set { _stomoney = value; }
            get { return _stomoney; }
        }
        /// <summary>
        /// 本期余额
        /// </summary>
        public decimal sBalanceMoney
        {
            set { _sBalanceMoney = value; }
            get { return _sBalanceMoney; }
        }
        /// <summary>
        /// 处理流程,新建=0,已对账=1,已到款=2
        /// </summary>
        public int sSteps
        {
            set { _ssteps = value; }
            get { return _ssteps; }
        }
        /// <summary>
        /// 余额类型,无余额=0,余额转费用=1,余额转收入=2,余额转坏账=3
        /// </summary>
        public int sBalanceType
        {
            set { _sbalancetype = value; }
            get { return _sbalancetype; }
        }
        /// <summary>
        /// 发票是否已开/收
        /// </summary>
        public int sReceiptState
        {
            set { _sreceiptstate = value; }
            get { return _sreceiptstate; }
        }
        /// <summary>
        /// 对账时间
        /// </summary>
        public DateTime sDateTime
        {
            set { _sdatetime = value; }
            get { return _sdatetime; }
        }
       /// <summary>
        /// 最后打印时间
        /// </summary>
        public DateTime LastPrintDateTime
        {
            set { _LastPrintDateTime = value; }
            get { return _LastPrintDateTime; }
        }
       
        /// <summary>
        /// 系统状态
        /// </summary>
        public int sState
        {
            set { _sstate = value; }
            get { return _sstate; }
        }
        /// <summary>
        /// 经办人编号
        /// </summary>
        public int UserID
        {
            set { _userid = value; }
            get { return _userid; }
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
       /// Json数据
       /// </summary>
        public MonthlyStatementDataJson MonthlyStatementDataJson
        {
            set { _MonthlyStatementDataJson = value; }
            get { return _MonthlyStatementDataJson; }
        }
    }

    /// <summary>
    /// 对账单内容
    /// </summary>
   public class MonthlyStatementDataInfo
   {
       private int _monthlystatementdataid;
       private int _monthlystatementid;
       private int _orderid;
       private decimal _omoney;
       private string _sremake;
       private DateTime _sappendtime;
       /// <summary>
       /// 对账单内容编号
       /// </summary>
       public int MonthlyStatementDataID
       {
           set { _monthlystatementdataid = value; }
           get { return _monthlystatementdataid; }
       }
       /// <summary>
       /// 所属对账单编号
       /// </summary>
       public int MonthlyStatementID
       {
           set { _monthlystatementid = value; }
           get { return _monthlystatementid; }
       }
       /// <summary>
       /// 进销存单据编号
       /// </summary>
       public int OrderID
       {
           set { _orderid = value; }
           get { return _orderid; }
       }
       /// <summary>
       /// 单据总金额
       /// </summary>
       public decimal oMoney
       {
           set { _omoney = value; }
           get { return _omoney; }
       }
       /// <summary>
       /// 备注
       /// </summary>
       public string sRemake
       {
           set { _sremake = value; }
           get { return _sremake; }
       }
       /// <summary>
       /// 创建时间
       /// </summary>
       public DateTime sAppendTime
       {
           set { _sappendtime = value; }
           get { return _sappendtime; }
       }
   }

    /// <summary>
    /// 对账单操作记录
    /// </summary>
   public class MonthlyStatementWorkingLogInfo
   {
       private int _monthlystatementworkinglogid;
       private int _monthlystatementid;
       private int _userid;
       private string _username;
       private int _mtype;
       private string _mmsg;
       private DateTime _mappendtime;
       /// <summary>
       /// 操作记录编号
       /// </summary>
       public int MonthlyStatementWorkingLogID
       {
           set { _monthlystatementworkinglogid = value; }
           get { return _monthlystatementworkinglogid; }
       }
       /// <summary>
       /// 单头编号
       /// </summary>
       public int MonthlyStatementID
       {
           set { _monthlystatementid = value; }
           get { return _monthlystatementid; }
       }
       /// <summary>
       /// 操作员编号
       /// </summary>
       public int UserID
       {
           set { _userid = value; }
           get { return _userid; }
       }
       /// <summary>
       /// 操作员名称
       /// </summary>
       public string UserName
       {
           set { _username = value; }
           get { return _username; }
       }
       /// <summary>
       /// 操作类型
       /// </summary>
       public int mType
       {
           set { _mtype = value; }
           get { return _mtype; }
       }
       /// <summary>
       /// 操作信息
       /// </summary>
       public string mMsg
       {
           set { _mmsg = value; }
           get { return _mmsg; }
       }
       /// <summary>
       /// 创建时间
       /// </summary>
       public DateTime mAppendTime
       {
           set { _mappendtime = value; }
           get { return _mappendtime; }
       }
   }

    /// <summary>
    /// 对账单附加凭证
    /// </summary>
   public class MonthlyStatementAppendDataInfo
   {
       private int _monthlystatementappenddataid;
       private int _monthlystatementid;
       private int _certificateid;
       private int _astate;
       private string _aremake;
       private DateTime _aappendtime;
       private decimal _cMoney;
       /// <summary>
       /// 附件凭证编号
       /// </summary>
       public int MonthlyStatementAppendDataID
       {
           set { _monthlystatementappenddataid = value; }
           get { return _monthlystatementappenddataid; }
       }
       /// <summary>
       /// 所属对账单编号
       /// </summary>
       public int MonthlyStatementID
       {
           set { _monthlystatementid = value; }
           get { return _monthlystatementid; }
       }
       /// <summary>
       /// 凭证编号
       /// </summary>
       public int CertificateID
       {
           set { _certificateid = value; }
           get { return _certificateid; }
       }
       /// <summary>
       /// 系统状态
       /// </summary>
       public int aState
       {
           set { _astate = value; }
           get { return _astate; }
       }
       /// <summary>
       /// 备注
       /// </summary>
       public string aRemake
       {
           set { _aremake = value; }
           get { return _aremake; }
       }
       /// <summary>
       /// 创建时间
       /// </summary>
       public DateTime aAppendTime
       {
           set { _aappendtime = value; }
           get { return _aappendtime; }
       }
       /// <summary>
       /// 凭证金额
       /// </summary>
       public decimal cMoney
       {
           set { _cMoney = value; }
           get { return _cMoney; }
       }
   }

    /// <summary>
    /// 对账单内容Json包
    /// </summary>
   public class MonthlyStatementDataJson
   {
       private MonthlyStatementDataInfo[] _MonthlyStatementDataInfo;
       private MonthlyStatementAppendDataInfo[] _MonthlyStatementAppendDataInfo;
       private MonthlyStatementAppendMoneyDataInfo[] _MonthlyStatementAppendMoneyDataInfo;
       public MonthlyStatementDataInfo[] MonthlyStatementData
       {
           set { _MonthlyStatementDataInfo = value; }
           get { return _MonthlyStatementDataInfo; }
       }
       public MonthlyStatementAppendDataInfo[] MonthlyStatementAppendData
       {
           set { _MonthlyStatementAppendDataInfo = value; }
           get { return _MonthlyStatementAppendDataInfo; }
       }
       public MonthlyStatementAppendMoneyDataInfo[] MonthlyStatementAppendMoneyData
       {
           set { _MonthlyStatementAppendMoneyDataInfo = value; }
           get { return _MonthlyStatementAppendMoneyDataInfo; }
       }
   }
}
