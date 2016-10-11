using System;
using System.Collections;
using System.Collections.Generic;
using Top.Api.Parser;
using Top.Api.Request;
using Top.Api.Util;

namespace Top.Api
{
    /// <summary>
    /// 基于REST的TOP客户端。
    /// </summary>
    public class DefaultTopClient : ITopClient
    {
        public const string APP_KEY = "app_key";
        public const string FORMAT = "format";
        public const string METHOD = "method";
        public const string TIMESTAMP = "timestamp";
        public const string VERSION = "v";
        public const string SIGN = "sign";
        public const string PARTNER_ID = "partner_id";
        public const string SESSION = "session";
        public const string FORMAT_XML = "xml";

        private string serverUrl;
        private string appKey;
        private string appSecret;
        private string format = FORMAT_XML;

        private WebUtils webUtils;

        #region DefaultTopClient Constructors

        public DefaultTopClient(string serverUrl, string appKey, string appSecret)
        {
            this.appKey = appKey;
            this.appSecret = appSecret;
            this.serverUrl = serverUrl;
            this.webUtils = new WebUtils();
        }

        public DefaultTopClient(string serverUrl, string appKey, string appSecret, string format)
            : this(serverUrl, appKey, appSecret)
        {
            this.format = format;
        }

        public void SetTimeout(int timeout)
        {
            webUtils.Timeout = timeout;
        }

        #endregion

        #region ITopClient Members

        public T Execute<T>(ITopRequest<T> request) where T : TopResponse
        {
            return Execute<T>(request, null);
        }

        public T Execute<T>(ITopRequest<T> request, string session) where T : TopResponse
        {
            // 添加协议级请求参数
            TopDictionary txtParams = new TopDictionary(request.GetParameters());
            txtParams.Add(METHOD, request.GetApiName());
            txtParams.Add(VERSION, "2.0");
            txtParams.Add(APP_KEY, appKey);
            txtParams.Add(FORMAT, format);
            txtParams.Add(PARTNER_ID, "top-sdk-net-20110512");
            txtParams.Add(TIMESTAMP, DateTime.Now);
            txtParams.Add(SESSION, session);

            // 添加签名参数
            txtParams.Add(SIGN, TopUtils.SignTopRequest(txtParams, appSecret));

            // 是否需要上传文件
            string body;
            if (request is ITopUploadRequest<T>)
            {
                ITopUploadRequest<T> uRequest = (ITopUploadRequest<T>)request;
                IDictionary<string, FileItem> fileParams = TopUtils.CleanupDictionary(uRequest.GetFileParameters());
                body = webUtils.DoPost(this.serverUrl, txtParams, fileParams);
            }
            else
            {
                body = webUtils.DoPost(this.serverUrl, txtParams);
            }

            T rsp;
            if (FORMAT_XML.Equals(format))
            {
                ITopParser<T> tp = new TopXmlParser<T>();
                rsp = tp.Parse(body);
            }
            else
            {
                ITopParser<T> tp = new TopJsonParser<T>();
                rsp = tp.Parse(body);
            }

            return rsp;
        }

        #endregion
    }
}
