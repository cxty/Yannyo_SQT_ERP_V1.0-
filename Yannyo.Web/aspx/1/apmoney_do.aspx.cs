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
    public partial class apmoney_do : PageBase
    {
        public APMoneyInfo ai = new APMoneyInfo();
        public string Act = "";
        public int APMoneyID = 0;
        public int APObjID = 0;
        public int APObjType = 0;
        public decimal aNPMoney = 0;
        public decimal aPMoney = 0;
        public decimal aPayMoney = 0;
        public decimal aOtherMoney = 0;
        public int FeesSubjectID = 0;
        public string aReMake = "";
        public DateTime aDoDateTime = DateTime.Now;
        public DateTime aAppendTime = DateTime.Now;

        protected virtual void Page_Load(object sender, EventArgs e)
        {
            if (this.userid > 0)
            {
                if (CheckUserPopedoms("X") || CheckUserPopedoms("6-4"))
                {
                    Act = HTTPRequest.GetString("Act");
                    if (Act == "Edit")
                    {
                        APMoneyID = Utils.StrToInt(HTTPRequest.GetString("aid"), 0);

                        ai = tbAPMoneyInfo.GetAPMoneyInfoModel(APMoneyID);
                    }
                    if (ispost)
                    {

                        APObjID = Utils.StrToInt(Utils.ChkSQL(HTTPRequest.GetString("APObjID")), 0);

                        APObjType = Utils.StrToInt(HTTPRequest.GetString("APObjType"), 0);
                        aPMoney = decimal.Parse(HTTPRequest.GetString("aPMoney"));
                        aPayMoney = decimal.Parse(HTTPRequest.GetString("aPayMoney"));
                        aNPMoney = decimal.Parse(HTTPRequest.GetString("aNPMoney"));
                        FeesSubjectID = Utils.StrToInt(HTTPRequest.GetString("FeesSubjectID"), 0);
                        aReMake = Utils.ChkSQL(HTTPRequest.GetString("aReMake"));
                        aDoDateTime = DateTime.Parse(HTTPRequest.GetString("aDoDateTime"));


                        if (APObjID > 0)
                        {

                            ai.APObjID = APObjID;
                            ai.APObjType = APObjType;
                            ai.aPMoney = aPMoney;
                            ai.aPayMoney = aPayMoney;
                            ai.aOtherMoney = aOtherMoney;
                            ai.FeesSubjectID = FeesSubjectID;
                            ai.aNPMoney = aNPMoney;

                            ai.aReMake = aReMake;
                            ai.aDoDateTime = aDoDateTime;

                                if (Act == "Add")
                                {

                                    ai.aAppendTime = DateTime.Now;

                                    if (tbAPMoneyInfo.AddAPMoneyInfo(ai) > 0)
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
                                if (Act == "Edit")
                                {
                                    try
                                    {

                                        tbAPMoneyInfo.UpdateAPMoneyInfo(ai);
                                        AddMsgLine("修改成功!");
                                        AddScript("window.setTimeout('window.parent.HidBox();',1000);");
                                    }
                                    catch (Exception ex)
                                    {
                                        AddErrLine("修改失败!<br/>" + ex);
                                        AddScript("window.setTimeout('window.parent.HidBox();',1000);");
                                    }
                                }
                            
                        }
                        else
                        {
                            AddErrLine("请选择应付对象!");
                            AddScript("window.setTimeout('history.back(1);',1000);");
                        }

                    }
                    else
                    {
                        if (Act == "Del")
                        {
                            try
                            {
                                tbAPMoneyInfo.DeleteAPMoneyInfo(HTTPRequest.GetString("aid"));
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
            pagetitle = " 添加修改应付数据";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}
