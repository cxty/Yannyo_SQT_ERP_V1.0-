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

namespace Yannyo.Web
{
    public partial class feessubject_do : PageBase
    {
        public FeesSubjectInfo FeesSubject = new FeesSubjectInfo();
        public string Act = "";
        public int FeesSubjectID = 0;
        public int FeesSubjectClassID = 0;
        public string fCode = "";
        public int fDebitCredit = 0;
        public string fName = "";
        public DateTime fAppendTime = DateTime.Now;
        public string FeesSubjectClass = "";
        protected virtual void Page_Load(object sender, EventArgs e)
        {
            if (this.userid > 0)
            {
                if (CheckUserPopedoms("X") || CheckUserPopedoms("1"))
                {
                    Act = HTTPRequest.GetString("Act");
                    FeesSubjectClass = Caches.GetFeesSubjectClassInfoToHTML();
                    fName = Utils.ChkSQL(HTTPRequest.GetString("fName"));
                    FeesSubjectClassID = HTTPRequest.GetInt("FeesSubjectClassID", 0);
                    fCode = Utils.ChkSQL(HTTPRequest.GetString("fCode"));
                    fDebitCredit = HTTPRequest.GetInt("fDebitCredit", 0);
                    if (Act == "Edit")
                    {
                        FeesSubjectID = Utils.StrToInt(HTTPRequest.GetString("fid"), 0);

                        FeesSubject = tbFeesSubjectInfo.GetFeesSubjectInfoModel(FeesSubjectID);
                    }
                    if (ispost)
                    {
                        FeesSubject.FeesSubjectClassID = FeesSubjectClassID;
                        FeesSubject.fCode = fCode;
                        FeesSubject.fDebitCredit = fDebitCredit;
                        if (Act == "Add")
                        {
                            if (!tbFeesSubjectInfo.ExistsFeesSubjectInfo(fName))
                            {
                                FeesSubject.fName = fName;
                                FeesSubject.fAppendTime = fAppendTime;

                                if (tbFeesSubjectInfo.AddFeesSubjectInfo(FeesSubject) > 0)
                                {
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
                                AddErrLine("费用科目:" + fName + ",已存在,请更换!");
                                AddScript("window.setTimeout('history.back(1);',1000);");
                            }
                        }
                        if (Act == "Edit")
                        {
                            if (FeesSubjectID > 0)
                            {
                                if (!tbFeesSubjectInfo.ExistsFeesSubjectInfo(fName) || FeesSubject.fName == fName)
                                {
                                    FeesSubject.fName = fName;
                                    try
                                    {
                                        tbFeesSubjectInfo.UpdateFeesSubjectInfo(FeesSubject);
                                        AddMsgLine("修改成功!");
                                        AddScript("window.setTimeout('window.parent.HidBox();',1000);");
                                    }
                                    catch (Exception ex)
                                    {
                                        AddErrLine("修改失败!<br/>" + ex);
                                        AddScript("window.setTimeout('window.parent.HidBox();',1000);");
                                    }
                                }
                                else
                                {
                                    AddErrLine("费用科目:" + fName + ",已存在,请更换!");
                                    AddScript("window.setTimeout('history.back(1);',1000);");
                                }
                            }
                            else
                            {
                                AddErrLine("参数错误,修改失败!");
                                AddScript("window.setTimeout('window.parent.HidBox();',1000);");
                            }
                        }
                    }
                    else
                    {
                        if (Act == "Add")
                        {
                            FeesSubject.fName = "";
                        }

                        if (Act == "Del")
                        {
                            try
                            {
                                tbFeesSubjectInfo.DeleteFeesSubjectInfo(HTTPRequest.GetString("fid"));
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
        }
        protected override void ShowPage()
        {
            pagetitle = " 添加修改费用科目信息";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}
