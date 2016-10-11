using System;

namespace Yannyo.Entity
{
    /// <summary>
    /// 在线用户信息描述类
    /// </summary>
    public class OnlineUserInfo
    {
        private int m_olID;	//唯一ID
        private int m_UserID;	//用户ID
        private string m_oIP;	//IP
        private string m_oUserName;	//用户名
        private int m_UserSPID;	//接入SP编号
        private int m_UserGroupsID;        //用户组
        private DateTime m_oAppendTime;	//创建时间
        private DateTime m_oLastTime;		//最后更新时间
        
        ///<summary>
        ///唯一ID
        ///</summary>
        public int olID
        {
            get { return m_olID; }
            set { m_olID = value; }
        }
        ///<summary>
        ///用户ID
        ///</summary>
        public int UserID
        {
            get { return m_UserID; }
            set { m_UserID = value; }
        }
        ///<summary>
        ///IP
        ///</summary>
        public string oIP
        {
            get { return m_oIP; }
            set { m_oIP = value; }
        }
        ///<summary>
        ///用户名
        ///</summary>
        public string oUserName
        {
            get { return m_oUserName; }
            set { m_oUserName = value; }
        }
        ///<summary>
        ///接入SP编号
        ///</summary>
        public int UserSPID
        {
            get { return m_UserSPID; }
            set { m_UserSPID = value; }
        }
        ///<summary>
        ///用户组
        ///</summary>
        public int UserGroupsID
        {
            get { return m_UserGroupsID; }
            set { m_UserGroupsID = value; }
        }
        ///<summary>
        ///创建时间
        ///</summary>
        public DateTime oAppendTime
        {
            get { return m_oAppendTime; }
            set { m_oAppendTime = value; }
        }
        ///<summary>
        ///最后更新时间
        ///</summary>
        public DateTime oLastTime
        {
            get { return m_oLastTime; }
            set { m_oLastTime = value; }
        }
    }
}
