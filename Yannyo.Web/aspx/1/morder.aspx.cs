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
    public partial class morder : MPageBase
    {
        public int m_OrderInfoID = 0;
        protected virtual void Page_Load(object sender, EventArgs e)
        {

        }
        protected override void ShowPage()
        {
            pagetitle = " 订单";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}