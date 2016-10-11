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
    public partial class products_beginning_do : PageBase
    {
        public ProductsInfo pi = new ProductsInfo();
        public string Act = "";
        public int ProductsID = 0;
        public decimal pDoDayQuantity = 0;
        public DataTable StorageList = new DataTable();

        protected virtual void Page_Load(object sender, EventArgs e)
        {
            if (this.userid > 0)
            {
                if (CheckUserPopedoms("X") || CheckUserPopedoms("2-4-3"))
                {
                    Act = HTTPRequest.GetString("Act");
                    if (Act == "Edit")
                    {
                        ProductsID = Utils.StrToInt(HTTPRequest.GetString("pid"), 0);

                        pi = tbProductsInfo.GetProductsInfoModel(ProductsID);
                    }
                    if (ispost)
                    {
                        if (Act == "Edit")
                        {
                            try
                            {
                                int loop = HTTPRequest.GetInt("loop",0);
                                int StorageID = 0;
                                decimal pQuantity = 0;
                                if (loop > 0)
                                {
                                    for (int i = 0; i <= loop; i++)
                                    {
                                        StorageID = HTTPRequest.GetInt("StorageID_" + i, 0);
                                        if (StorageID > 0)
                                        {
                                            pQuantity = (HTTPRequest.GetString("Quantity_" + i).Trim() != "") ? decimal.Parse(Utils.ChkSQL(HTTPRequest.GetString("Quantity_" + i))) : 0; 
                                            tbProductsInfo.UpdateProductsBeginningStorage(StorageID, ProductsID, pQuantity);
                                        }
                                    }
                                    AddMsgLine("修改成功!");
                                    AddScript("window.setTimeout('window.parent.HidBox();',1000);");
                                }
                            }
                            catch (Exception ex)
                            {
                                AddErrLine("修改失败!<br/>" + ex);
                                AddScript("window.setTimeout('window.parent.HidBox();',5000);");
                            }
                        }

                    }
                    else
                    {
                        StorageList = tbStorageInfo.GetStorageInfoList("").Tables[0];
                        if (StorageList != null)
                        {
                            StorageList.Columns.Add("Quantity", Type.GetType("System.Decimal"));
                            DataTable dt = new DataTable();
                            dt = tbProductsInfo.GetProductsStorageLogList(" ProductsID=" + ProductsID + " and pType=-1 and pState=0").Tables[0];
                            if (dt != null)
                            {
                                foreach (DataRow dr in dt.Rows)
                                {
                                    foreach (DataRow drr in StorageList.Rows)
                                    {
                                        if (dr["StorageID"].ToString() == drr["StorageID"].ToString())
                                        {
                                            drr["Quantity"] = dr["pQuantity"];
                                        }
                                    }
                                }
                            }
                            StorageList.AcceptChanges();
                        }
                    }
                }
                else
                {
                    AddErrLine("权限不足!");
                    AddScript("window.setTimeout('window.parent.HidBox();',2000);");
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
            pagetitle = " 产品期初库存信息";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}