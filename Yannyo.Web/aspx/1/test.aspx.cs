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
using System.IO;

namespace Yannyo.Web
{
    public partial class test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
			DateTime _dt = DateTime.Now;

			if (HTTPRequest.GetString ("dt").Trim () != "") {
			
				_dt = DateTime.Parse(HTTPRequest.GetString ("dt").Trim ());

			}

            Orders.SyncData2SCM();

            switch(HTTPRequest.GetInt("x",0))
            {
                case 1:
                    DataUtils.getStorageSalesDetails_ToMail("2011-6-10", "cxty@qq.com");
                    break;
                case 2:
					DataUtils.getJointInventoryDetails_ToMail(_dt, 1, "cxty@qq.com");
                    break;
                case 3:
					DataUtils.getIslandSalesDetails_ToMail(_dt, "cxty@qq.com");
                    break;
                case 4:
					DataUtils.getIslandShipmentDetails_ToMail(_dt, "cxty@qq.com");
                    break;
                case 5:
					DataUtils.getStockDetails_ToMail(_dt, "cxty@qq.com");
                    break;
                case 12:
					DataUtils.getStockDetails_all_file("cxty@qq.com", _dt);
                    break;
				case 13:
					DataUtils.getStockDetails_all_file_oneTable("cxty@qq.com", _dt);
				break;
            }
            //DataUtils.getStorageSalesDetails_ToMail("2011-6-10", "cxty@qq.com");
            //DataUtils.getJointInventoryDetails_ToMail(DateTime.Parse("2011-6-10"),1, "cxty@qq.com");
            //DataUtils.getIslandSalesDetails_ToMail(DateTime.Parse("2011-7-13"), "cxty@qq.com");
            //DataUtils.getIslandShipmentDetails_ToMail(DateTime.Parse("2011-6-10"), "cxty@qq.com");
            //DataUtils.getStockDetails_ToMail(DateTime.Parse("2011-7-13"), "cxty@qq.com");
        }
    }
}