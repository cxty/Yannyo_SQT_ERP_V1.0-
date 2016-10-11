using System;

namespace Yannyo.Entity
{
  public  class StorageInfo
    {
        private int _storageid;
        private string _scode;
        private string _sname;
        private int _smanager;
        private string _smanagername;
        private string _stel;
        private string _saddress;
        private string _sremake;
        private DateTime _sappendtime;
        private int _StorageClassID;
        private string _storageName;
        private int _sState;
        
      /// <summary>
      /// 仓库分类名称
      /// </summary>
        public string StorageName
        {
            get { return _storageName; }
            set { _storageName = value; }
        }


        /// <summary>
        /// 仓库分类编号
        /// </summary>
        public int StorageClassID
        {
            get { return _StorageClassID; }
            set { _StorageClassID = value; }
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
        public string sCode
        {
            set { _scode = value; }
            get { return _scode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string sName
        {
            set { _sname = value; }
            get { return _sname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int sManager
        {
            set { _smanager = value; }
            get { return _smanager; }
        }
        public string ManagerName
        {
            set { _smanagername = value; }
            get { return _smanagername; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string sTel
        {
            set { _stel = value; }
            get { return _stel; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string sAddress
        {
            set { _saddress = value; }
            get { return _saddress; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string sRemake
        {
            set { _sremake = value; }
            get { return _sremake; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime sAppendTime
        {
            set { _sappendtime = value; }
            get { return _sappendtime; }
        }
        /// <summary>
        /// 状态，0正常，1屏蔽
        /// </summary>
        public int sState
        {
            set { _sState = value; }
            get { return _sState; }
        }
    }
}
