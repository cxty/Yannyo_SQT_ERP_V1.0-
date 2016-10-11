using System;

namespace Yannyo.Entity
{
   public class CertificateInfo
    {
        private int _certificateid;
        private string _ccode;
        private int _cNumber;
        private decimal _cmoney;
        private int _ctype;
        private int _userid;
        private string _UserName;
        private string _UserStaffName;
        private int _staffid;
        private string _StaffName;
        private string _cremake;
        private int _cobject;
        private int _cobjectid;
        private int _cstate;
        private DateTime _cdatetime;
        private DateTime _cappendtime;
        private int _toObject;
        private int _toObjectID;
        private string _toObjectName;
        private int _BankID;
        private string _BankName;
        private int _cSteps;
        private CertificateDataJson _CertificateDataJson;
        /// <summary>
        /// 凭据编号
        /// </summary>
        public int CertificateID
        {
            set { _certificateid = value; }
            get { return _certificateid; }
        }
        /// <summary>
        /// 单位类型
        /// </summary>
        public int toObject
        {
            set { _toObject = value; }
            get { return _toObject; }
        }
        /// <summary>
        /// 单位编号
        /// </summary>
        public int toObjectID
        {
            set { _toObjectID = value; }
            get { return _toObjectID; }
        }
        /// <summary>
        /// 单位名称
        /// </summary>
        public string toObjectName
        {
            set { _toObjectName = value; }
            get { return _toObjectName; }
        }
        /// <summary>
        /// 凭证代码
        /// </summary>
        public string cCode
        {
            set { _ccode = value; }
            get { return _ccode; }
        }
        /// <summary>
        /// 凭证序号,周期月,初始为1
        /// </summary>
        public int cNumber
        {
            set { _cNumber = value; }
            get { return _cNumber; }
        }
        /// <summary>
        /// 总金额
        /// </summary>
        public decimal cMoney
        {
            set { _cmoney = value; }
            get { return _cmoney; }
        }
        /// <summary>
        /// 凭证类型
        /// </summary>
        public int cType
        {
            set { _ctype = value; }
            get { return _ctype; }
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
            set { _UserName = value; }
            get { return _UserName; }
        }
        /// <summary>
        /// 操作员,人员名称
        /// </summary>
        public string UserStaffName
        {
            set { _UserStaffName = value; }
            get { return _UserStaffName; }
        }
        /// <summary>
        /// 经办人
        /// </summary>
        public int StaffID
        {
            set { _staffid = value; }
            get { return _staffid; }
        }
       /// <summary>
        /// 经办人名称
        /// </summary>
        public string StaffName
        {
            set { _StaffName = value; }
            get { return _StaffName; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string cRemake
        {
            set { _cremake = value; }
            get { return _cremake; }
        }
        /// <summary>
        /// 随附对象
        /// </summary>
        public int cObject
        {
            set { _cobject = value; }
            get { return _cobject; }
        }
        /// <summary>
        /// 随附对象编号
        /// </summary>
        public int cObjectID
        {
            set { _cobjectid = value; }
            get { return _cobjectid; }
        }
        /// <summary>
        /// 系统状态
        /// </summary>
        public int cState
        {
            set { _cstate = value; }
            get { return _cstate; }
        }
        /// <summary>
        /// 发生时间
        /// </summary>
        public DateTime cDateTime
        {
            set { _cdatetime = value; }
            get { return _cdatetime; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime cAppendTime
        {
            set { _cappendtime = value; }
            get { return _cappendtime; }
        }
        /// <summary>
        /// 收付款方式,银行编号
        /// </summary>
        public int BankID
        {
            set { _BankID = value; }
            get { return _BankID; }
        }
        /// <summary>
        /// 收付款方式,银行名称
        /// </summary>
        public string BankName
        {
            set { _BankName = value; }
            get { return _BankName; }
        }
       /// <summary>
       /// 凭证内容Json字符串
       /// </summary>
        public CertificateDataJson CertificateDataJson
        {
            set { _CertificateDataJson = value; }
            get { return _CertificateDataJson; }
        }
        /// <summary>
        /// 步骤
        /// </summary>
        public int cSteps
        {
            set { _cSteps = value; }
            get { return _cSteps; }
        }
    }

   public class CertificateDataJson
   {
       private CertificateDataInfo[] _CertificateDataInfoJson;
       public CertificateDataInfo[] CertificateDataInfoJson
       {
           set { _CertificateDataInfoJson = value; }
           get { return _CertificateDataInfoJson; }
       }
   }

   public class CertificateDataInfo 
   {
       private int _certificatedataid;
       private int _certificateid;
       private int _feessubjectid;
       private string _cdname;
       private decimal _cdmoney;
       private decimal _cdMoneyB;
       private string _cdremake;
       private DateTime _cdappendtime;
       private string _feessubjectname;
       private int _toObject;
       private int _toObjectID;
       private string _ObjectName;
       /// <summary>
       /// 凭证内容编号
       /// </summary>
       public int CertificateDataID
       {
           set { _certificatedataid = value; }
           get { return _certificatedataid; }
       }
       /// <summary>
       /// 所属凭证编号
       /// </summary>
       public int CertificateID
       {
           set { _certificateid = value; }
           get { return _certificateid; }
       }
       /// <summary>
       /// 科目编号
       /// </summary>
       public int FeesSubjectID
       {
           set { _feessubjectid = value; }
           get { return _feessubjectid; }
       }
       /// <summary>
       /// 科目名称
       /// </summary>
       public string FeesSubjectName
       {
           set { _feessubjectname = value; }
           get { return _feessubjectname; }
       }
       /// <summary>
       /// 名称
       /// </summary>
       public string cdName
       {
           set { _cdname = value; }
           get { return _cdname; }
       }
       /// <summary>
       /// 借方金额
       /// </summary>
       public decimal cdMoney
       {
           set { _cdmoney = value; }
           get { return _cdmoney; }
       }
       /// <summary>
       /// 贷方金额
       /// </summary>
       public decimal cdMoneyB
       {
           set { _cdMoneyB = value; }
           get { return _cdMoneyB; }
       }
       /// <summary>
       /// 备注
       /// </summary>
       public string cdRemake
       {
           set { _cdremake = value; }
           get { return _cdremake; }
       }
       /// <summary>
       /// 创建时间
       /// </summary>
       public DateTime cdAppendTime
       {
           set { _cdappendtime = value; }
           get { return _cdappendtime; }
       }
       /// <summary>
       /// 单位类型,客户=0,供应商=1,人员=2,超市系统=3
       /// </summary>
       public int toObject
       {
           set { _toObject = value; }
           get { return _toObject; }
       }
       /// <summary>
       /// 单位编号
       /// </summary>
       public int toObjectID
       {
           set { _toObjectID = value; }
           get { return _toObjectID; }
       }
       /// <summary>
       /// 单位名称
       /// </summary>
       public string ObjectName
       {
           set { _ObjectName = value; }
           get { return _ObjectName; }
       }
   }

   public class CertificatePicInfo 
   {
       private int _certificatepicid;
       private int _UserID;
       private int _certificateid;
       private string _ccode;
       private string _cpic;
       private DateTime _cappendtime;
       /// <summary>
       /// 
       /// </summary>
       public int CertificatePicID
       {
           set { _certificatepicid = value; }
           get { return _certificatepicid; }
       }
       /// <summary>
       /// 所属用户编号
       /// </summary>
       public int UserID
       {
           set { _UserID = value; }
           get { return _UserID; }
       }
       /// <summary>
       /// 
       /// </summary>
       public int CertificateID
       {
           set { _certificateid = value; }
           get { return _certificateid; }
       }
       /// <summary>
       /// 
       /// </summary>
       public string cCode
       {
           set { _ccode = value; }
           get { return _ccode; }
       }
       /// <summary>
       /// 
       /// </summary>
       public string cPic
       {
           set { _cpic = value; }
           get { return _cpic; }
       }
       /// <summary>
       /// 
       /// </summary>
       public DateTime cAppendTime
       {
           set { _cappendtime = value; }
           get { return _cappendtime; }
       }
   }

   public class CertificateWorkingLogInfo
   {
       public CertificateWorkingLogInfo()
		{}
		#region Model
		private int _certificateworkinglogid;
		private int _certificateid;
		private int _userid;
		private int _ctype;
		private string _cmsg;
		private DateTime _cappendtime= DateTime.Now;
		/// <summary>
		/// 操作记录编号
		/// </summary>
		public int CertificateWorkingLogID
		{
			set{ _certificateworkinglogid=value;}
			get{return _certificateworkinglogid;}
		}
		/// <summary>
		/// 所属凭证编号
		/// </summary>
		public int CertificateID
		{
			set{ _certificateid=value;}
			get{return _certificateid;}
		}
		/// <summary>
		/// 操作员编号
		/// </summary>
		public int UserID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 操作类型
		/// </summary>
		public int cType
		{
			set{ _ctype=value;}
			get{return _ctype;}
		}
		/// <summary>
		/// 操作信息
		/// </summary>
		public string cMsg
		{
			set{ _cmsg=value;}
			get{return _cmsg;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime cAppendTime
		{
			set{ _cappendtime=value;}
			get{return _cappendtime;}
		}
		#endregion Model
   }
}
