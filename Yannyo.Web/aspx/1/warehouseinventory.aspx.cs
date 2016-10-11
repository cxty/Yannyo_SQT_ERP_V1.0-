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
using Newtonsoft.Json;

namespace Yannyo.Web
{
   public partial class warehouseinventory : PageBase
	{
        public WarehouseInventoryInfo ms = new WarehouseInventoryInfo();//盘点数据体
        public WarehouseInventory i = new WarehouseInventory();
        public StorageInfo si = new StorageInfo();
        public DataTable dList = new DataTable();
        public bool info;
        public int StorageID = 0;
        public int ProductID = 0;
        public DateTime sDate;//盘点时间
        public string InventoryName;//盘点人
        public string ManagerName;//仓管员
        public string sTel;//联系电话
        public string sAddress;//仓库地址
        public DateTime atime;//库存点
        public string reValue;
        public DateTime time;//获取传过来的日期
        public string storageName;
        public decimal SumA, SumB, SumC, SumD;
        protected virtual void Page_Load(object sender, EventArgs e)
		{
            if (this.userid > 0)
            {
                if (CheckUserPopedoms("X") || CheckUserPopedoms("3-4-5"))
                {
                    //获取表头基本信息
                    sDate = Utils.IsDateString(Utils.ChkSQL(HTTPRequest.GetString("dtime"))) ? DateTime.Parse(Utils.ChkSQL(HTTPRequest.GetString("dtime"))) : DateTime.Now;
                    InventoryName = HTTPRequest.GetString("InventoryName");//盘点人
                    ManagerName = HTTPRequest.GetString("ManagerName");//仓管员
                    sTel = HTTPRequest.GetString("sTel");
                    sAddress = HTTPRequest.GetString("sAddress");


                    StorageID = HTTPRequest.GetInt("StorageID", 0);
                    ProductID = HTTPRequest.GetInt("ProductID", 0);
                    time = HTTPRequest.GetString("sDate").Trim() != "" ? Convert.ToDateTime(HTTPRequest.GetString("sDate").Trim() + " 23:59:59") : DateTime.Now;

                    if (StorageID > 0)
                    {
                        si = tbStorageInfo.GetStorageInfoModel(StorageID);
                        dList = tbProductsInfo.GetProductsStorageInfoByStorageID(0,StorageID, time, ProductID);
                    }
                    if (ispost)
                    {
                        reValue = HTTPRequest.GetString("reValue");//获取button提交过来的json值
                        if (sDate > DateTime.Now)
                        {
                           AddErrLine("盘点日期不能大于当前日期！");
                        }
                        else
                        {
                            storageName = tbStockProductInfo.getSnameByScode(StorageID);
                            ms.SAppendTime = sDate;
                            ms.SDateTime = time;
                            ms.StorageID = StorageID;
                            ms.StorageStaff = ManagerName;
                            ms.StaffPhoneNum = sTel;
                            ms.StaffAdress = sAddress;
                            ms.InventoryName = InventoryName;
                            ms.StaffID = this.userinfo.StaffID;
                            ms.StaffName = this.userinfo.uName;
                            ms.StorageName = storageName;
                            try
                            {
                                info = tbStockProductInfo.getWarehouseInfo(StorageID, sDate);
                                if (info)
                                {
                                    AddMsgLine("数据重复，请核对后重新添加！");
                                    AddScript("window.setTimeout('window.parent.HidBox();',1000);");
                                }
                                else
                                {
                                    ms.GetWarehouseDateJson = (GetWarehouseDateJsonList)JavaScriptConvert.DeserializeObject(reValue, typeof(GetWarehouseDateJsonList));
                                    bool state = tbStockProductInfo.AddWarehouseList(ms);
                                    if (state)
                                    {
                                        AddMsgLine("添加数据成功！");
                                        AddScript("window.setTimeout('window.parent.HidBox();',1000);");
                                    }
                                    else
                                    {
                                        AddMsgLine("添加数据失败！");
                                        AddScript("window.setTimeout('window.parent.HidBox();',1000);");
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                AddErrLine(ex.Message);
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
            pagetitle = "仓库盘点管理";
            this.Load += new EventHandler(this.Page_Load);
        }
	}
}