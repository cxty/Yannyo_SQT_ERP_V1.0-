using System;

namespace Yannyo.Entity
{
    public class StaffInfo
    {
        public StaffInfo()
        { }
        #region Model
        private int _staffid;
        private string _sname;
        private string _ssex;
        private int _stype;
        private string _sTEL;
        private int _sstate;
        private string _sCarID;
        private string _sEmail;
        private DateTime _sappendtime;
        private int _DepartmentsClassID;
        private string _DepartmentsClassName;
        /// <summary>
        /// 人员编号
        /// </summary>
        public int StaffID
        {
            set { _staffid = value; }
            get { return _staffid; }
        }
        /// <summary>
        /// 所属部门编号
        /// </summary>
        public int DepartmentsClassID
        {
            set { _DepartmentsClassID = value; }
            get { return _DepartmentsClassID; }
        }
        /// <summary>
        /// 所属部门名称
        /// </summary>
        public string DepartmentsClassName
        {
            set { _DepartmentsClassName = value; }
            get { return _DepartmentsClassName; }
        }
        /// <summary>
        /// 姓名
        /// </summary>
        public string sName
        {
            set { _sname = value; }
            get { return _sname; }
        }
        /// <summary>
        /// 性别
        /// </summary>
        public string sSex
        {
            set { _ssex = value; }
            get { return _ssex; }
        }
        /// <summary>
        /// 类型
        /// </summary>
        public int sType
        {
            set { _stype = value; }
            get { return _stype; }
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
        /// 创建时间
        /// </summary>
        public DateTime sAppendTime
        {
            set { _sappendtime = value; }
            get { return _sappendtime; }
        }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string sEmail
        {
            set { _sEmail = value; }
            get { return _sEmail; }
        }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string sTel
        {
            set { _sTEL = value; }
            get { return _sTEL; }
        }
        /// <summary>
        /// 身份证
        /// </summary>
        public string sCarID
        {
            set { _sCarID = value; }
            get { return _sCarID; }
        }
        #endregion
    }

    public class StaffDataInfo
    { 
    public StaffDataInfo()
		{}
		#region Model
		private int _staffdataid;
		private int _staffid;
		private string _sbirthday;
		private string _spolitical;
		private string _sbirthplace;
		private string _shometown;
		private string _seducation;
		private string _sprofessional;
		private string _shealth;
		private int _sheight;
		private int _sweight;
		private string _sspecialty;
		private string _shobbies;
		private string _scontactaddress;
		private string _sphotos;
		private int _semployment;
		private string _scanbedate;
		private decimal _streatment;
		/// <summary>
		/// 
		/// </summary>
		public int StaffDataID
		{
			set{ _staffdataid=value;}
			get{return _staffdataid;}
		}
		/// <summary>
		/// 所属人员编号
		/// </summary>
		public int StaffID
		{
			set{ _staffid=value;}
			get{return _staffid;}
		}
		/// <summary>
		/// 出生日期
		/// </summary>
		public string sBirthDay
		{
			set{ _sbirthday=value;}
			get{return _sbirthday;}
		}
		/// <summary>
		/// 政治面貌
		/// </summary>
		public string sPolitical
		{
			set{ _spolitical=value;}
			get{return _spolitical;}
		}
		/// <summary>
		/// 籍贯
		/// </summary>
		public string sBirthplace
		{
			set{ _sbirthplace=value;}
			get{return _sbirthplace;}
		}
		/// <summary>
		/// 出生地
		/// </summary>
		public string sHometown
		{
			set{ _shometown=value;}
			get{return _shometown;}
		}
		/// <summary>
		/// 最高学历
		/// </summary>
		public string sEducation
		{
			set{ _seducation=value;}
			get{return _seducation;}
		}
		/// <summary>
		/// 专业
		/// </summary>
		public string sProfessional
		{
			set{ _sprofessional=value;}
			get{return _sprofessional;}
		}
		/// <summary>
		/// 身体状况
		/// </summary>
		public string sHealth
		{
			set{ _shealth=value;}
			get{return _shealth;}
		}
		/// <summary>
		/// 身高
		/// </summary>
		public int sHeight
		{
			set{ _sheight=value;}
			get{return _sheight;}
		}
		/// <summary>
		/// 体重
		/// </summary>
		public int sWeight
		{
			set{ _sweight=value;}
			get{return _sweight;}
		}
		/// <summary>
		/// 技能特长
		/// </summary>
		public string sSpecialty
		{
			set{ _sspecialty=value;}
			get{return _sspecialty;}
		}
		/// <summary>
		/// 兴趣爱好
		/// </summary>
		public string sHobbies
		{
			set{ _shobbies=value;}
			get{return _shobbies;}
		}
		/// <summary>
		/// 联系地址
		/// </summary>
		public string sContactAddress
		{
			set{ _scontactaddress=value;}
			get{return _scontactaddress;}
		}
		/// <summary>
		/// 照片
		/// </summary>
		public string sPhotos
		{
			set{ _sphotos=value;}
			get{return _sphotos;}
		}
		/// <summary>
		/// 就业情况
		/// </summary>
		public int sEmployment
		{
			set{ _semployment=value;}
			get{return _semployment;}
		}
		/// <summary>
		/// 可报到时间
		/// </summary>
		public string sCanBeDate
		{
			set{ _scanbedate=value;}
			get{return _scanbedate;}
		}
		/// <summary>
		/// 希望待遇
		/// </summary>
		public decimal sTreatment
		{
			set{ _streatment=value;}
			get{return _streatment;}
		}
		#endregion Model
    }

