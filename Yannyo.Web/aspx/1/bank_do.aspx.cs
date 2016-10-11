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
    public partial class bank_do : PageBase
    {
        public BankAccount ba = new BankAccount();
        public string Act = "";
        public int BankID = 0;
        public string bName = "";                     //账户名称
        public int FeesSubject;                       //科目选择
        public string beginMoney;                    //期初金额
        public DateTime bAppendTime =Convert.ToDateTime(DateTime.Now.Year+"-01-01");   //日期选择
        public int Begin = 0;
        public string FeesSubjectJson = "";
        public string cDirecion;
        public decimal cMoney;
        protected virtual void Page_Load(object sender, EventArgs e)
        {
            if (this.userid > 0)
            {
                if (CheckUserPopedoms("X") || CheckUserPopedoms("6-1-2"))
                {
                    Act = HTTPRequest.GetString("Act");
                    FeesSubjectJson = Caches.GetFeesSubjectClassInfoToJson(-1, false, true);
                    if (Act == "Edit")
                    {
                        BankID = Utils.StrToInt(HTTPRequest.GetString("bid"), 0);

                        ba = tbBankInfo.GetBankModel(BankID);
                    }
                    if (ispost)
                    {

                        bName =HTTPRequest.GetString("FeesSubject").Trim();           //账户名称
                        beginMoney = HTTPRequest.GetString("beginMoney");             //期初金额
                        FeesSubject = HTTPRequest.GetInt("FeesSubjectID", 0);         //获取科目
                        //bAppendTime = Utils.IsDateString(Utils.ChkSQL(HTTPRequest.GetString("bAppendTime"))) ? DateTime.Parse(Utils.ChkSQL(HTTPRequest.GetString("bAppendTime"))) : DateTime.Now;  //操作日期
                       
                        //获得科目方向
                        cDirecion = tbBankInfo.ClassDiretion(FeesSubject);
                        //检查账户名称是否存在
                        bool checkName = tbBankInfo.ExistsBank(FeesSubject);
                        
                        //添加
                        if (Act == "Add")
                        {

                            ba.CAccountName = bName;
                            ba.FeesSubjectClassID = FeesSubject;
                            ba.PAppendTime = bAppendTime;
                            ba.CAccountMoney = Convert.ToDecimal(beginMoney);
                            ba.CDirection =Convert.ToInt32(cDirecion);
                           
                            if (checkName)
                            {
                                    AddErrLine("该资金账户["+bName+"]已经存在！");
                            }

                            else
                            {
                                
                                if (tbBankInfo.AddBank(ba) > 0)
                                {
                                    Logs.AddEventLog(this.userid, "新增资金帐户." +ba.FeesSubjectClassID);
                                    AddMsgLine("创建成功!");
                                    AddScript("window.setTimeout('window.parent.HidBox();',1000);");
                                }
                                else
                                {
                                    AddErrLine("创建失败!");
                                    AddScript("history.back(1);");
                                }
                          
                            }
                        }
                       
                        if (Act == "Edit")
                        {
                          
                            ba.CAccountMoney = Convert.ToDecimal(beginMoney);

                            try
                            {
                                tbBankInfo.UpdateBank(ba);
                                Logs.AddEventLog(this.userid, "修改资金帐户." + ba.FeesSubjectClassID);
                                AddMsgLine("修改成功!");
                                AddScript("window.setTimeout('window.parent.HidBox();',1000);");
                            }
                            catch (Exception ex)
                            {
                                AddErrLine("修改失败!<br/>" + ex);
                              
                            }
                        }
                    }
                    else
                    {
                        if (Act == "Del")
                        {
                            try
                            {
                                string sCheckbox = HTTPRequest.GetString("bid");
                               
                                tbBankInfo.DeleteBank(sCheckbox);
                                Logs.AddEventLog(this.userid, "删除资金帐户." + HTTPRequest.GetString("bid"));
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
            pagetitle = " 添加修改银行数据";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}
