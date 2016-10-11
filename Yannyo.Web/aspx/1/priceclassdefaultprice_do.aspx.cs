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
    public partial class priceclassdefaultprice_do : PageBase
    {
        public ProductsInfo pi = new ProductsInfo();
        public DataTable dList = new DataTable();
        public string Act = "";
        public int ProductsID = 0;
        public string pPrice = "";//pcid,price;...
        public string pIsEdit = "";
        protected virtual void Page_Load(object sender, EventArgs e)
        {
            if (this.userid > 0)
            {
                if (CheckUserPopedoms("X") || CheckUserPopedoms("2-3-3"))
                {
                    Act = HTTPRequest.GetString("Act");
                    ProductsID = HTTPRequest.GetInt("pid", 0);
                    if (Act == "List")
                    {
                        pi = tbProductsInfo.GetProductsInfoModel(ProductsID);
                        dList = tbProductsInfo.GetProductsPriceClassPriceList(ProductsID);
                    }
                    if (Act == "Save")
                    {
                        try
                        {
                            pPrice = Utils.ChkSQL(HTTPRequest.GetString("pPrice"));
                            //pIsEdit = Utils.ChkSQL(HTTPRequest.GetString("pIsEdit"));

                            string[] pPriceArray = Utils.SplitString(pPrice, ";");
                            //string[] pIsEditArray = Utils.SplitString(pIsEdit, ";");
                            foreach (string pArray in pPriceArray)
                            {
                                string[] pp = Utils.SplitString(pArray, ",");
                                if (pp.Length > 0)
                                {
                                    if (pp[0].ToString().Trim() != "" && pp[1].ToString().Trim() != "" && pp[2].ToString().Trim() != "")
                                    {
                                        tbPriceClassDefaultPriceInfo.SavePriceClassDefaultPrice(Convert.ToInt32(pp[0].ToString().Trim()), ProductsID, Convert.ToDecimal(pp[1].ToString().Trim()), Convert.ToInt32(pp[2].ToString().Trim()));
                                    }
                                }
                                pp = null;
                            }
                            AddMsgLine("保存成功!");
                            AddScript("window.setTimeout('window.parent.HidBox();',1000);");
                        }
                        catch (Exception ex)
                        {
                            AddErrLine("保存失败!<br/>" + ex);
                            AddScript("window.setTimeout('window.parent.HidBox();',5000);");
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
            pagetitle = " 添加修改价格类型默认价格";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}