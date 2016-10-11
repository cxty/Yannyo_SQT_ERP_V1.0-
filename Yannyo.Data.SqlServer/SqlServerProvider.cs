using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
//using Yannyo.Data;

namespace Yannyo.Data
{


#if NET1

    public class SqlServerProvider : IDbProvider
    {
        public IDbProviderFactory Instance()
        {
            return SqlClientFactory.Instance;
        }

        public void DeriveParameters(IDbCommand cmd)
        {
            if ((cmd as SqlCommand) != null)
            {
                SqlCommandBuilder.DeriveParameters(cmd as SqlCommand);
            }
        }

        public IDataParameter MakeParam(string ParamName, DbType DbType, Int32 Size)
        {
            SqlParameter param;

            if (Size > 0)
                param = new SqlParameter(ParamName, (SqlDbType)DbType, Size);
            else
                param = new SqlParameter(ParamName, (SqlDbType)DbType);

            return param;
        }

		public bool IsFullTextSearchEnabled()
		{
			return true;
		}

		public bool IsCompactDatabase()
		{
			return true;
		}

		public bool IsBackupDatabase()
		{
			return true;
		}

		public string GetLastIdSql()
		{
			return "SELECT SCOPE_IDENTITY()";
		}
		public bool IsDbOptimize()
		{

			return false;
		}
		public bool IsShrinkData()
		{


			return true;
		}

		public bool IsStoreProc()
		{

			return true;
		}

    }

    public class SqlClientFactory : IDbProviderFactory
    {
        public static readonly SqlClientFactory Instance;

        static SqlClientFactory()
        {
            Instance = new SqlClientFactory();
        }

        private SqlClientFactory()
        {
        }


        public IDbConnection CreateConnection()
        {
            return new SqlConnection();
        }

        
        public IDbCommand CreateCommand()
        {
            return new SqlCommand();
        }

        public IDbDataAdapter CreateDataAdapter()
        {
            return new SqlDataAdapter();
        }

        //public void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        GC.SuppressFinalize(this);
        //    }
        //}

     
 

    }
#else

    public class SqlServerProvider : IDbProvider
    {
        public DbProviderFactory Instance()
        {
            return SqlClientFactory.Instance;
        }

        public void DeriveParameters(IDbCommand cmd)
        {
            if ((cmd as SqlCommand) != null)
            {
                SqlCommandBuilder.DeriveParameters(cmd as SqlCommand);
            }
        }

        public DbParameter MakeParam(string ParamName, DbType DbType, Int32 Size)
        {
            SqlParameter param;

            if (Size > 0)
                param = new SqlParameter(ParamName, (SqlDbType)DbType, Size);
            else
                param = new SqlParameter(ParamName, (SqlDbType)DbType);

            return param;
        }

        public bool IsFullTextSearchEnabled()
        {
            return true;
        }

        public bool IsCompactDatabase()
        {
            return true;
        }

        public bool IsBackupDatabase()
        {
            return true;
        }

        public string GetLastIdSql()
        {
            return "SELECT SCOPE_IDENTITY()";
        }
        public bool IsDbOptimize()
        {
            return false;
        }
        public bool IsShrinkData()
        {
            return true;
        }

        public bool IsStoreProc()
        {
            return true;
        }
    }

#endif

}
