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
using Newtonsoft.Json;

namespace Yannyo.Web
{
    public partial class warehouseinventorylist : PageBase
    {
        public DataTable dList = new DataTable();
        public WarehouseInventoryInfo si = new WarehouseInventoryInfo();
        //public StorageInfo ssi = new StorageInfo();

        public int pagesize;
        public int pageindex;
        public int pagetotal;
        public int StorageID = 0;//仓库编号
        public DateTime sUpdateTime=DateTime.Now;//盘点时间
        public string Act = HTTPRequest.GetString("Act");
        public string sid = "";
        public int StockID;
        public decimal SumA = 0;
        public decimal SumB = 0;
        public decimal SumC = 0;
        public string pagecode = "";
        protected virtual void Page_Load(object sender, EventArgs e)
        {
             pagesize = 20;
             PageBarHTML = "";
             if (this.userid > 0)
             {
                if (CheckUserPopedoms("X") || CheckUserPopedoms("3-4-1-2"))
                {
                    pagecode = Utils.GetRanDomCode().Trim();
                    UsersUtils.WriteCookie("OrderPageCode", pagecode);

                    if (HTTPRequest.GetString("page").Trim() != "" && Utils.IsInt(HTTPRequest.GetString("page").Trim()))
                    {
                        pageindex = int.Parse(HTTPRequest.GetString("page").Trim());
                    }
                    else
                    {
                        pageindex = 1;
                    }
                     if (Act == "Edit")
                     {
                         StockID = Utils.StrToInt(HTTPRequest.GetString("sid"), 0);
                         si = tbStockProductInfo.GetInventoryInfoModel(StockID);

                         if (ispost)
                         {
                             DateTime sDate = Utils.IsDateString(Utils.ChkSQL(HTTPRequest.GetString("dtime"))) ? DateTime.Parse(Utils.ChkSQL(HTTPRequest.GetString("dtime"))) : DateTime.Now;
                             string  InventoryName = Utils.ChkSQL(HTTPRequest.GetString("InventoryName"));//盘点人
                             string ManagerName = Utils.ChkSQL(HTTPRequest.GetString("ManagerName"));//仓管员
                             string sTel = Utils.ChkSQL(HTTPRequest.GetString("sTel"));
                             string sAddress = Utils.ChkSQL(HTTPRequest.GetString("sAddress"));
                             string reValue = HTTPRequest.GetString("reValue");

                             si.SAppendTime = sDate;
                             si.StorageStaff = ManagerName;
                             si.StaffPhoneNum = sTel;
                             si.StaffAdress = sAddress;
                             si.InventoryName = InventoryName;

                             si.GetWarehouseDateJson = (GetWarehouseDateJsonList)JavaScriptConvert.DeserializeObject(reValue, typeof(GetWarehouseDateJsonList));

                             bool state = tbStockProductInfo.UpdateWarehouseList(si);
                             if (state)
                             {
                                AddErrLine("修改数据成功！");
                                 AddScript("window.setTimeout('window.parent.HidBox();',1000);");
                             }
                             else
                             {
                                 AddErrLine("修改数据失败！");
                                 AddScript("window.setTimeout('window.parent.HidBox();',1000);");
                             }
                         }
                         else
                         {
                             
                             //ssi = tbStorageInfo.GetStorageInfoModel(si.StorageID);
                             dList = tbStockProductInfo.getInventoryInfoList(si.StorageID, si.SDateTime);
                             PageBarHTML = Utils.TenPage(pageindex, pagetotal, 0);
                         }
                     }
                }
                else
                {
                    AddErrLine("权限不足! ");
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
            pagetitle = " 仓库盘点信息";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}