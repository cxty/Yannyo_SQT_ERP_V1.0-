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
using Yannyo.Public;
using System.IO;

namespace Yannyo.Web
{
    public partial class page : PageBase
	{
        public DataTable PageTemplatesList = new DataTable();

        protected virtual void Page_Load(object sender, EventArgs e)
        {
            PageTemplatesList.Columns.Add("PageName", typeof(string));
            PageTemplatesList.Columns.Add("PageExt", typeof(string));

            foreach (string d in Directory.GetDirectories(Utils.GetMapPath("/templates/")))
            {
                foreach (string f in Directory.GetFiles(d))
                {
                    FileInfo fi = new FileInfo(f);
                    try
                    {
                        if (fi.Extension == ".htm" && fi.Name.IndexOf("_") != 0)
                        {
                            DataRow dr = PageTemplatesList.NewRow();
                            dr["PageName"] = fi.Name.Replace(".htm", "");
                            dr["PageExt"] = fi.Extension;
                            PageTemplatesList.Rows.Add(dr);
                        }
                    }
                    finally
                    {
                        fi = null;
                    }
                }
            }
            PageTemplatesList.AcceptChanges();

            if (ispost)
            {
                if (HTTPRequest.GetString("page") != "")
                {
                    SysPageTemplate syspagetemplate = new SysPageTemplate();
                    string t_Pagestr = HTTPRequest.GetString("page") + ",";
                    string[] t_Pagearray = Utils.SplitString(t_Pagestr,",");
                    if (t_Pagearray.Length > 0)
                    {
                        for (int i = 0; i < t_Pagearray.Length; i++)
                        {
                            if (t_Pagearray[i].Trim() != "")
                            {
                                syspagetemplate.GetTemplate(BaseConfigs.GetSysPath, "Default", t_Pagearray[i].Trim(), 1, 1, "Yannyo.Web");
                            }
                        }
                    }
                }
            }
        }
        protected override void ShowPage()
        {
            pagetitle = "模版生成";

            this.Load += new EventHandler(this.Page_Load);
        }
	}
}
