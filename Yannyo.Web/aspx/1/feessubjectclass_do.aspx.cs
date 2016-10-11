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
using Yannyo.Cache;
using Yannyo.Common;
using Yannyo.Entity;
using Yannyo.BLL;

namespace Yannyo.Web
{
    public partial class feessubjectclass_do : PageBase
    {
        public FeesSubjectClassInfo FeesSubjectClass = new FeesSubjectClassInfo();
        public int FeesSubjectClassID = 0;
        public string Act = "";
        public DataTable dList = new DataTable();
        public string FeesSubjectClassPaterStr = "";
        public string reformat = "";//返回格式
        public string reVal = "";
        public string lastName = "";//修改前的名称
        protected virtual void Page_Load(object sender, EventArgs e)
        {
            if (this.userid > 0)
            {
                if (CheckUserPopedoms("X") || CheckUserPopedoms("6-1-1"))
                {
                    reformat = HTTPRequest.GetString("reformat");
                    Act = HTTPRequest.GetString("Act");
                    FeesSubjectClassID = HTTPRequest.GetInt("FeesSubjectClassID", 0);

                    string cClassName = HTTPRequest.GetString("cClassName").Trim();
                    int cParentID = HTTPRequest.GetInt("cParentID",0);
                    int cOrder = HTTPRequest.GetInt("cOrder", 0);
                    int cDirection = HTTPRequest.GetInt("cDirection", 0);
                    string cCode = HTTPRequest.GetString("cCode").Trim();
                    int cType = HTTPRequest.GetInt("cType", 0);
                    lastName = HTTPRequest.GetString("lastName").Trim();
                    

                    if (Act =="Edit")
                    {
                        if (FeesSubjectClassID > 0)
                        {
                            FeesSubjectClass = DataClass.GetFeesSubjectClassInfoModel(FeesSubjectClassID);
                            if (FeesSubjectClass != null)
                            {

                            }
                            else
                            {
                                AddErrLine("参数错误,系统没有该科目!");
                            }
                        }
                        else {
                            AddErrLine("参数错误!");
                        }
                    }

                    if (ispost)
                    {
                        
                        FeesSubjectClass.cOrder = cOrder;
                        FeesSubjectClass.cDirection = cDirection;
                       
                        FeesSubjectClass.cType = cType;

                        if (Act == "Edit")
                        {
                           // FeesSubjectClass.cParentID = HTTPRequest.GetFormInt("cParentID",0);
                           // reVal = ",\"ReValue\":{\"ParentID\":\"" + FeesSubjectClass.cParentID + "\"}";

                            if (cCode != FeesSubjectClass.cCode ? !DataClass.ExistsFeesSubjectClassInfoByCode(cCode):true)
                            {
                                if ((cClassName != FeesSubjectClass.cClassName) ? !DataClass.ExistsFeesSubjectClassInfo(cClassName, cParentID):true)
                                {
                                    FeesSubjectClass.cCode = cCode;
                                    FeesSubjectClass.cClassName = cClassName;

                                    DataClass.UpdateFeesSubjectClassInfo(FeesSubjectClass);

                                    //记录修改操作
                                    Logs.AddEventLog(this.userid, "将" + lastName + "科目修改为" + cClassName);
                                    AddMsgLine("修改成功!");
                                    AddScript("window.setTimeout('window.parent.HidBox();',1000);");
                                }
                                else
                                {
                                    AddErrLine("科目名称:" + cClassName + ",系统已经存在,无法修改!");
                                }
                            }
                            else
                            {
                                AddErrLine("科目编号:" + cCode + ",系统已经存在,无法修改!");
                            }
                        }
                        if (Act == "Add")
                        {
                            FeesSubjectClass.cParentID = HTTPRequest.GetFormInt("cParentID", 0);
                            FeesSubjectClass.cAppendTime = DateTime.Now;
                            reVal = ",\"ReValue\":{\"ParentID\":\"" + FeesSubjectClass.cParentID + "\"}";

                            if (!DataClass.ExistsFeesSubjectClassInfo(cClassName, cParentID))
                            {
                                if (!DataClass.ExistsFeesSubjectClassInfoByCode(cCode))
                                {
                                    FeesSubjectClass.cCode = cCode;
                                    FeesSubjectClass.cClassName = cClassName;

                                    DataClass.AddFeesSubjectClassInfo(FeesSubjectClass);
                                    //记录成功操作
                                    Logs.AddEventLog(this.userid, "添加" + cClassName + "科目分类");
                                    AddMsgLine("添加成功!");
                                    AddScript("window.setTimeout('window.parent.HidBox();',1000);");
                                }
                                else
                                {
                                    AddErrLine("科目编号:" + cCode + ",系统已经存在,无法添加!");
                                }
                            }
                            else
                            {
                                AddErrLine("科目名称:" + cClassName + ",系统已经存在,无法添加!");
                            }
                        }
                    }
                    else {
                        dList = DataClass.GetFeesSubjectClassType();
                        if (Act == "Add")
                        {
                            if (cParentID > 0)
                            {
                                FeesSubjectClassPaterStr = DataClass.GetFeesSubjectClassPaterStr(cParentID);
                            }
                        }
                        if (Act == "Edit")
                        {
                            if (FeesSubjectClassID > 0)
                            {
                                FeesSubjectClassPaterStr = DataClass.GetFeesSubjectClassPaterStr(FeesSubjectClassID);
                            }
                        }
                    }
                }
                else
                {
                    AddErrLine("权限不足!");
                    AddScript("window.parent.HidBox();");
                }
            }
            else
            {
                AddErrLine("请先登录!");
                SetBackLink("login.aspx?referer=" + Utils.UrlEncode(Utils.GetUrlReferrer()));
                SetMetaRefresh(1, "login.aspx?referer=" + Utils.UrlEncode(Utils.GetUrlReferrer()));
            }
            if (reformat == "json")
            {
                Response.ClearContent();
                Response.Buffer = true;
                Response.ExpiresAbsolute = System.DateTime.Now.AddYears(-1);
                Response.Expires = 0;

                Response.Charset = "utf-8";
                Response.ContentEncoding = System.Text.Encoding.GetEncoding("utf-8");
                Response.ContentType = "application/json";
                string Json_Str = "{\"results\": {\"msg\":\"" + this.msgbox_text + "\",\"state\":\"" + (!IsErr()).ToString() + "\"" + reVal + "}}";
                Response.Write(Json_Str);
                Response.End();
            }
        }
        protected override void ShowPage()
        {
            pagetitle = " 科目";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}