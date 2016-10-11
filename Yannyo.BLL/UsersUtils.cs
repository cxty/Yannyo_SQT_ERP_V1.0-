using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

using Yannyo.Config;
using Yannyo.Entity;
using Yannyo.Common;
using Yannyo.Data;
using System.Data;
using System.Collections;
using System.Xml;
using Yannyo.SOAP;
using System.Collections.Generic;

namespace Yannyo.BLL
{
    /// <summary>
    /// 系统工具类
    /// </summary>
    public class UsersUtils
    {
        /// <summary>
        /// 获取指定数据表,指定条件数据集合
        /// </summary>
        /// <param name="TableName">表名</param>
        /// <param name="OutName">输出字段名</param>
        /// <param name="InName">输入字段名</param>
        public static string GetDataFieldStr(string TableName, string OutName, string InName, int InValue, string WhereStr)
        {
            return DatabaseProvider.GetInstance().GetDataFieldStr(TableName, OutName, InName, InValue, WhereStr);
        }
        /// <summary>
        /// 获取指定数据表,指定条件数据集合
        /// </summary>
        /// <param name="TableName">表名</param>
        /// <param name="OutName">输出字段名</param>
        /// <param name="InName">输入字段名</param>
        public static string GetDataFieldStr(string TableName, string OutName,string OutIDName, string InName, int InValue, string WhereStr)
        {
            return DatabaseProvider.GetInstance().GetDataFieldStr(TableName, OutName,OutIDName, InName, InValue, WhereStr);
        }
        /// <summary>
        /// 返回用户密码cookie明文
        /// </summary>
        /// <param name="key">密钥</param>
        /// <returns></returns>
        public static string GetCookiePassword(string key)
        {
            return DES.Decode(GetCookie("password"), key).Trim();
        }

        /// <summary>
        /// 返回用户密码cookie明文
        /// </summary>
        /// <param name="password">密码密文</param>
        /// <param name="key">密钥</param>
        /// <returns></returns>
        public static string GetCookiePassword(string password, string key)
        {
            return DES.Decode(password, key);
        }

        /// <summary>
        /// 返回密码密文
        /// </summary>
        /// <param name="password">密码明文</param>
        /// <param name="key">密钥</param>
        /// <returns></returns>
        public static string SetCookiePassword(string password, string key)
        {
            return DES.Encode(password, key);
        }
        
        #region Cookies

        /// <summary>
        /// 写cookie值
        /// </summary>
        /// <param name="strName">项</param>
        /// <param name="strValue">值</param>
        public static void WriteCookie(string strName, string strValue)
        {
            string cookietag = GeneralConfigs.GetConfig().CookieTag.Trim();
            HttpCookie cookie = HttpContext.Current.Request.Cookies[cookietag];
            if (cookie == null)
            {
                cookie = new HttpCookie(cookietag);
                cookie.Values[strName] = Utils.UrlEncode(strValue);
            }
            else
            {

                cookie.Values[strName] = Utils.UrlEncode(strValue);
                if (HttpContext.Current.Request.Cookies[cookietag]["expires"] != null)
                {
                    int expires = Utils.StrToInt(HttpContext.Current.Request.Cookies[cookietag]["expires"].ToString(), 0);
                    if (expires > 0)
                    {
                        cookie.Expires = DateTime.Now.AddMinutes(Utils.StrToInt(HttpContext.Current.Request.Cookies[cookietag]["expires"].ToString(), 0));
                    }
                }
            }

            string cookieDomain = GeneralConfigs.GetConfig().CookieDomain.Trim();
            if (cookieDomain != string.Empty && HttpContext.Current.Request.Url.Host.IndexOf(cookieDomain) > -1 && IsValidDomain(HttpContext.Current.Request.Url.Host))
                cookie.Domain = cookieDomain;

            HttpContext.Current.Response.AppendCookie(cookie);

        }


        /// <summary>
        /// 写cookie值
        /// </summary>
        /// <param name="strName">名称</param>
        /// <param name="intValue">值</param>
        public static void WriteCookie(string strName, int intValue)
        {
            WriteCookie(strName, intValue.ToString());
        }



