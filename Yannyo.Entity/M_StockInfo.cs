using System;
namespace Yannyo.Entity
{
	/// <summary>
	/// ʵ����M_StockInfo ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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
		/// ��Ʒ�����Ϣ���
		/// </summary>
		public int m_StockInfoID
		{
			set{ _m_stockinfoid=value;}
			get{return _m_stockinfoid;}
		}
        /// <summary>
        /// �����ֿ���
        /// </summary>
        public int StorageID
        {
            set { _StorageID = value; }
            get { return _StorageID; }
        }
		/// <summary>
		/// ����������Ϣ���
		/// </summary>
		public int m_ConfigInfoID
		{
			set{ _m_configinfoid=value;}
			get{return _m_configinfoid;}
		}
		/// <summary>
		/// ������Ʒ��Ϣ���
		/// </summary>
		public int ProductsID
		{
			set{ _productsid=value;}
			get{return _productsid;}
		}
		/// <summary>
		/// ����
		/// </summary>
		public int m_Num
		{
			set{ _m_num=value;}
			get{return _m_num;}
		}
		/// <summary>
		/// ����ʱ��
		/// </summary>
		public DateTime m_UpdateTime
		{
			set{ _m_updatetime=value;}
			get{return _m_updatetime;}
		}
        /// <summary>
		/// �ֿ�����
		/// </summary>
        public string StorageName
		{
            set { _StorageName = value; }
            get { return _StorageName; }
		}
        
		#endregion Model

	}
}

