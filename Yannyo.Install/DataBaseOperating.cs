using System;
using System.IO;
using System.Data.SqlClient;
using Yannyo.Config;
using Yannyo.Common;
using Yannyo.Public;
using Yannyo.Data;
using System.Configuration;
using System.Data;
using System.Collections;
using System.Text;

namespace Yannyo.Install
{
    public class DataBaseOperating
    {
        /// <summary>
        /// 数据库信息写入Yannyo.config文件
        /// </summary>
        /// <param name="dataSource">数据库地址</param>
        /// <param name="userID">数据库账号</param>
        /// <param name="password">数据库账号密码</param>
        /// <param name="databaseName">数据库名</param>
        /// <param name="tablePrefix">表前缀</param>
        /*
        protected void EditYannyoConfig(string dataSource, string userID, string password, string databaseName, string tablePrefix)
        {
            
            BaseConfigInfo baseConfig = BaseConfigs.GetBaseConfig();
            string connectionString = string.Format(@"Data Source={0};User ID={1};Password={2};Initial Catalog={3};Pooling=true",
                                             dataSource, userID, password, databaseName);
            baseConfig.Dbconnectstring = connectionString;
            baseConfig.Tableprefix = tablePrefix;
            baseConfig.Dbtype = "SqlServer";
            string dntPath = Utils.GetMapPath("~/Yannyo.config");
            if (!Utils.FileExists(dntPath))
            {
                dntPath = Utils.GetMapPath("/Yannyo.config");
            }
            SerializationHelper.Save(baseConfig, dntPath);
            DbHelper.ConnectionString = baseConfig.Dbconnectstring;
            BaseConfigs.ResetRealConfig();
        }*/
        /// <summary>
        /// 获得客户端用户配置信息写入config
        /// </summary>
        /// <param name="databaseAddress">数据库地址</param>
        /// <param name="databaseName">数据库名称</param>
        /// <param name="account">账户</param>
        /// <param name="pwd">密码</param>
        /// <returns>返回是否操作成功</returns>
        public bool getClientConfigDetails(string databaseAddress, string databaseName, string account, string pwd, string tablePrefix)
        {
            bool reuBool = true;
            string dntPath =Yannyo.Common.Utils.GetMapPath("~/Yannyo.config");
            if (!Yannyo.Common.Utils.FileExists(dntPath))
            {
                dntPath = Yannyo.Common.Utils.GetMapPath("/Yannyo.config");
            }
            if (File.Exists(dntPath.ToString()))
            {
                //将config文件备份
                SetDirPermission.CopyDir(Yannyo.Common.Utils.GetMapPath("/"), Yannyo.Common.Utils.GetMapPath("/install/saveConfig"));
                FileStream fs = new FileStream(dntPath.ToString(), FileMode.Open, FileAccess.ReadWrite);
                StreamWriter sw = new StreamWriter(fs);
                fs.SetLength(0);//清空配置
                string str = "<?xml version=\"1.0\"?>" +
                              "<BaseConfigInfo xmlns:xsd='http://www.w3.org/2001/XMLSchema' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance'>" +
                              "<Dbconnectstring>Data Source=" + databaseAddress + ";User ID=" + account + ";Password=" + pwd + ";Initial Catalog=" + databaseName + ";Pooling=true;Connect Timeout=1000;</Dbconnectstring>" +
                              "<Tableprefix>" + tablePrefix + "</Tableprefix>" +
                              "<Syspath>/</Syspath>" +
                              "<Dbtype>SqlServer</Dbtype>" +
                              "<Founderuid>1</Founderuid>" +
                              "</BaseConfigInfo>";
                //将客户端用户配置信息写入config
                try
                {
                    sw.Write(str);
                }
                catch
                {
                    reuBool = false;
                    //覆盖回文件
                    SetDirPermission.CopyDir(Yannyo.Common.Utils.GetMapPath("/install/saveConfig"), Yannyo.Common.Utils.GetMapPath("/"));
                }
                finally
                {
                    sw.Close();
                }
            }
            return reuBool;
        }
        /// <summary>
        /// 测试数据库是否连接正常
        /// </summary>
        /// <param name="adressName">数据库地址</param>
        /// <param name="accountName">账户</param>
        /// <param name="pwd">密码</param>
        /// <returns></returns>
        public bool CheckDataBaseConnetion(string adressName, string accountName, string pwd,string database)
        {
             SqlConnection mySqlConnection=new SqlConnection();  
             bool IsCanConnectioned = false;
             //从配置文件中读取数据库联接字符串
             //ConnectionString = BaseConfigs.GetBaseConfig().Dbconnectstring;
             mySqlConnection.ConnectionString = string.Format(@"Data Source={0};User ID={1};Password={2};Initial Catalog={3};Pooling=true",
                                                  adressName, accountName, pwd, database);
             //创建连接对象
             mySqlConnection = new SqlConnection(mySqlConnection.ConnectionString);
             try
             {
                 //打开数据库
                 mySqlConnection.Open();
                 IsCanConnectioned = true;
             }
             catch
             {
                 //打开不成功 则连接不成功
                 IsCanConnectioned = false;
             }
             finally
             {
                 //关闭数据库连接
                 mySqlConnection.Close();
             }
             if (mySqlConnection.State == ConnectionState.Closed || mySqlConnection.State == ConnectionState.Broken)
             {
                 return IsCanConnectioned;
             }
             else
             {
                 return IsCanConnectioned;
             }
        }
        public int ExecuteSql(string adressName, string accountName, string pwd, string database, string DatabaseName, string varFileName)
        {
            int reCount = 0;
            string commandText = "";
            string varLine = "";
            //判断是否为文件
            if (!File.Exists(varFileName))
            {
                reCount= 0;
            }
            else
            {
                //读取每行
                StreamReader sr = File.OpenText(varFileName);

                //将文本文件进行重组
                ArrayList rList = new ArrayList();
                while (sr.Peek() > -1)
                {
                    varLine = sr.ReadLine();
                    if (varLine == "")
                    {
                        continue;
                    }
                    if (varLine == "GO")
                    {
                        rList.Add(commandText);
                        commandText = "";
                    }
                    else
                    {
                        commandText += varLine + "\r\n";
                    }
                }

                //连接字符串
                string connStr = string.Format(@"Data Source={0};User ID={1};Password={2};Initial Catalog={3};Pooling=true",
                                                      adressName, accountName, pwd, database);
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    SqlTransaction varTrans = conn.BeginTransaction();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.Transaction = varTrans;
                    //conn.ChangeDatabase(DatabaseName);
                    try
                    {
                        foreach (string varcommand in rList)
                        {
                            cmd.CommandText = varcommand;
                            cmd.ExecuteNonQuery();
                            reCount++;
                        }
                        varTrans.Commit();
                    }
                    catch
                    {
                        varTrans.Rollback();
                        return 0;
                    }
                    finally
                    {
                        conn.Close();
                    }

                }
            }
            return reCount;
        }

    }
}

