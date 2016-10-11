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
using System.IO;
using System.Data.OleDb;

using Yannyo.Config;
using Yannyo.Common;
using Yannyo.Entity;
using Yannyo.BLL;
using Yannyo.Public;

namespace Yannyo.Web
{
    public partial class importdata : PageBase
    {
        public DataTable dList = new DataTable();
        public int steps = 1;
        public DateTime sDateTime;
        public string tJson = "";
        public string format = "";
        public string act = "";
        protected virtual void Page_Load(object sender, EventArgs e)
        {
            if (this.userid > 0)
            {
                if (CheckUserPopedoms("X") || CheckUserPopedoms("3-4-1"))
                {
                    steps = HTTPRequest.GetInt("steps", 1);
                    format = HTTPRequest.GetString("format");
                    act = HTTPRequest.GetString("act");
                    if (ispost)
                    {
                        string PathStr = Utils.GetMapPath(config.DataPath.ToString());
                        string fileExtension = "";
                        string fileName = "";
                        string thispath = DateTime.Now.Year + "-" + DateTime.Now.Month;
                        ArrayList filearr = new ArrayList();
                        int importdata_count = 0;
                        string tSName = "";
                        int sDateTime_S = Utils.StrToInt(HTTPRequest.GetString("sDateTime_S"), 0);

                        sDateTime = Utils.IsDateString(Utils.ChkSQL(HTTPRequest.GetString("sDateTime"))) ? DateTime.Parse(Utils.ChkSQL(HTTPRequest.GetString("sDateTime"))) : DateTime.Now;

                        if (!Directory.Exists(PathStr + thispath))
                        {
                            Directory.CreateDirectory(PathStr + thispath);
                        }
                        if (steps == 1)
                        {
                            try
                            {
                                //文件上传
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
                                            }
                                        }
                                    }
                                    if (filearr.Count > 0)
                                    {
                                        for (int j = 0; j < filearr.Count; j++)
                                        {
                                            DataSet ds = Excels.ExcelToDataTable(filearr[j].ToString());
                                            try
                                            {
                                                dList = ds.Tables[0];
                                                dList.Rows[0].Delete();
                                                dList.AcceptChanges();
                                                steps = 2;
                                                break;
                                            }
                                            finally {
                                                ds = null;
                                            }
                                        }
                                    }
                                }
                                finally
                                {
                                    files = null;
                                    filearr.Clear();
                                }
                            }
                            catch (Exception ex)
                            {
                                AddErrLine("<b>文件格式错误,请将 Xls 文件用 Excel 另存后再导入!</b>:<br>" + ex);
                                AddScript("window.setTimeout('history.back(1);',5000);");
                            }
                        }
                        if (format == "Json")
                        {
                            if (steps == 2)
                            {
                                if (act == "add")
                                {
                                    string sStoresID = Utils.ChkSQL(HTTPRequest.GetString("sStoresID")).Trim();
                                    string sStoresName = Utils.ChkSQL(HTTPRequest.GetString("sStoresName")).Trim();
                                    string pBarcode = Utils.ChkSQL(HTTPRequest.GetString("pBarcode")).Trim();
                                    string sProductsName = Utils.ChkSQL(HTTPRequest.GetString("sProductsName")).Trim();
                                    string sNum = Utils.ChkSQL(HTTPRequest.GetString("sNum")).Trim();
                                    string sPrice = Utils.ChkSQL(HTTPRequest.GetString("sPrice")).Trim();
                                    string tID = Utils.ChkSQL(HTTPRequest.GetString("tID")).Trim();

                                    tJson = ",\"tID\":\"" + tID + "\"";

                                    SalesInfo si = new SalesInfo();
                                    StoresInfo so = new StoresInfo();
                                    ProductsInfo pi = new ProductsInfo();
                                    try
                                    {
                                        si.sDateTime = sDateTime;
                                        si.sAppendTime = DateTime.Now;
                                        sStoresName = Utils.ReplaceString(Utils.ReplaceString(sStoresName.ToString().Trim(), "(", "（", false), ")", "）", false);
                                        so = tbStoresInfo.GetStoresInfoModelByName(sStoresName);

                                        if (so == null)
                                        {
                                            so = tbStoresInfo.GetStoresInfoModelByCode(sStoresID.ToString().Trim());
                                        }
                                        pi = tbProductsInfo.GetProductsInfoModelByName(sProductsName.ToString().Trim());

                                        if (pi == null)
                                        {
                                            pi = tbProductsInfo.GetProductsInfoModelByBarcode(pBarcode.ToString().Trim());
                                        }
                                        if (so != null)
                                        {
                                            si.StoresID = so.StoresID;
                                            si.StoresName = so.sName;
                                        }
                                        else
                                        {
                                            si.StoresID = 0;
                                            si.StoresName = sStoresName;
                                        }
                                        if (pi != null)
                                        {
                                            si.ProductsID = pi.ProductsID;
                                            si.ProductsName = pi.pName;
                                        }
                                        else
                                        {
                                            si.ProductsID = 0;
                                            si.ProductsName = sProductsName;
                                        }
                                        si.sStoresID = sStoresID;
                                        si.sNum = int.Parse(Utils.StrToFloat(sNum, 0).ToString());

                                        if (sPrice.ToString().IndexOf(",") > -1)
                                        {
                                            si.sPrice = decimal.Parse(sPrice.ToString().Replace(",", ""));
                                        }
                                        else
                                        {
                                            si.sPrice = decimal.Parse(sPrice.ToString());
                                        }
                                        si.sIsYH = 1;
                                        int sID = tbSalesInfo.AddSalesInfo(si);
                                        if (sID > 0)
                                        {
                                            tJson += ",\"sID\":\"" + sID + "\"";
                                            AddMsgLine("添加成功!");
                                        }
                                        else
                                        {
                                            AddErrLine("添加失败!");
                                        }
                                    }
                                    finally
                                    {
                                        si = null;
                                        so = null;
                                        pi = null;
                                    }
                                }
                                if (act == "del")
                                {
                                    try
                                    {
                                        string sIdStr = HTTPRequest.GetString("sIDStr");
                                        sIdStr = Utils.ReSQLSetTxt(sIdStr);
                                        if (sIdStr.Trim() != "")
                                        {
                                            tbSalesInfo.DeleteSalesInfo(sIdStr, sDateTime);
                                        }
                                        AddMsgLine("撤销成功!") ;
                                    }
                                    catch(Exception ex) {
                                        AddErrLine("撤销失败!");
                                    }
                                }

                                Response.ClearContent();
                                Response.Buffer = true;
                                Response.ExpiresAbsolute = System.DateTime.Now.AddYears(-1);
                                Response.Expires = 0;

                                Response.Charset = "utf-8";
                                Response.ContentEncoding = System.Text.Encoding.GetEncoding("utf-8");
                                Response.ContentType = "application/json";
                                string Json_Str = "{\"results\": {\"msg\":\"" + this.msgbox_text + "\",\"state\":\"" + (!IsErr()).ToString() + "\"" + tJson + "}}";
                                Response.Write(Json_Str);
                                Response.End();

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
            pagetitle = "数据导入";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}
