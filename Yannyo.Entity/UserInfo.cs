using System;

namespace Yannyo.Entity
{
   public class UserInfo
    {
        public UserInfo()
        { }
        #region Model
        private int _userid;
        private int _StaffID;
        private string _StaffName;
        private string _uname;
        private string _upwd;
        private string _ucode;
        private string _upermissions;
        private DateTime _uappendtime;
        private DateTime _uupappendtime;
        private string _ulastip;
        private int _uestate;
        private int _uType;
        private string _uTypeName;

		private string _StorageIDStr;

        /// <summary>
        /// 用户编号
        /// </summary>
        public int UserID
        {
            set { _userid = value; }
            get { return _userid; }
        }
        public int StaffID
        {
            set { _StaffID = value; }
            get { return _StaffID; }
        }
        public string StaffName
        {
            set { _StaffName = value; }
            get { return _StaffName; }
        }
        /// <summary>
        /// 用户名
        /// </summary>
        public string uName
        {
            set { _uname = value; }
            get { return _uname; }
        }
        /// <summary>
        /// 登陆密码
        /// </summary>
        public string uPWD
        {
            set { _upwd = value; }
            get { return _upwd; }
        }
        /// <summary>
        /// 随机校验码
        /// </summary>
        public string uCode
        {
            set { _ucode = value; }
            get { return _ucode; }
        }
        /// <summary>
        /// 权限
        /// </summary>
        public string uPermissions
        {
            set { _upermissions = value; }
            get { return _upermissions; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime uAppendTime
        {
            set { _uappendtime = value; }
            get { return _uappendtime; }
        }
        /// <summary>
        /// 上回登录时间
        /// </summary>
        public DateTime uUpAppendTime
        {
            set { _uupappendtime = value; }
            get { return _uupappendtime; }
        }
        /// <summary>
        /// 上回登录IP
        /// </summary>
        public string uLastIP
        {
            set { _ulastip = value; }
            get { return _ulastip; }
        }
        /// <summary>
        /// 系统状态
        /// </summary>
        public int uEstate
        {
            set { _uestate = value; }
            get { return _uestate; }
        }
       /// <summary>
       /// 人员类型
       /// </summary>
        public int uType
        {
            set { _uType = value; }
            get { return _uType; }
        }
        public string uTypeName
        {
            set { _uTypeName = value; }
            get { return _uTypeName; }
        }
		public string StorageIDStr
		{
			set { _StorageIDStr = value;}
			get { return _StorageIDStr;}
		}
        #endregion Model
    }
   /// <summary>
   /// 简短的用户信息描述类
   /// </summary>
   public class ShortUserInfo
   {

       private int m_UserID;	//用户uid
       private string m_uName;	//用户名

       private string m_uPWD;	//用户密码

       private string m_uCode;	//校验码

       private DateTime m_uAppendTime;	//创建时间
       private DateTime m_uUpAppendTime;	//最后登录时间
       private DateTime m_uLastActivity;	//最后活动时间

       private int m_olTime;//累积时长

       private int m_uEstate;	//系统状态


       ///<summary>
       ///用户UserID
       ///</summary>
       public int UserID
       {
           get { return m_UserID; }
           set { m_UserID = value; }
       }
       ///<summary>
       ///用户名
       ///</summary>
       public string uName
       {
           get { return m_uName; }
           set { m_uName = value; }
       }
       ///<summary>
       ///用户密码
       ///</summary>
       public string uPWD
       {
           get { return m_uPWD; }
           set { m_uPWD = value; }
       }
       ///<summary>
       ///校验码
       ///</summary>
       public string uCode
       {
           get { return m_uCode; }
           set { m_uCode = value; }
       }
       ///<summary>
       ///创建时间
       ///</summary>
       public DateTime uAppendTime
       {
           get { return m_uAppendTime; }
           set { m_uAppendTime = value; }
       }
       ///<summary>
       ///最后登录时间
       ///</summary>
       public DateTime uUpAppendTime
       {
           get { return m_uUpAppendTime; }
           set { m_uUpAppendTime = value; }
       }
       ///<summary>
       ///最后活动时间
       ///</summary>
       public DateTime uLastActivity
       {
           get { return m_uLastActivity; }
           set { m_uLastActivity = value; }
       }
       ///<summary>
       ///累积时长
       ///</summary>
       public int olTime
       {
           get { return m_olTime; }
           set { m_olTime = value; }
       }
       ///<summary>
       ///系统状态
       ///</summary>
       public int uEstate
       {
           get { return m_uEstate; }
           set { m_uEstate = value; }
       }


   }

   public class UserPassportInfo
   {
       private int _userid;
       private string _erp_name;
       private string _erp_pwd;
       private string _g_name;
       private string _g_pwd;
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
       public string Erp_Name
       {
           set { _erp_name = value; }
           get { return _erp_name; }
       }
       /// <summary>
       /// 
       /// </summary>
       public string Erp_Pwd
       {
           set { _erp_pwd = value; }
           get { return _erp_pwd; }
       }
       /// <summary>
       /// 
       /// </summary>
       public string g_Name
       {
           set { _g_name = value; }
           get { return _g_name; }
       }
       /// <summary>
       /// 
       /// </summary>
       public string g_PWD
       {
           set { _g_pwd = value; }
           get { return _g_pwd; }
       }
   }
}
