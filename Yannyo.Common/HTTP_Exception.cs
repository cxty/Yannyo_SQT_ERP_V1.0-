using System;

namespace Yannyo.Common
{
	/// <summary>
	/// �Զ����쳣�ࡣ
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
