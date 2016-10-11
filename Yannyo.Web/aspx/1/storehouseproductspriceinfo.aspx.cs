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
    public partial class storehouseproductspriceinfo : PageBase
    {
        public int pagesize;
        public int pageindex;
        public int pagetotal;
        public DataTable sNum;//门店编号
        public string SName = "";
        public string sName;//门店名称
        public string stName;//仓库名称
        public string stNum;//仓库编号
        public int StoresID;//匹配状态记录：匹配未成功=0
        protected virtual void Page_Load(object sender, EventArgs e)
        {
            if (ispost)
            {
                if (this.userid > 0)
                {
                    if (CheckUserPopedoms("X") || CheckUserPopedoms("3-4-6-1"))
                    {
                        //获取前台的门店名称与仓库名称
                        sName = HTTPRequest.GetString("SName").Trim();
                        stName = HTTPRequest.GetString("stName").Trim();
                        //根据仓库名称找到仓库编号--预留
                        stNum = "默认值";
                        //获取前台选择的时间
                        DateTime sDateTime = Utils.IsDateString(Utils.ChkSQL(HTTPRequest.GetString("dtime"))) ? DateTime.Parse(Utils.ChkSQL(HTTPRequest.GetString("dtime"))) : DateTime.Now;
                        //根据门店名称取出门店编号
                        sNum = storehouseStorage.GetScodeBySname(sName);

                        StoresID = Utils.StrToInt(HTTPRequest.GetString("StoresID"), 0); //获得门店编号

                        if (sNum.Rows.Count > 0)
                        {
                            //判断选择时间是否大于当前时间
                            if (sDateTime > DateTime.Now)
                            {
                                AddErrLine("日期选择错误，不能大于当前日期，请重新选择!");
                            }
                            else
                            {
                                //获取上传文件路径
                                string PathStr = Utils.GetMapPath(config.DataPath.ToString());
                                string fileExtension = "";
                                string fileName = "";
                                string thispath = DateTime.Now.Year + "-" + DateTime.Now.Month;
                                ArrayList filearr = new ArrayList();
                                int importdata_count = 0;
                                if (!Directory.Exists(PathStr + thispath))
                                {
                                    Directory.CreateDirectory(PathStr + thispath);
                                }

                                //上传文件
                                HttpFileCollection files = HttpContext.Current.Request.Files;
                                try
                                {
                                    if (files.Count > 0)
                                    {
                                        for (int i = 0; i < files.Count; i++)
                                        {
                                            HttpPostedFile postedFile = files[i];
                                            fileName = System.IO.Path.GetFileName(postedFile.FileName);
                                            if (Utils.ChkSQL(fileName) != "")
                                            {
                                                fileExtension = System.IO.Path.GetExtension(fileName).ToLower();
                                                if (fileExtension == ".xls")
                                                {
                                                    postedFile.SaveAs(PathStr + thispath + "/" + fileName);
                                                    filearr.Add(PathStr + thispath + "/" + fileName);
                                                }
                                                else
                                                {
                                                    AddErrLine("<b>文件格式错误,请将 Xls 文件用 Excel 另存后再导入!</b>:<br>");
                                                }
                                            }
                                        }
                                    }
                                    if (filearr.Count > 0)
                                    {
                                        storehouseproductsprice pi = new storehouseproductsprice();
                                        for (int j = 0; j < filearr.Count; j++)
                                        {
                                            DataSet ds = Excels.ExcelToDataTable(filearr[j].ToString());
                                            DataTable dt = new DataTable();
                                            try
                                            {
                                                dt = ds.Tables[0];
                                                foreach (DataRow dr in dt.Rows)
                                                {
                                                    if (dr[0].ToString().Trim() != "" && Utils.IsNumeric(dr[2].ToString().Trim()))
                                                    {
                                                        string pName = dr[0].ToString().Trim();//产品名称
                                                        decimal pPrice = decimal.Parse(dr[2].ToString().Trim());//产品单价
                                                        string pBarcode = Utils.ChkSQL(dr[1].ToString().Trim());//产品条码

                                                        if (pBarcode == "")
                                                        {
                                                            pBarcode = "null";
                                                            int proCode = Utils.StrToInt(storehouseStorage.SelectPcodeByName(pName), 0);//通过产品名称获得产品编号
                                                            int pbrCode = Utils.StrToInt(storehouseStorage.SelectpBarcodeByName(pBarcode).ToString(), 0);//通过产品条码获得产品编号

                                                            if (pbrCode > 0 || proCode > 0)
                                                            {
                                                                bool state = storehouseStorage.GetStorehouseProductPriceInfoList(StoresID, stNum, proCode, pName, pBarcode, pPrice, sDateTime);
                                                                if (state)
                                                                {
                                                                    AddErrLine("价格重复:产品条码[" + pBarcode + "];产品名称[" + pName + "]");
                                                                }
                                                                else if (pbrCode > 0)
                                                                {
                                                                    pi.StoresID = StoresID;
                                                                    pi.StoresName = sName;
                                                                    pi.StCode = stNum;
                                                                    pi.StName = "默认值";
                                                                    pi.ProductsID = pbrCode;
                                                                    pi.ProductsName = pName;
                                                                    pi.ProductsBarcode = pBarcode;
                                                                    pi.PPrice = pPrice;
                                                                    pi.PAppendTime = sDateTime;
                                                                    if (storehouseStorage.AddStorehouseStorageProductsPriceInfo(pi) > 0)
                                                                    {
                                                                        importdata_count++;
                                                                    }
                                                                }
                                                                else if (pbrCode == 0)
                                                                {
                                                                    pi.StoresID = StoresID;
                                                                    pi.StoresName = sName;
                                                                    pi.StCode = stNum;
                                                                    pi.StName = "默认值";
                                                                    pi.ProductsID = proCode;
                                                                    pi.ProductsName = pName;
                                                                    pi.ProductsBarcode = "null";
                                                                    pi.PPrice = pPrice;
                                                                    pi.PAppendTime = sDateTime;
                                                                    if (storehouseStorage.AddStorehouseStorageProductsPriceInfo(pi) > 0)
                                                                    {
                                                                        importdata_count++;
                                                                    }
                                                                }
                                                            }
                                                            else
                                                            {
                                                                AddMsgLine("该产品[" + pName + "];产品条码[" + pBarcode + "]库中不存在！");
                                                            }
                                                        }
                                                        else
                                                        {
                                                            int proCode = Utils.StrToInt(storehouseStorage.SelectPcodeByName(pName), 0);//通过产品名称获得产品编号
                                                            int pbrCode = Utils.StrToInt(storehouseStorage.SelectpBarcodeByName(pBarcode).ToString(), 0);//通过产品条码获得产品编号

                                                            if (pbrCode > 0 || proCode > 0)
                                                            {
                                                                bool state = storehouseStorage.GetStorehouseProductPriceInfoList(StoresID, stNum, pbrCode, pName, pBarcode, pPrice, sDateTime);
                                                                if (state)
                                                                {
                                                                    AddErrLine("价格重复:产品条码[" + pBarcode + "];产品名称[" + pName + "]");
                                                                }
                                                                else if (pbrCode > 0)
                                                                {
                                                                    pi.StoresID = StoresID;
                                                                    pi.StoresName = sName;
                                                                    pi.StCode = stNum;
                                                                    pi.StName = "默认值";
                                                                    pi.ProductsID = pbrCode;
                                                                    pi.ProductsName = pName;
                                                                    pi.ProductsBarcode = pBarcode;
                                                                    pi.PPrice = pPrice;
                                                                    pi.PAppendTime = sDateTime;
                                                                    if (storehouseStorage.AddStorehouseStorageProductsPriceInfo(pi) > 0)
                                                                    {
                                                                        importdata_count++;
                                                                    }
                                                                }
                                                                else if (pbrCode == 0)
                                                                {
                                                                    pi.StoresID = StoresID;
                                                                    pi.StoresName = sName;
                                                                    pi.StCode = stNum;
                                                                    pi.StName = "默认值";
                                                                    pi.ProductsID = proCode;
                                                                    pi.ProductsName = pName;
                                                                    pi.ProductsBarcode = "null";
                                                                    pi.PPrice = pPrice;
                                                                    pi.PAppendTime = sDateTime;
                                                                    if (storehouseStorage.AddStorehouseStorageProductsPriceInfo(pi) > 0)
                                                                    {
                                                                        importdata_count++;
                                                                    }
                                                                }
                                                            }
                                                            else
                                                            {
                                                                AddMsgLine("该产品[" + pName + "];产品条码[" + pBarcode + "]库中不存在！");
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                            catch (Exception ex)
                                            {
                                                AddErrLine(ex.Message);
                                            }
                                            finally
                                            {
                                                ds.Clear();
                                                ds.Dispose();
                                            }
                                        }

                                        if (importdata_count > 0)
                                        {
                                            AddMsgLine("数据导入成功!共导入数据[" + importdata_count.ToString() + "]条.");
                                            //AddScript("window.setTimeout('window.parent.HidBox();',1000);");
                                        }
                                        else
                                        {
                                            AddErrLine("系统忙!导入失败!");
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    AddErrLine("错误信息" + ex.Message);
                                }
                            }
                        }
                        else
                        {
                            AddMsgLine("该门店[" + sName + "]编号不存在！请确认后再次输入或先添加该门店！");
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
        }
        protected override void ShowPage()
        {
            pagetitle = "添加门店仓库库存";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}
