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
    public partial class mconfig : PageBase
    {
        public GeneralConfigInfo ManageConfig = new GeneralConfigInfo();
        public DataTable dList = new DataTable();
        public string Act = "";
        protected virtual void Page_Load(object sender, EventArgs e)
        {
            if (this.userid > 0)
            {
                if (CheckUserPopedoms("X"))
                {
                    Act = HTTPRequest.GetString("Act");
                    if (!ispost)
                    {
                        ManageConfig = GeneralConfigs.GetConfig();
                        if (ManageConfig == null)
                        {
                            AddErrLine("获取配置信息发生错误.<br>");
                        }
                        else {
                            dList = M_Utils.GetM_ConfigInfoList(" 1=1 order by m_ConfigInfoID desc").Tables[0];
                        }
                    }
                    else
                    {
                        try
                        {
                            ManageConfig = GeneralConfigs.GetConfig();
                            ManageConfig.Taobao_Open = HTTPRequest.GetInt("Taobao_Open", 0);
                            ManageConfig.Taobao_SandBox = HTTPRequest.GetInt("Taobao_SandBox", 1);
                            GeneralConfigs.Serialiaze(ManageConfig, Utils.GetMapPath(BaseConfigs.GetSysPath + "config/general.config"));

                            BaseConfigs.ResetConfig();
                            Caches.ReSet();
                            AddMsgLine("提交成功!");
                            SetBackLink("mconfig.aspx?r=" + Utils.GetRanDomCode());
                            SetMetaRefresh(1, "mconfig.aspx?r=" + Utils.GetRanDomCode());
                        }
                        catch (Exception ex)
                        {
                            AddErrLine("提交时发生错误:<br>" + ex.Message.ToString());
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
        }
        protected override void ShowPage()
        {
            pagetitle = " 网店配置信息";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}