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
    public partial class supplier_do : PageBase
    {
        public SupplierInfo si = new SupplierInfo();
        public string Act = "";
        public int StoresID = 0;
        public string sName = "";
        public string sCode = "";
        public string sAddress = "";
        public string sTel = "";
        public string sLinkMan = "";
        public string sLicense = "";
        public int sDoDay = 0;
        public int SupplierClassID = 0;

        public decimal sDoDayMoney = 0;
        public DateTime sAppendTime = DateTime.Now;

        public string SupplierClass = "";

        protected virtual void Page_Load(object sender, EventArgs e)
        {
            if (this.userid > 0)
            {
                if (CheckUserPopedoms("X") || CheckUserPopedoms("2-2-3"))
                {
                    Act = HTTPRequest.GetString("Act");

                    if (Act == "Edit")
                    {
                        StoresID = Utils.StrToInt(HTTPRequest.GetString("sid"), 0);

                        si = tbSupplierInfo.GetSupplierInfoModel(StoresID);
                    }
                    if (ispost)
                    {
                        sName = Utils.ChkSQL(HTTPRequest.GetString("sName"));
                        sCode = Utils.ChkSQL(HTTPRequest.GetString("sCode"));
                        sAddress = Utils.ChkSQL(HTTPRequest.GetString("sAddress"));
                        sTel = Utils.ChkSQL(HTTPRequest.GetString("sTel"));
                        sLinkMan = Utils.ChkSQL(HTTPRequest.GetString("sLinkMan"));
                        sLicense = Utils.ChkSQL(HTTPRequest.GetString("sLicense"));

                        sDoDay = Utils.StrToInt(HTTPRequest.GetString("sDoDay"), 0);
                        SupplierClassID = Utils.StrToInt(HTTPRequest.GetString("SupplierClassID"), 0);
                        sDoDayMoney = decimal.Parse(HTTPRequest.GetString("sDoDayMoney").Trim() != "" ? HTTPRequest.GetString("sDoDayMoney") : "0");

                        si.sName = sName;
                        
                        si.sAddress = sAddress;
                        si.sTel = sTel;
                        si.sLinkMan = sLinkMan;
                        si.sDoDay = sDoDay;
                        si.sDoDayMoney = sDoDayMoney;
                        si.SupplierClassID = SupplierClassID;
                        si.sLicense = sLicense;

                        if (Act == "Add")
                        {
                            if (!tbSupplierInfo.ExistsSupplierInfo(sName))
                            {
                                si.sCode = (sCode.Trim() != "") ? sCode : tbSupplierInfo.GetNewSupplierNum();
                                si.sName = sName;
                                //si.sCode = sCode;

                                si.sAppendTime = sAppendTime;

                                if (tbSupplierInfo.AddSupplierInfo(si) > 0)
                                {
                                    Logs.AddEventLog(this.userid, "新增供应商." +si.sName);
                                    AddMsgLine("创建成功!");
                                    AddScript("window.setTimeout('window.parent.HidBox();',1000);");
                                }
                                else
                                {
                                    AddErrLine("创建失败!");
                                    AddScript("window.setTimeout('history.back(1);',2000);");
                                }
                            }
                            else
                            {
                                AddErrLine("供货商:" + sName + ",已存在,请更换!");
                                AddScript("window.setTimeout('history.back(1);',2000);");
                            }
                        }
                        if (Act == "Edit")
                        {
                            bool nOK = false;
                            if (si.sName != sName)
                            {
                                if (!tbSupplierInfo.ExistsSupplierInfo(sName))
                                {
                                    nOK = true;
                                }
                                else
                                {
                                    nOK = false;
                                    AddErrLine("供货商:" + sName + ",已存在,请更换!");
                                    AddScript("window.setTimeout('history.back(1);',2000);");
                                }
                            }
                            else
                            {
                                nOK = true;
                            }
                            sCode = (sCode.Trim() != "") ? sCode : tbSupplierInfo.GetNewSupplierNum();
                            if (si.sCode != sCode)
                            {

                                if (!tbSupplierInfo.ExistsSupplierInfoCode(sCode))
                                {
                                    nOK = true;
                                }
                                else
                                {
                                    nOK = false;
                                    AddErrLine("供货商 编码:" + sCode + ",已存在,请更换!");
                                    AddScript("window.setTimeout('history.back(1);',2000);");
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
                                    si.sCode = sCode;

                                    tbSupplierInfo.UpdateSupplierInfo(si);
                                    Logs.AddEventLog(this.userid, "修改供应商." + si.sName);
                                    AddMsgLine("修改成功!");
                                    AddScript("window.setTimeout('window.parent.HidBox();',2000);");
                                }
                                catch (Exception ex)
                                {
                                    AddErrLine("修改失败!<br/>" + ex);
                                    AddScript("window.setTimeout('window.parent.HidBox();',5000);");
                                }
                            }
                        }
                        Caches.ReSet();
                    }
                    else
                    {
                        SupplierClass = DataClass.GetSupplierClassInfoToHTML();
                        if (Act == "Add")
                        {
                            
                        }

                        if (Act == "Del")
                        {
                            try
                            {
                                tbSupplierInfo.DeleteSupplierInfo(HTTPRequest.GetString("sid"));
                                Logs.AddEventLog(this.userid, "删除供应商." + HTTPRequest.GetString("sid"));
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
            pagetitle = " 添加修改供货商信息";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}
