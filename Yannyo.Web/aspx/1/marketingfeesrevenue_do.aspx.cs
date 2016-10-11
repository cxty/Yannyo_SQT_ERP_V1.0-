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
    public partial class marketingfeesrevenue_do : PageBase
    {
        public MarketingFeesInfo mi = new MarketingFeesInfo();
        public string Act = "";
        public int MarketingFeesID = 0;
        public int StoresID = 0;
        public int FeesSubjectID = 0;
        public string mRemark = "";
        public float mFees = 0;
        public DateTime mDateTime = DateTime.Now;
        public int mType = 0;
        public int StaffID = 0;
        public int mIsIncomeExpenditure = 1;
        public DateTime mAppendTime = DateTime.Now;

        protected virtual void Page_Load(object sender, EventArgs e)
        {
            if (this.userid > 0)
            {
                if (CheckUserPopedoms("X") || CheckUserPopedoms("6-1"))
                {
                    Act = HTTPRequest.GetString("Act");
                    if (Act == "Edit")
                    {
                        MarketingFeesID = Utils.StrToInt(HTTPRequest.GetString("mid"), 0);

                        mi = tbMarketingFeesInfo.GetMarketingFeesInfoModel(MarketingFeesID);
                    }
                    if (ispost)
                    {
                        StoresID = 0;
                        FeesSubjectID = Utils.StrToInt(Utils.ChkSQL(HTTPRequest.GetString("FeesSubjectID")), 0);
                        mRemark = Utils.ChkSQL(HTTPRequest.GetString("mRemark"));
                        mFees = Utils.StrToFloat(Utils.ChkSQL(HTTPRequest.GetString("mFees")), 0);
                        mDateTime = Utils.IsDateString(Utils.ChkSQL(HTTPRequest.GetString("mDateTime"))) ? DateTime.Parse(Utils.ChkSQL(HTTPRequest.GetString("mDateTime"))) : DateTime.Now;
                        mType = -1;
                        StaffID = Utils.StrToInt(Utils.ChkSQL(HTTPRequest.GetString("StaffID")), 0);

                        mi.StoresID = StoresID;
                        mi.FeesSubjectID = FeesSubjectID;
                        mi.mRemark = mRemark;
                        mi.mFees = decimal.Parse(mFees.ToString());
                        mi.mDateTime = mDateTime;
                        mi.mType = mType;
                        mi.StaffID = StaffID;
                        mi.mIsIncomeExpenditure = 1;

                       
                            if (FeesSubjectID > 0)
                            {
                                if (StaffID > 0)
                                {
                                    if (Act == "Add")
                                    {
                                        mi.mAppendTime = mAppendTime;
                                        if (tbMarketingFeesInfo.AddMarketingFeesInfo(mi) > 0)
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
                                            tbMarketingFeesInfo.UpdateMarketingFeesInfo(mi);
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
                                    AddErrLine("经办人不能为空!");
                                    AddScript("window.setTimeout('history.back(1);',1000);");
                                }
                            }
                            else
                            {
                                AddErrLine("费用科目不能为空!");
                                AddScript("window.setTimeout('history.back(1);',1000);");
                            }
                        
                    }
                    else
                    {
                        if (Act == "Del")
                        {
                            try
                            {
                                tbMarketingFeesInfo.DeleteMarketingFeesInfo(HTTPRequest.GetString("mid"));
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
            pagetitle = " 添加修改收入数据";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}
