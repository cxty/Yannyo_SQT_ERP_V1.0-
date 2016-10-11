using System;
using System.Web;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;


namespace Yannyo.Common
{
	/// <summary>
	/// Request������
	/// </summary>
	public class HTTPRequest
	{
		/// <summary>
		/// �жϵ�ǰҳ���Ƿ���յ���Post����
		/// </summary>
		/// <returns>�Ƿ���յ���Post����</returns>
		public static bool IsPost()
		{
			return HttpContext.Current.Request.HttpMethod.Equals("POST");
		}
		/// <summary>
		/// �жϵ�ǰҳ���Ƿ���յ���Get����
		/// </summary>
		/// <returns>�Ƿ���յ���Get����</returns>
		public static bool IsGet()
		{
			return HttpContext.Current.Request.HttpMethod.Equals("GET");
		}

		/// <summary>
		/// ����ָ���ķ�����������Ϣ
		/// </summary>
		/// <param name="strName">������������</param>
		/// <returns>������������Ϣ</returns>
		public static string GetServerString(string strName)
		{
			//
			if (HttpContext.Current.Request.ServerVariables[strName] == null)
			{
				return "";
			}
			return HttpContext.Current.Request.ServerVariables[strName].ToString();
		}

		/// <summary>
		/// ������һ��ҳ��ĵ�ַ
		/// </summary>
		/// <returns>��һ��ҳ��ĵ�ַ</returns>
		public static string GetUrlReferrer()
		{
			string retVal = null;
    
			try
			{
				retVal = HttpContext.Current.Request.UrlReferrer.ToString();
			}
			catch{}
			
			if (retVal == null)
				return "";
    
			return retVal;

		}
		
		/// <summary>
		/// �õ���ǰ��������ͷ
		/// </summary>
		/// <returns></returns>
		public static string GetCurrentFullHost()
		{
			HttpRequest request = System.Web.HttpContext.Current.Request;
			if (!request.Url.IsDefaultPort)
			{
				return string.Format("{0}:{1}", request.Url.Host, request.Url.Port.ToString());
			}
			return request.Url.Host;
		}

		/// <summary>
		/// �õ�����ͷ
		/// </summary>
		/// <returns></returns>
		public static string GetHost()
		{
			return HttpContext.Current.Request.Url.Host;
		}


		/// <summary>
		/// ��ȡ��ǰ�����ԭʼ URL(URL ������Ϣ֮��Ĳ���,������ѯ�ַ���(�������))
		/// </summary>
		/// <returns>ԭʼ URL</returns>
		public static string GetRawUrl()
		{
			return HttpContext.Current.Request.RawUrl;
		}

		/// <summary>
		/// �жϵ�ǰ�����Ƿ�������������
		/// </summary>
		/// <returns>��ǰ�����Ƿ�������������</returns>
		public static bool IsBrowserGet()
		{
			string[] BrowserName = {"ie", "opera", "netscape", "mozilla", "konqueror", "firefox"};
			string curBrowser = HttpContext.Current.Request.Browser.Type.ToLower();
			for (int i = 0; i < BrowserName.Length; i++)
			{
				if (curBrowser.IndexOf(BrowserName[i]) >= 0)
				{
					return true;
				}
			}
			return false;
		}

		/// <summary>
		/// �ж��Ƿ�����������������
		/// </summary>
		/// <returns>�Ƿ�����������������</returns>
		public static bool IsSearchEnginesGet()
		{
            if (HttpContext.Current.Request.UrlReferrer == null)
            {
                return false;
            }
		    string[] SearchEngine = {"google", "yahoo", "msn", "baidu", "sogou", "sohu", "sina", "163", "lycos", "tom", "yisou", "iask", "soso", "gougou", "zhongsou"};
			string tmpReferrer = HttpContext.Current.Request.UrlReferrer.ToString().ToLower();
			for (int i = 0; i < SearchEngine.Length; i++)
			{
				if (tmpReferrer.IndexOf(SearchEngine[i]) >= 0)
				{
					return true;
				}
			}
			return false;
		}

		/// <summary>
		/// ��õ�ǰ����Url��ַ
		/// </summary>
		/// <returns>��ǰ����Url��ַ</returns>
		public static string GetUrl()
		{
			return HttpContext.Current.Request.Url.ToString();
		}
		

