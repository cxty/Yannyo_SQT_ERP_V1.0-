using System;
namespace Yannyo.Entity
{
	/// <summary>
	/// 实体类M_StockInfo 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class M_StockInfo
	{
		public M_StockInfo()
		{}
		#region Model
		private int _m_stockinfoid;
		private int _m_configinfoid;
		private int _productsid;
		private int _m_num;
		private DateTime _m_updatetime;
        private int _StorageID;
        private string _StorageName;
		/// <summary>
		/// 商品库存信息编号
		/// </summary>
		public int m_StockInfoID
		{
			set{ _m_stockinfoid=value;}
			get{return _m_stockinfoid;}
		}
        /// <summary>
        /// 所属仓库编号
        /// </summary>
        public int StorageID
        {
            set { _StorageID = value; }
            get { return _StorageID; }
        }
		/// <summary>
		/// 所属配置信息编号
		/// </summary>
		public int m_ConfigInfoID
		{
			set{ _m_configinfoid=value;}
			get{return _m_configinfoid;}
		}
		/// <summary>
		/// 所属商品信息编号
		/// </summary>
		public int ProductsID
		{
			set{ _productsid=value;}
			get{return _productsid;}
		}
		/// <summary>
		/// 数量
		/// </summary>
		public int m_Num
		{
			set{ _m_num=value;}
			get{return _m_num;}
		}
		/// <summary>
		/// 更新时间
		/// </summary>
		public DateTime m_UpdateTime
		{
			set{ _m_updatetime=value;}
			get{return _m_updatetime;}
		}
        /// <summary>
		/// 仓库名称
		/// </summary>
        public string StorageName
		{
            set { _StorageName = value; }
            get { return _StorageName; }
		}
        
		#endregion Model

	}
}

