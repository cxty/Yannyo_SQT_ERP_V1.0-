using System;

namespace Yannyo.Entity
{
    public class FeesSubjectInfo
    {
        public FeesSubjectInfo()
		{}
		#region Model
		private int _feessubjectid;
        private int _FeesSubjectClassID;
		private string _fname;
        private string _fCode;
        private int _fDebitCredit;
		private DateTime _fappendtime;

		/// <summary>
		/// 费用科目编号
		/// </summary>
		public int FeesSubjectID
		{
			set{ _feessubjectid=value;}
			get{return _feessubjectid;}
		}
        /// <summary>
        /// 科目分类
        /// </summary>
        public int FeesSubjectClassID
        {
            set { _FeesSubjectClassID = value; }
            get { return _FeesSubjectClassID; }
        }
		/// <summary>
		/// 名称
		/// </summary>
		public string fName
		{
			set{ _fname=value;}
			get{return _fname;}
		}
        /// <summary>
        /// 编码
        /// </summary>
        public string fCode
        {
            set { _fCode = value; }
            get { return _fCode; }
        }
        /// <summary>
        /// 借/贷,借=0,贷=1
        /// </summary>
        public int fDebitCredit
        {
            set { _fDebitCredit = value; }
            get { return _fDebitCredit; }
        }
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime fAppendTime
		{
			set{ _fappendtime=value;}
			get{return _fappendtime;}
		}
        
		#endregion Model
    }
}
