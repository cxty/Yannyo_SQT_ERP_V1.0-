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
    public partial class armoney_do : PageBase
    {
        public ARMoneyInfo ai = new ARMoneyInfo();
        public string Act = "";
        public int ARMoneyID = 0;
        public int ARObjID = 0;
        public int ARObjType = 0;
        public decimal aAMoney = 0;
        public decimal aBMoney = 0;
        public DateTime aOpenDate = DateTime.Now;
        public decimal aOpenMoney = 0;
        public DateTime aDate = DateTime.Now;
        public DateTime aActualDate = DateTime.Now;
        public decimal aActualMoney = 0;
        public DateTime aUpdateTime = DateTime.Now;
        public int aSteps = 0;
        public DateTime aAppendTime = DateTime.Now;


        protected virtual void Page_Load(object sender, EventArgs e)
        {
            if (this.userid > 0)
            {
                if (CheckUserPopedoms("X") || CheckUserPopedoms("6-3"))
                {
                    Act = HTTPRequest.GetString("Act");
                    if (Act == "Edit")
                    {
                        ARMoneyID = Utils.StrToInt(HTTPRequest.GetString("aid"), 0);

                        ai = tbARMoneyInfo.GetARMoneyInfoModel(ARMoneyID);
                    }
                    if (ispost)
                    {

                        ARObjID = Utils.StrToInt(Utils.ChkSQL(HTTPRequest.GetString("ARObjID")), 0);

                        ARObjType = Utils.StrToInt(HTTPRequest.GetString("ARObjType"), 0);
                        aAMoney = decimal.Parse(HTTPRequest.GetString("aAMoney").Trim());
                        aBMoney = decimal.Parse(HTTPRequest.GetString("aBMoney").Trim());
                        aSteps = HTTPRequest.GetInt("aSteps", 1);
                        if (HTTPRequest.GetString("aOpenDate").Trim() != "")
                        {
                            aOpenDate = DateTime.Parse(Utils.ChkSQL(HTTPRequest.GetString("aOpenDate")));
                        }
                        aOpenMoney = decimal.Parse(HTTPRequest.GetString("aOpenMoney"));
                        if (HTTPRequest.GetString("aDate").Trim() != "")
                        {
                            aDate =DateTime.Parse(Utils.ChkSQL(HTTPRequest.GetString("aDate")));
                        }
                        if (HTTPRequest.GetString("aActualDate").Trim() != "")
                        {
                            aActualDate =DateTime.Parse( Utils.ChkSQL(HTTPRequest.GetString("aActualDate")));
                        }
                        aActualMoney = decimal.Parse(HTTPRequest.GetString("aActualMoney").Trim());


                        if (ARObjID > 0)
                        {
                            //if (aAMoney > 0)
                            {
                                ai.ARObjID = ARObjID;
                                ai.ARObjType = ARObjType;
                                ai.aAMoney = aAMoney;
                                ai.aBMoney = aBMoney;
                                ai.aOpenDate = aOpenDate;
                                ai.aOpenMoney = aOpenMoney;

                                ai.aDate = aDate;

                                if (Act == "Add")
                                {
                                    ai.aActualDate = aActualDate;
                                    ai.aActualMoney = aActualMoney;

                                    ai.aUpdateTime = DateTime.Now;

                                    ai.aSteps = aSteps;
                                    ai.aAppendTime = DateTime.Now;

                                    if (tbARMoneyInfo.AddARMoneyInfo(ai) > 0)       
                                    {
                                        AddMsgLine("创建成功!");
                                        AddScript("window.setTimeout('window.parent.HidBox();',1000);");
                                    }
                                    else
                                    {
                                        AddErrLine("创建失败!");
                                        AddScript("window.setTimeout('history.back(1);',3000);");
                                    }
                                }
                                if (Act == "Edit")
                                {
                                    try
                                    {
                                        ai.aActualDate = aActualDate;
                                        ai.aActualMoney = aActualMoney;

                                        ai.aUpdateTime = DateTime.Now;

                                        ai.aSteps = aSteps;

                                        tbARMoneyInfo.UpdateARMoneyInfo(ai);
                                        AddMsgLine("修改成功!");
                                        AddScript("window.setTimeout('window.parent.HidBox();',1000);");
                                    }
                                    catch (Exception ex)
                                    {
                                        AddErrLine("修改失败!<br/>" + ex);
                                        AddScript("window.setTimeout('window.parent.HidBox();',3000);");
                                    }
                                }
                            }
                           // else
                            {
                            //    AddErrLine("请填写发生金额!");
                           //     AddScript("window.setTimeout('history.back(1);',1000);");
                            }
                        }
                        else
                        {
                            AddErrLine("请选择应收对象!");
                            AddScript("window.setTimeout('history.back(1);',2000);");
                        }

                    }
                    else
                    {
                        if (Act == "Del")
                        {
                            try
                            {
                                tbARMoneyInfo.DeleteARMoneyInfo(HTTPRequest.GetString("aid"));
                                AddMsgLine("删除成功!");
                                AddScript("window.setTimeout('window.parent.HidBox();',1000);");
                            }
                            catch (Exception ex)
                            {
                                AddErrLine("删除失败!<br/>" + ex);
                                AddScript("window.setTimeout('window.parent.HidBox();',3000);");
                            }
                        }
                    }
                }
                else
                {
                    AddErrLine("权限不足!");
                    AddScript("window.setTimeout('window.parent.HidBox();',2000);");
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
            pagetitle = " 添加修改应收数据";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}
