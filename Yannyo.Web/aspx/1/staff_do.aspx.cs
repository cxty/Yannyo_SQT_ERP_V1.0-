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
using Newtonsoft.Json.Converters;

namespace Yannyo.Web
{
    public partial class staff_do : PageBase
    {
        public StaffInfo si = new StaffInfo();
        public StaffDataInfo sd = new StaffDataInfo();
        public StaffAnalysisDataInfo sad = new StaffAnalysisDataInfo();
        public string Act = "";
        public int StaffID = 0;
        public string sName = "";
        public string sSex = "";
        public string sTel = "";
        public string sCarID = "";
        public int sType = 0;
        public int sState = 0;
        public string sEmail = "";
        public int DepartmentsClassID = 0;
        public DateTime sAppendTime = DateTime.Now;
        public string DepartmentsClass = "";

        public string EduDataListJson = "";
        public string WorkDataListJson = "";
        public string FamilyDataListJson = "";

        public DataTable EduDataList = new DataTable();
        public DataTable StaffWorkDataList = new DataTable();
        public DataTable StaffFamilyDataList = new DataTable();
        public string ucode = "";

        public string format = "";
        public string tJson = "";

        protected virtual void Page_Load(object sender, EventArgs e)
        {
            if (this.userid > 0)
            {
                if (CheckUserPopedoms("X") || CheckUserPopedoms("4-1"))
                {
                    ucode = DES.Encode(this.userinfo.uName + "|" + UsersUtils.GetCookiePassword(config.Passwordkey), config.Passwordkey);
                    Act = HTTPRequest.GetString("Act");
                    StaffID = Utils.StrToInt(HTTPRequest.GetString("sid"), 0);
                    format = HTTPRequest.GetString("format");
                    if (Act == "Edit")
                    {
                        si = tbStaffInfo.GetStaffInfoModel(StaffID);

                        sd = tbStaffInfo.GetStaffDataInfoModelByStaffID(StaffID);

                        if (sd != null)
                        { 
                            sd.sBirthDay = sd.sBirthDay!=null?sd.sBirthDay:"";
                            sd.sPolitical = sd.sPolitical != null ? sd.sPolitical : "";
                            sd.sBirthplace = sd.sBirthplace != null ? sd.sBirthplace : "";
                            sd.sHometown = sd.sHometown != null ? sd.sHometown : "";
                            sd.sEducation = sd.sEducation != null ? sd.sEducation : "";
                            sd.sProfessional = sd.sProfessional != null ? sd.sProfessional : "";
                            sd.sHealth = sd.sHealth != null ? sd.sHealth : "";

                            sd.sSpecialty = sd.sSpecialty != null ? sd.sSpecialty : "";
                            sd.sHobbies = sd.sHobbies != null ? sd.sHobbies : "";
                            sd.sContactAddress = sd.sContactAddress != null ? sd.sContactAddress : "";
                            sd.sPhotos = sd.sPhotos != null ? sd.sPhotos : "";

                            sd.sCanBeDate = sd.sCanBeDate != null ? sd.sCanBeDate : "";

                        }

                        sad = tbStaffInfo.GetStaffAnalysisDataInfoModelByStaffID(StaffID);
                        if (sad != null)
                        {
                            
                            sad.aEvaluationMSG = sad.aEvaluationMSG != null ? sad.aEvaluationMSG : "";

                        }
                    }
                    //修改状体
                    if(Act == "State")
                    {
                        si = tbStaffInfo.GetStaffInfoModel(StaffID);
                        tJson = ",\"StaffID\":" + StaffID + "";
                        if (si != null)
                        {
                            si.sState = (si.sState == 0 ? 1 : 0);
                            tbStaffInfo.UpdateStaffInfo(si);
                            Logs.AddEventLog(this.userid, "修改人员状态." +si.sName);
                            tJson += ",\"StaffState\":" + si.sState;
                            AddMsgLine("修改成功!");
                        }
                        else {
                            AddErrLine("修改失败,对象不存在!");
                        }
                    }
                    if (ispost)
                    {
                        sName = Utils.ChkSQL(HTTPRequest.GetString("sName"));
                        sSex = Utils.ChkSQL(HTTPRequest.GetString("sSex"));
                        sTel = Utils.ChkSQL(HTTPRequest.GetString("sTel"));
                        sCarID = Utils.ChkSQL(HTTPRequest.GetString("sCarID"));
                        sType = Utils.StrToInt(HTTPRequest.GetString("sType"), 0);
                        sEmail = Utils.ChkSQL(HTTPRequest.GetString("sEmail"));
                        DepartmentsClassID = Utils.StrToInt(HTTPRequest.GetString("DepartmentsClassID"), 0);
                        sState = HTTPRequest.GetString("sState").Trim() != "" ? Utils.StrToInt(HTTPRequest.GetString("sState"), 0) : 1;

                        si.sSex = sSex;
                        si.sTel = sTel;
                        si.sCarID = sCarID;
                        si.sType = sType;
                        si.sState = sState;
                        si.sEmail = sEmail;
                        si.DepartmentsClassID = DepartmentsClassID;

                        sd = sd != null ? sd : new StaffDataInfo();

                        sd.sBirthDay = Utils.ChkSQL(HTTPRequest.GetString("sBirthDay"));
                        sd.sPolitical = Utils.ChkSQL(HTTPRequest.GetString("sPolitical"));
                        sd.sBirthplace = Utils.ChkSQL(HTTPRequest.GetString("sBirthplace"));
                        sd.sHometown = Utils.ChkSQL(HTTPRequest.GetString("sHometown"));
                        sd.sEducation = Utils.ChkSQL(HTTPRequest.GetString("sEducation"));
                        sd.sProfessional = Utils.ChkSQL(HTTPRequest.GetString("sProfessional"));
                        sd.sHealth = Utils.ChkSQL(HTTPRequest.GetString("sHealth"));
                        sd.sHeight = HTTPRequest.GetInt("sHeight", 0);
                        sd.sWeight = HTTPRequest.GetInt("sWeight", 0);
                        sd.sSpecialty = Utils.ChkSQL(HTTPRequest.GetString("sSpecialty"));
                        sd.sHobbies = Utils.ChkSQL(HTTPRequest.GetString("sHobbies"));
                        sd.sContactAddress = Utils.ChkSQL(HTTPRequest.GetString("sContactAddress"));
                        sd.sPhotos = Utils.ChkSQL(HTTPRequest.GetString("sPhotos"));
                        sd.sEmployment = HTTPRequest.GetInt("sEmployment", 0);
                        sd.sCanBeDate = Utils.ChkSQL(HTTPRequest.GetString("sCanBeDate"));
                        sd.sTreatment = HTTPRequest.GetInt("sTreatment", 0);

                        sad = sad != null ? sad : new StaffAnalysisDataInfo();

                        sad.aWearing= HTTPRequest.GetInt("aWearing", 0);
                        sad.aEducation= HTTPRequest.GetInt("aEducation", 0);
                        sad.aWork= HTTPRequest.GetInt("aWork", 0);
                        sad.aCommunication= HTTPRequest.GetInt("aCommunication", 0);
                        sad.aConfidence= HTTPRequest.GetInt("aConfidence", 0);
                        sad.aLeadership= HTTPRequest.GetInt("aLeadership", 0);
                        sad.aJobstability= HTTPRequest.GetInt("aJobstability", 0);
                        sad.aComputer= HTTPRequest.GetInt("aComputer", 0);
                        sad.aEnglish= HTTPRequest.GetInt("aEnglish", 0);
                        sad.aWritten= HTTPRequest.GetInt("aWritten", 0);
                        sad.aEvaluation= HTTPRequest.GetInt("aEvaluation", 0);
                        sad.aEvaluationMSG = Utils.ChkSQL(HTTPRequest.GetString("aEvaluationMSG"));
                        try
                        {
                            sad.aDateTime = Utils.IsDateString(HTTPRequest.GetString("aDateTime")) ? DateTime.Parse(HTTPRequest.GetString("aDateTime").Trim()) : DateTime.Now;
                        }
                        catch {
                            sad.aDateTime = DateTime.Now;
                        }

                        EduDataListJson = HTTPRequest.GetString("EduDataListJson");
                        WorkDataListJson = HTTPRequest.GetString("WorkDataListJson");
                        FamilyDataListJson = HTTPRequest.GetString("FamilyDataListJson");

                        if (Act == "Add")
                        {
                            if (!tbStaffInfo.ExistsStaffInfo(sName))
                            {
                                si.sName = sName;
                                si.sAppendTime = sAppendTime;
                                StaffID = tbStaffInfo.AddStaffInfo(si);
                                if (StaffID > 0)
                                {

                                    sd.StaffID = StaffID;

                                    tbStaffInfo.AddStaffDataInfo(sd);

                                    sad.StaffID = StaffID;
                                    sad.aAppendTime = DateTime.Now;

                                    tbStaffInfo.AddStaffAnalysisDataInfo(sad);

                                    if (EduDataListJson.Trim() != "")
                                    {
                                        StaffEduDataJson EduDataJson = (StaffEduDataJson)JavaScriptConvert.DeserializeObject(EduDataListJson, typeof(StaffEduDataJson));

                                        tbStaffInfo.AddStaffEduDataInfoByJson(EduDataJson);
                                    }
                                    if (WorkDataListJson.Trim() != "")
                                    {
                                        StaffWorkDataJson WorkDataJson = (StaffWorkDataJson)JavaScriptConvert.DeserializeObject(WorkDataListJson, typeof(StaffWorkDataJson));

                                        tbStaffInfo.AddStaffWorkDataInfoByJson(WorkDataJson);
                                    }
                                    if (FamilyDataListJson.Trim() != "")
                                    {
                                        StaffFamilyDataJson FamilyDataJson = (StaffFamilyDataJson)JavaScriptConvert.DeserializeObject(FamilyDataListJson, typeof(StaffFamilyDataJson));

                                        tbStaffInfo.AddStaffFamilyDataInfoByJson(FamilyDataJson);
                                    }
                                    Logs.AddEventLog(this.userid, "新增人员." + si.sName);
                                    AddMsgLine("创建成功!");
                                    AddScript("window.setTimeout('window.parent.HidBox();',1000);");
                                }
                                else
                                {
                                    AddErrLine("创建失败!");
                                    AddScript("window.setTimeout('history.back(1);',1000);");
                                }
                            }
                            else
                            {
                                AddErrLine("人员:" + sName + ",已存在,请更换!");
                                AddScript("window.setTimeout('history.back(1);',3000);");
                            }
                        }
                        if (Act == "Edit")
                        {
                            bool nOK = false;
                            if (si.sName.Trim() != sName.Trim())
                            {
                                if (!tbStaffInfo.ExistsStaffInfo(sName.Trim()))
                                {
                                    nOK = true;
                                }
                                else
                                {
                                    nOK = false;
                                    AddErrLine("人员:" + sName + ",已存在,请更换!");
                                    AddScript("window.setTimeout('history.back(1);',3000);");
                                }
                            }
                            else
                            {
                                nOK = true;
                            }
                            if (nOK)
                            {
                                try
                                {
                                    si.sName = sName;

                                    tbStaffInfo.UpdateStaffInfo(si);

                                    if (sd.StaffID > 0)
                                    {
                                        tbStaffInfo.UpdateStaffDataInfo(sd);
                                    }
                                    else
                                    {
                                        sd.StaffID = StaffID;

                                        tbStaffInfo.AddStaffDataInfo(sd);
                                    }

                                    if (sad.StaffID > 0)
                                    {
                                        tbStaffInfo.UpdateStaffAnalysisDataInfo(sad);
                                    }
                                    else
                                    {
                                        sad.StaffID = StaffID;
                                        sad.aAppendTime = DateTime.Now;

                                        tbStaffInfo.AddStaffAnalysisDataInfo(sad);
                                    }

                                    if (EduDataListJson.Trim() != "")
                                    {
                                        StaffEduDataJson EduDataJson = (StaffEduDataJson)JavaScriptConvert.DeserializeObject(EduDataListJson, typeof(StaffEduDataJson));

                                        tbStaffInfo.UpdateStaffEduDataInfoByJson(EduDataJson, StaffID);
                                    }
                                    if (WorkDataListJson.Trim() != "")
                                    {
                                        StaffWorkDataJson WorkDataJson = (StaffWorkDataJson)JavaScriptConvert.DeserializeObject(WorkDataListJson, typeof(StaffWorkDataJson));

                                        tbStaffInfo.UpdateStaffWorkDataInfoByJson(WorkDataJson, StaffID);
                                    }
                                    if (FamilyDataListJson.Trim() != "")
                                    {
                                        StaffFamilyDataJson FamilyDataJson = (StaffFamilyDataJson)JavaScriptConvert.DeserializeObject(FamilyDataListJson, typeof(StaffFamilyDataJson));

                                        tbStaffInfo.UpdateStaffFamilyDataInfoByJson(FamilyDataJson, StaffID);
                                    }

                                    Logs.AddEventLog(this.userid, "修改人员." +si.sName);
                                    AddMsgLine("修改成功!");
                                    AddScript("window.setTimeout('window.parent.HidBox();',1000);");
                                }
                                catch (Exception ex)
                                {
                                    AddErrLine("修改失败!<br/>" + ex);
                                    //AddScript("window.setTimeout('window.parent.HidBox();',1000);");
                                }
                            }
                        }
                        Caches.ReSet();
                    }
                    else
                    {
                        DepartmentsClass = Caches.GetDepartmentsClassInfoToHTML();
                        if (Act == "Add")
                        {
                            si.sName = "";
                            si.sSex = "男";
                            si.sState = 0;
                            si.sType = 0;
                        }
                        if(Act== "Edit")
                        {
                            EduDataListJson = "";
                            WorkDataListJson = "";
                            FamilyDataListJson = "";

                             EduDataList = tbStaffInfo.GetStaffEduDataInfoList(" StaffID=" + StaffID + " order by StaffEduDataID desc").Tables[0];
                             StaffWorkDataList = tbStaffInfo.GetStaffWorkDataInfoList(" StaffID=" + StaffID + " order by StaffWorkDataID desc").Tables[0];
                             StaffFamilyDataList = tbStaffInfo.GetStaffFamilyDataInfoList(" StaffID=" + StaffID + " order by StaffFamilyDataID desc").Tables[0];
                            try {
                                foreach(DataRow dr in EduDataList.Rows)
                                {
                                    EduDataListJson += "{\"StaffEduDataID\":\"" + dr["StaffEduDataID"].ToString() + "\",\"StaffID\":\"" + dr["StaffID"].ToString() + "\",\"eDate\":\"" + dr["eDate"].ToString() + "\",\"eSchools\":\"" + dr["eSchools"].ToString().Replace("\"", "\\\"") + "\",\"eContent\":\"" + dr["eContent"].ToString().Replace("\"", "\\\"") + "\"},";
                                }
                                if (EduDataListJson.Trim() != "")
                                {
                                    EduDataListJson = EduDataListJson.Substring(0, EduDataListJson.Length - 1);
                                }
                                EduDataListJson = "{\"EduDataList\":[" + EduDataListJson + "]}";

                                foreach (DataRow dr in StaffWorkDataList.Rows)
                                {
                                    WorkDataListJson += "{\"StaffWorkDataID\":\"" + dr["StaffWorkDataID"].ToString() + "\",\"StaffID\":\"" + dr["StaffID"].ToString() + "\",\"wDate\":\"" + dr["wDate"].ToString() + "\",\"wEnterprise\":\"" + dr["wEnterprise"].ToString().Replace("\"", "\\\"") + "\",\"wTel\":\"" + dr["wTel"].ToString().Replace("\"", "\\\"") + "\",\"wJobs\":\"" + dr["wJobs"].ToString().Replace("\"", "\\\"") + "\",\"wIncome\":\"" + dr["wIncome"].ToString().Replace("\"", "\\\"") + "\"},";
                                }
                                if (WorkDataListJson.Trim() != "")
                                {
                                    WorkDataListJson = WorkDataListJson.Substring(0, WorkDataListJson.Length - 1);
                                }
                                WorkDataListJson = "{\"WorkDataList\":[" + WorkDataListJson + "]}";

                                foreach (DataRow dr in StaffFamilyDataList.Rows)
                                {
                                    FamilyDataListJson += "{\"StaffFamilyDataID\":\"" + dr["StaffFamilyDataID"].ToString() + "\",\"StaffID\":\"" + dr["StaffID"].ToString() + "\",\"fTitle\":\"" + dr["fTitle"].ToString() + "\",\"fName\":\"" + dr["fName"].ToString().Replace("\"", "\\\"") + "\",\"fAge\":\"" + dr["fAge"].ToString().Replace("\"", "\\\"") + "\",\"fEnterprise\":\"" + dr["fEnterprise"].ToString().Replace("\"", "\\\"") + "\",\"fWork\":\"" + dr["fWork"].ToString().Replace("\"", "\\\"") + "\",\"fAddress\":\"" + dr["fAddress"].ToString().Replace("\"", "\\\"") + "\",\"fTel\":\"" + dr["fTel"].ToString().Replace("\"", "\\\"") + "\"},";
                                }
                                if (FamilyDataListJson.Trim() != "")
                                {
                                    FamilyDataListJson = FamilyDataListJson.Substring(0, FamilyDataListJson.Length - 1);
                                }
                                FamilyDataListJson = "{\"FamilyDataList\":[" + FamilyDataListJson + "]}";
                            }
                            finally {
                                EduDataList = null;
                                StaffWorkDataList = null;
                                StaffFamilyDataList = null;
                            }
                        }

                        if (Act == "Del")
                        {
                            try
                            {
                                tbStaffInfo.DeleteStaffInfo(HTTPRequest.GetString("sid"));
                                Logs.AddEventLog(this.userid, "删除人员." + HTTPRequest.GetString("sid"));
                                AddMsgLine("删除成功!");
                                AddScript("window.setTimeout('window.parent.HidBox();',1000);");
                            }
                            catch (Exception ex)
                            {
                                AddErrLine("删除失败!<br/>" + ex);
                                AddScript("window.setTimeout('window.parent.HidBox();',1000);");
                            }
                        }
                    }
                }
                else
                {
                    AddErrLine("权限不足!");
                    AddScript("window.setTimeout('window.parent.HidBox();',1000);");
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
            pagetitle = " 添加修改人员信息";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}
