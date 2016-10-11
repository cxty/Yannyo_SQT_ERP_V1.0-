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
    public partial class feessubjectclass_do_move : PageBase
    {
        public string sName = "";//节点名称
        public int sID;//节点编号
        public DataTable cList = new DataTable();
        public string FeesSubjectJson = "";
        //更新
        public string certificateID = "";//凭证编号
        public int classID;//科目编号
        public string lastName = "";//移动前的科目名称
        public string FeesSubjectName = "";//移动至某个科目下
        protected virtual void Page_Load(object sender, EventArgs e)
        {
            if (this.userid > 0)
            {
                if (CheckUserPopedoms("X") || CheckUserPopedoms("6-1-3"))
                {
                    FeesSubjectJson = Caches.GetFeesSubjectClassInfoToJson(-1, false, true);
                    sName = HTTPRequest.GetString("sName").Trim();
                    sID = HTTPRequest.GetInt("FeesSubjectClassID",0);
                   

                    if (ispost)
                    {
                        certificateID = HTTPRequest.GetString("Content");
                        classID = HTTPRequest.GetInt("treeNode", -1);
                        lastName = HTTPRequest.GetString("lastName").Trim();
                        FeesSubjectName = HTTPRequest.GetString("getTreeName").Trim();

                        if (certificateID != "")
                        {
                            if (classID > -1)
                            {
                                int uState = DataClass.updateCertificateToFeessubjects(certificateID, classID, HTTPRequest.GetInt("sFeeID", 0));
                                if (uState > 0)
                                {
                                    //记录修改操作
                                    Logs.AddEventLog(this.userid, "将" + lastName + "科目下凭证移动至" + FeesSubjectName);
                                    Response.Write(uState);
                                    Response.End();
                                }
                                else
                                {
                                    Response.Write("0");
                                    Response.End();
                                }

                            }
                            else
                            {
                                AddErrLine("请核对选中的科目信息!");
                            }
                        }
                        else
                        {
                            AddErrLine("请核对选中的凭证信息!");
                        }
                    }
                    else
                    {
                        cList = DataClass.getCertificateDate(sID);
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
        }
        protected override void ShowPage()
        {
            pagetitle = "科目数据批量转移";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}