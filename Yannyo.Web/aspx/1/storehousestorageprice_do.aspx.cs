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
    public partial class storehousestorageprice_do : PageBase
    {
        public storehouseproductsprice pi = new storehouseproductsprice();
        public string Act = HTTPRequest.GetString("Act");
        public DataTable sNum;//门店编号
        public string SName = "";
        public string sName;//门店名称
        public string stName;//仓库名称
        public string stNum;//仓库编号
        public string pName;//产品名称
        public int ProductID;//产品编号
        public int StoresID;//门店编号
        public string ProductsBarcode;//产品条码
        public decimal pPrice;//产品价格
        public DateTime sDateTime;
        public int ProductPriceID = 0;
        public string sid = "";
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
                            storehouseStorage.DeleteStoragesPriceInfo(sid);
                            AddMsgLine("删除成功!");
                            AddScript("window.setTimeout('window.parent.HidBox();',1000);");
                        }
                        catch (Exception ex)
                        {
                            AddErrLine("创建失败!<br/>" + ex.Message);
                            AddScript("window.setTimeout('window.parent.HidBox();',1000);");
                        }
                    }
                    if (Act == "Edit")
                    {
                        ProductPriceID = Utils.StrToInt(HTTPRequest.GetString("sid"), 0);

                        pi = storehouseStorage.GetStorehouseProductsPriceInfoModel(ProductPriceID);
                    }
                    if (ispost)
                    {
                        sName = HTTPRequest.GetString("StoresName").Trim();//获取前台的门店名称
                        StoresID = Utils.StrToInt(HTTPRequest.GetString("StoresID"), 0);//获取前台门店编号
                        stName = HTTPRequest.GetString("stName").Trim();//获取前台的仓库名称
                        pName = HTTPRequest.GetString("ProductsName").Trim();//获取前台的产品名称
                        ProductID = HTTPRequest.GetInt("ProductID",0);//获取前台的产品编号
                        ProductsBarcode = HTTPRequest.GetString("ProductsBarcode").Trim();//获取前台产品条码
                        pPrice = decimal.Parse(HTTPRequest.GetString("pPrice").Trim());//获取前台产品单价
                        //获取前台选择的时间
                        sDateTime = Utils.IsDateString(Utils.ChkSQL(HTTPRequest.GetString("pAppendTime"))) ? DateTime.Parse(Utils.ChkSQL(HTTPRequest.GetString("pAppendTime"))) : DateTime.Now;

                        //根据门店名称取出门店编号
                        sNum = storehouseStorage.GetScodeBySname(sName);

                        pi.StoresID = StoresID;
                        pi.StoresName = sName;
                        pi.StCode = "默认值";
                        pi.StName = "默认值";
                        pi.ProductsID = ProductID;
                        pi.ProductsName = pName;
                        pi.ProductsBarcode = ProductsBarcode;
                        pi.PPrice = pPrice;
                        pi.PAppendTime = sDateTime;
                        
                        if (Act == "Add")
                        {
                            if (sNum.Rows.Count > 0)
                            {
                                if (sDateTime > DateTime.Now)
                                {
                                    AddMsgLine("创建时间不能大于当前时间，请重新选择!");
                                }
                                else
                                {
                                    if (ProductsBarcode == "")
                                    {
                                       
                                        if (ProductID > 0)
                                        {
                                            bool state = storehouseStorage.GetStorehousePriceInfoList(StoresID, stNum, ProductID, sDateTime);
                                            if (state)
                                            {
                                                AddErrLine("价格重复:产品名称[" + pName + "]库中已经存在！");
                                            }
                                            else
                                            {
                                                ProductsBarcode = "null";
                                                pi.ProductsBarcode = ProductsBarcode;
                                                if (storehouseStorage.AddStorehouseStorageProductsPriceInfo(pi) > 0)
                                                {
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
                                    else
                                    {
                                        if (ProductID > 0)
                                        {

                                            bool state = storehouseStorage.GetStorehousePriceInfoList(StoresID, stNum, ProductID, sDateTime);
                                            if (state)
                                            {
                                                AddErrLine("价格重复:产品名称[" + pName + "]库中已经存在！");
                                            }
                                            else
                                            {
                                                if (storehouseStorage.AddStorehouseStorageProductsPriceInfo(pi) > 0)
                                                {
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
                            }
                            else
                            {
                                AddMsgLine("该门店[" + sName + "]编号不存在！请确认后再次输入或先添加该门店！");
                            }

                        }

                        if (Act == "Edit")
                        {
                            ProductPriceID = Utils.StrToInt(HTTPRequest.GetString("sid"), 0);
                           
                            string pNum = storehouseStorage.getPricePnumByPname(pName);
                            if (pNum !="")
                            {
                                pi.ProductPriceID = ProductPriceID;
                                try
                                {
                                   int state= storehouseStorage.UpdateStorehouseStoragePriceInfo(pi);
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
                                    AddErrLine("错误信息"+ex.Message);
                                }
                            }
                            else
                            {
                                ProductPriceID = Utils.StrToInt(HTTPRequest.GetString("sid"), 0);
                                string PNum =storehouseStorage.SelectpBarcodeByName(ProductsBarcode);
                                pi.ProductPriceID = ProductPriceID;
                                try
                                {
                                    int state = storehouseStorage.UpdateStorehouseStoragePriceInfo(pi);
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
                                    AddErrLine("错误信息" + ex.Message);
                                }
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