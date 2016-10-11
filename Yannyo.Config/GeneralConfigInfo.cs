using System;

namespace Yannyo.Config
{
	/// <summary>
	/// 基本设置描述类, 加[Serializable]标记为可序列化
	/// </summary>
	[Serializable]
	public class GeneralConfigInfo : IConfigInfo
    {
        #region 私有字段
        private string m_Systitle = ""; //系统名称,冰岛销售管理系统
        private string m_Sysurl = "Default.aspx"; //系统url地址
        private string m_webtitle = ""; //网站名称,冰岛销售管理系统
		private string m_weburl = ""; //网站url地址
		private int m_licensed = 1; //是否显示商业授权链接
		private string m_icp = ""; //网站备案信息
		private int m_closed = 0; //系统关闭
		private string m_closedreason = ""; //系统关闭提示信息
        private string m_linktext = ""; //外部链接html
        private string m_statcode = ""; //统计代码
             
		private string m_passwordkey = "1234567890"; //用户密码Key

        private int m_onlinetimeout = 10; //多久无动作视为离线
        private int m_oltimespan = 20;//用户在线时间更新时长(分钟)
        private int m_debug = 1; //显示程序运行信息

        private int m_aspxrewrite = 1; //是否使用伪aspx, 如:user-1.aspx等.
        private string m_templatesinherits = "";//生成模板页面引用前缀

		private string m_ipdenyaccess = ""; //IP禁止访问列表
		private string m_ipaccess = ""; //IP访问列表

        private string m_cookiedomain = "";//身份验证Cookie域

        private string m_cookie_tag = "IsLand_Sales";//cookie标示,IsLand_Sales

		private int m_archiverstatus = 1; //启用 Archiver
		private string m_seotitle = ""; //标题附加字
		private string m_seokeywords = ""; //Meta Keywords
		private string m_seodescription = ""; //Meta Description
		private string m_seohead = "<meta name=\"generator\" content=\"Yannyo Sales\" />"; //其他头部信息

		private int m_passwordmode = 0; //密码模式, 0为默认(32位md5), 1为动网兼容模式(16位md5)

        private string m_MailQueueWEBServicesURL = "http://mailqueue.yannyo.com/MailQueueService.asmx";//邮件队列服务地址
        private string m_sendmailusername = "";//邮件队列登录用户名
        private string m_sendmailuserpwd = "";//邮件队列登录密码

        private string m_WeatherWebServiceURL = "http://www.webxml.com.cn/WebServices/WeatherWebService.asmx";//天气预报服务地址
        private string m_ErpWebServiceURL = "http://erp.bdu9.com/DataEngine.asmx";//Erp系统服务地址
        private string m_ErpWebServicePWD = "20071211";//Erp系统服务调用密码

        private string m_Path = "/Data/";//存储导入数据目录


        private string m_orderid = "1022826";//订单号初始值
        private int m_moneyDecimal = 6;//金额小数保留位数
        private int m_QuantityDecimal = 2;//数量小数保留位数
        private string m_MonthlyStatementCode = "2000000";//对账单号码初始值
        private string m_SupplierCode = "6010101151";//供应商代码初始值
        private string m_CertificateCode = "80800001";//凭证编号
        private string m_ReWorkedOrderNum = "9000000";//工序单编号

        private string m_CompanyName = "";//企业名称,福州冰岛食品有限公司
        private string m_RegistrationNo = "";//注册号,350100100052568
        private string m_Address = "";//地址,福州市鼓楼区福飞路98号门楼二层
        private string m_Phone = "";//电话,0591-87819178

		private string m_PrinterName = "Aisino SK-800II";//默认打印机名称 Aisino SK-800II
        private string m_PrintPageWidth = "21.5cm";//打印单据宽度

        private string m_PrintCertificatePageWidth = "21.5cm";//凭证打印宽度
        private int m_CertificateRow = 10;//凭证行数
        private int m_CertificateCodeLen = 4;//凭证号位数

