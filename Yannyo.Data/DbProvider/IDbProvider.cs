using System;
using System.Data;
using System.Data.Common;

namespace Yannyo.Data
{
    public interface IDbProvider
    {
        /// <summary>
        /// ����DbProviderFactoryʵ��
        /// </summary>
        /// <returns></returns>
#if NET1        
		IDbProviderFactory Instance();
#else
        DbProviderFactory Instance();
#endif

        /// <summary>
        /// ����SQL������Ϣ�����
        /// </summary>
        /// <param name="cmd"></param>
        void DeriveParameters(IDbCommand cmd);

        /// <summary>
        /// ����SQL����
        /// </summary>
        /// <param name="ParamName"></param>
        /// <param name="DbType"></param>
        /// <param name="Size"></param>
        /// <returns></returns>
#if NET1  
		IDataParameter MakeParam(string ParamName, DbType DbType, Int32 Size);
#else
        DbParameter MakeParam(string ParamName, DbType DbType, Int32 Size);
#endif

        /// <summary>
        /// �Ƿ�֧��ȫ������
        /// </summary>
        /// <returns></returns>
        bool IsFullTextSearchEnabled();

        /// <summary>
        /// �Ƿ�֧��ѹ�����ݿ�
        /// </summary>
        /// <returns></returns>
        bool IsCompactDatabase();

        /// <summary>
        /// �Ƿ�֧�ֱ������ݿ�
        /// </summary>
        /// <returns></returns>
        bool IsBackupDatabase();

        /// <summary>
        /// ���ظղ����¼������IDֵ, �粻֧����Ϊ""
        /// </summary>
        /// <returns></returns>
        string GetLastIdSql();
        /// <summary>
        /// �Ƿ�֧�����ݿ��Ż�
        /// </summary>
        /// <returns></returns>
        bool IsDbOptimize();
        /// <summary>
        /// �Ƿ�֧�����ݿ�����
        /// </summary>
        /// <returns></returns>
        bool IsShrinkData();
        /// <summary>
        /// �Ƿ�֧�ִ洢����
        /// </summary>
        /// <returns></returns>
        bool IsStoreProc();
    }
}
