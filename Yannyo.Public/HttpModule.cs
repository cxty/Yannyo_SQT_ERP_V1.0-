using System;
using System.Diagnostics;
using System.Threading;
using System.Web;
using System.Xml;
using System.Text.RegularExpressions;
using System.IO;
using System.Web.SessionState;

using Yannyo.Common;
using Yannyo.Data;
using Yannyo.Config;
using Yannyo.Config.Provider;
using Yannyo.Public.ScheduledEvents;
using Yannyo.BLL;

namespace Yannyo.Public
{
    /// <summary>
    /// HttpModule类
    /// </summary>
    public class HttpModule : System.Web.IHttpModule
    {
        static Timer eventTimer;
        /// <summary>
        /// 实现接口的Init方法
        /// </summary>
        /// <param name="context"></param>
        public void Init(HttpApplication context)
        {
            OnlineUsers.ResetOnlineList();
            context.BeginRequest += new EventHandler(ReUrl_BeginRequest);
            context.AcquireRequestState += new EventHandler(context_AcquireRequestState);
            context.PreRequestHandlerExecute += new EventHandler(context_PreRequestHandlerExecute);

            if (eventTimer == null && ScheduleConfigs.GetConfig().Enabled)
            {
                EventLogs.LogFileName = Utils.GetMapPath(string.Format("{0}cache/scheduleeventfaildlog.config", BaseConfigs.GetSysPath));
                EventManager.RootPath = Utils.GetMapPath(BaseConfigs.GetSysPath);
                eventTimer = new Timer(new TimerCallback(ScheduledEventWorkCallback), context.Context, 60000, EventManager.TimerMinutesInterval * 60000);
            }
        }

        private void ScheduledEventWorkCallback(object sender)
        {
            try
            {
                if (ScheduleConfigs.GetConfig().Enabled)
                {
                    EventManager.Execute();
                }
            }
            catch(Exception ex)
            {
                EventLogs.WriteFailedLog("Failed ScheduledEventCallBack,"+ex.Source+"," +ex.Data+","+ ex);
            }

        }

        public void Application_OnError(Object sender, EventArgs e)
        {
            HttpApplication application = (HttpApplication)sender;
            HttpContext context = application.Context;
            //if (context.Server.GetLastError().GetBaseException() is MyException)
            {
                //MyException ex = (MyException) context.Server.GetLastError().GetBaseException();
                context.Response.Write("<html><body style=\"font-size:14px;\">");
                context.Response.Write("Error:<br />");
                context.Response.Write("<textarea name=\"errormessage\" style=\"width:80%; height:200px; word-break:break-all\">");
                context.Response.Write(System.Web.HttpUtility.HtmlEncode(context.Server.GetLastError().ToString()));
                context.Response.Write("</textarea>");
                context.Response.Write("</body></html>");
                context.Response.End();
            }

        }

        /// <summary>
        /// 实现接口的Dispose方法
        /// </summary>
        public void Dispose()
        {
            eventTimer = null;
        }