        private string m_PrintAddPageWidth = "21.5cm";//打印随附单据宽度
        private int m_PrintAddRow = 10;//随附单行数

        private int m_Taobao_Open = 0;//是否开启淘宝网店,0关闭,1开启
        private int m_Taobao_SandBox = 1;//是否为沙箱环境,1是,0否
        private string m_Taobao_Api = "";//淘宝API地址
        private string m_Taobao_Api_Authorize = "http://open.taobao.com/isv/authorize.php?appkey=";//淘宝Api获取AuthorizeKey地址
        private string m_Taobao_Api_Authorize_KeyName = "autoInput";//取AuthorizeKey的Input的Id
        private string m_Taobao_Api_Session = "";//淘宝Api获取SessionKey地址
        private string m_Taobao_Api_Session_KeyName = "top_session";//取SessionKey的参数名称
        ///private string m_Taobao_AppKey = "";//淘宝店AppKey
        ///private string m_Taobao_AppSecret = "";//淘宝店AppSecret
        ///
        private int m_order_lock = 0;//盘点,关闭单据操作,0正常,1锁定
        private int m_certificate_lock = 0;//账期,关闭凭证操作,0正常,1锁定

		private string m_ProductCostPriceCodeMail = "";//成本查看验证邮件（特）

        private string _print_foot = "";//打印页脚信息

        private int _order_print_item = 10;//打印分页，每页条数
        #endregion

        #region OpenID
        //Live ID
        private string wll_appid = "00000000400164C0";//Application ID
        private string wll_secret = "4nOatYmh3AO2Cfvc2cbQ8ehLBDaNB7rT";//Secret Key
        private string wll_securityalgorithm = "wsignin1.0";

        //Google ID
        private string g_urlScope = "http://www.google.com/m8/feeds/";
        private string g_urlAuthSubRequest = "https://www.google.com/accounts/AuthSubRequest?";
        private string g_urlData = "http://www.google.com/m8/feeds/contacts/default/thin?max-results=0";

        //Yahoo ID
        private string y_appid = "";
        private string y_secret = "";
        private string y_timeout = "300";
        private string y_server = "https://api.login.yahoo.com";
        private string y_pathLogin = "/WSLogin/V1/wslogin?";
        private string y_pathPwtoken_login = "/WSLogin/V1/wspwtoken_login?";

        //Xiaonei ID
        private string x_loginUrl = "http://apps.xiaonei.com/passport/login.html";

        #endregion


		#region DBOwner平台配置
		private string _dbo_appid = "";
		private string _dbo_appkey = "";
		private string _dbo_api = "";
		private string _dbo_CompanyID = "";
		private string _dbo_ErpSys = "";
		#endregion

		#region 外部调用Service时需验证的秘钥
		private string _service_key = "";
		private string _service_Staff = "";//接口下单的内部显示业务员
		private string _service_User = "";//接口下单的内部显示操作员
		#endregion

        #region 属性
	
		/// <summary>
		/// 版权文字 (只读)
		/// </summary>
		public string Syscopyright
		{
			get { return "&copy; 2005-" + DateTime.Now.Year.ToString() + "";}
		}

		/// <summary>
		/// 系统名称
		/// </summary>
		public string Systitle
		{
			get { return m_Systitle;}
			set { m_Systitle = value;}
		}

		/// <summary>
		/// 系统url地址
		/// </summary>
		public string Sysurl
		{
			get { return m_Sysurl;}
			set { m_Sysurl = value;}
		}

		/// <summary>
		/// 网站名称
		/// </summary>
		public string Webtitle
		{
			get { return m_webtitle;}
			set { m_webtitle = value;}
		}

        /// <summary>
        /// 网站URL
        /// </summary>
        public string Weburl
        {
            get { return m_weburl; }
            set { m_weburl = value; }
        }

		/// <summary>
		/// 是否显示商业授权链接
		/// </summary>
		public int Licensed
		{
			get { return m_licensed;}
			set { m_licensed = value;}
		}

