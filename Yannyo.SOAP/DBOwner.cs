using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data;
using System.Web;

using Yannyo.Entity;
using Yannyo.Common;
using Yannyo.Config;
using System.Net;
using System.IO;

namespace Yannyo.SOAP
{

    

    public class DBOwner
    {
        string devUrl;
        string _signStr;
        string RequestMethod;
        string _dbo_client_id;
        string _dbo_client_secret;
        string _dbo_Api;
        string _dbo_access_token;
        string _dbo_format;
        string _dbo_user_id;
		IDictionary<string, string> _parameters = new Dictionary<string, string>();
		private int _timeout = 100000;
       

        // http method
        public enum HttpMethod
        {
            POST,
            GET
        }
		public DBOwner(string dbo_api,string dbo_appid,string dbo_appkey,string dbo_access_token,string dbo_format,string dbo_user_id) {
            this._dbo_Api = dbo_api;
            this._dbo_client_id = dbo_appid;
            this._dbo_client_secret = dbo_appkey;

			this._dbo_access_token = dbo_access_token;
			this._dbo_format = dbo_format;
			this._dbo_user_id = dbo_user_id;
        }


        /// <summary>
        /// 签名，参数构造
        /// </summary>
        private void _sign(string act, string data)
        {
            devUrl = _dbo_Api + this.RequestMethod;   //字符串格式输出  

			byte[] data_bytes = Encoding.UTF8.GetBytes(data);
			data = Convert.ToBase64String (data_bytes);

			this._parameters.Add ("access_token",this._dbo_access_token);
			this._parameters.Add ("act",act);
			this._parameters.Add ("appid",this._dbo_client_id);
			this._parameters.Add ("data",data);
			this._parameters.Add ("format",this._dbo_format);
			this._parameters.Add ("user_id",this._dbo_user_id);

			IDictionary<string, string> _sign_parameters = new Dictionary<string, string>();
			_sign_parameters = _parameters;

			_sign_parameters.Add ("appkey",this._dbo_client_secret);


			string _sign_parameters_str = BuildQuery (_sign_parameters);


			//this.log (_sign_parameters_str);

			_signStr = Utils.MD5(_sign_parameters_str).ToUpper();

            byte[] bytes = Encoding.UTF8.GetBytes(_signStr);

            string _sign = Convert.ToBase64String(bytes);//签名

			//this.log (_sign);

			_parameters.Add ("sign",_sign);

        }


        /// <summary>
        /// 发邮件
        /// </summary>
        public void DBOwnerDataSendMail(string appid, string toMail, string title, string content)
        {
          
           this.RequestMethod = "cloudcode.html";

            string data = "{\"ClassName\":\"CloudCode\",\"Function\":\"AddMailQ\",\"Params\":"+
            "{\"ToAddress\":\"" + toMail + "\"," +
            "\"Title\":\"" + title + "\"," +
			"\"Content\":\"" + Utils.ReplaceString( content,"\"","",false) + "\"," +
            "\"SendTime\":\"\","+
            "\"Tip\":\"\","+
            "\"AppID\":\"" + appid + "\"}}";


			//string data = "{}";

            this._sign("call", data);

			string _re = this.DoPost(this.devUrl, BuildQuery(this._parameters));
			/*
			this.log (this.devUrl);
			this.log (data);
			this.log (_re);
			this.log (BuildQuery(this._parameters));
            */
        }

        public void DBOwnerUpdateProductsStock(string ErpSys, string CompanyID, string ProductsCode, string StockCode, int Quantity, string appid)
        {
			this.RequestMethod = "cloudcode.html";
			string data = "{\"ClassName\":\"CloudCode\",\"Function\":\"UpdateSCMProductsStock\",\"Params\":"+
								"{\"ProductsCode\":\"" + ProductsCode + "\"," +
								"\"StockCode\":\"" + StockCode + "\"," +
								"\"Quantity\":" + Quantity + "," +
								"\"CompanyID\":\""+CompanyID+"\","+
								"\"ErpSys\":\""+ErpSys+"\","+
                                "\"AppID\":\"" + appid + "\"" +
								"}"+
							"}";


			//string data = "{}";

			this._sign("call", data);

			string _re = this.DoPost(this.devUrl, BuildQuery(this._parameters));

		}

