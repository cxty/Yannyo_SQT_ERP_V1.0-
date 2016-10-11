using System;

namespace Yannyo.Entity
{
    public class YHsysInfo
    {
        public YHsysInfo()
		{}
		#region Model
		private int _yhsysid;
		private string _yname;
		private DateTime _yappendtime;
		/// <summary>
		/// 
		/// </summary>
		public int YHsysID
		{
			set{ _yhsysid=value;}
			get{return _yhsysid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string yName
		{
			set{ _yname=value;}
			get{return _yname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime yAppendTime
		{
			set{ _yappendtime=value;}
			get{return _yappendtime;}
		}
		#endregion Model
    }
}