        /// <summary>
        /// 重写Url
        /// </summary>
        /// <param name="sender">事件的源</param>
        /// <param name="e">包含事件数据的 EventArgs</param>
        private void ReUrl_BeginRequest(object sender, EventArgs e)
        {
            BaseConfigInfo baseconfig = BaseConfigProvider.Instance();
            if (baseconfig == null)
            {
                return;
            }
            GeneralConfigInfo config = GeneralConfigs.GetConfig();
            HttpContext context = ((HttpApplication)sender).Context;
            string sysPath = baseconfig.Syspath.ToLower();
            string requestValue = context.Request.QueryString.ToString();
            string requestPath = context.Request.Path.ToString();
            // 当前样式
            string strTemplateid = "1";

            if (requestPath.ToLower().StartsWith(sysPath))
            {
                if (requestPath.ToLower().Substring(sysPath.Length).IndexOf("/") == -1)
                {
                    
                    if (requestPath.ToLower().EndsWith("/default.aspx"))
                    {
                        CreateTemplate(sysPath, Templates.GetTemplateItem(int.Parse(strTemplateid)).Directory, "IndexPage.aspx", int.Parse(strTemplateid));

                        context.RewritePath(sysPath + "aspx/" + strTemplateid + "/IndexPage.aspx");

                        return;
                    }

                    //当使用伪aspx, 如:user-1.aspx等.
                    if (config.Aspxrewrite == 1)
                    {
                        foreach (SiteUrls.URLRewrite url in SiteUrls.GetSiteUrls().Urls)
                        {
                            if (Regex.IsMatch(requestPath, url.Pattern, Utils.GetRegexCompiledOptions() | RegexOptions.IgnoreCase))
                            {
                                string newUrl = Regex.Replace(requestPath.Substring(context.Request.Path.LastIndexOf("/")), url.Pattern, url.QueryString, Utils.GetRegexCompiledOptions() | RegexOptions.IgnoreCase);

                                //if ( url.Page.ToLower() =="/topapirecall.aspx")//淘宝回调处理
                               // {
                               //     context.RewritePath(sysPath + "Services/" + url.Page, string.Empty, newUrl + "&" + requestValue);
                               // }
                               // else
                               // {
                                    context.RewritePath(sysPath + "aspx/" + strTemplateid + url.Page, string.Empty, newUrl + "&selectedtemplateid=" + strTemplateid + "&" + requestValue);
                               // }

                                return;
                            }
                        }
                    }
                   
                    context.RewritePath(sysPath + "aspx/" + strTemplateid + requestPath.Substring(context.Request.Path.LastIndexOf("/")), string.Empty, context.Request.QueryString.ToString() + "&selectedtemplateid=" + strTemplateid);

                    return;
                }
                else if (requestPath.ToLower().StartsWith(sysPath + "home") || requestPath.ToLower().StartsWith(sysPath + "userheadimgu"))
                {
                    //当使用伪aspx, 如:user-1.aspx等.
                    if (config.Aspxrewrite == 1)
                    {
                        foreach (SiteUrls.URLRewrite url in SiteUrls.GetSiteUrls().Urls)
                        {
                            if (Regex.IsMatch(requestPath, url.Pattern, Utils.GetRegexCompiledOptions() | RegexOptions.IgnoreCase))
                            {
                                string newUrl = Regex.Replace(requestPath.Substring(context.Request.Path.LastIndexOf("/")), url.Pattern, url.QueryString, Utils.GetRegexCompiledOptions() | RegexOptions.IgnoreCase);

                                context.RewritePath(sysPath + "aspx/" + strTemplateid + url.Page, string.Empty, newUrl + "&selectedtemplateid=" + strTemplateid + "&" + requestValue);

                                return;
                            }
                        }
                    }
                    return;
                }
/*
                else if (requestPath.StartsWith(sysPath + "archiver/"))
                {
                    //当使用伪aspx
                    if (config.Aspxrewrite == 1)
                    {
                        string path = requestPath.Substring(sysPath.Length + 8);
                        foreach (SiteUrls.URLRewrite url in SiteUrls.GetSiteUrls().Urls)
                        {
                            if (Regex.IsMatch(path, url.Pattern, Utils.GetRegexCompiledOptions() | RegexOptions.IgnoreCase))
                            {
                                string newUrl = Regex.Replace(path, url.Pattern, url.QueryString, Utils.GetRegexCompiledOptions() | RegexOptions.IgnoreCase);

                                context.RewritePath(sysPath + "archiver" + url.Page, string.Empty, newUrl);
                                return;
                            }
                        }

                    }
                    return;
                }
                else if (requestPath.StartsWith(sysPath + "tools/"))
                {
                    //当使用伪aspx
                    if (config.Aspxrewrite == 1)
                    {
                        string path = requestPath.Substring(sysPath.Length + 5);
                        foreach (SiteUrls.URLRewrite url in SiteUrls.GetSiteUrls().Urls)
                        {
                            if (Regex.IsMatch(path, url.Pattern, Utils.GetRegexCompiledOptions() | RegexOptions.IgnoreCase))
                            {
                                string newUrl = Regex.Replace(path, url.Pattern, Utils.UrlDecode(url.QueryString), Utils.GetRegexCompiledOptions() | RegexOptions.IgnoreCase);

                                context.RewritePath(sysPath + "tools" + url.Page, string.Empty, newUrl);
                                return;
                            }
                        }
                    }
                    return;
                }
 */
            }
        }

