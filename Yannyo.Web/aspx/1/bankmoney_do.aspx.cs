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
    public partial class bankmoney_do : PageBase
    {
        public DataTable fList = new DataTable();
        public string Act = "";
        public DateTime sDate;//日期

        protected virtual void Page_Load(object sender, EventArgs e)
        {
            if (this.userid > 0)
            {
                if (CheckUserPopedoms("X") || CheckUserPopedoms("6-2"))
                {
                    fList = tbBankInfo.GetBankList(" 1=1 order by bAppendTime desc").Tables[0];
                    Act = HTTPRequest.GetString("Act");

                    fList.Columns.Add("money", typeof(decimal));

                    if (Act == "Edit")
                    {
                        sDate = DateTime.Parse(HTTPRequest.GetString("sDate"));
                        DataTable tDt = new DataTable();

                        tDt = tbBankMoneyInfo.GetBankMoneyList(" bUpdateTime='" + sDate + "'").Tables[0];
                        foreach (DataRow dr in tDt.Rows)
                        {
                            foreach (DataRow dr_x in fList.Rows)
                            {
                                if (dr_x["BankID"].ToString() == dr["BankID"].ToString())
                                {
                                    dr_x["money"] = dr["bMoney"];
                                }
                            }
                        }
                        fList.AcceptChanges();
                    }
                    if (ispost)
                    {
                        int t = 0;
                        DateTime bUpdateTime = DateTime.Parse(HTTPRequest.GetString("bUpdateTime"));

                        if (Act == "Add")
                        {
                            try
                            {
                                t = 0;
                                foreach (DataRow dr_x in fList.Rows)
                                {
                                    t++;
                                    if (HTTPRequest.GetString("Bank_" + t).Trim() != "")
                                    {
                                        BankMoneyInfo bmi = new BankMoneyInfo();
                                        bmi.BankID = int.Parse(dr_x["BankID"].ToString());
                                        bmi.bMoney = decimal.Parse(HTTPRequest.GetString("Bank_" + t));
                                        bmi.bUpdateTime = bUpdateTime;
                                        bmi.bAppendTime = DateTime.Now;

                                        tbBankMoneyInfo.AddBankMoney(bmi);
                                    }
                                }
                                AddMsgLine("添加成功!");
                                AddScript("window.setTimeout('window.parent.HidBox();',1000);");
                            }
                            catch (Exception ex)
                            {
                                AddMsgLine("添加失败!<br/>" + ex);
                                AddScript("window.setTimeout('window.parent.HidBox();',1000);");
                            }
                        }
                        else if (Act == "Edit")
                        {
                            try
                            {
                                t = 0;
                                foreach (DataRow dr_x in fList.Rows)
                                {
                                    t++;
                                    if (HTTPRequest.GetString("Bank_" + t).Trim() != "")
                                    {
                                        BankMoneyInfo bmi = new BankMoneyInfo();
                                        bmi = tbBankMoneyInfo.GetBankMoneyModel(sDate, int.Parse(dr_x["BankID"].ToString()));
                                        if (bmi != null)
                                        {
                                            bmi.bMoney = decimal.Parse(HTTPRequest.GetString("Bank_" + t));
                                            tbBankMoneyInfo.UpdateBankMoney(bmi);
                                        }
                                        else
                                        {
                                            bmi = new BankMoneyInfo();
                                            bmi.BankID = int.Parse(dr_x["BankID"].ToString());
                                            bmi.bMoney = decimal.Parse(HTTPRequest.GetString("Bank_" + t));
                                            bmi.bUpdateTime = bUpdateTime;
                                            bmi.bAppendTime = DateTime.Now;

                                            tbBankMoneyInfo.AddBankMoney(bmi);
                                        }
                                    }
                                }
                                AddMsgLine("修改成功!");
                                AddScript("window.setTimeout('window.parent.HidBox();',1000);");
                            }
                            catch (Exception ex)
                            {
                                AddMsgLine("修改失败!<br/>" + ex);
                                AddScript("window.setTimeout('window.parent.HidBox();',1000);");
                            }
                        }
                    }
                    else
                    {
                        if (Act == "Del")
                        {
                            try
                            {
                                tbBankMoneyInfo.DeleteBankMoneyForDate(HTTPRequest.GetString("sDate"));
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
            pagetitle = " 添加修改银行明细数据";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}