        /// <summary>
        /// 写登录用户的cookie
        /// </summary>
        /// <param name="uid">用户Id</param>
        /// <param name="expires">cookie有效期</param>
        /// <param name="passwordkey">用户密码Key</param>
        /// <param name="invisible">用户当前的登录模式(正常或隐身)</param>
        public static void WriteUserCookie(int uid, int expires, string passwordkey, int invisible)
        {
            UserInfo userinfo = BLL.tbUserInfo.GetUserInfoModel(uid);
            WriteUserCookie(userinfo, expires, passwordkey, invisible);
        }

        /// <summary>
        /// 写登录用户的cookie
        /// </summary>
        /// <param name="userinfo">用户信息</param>
        /// <param name="expires">cookie有效期</param>
        /// <param name="passwordkey">用户密码Key</param>
        /// <param name="invisible">用户当前的登录模式(正常或隐身)</param>
        public static void WriteUserCookie(UserInfo userinfo, int expires, string passwordkey, int invisible)
        {
            string cookietag = GeneralConfigs.GetConfig().CookieTag.Trim();
            if (userinfo == null)
            {
                return;
            }
            HttpCookie cookie = new HttpCookie(cookietag);
            cookie.Values["userid"] = userinfo.UserID.ToString();
            cookie.Values["password"] = Utils.UrlEncode(SetCookiePassword(userinfo.uPWD, passwordkey));

            cookie.Values["referer"] = "default.aspx";
            cookie.Values["expires"] = expires.ToString();
            if (expires > 0)
            {
                cookie.Expires = DateTime.Now.AddMinutes(expires);
            }
            string cookieDomain = GeneralConfigs.GetConfig().CookieDomain.Trim();
            if (cookieDomain != string.Empty && HttpContext.Current.Request.Url.Host.IndexOf(cookieDomain) > -1 && IsValidDomain(HttpContext.Current.Request.Url.Host))
            {
                cookie.Domain = cookieDomain;
            }

            HttpContext.Current.Response.AppendCookie(cookie);
        }

        /// <summary>
        /// 写登录用户的cookie
        /// </summary>
        /// <param name="uid">用户Id</param>
        /// <param name="expires">cookie有效期</param>
        /// <param name="passwordkey">用户密码Key</param>
        public static void WriteUserCookie(int uid, int expires, string passwordkey)
        {
            WriteUserCookie(uid, expires, passwordkey);
        }

        /// <summary>
        /// 写登录用户的cookie
        /// </summary>
        /// <param name="userinfo">用户信息</param>
        /// <param name="expires">cookie有效期</param>
        /// <param name="passwordkey">用户密码Key</param>
        public static void WriteUserCookie(UserInfo userinfo, int expires, string passwordkey)
        {
            WriteUserCookie(userinfo, expires, passwordkey);
        }

        /// <summary>
        /// 获得cookie值
        /// </summary>
        /// <param name="strName">项</param>
        /// <returns>值</returns>
        public static string GetCookie(string strName)
        {
            string cookietag = GeneralConfigs.GetConfig().CookieTag.Trim();
            if (HttpContext.Current.Request.Cookies != null && HttpContext.Current.Request.Cookies[cookietag] != null && HttpContext.Current.Request.Cookies[cookietag][strName] != null)
            {
                return Utils.UrlDecode(HttpContext.Current.Request.Cookies[cookietag][strName].ToString());
            }

            return "";
        }


        /// <summary>
        /// 清除登录用户的cookie
        /// </summary>
        public static void ClearUserCookie()
        {
            string cookietag = GeneralConfigs.GetConfig().CookieTag.Trim();
            ClearUserCookie(cookietag);
        }

