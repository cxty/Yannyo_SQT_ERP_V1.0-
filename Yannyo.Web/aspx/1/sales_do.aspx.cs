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
    public partial class sales_do : PageBase
    {
        public SalesInfo si = new SalesInfo();
        public string Act = "";
        public int SalesID = 0;
        public int StoresID = 0;
        public int ProductsID = 0;
        public int sNum = 0;
        public decimal sPrice = 0;
        
        public DateTime sDateTime = DateTime.Now;
        public DateTime sAppendTime = DateTime.Now;

        protected virtual void Page_Load(object sender, EventArgs e)
        {
            if (this.userid > 0)
            {
                if (CheckUserPopedoms("X") || CheckUserPopedoms("3-4-1"))
                {
                    Act = HTTPRequest.GetString("Act");
                    if (Act == "Edit")
                    {
                        SalesID = Utils.StrToInt(HTTPRequest.GetString("sid"), 0);

                        si = tbSalesInfo.GetSalesInfoModel(SalesID);
                    }
                    if (ispost)
                    {
                        StoresID = Utils.StrToInt(Utils.ChkSQL(HTTPRequest.GetString("StoresID")), 0);
                        ProductsID = Utils.StrToInt(Utils.ChkSQL(HTTPRequest.GetString("ProductsID")), 0);
                        sNum = Utils.StrToInt(Utils.ChkSQL(HTTPRequest.GetString("sNum")), 0);
                        sPrice = HTTPRequest.GetString("sPrice").Trim()!="" ?decimal.Parse(Utils.ChkSQL(HTTPRequest.GetString("sPrice"))):0;
                        
                        sDateTime = Utils.IsDateString(Utils.ChkSQL(HTTPRequest.GetString("sDateTime"))) ? DateTime.Parse(Utils.ChkSQL(HTTPRequest.GetString("sDateTime"))) : DateTime.Now;

                        si.StoresID = StoresID;
                        si.ProductsID = ProductsID;
                        si.sNum = sNum;
                        si.sPrice = sPrice;
                        
                        si.sDateTime = sDateTime;

                        if (StoresID > 0)
                        {
                            if (ProductsID > 0)
                            {
                                if (Act == "Add")
                                {
                                    si.sAppendTime = sAppendTime;
                                    if (tbSalesInfo.AddSalesInfo(si) > 0)
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
                                if (Act == "Edit")
                                {
                                    try
                                    {
                                        tbSalesInfo.UpdateSalesInfo(si);
                                        AddMsgLine("修改成功!");
                                        AddScript("window.setTimeout('window.parent.HidBox();',1000);");
                                    }
                                    catch (Exception ex)
                                    {
                                        AddErrLine("修改失败!<br/>" + ex);
                                        AddScript("window.setTimeout('window.parent.HidBox();',1000);");
                                    }
                                }
                            }
                            else
                            {
                                AddErrLine("产品不能为空!");
                                AddScript("window.setTimeout('history.back(1);',1000);");
                            }
                        }
                        else
                        {
                            AddErrLine("门店不能为空!");
                            AddScript("window.setTimeout('history.back(1);',1000);");
                        }
                    }
                    else
                    {
                        if (Act == "Del")
                        {
                            try
                            {
                                tbSalesInfo.DeleteSalesInfo(HTTPRequest.GetString("sid"));
                                AddMsgLine("删除成功!");
                                AddScript("window.setTimeout('window.parent.HidBox();',1000);");
                            }
                            catch (Exception ex)
                            {
                                AddErrLine("删除失败!<br/>" + ex);
                                AddScript("window.setTimeout('window.parent.HidBox();',1000);");
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
            pagetitle = " 添加修改销售信息";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}
