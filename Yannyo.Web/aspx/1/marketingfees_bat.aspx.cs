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
    public partial class marketingfees_bat : PageBase
    {
        public int loop_count = 0;
        public string Act = "";
        protected virtual void Page_Load(object sender, EventArgs e)
        {
            if (this.userid > 0)
            {
                if (CheckUserPopedoms("X") || CheckUserPopedoms("6-1"))
                {
                    Act = HTTPRequest.GetString("Act");
                    if (ispost)
                    {
                        if (Act == "OK")
                        {
                            loop_count = HTTPRequest.GetInt("loop_count_obj", 0);
                            if (loop_count > 0)
                            {
                                int ObjType = HTTPRequest.GetInt("ObjType", 0);//收入=0,支出=1
                                int ObjTypeB = HTTPRequest.GetInt("ObjTypeB", 0);//销售费用=0,公司费用=1
                                int StoresID = 0;//门店
                                int FeesSubjectID = 0;//科目
                                int StaffID = 0;//人员
                                DateTime mDateTime = DateTime.Now;//发生时间
                                decimal mFees = 0;//金额
                                string mRemark = "";//备注
                                int tCount = 0;

                                MarketingFeesInfo mi = new MarketingFeesInfo();
                                for (int i = 0; i < loop_count; i++)
                                {

                                    FeesSubjectID = HTTPRequest.GetInt("FeesSubjectID_" + i, 0);
                                    StaffID = HTTPRequest.GetInt("StaffID_"+i, 0);
                                    mDateTime = HTTPRequest.GetString("mDateTime_" + i).Trim() != "" ? DateTime.Parse(HTTPRequest.GetString("mDateTime_" + i).Trim()) : DateTime.Now;

                                    mFees = Utils.IsNumeric(HTTPRequest.GetString("mFees_" + i)) ? decimal.Parse(HTTPRequest.GetString("mFees_" + i).ToString()) : 0;
                                    mRemark = HTTPRequest.GetString("mRemark_"+i);


                                    if (FeesSubjectID > 0 && StaffID > 0)
                                    {
                                        if (ObjType == 1 && ObjTypeB == 0)
                                        {
                                            StoresID = HTTPRequest.GetInt("StoresID_"+i, 0);
                                            mi.mIsIncomeExpenditure = 0;
                                            mi.mType = 0;
                                        }
                                        else if (ObjType == 1 && ObjTypeB == 1)
                                        {
                                            mi.mIsIncomeExpenditure = 0;
                                            StoresID = 0;
                                            mi.mType = 1;
                                        }
                                        else if (ObjType == 0)
                                        {
                                            StoresID = 0;
                                            mi.mType = -1;
                                            mi.mIsIncomeExpenditure = 1;
                                        }
                                        mi.StoresID = StoresID;
                                        mi.FeesSubjectID = FeesSubjectID;
                                        mi.mRemark = mRemark;
                                        mi.mFees = decimal.Parse(mFees.ToString());
                                        mi.mDateTime = mDateTime;                                        
                                        mi.StaffID = StaffID;
                                        mi.mAppendTime = DateTime.Now;

                                        if (tbMarketingFeesInfo.AddMarketingFeesInfo(mi) > 0)
                                        {
                                            tCount++;
                                        }
                                    }
                                }
                                AddMsgLine("导入成功,共导入 <b>" + tCount + "</b> 条数据!");
                                AddScript("window.setTimeout('window.parent.HidBox();',3000);");
                            }
                            else
                            {
                                AddErrLine("没有任何数据插入!");
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
            pagetitle = " 添加收入支出";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}
