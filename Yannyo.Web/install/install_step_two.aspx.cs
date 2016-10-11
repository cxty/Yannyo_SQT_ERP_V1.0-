using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using Yannyo.Config;
using Yannyo.Common;
using Yannyo.Entity;
using Yannyo.BLL;
using Yannyo.Install;

namespace Yannyo.Web
{
    public partial class Install_StepTwo : Page
    {
        public string getIP = "";       //获得服务器IP
        public string getDomain = "";   //获得服务器域名
        public string getPort = "";     //获得服务器端口
        public string getOperat = "";   //获得服务器操作系统
        public string getMemory = "";   //获得服务器虚拟内存
        public string getCpuMemory = "";//获得服务器当前CPU占有内存

        public string sTjson = "";
        public string Act = "";
        //文件夹权限判断
        public bool _cache = false;
        public bool _config = false;
        public bool _Data = false;
        public bool _ExportData = false;
        public bool _Default = false;
        public bool _ufile = false;
        public bool _install = false;
        //文件权限判断
        public bool _yannyo_config = false;

        public int ErrorNum = 0;
        public int getCache = 0;
        public int getConfig = 0;
        public int getData = 0;
        public int getExportData = 0;
        public int getDefault = 0;
        public int getUfile = 0;
        public int getYannyoConfig = 0;
        public int getInstall = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            Act = HTTPRequest.GetString("act");
            //实例化获得权限
            SetDirPermission permission = new SetDirPermission();

            if (Act.IndexOf("install") > -1)
            {
                //获得服务器相关信息
                getIP = Request.ServerVariables["LOCAl_ADDR"];
                getDomain = Request.ServerVariables["SERVER_NAME"].ToString();
                getPort = Request.ServerVariables["Server_Port"].ToString();
                getOperat = Environment.OSVersion.ToString();
                getMemory = (Environment.WorkingSet / 1024).ToString() + "M";
                getCpuMemory = ((Double)GC.GetTotalMemory(false) / 1048576).ToString("N2") + "M";
                //获得服务器相关文件及文件夹的权限

                _cache = permission.GetFilePermission(Yannyo.Common.Utils.GetMapPath("~/cache"), "1.txt");
                _config = permission.GetFilePermission(Yannyo.Common.Utils.GetMapPath("~/config"), "1.txt");
                _Data = permission.GetFilePermission(Yannyo.Common.Utils.GetMapPath("~/Data"), "1.txt");
                _ExportData = permission.GetFilePermission(Yannyo.Common.Utils.GetMapPath("~/Data/ExportData"), "1.txt");
                _Default = permission.GetFilePermission(Yannyo.Common.Utils.GetMapPath("~/aspx/1"), "1.txt");
                _ufile = permission.GetFilePermission(Yannyo.Common.Utils.GetMapPath("~/ufile"), "1.txt");
                _yannyo_config = permission.GetFilePermission(Yannyo.Common.Utils.GetMapPath("~/Yannyo.config"), "1.txt");
                _install = permission.GetFilePermission(Yannyo.Common.Utils.GetMapPath("~/install"), "1.txt");

                if (!_cache || !_config || !_Data || !_ExportData || !_Default || !_ufile || !_install || !_yannyo_config || getIP == "" || getDomain == "" || getPort == "" || getOperat == "" || getMemory == "" || getCpuMemory == "")
                {
                    ErrorNum++;
                }
                if (_cache)
                {
                    getCache++;
                }
                if (_config)
                {
                    getConfig++;
                }
                if (_Data)
                {
                    getData++;
                }
                if (_ExportData)
                {
                    getExportData++;
                }
                if (_Default)
                {
                    getDefault++;
                }
                if (_ufile)
                {
                    getUfile++;
                }
                if (_install)
                {
                    getInstall++;
                }
                if (_yannyo_config)
                {
                    getYannyoConfig++;
                }


                string pJson = "details:{'ErrorNum':" + ErrorNum + ",'cache':" + getCache + ",'config':" + getConfig + ",'data':" + getData + ",'exportdata':" + getExportData + ",'de':" + getDefault + ",'ufile':" + getUfile + ",'install':" + getInstall + ",'yannyoconfig':" + getYannyoConfig + ",'getIP':'" + getIP + "','getDomain':'" + getDomain + "','getPort':'" + getPort + "','getOperat':'" + getOperat + "','getMemory':'" + getMemory + "','getCpuMemory':'" + getCpuMemory + "'}";
                Response.Charset = "utf-8";
                Response.ContentEncoding = System.Text.Encoding.GetEncoding("utf-8");
                //Response.ContentType = "application/json";
                Response.Clear();
                Response.Write("{" + pJson + "}"); //系统检测不通过
                Response.End();

            }
        }
    }
}