		/// <summary>
		/// 网站备案信息
		/// </summary>
		public string Icp
		{
			get { return m_icp;}
			set { m_icp = value;}
		}

		/// <summary>
		/// 关闭
		/// </summary>
		public int Closed
		{
			get { return m_closed;}
			set { m_closed = value;}
		}

		/// <summary>
		/// 关闭提示信息
		/// </summary>
		public string Closedreason
		{
			get { return m_closedreason;}
			set { m_closedreason = value;}
		}

        /// <summary>
        /// 身份验证Cookie域
        /// </summary>
        public string CookieDomain
        {
            get { return m_cookiedomain; }
            set { m_cookiedomain = value; }
        }
        /// <summary>
        /// 身份验证Cookie标示
        /// </summary>
        public string CookieTag
        {
            get { return m_cookie_tag; }
            set { m_cookie_tag = value; }
        }
        
        /// <summary>
        /// 外部链接html
        /// </summary>
        public string Linktext
        {
            get { return m_linktext;}
            set { m_linktext = value;}
        }

        /// <summary>
        /// 统计代码
        /// </summary>
        public string Statcode
        {
            get { return m_statcode; }
            set { m_statcode = value; }
        }

		/// <summary>
		/// 用户密码Key
		/// </summary>
		public string Passwordkey
		{
			get { return m_passwordkey;}
			set { m_passwordkey = value;}
		}

		/// <summary>
        /// IP禁止访问列表
		/// </summary>
		public string Ipdenyaccess
		{
			get { return m_ipdenyaccess;}
			set { m_ipdenyaccess = value;}
		}

		/// <summary>
		/// IP访问列表
		/// </summary>
		public string Ipaccess
		{
			get { return m_ipaccess;}
			set { m_ipaccess = value;}
		}

		/// <summary>
		/// 启用 Archiver
		/// </summary>
		public int Archiverstatus
		{
			get { return m_archiverstatus;}
			set { m_archiverstatus = value;}
		}

		/// <summary>
		/// 标题附加字
		/// </summary>
		public string Seotitle
		{
			get { return m_seotitle;}
			set { m_seotitle = value;}
		}

		/// <summary>
		/// Meta Keywords
		/// </summary>
		public string Seokeywords
		{
			get { return m_seokeywords;}
			set { m_seokeywords = value;}
		}

		/// <summary>
		/// Meta Description
		/// </summary>
		public string Seodescription
		{
			get { return m_seodescription;}
			set { m_seodescription = value;}
		}

		/// <summary>
		/// 其他头部信息
		/// </summary>
		public string Seohead
		{
			get { return m_seohead;}
			set { m_seohead = value;}
		}

		/// <summary>
		/// 密码模式, 0为默认(32位md5), 1为动网兼容模式(16位md5)
		/// </summary>
		public int Passwordmode
		{
			get { return m_passwordmode;}
			set { m_passwordmode = value;}
		}
        /// <summary>
        /// 是否使用伪aspx, 如:user-1.aspx等.
        /// </summary>
        public int Aspxrewrite
        {
            get { return m_aspxrewrite; }
            set { m_aspxrewrite = value; }
        }

        /// <summary>
        /// 生成模板页面引用前缀
        /// </summary>
        public string TemplatesInherits
        {
            get { return m_templatesinherits; }
            set { m_templatesinherits = value; }
        }

        /// <summary>
        /// 多久无动作视为离线
        /// </summary>
        public int Onlinetimeout
        {
            get { return m_onlinetimeout; }
            set { m_onlinetimeout = value; }
        }


        /// <summary>
        /// 用户在线时间更新时长(分钟)
        /// </summary>
        public int Oltimespan
        {
            get { return m_oltimespan; }
            set { m_oltimespan = value; }
        }

        /// <summary>
        /// 显示程序运行信息
        /// </summary>
        public int Debug
        {
            get { return m_debug; }
            set { m_debug = value; }
        }