        public static void ClearUserCookie(string cookieName)
        {
            HttpCookie cookie = new HttpCookie(cookieName);
            cookie.Values.Clear();
            cookie.Expires = DateTime.Now.AddYears(-1);
            string cookieDomain = GeneralConfigs.GetConfig().CookieDomain.Trim();
            if (cookieDomain != string.Empty && HttpContext.Current.Request.Url.Host.IndexOf(cookieDomain) > -1 && IsValidDomain(HttpContext.Current.Request.Url.Host))
                cookie.Domain = cookieDomain;
            HttpContext.Current.Response.AppendCookie(cookie);
        }

        #endregion

        /// <summary>
        /// 从cookie中获取转向页
        /// </summary>
        /// <returns>string</returns>
        public static string GetReUrl()
        {
            if (HTTPRequest.GetString("reurl").Trim() != "")
            {
                UsersUtils.WriteCookie("reurl", HTTPRequest.GetString("reurl").Trim());
                return HTTPRequest.GetString("reurl").Trim();
            }
            else
            {
                if (UsersUtils.GetCookie("reurl") == "")
                {
                    return "default.aspx";
                }
                else
                {
                    return UsersUtils.GetCookie("reurl");
                }
            }
        }

        /// <summary>
        /// 是否为有效域
        /// </summary>
        /// <param name="host">域名</param>
        /// <returns></returns>
        public static bool IsValidDomain(string host)
        {
            Regex r = new Regex(@"^\d+$");
            if (host.IndexOf(".") == -1)
            {
                return false;
            }
            return r.IsMatch(host.Replace(".", string.Empty)) ? false : true;
        }


        /// <summary>
        /// 更新路径url串中的扩展名
        /// </summary>
        /// <param name="pathlist">路径url串</param>
        /// <param name="extname">扩展名</param>
        /// <returns>string</returns>
        public static string UpdatePathListExtname(string pathlist, string extname)
        {
            return pathlist.Replace("{extname}", extname);
        }

        /// <summary>
        /// 用户权限为DataTable
        /// </summary>
        public static DataTable GetUserPopedom()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("PopedomName", typeof(string));
            dt.Columns.Add("PopedomID", typeof(string));
            dt.Columns.Add("PopedomImg", typeof(string));

