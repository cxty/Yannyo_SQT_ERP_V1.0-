using System;
using System.Data;
using System.Data.Common;
using System.Text.RegularExpressions;

using Yannyo.Common;

namespace Yannyo.Config
{
    public class OpenIDConfigs
    {
        private static object lockHelper = new object();

        private static System.Timers.Timer generalConfigTimer = new System.Timers.Timer(15000);

        private static OpenIDConfigInfo m_configinfo;

        /// <summary>
        /// 静态构造函数初始化相应实例和定时器
        /// </summary>
        static OpenIDConfigs()
        {
            m_configinfo = OpenIDConfigFileManager.LoadConfig();

            generalConfigTimer.AutoReset = true;
            generalConfigTimer.Enabled = true;
            generalConfigTimer.Elapsed += new System.Timers.ElapsedEventHandler(Timer_Elapsed);
            generalConfigTimer.Start();
        }
        private static void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            ResetConfig();
        }
        /// <summary>
        /// 重设配置类实例
        /// </summary>
        public static void ResetConfig()
        {
            m_configinfo = OpenIDConfigFileManager.LoadConfig();
        }

        public static OpenIDConfigInfo GetConfig()
        {
            return m_configinfo;
        }

        
        #region Helper

        /// <summary>
        /// 序列化配置信息为XML
        /// </summary>
        /// <param name="configinfo">配置信息</param>
        /// <param name="configFilePath">配置文件完整路径</param>
        public static OpenIDConfigInfo Serialiaze(OpenIDConfigInfo configinfo, string configFilePath)
        {
            lock (lockHelper)
            {
                SerializationHelper.Save(configinfo, configFilePath);
            }
            return configinfo;
        }


        public static OpenIDConfigInfo Deserialize(string configFilePath)
        {
            return (OpenIDConfigInfo)SerializationHelper.Load(typeof(OpenIDConfigInfo), configFilePath);
        }

        #endregion
    }
}
