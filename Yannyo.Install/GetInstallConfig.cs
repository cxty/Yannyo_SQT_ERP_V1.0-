using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yannyo.Install
{
    public class GetInstallConfig : System.Web.UI.Page
    {
        public string GetSeverInfo(string info)
        {
            //获取服务器的ip
            if (info.ToLower().IndexOf("ip") > -1)
            {
                return Request.ServerVariables["LOCAl_ADDR"];
            }
            //获取服务器域名
            if (info.ToLower().IndexOf("domain") > -1)
            {
                return Request.ServerVariables["SERVER_NAME"].ToString();
            }
            //获取服务器端口
            if (info.ToLower().IndexOf("port") > -1)
            {
                return Request.ServerVariables["Server_Port"].ToString();
            }
            //获取服务器操作系统
            if (info.ToLower().IndexOf("operat") > -1)
            {
                return Environment.OSVersion.ToString();
            }
            //获取当前服务器cpu虚拟内存
            if (info.ToLower().IndexOf("memory") > -1)
            {
                return (Environment.WorkingSet / 1024).ToString() + "M";
            }
            //获取服务器当前占有内存
            if (info.ToLower().IndexOf("cpumemory") > -1)
            {
                return ((Double)GC.GetTotalMemory(false) / 1048576).ToString("N2") + "M";
            }
            return "";
        }
    }
}
