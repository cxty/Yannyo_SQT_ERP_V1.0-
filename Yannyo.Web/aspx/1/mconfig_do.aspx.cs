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
    public partial class mconfig_do : PageBase
    {
        public M_ConfigInfo mc = new M_ConfigInfo();
        public string Act = "";
        public int m_ConfigInfoID = 0;
        public string format = "";//返回值格式,默认html
        public string tJson = "";
        protected virtual void Page_Load(object sender, EventArgs e)
        {
            if (this.userid > 0)
            {
                if (CheckUserPopedoms("X"))
                {
                    Act = HTTPRequest.GetString("Act");
                    format = HTTPRequest.GetString("format");

                    if (Act == "Edit" || Act=="State")
                    {
                        m_ConfigInfoID = Utils.StrToInt(HTTPRequest.GetString("mid"), 0);

                        mc = M_Utils.GetM_ConfigInfoModel(m_ConfigInfoID);
                    }
                    if (ispost)
                    {
                        int StoresID = Utils.StrToInt(HTTPRequest.GetString("StoresID"), 0);
                        string m_Name = Utils.ChkSQL(HTTPRequest.GetString("m_Name"));
                        string m_AppKey = Utils.ChkSQL(HTTPRequest.GetString("m_AppKey"));
                        string m_AppSecret = Utils.ChkSQL(HTTPRequest.GetString("m_AppSecret"));
                        int m_State = Utils.StrToInt(HTTPRequest.GetString("m_State"), 0);

                        if (StoresID > 0)
                        {
                            mc.m_AppKey = m_AppKey;
                            mc.m_AppSecret = m_AppSecret;
                            mc.StoresID = StoresID;
                            mc.m_State = m_State;

                            if (Act == "Add")
                            {
                                if (!M_Utils.ExistsM_ConfigInfo(m_Name))
                                {
                                    mc.m_Name = m_Name;
                                    mc.m_AppendTime = DateTime.Now;
                                    mc.m_UpdateTime = DateTime.Now;
                                    try
                                    {
                                        if (M_Utils.AddM_ConfigInfo(mc) > 0)
                                        {
                                            Logs.AddEventLog(this.userid, "新增网店配置."+mc.m_Name);
                                            AddMsgLine("添加成功!");
                                            AddScript("window.setTimeout('window.parent.HidBox();',1000);");
                                        }
                                        else
                                        {
                                            AddErrLine("添加失败,请重试!");
                                            AddScript("window.setTimeout('history.back(1);',2000);");
                                        }
                                    }
                                    catch(Exception ex) {
                                        AddErrLine("系统错误:"+ex.Message);
                                    }
                                }
                                else
                                {
                                    AddErrLine("名称重复!");
                                    AddScript("window.setTimeout('history.back(1);',2000);");
                                }
                            }
                            if (Act == "Edit")
                            {
                                if (mc.m_Name != m_Name && M_Utils.ExistsM_ConfigInfo(m_Name))
                                {
                                    AddErrLine("名称重复!");
                                    AddScript("window.setTimeout('history.back(1);',2000);");
                                }
                                else {
                                    try
                                    {
                                        mc.m_Name = m_Name;
                                        M_Utils.UpdateM_ConfigInfo(mc);
                                        Logs.AddEventLog(this.userid, "修改网店配置."+mc.m_Name);
                                        AddMsgLine("修改成功!");
                                        AddScript("window.setTimeout('window.parent.HidBox();',1000);");
                                    }
                                    catch (Exception ex)
                                    {
                                        AddErrLine("系统错误:" + ex.Message);
                                    }
                                }
                            }
                        }
                        else 
                        {
                            AddErrLine("请选择客户!");
                            AddScript("window.setTimeout('history.back(1);',2000);");
                        }
                        Caches.ReSet();//重置缓存
                    }
                    else {
                        if (Act == "State")
                        {
                            mc.m_State = mc.m_State == 0 ? 1 : 0;
                            try
                            {
                                M_Utils.UpdateM_ConfigInfo(mc);
                                Logs.AddEventLog(this.userid, "修改网店状态."+mc.m_Name);
                                tJson = ",\"idStr\":\"" + m_ConfigInfoID + "\",\"state\":\"" + mc.m_State + "\"";
                                AddMsgLine("修改成功!");
                            }
                            catch (Exception ex)
                            {
                                AddErrLine("系统错误:" + ex.Message);
                            }
                        }
                        Caches.ReSet();//重置缓存
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
            pagetitle = " 网店信息";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}