        /// <summary>
        /// 邮件队列服务地址
        /// </summary>
        public string MailQueueWEBServicesURL
        {
            get { return m_MailQueueWEBServicesURL; }
            set { m_MailQueueWEBServicesURL = value; }
        }
        /// <summary>
        /// 邮件队列登录用户名
        /// </summary>
        public string SendMailUserName
        {
            get { return m_sendmailusername; }
            set { m_sendmailusername = value; }
        }
        /// <summary>
        /// 邮件队列登录密码
        /// </summary>
        public string SendMailUserPWD
        {
            get { return m_sendmailuserpwd; }
            set { m_sendmailuserpwd = value; }
        }
        /// <summary>
        /// 天气预报服务地址
        /// </summary>
        public string WeatherWebServiceURL
        {
            get { return m_WeatherWebServiceURL; }
            set { m_WeatherWebServiceURL = value; }
        }
        /// <summary>
        /// Erp系统服务地址
        /// </summary>
        public string ErpWebServiceURL
        {
            get { return m_ErpWebServiceURL; }
            set { m_ErpWebServiceURL = value; }
        }
        /// <summary>
        /// Erp系统服务调用密码
        /// </summary>
        public string ErpWebServicePWD
        {
            get { return m_ErpWebServicePWD; }
            set { m_ErpWebServicePWD = value; }
        }
        /// <summary>
        /// 存储导入数据的路径
        /// </summary>
        public string DataPath
        {
            get { return m_Path; }
            set { m_Path = value; }
        }

        /// <summary>
        /// Live ID appid
        /// </summary>
        public string LiveID_appid
        {
            get { return wll_appid; }
            set { wll_appid = value; }
        }

        /// <summary>
        /// Live ID Secret Key
        /// </summary>
        public string LiveID_secret
        {
            get { return wll_secret; }
            set { wll_secret = value; }
        }

        /// <summary>
        /// Live ID ver
        /// </summary>
        public string LiveID_securityalgorithm
        {
            get { return wll_securityalgorithm; }
            set { wll_securityalgorithm = value; }
        }

        /// <summary>
        /// Google ID urlScope
        /// </summary>
        public string GoogleID_urlScope
        {
            get { return g_urlScope; }
            set { g_urlScope = value; }
        }

        /// <summary>
        /// Google ID urlAuthSubRequest
        /// </summary>
        public string GoogleID_urlAuthSubRequest
        {
            get { return g_urlAuthSubRequest; }
            set { g_urlAuthSubRequest = value; }
        }

        /// <summary>
        /// Google ID urlData
        /// </summary>
        public string GoogleID_urlData
        {
            get { return g_urlData; }
            set { g_urlData = value; }
        }

        /// <summary>
        /// Yahoo ID appid
        /// </summary>
        public string GoogleID_appid
        {
            get { return y_appid; }
            set { y_appid = value; }
        }

        /// <summary>
        /// Yahoo ID secret
        /// </summary>
        public string YahooID_secret
        {
            get { return y_secret; }
            set { y_secret = value; }
        }

        /// <summary>
        /// Yahoo ID timeout
        /// </summary>
        public string YahooID_timeout
        {
            get { return y_timeout; }
            set { y_timeout = value; }
        }

        /// <summary>
        /// Yahoo ID server
        /// </summary>
        public string Yahoo_server
        {
            get { return y_server; }
            set { y_server = value; }
        }

        /// <summary>
        /// Yahoo ID pathLogin
        /// </summary>
        public string Yahoo_pathLogin
        {
            get { return y_pathLogin; }
            set { y_pathLogin = value; }
        }

        /// <summary>
        /// Yahoo ID pathPwtoken_login
        /// </summary>
        public string YahooID_pathPwtoken_login
        {
            get { return y_pathPwtoken_login; }
            set { y_pathPwtoken_login = value; }
        }

