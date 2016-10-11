using System;

namespace Yannyo.Entity
{
   public  class EventLogInfo
    {
        private int _eventlogid;
        private int _userid;
        private string _emsg;
        private DateTime _eappendtime = DateTime.Now;
        private string _username;
        /// <summary>
        /// 
        /// </summary>
        public int EventLogID
        {
            set { _eventlogid = value; }
            get { return _eventlogid; }
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
        public string eMSG
        {
            set { _emsg = value; }
            get { return _emsg; }
        }
        public string UserName
        {
            set { _username = value; }
            get { return _username; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime eAppendTime
        {
            set { _eappendtime = value; }
            get { return _eappendtime; }
        }
    }
}
