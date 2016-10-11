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
    public partial class storehousestorage_do : PageBase
    {
        public StorehouseStoreInfo si = new StorehouseStoreInfo();
        public string Act = HTTPRequest.GetString("Act");
        public DataTable sNum;//门店编号
        public string sName;//门店名称
        public string stCode = "默认值";//仓库编号 暂取默认值
        public string stName;//仓库名称
        public int pCode;//产品编号
        public string pName;//产品名称
        public string pBrand;//产品品牌
        public string pStandred;//产品规格
        public int pRelityStorage;//产品数量
        public string pMoney;//产品单价
        public string pBarcode;//产品条码
        public string proCode;//产品自编码
        public DateTime sDateTime=DateTime.Now;
        public int StoresID;//门店编号
        public int ProductID;//产品编号
        public  string sid = "";
        public int productStorageID = 0;
        protected virtual void Page_Load(object sender, EventArgs e)
        {
            if (this.userid > 0)
            {
                if (CheckUserPopedoms("X") || CheckUserPopedoms("3-4-6-1"))
                {
                        if (Act == "Del")
                        {
                            try
                            {
                                sid = Utils.ChkSQL(HTTPRequest.GetString("sid"));
                                storehouseStorage.DeleteStoragesInfo(sid);
                                AddMsgLine("删除成功!");
                                AddScript("window.setTimeout('window.parent.HidBox();',1000);");
                            }
                            catch(Exception ex)
                            {
                                AddErrLine("创建失败!<br/>" + ex.Message);
                                AddScript("window.setTimeout('window.parent.HidBox();',1000);");
                            }
                        }
                        if (Act == "Edit")
                        {
                            productStorageID = Utils.StrToInt(HTTPRequest.GetString("sid"), 0);

                            si = storehouseStorage.GetStorehouseProductsInfoModel(productStorageID);
                            
                        }
                        if (ispost)
                        {                            
                            sName = Utils.ChkSQL(HTTPRequest.GetString("SName"));//  门店名称
                            stName = Utils.ChkSQL(HTTPRequest.GetString("stName")); //仓库名称
                            pName = Utils.ChkSQL(HTTPRequest.GetString("pName"));//产品名称    
                            pBrand = Utils.ChkSQL(HTTPRequest.GetString("pBrand"));//品牌
                            proCode = Utils.ChkSQL(HTTPRequest.GetString("proCode"));//产品自编号
                            pStandred = Utils.ChkSQL(HTTPRequest.GetString("pStandred"));//产品规格
                            pRelityStorage = Utils.StrToInt(Utils.ChkSQL(HTTPRequest.GetString("pNum")), 0);//数量
                            pBarcode = Utils.ChkSQL(HTTPRequest.GetString("pBarcode"));//条码
                            pMoney = Utils.ChkSQL(HTTPRequest.GetString("pMoney"));//单价
                            sDateTime = Utils.IsDateString(Utils.ChkSQL(HTTPRequest.GetString("sDateTime"))) ? DateTime.Parse(Utils.ChkSQL(HTTPRequest.GetString("sDateTime"))) : DateTime.Now;//获取日期

                            StoresID = Utils.StrToInt(Utils.ChkSQL(HTTPRequest.GetString("StoresID")), 0);//直接获取门店编号
                            ProductID = Utils.StrToInt(Utils.ChkSQL(HTTPRequest.GetString("ProductID")), 0);//直接获取产品编号

                          
                            pCode =Utils.StrToInt(storehouseStorage.SelectPcodeByName(pName),0);//通过产品名称找到产品系统编号
                            int pbrCode =Utils.StrToInt(storehouseStorage.SelectpBarcodeByName(pBarcode),0);//通过产品条码获得产品编号

                            si.SName = sName;
                            si.StCode = "默认值";
                            si.StName = "默认值";
                            si.PAppendTime = sDateTime;
                            si.StoresID = StoresID;
                            si.ProductsID = ProductID;
                            si.ProCode = proCode;
                            si.PBarcode = pBarcode;
                            si.PName = pName;
                            si.PBrand = pBrand;
                            si.PStandard = pStandred;
                            si.PNum = pRelityStorage;
                            si.PMoney = pMoney;
                           
                            
                            if (Act == "Add")
                            {
                                if(StoresID>0)
                                {
                                    if (sDateTime > DateTime.Now)
                                    {
                                        AddMsgLine("创建时间不能大于当前时间，请重新选择!");
                                    }
                                    else
                                    {
                                        if (ProductID > 0)
                                        {

                                            bool state = storehouseStorage.GetDateTimeDataStorehouseInfoList(sDateTime, StoresID, stCode, pCode);
                                            if (state)
                                            {
                                                AddErrLine("该产品["+pName+"]数据库已经存在！");
                                            }
                                            else
                                            {
                                                if (storehouseStorage.AddStorehouseStorageInfo(si) > 0)
                                                {
                                                    storehouseStorage.AddStorehouseStorageInfo_calculate(si);
                                                    AddMsgLine("创建成功!");
                                                    AddScript("window.setTimeout('window.parent.HidBox();',1000);");
                                                }
                                                else
                                                {
                                                    AddErrLine("创建失败!");
                                                    AddScript("window.setTimeout('history.back(1);',1000);");
                                                }
                                            }
                                        }
                                        else
                                        {
                                            AddMsgLine("该产品[" + pName + "]编号不存在！");
                                        }
                                    }
                                }
                                else
                                {
                                    AddMsgLine("该门店[" + sName + "]编号不存在！请确认后再次输入或先添加该门店！");
                                }

                            }
                            if (Act == "Edit")
                            {
                                productStorageID = Utils.StrToInt(HTTPRequest.GetString("sid"), 0);
                                si.ProductStorageID = productStorageID;
                                try
                                {
                                   int state=  storehouseStorage.UpdateStorehouseStorageInfo(si);
                                   if (state > 0)
                                   {
                                       
                                       AddMsgLine("修改成功!");
                                       AddScript("window.setTimeout('window.parent.HidBox();',1000);");
                                   }
                                   else
                                   {
                                      AddErrLine("修改失败!<br/>");
                                   }
                                }
                                catch (Exception ex)
                                {
                                    AddErrLine("错误信息!<br/>" + ex.Message);
                                }
                            }
                    }
                }
                else
                {
                    AddErrLine("权限不足!");
                    AddScript("window.parent.HidBox();");
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
            pagetitle = "添加门店仓库库存";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}