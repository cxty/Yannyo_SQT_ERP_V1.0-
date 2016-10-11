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
    public partial class products_importdata : PageBase
    {
        protected virtual void Page_Load(object sender, EventArgs e)
        {
            if (this.userid > 0)
            {
                if (CheckUserPopedoms("X") || CheckUserPopedoms("2-2-2") || CheckUserPopedoms("5-1"))
                {
                    if (ispost)
                    {
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
                                ProductsInfo pi = new ProductsInfo();
                                try
                                {
                                    for (int j = 0; j < filearr.Count; j++)
                                    {
                                        try
                                        {
                                            DataSet ds = Excels.ExcelToDataTable(filearr[j].ToString());
                                            DataTable dt = new DataTable();
                                            try
                                            {
                                                dt = ds.Tables[0];
                                                foreach (DataRow dr in dt.Rows)
                                                {
                                                    if (dr[1].ToString() != "" && dr[3].ToString() != "" && dr[4].ToString() != "" && dr[5].ToString() != "" && dr[6].ToString() != "" )
                                                    {
                                                        if (Utils.IsInt(dr[5].ToString()))
                                                        {
                                                            pi = tbProductsInfo.GetProductsInfoModelByName(dr[1].ToString());
                                                            if (pi == null)
                                                            {
                                                                pi = new ProductsInfo();

                                                                pi.pName = dr[1].ToString();
                                                                pi.pBarcode = dr[0].ToString();
                                                                pi.pBrand = dr[2].ToString();
                                                                pi.pStandard = dr[3].ToString();
                                                                pi.pUnits = dr[4].ToString();
                                                                pi.pToBoxNo = Utils.StrToInt(dr[5].ToString(), 0);
                                                                pi.pPrice = decimal.Parse(Utils.StrToFloat(dr[6].ToString(), 0).ToString());
                                                                pi.pState = 0;
                                                                pi.pAppendTime = DateTime.Now;
                                                                pi.pCode = "";
                                                                if (tbProductsInfo.AddProductsInfo(pi) > 0)
                                                                {
                                                                    importdata_count++;
                                                                }
                                                            }
                                                            else
                                                            {
                                                                pi.pBarcode = dr[0].ToString();
                                                                pi.pBrand = dr[2].ToString();
                                                                pi.pStandard = dr[3].ToString();
                                                                pi.pUnits = dr[4].ToString();
                                                                pi.pToBoxNo = Utils.StrToInt(dr[5].ToString(), 0);
                                                                pi.pPrice = decimal.Parse(Utils.StrToFloat(dr[6].ToString(), 0).ToString());

                                                                try
                                                                {
                                                                    tbProductsInfo.UpdateProductsInfo(pi);
                                                                    importdata_count++;
                                                                }
                                                                catch
                                                                {

                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                            finally
                                            {
                                                ds.Clear();
                                                ds.Dispose();
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            AddErrLine("<b>文件格式错误,请将 Xls 文件用 Excel 另存后再导入!</b>:<br>" + ex);
                                            //AddScript("window.setTimeout('history.back(1);',5000);");
                                        }
                                    }
                                    if (importdata_count > 0)
                                    {
                                        AddMsgLine("数据导入成功!共导入数据[" + importdata_count.ToString() + "]条.");
                                        AddScript("window.setTimeout('window.parent.HidBox();',5000);");
                                    }
                                    else
                                    {
                                        AddErrLine("系统忙!导入失败!");
                                        //AddScript("window.setTimeout('history.back(1);',1000);");
                                    }
                                }
                                finally
                                {
                                    pi = null;
                                }
                            }
                            else
                            {
                                AddErrLine("为发现任何数据!导入失败!");
                                AddScript("window.setTimeout('history.back(1);',1000);");
                            }
                        }
                        finally
                        {
                            files = null;
                            filearr.Clear();
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
            pagetitle = " 导入产品信息";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}