        private void context_AcquireRequestState(object sender, EventArgs e)
        {
            HttpContext context = ((HttpApplication)sender).Context;
            return;
        }
        private void context_PreRequestHandlerExecute(object sender, EventArgs e)
        {
            HttpContext context = ((HttpApplication)sender).Context;
            return;
        }

        //生成模板文件
        private void CreateTemplate(string syspath, string templatepath, string pagename, int templateid)
        {
            if (!Directory.Exists(Utils.GetMapPath(syspath + "aspx/" + templateid)))
            {
                Directory.CreateDirectory(Utils.GetMapPath(syspath + "aspx/" + templateid));
            }
            if (!File.Exists(Utils.GetMapPath(syspath + "aspx/" + templateid + "/" + pagename)))   //当前模板文件不存在
            {
                SysPageTemplate syspagetemplate = new SysPageTemplate();
                syspagetemplate.GetTemplate(syspath, templatepath, pagename.Split('.')[0], 1, templateid, GeneralConfigs.GetConfig().TemplatesInherits);
            }
        }

        //////////////////////////////////////////////////////////////////////
        /// <summary>
        /// 站点伪Url信息类
        /// </summary>
        public class SiteUrls
        {
            #region 内部属性和方法
            private static object lockHelper = new object();
            private static volatile SiteUrls instance = null;

            string SiteUrlsFile = HttpContext.Current.Server.MapPath(BaseConfigs.GetSysPath + "config/urls.config");
            private System.Collections.ArrayList _Urls;
            public System.Collections.ArrayList Urls
            {
                get
                {
                    return _Urls;
                }
                set
                {
                    _Urls = value;
                }
            }

            private System.Collections.Specialized.NameValueCollection _Paths;
            public System.Collections.Specialized.NameValueCollection Paths
            {
                get
                {
                    return _Paths;
                }
                set
                {
                    _Paths = value;
                }
            }

            private SiteUrls()
            {
                Urls = new System.Collections.ArrayList();
                Paths = new System.Collections.Specialized.NameValueCollection();

                XmlDocument xml = new XmlDocument();

                xml.Load(SiteUrlsFile);

                XmlNode root = xml.SelectSingleNode("urls");
                foreach (XmlNode n in root.ChildNodes)
                {
                    if (n.NodeType != XmlNodeType.Comment && n.Name.ToLower() == "rewrite")
                    {
                        XmlAttribute name = n.Attributes["name"];
                        XmlAttribute path = n.Attributes["path"];
                        XmlAttribute page = n.Attributes["page"];
                        XmlAttribute querystring = n.Attributes["querystring"];
                        XmlAttribute pattern = n.Attributes["pattern"];

                        if (name != null && path != null && page != null && querystring != null && pattern != null)
                        {
                            Paths.Add(name.Value, path.Value);
                            Urls.Add(new URLRewrite(name.Value, pattern.Value, page.Value.Replace("^", "&"), querystring.Value.Replace("^", "&")));
                        }
                    }
                }
            }
            #endregion

            public static SiteUrls GetSiteUrls()
            {
                if (instance == null)
                {
                    lock (lockHelper)
                    {
                        if (instance == null)
                        {
                            instance = new SiteUrls();
                        }
                    }
                }
                return instance;

            }

            public static void SetInstance(SiteUrls anInstance)
            {
                if (anInstance != null)
                    instance = anInstance;
            }

            public static void SetInstance()
            {
                SetInstance(new SiteUrls());
            }


            /// <summary>
            /// 重写伪地址
            /// </summary>
            public class URLRewrite
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

                private string _Pattern;
                public string Pattern
                {
                    get
                    {
                        return _Pattern;
                    }
                    set
                    {
                        _Pattern = value;
                    }
                }

                private string _Page;
                public string Page
                {
                    get
                    {
                        return _Page;
                    }
                    set
                    {
                        _Page = value;
                    }
                }

                private string _QueryString;
                public string QueryString
                {
                    get
                    {
                        return _QueryString;
                    }
                    set
                    {
                        _QueryString = value;
                    }
                }
                #endregion

                #region 构造函数
                public URLRewrite(string name, string pattern, string page, string querystring)
                {
                    _Name = name;
                    _Pattern = pattern;
                    _Page = page;
                    _QueryString = querystring;
                }
                #endregion
            }

        }

    }
}