		/// <summary>
		/// ���ָ��Url������ֵ
		/// </summary>
		/// <param name="strName">Url����</param>
		/// <returns>Url������ֵ</returns>
		public static string GetQueryString(string strName)
		{
			if (HttpContext.Current.Request.QueryString[strName] == null)
			{
				return "";
			}
			return HttpContext.Current.Request.QueryString[strName];
		}

		/// <summary>
		/// ��õ�ǰҳ�������
		/// </summary>
		/// <returns>��ǰҳ�������</returns>
		public static string GetPageName()
		{
			string [] urlArr = HttpContext.Current.Request.Url.AbsolutePath.Split('/');
			return urlArr[urlArr.Length - 1].ToLower();
		}

		/// <summary>
		/// ���ر���Url�������ܸ���
		/// </summary>
		/// <returns></returns>
		public static int GetParamCount()
		{
			return HttpContext.Current.Request.Form.Count + HttpContext.Current.Request.QueryString.Count;
		}


		/// <summary>
		/// ���ָ����������ֵ
		/// </summary>
		/// <param name="strName">������</param>
		/// <returns>��������ֵ</returns>
		public static string GetFormString(string strName)
		{
			if (HttpContext.Current.Request.Form[strName] == null)
			{
				return "";
			}
			return HttpContext.Current.Request.Form[strName];
		}

		/// <summary>
		/// ���Url���������ֵ, ���ж�Url�����Ƿ�Ϊ���ַ���, ��ΪTrue�򷵻ر�������ֵ
		/// </summary>
		/// <param name="strName">����</param>
		/// <returns>Url���������ֵ</returns>
		public static string GetString(string strName)
		{
			if ("".Equals(GetQueryString(strName)))
			{
				return GetFormString(strName);
			}
			else
			{
				return GetQueryString(strName);
			}
		}


		/// <summary>
		/// ���ָ��Url������int����ֵ
		/// </summary>
		/// <param name="strName">Url����</param>
		/// <param name="defValue">ȱʡֵ</param>
		/// <returns>Url������int����ֵ</returns>
		public static int GetQueryInt(string strName, int defValue)
		{
			return Utils.StrToInt(HttpContext.Current.Request.QueryString[strName], defValue);
		}


		/// <summary>
		/// ���ָ����������int����ֵ
		/// </summary>
		/// <param name="strName">������</param>
		/// <param name="defValue">ȱʡֵ</param>
		/// <returns>��������int����ֵ</returns>
		public static int GetFormInt(string strName, int defValue)
		{
			return Utils.StrToInt(HttpContext.Current.Request.Form[strName], defValue);
		}

		/// <summary>
		/// ���ָ��Url���������int����ֵ, ���ж�Url�����Ƿ�Ϊȱʡֵ, ��ΪTrue�򷵻ر�������ֵ
		/// </summary>
		/// <param name="strName">Url�������</param>
		/// <param name="defValue">ȱʡֵ</param>
		/// <returns>Url���������int����ֵ</returns>
		public static int GetInt(string strName, int defValue)
		{
			if (GetQueryInt(strName, defValue) == defValue)
			{
				return GetFormInt(strName, defValue);
			}
			else
			{
				return GetQueryInt(strName, defValue);
			}
		}

		/// <summary>
		/// ���ָ��Url������float����ֵ
		/// </summary>
		/// <param name="strName">Url����</param>
		/// <param name="defValue">ȱʡֵ</param>
		/// <returns>Url������int����ֵ</returns>
		public static float GetQueryFloat(string strName, float defValue)
		{
			return Utils.StrToFloat(HttpContext.Current.Request.QueryString[strName], defValue);
		}


		/// <summary>
		/// ���ָ����������float����ֵ
		/// </summary>
		/// <param name="strName">������</param>
		/// <param name="defValue">ȱʡֵ</param>
		/// <returns>��������float����ֵ</returns>
		public static float GetFormFloat(string strName, float defValue)
		{
			return Utils.StrToFloat(HttpContext.Current.Request.Form[strName], defValue);
		}
		
