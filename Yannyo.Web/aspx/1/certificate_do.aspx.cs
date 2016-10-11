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
using Newtonsoft.Json;

namespace Yannyo.Web
{
    public partial class certificate_do : PageBase
    {
        public string Act = "";
        public int CertificateID = 0;
        public int OrderID = 0;
        public int OrderType = 0;
        public CertificateInfo ci = new CertificateInfo();
        public DateTime cDateTime = DateTime.Now;
        public string CertificateDataJsonStr = "";
        public DataTable PicList = new DataTable();
        public string cCode = "";
        public int cNumber = 0;

        public string StaffList = "";//人员列表
        public string FeesSubjectClassList = "";//科目列表
        public string ToObjectList = "";//单位列表

        public string DepartmentsJson = "";
        public string SupplierJson = "";
        public string CustomersJson = "";
        public string FeesSubjectJson = "";
        public string PaymentSystemJson = "";

        public bool IsVerify = false;//是否已审核

        public string format = "";//返回值格式,默认html
        public string tJson = "";

        //是否已审核超过48小时
        public bool IsVerifyLongTime = false;
        //是否审核超过6小时,审核反悔用
        public bool IsVerifyLongTimeB = false;
        
        //public DataTable BankList = new DataTable();//银行列表

        protected virtual void Page_Load(object sender, EventArgs e)
        {
            if (this.userid > 0)
            {
                /*
                CertificateDataJson cdj = new CertificateDataJson();
                CertificateDataInfo[] cdi = new CertificateDataInfo[1] ;
                cdi[0] = new CertificateDataInfo();
                cdi[0].cdAppendTime = DateTime.Now;
                
                cdj.CertificateDataInfoJson = cdi;
                CertificateDataJsonStr = JavaScriptConvert.SerializeObject(cdi);
                 */
                if (CheckUserPopedoms("X") || CheckUserPopedoms("6-5-1") || CheckUserPopedoms("6-5-2") || CheckUserPopedoms("6-5-3") || CheckUserPopedoms("6-5-4"))
                {
                    Act = HTTPRequest.GetString("Act");
                    OrderType = HTTPRequest.GetInt("OrderType", 0);
                    OrderID = HTTPRequest.GetInt("OrderID", 0);
                    string NewPIC = Utils.ChkSQL(HTTPRequest.GetString("NewPIC"));
                    cCode = Utils.ChkSQL(HTTPRequest.GetString("cCode"));
                    format = HTTPRequest.GetString("format");

                    #region 鉴权
                    if (CheckUserPopedoms("X") || CheckUserPopedoms("6-5-1") || CheckUserPopedoms("6-5-2") || CheckUserPopedoms("6-5-3") || CheckUserPopedoms("6-5-4") || CheckUserPopedoms("6-5-5") || CheckUserPopedoms("6-5-6"))
                    {
                        if (Act == "Add")
                        {
                            if (CheckUserPopedoms("X") || CheckUserPopedoms("6-5-1"))
                            {
                                
                            }
                            else
                            {
                                AddErrLine("权限不足,无法新建 凭证 列表!");
                            }
                        }
                        if (Act == "Edit" || Act=="View")
                        {
                            if (CheckUserPopedoms("X") || CheckUserPopedoms("6-5-2") || CheckUserPopedoms("6-5-3"))
                            {

                            }
                            else
                            {
                                AddErrLine("权限不足,无法新建 凭证 列表!");
                            }
                        }
                        //作废
                        if (Act == "i")
                        {
                            if (CheckUserPopedoms("X") || CheckUserPopedoms("6-5-4"))
                            {

                            }
                            else
                            {
                                AddErrLine("权限不足,无法新建 凭证 列表!");
                            }
                        }
                        //审核
                        if (Act == "s")
                        {
                            if (CheckUserPopedoms("X") || CheckUserPopedoms("6-5-5"))
                            {

                            }
                            else
                            {
                                AddErrLine("权限不足,无法新建 凭证 列表!");
                            }
                        }
                    }
                    #endregion

                    if (!IsErr())
                    {

                        if (Act == "Edit")
                        {
                            CertificateID = Utils.StrToInt(HTTPRequest.GetString("cid"), 0);

                            ci = Certificates.GetCertificateInfoModel(CertificateID);
                            cCode = ci.cCode;
                            cDateTime = ci.cDateTime;
                            cNumber = ci.cNumber;

                            IsVerify = ci.cSteps == 1;

                            if (IsVerify)
                            {

                                TimeSpan ts1=new TimeSpan(DateTime.Now.Ticks);
                                TimeSpan ts2 = new TimeSpan(Certificates.GetLastVerifyTime(CertificateID).Ticks);  
                                TimeSpan ts=ts1.Subtract(ts2).Duration();
                                
                                IsVerifyLongTime = ts.TotalHours > 48;
                                IsVerifyLongTimeB = ts.TotalHours > 6;
                            }

                            DataTable cdList = Certificates.GetCertificateDataInfoList(" cd.CertificateID = " + CertificateID + " order by cd.CertificateDataID asc").Tables[0];
                            if (cdList != null)
                            {
                                foreach (DataRow dr in cdList.Rows)
                                {
                                    CertificateDataJsonStr += "{\"CertificateDataID\":\"" + dr["CertificateDataID"].ToString() + "\",\"CertificateID\":\"" + dr["CertificateID"].ToString() + "\",\"FeesSubjectName\":\"" + dr["FeesSubjectName"].ToString() + "\",\"FeesSubjectID\":\"" + dr["FeesSubjectID"].ToString() + "\",\"cdName\":\"" + dr["cdName"].ToString() + "\",\"cdMoney\":\"" + dr["cdMoney"].ToString() + "\",\"cdMoneyB\":\"" + dr["cdMoneyB"].ToString() + "\",\"cdRemake\":\"" + dr["cdRemake"].ToString() + "\",\"cdAppendTime\":\"" + dr["cdAppendTime"].ToString() + "\",\"toObject\":\"" + dr["toObject"].ToString() + "\",\"toObjectID\":\"" + dr["toObjectID"].ToString() + "\",\"ObjectName\":\"" + dr["ObjectName"].ToString() + "\"},";
                                }
                            }
                            if (CertificateDataJsonStr.Trim() != "")
                            {
                                CertificateDataJsonStr = "{\"CertificateDataInfoJson\":[" + Utils.ReSQLSetTxt(CertificateDataJsonStr.Trim()) + "]}";
                            }

                            PicList = Certificates.GetCertificatePicInfoList(" CertificateID=" + CertificateID + " order by cAppendTime desc").Tables[0];
                        }
                        if (ispost)
                        {

                            //string cCode = Utils.ChkSQL(HTTPRequest.GetString("cCode"));
                            decimal cMoney = (HTTPRequest.GetString("cMoney").Trim() != "") ? Convert.ToDecimal(HTTPRequest.GetString("cMoney")) : 0;
                            int cType = HTTPRequest.GetInt("cType", 0);
                            int UserID = this.userid;
                            int StaffID = HTTPRequest.GetInt("StaffID", 0);
                            string cRemake = HTTPRequest.GetString("cRemake");
                            int toObject = HTTPRequest.GetInt("toObject", 0);
                            int toObjectID = HTTPRequest.GetInt("toObjectID", 0);
                            int cObject = HTTPRequest.GetInt("cObject", 0);
                            int cObjectID = HTTPRequest.GetInt("cObjectID", 0);
                            int cState = HTTPRequest.GetInt("cState", 0);
                            int BankID = HTTPRequest.GetInt("BankID", 0);
                            cNumber = HTTPRequest.GetInt("cNumber", 0);

                            cDateTime = (HTTPRequest.GetString("cDateTime").Trim() != "") ? Convert.ToDateTime(HTTPRequest.GetString("cDateTime")) : DateTime.Now;

                            string CertificateDataStr = Utils.ChkSQL(HTTPRequest.GetString("CertificateDataStr"));


                            ci.cMoney = cMoney;
                            ci.cType = cType;
                            ci.StaffID = StaffID;
                            ci.cRemake = cRemake;
                            ci.toObject = toObject;
                            ci.toObjectID = toObjectID;
                            ci.cObject = cObject;
                            ci.cObjectID = cObjectID;
                            ci.cState = cState;
                            ci.cDateTime = cDateTime;
                            ci.BankID = BankID;
                            

                            ci.CertificateDataJson = (CertificateDataJson)JavaScriptConvert.DeserializeObject(CertificateDataStr, typeof(CertificateDataJson));

                            if (Act == "Add")
                            {
                                if (CheckUserPopedoms("X") || CheckUserPopedoms("6-5-1"))
                                {
                                    ci.cSteps = 0;
                                    ci.UserID = UserID;
                                    ci.cAppendTime = DateTime.Now;
                                    ci.cCode = Certificates.GetNewNum(); //cCode;// 

                                    ci.cNumber = cNumber;
                                    if (!Certificates.CheckCertificateNumber(ci.cDateTime, ci.cNumber))
                                    {
                                        if (!Certificates.ExistsCertificateInfo(ci.cCode))
                                        {
                                            CertificateID = Certificates.AddCertificateInfo(ci);

                                            //添加凭证照片
                                            AddPic(NewPIC, CertificateID);

                                            CertificateWorkingLogInfo co = new CertificateWorkingLogInfo();
                                            co.CertificateID = CertificateID;
                                            co.UserID = this.userid;
                                            co.cType = 0;
                                            co.cAppendTime = DateTime.Now;
                                            Certificates.AddCertificateWorkingLog(co);

                                            AddMsgLine("凭证录入成功!");
                                            AddScript("window.setTimeout('window.parent.HidBox();',1000);");
                                        }
                                        else
                                        {
                                            AddErrLine("凭证编号重复,系统已存在该编号(" + ci.cCode + ")!");
                                        }
                                    }
                                    else
                                    {
                                        AddErrLine("凭证序号重复,系统已存在该序号(" + ci.cDateTime.ToString("yyyyMMdd") + "-" + (ci.cNumber.ToString()).PadLeft(config.CertificateCodeLen, '0') + ")!");
                                    }
                                }
                                else
                                {
                                    AddErrLine("权限不足!");
                                    AddScript("window.setTimeout('window.parent.HidBox();',1000);");
                                }
                            }
                            if (Act == "Edit")
                            {
                                if (CheckUserPopedoms("X") || CheckUserPopedoms("6-5-3"))
                                {
                                    if (ci.cNumber != cNumber)
                                    {
                                        if (!Certificates.CheckCertificateNumber(ci.cDateTime, cNumber))
                                        {
                                            ci.cNumber = cNumber;
                                        }
                                        else {
                                            AddErrLine("凭证序号重复,系统已存在该序号(" + ci.cDateTime.ToString("yyyyMMdd") + "-" + (cNumber.ToString()).PadLeft(config.CertificateCodeLen, '0') + ")!");
                                        }
                                    }

                                    if (!IsErr())
                                    {

                                        Certificates.UpdateCertificateInfo(ci);
                                        //添加凭证照片
                                        AddPic(NewPIC, CertificateID);

                                        CertificateWorkingLogInfo co = new CertificateWorkingLogInfo();
                                        co.CertificateID = CertificateID;
                                        co.UserID = this.userid;
                                        co.cType = 1;
                                        co.cAppendTime = DateTime.Now;
                                        Certificates.AddCertificateWorkingLog(co);

                                        AddMsgLine("凭证 " + ci.cDateTime.ToString("yyyyMMdd") + "-" + (ci.cNumber.ToString()).PadLeft(config.CertificateCodeLen, '0') + " 修改成功!");
                                        AddScript("window.setTimeout('location=\"/certificate_do-Edit-" + OrderType + "-" + OrderID + "-" + CertificateID + ".aspx\";',1000);");
                                    }
                                }
                                else
                                {
                                    AddErrLine("权限不足!");
                                    AddScript("window.setTimeout('window.parent.HidBox();',1000);");
                                }
                            }
                        }
                        else
                        {
                            if (format != "json")
                            {
                                //BankList = tbBankInfo.GetBankList("").Tables[0];
                                StaffList = Caches.GetDepartmentsClassInfoAndStaffListToHTML();
                                //FeesSubjectClassList = Caches.GetFeesSubjectClassInfoToHTML();
                                //string CustomersList = Caches.GetCustomersClassInfoAndDataToHTML();//客户
                                //string SupplierList = Caches.GetSupplierClassInfoAndDataToHTML();//供应商
                                //ToObjectList = "<ul><li rel=\"cus\">客户" + CustomersList + "</li>"+
                                //                        "<li rel=\"sup\">供应商" + SupplierList + "</li>" +
                                //                        "<li rel=\"sta\">人员" + StaffList + "</li>" +
                                //                        "</ul>";

                                DepartmentsJson = Caches.GetDepartmentsClassInfoToJson(-1, true, true);
                                SupplierJson = Caches.GetSupplierClassInfoToJson(-1, true, true);
                                CustomersJson = Caches.GetCustomersClassInfoToJson(-1, true, true);
                                FeesSubjectJson = Caches.GetFeesSubjectClassInfoToJson(-1, false, true);

                                PaymentSystemJson = Caches.GetPaymentSystemJson();
                                
                            }
                            if (Act == "Add")
                            {
                                cCode = "";// Certificates.GetNewNum();
                                cNumber = Certificates.GetCertificateNewNumber(cDateTime);
                            }
                            if(Act == "GetNum")
                            {
                                CertificateID = Utils.StrToInt(HTTPRequest.GetString("cid"), 0);
                                cDateTime = (HTTPRequest.GetString("cDateTime").Trim() != "") ? Convert.ToDateTime(HTTPRequest.GetString("cDateTime")) : DateTime.Now;
                                cNumber = Certificates.GetCertificateNewNumber(cDateTime);
                                tJson = ",\"MaxOrderDate\":\"" + Certificates.GetMaxCertificateData(CertificateID) + "\",\"Num\":" + cNumber;
                            }
                            //作废
                            if (Act == "i")
                            {
                                if (CheckUserPopedoms("X") || CheckUserPopedoms("6-5-4"))
                                {
                                    CertificateID = Utils.StrToInt(HTTPRequest.GetString("cid"), 0);
                                    
                                    if (CertificateID > 0)
                                    {
                                        ci = Certificates.GetCertificateInfoModel(CertificateID);
                                        if (ci != null)
                                        {
                                            ci.cState = 1;
                                            Certificates.UpdateCertificateInfo(ci);

                                            CertificateWorkingLogInfo co = new CertificateWorkingLogInfo();
                                            co.CertificateID = CertificateID;
                                            co.UserID = this.userid;
                                            co.cType = -1;
                                            co.cAppendTime = DateTime.Now;
                                            Certificates.AddCertificateWorkingLog(co);

                                            AddMsgLine("凭证 " + ci.cDateTime.ToString("yyyyMMdd") + "-" + (ci.cNumber.ToString()).PadLeft(config.CertificateCodeLen, '0') + " 作废成功!");
                                        }
                                        else
                                        {
                                            AddErrLine("凭证不存在!");
                                        }
                                    }
                                    else
                                    {
                                        AddErrLine("参数错误!");
                                    }
                                }
                                else
                                {
                                    AddErrLine("权限不足!");
                                    AddScript("window.setTimeout('window.parent.HidBox();',1000);");
                                }
                            }
                            //审核
                            if (Act == "s")
                            {
                                if (CheckUserPopedoms("X") || CheckUserPopedoms("6-5-5"))
                                {
                                    CertificateID = Utils.StrToInt(HTTPRequest.GetString("cid"), 0);
                                    if (CertificateID > 0)
                                    {
                                        ci = Certificates.GetCertificateInfoModel(CertificateID);
                                        if (ci != null)
                                        {
                                            Certificates.SetCertificateSteps(CertificateID, 1);

                                            CertificateWorkingLogInfo co = new CertificateWorkingLogInfo();
                                            co.CertificateID = CertificateID;
                                            co.UserID = this.userid;
                                            co.cType = 2;
                                            co.cAppendTime = DateTime.Now;
                                            Certificates.AddCertificateWorkingLog(co);

                                            AddMsgLine("凭证 " + ci.cDateTime.ToString("yyyyMMdd") + "-" + (ci.cNumber.ToString()).PadLeft(config.CertificateCodeLen, '0') + " 审核成功!");
                                        }
                                        else
                                        {
                                            AddErrLine("凭证不存在!");
                                        }
                                    }
                                    else
                                    {
                                        AddErrLine("参数错误!");
                                    }
                                }
                                else
                                {
                                    AddErrLine("权限不足!");
                                }
                            }
                            //撤回重审
                            if(Act=="rs")
                            {
                                if (CheckUserPopedoms("X") || CheckUserPopedoms("6-5-7") || CheckUserPopedoms("6-5-8"))
                                {
                                    CertificateID = Utils.StrToInt(HTTPRequest.GetString("cid"), 0);
                                    if (CertificateID > 0)
                                    {
                                        ci = Certificates.GetCertificateInfoModel(CertificateID);
                                        if (ci != null)
                                        {
                                            Certificates.SetCertificateSteps(CertificateID, 0);

                                            CertificateWorkingLogInfo co = new CertificateWorkingLogInfo();
                                            co.CertificateID = CertificateID;
                                            co.UserID = this.userid;
                                            co.cType = 4;
                                            co.cAppendTime = DateTime.Now;
                                            Certificates.AddCertificateWorkingLog(co);

                                            AddMsgLine("凭证 " + ci.cDateTime.ToString("yyyyMMdd") + "-" + (ci.cNumber.ToString()).PadLeft(config.CertificateCodeLen, '0') + " 撤回成功!");
                                        }
                                        else
                                        {
                                            AddErrLine("凭证不存在!");
                                        }
                                    }
                                    else
                                    {
                                        AddErrLine("参数错误!");
                                    }
                                }
                                else
                                {
                                    AddErrLine("权限不足!");
                                }
                            }
                            //获取指定凭证前后两个凭证信息
                            if(Act=="p")
                            {
                                if (CheckUserPopedoms("X") || CheckUserPopedoms("6-5-2"))
                                {
                                    CertificateID = Utils.StrToInt(HTTPRequest.GetString("cid"), 0);
                                    if (CertificateID > 0)
                                    {
                                        long[] UpDownID = Certificates.GetCertificateUpDownID(CertificateID);
                                        tJson = ",\"UpDownID\":{\"UpID\":\"" + UpDownID[0] + "\",\"DownID\":\"" + UpDownID[1] + "\"}";
                                    }
                                    else
                                    {
                                        AddErrLine("参数错误!");
                                    }
                                }
                                else {
                                    AddErrLine("权限不足!");
                                }
                            }
                        }
                    }
                }
                else
                {
                    AddErrLine("权限不足!");
                }
            }
            else
            {
                AddErrLine("请先登录!");
                SetBackLink("login.aspx?referer=" + Utils.UrlEncode(Utils.GetUrlReferrer()));
                SetMetaRefresh(1, "login.aspx?referer=" + Utils.UrlEncode(Utils.GetUrlReferrer()));
            }
            if (format == "json")
            {
                Response.ClearContent();
                Response.Buffer = true;
                Response.ExpiresAbsolute = System.DateTime.Now.AddYears(-1);
                Response.Expires = 0;

                Response.Charset = "utf-8";
                Response.ContentEncoding = System.Text.Encoding.GetEncoding("utf-8");
                Response.ContentType = "application/json";
                string Json_Str = "{\"results\": {\"msg\":\"" + this.msgbox_text + "\",\"state\":\"" + (!IsErr()).ToString() + "\"" + tJson + "}}";
                Response.Write(Json_Str);
                Response.End();
            }
        }
        protected override void ShowPage()
        {
            pagetitle = " 凭证录入";
            this.Load += new EventHandler(this.Page_Load);
        }
        /// <summary>
        /// 添加新照片
        /// </summary>
        /// <param name="NewPIC"></param>
        /// <param name="CertificateID"></param>
        private void AddPic(string NewPIC, int CertificateID)
        {
            if (NewPIC.Trim() != "")
            {
                string[] NewPICArr = Utils.SplitString(NewPIC, ",");
                foreach (string _NewPIC in NewPICArr)
                {
                    if (_NewPIC.Trim() != "")
                    {
                        Certificates.UpdateCertificatePicCertificateID(Convert.ToInt32(_NewPIC), CertificateID);
                    }
                }
            }
        }
    }
}