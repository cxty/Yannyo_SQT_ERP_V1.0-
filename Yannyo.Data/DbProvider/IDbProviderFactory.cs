#if NET1

using System;
using System.Data;

using System.Text;

namespace Yannyo.Data
{
    public interface IDbProviderFactory
    {
        IDbConnection CreateConnection();
        IDbCommand CreateCommand();
        IDbDataAdapter CreateDataAdapter();
       // void Dispose(bool disposing);
    }
}

#endif