    public class StaffEduDataInfo
    {
        public StaffEduDataInfo()
        { }
        #region Model
        private int _staffedudataid;
        private int _staffid;
        private string _edate;
        private string _eschools;
        private string _econtent;
        /// <summary>
        /// 
        /// </summary>
        public int StaffEduDataID
        {
            set { _staffedudataid = value; }
            get { return _staffedudataid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int StaffID
        {
            set { _staffid = value; }
            get { return _staffid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string eDate
        {
            set { _edate = value; }
            get { return _edate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string eSchools
        {
            set { _eschools = value; }
            get { return _eschools; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string eContent
        {
            set { _econtent = value; }
            get { return _econtent; }
        }
        #endregion Model

    }

    public class StaffEduDataJson {
        private StaffEduDataInfo[] _EduDataListJson;

        public StaffEduDataInfo[] EduDataListJson
        {
            set { _EduDataListJson = value; }
            get { return _EduDataListJson; }
        }
    }

    public class StaffFamilyDataInfo
    {
        public StaffFamilyDataInfo()
        { }
        #region Model
        private int _stafffamilydataid;
        private int _staffid;
        private string _ftitle;
        private string _fname;
        private string _fage;
        private string _fenterprise;
        private string _fwork;
        private string _faddress;
        private string _ftel;
        /// <summary>
        /// 
        /// </summary>
        public int StaffFamilyDataID
        {
            set { _stafffamilydataid = value; }
            get { return _stafffamilydataid; }
        }
        /// <summary>
        /// 所属人员编号
        /// </summary>
        public int StaffID
        {
            set { _staffid = value; }
            get { return _staffid; }
        }
        /// <summary>
        /// 称谓
        /// </summary>
        public string fTitle
        {
            set { _ftitle = value; }
            get { return _ftitle; }
        }
        /// <summary>
        /// 姓名
        /// </summary>
        public string fName
        {
            set { _fname = value; }
            get { return _fname; }
        }
        /// <summary>
        /// 年龄
        /// </summary>
        public string fAge
        {
            set { _fage = value; }
            get { return _fage; }
        }
        /// <summary>
        /// 工作单位
        /// </summary>
        public string fEnterprise
        {
            set { _fenterprise = value; }
            get { return _fenterprise; }
        }
        /// <summary>
        /// 岗位
        /// </summary>
        public string fWork
        {
            set { _fwork = value; }
            get { return _fwork; }
        }
        /// <summary>
        /// 地址
        /// </summary>
        public string fAddress
        {
            set { _faddress = value; }
            get { return _faddress; }
        }
        /// <summary>
        /// 电话
        /// </summary>
        public string fTel
        {
            set { _ftel = value; }
            get { return _ftel; }
        }
        #endregion Model

    }

    public class StaffFamilyDataJson {
        private StaffFamilyDataInfo[] _FamilyDataListJson;

        public StaffFamilyDataInfo[] FamilyDataListJson
        {
            set { _FamilyDataListJson = value; }
            get { return _FamilyDataListJson; }
        }
    }

    public class StaffWorkDataInfo
    {
        public StaffWorkDataInfo()
        { }
        #region Model
        private int _staffworkdataid;
        private int _staffid;
        private string _wdate;
        private string _wenterprise;
        private string _wtel;
        private string _wjobs;
        private string _wincome;
        /// <summary>
        /// 
        /// </summary>
        public int StaffWorkDataID
        {
            set { _staffworkdataid = value; }
            get { return _staffworkdataid; }
        }
        /// <summary>
        /// 所属人员编号
        /// </summary>
        public int StaffID
        {
            set { _staffid = value; }
            get { return _staffid; }
        }
        /// <summary>
        /// 时间
        /// </summary>
        public string wDate
        {
            set { _wdate = value; }
            get { return _wdate; }
        }
        /// <summary>
        /// 单位
        /// </summary>
        public string wEnterprise
        {
            set { _wenterprise = value; }
            get { return _wenterprise; }
        }
        /// <summary>
        /// 电话
        /// </summary>
        public string wTel
        {
            set { _wtel = value; }
            get { return _wtel; }
        }
        /// <summary>
        /// 职位
        /// </summary>
        public string wJobs
        {
            set { _wjobs = value; }
            get { return _wjobs; }
        }
        /// <summary>
        /// 收入
        /// </summary>
        public string wIncome
        {
            set { _wincome = value; }
            get { return _wincome; }
        }
        #endregion Model

    }

    public class StaffWorkDataJson
    {
        private StaffWorkDataInfo[] _WorkDataListJson;

        public StaffWorkDataInfo[] WorkDataListJson
        {
            set { _WorkDataListJson = value; }
            get { return _WorkDataListJson; }
        }
    }

    public class StaffAnalysisDataInfo
    {
        public StaffAnalysisDataInfo()
        { }
        #region Model
        private int _staffanalysisdataid;
        private int _staffid;
        private int _awearing;
        private int _aeducation;
        private int _awork;
        private int _acommunication;
        private int _aconfidence;
        private int _aleadership;
        private int _ajobstability;
        private int _acomputer;
        private int _aenglish;
        private int _awritten;
        private int _aevaluation;
        private string _aevaluationmsg;
        private DateTime _adatetime;
        private DateTime _aappendtime = DateTime.Now;
        /// <summary>
        /// 
        /// </summary>
        public int StaffAnalysisDataID
        {
            set { _staffanalysisdataid = value; }
            get { return _staffanalysisdataid; }
        }
        /// <summary>
        /// 所属人员编号
        /// </summary>
        public int StaffID
        {
            set { _staffid = value; }
            get { return _staffid; }
        }
        /// <summary>
        /// 形象
        /// </summary>
        public int aWearing
        {
            set { _awearing = value; }
            get { return _awearing; }
        }
        /// <summary>
        /// 教育
        /// </summary>
        public int aEducation
        {
            set { _aeducation = value; }
            get { return _aeducation; }
        }
        /// <summary>
        /// 工作经验
        /// </summary>
        public int aWork
        {
            set { _awork = value; }
            get { return _awork; }
        }
        /// <summary>
        /// 沟通能力
        /// </summary>
        public int aCommunication
        {
            set { _acommunication = value; }
            get { return _acommunication; }
        }
        /// <summary>
        /// 自信心
        /// </summary>
        public int aConfidence
        {
            set { _aconfidence = value; }
            get { return _aconfidence; }
        }
        /// <summary>
        /// 领导能力
        /// </summary>
        public int aLeadership
        {
            set { _aleadership = value; }
            get { return _aleadership; }
        }
        /// <summary>
        /// 工作稳定性
        /// </summary>
        public int aJobstability
        {
            set { _ajobstability = value; }
            get { return _ajobstability; }
        }
        /// <summary>
        /// 计算机操作能力
        /// </summary>
        public int aComputer
        {
            set { _acomputer = value; }
            get { return _acomputer; }
        }
        /// <summary>
        /// 英语水平
        /// </summary>
        public int aEnglish
        {
            set { _aenglish = value; }
            get { return _aenglish; }
        }
        /// <summary>
        /// 笔试
        /// </summary>
        public int aWritten
        {
            set { _awritten = value; }
            get { return _awritten; }
        }
        /// <summary>
        /// 综合评价
        /// </summary>
        public int aEvaluation
        {
            set { _aevaluation = value; }
            get { return _aevaluation; }
        }
        /// <summary>
        /// 平价信息
        /// </summary>
        public string aEvaluationMSG
        {
            set { _aevaluationmsg = value; }
            get { return _aevaluationmsg; }
        }
        /// <summary>
        /// 面试时间
        /// </summary>
        public DateTime aDateTime
        {
            set { _adatetime = value; }
            get { return _adatetime; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime aAppendTime
        {
            set { _aappendtime = value; }
            get { return _aappendtime; }
        }
        #endregion Model

    }
}