        public void DBOwnerUpdateProductsStockByStr(string ErpSys, string CompanyID, string ProductsCodeStr, string StockCodeStr, string QuantityStr, string appid)
        {
            this.RequestMethod = "cloudcode.html";
            string data = "{\"ClassName\":\"CloudCode\",\"Function\":\"UpdateSCMProductsStock\",\"Params\":" +
                                "{\"ProductsCode\":\"" + ProductsCodeStr + "\"," +
                                "\"StockCode\":\"" + StockCodeStr + "\"," +
                                "\"Quantity\":\"" + QuantityStr + "\"," +
                                "\"CompanyID\":\"" + CompanyID + "\"," +
                                "\"ErpSys\":\"" + ErpSys + "\"," +
                                "\"AppID\":\"" + appid + "\"," +
                                "\"ByStr\":\"Yes\""+
                                "}" +
                            "}";


            //string data = "{}";

            this._sign("call", data);

            string _re = this.DoPost(this.devUrl, BuildQuery(this._parameters));

        }

		public HttpWebRequest GetWebRequest(string url, string method)
		{
			HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
			req.ServicePoint.Expect100Continue = false;
			req.Method = method;
			req.KeepAlive = true;
			req.UserAgent = "YannyoSQT";
			req.Timeout = this._timeout;
			return req;
		}

		/// <summary>
		/// 执行HTTP POST请求。
		/// </summary>
		/// <param name="url">请求地址</param>
		/// <param name="parameters">请求参数</param>
		/// <returns>HTTP响应</returns>
		public string DoPost(string url, string parameters)
		{
			HttpWebRequest req = GetWebRequest(url, "POST");
			req.ContentType = "application/x-www-form-urlencoded;charset=utf-8";

			byte[] postData = Encoding.UTF8.GetBytes(parameters);
			Stream reqStream = req.GetRequestStream();
			reqStream.Write(postData, 0, postData.Length);
			reqStream.Close();

			HttpWebResponse rsp = (HttpWebResponse)req.GetResponse();
			Encoding encoding = Encoding.GetEncoding(rsp.CharacterSet);
			return GetResponseAsString(rsp, encoding);
		}

		/// <summary>
		/// 把响应流转换为文本。
		/// </summary>
		/// <param name="rsp">响应流对象</param>
		/// <param name="encoding">编码方式</param>
		/// <returns>响应文本</returns>
		public string GetResponseAsString(HttpWebResponse rsp, Encoding encoding)
		{
			StringBuilder result = new StringBuilder();
			Stream stream = null;
			StreamReader reader = null;

			try
			{
				// 以字符流的方式读取HTTP响应
				stream = rsp.GetResponseStream();
				reader = new StreamReader(stream, encoding);

				// 按字符读取并写入字符串缓冲
				int ch = -1;
				while ((ch = reader.Read()) > -1)
				{
					// 过滤结束符
					char c = (char)ch;
					if (c != '\0')
					{
						result.Append(c);
					}
				}
			}
			finally
			{
				// 释放资源
				if (reader != null) reader.Close();
				if (stream != null) stream.Close();
				if (rsp != null) rsp.Close();
			}

			return result.ToString();
		}

		/// <summary>
		/// 组装普通文本请求参数。
		/// </summary>
		/// <param name="parameters">Key-Value形式请求参数字典</param>
		/// <returns>URL编码后的请求数据</returns>
		public static string BuildQuery(IDictionary<string, string> parameters)
		{
			StringBuilder postData = new StringBuilder();
			bool hasParam = false;

			IDictionary<string, string> sortedParams = new SortedDictionary<string, string>(parameters);

			IEnumerator<KeyValuePair<string, string>> dem = sortedParams.GetEnumerator();
			while (dem.MoveNext())
			{
				string name = dem.Current.Key;
				string value = string.IsNullOrEmpty (dem.Current.Value)? "":dem.Current.Value;
				// 忽略参数名或参数值为空的参数

				if (!string.IsNullOrEmpty(name))
				{
					if (hasParam)
					{
						postData.Append("&");
					}

					postData.Append(name);
					postData.Append("=");
					postData.Append(Uri.EscapeDataString(value));
					hasParam = true;
				}
			}

			return postData.ToString();
		}

		public void log(string _log){
			StreamWriter log = new StreamWriter("D:\\www\\sqt.yannyo.com\\log.log", true);
			log.WriteLine( string.Format("[{0}] {1}",System.DateTime.Now,_log));
			log.Flush();
			log.Dispose ();
		}
    }
}