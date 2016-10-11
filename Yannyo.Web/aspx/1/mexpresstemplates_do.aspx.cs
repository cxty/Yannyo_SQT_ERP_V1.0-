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
    public partial class mexpresstemplates_do : MPageBase
    {
        public string Act = "";
        public int m_ExpressTemplatesID = 0;
        public string PublicExpressTemplatesJson = "";
        public M_ExpressTemplatesInfo ExpressTemplates = new M_ExpressTemplatesInfo();
        protected virtual void Page_Load(object sender, EventArgs e)
        {
            if (this.userid > 0)
            {
                if (CheckUserPopedoms("X") || CheckUserPopedoms("8-6"))
                {
                    
                    string mName = Utils.ChkSQL( HTTPRequest.GetString("mName"));
                    string mPIC= Utils.ChkSQL( HTTPRequest.GetString("mPIC"));
                    string mWidth = Utils.ChkSQL(HTTPRequest.GetString("mWidth"));
                    string mHeight = Utils.ChkSQL(HTTPRequest.GetString("mHeight"));
                    string mExpName= Utils.ChkSQL( HTTPRequest.GetString("mExpName"));
                    string mData= Utils.ChkSQL( HTTPRequest.GetString("mData"));
                    Act = HTTPRequest.GetString("Act");

                    m_ExpressTemplatesID = HTTPRequest.GetInt("m_ExpressTemplatesID", 0);
                    if (Act == "Edit")
                    {
                        ExpressTemplates = M_Utils.GetM_ExpressTemplatesInfoModel(m_ExpressTemplatesID);
                        if (ExpressTemplates != null)
                        {
                            if (ExpressTemplates.m_ConfigInfoID != M_Config.m_ConfigInfoID)
                            {
                                AddErrLine("参数错误,该模板非本网店!");
                            }
                        }
                        else {
                            AddErrLine("参数错误,系统中没有该模板!");
                        }
                    }
                    if (ispost)
                    {
                        
                        ExpressTemplates.mPIC = mPIC;
                        ExpressTemplates.mWidth = mWidth;
                        ExpressTemplates.mHeight = mHeight;
                        ExpressTemplates.mExpName = mExpName;
                        ExpressTemplates.mData = mData;

                        if (Act == "Add")
                        {
                            if (!M_Utils.ExistsM_ExpressTemplatesInfo(mName))
                            {
                                ExpressTemplates.m_ConfigInfoID = M_Config.m_ConfigInfoID;
                                
                                ExpressTemplates.mAppendTime = DateTime.Now;

                                ExpressTemplates.mName = mName;

                                if (M_Utils.AddM_ExpressTemplatesInfo(ExpressTemplates) > 0)
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
                                AddErrLine("名称:" + mName + ",已存在,请更换!");
                                AddScript("window.setTimeout('history.back(1);',1000);");
                            }
                        }
                        if (Act == "Edit")
                        {
                            if (m_ExpressTemplatesID > 0)
                            {
                                if (!M_Utils.ExistsM_ExpressTemplatesInfo(mName) || mName == ExpressTemplates.mName)
                                {
                                    ExpressTemplates.mName = mName;
                                    try
                                    {
                                        M_Utils.UpdateM_ExpressTemplatesInfo(ExpressTemplates);
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
                                    AddErrLine("名称:" + mName + ",已存在,请更换!");
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
                    else {

                        if (Act == "Del")
                        {
                            try
                            {
                                M_Utils.DeleteM_ExpressTemplatesInfoList(HTTPRequest.GetString("etId"));
                                AddMsgLine("删除成功!");
                                AddScript("window.setTimeout('window.parent.HidBox();',1000);");
                            }
                            catch (Exception ex)
                            {
                                AddErrLine("删除失败!<br/>" + ex);
                                AddScript("window.setTimeout('window.parent.HidBox();',1000);");
                            }
                        }
                        else {
                            PublicExpressTemplatesJson = M_Utils.GetPublicExpressTemplatesJson();
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
        }
        protected override void ShowPage()
        {
            pagetitle = config.CompanyName + " 快递运单模板";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}