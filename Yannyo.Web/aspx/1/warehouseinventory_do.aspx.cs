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
using Yannyo.Public;

namespace Yannyo.Web
{
    public partial class warehouseinventory_do : PageBase
    {
        public string Act = HTTPRequest.GetString("Act");
        public WarehouseInventoryInfo si = new WarehouseInventoryInfo();
        public int StocktakeID;
        public DataTable productsName=new DataTable();
        public DataTable storageName = new DataTable();
        protected virtual void Page_Load(object sender, EventArgs e)
        {
             if (this.userid > 0)
            {
                if (CheckUserPopedoms("X") || CheckUserPopedoms("3-4-5"))
                {
                   
                    if (Act == "Edit")
                    {
                        
                        StocktakeID = Utils.StrToInt(HTTPRequest.GetString("sid"), 0);
                        si= tbStockProductInfo.GetWarehouseInventoryInfoModel(StocktakeID);
                    }
                    if (ispost)
                    {
                        if (Act == "Edit")
                        {
                            si.Quantity = Convert.ToDecimal(HTTPRequest.GetString("Quantity"));
                            si.StocktakeID = Utils.StrToInt(HTTPRequest.GetString("sid"), 0);
                            
                            int state  =tbStockProductInfo.UpdateStorageInventoryInfo(si);
                            if (state > 0)
                            {
                                AddMsgLine("更新数据成功！");
                                AddScript("window.setTimeout('window.parent.HidBox();',1000);");
                            }
                            else
                            {
                                AddMsgLine("更新数据失败！");
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
            pagetitle = "添加门店产品单价数据";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}