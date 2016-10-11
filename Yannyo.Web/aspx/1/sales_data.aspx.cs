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
    public partial class sales_data : PageBase
    {
        public DataTable ProductList = new DataTable();//产品列表
        public DataTable StoresList = new DataTable();//当前人员业务客户
        public string sDate = "";//发生时间
        public int StoresID = 0;//客户编号

        protected virtual void Page_Load(object sender, EventArgs e)
        {
            if (this.userid > 0)
            {
                if (CheckUserPopedoms("X") || CheckUserPopedoms("6-4"))
                {
                    if (ispost)
                    {
                        sDate = HTTPRequest.GetString("sDate");
                        StoresID = HTTPRequest.GetInt("StoresID", 0);
                        if (StoresID > 0)
                        {
                            if (sDate.Trim() != "")
                            {

                            }
                            else
                            {
                                AddErrLine("请填写发生时间.");
                            }
                        }
                        else
                        {
                            AddErrLine("请选择客户,门店.");
                        }
                    }
                    else
                    {
                        ProductList = tbProductsInfo.GetProductsInfoList(" 1=1 order by ProductClassID,ProductsID desc ").Tables[0];
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
            pagetitle = " 添加客户销售数据";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}