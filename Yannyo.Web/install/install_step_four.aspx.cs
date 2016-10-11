using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Yannyo.Install;
using Yannyo.Config;
using Yannyo.Common;
using Yannyo.Entity;
using Yannyo.BLL;

namespace Yannyo.Web
{
    public partial class install_step_four : page
    {
        public GeneralConfigInfo ManageConfig = new GeneralConfigInfo();
        public string getAct = "";
        public string getAdminName = "";
        public string getAdminPwd = "";

        public string comName = "";
        public string comID = "";
        public string comAddress = "";
        public string comTel = "";
        public string orderNum = "";
        public string cumNum = "";
        public string ordNum = "";
        public int pzLen;
        public int MonNum;
        public int CounNum;
        public string oListWidth = "";
        public string pzWidth = "";
        public int pzRow;
        public string sOListWidth = "";
        public int sOrderRow;

        protected virtual void Page_Load(object sender, EventArgs e)
        {
            getAct = HTTPRequest.GetString("Act");
            getAdminName = HTTPRequest.GetString("adminName");
            getAdminPwd = HTTPRequest.GetString("adminPwd");

            comName = HTTPRequest.GetString("comName");
            comID = HTTPRequest.GetString("comID");
            comAddress = HTTPRequest.GetString("comAddress");
            comTel = HTTPRequest.GetString("comTel");
            orderNum = HTTPRequest.GetString("orderNum");
            cumNum = HTTPRequest.GetString("cumNum");
            ordNum = HTTPRequest.GetString("ordNum");
            pzLen = HTTPRequest.GetInt("pzLen",0);
            MonNum = HTTPRequest.GetInt("MonNum",0);
            CounNum = HTTPRequest.GetInt("CounNum",0);
            oListWidth = HTTPRequest.GetString("oListWidth");
            pzWidth = HTTPRequest.GetString("pzWidth");
            pzRow = HTTPRequest.GetInt("pzRow",0);
            sOListWidth = HTTPRequest.GetString("sOListWidth");
            sOrderRow = HTTPRequest.GetInt("sOrderRow",0);

            if (!ispost)
            {
                if (getAct.IndexOf("install_four") > -1)
                {
                    //设置基本配置
                    ManageConfig = GeneralConfigs.GetConfig();
                    ManageConfig.CompanyName = comName;
                    ManageConfig.RegistrationNo = comID;
                    ManageConfig.Address = comAddress;
                    ManageConfig.Phone = comTel;
                    ManageConfig.OrderID = orderNum;
                    ManageConfig.SupplierCode = cumNum;
                    ManageConfig.MonthlyStatementCode = ordNum;
                    ManageConfig.CertificateCodeLen = pzLen;
                    ManageConfig.MoneyDecimal = MonNum;
                    ManageConfig.QuantityDecimal = CounNum;
                    ManageConfig.PrintPageWidth = oListWidth;
                    ManageConfig.PrintCertificatePageWidth = pzWidth;
                    ManageConfig.CertificateRow = pzRow;
                    ManageConfig.PrintAddPageWidth = sOListWidth;
                    ManageConfig.PrintAddRow = sOrderRow;

                    GeneralConfigs.Serialiaze(ManageConfig, Yannyo.Common.Utils.GetMapPath(BaseConfigs.GetSysPath + "/config/general.config"));
                    Logs.AddEventLog(this.userid, "修改系统配置.");
                    BaseConfigs.ResetConfig();
                    Caches.ReSet();
                    try
                    {
                        Yannyo.Install.Utils.toSystemReg(ManageConfig);
                    }
                    catch
                    { 
                    }

                    if (getAdminName != "" && getAdminPwd !="")
                    {
                        if (!tbUserInfo.ExistsUserInfo(getAdminName))
                        {
                            //创建新用户
                            UserInfo ui = new UserInfo();
                            ui.uName = getAdminName;
                            ui.uPWD =Yannyo.Common.Utils.MD5(getAdminPwd);
                            ui.uCode = Yannyo.Common.Utils.CutString(Yannyo.Common.Utils.GetRanDomCode(), 16);

                            ui.uLastIP = HTTPRequest.GetIP();
                            ui.uAppendTime = DateTime.Now;
                            ui.uUpAppendTime = DateTime.Now;
                            ui.uEstate = 0;
                            ui.StaffID = 0;
                            ui.uType = 0;
                            ui.uPermissions = "X";
                            if (tbUserInfo.AddUserInfo(ui) > 0)
                            {
                                Logs.AddEventLog(this.userid, "新增用户:" + ui.uName);
                            }
                        }
                        else {
                            this.AddErrLine("系统已经初始化,请不要刷新页面或重新初始化!");
                        }
                    }
                }
            }
        }
        protected override void ShowPage()
        {
            pagetitle = "安装程序完成";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}