            foreach (User_Popedom.Rewrite Popedom in User_Popedom.GetUserPopedom().Popedoms)
            {
                DataRow dr = dt.NewRow();
                dr["PopedomName"] = Popedom.Name;
                dr["PopedomID"] = Popedom.Id;
                dr["PopedomImg"] = Popedom.Name;

                dt.Rows.Add(dr);
            }
            dt.AcceptChanges();
            return dt;
        }
        /// <summary>
        /// 用户权限为 Json
        /// </summary>
        /// <returns></returns>
        public static string GetUserPopedomToJsonStr()
        {
            string json = "";
            DataTable dt = Caches.GetUserPopedom();
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["PopedomID"].ToString().IndexOf("-") < 0)
                {
                    json = json + "{data:\"" + dr["PopedomName"].ToString() + "\",attr:{id:\"t_" + dr["PopedomID"].ToString() + "\",value:\"" + dr["PopedomID"].ToString() + "\"},children:[" + GetUserPopedomToJsonStr_loop(dt,dr["PopedomID"].ToString()) + "]},";
                }
            }
            return Utils.ReSQLSetTxt(json);
        }
        public static string GetUserPopedomToJsonStr_loop(DataTable dt, string PopedomID)
        {
            string json = "";

            foreach (DataRow dr in dt.Rows)
            {
                if (dr["PopedomID"].ToString().Trim().Length > PopedomID.Trim().Length)
                {
                    if (dr["PopedomID"].ToString().Trim().Split(new char[] { '-' }).Length-1 == PopedomID.Trim().Split(new char[] { '-' }).Length)
                    {
                        if (dr["PopedomID"].ToString().Trim().Substring(0, PopedomID.Trim().Length) == PopedomID.Trim())
                        {
                            json = json + "{data:\"" + dr["PopedomName"].ToString() + "\",attr:{id:\"t_" + dr["PopedomID"].ToString() + "\",value:\"" + dr["PopedomID"].ToString() + "\"},children:[" + GetUserPopedomToJsonStr_loop(dt, dr["PopedomID"].ToString()) + "]},";
                        }
                    }
                }
            }
            return Utils.ReSQLSetTxt(json);
        }

        /// <summary>
        /// 用户权限为 Json
        /// </summary>
        /// <param name="UserPopedomStr"></param>
        /// <returns></returns>
        public static string GetUserPopedomToJsonStr(string UserPopedomStr)
        {
            string json = "";
            string tState = "";
            DataTable dt = Caches.GetUserPopedom();
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["PopedomID"].ToString().IndexOf("-") < 0)
                {
                    tState = "";
                    if (("," + UserPopedomStr + ",").IndexOf("," + dr["PopedomID"].ToString() + ",") > -1)
                    {
                        tState = ",state:\"checked\"";
                    }
                    else {
                        tState = ",state:\"unchecked\"";
                    }
                    json = json + "{data:\"" + dr["PopedomName"].ToString() + "\"" + tState + ",attr:{id:\"t_" + dr["PopedomID"].ToString() + "\",value:\"" + dr["PopedomID"].ToString() + "\"},children:[" + GetUserPopedomToJsonStr_loop(dt, dr["PopedomID"].ToString(), UserPopedomStr) + "]},";
                }
            }
            return Utils.ReSQLSetTxt(json);
        }
        public static string GetUserPopedomToJsonStr_loop(DataTable dt, string PopedomID, string UserPopedomStr)
        {
            string json = "";
            string tState = "";

            foreach (DataRow dr in dt.Rows)
            {
                if (dr["PopedomID"].ToString().Trim().Length > PopedomID.Trim().Length)
                {
                    if (dr["PopedomID"].ToString().Trim().Split(new char[] { '-' }).Length - 1 == PopedomID.Trim().Split(new char[] { '-' }).Length)
                    {
                        if (dr["PopedomID"].ToString().Trim().Substring(0, PopedomID.Trim().Length) == PopedomID.Trim())
                        {
                            tState = "";
                            if (("," + UserPopedomStr + ",").IndexOf("," + dr["PopedomID"].ToString().Trim() + ",") > -1)
                            {
                                tState = ",state:\"checked\"";
                            }
                            else
                            {
                                tState = ",state:\"unchecked\"";
                            }
                            json = json + "{data:\"" + dr["PopedomName"].ToString() + "\"" + tState + ",attr:{id:\"t_" + dr["PopedomID"].ToString() + "\",value:\"" + dr["PopedomID"].ToString() + "\"},children:[" + GetUserPopedomToJsonStr_loop(dt, dr["PopedomID"].ToString(), UserPopedomStr) + "]},";
                        }
                    }
                }
            }
            return Utils.ReSQLSetTxt(json);
        }

        /// <summary>
        /// 取指定权限的所有父权限
        /// </summary>
        /// <param name="PopedomID"></param>
        /// <returns></returns>
        public static string GetUserPopedomByPopedomIDUp(string PopedomID)
        {
            string re = "";
            DataTable dt = Caches.GetUserPopedom();
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["PopedomID"].ToString().Trim().Length < PopedomID.Trim().Length)
                {
                    if (PopedomID.Trim().Substring(0, dr["PopedomID"].ToString().Trim().Length) == dr["PopedomID"].ToString().Trim())
                    {
                        re = re + dr["PopedomID"].ToString().Trim()+",";
                    }
                }
            }
            return re;
        }
        /// <summary>
        /// 用户权限
        /// </summary>
        public class User_Popedom
        {
            private static object lockHelper = new object();
            private static volatile User_Popedom instance = null;
            string Files = HttpContext.Current.Server.MapPath(BaseConfigs.GetSysPath + "config/popedoms.config");
            private System.Collections.ArrayList _Popedoms;
            public System.Collections.ArrayList Popedoms
            {
                get
                {
                    return _Popedoms;
                }
                set
                {
                    _Popedoms = value;
                }
            }
            private User_Popedom()
            {
                Popedoms = new ArrayList();
                XmlDocument xml = new XmlDocument();
                xml.Load(Files);
                try
                {
                    XmlNode root = xml.SelectSingleNode("//Popedoms");
                    foreach (XmlNode n in root.ChildNodes)
                    {
                        if (n.NodeType != XmlNodeType.Comment && n.Name.ToLower() == "bpopedom")
                        {
                            XmlAttribute PopedomName = n.Attributes["name"];
                            XmlAttribute PopedomID = n.Attributes["popedomid"];

                            if (PopedomName != null && PopedomID != null)
                            {
                                Popedoms.Add(new Rewrite(PopedomName.Value, PopedomID.Value, n.InnerText));
                            }
                        }
                    }
                }
                finally
                {
                    xml = null;
                }
            }
            public static User_Popedom GetUserPopedom()
            {
                if (instance == null)
                {
                    lock (lockHelper)
                    {
                        if (instance == null)
                        {
                            instance = new User_Popedom();
                        }
                    }
                }
                return instance;

            }

            public static void SetInstance(User_Popedom anInstance)
            {
                if (anInstance != null)
                    instance = anInstance;
            }

            public static void SetInstance()
            {
                SetInstance(new User_Popedom());
            }
            public class Rewrite
            {
                #region 成员变量
                private string _Name;
                public string Name
                {
                    get
                    {
                        return _Name;
                    }
                    set
                    {
                        _Name = value;
                    }
                }
                private string _Id;
                public string Id
                {
                    get
                    {
                        return _Id;
                    }
                    set
                    {
                        _Id = value;
                    }
                }
                private string _Img;
                public string Img
                {
                    get
                    {
                        return _Img;
                    }
                    set
                    {
                        _Img = value;
                    }
                }
                #endregion
                #region 构造函数
                public Rewrite(string name, string id, string img)
                {
                    _Name = name;
                    _Id = id;
                    _Img = img;
                }
                #endregion
            }
        }

        /// <summary>
        /// 给执行权限的用户发送邮件
        /// </summary>
        /// <param name="PopedomCode">权限代码</param>
        /// <param name="MailSubject">邮件标题</param>
        /// <param name="MailMsg">邮件内容</param>
        public static void SendUserMailByPopedom(string PopedomCode, string MailSubject, string MailMsg)
        {
            string PopedomAllStr = GetUserPopedomByPopedomIDUp(PopedomCode);//取该权限对应的夫以上级别的权限代码
            string Mail = DatabaseProvider.GetInstance().GetUserMailByPopedom(PopedomAllStr);
            if (Mail.Trim() != "")
            {
                GeneralConfigInfo configs = Config.GeneralConfigs.GetConfig();
                string[] MailArray = Utils.SplitString(Mail, ",");
                string SendedStr = ",";
                foreach (string _mail in MailArray)
                {
                    if (_mail.Trim() != "")
                    {
                        if (!(SendedStr.IndexOf("," + _mail.Trim() + ",") > -1))
                        {
                            MailQueueService.SendMail(configs.SendMailUserName, configs.SendMailUserPWD, MailSubject, MailMsg, configs.CompanyName, configs.SendMailUserName, _mail.Trim(), _mail.Trim(), true, DateTime.Now.AddSeconds(10));
                            SendedStr += _mail.Trim() + ",";
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 给指定用户发送邮件
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="MailSubject"></param>
        /// <param name="MailMsg"></param>
        public static void SendMailToUser(int UserID, string MailSubject, string MailMsg)
        {
            string Mail = DatabaseProvider.GetInstance().GetUserEmail(UserID);
            if (Mail.Trim() != "")
            {
                GeneralConfigInfo configs = Config.GeneralConfigs.GetConfig();
                MailQueueService.SendMail(configs.SendMailUserName, configs.SendMailUserPWD, MailSubject, MailMsg, configs.CompanyName, configs.SendMailUserName, Mail, Mail, true, DateTime.Now.AddSeconds(10));
            }
        }

        public static void SendMailToEmail(string Mail, string MailSubject, string MailMsg)
        {
            if (Mail.Trim() != "")
            {
                GeneralConfigInfo configs = Config.GeneralConfigs.GetConfig();
                MailQueueService.SendMail(configs.SendMailUserName, configs.SendMailUserPWD, MailSubject, MailMsg, configs.CompanyName, configs.SendMailUserName, Mail, Mail, true, DateTime.Now.AddSeconds(10));
            }
        }

        public static DataTable GetUserType()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("ID", typeof(string));
            dt.Columns.Add("Popedoms", typeof(string));
            dt.Columns.Add("Img", typeof(string));
            User_Class uc = User_Class.GetUserClass();
            try
            {
                foreach (User_Class.Rewrite _ManagerClass in uc.ManagerClass)
                {
                    DataRow dr = dt.NewRow();
                    dr["Name"] = _ManagerClass.Name;
                    dr["ID"] = _ManagerClass.Classid;
                    dr["Popedoms"] = _ManagerClass.Popedoms;
                    dr["Img"] = _ManagerClass.Img;

                    dt.Rows.Add(dr);
                }
                dt.AcceptChanges();
            }
            finally {
                uc = null;
            }
            return dt;
        }
        /// <summary>
        /// 用户默认分类
        /// </summary>
        public class User_Class
        {
            private static object lockHelper = new object();
            private static volatile User_Class instance = null;
            string Files = HttpContext.Current.Server.MapPath(BaseConfigs.GetSysPath + "config/managerclass.config");
            private System.Collections.ArrayList _ManagerClass;
            public System.Collections.ArrayList ManagerClass
            {
                get
                {
                    return _ManagerClass;
                }
                set
                {
                    _ManagerClass = value;
                }
            }
            private User_Class()
            {
                ManagerClass = new ArrayList();
                XmlDocument xml = new XmlDocument();
                xml.Load(Files);
                try
                {
                    XmlNode root = xml.SelectSingleNode("//ManagerClass");
                    foreach (XmlNode n in root.ChildNodes)
                    {
                        if (n.NodeType != XmlNodeType.Comment && n.Name.ToLower() == "manager")
                        {
                            XmlAttribute ClassName = n.Attributes["name"];
                            XmlAttribute ClassID = n.Attributes["Classid"];
                            XmlAttribute Popedoms = n.Attributes["Popedoms"];

                            if (ClassName != null && ClassID != null)
                            {
                                ManagerClass.Add(new Rewrite(ClassName.Value, ClassID.Value,Popedoms.Value, n.InnerText));
                            }
                        }
                    }
                }
                finally
                {
                    xml = null;
                }
            }
            public static User_Class GetUserClass()
            {
                //if (instance == null)
                {
               //     lock (lockHelper)
                    {
               //         if (instance == null)
                        {
                            instance = new User_Class();
                        }
                    }
                }
                return instance;
            }

            public static void SetInstance(User_Class anInstance)
            {
                if (anInstance != null)
                    instance = anInstance;
            }

            public static void SetInstance()
            {
                SetInstance(new User_Class());
            }
            public class Rewrite
            {
                #region 成员变量
                private string _Name;
                public string Name
                {
                    get
                    {
                        return _Name;
                    }
                    set
                    {
                        _Name = value;
                    }
                }
                private string _Classid;
                public string Classid
                {
                    get
                    {
                        return _Classid;
                    }
                    set
                    {
                        _Classid = value;
                    }
                }
                private string _Popedoms;
                public string Popedoms
                {
                    get
                    {
                        return _Popedoms;
                    }
                    set
                    {
                        _Popedoms = value;
                    }
                }
                private string _Img;
                public string Img
                {
                    get
                    {
                        return _Img;
                    }
                    set
                    {
                        _Img = value;
                    }
                }
                #endregion
                #region 构造函数
                public Rewrite(string name, string Classid, string Popedoms,string img)
                {
                    _Name = name;
                    _Classid = Classid;
                    _Popedoms = Popedoms;
                    _Img = img;
                }
                #endregion
            }
        }
    }
}
