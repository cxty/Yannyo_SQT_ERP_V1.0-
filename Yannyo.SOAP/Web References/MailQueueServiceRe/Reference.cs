﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.1
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

// 
// 此源代码是由 Microsoft.VSDesigner 4.0.30319.1 版自动生成。
// 
#pragma warning disable 1591

namespace Yannyo.SOAP.MailQueueServiceRe {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.ComponentModel;
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="MailQueueServiceSoap", Namespace="http://www.openx.cn/")]
    public partial class MailQueueService : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback SendMailOperationCompleted;
        
        private System.Threading.SendOrPostCallback SendMailByMailEntityListOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public MailQueueService() {
            this.Url = global::Yannyo.SOAP.Properties.Settings.Default.Yannyo_SOAP_MailQueueServiceRe_MailQueueService;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event SendMailCompletedEventHandler SendMailCompleted;
        
        /// <remarks/>
        public event SendMailByMailEntityListCompletedEventHandler SendMailByMailEntityListCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.openx.cn/SendMail", RequestNamespace="http://www.openx.cn/", ResponseNamespace="http://www.openx.cn/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public int SendMail(string UserName, string UserPWD, string mTitle, string mContent, string mSender, string mSendMail, string mAddressee, string mAddresseeMail, bool mIsHTML, System.DateTime SetSendTime) {
            object[] results = this.Invoke("SendMail", new object[] {
                        UserName,
                        UserPWD,
                        mTitle,
                        mContent,
                        mSender,
                        mSendMail,
                        mAddressee,
                        mAddresseeMail,
                        mIsHTML,
                        SetSendTime});
            return ((int)(results[0]));
        }
        
        /// <remarks/>
        public void SendMailAsync(string UserName, string UserPWD, string mTitle, string mContent, string mSender, string mSendMail, string mAddressee, string mAddresseeMail, bool mIsHTML, System.DateTime SetSendTime) {
            this.SendMailAsync(UserName, UserPWD, mTitle, mContent, mSender, mSendMail, mAddressee, mAddresseeMail, mIsHTML, SetSendTime, null);
        }
        
        /// <remarks/>
        public void SendMailAsync(string UserName, string UserPWD, string mTitle, string mContent, string mSender, string mSendMail, string mAddressee, string mAddresseeMail, bool mIsHTML, System.DateTime SetSendTime, object userState) {
            if ((this.SendMailOperationCompleted == null)) {
                this.SendMailOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSendMailOperationCompleted);
            }
            this.InvokeAsync("SendMail", new object[] {
                        UserName,
                        UserPWD,
                        mTitle,
                        mContent,
                        mSender,
                        mSendMail,
                        mAddressee,
                        mAddresseeMail,
                        mIsHTML,
                        SetSendTime}, this.SendMailOperationCompleted, userState);
        }
        
        private void OnSendMailOperationCompleted(object arg) {
            if ((this.SendMailCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SendMailCompleted(this, new SendMailCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.openx.cn/SendMailByMailEntityList", RequestNamespace="http://www.openx.cn/", ResponseNamespace="http://www.openx.cn/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public int SendMailByMailEntityList(string UserName, string UserPWD, MailEntity[] mail) {
            object[] results = this.Invoke("SendMailByMailEntityList", new object[] {
                        UserName,
                        UserPWD,
                        mail});
            return ((int)(results[0]));
        }
        
        /// <remarks/>
        public void SendMailByMailEntityListAsync(string UserName, string UserPWD, MailEntity[] mail) {
            this.SendMailByMailEntityListAsync(UserName, UserPWD, mail, null);
        }
        
        /// <remarks/>
        public void SendMailByMailEntityListAsync(string UserName, string UserPWD, MailEntity[] mail, object userState) {
            if ((this.SendMailByMailEntityListOperationCompleted == null)) {
                this.SendMailByMailEntityListOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSendMailByMailEntityListOperationCompleted);
            }
            this.InvokeAsync("SendMailByMailEntityList", new object[] {
                        UserName,
                        UserPWD,
                        mail}, this.SendMailByMailEntityListOperationCompleted, userState);
        }
        
        private void OnSendMailByMailEntityListOperationCompleted(object arg) {
            if ((this.SendMailByMailEntityListCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SendMailByMailEntityListCompleted(this, new SendMailByMailEntityListCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.openx.cn/")]
    public partial class MailEntity {
        
        private string mTitleField;
        
        private string mContentField;
        
        private string mSenderField;
        
        private string mSendMailField;
        
        private string mAddresseeField;
        
        private string mAddresseeMailField;
        
        private bool mIsHTMLField;
        
        private System.DateTime mSetSendTimeField;
        
        private System.DateTime mSendTimeField;
        
        /// <remarks/>
        public string mTitle {
            get {
                return this.mTitleField;
            }
            set {
                this.mTitleField = value;
            }
        }
        
        /// <remarks/>
        public string mContent {
            get {
                return this.mContentField;
            }
            set {
                this.mContentField = value;
            }
        }
        
        /// <remarks/>
        public string mSender {
            get {
                return this.mSenderField;
            }
            set {
                this.mSenderField = value;
            }
        }
        
        /// <remarks/>
        public string mSendMail {
            get {
                return this.mSendMailField;
            }
            set {
                this.mSendMailField = value;
            }
        }
        
        /// <remarks/>
        public string mAddressee {
            get {
                return this.mAddresseeField;
            }
            set {
                this.mAddresseeField = value;
            }
        }
        
        /// <remarks/>
        public string mAddresseeMail {
            get {
                return this.mAddresseeMailField;
            }
            set {
                this.mAddresseeMailField = value;
            }
        }
        
        /// <remarks/>
        public bool mIsHTML {
            get {
                return this.mIsHTMLField;
            }
            set {
                this.mIsHTMLField = value;
            }
        }
        
        /// <remarks/>
        public System.DateTime mSetSendTime {
            get {
                return this.mSetSendTimeField;
            }
            set {
                this.mSetSendTimeField = value;
            }
        }
        
        /// <remarks/>
        public System.DateTime mSendTime {
            get {
                return this.mSendTimeField;
            }
            set {
                this.mSendTimeField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void SendMailCompletedEventHandler(object sender, SendMailCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class SendMailCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal SendMailCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public int Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((int)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void SendMailByMailEntityListCompletedEventHandler(object sender, SendMailByMailEntityListCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class SendMailByMailEntityListCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal SendMailByMailEntityListCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public int Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((int)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591