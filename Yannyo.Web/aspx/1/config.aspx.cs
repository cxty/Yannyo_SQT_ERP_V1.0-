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
    public partial class config : PageBase
    {
        public GeneralConfigInfo ManageConfig = new GeneralConfigInfo();
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
                        if (Act == "recache")
                        {
                            BaseConfigs.ResetConfig();
                            GeneralConfigs.Serialiaze(GeneralConfigs.GetConfig(), Utils.GetMapPath(BaseConfigs.GetSysPath + "config/general.config"));
                            Caches.ReSet();
                            AddMsgLine("已重建缓存.");
                            AddScript("window.setTimeout('history.back(1);',2000);");
                        }
                        else
                        {
                            ManageConfig = GeneralConfigs.GetConfig();
                            if (ManageConfig == null)
                            {
                                AddErrLine("获取配置信息发生错误.<br>");
                            }
                        }
                    }
                    else
                    {
                        try
                        {
                            ManageConfig = GeneralConfigs.GetConfig();

                            ManageConfig.OrderID = HTTPRequest.GetString("OrderID");
                            ManageConfig.MoneyDecimal = HTTPRequest.GetInt("MoneyDecimal",0);
                            ManageConfig.QuantityDecimal = HTTPRequest.GetInt("QuantityDecimal", 0);
                            ManageConfig.CompanyName = HTTPRequest.GetString("CompanyName");
                            ManageConfig.RegistrationNo = HTTPRequest.GetString("RegistrationNo");
                            ManageConfig.Address = HTTPRequest.GetString("Address");
                            ManageConfig.Phone = HTTPRequest.GetString("Phone");
                            ManageConfig.MonthlyStatementCode = HTTPRequest.GetString("MonthlyStatementCode");
                            ManageConfig.SupplierCode = HTTPRequest.GetString("SupplierCode");
                            ManageConfig.ReWorkedOrderNum = HTTPRequest.GetString("ReWorkedOrderNum");
                            //ManageConfig.CertificateCode = HTTPRequest.GetString("CertificateCode");

                            ManageConfig.PrinterName = HTTPRequest.GetString("PrinterName");
                            ManageConfig.PrintPageWidth = HTTPRequest.GetString("PrintPageWidth");
                            ManageConfig.PrintCertificatePageWidth= HTTPRequest.GetString("PrintCertificatePageWidth");
                            ManageConfig.CertificateRow = HTTPRequest.GetInt("CertificateRow", 0);
                            ManageConfig.CertificateCodeLen = HTTPRequest.GetInt("CertificateCodeLen", 0);

                            ManageConfig.PrintAddPageWidth = HTTPRequest.GetString("PrintAddPageWidth");
                            ManageConfig.PrintAddRow = HTTPRequest.GetInt("PrintAddRow", 0);

                            ManageConfig.Taobao_Open = HTTPRequest.GetInt("Taobao_Open", 0);
                            ManageConfig.Order_lock = HTTPRequest.GetInt("Order_lock", 0) ;
                            ManageConfig.Certificate_lock = HTTPRequest.GetInt("Certificate_lock", 0);
                            //ManageConfig.Taobao_AppKey = HTTPRequest.GetString("Taobao_AppKey");
                            //ManageConfig.Taobao_AppSecret = HTTPRequest.GetString("Taobao_AppSecret");

                            GeneralConfigs.Serialiaze(ManageConfig, Utils.GetMapPath(BaseConfigs.GetSysPath + "config/general.config"));

                            Logs.AddEventLog(this.userid, "修改系统配置.");

                            BaseConfigs.ResetConfig();
                            Caches.ReSet();
                            AddMsgLine("提交成功!");
                            SetBackLink("config.aspx?r=" + Utils.GetRanDomCode());
                            SetMetaRefresh(1, "config.aspx?r=" + Utils.GetRanDomCode());
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
            pagetitle = " 修改系统配置信息";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}