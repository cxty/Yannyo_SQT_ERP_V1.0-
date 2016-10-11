using System;

namespace Yannyo.Entity
{
    public class CostValenceInfo
    {
		#region Model
		private int _costvelenceid;
		private int _productsid;
		private decimal _cprice;
		private DateTime _cdatetime;
		private DateTime _cappendtime;
        private string _ProductsName;
		/// <summary>
		/// 成本编号
		/// </summary>
		public int CostVelenceID
		{
			set{ _costvelenceid=value;}
			get{return _costvelenceid;}
		}
		/// <summary>
		/// 产品编号
		/// </summary>
		public int ProductsID
		{
			set{ _productsid=value;}
			get{return _productsid;}
		}
		/// <summary>
		/// 成本
		/// </summary>
		public decimal cPrice
		{
			set{ _cprice=value;}
			get{return _cprice;}
		}
		/// <summary>
		/// 发生时间
		/// </summary>
		public DateTime cDateTime
		{
			set{ _cdatetime=value;}
			get{return _cdatetime;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime cAppendTime
		{
			set{ _cappendtime=value;}
			get{return _cappendtime;}
		}
        /// <summary>
        /// 产品名称
        /// </summary>
        public string ProductsName
        {
            set { _ProductsName = value; }
            get { return _ProductsName; }
        }
		#endregion Model
    }
}
