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
using Yannyo.Public;
using System.IO;

namespace Yannyo.Web
{
    public partial class data_import_export : PageBase
    {
        public string DataType = "";//数据类型,Products产品,Supplier供应商,Stores客户,Storage仓库
        public string Act = "";//动作,import导入,export导出
        public string Do = "";//具体动作,Full完全覆盖替换,New累加
        public string PathStr = "/Data/Import/";
        protected virtual void Page_Load(object sender, EventArgs e)
        {
            this.DataType = HTTPRequest.GetString("DataType");
            this.Act = HTTPRequest.GetString("Act");
            this.Do = HTTPRequest.GetString("Do");
            DataTable dt = new DataTable();
            string filename = "";

            if (ispost)
            {
                string _PathStr = HttpContext.Current.Server.MapPath("/") + PathStr;
                if (!Directory.Exists(_PathStr))
                {
                    Directory.CreateDirectory(_PathStr);
                }
                HttpFileCollection files = HttpContext.Current.Request.Files;
                try
                {
                    if (files.Count > 0)
                    {
                        FileExtension[] fe = { FileExtension.XLS, FileExtension.XLSX };
                        HttpPostedFile postedFile = files[0];
                        int fileLen = postedFile.ContentLength;
                        byte[] fileArray = new byte[fileLen];
                        postedFile.InputStream.Read(fileArray, 0, fileLen);
                        System.IO.MemoryStream fs = new System.IO.MemoryStream(fileArray);
                        try
                        {
                            if (FileValidation.IsAllowedExtension(fs, fe))
                            {
                                filename = _PathStr + '/' + postedFile.FileName;
                                postedFile.SaveAs(filename);
                                dt = Public.Excels.ExcelToTableForXLSX(filename);
                            }
                        }
                        finally
                        {
                            fs.Close();
                        }
                    }
                    else {
                        this.AddErrLine("没有文件数据");
                    }
                }
                catch (Exception ex) {
                    this.AddErrLine(ex.Message);
                }
            }

            switch (this.DataType)
            {
                case "Products":
                    if (CheckUserPopedoms("2-2-2-1") || CheckUserPopedoms("X"))
                    {
                        this.Products_do(this.Act, this.Do, dt);
                    }
                    else
                    {
                        AddErrLine("权限不足!");
                    }
                    break;
                case "Supplier":
                    if (CheckUserPopedoms("2-2-3-1") || CheckUserPopedoms("X"))
                    {
                        this.Supplier_do(this.Act, this.Do, dt);
                    }
                    else
                    {
                        AddErrLine("权限不足!");
                    }
                    break;
                case "Stores":
                    if (CheckUserPopedoms("2-2-4-1") || CheckUserPopedoms("X"))
                    {
                        this.Stores_do(this.Act, this.Do, dt);
                    }
                    else
                    {
                        AddErrLine("权限不足!");
                    }
                    break;
                case "Storage":
                    if (CheckUserPopedoms("2-2-1-1") || CheckUserPopedoms("X"))
                    {
                        this.Storage_do(this.Act, this.Do, dt);
                    }
                    else
                    {
                        AddErrLine("权限不足!");
                    }
                    break;
            }
        }

