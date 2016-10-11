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
    public partial class workdata_do : PageBase
    {
        protected virtual void Page_Load(object sender, EventArgs e)
        {

        }
        protected override void ShowPage()
        {
            pagetitle = " 工作信息";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}