		/// <summary>
		/// ���ָ��Url���������float����ֵ, ���ж�Url�����Ƿ�Ϊȱʡֵ, ��ΪTrue�򷵻ر�������ֵ
		/// </summary>
		/// <param name="strName">Url�������</param>
		/// <param name="defValue">ȱʡֵ</param>
		/// <returns>Url���������int����ֵ</returns>
		public static float GetFloat(string strName, float defValue)
		{
			if (GetQueryFloat(strName, defValue) == defValue)
			{
				return GetFormFloat(strName, defValue);
			}
			else
			{
				return GetQueryFloat(strName, defValue);
			}
		}

		/// <summary>
		/// ��õ�ǰҳ��ͻ��˵�IP
		/// </summary>
		/// <returns>��ǰҳ��ͻ��˵�IP</returns>
		public static string GetIP()
		{

			string result = String.Empty;

			result = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
			if (string.IsNullOrEmpty(result))
			{
				result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
			}

			if (string.IsNullOrEmpty(result))
			{
				result = HttpContext.Current.Request.UserHostAddress;
			}

			if (string.IsNullOrEmpty(result) || !Utils.IsIP(result))
			{
				return "127.0.0.1";
			}

			return result;

		}

        /// <summary>
        /// ��õ�ǰ�ͻ���ϵͳ����
        /// </summary>
        /// <returns></returns>
        public static string GetLanguage()
        {
            string[] lanarray = { "zh-cn", "zh-tw", "zh-mo", "zh-hk", "zh-sg", "en-us", "en", "da-dk", "nl-nl", "fi-fi", "fr-fr", "de-de", "de", "it-it", "ja-jp", "jp", "ko-kr", "ko", "nb-no", "pt-br", "es-es", "es-us", "sv-se" };
            string result = String.Empty;
            result = HttpContext.Current.Request.ServerVariables["HTTP_ACCEPT_LANGUAGE"];
            if (!string.IsNullOrEmpty(result))
            {
                foreach (string x in lanarray)
                {
                    if (result.ToLower().IndexOf(x) > -1)
                    {
                        result = x;
                        break;
                    }
                }
            }
            if (string.IsNullOrEmpty(result))
            {
                result = "zh-cn";
            }
            return result;
        }

		/// <summary>
		/// �����û��ϴ����ļ�
		/// </summary>
		/// <param name="path">����·��</param>
		public static void SaveRequestFile(string path)
		{
			if (HttpContext.Current.Request.Files.Count > 0)
			{
				HttpContext.Current.Request.Files[0].SaveAs(path);
			}
		}

//		/// <summary>
//		/// �����ϴ����ļ�
//		/// </summary>
//		/// <param name="MaxAllowFileCount">���������ϴ��ļ�����</param>
//		/// <param name="MaxAllowFileSize">���������ļ�����(��λ: KB)</param>
//		/// <param name="AllowFileExtName">������ļ���չ��, ��string[]��ʽ�ṩ</param>
//		/// <param name="AllowFileType">������ļ�����, ��string[]��ʽ�ṩ</param>
//		/// <param name="Dir">Ŀ¼</param>
//		/// <returns></returns>
//		public static Forum.AttachmentInfo[] SaveRequestFiles(int MaxAllowFileCount, int MaxAllowFileSize, string[] AllowFileExtName, string[] AllowFileType, string Dir)
//		{
//			int savefilecount = 0;
//			
//			int fcount = Math.Min(MaxAllowFileCount, HttpContext.Current.Request.Files.Count);
//
//			Forum.AttachmentInfo[] attachmentinfo = new Forum.AttachmentInfo[fcount];
//			for(int i=0;i<fcount;i++)
//			{
//				string filename = HttpContext.Current.Request.Files[i].FileName;
//				string fileextname = filename.Substring(filename.LastIndexOf("."));
//				string filetype = HttpContext.Current.Request.Files[i].ContentType;
//				int filesize = HttpContext.Current.Request.Files[i].ContentLength;
//				// �ж� �ļ���չ��/�ļ���С/�ļ����� �Ƿ����Ҫ��
//				if(Utils.InArray(fileextname, AllowFileExtName) && (filesize <= MaxAllowFileSize * 1024) && Utils.InArray(filetype, AllowFileType))
//				{
//
//					HttpContext.Current.Request.Files[i].SaveAs(Dir + Utils.GetDateTime() + Environment.TickCount.ToString() + fileextname);
//					attachmentinfo[savefilecount].Filename = filename;
//					attachmentinfo[savefilecount].Filesize = filesize;
//					attachmentinfo[savefilecount].Description = filetype;
//					attachmentinfo[savefilecount].Filetype = fileextname;
//					savefilecount++;
//				}
//			}
//			return attachmentinfo;
//			
//		}
        /// <summary>
        /// �ж����������Ƿ����ƽ��
        /// </summary>
        /// <param name="MaxSeconds">�ж����ݷ�����̼��</param>
        public static bool CheckRequestDataFrequency(int MaxSeconds)
        {
            MaxSeconds = (MaxSeconds > 0) ? MaxSeconds : 3;
            bool reValue = true;
            if (HttpContext.Current.Session["RequestData_Time"] != null)
            {
                TimeSpan sp = new TimeSpan();
                DateTime dt = DateTime.Now;
                sp = DateTime.Now - Convert.ToDateTime(HttpContext.Current.Session["RequestData_Time"]);
                if (sp.Seconds < MaxSeconds)
                {
                    reValue = false;
                }
            }
            HttpContext.Current.Session["RequestData_Time"] = DateTime.Now.AddSeconds(10).ToString();
            return reValue;
        }

