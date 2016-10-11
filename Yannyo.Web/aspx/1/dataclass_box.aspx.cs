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
    public partial class dataclass_box : PageBase
    {
        public string DepartmentsJson = "";
        public string SupplierJson = "";
        public string CustomersJson = "";
        public string FeesSubjectJson = "";
        public string Act = "";
        public string ShowType = "";
        protected virtual void Page_Load(object sender, EventArgs e)
        {
            Act = HTTPRequest.GetString("Act");
            ShowType = HTTPRequest.GetString("ShowType");
            DepartmentsJson = Caches.GetDepartmentsClassInfoToJson(-1, true, true);
            SupplierJson = Caches.GetSupplierClassInfoToJson(-1, true, true);
            CustomersJson = Caches.GetCustomersClassInfoToJson(-1, true, true);
            FeesSubjectJson = Caches.GetFeesSubjectClassInfoToJson(-1, false, true);
        }
        protected override void ShowPage()
        {
            pagetitle = " 分类工具";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}