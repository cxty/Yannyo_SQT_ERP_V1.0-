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
    public partial class certificateworkinglog : PageBase
    {
        public int CertificateID = 0;
        public CertificateInfo ci = new CertificateInfo();
        public DataTable dList = new DataTable();
        protected virtual void Page_Load(object sender, EventArgs e)
        {
            if (this.userid > 0)
            {
                CertificateID = Utils.StrToInt(HTTPRequest.GetString("cid"), 0);
                if (CertificateID > 0)
                {
                    ci = Certificates.GetCertificateInfoModel(CertificateID);
                    if (ci != null)
                    {
                        dList = Certificates.GetCertificateWorkingLogList(" CertificateID=" + CertificateID + " order by cAppendTime desc").Tables[0];
                    }
                    else {
                        AddErrLine("凭证不存在!");
                    }
                }
                else {
                    AddErrLine("参数错误!");
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
            pagetitle = " 凭证操作记录";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}