        /// <summary>
        /// Xiaonei ID loginUrl
        /// </summary>
        public string XiaoneiID_loginUrl
        {
            get { return x_loginUrl; }
            set { x_loginUrl = value; }
        }

        /// <summary>
        /// 订单号初始值
        /// </summary>
        public string OrderID
        {
            get { return m_orderid; }
            set { m_orderid = value; }
        }
        /// <summary>
        /// 对账单号初始值
        /// </summary>
        public string MonthlyStatementCode
        {
            get { return m_MonthlyStatementCode; }
            set { m_MonthlyStatementCode = value; }
        }
        /// <summary>
        /// 供应商代码初始值
        /// </summary>
        public string SupplierCode
        {
            get { return m_SupplierCode; }
            set { m_SupplierCode = value; }
        }
        /// <summary>
        /// 凭证编号
        /// </summary>
        public string CertificateCode
        {
            get { return m_CertificateCode; }
            set { m_CertificateCode = value; }
        }

        public string ReWorkedOrderNum
        {
            get { return m_ReWorkedOrderNum; }
            set { m_ReWorkedOrderNum = value; }
        }
        
        /// <summary>
        /// 金额小数保留位数
        /// </summary>
        public int MoneyDecimal
        {
            get { return m_moneyDecimal; }
            set { m_moneyDecimal = value; }
        }
        /// <summary>
        /// 数量小数保留位数
        /// </summary>
        public int QuantityDecimal
        {
            get { return m_QuantityDecimal; }
            set { m_QuantityDecimal = value; }
        }
        /// <summary>
        /// 企业名称
        /// </summary>
        public string CompanyName
        {
            get { return m_CompanyName; }
            set { m_CompanyName = value; }
        }
        /// <summary>
        /// 注册号
        /// </summary>
        public string RegistrationNo
        {
            get { return m_RegistrationNo; }
            set { m_RegistrationNo = value; }
        }
        /// <summary>
        /// 地址
        /// </summary>
        public string Address
        {
            get { return m_Address; }
            set { m_Address = value; }
        }
        /// <summary>
        /// 电话
        /// </summary>
        public string Phone
        {
            get { return m_Phone; }
            set { m_Phone = value; }
        }


		public string PrinterName{
			get{ return m_PrinterName;}
			set{ m_PrinterName = value;}
		}
        /// <summary>
        /// 打印单据宽度
        /// </summary>
        public string PrintPageWidth
        {
            get { return m_PrintPageWidth; }
            set { m_PrintPageWidth = value; }
        }
        /// <summary>
        /// 凭证打印宽度
        /// </summary>
        public string PrintCertificatePageWidth
        {
            get { return m_PrintCertificatePageWidth; }
            set { m_PrintCertificatePageWidth = value; }
        }
        /// <summary>
        /// 凭证行数
        /// </summary>
        public int CertificateRow
        {
            get { return m_CertificateRow; }
            set { m_CertificateRow = value; }
        }
        /// <summary>
        /// 凭证号位数
        /// </summary>
        public int CertificateCodeLen
        {
            get { return m_CertificateCodeLen; }
            set { m_CertificateCodeLen = value; }
        }
        
        /// <summary>
        /// 随附单打印宽度
        /// </summary>
        public string PrintAddPageWidth
        {
            get { return m_PrintAddPageWidth; }
            set { m_PrintAddPageWidth = value; }
        }
        /// <summary>
        /// 随附单行数
        /// </summary>
        public int PrintAddRow
        {
            get { return m_PrintAddRow; }
            set { m_PrintAddRow = value; }
        }
        #endregion

