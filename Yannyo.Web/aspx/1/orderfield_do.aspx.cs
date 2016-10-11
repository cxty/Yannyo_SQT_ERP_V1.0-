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
    public partial class orderfield_do : PageBase
    {
        public OrderFieldInfo oi = new OrderFieldInfo();
        public string Act = "";
        public int OrderFieldID = 0;
        public int OrderType = 0;
        public string fName = "";
        public int fType = 0;
        public int fState = 0;
        public int fPrint = 0;
        public int fPrintAdd = 0;
        public string fProductField = "";

        public DataTable Order_Type = new DataTable();
        public DataTable OrderFieldTypes = new DataTable();

        protected virtual void Page_Load(object sender, EventArgs e)
        {
            if (this.userid > 0)
            {
                if (CheckUserPopedoms("X") || CheckUserPopedoms("2-1-7"))
                {
                    Act = HTTPRequest.GetString("Act");
                    if (Act == "Edit")
                    {
                        OrderFieldID = Utils.StrToInt(HTTPRequest.GetString("oid"), 0);

                        oi = Orders.GetOrderFieldInfoModel(OrderFieldID);
                    }
                    if (ispost)
                    {
                        fName = Utils.ChkSQL(HTTPRequest.GetString("fName"));
                        OrderType = Utils.StrToInt(Utils.ChkSQL(HTTPRequest.GetString("OrderType")), 0);
                        fType = Utils.StrToInt(Utils.ChkSQL(HTTPRequest.GetString("fType")), 0);
                        fState = HTTPRequest.GetString("fState").Trim() != "" ? Utils.StrToInt(HTTPRequest.GetString("fState"), 0) : 1;
                        fPrint = HTTPRequest.GetString("fPrint").Trim() != "" ? Utils.StrToInt(HTTPRequest.GetString("fPrint"), 0) : 1;
                        fPrintAdd = HTTPRequest.GetString("fPrintAdd").Trim() != "" ? Utils.StrToInt(HTTPRequest.GetString("fPrintAdd"), 0) : 1;
                        fProductField = Utils.ChkSQL(HTTPRequest.GetString("fProductField"));

                        oi.OrderType = OrderType;
                        oi.fType = fType;
                        oi.fState = fState;
                        oi.fPrint = fPrint;
                        oi.fPrintAdd = fPrintAdd;
                        oi.fProductField = fProductField;

                        if (Act == "Add")
                        {
                            oi.fName = fName;

                            if (!Orders.ExistsOrderFieldInfo(OrderType, fName))
                            {
                                if (Orders.AddOrderFieldInfo(oi) > 0)
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
                            else
                            {
                                AddErrLine("字段:" + fName + ",已存在,请更换!");
                                AddScript("window.setTimeout('history.back(1);',1000);");
                            }
                        }
                        if (Act == "Edit")
                        {
                            if (oi.fName != fName)
                            {
                                if (Orders.ExistsOrderFieldInfo(OrderType, fName))
                                {
                                    AddErrLine("字段:" + fName + ",已存在,请更换!");
                                    AddScript("window.setTimeout('history.back(1);',1000);");
                                }
                            }
                            if (!IsErr())
                            {
                                try
                                {
                                    oi.fName = fName;

                                    Orders.UpdateOrderFieldInfo(oi);
                                    AddMsgLine("修改成功!");
                                    AddScript("window.setTimeout('window.parent.HidBox();',1000);");
                                }
                                catch (Exception ex)
                                {
                                    AddErrLine("修改失败!<br/>" + ex);
                                    AddScript("window.setTimeout('window.parent.HidBox();',5000);");
                                }
                            }
                        }
                    }
                    else
                    {
                        if (Act == "Del")
                        {
                            try
                            {
                                Orders.DeleteOrderFieldInfo(HTTPRequest.GetString("oid"));
                                AddMsgLine("删除成功!");
                                AddScript("window.setTimeout('window.parent.HidBox();',2000);");
                            }
                            catch (Exception ex)
                            {
                                AddErrLine("创建失败!<br/>" + ex);
                                AddScript("window.setTimeout('window.parent.HidBox();',5000);");
                            }
                        }
                        else
                        {
                            Order_Type = Orders.GetOrder_Type();
                            OrderFieldTypes = Orders.GetOrderFieldTypes();
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
            pagetitle = " 添加修改单据自定义字段信息";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}