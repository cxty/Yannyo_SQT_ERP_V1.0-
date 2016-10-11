using System;
using System.Text;

namespace Yannyo.Data
{
    public class DbException : Yannyo.Common.HTTP_Exception
    {
        public DbException(string message)
            : base(message)
        {
        }

        public int Number
        {
            get { return 0 ; }
        }

       
    }
}