        #region 淘宝
        /// <summary>
        /// 是否已开通淘宝商城
        /// </summary>
        public int Taobao_Open
        {
            get { return m_Taobao_Open; }
            set { m_Taobao_Open = value; }
        }
        /// <summary>
        /// 是否沙箱模式,1是,0否
        /// </summary>
        public int Taobao_SandBox
        {
            get { return m_Taobao_SandBox; }
            set { m_Taobao_SandBox = value; }
        }   
        /// <summary>
        /// 淘宝API地址
        /// </summary>
        public string Taobao_Api
        {
            get { return Taobao_SandBox == 1 ? "http://gw.api.tbsandbox.com/router/rest" : "http://gw.api.taobao.com/router/rest"; }
            set { m_Taobao_Api = value; }
        }
        /// <summary>
        /// 淘宝API中获取当前会话AuthorizeKey的URL
        /// </summary>
        public string Taobao_Api_Authorize
        {
            //get { return Taobao_SandBox == 1 ? "http://open.taobao.com/isv/authorize.php?appkey=" : "http://auth.open.taobao.com/?appkey="; }
            get { return Taobao_SandBox == 1 ? "http://container.api.tbsandbox.com/container?appkey=" : "http://container.open.taobao.com/container?appkey="; }
            set { m_Taobao_Api_Authorize = value; }
        }
        /// <summary>
        /// 取AuthorizeKey的Input的Id
        /// </summary>
        public string Taobao_Api_Authorize_KeyName
        {
            get { return m_Taobao_Api_Authorize_KeyName; }
            set { m_Taobao_Api_Authorize_KeyName = value; }
        }
        /// <summary>
        /// 淘宝API中获取当前会话SessionKey的URL
        /// </summary>
        public string Taobao_Api_Session
        {
            get { return Taobao_SandBox == 1 ? "http://container.api.tbsandbox.com/container?authcode=" : "http://container.open.taobao.com/container?authcode="; }
            set { m_Taobao_Api_Session = value; }
        }
        /// <summary>
        /// 取SessionKey的参数
        /// </summary>
        public string Taobao_Api_Session_KeyName
        {
            get { return m_Taobao_Api_Session_KeyName; }
            set { m_Taobao_Api_Session_KeyName = value; }
        }
        
        /// <summary>
        /// TaobaoTopAppSecret
        /// </summary>
        ///public string Taobao_AppSecret
        ///{
       ///     get { return m_Taobao_AppSecret; }
       ///     set { m_Taobao_AppSecret = value; }
       /// }
        #endregion
        /// <summary>
        /// 关闭单据操作
        /// </summary>
        public int Order_lock
        {
            get { return m_order_lock; }
            set { m_order_lock = value; }
        }
        /// <summary>
        /// 关闭凭证操作
        /// </summary>
        public int Certificate_lock
        {
            get { return m_certificate_lock; }
            set { m_certificate_lock = value; }
        }

		/// <summary>
		/// 产品成本查看专用账号验证邮箱
		/// </summary>
		/// <value>The product cost price code mail.</value>
		public string ProductCostPriceCodeMail
		{
			get { return m_ProductCostPriceCodeMail;}
			set { m_ProductCostPriceCodeMail = value;}
		}

		public string DBO_AppID
		{
			get{ return _dbo_appid;}
			set{ _dbo_appid = value;}
		}

		public string DBO_AppKey
		{
			get{ return _dbo_appkey;}
			set{ _dbo_appkey = value;}
		}

		public string DBO_API
		{
			get{ return _dbo_api;}
			set{ _dbo_api = value;}
		}

		public string DBO_CompanyID
		{
			get{ return _dbo_CompanyID; }
			set{ _dbo_CompanyID = value; }
		}

		public string DBO_ErpSys
		{
			get{ return _dbo_ErpSys; }
			set{ _dbo_ErpSys = value; }
		}

		public string Server_Key
		{
			get{ return _service_key;}
			set{ _service_key = value;}
		}

		public string Server_Staff
		{
			get{ return _service_Staff;}
			set{ _service_Staff = value;}
		}

		public string Server_User
		{
			get{ return _service_User;}
			set{ _service_User = value;}
		}

        public string Print_Foot {
            get { return _print_foot; }
            set { _print_foot = value; }
        }

        public int Order_Print_Item {
            get { return _order_print_item; }
            set { _order_print_item = value; }
        }
    }
}
        

