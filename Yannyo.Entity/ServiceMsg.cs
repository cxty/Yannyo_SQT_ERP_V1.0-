using System;
using System.Data;

namespace Yannyo.Entity
{
	public class ServiceMsg
	{
		private string _reCode;
		private bool _reState;
		private string _reMsg;
		private DataTable _reObj;

		public string reCode
		{
			set{ _reCode = value; }
			get{ return _reCode; }
		}

		public bool reState
		{
			set{ _reState = value; }
			get{ return _reState; }
		}

		public string reMsg
		{
			set{ _reMsg = value; }
			get{ return _reMsg; }
		}

		public DataTable reObj
		{
			set{ _reObj = value; }
			get{ return _reObj; }
		}
	}
}

