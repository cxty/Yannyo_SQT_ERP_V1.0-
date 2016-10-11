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
using Yannyo.Cache;
using Yannyo.Common;
using Yannyo.Entity;
using Yannyo.BLL;

namespace Yannyo.Web
{
    public partial class msendgoods_exp : MPageBase
    {
        public DataTable eList = new DataTable();//物流
        protected virtual void Page_Load(object sender, EventArgs e)
        {
            eList = M_Utils.GetM_ExpressTemplatesInfoList(" m_ConfigInfoID=" + M_Config.m_ConfigInfoID + " order by mAppendTime desc").Tables[0];
        }
        protected override void ShowPage()
        {
            pagetitle = " 网购订单物流信息";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}