        /// <summary>
        /// ��ȡԶ��ҳ������
        /// </summary>
        /// <param name="Url">URL·��</param>
        /// <param name="PostType">POST���� GET/POST</param>
        /// <param name="codes">����GB2312 / utf-8</param>
        /// <returns></returns>
        public static string GetHttp(string Url, string PostType, string codes)
        {
            string StrHttp = "";
            try
            {
                if (PostType == "POST")
                {
                    string[] TmpUrl = Url.Split('?');
                    string PostStr = TmpUrl[TmpUrl.Length - 1];
                    byte[] requestBytes = System.Text.Encoding.Default.GetBytes(PostStr);
                    HttpWebRequest httpReq = (HttpWebRequest)WebRequest.Create(TmpUrl[0]);
                    httpReq.Timeout = 10000;//���ó�ʱֵ2��
                    httpReq.Method = "POST";
                    httpReq.ContentType = "application/x-www-form-urlencoded";
                    httpReq.ContentLength = requestBytes.Length;
                    Stream requestStream = httpReq.GetRequestStream();
                    requestStream.Write(requestBytes, 0, requestBytes.Length);
                    requestStream.Close();

                    HttpWebResponse res = (HttpWebResponse)httpReq.GetResponse();
                    StreamReader sr = new StreamReader(res.GetResponseStream(), System.Text.Encoding.GetEncoding(codes));
                    StrHttp = sr.ReadToEnd();
                    sr.Close();
                    res.Close();
                    sr = null;
                    res = null;
                }
                else
                {
                    HttpWebRequest httpReq = (HttpWebRequest)WebRequest.Create(Url);//HttpWebRequest ��� WebRequest �ж�������Ժͷ����ṩ֧��'��Ҳ��ʹ�û��ܹ�ֱ����ʹ�� HTTP �ķ����������ĸ������Ժͷ����ṩ֧�֡�
                    httpReq.ContentType = "application/x-www-form-urlencoded";
                    //httpReq.Headers.Add("Accept-Language", "zh-cn");
                    httpReq.Timeout = 10000; //���ó�ʱֵ2��
                    httpReq.Method = "GET";
                    HttpWebResponse httpResq = (HttpWebResponse)httpReq.GetResponse();
                    StreamReader reader = new StreamReader(httpResq.GetResponseStream(), System.Text.Encoding.GetEncoding(codes));//�������ģ�Ҫ���ñ����ʽΪ��GB2312����
                    string respHTML = reader.ReadToEnd(); //respHTML����ҳ��Դ����
                    StrHttp = respHTML;
                    httpResq.Close();
                    httpResq = null;
                }
            }
            catch (Exception ex)
            {
                StrHttp = ex.Message;
            }
            return StrHttp;
        }


	}
}
