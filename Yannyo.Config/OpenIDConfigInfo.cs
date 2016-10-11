using System;
using System.Xml.Serialization;
using System.Web;

namespace Yannyo.Config
{
    [Serializable]
    public class OpenIDConfigInfo : IConfigInfo
    {
        private string m_cookieName = "YannyoATS";
        private string m_cookieDomain = "yannyo.com";
        private string m_paramName = "YannyoAC";
        private string m_rootUrl = "http://my.yannyo.com/";

        public OpenIDConfigInfo()
        {
        }
        /// <summary>
        /// cookieName
        /// </summary>
        public string cookieName
        {
            get { return m_cookieName; }
            set { m_cookieName = value; }
        }
        /// <summary>
        /// cookieDomain
        /// </summary>
        public string cookieDomain
        {
            get { return m_cookieDomain; }
            set { m_cookieDomain = value; }
        }
        /// <summary>
        /// paramName
        /// </summary>
        public string paramName
        {
            get { return m_paramName; }
            set { m_paramName = value; }
        }
        /// <summary>
        /// rootUrl
        /// </summary>
        public string rootUrl
        {
            get { return m_rootUrl; }
            set { m_rootUrl = value; }
        }

        /// <summary>
        /// AccountServers
        /// </summary>
        [XmlArray("AccountServers")]
        public AccountServer[] AccountServer;

    }

    [Serializable]
    public class AccountServer
    {
        private string m_name = "";
        private string m_type = "";
        private string m_urlAuthSubRequest = "";
        private string m_urlScope = "";
        private string m_urlData = "";
        private string m_appid = "";
        private string m_secret = "";
        private int m_timeout = 300;
        private string m_server = "";
        private string m_pathLogin = "";
        private string m_pathPwtoken_login = "";
        private string m_securityalgorithm = "";
        private string m_loginUrl = "";
        private string m_urlOAuthGetRequestToken = "";
        private string m_urlOAuthAuthorizeToken = "";
        private string m_urlOAuthGetAccessToken = "";
        private string m_consumerKey = "";
        private string m_consumerSecret = "";

        public AccountServer()
        { }
        /// <summary>
        /// 名称
        /// </summary>
        [XmlAttribute("name")] 
        public string name
        {
            get { return m_name; }
            set { m_name = value; }
        }
        /// <summary>
        /// 类型
        /// </summary>
        [XmlAttribute("type")] 
        public string type
        {
            get { return m_type; }
            set { m_type = value; }
        }
        /// <summary>
        /// Google使用AuthSubRequest
        /// </summary>
        [XmlAttribute("urlAuthSubRequest")] 
        public string urlAuthSubRequest
        {
            get { return m_urlAuthSubRequest; }
            set { m_urlAuthSubRequest = value; }
        }
        /// <summary>
        /// Google使用urlScope
        /// </summary>
        [XmlAttribute("urlScope")] 
        public string urlScope
        {
            get { return m_urlScope; }
            set { m_urlScope = value; }
        }
        /// <summary>
        /// Google使用urlData
        /// </summary>
        [XmlAttribute("urlData")] 
        public string urlData
        {
            get { return m_urlData; }
            set { m_urlData = value; }
        }

        /// <summary>
        /// Yahoo,Live使用appid
        /// </summary>
        [XmlAttribute("appid")] 
        public string appid
        {
            get { return m_appid; }
            set { m_appid = value; }
        }
        /// <summary>
        /// Yahoo,Live使用secret
        /// </summary>
        [XmlAttribute("secret")] 
        public string secret
        {
            get { return m_secret; }
            set { m_secret = value; }
        }
        /// <summary>
        /// Yahoo使用timeout
        /// </summary>
        [XmlAttribute("timeout")] 
        public int timeout
        {
            get { return m_timeout; }
            set { m_timeout = value; }
        }
        /// <summary>
        /// Yahoo使用server
        /// </summary>
        [XmlAttribute("server")] 
        public string server
        {
            get { return m_server; }
            set { m_server = value; }
        }
        /// <summary>
        /// Yahoo使用pathLogin
        /// </summary>
        [XmlAttribute("pathLogin")] 
        public string pathLogin
        {
            get { return m_pathLogin; }
            set { m_pathLogin = value; }
        }
        /// <summary>
        /// Yahoo使用pathPwtoken_login
        /// </summary>
        [XmlAttribute("pathPwtoken_login")]
        public string pathPwtoken_login
        {
            get { return m_pathPwtoken_login; }
            set { m_pathPwtoken_login = value; }
        }
        /// <summary>
        /// Live使用securityalgorithm
        /// </summary>
        [XmlAttribute("securityalgorithm")]
        public string securityalgorithm
        {
            get { return m_securityalgorithm; }
            set { m_securityalgorithm = value; }
        }
        /// <summary>
        /// 校内使用loginUrl
        /// </summary>
        [XmlAttribute("loginUrl")]
        public string loginUrl
        {
            get { return m_loginUrl; }
            set { m_loginUrl = value; }
        }

        [XmlAttribute("urlOAuthGetRequestToken")]
        public string urlOAuthGetRequestToken
        {
            get { return m_urlOAuthGetRequestToken; }
            set { m_urlOAuthGetRequestToken = value; }
        }
        [XmlAttribute("urlOAuthAuthorizeToken")]
        public string urlOAuthAuthorizeToken
        {
            get { return m_urlOAuthAuthorizeToken; }
            set { m_urlOAuthAuthorizeToken = value; }
        }
        [XmlAttribute("urlOAuthGetAccessToken")]
        public string urlOAuthGetAccessToken
        {
            get { return m_urlOAuthGetAccessToken; }
            set { m_urlOAuthGetAccessToken = value; }
        }
        [XmlAttribute("consumerKey")]
        public string consumerKey
        {
            get { return m_consumerKey; }
            set { m_consumerKey = value; }
        }
        [XmlAttribute("consumerSecret")]
        public string consumerSecret
        {
            get { return m_consumerSecret; }
            set { m_consumerSecret = value; }
        }
    }
}