        public void Products_do(string Act,string Do,DataTable Dt) {
            if (ispost)
            {
                if (Dt.Rows.Count > 0) {
                    ProductsInfo model = new ProductsInfo();

                    for (int i = 0; i < Dt.Rows.Count; i++) {
                        if (Dt.Rows[i]["ProductsID"].ToString() != "")
                        {
                            model.ProductsID = int.Parse(Dt.Rows[i]["ProductsID"].ToString());
                        }
                        model.pCode = Dt.Rows[i]["pCode"].ToString();
                        model.pBarcode = Dt.Rows[i]["pBarcode"].ToString();
                        model.pName = Dt.Rows[i]["pName"].ToString();
                        model.pBrand = Dt.Rows[i]["pBrand"].ToString();
                        model.pStandard = Dt.Rows[i]["pStandard"].ToString();
                        model.pUnits = Dt.Rows[i]["pUnits"].ToString();
                        model.pMaxUnits = Dt.Rows[i]["pMaxUnits"].ToString();
                        model.pProducer = Dt.Rows[i]["pProducer"].ToString();
                        model.pExpireDay = Dt.Rows[i]["pExpireDay"].ToString();
                        model.pAddress = Dt.Rows[i]["pAddress"].ToString();

                        if (Dt.Rows[i]["ProductClassID"].ToString() != "")
                        {
                            model.ProductClassID = int.Parse(Dt.Rows[i]["ProductClassID"].ToString());
                        }
                        model.ProductClass = Dt.Rows[i]["ProductClass"].ToString();
                        if (Dt.Rows[i]["pToBoxNo"].ToString() != "")
                        {
                            model.pToBoxNo = int.Parse(Dt.Rows[i]["pToBoxNo"].ToString());
                        }
                        if (Dt.Rows[i]["pState"].ToString() != "")
                        {
                            model.pState = int.Parse(Dt.Rows[i]["pState"].ToString());
                        }
                        if (Dt.Rows[i]["pAppendTime"].ToString() != "")
                        {
                            model.pAppendTime = DateTime.Parse(Dt.Rows[i]["pAppendTime"].ToString());
                        }
                        else {
                            model.pAppendTime = DateTime.Now;
                        }
                        if (Dt.Rows[i]["pPrice"].ToString() != "")
                        {
                            model.pPrice = decimal.Parse(Dt.Rows[i]["pPrice"].ToString());
                        }
                        
                        if (Dt.Rows[i]["pDoDayQuantity"].ToString() != "")
                        {
                            model.pDoDayQuantity = decimal.Parse(Dt.Rows[i]["pDoDayQuantity"].ToString());
                        }

                        ProductsInfo modelOld = new ProductsInfo();
                        if (model.pCode.Trim() != "")
                        {
                            modelOld = tbProductsInfo.GetProductsInfoModelByCode(model.pCode);
                        }
                        else {
                            modelOld = null;
                        }
                        if (modelOld != null)
                        {
                            model.ProductsID = modelOld.ProductsID;
                            tbProductsInfo.UpdateProductsInfo(model);
                            AddMsgLine(model.pName+"(更新)");
                        }
                        else {
                            model.pCode = Utils.GetRanDomCode();
                            tbProductsInfo.AddProductsInfo(model);
                            AddMsgLine(model.pName + "(新增)");
                        }
                    }
                }
            }
            else 
            {
                if (Do == "down") { 
                    DataTable dt = tbProductsInfo.GetProductsInfoList("").Tables[0];
                    Public.Excels.TableToExcelForXLSX(dt, "产品列表" + (DateTime.Now).ToString("yyyy-MM-dd")+".xls");
                }
            }
        }
        public void Supplier_do(string Act, string Do, DataTable Dt)
        {
            if (ispost)
            {
                if (Dt.Rows.Count > 0)
                {
                    SupplierInfo model = new SupplierInfo();

                    for (int i = 0; i < Dt.Rows.Count; i++)
                    {
                        if (Dt.Rows[i]["SupplierID"].ToString() != "")
                        {
                            model.SupplierID = int.Parse(Dt.Rows[i]["SupplierID"].ToString());
                        }
                        if (Dt.Rows[i]["SupplierClassID"].ToString() != "")
                        {
                            model.SupplierClassID = int.Parse(Dt.Rows[i]["SupplierClassID"].ToString());
                        }
                        model.SupplierClassName = Dt.Rows[i]["SupplierClassName"].ToString();
                        model.sName = Dt.Rows[i]["sName"].ToString();
                        model.sCode = Dt.Rows[i]["sCode"].ToString();
                        model.sAddress = Dt.Rows[i]["sAddress"].ToString();
                        model.sTel = Dt.Rows[i]["sTel"].ToString();
                        model.sLinkMan = Dt.Rows[i]["sLinkMan"].ToString();
                        model.sLicense = Dt.Rows[i]["sLicense"].ToString();
                        if (Dt.Rows[i]["sDoDay"].ToString() != "")
                        {
                            model.sDoDay = int.Parse(Dt.Rows[i]["sDoDay"].ToString());
                        }
                        if (Dt.Rows[i]["sDoDayMoney"].ToString() != "")
                        {
                            model.sDoDayMoney = decimal.Parse(Dt.Rows[i]["sDoDayMoney"].ToString());
                        }
                        if (Dt.Rows[i]["sAppendTime"].ToString() != "")
                        {
                            model.sAppendTime = DateTime.Parse(Dt.Rows[i]["sAppendTime"].ToString());
                        }

                        SupplierInfo modelOld = new SupplierInfo();
                        if (model.sCode.Trim() != "")
                        {
                            modelOld = tbSupplierInfo.GetSupplierInfoModelByCode(model.sCode);
                        }
                        else {
                            modelOld = tbSupplierInfo.GetSupplierInfoModelByName(model.sName);
                        }
                        if (modelOld != null)
                        {
                            model.SupplierID = modelOld.SupplierID;
                            tbSupplierInfo.UpdateSupplierInfo(model);

                            AddMsgLine(model.sName+"更新");
                        }
                        else {
                            tbSupplierInfo.AddSupplierInfo(model);
                            AddMsgLine(model.sName+"新增");
                        }
                    }
                }
            }
            else {
                if (Do == "down")
                {
                    DataTable dt = tbSupplierInfo.GetSupplierInfoList("").Tables[0];
                    Public.Excels.TableToExcelForXLSX(dt, "供应商列表" + (DateTime.Now).ToString("yyyy-MM-dd") + ".xls");
                }
            }
        }
        public void Stores_do(string Act, string Do, DataTable Dt)
        {
            if (ispost)
            {
                if (Dt.Rows.Count > 0)
                {
                    StoresInfo model = new StoresInfo();
                    for (int i = 0; i < Dt.Rows.Count; i++)
                    {
                        if (Dt.Rows[i]["StoresID"].ToString() != "")
                        {
                            model.StoresID = int.Parse(Dt.Rows[i]["StoresID"].ToString());
                        }
                        if (Dt.Rows[i]["PaymentSystemID"].ToString() != "")
                        {
                            model.PaymentSystemID = int.Parse(Dt.Rows[i]["PaymentSystemID"].ToString());
                        }
                        model.PaymentSystemName = Dt.Rows[i]["PaymentSystemName"].ToString();
                        if (Dt.Rows[i]["PriceClassID"].ToString() != "")
                        {
                            model.PriceClassID = int.Parse(Dt.Rows[i]["PriceClassID"].ToString());
                        }
                        model.PriceClassName = Dt.Rows[i]["PriceClassName"].ToString();
                        if (Dt.Rows[i]["CustomersClassID"].ToString() != "")
                        {
                            model.CustomersClassID = int.Parse(Dt.Rows[i]["CustomersClassID"].ToString());
                        }
                        model.CustomersClassName = Dt.Rows[i]["CustomersClassName"].ToString();

                        model.sName = Dt.Rows[i]["sName"].ToString();
                        model.sCode = Dt.Rows[i]["sCode"].ToString();
                        model.sType = Dt.Rows[i]["sType"].ToString();
                        model.YHsysName = Dt.Rows[i]["YHsysName"].ToString();
                        if (Dt.Rows[i]["YHsysID"].ToString() != "")
                        {
                            model.YHsysID = int.Parse(Dt.Rows[i]["YHsysID"].ToString());
                        }
                        if (Dt.Rows[i]["sIsFZYH"].ToString() != "")
                        {
                            model.sIsFZYH = int.Parse(Dt.Rows[i]["sIsFZYH"].ToString());
                        }
                        if (Dt.Rows[i]["RegionID"].ToString() != "")
                        {
                            model.RegionID = int.Parse(Dt.Rows[i]["RegionID"].ToString());
                        }
                        if (Dt.Rows[i]["sState"].ToString() != "")
                        {
                            model.sState = int.Parse(Dt.Rows[i]["sState"].ToString());
                        }
                        if (Dt.Rows[i]["sAppendTime"].ToString() != "")
                        {
                            model.sAppendTime = DateTime.Parse(Dt.Rows[i]["sAppendTime"].ToString());
                        }
                        if (Dt.Rows[i]["sDoDay"].ToString() != "")
                        {
                            model.sDoDay = int.Parse(Dt.Rows[i]["sDoDay"].ToString());
                        }
                        if (Dt.Rows[i]["sDoDayMoney"].ToString() != "")
                        {
                            model.sDoDayMoney = decimal.Parse(Dt.Rows[i]["sDoDayMoney"].ToString());
                        }
                        model.sContact = Dt.Rows[i]["sContact"].ToString();
                        model.sTel = Dt.Rows[i]["sTel"].ToString();
                        model.sAddress = Dt.Rows[i]["sAddress"].ToString();
                        model.sEmail = Dt.Rows[i]["sEmail"].ToString();
                        model.sLicense = Dt.Rows[i]["sLicense"].ToString();

                        StoresInfo modelOld = new StoresInfo();
                        if (model.sCode.Trim() != "")
                        {
                            modelOld = tbStoresInfo.GetStoresInfoModelByCode(model.sCode);
                        }
                        else {
                            modelOld = tbStoresInfo.GetStoresInfoModelByName(model.sName);
                        }
                        if (modelOld != null)
                        {
                            model.StoresID = modelOld.StoresID;
                            tbStoresInfo.UpdateStoresInfo(model);

                            AddMsgLine(model.sName + "更新");
                        }
                        else
                        {
                            tbStoresInfo.AddStoresInfo(model);
                            AddMsgLine(model.sName + "新增");
                        }

                    }
                }
            }
            else
            {
                if (Do == "down")
                {
                    DataTable dt = tbStoresInfo.GetStoresInfoList("").Tables[0];
                    Public.Excels.TableToExcelForXLSX(dt, "客户列表" + (DateTime.Now).ToString("yyyy-MM-dd") + ".xls");
                }
            }
        }
        public void Storage_do(string Act, string Do, DataTable Dt)
        {
            if (ispost)
            {
                if (Dt.Rows.Count > 0)
                {
                    StorageInfo model = new StorageInfo();
                    for (int i = 0; i < Dt.Rows.Count; i++)
                    {
                        if (Dt.Rows[i]["StorageID"].ToString() != "")
                        {
                            model.StorageID = int.Parse(Dt.Rows[i]["StorageID"].ToString());
                        }
                        model.sCode = Dt.Rows[i]["sCode"].ToString();
                        model.sName = Dt.Rows[i]["sName"].ToString();
                        model.ManagerName = Dt.Rows[i]["Manager"].ToString();
                        if (Dt.Rows[i]["sManager"].ToString() != "")
                        {
                            model.sManager = int.Parse(Dt.Rows[i]["sManager"].ToString());
                        }
                        model.sTel = Dt.Rows[i]["sTel"].ToString();
                        model.sAddress = Dt.Rows[i]["sAddress"].ToString();
                        model.sRemake = Dt.Rows[i]["sRemake"].ToString();
                        if (Dt.Rows[i]["sAppendTime"].ToString() != "")
                        {
                            model.sAppendTime = DateTime.Parse(Dt.Rows[i]["sAppendTime"].ToString());
                        }
                        if (Dt.Rows[i]["StorageClassID"].ToString() != "")
                        {
                            model.StorageClassID = int.Parse(Dt.Rows[i]["StorageClassID"].ToString());
                        }
                        model.StorageName = Dt.Rows[i]["storageName"].ToString();
                        if (Dt.Rows[i]["sState"].ToString() != "")
                        {
                            model.sState = int.Parse(Dt.Rows[i]["sState"].ToString());
                        }

                        StorageInfo modelOld = new StorageInfo();
                        if (model.sCode.Trim() != "")
                        {
                            modelOld = tbStorageInfo.GetStorageInfoModelBySCode(model.sCode);
                        }
                        else {
                            modelOld = tbStorageInfo.GetStorageInfoModelByName(model.sName);
                        }
                        if (modelOld != null)
                        {
                            model.StorageID = modelOld.StorageID;

                            tbStorageInfo.UpdateStorageInfo(model);
                            AddMsgLine(model.sName+"更新");
                        }
                        else {
                            tbStorageInfo.AddStorageInfo(model);
                            AddMsgLine(model.sName+"新增");
                        }
                    }
                }
            }
            else
            {
                if (Do == "down")
                {
                    DataTable dt = tbStorageInfo.GetStoragesInfoList("").Tables[0];
                    Public.Excels.TableToExcelForXLSX(dt, "仓库列表" + (DateTime.Now).ToString("yyyy-MM-dd") + ".xls");
                }
            }
        }

        protected override void ShowPage()
        {
            pagetitle = " 数据导入导出";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}