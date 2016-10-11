using System;

namespace Yannyo.Entity
{
    public class GiftsInfo
    {
        public GiftsInfo()
        { }
        #region Model
        private int _giftsid;
        private int _productsid;
        private int _storesid;
        private int _gnum;
        private DateTime _gdatetime;
        private DateTime _gappendtime;
        private string _ProductsName;
        private string _StoresName;
        /// <summary>
        /// 赠品编号
        /// </summary>
        public int GiftsID
        {
            set { _giftsid = value; }
            get { return _giftsid; }
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
        /// 门店编号
        /// </summary>
        public int StoresID
        {
            set { _storesid = value; }
            get { return _storesid; }
        }
        /// <summary>
        /// 赠品数量
        /// </summary>
        public int gNum
        {
            set { _gnum = value; }
            get { return _gnum; }
        }
        /// <summary>
        /// 发生时间
        /// </summary>
        public DateTime gDateTime
        {
            set { _gdatetime = value; }
            get { return _gdatetime; }
        }
        /// <summary>
        /// 系统创建时间
        /// </summary>
        public DateTime gAppendTime
        {
            set { _gappendtime = value; }
            get { return _gappendtime; }
        }
        /// <summary>
        /// 门店
        /// </summary>
        public string StoresName
        {
            set { _StoresName = value; }
            get { return _StoresName; }
        }
        /// <summary>
        /// 产品
        /// </summary>
        public string ProductsName
        {
            set { _ProductsName = value; }
            get { return _ProductsName; }
        }
        #endregion Model
    }
}
