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
    public partial class monthlystatementprint : PageBase
    {
        public MonthlyStatementInfo msi = new MonthlyStatementInfo();
        public DataTable msdList = new DataTable();
        public DataTable msadList = new DataTable();
        public DataTable msmdList = new DataTable();
        public decimal SumA = 0;
        public decimal SumB = 0;
        public int MonthlyStatementID = 0;
        protected virtual void Page_Load(object sender, EventArgs e)
        {
            
            if (this.userid > 0)
            {
                if (CheckUserPopedoms("X") || CheckUserPopedoms("6-6-2-1") || CheckUserPopedoms("6-6-1-1"))
                {
                    MonthlyStatementID = HTTPRequest.GetInt("msid", 0);
                    if (MonthlyStatementID > 0)
                    {
                        msi = MonthlyStatements.GetMonthlyStatementInfoModel(MonthlyStatementID);
                        if (msi != null)
                        {
                            msdList = MonthlyStatements.GetMonthlyStatementDataInfoList(" MonthlyStatementID=" + MonthlyStatementID + " order by sAppendTime desc").Tables[0];
                            msadList = MonthlyStatements.GetMonthlyStatementAppendDataInfoList(" MonthlyStatementID=" + MonthlyStatementID + " and aState=0 order by aAppendTime desc").Tables[0];
                            msmdList = MonthlyStatements.GetMonthlyStatementAppendMoneyDataInfoList(" MonthlyStatementID=" + MonthlyStatementID + " and mState=0 order by mAppendTime desc").Tables[0];
                            
                            MonthlyStatementWorkingLogInfo mwl = new MonthlyStatementWorkingLogInfo();
                            mwl.MonthlyStatementID = MonthlyStatementID;
                            mwl.UserID = this.userid;
                            mwl.mType = 5;
                            mwl.mMsg = "";
                            mwl.mAppendTime = DateTime.Now;

                            MonthlyStatements.AddMonthlyStatementWorkingLogInfo(mwl);

                        }
                        else
                        {
                            AddErrLine("参数错误!");
                        }
                    }
                    else
                    {
                        AddErrLine("参数错误!");
                    }
                }
                else
                {
                    AddErrLine("权限不足!");
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
            pagetitle = " 打印对账单";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}