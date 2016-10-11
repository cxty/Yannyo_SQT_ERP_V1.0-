using System;

namespace Yannyo.Common
{
	/// <summary>
	/// 自定义异常类。
	/// </summary>
	public class HTTP_Exception : Exception
	{
		public HTTP_Exception()
		{
			//
		}


        public HTTP_Exception(string msg)
            : base(msg)
		{
			//
		}
	}
}
