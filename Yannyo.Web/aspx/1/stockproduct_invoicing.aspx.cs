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

namespace Yannyo.Web
{
    public partial class stockproduct_invoicing : PageBase
    {
        public DataTable dList = new DataTable();
        public string sDate = "";
        public int ProductsID = 0;//商品编号
        public int StorageID = 0;//仓库编号
        public DataTable StorageList = new DataTable();
        public string tJson = "";
        public string format = "";
        public string act = "";

        protected virtual void Page_Load(object sender, EventArgs e)
        {
            if (this.userid > 0)
            {
                if (CheckUserPopedoms("X") || CheckUserPopedoms("7-2-1-5-1"))
                {
                    StorageList = tbStorageInfo.GetStorageInfoList("").Tables[0];
                    sDate = HTTPRequest.GetString("sDate").Trim();
                    ProductsID = HTTPRequest.GetInt("ProductsID", 0);
                    StorageID = HTTPRequest.GetInt("StorageID", 0);

                    format = HTTPRequest.GetString("format");
                    act = HTTPRequest.GetString("act");

                    if (ispost)
                    {
                        if (act == "")
                        {
                            dList = Orders.GetReportInvoicingDataInfoList(StorageID, ProductsID, Convert.ToDateTime(sDate), 0);
                        }
                        if(act == "reset")
                        {
                            if (Utils.IsDateString(sDate))
                            {
                                if (Orders.ReSetInvoicingData(DateTime.Parse(sDate)))
                                {
                                    AddMsgLine("重置成功!");
                                }
                                else {
                                    AddErrLine("重置失败!");
                                }
                            }
                            else
                            {
                                AddErrLine("请选择时间点.");
                            }
                        }
                        if (act == "update")
                        {
                            int ReportInvoicingID = HTTPRequest.GetInt("ReportInvoicingID", 0);
                            decimal eQuantity = 0;
                            decimal Price = 0;
                            decimal eMoney = 0;
                            decimal bQuantity = 0;
                            decimal bMoney = 0;
                            decimal InQuantity = 0;
                            decimal InMoney = 0;
                            decimal OutQuantity = 0;
                            decimal OutMoney = 0;
                            tJson = ",\"ReportInvoicingID\":\"" + ReportInvoicingID + "\"";
                            try
                            {
                                 eQuantity = Convert.ToDecimal(HTTPRequest.GetString("eQuantity"));
                                 Price = Convert.ToDecimal(HTTPRequest.GetString("Price"));
                                 eMoney = Convert.ToDecimal(HTTPRequest.GetString("eMoney"));

                                 bQuantity = Convert.ToDecimal(HTTPRequest.GetString("bQuantity"));
                                 bMoney = Convert.ToDecimal(HTTPRequest.GetString("bMoney"));
                                 InQuantity = Convert.ToDecimal(HTTPRequest.GetString("InQuantity"));
                                 InMoney = Convert.ToDecimal(HTTPRequest.GetString("InMoney"));
                                 OutQuantity = Convert.ToDecimal(HTTPRequest.GetString("OutQuantity"));
                                 OutMoney = Convert.ToDecimal(HTTPRequest.GetString("OutMoney"));


                                 if (Orders.UpdateReportInvoicingDataInfoByEndData(eQuantity, eMoney, bQuantity, bMoney, InQuantity, InMoney, OutQuantity, OutMoney,ReportInvoicingID))
                                 {
                                     AddMsgLine("修改成功!");
                                 }
                                 else {
                                     AddErrLine("修改失败!");
                                 }
                            }
                            catch
                            {
                                AddErrLine("数据格式错误!请重试!");
                            }

                            if (!IsErr())
                            {
                                if (ReportInvoicingID > 0)
                                {
                                    
                                }
                                else
                                {
                                    AddErrLine("参数错误,请传入进销存数据编号!");
                                }
                            }

                        }
                    }
                    if (format == "Json")
                    {
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
                else
                {
                    AddErrLine("权限不足!");
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
            pagetitle = config.CompanyName + " 产品进销存数据调整";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}